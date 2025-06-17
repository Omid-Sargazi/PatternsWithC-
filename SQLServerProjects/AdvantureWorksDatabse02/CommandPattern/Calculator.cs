namespace AdvantureWorksDatabse02.CommandPattern
{
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


    }
    
}