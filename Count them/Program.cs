using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_them
{
    class Count_them
    {
        static string ReadInput()
        {
            StringBuilder inputData = new StringBuilder();
            while (true)
            {
                string line = Console.ReadLine();
                inputData.AppendLine(line);
                if (line == "{!}") break;
            }
            return inputData.ToString();
        }

        static bool isValidVariableChar(char c)
        {
            if (c >= 'a' && c <= 'z') return true;
            if (c >= 'A' && c <= 'Z') return true;
            if (c >= '0' && c <= '9') return true;
            if (c == '_') return true;
            return false;
        }

        static List<string> FindVariables(string Code)
        {
            List<string> variables = new List<string>();

            bool isInOneLineComment = false;
            bool isInMultiLineComment = false;
            bool isInSingleQuoteString = false;
            bool isInDoubleQuoteString = false;
            bool isInVariableName = false;
            StringBuilder variableName = new StringBuilder();

            char ch;
            for (int i = 0; i < Code.Length; i++)
            {
                ch = Code[i];
                if (isInMultiLineComment)
                {

                    if (ch == '*' && Code[i + 1] == '/')
                    {
                        isInMultiLineComment = false;
                        i++;
                        continue;
                    }
                    else
                    {

                        continue;
                    }
                }
                if (isInOneLineComment)
                {
                    if (ch == '\n')
                    {
                        isInOneLineComment = false;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (isInVariableName)
                {
                    if (isValidVariableChar(ch))
                    {
                        variableName.Append(ch);
                    }
                    else
                    {
                        string newVariable = variableName.ToString();
                        if (newVariable.Length > 0 && !variables.Contains(newVariable))
                        {
                            variables.Add(newVariable);
                        }
                        isInVariableName = false;
                        variableName.Clear();
                    }
                }
                if (isInSingleQuoteString)
                {
                    if (ch == '\'')
                    {

                        isInSingleQuoteString = false;
                        continue;
                    }
                }
                if (isInDoubleQuoteString)
                {
                    if (ch == '\"')
                    {
                        isInDoubleQuoteString = false;
                        continue;
                    }
                }
                if (!isInDoubleQuoteString && !isInSingleQuoteString)
                {
                    if (ch == '#')
                    {
                        isInOneLineComment = true;
                        continue;
                    }
                    if (ch == '/' && Code[i + 1] == '/')
                    {
                        i++;
                        isInOneLineComment = true;
                        continue;
                    }
                    if (ch == '/' && Code[i + 1] == '*')
                    {
                        i++;
                        isInMultiLineComment = true;
                        continue;
                    }
                }
                else
                {
                    if (ch == '\\')
                    {
                        i++;
                        continue;
                    }
                }
                if (ch == '\"')
                {
                    isInDoubleQuoteString = true;
                    continue;
                }
                if (ch == '\'')
                {
                    isInSingleQuoteString = true;
                    continue;
                }
                if (ch == '@')
                {
                    isInVariableName = true;
                    continue;
                }
            }

            return variables;
        }

        static void WriteVariables(List<string> variables)
        {
            Console.WriteLine(variables.Count);
            variables.Sort(StringComparer.Ordinal);
            foreach (string variable in variables)
            {
                Console.WriteLine(variable);
            }
        }
        static void Main()
        {
            string Code = ReadInput();
            List<string> variables = FindVariables(Code);
            WriteVariables(variables);
        }
    }
}
