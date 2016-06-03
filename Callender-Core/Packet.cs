using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Packet
    {
        string[] command = null;

        public string[] List
        {
            get
            {
                return command;
            }
        }

        public Packet()
        {

        }

        public void Add(string what)
        {
            List<string> tmp;
            if (command == null) tmp = new List<string>();
            else tmp  = new List<string>(command);
            tmp.Add(what);
            command = tmp.ToArray();
        }

        public void Send(TcpClient client)
        {
            Serializer<Packet>.Serialize(client.GetStream(), this);
        }

        public Packet Take(TcpClient client)
        {
            return Serializer<Packet>.Deserialize(client.GetStream());
        }
    }
}
