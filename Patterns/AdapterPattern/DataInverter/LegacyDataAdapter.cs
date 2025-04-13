namespace Patterns.AdapterPattern.DataInverter
{
    public class LegacyDataAdapter : IModernDataSystem
    {
        private LegacyDataSystem _legacyData;
        public LegacyDataAdapter()
        {
            _legacyData = new LegacyDataSystem();
        }
        public string GetData()
        {
            string rawData =  _legacyData.FetchData();
            string[] parts = rawData.Split('|');
            string name = parts[0];
            int age = int.Parse(parts[1]);
            string city = parts[2];

            string jsonData = $"{{\"name\":\"{name}\",\"age\":{age},\"city\":\"{city}\"}}";
            return jsonData;
        }
    }
}