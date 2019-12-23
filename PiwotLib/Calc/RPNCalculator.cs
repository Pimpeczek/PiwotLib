using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiwotToolsLib.Calc.EquationElements;

namespace PiwotToolsLib.Calc
{
    public static class RPNCalculator
    {
        public static List<EquationSymbol> Operators { get; private set; }
        static RPNCalculator()
        {
            Operators = new List<EquationSymbol>();
            Operators.Add(new EquationSymbol("("));
            Operators.Add(new EquationSymbol(")"));
            Operators.Add(new EquationOperator("+", 0, OperatorBase.OperatorAssociativity.Left, (b, a) => a + b));
            Operators.Add(new EquationOperator("-", 0, OperatorBase.OperatorAssociativity.Left, (b, a) => a - b));
            Operators.Add(new EquationOperator("*", 1, OperatorBase.OperatorAssociativity.Left, (b, a) => a * b));
            Operators.Add(new EquationOperator("/", 1, OperatorBase.OperatorAssociativity.Left, (b, a) => a / b));
            Operators.Add(new EquationOperator("^", 2, OperatorBase.OperatorAssociativity.Right, (b, a) => Math.Pow(a, b)));
            Operators.Add(new EquationOperator("%", 2, OperatorBase.OperatorAssociativity.Right, (b, a) => a % b));

            Operators.Add(new EquationFunction("sin", 3, 1, (args) => Math.Sin(args[0])));
            Operators.Add(new EquationFunction("cos", 3, 1, (args) => Math.Cos(args[0])));
            Operators.Add(new EquationFunction("tan", 3, 1, (args) => Math.Tan(args[0])));
            Operators.Add(new EquationFunction("abs", 3, 1, (args) => Math.Abs(args[0])));
            Operators.Add(new EquationFunction("celi", 3, 1, (args) => Math.Ceiling(args[0])));
            Operators.Add(new EquationFunction("floor", 3, 1, (args) => Math.Floor(args[0])));
            Operators.Add(new EquationFunction("round", 3, 1, (args) => Math.Round(args[0])));
            Operators.Add(new EquationFunction("exp", 3, 1, (args) => Math.Exp(args[0])));
            Operators.Add(new EquationFunction("ln", 3, 1, (args) => Math.Log(args[0])));
            Operators.Add(new EquationFunction("log", 3, 2, (args) => Math.Log(args[1]) / Math.Log(args[0])));
            Operators.Add(new EquationFunction("sqrt", 3, 1, (args) => Math.Sqrt(args[0])));
            Operators.Add(new EquationFunction("max", 3, 2, (args) => Math.Max(args[0], args[1])));
            Operators.Add(new EquationFunction("min", 3, 2, (args) => Math.Min(args[0], args[1])));
            Operators.Add(new EquationFunction("clamp", 3, 3, (args) => PMath.Arit.Clamp(args[0], args[1], args[2])));
            SortOperators();
        }

        public static double Calculate(string equationString)
        {
            Equation equation = new Equation(equationString);
            return equation.Calculate();
        }

        public static OperatorBase GetOperatorBySymbol(string symbol)
        {
            for(int i = 0; i < Operators.Count; i++)
            {
                if (Operators[i].Symbol == symbol)
                    return (OperatorBase) Operators[i];
            }
            return null;
        }

        public static bool AddOperator(OperatorBase newOperator)
        {
            for(int i = 0; i < Operators.Count; i++)
            {
                if (newOperator.Symbol == Operators[i].Symbol)
                    return false;
            }

            Operators.Add(newOperator);
            SortOperators();
            return true;
        }

        public static bool RemoveOperator(string symbol)
        {
            for (int i = 0; i < Operators.Count; i++)
            {
                if (symbol == Operators[i].Symbol)
                {
                    Operators.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static bool ReplaceOperator(string oldOperatorSymbol, OperatorBase newOperator)
        {
            for (int i = 0; i < Operators.Count; i++)
            {
                if (oldOperatorSymbol == Operators[i].Symbol)
                {
                    Operators[i] = newOperator;
                    SortOperators();
                    return true;
                }
            }
            return false;
        }


        public static EquationElement InterpretToken(string token)
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
            
            if ((o = GetOperatorBySymbol(token)) != null)
                return o;
            if (double.TryParse(token, out double val))
                return new EquationOperand(val);
            return null;
        }

        static void SortOperators()
        {
            Operators.Sort((x, y) => y.Symbol.Length.CompareTo(x.Symbol.Length));
        }
    }
}



/*




def calculateFromString(equation: str):
    equation = equation.replace('+', ' + ')
    equation = equation.replace('-', ' - ')
    equation = equation.replace('*', ' * ')
    equation = equation.replace('/', ' / ')
    equation = equation.replace('^', ' ^ ')
    equation = equation.replace('(', ' ( ')
    equation = equation.replace(')', ' ) ')
    tokens = equation.split(' ')
    operatorStack = []
    outputQueue = []
    wynik = 0
    for token in tokens:
        if token == '':
            continue
        if isOperator(token):
            if token == '(':
                operatorStack.append(token)
            elif token == ')':
                while  len(operatorStack) > 0 and operatorStack[-1] != '(':
                    outputQueue.append(operatorStack.pop())
                operatorStack.pop()
            else:
                while len(operatorStack) > 0 and sholdPopOpToQueue(token, operatorStack[-1]):
                    outputQueue.append(operatorStack.pop())
                operatorStack.append(token)
        else:
            try:
                val = float(token)
                outputQueue.append(val)
            except ValueError:
                return None
    
    while len(operatorStack) > 0:
        outputQueue.append(operatorStack.pop())

    operandStack = []
    while len(outputQueue) > 0:

        token = outputQueue.pop(0)
        if isOperator(token):
            a = operandStack.pop()
            b = operandStack.pop()
            if token == '-':
                operandStack.append(b - a)
            elif token == '+':
                operandStack.append(a + b)
            elif token == '/':
                operandStack.append(b / a)
            elif token == '*':
                operandStack.append(a * b)
            elif token == '^':
                operandStack.append(pow(b, a))
        else:
            operandStack.append(token)
    
    
    wynik = operandStack.pop(0)

    return wynik

def isOperator(token):

    try:
        float(token)
        return False
    except ValueError:
        pass
    if token in '+*-/()^':
        return True
    return False
    
def sholdPopOpToQueue(to, so):
    tos = 0
    sos = 0
    if to in '* /':
        tos = 1
    elif to in '^':
        tos = 2
    if so in '* /':
        sos = 1
    elif so in '^':
        sos = 2
    if sos > tos:
        return True
    if sos >= tos and so in '-+/*':
        return True
    return False

    */ 
