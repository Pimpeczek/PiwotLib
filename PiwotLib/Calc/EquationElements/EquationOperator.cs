using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    /// <summary>
    /// Represents a basic two argument operator in Piwot Equation.
    /// </summary>
    public class EquationOperator : OperatorBase
    {
        /// <summary>
        /// The function assigned to this operator.
        /// </summary>
        public Func<double, double, double> func;

        /// <summary>
        /// Creates EquationOperator with a given attributes.
        /// </summary>
        /// <param name="symbol">The symbol of this variable.</param>
        /// <param name="precedence">The precedence(importance) of this variable.</param>
        /// <param name="associativity">Determines if the operator is left or right associative.</param>
        /// <param name="func">The function being assigned to this operator.</param>
        public EquationOperator(string symbol, int precedence, OperatorAssociativity associativity, Func<double, double, double> func) :base(symbol, precedence, associativity)
        {
            this.func = func;
        }

        /// <summary>
        /// Calculates value of this operation on two given arguments.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public double Calculate(double arg1, double arg2)
        {
            if (func == null)
                throw new ArgumentNullException("Func");
            return func.Invoke(arg1, arg2);
        }
    }
}
