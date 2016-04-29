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

                    foreach (var token in _tokens)
                    {
                        switch(char.ToLower(token.Type))
                        {
                            case 'c':
                                tmp.Enqueue(new Parametr((Object)Char.Parse(token.String), Parametr.TypeVarable.Char));
                                break;
                            case 'i':
                                tmp.Enqueue(new Parametr((Object)int.Parse(token.String), Parametr.TypeVarable.Integer));
                                break;
                            case 'f':
                                tmp.Enqueue(new Parametr((Object)float.Parse(token.String), Parametr.TypeVarable.Float));
                                break;
                            case 'd':
                                tmp.Enqueue(new Parametr((Object)double.Parse(token.String), Parametr.TypeVarable.Double));
                                break;
                            default:
                                tmp.Enqueue(new Parametr((Object)token.String, Parametr.TypeVarable.String));
                                break;
                        }
                    }

                    return tmp;
                }
            }
        }
    }
}
