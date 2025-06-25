using System.Runtime.ConstrainedExecution;

namespace DesignPattern.BuilderPattern
{
    public interface IBuilder
    {
        void StartUpOperations();
        void BuildBody();
        void InserWheels();
        void AddHeadlights();
        void EndOperations();
        Product GetVehicle();
    }

    public class Product
    {
        private List<string> parts = new List<string>();
        public void Add(string part) => parts.Add(part);

        public void Show()
        {
            Console.WriteLine("\nProduct completed as below:");
            foreach (var part in parts)
                Console.WriteLine(part);
        }
    }

    public class Car : IBuilder
    {
        private string _brandName;
        private Product _product;
        public Car(string brandName, Product product)
        {
            _brandName = brandName;
            _product = product;
        }
        public void AddHeadlights()
        {
            _product.Add("2 Headlights are added");
        }

        public void BuildBody()
        {
            _product.Add("This is a body of a Car");
        }

        public void EndOperations()
        {
            
        }

        public Product GetVehicle()
        {
            return _product;
        }

        public void InserWheels()
        {
            _product.Add("4 wheels are added");
        }

        public void StartUpOperations()
        {
            _product.Add($"Car Model name {_brandName}");
        }
    }
}