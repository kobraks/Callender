using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.INIFiles
{
    class Variable
    {
        public Variable(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public static bool IsVariable(string line)
        {
            if (String.IsNullOrEmpty(line)) return false;
            if (line.IndexOf('=') != -1 && line[0] != ';') return true;
            return false;
        }

        public static string GetName(string line)
        {
            if (String.IsNullOrEmpty(line)) return null;
            if (!IsVariable(line)) return null;
            string tmp = "";
            tmp = line.Substring(0, line.IndexOf('='));
            tmp = tmp.TrimEnd(' ');
            tmp = tmp.TrimStart(' ');

            return tmp;
        }

        public static string GetValue(string line)
        {
            if (String.IsNullOrEmpty(line)) return null;
            if (!IsVariable(line)) return null;
            string tmp = "";
            tmp = line.Substring(line.IndexOf('=') + 1);
            tmp = tmp.TrimEnd(' ');
            tmp = tmp.TrimStart(' ');

            return tmp;
        }
    }
}
