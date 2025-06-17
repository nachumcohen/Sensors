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
        public string Type { get; protected set; }

        public SensorBasic()
        {
            Type = this.GetType().Name;
            ListSensor.AddList(this);
        }

        public virtual void Activate(Agent iranianAgent)
        {
            if (iranianAgent.IsSensor(Type))
            {
                iranianAgent.AddExposureSensor(this);
            }
        }
    }
}
