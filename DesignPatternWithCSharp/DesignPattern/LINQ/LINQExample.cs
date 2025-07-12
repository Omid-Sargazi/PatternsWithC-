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
            new Customer { Id= 1,Name = "Omid",City="Tehran"},
            new Customer { Id= 2,Name = "Saeed",City="Lux"},
            new Customer { Id= 3,Name = "Vahid",City="Gorgan"},
            new Customer { Id= 4,Name = "Vahid",City="Esfahan"},
            new Customer { Id= 5,Name = "Vahid",City="Shiraz"},
            new Customer { Id = 6, Name = "Amir", City = "Tehran" },
            new Customer { Id = 7, Name = "Ali", City = "Tehran" },
            new Customer { Id = 8, Name = "Sara", City = "Shiraz" },
            new Customer { Id = 9, Name = "Reza", City = "Tehran" },
            new Customer { Id = 10, Name = "Maryam", City = "Isfahan" },
            new Customer { Id = 11, Name = "Mehdi", City = "Shiraz" },
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

            var VNameFromGorgan = from c in customers
                                  where c.Name.StartsWith("V") && c.City == "Gorgan"
                                  select c;
            var groups = from c in customers
                         group c by c.City;

            foreach (var group in groups)
            {
                Console.WriteLine($"City:{group.Key}");
                foreach (var customer in group)
                {
                    Console.WriteLine($"-{customer.Name}");
                }
            }


            var cityCounts = from c in customers
                             group c by c.City into g
                             select new { City = g.Key, Count = g.Count() };

            foreach (var item in cityCounts)
            {
                Console.WriteLine($"{item.City} : {item.Count}");
            }


            var popularCities = from c in customers
                                group c by c.City into g
                                where g.Count() > 1
                                select new { City = g.Key, Count = g.Count() };

            var nameGroups = from c in customers
                             group c by c.Name[0] into g
                             orderby g.Key
                             select new { FirstLetter = g.Key, Count = g.Count(), Names = g };

            foreach (var group in nameGroups)
            {
                Console.WriteLine($"Names starting with:{group.FirstLetter}: {group.Count}");
                foreach (var c in group.Names)
                {
                    Console.WriteLine($"- {c.Name}");
                }

            }

            var customerMoreThan4 = from c in customers
                                    group c by c.City into g
                                    where g.All(c => c.Name.Length > 4)
                                    select new { City = g.Key, Customer = g.ToList() };

            foreach (var group in customerMoreThan4)
            {
                Console.WriteLine($"City:{group.City}");
                foreach (var c in group.Customer)
                {
                    Console.WriteLine($"-{c.Name}");
                }
            }

            var orderedCities = from c in customers
                                group c by c.City into g
                                orderby g.Count() descending
                                select new { City = g.Key, Count = g.Count() };
            foreach (var item in orderedCities)
            {
                Console.WriteLine($"{item.City}: {item.Count} customer");
            }


            var namesByCity = from c in customers
                              group c by c.City into g
                              select new
                              {
                                  City = g.Key,
                                  names = string.Join(",", g.Select(c => c.Name)),
                              };
            foreach (var item in namesByCity)
            {
                Console.WriteLine($"{item.City}:{item.names}");
            }
            
            foreach (var name in moreThan4)
                {
                    Console.WriteLine($"{name}");
                }
        }
    }
}