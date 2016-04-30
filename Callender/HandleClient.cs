using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class HandleClient
    {
        Thread thread;
        bool _isRun = true;
        public TcpClient Client
        {
            get;
            private set;
        }

        public HandleClient(TcpClient client)
        {
            Client = client;
            thread = new Thread(Exec);
            thread.Start();
        }

        void Exec()
        {
            while(_isRun)
            {
                try
                {
                    var networkStream = Client.GetStream();

                    Packet packet = Packet.Read(networkStream);
                }
                catch (Exception ex)
                {
                    IO.Write(ex.ToString());
                }
            }
        }
    }
}
