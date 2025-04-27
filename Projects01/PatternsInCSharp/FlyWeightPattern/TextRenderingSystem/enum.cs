namespace PatternsInCSharp.FlyWeightPattern.TextRenderingSystem
{
    public enum RenderStatus
    {
        Success,
        Failed,
    }

    public interface ICharacterStyle
    {
        string Font {get;}
        int FontSize {get;}
        string Color {get;}
        RenderStatus Render(char value, int x, int y);
    }

    public class CharacterStyle : ICharacterStyle
    {
        public string Font {get;}

        public int FontSize {get;}

        public string Color {get;}

        public CharacterStyle(string font, int fontSize, string color)
        {
            Font = font;
            FontSize = fontSize;
            Color = color;
        }

        public RenderStatus Render(char value, int x, int y)
        {
            Console.WriteLine($"Rendering character '{value}' ({Font}, {FontSize}, {Color}) at ({x}, {y}): Success");
            return RenderStatus.Success;
        }

        public class CharacterStyleFactory
        {
            private Dictionary<string,ICharacterStyle> _styles = new Dictionary<string, ICharacterStyle>();
            public ICharacterStyle GetStyle(string font, int fontSize, string color)
            {
                string key = $"{font}_{fontSize}_{color}";
                if (!_styles.ContainsKey(key))
                {
                    _styles[key] = new CharacterStyle(font, fontSize, color);
                }
                return _styles[key];
            }
        }
    }
}