namespace DesignPattern.BridgePattern
{
    public interface  IImplementation
    {
        string OperationImplementation();
    }

    public class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform A.\n";
        }
    }

    public class ConcreteImplementationB : IImplementation
    {
         public string OperationImplementation()
         {
            return "ConcreteImplementationB: The result in platform B.\n";
         }
    }

    public class Abstraction
    {
        protected IImplementation _implementation;

         public Abstraction(IImplementation implementation)
        {
            this._implementation = implementation;
        }
        
        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" + 
                _implementation.OperationImplementation();
        }
    }

    public class ExtendedAbstraction : Abstraction
    {
         public ExtendedAbstraction(IImplementation implementation) : base(implementation)
        {
        }
        
        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n" +
                base._implementation.OperationImplementation();
        }
    }

}