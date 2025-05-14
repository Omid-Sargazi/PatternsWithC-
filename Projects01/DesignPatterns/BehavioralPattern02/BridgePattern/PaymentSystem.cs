namespace BehavioralPattern02.BridgePattern
{
    public interface IPaymentSystemRenderer
    {
        void Render(string title, string content);
    }

    public class PdfRenderer : IPaymentSystemRenderer
    {
        public void Render(string title, string content)
        {
            Console.WriteLine($"[PDF] {title} - {content}");
        }
    }

    public class HtmllRenderer : IPaymentSystemRenderer
    {
        public void Render(string title, string content)
        {
            Console.WriteLine($"<html><h1>{title}</h1><p>{content}</p></html>");
        }
    }

    public class InvoicePaymemtSystem
    {
        public string Title {get; set;}
        public string Content {get; set;}
        protected IPaymentSystemRenderer _paymentSystemRenderer;
        public InvoicePaymemtSystem(IPaymentSystemRenderer paymentSystemRenderer)
        {
            _paymentSystemRenderer = paymentSystemRenderer;
        }
        public void Display()
        {
            _paymentSystemRenderer.Render(Title, Content);
        }
    }

    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount} using Credit Card.");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount} using PayPal.");
        }
    }

    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;
        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ProcessPayment(decimal amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }
}