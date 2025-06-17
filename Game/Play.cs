using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;
using TheInvestingationGame.Sensors;

namespace TheInvestingationGame
{
    internal static class Play
    {
        static bool IsWin1 = false;
        static bool IsWin2 = false;
        static bool IsWin3 = false;
        static bool IsWin4 = false;

        static List<ISensor> Sensors;
        public static void StartAgentBasic()
        {
            AgentBasic agent = new AgentBasic();
            Sensors = new List<ISensor>();
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                Logic(agent);
            }
            Console.WriteLine($"Num turns {agent.ReturnNumAttack()}");
            IsWin1 = true;

        }

        public static void StartAgentSquadLeader()
        {
            if (!IsWin1)
            {
                Console.WriteLine("Completed first stage");
                return;
            }
            Squad_Leader agent = new Squad_Leader();
            Sensors = new List<ISensor>();
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                Logic(agent);

                if (agent.ReturnNumAttack() % 3 == 0)
                {
                    agent.RemoveSensor();
                }
            }
            Console.WriteLine($"Num turns {agent.ReturnNumAttack()}");
            IsWin2 = true;

        }

        public static void StartAgentOrganizationLeader()
        {
            if (!IsWin2)
            {
                Console.WriteLine("Completed first stage");
                return;
            }

            OrganizationLeader agent = new OrganizationLeader();
            Sensors = new List<ISensor>();
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                Logic(agent);
                if (agent.ReturnNumAttack() % 3 == 0)
                {
                    agent.RemoveSensor();
                }
                if (agent.ReturnNumAttack() % 15 == 0)
                {
                    agent.ResetDictSensorsAndListExposureSensor();
                }
            }
            Console.WriteLine($"Num turns {agent.ReturnNumAttack()}");
            IsWin3 = true;
        }

        public static void StartAgentSeniorCommander()
        {
            if (!IsWin3)
            {
                Console.WriteLine("Completed first stage");
                return;
            }
            SeniorCommander agent = new SeniorCommander();

            Sensors = new List<ISensor>();
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                Logic (agent);
                if (agent.ReturnNumAttack() % 3 == 0)
                {
                    agent.RemoveTowSensors();
                }
            }
            Console.WriteLine($"Num turns {agent.ReturnNumAttack()}");
            IsWin4 = true;
            
        }

        public static void Logic(Agent agent)
        {
            ISensor Sensor;
            string TypeSensor;
            while (true)
            {
                string StringSensors = string.Join(" or ", ListSensor.ReturnList());
                Console.WriteLine($"enter sensor: {StringSensors}");
                TypeSensor = Console.ReadLine();
                if (ListSensor.ReturnList().Contains(TypeSensor))
                {
                    break;
                }
                Console.WriteLine($"enter only {StringSensors}");
            }

            Sensor = Sensors.FirstOrDefault(s => s.Type == TypeSensor);
            if (Sensor == null)
            {
                Type type = Type.GetType($"TheInvestingationGame.Sensors.{TypeSensor}");
                Sensor = (ISensor)Activator.CreateInstance(type);
                Sensors.Add(Sensor);
            }

            Sensor.Activate(agent);
            agent.AddNumAttack();


        }
    }
}
