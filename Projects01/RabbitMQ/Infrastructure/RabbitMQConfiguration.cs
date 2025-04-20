namespace RabbitMQ.Infrastructure
{
    public class RabbitMQConfiguration
    {
        public string HostName { get; set; } = "localhost";
        public int Port { get; set; } = 5672;
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string VirtualHost { get; set; } = "/";
        public bool UseSsl { get; set; } = false;
        public int RequestedConnectionTimeout { get; set; } = 30000; // 30 seconds
        public int SocketReadTimeout { get; set; } = 30000; // 30 seconds
        public int SocketWriteTimeout { get; set; } = 30000; // 30 seconds
        public ushort RequestedHeartbeat { get; set; } = 60; // 60 seconds
    }
}