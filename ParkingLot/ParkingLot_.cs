namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot_
    {
        private string parkingLotName;
        private Dictionary<string, Car> cars = new Dictionary<string, Car>();
        private int capacity;

        public ParkingLot_(string parkingLotName, int capacity = 10)
        {
            this.parkingLotName = parkingLotName;
            this.capacity = capacity;
        }

        public ParkingTicket CarIn(Car car)
        {
            if (!HasPosition())
            {
                return null;
            }

            cars.TryAdd(car.GetCarNumber(), car);
            capacity--;
            return GenerateTicket(car);
        }

        public Car CarOut(ParkingTicket ticket)
        {
            capacity++;
            return cars[ticket.GetCarNumber()];
        }

        public ParkingTicket GenerateTicket(Car car)
        {
            return new ParkingTicket(car.GetCarNumber(), this);
        }

        public bool HasPosition()
        {
            return capacity > 0;
        }
    }
}
