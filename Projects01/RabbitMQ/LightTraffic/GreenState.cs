namespace RabbitMQ.LightTraffic
{
    public class GreenState : ITrafficLightState
    {
        public void Handle(TrafficLight context)
        {
            Console.WriteLine("🟢 چراغ سبز! برو.");
            context.SetState(new YellowState());
        }
    }
}