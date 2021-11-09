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

        public Grammar(List<Variable>  variables)
        {
            this.variables = variables;
        }
    }
}
