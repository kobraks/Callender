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
        private Configuration config = new Configuration();
        private Boolean _isRun = true;

        public Server()
        {
            config.LoadFromFile("config.ini");
        }

        public void ParseArgv(string[] args)
        {

        }

        public void Run()
        {
            TcpListener listener = new TcpListener(new IPEndPoint(config.IP, config.Port));
            listener.Start();
            while (_isRun)
            {
            }
        }
    }
}
