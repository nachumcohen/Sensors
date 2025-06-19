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

        public override bool Activate(Agent iranianAgent)
        {
            if (Active > 0)
            {
                if (iranianAgent.IsSensor(Type))
                {
                    //iranianAgent.AddExposureSensor(this);
                    Active--;
                    return true;
                }
                Active--;
                return false;
            }
            else
            {
                Console.WriteLine("Sensor is broken");
                Status = false;
                return false;
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
