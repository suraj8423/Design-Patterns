
namespace Interview.RentalSystem;
    public class BikeReservationStrategy : IReservationStrategy
    {
    public Reservation MakeReservation(Customer customer, Vehicle vehicle, DateTime start, DateTime end, RentalMode mode)
    {
        // based on this rental mode we will calculate the total price and return the reservation
        var reservation = new Reservation
        {
            Customer = customer,
            Vehicle = vehicle,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddHours(1), // default to 1 hour for simplicity
            TotalPrice = 10
        };
        
           return reservation;
        }
    }
