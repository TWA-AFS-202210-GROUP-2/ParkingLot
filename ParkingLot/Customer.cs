using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Customer
    {
        private string name;
        private string carKey;

        public Customer(string name, string carKey)
        {
            this.name = name;
            this.carKey = carKey;
        }
    }
}
