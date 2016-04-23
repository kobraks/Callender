using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace Server
{
    namespace IO
    {
        class Input
        {
            private static readonly Object _locker = new Object();
            private static Queue<string> _buff = new Queue<string>();
            private static Thread _thread;
            private static Boolean _isRun = true;

            /// <summary>
            /// Reads form buffer a text wirted in console
            /// </summary>
            /// <returns>Writed text form console, if nothing was write it will return null</returns>
            public static string Read()
            {
                if (_buff.Count == 0)
                {
                    return null;
                }

                lock (_locker)
                {
                    return _buff.Dequeue();
                }
            }

            static Input()
            {
                _thread = new Thread(exec);
                _thread.Start();
            }

            /// <summary>
            /// This function reads form console in another thread text
            /// </summary>
            private static void exec()
            {
                string command = "";

                while (_isRun)
                {
                    Command tmp = new Command(": " + command, -2, -2);
                    Output.WriteCommand(tmp);
                    ConsoleKeyInfo c = Console.ReadKey(true);

                    switch (c.Key)
                    {
                        case ConsoleKey.Enter:
                            lock (_locker)
                            {
                                _buff.Enqueue(command);
                            }
                            command = "";
                            break;

                        case ConsoleKey.Backspace:
                            if (!String.IsNullOrEmpty(command))
                            {
                                command = command.Remove(command.Length - 1);
                            }
                            break;

                        default:
                            if (!Char.IsControl(c.KeyChar)) command += c.KeyChar;
                            break;
                    }
                }
            }
        }
    }
}
