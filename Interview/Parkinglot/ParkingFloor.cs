namespace Interview.Parkinglot;

public class ParkingFloor
{
    public int FloorNumber { get; }
    public List<ParkingSpot> ParkingSpots { get; }

    public ParkingFloor(int floorNumber, List<ParkingSpot>? parkingSpots = null)
    {
        FloorNumber = floorNumber;
        ParkingSpots = parkingSpots ?? new List<ParkingSpot>();
    }

    public ParkingSpot? GetAvailableParkingSpot(Vehicle vehicle)
    {
        return ParkingSpots.FirstOrDefault(spot => spot.IsAvailable() && spot.CanFitVehicle(vehicle));
    }
}