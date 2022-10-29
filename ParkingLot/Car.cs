namespace ParkingLot
{
    using System;
    public class Car
    {
        private string carNumber;

        public Car(string carNumber)
        {
            this.carNumber = carNumber;
        }

        public string GetCarNumber()
        {
            return carNumber;
        }
    }
}
