using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    partial class IO
    {
        class Output
        {
            #region private members
             int y = 0;
             readonly Object _locker = new Object();
             Queue<Text> _buff = new Queue<Text>();
             Thread _thread;
             Boolean _isRun = true;
             Text _lastedCommand = null;

             public Output()
            {
                _thread = new Thread(Exec);
                _thread.Start();
            }

            /// <summary>
            /// This Function returns a bottom of console
            /// </summary>
            /// <returns>A bottom of console</returns>
             int Bottom()
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
             void ClearLine(int line)
            {
                //Clean a pointed line in console
                int currentLine = Console.CursorTop;
                Console.SetCursorPosition(0, line);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 0);
                Console.SetCursorPosition(0, line);
            }

            /// <summary>
            /// Main function where text is write on the console, its working in another thread
            /// </summary>
             void Exec()
            {
                while (_isRun)
                {
                    lock (_locker)
                    {
                        while (_buff.Count == 0) Monitor.Wait(_locker);

                        Text tmp = _buff.Dequeue();

                        Console.SetCursorPosition(tmp.Coords.x, tmp.Coords.y);
                        Console.Write(tmp.String);
                        Console.ForegroundColor = tmp.Color;
                        Console.ResetColor();
                        try
                        {
                            int x = _lastedCommand.String.Length;
                            int y = Bottom();

                            for (; x >= Console.BufferWidth;)
                            {
                                x -= Console.BufferWidth;
                                y += 1;
                            }

                            Console.SetCursorPosition(x, y);
                        }
                        catch (NullReferenceException)
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
            public  void WriteCommand(Text command)
            {
                try
                {
                    lock (_locker)
                    {
                        if (_lastedCommand != null)
                        {
                            if (_lastedCommand.String.Length > command.String.Length)
                            {
                                ClearLine(Bottom());
                                int x = _lastedCommand.String.Length;
                                for (int i = 0; x >= Console.BufferWidth; i++)
                                {
                                    ClearLine(Bottom() + 1);
                                    x -= Console.BufferWidth;
                                }
                            }
                        }

                        command.Coords.x = 0;
                        command.Coords.y = Bottom();
                        _lastedCommand = (Text)command.Clone();

                        _buff.Enqueue(_lastedCommand);
                        Monitor.Pulse(_locker);
                    }
                }
                catch(NullReferenceException)
                {
                    return;
                }
            }

            public  void Write(Text write)
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
            public  void Write(string toWrite)
            {
                if (String.IsNullOrEmpty(toWrite)) return;

                Write(new Text(toWrite));
            }

            /// <summary>
            /// Clear console window
            /// </summary>
            public  void Clear()
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
