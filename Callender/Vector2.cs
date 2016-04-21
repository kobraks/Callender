using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Vector2<T>
    {
        T _x;
        T _y;

        public Vector2(T x, T y)
        {
            this._x = x;
            this._y = y;
        }

        public T x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public T y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }
    }
}
