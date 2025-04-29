namespace PatternsInCSharp02.BridgePattern
{
    public interface IServiceStyle
    {
        string Serve();
    }

    public class NormalService : IServiceStyle
    {
        public string Serve()
        {
            return "Normal Service";
        }
    }
    public class LuxuryService : IServiceStyle
    {
        public string Serve()
        {
            return "Luxury Service";
        }
    }
    public class TakeawayService : IServiceStyle
    {
        public string Serve()
        {
            return "Takeaway Service";
        }
    }

    public abstract class Food
    {
        protected IServiceStyle _serviceStyle;
        protected Food(IServiceStyle serviceStyle)
        {
            _serviceStyle = serviceStyle;
        }

        public abstract string Prepare();
        public string Serve()
        {
            return _serviceStyle.Serve();
        }
    }

    public class Pizza : Food
    {
        public Pizza(IServiceStyle serviceStyle) : base(serviceStyle)
        {
        }

        public override string Prepare()
        {
            return "Preparing Pizza";
        }
    }

    public class QormeSabzi : Food
    {
        public QormeSabzi(IServiceStyle serviceStyle) : base(serviceStyle)
        {
        }

        public override string Prepare()
        {
            return "Preparing Qorme Sabzi";
        }
    }
}