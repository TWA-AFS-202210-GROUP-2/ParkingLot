using System.Collections.Generic;
using System.Linq;

namespace ParkingLot;

public class Customer
{
    private List<Ticket> myTicket = new List<Ticket>();
    public Customer(string name)
    {
        CustomerName = name;
    }

    public string CustomerName { get; }

    public string ParkCar(Car car, ParkingBoy parkingBoy)
    {
        Ticket receivedTicket = parkingBoy.ParkCar(car);
        myTicket.Add(receivedTicket);
        return $"customer {CustomerName} received ticket: {receivedTicket.Location} {receivedTicket.FloorName}";
    }

    public List<Car> RetriveCar(ParkingBoy parkingBoy)
    {
        var cars = myTicket.Select(item => parkingBoy.RetriveCar(item)).ToList();
        myTicket.Clear();
        return cars;
    }

    public string ParkCar(List<Car> carList, ParkingBoy parkingBoy)
    {
        carList.ForEach(item => ParkCar(item,parkingBoy));
        return "ok";
    }

    public void AddTicket(Ticket fakeTicket)
    {
        myTicket.Add(fakeTicket);
    }
}
