
using static PatternsInCSharp02.AbstarctFactory.AdapterRobotFactory;

namespace PatternsInCSharp02.AbstarctFactory;
    public interface ISensor
    {
        void Detect();
    }

    public interface IMotor
    {
        void Start();
    }


    public interface IInterface
    {
        void Show();
    }

public class ModernSensor : ISensor
{
    public void Detect()
    {
        Console.WriteLine("Modern Sensor: Detecting...");
    }
}

public class ModernMotor : IMotor
{
    public void Start()
    {
        Console.WriteLine("Modern Motor: Starting...");
    }
}

public class ModernInterface : IInterface
{
    public void Show()
    {
        Console.WriteLine("Modern Interface: Displaying...");
    }
}

public class TraditionalSensor : ISensor
{
    public void Detect()
    {
        Console.WriteLine("Traditional Sensor: Detecting...");
    }
}

public class TraditionalMotor : IMotor
{
    public void Start()
    {
        Console.WriteLine("Traditional Motor: Starting...");
    }
}

public class TraditionalInterface : IInterface
{
    public void Show()
    {
        Console.WriteLine("Traditional Interface: Displaying...");
    }
}

public class MinimalSensor : ISensor
{
    public void Detect()
    {
        Console.WriteLine("Minimal Sensor: Detecting...");
    }
}

public class MinimalMotor : IMotor
{
    public void Start()
    {
        Console.WriteLine("Minimal Motor: Starting...");
    }
}

public class MinimalInterface : IInterface
{
    public void Show()
    {
        Console.WriteLine("Minimal Interface: Displaying...");
    }
}

public interface IRobotFactory
{
    ISensor CreateSensor();
    IMotor CreateMotor();
    IInterface CreateInterface();
}


public class ModernRobotFactory : IRobotFactory
{
    public IInterface CreateInterface()
    {
        return new ModernInterface();
    }

    public IMotor CreateMotor()
    {
        return new ModernMotor();
    }

    public ISensor CreateSensor()
    {
        return new ModernSensor();
    }
}

public class TraditionalRobotFactory : IRobotFactory
{
    public IInterface CreateInterface()
    {
        return new TraditionalInterface();
    }

    public IMotor CreateMotor()
    {
        return new TraditionalMotor();
    }

    public ISensor CreateSensor()
    {
        return new TraditionalSensor();
    }
}

public class MinimalRobotFactory : IRobotFactory
{
    public IInterface CreateInterface()
    {
        return new MinimalInterface();
    }

    public IMotor CreateMotor()
    {
        return new MinimalMotor();
    }

    public ISensor CreateSensor()
    {
        return new MinimalSensor();
    }
}

public class ClientRobot 
{
    // private readonly ISensor _sensor;
    // private readonly IMotor _motor;
    // private readonly IInterface _robotInterface;
    // public ClientRobot(IRobotFactory robotFactory)
    // {
    //     _sensor = robotFactory.CreateSensor();
    //     _motor = robotFactory.CreateMotor();
    //     _robotInterface = robotFactory.CreateInterface();
    // }

    // public void CreateRobot()
    // {
    //     _sensor.Detect();
    //     _motor.Start();
    //     _robotInterface.Show();
    // }
    private readonly Robot robot;
}

public class LegacyComponentSystem
{
    public string ProduceLegacySensor()
    {
        return "LEGACY_LIDAR_SENSOR";
    }

    public string ProduceLegacyMotor()
    {
        return "LEGACY_STANDARD_MOTOR";
    }

    public string ProduceLegacyInterface()
    {
        return "LEGACY_BUTTON_PANEL";
    }
}

public class AdapterRobotFactory : IRobotFactory
{
    private readonly LegacyComponentSystem _legacyComponentSystem;

    public AdapterRobotFactory(LegacyComponentSystem legacyComponentSystem)
    {
        _legacyComponentSystem = legacyComponentSystem;
    }
    public IInterface CreateInterface()
    {
        string legacyInterface = _legacyComponentSystem.ProduceLegacyInterface();
        return new ClassicInterface(legacyInterface);
    }

