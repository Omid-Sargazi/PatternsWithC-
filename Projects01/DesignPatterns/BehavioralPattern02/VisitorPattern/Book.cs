using Microsoft.VisualBasic;

namespace BehavioralPattern02.VisitorPattern
{
    public interface IVisitor
    {
        public string Name { get; }
        public double UnitPrice { get; }
        public int Quantity { get; }
        public void Accept(IProduct visitor);
    }

    public interface IProduct
    {
        void Visit(Book book);
        void Visit(Tool tool);
        void Visit(Food food);
    }

    public class Book : IVisitor
    {
        public string Name {get;}

        public double UnitPrice {get;}

        public int Quantity {get;}

        public void Accept(IProduct visitor)
        {
           visitor.Visit(this);
        }
    }

    public class Tool : IVisitor
    {
        public string Name {get;}
        public double UnitPrice {get;}

        public int Quantity {get;}

        public void Accept(IProduct visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Food : IVisitor
    {
        public string Name {get;}

        public double UnitPrice {get;}

        public int Quantity {get;}
        public DateTime ExpiryDate { get; }

        public void Accept(IProduct visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CalculateInventoryValue : IProduct
    {
        public double totalPrice {get; private set;}
       
        public void Visit(Book book)
        {
             totalPrice = book.UnitPrice * book.Quantity;
        }

        public void Visit(Tool tool)
        {
             totalPrice = tool.UnitPrice * tool.Quantity;
        }

        public void Visit(Food food)
        {
            totalPrice =  food.UnitPrice * food.Quantity;
        }
    }

    public class PrintDetails : IProduct
    {
        public void Visit(Book book)
        {
            Console.WriteLine($"Book: {book.Name}, Unit Price: {book.UnitPrice}, Quantity: {book.Quantity}");
        }

        public void Visit(Tool tool)
        {
           Console.WriteLine($"Tool: {tool.Name}, Unit Price: {tool.UnitPrice}, Quantity: {tool.Quantity}");
        }

        public void Visit(Food food)
        {
            Console.WriteLine($"Food: {food.Name}, Unit Price: {food.UnitPrice}, Quantity: {food.Quantity}, Expiry: {food.ExpiryDate.ToShortDateString()}");
        }
    }

}