using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotLib.Data
{
    enum TextAlignment { Left, Middle, Right }
    class Stringer
    {

        /// <summary>Counts occurences of a given char in a given string.</summary>
        /// <param name="str">String to be analized.</param>
        /// <param name="ch">Char to be counted.</param>
        public static int CountChars(string str, char ch)
        {
            return str.Count((c) => c == ch);
        }

        #region Alignment
        /// <summary>Returns string aligned to the left adding spaces on the right side until it has given length.</summary>
        /// <param name="str">String to be aligned.</param>
        /// <param name="len">Desired length.</param>
        public static string AlignLeft(string str, int len)
        {
            return Align(str, len, TextAlignment.Left);
        }

        /// <summary>Returns string aligned to the middle adding spaces on the left and right side until it has given length.</summary>
        /// <param name="str">String to be aligned.</param>
        /// <param name="len">Desired length.</param>
        public static string AlignMiddle(string str, int len)
        {
            return Align(str, len, TextAlignment.Middle);
        }

        /// <summary>Returns string aligned to the right adding spaces on the left side until it has given length.</summary>
        /// <param name="str">String to be aligned.</param>
        /// <param name="len">Desired length.</param>
        public static string AlignRight(string str, int len)
        {
            return Align(str, len, TextAlignment.Right);
        }

        /// <summary>Returns string aligned to a given alignment and length.</summary>
        /// <param name="str">String to be aligned.</param>
        /// <param name="len">Desired length.</param>
        /// <param name="alignment">Desired alignment.</param>
        public static string Align(string str, int len, TextAlignment alignment)
        {
            if (len <= str.Length)
                return str;
            switch (alignment)
            {
                case TextAlignment.Left:
                    return str.PadLeft(len);
                case TextAlignment.Middle:
                    return str.PadLeft(str.Length + ((len - str.Length) / 2)).PadRight(len);
                default:
                    return str.PadRight(len);
            }
        }

        /// <summary>Returns a string filled with a given character to a given lenght.</summary>
        /// <param name="str">String to be filled.</param>
        /// <param name="len">Desired length.</param>
        /// <param name="c">Filling character.</param>
        public static string FillToLength(string str, int len, char c)
        {
            return str.Length < len ? str.PadRight(len, c) : str;
        }

        /// <summary>Returns a string filled with a given pattern to a given lenght.</summary>
        /// <param name="str">String to be filled.</param>
        /// <param name="len">Desired length.</param>
        /// <param name="pattern">Filling pattern.</param>
        public static string FillToLength(string str, int len, string pattern)
        {
            if (str.Length < len)
            {
                return str + GetFilledString(len - str.Length, pattern);
            }
            return str;
        }
        #endregion

        #region Building strings
        /// <summary>Creates a string filled with a given character to a given lenght.</summary>
        /// <param name="len">Desired length.</param>
        /// <param name="c">Filling character.</param>
        public static string GetFilledString(int len, char c)
        {
            return "".PadRight(len, c);
        }

        /// <summary>Creates a string filled with a given pattern to a given lenght.</summary>
        /// <param name="len">Desired length.</param>
        /// <param name="pattern">Filling pattern.</param>
        public static string GetFilledString(int len, string pattern)
        {
            string str = "";
            while (str.Length < len)
            {
                str += pattern;
            }
            return str.Substring(0, len);
        }

        /// <summary>Creates a string using a given function to fill it to a given lenght.</summary>
        /// <param name="len">Desired length.</param>
        /// <param name="func">Function used to fill the string based on a position.</param>
        public static string GetFilledString(int len, Func<int, char> func)
        {
            string str = "";
            for (int i = 0; i < len; i++)
            {
                str += func(i);
            }
            return str;
        }

        /// <summary>Creates a string using a given function to fill it to a given lenght.</summary>
        /// <param name="len">Desired length.</param>
        /// <param name="func">Function used to fill the string based on a position and previous character.</param>
        public static string GetFilledString(int len, Func<int, char, char> func)
        {
            string str = "";
            for (int i = 0; i < len; i++)
            {
                str += func(i, str.Length > 0 ? str.Last() : (char)0);
            }
            return str;
        }
        #endregion
    }
}
