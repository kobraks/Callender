using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private Boolean isRun = true;

        public Server()
        {
        }

        public void parseArgv(string[] args)
        {

        }

        public void run()
        {
            while(isRun)
            {
                string s= IO.read();

                if (s != null)
                {
                    IO.write(s);
                }
            }
        }
    }
}