    public IMotor CreateMotor()
    {
        string legacyMotor = _legacyComponentSystem.ProduceLegacyInterface();
        return new ClassicMotor(legacyMotor);
    }

    public ISensor CreateSensor()
    {
        string legacySensor = _legacyComponentSystem.ProduceLegacySensor();
        return new ClassicSensor(legacySensor);
    }

    public class ClassicSensor : ISensor
    {
        private readonly string _sensorDescription;
        public ClassicSensor(string sensorDescription)
        {
            _sensorDescription = sensorDescription.Replace("LEGACY_", "کلاسیک_") + " (سازگار با سیستم جدید)";
        }
        public void Detect()
        {
            Console.WriteLine($"Classic Sensor: Detecting with {_sensorDescription}");
        }
    }

    public class ClassicMotor : IMotor
    {
        private readonly string _motorDescription;

        public ClassicMotor(string motorDescription)
        {
            _motorDescription = motorDescription.Replace("LEGACY_", "کلاسیک_") + " (سازگار با سیستم جدید)";
        }

        public void Start()
        {
            Console.WriteLine($"Classic Motor: Starting with {_motorDescription}");
        }
    }

    public class ClassicInterface : IInterface
    {
       private readonly string _interfaceDescription;

        public ClassicInterface(string interfaceDescription)
        {
            _interfaceDescription = interfaceDescription.Replace("LEGACY_", "کلاسیک_") + " (سازگار با سیستم جدید)";
        }

        public void Show()
        {
            Console.WriteLine($"Classic Interface: Displaying with {_interfaceDescription}");
        }
    }

    public interface IRobotImplementation
    {
        void Detect(ISensor sensor);
        void Start(IMotor motor);
        void Show(IInterface robotInterface);
    }

    public class DomesticRobotImplementation : IRobotImplementation
    {
        public void Detect(ISensor sensor)
        {
            Console.WriteLine("رفتار خانگی: اسکن محیط خانه...");
            sensor.Detect();
        }

        public void Show(IInterface robotInterface)
        {
            Console.WriteLine("رفتار خانگی: نمایش ساده برای کاربر خانگی...");
            robotInterface.Show();
        }

        public void Start(IMotor motor)
        {
            Console.WriteLine("رفتار خانگی: شروع آرام برای محیط خانه...");
            motor.Start();
        }
    }

    public class IndustrialRobotImplementation : IRobotImplementation
    {
        public void Detect(ISensor sensor)
        {
            sensor.Detect();
        }

        public void Show(IInterface robotInterface)
        {
            robotInterface.Show();
        }

        public void Start(IMotor motor)
        {
            motor.Start();
        }
    }

    public abstract class Robot
    {
        protected  IRobotImplementation _robotImplementation;
        protected readonly ISensor _sensor;
        protected readonly IMotor _motor;
        protected readonly IInterface _robotInterface;
        public Robot(IRobotFactory robotFactory, IRobotImplementation robotImplementation)
        {
            _robotImplementation = robotImplementation;
            _sensor = robotFactory.CreateSensor();
            _motor = robotFactory.CreateMotor();
            _robotInterface = robotFactory.CreateInterface();
        }

        public abstract void Operate();
    }

    public class DomesticRobot : Robot
    {
        public DomesticRobot(IRobotFactory robotFactory, IRobotImplementation robotImplementation) : base(robotFactory, robotImplementation)
        {
        }

        public override void Operate()
        {
            Console.WriteLine("ربات خانگی در حال کار...");
            _robotImplementation.Detect(_sensor);
            _robotImplementation.Start(_motor);
            _robotImplementation.Show(_robotInterface);
        }
    }

    public class IndustrialRobot : Robot
    {
        public IndustrialRobot(IRobotFactory robotFactory, IRobotImplementation robotImplementation) : base(robotFactory, robotImplementation)
        {
        }

        public override void Operate()
        {
            _robotImplementation.Detect(_sensor);
            _robotImplementation.Start(_motor);
            _robotImplementation.Show(_robotInterface);
        }
    }
}

