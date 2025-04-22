namespace RabbitMQ.Document
{
    public class DraftState : IDocumentState
    {
        public void Approve(Document context, Role role)
        {
            throw new NotImplementedException();
        }

        public void Archive(Document context, Role role)
        {
            throw new NotImplementedException();
        }

        public void Delete(Document context, Role role)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Restore(Document context, Role role)
        {
            throw new NotImplementedException();
        }

        public void SubmitForModeration(Document context, Role role)
        {
            if(role == Role.Author)
            {
                Console.WriteLine("سند برای بررسی ارسال شد.");
                context.SetState(new ModerationState());
            }
        }
    }
}