namespace MessageBroker.MessageBrokerExample
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
        public int Priority { get; set; } = 1; // 1: عادی، 2: مهم، 3: فوری
    }
}