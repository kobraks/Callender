using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.INIFiles
{
    class Section
    {
        string _name;

        public List<Variable> Variables
        {
            get;
            private set;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                string tmp = value;
                if (!String.IsNullOrEmpty(tmp))
                {
                    _name = tmp;
                }
            }
        }

        public Section(string name)
        {
            Variables = new List<Variable>();
            Name = name;
        }

        public void Add(Variable var)
        {
            Variables.Add(var);
        }

        public void Add(string name, string value)
        {
            Variables.Add(new Variable(name, value));
        }

        public Variable Find(string variableName)
        {
            variableName = variableName.ToUpper();
            foreach(Variable var in Variables)
            {
                if (var.Name.ToUpper() == variableName) return var;
            }

            return null;
        }

        #region static
        public static bool IsSection(string line)
        {
            if (String.IsNullOrEmpty(line)) return false;

            if (line[0] == '[')
                if (line[line.Length - 1] == ']') return true;

            return false;
        }

        public static string GetName(string line)
        {
            if (String.IsNullOrEmpty(line)) return null;
            if (!IsSection(line)) return null;

            line = line.TrimStart('[');
            line = line.TrimEnd(']');
            return line;
        }

        #endregion
    }
}
