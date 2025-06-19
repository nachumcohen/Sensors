using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;

namespace TheInvestingationGame.Sensors
{
    internal class ThermalSensor : SensorBasic
    {

        static Random random = new Random();
        public ThermalSensor() : base() { }

        public override bool Activate(Agent iranianAgent)
        {
            if (iranianAgent.IsSensor(Type))
            {
                List<string> keys = new List<string>();
                foreach (var key in iranianAgent.GetSensors())
                {
                    if (key.Value > 0)
                    {
                        keys.Add(key.Key);
                    }
                }
                if (keys.Count > 0)
                {
                    string agent = keys[random.Next(keys.Count)];
                    Console.WriteLine(agent);
                }
                return true;
                
            }
            return false;
        }
    }
}
