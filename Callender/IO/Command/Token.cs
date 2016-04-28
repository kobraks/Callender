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
                #region public
                public Token(string str, char type)
                {
                    Type = type;
                    String = str;
                }

                public static Token StringToToken(string str)
                {
                    Token t = new Token();

                    if (str == "\\") t.Type =  '\\';
                    else if (str == "'") t.Type = '\'';
                    else if (str == "\"") t.Type = '"';
                    else
                    {
                        if (IsInt(str)) t.Type = 'i';
                        else if (IsFloat(str)) t.Type = 'f';
                        else if (IsDouble(str)) t.Type = 'd';
                        else if (IsChar(str)) t.Type = 'c';
                        else t.Type = 's';

                        t.String = str;
                    }

                    return t;
                }
                public char Type { get; set; }
                public string String { get; set; }
                #endregion

                #region private
                Token()
                {
                    this.String = "";
                    this.Type = ' ';
                }

                private static bool IsInt(string str)
                {
                    int k = 0;
                    return int.TryParse(str, out k);
                }

                private static bool IsFloat(string str)
                {
                    float k = 0;
                    return float.TryParse(str, out k);
                }

                private static bool IsDouble(string s)
                {
                    double k = 0;
                    return Double.TryParse(s, out k);
                }

                private static bool IsChar(string s)
                {
                    char k = ' ';
                    return char.TryParse(s, out k);
                }
                #endregion
                
            }
        }
    }
}
