namespace Patterns.CompositePattern.MenuRestuant
{
    public class Menu : IMenuComponent
    {
        private string _name;
        private List<IMenuComponent> _menuComponents;
        public Menu(string name)
        {
            _name = name;
            _menuComponents = new List<IMenuComponent>();
        }
        public void Add(IMenuComponent menuComponent)
        {
            _menuComponents.Add(menuComponent);
        }
        public void Display(int depth = 0)
        {
            string indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}Menu: {_name}");
            foreach (var component in _menuComponents)
            {
                component.Display(depth + 1);
            }
        }
    }
}