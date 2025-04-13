namespace Patterns.AdapterPattern.DataInverter
{
    public class DataClient
    {
        private IModernDataSystem _dataSystem;
        public DataClient(IModernDataSystem modern)
        {
            _dataSystem = modern;
        }
        public void ProcessDate()
        {
            string data = _dataSystem.ReadData();
            Console.WriteLine($"DataClient: Received data: {data}");

        // نوشتن داده‌ها
            string newData = "{\"name\": \"Reza\", \"age\": \"40\"}";
            _dataSystem.WriteData(newData);
        }
    }
}