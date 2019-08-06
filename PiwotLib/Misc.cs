using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PiwotLib
{
    class Misc
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

    class Stringer
    {
        
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
            return Color.FromArgb(Math.Rand.Int(256), Math.Rand.Int(256), Math.Rand.Int(256));
        }
        public static Color RandomColor(int seed)
        {
            Random rng = new Random(seed);
            return Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
        }
    }

    

    class Boxes
    {
        public enum BoxType { light, round, normal, doubled, dashed, dashedLight };
        public static readonly Char cor_b_lu = '╔';
        public static readonly Char cor_b_ru = '╗';
        public static readonly Char cor_b_rl = '╝';
        public static readonly Char cor_b_ll = '╚';
        public static readonly Char cor_b_notd = '╩';
        public static readonly Char cor_b_notu = '╦';
        public static readonly Char cor_b_notl = '╠';
        public static readonly Char cor_b_notr = '╣';
        public static readonly Char cor_b_cross = '╬';
        public static readonly Char wal_b_h = '║';
        public static readonly Char wal_b_v = '═';

        public static readonly Char cor_lu = '┏';
        public static readonly Char cor_ru = '┓';
        public static readonly Char cor_rl = '┛';
        public static readonly Char cor_ll = '┗';
        public static readonly Char cor_notd = '┻';
        public static readonly Char cor_notu = '┳';
        public static readonly Char cor_notl = '┣';
        public static readonly Char cor_notr = '┫';
        public static readonly Char cor_cross = '╋';
        public static readonly Char wal_h = '┃';
        public static readonly Char wal_v = '━';

        public static readonly Char[] doubleBoxChars = { '╗', ' ', '═', '╔', '╦', ' ', '╝', '║', '╣', '╚', '╩', '╠', '╬' };
        public static readonly Char[] boxChars = { '┓', ' ', '━', '┏', '┳', ' ', '┛', '┃', '┫', '┗', '┻', '┣', '╋' };
        public static readonly Char[] lightBoxChars = { '┐', ' ', '─', '┌', '┬', ' ', '┘', '│', '┤', '└', '┴', '├', '┼' };
        public static readonly Char[] roundBoxChars = { '╮', ' ', '─', '╭', '┬', ' ', '╯', '│', '┤', '╰', '┴', '├', '┼' };
        public static readonly Char[] dashedLightBoxChars = { '┐', ' ', '┄', '┌', '┬', ' ', '┘', '┊', '┤', '└', '┴', '├', '┼' };
        public static readonly Char[] dashedBoxChars = { '┓', ' ', '┅', '┏', '┳', ' ', '┛', '┋', '┫', '┗', '┻', '┣', '╋' };


        public static Char GetBoxChar(int id)
        {
            id -= 3;
            if (id < 0 || id > 12)
                return ' ';
            return boxChars[id];
        }
        public static Char GetDoubleBoxChar(int id)
        {
            id -= 3;
            if (id < 0 || id > 12)
                return ' ';
            return doubleBoxChars[id];
        }
        public static Char GetLightBoxChar(int id)
        {
            id -= 3;
            if (id < 0 || id > 12)
                return ' ';
            return lightBoxChars[id];
        }
        public static Char GetDashedBoxChar(int id)
        {
            id -= 3;
            if (id < 0 || id > 12)
                return ' ';
            return dashedBoxChars[id];
        }


        /*
        protected char GetBorderChar(Int2 pos, char[] boxes)
        {
            int id = 0;
            if (pos.x > 0 && borderMap[pos.x - 1, pos.y])
                id += 1;
            if (pos.y < Size.y - 1 && borderMap[pos.x, pos.y + 1])
                id += 2;
            if (pos.x < Size.x - 1 && borderMap[pos.x + 1, pos.y])
                id += 4;
            if (pos.y > 0 && borderMap[pos.x, pos.y - 1])
                id += 8;
            id -= 3;
            return boxes[id];
        }
        */

        public static Char[] GetBoxArray(BoxType boxType)
        {
            Char[] bs;
            switch (boxType)
            {
                case BoxType.dashed:
                    bs = dashedBoxChars;
                    break;
                case BoxType.dashedLight:
                    bs = dashedLightBoxChars;
                    break;
                case BoxType.doubled:
                    bs = doubleBoxChars;
                    break;
                case BoxType.light:
                    bs = lightBoxChars;
                    break;
                case BoxType.round:
                    bs = roundBoxChars;
                    break;
                default:
                    bs = boxChars;
                    break;
            }
            return bs;
        }

        /*public static void DrawBox(BoxType boxType, int x, int y, int sx, int sy)
        {
            DrawBox(GetBoxArray(boxType), x, y, sx, sy);
        }

        public static void DrawBox(Char[] bs, int x, int y, int sx, int sy)
        {
            Renderer.Write($"{bs[3]}{"".PadLeft(sx - 2, bs[2])}{bs[0]}", x, y);
            string midBorder = $"{bs[7]}{"".PadLeft(sx - 2)}{bs[7]}";
            for (int i = 1; i < sy - 1; i++)
            {
                Renderer.Write(midBorder, x, y + i);

            }
            Renderer.Write($"{bs[9]}{"".PadLeft(sx - 2, bs[2])}{bs[6]}", x, y + sy - 1);

        rand
    }
    */
        public static string GetBoxName(string name, BoxType boxType)
        {
            return GetBoxName(name, GetBoxArray(boxType));
        }

        public static string GetBoxName(string name, Char[] boxes)
        {
            return $"{boxes[8]}{name}{boxes[11]}";
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
