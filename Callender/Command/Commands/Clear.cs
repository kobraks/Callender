using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Command.Exceptions;

namespace Server.Command.Commands
{
    class Clear : ICommand
    {
        int line = -1;

        public Clear(Parametr[] param)
        {
            if (param.Count() > 1)
            {
                if (param.Count() == 2)
                {
                    if (param[1].Type == Parametr.EType.Integer) line = int.Parse(param[1].Value.ToString());
                    else throw new BadArgumentTypeException(param[1].Type.ToString());
                }
                else throw new TooMuchArgumentsException();
            }
        }

        public void Execute()
        {
            if (line >= 0)
            {
                IO.ClearLine(line);
            }
            else IO.Clear();
        }

        public void ShowHelp()
        {
            string[] lines =
            {
                "\tCleaning the console window",
                "\tHELP [line]",
                "",
                "\tline - Clean the current line."
            };

            IO.WriteLines(lines);
        }
    }
}
