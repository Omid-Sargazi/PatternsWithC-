namespace RabbitMQ.LightTrafficStatePattern
{
    public interface ITrafficLightState
    {
        public void Next(TrafficLight context);
        string GetMessage();
    }
}