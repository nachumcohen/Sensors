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

        public Squad_Leader(string name) : base(name) { }

        public override int GetSensorCount()
        {
            return 4;
        }
        public override string[] TypesSensors()
        {
            string[] Types = new string[] {"Thermal" , "Cellular" , "Traffic", "Distance"};
            return Types;
        }

        public override void AddExposureSensor(ISensor sensor)
        {
            base.AddExposureSensor(sensor);
        }

        public void RemoveSensor()
        {
            int index = random.Next(ExposureSensor.Count);
            ISensor sensor = ExposureSensor[index];
            ExposureSensor.RemoveAt(index);
            Sensors[sensor.Name] += 1;
            Console.WriteLine("remove sensor");
        }

    }
}
