using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Radar
    {
        private int max_legal_speed;
        private List<int> measured_speeds;
        public Radar()
        {
            max_legal_speed = 50;
            measured_speeds = new List<int>();
        }
        public int measured_Speed(Vehicle vehicle)
        {
            int speed = vehicle.GetVehicleSpeed();
            measured_speeds.Add(speed);
            return speed;
        }
        public int GetMaximumLegalSpeed()
        {
            return max_legal_speed;
        }
        public List<int> GetMeasuredSpeeds()
        {
            return measured_speeds;
        }
    }
}
