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
            client.SetProjectManager(this);
            Console.WriteLine($"Client {client.Name} registered.");
        }

        public void RegisterEmployee(Employee employee)
        {
            _employees.Add(employee);
            employee.SetProjectManager(this);
            Console.WriteLine($"Employee {employee.Name} registered.");
        }

        public void SendChangeRequest(ChangeRequest changeRequest, Client client)
        {
            Console.WriteLine($"Project Manager received change request {changeRequest.Id} from {client.Name}.");
            _requestToClient[changeRequest.Id] = client;
            Employee targetEmployee = _employees.Find(e => e.Specialty == changeRequest.Description) ?? _employees[0];
            targetEmployee.ReceiveNotification($"Change Request{changeRequest.Id}:{changeRequest.Description}");
        }

        public void SendProgressRepost(ProgressReport progressReport, Employee employee)
        {
            Console.WriteLine($"Project Manager received progress report for task {progressReport.TaskId} from {employee.Name}.");
             if (_requestToClient.TryGetValue(progressReport.TaskId, out Client client))
            {
                client.ReceiveNotification($"Progress Report for task {progressReport.TaskId}: {progressReport.Status}");
            }
            else
            {
                Console.WriteLine($"No client found for task {progressReport.TaskId}.");
            }
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
        public string Name { get; }
        public string Specialty { get; }
        private  IProjectManager _projectManager;
        public Employee(string name, string specialty)
        {
            Specialty = specialty;
            Name = name;
        }
        
        public void SetProjectManager(IProjectManager projectManager)
        {

            _projectManager = projectManager;
        }
        public void ReceiveNotification(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class Client : IColleague
    {   
        public string Name { get; }
        private  IProjectManager _projectManager;
        public Client(string name)
        {
            Name = name;
        }

        public void SubmitChangeRequest(ChangeRequest request)
        {
            Console.WriteLine($"Client {Name} submitted change request {request.Id}.");
            _projectManager.SendChangeRequest(request, this);
        }
       
        public void SetProjectManager(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        public void ReceiveNotification(string message)
        {
            Console.WriteLine($"Client {Name} received: {message}");
        }
    }
}