using System.Runtime.InteropServices;

namespace AdventureWorksLT2019_2.PatternsInCSharp
{
    public interface ICommandLight
    {
        public void Run();
        public void Undo();
    }
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine($"Light is on.");
        }

        public void TurnOff()
        {
            Console.WriteLine($"Light is Off.");
        }
    }

    public class TurnOnLight : ICommandLight
    {
        private Light _light;
        public TurnOnLight(Light light)
        {
            _light = light;
        }
        public void Run()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    public class TurnOffLight : ICommandLight
    {
        private Light _light;
        public TurnOffLight(Light light)
        {
            _light = light;
        }
        public void Run()
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
        private Stack<ICommandLight> _commandLights = new Stack<ICommandLight>();
        public void ExecuteCommand(ICommandLight commandLight)
        {
            commandLight.Run();
            _commandLights.Push(commandLight);
        }
        private TurnOnLight _turnOnLight;
        public RemoteControl(TurnOnLight turnOnLight)
        {
            _turnOnLight = turnOnLight;
        }


        public void UndoLastCommand()
        {
            if (_commandLights.Count > 0)
            {
                var command = _commandLights.Pop();
                command.Undo();
            }
        }
    }
}