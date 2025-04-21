namespace RabbitMQ.StatePattern
{
    public class NoCoinState : IVendingMachineState
    {
        public void DispenseProduct(VendingMachine machine)
        {
            throw new NotImplementedException();
        }

        public void InsertCoin(VendingMachine machine)
        {
           Console.WriteLine("سکه وارد شد. حالا می‌توانید محصول انتخاب کنید.");
        //    machine.CurrentState(machine.)
        }

        public void PressButton(VendingMachine machine)
        {
            throw new NotImplementedException();
        }
    }
}