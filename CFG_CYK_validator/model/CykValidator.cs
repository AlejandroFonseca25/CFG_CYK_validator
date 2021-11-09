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

        public CykValidator()
        {
            grammar = null;
            chain = null;
            length = 0;
        }

        public void init(List<Tuple<string, List<string>>> variables)
        {
            foreach (Tuple<string, List<string>> v in variables)
            {
                
            }
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
