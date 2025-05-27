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
        public void NotifyGameServer(string message)
        {

        }

        public void UpdateGameState(string eventDetails)
        {

        }
    }

    public class ChatSystem
    {
        public void NotifyChatSystem(string message)
        {

        }

        public void BroadcastMessage(string message)
        {

        }
    }
}