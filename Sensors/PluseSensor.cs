using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;

namespace TheInvestingationGame.Sensors
{
    internal class PluseSensor : SensorBasic
    {
        int Active = 3;
        bool Status = true;

        public PluseSensor(string name) : base(name) { }

        public override void Activate(Agent iranianAgent)
        {
            if (iranianAgent.IsSensor(Name))
            {
                if (Active > 0)
                {
                    iranianAgent.AddExposureSensor(this);
                    Active--;
                }
                else
                {
                    Console.WriteLine("Sensor is broken");
                    Status = false;
                }

            }
        }
        public int GetManyTurns()
        {
            return Active;
        }

        public bool IsSensor()
        {
            return Status;
        }

    }
}
