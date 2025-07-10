namespace DesignPattern.LINQ
{
    /// <summary>
    /// var result = from item in collection
    /// where ...
    /// orderby 
    /// selec
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        
    }
    public class LINQExample
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer{Id=1,Name = "Omid",City="Tehran"},
            new Customer{Id=2,Name = "Saeed",City="Lux"},
            new Customer{Id=3,Name = "Vahid",City="Gorgan"},
        };

        public void RunLINQ()
        {
            var tehranCustomers = from c in customers
                                  where c.City == "Tehran"
                                  select c;

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Name}-{customer.City}");
            }
        }
    }
}