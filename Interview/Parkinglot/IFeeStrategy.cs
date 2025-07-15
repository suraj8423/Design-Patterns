namespace Interview.Parkinglot;

public interface IFeeStrategy
{
    double CalculateFee(ParkingTicket ticket);
}