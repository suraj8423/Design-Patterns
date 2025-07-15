namespace Interview.RentalSystem;

public class CarReservationStrategy : IReservationStrategy
{
    public Reservation ReserveVehicle(Vehicle vehicle, Customer customer, RentalModes rentalMode)
    {
        // based on this rental mode we will calculate the total price and return the reservation
        var reservation = new Reservation
        {
            Customer = customer,
            Vehicle = vehicle,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddHours(1), // default to 1 hour for simplicity
            TotalPrice = 20
        };
        return reservation;
    }
}