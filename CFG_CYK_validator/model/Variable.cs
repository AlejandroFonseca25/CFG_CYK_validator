using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    class Variable
    {
        public string   Name { get; }
        public List<Production> Productions { get; }
        
        public Variable(List<Production> productions)
        {
            this.Productions = productions;
        }

        private List<char> GetTerminals()
        {
            return null;
        }
    }
}
