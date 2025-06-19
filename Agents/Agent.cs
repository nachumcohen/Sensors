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
        protected int LevelAgent;
        protected Dictionary<string, int> Sensors {  get;  set; }
        protected List<ISensor> ExposureSensor = new List<ISensor>();
        protected int SensorCount;
        protected List<string> Types;
        protected int NumAttack;
        protected int NumMistake;
        protected int NumLoss;

        public Agent()
        {
            SensorCount = GetSensorCount();
            LevelAgent = GetLevelAgent();
            Types = ListSensor.ReturnList();
            Sensors = new Dictionary<string , int>();
            NumAttack = 0;
            StartSensors();
            
        }

        public virtual void StartSensors()
        {
            for (int i = 0; i < GetSensorCount(); i++)
            {
                string sensor = Types[random.Next(Types.Count)];
                if (Sensors.ContainsKey(sensor))
                {
                    Sensors[sensor] += 1;
                }
                else
                {
                    Sensors.Add(sensor, 1);
                }
            }
        }

        public abstract int GetSensorCount();

        public abstract int GetLevelAgent();





        public virtual void AddExposureSensor(ISensor sensor)
        {
            ExposureSensor.Add(sensor);
            Sensors[sensor.Type] -= 1;

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
                Console.WriteLine("Agent Name exposed");
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

        public void AddNumMistake()
        {
            NumMistake++;
        }

        public int ReturnNumMistake()
        {
            return NumMistake;
        }

        public Dictionary<string, int> GetSensors()
        {
            return Sensors;
        }

        public void ResetDictSensorsAndListExposureSensor()
        {
            ExposureSensor.Clear();
            Dictionary<string, int> sensors = null;

            if (NumMistake % 10 == 0)
            {
                sensors = new Dictionary<string, int>();

                StartSensors();
                this.Sensors = sensors;
            }
        }




    }
}
