using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ParkingLot;

public class ParkingBoy
{
    protected List<ParkingFloor> managedFloors = new List<ParkingFloor>();

    public ParkingBoy(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public virtual Ticket ParkCar(Car car)
    {
        if (managedFloors.Exists((floor) => floor.GetRemainSlotsCount() > 0))
        {
            var ticket = managedFloors.Find((floor) => floor.GetRemainSlotsCount() > 0).ParkCar(car);
            return ticket;
        }
        else
        {
            throw new NotEnoughCapacityException("not enough capacity");
        }
    }

    public void AddParkingFloor(ParkingFloor parkingFloor)
    {
        managedFloors.Add(parkingFloor);
    }

    public Car RetriveCar(Ticket ticket)
    {
        if (ticket == null)
        {
            throw new NoTicketExcption("Please provide your parking ticket.");
        }
        if (!managedFloors.Exists(floor => floor.FloorName == ticket.FloorName))
        {
            throw new WrongTicketExcption("no such ticket");
        }
        var parkingFloor = managedFloors.Find(floor => floor.FloorName == ticket.FloorName);
        Car car = parkingFloor.retriveCar(ticket);
        return car;
    }
}