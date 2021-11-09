using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    class Grammar
    {
        public List<Variable> Variables { get; }

        public Grammar(List<Variable>  variables)
        {
            this.Variables = variables;
        }

        public List<Variable> GeneratorsOfChar(char ch)
        {
            List<Variable> generators = new List<Variable>();

            foreach (Variable v in Variables)
            {
                foreach (TerminalProduction p in v.Productions)
                {
                    if (p.Contains(ch))
                    {
                        generators.Add(v);
                        break;
                    }
                }
            }
            return generators;
        }
    }
}
