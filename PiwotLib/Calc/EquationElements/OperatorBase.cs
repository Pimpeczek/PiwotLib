using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    /// <summary>
    /// Represents a base for functions and operators except brackets.
    /// </summary>
    public abstract class OperatorBase: EquationSymbol
    {
        /// <summary>
        /// The possible associativities.
        /// </summary>
        public enum OperatorAssociativity
        {
            /// <summary>
            /// The operator or function is left associative.
            /// </summary>
            Left,
            /// <summary>
            /// The operator or function is right associative.
            /// </summary>
            Right
        }
        

        /// <summary>
        /// The associativity of this operator or function.
        /// </summary>
        public OperatorAssociativity Associativity { get; protected set; }

        /// <summary>
        /// The precedence of this function or operator.
        /// </summary>
        public int Precedence { get; protected set; }

        /// <summary>
        /// Creates new instace of OperatorBase with given parameters.
        /// </summary>
        /// <param name="symbol">Symbol of this function or operator.</param>
        /// <param name="precedence">Precedence of this function or operator.</param>
        /// <param name="associativity">Associativity of this function or operator.</param>
        public OperatorBase(string symbol, int precedence, OperatorAssociativity associativity) :base(symbol)
        {
            Precedence = precedence;
            Associativity = associativity;
        }
        


    }
}
