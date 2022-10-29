namespace ParkingLot
{
    using System;
    public class ParkingTicket
    {
        private string carNumber;
        private ParkingLot_ parkingLot;

        public ParkingTicket(string carNumber, ParkingLot_ parkingLot)
        {
            this.carNumber = carNumber;
            this.parkingLot = parkingLot;
        }
    }
}
