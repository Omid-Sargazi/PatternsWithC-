namespace RabbitMQ.StatePattern
{
    public interface IVendingMachineState
    {
        void InsertCoin(VendingMachine machine);
        void PressButton(VendingMachine machine);
        void DispenseProduct(VendingMachine machine);
    }
}