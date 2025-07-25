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

        // CommonTableExpression.RunQuery();

        // await ProductRanked.RunProductRanked();
        await TestQueryAdventureWork.Run();


        List<List<int>> nestedList = new List<List<int>>
        {
            new List<int>{1,2,3},
            new List<int>{4,5,6}
        };

        var result = nestedList.SelectMany(x => x);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        List<List<List<List<int>>>> fourLevelList = new List<List<List<List<int>>>>
{
    new List<List<List<int>>>
    {
        new List<List<int>>
        {
            new List<int> {1, 2},
            new List<int> {3, 4}
        },
        new List<List<int>>
        {
            new List<int> {5, 6},
            new List<int> {7, 8}
        }
    },
    new List<List<List<int>>>
    {
        new List<List<int>>
        {
            new List<int> {9, 10},
            new List<int> {11, 12}
        }
    }
};

        var result02 = fourLevelList.SelectMany(x => x.SelectMany(x=>x.SelectMany(x=>x)));
        foreach (var item in result02)
        {
            Console.WriteLine($"FourList:{item}");
        }
    }
}