namespace RabbitMQ.StatePattern
{
    public class Document
    {
        // public enum Status {Draft, Moderation, Published}
        // private Status _status = Status.Draft;

        // public void Publish()
        // {
        //     if(_status == Status.Draft)
        //         _status = Status.Published;
        //     else 
        //         throw new InvalidOperationException("Document is not in draft state.");
        // }

        // public void Render()
        // {
        //     if(_status == Status.Draft)
        //     {
        //         Console.WriteLine("Editing view");
        //     }else if(_status == Status.Moderation)
        //         Console.WriteLine("Preview view");
        //     else
        //         Console.WriteLine("Read-only view");
        // }

        private IState _state = new DraftState();
        public void Published()=>_state.Publish(this);
        public void Render()=>_state.Render(this);

        internal void SetState(IState s)=>_state = s;
        
    }
}