using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
 
    
    class BinaryProduction : Production
    {
        public char FirstVariable { get; }
        public char SecondVariable { get; }

        public BinaryProduction(char f, char s)
        {
            FirstVariable = f;
            SecondVariable = s;
        }

        public bool Contains(string variables)
        {
            if (variables.Equals(FirstVariable.ToString() + SecondVariable.ToString()))
            {
                return true;
            }
            else return false;
        }
    }
}
