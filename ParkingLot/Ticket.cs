using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        private string id;
        private string carId;

        public Ticket(ParkingLots parkingLotName, Car car)
        {
            this.id = parkingLotName.ParkingLotName + $": {car.CarId}";
            this.carId = car.CarId;
        }

        public string Id
        {
            get { return id; }
        }

        public string CarId
        {
            get { return carId; }
        }
    }
}
