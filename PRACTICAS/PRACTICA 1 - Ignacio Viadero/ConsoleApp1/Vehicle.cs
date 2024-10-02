using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Vehicle
    {
        private string vehicle_type;
        private string plate;
        private int speed;

        public Vehicle(string vehicle_type, string plate, int speed)
        {
            this.vehicle_type = vehicle_type;
            this.plate = plate;
            this.speed = speed;
        }
        public string GetVehicleType()
        {
            return vehicle_type;
        }
        public string GetVehiclePlate()
        {
            return plate;
        }
        public int GetVehicleSpeed()
        {
            return speed;
        }
        public override string ToString()
        {
            return $"{GetVehicleType()} with plate {GetVehiclePlate()}";
        }
        public void SetVehicleSpeed(int speed)
        {
            this.speed = speed;
        }
    }
}
