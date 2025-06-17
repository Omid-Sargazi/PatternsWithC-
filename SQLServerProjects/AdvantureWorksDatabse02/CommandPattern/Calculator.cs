namespace AdvantureWorksDatabse02.CommandPattern
{
    public interface ICalculateCommand
    {
        void Execute();
        void Undo();
    }

  
    public class Calculator
    {
        public double Value {get; private set;}
        public void Add(double number)
        {
            Vahid+=number;
            Console.WriteLine($"Added {number}. Result: {Value}");
        }

         public void Subtract(double number)
        {
            Value -= number;
            Console.WriteLine($"Subtracted {number}. Result: {Value}");
        }

        public void Multiply(double number)
        {
            Value *= number;
            Console.WriteLine($"Multiplied by {number}. Result: {Value}");
        }

         public void Divide(double number)
    {
        if (number != 0)
        {
            Value /= number;
            Console.WriteLine($"Divided by {number}. Result: {Value}");
        }
        else
        {
            Console.WriteLine("Cannot divide by zero!");
        }
    }


    public class AddCommand : ICalculateCommand
    {
        private Calculator _calculator;
        private double _operand;

        public AddCommand(Calculator calculator,double operand)
        {
            _calculator = calculator;
            _operand = operand;
        }
    }

        public void Execute()
        {
            _calculator.Add(_operand);
            Console.WriteLine($"Added {_operand}. Result: {_calculator.Value}");
        }

        public void Undo()
        {
            _calculator.Subtract(_operand);
            Console.WriteLine($"Undo: Subtracted {_operand}. Result: {_calculator.Value}");
        }


    }

    public class SubtractCommand : ICommand
{
    private Calculator _calculator;
    private double _operand;

    public SubtractCommand(Calculator calculator, double operand)
    {
        _calculator = calculator;
        _operand = operand;
    }

    public void Execute()
    {
        _calculator.Subtract(_operand);
        Console.WriteLine($"Subtracted {_operand}. Result: {_calculator.Value}");
    }

    public void Undo()
    {
        _calculator.Add(_operand);
        Console.WriteLine($"Undo: Added {_operand}. Result: {_calculator.Value}");
    }
}

}