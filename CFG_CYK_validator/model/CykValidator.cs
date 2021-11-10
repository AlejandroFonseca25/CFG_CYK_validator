﻿using System;
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
            
            bool generated = InitialStepCyk(chain);

            if (generated && chain.Length > 1)
            {
                generated = RepetitiveStepCyk(chain);
            }

            return generated;
        }

        private bool InitialStepCyk(string chain)
        {
            for (int i = 0; i < chain.Length; i++)
            {
                cykGrid[i, 0] = grammar.GeneratorsOfChar(chain[i]);
                if (cykGrid[i,0].Count == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool RepetitiveStepCyk(string chain)
        {
            List<Variable> generators = new List<Variable>();

            for (int j = 1; j < chain.Length; j++)
            {
                List<Tuple<List<Variable>, List<Variable>>> couples =
                            new List<Tuple<List<Variable>, List<Variable>>>();

                for (int i = 0; i < chain.Length - j; i++)
                {
                    for (int k = 0; k <= j - 1; k++)
                    {
                        couples.Add(new Tuple<List<Variable>, List<Variable>>(cykGrid[i,k],cykGrid[i+k,j-k]));
                    }
                    generators = GeneratorsOfChain(couples);
                }
            }

            return false;
        }

        private List<Variable> GeneratorsOfChain(List<Tuple<List<Variable>, List<Variable>>> couples)
        {
            List<Variable> generators = new List<Variable>();
            
            foreach (Tuple<List<Variable>, List<Variable>> couple in couples)
            {
                List<Variable> first = couple.Item1;
                List<Variable> second = couple.Item2;

                if (first.Count != 0 && second.Count != 0)
                {
                    List<string> possibleProds = new List<string>();

                    foreach (Variable vFirst in first)
                    {
                        foreach (Variable vSecond in second)
                        {
                            possibleProds.Add(vFirst.Name + vSecond.Name);
                        }
                    }

                    foreach (string prod in possibleProds)
                    {
                        generators.AddRange(grammar.GeneratorsOfBinary(prod));
                    }
                }
            }
            return generators;
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
