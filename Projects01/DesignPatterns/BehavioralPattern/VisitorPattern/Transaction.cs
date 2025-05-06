namespace BehavioralPattern.VisitorPattern
{
    public interface ITransactionVisitor
    {
        string Visit(Purchase visitor);
        string Visit(Sale visitor);
        string Visit(Transfer visitor);
        string Visit(BillPayment visitor);

    }
    public abstract class Transaction
    {
        public DateTime Date {get;set;}
        public decimal Amount {get; set;}
        public string ReferenceNumber {get; set;}

        public abstract void Accept(ITransactionVisitor visitor);


    }

    public class Purchase : Transaction
    {
        public override void Accept(ITransactionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Sale : Transaction
    {
        public override void Accept(ITransactionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Transfer : Transaction
    {
        public override void Accept(ITransactionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class BillPayment : Transaction
    {
        public override void Accept(ITransactionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class TaxReportVisitor : ITransactionVisitor
    {
        public string Visit(Purchase visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Sale visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Transfer visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(BillPayment visitor)
        {
            throw new NotImplementedException();
        }
    }

    public class AuditReportVisitor : ITransactionVisitor
    {
        public string Visit(Purchase visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Sale visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Transfer visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(BillPayment visitor)
        {
            throw new NotImplementedException();
        }
    }


    public class SummaryReportVisitor : ITransactionVisitor
    {
        public string Visit(Purchase visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Sale visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Transfer visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(BillPayment visitor)
        {
            throw new NotImplementedException();
        }
    }

    public class RiskAssessmentVisitor : ITransactionVisitor
    {
        public string Visit(Purchase visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Sale visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(Transfer visitor)
        {
            throw new NotImplementedException();
        }

        public string Visit(BillPayment visitor)
        {
            throw new NotImplementedException();
        }
    }
}