using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.PMath
{
    public class Arit
    {
        #region Clamps
        ///<summary>Returns value clamped between 0 and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static int Clamp(int value, int inclusiveMax)
        {
            if (value < 0)
                return 0;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static int Clamp(int value, int inclusiveMin, int inclusiveMax)
        {
            if (value < inclusiveMin)
                return inclusiveMin;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between 0 and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static long Clamp(long value, long inclusiveMax)
        {
            if (value < 0)
                return 0;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static long Clamp(long value, long inclusiveMin, long inclusiveMax)
        {
            if (value < inclusiveMin)
                return inclusiveMin;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between 0 and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static float Clamp(float value, float inclusiveMax)
        {
            if (value < 0)
                return 0;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static float Clamp(float value, float inclusiveMin, float inclusiveMax)
        {
            if (value < inclusiveMin)
                return inclusiveMin;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between 0 and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static double Clamp(double value, double inclusiveMax)
        {
            if (value < 0)
                return 0;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static double Clamp(double value, double inclusiveMin, double inclusiveMax)
        {
            if (value < inclusiveMin)
                return inclusiveMin;
            if (value > inclusiveMax)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static IComparable Clamp(IComparable value, IComparable inclusiveMin, IComparable inclusiveMax)
        {
            if (value.CompareTo(inclusiveMin) < 0)
                return inclusiveMin;
            if (value.CompareTo(inclusiveMax) > 0)
                return inclusiveMax;
            return value;
        }

        ///<summary>Returns value clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="value">The value to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static T Clamp<T>(IComparable value, IComparable inclusiveMin, IComparable inclusiveMax)
        {
            if (value.CompareTo(inclusiveMin) < 0)
                return (T)inclusiveMin;
            if (value.CompareTo(inclusiveMax) > 0)
                return (T)inclusiveMax;
            return (T)value;
        }
        #endregion

        #region Greater - Lesser choosing
        /// <summary>Returns greater value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static int TakeGreater(int x, int y)
        {
            return (x > y ? x : y);
        }
        /// <summary>Returns lesser value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static int TakeLesser(int x, int y)
        {
            return (x < y ? x : y);
        }
        /// <summary>Returns greater value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static long TakeGreater(long x, long y)
        {
            return (x > y ? x : y);
        }
        /// <summary>Returns lesser value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static long TakeLesser(long x, long y)
        {
            return (x < y ? x : y);
        }
        /// <summary>Returns greater value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static decimal TakeGreater(decimal x, decimal y)
        {
            return (x > y ? x : y);
        }
        /// <summary>Returns lesser value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static decimal TakeLesser(decimal x, decimal y)
        {
            return (x < y ? x : y);
        }
        /// <summary>Returns greater value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static float TakeGreater(float x, float y)
        {
            return (x > y ? x : y);
        }
        /// <summary>Returns lesser value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static float TakeLesser(float x, float y)
        {
            return (x < y ? x : y);
        }
        /// <summary>Returns greater value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static double TakeGreater(double x, double y)
        {
            return (x > y ? x : y);
        }
        /// <summary>Returns lesser value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static double TakeLesser(double x, double y)
        {
            return (x < y ? x : y);
        }
        /// <summary>Returns greater value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static IComparable TakeGreater(IComparable x, IComparable y)
        {
            return (x.CompareTo(y) < 0 ? y : x);
        }
        /// <summary>Returns lesser value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static IComparable TakeLesser(IComparable x, IComparable y)
        {
            return (x.CompareTo(y) < 0 ? x : y);
        }
        /// <summary>Returns greater value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static T TakeGreater<T>(IComparable x, IComparable y)
        {
            return (T)(x.CompareTo(y) < 0 ? y : x);
        }
        /// <summary>Returns lesser value from given parameters.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static T TakeLesser<T>(IComparable x, IComparable y)
        {
            return (T)(x.CompareTo(y) < 0 ? x : y);
        }
        #endregion

        #region Between checking
        /// <summary>Checks if a given value is between a given range (inclusive).</summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="inclusiveMin">Lower inclusive border of the range.</param>
        /// <param name="inclusiveMax">Upper inclusive border of the range.</param>
        /// <returns></returns>
        public static bool BetweenIn(IComparable value, IComparable inclusiveMin, IComparable inclusiveMax)
        {
            if (inclusiveMin.CompareTo(inclusiveMax) > 0)
                throw new ArgumentException("inclusiveMin cannot be greater than inclusiveMax");
            return value.CompareTo(inclusiveMax) <= 0 && value.CompareTo(inclusiveMin) >= 0;
        }

        /// <summary>Checks if a given value is between a given range (exclusive).</summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="exclusiveMin">Lower exclusive border of the range.</param>
        /// <param name="exclusiveMax">Upper exclusive border of the range.</param>
        /// <returns></returns>
        public static bool BetweenEx(IComparable value, IComparable exclusiveMin, IComparable exclusiveMax)
        {
            if (exclusiveMin.CompareTo(exclusiveMax) > 0)
                throw new ArgumentException("inclusiveMin cannot be greater than inclusiveMax");
            return value.CompareTo(exclusiveMax) < 0 && value.CompareTo(exclusiveMin) > 0;
        }
        #endregion

        #region NumberOperations
        public static int NarmalizeToMagnitude(int value, int magnitude)
        {
            if (magnitude <= 1)
            {
                throw new ArgumentOutOfRangeException("magnitude");
            }

            while (value > magnitude)
                value /= magnitude;

            return value;
        }

        public static float NarmalizeToMagnitude(float value, float magnitude)
        {
            if (magnitude <= 0)
            {
                throw new ArgumentOutOfRangeException("magnitude");
            }

            float multiplier = 1;

            while(magnitude <= 1)
            {
                magnitude *= 10;
                multiplier *= 10;
            }
            if(magnitude < 2)
            {
                magnitude *= 2;
                multiplier *= 2;
            }

            while (value > magnitude)
                value /= magnitude;

            return value / multiplier;
        }


        #endregion

    }
}
