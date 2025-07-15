namespace Interview.RentalSystem;

public class Reservation
{
    public int ReservationId { get; set; }
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalPrice { get; set; }
}