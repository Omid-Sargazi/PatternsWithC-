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
}