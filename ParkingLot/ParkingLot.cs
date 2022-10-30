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
        private double positionRate;

        public ParkingLots(string parkingLotName, int capacity)
        {
            this.parkingLotName = parkingLotName;
            this.capacity = capacity;
            cars = new List<Car>();
            tickets = new List<Ticket>();
            this.positionRate = 1;
        }

        public string ParkingLotName { get; set; }
        public int Capacity { get; set; }
        public double PositionRate { get; set; }

        public Ticket StorageCar(Car car)
        {
            if (capacity > 0)
            {
                throw new Exception("Not enough position.");
            }

            this.positionRate = 1 / (this.Capacity / this.capacity--);

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
