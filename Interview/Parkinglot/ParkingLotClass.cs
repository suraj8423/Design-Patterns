namespace Interview.Parkinglot;

public sealed class ParkingLotClass
{
    private static readonly Lazy<ParkingLotClass> instance = new(() => new ParkingLotClass());
    public static ParkingLotClass Instance => instance.Value;

    private List<ParkingFloor> Floors { get; } = new();
    private Dictionary<string, ParkingTicket> ActiveTickets { get; } = new();

    private IFeeStrategy? FeeStrategy { get; set; }

    private ParkingLotClass()
    {
    }
    
    public void AddFloor(ParkingFloor floor) => Floors.Add(floor);
    public void SetFeeStrategy(IFeeStrategy strategy) => FeeStrategy = strategy;

    public ParkingTicket ParkVehicle(Vehicle vehicle)
    {
        foreach (var floor in Floors)
        {
            var spot = floor.GetAvailableParkingSpot(vehicle);
            if (spot != null && spot.AssignVehicle(vehicle))
            {
                var ticket = new ParkingTicket(vehicle, spot);
                ActiveTickets[vehicle.LicensePlate] = ticket;
                return ticket;
            }
        }
        throw new Exception("No available spot for vehicle.");
    }

    public double UnparkVehicle(string licensePlate)
    {
        if (!ActiveTickets.TryGetValue(licensePlate, out var ticket))
            throw new Exception("Vehicle not found.");

        if (FeeStrategy == null)
            throw new Exception("Fee strategy not set.");

        ticket.SetExitTimeStamp();
        var fee = FeeStrategy.CalculateFee(ticket);
        ticket.ParkingSpot.RemoveVehicle();
        ActiveTickets.Remove(licensePlate);
        return fee;
    }
}