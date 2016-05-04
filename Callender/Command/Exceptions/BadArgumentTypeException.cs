using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command.Exceptions
{
    class BadArgumentTypeException : Exception
    {
        public BadArgumentTypeException() : base()
        { }

        public BadArgumentTypeException(string message) : base("Bad argument type " + message)
        { }

        public BadArgumentTypeException(string message, Exception inner): base("Bad argument type " + message, inner)
        { }
    }
}
