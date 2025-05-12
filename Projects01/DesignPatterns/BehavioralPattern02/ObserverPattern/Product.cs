namespace BehavioralPattern02.ObserverPattern
{
    
    public class Product
    {
        public string name {get; set;}
        public bool isStick {get; set;}
        public Customer customer;

        public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }

        public void setInStock(bool inStock)
        {
            if(inStock && customer !=null)
            {
                customer.Update(this.name+"there is now");
            }
        }
    }

    public class Customer
    {
        private string Name {get; set;}

        public Customer(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{Name} received {message}");
        }
    }
}