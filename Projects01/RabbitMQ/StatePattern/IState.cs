namespace RabbitMQ.StatePattern
{
    public interface IState
    {
        void Publish(Document doc);
        void Render(Document doc);
    }
}