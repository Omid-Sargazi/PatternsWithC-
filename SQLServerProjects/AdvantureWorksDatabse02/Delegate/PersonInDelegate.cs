namespace AdvantureWorksDatabse02.Delegate
{
    public class PersonInDelegate
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonProcessor
    {
        public delegate bool FIlter(PersonInDelegate p);
        public void PrintFiltered(List<PersonInDelegate> people, FIlter filter)
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


    public class ReportGenerator
    {
        public delegate int reportList(List<int> list);
        private Dictionary<string, reportList> _operations;

        public ReportGenerator()
        {
            _operations = new Dictionary<string, reportList>
            {
                ["sum"] = Sum,
                ["average"] = Average,
                ["big"] = BigNumber
            };
        }

        public void generateReport(List<int> list, string operation)
        {
            if (_operations.ContainsKey(operation))
            {
                _operations[operation](list);
            }
            else
            {
                Console.WriteLine("Invalid report operation.");
            }
        }

        private int Sum(List<int> nums)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }

            return sum;
        }

        private int Average(List<int> nums)
        {
            var result = Sum(nums) / nums.Count();
            return result;
        }

        private int BigNumber(List<int> nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                if (num > result)
                    result = num;
            }

            return result;
        }
    }

    public class Publisher
    {
        public delegate void Notify();
        public event Notify OnPublish;

        public void Publish()
        {
            Console.WriteLine("Publishing...");
            OnPublish?.Invoke();
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
        public event Action<string> onOrderPlaced;
        public void PlacedOrder(string item)
        {
            Console.WriteLine($"Order placed for {item}");
            onOrderPlaced?.Invoke(item);
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
        public delegate void sendNotify(string message);
        public event sendNotify BuyIvent;
        public void buy(string message)
        {
            BuyIvent?.Invoke(message);
        }
    }

    public class SendMessage
    {
        public void message(string message)
        {
            Console.WriteLine($"sent email:{message}");
        }
    }

    public class LogMessage
    {
        public void messageLog(string messae)
        {
            Console.WriteLine($"recorded log:{messae}");
        }
    }

    public class SendEmail
    {
        public void emailSend(string message)
        {
            Console.WriteLine($"sent email{message}");
        }
    }

    public class BillPaymentSystem
    {
        public delegate void PaymentHandler(string message);
        public event PaymentHandler onPaymentSuccess;

        public void PayBill(string messae, decimal amount)
        {
            Console.WriteLine($"💸 Payment of {amount} for {messae} submitted.");
            onPaymentSuccess?.Invoke($"Payment for {messae} was successful.");
        }
    }

    public class SmsService
    {
        public void sendSms(string message)
        {
            Console.WriteLine($"📱 SMS: {message}");
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
        public void Log(string message)
    {
        Console.WriteLine($"📝 Log: {message}");
    }
    }
}