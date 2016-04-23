using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    namespace IO
    {
        class IO
        {
            static IO()
            {
            }

            /// <summary>
            /// This function reads form buffer in Input class a text writed in console.
            /// </summary>
            /// <returns>Text writed in console or null when nothing was writed in console</returns>
            public static string Read()
            {
                return Input.Read();
            }

            /// <summary>
            /// This function is simple port of Output.Write
            /// Its just write a text in console
            /// </summary>
            /// <param name="toWrite"></param>
            public static void Write(string toWrite)
            {
                Output.Write(toWrite);
            }

            /// <summary>
            /// This function is simple port of Output.Write
            /// Its just write a text in console
            /// </summary>
            /// <param name="write"></param>
            public static void Write(Command write)
            {
                Output.Write(write);
            }

            /// <summary>
            /// This function is just for simple use of Output.Clear();
            /// And clear a console window
            /// </summary>
            public static void Clear()
            {
                Output.Clear();
            }
        }
    }
}
