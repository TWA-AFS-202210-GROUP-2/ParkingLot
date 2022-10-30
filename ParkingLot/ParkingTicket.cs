namespace ParkingLot
{
    using System;
    public class ParkingTicket
    {
        private string carNumber;
        private ParkingLot_ parkingLot;
        private bool isUsed = false;

        public ParkingTicket(string carNumber, ParkingLot_ parkingLot)
        {
            this.carNumber = carNumber;
            this.parkingLot = parkingLot;
        }

        public string GetCarNumber()
        {
            return carNumber;
        }

        public bool GetIsUsed()
        {
            return isUsed;
        }

        public void UseTIcket()
        {
            isUsed = true;
        }

        public ParkingLot_ GetParkingLot()
        {
            return parkingLot;
        }
    }
}
