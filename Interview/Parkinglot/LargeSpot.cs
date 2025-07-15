namespace Interview.Parkinglot;
public class LargeSpot : ParkingSpot
{
    public LargeSpot(string spotId) : base(spotId) { }

    public override bool CanFitVehicle(Vehicle vehicle) =>
        vehicle.Type == VehicleType.Truck ||
        vehicle.Type == VehicleType.Car ||
        vehicle.Type == VehicleType.Bike;
}