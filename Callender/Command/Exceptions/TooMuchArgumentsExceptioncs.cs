using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command.Exceptions
{
    class TooMuchArgumentsExceptioncs : Exception
    {
        public TooMuchArgumentsExceptioncs() : base("Too much arguments to command")
        { }

        public TooMuchArgumentsExceptioncs(string message) : base("Too much arguments to command " + message)
        { }

        public TooMuchArgumentsExceptioncs(string message, Exception inner) : base ("Too much arguments to command " + message, inner)
        { }
    }
}
