using System.Net.NetworkInformation;

namespace PatternsInCSharp02.CommandPattern
{
    public class WaterPump
    {
        public void TurnOn()=>Console.WriteLine("Turn on Pump");
        public void TurnOff()=>Console.WriteLine("Turn off Pump");
    }

    public class GrowLight
    {
        public void TurnOn()=> Console.WriteLine("Turn On Light");
        public void TurnOff()=> Console.WriteLine("Turn Off Light");
    }

    public class GreenhouseController
    {
       private readonly List<ICommand> _commandHistory = new List<ICommand>();

      

       public void ExcecuteCommnad(ICommand command)
       {
            command.Execute();
            _commandHistory.Add(command);
       }

       public void UndoCommnad(ICommand command)
       {
            if(_commandHistory.Count == 0) return;
            var lastCommand = _commandHistory[^1];
            lastCommand.Undo();
            _commandHistory.RemoveAt(_commandHistory.Count - 1);
       }
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class PumpOnCommand : ICommand
    {
        private readonly WaterPump _waterPump;
        public void Execute()
        {
            _waterPump.TurnOn();
        }

        public void Undo()
        {
            _waterPump.TurnOff();
        }
    }

    public class PumpOffCommand : ICommand
    {
        private readonly WaterPump _waterPump;
        public PumpOffCommand(WaterPump waterPump)
        {
            _waterPump = waterPump;
        }

        public void Execute()
        {
            _waterPump.TurnOff();
        }

        public void Undo()
        {
            _waterPump.TurnOn();
        }
    }

    public class LightOnCommand : ICommand
    {
        private readonly GrowLight _growLight;
        public LightOnCommand(GrowLight growLight)
        {
            _growLight = growLight;
        }

        public void Execute()
        {
            _growLight.TurnOn();
        }

        public void Undo()
        {
            _growLight.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private readonly GrowLight _growLight;
        public LightOffCommand(GrowLight growLight)
        {
            _growLight = growLight;
        }
        public void Execute()
        {
            _growLight.TurnOff();
        }

        public void Undo()
        {
            _growLight.TurnOn();
        }
    }

    public class Heater
    {
        public void TurnOn()=> Console.WriteLine("Turn on Heater");
        public void TurnOff()=> Console.WriteLine("Turn off Heater");
    }

    public class HeaterOnCommand : ICommand
    {
        private readonly Heater _heater;
        public HeaterOnCommand(Heater heater)
        {
            _heater = heater;
        }
        public void Execute()
        {
            _heater.TurnOn();
        }

        public void Undo()
        {
            _heater.TurnOff();
        }
    }

    public class HeaterOffCommand : ICommand
    {
        private readonly Heater _heater;
        public HeaterOffCommand(Heater heater)
        {
            _heater = heater;
        }
        public void Execute()
        {
            _heater.TurnOff();
        }

        public void Undo()
        {
            _heater.TurnOn();
        }
    }

    public class OldDripIrrigationSystem
    {
        public void StartIrrigation(int duration)
        {
            Console.WriteLine($"Starting irrigation for {duration} minutes.");
        }

        public void StopIrrigation()
        {
            Console.WriteLine("Stopping irrigation.");
        }
    }

    public class DripIrrigationAdapter : ICommand
    {
        private readonly OldDripIrrigationSystem _irrigationSystem;
        private readonly int _duration;

        public DripIrrigationAdapter(OldDripIrrigationSystem oldDripIrrigationSystem, int duration)
        {
            _duration = duration;
            _irrigationSystem = oldDripIrrigationSystem;
        }
        public void Execute()
        {
            _irrigationSystem.StartIrrigation(_duration);
        }

        public void Undo()
        {
            _irrigationSystem.StopIrrigation();
        }
    }

    public class CommandProxy : ICommand
    {
        private readonly ICommand _commnad;
        private readonly string _userRole;
        public CommandProxy(ICommand command, string userRole)
        {
            _commnad = command;
            _userRole = userRole;
        }
        public void Execute()
        {
            if(_userRole == "Admin")
                _commnad.Execute();
            else
                Console.WriteLine("دسترسی غیرمجاز: فقط کاربران با نقش Admin می‌توانند این دستور را اجرا کنند.");
        }

        public void Undo()
        {
             if (_userRole == "Admin")
        {
            _commnad.Undo();
        }
        else
        {
            Console.WriteLine("دسترسی غیرمجاز: فقط کاربران با نقش Admin می‌توانند این دستور را لغو کنند.");
        }
        }
    }
}