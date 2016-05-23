using System;
using System.Collections.Generic;
using Core.INIFiles;
using System.IO;

namespace Callender_Core
{
    /// <summary>
    /// Class used to read and write a ini files.
    /// </summary>
    public class INIFile
    {

        int _precision = 3;

        /// <summary>
        /// Sections
        /// </summary>
        List<Section> Sections
        {
            get;
            set;
        }

        /// <summary>
        /// Name of INIFile and path to it
        /// </summary>
        public string FileName
        {
            get;
            private set;
        }

        /// <summary>
        /// Precision of float and double values that you want to write in ini file
        /// </summary>
        public int Precision
        {
            get
            {
                return _precision;
            }
            set
            {
                int tmp = value;
                if (tmp < 0)
                    _precision = 0;
                else _precision = tmp;
            }
        }

        public INIFile()
        {
            Sections = new List<Section>();
        }

        /// <summary>
        /// Open and try to read ini file
        /// </summary>
        /// <param name="fileName">Path to ini file</param>
        /// <returns>Return false when it cannot open a ini file or true when it read it</returns>
        public bool Open(string fileName)
        {
            FileName = fileName;

            if (!File.Exists(FileName)) return false;

            StreamReader reader = new StreamReader(FileName);

            string line;
            Section section = null;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.TrimEnd(' ');
                line = line.TrimStart(' ');

                if (String.IsNullOrEmpty(line)) continue;

                if (line[0] != ';')
                {
                    if (Section.IsSection(line))
                    {
                        section = new Section(Section.GetName(line));
                        Sections.Add(section);
                    }
                    else if (Variable.IsVariable(line) && section != null)
                    {
                        section.Add(new Variable(Variable.GetName(line), Variable.GetValue(line)));
                    }
                }
            }

            DeleteDuplicates();
            reader.Close();

            return true;
        }

        /// <summary>
        /// Delete duplicates of sections
        /// </summary>
        void DeleteDuplicates()
        {
            for (int i = 0; i < Sections.Count; i++)
            {
                for (int b = 0; b < Sections.Count; b++)
                {
                    if (b != i && Sections[b].Name.ToUpper() == Sections[i].Name.ToUpper() && b > i)
                    {
                        Sections.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// Try to found a section
        /// </summary>
        /// <param name="sectionName">Name of section to found</param>
        /// <returns>A fined section, if not found it will return null</returns>
        Section FindSection(string sectionName)
        {
            sectionName = sectionName.ToUpper();
            foreach (Section element in Sections)
            {
                if (element.Name.ToUpper() == sectionName) return element;
            }

            return null;
        }

        #region read
        /// <summary>
        /// Read a string value from a INIFile
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="defaultValue">Default Value returned if section or variable does not found</param>
        /// <returns>A string form file if that string doesnt found it will return a default value</returns>
        public string ReadString(string section, string variable, string defaultValue)
        {
            Section sect = FindSection(section);
            if (sect != null)
            {
                Variable var = sect.Find(variable);

                if (var != null)
                {
                    return var.Value;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Read a integer value from a INIFile
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="defaultValue">Default Value returned if section or variable does not found</param>
        /// <returns>A integer form file if that integer doesnt found it will return a default value</returns>
        public int ReadInt(string section, string variable, int defaultValue)
        {
            try
            {
                return int.Parse(ReadString(section, variable, defaultValue.ToString()));
            }
            catch (FormatException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Read a char value from a INIFile
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="defaultValue">Default Value returned if section or variable does not found</param>
        /// <returns>A char form file if that char doesnt found it will return a default value</returns>
        public char ReadChar(string section, string variable, char defaultValue)
        {
            try
            {
                return char.Parse(ReadString(section, variable, defaultValue.ToString()));
            }
            catch (FormatException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Read a double value from a INIFile
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="defaultValue">Default Value returned if section or variable does not found</param>
        /// <returns>A double form file if that double doesnt found it will return a default value</returns>
        public double ReadDouble(string section, string variable, double defaultValue)
        {
            try
            {
                return double.Parse(ReadString(section, variable, defaultValue.ToString()));
            }
            catch (FormatException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Read a float value from a INIFile
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="defaultValue">Default Value returned if section or variable does not found</param>
        /// <returns>A float form file if that float doesnt found it will return a default value</returns>
        public float ReadFloat(string section, string variable, float defaultValue)
        {
            try
            {
                return float.Parse(ReadString(section, variable, defaultValue.ToString()));
            }
            catch (FormatException)
            {
                return defaultValue;
            }
        }
        #endregion

        #region write
        /// <summary>
        /// Write a string to INIFile, its not save a file default after operation
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="value">Value</param>
        public void WriteString(string section, string variable, string value)
        {
            Section sect = FindSection(section);

            if (sect != null)
            {
                Variable var = sect.Find(variable);

                if (var != null)
                {
                    var.Value = value;
                }

                else sect.Add(new Variable(variable, value));
            }
            else
            {
                sect = new Section(section);
                sect.Add(new Variable(variable, value));

                Sections.Add(sect);
            }
        }

        /// <summary>
        /// Write a integer value to iniFile, its not save a file default after operation
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="value">Value</param>
        public void WriteInt(string section, string variable, int value)
        {
            WriteString(section, variable, value.ToString());
        }

        /// <summary>
        /// Write a char value to iniFile, its not save a file default after operation
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="value">Value</param>
        public void WriteChar(string section, string variable, char value)
        {
            WriteString(section, variable, value.ToString());
        }

        /// <summary>
        /// Write a float value to iniFile, its not save a file default after operation
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="value">Value</param>
        public void WriteFloat(string section, string variable, float value)
        {
            WriteString(section, variable, value.ToString());
        }

        /// <summary>
        /// Write a double value to iniFile, its not save a file default after operation
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="variable">Variable Name</param>
        /// <param name="value">Value</param>
        public void WriteDouble(string section, string variable, double value)
        {
            WriteString(section, variable, value.ToString());
        }
        #endregion

        /// <summary>
        /// Save a INIFile where do you opened it.
        /// </summary>
        public void Save()
        {
            SaveTo(FileName);
        }

        /// <summary>
        /// Save INIFile to location posted in parametr.
        /// 
        /// </summary>
        /// <param name="fileName">Path to the file where you want to save a INIFile</param>
        public void SaveTo(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            foreach (Section section in Sections)
            {
                writer.WriteLine('[' + section.Name + ']');

                foreach (Variable var in section.Variables)
                {
                    writer.WriteLine(var.Name + " = " + var.Value);
                }

                writer.WriteLine();
            }

            writer.Close();
        }

        /// <summary>
        /// Clear a sections list
        /// </summary>
        public void Close()
        {
            Sections.Clear();
        }
    }
}
