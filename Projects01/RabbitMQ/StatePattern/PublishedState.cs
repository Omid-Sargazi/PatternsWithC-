namespace RabbitMQ.StatePattern
{
    public class PublishedState : IState
    {
        public void Publish(Document doc)
        {
            doc.SetState(new PublishedState());
        }

        public void Render(Document doc)
        {
            Console.WriteLine("Read-only view");
        }
    }
}