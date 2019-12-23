using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    public class EquationVariable : EquationOperand
    {
        /// <summary>
        /// The name of this variable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents variable for Equation.
        /// </summary>
        /// <param name="name">The name of this variable.</param>
        public EquationVariable(string name) : base(0)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}:{Value}";
        }

    }
}
