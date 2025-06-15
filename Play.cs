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
            while (agent.IsGuessing() < 2)
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
            }

        }
    }
}
