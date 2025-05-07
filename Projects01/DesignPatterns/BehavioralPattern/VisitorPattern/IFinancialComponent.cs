namespace BehavioralPattern.VisitorPattern
{
    public interface IFinancialComponent
    {
        public int Id {get;}
        public decimal Amount {get;}
        public DateTime Date {get;}

        string Accept(IFinancialVisitor visitor);
    }

    public interface IFinancialVisitor
    {
        string Visit(Invoicee invoicee);
        string Visit(DocumentFolder folder);
       
    }
    public class Invoicee : IFinancialComponent
    {
        public int Id {get;}

        public decimal Amount {get;}

        public DateTime Date {get;}

        public string Accept(IFinancialVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class DocumentFolder : IFinancialComponent
    {
        public int Id {get;}
        private List<IFinancialComponent> _components = new List<IFinancialComponent>();

        public decimal Amount()
        {
            return CalculateTotalAmount();
        }

        public DateTime Date {get;}

        decimal IFinancialComponent.Amount => throw new NotImplementedException();

        public void Add(IFinancialComponent component)
        {
            _components.Add(component);
        }

        public string Accept(IFinancialVisitor visitor)
        {
            return visitor.Visit(this);
        }

        private decimal CalculateTotalAmount()
        {
            return _components.Sum(c=>c.Amount);
        }
    }

    public class TotalAmountVisitor : IFinancialVisitor
    {
        public string Visit(Invoicee invoicee)
        {
            return $"invoice {invoicee.Id} {invoicee.Amount}";
        }

        public string Visit(DocumentFolder folder)
        {
            return $"Invoice {folder.Id} {folder.Amount}";
        }
    }
}