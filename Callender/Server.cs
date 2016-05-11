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
        static public List<HandleClient> Clients = new List<HandleClient>();
        static Boolean _isRun = true;
        static TcpListener _listener;
        static readonly Object _locker = new Object();
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
            _listener = new TcpListener(new IPEndPoint(Config.IP, Config.Port));
            TcpClient client = default(TcpClient);

            IO.Write("Listening port: " + Config.Port);
            IO.Write("Listening IP: " + Config.IP);
            _listener.Start();
            IO.Write("Server Started");
            try
            {
                while (_isRun)
                {
                    client = _listener.AcceptTcpClient();
                    IO.Write("Incoming connection: " + client.Client.RemoteEndPoint.ToString());
                    IO.Write("Acceptiong new client");
                    lock(_locker)
                    {
                        Clients.Add(new HandleClient(client));
                    }
                }
            }
            catch (Exception) { }
        }

        public static void DisconectAll()
        {
            lock(_locker)
            {
                foreach (var e in Clients)
                {
                    e.Disconnect();
                }

                Clients.Clear();
            }
        }

        public static void Stop()
        {
            IO.Write("Stoping server");
            _isRun = false;
            _listener.Stop();
            IO.Write("Server stoped");
        }
    }
}
