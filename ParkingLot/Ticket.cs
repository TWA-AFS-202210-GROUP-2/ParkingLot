namespace ParkingLot;

public class Ticket
{
    public Ticket(int location, string floorName)
    {
        Location = location;
        FloorName = floorName;
    }

    public int Location { get; }
    public string FloorName { get; }
}