namespace DesignPattern.PrototypePattern
{
    public abstract class DInvitationCard : IInvitationCard
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string BackgroundColor { get; set; }
        public string Font { get; set; }
        public List<string> ImageUrls { get; set; }

        public DInvitationCard(string title, string message, string backgroundColor,
        string font)
        {
            Title = title;
            Message = message;
            BackgroundColor = backgroundColor;
            Font = font;
            ImageUrls = new List<string>();
        }
        public IInvitationCard Clone()
        {
            throw new NotImplementedException();
        }

        public abstract IInvitationCard DeepClone();

        public void Display()
        {
            Console.WriteLine($"Card: {Title}");
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Images: {string.Join(", ", ImageUrls)}");
        }
    }


    public class DBirthdayCard : DInvitationCard
    {
        public string Customer { get; set; }
        public DBirthdayCard(string title, string message,
        string backgroundColor, string font, string customer) : base(title, message, backgroundColor, font)
        {
            Customer = customer;
            Message = $"{message} {customer}";
        }

        public override IInvitationCard DeepClone()
        {
            var copy = new DBirthdayCard(Title, Message, BackgroundColor, Font, Customer);
            copy.ImageUrls = new List<string>(this.ImageUrls);
            return copy;
        }
    }

}