using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Command.Exceptions;

namespace Server.Command
{
    partial class Command
    {
        public Command()
        {
        }

        public static ICommand Parse(string str)
        {
            Tokenizer Tokenizer = new Tokenizer();
            Tokenizer.Tokenize(str);
            Parser parser = new Parser(Tokenizer.GetTokens());
            var parametrs = parser.Parse();

            if (parametrs.Count() == 0) return null;
            if (parametrs[0].Type == Parametr.EType.String)
            {
                var tmp = parametrs[0].Value.ToString().ToLower();

                if (tmp == "echo") return new Commands.Echo(parametrs);
                else if (tmp == "clear") return new Commands.Clear(parametrs);
                else if (tmp == "help") return new Commands.Help(parametrs);
                else if (tmp == "stop") return new Commands.Stop(parametrs);
                else throw new UnknownCommandException();
            }
            else throw new UnknownCommandException();
        }

        public void Execute(ICommand command)
        {
            if (command != null) command.Execute();
        }
    }
}
