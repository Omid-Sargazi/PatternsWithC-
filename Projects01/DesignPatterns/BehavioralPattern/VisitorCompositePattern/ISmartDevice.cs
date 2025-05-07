namespace BehavioralPattern.VisitorCompositePattern
{
    public interface ISmartDevice
    {
        void Accept(IDeviceVisitor visitor);
    }

    public interface IDeviceVisitor
    {
        void Visit(LightSmart light);
    }

    public class LightSmart : ISmartDevice
    {
        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class LightSmartVisitor : IDeviceVisitor
    {
        public void Visit(LightSmart light)
        {
            throw new NotImplementedException();
        }
    }
}