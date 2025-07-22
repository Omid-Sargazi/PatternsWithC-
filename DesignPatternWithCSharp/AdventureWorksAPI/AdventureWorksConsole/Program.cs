using System.Security.Cryptography;
using System.Threading.Tasks;
using AdventureWorksAPI.Models;
using AdventureWorksConsole.QueriesExample;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Hello");
        // await Example1.Run();

        CommonTableExpression.RunQuery();
    }
}