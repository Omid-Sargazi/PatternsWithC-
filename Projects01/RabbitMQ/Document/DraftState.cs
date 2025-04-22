namespace RabbitMQ.Document
{
    public class DraftState : IDocumentState
    {
        public void Approve(Document context, Role role)
        {
            Console.WriteLine("سند در حالت پیش‌نویس است و نمی‌تواند تأیید شود!");
        }

        public void Archive(Document context, Role role)
        {
            Console.WriteLine("سند در حالت پیش‌نویس است و نمی‌تواند آرشیو شود!");
        }

        public void Delete(Document context, Role role)
        {
            if (role == Role.Author)
            {
                Console.WriteLine("سند حذف شد.");
                // برای سادگی فرض می‌کنیم سند حذف می‌شه و دیگه حالتی نداره
            }
            else
            {
                Console.WriteLine("فقط نویسندگان می‌توانند سند را حذف کنند!");
            }
        }

        public void Edit(Document context, Role role)
        {
            if(role == Role.Author)
            {
                Console.WriteLine("سند ویرایش شد.");
            }
            else
            {
                Console.WriteLine("فقط نویسندگان می‌توانند سند را ویرایش کنند!");
            }
        }

        public void Reject(Document context, Role role)
        {
            Console.WriteLine("سند در حالت پیش‌نویس است و نمی‌تواند رد شود!");
        }

        public void Restore(Document context, Role role)
        {
            Console.WriteLine("سند در حالت پیش‌نویس است و نیازی به بازیابی ندارد!");
        }

        public void SubmitForModeration(Document context, Role role)
        {
            if(role == Role.Author)
            {
                Console.WriteLine("سند برای بررسی ارسال شد.");
                context.SetState(new ModerationState());
            }
            else
            {
                Console.WriteLine("فقط نویسندگان می‌توانند سند را برای بررسی ارسال کنند!");
            }
        }
    }
}