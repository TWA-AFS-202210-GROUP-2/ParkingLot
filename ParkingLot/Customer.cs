namespace ParkingLot;

public class Customer
{
    public Customer(string name)
    {
        CustomerName = name;
    }

    public Ticket MyTicket { get; set; }
    public string CustomerName { get; }

    public string ParkCar(Car car, ParkingBoy parkingBoy)
    {
        MyTicket = parkingBoy.ParkCar(car);
        return $"customer {CustomerName} received ticket: {MyTicket.Location} {MyTicket.FloorName}";
    }

    public Car RetriveCar(ParkingBoy parkingBoy)
    {
        Car mycar = parkingBoy.retriveCar(MyTicket);
        return mycar;
    }
}
