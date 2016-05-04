using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command.Exceptions
{
    class UnknownCommandException : Exception
    {
        public UnknownCommandException()
        { }

        public UnknownCommandException(string message) : base("Unknown command: " + message)
        {}

        public UnknownCommandException(string message, Exception inner) : base("Unknown command: " + message, inner)
        { }
    }
}
