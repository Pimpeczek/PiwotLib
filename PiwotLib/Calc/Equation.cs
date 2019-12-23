using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiwotToolsLib.Calc.EquationElements;

namespace PiwotToolsLib.Calc
{
    /// <summary>
    /// Represents an equation in Piwot library.
    /// </summary>
    public class Equation
    {
        /// <summary>
        /// List of all detected variables.
        /// </summary>
        public List<EquationVariable> variables;
        EquationElement[] equation;
        double[] functionArguments;

        /// <summary>
        /// Creates a new instance of Piwot Equation.
        /// 
        /// </summary>
        /// <param name="equationString">The equation represented on string.
        ///     <para>Minuses '-' are interpreted as operators '2 - 1' unless there is no space between the sign and a digit '2 + -1'.</para>
        /// </param>
        public Equation(string equationString)
        {
            variables = new List<EquationVariable>();
            CreateFromString(equationString);
        }

        /// <summary>
        /// Returns a refference to a variable with a given name.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <returns></returns>
        public EquationVariable GetVariable(string name)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].Name == name)
                    return variables[i];
            }
            return null;
        }

        /// <summary>
        /// Adds a new variable to variable list. Returns false if variable with the same name exists.
        /// </summary>
        /// <param name="variable">The new variable.</param>
        /// <returns></returns>
        public bool AddVariable(EquationVariable variable)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].Name == variable.Name)
                    return false;
            }
            variables.Add(variable);
            return true;
        }
        /// <summary>
        /// Removes variable with a given name. Returns false if such variable does not exist.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <returns></returns>
        public bool RemoveVariable(string name)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].Name == name)
                {
                    variables.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        void CreateFromString(string equationString)
        {
            
            string[] splittedInput = GetEquationAsTokens(equationString);
            EquationElement tempElement;
            Stack<EquationSymbol> symbolStack = new Stack<EquationSymbol>();
            Queue<EquationElement> outputQueue = new Queue<EquationElement>();
            for (int i = 0; i < splittedInput.Length; i++)
            {
                if (splittedInput[i].Length != 0)
                {

                    if ((tempElement = InterpretToken(splittedInput[i])) == null)
                    {
                        throw new Exceptions.InvalidTokenSymbolException(splittedInput[i]);
                    }
                    else
                    {
                        if (tempElement is EquationOperand)
                        {
                            if (tempElement is EquationVariable)
                                AddVariable((EquationVariable)tempElement);
                            outputQueue.Enqueue(tempElement);
                        }
                        else
                        {
                            if (tempElement is LeftBracketSymbol)
                            {
                                symbolStack.Push((EquationSymbol)tempElement);
                            }
                            else if (tempElement is RightBracketSymbol)
                            {
                                while (symbolStack.Count > 0 && !(symbolStack.Peek() is LeftBracketSymbol))
                                {
                                    outputQueue.Enqueue(symbolStack.Pop());
                                }
                                symbolStack.Pop();
                            }
                            else if (tempElement is EquationFunction)
                            {
                                symbolStack.Push((EquationSymbol)tempElement);
                            }
                            else
                            {
                                while (symbolStack.Count > 0
                                    && ShouldPopOperatorToQueue(tempElement,
                                                                symbolStack.Peek()))
                                {
                                    outputQueue.Enqueue(symbolStack.Pop());
                                }
                                symbolStack.Push((OperatorBase)tempElement);
                            }

                        }
                    }
                }
            }

            while (symbolStack.Count > 0)
            {
                outputQueue.Enqueue(symbolStack.Pop());
            }
            equation = new EquationElement[outputQueue.Count];
            int maxArgs = 0;
            for (int i = 0; i < equation.Length; i++)
            {
                equation[i] = outputQueue.Dequeue();
                if(equation[i] is EquationFunction)
                {
                    if (maxArgs < ((EquationFunction)equation[i]).ArgumentCount)
                        maxArgs = ((EquationFunction)equation[i]).ArgumentCount;
                }
            }
            functionArguments = new double[maxArgs];
        }

        /// <summary>
        /// Calculates and returns value of this equation.
        /// </summary>
        /// <returns></returns>
        public double Calculate()
        {
            Stack<EquationOperand> operandHeap = new Stack<EquationOperand>();
            EquationFunction equationFunction;
            for (int i = 0; i < equation.Length; i++)
            {
                if(equation[i] is EquationOperand)
                {
                    operandHeap.Push((EquationOperand)equation[i]);
                }
                else
                {
                    if(equation[i] is EquationOperator)
                    {
                        operandHeap.Push(new EquationOperand(
                            ((EquationOperator)equation[i]).Calculate(operandHeap.Pop().Value, 
                                                                      operandHeap.Pop().Value)));
                    }
                    else
                    {
                        equationFunction = (EquationFunction)equation[i];
                        for (int a = 0; a < equationFunction.ArgumentCount; a++)
                            functionArguments[a] = operandHeap.Pop().Value;
                        operandHeap.Push(new EquationOperand(equationFunction.Calculate(functionArguments)));
                    }
                }
            }
            
            return operandHeap.Pop().Value;
        }

        /// <summary>
        /// Calculates aproximation of a integral over a given variable on a given interval.
        /// </summary>
        /// <param name="variableName">Variable to integrate over.</param>
        /// <param name="lowerBound">Lower inclusive boundry.</param>
        /// <param name="upperBound">Upper exclusive boundry.</param>
        /// <param name="step">The step of the integration.</param>
        /// <returns></returns>
        public double Integrate(string variableName, double lowerBound, double upperBound, double step)
        {
            if (lowerBound > upperBound)
                upperBound = lowerBound;
            double result = 0;
            EquationVariable variable = GetVariable(variableName);
            variable.Value = lowerBound;
            while (variable.Value < upperBound)
            {
                result += Calculate() * step;
                variable.Value += step;
            }
            return result;

        }

        static bool ShouldPopOperatorToQueue(EquationElement to, EquationElement so)
        {
            if (so is LeftBracketSymbol)
                return false;
            if (so is OperatorBase)
            {
                if (so is EquationFunction)
                    return true;
                if (((OperatorBase)so).Precedence > ((OperatorBase)to).Precedence)
                    return true;
                if (((OperatorBase)so).Precedence == ((OperatorBase)to).Precedence 
                 && ((OperatorBase)so).Associativity == OperatorBase.OperatorAssociativity.Left)
                    return true;
            }
            return false;
        }

        static string[] GetEquationAsTokens(string equation)
        {


            equation = System.Text.RegularExpressions.Regex.Replace(equation, @"-(\d+)", "THENUMBERMINUS$1");
            for (int i = 0; i < CalculatorBase.Operators.Count; i++)
            {
                equation = equation.Replace(CalculatorBase.Operators[i].Symbol, CalculatorBase.Operators[i].SpacedSymbol);
            }
            equation = equation.Replace("THENUMBERMINUS", "-");
            equation = equation.Replace(',', EquationSymbol.spacingChar);
            equation = equation.Replace(" ", "");
            return equation.Split(EquationSymbol.spacingChar);
        }

        static EquationElement InterpretToken(string token)
        {
            if (token == "(")
                return new LeftBracketSymbol();
            if (token == ")")
                return new RightBracketSymbol();
            OperatorBase o;
            if (token.StartsWith("var"))
            {
                return new EquationVariable(token);
            }

            if ((o = CalculatorBase.GetOperatorBySymbol(token)) != null)
                return o;
            if (double.TryParse(token, out double val))
                return new EquationOperand(val);
            return null;
        }
    }
}
