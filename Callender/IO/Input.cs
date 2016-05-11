using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace Server
{
    partial class IO
    {
        class Input
        {
            readonly Object _locker = new Object();
            Queue<string> _buff = new Queue<string>();
            Thread _thread;
            Boolean _isRun = true;
            Command.Command _command = new Command.Command();

            /// <summary>
            /// Reads form buffer a text wirted in console
            /// </summary>
            /// <returns>Writed text form console, if nothing was write it will return null</returns>
            public string Read()
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

            public Input()
            {
                _thread = new Thread(exec);
                _thread.Start();
            }

            /// <summary>
            /// This function reads form console in another thread text
            /// </summary>
            private void exec()
            {
                string command = "";

                while (_isRun)
                {
                    IO.WriteCommand(new Text(": " + command, -2, -2));
                    ConsoleKeyInfo c = Console.ReadKey(true);
                    switch (c.Key)
                    {
                        case ConsoleKey.Enter:
                            lock (_locker)
                            {
                                _buff.Enqueue(command);
                            }

                            IO.Write(command);
                            
                            try
                            {
                                _command.Execute(Command.Command.Parse(command));
                            }
                            catch(Exception ex)
                            {
                                IO.Write(ex.Message);
                            }

                            //IO.Write(tmp.ToText());

                            command = "";
                            IO.WriteCommand(new Text(": " + command, -2, -2));
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

            public void Stop()
            {
                _isRun = false;
                _thread.Abort();
            }
        }
    }
}
