namespace DesignPattern.AbstractFactory
{
    public interface IButton
    {
        void Render();
        void OnClick(Action action);
    }

    public interface ICheckBox
    {
        void Render();
        void Toggle();
    }


    public interface ITextBox
    {
        void Render();
        void SetTextBox(string text);
    }

    public class WinButton : IButton
    {
        public void OnClick(Action action)
        {
            Console.WriteLine("Windows button click event attached");
            action?.Invoke();
        }

        public void Render()
        {
            Console.WriteLine("Rendering a Windows-style button");
        }
    }

    public class WinTextBox : ITextBox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows-style textbox");
        }

        public void SetTextBox(string text)
        {
            Console.WriteLine($"Windows textbox set to {text}");
        }
    }

    public class WinCheckBox : ICheckBox
    {
        private bool _isChecked;

        public void Render()
        {
            Console.WriteLine($"Rendering Windows checkbox. Checked: {_isChecked}");
        }

        public void Toggle()
        {
            _isChecked = !_isChecked;
            Console.WriteLine($"Windows checkbox toggled to {_isChecked}");
        }
    }


    public class MacButton : IButton
    {
        public void OnClick(Action action)
        {
            Console.WriteLine("Mac button click event attached");
            action?.Invoke();
        }

        public void Render()
        {
            Console.WriteLine("Rendering a Mac-style button");
        }
    }

    public class MacTextBox : ITextBox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac-style textbox");
        }

        public void SetTextBox(string text)
        {
            Console.WriteLine($"Windows textbox set to {text}");
        }
    }

    public class MacCheckBox : ICheckBox
    {
        private bool _isChecked;

        public void Render()
        {
            Console.WriteLine($"Rendering Mac checkbox. Checked: {_isChecked}");
        }

        public void Toggle()
        {
            _isChecked = !_isChecked;
            Console.WriteLine($"Mac checkbox toggled to {_isChecked}");
        }
    }


    public interface IUIFactory
    {
        IButton CreateButton();
        ICheckBox CreateCheckBox();
        ITextBox CreateTextBox();
    }

    public class WinUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new WinCheckBox();
        }

        public ITextBox CreateTextBox()
        {
            return new WinTextBox();
        }
    }

    public class MacUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new MacCheckBox();
        }

        public ITextBox CreateTextBox()
        {
            return new MacTextBox();
        }
    }

    public class ClientUI
    {
        private readonly IButton _button;
        private readonly ICheckBox _checkBox;
        private readonly ITextBox _textBox;

        public ClientUI(IUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkBox = factory.CreateCheckBox();
            _textBox = factory.CreateTextBox();
        }

        public void RenderUI()
        {
            _button.Render();
            _checkBox.Render();
            _textBox.Render();
        }

        public void SimulateUserInteraction()
        {
            _button.OnClick(() => Console.WriteLine("Button CLicked."));
            _checkBox.Toggle();
            _textBox.SetTextBox("Hello Abstract Factory!");
        }


    }
    
}