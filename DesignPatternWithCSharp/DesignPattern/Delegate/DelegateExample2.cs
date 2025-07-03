using System.Reflection.Metadata;

namespace DesignPattern.Delegate
{
    public class DelegateProblem02
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


    public class DelegateProblem03
    {
        public delegate int Cal(int a, int b);

        public Cal cal;

        public void Calculate(int a, int b)
        {
            Console.WriteLine("Processing numbers...");
            cal?.Invoke(a, b);
        }
    }

    public class CalculateDelegate
    {
        public delegate int Calculate(int a, int b);

        public Calculate calculate;

        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a, int b)
        {
            return a - b;
        }
        public void Calculator(string method)
        {
            if (method == "+")
            {
                calculate = Add;

            }
            else if (method == "-")
            {
                calculate = Minus;
            }
        }
    }

    public class DelegateProblem04
    {
        public delegate string JoinWords(string s1, string s2);

        public JoinWords joinWords;

        public string ShowResult(string s1, string s2)
        {
            joinWords = Join1;
            return joinWords(s1, s2);
        }


        protected string Join1(string s1, string s2)
        {
            return $"{s1} + {s2}";
        }
    }

    public class Personn
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonProcessor
    {
        public delegate bool Filter(Personn person);



        public void PrintFiltered(List<Personn> people, Filter filter)
        {
            foreach (var person in people)
            {
                if (filter(person))
                {
                    Console.WriteLine($"{person.Name}, {person.Age}");
                }
            }
        }

        public void PrintFiltered02(List<Personn> people, Func<Personn, bool> filter)
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
}