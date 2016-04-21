using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class IO
    {
        static IO()
        {
        }

        public static string read()
        {
            return Input.read;
        }

        public static void write(string toWrite)
        {
            Output.write(toWrite);
        }
    }
}
