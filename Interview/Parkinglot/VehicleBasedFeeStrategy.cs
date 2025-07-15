namespace Interview.Parkinglot;

public class VehicleBasedFeeStrategy : IFeeStrategy
{
    private readonly Dictionary<VehicleType, double> _rates;

    public VehicleBasedFeeStrategy(Dictionary<VehicleType, double> rates)
    {
        _rates = rates;
    }

    public double CalculateFee(ParkingTicket ticket)
    {
        var duration = ticket.ExitTimeStamp - ticket.EntryTimeStamp;
        var hours = Math.Ceiling(duration / 3600.0);
        
        if (_rates.TryGetValue(ticket.Vehicle.Type, out var hourlyRate))
        {
            return hours * hourlyRate;
        }
        
        return 0;
    }
}