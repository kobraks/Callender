using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    partial class IO
    {
        partial class Command
        {
            class Token
            {
                public Token(string str, char type)
                {
                    Type = type;
                    String = str;
                }

                char Type { get; set; }
                string String { get; set; }
            }
        }
    }
}
