namespace Patterns.CompositePattern.MenuRestuant
{
    public class MenuItem : IMenuComponent
    {
        private string _name;
        private decimal _price;
        public MenuItem(string name, decimal price)
        {
            _name = name;
            _price = price;            
        }
        public void Display(int depth=0)
        {
            string indent = new string(' ', depth*2);
            Console.WriteLine($"{indent}Item: {_name} - ${_price}");
        }
    }
}