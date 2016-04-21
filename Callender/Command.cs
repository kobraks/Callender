using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Command : ICloneable
    {
        Vector2<int> _coords;
        ConsoleColor _color;
        string _s;

        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        public Command(string command, int x = -1, int y = -1, ConsoleColor color = ConsoleColor.White)
        {
            _coords = new Vector2<int>(x, y);
            this._color = color;
            _s = command;
        }

        public string command
        {
            get
            {
                return _s;
            }

            set
            {
                _s = value;
            }
        }

        public ConsoleColor color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public Vector2<int> coords
        {
            get
            {
                return _coords;
            }
            set
            {
                _coords = value;
            }
        }

    }
}
