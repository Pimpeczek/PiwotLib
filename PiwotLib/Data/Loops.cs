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
            ForLoopOffset(xTimes, 0, func);
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times or until the 'func' returns false.
        /// </summary>
        /// <param name="xTimes">How many times does the loop happen.</param>
        /// <param name="func">The function to be invoked given number of times.
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <para>Function arguments correspond to loop iteration numbers.</para>
        /// <para>If false is returned the loop breaks.</para></param>
        public static void ForLoopOffset(int xTimes, int xOffset, Func<int, bool> func)
        {
            xTimes += xOffset;
            for (int x = xOffset; x < xTimes; x++)
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
            ForLoopOffset(xTimes, yTimes, 0, 0, func);
        }

        /// <summary>
        /// Basic nested for loops that run for a given number of times or until the 'func' returns false.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the inner loop happen.</param>
        /// <param name="func">The function to be invoked given number of times.
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <param name="yOffset">Optional loop offset in Y axis</param>
        /// <para>Function arguments correspond to loop iteration numbers.</para>
        /// <para>If false is returned the loop breaks.</para></param>
        public static void ForLoopOffset(int xTimes, int yTimes, int xOffset, int yOffset, Func<int, int, bool> func)
        {
            bool repeat = true;
            xTimes += xOffset;
            yTimes += yOffset;
            for (int x = xOffset; repeat && x < xTimes; x++)
            {
                for (int y = xOffset; repeat && y < yTimes; y++)
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
            ForLoopOffset(xTimes, yTimes, zTimes, 0, 0, 0, func);
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times or until the 'func' returns false.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the middle loop happen.</param>
        /// <param name="zTimes">How many times does the inner loop happen.</param>
        /// <param name="func">The function to be invoked given number of times.
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <param name="yOffset">Optional loop offset in Y axis</param>
        /// <param name="zOffset">Optional loop offset in Z axis</param>
        /// <para>Function arguments correspond to loop iteration numbers.</para>
        /// <para>If false is returned the loop breaks.</para></param>
        public static void ForLoopOffset(int xTimes, int yTimes, int zTimes, int xOffset, int yOffset, int zOffset, Func<int, int, int, bool> func)
        {
            bool repeat = true;
            xTimes += xOffset;
            yTimes += yOffset;
            zTimes += zOffset;
            for (int x = xOffset; repeat && x < xTimes; x++)
            {
                for (int y = yOffset; repeat && y < yTimes; y++)
                {
                    for (int z = zOffset; repeat && z < zTimes; z++)
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
            ForLoopOffset(xTimes, 0, action);
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <para>Action arguments correspond to loop iteration numbers.</para></param>
        public static void ForLoopOffset(int xTimes, int xOffset, Action<int> action)
        {
            xTimes += xOffset;
            for (int x = xOffset; x < xTimes; x++)
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
            ForLoopOffset(xTimes, yTimes, 0, 0, action);
        }

        /// <summary>
        /// Basic nested for loops that run for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the inner loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <param name="yOffset">Optional loop offset in Y axis</param>
        /// <para>Action arguments correspond to loop iteration numbers.</para></param>
        public static void ForLoopOffset(int xTimes, int yTimes, int xOffset, int yOffset, Action<int, int> action)
        {
            xTimes += xOffset;
            yTimes += yOffset;
            for (int x = xOffset; x < xTimes; x++)
            {
                for (int y = yOffset; y < yTimes; y++)
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
            ForLoopOffset(xTimes, yTimes, zTimes, 0, 0, 0, action);
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the middle loop happen.</param>
        /// <param name="zTimes">How many times does the inner loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <param name="yOffset">Optional loop offset in Y axis</param>
        /// <param name="zOffset">Optional loop offset in Z axis</param>
        /// <para>Action arguments correspond to loop iteration numbers.</para></param>
        public static void ForLoopOffset(int xTimes, int yTimes, int zTimes, int xOffset, int yOffset, int zOffset, Action<int, int, int> action)
        {
            xTimes += xOffset;
            yTimes += yOffset;
            zTimes += zOffset;
            for (int x = xOffset; x < xTimes; x++)
            {
                for (int y = yOffset; y < yTimes; y++)
                {
                    for (int z = zOffset; z < zTimes; z++)
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
            ForLoopOffset(xTimes, 0, action);
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the loop happen.</param>
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <param name="action">The action to be invoked given number of times.</param>
        public static void ForLoopOffset(int xTimes, int xOffset, Action action)
        {
            xTimes += xOffset;
            for (int x = xOffset; x < xTimes; x++)
                action.Invoke();
        }

        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the middle loop happen.</param>
        /// <param name="action">The action to be invoked given number of times.</param>
        public static void ForLoop(int xTimes, int yTimes, Action action)
        {
            ForLoopOffset(xTimes, yTimes, 0, 0, action);
        }

        /// <summary>
        /// Basic nested for loops that run for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the inner loop happen.</param>
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <param name="yOffset">Optional loop offset in Y axis</param>
        /// <param name="action">The action to be invoked given number of times.</param>
        public static void ForLoopOffset(int xTimes, int yTimes, int xOffset, int yOffset, Action action)
        {
            xTimes += xOffset;
            yTimes += yOffset;
            for (int x = xOffset; x < xTimes; x++)
            {
                for (int y = yOffset; y < yTimes; y++)
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
            ForLoopOffset(xTimes, yTimes, zTimes, 0, 0, 0, action);
        }


        /// <summary>
        /// Basic for loop that runs for a given number of times.
        /// </summary>
        /// <param name="xTimes">How many times does the outer loop happen.</param>
        /// <param name="yTimes">How many times does the middle loop happen.</param>
        /// <param name="zTimes">How many times does the inner loop happen.</param>
        /// <param name="xOffset">Optional loop offset in X axis</param>
        /// <param name="yOffset">Optional loop offset in Y axis</param>
        /// <param name="zOffset">Optional loop offset in Z axis</param>
        /// <param name="action">The action to be invoked given number of times.</param>
        public static void ForLoopOffset(int xTimes, int yTimes, int zTimes, int xOffset, int yOffset, int zOffset, Action action)
        {
            xTimes += xOffset;
            yTimes += yOffset;
            zTimes += zOffset;
            for (int x = xOffset; x < xTimes; x++)
            {
                for (int y = yOffset; y < yTimes; y++)
                {
                    for (int z = zOffset; z < zTimes; z++)
                    {
                        action.Invoke();
                    }
                }
            }
        }
        #endregion

        #region Edge loops with action
        /// <summary>
        /// For loop that only iterates through 'edges' of a virtual rectangle.
        /// </summary>
        /// <param name="xSize">Rectangle first dimention size</param>
        /// <param name="ySize">Rectangle second dimention size</param>
        /// <param name="action">The action to be invoked on the rectangle edges.
        /// <para>Action arguments correspond to coordinates.</para></param>
        public static void ForEdgesLoop(int xSize, int ySize, Action<int, int> action)
        {
            xSize -= 1;
            ySize -= 1;
            for (int x = 0; x <= xSize; x++)
            {
                action.Invoke(x, 0);
                action.Invoke(x, ySize);
            }
            
            for (int y = 1; y <= ySize; y++)
            {
                action.Invoke(0, y);
                action.Invoke(xSize, y);
            }
        }

        /// <summary>
        /// For loop that only iterates through 'edges' of a virtual rectangle.
        /// </summary>
        /// <param name="xSize">Rectangle first dimention size</param>
        /// <param name="ySize">Rectangle second dimention size</param>
        /// <param name="zSize">Rectangle third dimention size</param>
        /// <param name="action">The action to be invoked on the rectangle edges.
        /// <para>Action arguments correspond to coordinates.</para></param>
        public static void ForEdgesLoop(int xSize, int ySize, int zSize, Action<int, int, int> action)
        {
            xSize -= 1;
            ySize -= 1;
            zSize -= 1;
            for (int x = 0; x <= xSize; x++)
            {
                action.Invoke(x, 0, 0);
                action.Invoke(x, 0, zSize);
                action.Invoke(x, ySize, 0);
                action.Invoke(x, ySize, zSize);

            }

            for (int y = 0; y <= ySize; y++)
            {
                action.Invoke(0, y, 0);
                action.Invoke(0, 0, zSize);
                action.Invoke(xSize, ySize, 0);
                action.Invoke(xSize, ySize, zSize);
            }

            for (int z = 0; z <= zSize; z++)
            {
                action.Invoke(0, 0, z);
                action.Invoke(0, ySize, zSize);
                action.Invoke(xSize, 0, z);
                action.Invoke(xSize, ySize, z);
            }
        }
        #endregion
    }
}
