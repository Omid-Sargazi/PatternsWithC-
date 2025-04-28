// See https://aka.ms/new-console-template for more information
using PatternsInCSharp02.BridgePattern;

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