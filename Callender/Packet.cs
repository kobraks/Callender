using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    [Serializable]
    class Packet
    {
        Packet()
        {
            Objects = new List<object>();
        }

        public List<Object> Objects
        {
            get;
            private set;
        }

        public void Add(Object obj)
        {
            Objects.Add(obj);
        }

        private class Serializer<T>
        {
            public static void Serialize(NetworkStream stream, T obj)
            {
                if (obj != null)
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(stream, obj);
                }
            }

            public static T Deserialize(NetworkStream stream)
            {
                try
                {
                    var bf = new BinaryFormatter();
                    return (T)bf.Deserialize(stream);
                }
                catch(Exception)
                {
                    return default(T);
                }
            }
        }

        public static Packet Read(NetworkStream stream)
        {
            return Serializer<Packet>.Deserialize(stream);
        }

        public static void Send(NetworkStream stream, Packet pack)
        {
            Serializer<Packet>.Serialize(stream, pack);
        }
    }
}
