using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    class Variable
    {
        public List<Production> productions { get; }
        
        public Variable(List<Production> productions)
        {
            this.productions = productions;
        }

        private List<char> GetTerminals()
        {
            foreach(Production p in productions)
            {
                if (p is TerminalProduction)
                {

                }
            }
        }
    }
}
