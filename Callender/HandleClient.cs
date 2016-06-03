using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Core;
using System.Diagnostics;

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
                    Packet packet = new Packet();
                    packet = packet.Take(Client);

                    var obj = packet.List;

                    foreach(var o in obj)
                    {
                        IO.Write(o);
                    }
                }
                catch (Exception)
                {
                    IO.Write("Client disconnected");
                    Disconnect();
                }
            }
        }

        public void Disconnect()
        {
            _isRun = false;
            Client.Close();
            thread.Abort();
        }
    }
}
