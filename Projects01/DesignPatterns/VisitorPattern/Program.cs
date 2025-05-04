// See https://aka.ms/new-console-template for more information
using VisitorPattern.LibrarySystem;

Console.WriteLine("Hello, World!");

var library = new Library();
library.AddItem(new StoryBook("The Hobbit", 310, "Fantasy"));
library.AddItem(new SienceBook("A Brief History of Time", 256, "Physics"));
library.AddItem(new Magazine("National Geographic", 5, 2023));

var pageCountVisitor = new PageCountVisitor();
var summaryVisitor = new SummaryVisitor();
library.Accept(pageCountVisitor);
library.Accept(summaryVisitor);
Console.WriteLine($"Total Pages: {pageCountVisitor.totalPages}");
