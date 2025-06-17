using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestingationGame.Sensors
{
    internal static class ListSensor
    {
        private static List<string> Sensors = new List<string>() { "ThermalSensor" , "PluseSensor" , "SensorBasic" , "MagneticSensor" };

        public static void AddList(ISensor sensor)
        {

            if (!Sensors.Contains(sensor.Type))
            {
                Sensors.Add(sensor.Type);
            }
        }

        public static List<string> ReturnList()
        {
            return Sensors;
        }
    }
}
