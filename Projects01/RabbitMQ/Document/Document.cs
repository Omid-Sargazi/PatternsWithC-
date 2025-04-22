namespace RabbitMQ.Document
{
    public class Document
    {
        private DocumentState _state = DocumentState.Draft;
        public void Edit(Role role)
        {
            if(_state == DocumentState.Draft && role == Role.Author)
            {
                Console.WriteLine("سند ویرایش شد.");
            }else
            {
                Console.WriteLine("عملیات غیرمجاز!");
            }
        }

        public void SubmitForModeration(Role role)
        {
            if(_state == DocumentState.Draft && role == Role.Author)
            {
                Console.WriteLine("سند برای بررسی ارسال شد.");
                _state = DocumentState.Moderation;
            }else
            {
                Console.WriteLine("عملیات غیرمجاز!");
            }
        }

        public void Approve(Role role)
        {
            if(_state == DocumentState.Moderation && role == Role.Moderator)
            {
                Console.WriteLine("سند تأیید شد.");
                _state = DocumentState.Published;
            }
            else
            {
                Console.WriteLine("عملیات غیرمجاز!");
            }
        }

        public void Reject(Role role)
        {
            if (_state == DocumentState.Moderation && role == Role.Moderator)
            {
                Console.WriteLine("سند رد شد.");
                _state = DocumentState.Draft;
            }
            else
            {
                Console.WriteLine("عملیات غیرمجاز!");
            }
        }

        public void Archive(Role role)
    {
        if (_state == DocumentState.Published && role == Role.Admin)
        {
            Console.WriteLine("سند آرشیو شد.");
            _state = DocumentState.Archived;
        }
        else
        {
            Console.WriteLine("عملیات غیرمجاز!");
        }
    }

    public void Restore(Role role)
    {
        if (_state == DocumentState.Archived && role == Role.Admin)
        {
            Console.WriteLine("سند بازیابی شد.");
            _state = DocumentState.Published;
        }
        else
        {
            Console.WriteLine("عملیات غیرمجاز!");
        }
    }
    }
}