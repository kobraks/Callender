using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Command.Exceptions;

namespace Server.Command.Commands
{
    class Help : ICommand
    {
        ICommand _help = null;
        Parametr[] _parametrs = null;

        public Help(Parametr[] parametrs)
        {
            _parametrs = parametrs;
            if (parametrs.Count() > 1)
            {
                if (parametrs.Count() == 2)
                {
                    if (parametrs[1].Type == Parametr.EType.String)
                    {
                        try
                        {
                            _help = Command.Parse(parametrs[1].Value.ToString());
                        }
                        catch (UnknownCommandException ex)
                        {
                            IO.Write(ex.Message + " for " + parametrs[1].Value.ToString());
                        }
                    }
                    else throw new BadArgumentTypeException();
                }
                else throw new TooMuchArgumentsException();
            }
        }

        public void Execute()
        {
            if (_help == null && _parametrs.Count() == 1)
            {
                string[] lines =
                {
                    "For more information on a specific command, type HELP command-name",
                    "",
                    "\tCLEAR - clear screen",
                    "\tECHO - show message on screen",
                    "\tHELP - Provides Help information",
                    "\tSTOP - Stoping the server",
                    "\tBAN - Banning the selected client",
                    "\tLIST - List users are connected to the server"
                };

                IO.WriteLines(lines);
            }
            else if (_parametrs.Count() == 2 && _help != null) _help.ShowHelp();
        }

        public void ShowHelp()
        {
            string[] lines =
            {
                "\tProvides help information for commands.",
                "\tHELP [command]",
                "",
                "\tcommand - displays help information on that command."
            };

            IO.WriteLines(lines);
        }
    }
}
