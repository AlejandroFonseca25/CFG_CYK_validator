using System.Collections.Generic;

namespace CFG_CYK_validator.model
{
    internal class Grammar
    {
        public List<Variable> Variables { get; }

        public Grammar(List<Variable> variables)
        {
            this.Variables = variables;
        }

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