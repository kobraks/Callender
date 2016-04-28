using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    partial class IO
    {
        partial class Command
        {
            class Parametr
            {
                public enum TypeVarable
                {
                    Integer,
                    Char,
                    String,
                    Float,
                    Double,
                    None
                }
                
                public Parametr (Object obj, TypeVarable type)
                {
                    Type = type;
                    Object = obj;
                }

                public TypeVarable Type { get; set; }
                public Object Object { get; set; }
            }
        }
    }
}
