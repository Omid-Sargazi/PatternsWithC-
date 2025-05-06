namespace BehavioralPattern.VisitorPattern
{
    public enum DocumentType
    {
        Invoice,
        Receipt,
        Contract,
        Payroll,
    }

    public interface IFinancialDocumentVisitor
    {
        void Visit(Invoice visitor);
        void Visit(Receipt visitor);
        void Visit(Contract visitor);
        void Visit(Payroll visitor);
    }

    public abstract class FinancialDocument
    {
        public string Id {get; set;}
        public DateTime Date {get; set;}
        public decimal Amount {get; set;}
        public DocumentType Type {get; set;}

        protected FinancialDocument(string id, DateTime date, decimal amount, DocumentType type)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Type = type;
        }
        public abstract void Accept(IFinancialDocumentVisitor visitor);
    }

    public class Invoice : FinancialDocument
    {
        public Invoice(string id, DateTime date, decimal amount, DocumentType type) : base(id, date, amount, type)
        {
        }

        public string CustomerName { get; set; }
        public List<string> Items { get; set; }
        public bool IsPaid { get; set; }
        public override void Accept(IFinancialDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Receipt : FinancialDocument
    {
        public Receipt(string id, DateTime date, decimal amount, DocumentType type) : base(id, date, amount, type)
        {
        }

        public string PaymentMethod { get; set; }
        public string ReceivedFrom { get; set; }
        public override void Accept(IFinancialDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Contract : FinancialDocument
    {
        public Contract(string id, DateTime date, decimal amount, DocumentType type) : base(id, date, amount, type)
        {
        }

        public string PartyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Terms { get; set; }
        public override void Accept(IFinancialDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Payroll : FinancialDocument
    {
        public Payroll(string id, DateTime date, decimal amount, DocumentType type) : base(id, date, amount, type)
        {
        }

        public string EmployeeName { get; set; }
        public int WorkingHours { get; set; }
        public decimal TaxAmount { get; set; }
        public override void Accept(IFinancialDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class GenerateDetailReportVisitor : IFinancialDocumentVisitor
    {
        public void Visit(Invoice visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Receipt visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Contract visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Payroll visitor)
        {
            throw new NotImplementedException();
        }
    }

    public class GenerateSummaryReport : IFinancialDocumentVisitor
    {
        public void Visit(Invoice visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Receipt visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Contract visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Payroll visitor)
        {
            throw new NotImplementedException();
        }
    }

    public class GenerateTaxReportVisitor : IFinancialDocumentVisitor
    {
        public void Visit(Invoice visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Receipt visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Contract visitor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Payroll visitor)
        {
            throw new NotImplementedException();
        }
    }
}