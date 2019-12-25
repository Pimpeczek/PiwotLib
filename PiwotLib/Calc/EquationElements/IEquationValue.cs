using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    interface IEquationValue
    {
        /// <summary>
        /// The value of this constant operand.
        /// </summary>
        double Value { get;}
    }
}
