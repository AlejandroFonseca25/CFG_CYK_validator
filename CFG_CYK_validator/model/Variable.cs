using System.Collections.Generic;

namespace CFG_CYK_validator.model
{
    internal class Variable
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
                if (p is TerminalProduction terminal)
                {
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