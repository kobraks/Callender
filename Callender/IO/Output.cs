using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    namespace IO
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
                _thread = new Thread(Exec);
                _thread.Start();
            }

            /// <summary>
            /// This Function returns a bottom of console
            /// </summary>
            /// <returns>A bottom of console</returns>
            static int Bottom()
            {
                if (Console.WindowHeight - 1 > y)
                    return Console.WindowHeight - 1;
                else
                    return (y - Console.WindowWidth) + Console.WindowWidth;
            }

            /// <summary>
            /// This Function clear a current line of console
            /// </summary>
            /// <param name="line">line to clear</param>
            static void ClearLine(int line)
            {
                //Clean a pointed line in console
                int currentLine = Console.CursorTop;
                Console.SetCursorPosition(0, line);
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition(0, currentLine);
            }

            /// <summary>
            /// Main function where text is write on the console, its working in another thread
            /// </summary>
            static void Exec()
            {
                while (_isRun)
                {
                    lock (_locker)
                    {
                        while (_buff.Count == 0) Monitor.Wait(_locker);

                        Command tmp = _buff.Dequeue();

                        Console.SetCursorPosition(tmp.Coords.x, tmp.Coords.y);
                        Console.Write(tmp.Text);
                        Console.ForegroundColor = tmp.Color;
                        Console.ResetColor();
                        try
                        {
                            Console.SetCursorPosition(_lastedCommand.Text.Length, Bottom());
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.SetCursorPosition(0, y);
                        }
                    }
                }
            }
            #endregion

            #region public_members
            /// <summary>
            /// This method only is used to write command from Input Class
            /// </summary>
            /// <param name="command">Command</param>
            public static void WriteCommand(Command command)
            {
                try
                {
                    lock (_locker)
                    {
                        if (_lastedCommand != null)
                        {
                            if (_lastedCommand.Text.Length > command.Text.Length)
                            {
                                ClearLine(Bottom());
                            }
                        }

                        command.Coords.x = 0;
                        command.Coords.y = Bottom();
                        _lastedCommand = (Command)command.Clone();

                        _buff.Enqueue(command);
                        Monitor.Pulse(_locker);
                    }
                }
                catch(NullReferenceException ex)
                {
                    return;
                }
            }

            public static void Write(Command write)
            {
                lock(_locker)
                {
                    ClearLine(y);
                    if (write.Coords.y < 0) write.Coords.y = y;
                    if (write.Coords.x < 0) write.Coords.x = 0;
                    _buff.Enqueue(write);
                    Monitor.Pulse(_locker);
                    y++;
                    WriteCommand(_lastedCommand);
                }
            }

            /// <summary>
            /// This method is used to add to buffer some text and then it will be write in console
            /// </summary>
            /// <param name="toWrite">Whats do you want to write in console</param>
            public static void Write(string toWrite)
            {
                if (String.IsNullOrEmpty(toWrite)) return;

                Write(new Command(toWrite));
            }

            /// <summary>
            /// Clear console window
            /// </summary>
            public static void Clear()
            {
                lock (_locker)
                {
                    Console.Clear();
                    y = 0;
                    _lastedCommand.Coords.y = Bottom();
                    _buff.Enqueue(_lastedCommand);
                }
            }
            #endregion
        }
    }
}
