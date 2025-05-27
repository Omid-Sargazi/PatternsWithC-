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
}