using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    /// <summary>
    /// Represents a base for every Equation Operator and Function.
    /// </summary>
    public abstract class EquationSymbol : EquationElement
    {
        /// <summary>
        /// The character used to mark beggining of the EquationSymbol in the string representation.
        /// <para>Ths value is equal to 27, which is a representation for Esc key.</para>
        /// </summary>
        public static readonly char begSpacingChar = (char)27;

        /// <summary>
        /// The character used to mark end of the EquationSymbol in the string representation.
        /// <para>Ths value is equal to 27, which is a representation for Esc key.</para>
        /// </summary>
        public static readonly char endSpacingChar = (char)8;
        /// <summary>
        /// The string representation of this EquationSymbol.
        /// </summary>
        public string Symbol { get; protected set; }

        /// <summary>
        /// The string representation of this EquationSymbol with spacingChar on beggining and end.
        /// </summary>
        public string SpacedSymbol { get; protected set; }

        /// <summary>
        /// Creates new Equation symbol.
        /// </summary>
        /// <param name="symbol"></param>
        public EquationSymbol(string symbol)
        {
            Symbol =  System.Text.RegularExpressions.Regex.Replace(symbol, @"[0-9]+", "");
            SpacedSymbol = $"{begSpacingChar}{Symbol}{endSpacingChar}";
        }

        /// <summary>
        /// Returns the string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Symbol;
        }


    }
}
