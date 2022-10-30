namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot_
    {
        private string parkingLotName;
        private Dictionary<string, Car> cars = new Dictionary<string, Car>();

        public ParkingLot_(string parkingLotName)
        {
            this.parkingLotName = parkingLotName;
        }

        public ParkingTicket CarIn(Car car)
        {
            cars.TryAdd(car.GetCarNumber(), car);
            return GenerateTicket(car);
        }

        public Car CarOut(ParkingTicket ticket)
        {
            return cars[ticket.GetCarNumber()];
        }

        public ParkingTicket GenerateTicket(Car car)
        {
            return new ParkingTicket(car.GetCarNumber(), this);
        }
    }
}
