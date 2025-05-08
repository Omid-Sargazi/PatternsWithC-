namespace BehavioralPattern.VisitorCompositePattern
{
    public interface ICommandTask
    {
        void Execute();
        void Undo();
    }

    public class EmailTask : ICommandTask
    {
        public string Recipient { get; }
        public string Subject { get; }

        public EmailTask(string recipient, string subject)
        {
            Recipient = recipient;
            Subject = subject;
        }
        public void Execute()
        {
            Console.WriteLine($"Sending email to {Recipient} with subject: {Subject}");
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    public class SaveFileTask : ICommandTask
    {
        public string FileName { get; }
        public string Path { get; }

        public SaveFileTask(string fileName, string path)
        {
            FileName = fileName;
            Path = path;
        }
        public void Execute()
        {
            Console.WriteLine($"Saving file {FileName} to {Path}");
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    public class PrintMessageTask : ICommandTask
    {
        public string Message { get; }

        public PrintMessageTask(string message)
        {
            Message = message;
        }
        public void Execute()
        {
            Console.WriteLine($"Printing message: {Message}");
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    public class TaskManager
    {
        private List<ICommandTask> _commandTasks;
        public void AddTask(ICommandTask command)
        {
            _commandTasks.Add(command);
        }

        public void Execute()
        {
            foreach(var command in _commandTasks)
            {
                command.Execute();
            }
        }
    }

}