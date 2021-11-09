using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    class TerminalProduction : Production
    {
        public char Terminal { get; }
        public TerminalProduction(char t)
        {
            Terminal = t;
        }    
        
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
