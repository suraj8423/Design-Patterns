namespace Interview.RentalSystem;

public interface IVehicleRentalSystem
{
    void AddVehicle(Vehicle vehicle);
    void RemoveVehicle(string licensePlate);
    List<Vehicle> GetAvailableVehicles(VehicleType type);
     Reservation MakeReservation(Customer customer, Vehicle vehicle, DateTime start, DateTime end, RentalMode mode);
}