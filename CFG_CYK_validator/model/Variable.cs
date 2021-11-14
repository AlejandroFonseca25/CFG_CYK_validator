using System.Collections.Generic;

namespace CFG_CYK_validator.model
{
    ///<summary>Class representing a variable in a CFG in Chompsky form.</summary>
    internal class Variable
    {
        public string Name { get; }
        public List<Production> Productions { get; }

        public Variable(string name, List<Production> productions)
        {
            this.Productions = productions;
            this.Name = name;
        }

        ///<summary>
		///Validates if the variable contains the empty production.
		///</summary>
        ///<returns>
        ///Bool value. True if the variable contains the empty production, false if otherwise.
        ///</returns>
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