namespace PatternsInCSharp.MediatorPattern
{
    public interface IGameMediator
    {
        void PlayerMove(string playerName, string position);
        void PlayerSendMessage(string playerName, string message);
        void PlayerCollectItem(string playerName, string item);
        void NotifyGameSever(string eventDetails);
        void NotifyChatSystem(string message);
    }

    public class GameEventSystem : IGameMediator
    {
        private readonly ChatSystem _chatSystem;
        private readonly GameServer _gameServer;
        public GameEventSystem(ChatSystem chatSystem, GameServer gameServer)
        {
            _chatSystem = chatSystem;
            _gameServer = gameServer;
        }
        public void NotifyChatSystem(string message)
        {
            _chatSystem.BroadcastMessage(message);
        }

        public void NotifyGameSever(string eventDetails)
        {
            _gameServer.UpdateGameState(eventDetails);
        }

        public void PlayerCollectItem(string playerName, string item)
        {
            Console.WriteLine($"بازیکن {playerName} آیتم {item} را جمع کرد.");
            NotifyGameSever($"جمع‌آوری: {playerName} آیتم {item} را برداشت");
        }

        public void PlayerMove(string playerName, string position)
        {
            Console.WriteLine($"بازیکن {playerName} به موقعیت {position} حرکت کرد.");
            NotifyGameSever($"حرکت: {playerName} به {position}");
        }

        public void PlayerSendMessage(string playerName, string message)
        {
            Console.WriteLine($"بازیکن {playerName} پیام فرستاد: {message}");
            NotifyChatSystem($"[{playerName}]: {message}");
        }
    }

    public class GameServer
    {


        public void UpdateGameState(string eventDetails)
        {
            Console.WriteLine($"سرور بازی: به‌روزرسانی وضعیت - {eventDetails}");
        }
    }

    public class ChatSystem
    {


        public void BroadcastMessage(string message)
        {
            Console.WriteLine($"سیستم چت: پخش پیام - {message}");
        }
    }

    public class Player
    {
        private readonly IGameMediator _mediator;
        public string Name { get; }
        public Player(string name, IGameMediator gameMediator)
        {
            _mediator = gameMediator;
            Name = name;
        }

        public void Move(string position)
        {
            _mediator.PlayerMove(Name, position);
        }

        public void SendMassage(string message)
        {
            _mediator.PlayerSendMessage(Name, message);
        }

        public void CollectItem(string item)
        {
            _mediator.PlayerCollectItem(Name, item);
        }

    }
}