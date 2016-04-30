using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server
{
    class Configuration
    {
        INIFiles.INIFiles _ini = new INIFiles.INIFiles();
        public Configuration()
        {}

        public int Port
        {
            get;
            private set;
        }
        public IPAddress IP
        {
            get;
            private set;
        }
        public int MaxConnections
        {
            get;
            private set;
        }

        public string DBHost
        {
            get;
            private set;
        }
        public string DBUser
        {
            get;
            private set;
        }
        public string DBPassword
        {
            get;
            private set;
        }
        public string DBName
        {
            get;
            private set;
        }

        public bool LoadFromFile(string fileName)
        {
            if (!_ini.Open(fileName))
            {
                IO.Write("Cannot open the file " + fileName);

                IO.Write("Restoring values to default");
                Default();
                IO.Write("Creating a new configuration file");
                _ini.Save();

                return false;
            }
            else Read();

            return true;
        }

        public void Default()
        {
            IP = IPAddress.Parse("127.0.0.1");
            Port = 55005;
            MaxConnections = 30;

            DBHost = "localhost";
            DBName = "Callender";
            DBUser = "root";
            DBPassword = "";

            _ini.WriteString("General", "IPAdress", "127.0.0.1");
            _ini.WriteInt("General", "Port", 55005);
            _ini.WriteInt("General", "maxusers", 30);
            _ini.WriteString("DataBase", "Host", DBHost);
            _ini.WriteString("DataBase", "Name", DBName);
            _ini.WriteString("DataBase", "User", DBUser);
            _ini.WriteString("DataBase", "Password", DBPassword);
        }

        private void Read()
        {
           try
            {
                IP = IPAddress.Parse(_ini.ReadString("General", "IPAdress", "127.0.0.1"));
            }
            catch(FormatException)
            {
                IO.Write("Unknown IPAddres" + _ini.ReadString("General", "IPAdress", "127.0.0.1"));
                IO.Write("Using default 127.0.0.1");
                IP = IPAddress.Parse("127.0.0.1");
            }
            Port = _ini.ReadInt("General", "Port", 55005);
            MaxConnections = _ini.ReadInt("General", "maxUsers", 30);

            DBHost = _ini.ReadString("DataBase", "Host", "localhost");
            DBUser = _ini.ReadString("DataBase", "User", "root");
            DBName = _ini.ReadString("DataBase", "Name", "Callender");
            DBPassword = _ini.ReadString("DataBase", "Password", "");
        }
    }
}
