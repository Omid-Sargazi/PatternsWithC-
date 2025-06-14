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

        protected async Task SafeExecuteAsync(Func<Task> action, string operationName)
        {
            try
            {
                if (!CanExecute())
                {
                    _logger.LogWarning($"Cannot excecute {operationName}");
                    return;
                }
                _logger.LogInformation($"Starting {operationName}");
                await action();
                _logger.LogInformation($"Completed{operationName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in{operationName}");
                throw;
            }
        }
    }

    public class LightCommandEnhance : CommandBase
    {
        private readonly Light _light;
        private readonly bool _turnOn;
        public LightCommandEnhance(ILogger logger, bool turnOn, Light light) : base(logger)
        {
            _light = light;
            _turnOn = turnOn;
        }

        public override async Task ExecuteAsync(CancellationToken ct = default)
        {
            await SafeExecuteAsync(async () =>
            {
                if (_turnOn)
                    _light.TurnOn();
                else
                    _light.TurnOff();
            },nameof(ExecuteAsync));
        }

        public override async Task UndoAsync(CancellationToken ct = default)
        {
            await SafeExecuteAsync(async () =>
            {
                if (_turnOn)
                    _light.TurnOff();
                else
                    _light.TurnOn();
            },nameof(UndoAsync));
        }
    }
}