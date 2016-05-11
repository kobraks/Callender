using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command.Commands
{
    class List : ICommand
    {
        public List(Parametr[] parametrs)
        {
            if (parametrs.Count() > 1)
            {
                throw new Exceptions.TooMuchArgumentsException();
            }
        }

        public void Execute()
        {
            foreach(var e in Server.Clients)
            {
                IO.Write(e.Client.ToString());
            }
        }

        public void ShowHelp()
        {
            throw new NotImplementedException();
        }
    }
}
