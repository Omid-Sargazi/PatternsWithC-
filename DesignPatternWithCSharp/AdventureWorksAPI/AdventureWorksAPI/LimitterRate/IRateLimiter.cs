namespace AdventureWorksAPI.LimitterRate
{
    public interface IRateLimiter
    {
        bool AllowRequest(string ClientIp);
    }

    public class InMemoryRateLimiter : IRateLimiter
    {
        private readonly Dictionary<string, (int Count, DateTime ResetTime)> _requestCounts = new();
        private readonly int _limit = 5;
        private readonly TimeSpan _window = TimeSpan.FromMinutes(1);
        public bool AllowRequest(string ClientIp)
        {
            lock (_requestCounts)
            {
                if (_requestCounts.TryGetValue(ClientIp, out var data) || data.ResetTime <= DateTime.UtcNow)
                {
                    _requestCounts[ClientIp] = (1, DateTime.UtcNow.Add(_window));
                }
                if (data.Count >= _limit)
                    return false;

                _requestCounts[ClientIp] = (data.Count + 1, data.ResetTime);
                return true;
            }
        }
    }
}