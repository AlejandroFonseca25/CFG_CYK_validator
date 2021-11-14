using System;
using System.Collections.Generic;

namespace CFG_CYK_validator.model
{
    internal class CykValidator
    {
        private Grammar grammar;
        private Variable startVariable;
        private List<Variable>[,] cykGrid;

        public CykValidator()
        {
        }

        public void Init(List<Tuple<string, List<string>>> rawVariables)
        {
            List<Variable> finalVariables = new List<Variable>();

            foreach (Tuple<string, List<string>> v in rawVariables)
            {
                List<Production> prodsToAdd = new List<Production>();

                foreach (string p in v.Item2)
                {
                    if (p.Length == 2)
                    {
                        prodsToAdd.Add(new BinaryProduction(p[0], p[1]));
                    }
                    else
                    {
                        prodsToAdd.Add(new TerminalProduction(p[0]));
                    }
                }

                finalVariables.Add(new Variable(v.Item1, prodsToAdd));
            }

            grammar = new Grammar(finalVariables);

            startVariable = grammar.Variables[0];
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

            if (generated)
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
                if (cykGrid[i, 0].Count == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool RepetitiveStepCyk(string chain)
        {
            for (int j = 2; j <= chain.Length; j++)
            {
                for (int i = 1; i <= chain.Length - j + 1; i++)
                {
                    List<Tuple<List<Variable>, List<Variable>>> couples =
                           new List<Tuple<List<Variable>, List<Variable>>>();

                    for (int k = 1; k <= j - 1; k++)
                    {
                        couples.Add(new Tuple<List<Variable>, List<Variable>>(cykGrid[i - 1, k - 1], 
                            cykGrid[i + k - 1, j - k - 1]));
                    }
                    cykGrid[i - 1, j - 1] = GeneratorsOfChain(couples);
                }
            }

            if (cykGrid[0, chain.Length - 1].Contains(startVariable))
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (startVariable.HasEmpty())
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