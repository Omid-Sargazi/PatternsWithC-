using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using DesignPattern.AbstractFactory;
using DesignPattern.BuilderPattern;
using DesignPattern.CSharpBook;
using DesignPattern.Delegate;
using DesignPattern.LeetCode;
using DesignPattern.PrototypePattern;
using DesignPattern.ProxyPattern;
using DesignPattern.ThreadConcept;
using System.Threading;
using DesignPattern.MediatorPattern;
using DesignPattern.Tasks;
using DesignPattern.YeldExample;
using DesignPattern.LINQ;
using DesignPattern.ChainOfResponsibility;
using Microsoft.VisualBasic;
using DesignPattern.BridgePattern;

public class Program
{

    // static async Task<string> GetWebsiteContentAsync()
    // {
    //     Console.WriteLine("Calling website...");
    //     HttpClient client = new HttpClient();
    //     string content = await client.GetStringAsync("https://example.com");
    //     Console.WriteLine("Website response received.");
    //     return content;
    // }
    public static async Task Main(string[] args)
    {
        // Console.WriteLine($"DesignPattern");
        // Console.WriteLine("Start Main");
        //  string resultttt = await GetWebsiteContentAsync();
        //  Console.WriteLine("Content length: " + resultttt.Length);
        //     Console.WriteLine("End Main");

        //=================================
        Console.WriteLine("==============================ChainOfResponsibility======================");
        ClientChain.HandleChain();

        Console.WriteLine("==============================TAskkkkkkkk======================");

        TaskExceptions.SynchronizationTasks();




        Console.WriteLine("==============================LeetCode======================");
        var sumTwonumber = new SumTwoNumber();
        int[] nums = new int[] { 7, 2, 15, 13 };
        int target = 9;
        var res = sumTwonumber.RunSumTwoNumber(nums, target);
        for (int i = 0; i < res.Length; i++)
        {
        Console.WriteLine($"Find Two Number{res[i]}");            
        }
        //=================================

        //==================================
        Console.WriteLine("Bridge Pattern.=======================");
        
        Console.WriteLine(".=======================Bridge Pattern");

        //==================================


        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        IEnumerable<int> eventNumbers = numbers.Where(x => x % 2 == 0);
        foreach (var num in eventNumbers)
        {
            Console.WriteLine($"events numbers are: {num}");
        }


        var chatRum = new ChatRoomm();
        var omid = new UserMediator("Omid", chatRum);
        var saeed = new UserMediator("Saeed", chatRum);
        var vahid = new UserMediator("Vahid", chatRum);
        omid.SendMessage("hii there");

        //==========================
        var tower = new ControlTower();
        var flight1 = new Aircraft("Flight123", tower);
        var flight2 = new Aircraft("Flight456", tower);

        flight1.RequestLanding();
        //==========================

      
        //====================================
        Console.WriteLine("==================Tasks========");
        //TaskExample.RunTasks();

        //    await RestaurantTasks.MakeFood();

        //     await RestaurantTasks.MakeFoodRegularly();

        //SimpleYieldExample.Run();

        //await UserAsync.CreateUser();

        //await GenerateNumbers.generateNumbers();
        //await TaskException.RunException();
        //await TaskException.RunException();

        //await NegativeNumber.RunException();
        //await FileNFoundException.RunException();

        //await FetchDataTaskException.RunFetchData();

        //====================================

        //======================================
        Console.WriteLine("//===================LINq=========================//");
        var linqExampel = new LINQExample();
        linqExampel.RunLINQ();
        //======================================


        //===========================================
        Console.WriteLine("//============= Chain Of Responsibility ========================//");
        var teamLead = new LeaveHandler("Team Lead", r => r.NumberOfDays <= 2 && r.Reason != LeaveReason.Medical);
        var projectManager = new LeaveHandler("Project manager", r => r.NumberOfDays <= 5 && r.Reason != LeaveReason.Medical);
        var hrmanager = new LeaveHandler("HR Manager", r => r.Reason == LeaveReason.Medical || r.NumberOfDays > 5);
        teamLead.SetNext(projectManager).SetNext(hrmanager);

        var requests = new List<LeaveRequestt>
        {
            new LeaveRequestt { EmployeeName = "Ali", NumberOfDays = 1, Reason = LeaveReason.Personal },
            new LeaveRequestt { EmployeeName = "Sara", NumberOfDays = 4, Reason = LeaveReason.Study },
            new LeaveRequestt { EmployeeName = "John", NumberOfDays = 7, Reason = LeaveReason.Medical },
            new LeaveRequestt { EmployeeName = "Reza", NumberOfDays = 3, Reason = LeaveReason.Medical },
            new LeaveRequestt { EmployeeName = "Mona", NumberOfDays = 10, Reason = LeaveReason.Vacation },
            new LeaveRequestt { EmployeeName = "Zizi", NumberOfDays = 2, Reason = LeaveReason.Medical },
        };

        foreach (var request in requests)
        {
            teamLead.Handle(request);
        }


        // var processor = new OrderProcessorr()
        // .AddCheck(order => order.Quantity > order.StockAvailable ? OrderStatus.RejectedByStock : (OrderStatus?)null)
        // .AddCheck(order => order.IsBlacklisted ? OrderStatus.RejectedByBlacklist : (OrderStatus?)null)
        // .AddCheck(order => order.TotalPrice > 1_000_000 ? OrderStatus.RequiresManagerApproval : (OrderStatus?)null);
        //===========================================

        var delegate02 = new DelegateProblem02();
        delegate02.ProcessCompleted = ShowMessage;
        delegate02.StartProcess();

        var delegate03 = new DelegateProblem03();
        var n = delegate03.Calculate;
        n(4, 3);
        var result = delegate03.cal = Cal;
        Console.WriteLine($"{result(10, 100)}");

        var calculateDelegate = new CalculateDelegate();
        calculateDelegate.Calculator("+");
        if (calculateDelegate.calculate != null)
        {
            int resultt = calculateDelegate.calculate(10, 20);
            Console.WriteLine($"Result is: {resultt}");

        }

        var delegate04 = new DelegateProblem04();
        var ss = delegate04.ShowResult("omi", "sa");
        Console.WriteLine(ss);


        var people = new List<Personn>
        {
            new Personn { Name = "Ali", Age = 25 },
            new Personn{ Name = "Sara", Age = 17 },
            new Personn { Name = "Maryam", Age = 30 }
        };

        var personProcessor = new PersonProcessor();

        personProcessor.PrintFiltered02(people, p => p.Name.StartsWith("A"));

        PersonProcessor.Filter adultFilter = p => p.Age > 20;
        personProcessor.PrintFiltered(people, p => p.Age > 20);

        var aveDelegate = new AveDelegate();
        aveDelegate.average = aveDelegate.AveageInt;
        var resulttt = aveDelegate.average(10, 20, 30, 40);
        Console.WriteLine($"resultt:{resulttt}");

        var sumdelegate = new SumAverage();
        var rrr = sumdelegate.SumFunc(new[] { 10, 20, 30, 40 });
        Console.WriteLine($"Result:{rrr}");


        var processor = new OrderProcessor();
        CalculatePrice standardCalc = processor.ApplyStandardDiscount;
        processor.ProcessOrder(100, standardCalc);

        var advancedProcessor = new AdvancedOrderProcessor();
        Func<decimal, decimal> summerSale = price => price * 0.7m;
        Func<decimal, decimal> vatCalculator = price => price * 1.05m;

        var finalPrice = advancedProcessor.ProcessOrder(100, summerSale, vatCalculator);
        Console.WriteLine(finalPrice);


        //==========================================
        var product = new ProductRating();
        product.OnRatingAdded += r => Console.WriteLine($"New rating:{r}");

        product.AddRating(4);
        product.AddRating(5);
        product.AddRating(3);


        double average = product.Calculate(ratings => ratings.Average());
        Console.WriteLine($"Average rating: {average}");
        //==========================================

        //==========================================

        Console.WriteLine("=====================Dlegate===================");

        var userss = new List<Usserr>
        {
            new Usserr {Name="Omid",Age=42},
            new Usserr {Name="Saeed",Age=28},
        };

        var userDelegate = new UserDelagate();

        UserDelagate.PrintUsers(userss, user => Console.WriteLine($"{user.Name},{user.Age}"));

        //==========================================

        var list = new List<int> { 1, 2, 3 };
        var doubled = TransformList.Transform(list, x => x * 2);
        foreach (var item in doubled)
        {
            Console.WriteLine(item);
        }

        //==========================================

        //==========================================
        var orders = new List<OrderDelegate>
        {
            new OrderDelegate { Id = 1, Amount = 250, Customer = "Omid" },
            new OrderDelegate { Id = 2, Amount = 80, Customer = "Ali" },
            new OrderDelegate { Id = 3, Amount = 120, Customer = "Sara" }
        };

        ProcessOrderDelegate.ProcessOrders(orders,
            o => o.Amount > 100,
            o => o.Amount,
            msg => Console.WriteLine(" " + msg)
        );
        //==========================================
        //==========================================
        Problem10 obj = new Problem10();
        Thread t1 = new Thread(obj.Increament);
        Thread t2 = new Thread(obj.Increament);

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();


        //==========================================


        var chatroomm = new ChatRoomMediator();

        var alice = new Userr("Alice");
        var bob = new Userr("Bob");
        var carol = new Userr("Carol");

        chatroomm.Register(alice);
        chatroomm.Register(bob);
        chatroomm.Register(carol);

        alice.Send("hi all");

        //===================================
        Console.WriteLine("Yeild in C#=============");
        foreach (var num in GetNumbers())
        {
            Console.WriteLine(num);
        }
        //===================================

        var odds = new OddNumbers().GenerateOdd(10);
        foreach (var num in odds)
        {
            Console.WriteLine($"odds are {num}");
        }
    }

    public static void ShowMessage()
    {
        Console.WriteLine($"This show is from delegate");
    }

    public static int Cal(int a, int b)
    {
        return a * b;
    }


   


    public static IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
    }

    
}