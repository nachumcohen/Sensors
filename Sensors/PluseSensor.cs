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
        public PluseSensor() : base()
        {
            
        }

        public override void Activate(Agent iranianAgent)
        {
            if (Active > 0)
            {
                if (iranianAgent.IsSensor(Type))
                {
                    iranianAgent.AddExposureSensor(this);
                }
                Active--;
            }
            else
            {
                Console.WriteLine("Sensor is broken");
                Status = false;
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
