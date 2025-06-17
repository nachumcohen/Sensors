using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Sensors;

namespace TheInvestingationGame.Agents
{
    internal class Squad_Leader : Agent
    {

        static Random random = new Random();

        public Squad_Leader() : base() { }

        public override int GetSensorCount()
        {
            return 4;
        }

        public virtual void RemoveSensor()
        {
            if (NumAttack % 3 == 0)
            {
                if (ExposureSensor.Count > 0)
                {
                    int index = random.Next(ExposureSensor.Count);
                    ISensor sensor = ExposureSensor[index];
                    if (sensor is MagneticSensor)
                    {
                        if (((MagneticSensor)sensor).Cancelsterroristattack())
                        {
                            return;
                        }
                    }
                    ExposureSensor.RemoveAt(index);
                    Sensors[sensor.Type] += 1;
                    Console.WriteLine("remove sensor");
                }
            }
        }

    }
}
