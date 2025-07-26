using System.Reflection;
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

            // Console.WriteLine($"x is {x.GetType()}");
            // Console.WriteLine($"y is {y.GetType()}");
            // Console.WriteLine($"ox is {ox.GetType()}");
            // Console.WriteLine($" oy is {oy.GetType()}");

            // Console.WriteLine($"typeof(int) is {typeof(int)}");
            // Console.WriteLine($"typeof(string) is {typeof(string)}");


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

            var nameProp = type.GetProperty("Name"); Console.WriteLine($"name before :{nameProp.GetValue(obj)}");

            nameProp.SetValue(obj, "Saeed");
            Console.WriteLine($"Name after is:{nameProp.GetValue(obj)}");

            var method1 = type.GetMethod("SayHello");
            method1.Invoke(obj, null);
        }


        public static void Run2()
        {
            object obj = new Person { Name = "Saeed", Age = 38 };
            Type type = obj.GetType();

            Console.WriteLine($"Inspecting Type :{type.Name}");

            Console.WriteLine($"Properties");
            foreach (var prop in type.GetProperties())
            {
                var value = prop.GetValue(obj);
                Console.WriteLine($"{prop.Name}({prop.PropertyType.Name})={value}");
            }


            Console.WriteLine($"\n Methods:");
            foreach (var method in type.GetMethods().Where(m => m.DeclaringType == type))
            {
                Console.WriteLine($"--{method.Name} ({method.GetParameters().Length} params)");
            }
        }


        public static void Run3()
        {
            Console.WriteLine("Runnnnnn3==================>");
            Type type = typeof(Person);
            var ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Constructors:");
            foreach (var ctor in ctors)
            {
                var parameters = ctor.GetParameters();
                Console.WriteLine($"{(ctor.IsPublic ? "public" : "non-public")} {type.Name}({string.Join(", ", parameters.Select(p => p.ParameterType.Name + p.Name))})");

            }

            var person11 = (Person)Activator.CreateInstance(type);
            var person12 = (Person)Activator.CreateInstance(type, "Omid", 42);
            Console.WriteLine(person12);

        }
    }

    public class Person
    {
        public Person()
        {
            Name = "Unknown";
            Age = 0;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        private Person(string name)
        {
            Name = name;
            Age = -1;
        }

        public override string ToString()
        {
            return $"{Name},({Age})";
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Hi I`m {Name} and I`m {Age} years old");
        }

        public void Walk(int steps)
        {
            Console.WriteLine($"Walking {steps} steps...");
        }

    }
}