using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Core;

namespace Client
{
    public class Connection : IDisposable
    {
        TcpClient client = new TcpClient();
        NetworkStream stream = null;
        bool disposed = false;

        public Connection() { }

        public void Connect(string ip, int port)
        {
            try
            {
                client.Connect(ip, port);
            }
            catch(Exception)
            {
                return;
            }

            stream = client.GetStream();
        }

        public void Disconnect()
        {
            stream.Dispose();
            client.Close();
        }

        public void Send(string[] message)
        {
            Packet packet = new Packet();

            foreach(var obj in message)
            {
                packet.Add(obj);
            }

            packet.Send(client);
        } 

        public string[] Answer()
        {
            Packet packet = new Packet();

            packet = packet.Take(client);

            return packet.List;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Disconnect();
            }

            disposed = true;
        }
    }
}
