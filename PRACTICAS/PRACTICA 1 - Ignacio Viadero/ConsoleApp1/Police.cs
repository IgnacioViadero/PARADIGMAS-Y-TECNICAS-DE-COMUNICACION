using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Police : Vehicle
    {
        private bool Patrolling;
        private Radar radar;
        public Police(string plate) : base(plate, "Police Car", 0)
        {
            Patrolling = false;
            radar = new Radar();
            Console.WriteLine($"{ToString()}: Created");
        }
        public void measured_Speed(Vehicle vehicle)
        {
            if (Patrolling)
            {
                int speed = radar.measured_Speed(vehicle);
                string result = "";

                if (speed > radar.GetMaximumLegalSpeed())
                {
                    result = "Catched above legal speed.";
                }
                else
                {
                    result = "Driving legally.";
                }
                Console.WriteLine($"{ToString()}: Triggered radar. Result: {vehicle.ToString()} at {speed} km/h. {result}");
            }
            else
            {
                Console.WriteLine($"{ToString()}: has no active radar.");
            }
        }

        public bool OnPatrol()
        {
            return Patrolling;
        }
        public void PatrolStart()
        {
            string result = "";
            if (Patrolling)
            {
                result = "Is patrolling";

            }
            else
            {
                Patrolling = true;
                result = "Has started patrolling";
            }
            Console.WriteLine($"{ToString()}: {result}");
        }
        public void PatrolStop()
        {
            string result = "";
            if (Patrolling)
            {
                Patrolling = false;
                result = "Has stopped patrolling";
            }
            else
            {
                result = "It wasn't patrolling";
            }
            Console.WriteLine($"{ToString()}: {result}");
        }
        public void SpeedHistory()
        {
            List<int> list = radar.GetMeasuredSpeeds();
            Console.WriteLine($"{ToString()}: Report radar history:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}

