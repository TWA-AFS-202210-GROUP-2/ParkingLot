using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot;

public class ParkingFloor
{
    private List<Tuple<Car, int>> CarList = new List<Tuple<Car, int>>();

    public ParkingFloor(int capasity, string name)
    {
        FloorCapacity = capasity;
        FloorName = name;
        CarList.Add(new Tuple<Car, int>(new Car("base"), 0));
    }

    public int FloorCapacity { get; }
    public string FloorName { get; }
    public Ticket ParkCar(Car car)
    {
        Tuple<Car, int> newTicket = new Tuple<Car, int>(car, assignLocation());
        CarList.Add(newTicket);
        return new Ticket(newTicket.Item2, this.FloorName);
    }

    private int assignLocation()
    {
        int newId = CarList.Last().Item2 + 1;
        if (CarList.Count >= this.FloorCapacity)
        {
            throw new Exception("not enough capacity");
        }

        return newId;
    }

    public Car retriveCar(Ticket ticket)
    {
        if (!CarList.Exists(item => item.Item2 == ticket.Location))
        {
            throw new Exception("no such ticket");
        }
        Car target = CarList.Find(item => item.Item2 == ticket.Location).Item1;
        CarList.Remove(CarList.Find(item => item.Item2 == ticket.Location));
        return target;
    }
}