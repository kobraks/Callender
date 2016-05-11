using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Command.Exceptions;
using System.Threading;

namespace Server.Command.Commands
{
    class Stop : ICommand
    {
        public Stop(Parametr[] parametrs)
        {
            if (parametrs.Count() > 1) throw new TooMuchArgumentsException();
        }

        public void Execute()
        {
            Server.DisconectAll();
            Server.Stop();

            Environment.Exit(0);
        }

        public void ShowHelp()
        {
            string[] lines =
            {
                "\tStoping a server"
            };

            IO.WriteLines(lines);
        }
    }
}
