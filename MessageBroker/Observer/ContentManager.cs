using System.Globalization;

namespace MessageBroker.Observer
{
    public class ContentManager 
    {
        public void PublishContent(string content, string author, string title)
        {
              SaveToDatabase(content, author, title);
        
        // اطلاع رسانی به سیستم های مختلف
            SendEmailToSubscribers(title);
            NotifyAdmins(title, author);
            UpdateAnalytics(title);
            ClearCache();
        }

        private void SaveToDatabase(string content, string author, string title)
        {
            Console.WriteLine($"ذخیره محتوا در پایگاه داده: {title}");
        }
        private void SendEmailToSubscribers(string title)
        {
            Console.WriteLine($"ارسال ایمیل به مشترکین درباره: {title}");
        }

            private void NotifyAdmins(string title, string author)
        {
            // کد ارسال نوتیفیکیشن
            Console.WriteLine($"ارسال نوتیفیکیشن به مدیران: {title} توسط {author}");
        }
        
        private void UpdateAnalytics(string title)
        {
            // کد بروزرسانی آمار
            Console.WriteLine($"بروزرسانی آمار برای: {title}");
        }
        
        private void ClearCache()
        {
            // کد پاک کردن کش
            Console.WriteLine("پاک کردن کش سایت");
        }
    }
}