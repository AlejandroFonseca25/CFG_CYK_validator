namespace CFG_CYK_validator.model
{
    ///<summary>Class representing a binary production (A -> BC, where A,B and C are variables in the CFG).</summary>
    internal class BinaryProduction : Production
    {
        public char FirstVariable { get; }
        public char SecondVariable { get; }

        public BinaryProduction(char f, char s)
        {
            FirstVariable = f;
            SecondVariable = s;
        }

        ///<summary>
		///Checks if the provided binary production is contained within the class.
		///</summary>
		///<param name="variables">
		///A length two string that represents a binary production.
        ///<returns>
        ///Bool value. True if the provided binary production is contained within the class, false if otherwise.
        ///</returns>
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