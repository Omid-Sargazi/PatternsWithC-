// See https://aka.ms/new-console-template for more information
using PatternsInCSharp02.BridgePattern;
using PatternsInCSharp02.CommandPattern;

Console.WriteLine("Hello, World!");
Shape circle = new Circle(new VectorRendering());
circle.Draw();
circle = new Circle(new PixelRendering());
circle.Draw();

PrintedBook physicalBook = new PrintedBook("The Alchemist", new PhysicalAccess());
physicalBook.Borrow("John Doe");
physicalBook.Return();

PrintedBook downloadedBook = new PrintedBook("Deep Work",new DownloadAccess());
downloadedBook.Borrow("Omid");
downloadedBook.Return();
Console.WriteLine("/////////////////////////////////////");
var oldDripIrrigationSystem = new OldDripIrrigationSystem();
var irrigationCommand = new DripIrrigationAdapter(oldDripIrrigationSystem,5);

var adminCommand = new CommandProxy(irrigationCommand, "Admin");
var guestCommand = new CommandProxy(irrigationCommand, "Guest");

// ایجاد کنترل‌کننده
var controller = new GreenhouseController();

// تست با کاربر Admin
Console.WriteLine("تست با کاربر Admin:");
controller.ExcecuteCommnad(adminCommand); // باید اجرا بشه
// controller.UndoLastCommand(); // باید لغو بشه

// تست با کاربر Guest
Console.WriteLine("\nتست با کاربر Guest:");
controller.ExcecuteCommnad(guestCommand); // باید خطای دسترسی بده
// controller.UndoLastCommand(); // باید خطای دسترسی بده
