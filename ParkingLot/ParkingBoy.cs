namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingBoy
    {
        private readonly string wrongTicketMessage = "Unrecognized parking ticket.";
        private readonly string nullTicketMessage = "Please provide your parking ticket.";
        private string name;
        private List<ParkingLot_> managerParkingLots;
        private Dictionary<string, ParkingTicket> providedParkingTickets = new Dictionary<string, ParkingTicket>();

        public ParkingBoy(string name, List<ParkingLot_> parkingLots)
        {
            this.name = name;
            this.managerParkingLots = parkingLots;
        }

        public ParkingTicket ParkCar(Car car)
        {
            ParkingTicket parkingTicket = null;
            foreach (var parkingLot in managerParkingLots)
            {
                parkingTicket = parkingLot.CarIn(car);
                if (parkingTicket == null)
                {
                    continue;
                }

                UpdateProvidedParkingTickets(parkingTicket);
                break;
            }

            return parkingTicket;
        }

        public Car FetchCar(ParkingTicket ticket)
        {
            Printer printer = new Printer();
            if (ticket == null)
            {
                printer.PrintMessage(nullTicketMessage);
                return null;
            }

            if (ticket.GetIsUsed() || !IsProvidedParkingTicket(ticket))
            {
                printer.PrintMessage(wrongTicketMessage);
                return null;
            }

            Car fetchCar = ticket.GetParkingLot().CarOut(ticket);
            if (fetchCar != null)
            {
                ticket.UseTIcket();
            }

            UpdateProvidedParkingTickets(ticket);

            return fetchCar;
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
            this.providedParkingTickets.TryAdd(parkingTicket.GetCarNumber(), parkingTicket);
        }

        private bool IsProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            return this.providedParkingTickets.ContainsKey(parkingTicket.GetCarNumber());
        }
    }
}
