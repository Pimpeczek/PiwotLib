using System;
using System.Collections.Generic;
using PiwotToolsLib.Calc.EquationElements;

//########################################
//
//     WE NEED TO DO THE EXCEPTIONS!
//
//########################################

namespace PiwotToolsLib.Calc
{
    /// <summary>
    /// The base for calculations. Contains all operators and functions and allows adding more.
    /// </summary>
    public static class CalculatorBase
    {
        /// <summary>
        /// The list of symbols.
        /// </summary>
        public static List<EquationSymbol> Symbols { get; private set; }

        /// <summary>
        ///  
        /// </summary>
        public static string NumberDecimalSeparator { get; private set; }

        /// <summary>
        /// Creates the list of symbols.
        /// </summary>
        static CalculatorBase()
        {
            NumberDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            Symbols = new List<EquationSymbol>
            {
                new LeftBracketSymbol(),
                new RightBracketSymbol(),
                new EquationOperator("+", 0, OperatorBase.OperatorAssociativity.Left, (b, a) => a + b),
                new EquationOperator("-", 0, OperatorBase.OperatorAssociativity.Left, (b, a) => a - b),
                new EquationOperator("*", 1, OperatorBase.OperatorAssociativity.Left, (b, a) => a * b),
                new EquationOperator("/", 1, OperatorBase.OperatorAssociativity.Left, (b, a) => a / b),
                new EquationOperator("^", 2, OperatorBase.OperatorAssociativity.Right, (b, a) => Math.Pow(a, b)),
                new EquationOperator("%", 2, OperatorBase.OperatorAssociativity.Right, (b, a) => a % b),

                new EquationFunction("sin", 3, 1, (args) => Math.Sin(args[0])),
                new EquationFunction("cos", 3, 1, (args) => Math.Cos(args[0])),
                new EquationFunction("tan", 3, 1, (args) => Math.Tan(args[0])),
                new EquationFunction("abs", 3, 1, (args) => Math.Abs(args[0])),
                new EquationFunction("celi", 3, 1, (args) => Math.Ceiling(args[0])),
                new EquationFunction("floor", 3, 1, (args) => Math.Floor(args[0])),
                new EquationFunction("round", 3, 1, (args) => Math.Round(args[0])),
                new EquationFunction("exp", 3, 1, (args) => Math.Exp(args[0])),
                new EquationFunction("ln", 3, 1, (args) => Math.Log(args[0])),
                new EquationFunction("log", 3, 2, (args) => Math.Log(args[1]) / Math.Log(args[0])),
                new EquationFunction("sqrt", 3, 1, (args) => Math.Sqrt(args[0])),
                new EquationFunction("max", 3, 2, (args) => Math.Max(args[0], args[1])),
                new EquationFunction("min", 3, 2, (args) => Math.Min(args[0], args[1])),
                new EquationFunction("clamp", 3, 3, (args) => PMath.Arit.Clamp(args[0], args[1], args[2])),

                new EquationConstant(Math.PI, "PI"),
                new EquationConstant(Math.E, "E"),
                new EquationConstant(2137, "PA_+P")
            };

            SortSymbols();
        }

        /// <summary>
        /// Calculates equation represented on the equationString.
        /// </summary>
        /// <param name="equationString">Represents the equation to calculate.</param>
        /// <returns></returns>
        public static double Calculate(string equationString)
        {
            Equation equation = new Equation(equationString);
            return equation.Calculate();
        }

        /// <summary>
        /// Returns operator or function represented by a given string.
        /// </summary>
        /// <param name="symbol">Operator unique symbol.</param>
        /// <returns></returns>
        public static EquationSymbol GetEquationSymbol(string symbol)
        {
            for(int i = 0; i < Symbols.Count; i++)
            {
                
                if (Symbols[i].Symbol == symbol)
                    return (EquationSymbol) Symbols[i];
            }
            return null;
        }

        /// <summary>
        /// Adds new operator or function to the operator list. If action was succesfull returns true.
        /// </summary>
        /// <param name="newOperator">The new operator.</param>
        /// <returns></returns>
        public static bool AddOperator(OperatorBase newOperator)
        {
            for(int i = 0; i < Symbols.Count; i++)
            {
                if (newOperator.Symbol == Symbols[i].Symbol)
                    return false;
            }

            Symbols.Add(newOperator);
            SortSymbols();
            return true;
        }

        /// <summary>
        /// Removes operator or function with a given symbol. If action was succesfull returns true.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static bool RemoveOperator(string symbol)
        {
            for (int i = 0; i < Symbols.Count; i++)
            {
                if (symbol == Symbols[i].Symbol)
                {
                    Symbols.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Replaces existing operator represented by a given string with a given operator. If action was succesfull returns true.
        /// </summary>
        /// <param name="oldOperatorSymbol"></param>
        /// <param name="newOperator"></param>
        /// <returns></returns>
        public static bool ReplaceOperator(string oldOperatorSymbol, OperatorBase newOperator)
        {
            if (newOperator == null)
                return false;
            for (int i = 0; i < Symbols.Count; i++)
            {
                if (oldOperatorSymbol == Symbols[i].Symbol)
                {
                    Symbols[i] = newOperator;
                    SortSymbols();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sorts operators by symbol lenght.
        /// </summary>
        static void SortSymbols()
        {
            Symbols.Sort((x, y) => y.Symbol.Length.CompareTo(x.Symbol.Length));
        }
    }
}