namespace PatternsInCSharp.AdapterPattern
{
    public class TranslationSystem
    {
        public string TranslateToXml(string text, string targetLanguage)
        {
            return $"<translation lang='{targetLanguage}'>{text}</translation>";
        }
    }

    public interface ITranslationService
    {
        string Translate(string text, string targetLanguage);
    }

    public class TranslateAdapter : ITranslationService
    {
        private readonly TranslationSystem _translation;
        public TranslateAdapter(TranslationSystem translation)
        {
            _translation = translation;
        }
        public string Translate(string text, string targetLanguage)
        {
            return _translation.TranslateToXml(text, targetLanguage);
        }
    }
}