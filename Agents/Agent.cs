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
        protected string[] Types;
        int NumAttack;

        public Agent(string name)
        {
            Name = name;
            SensorCount = GetSensorCount();
            Types = TypesSensors();
            Sensors = new Dictionary<string , int>();
            NumAttack = 0;

            for (int i = 0; i < GetSensorCount();  i++)
            {
                string sensor = Types[random.Next(Types.Length)];
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

        public virtual string[] TypesSensors()
        {
            string[] Names = new string[] { "Thermal", "Cellular" };
            return Names;
        }

        public virtual void AddExposureSensor(ISensor sensor)
        {
            ExposureSensor.Add(sensor);
            Sensors[sensor.Name] -= 1;

            Console.WriteLine($"len ExposureSensor {ExposureSensor.Count}");
        }
        public virtual bool IsSensor(string sensor)
        {
            return Sensors.TryGetValue(sensor, out int Value) && Value > 0;
        }

        public virtual int NumGuessing()
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

        public void AddNumAttack()
        {
            NumAttack++;
        }

        public int ReturnNumAttack()
        {
            return NumAttack;
        }


    }
}
