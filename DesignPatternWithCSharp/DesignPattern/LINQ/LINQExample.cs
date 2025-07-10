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
            new Customer{Id=4,Name = "Vahid",City="Esfahan"},
            new Customer{Id=5,Name = "Vahid",City="Shiraz"},
        };

        public void RunLINQ()
        {
            var tehranCustomers = from c in customers
                                  where c.City == "Tehran"
                                  select c;

            var nameFromGorgan = from c in customers
                                 where c.City == "Gorgan"
                                 select c.Name;

            var ordered = from c in customers
                          orderby c.Name
                          select c;

            var vName = from c in customers
                        where c.Name.StartsWith("V")
                        select c.Name;

            var moreThan4 = from c in customers
                            where c.Name.Length > 4
                            select c.Name;

            
            
            foreach (var name in moreThan4)
            {
                Console.WriteLine($"{name}");
            }
        }
    }
}