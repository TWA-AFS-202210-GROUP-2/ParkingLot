namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(string name, List<ParkingLot_> parkingLots) : base(name, parkingLots)
        {
        }

        public override ParkingTicket ParkCar(Car car)
        {
            ManagerParkingLots.Sort((x, y) => y.GetCapacity() - x.GetCapacity());
            ParkingTicket parkingTicket = ManagerParkingLots[0].CarIn(car);
            if (parkingTicket == null)
            {
                return null;
            }

            UpdateProvidedParkingTickets(parkingTicket);
            return parkingTicket;
        }
    }
}
