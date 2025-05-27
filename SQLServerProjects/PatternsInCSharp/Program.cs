// See https://aka.ms/new-console-template for more information
using PatternsInCSharp.MediatorPattern;

Console.WriteLine("Hello, World!");
IMediator mediator = new Mediator();

User omid = new User("Omid", mediator);
User Zini = new User("Zini", mediator);
mediator.AddUser(omid);
mediator.AddUser(Zini);
mediator.SendMessage("Hello", omid);
omid.send("Hello");
Zini.send("hi");