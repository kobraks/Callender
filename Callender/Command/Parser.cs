using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Command
{
    partial class Command
    {
        class Token
        {
            public string Value
            {
                get;
                set;
            }
            public char Type
            {
                get;
                set;
            }

            public Token(string value, char type)
            {
                this.Value = value;
                this.Type = type;
            }
        }

        class Tokenizer
        {
            List<Token> Tokens = new List<Token>();

            public void Tokenize(string str)
            {
                var split = PrepareToSplit(str).Split();
                foreach (var s in split)
                {
                    s.Trim();
                    bool special = false;
                    if (!String.IsNullOrEmpty(s))
                    {
                        if (s.Length == 1)
                        {
                            if (s[0] == '\\') special = true;
                            else if (s[0] == '\'') special = true;
                            else if (s[0] == '"') special = true;

                            if (special)
                            { 
                                Tokens.Add(new Token("", s[0]));
                                special = false;
                                continue;
                            }
                        }
                        if (IsInt(s)) Tokens.Add(new Token(s, 'i'));
                        else if (IsChar(s)) Tokens.Add(new Token(s, 'c'));
                        else if (IsFloat(s)) Tokens.Add(new Token(s, 'f'));
                        else if (IsDouble(s)) Tokens.Add(new Token(s, 'd'));
                        else Tokens.Add(new Token(s, 's'));
                        //IO.Write(Tokens.ElementAt(Tokens.Count - 1).Value + ", Type: " + Tokens.ElementAt(Tokens.Count - 1).Type);
                    }
                }
            }

            #region static
            static bool IsInt(string value)
            {
                int tmp;
                return int.TryParse(value, out tmp);
            }
            static bool IsChar(string value)
            {
                Char tmp;
                return char.TryParse(value, out tmp);
            }
            static bool IsFloat(string value)
            {
                float tmp;
                return float.TryParse(value, out tmp);
            }
            static bool IsDouble(string value)
            {
                double tmp;
                return double.TryParse(value, out tmp);
            }
            #endregion

            string PrepareToSplit(string str)
            {
                str = str.Replace("\"", " \" ");
                str = str.Replace("\\\"", " \\ \" ");
                str = str.Replace("'", " ' ");
                str = str.Replace("'", " \\ ' ");
                str.Trim();

                while (str.Contains("  "))
                    str = str.Replace("  ", " ");

                return str;
            }

            public List<Token> GetTokens()
            {
                return Tokens;
            }
        }


        class Parser
        {
            List<Token> Tokens = null;

            public Parser(List<Token> tokens)
            {
                Tokens = tokens;
            }

            public Parametr[] Parse()
            {
                List<Parametr> list = new List<Parametr>();

                bool _string = false;
                string s = "";

                for (int i = 0; i < Tokens.Count; i++)
                {
                    Token t = Tokens[i];
                    if (_string)
                    {
                        if (t.Type == '"' || t.Type == '\'')
                        {
                            list.Add(new Parametr(s.Clone()));
                            _string = false;
                            s = "";
                        }
                        else s += t.Value + " ";
                    }
                    else
                    {
                        if (t.Type == '\'' || t.Type == '"') _string = true;
                        if (!_string)
                        {
                            switch (t.Type)
                            {
                                case 'i':
                                    list.Add(new Parametr(t.Value, Parametr.EType.Integer));
                                    break;

                                case 'c':
                                    list.Add(new Parametr(t.Value, Parametr.EType.Char));
                                    break;

                                case 'd':
                                    list.Add(new Parametr(t.Value, Parametr.EType.Double));
                                    break;

                                case 'f':
                                    list.Add(new Parametr(t.Value, Parametr.EType.Float));
                                    break;

                                case 's':
                                    list.Add(new Parametr(t.Value, Parametr.EType.String));
                                    break;
                            }
                        }
                    }
                }

                return list.ToArray();
            }
        }
    }
}
