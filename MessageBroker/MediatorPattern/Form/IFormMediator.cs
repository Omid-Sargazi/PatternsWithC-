using System.Globalization;

namespace MessageBroker.MediatorPattern.Form
{
   public interface IFormMediator
   {
     void Notify(object sender, string eventName);
   }
}