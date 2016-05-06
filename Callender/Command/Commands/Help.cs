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

        public Help(Parametr[] parametrs)
        {
            if (parametrs.Count() > 1)
            {
                if (parametrs.Count() == 2)
                {
                    if (parametrs[1].Type == Parametr.EType.String)
                    {
                        _help = Command.Parse(parametrs[1].Value.ToString());
                    }
                    else throw new UnknownCommandException(parametrs[1].Value.ToString());
                }
                else throw new TooMuchArgumentsExceptioncs();
            }
        }

        public void Execute()
        {
            if (_help == null)
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
                    "\tLIST - List users are connection to the server"
                };
               
                IO.WriteLines(lines);
            }
            else ShowHelp();
        }

        public void ShowHelp()
        {
            if (_help == null) return;

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
