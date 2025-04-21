namespace RabbitMQ.VendingMechine
{
    public class NooCoinState : IState
    {
        public void InsertCoin(VenddingMachine context)
        {
            Console.WriteLine("سکه دریافت شد.");
        }

        public void SelectItem(VenddingMachine context)
        {
            Console.WriteLine("لطفاً اول سکه بنداز!");
        }
    }
}