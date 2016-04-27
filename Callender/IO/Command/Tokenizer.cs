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
                    var split = str.Split(' ');
                    foreach (var element in split)
                    {
                        var tmp = element;
                        tmp = tmp.TrimStart(' ');
                        tmp = tmp.TrimEnd(' ');


                    }
                }
                #endregion

                #region private
                
                #endregion

            }
        }
    } 
}
