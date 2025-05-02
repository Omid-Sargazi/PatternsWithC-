namespace PatternsInCSharp02.Facade
{
    public enum ReservationStatus
    {
       Success,
        Failed
    }

    public class FlightSearchService
    {
        public string SearchFlight(string origin, string destination, string date)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
                return null;
            return $"FLIGHT_{origin}_{destination}_{date}";
        }
    }

    public class ReservationService
    {
        public bool ReserveFlight(string flightId, string passengerName)
        {
            if (string.IsNullOrEmpty(flightId) || string.IsNullOrEmpty(passengerName))
                return false;
            Console.WriteLine($"Reserved flight {flightId} for {passengerName}");
            return true;
        }
    }

    public class PaymentService
    {
        public bool ProcessPayment(string passengerName, double amount)
        {
            if (amount <= 0)
                return false;
            Console.WriteLine($"Processed payment of {amount} for {passengerName}");
            return true;
        }
    }

    public class FlightReservationFacade
    {
        private FlightSearchService _flightSearchService;
        private ReservationService _reservationService;
        private PaymentService _paymentService;
        public FlightReservationFacade()
        {
            _flightSearchService = new FlightSearchService();
            _reservationService = new ReservationService();
            _paymentService = new PaymentService();
        }

        public ReservationStatus ReserveFlight(string origin, string destination, string date, string passengerName, double amount)
        {
             string flightId = _searchService.SearchFlight(origin, destination, date);
            if (flightId == null)
            {
                Console.WriteLine("Flight search failed");
                return ReservationStatus.Failed;
            }

            // Step 2: Reserve flight
            if (!_reservationService.ReserveFlight(flightId, passengerName))
            {
                Console.WriteLine("Reservation failed");
                return ReservationStatus.Failed;
            }

            // Step 3: Process payment
            if (!_paymentService.ProcessPayment(passengerName, amount))
            {
                Console.WriteLine("Payment failed");
                return ReservationStatus.Failed;
            }

            Console.WriteLine($"Flight reservation for {passengerName} from {origin} to {destination} on {date}: Success");
            return ReservationStatus.Success;
        }
    }
}