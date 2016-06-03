using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    class Serializer<T>
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
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
