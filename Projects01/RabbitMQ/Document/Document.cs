namespace RabbitMQ.Document
{
    public class Document
    {
    //     private DocumentState _state = DocumentState.Draft;
    //     public void Edit(Role role)
    //     {
    //         if(_state == DocumentState.Draft && role == Role.Author)
    //         {
    //             Console.WriteLine("سند ویرایش شد.");
    //         }else
    //         {
    //             Console.WriteLine("عملیات غیرمجاز!");
    //         }
    //     }

    //     public void SubmitForModeration(Role role)
    //     {
    //         if(_state == DocumentState.Draft && role == Role.Author)
    //         {
    //             Console.WriteLine("سند برای بررسی ارسال شد.");
    //             _state = DocumentState.Moderation;
    //         }else
    //         {
    //             Console.WriteLine("عملیات غیرمجاز!");
    //         }
    //     }

    //     public void Approve(Role role)
    //     {
    //         if(_state == DocumentState.Moderation && role == Role.Moderator)
    //         {
    //             Console.WriteLine("سند تأیید شد.");
    //             _state = DocumentState.Published;
    //         }
    //         else
    //         {
    //             Console.WriteLine("عملیات غیرمجاز!");
    //         }
    //     }

    //     public void Reject(Role role)
    //     {
    //         if (_state == DocumentState.Moderation && role == Role.Moderator)
    //         {
    //             Console.WriteLine("سند رد شد.");
    //             _state = DocumentState.Draft;
    //         }
    //         else
    //         {
    //             Console.WriteLine("عملیات غیرمجاز!");
    //         }
    //     }

    //     public void Archive(Role role)
    // {
    //     if (_state == DocumentState.Published && role == Role.Admin)
    //     {
    //         Console.WriteLine("سند آرشیو شد.");
    //         _state = DocumentState.Archived;
    //     }
    //     else
    //     {
    //         Console.WriteLine("عملیات غیرمجاز!");
    //     }
    // }

    // public void Restore(Role role)
    // {
    //     if (_state == DocumentState.Archived && role == Role.Admin)
    //     {
    //         Console.WriteLine("سند بازیابی شد.");
    //         _state = DocumentState.Published;
    //     }
    //     else
    //     {
    //         Console.WriteLine("عملیات غیرمجاز!");
    //     }
    // }

    private IDocumentState _currentState;
    public Document()
    {
        _currentState = new DraftState();
    }
    public void SetState(IDocumentState state)
    {
        _currentState = state;
    }
    public void Edit(Role role)
    {
        _currentState.Edit(this, role);
    }
    public void SubmitForModeration(Role role)
    {
        _currentState.SubmitForModeration(this, role);
    }
    public void Approve(Role role)
    {
        _currentState.Approve(this, role);
    }
    public void Reject(Role role)
    {
        _currentState.Reject(this, role);
    }

    public void Archive(Role role)
    {
        _currentState.Archive(this, role);
    }

    public void Restore(Role role)
    {
        _currentState.Restore(this, role);
    }

    public void Delete(Role role)
    {
        _currentState.Delete(this, role);
    }
    }
}