using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Console
{
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
