using System.Net.NetworkInformation;

namespace AdvantureWorksDatabse02.CommandPattern
{
    public class Light
    {
        public void TurnOn() => Console.WriteLine();
        public void TurnOff() => Console.WriteLine();
    }



    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }

    public class RemoteControl
    {
        private ICommand _onCommnad;
        private ICommand _offCommand;
        private Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void SetCommands(ICommand onCommand, ICommand offCommnad)
        {
            _onCommnad = onCommand;
            _offCommand = offCommnad;
        }


        public void PressOnButton()
        {
            _onCommnad.Execute();
            _commandHistory.Push(_onCommnad);
        }

        public void PressOffButton()
        {
            _offCommand.Execute();
            _commandHistory.Push(_offCommand);
        }

        public void PressUndo()
        {
            if (_commandHistory.Count() > 0)
            {
                var lastCommand = _commandHistory.Pop();
                lastCommand.Undo();
            }
        }
    }
    
}
