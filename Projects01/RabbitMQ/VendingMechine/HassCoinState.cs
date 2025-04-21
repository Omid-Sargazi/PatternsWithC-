namespace RabbitMQ.VendingMechine
{
    public class HassCoinState : IState
    {
        public void InsertCoin(VenddingMachine context)
        {
            Console.WriteLine("قبلاً سکه انداختی!");
        }

        public void SelectItem(VenddingMachine context)
        {
           Console.WriteLine("محصول تحویل داده شد.");
           
        }
    }
}