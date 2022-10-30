namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingBoy
    {
        private string name;
        private List<ParkingLot_> managerParkingLots = new ();
        private Dictionary<string, ParkingTicket> providedParkingTickets = new Dictionary<string, ParkingTicket>();

        public ParkingBoy(string name, ParkingLot_ parkingLot_)
        {
            this.name = name;
            managerParkingLots.Add(parkingLot_);
        }

        public ParkingTicket ParkCar(Car car)
        {
            ParkingTicket parkingTicket = managerParkingLots[0].CarIn(car);
            UpdateProvidedParkingTickets(parkingTicket);
            return parkingTicket;
        }

        public Car FetchCar(ParkingTicket ticket)
        {
            if (ticket == null || !IsProvidedParkingTicket(ticket))
            {
                return null;
            }

            return managerParkingLots[0].CarOut(ticket);
        }

        public List<ParkingTicket> ParkCars(List<Car> cars)
        {
            var tickets = new List<ParkingTicket>();
            foreach (Car car in cars)
            {
                tickets.Add(ParkCar(car));
            }

            return tickets;
        }

        public List<Car> FetchCars(List<ParkingTicket> tickets)
        {
            var cars = new List<Car>();
            foreach (ParkingTicket parkingTicket in tickets)
            {
                cars.Add(FetchCar(parkingTicket));
            }

            return cars;
        }

        private void UpdateProvidedParkingTickets(ParkingTicket parkingTicket)
        {
            this.providedParkingTickets.Add(parkingTicket.GetCarNumber(), parkingTicket);
        }

        private bool IsProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            return this.providedParkingTickets.ContainsKey(parkingTicket.GetCarNumber());
        }
    }
}
