namespace DesignPattern.CSharpBook
{
    public class Person(string firstName, string lastName)
    {
        public string GetFullName() => $"{firstName} {lastName}";
    }

    public class Car(string brand, string model)
    {
        public void DisplayInfo() => Console.WriteLine($"brand is {brand},model is{model}");
    }

    public class Book(string title, string author)
    {
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;

        public void DisplayInfo() => Console.WriteLine($"{Title} By {Author}");
    }
}