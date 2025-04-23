namespace RabbitMQ.LightTrafficStatePattern
{
    public class GreenState : ITrafficLightState
    {
        public string GetMessage()
        {
            return "GO";
        }

        public void Next(TrafficLight context)
        {
            context.ChangeState(new YellowState());
        }
    }
}