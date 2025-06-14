using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;

namespace AdvantureWorksDatabse02.CommandPattern
{
    public interface ICommandEnhance
    {
        Task ExecuteAsync(CancellationToken ct = default);
        Task UndoAsync(CancellationToken ct = default);
        bool CanExecute();
    }

    public abstract class CommandBase : ICommandEnhance
    {
        protected readonly ILogger _logger;
        protected CommandBase(ILogger logger)
        {
            _logger = logger;
        }

        public virtual bool CanExecute() => true;

        public abstract Task ExecuteAsync(CancellationToken ct = default);

        public abstract Task UndoAsync(CancellationToken ct = default);
    }
}