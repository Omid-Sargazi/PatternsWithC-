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
        throw new NotImplementedException();
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


