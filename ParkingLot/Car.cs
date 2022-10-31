using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        private readonly string plateNumber;

        public Car(string carPlateNumber)
        {
            this.plateNumber = carPlateNumber;
        }

        public string GetPlateNumber()
        {
            return this.plateNumber;
        }
    }
}