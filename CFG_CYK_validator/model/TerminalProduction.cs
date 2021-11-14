using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    ///<summary>Class representing a terminal production (A -> B, where A is a variable and B is a terminal value in the CFG).</summary>
    class TerminalProduction : Production
    {
        public char Terminal { get; }
        public TerminalProduction(char t)
        {
            Terminal = t;
        }

        ///<summary>
        ///Checks if the provided terminal production is contained within the class.
        ///</summary>
        ///<param name="terminal">
        ///A char that represents a terminal production.
        ///<returns>
        ///Bool value. True if the provided terminal production is contained within the class, false if otherwise.
        ///</returns>
        public bool Contains(char terminal)
        {
            if (Terminal == terminal)
            {
                return true;
            }
            else return false;
        }
    }
}
