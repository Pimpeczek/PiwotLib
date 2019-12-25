using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    public class EquationConstant : EquationSymbol, IEquationValue
    {
        /// <summary>
        /// The value of this constant operand.
        /// </summary>
        public double Value { get; protected set; }

        /// <summary>
        /// Creates a new constant operand with a given value.
        /// </summary>
        /// <param name="value">The value of this constant.</param>
        /// <param name="symbol"></param>
        public EquationConstant(double value, string symbol):base(symbol)
        {
            Value = value;
        }
    }
}
