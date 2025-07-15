namespace Interview.Parkinglot;

public abstract class ParkingSpot
{
    public string SpotId { get; }
    public Vehicle? Vehicle { get; private set; }
    public bool IsOccupied { get; private set; }

    public ParkingSpot(string spotId)
    {
        SpotId = spotId;
    }

    public bool IsAvailable()
    {
        return !IsOccupied;
    }

    public bool AssignVehicle(Vehicle vehicle)
    {
        if (!CanFitVehicle(vehicle) || IsOccupied)
        {
            return false;
        }
        Vehicle = vehicle;
        IsOccupied = true;
        return true;
    }

    public void RemoveVehicle()
    {
        Vehicle = null;
        IsOccupied = false;
    }

    public abstract bool CanFitVehicle(Vehicle vehicle);
}