using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Parser
{
    public interface ITokenizer
    {
        IToken[] Tokenize();
    }
}
