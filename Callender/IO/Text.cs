using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    partial class IO
    {
        public class Text : ICloneable
        {
            #region public
            public Object Clone()
            {
                return this.MemberwiseClone();
            }

            public Text(string str, int x = -1, int y = -1, ConsoleColor color = ConsoleColor.White)
            {
                this.String = str;
                Coords = new Vector2<int>(x, y);
                Color = color;
            }

            public Text(string str, Vector2<int> coords, ConsoleColor color = ConsoleColor.White)
            {
                String = str;
                Coords = coords;
                Color = color;
            }

            #region properties
            public Vector2<int> Coords
            {
                get
                {
                    return _coords;
                }
                set
                {
                    Vector2<int> tmp = value;
                    if (tmp.x < -2) tmp.x = 0;
                    if (tmp.y < -2) tmp.y = 0;
                }
            }

            public string String { get; set; }
            public ConsoleColor Color { get; set; }
            #endregion
            #endregion

            private Vector2<int> _coords = new Vector2<int>(0, 0);
        }
    }
}
