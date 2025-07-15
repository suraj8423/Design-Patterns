namespace Interview.RentalSystem;

    public class VehicleRentalSystem : IVehicleRentalSystem
    {
        private readonly Dictionary<string, Vehicle> _vehicles = new();
        private readonly IReservationStrategy _reservationStrategy;

        public VehicleRentalSystem(IReservationStrategy reservationStrategy)
        {
            _reservationStrategy = reservationStrategy;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles[vehicle.LicensePlate] = vehicle;
        }

        public void RemoveVehicle(string licensePlate)
        {
            _vehicles.Remove(licensePlate);
        }

        public List<Vehicle> SearchAvailableVehicles(VehicleType type, string make, string model)
        {
            return _vehicles.Values.Where(v =>
                v.VehicleType == type && 
                v.Make == make && 
                v.Model == model &&
                v.IsAvailable).ToList();
        }

        public Reservation MakeReservation(Customer customer, Vehicle vehicle, DateTime start, DateTime end, RentalMode mode)
        {
            var reservation = _reservationStrategy.MakeReservation(customer, vehicle, start, end, mode);
            vehicle.SetAvailability(false);
            return reservation;
        }
    }
