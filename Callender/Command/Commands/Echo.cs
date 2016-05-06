using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command.Commands
{
    class Echo : ICommand
    {
        string message = null;

        public Echo(Parametr[] parametrs)
        {
            if (parametrs.Count() == 1) return;
            else
            {
                for (int i = 1; i < parametrs.Count(); i++)
                {
                    message += parametrs[i].Value.ToString() + " ";
                }
            }
        }

        public void Execute()
        {
            IO.Write(new IO.Text(message));
        }

        public void ShowHelp()
        {
            throw new NotImplementedException();
        }
    }
}
