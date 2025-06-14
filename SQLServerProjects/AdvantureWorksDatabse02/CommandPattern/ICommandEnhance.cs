using System.Reflection.Metadata;

namespace AdvantureWorksDatabse02.CommandPattern
{
    public interface ICommandEnhance
    {
        Task ExecuteAsync(CancellationToken ct = default);
        Task UndoAsync(CancellationToken ct = default);
        bool CanExecute();
    }
}