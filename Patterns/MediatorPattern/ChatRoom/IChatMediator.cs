namespace Patterns.MediatorPattern.ChatRoom
{
   public interface IChatMediator
   {
        void Notify(object sender, string message);
   }
}