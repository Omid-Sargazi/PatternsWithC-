namespace CompositePattern.Pattern01
{
    public class App
    {
        public Theme CurrentTheme {get; set;}
        public List<Button> Components { get; set; } = new List<Button>();

        public App()
        {
            CurrentTheme = new Theme("White", "Black", "Arial", 12); // تم روشن
        }

        public void AddComponent(Button button)
        {
            Components.Add(button);
            button.ApplyTheme(CurrentTheme);
        }

        public void SwitchTheme(Theme newTheme)
        {
            CurrentTheme = newTheme;
            foreach(var component in Components)
            {
                component.ApplyTheme(CurrentTheme);
            }
        }
    }
}