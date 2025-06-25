using System.IO.Compression;

namespace DesignPattern.BuilderPattern
{
    public interface IFluentVehicleBuilder
    {
        IFluentVehicleBuilder StartUp(string brand);
        IFluentVehicleBuilder BuildBody();
        IFluentVehicleBuilder InsertWheels();
        IFluentVehicleBuilder AddHeadlights();
        IFluentVehicleBuilder End();
        Product Build();
    }

    class FluentCarBuilder : IFluentVehicleBuilder
    {
        private string _brand;
        private Product _product = new Product();

        public IFluentVehicleBuilder AddHeadlights()
        {
            _product.Add("2 Headlights are added");
            return this;
        }

        public Product Build()
        {
            return _product;
        }

        public IFluentVehicleBuilder BuildBody()
        {
            _product.Add("This is a body of a Car");
            return this;
        }

        public IFluentVehicleBuilder End()
        {
            return this;
        }

        public IFluentVehicleBuilder InsertWheels()
        {
            _product.Add("4 wheels are added");
            return this;
        }

        public IFluentVehicleBuilder StartUp(string brand)
        {
            _brand = brand;
            _product.Add($"Car Model name: {_brand}");
            return this;
        }

    }

    public class FluentMotorcycleBuilder : IFluentVehicleBuilder
    {
        private string _brand;
        private Product _product = new Product();
        public IFluentVehicleBuilder AddHeadlights()
        {
            _product.Add("1 Headlight is added");
            return this;
        }

        public Product Build()
        {
            return _product;
        }

        public IFluentVehicleBuilder BuildBody()
        {
            _product.Add("This is a body of a Motorcycle");
            return this;
        }

        public IFluentVehicleBuilder End()
        {
            _product.Add($"Motorcycle Model name: {_brand}");
            return this;
        }

        public IFluentVehicleBuilder InsertWheels()
        {
            _product.Add("2 wheels are added");
            return this;
        }

        public IFluentVehicleBuilder StartUp(string brand)
        {
            _brand = brand;
            return this;
        }
    }
}