﻿// See https://aka.ms/new-console-template for more information
using System.Runtime;
using PatternsInCSharp.MediatorPattern;

Console.WriteLine("Hello, World!");
// IMediator mediator = new Mediator();

// User omid = new User("Omid", mediator);
// User Zini = new User("Zini", mediator);
// mediator.AddUser(omid);
// mediator.AddUser(Zini);
// mediator.SendMessage("Hello", omid);
// omid.send("Hello");
// Zini.send("hi");

// Kitchen kitchen = new Kitchen();
// Cashier cashier = new Cashier();
// Waiter waiter = new Waiter();

// IRestaurantMediator restaurantMediator = new OrderManagementSystem(kitchen, cashier, waiter);
// Customer customer = new Customer("Omid", restaurantMediator);
// customer.PlaceOrder("Pizza");

GameServer gameServer = new GameServer();
ChatSystem chatSystem = new ChatSystem();

IGameMediator gameMediator = new GameEventSystem(chatSystem, gameServer);
Player player = new Player("omid", gameMediator);
player.Move("(10,10)");
player.SendMassage("hi to all");
player.CollectItem("golden swor");
