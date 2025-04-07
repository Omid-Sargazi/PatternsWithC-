namespace CompositePattern.Pattern01
{
    public class Theme
    {
       public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }

       public Theme(string bgColor, string textColor, string fontFamily, int fontSize)
    {
        BackgroundColor = bgColor;
        TextColor = textColor;
        FontFamily = fontFamily;
        FontSize = fontSize;
    }

       
    }
}