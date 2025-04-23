namespace RabbitMQ.StatePattern
{
    public class DraftState : IState
    {
        public void Publish(Document doc)
        {
            
        }

        public void Render(Document doc)
        {
            Console.WriteLine("Editing view");
        }
    }
}