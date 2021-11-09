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
        private List<Variable>[,] cykGrid;

        public CykValidator()
        {

        }

        public void init(List<Tuple<string, List<string>>> rawVariables)
        {
            List<Variable> finalVariables = new List<Variable>();

            foreach (Tuple<string, List<string>> v in rawVariables)
            {
                foreach(string p in v.Item2)
                {
                    List<Production> prodsToAdd = new List<Production>();

                    if (p.Length == 2)
                    {
                        prodsToAdd.Add(new BinaryProduction(p[0], p[1]));
                    } else 
                    {
                        prodsToAdd.Add(new TerminalProduction(p[0]));
                    }

                    finalVariables.Add(new Variable(v.Item1, prodsToAdd));
                    
                    grammar = new Grammar(finalVariables);
                }
            }
        }

        public bool ValidateChain(string chain)
        {
            if (chain.Length == 0)
            {
                return ValidateEmpty();
            }
            else
            {
                return CykAlgorithm(chain); 
            }
        }

        private bool CykAlgorithm(string chain)
        {
            cykGrid = new List<Variable>[chain.Length, chain.Length];
            bool generated = false;
            CykInitialize(chain);
            return false;
        }
        private void CykInitialize(string chain)
        {
            for (int i = 0; i < chain.Length; i++)
            {
                cykGrid[i, 0] = grammar.GeneratorsOfChar(chain[i]);
            }
        }

        private void CykRepetitive()
        {

        }

        private bool ValidateEmpty()
        {
            if (grammar.Variables[0].HasEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        
    }
}
