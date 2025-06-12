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
