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


    }


    public static void ShowMessage()
    {
        Console.WriteLine("Process Completed Successfully!");
    }
}