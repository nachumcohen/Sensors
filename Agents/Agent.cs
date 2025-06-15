using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TheInvestingationGame.Sensors;

namespace TheInvestingationGame.Agents
{
    internal abstract class Agent
    {

        static Random random = new Random();
        protected string Name { get; }
        protected Dictionary<string, int> Sensors;
        protected List<ISensor> ExposureSensor = new List<ISensor>();
        protected int SensorCount;

        public Agent(string name)
        {
            Name = name;
            SensorCount = GetSensorCount();
            string[] Names = RandomTypesSensors();
            Sensors = new Dictionary<string , int>();

            for (int i = 0; i < 2;  i++)
            {
                string sensor = Names[random.Next(Names.Length)];
                if (Sensors.ContainsKey(sensor))
                {
                    Sensors[sensor] +=1;
                }
                else
                {
                    Sensors.Add(sensor, 1);
                }
            }
        }
        public virtual int GetSensorCount()
        {
            return 2;
        }

        public virtual string[] RandomTypesSensors()
        {
            string[] Names = new string[] { "Thermal", "Cellular" };
            return Names;
        }

        public virtual void AddExposureSensor(SensorBasic sensorBasic)
        {
            ExposureSensor.Add(sensorBasic);
            Sensors[sensorBasic.Name] -=1;
            Console.WriteLine(ExposureSensor.Count);
        }
        public virtual bool IsSensor(string sensor)
        {
            return Sensors.TryGetValue(sensor, out int Value) && Value > 0;
        }

        public virtual int IsGuessing()
        {
            int len = ExposureSensor.Count;
            if (len < SensorCount)
            {
                Console.WriteLine($"Num Guessing {len} / {SensorCount}");

            }
            else
            {
                Console.WriteLine($"Num Guessing {len} / {SensorCount}");
                Console.WriteLine($"Agent Name {Name} exposed");
            }
            return len;
        }


    }
}
