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
        public string Vendor {get; set;}
        public string ProductCategory {get; set;}
        public override void Accept(ITransactionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Sale : Transaction
    {
        public string Customer {get; set;}
        public decimal Profit {get; set;}
        public override void Accept(ITransactionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Transfer : Transaction
    {
        public string FromAccount {get; set;}
        public string ToAccount {get; set;}
        public override void Accept(ITransactionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class BillPayment : Transaction
    {
         public string Payee { get; set; }
        public string BillType { get; set; }
        public string BillNumber { get; set; }
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
            return $"مالیات پرداخت قبض: {visitor.Date} به {visitor.Payee} برای {visitor.BillType} - " + 
                   $"شماره قبض: {visitor.BillNumber} - مبلغ: {visitor.Amount}";
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