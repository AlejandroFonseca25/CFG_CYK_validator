using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_CYK_validator.model
{
    class CykValidator
    {
        private Grammar grammar;
        private string chain;
        private int length;
        private List<Variable>[,] cykGrid;

        public CykValidator(Grammar grammar, string chain)
        {
            this.grammar = grammar;
            this.chain = chain;
            length = chain.Length;
        }

        public bool CykAlgorithm()
        {
            cykGrid = new List<Variable>[length, length];
            bool generated = false;
            CykInitialize();
            return false;
        }

        private void CykInitialize()
        {
            
            
        }

        private void CykRepetitive()
        {

            
        }

        public void setChain(string newChain)
        {
            chain = newChain;
            length = chain.Length;
        }
    }
}
