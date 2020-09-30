using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Data
{
    /// <summary>
    /// Helper class used for looping.
    /// </summary>
    public static class Loops
    {
        #region Loops with functions
        /// <summary>
        /// Basic for loop that runs for a given number of times or until the 'func' returns false.
        /// </summary>
        /// <param name="xTimes">How many times does the loop happen.</param>
        /// <param name="func">The function to be invoked given number of times.
        /// <para>Function arguments correspond to loop iteration numbers.</para>
        /// <para>If false is returned the loop breaks.</para></param>
        public static void ForLoop(int xTimes, Func<int, bool> func)
        {
            for (int x = 0; x < xTimes; x++)
                if (!func.Invoke(x))
                    break;
        }

        /// <summary>
        /// Basic nested for loops that run for a given number of times or until the 'func' returns false.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the inner loop happen.</param>
        /// <param name="func">The function to be invoked given number of times.
        /// <para>Function arguments correspond to loop iteration numbers.</para>
        /// <para>If false is returned the loop breaks.</para></param>
        public static void ForLoop(int xTimes, int yTimes, Func<int, int, bool> func)
        {
            bool repeat = true;
            for (int x = 0; repeat && x < xTimes; x++)
            {
                for (int y = 0; repeat && y < yTimes; y++)
                {
                    repeat = func.Invoke(x, y);
                }
            }
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times or until the 'func' returns false.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the middle loop happen.</param>
        /// <param name="zTimes">How many times does the inner loop happen.</param>
        /// <param name="func">The function to be invoked given number of times.
        /// <para>Function arguments correspond to loop iteration numbers.</para>
        /// <para>If false is returned the loop breaks.</para></param>
        public static void ForLoop(int xTimes, int yTimes, int zTimes, Func<int, int, int, bool> func)
        {
            bool repeat = true;
            for (int x = 0; repeat && x < xTimes; x++)
            {
                for (int y = 0; repeat && y < yTimes; y++)
                {
                    for (int z = 0; repeat && z < zTimes; z++)
                    {
                        repeat = func.Invoke(x, y, z);
                    }
                }
            }
        }
        #endregion

        #region Loops with Actions
        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.
        /// <para>Action arguments correspond to loop iteration numbers.</para></param>
        public static void ForLoop(int xTimes, Action<int> action)
        {
            for (int x = 0; x < xTimes; x++)
                action.Invoke(x);
        }

        /// <summary>
        /// Basic nested for loops that run for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the inner loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.
        /// <para>Action arguments correspond to loop iteration numbers.</para></param>
        public static void ForLoop(int xTimes, int yTimes, Action<int, int> action)
        {
            bool repeat = true;
            for (int x = 0; repeat && x < xTimes; x++)
            {
                for (int y = 0; repeat && y < yTimes; y++)
                {
                    action.Invoke(x, y);
                }
            }
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the middle loop happen.</param>
        /// <param name="zTimes">How many times does the inner loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.
        /// <para>Action arguments correspond to loop iteration numbers.</para></param>
        public static void ForLoop(int xTimes, int yTimes, int zTimes, Action<int, int, int> action)
        {
            bool repeat = true;
            for (int x = 0; repeat && x < xTimes; x++)
            {
                for (int y = 0; repeat && y < yTimes; y++)
                {
                    for (int z = 0; repeat && z < zTimes; z++)
                    {
                        action.Invoke(x, y, z);
                    }
                }
            }
        }
        #endregion

        #region Loops with no-parameter actions
        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.</param>
        public static void ForLoop(int xTimes, Action action)
        {
            for (int x = 0; x < xTimes; x++)
                action.Invoke();
        }

        /// <summary>
        /// Basic nested for loops that run for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the inner loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.</param>
        public static void ForLoop(int xTimes, int yTimes, Action action)
        {
            bool repeat = true;
            for (int x = 0; repeat && x < xTimes; x++)
            {
                for (int y = 0; repeat && y < yTimes; y++)
                {
                    action.Invoke();
                }
            }
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the middle loop happen.</param>
        /// <param name="zTimes">How many times does the inner loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.</param>
        public static void ForLoop(int xTimes, int yTimes, int zTimes, Action action)
        {
            bool repeat = true;
            for (int x = 0; repeat && x < xTimes; x++)
            {
                for (int y = 0; repeat && y < yTimes; y++)
                {
                    for (int z = 0; repeat && z < zTimes; z++)
                    {
                        action.Invoke();
                    }
                }
            }
        }
        #endregion
    }
}
