using System.Reflection.Metadata.Ecma335;

namespace Patterns.AdapterPattern.DataInverter
{
    public class LegacyDataSystem
    {
        public string FetchData()
        {
            return "Alice|30|New York";
        }
    }
}