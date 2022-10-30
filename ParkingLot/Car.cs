using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        private string parkingLotId;
        private Customer customer;
        private string carId;

        public Car(Customer customer, string carId, string parkingLotId = null)
        {
            this.customer = customer;
            this.carId = carId;
            this.parkingLotId = parkingLotId;
        }

        public string CarId
        {
            get { return carId; }
        }

        public Customer Customer
        {
            get { return customer; }
        }

        public string ParkingLotId
        {
            get { return parkingLotId; }
            set { parkingLotId = value; }
        }
    }
}
