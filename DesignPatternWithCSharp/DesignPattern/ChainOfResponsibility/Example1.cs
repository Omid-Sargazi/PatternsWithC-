namespace DesignPattern.ChainOfResponsibility
{
    public abstract class SupportHandler
    {
        protected SupportHandler _next;
        public void SetNext(SupportHandler nextHandler)
        {
            _next = nextHandler;
        }

        public abstract void Handle(string requestType);
    }
}