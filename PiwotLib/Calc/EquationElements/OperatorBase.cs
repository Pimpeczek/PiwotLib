using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    public abstract class OperatorBase: EquationSymbol
    {
        public enum OperatorAssociativity { Left, Right}

        public OperatorAssociativity Associativity { get; protected set; }
        public int Precedence { get; protected set; }
        

        public OperatorBase(string symbol, int precedence, OperatorAssociativity associativity) :base(symbol)
        {
            Precedence = precedence;
            Associativity = associativity;
        }
        


    }
}
