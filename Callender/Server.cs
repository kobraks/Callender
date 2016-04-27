using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class Server
    {
        List<HandleClient> _clients = new List<HandleClient>();
        Boolean _isRun = true;
        string _configurationFile = "config.ini";
        public Configuration Config
        {
            get;
            private set;
        }

        public Server()
        {
            Config = new Configuration();
            Config.LoadFromFile(_configurationFile);
        }

        public void ParseArgv(string[] args)
        {

        }

        public void Run()
        {
            TcpListener listener = new TcpListener(new IPEndPoint(Config.IP, Config.Port));
            TcpClient client = default(TcpClient);

            listener.Start();
            IO.Write("Server Started");
            IO.Read();
            while (_isRun)
            {
                client = listener.AcceptTcpClient();
                IO.Write("Acceptiong new client");
                _clients.Add(new HandleClient(client));
            }
        }
    }
}
