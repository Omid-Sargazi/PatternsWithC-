using System.Reflection.Metadata.Ecma335;

namespace Patterns.AdapterPattern.DataInverter
{
    public class LegacyDataSystem
    {
       private string _csvData = "name,age\nAli,30"; // داده‌های نمونه به فرمت CSV

        public string ReadCsvData()
        {
            Console.WriteLine("LegacyDataSystem: Reading CSV data...");
            return _csvData;
        }

        public void WriteCsvData(string csvData)
        {
            _csvData = csvData;
            Console.WriteLine($"LegacyDataSystem: Writing CSV data: {csvData}");
        }
    }
}