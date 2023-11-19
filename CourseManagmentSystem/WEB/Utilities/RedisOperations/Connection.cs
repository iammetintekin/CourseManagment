using StackExchange.Redis;

namespace WEB.Utilities.RedisOperations
{
    public class Connection
    {
        private readonly string _host;
        private readonly string _port;
        public Connection(string host, string port)
        {
            _host = host;
            _port = port;
        }

        private ConnectionMultiplexer _multiplexer;
        public void Connect() => _multiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase Database(int Id=2) => _multiplexer.GetDatabase(Id);
    }
}
