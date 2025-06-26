namespace DesignPattern.PrototypePattern
{
    public interface IInvitationCard
    {
        public IInvitationCard Clone();
        public void Display();
    }
    public abstract class InvitationCard : IInvitationCard
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string BackgroundColor { get; set; }
        public string Font { get; set; }

        public InvitationCard(string title, string message,
        string backgroundColor, string font)
        {
            Title = title;
            Message = message;
            BackgroundColor = backgroundColor;
            Font = font;
        }

        public IInvitationCard Clone()
        {
            return (IInvitationCard)this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine($"Card: {Title}");
            Console.WriteLine($"Message: {Message}");
        }
    }

    public class BirthdayCard : InvitationCard
    {
        public string customer { get; set; }
        public BirthdayCard(string title, string message,
        string backgroundColor, string font,string customer) : base(title, message, backgroundColor, font)
        {

            this.Message = $"{message} {customer}";
        }
    }



}