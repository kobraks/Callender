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
            Queue<Parametr> _params;
            #endregion

            #region private
            Command()
            {
            }

            Command(Queue<Parametr> para)
            {
                this._params = para;
            }
            #endregion

            #region public
            public Object Clone()
            {
                return this.MemberwiseClone();
            }

            public static Command Parse(string text)
            {

                Tokenizer tokenizer = new Tokenizer();
                tokenizer.Tokenize(text);

                Parser parser = new Parser(tokenizer.Tokens);
                return new Command(parser.Parse());
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
