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
}