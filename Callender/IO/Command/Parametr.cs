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
            struct Parametr
            {
                enum TypeVarable
                {
                    Integer,
                    Char,
                    String,
                    Float,
                    Double,
                    None
                }
                
                Parametr (Object obj, TypeVarable type)
                {
                    Type = type;
                    Object = obj;
                }

                TypeVarable Type { get; set; }
                Object Object { get; set; }
            }
        }
    }
}
