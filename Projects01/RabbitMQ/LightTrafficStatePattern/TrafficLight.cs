namespace RabbitMQ.LightTrafficStatePattern
{
    public class TrafficLight
    {
        private ITrafficLightState CurrentState {get; set;}
        public List<string> Logs {get; private set;} = new List<string>();
        public TrafficLight()
        {
            CurrentState = new RedState();
            LogChange("چراغ در حالت قرمز شروع شد");
        }

        public void LogChange(string message)
        {
            string log = $"{DateTime.Now}: {message}";
            Logs.Add(log);
        }

        public void ChangeState(ITrafficLightState newState)
        {
            CurrentState = newState;
            LogChange($"حالت به {newState.GetType().Name} تغییر کرد");
        }

        public void Next()=>CurrentState.Next(this);
        public string GetMessage()=>CurrentState.GetMessage();
    }
}