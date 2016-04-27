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
            class Parser
            {
                List<Token> _tokens;

                public Parser(List<Token> tokens)
                {
                    _tokens = tokens;
                }

                public Queue<Parametr> Parse()
                {
                    Queue<Parametr> tmp = new Queue<Parametr>();


                    return tmp;
                }
            }
        }
    }
}
