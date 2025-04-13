namespace Patterns.AdapterPattern.DataInverter
{
    public class ModernDataSystem : IModernDataSystem
    {
        private string _jsonData = "{\"name\": \"Sara\", \"age\": \"25\"}";

        public string ReadData()
        {
            Console.WriteLine($"ModernDataSystem: Reading JSON data: {_jsonData}");
            return _jsonData;
        }

        public void WriteData(string jsonData)
        {
            _jsonData = jsonData;
            Console.WriteLine($"ModernDataSystem: Writing JSON data: {jsonData}");
        }
    }
}