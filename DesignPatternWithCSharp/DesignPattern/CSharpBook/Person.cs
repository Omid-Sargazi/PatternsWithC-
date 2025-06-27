namespace DesignPattern.CSharpBook
{
    public class Person(string firstName, string lastName)
    {
        public string GetFullName() => $"{firstName} {lastName}";
    }
}