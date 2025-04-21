namespace RabbitMQ.VendingMechine
{
    public interface IState
    {
        void InsertCoin(VenddingMachine context);
        void SelectItem(VenddingMachine context);
    }
}