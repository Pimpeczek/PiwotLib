using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Text
{
    /*
    /// <summary>
    /// 
    /// </summary>
    public static class Boxes
    {
        /// <summary>
        /// Type of a box border.
        /// </summary>
        public enum BoxType
        {
            /// <summary>
            /// 
            /// </summary>
            light,
            /// <summary>
            /// 
            /// </summary>
            round,
            /// <summary>
            /// 
            /// </summary>
            normal,
            /// <summary>
            /// 
            /// </summary>
            doubled,
            /// <summary>
            /// 
            /// </summary>
            dashed,
            /// <summary>
            /// 
            /// </summary>
            dashedLight
        };
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

        public static string GetBoxName(string name, BoxType boxType)
        {
            return GetBoxName(name, GetBoxArray(boxType));
        }

        public static string GetBoxName(string name, Char[] boxes)
        {
            return $"{boxes[8]}{name}{boxes[11]}";
        }
    }
    */
}
