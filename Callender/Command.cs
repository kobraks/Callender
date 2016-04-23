using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Command : ICloneable
    {
        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        public Command(string command, int x = 0, int y = -1, ConsoleColor color = ConsoleColor.White)
        {
            Coords = new Vector2<int>(x, y);
            this.Color = color;
            Text = command;
        }

        public string Text { get; set; }
        public ConsoleColor Color { get; set; }
        public Vector2<int> Coords { get; set; }
    }
}
