namespace DesignPatterns.AbstractFactory
{
    public interface IButton
    {
        void Render();
    }

    public interface IWindow
    {
        void Render();
    }

    public class WinButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows-style button (rectangular, gray).");
        }
    }

    public class WinWindow : IWindow
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows-style window (rectangular, gray).");
        }
    }

    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac-style button (rounded, colorful).");
        }
    }
    public class MacWindow : IWindow
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac-style window (rounded, colorful).");
        }
    }

    public interface IUIFactory
    {
        IButton CreateButton();
        IWindow CreateWindow();
    }

    public class UIWindow : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public IWindow CreateWindow()
        {
            return new WinWindow();
        }
    }

    public class UIMac : IUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public IWindow CreateWindow()
        {
            return new MacWindow();
        }
    }

    public class ClientUI
    {
        private IUIFactory _factory;
        private IButton _button;
        private IWindow _window;
        public ClientUI(IUIFactory factory)
        {
            _button = factory.CreateButton();
            _window = factory.CreateWindow();
        }

        public void Render()
        {
            _button.Render();
            _window.Render();
        }
    }
}