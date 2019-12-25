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
            while (true)
            {
                System.Console.Write("Wpisz no działanie: ");
                Calc.Equation eq = new Calc.Equation(System.Console.ReadLine());
                System.Console.WriteLine( eq.Calculate());
                //System.Console.WriteLine("Rect: " + eq.Integrate("var", 0, 1, 0.0001));
                //System.Console.WriteLine("Trap: " + eq.Integrate("var", 0, 1, 0.0001, Calc.Equation.IntegrationMode.Trapezoid));
            }
            System.Console.ReadKey(true);
        }
        
    }
}
