namespace CompositePattern.Pattern01
{
    public class Button
    {
        public string Text {get; set;}
        public string Color {get; set;}

        public void ApplyTheme(Theme theme)
        {
            if(string.IsNullOrEmpty(Color))
            {
                Color = theme.TextColor;
            }
        }

        public void Render()
        {
            Console.WriteLine($"دکمه: {Text} با رنگ {Color}");
        }
    }
}