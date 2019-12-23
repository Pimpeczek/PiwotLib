using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.Exceptions
{
    public class WrongNumberOfArgumentsException: ArgumentException
    {
        public WrongNumberOfArgumentsException():base()
        {

        }

        public WrongNumberOfArgumentsException(string message) : base(message)
        {

        }

        public WrongNumberOfArgumentsException(string message, string paramName) : base(message, paramName)
        {

        }
    }
}
