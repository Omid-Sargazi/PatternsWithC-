namespace BehavioralPattern.Command
{
    public interface IRobotCommand
    {
        void Execute();
        void Undo();
    }
    public class Robot
    {
        public void MoveForward()
        {
            Console.WriteLine("Robot moves forward");
        }

        public void TurnLeft()
        {
            Console.WriteLine("Robot turns left");
        }

        public void TurnRight()
        {
            Console.WriteLine("Robot turns right");
        }
    }

    public class MoveForward : IRobotCommand
    {
        private Robot _robot;
        public void Execute()
        {
            _robot.MoveForward();
        }

        public void Undo()
        {
            _robot.TurnLeft();
        }
    }
}