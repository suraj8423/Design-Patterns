namespace Interview.Parkinglot;
public class BikeSpot : ParkingSpot
{
    public BikeSpot(string spotId) : base(spotId) { }

    public override bool CanFitVehicle(Vehicle vehicle) =>
        vehicle.Type == VehicleType.Bike;
}