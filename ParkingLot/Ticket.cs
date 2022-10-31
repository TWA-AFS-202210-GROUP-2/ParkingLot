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
        private string parkingLotName;

        public Ticket(ParkingLots parkingLot, Car car)
        {
            this.id = parkingLot.ParkingLotName + $": {car.CarId}";
            this.carId = car.CarId;
            this.parkingLotName = parkingLot.ParkingLotName;
        }

        public string Id
        {
            get { return id; }
        }

        public string CarId
        {
            get { return carId; }
        }

        public string ParkingLotName
        {
            get { return parkingLotName; }
        }
    }
}
