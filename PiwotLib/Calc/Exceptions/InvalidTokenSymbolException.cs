using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Calc.Exceptions
{
    class InvalidTokenSymbolException : ArgumentException
    {
        public InvalidTokenSymbolException() : base()
        {

        }

        public InvalidTokenSymbolException(string message) : base(message)
        {

        }

        public InvalidTokenSymbolException(string message, string paramName) : base(message, paramName)
        {

        }
    }
}
