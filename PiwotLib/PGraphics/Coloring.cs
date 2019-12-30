using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PiwotToolsLib.PGraphics
{
    /// <summary>
    /// Piwot helper class used to manage color.
    /// </summary>
    public static class Coloring
    {
        /// <summary>
        /// Tells how many bits are used to encode rgb(a) color.
        /// </summary>
        public enum ColorEncodingMasks
        {
            /// <summary>
            /// 24 bits are used to encode 16777216‬ colors.
            /// </summary>
            Bit24,
            /// <summary>
            /// 21 bits are used to encode 2097152‬ colors.
            /// </summary>
            Bit21,
            /// <summary>
            /// 18 bits are used to encode 262144‬ colors.
            /// </summary>
            Bit18,
            /// <summary>
            /// 15 bits are used to encode 32768‬ colors.
            /// </summary>
            Bit15,
            /// <summary>
            /// 12 bits are used to encode 4096‬ colors.
            /// </summary>
            Bit12,
            /// <summary>
            /// 9 bits are used to encode 512 colors.
            /// </summary>
            Bit9,
            /// <summary>
            /// 6 bits are used to encode 64 colors.
            /// </summary>
            Bit6,
            /// <summary>
            /// 3 bits are used to encode 8 colors.
            /// </summary>
            Bit3
        }

        /// <summary>
        /// 24 bits are used to encode red, green and blue channels.
        /// <para>0x00FFFFFF</para>
        /// </summary>
        public static readonly uint colorMask24 = 0x00FFFFFF;
        /// <summary>
        /// 21 bits are used to encode red, green and blue channels.
        /// <para>0x00FEFEFE</para>
        /// </summary>
        public static readonly uint colorMask21 = 0x00FEFEFE;
        /// <summary>
        /// 18 bits are used to encode red, green and blue channels.
        /// <para>0x00FCFCFC</para>
        /// </summary>
        public static readonly uint colorMask18 = 0x00FCFCFC;
        /// <summary>
        /// 15 bits are used to encode red, green and blue channels.
        /// <para>0x00F8F8F8</para>
        /// </summary>
        public static readonly uint colorMask15 = 0x00F8F8F8;
        /// <summary>
        /// 12 bits are used to encode red, green and blue channels.
        /// <para>0x00F0F0F0</para>
        /// </summary>
        public static readonly uint colorMask12 = 0x00F0F0F0;
        /// <summary>
        /// 9 bits are used to encode red, green and blue channels.
        /// <para>0x00E0E0E0</para>
        /// </summary>
        public static readonly uint colorMask9 = 0x00E0E0E0;
        /// <summary>
        /// 6 bits are used to encode red, green and blue channels.
        /// <para>0x00C0C0C0</para>
        /// </summary>
        public static readonly uint colorMask6 = 0x00C0C0C0;
        /// <summary>
        /// 3 bits are used to encode red, green and blue channels.
        /// <para>0x00808080</para>
        /// </summary>
        public static readonly uint colorMask3 = 0x00808080;


        /// <summary>
        /// Tells how many bits are used to encode rgb(a) color.
        /// </summary>
        public enum AlphaEncodingMasks
        {
            /// <summary>
            /// 8 bits are used to encode 256‬ transparency levels.
            /// </summary>
            Bit8,
            /// <summary>
            /// 7 bits are used to encode 128‬ transparency levels.
            /// </summary>
            Bit7,
            /// <summary>
            /// 6 bits are used to encode 64‬ transparency levels.
            /// </summary>
            Bit6,
            /// <summary>
            /// 5 bits are used to encode 32‬ transparency levels.
            /// </summary>
            Bit5,
            /// <summary>
            /// 4 bits are used to encode 16‬ transparency levels.
            /// </summary>
            Bit4,
            /// <summary>
            /// 3 bits are used to encode 8‬ transparency levels.
            /// </summary>
            Bit3,
            /// <summary>
            /// 2 bits are used to encode 4‬ transparency levels.
            /// </summary>
            Bit2,
            /// <summary>
            /// 1 bit is used to encode 2‬ transparency levels.
            /// </summary>
            Bit1
        }

        /// <summary>
        /// 8 bits are used to encode alpha channel.
        /// <para>0xFF000000</para>
        /// </summary>
        public static readonly uint alphaMask8 = 0xFF000000;
        /// <summary>
        /// 7 bits are used to encode alpha channel.
        /// <para>0xFE000000</para>
        /// </summary>
        public static readonly uint alphaMask7 = 0xFE000000;
        /// <summary>
        /// 6 bits are used to encode alpha channel.
        /// <para>0xFC000000</para>
        /// </summary>
        public static readonly uint alphaMask6 = 0xFC000000;
        /// <summary>
        /// 5 bits are used to encode alpha channel.
        /// <para>0xF8000000</para>
        /// </summary>
        public static readonly uint alphaMask5 = 0xF8000000;
        /// <summary>
        /// 4 bits are used to encode alpha channel.
        /// <para>0xF0000000</para>
        /// </summary>
        public static readonly uint alphaMask4 = 0xF0000000;
        /// <summary>
        /// 3 bits are used to encode alpha channel.
        /// <para>0xE0000000</para>
        /// </summary>
        public static readonly uint alphaMask3 = 0xE0000000;
        /// <summary>
        /// 2 bits are used to encode alpha channel.
        /// <para>0xC0000000</para>
        /// </summary>
        public static readonly uint alphaMask2 = 0xC0000000;
        /// <summary>
        /// 1 bit is used to encode alpha channel.
        /// <para>0x80000000</para>
        /// </summary>
        public static readonly uint alphaMask1 = 0x80000000;

        /// <summary>
        /// Array of all color masks starting from 24 bits to 3 bits.
        /// </summary>
        public static readonly uint[] colorMasks = new uint[8] { colorMask24, colorMask21, colorMask18, colorMask15, colorMask12, colorMask9, colorMask6, colorMask3 };
        /// <summary>
        /// Array of all alpha masks starting from 8 bits to 1 bit.
        /// </summary>
        public static readonly uint[] alphaMasks = new uint[8] { alphaMask8, alphaMask7, alphaMask6, alphaMask5, alphaMask4, alphaMask3, alphaMask2, alphaMask1 };

        /// <summary>
        /// Returns a reversed version of a given color.
        /// </summary>
        /// <param name="c">Base color.</param>
        /// <returns></returns>
        public static Color NegateColor(Color c)
        {
            return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
        }

        /// <summary>
        /// Returns a color with its red, green and blue channels multiplied by a given factor.
        /// </summary>
        /// <param name="c">Base color.</param>
        /// <param name="multi">The multiplier.</param>
        /// <returns></returns>
        public static Color MultplyColor(Color c, float multi)
        {
            int iMulti = (int)(multi * 255);
            return Color.FromArgb(c.R * iMulti / 255, c.G * iMulti / 255, c.B * iMulti / 255);
        }

        /// <summary>
        /// Returns a color with its red, green and blue channels randomized.
        /// </summary>
        /// <returns></returns>
        public static Color RandomColor()
        {
            return Color.FromArgb(PMath.Rand.Int(256), PMath.Rand.Int(256), PMath.Rand.Int(256));
        }

        /// <summary>
        /// Returns a color with its red, green and blue channels encoded by a given number of bits. 
        /// </summary>
        /// <param name="c">The base color.</param>
        /// <param name="colorEncoding">The color encoding used.</param>
        /// <returns></returns>
        public static Color CutColor(Color c, ColorEncodingMasks colorEncoding)
        {
            return Color.FromArgb(CutBits(c.ToArgb(), CombineMasks(colorEncoding, AlphaEncodingMasks.Bit8)));
        }

        /// <summary>
        /// Returns a color with its red, green and blue channels encoded by a given number of bits. 
        /// </summary>
        /// <param name="c">The base color.</param>
        /// <param name="alphaEncoding">The alpha encoding used.</param>
        /// <returns></returns>
        public static Color CutAlpha(Color c, AlphaEncodingMasks alphaEncoding)
        {
            return Color.FromArgb(CutBits(c.ToArgb(), CombineMasks(ColorEncodingMasks.Bit24, alphaEncoding)));
        }

        /// <summary>
        /// Returns a color with its red, green and blue channels encoded by a given number of bits. 
        /// </summary>
        /// <param name="c">The base color.</param>
        /// <param name="colorEncoding">The color encoding used.</param>
        /// <param name="alphaEncoding">The alpha encoding used.</param>
        /// <returns></returns>
        public static Color CutAlpha(Color c, ColorEncodingMasks colorEncoding, AlphaEncodingMasks alphaEncoding)
        {
            return Color.FromArgb(CutBits(c.ToArgb(), CombineMasks(colorEncoding, alphaEncoding)));
        }

        /// <summary>
        /// Returns a color with its alpha, red, green and blue channels encoded by number of bits indicated by a given mask.
        /// </summary>
        /// <param name="c">The base color.</param>
        /// <param name="encodingMask">The encoding mask.</param>
        /// <returns></returns>
        public static Color CutBits(Color c, uint encodingMask)
        {
            return Color.FromArgb(CutBits(c.ToArgb(), encodingMask));
        }

        /// <summary>
        /// Returns a integer representation of color with its alpha, red, green and blue channels encoded by number of bits indicated by a given mask.
        /// </summary>
        /// <param name="c">The base color.</param>
        /// <param name="encodingMask">The encoding mask.</param>
        /// <returns></returns>
        public static int CutBits(int c, uint encodingMask)
        {
            return (int)(c & encodingMask);
        }


        /// <summary>
        /// Returns a new encoding mask that is a combination of color and alpha masks.
        /// </summary>
        /// <param name="colorEncoding"></param>
        /// <param name="alphaEncoding"></param>
        /// <returns></returns>
        public static uint CombineMasks(ColorEncodingMasks colorEncoding, AlphaEncodingMasks alphaEncoding)
        {
            return colorMasks[(int)colorEncoding] | alphaMasks[(int)alphaEncoding];
        }

    }
}
