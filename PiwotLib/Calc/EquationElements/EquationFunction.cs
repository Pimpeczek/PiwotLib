using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.EquationElements
{
    /// <summary>
    /// A class representing function in Piwot Equation.
    /// </summary>
    public class EquationFunction : OperatorBase
    {
        /// <summary>
        /// The function assigned to this EquationFunction.
        /// </summary>
        public Func<double[], double> Func { get; protected set; }

        /// <summary>
        /// Number of arguments this function takes.
        /// </summary>
        public int ArgumentCount { get; protected set; }
        /// <summary>
        /// Creates new instance of Equation Function with one argument.
        /// </summary>
        /// <param name="symbol">The symbol associated with this function.</param>
        /// <param name="precedence">The order of operation.</param>
        /// <param name="func">The function assigned to this EquationFunction.</param>
        /// <param name="argumentCount">The number of arguments of function assigned to this EquationFunction.</param>
        public EquationFunction(string symbol, int precedence, int argumentCount, Func<double[], double> func) : base(symbol, precedence, OperatorAssociativity.Right)
        {
            this.Func = func;
            ArgumentCount = argumentCount;
        }
        /// <summary>
        /// Calculates value of the function for a given argument.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public double Calculate(double[] args)
        {
            if (Func == null)
                throw new ArgumentNullException("Func");
            if (args.Length != ArgumentCount)
                throw new Exceptions.WrongNumberOfArgumentsException();
            return Func.Invoke(args);
        }
    }
}
