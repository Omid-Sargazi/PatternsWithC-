namespace RabbitMQ.StatePattern
{
    public class VendingMachine
    {
        // private enum State
        // {
        //     WaitingForCoin,
        //     CoinInserted,
        //     ProductDelivered,
        //     OutOfService,
        // }

        // private State _currentState = State.WaitingForCoin;
        // public void InsertCoin()
        // {
        //     if(_currentState == State.WaitingForCoin)
        //     {
        //         _currentState = State.CoinInserted;
        //         Console.WriteLine("سکه دریافت شد");
        //     }
        //     else if(_currentState == State.CoinInserted)
        //     {
        //         Console.WriteLine("سکه قبلاً وارد شده است");
        //     }
        //         else if (_currentState == State.OutOfService)
        //     {
        //         Console.WriteLine("دستگاه خارج از سرویس است");
                
        //     }
        // }

        public IVendingMachineState _state;

        public IVendingMachineState NoCoinState {get;}
        public IVendingMachineState HasCoinState {get;}
        public IVendingMachineState DispensingState {get;}
        public IVendingMachineState OutOfStockState {get;}
        public VendingMachine()
        {
            _state = NoCoinState;
        }

        public void SetState(IVendingMachineState state)
        {
            _state = state;
        }

        // public void InsertCoin()=>_state.
    }
}