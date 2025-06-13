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
        public filterNumbers filter;

        public void showResult(List<int> nums, filterNumbers filter)
        {
            foreach (var num in nums)
            {
                Console.WriteLine($"the result is {num} after filtering");
            }
        }
    }
    
}