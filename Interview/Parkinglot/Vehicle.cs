namespace Interview.Parkinglot;

public abstract class Vehicle
{
    public string LicensePlate { get; }
    public VehicleType Type { get; }

    protected Vehicle(string licensePlate, VehicleType type)
    {
        LicensePlate = licensePlate;
        Type = type;
    }
}