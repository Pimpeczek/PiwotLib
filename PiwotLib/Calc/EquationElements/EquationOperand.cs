using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    /// <summary>
    /// Represents operand in Piwot Equation.
    /// </summary>
    public class EquationOperand: EquationElement
    {
        /// <summary>
        /// The value of this operand.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Creates a new operand with a given value.
        /// </summary>
        /// <param name="value"></param>
        public EquationOperand(double value)
        {
            Value = value;
        }
        /// <summary>
        /// Returns the string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
