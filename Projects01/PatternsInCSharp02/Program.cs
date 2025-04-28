// See https://aka.ms/new-console-template for more information
using PatternsInCSharp02.BridgePattern;

Console.WriteLine("Hello, World!");
Shape circle = new Circle(new VectorRendering());
circle.Draw();
circle = new Circle(new PixelRendering());
circle.Draw();