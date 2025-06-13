        // See https://aka.ms/new-console-template for more information
using AdventureWorksDatabase.Data;
using AdventureWorksDatabase.Delegates;
using AdventureWorksDatabase.Models;
using Microsoft.EntityFrameworkCore;
public class Program
{
    public static void Main(string[] args)
    {



        Console.WriteLine("Hello, World!");

        var processBusinessLogic = new ProcessBusinessLogic();
        processBusinessLogic.ProcessCompleted = ShowMessage;
        processBusinessLogic.StartProcess();

        /////////////////////////////////////////////////
        var calc = new Calculator();
        calc.ShowResult(10, 20, "multiply");

        ////////////////////////////////////////////////////
        var delegatePerson = new List<DelegatePerson>
        {
            new DelegatePerson{Name="Omid", Age=42},
            new DelegatePerson{Name="Saeed", Age=38},
            new DelegatePerson{Name="Vahid", Age=36},
        };

        var personProcessor = new PersonProcessor();
        var filter = personProcessor.filterr = p => p.Age > 40;
        personProcessor.PrintFiltered(delegatePerson, filter);
        //////////////////////////////////////
        List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };
        var intProcessor = new IntProcessor();
        IntProcessor.filterNumbers eventNumbers = numbers => numbers.Where(n => n % 2 == 0).ToList();
        intProcessor.showResult(nums, eventNumbers);
    }


    public static void ShowMessage()
    {
        Console.WriteLine("Process Completed Successfully!");
    }


}