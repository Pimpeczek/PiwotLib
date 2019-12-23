using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib
{
    class RuntimeTestingClass
    {
        static void Main(string[] args)
        {
            
            Calc.Equation eq = new Calc.Equation("min(-2, -1)");
            System.Console.WriteLine(eq.Calculate());
            //System.Console.WriteLine(eq.Integrate("var", 0, 2, 0.0001));

            //for (int i = 0; i < Calc.RPNCalculator.operators.Count; i++)
            //System.Console.WriteLine(Calc.RPNCalculator.operators[i].Symbol);
            System.Console.ReadKey(true);
        }
        
    }
}
