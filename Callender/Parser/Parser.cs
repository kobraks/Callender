using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Parser
{
    class Parser : IDisposable
    {
        bool _disposed = false;

        /*Tokenizer _token = null;
        public Tokenizer Tokenizer
        {
            private get;
            set;
        }*/

        public Parser()
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {

            }
            
            _disposed = true;
        }

        ~Parser()
        {
            Dispose(true);
        }
    }
}
