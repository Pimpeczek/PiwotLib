using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotToolsLib.Text
{
    /// <summary>
    /// Piwot helper class containing full block characters.
    /// </summary>
    public static class Bars
    {
        /// <summary>
        /// 1/8 of horizontal filling
        /// </summary>
        public static readonly Char b_0 = '▏';
        /// <summary>
        /// 2/8 of horizontal filling
        /// </summary>
        public static readonly Char b_1 = '▎';
        /// <summary>
        /// 3/8 of horizontal filling
        /// </summary>
        public static readonly Char b_2 = '▍';
        /// <summary>
        /// 4/8 of horizontal filling
        /// </summary>
        public static readonly Char b_3 = '▌';
        /// <summary>
        /// 5/8 of horizontal filling
        /// </summary>
        public static readonly Char b_4 = '▋';
        /// <summary>
        /// 6/8 of horizontal filling
        /// </summary>
        public static readonly Char b_5 = '▊';
        /// <summary>
        /// 7/8 of horizontal filling
        /// </summary>
        public static readonly Char b_6 = '▉';
        /// <summary>
        /// 8/8 of horizontal filling
        /// </summary>
        public static readonly Char b_7 = '█';

        /// <summary>
        /// All horizontaly filling bars from 1/8 to 8/8
        /// </summary>
        public static readonly Char[] bars = { '▏', '▎', '▍', '▌', '▋', '▊', '▉', '█' };
        /// <summary>
        /// 1/8 of vertival filling
        /// </summary>
        public static readonly Char bv_0 = '▁';
        /// <summary>
        /// 2/8 of vertival filling
        /// </summary>
        public static readonly Char bv_1 = '▂';
        /// <summary>
        /// 3/8 of vertival filling
        /// </summary>
        public static readonly Char bv_2 = '▃';
        /// <summary>
        /// 4/8 of vertival filling
        /// </summary>
        public static readonly Char bv_3 = '▄';
        /// <summary>
        /// 5/8 of vertival filling
        /// </summary>
        public static readonly Char bv_4 = '▅';
        /// <summary>
        /// 6/8 of vertival filling
        /// </summary>
        public static readonly Char bv_5 = '▆';
        /// <summary>
        /// 7/8 of vertival filling
        /// </summary>
        public static readonly Char bv_6 = '▇';
        /// <summary>
        /// 8/8 of vertival filling
        /// </summary>
        public static readonly Char bv_7 = '█';

        /// <summary>
        /// All vertivaly filling bars from 1/8 to 8/8
        /// </summary>
        public static readonly Char[] barsVertical = { '▁', '▂', '▃', '▄', '▅', '▆', '▇', '█' };

        /// <summary>
        /// Transparent bar with 0/4 of the filling
        /// </summary>
        public static readonly Char t0 = ' ';
        /// <summary>
        /// Transparent bar with 1/4 of the filling
        /// </summary>
        public static readonly Char t1 = '░';
        /// <summary>
        /// Transparent bar with 2/4 of the filling
        /// </summary>
        public static readonly Char t2 = '▒';
        /// <summary>
        /// Transparent bar with 3/4 of the filling
        /// </summary>
        public static readonly Char t3 = '▓';
        /// <summary>
        /// Transparent bar with 4/4 of the filling
        /// </summary>
        public static readonly Char t4 = '█';
        /// <summary>
        /// All transparent bars from 0/4 to 4/4
        /// </summary>
        public static readonly Char[] transparent = { ' ', '░', '▒', '▓', '█' };

        /// <summary>
        /// Returns horizontal bar with a given id (filled fraction)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Char GetBarSegment(int id)
        {
            if (id < 0 || id > 7)
            {
                return ' ';
            }
            return bars[id];
        }
        /// <summary>
        /// Returns vertical bar with a given id (filled fraction)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
