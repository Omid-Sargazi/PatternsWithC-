namespace LeetCode.Delegate
{
    public delegate bool EmailRule(Email email);

    public class EmailHandlerr
    {
        private readonly List<EmailRule> _rules = new();
        public EmailHandlerr AddRule(EmailRule rule)
        {
            _rules.Add(rule);
            return this;
        }

        public bool Handle(Email email)
        {
            foreach (var rule in _rules)
            {
                if (!rule(email))
                    Console.WriteLine("Email Rejected");
                return false;
            }
            Console.WriteLine($"Email Accepted");
            return true;
        }
    }
    public class Email
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public delegate bool EmailFilter(Email email);

    public class EmailHandler
    {
        private List<EmailFilter> _filters = new();

        public void AddFiletr(EmailFilter filter) => _filters.Add(filter);

        public void Handle(Email email)
        {
            foreach (var filter in _filters)
            {
                if (!filter(email))
                {
                    Console.WriteLine($"Email rejected.");
                    return;
                }
            }
            Console.WriteLine("✅ Email accepted.");
        }
    }

    public class HandleEmail
    {

        public static void Run()
        {
            var email1 = new Email { Subject = "buy now spam", Body = "short" };
            var email2 = new Email { Subject = "hello", Body = "this is a real message" };

            var handler = new EmailHandlerr()
            .AddRule(e => e.Subject.ToLower().Contains("spam"))
            .AddRule(e => e.Body.Length >= 20)
            .AddRule(e => e.Body.Contains("Invoice") || e.Subject.Contains("invoice"));
            handler.Handle(email1);
            handler.Handle(email2);
            // var handler = new EmailHandler();

            // handler.AddFiletr(e => !e.Subject.Contains("spam"));
            // handler.AddFiletr(e => e.Body.Length > 20);

            // handler.Handle(email1);
            // handler.Handle(email2);
        }
    }

    

} 