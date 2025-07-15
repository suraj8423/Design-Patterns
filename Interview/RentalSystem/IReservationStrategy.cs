namespace Interview.RentalSystem;

public interface IReservationStrategy
{
    Reservation ReserveVehicle(Vehicle vehicle, Customer customer, RentalModes rentalMode);
}