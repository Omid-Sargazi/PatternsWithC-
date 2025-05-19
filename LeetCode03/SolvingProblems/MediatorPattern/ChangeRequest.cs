namespace SolvingProblems.MediatorPattern
{
    public interface IProjectManager
    {
        void RegisterEmployee(Employee employee);
        void RegisterClient(Client client);
        void SendChangeRequest(ChangeRequest changeRequest, Client client);
        void SendProgressRepost(ProgressReport progressReport, Employee employee);
    }
    public interface IColleague
    {
        void ReceiveNotification(string message);
    }

    public class ProjectManager : IProjectManager
    {
        private readonly List<Employee> _employees = new List<Employee>();
        private readonly List<Client> _clients = new List<Client>();
        private readonly Dictionary<int, Client> _requestToClient = new Dictionary<int, Client>();

        public void RegisterClient(Client client)
        {
            _clients.Add(client);
            Console.WriteLine($"Client {client.Name} registered.");
        }

        public void RegisterEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void SendChangeRequest(ChangeRequest changeRequest, Client client)
        {
            throw new NotImplementedException();
        }

        public void SendProgressRepost(ProgressReport progressReport, Employee employee)
        {
            throw new NotImplementedException();
        }
    }

    public class ChangeRequest
    {
        public int Id { get; set; }
        public string Description { get; }
        public ChangeRequest(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }

    public class ProgressReport
    {
        public int TaskId { get; }
        public string Status { get; }
        public ProgressReport(int taskId, string status)
        {
            TaskId = taskId;
            Status = status;
        }
    }

    public class Employee : IColleague
    {
        private readonly IProjectManager _projectManager;
        public Employee(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        public void SetProjectManager()
        {
            _projectManager.RegisterEmployee(this);
        }
        public void ReceiveNotification(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class Client : IColleague
    {
        private readonly IProjectManager _projectManager1;
        public Client(IProjectManager projectManager)
        {
            _projectManager1 = projectManager;
        }
        public void SetProjectManager()
        {
            _projectManager1.RegisterClient(this);
        }
        public void ReceiveNotification(string message)
        {
            throw new NotImplementedException();
        }
    }
}