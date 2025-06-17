using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Sensors;

namespace TheInvestingationGame.Agents
{
    internal class SeniorCommander : Agent
    {
        static Random random = new Random();
        public SeniorCommander() : base() { }
        
        public override int GetSensorCount()
        {
            return 6;
        }

        public void RemoveTowSensors()
        {
            if (NumAttack % 3 == 0)
            {
                if (ExposureSensor.Count >= 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int index = random.Next(ExposureSensor.Count);
                        ISensor sensor = ExposureSensor[index];
                        if (sensor is MagneticSensor)
                        {
                            if (((MagneticSensor)sensor).Cancelsterroristattack())
                            {
                                 continue;
                            }
                        }
                        ExposureSensor.RemoveAt(index);
                        Sensors[sensor.Type] += 1;
                        Console.WriteLine("remove sensor");
                    }
                }
                if (ExposureSensor.Count == 1)
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
