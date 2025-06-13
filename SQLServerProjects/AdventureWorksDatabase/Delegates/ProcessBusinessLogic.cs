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

        public  calculator defineCalculatoe;
        public void ShowResult(int a, int b, string opr)
        {
            if (operators.ContainsKey(opr))
            {
                Console.WriteLine($"Calculate{operators[opr](a,b)}");
                defineCalculatoe?.Invoke(a,b);
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
    
}