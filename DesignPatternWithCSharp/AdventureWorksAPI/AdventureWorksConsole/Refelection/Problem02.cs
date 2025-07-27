namespace AdventureWorksConsole.Refelection
{

    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Hello, I`m {Name} {Age} years old;");
        }
    }
    public class Problem02
    {
        public static void Run()
        {
            object obj = new Person2 { Age = 42, Name = "Omid" };


            Type type = obj.GetType();

            Console.WriteLine($"Type:" + type.Name);
            var nameProp = type.GetProperty("Name");
            Console.WriteLine($"nameProp:" + nameProp);
            var ageProp = type.GetProperty("Age");
            Console.WriteLine($"ageProp:" + ageProp);

            Console.WriteLine($"typeof(nameProp):{typeof(int)}");

            Console.WriteLine($"{nameProp.GetValue(obj)}");
            Console.WriteLine($"{ageProp.GetValue(obj)}");


            var method = type.GetMethod("SayHello");
            method.Invoke(obj, null);

        }
    }

    public class Problem03
    {
        public static void Run()
        {
            var person = new Person2
            {
                Age = 42,
                Name = "Omid"
            };

            person.SayHello();


            object obj = new Person2
            {
                Age = 42,
                Name = "Omid"
            };

            Type type = obj.GetType();
            Console.WriteLine($"Object Type is:{type.Name}");

            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"Method names:{method.Name}");
            }

            var props = type.GetProperties();
            Console.WriteLine("Properties in class:");
            foreach (var prop in props)
            {
                Console.WriteLine($"Props are:{prop.Name}");
            }

            var nameprop = type.GetProperty("Name");
            nameprop.SetValue(obj, "Saeed");
            Console.WriteLine($"name after:{nameprop.GetValue(obj)}");
        }
    }
}