namespace RabbitMQ.FactoryPattern
{
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();
        public string SomeOperation()
        {
            return "";
        }
    }
}