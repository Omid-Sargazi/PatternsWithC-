namespace RabbitMQ.Document
{
    public interface IDocumentState
    {
       void Edit(Document context, Role role);
       void SubmitForModeration(Document context, Role role);
       void Approve(Document context, Role role);
       void Reject(Document context, Role role);
        void Archive(Document context, Role role);
        void Restore(Document context, Role role);
        void Delete(Document context, Role role);
    }
}