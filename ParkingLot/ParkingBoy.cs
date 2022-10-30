namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingBoy
    {
        private string name;
        private List<ParkingLot_> managerParkingLots = new ();

        public ParkingBoy(string name, ParkingLot_ parkingLot_)
        {
            this.name = name;
            managerParkingLots.Add(parkingLot_);
        }

        public Car FetchCar(ParkingTicket ticket)
        {
            return managerParkingLots[0].CarOut(ticket);
        }

        public ParkingTicket ParkCar(Car car)
        {
            return managerParkingLots[0].CarIn(car);
        }
    }
}
