using FluentAssertions;

namespace AdventureWorksConsole.Refelection
{
    public class Problem01
    {
        public static void Run()
        {
            int x = 100;
            string y = "ReflectionAI";
            object ox = x;
            object oy = y;

            Console.WriteLine($"x is {x.GetType()}");
            Console.WriteLine($"y is {y.GetType()}");
            Console.WriteLine($"ox is {ox.GetType()}");
            Console.WriteLine($" oy is {oy.GetType()}");

            Console.WriteLine($"typeof(int) is {typeof(int)}");
            Console.WriteLine($"typeof(string) is {typeof(string)}");


            var person = new Person
            {
                Age = 42,
                Name = "Omid"
            };

            person.SayHello();



            object obj = new Person
            {
                Age = 42,
                Name = "omid"
            };

            Type type = obj.GetType();
            Console.WriteLine($"Object type is {type.Name}");

            var methods = type.GetMethods();
            Console.WriteLine("Methods in class");
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }


            var props = type.GetProperties();
            Console.WriteLine($"Properties in class:");
            foreach (var prop in props)
            {
                Console.WriteLine($"{prop.Name}==============>{prop.GetValue(obj)}");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Hi I`m {Name} and I`m {Age} years old");
        }

    }
}