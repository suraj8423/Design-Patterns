public class FlatRateFeeStrategy : IFeeStrategy
{
    private const double RATE_PER_HOUR = 10.0;

    public double CalculateFee(ParkingTicket ticket)
    {
        var hours = Math.Ceiling((ticket.ExitTimestamp - ticket.EntryTimestamp) / 3600.0);
        return hours * RATE_PER_HOUR;
    }
}

public class VehicleBasedFeeStrategy : IFeeStrategy
{
    private readonly Dictionary<VehicleType, double> hourlyRates;

    public VehicleBasedFeeStrategy(Dictionary<VehicleType, double> rates)
    {
        hourlyRates = rates;
    }

    public double CalculateFee(ParkingTicket ticket)
    {
        var rate = hourlyRates[ticket.Vehicle.Type];
        var hours = Math.Ceiling((ticket.ExitTimestamp - ticket.EntryTimestamp) / 3600.0);
        return hours * rate;
    }
}
