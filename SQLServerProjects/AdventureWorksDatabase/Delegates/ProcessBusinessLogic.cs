using System.Globalization;

namespace AdventureWorksDatabase.Delegates
{
    public class ProcessBusinessLogic
    {
        public delegate void Notify();
        public Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Processing started...");
            Console.WriteLine("Processing finished.");
            ProcessCompleted?.Invoke();

        }

    }

    public class Calculator
    {
        public delegate int calculator(int x, int y);
        public Dictionary<string, calculator> operators;
        public Calculator()
        {
            operators = new Dictionary<string, calculator>
            {
                ["add"] = Add,
                ["subtrac"] = subtract,
                ["multiply"] = multiply,
                ["divided"] = divided,
            };
        }

        public calculator defineCalculatoe;
        public void ShowResult(int a, int b, string opr)
        {
            if (operators.ContainsKey(opr))
            {
                Console.WriteLine($"Calculate{operators[opr](a, b)}");
                defineCalculatoe?.Invoke(a, b);
            }
            else Console.WriteLine("the operation is not correct");
        }

        private int Add(int a, int b)
        {
            return a + b;
        }

        private int multiply(int a, int b)
        {
            return a * b;
        }

        private int subtract(int a, int b)
        {
            return a - b;
        }

        private int divided(int a, int b)
        {
            return a / b;
        }
    }

    public class DelegatePerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonProcessor
    {
        public delegate bool Filterr(DelegatePerson person);
        public Filterr filterr;
        public void PrintFiltered(List<DelegatePerson> people, Filterr filter)
        {
            foreach (var person in people)
            {
                if (filter(person))
                {
                    Console.WriteLine($"{person.Name}, {person.Age}");
                }
            }
        }
    }


    public class IntProcessor
    {
        public delegate List<int> filterNumbers(List<int> nums);

        public void showResult(List<int> nums, filterNumbers filter)
        {
            var filterNumbers = filter(nums);

            foreach (var num in filterNumbers)
            {
                Console.WriteLine($"the result is {num} after filtering");
            }
        }
    }


    public class ReportGenerator
    {
        public delegate int transformList(List<int> nums);
        private Dictionary<string, transformList> _operators;
        public ReportGenerator()
        {
            _operators = new Dictionary<string, transformList>
            {
                ["sum"] = SumList,
                ["average"] = Average,
                ["big"] = Biggest,
            };
        }

        public void ShowResult(List<int> list, string operation)
        {
            if (_operators.ContainsKey(operation))
            {
                _operators[operation](list);
            }
            else
            {
                Console.WriteLine("There isn't operation. please correct operation.");
            }
        }

        private int SumList(List<int> nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                result += num;
            }
            Console.WriteLine($"Sum is{result}");

            return result;
        }

        private int Average(List<int> nums)
        {
            Console.WriteLine("Average");
            return 2;
        }

        private int Biggest(List<int> nums)
        {
            Console.WriteLine($"the Biggest number in the list.");
            return 10;
        }

    }
    public class Publisher
    {
        public delegate void Notify();
        public event Notify onPublish;
        public void Publish()
        {
            Console.WriteLine("Publishing...");
            onPublish.Invoke();
        }
    }

    public class Subscriber
    {
        public void Handle()
        {
            Console.WriteLine("Subscriber received notification.");
        }
    }

    public class Shop
    {
        public event Action<string> OnOrderPlaced;
        public void PlaceOrder(string item)
        {
            Console.WriteLine($"Order placed for {item}");
            OnOrderPlaced?.Invoke(item);
        }
    }

    public class NotificationService
    {
        public void SendEmail(string item)
        {
            Console.WriteLine($"Email sent for: {item}");
        }
    }

    public class OnlineShop
    {
        public event Action<string> BuyIvent;
        public void buy(string message)
        {
            Console.WriteLine("Buying process started...");
            BuyIvent?.Invoke(message);
        }

    }
    public class SendMessage
    {
        public void sendMessage(string message)
        {
            Console.WriteLine($"📱 SMS sent: {message}");
        }
    }

    public class LogMessage
    {
        public void messageLog(string message)
        {
            Console.WriteLine($"📝 Log recorded: {message}");
        }
    }

    public class SendEmail
    {
        public void emailSend(string message)
        {
            Console.WriteLine($"📧 Email sent: {message}");
        }
    }

    public class BillPaymentSystem
    {

        public event Action<string> OnPaymentSuccess;
        public void PayBill(string message)
        {
            OnPaymentSuccess?.Invoke(message);
        }
    }

    public class SmsService
    {
        public void SendSMS(string message)
        {
            Console.WriteLine($"Sent SMS: {message}");
        }
    }

    public class EmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"📧 Email: {message}");
        }
    }

    public class Logger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Log Message: {message}");
        }
    }


    public class MultiPrinter
    {
        public delegate void PrintHandler();
        public void Print1() => Console.WriteLine("🖨️ Print1 executed");
        public void Print2() => Console.WriteLine("🖨️ Print2 executed");
        public void Print3() => Console.WriteLine("🖨️ Print3 executed");
    }
    
}