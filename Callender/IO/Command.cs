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
            #region types
            enum Commands
            {
                unknown,
                clear,
                echo,
                stop,
                ping,
                help,
                list,
                ban
            }
            #endregion

            #region priv_varables
            string _message = null;
            Queue<Parametr> _params = null;
            Commands _command = Commands.unknown;
            bool haveParams = false;
            #endregion

            #region private
            Command()
            {
            }

            Command(Queue<Parametr> para)
            {
                this._params = para;

                SearchForTheCommand();
            }

            void SearchForTheCommand()
            {
                var command = _params.First();

                if (command.Type == Parametr.TypeVarable.String)
                {
                    string tmp = (string)(command.Object);
                    if (tmp.ToLower() == Commands.clear.ToString().ToLower())
                    {
                        if (_params.Count == 1)
                        {
                            _command = Commands.clear;
                            IO.Clear();
                        }

                        else if (_params.Count == 2)
                        {
                            command = _params.ToList()[1];

                            if (command.Type == Parametr.TypeVarable.Integer)
                            {
                                haveParams = true;
                                IO.ClearLine((int)command.Object);
                            }
                            else _message = "Parametr type: " + command.Type.ToString() + " expected Integer";
                        }
                        else _message = "Parametrs unknown current parametrs are Integer";
                    }
                    else if (tmp.ToLower() == Commands.help.ToString().ToLower())
                    {

                    }
                    else _command = Commands.unknown;
                }
                
                if (_command == Commands.unknown) _message = "Unknown command";
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
                switch (_command)
                {
                    case Commands.clear:
                        if (!haveParams) IO.Clear();
                        else IO.ClearLine((int)_params.ToList()[0].Object);
                        break;
                }

            }

            #endregion
        }
    }
    
}
