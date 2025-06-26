using System.Security.AccessControl;

namespace DesignPattern.PrototypePattern
{
    public interface IEmailTemplate
    {
        IEmailTemplate Clone();
        IEmailTemplate DeepClone();
        void Display();
    }

    public abstract class EmailTemplate : IEmailTemplate
    {
        public string Font { get; set; }
        public string BackgroundColor { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public List<string> Links;

        public EmailTemplate(string font, string backgroundColor,
        string body, string subject)
        {
            Font = font;
            Body = body;
            Subject = subject;
            BackgroundColor = backgroundColor;
            Links = new List<string>();
        }
        public abstract IEmailTemplate Clone();

        public abstract IEmailTemplate DeepClone();

        public void Display()
        {
            Console.WriteLine($"Subject: {Subject}");
            Console.WriteLine($"Links: {string.Join(", ", Links)}");
        }
    }

    public class CampaignManager : EmailTemplate
    {
        public CampaignManager(string font, string backgroundColor, string body, string subject) : base(font, backgroundColor, body, subject)
        {
        }

        public override IEmailTemplate Clone()
        {
            return (IEmailTemplate)this.MemberwiseClone();
        }

        public override IEmailTemplate DeepClone()
        {
            var copy = new CampaignManager(Font, BackgroundColor, Body, Subject);
            copy.Links = new List<string>(this.Links);
            return copy;
        }
    }
}