namespace Patterns.AdapterPattern.DataInverter
{
    public interface IModernDataSystem
    {
        string ReadData(); // داده‌ها رو به فرمت JSON برگردونه
        void WriteData(string jsonData);
    }
}