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
            foreach (TerminalProduction prod in Productions)
            {
                if (prod.Terminal == '#')
                {
                    return true;
                }
            }

            return false;
        }
    }
}
