
namespace RabbitMQ.LightTrafficStatePattern
{
    public class RedState : ITrafficLightState
    {
        public string GetMessage()
        {
            return "Stop";
        }

        public void Next(TrafficLight context)
        {
            context.ChangeState(new GreenState());
        }
    }
}