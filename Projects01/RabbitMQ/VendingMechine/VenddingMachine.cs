namespace RabbitMQ.VendingMechine
{
    public class VenddingMachine
    {
        private IState _state;

        public VenddingMachine()
        {
            _state = new NooCoinState();
        }

        public void SetState(IState state)
        {
            _state = state;
        }

        public void InsertCoin()
        {
            _state.InsertCoin(this);
        }

        public void SelectItem()
        {
            _state.SelectItem(this);
        }
    }
}