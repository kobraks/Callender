using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command
{
    class Parametr
    {
        public enum EType
        {
            String,
            Char,
            Integer,
            Float,
            Double,
        }

        public EType Type
        {
            get;
            set;
        }

        public Object Value
        {
            get;
            set;
        }

        public Parametr(Object value, EType type = EType.String)
        {
            Type = type;
            Value = value;
        }
    }
}
