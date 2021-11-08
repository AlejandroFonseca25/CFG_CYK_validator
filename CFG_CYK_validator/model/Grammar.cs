using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    class Grammar
    {
        private List<Variable> variables { get; }
        private List<char> terminals { get; }

        public Grammar(List<Variable>  variables, List<terminals> )
        {
            this.variables = variables;
            terminals = FindTerminals();
        }

        public bool QuickGenerationCheck(string chain)
        {

            return false;
        }

        private List<char> FindTerminals()
        {
            List<char> tempTerminals = new List<char>();

            foreach (Variable v in variables)
            {
                if ()
            }
        }
    }
}
