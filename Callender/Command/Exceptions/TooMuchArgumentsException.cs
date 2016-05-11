using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command.Exceptions
{
    class TooMuchArgumentsException : Exception
    {
        public TooMuchArgumentsException() : base("Too much arguments to command")
        { }

        public TooMuchArgumentsException(string message) : base("Too much arguments to command " + message)
        { }

        public TooMuchArgumentsException(string message, Exception inner) : base ("Too much arguments to command " + message, inner)
        { }
    }
}
