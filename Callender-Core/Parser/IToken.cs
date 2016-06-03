using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Parser
{
    public interface IToken
    {
        char Key { get; set; }
        string Value { get; set; }
    }
}
