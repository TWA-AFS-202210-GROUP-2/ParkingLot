using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ParkingLot;

public class ParkingBoy
{
    private List<ParkingFloor> managedFloors = new List<ParkingFloor>();

    public ParkingBoy(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public Ticket ParkCar(Car car)
    {
        Ticket ticket = managedFloors[0].ParkCar(car);
        return ticket;
    }

    public void AddParkingFloor(ParkingFloor parkingFloor)
    {
        managedFloors.Add(parkingFloor);
    }

    public Car RetriveCar(Ticket ticket)
    {
        if (!managedFloors.Exists(floor => floor.FloorName == ticket.FloorName))
        {
            throw new Exception("no such ticket");
        }
        var parkingFloor = managedFloors.Find(floor => floor.FloorName == ticket.FloorName);
        Car car = parkingFloor.retriveCar(ticket);
        return car;
    }
}