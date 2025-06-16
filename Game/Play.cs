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
        public static void StartAgentBasic()
        {
            Console.WriteLine("enter Name");
            string Name = Console.ReadLine();
            Agent agent = new AgentBasic(Name);
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                string sensor;
                while (true)
                {
                    Console.WriteLine("enter basic sensor: Thermal or Cellular");
                    sensor = Console.ReadLine();
                    if (sensor == "Thermal" || sensor == "Cellular")
                    {
                        break;
                    }
                    Console.WriteLine("enter only Thermal or Cellular");
                }
                SensorBasic sensorBasic = new SensorBasic(sensor);
                sensorBasic.Activate(agent);
                agent.AddNumAttack();
            }
            Console.WriteLine($"Num turns {agent.ReturnNumAttack()}");

        }

        public static void StartAgentSquadLeader()
        {
            Console.WriteLine("enter Name");
            string Name = Console.ReadLine();
            Squad_Leader agent = new Squad_Leader(Name);
            while (agent.NumGuessing() < agent.GetSensorCount())
            {
                string sensorName;
                while (true)
                {
                    Console.WriteLine("enter basic sensor: Thermal or Cellular or Traffic or Distance");
                    sensorName = Console.ReadLine();
                    if (sensorName == "Thermal" || sensorName == "Cellular" || sensorName == "Traffic" || sensorName == "Distance")
                    {
                        break;
                    }
                    Console.WriteLine("enter only Thermal or Cellular or Traffic or Distance");
                }
                SensorBasic sensorBasic = new SensorBasic(sensorName);

                sensorBasic.Activate(agent);

                agent.AddNumAttack();

                if (agent.ReturnNumAttack() % 3 == 0)
                {
                    agent.RemoveSensor();
                }
            }
            Console.WriteLine($"Num turns {agent.ReturnNumAttack()}");

        }
    }
}
