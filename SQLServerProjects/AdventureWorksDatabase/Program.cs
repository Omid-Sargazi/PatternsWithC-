﻿// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;
using AdventureWorksDatabase.Data;
using AdventureWorksDatabase.Delegates;
using AdventureWorksDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        //////////////////////////////////////////////
        var report = new ReportGenerator();
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        report.ShowResult(list, "sum");

        ///////////////////////////////////////////////
        var publisher = new Publisher();
        var subscriber = new Subscriber();
        publisher.onPublish += subscriber.Handle;
        publisher.Publish();

        Func<int, bool> isEven = n => n % 2 == 0;
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        var evenNumbers = numbers.Where(isEven);
        ///////////////////////////////////////////////
        var shop = new Shop();
        var notify = new NotificationService();
        shop.OnOrderPlaced += notify.SendEmail;
        shop.PlaceOrder("laptop");

        //////////////////////////////////////////
        var onlineshop = new OnlineShop();
        var log = new LogMessage();
        var message = new SendMessage();
        var email = new SendEmail();
        onlineshop.BuyIvent += log.messageLog;
        onlineshop.BuyIvent += message.sendMessage;
        onlineshop.BuyIvent += email.emailSend;
        onlineshop.buy("Laptop");
        ///////////////////////////////////////
        var bill = new BillPaymentSystem();
        var smsService = new SmsService();
        var emeilService = new EmailService();
        var logger = new Logger();
        bill.OnPaymentSuccess += smsService.SendSMS;
        bill.OnPaymentSuccess += emeilService.SendEmail;
        bill.OnPaymentSuccess += logger.LogMessage;
        bill.PayBill("Billllllllll");
        ///////////////////////////////
        var print = new MultiPrinter();
        print.printHandler += print.Print1;
        print.printHandler += print.Print2;
        print.printHandler += print.Print3;
        print.ExecuteAll();
        /////////////////////////////////////
        var bus = new EventBus();
        bus.Subscribe("order", msg => Console.WriteLine($"order handled:{msg}"));
        bus.Subscribe("order", msg => Console.WriteLine($"order handled:{msg}"));

        bus.Publish("order", "Product #123 ordered");

        /////////////////////////////////////////////
    }


    public static void ShowMessage()
    {
        Console.WriteLine("Process Completed Successfully!");
    }



}