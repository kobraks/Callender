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
                ban,
                save
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
                    tmp = tmp.ToLower();

                    if (tmp == Commands.clear.ToString().ToLower())
                    {
                        if (_params.Count == 1)
                        {
                            _command = Commands.clear;
                        }

                        else if (_params.Count == 2)
                        {
                            _command = Commands.clear;
                            command = _params.ToList()[1];

                            if (command.Type == Parametr.TypeVarable.Integer) haveParams = true;
                            else _message = "Parametr type: " + command.Type.ToString() + " expected Integer";
                        }
                        else _message = "Parametrs unknown current parametrs are Integer";
                    }
                    else if (tmp == Commands.help.ToString().ToLower())
                        _command = Commands.clear;
                    else if (tmp == Commands.echo.ToString().ToLower())
                        _command = Commands.echo;
                    else if (tmp == Commands.list.ToString().ToLower())
                        _command = Commands.list;
                    else if (tmp == Commands.save.ToString().ToLower())
                        _command = Commands.save;
                    else if (tmp == Commands.stop.ToString())
                    {
                        _command = Commands.stop;

                        if (_params.Count > 1) _message = "Stop: has no parametrs";
                    }
                    else _command = Commands.unknown;
                }

                if (_command == Commands.unknown) _message = "Unknown command";
                else _message = null;
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
                        else IO.ClearLine((int)_params.ToList()[1].Object);
                        break;

                    case Commands.echo:
                        if (_params.Count > 0)
                        {
                            var tmp = _params.ToList();
                            for (int i = 1; i < tmp.Count; i++)
                            {
                                _message += tmp[i].Object.ToString() + " ";
                            }
                        }
                        break;

                    case Commands.list:

                        break;
                }

            }

            #endregion
        }
    }
    
}
