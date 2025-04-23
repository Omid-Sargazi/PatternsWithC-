namespace RabbitMQ.LightTrafficStatePattern
{
    public class YellowState : ITrafficLightState
    {
        public string GetMessage()
        {
            return "Ready to stop";
        }

        public void Next(TrafficLight context)
        {
            context.ChangeState(new RedState());
        }
    }
}