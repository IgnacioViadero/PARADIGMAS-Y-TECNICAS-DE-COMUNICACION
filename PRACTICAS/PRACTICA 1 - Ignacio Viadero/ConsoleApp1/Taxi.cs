using Practica1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    internal class Taxi : Vehicle
    {
        private bool has_passengers;
        public Taxi(string plate) : base(plate, "Taxi", 0)
        {
            has_passengers = false;
            SetVehicleSpeed(45);
            Console.WriteLine($"{ToString()}: Created");
        }
        public bool Riding()
        {
            return has_passengers;
        }
        public void SetPassengers(bool passengers)
        {
            has_passengers = passengers;
        }
        public void StartRide()
        {
            string result = "";
            if (Riding())
            {
                result = "is already in a ride.";
            }
            else
            {
                SetVehicleSpeed(100);
                SetPassengers(true);
                result = "starting a ride.";
            }
            Console.WriteLine($"{ToString()}: {result}");
        }
        public void StopRide()
        {
            string result = "";
            if (Riding())
            {
                SetVehicleSpeed(45);
                SetPassengers(false);
                result = "Has finished the ride.";
            }
            Console.WriteLine($"{ToString()}: {result}");
        }
    }
}