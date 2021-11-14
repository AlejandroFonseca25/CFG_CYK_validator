using System.Collections.Generic;

namespace CFG_CYK_validator.model
{
    ///<summary>Class representing a Context Free Grammar in Chompsky form.</summary>
    internal class Grammar
    {
        public List<Variable> Variables { get; }

        public Grammar(List<Variable> variables)
        {
            this.Variables = variables;
        }

        ///<summary>
		///Obtains the variables that can generate the given char.
		///</summary>
		///<param name="ch">
		///A given char of the original chain.
        ///<returns>
        ///A list of variables capable of generating the given char.
        ///</returns>
        public List<Variable> GeneratorsOfChar(char ch)
        {
            List<Variable> generators = new List<Variable>();

            foreach (Variable v in Variables)
            {
                foreach (Production p in v.Productions)
                {
                    if (p is TerminalProduction terminal)
                    {
                        if (terminal.Contains(ch))
                        {
                            generators.Add(v);
                            break;
                        }
                    }
                }
            }
            return generators;
        }

        ///<summary>
        ///Obtains the variables that contain the given binary production.
        ///</summary>
        ///<param name="prod">
        ///A given string, representing a binary production.
        ///<returns>
        ///A list of variables that contain the given production.
        ///</returns>
        public List<Variable> GeneratorsOfBinary(string prod)
        {
            List<Variable> generators = new List<Variable>();

            foreach (Variable v in Variables)
            {
                foreach (Production p in v.Productions)
                {
                    if (p is BinaryProduction binary)
                    {
                        if (binary.Contains(prod))
                        {
                            generators.Add(v);
                            break;
                        }
                    }
                }
            }
            return generators;
        }
    }
}