namespace RabbitMQ.LightTraffic
{
    public class TrafficLight
    {
        private ITrafficLightState _state;
        public TrafficLight()
        {
            _state = new RedState();
        }

        public void SetState(ITrafficLightState state)
        {
            _state = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}