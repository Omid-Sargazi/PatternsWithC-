namespace Patterns.AdapterPattern.DataInverter
{
    public class LegacyDataAdapter : IModernDataSystem
    {
        private LegacyDataSystem _legacySystem;
        public LegacyDataAdapter(LegacyDataSystem legacySystem)
        {
            _legacySystem = legacySystem;
        }
        
        public string ReadData()
        {
            string csvData = _legacySystem.ReadCsvData();

        // CSV رو به JSON تبدیل کن
        string[] lines = csvData.Split('\n');
        string[] headers = lines[0].Split(',');
        string[] values = lines[1].Split(',');

        string jsonData = "{";
        for (int i = 0; i < headers.Length; i++)
        {
            jsonData += $"\"{headers[i].Trim()}\": \"{values[i].Trim()}\"";
            if (i < headers.Length - 1) jsonData += ", ";
        }
        jsonData += "}";

        Console.WriteLine($"LegacyDataAdapter: Converted CSV to JSON: {jsonData}");
        return jsonData;
        }

        public void WriteData(string jsonData)
        {
            string csvData = "name,age\n";
        string cleanedJson = jsonData.Replace("{", "").Replace("}", "").Replace("\"", "");
        string[] pairs = cleanedJson.Split(',');
        string name = pairs[0].Split(':')[1].Trim();
        string age = pairs[1].Split(':')[1].Trim();
        csvData += $"{name},{age}";

        // داده‌ها رو به سیستم قدیمی بنویس
        _legacySystem.WriteCsvData(csvData);
        }
    }
}