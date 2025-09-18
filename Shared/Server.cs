
namespace MyApp.Shared
{
    internal class Server
    {
        private string _host;
        private int _port;
        private static DateTime? _startTime;


        public Server(string host, int port)
        {
            this._host = host;
            this._port = port;
        }
        public string Host { get => _host; set => _host = value; }
        public int Port { get => _port; set => _port = value; }
        public static DateTime StartTime => _startTime ?? throw new InvalidOperationException("Server not started yet.");

        internal void Start()
        {
            if (_startTime != null)
                throw new InvalidOperationException("Server already started.");

            _startTime = DateTime.Now;
        }

    }
}