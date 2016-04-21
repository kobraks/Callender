using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace Server
{
    class Input
    {
        private static readonly Object locker = new Object();
        private static Queue<string> buff = new Queue<string>();
        private static Thread thread;
        private static Boolean isRun = true;

        public static string read
        {
            get
            {
                lock(locker)
                {
                    if (buff.Count == 0)
                    {
                        return null;
                    }
                    else return buff.Dequeue();
                }
            }
        }

        static Input()
        {
            thread = new Thread(exec);
            thread.Start();
        }

        public void stop()
        {
            isRun = false;
            thread.Abort();
        }

        private static void exec()
        {
            string command = "";

            while(isRun)
            {
                Output.writeCommand(new Command(": " + command, -2, -2));
                ConsoleKeyInfo c =  Console.ReadKey(true);

                switch (c.Key)
                {
                    case ConsoleKey.Enter:
                        lock(locker)
                        {
                            buff.Enqueue(command);
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
