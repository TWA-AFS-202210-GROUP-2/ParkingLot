using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(string name) : base(name)
        {
        }
        public override Ticket ParkCar(Car car)
        {
            if (managedFloors.Exists((floor) => floor.GetRemainSlotsCount() > 0))
            {
                var ticket = managedFloors.MaxBy((floor) => floor.GetRemainSlotsCount()).ParkCar(car);
                return ticket;
            }
            else
            {
                throw new NotEnoughCapacityException("not enough capacity");
            }
        }
    }
}
