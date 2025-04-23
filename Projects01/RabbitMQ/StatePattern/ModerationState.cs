namespace RabbitMQ.StatePattern
{
    public class ModerationState : IState
    {
        public void Publish(Document doc)
        {
            throw new NotImplementedException();
        }

        public void Render(Document doc)
        {
            Console.WriteLine("Preview view");
        }
    }
}