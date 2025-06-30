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
    
}