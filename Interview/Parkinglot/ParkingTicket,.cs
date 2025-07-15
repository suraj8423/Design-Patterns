namespace Interview.Parkinglot;

public class ParkingTicket
{
    public string TicketId { get; }
    public Vehicle Vehicle { get; }
    public ParkingSpot ParkingSpot { get; }
    public long EntryTimeStamp { get; }
    public long ExitTimeStamp { get; private set; }

    public ParkingTicket(Vehicle vehicle, ParkingSpot spot)
    {
        TicketId = Guid.NewGuid().ToString();
        Vehicle = vehicle;
        ParkingSpot = spot;
        EntryTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
    
    public void SetExitTimeStamp()
    {
        ExitTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}