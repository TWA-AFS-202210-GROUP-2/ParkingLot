using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLots
    {
        private List<Car> cars;
        private List<Ticket> tickets;
        private string parkingLotName;
        private int capacity;

        public ParkingLots(string parkingLotName, int capacity = 10)
        {
            this.parkingLotName = parkingLotName;
            this.capacity = capacity;
            cars = new List<Car>();
            tickets = new List<Ticket>();
        }

        public string ParkingLotName { get; set; }
        public Ticket StorageCar(Car car)
        {
            if (tickets.Count > capacity)
            {
                throw new Exception("Not enough position.");
            }

            car.ParkingLotId = parkingLotName;
            cars.Add(car);
            var ticket = new Ticket(this, car);
            tickets.Add(ticket);

            return ticket;
        }

        public Car GetCar(Ticket ticket)
        {
            if (!tickets.Contains(ticket))
            {
                throw new Exception("Unrecognized parking ticket.");
            }

            for (int i = 0; i < cars.Count; i++)
            {
                if (ticket.CarId == cars[i].CarId)
                {
                    tickets.Remove(ticket);
                    return cars[i];
                }
            }

            var rightCar = (Car)cars.Select(car => car.CarId == ticket.Id);

            return rightCar;
        }
    }
}
