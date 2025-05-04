// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
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



//////////////////////////
/// Visitor Pattern for Document System

var documnet = new Documents();
documnet.AddItem(new PDFDocument(10, false));
documnet.AddItem(new WordDocument(1000, true));
documnet.AddItem(new SpreadsheetDocument(5, 1000));

var printVisitor = new PrintVisitor();
documnet.Accept(printVisitor);