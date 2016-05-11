using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    partial class IO
    {
        static Input _in = new Input();
        static Output _out = new Output();

        static IO()
        {
        }

        #region input
        /// <summary>
        /// This function reads form buffer in Input class a text writed in console.
        /// </summary>
        /// <returns>Text writed in console or null when nothing was writed in console</returns>
        public static string Read()
        {
            return _in.Read();
        }
        #endregion

        #region output
        /// <summary>
        /// This function is simple port of Output.Write
        /// Its just write a text in console
        /// </summary>
        /// <param name="toWrite"></param>
        public static void Write(string toWrite)
        {
            _out.Write(DateTime.Now.ToString("HH:mm:ss") + "> " + toWrite);
        }

        /// <summary>
        /// This function is simple port of Output.Write
        /// Its just write a text in console
        /// </summary>
        /// <param name="write"></param>
        public static void Write(Text write)
        {
            if (String.IsNullOrEmpty(write.String)) return;
            write.String = DateTime.Now.ToString("HH:mm:ss") + "> " + write.String;
            _out.Write(write);
        }

        /// <summary>
        /// This function is just for simple use of Output.Clear();
        /// And clear a console window
        /// </summary>
        public static void Clear()
        {
            _out.Clear();
        }

        public static void ClearLine(int line)
        {
            if (line < 0) return;
            _out.ClearLine(line);
        }

        private static void WriteCommand(Text command)
        {
            _out.WriteCommand(command);
        }

        public static void WriteLines(string[] lines)
        {
            _out.WriteLines(lines);
        }

        public static void Stop()
        {
            Write("Stopping Input Output operations");
            _in.Stop();
            _out.Stop();

            _in = null;
            _out = null;
        }
        #endregion
    }
}
