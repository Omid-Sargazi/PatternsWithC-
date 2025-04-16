namespace Patterns.MediatorPattern.ChatRoom
{
   public class ChatBox
    {
        public void LoadMessages() => Console.WriteLine("Loading messages...");
    }

    public class MessageInput
    {
        public void Clear() => Console.WriteLine("Clearing input...");
    }

    public class SendButton
    {
        public void Enable() => Console.WriteLine("Enabling send button...");
    }
}