using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestingationGame.Sensors
{
    internal class MagneticSensor : SensorBasic
    {
        int Counterattack = 2;
        public MagneticSensor() : base() { }

        public bool Cancelsterroristattack()
        {
            if (Counterattack > 0)
            {
                Counterattack--;
                return true;
            }
            return false;
        }
    }
}
