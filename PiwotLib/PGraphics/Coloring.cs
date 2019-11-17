using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PiwotToolsLib.PGraphics
{
    public static class Coloring
    {
        public enum ColorEncoding { Bit24, Bit21, Bit18, Bit15, Bit12, Bit9, Bit6, Bit3 }
        public static readonly uint mod24 = 0xFFFFFFFF;
        public static readonly uint mod21 = 0xFFFEFEFE;
        public static readonly uint mod18 = 0xFFFCFCFC;
        public static readonly uint mod15 = 0xFFF8F8F8;
        public static readonly uint mod12 = 0xFFF0F0F0;
        public static readonly uint mod9 = 0xFFE0E0E0;
        public static readonly uint mod6 = 0xFFC0C0C0;
        public static readonly uint mod3 = 0xFF808080;

        public static readonly uint[] mods = new uint[8] { mod24, mod21, mod18, mod15, mod12, mod9, mod6, mod3 };

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

        public static Color CutBits(Color c, ColorEncoding colorEncoding)
        {
            return Color.FromArgb(CutBits(c.ToArgb(), mods[(int)colorEncoding]));
        }

        public static int CutBits(int c, uint colorEncoding)
        {
            return (int)(c & colorEncoding);
        }

    }
}
