namespace PatternsInCSharp.ObserverPattern
{
    public class EmailSender
    {
        public async Task SendWelcomeEmailAsync(string emailAddress)
        {
            await Task.Delay(2000);
            Console.WriteLine($"ایمیل خوش‌آمدگویی به {emailAddress} ارسال شد.");
        }
    }

    public class UserRegistration
    {
        private readonly EmailSender _emailSender =  new EmailSender();
        public async Task RegisterUserAsync(string email)
        {
            Console.WriteLine($"کاربر با ایمیل {email} ثبت‌نام کرد.");
            await _emailSender.SendWelcomeEmailAsync(email);
        }
    }
    
}