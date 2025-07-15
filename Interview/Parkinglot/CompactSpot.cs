namespace Interview.Parkinglot;

public class CompactSpot : ParkingSpot
{
    public CompactSpot(string spotId) : base(spotId) { }

    public override bool CanFitVehicle(Vehicle vehicle) =>
        vehicle.Type == VehicleType.Car || vehicle.Type == VehicleType.Bike;
}