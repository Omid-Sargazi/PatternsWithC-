namespace RabbitMQ.LightTraffic
{
    public interface ITrafficLightState
    {
        void Handle(TrafficLight context);
    }
}