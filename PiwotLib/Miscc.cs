using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PiwotToolsLib
{
    class Miscc
    {
        public static List<int> SumListCollumn(List<int[]> list)
        {
            List<int> sums = new List<int>();
            for (int y = 0; y < list.Count; y++)
            {

                for (int x = 0; x < list[y].Length; x++)
                {
                    if (sums.Count <= x)
                    {
                        sums.Add(0);
                    }
                    sums[x] += list[y][x];
                }
            }
            return sums;
        }
    }

    class Loops
    {
        public static void ForLoop(int xTimes, Func<int, bool> func)
        {
            for (int x = 0; x < xTimes; x++)
                if (!func.Invoke(x))
                    break;
        }

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
    }

    

    

    class MyColor
    {
        public static Color NegateColor(Color c)
        {
            return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
        }
        public static Color MultplyColor(Color c, float multi)
        {
            int iMulti = (int)(multi * 255);
            return Color.FromArgb(c.R * iMulti / 255, c.G * iMulti / 255, c.B * iMulti / 255);
        }
        public static Color RandomColor()
        {
            return Color.FromArgb(PMath.Rand.Int(256), PMath.Rand.Int(256), PMath.Rand.Int(256));
        }
        public static Color RandomColor(int seed)
        {
            Random rng = new Random(seed);
            return Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
        }
    }

    

    

    class Bars
    {
        public static readonly Char b_0 = '▏';
        public static readonly Char b_1 = '▎';
        public static readonly Char b_2 = '▍';
        public static readonly Char b_3 = '▌';
        public static readonly Char b_4 = '▋';
        public static readonly Char b_5 = '▊';
        public static readonly Char b_6 = '▉';
        public static readonly Char b_7 = '█';
        public static readonly Char[] bars = { '▏', '▎', '▍', '▌', '▋', '▊', '▉', '█' };
        public static readonly Char bv_0 = '▁';
        public static readonly Char bv_1 = '▂';
        public static readonly Char bv_2 = '▃';
        public static readonly Char bv_3 = '▄';
        public static readonly Char bv_4 = '▅';
        public static readonly Char bv_5 = '▆';
        public static readonly Char bv_6 = '▇';
        public static readonly Char bv_7 = '█';
        public static readonly Char[] barsVertical = { '▁', '▂', '▃', '▄', '▅', '▆', '▇', '█' };
        public static readonly Char t0 = ' ';
        public static readonly Char t1 = '░';
        public static readonly Char t2 = '▒';
        public static readonly Char t3 = '▓';
        public static readonly Char t4 = '█';
        public static readonly Char[] transparent = { ' ', '░', '▒', '▓', '█' };


        public static Char GetBarSegment(int id)
        {
            if (id < 0 || id > 7)
            {
                return ' ';
            }
            return bars[id];
        }
        public static Char GetVerticalBarSegment(int id)
        {
            if (id < 0 || id > 7)
            {
                return ' ';
            }
            return barsVertical[id];
        }
    }
}
