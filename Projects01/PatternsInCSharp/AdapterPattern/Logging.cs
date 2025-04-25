using System.Globalization;

namespace PatternsInCSharp.AdapterPattern
{
    public class OldLogger
    {
        public void LogText(string message)
        {
            Console.WriteLine($"[TEXT LOG] {message}");
        }
    }

    public class LoggerAdapter : ILoggSyatem
    {
        private readonly ILoggSyatem _loggSyatem;
        public LoggerAdapter(ILoggSyatem loggSyatem)
        {
            _loggSyatem = loggSyatem;
        }
        public void Logger(string message)
        {
            _loggSyatem.Logger(message);
        }

        
    }

    public interface ILoggSyatem
    {
        public void Logger(string message);
    }

   
}