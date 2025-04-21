namespace RabbitMQ.LightTraffic
{
    public class RedState : ITrafficLightState
    {
        public void Handle(TrafficLight context)
        {
            Console.WriteLine("🔴 چراغ قرمز! توقف کن.");
            context.SetState(new GreenState());
        }
    }
}