namespace Interview.Parkinglot;

public static class ParkingSpotFactory
{
    public static ParkingSpot CreateParkingSpot(ParkingSpotType type, string spotId)
    {
        return type switch
        {
            ParkingSpotType.Compact => new CompactSpot(spotId),
            ParkingSpotType.Large => new LargeSpot(spotId),
            ParkingSpotType.Bike  => new BikeSpot(spotId),
            _ => throw new ArgumentException("Invalid parking spot type")
        };
    }
}