using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;

namespace TheInvestingationGame.Sensors
{
    internal class SensorBasic : ISensor
    {
        public string Name { get; private set; }

        public SensorBasic(string name)
        {
            Name = name;
        }

        public void Activate(Agent iranianAgent)
        {
            if (iranianAgent.IsSensor(Name))
            {
                iranianAgent.AddExposureSensor(this);
            }
        }
    }
}
