using CompositePattern.Pattern01;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // Create an instance of the Test class
        var test = new Test();
        test.Run();

        var file1 = new CompositePattern.Pattern01.File("file1", 100);
        var file2 = new CompositePattern.Pattern01.File("file2", 200);

        var subDir = new CompositePattern.Pattern01.Directory("root");
        subDir.AddFile(file2);

        var rootDir = new CompositePattern.Pattern01.Directory("Root");
        rootDir.AddFile(file1);
        rootDir.AddFile(subDir);
        Console.WriteLine($"اندازه کل Root: {rootDir.GetSize()}"); // خروجی: 300    };
        Console.WriteLine($"اندازه کل SubDir: {subDir.GetSize()}"); // خروجی: 200

        var book = new SimpleProduct("Book",20, 0.5);
        var phone = new SimpleProduct("IPhone",200, 0.2);

        var bundle = new ProductBundle("Book + Phone", 50.0m);
        bundle.AddProduct(book);
        bundle.AddProduct(phone);
        
        Console.WriteLine("فاکتور:");
        Console.WriteLine(bundle.GenerateInvoiceLine());
        Console.WriteLine($"وزن کل: {bundle.GetWeight()} کیلوگرم");


    }
}