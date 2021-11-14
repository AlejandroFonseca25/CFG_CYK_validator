using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    class Variable
    {
        public string Name { get; }
        public List<Production> Productions { get; }

        public Variable(string name, List<Production> productions)
        {
            this.Productions = productions;
            this.Name = name;
        }

        public bool HasEmpty()
        {
            foreach (Production p in Productions)
            {
                if (p is TerminalProduction)
                {
                    TerminalProduction terminal = (TerminalProduction)p;
                    if (terminal.Terminal == '#')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
