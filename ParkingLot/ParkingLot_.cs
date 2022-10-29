namespace ParkingLot
{
    using System;
    public class ParkingLot_
    {
        private string parkingLotName;

        public ParkingLot_(string parkingLotName)
        {
            this.parkingLotName = parkingLotName;
        }

        public ParkingTicket CarIn(Car car)
        {
            return GenerateTicket(car);
        }

        public ParkingTicket GenerateTicket(Car car)
        {
            return new ParkingTicket(car.GetCarNumber(), this);
        }
    }
}
