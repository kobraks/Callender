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
            class Tokenizer
            {
                #region public
                public List<Token> Tokens
                {
                    get;
                    private set;
                }

                public Tokenizer()
                {
                    Tokens = new List<Token>();
                }

                public void Tokenize(string str)
                {
                    string[] split = SplitForTokenize(str);
                    foreach(var s in split)
                    {
                        Token t = Token.StringToToken(s);
                        Tokens.Add(t);
                    }
                }
                #endregion

                #region private
                private string[] SplitForTokenize(string str)
                { 
                    str = str.Replace("\\'", " \\' ");
                    str = str.Replace("\\'", " \\' ");
                    str = str.Replace("'", " ' ");
                    str = str.Replace("\"", " \" ");
                    str = str.Trim();

                    while(str.Contains("  "))
                        str = str.Replace("  ", " ");

                    return str.Split(' ');
                }
                #endregion
            }
        }
    } 
}
