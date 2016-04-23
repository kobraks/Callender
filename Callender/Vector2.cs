using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Vector2<T>
    {

        public Vector2(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

        public T x { get; set; }
        public T y { get; set; }
    }
}
