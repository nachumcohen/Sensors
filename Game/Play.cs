using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;
using TheInvestingationGame.Sensors;

namespace TheInvestingationGame
{
    internal class Play
    {
        //internal static bool IsWin1;
        //internal static bool IsWin2;
        //internal static bool IsWin3;
        //internal static bool IsWin4;

        static List<ISensor> Sensors;
        static bool IsExit = false;


        
        public static async Task StartAgentBasic(PlayerData playerData)
        {
            Console.WriteLine(playerData.LevelAgent);
            AgentBasic agent = new AgentBasic();
            Sensors = new List<ISensor>();

            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                await Logic(agent, playerData);
                if (IsExit)
                {
                    return;
                }
            }

            Win(playerData, agent);
            //IsWin1 = true;

        }

        public static async Task StartAgentSquadLeader(PlayerData playerData)
        {
            if (playerData.LevelAgent < 1)
            {
                Console.WriteLine("Completed first stage");
                return;
            }

            Squad_Leader agent = new Squad_Leader();
            Sensors = new List<ISensor>();
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                await Logic(agent, playerData);
                if (IsExit)
                {
                    return;
                }
                if (agent.ReturnNumAttack() % 3 == 0)
                {
                    agent.RemoveSensor();
                }
                
            }
            Win(playerData, agent);
            //IsWin2 = true;

        }

        public static async Task StartAgentSeniorCommander(PlayerData playerData)
        {
            if (playerData.LevelAgent < 2)
            {
                Console.WriteLine("Completed first stage");
                return;
            }
            SeniorCommander agent = new SeniorCommander();

            Sensors = new List<ISensor>();
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                await Logic (agent, playerData);
                if (IsExit)
                {
                    return;
                }
                
                if (agent.ReturnNumAttack() % 3 == 0)
                {
                    agent.RemoveTowSensors();
                }
                
            }

            Win(playerData, agent);

            //IsWin3 = true;
            
        }
        public static async Task StartAgentOrganizationLeader(PlayerData playerData)
        {
            if (playerData.LevelAgent < 3)
            {
                Console.WriteLine("Completed first stage");
                return;
            }

            OrganizationLeader agent = new OrganizationLeader();
            Sensors = new List<ISensor>();
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                await Logic(agent , playerData);
                if (IsExit)
                {
                    return;
                }
                if (agent.ReturnNumAttack() % 3 == 0)
                {
                    agent.RemoveSensor();
                }
                
                
            }

            Win(playerData, agent);

            //IsWin4 = true;
        }


        public static async Task Logic(Agent agent , PlayerData playerData)
        {
            ISensor Sensor;
            string TypeSensor = "";

            var StopWatch = Stopwatch.StartNew();

            while (StopWatch.ElapsedMilliseconds <= 15000)
            {
                int Delay = 15000 - (int)StopWatch.ElapsedMilliseconds;
                Console.WriteLine($"Remauning time {Delay / 1000} seconds");

                string StringSensors = string.Join(" or ", ListSensor.ReturnList());
                Console.WriteLine($"enter sensor: {StringSensors} or exit");

                var input = Task.Run(() => Console.ReadLine());
                var timeout = Task.Delay(Delay);

                var completed = await Task.WhenAny(input, timeout);
                if (completed == input)
                {
                    TypeSensor = input.Result;

                    if (TypeSensor.ToLower() == "exit")
                    {
                        IsExit = true;
                        return;
                    }
                    else if (ListSensor.ReturnList().Contains(TypeSensor))
                    {
                        IsExit= false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"enter only {StringSensors} or exit");
                    }

                }
                else
                {
                    Console.WriteLine("Time is up");
                    agent.AddNumAttack();
                    return;
                }
            }

            Sensor = Sensors.FirstOrDefault(s => s.Type == TypeSensor);
            if (Sensor == null)
            {
                Type type = Type.GetType($"TheInvestingationGame.Sensors.{TypeSensor}");
                Sensor = (ISensor)Activator.CreateInstance(type);
                Sensors.Add(Sensor);
            }
            bool isAdd =  Sensor.Activate(agent);
            if (isAdd)
            {
                agent.AddExposureSensor(Sensor);
                Sensors.Remove(Sensor);
            }
            else if (!isAdd)
            {
                agent.AddNumMistake();
            }

            agent.AddNumAttack();

            int NumMistake = agent.ReturnNumMistake();
            if (NumMistake % 10 == 0 && NumMistake != 0)
            {
                agent.ResetDictSensorsAndListExposureSensor();
                
                Loss(playerData, agent);
                IsExit = true;

            }
        }

        private static void Loss(PlayerData playerData , Agent agent)
        {
            playerData.Status = Status.Loss;
            playerData.LevelAgent = agent.GetLevelAgent();
            playerData.NumMistake = 10;
            playerData.MountTurns = agent.ReturnNumAttack();
            playerData.Score = playerData.GetScore();

            Console.WriteLine("********************************************");
            Console.WriteLine("********************************************");
            Console.WriteLine("**                                        **");
            Console.WriteLine("**               GAME OVER                **");
            Console.WriteLine("**                                        **");
            Console.WriteLine("********************************************");
            Console.WriteLine("********************************************");

            Console.WriteLine(playerData.ToString());
        }

        static void Win(PlayerData playerData , Agent agent)
        {
            playerData.Status = Status.Win;
            playerData.LevelAgent = agent.GetLevelAgent();
            playerData.NumMistake = agent.ReturnNumMistake();
            playerData.MountTurns = agent.ReturnNumAttack();
            playerData.Score = playerData.GetScore();

            Console.WriteLine("********************************************");
            Console.WriteLine("********************************************");
            Console.WriteLine("**                                        **");
            Console.WriteLine("**                 WIN                    **");
            Console.WriteLine("**                                        **");
            Console.WriteLine("********************************************");
            Console.WriteLine("********************************************");

            Console.WriteLine(playerData.ToString());
        }
    }
}
