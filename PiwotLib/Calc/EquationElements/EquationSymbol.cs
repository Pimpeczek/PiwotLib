using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    public class EquationSymbol : EquationElement
    {
        public static readonly char spacingChar = (char)27;
        public string Symbol { get; protected set; }
        public string SpacedSymbol { get; protected set; }

        public EquationSymbol(string symbol)
        {
            Symbol = symbol;
            SpacedSymbol = $"{spacingChar}{symbol}{spacingChar}";
        }

        public override string ToString()
        {
            return Symbol;
        }


    }
}
