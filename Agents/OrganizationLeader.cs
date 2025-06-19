using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestingationGame.Agents;

namespace TheInvestingationGame.Sensors
{
    internal class OrganizationLeader : Squad_Leader
    {
        static Random random = new Random();
        public OrganizationLeader() : base() { }


        public override int GetSensorCount()
        {
            return 8;
        }
        public override int GetLevelAgent()
        {
            return 4;
        }

        public override void StartSensors()
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

        //public void ResetDictSensorsAndListExposureSensor()
        //{
        //    ExposureSensor.Clear();
        //    Dictionary<string, int> sensors = null;

        //    if (NumMistake % 10 == 0)
        //    {
        //        sensors =  new Dictionary<string, int>();

        //        StartSensors();
        //        this.Sensors = sensors;
        //    }
        //}

    }
}
