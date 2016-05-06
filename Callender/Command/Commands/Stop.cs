using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command.Commands
{
    class Stop : ICommand
    {
        public Stop(Parametr[] parametrs)
        {

        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void ShowHelp()
        {
            throw new NotImplementedException();
        }
    }
}
