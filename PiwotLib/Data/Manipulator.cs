using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Data
{
    /// <summary>
    /// Class for misc data manipulation.
    /// </summary>
    public static class Manipulator
    {
        /// <summary>
        /// Swaps two variables.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public static void Swap<T>(ref T v1, ref T v2)
        {
            T t = v1;
            v1 = v2;
            v2 = t;
        }
    }
}
