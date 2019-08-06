using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotLib.Math
{
    class Rand
    {
        static Random rng = new Random();

        static Rand()
        {
            rng = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>Sets new seed for the global rabdom function.</summary>
        /// <param name="seed">The new seed.</param>
        public static void SetSeed(int seed)
        {
            rng = new Random(seed);
        }

        #region Simple, single value random generation
        /// <summary>Returns non-negative random integer.</summary>
        public static int Int()
        {
            return rng.Next();
        }

        /// <summary>Returns a random integer between 0 and 'exclusiveMax'.</summary>
        /// <param name="exclusiveMax">The exclusive upper border of the range.</param>
        public static int Int(int exclusiveMax)
        {
            return rng.Next(exclusiveMax);
        }

        /// <summary>Returns a random integer between 'inclusiveMin' and 'exclusiveMax'.</summary>
        /// <param name="inclusiveMin">The inclusive lower border of the range.</param>
        /// <param name="exclusiveMax">The exclusive upper border of the range.</param>
        public static int Int(int inclusiveMin, int exclusiveMax)
        {
            return rng.Next(inclusiveMin, exclusiveMax);
        }

        /// <summary>Returns random double, that is greater than 0 and less than 1.</summary>
        public static double Double()
        {
            return rng.NextDouble();
        }

        /// <summary>Returns a random double between 0 and 'exclusiveMax'.</summary>
        /// <param name="exclusiveMax">The exclusive upper border of the range.</param>
        public static double Double(double exclusiveMax)
        {
            return rng.NextDouble() * exclusiveMax;
        }

        /// <summary>Returns a random double between 'inclusiveMin' and 'exclusiveMax'.</summary>
        /// <param name="inclusiveMin">The inclusive lower border of the range.</param>
        /// <param name="exclusiveMax">The exclusive upper border of the range.</param>
        public static double Double(double inclusiveMin, double exclusiveMax)
        {
            return rng.Next() * (exclusiveMax - inclusiveMin) + inclusiveMin;
        }
        #endregion
    }
}
