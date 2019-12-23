using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    public class EquationOperator : OperatorBase
    {
        public Func<double, double, double> func;
        public EquationOperator(string symbol, int precedence, OperatorAssociativity associativity, Func<double, double, double> func) :base(symbol, precedence, associativity)
        {
            this.func = func;
        }
        public double Calculate(double arg1, double arg2)
        {
            if (func == null)
                throw new ArgumentNullException("Func");
            return func.Invoke(arg1, arg2);
        }
    }
}
