using Azure;
using Azure.Core.Pipeline;

namespace AdvantureWorksDatabse02.Delegate
{
    public delegate void Notify();
    public class ProcessBusinessLogic
    {
        public Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Processing started...");
            // کارهای مختلف
            Console.WriteLine("Processing finished.");

            ProcessCompleted?.Invoke();
        }

        static void ShowMessage()
        {
            Console.WriteLine("Process Completed Successfully!");
        }
    }


    public class Calculator
    {
        public delegate int Calc(int x, int y);
        private Dictionary<string, Calc> dicCalc;
        public Calculator()
        {
            dicCalc = new Dictionary<string, Calc>
            {
                ["add"] = Add,
                ["multiply"] = Multilple,
                ["subtract"] = Subtract,
                ["divid"] = Divide,
            };
        }



        public void calculator(int a, int b, string operation)
        {
            if (dicCalc.ContainsKey(operation))
            {
                dicCalc[operation](a, b);
            }
            else Console.WriteLine("This operation is not valid");
        }


        private int Add(int x, int y)
        {
            return x + y;
        }

        private int Multilple(int x, int y)
        {
            return x * y;
        }

        private int Divide(int a, int b)
        {
            return a / b;
        }

        private int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}