namespace RabbitMQ.LightTraffic
{
    public class YellowState : ITrafficLightState
    {
        public void Handle(TrafficLight context)
        {
            Console.WriteLine("🟡 چراغ زرد! آماده توقف باش.");
            context.SetState(new RedState());
        }
    }
}