using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PiwotToolsLib.PGraphics
{
    public class Coloring
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
}
