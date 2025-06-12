using System.Runtime.Intrinsics.X86;
using AdvantureWorksDatabse02.Delegate;
using AdvantureWorksDatabse02.StrategyPattern;
using Microsoft.VisualBasic;

namespace AdvantureWorksDatabse02
{
    
    // See https://aka.ms/new-console-template for more information
public delegate int Calculator(int a, int b);
    public class Program
    {
        public static void Main(string[] args)
        {

            var operations = new Dictionary<string, Calculator>
            {
                ["add"] = Add,
                ["multiply"] = Multiple,
                ["subtract"] = Subtract,
                ["divide"] = Divide
            };

            string operation = "multiply";
            int a = 10, b = 5;

            if (operations.ContainsKey(operation))
            {
                int result = operations[operation](a, b);
                Console.WriteLine($"{operation}:{result}");
            }
            Console.WriteLine("Hello, World!");

            // Calculator calc = Add;
            // int result = calc(5, 3);
            // Console.WriteLine(result);

            // calc = Multiple;
            // result = calc(5, 3);
            // Console.WriteLine(result);

            var process = new PaymentProcessorGood();
            process.ProcessPayment(100, "credit");
            process.ProcessPayment(520, "paypall");

            ProcessBusinessLogic b1 = new ProcessBusinessLogic();
            b1.ProcessCompleted = ShowMessage;
            b1.StartProcess();

            Console.WriteLine("\n--- Calculator Example ---");
            var calc = new Calculatorr();
            calc.calculator(5, 3, "add");


            var people = new List<PersonInDelegate>
            {
                new PersonInDelegate{Name = "Omid",Age=42},
                new PersonInDelegate{Name = "Saeed", Age=38},
                new PersonInDelegate {Name = "Vahid", Age=36}
            };

            var processor = new PersonProcessor();
            PersonProcessor.FIlter adultFilter = p => p.Age > 38;
            processor.PrintFiltered(people, adultFilter);

            var publisher = new Publisher();
            var subscriber = new Subscriber();

            publisher.OnPublish += subscriber.Handle;
            publisher.Publish();

            Func<int, bool> isEvent = n => n % 2 == 0;
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var eventNumbers = numbers.Where(isEvent);
            foreach (var num in eventNumbers)
            {
                Console.WriteLine($"event numbers are:{num}");
            }


            var onlineShop = new OnlineShop();
            var sendMessage = new SendMessage();
            var logMessage = new LogMessage();
            var sendEmail = new SendEmail();
            onlineShop.BuyIvent += sendMessage.message;
            onlineShop.BuyIvent += logMessage.messageLog;
            onlineShop.BuyIvent += sendEmail.emailSend;

            onlineShop.buy("hiiii");


            var billPaymentSystem = new BillPaymentSystem();
            var smsService = new SmsService();
            var emailService = new EmailService();
            var logger = new Logger();
            billPaymentSystem.onPaymentSuccess += smsService.sendSms;
            billPaymentSystem.onPaymentSuccess += logger.Log;
            billPaymentSystem.onPaymentSuccess += emailService.SendEmail;
            billPaymentSystem.PayBill("buy a laptop", 100); 
           
        }

        public static int Add(int x, int y)
        {
            int sum = x + y;
            Console.WriteLine($"Add:{sum}");
            return sum;
        }

        public static int Multiple(int a, int b)
        {
            int mul = a * b;
            Console.WriteLine($"Multiple is:{mul}");
            return mul;
        }

        public static int Divide(int x, int y) => x / y;
        public static int Subtract(int x, int y) => x - y;


      
        
        static void ShowMessage()
    {
        Console.WriteLine("Process Completed Successfully!");
    }
    }
}
