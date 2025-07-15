namespace Interview.RentalSystem;

public abstract class Vehicle
{
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double RentalPricePerDay { get; set; }
    public bool IsAvailable { get; set; } = true;
    public VehicleType VehicleType { get; set; }
}
