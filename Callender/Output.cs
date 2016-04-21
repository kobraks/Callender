using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    class Output
    {
        #region private members
        static int y = 0;
        static readonly Object _locker = new Object();
        static Queue<Command> _buff = new Queue<Command>();
        static Thread _thread;
        static Boolean _isRun = true;
        static Command _lastedCommand = null;

        static Output()
        {
            _thread = new Thread(exec);
            _thread.Start();
        }

        static int bottom
        {
            get
            {
                return Console.WindowHeight - 1 > y ? Console.WindowHeight - 1 : (y - Console.WindowWidth) + Console.WindowWidth;
            }
        }

        static void clearLine(int line)
        {
            //Clean a pointed line in console
            int currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Console.WindowWidth - 1));
            Console.SetCursorPosition(0, currentLine);
        }

        static void exec()
        {
            while (_isRun)
            {
                lock (_locker)
                {
                    while (_buff.Count == 0) Monitor.Wait(_locker);

                    Command tmp = _buff.Dequeue();

                    Console.SetCursorPosition(tmp.coords.x, tmp.coords.y);
                    Console.Write(tmp.command);
                    Console.SetCursorPosition(_lastedCommand.command.Length, bottom);
                }
            }
        }
        #endregion

        #region public_members
        public static void writeCommand(Command command)
        {
            lock (_locker)
            {
                if (_lastedCommand != null)
                {
                    if (_lastedCommand.command.Length > command.command.Length)
                    {
                        clearLine(bottom);
                    }
                }

                command.coords.x = 0;
                command.coords.y = bottom;
                _lastedCommand = (Command)command.Clone();

                _buff.Enqueue(command);
                Monitor.Pulse(_locker);
            }
        }

        public static void write(string toWrite)
        {
            if (String.IsNullOrEmpty(toWrite)) return;

            lock (_locker)
            {
                clearLine(y);
                _buff.Enqueue(new Command(toWrite, 0, y));
                Monitor.Pulse(_locker);
                y++;
            }
            writeCommand(_lastedCommand);
        }

        public static void stop()
        {
            _isRun = false;
            _thread.Abort();
        }
        #endregion
    }
}
