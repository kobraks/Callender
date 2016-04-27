using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    partial class IO
    {
        public partial class Command : ICloneable
        {
            #region priv_varables
            string _message;
            #endregion

            #region private
            Command()
            {
            }
            #endregion

            #region public
            public Object Clone()
            {
                return this.MemberwiseClone();
            }

            public static Command Parse(string text)
            {
                Command tmp = new Command();

                Tokenizer tokenizer = new Tokenizer();
                tokenizer.Tokenize(text);

                Parser parser = new Parser(tokenizer.Tokens);
                return tmp;
            }

            public Text ToText()
            {
                return new IO.Text(_message);
            }

            public void Use()
            {
            }
            #endregion
        }
    }
    
}
