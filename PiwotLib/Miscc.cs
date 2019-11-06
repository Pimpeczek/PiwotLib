using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PiwotToolsLib
{
    public static class Miscc
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

    
    
}
