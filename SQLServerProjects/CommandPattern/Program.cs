// See https://aka.ms/new-console-template for more information
using CommandPattern.MediatorPattern;

Console.WriteLine("Hello, World!");
IIMediator mediator = new Mediatorr();
Userr omid = new Userr("OMid", mediator);
Userr maryam = new Userr("Maryam", mediator);

mediator.AddUser(omid);
mediator.AddUser(maryam);

omid.Send("Hello Maryam");
maryam.Send("Hello Omid");