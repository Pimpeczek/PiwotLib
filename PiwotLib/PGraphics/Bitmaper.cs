using System.Drawing;

namespace PiwotToolsLib.PGraphics
{
    public static class Bitmaper
    {
        /// <summary>
        /// Returns a part of oryginal bitmap specified by rect.
        /// </summary>
        /// <param name="bitmap">The oryginal bitmap.</param>
        /// <param name="rect">The region to be croped.</param>
        /// <returns></returns>
        public static Bitmap CropBitmap(Bitmap bitmap, Rectangle rect)
        {
            return CropBitmap(bitmap, rect.X, rect.Y, rect.Width, rect.Height);
        }
        /// <summary>
        /// Returns a part of oryginal bitmap specified by rect.
        /// </summary>
        /// <param name="bitmap">The oryginal bitmap.</param>
        /// <param name="x">X position of the cropped area.</param>
        /// <param name="y">Y position of the cropped area.</param>
        /// <param name="width">Width of the cropped area.</param>
        /// <param name="height">Height of the cropped area.</param>
        /// <returns></returns>
        public static Bitmap CropBitmap(Bitmap bitmap, int x, int y, int width, int height)
        {
            Bitmap nb = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(nb))
            {
                g.DrawImage(bitmap, -x, -y);
            }
            return nb;
        }

        /// <summary>
        /// Returns a new streched instance of the oryginal bitmap.
        /// </summary>
        /// <param name="bitmap">The oryginal bitmap.</param>
        /// <param name="width">New height.</param>
        /// <param name="height">New width.</param>
        /// <returns></returns>
        public static Bitmap StreachToSize(Bitmap bitmap, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bitmap, new Rectangle(0, 0, width, height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            }

            return result;
        }

        /// <summary>
        /// Returns a new resized instance of the oryginal bitmap, that fits given size.
        /// </summary>
        /// <param name="bitmap">The oryginal bitmap.</param>
        /// <param name="width">Given height.</param>
        /// <param name="height">Given width.</param>
        /// <returns></returns>
        public static Bitmap ResizeToFit(Bitmap bitmap, int width, int height)
        {
            float dRatio = (float)width / (float)height;
            float bRatio = (float)bitmap.Width / (float)bitmap.Height;
            if (dRatio < bRatio)
            {
                return new Bitmap(bitmap, width, (int)(width / bRatio));
            }
            else
            {
                return new Bitmap(bitmap, (int)(height * bRatio), (int)(height));
            }

        }
        /// <summary>
        /// Returns a new resized instance of the oryginal bitmap, that fits given size, and fills empty space with a given color.
        /// </summary>
        /// <param name="bitmap">The oryginal bitmap.</param>
        /// <param name="width">Given height.</param>
        /// <param name="height">Given width.</param>
        /// <param name="fillColor"></param>
        /// <returns></returns>
        public static Bitmap ResizeToFit(Bitmap bitmap, int width, int height, Color fillColor)
        {
            float dRatio = (float)width / (float)height;
            float bRatio = (float)bitmap.Width / (float)bitmap.Height;
            Bitmap nb = new Bitmap(width, height);
            
            if (dRatio < bRatio)
            {
                using (Graphics g = Graphics.FromImage(nb))
                {
                    g.DrawImage(new Bitmap(bitmap, width, (int)(width / bRatio)), 0, 0);
                }
                return nb;
            }
            else
            {
                using (Graphics g = Graphics.FromImage(nb))
                {
                    g.DrawImage(new Bitmap(bitmap, (int)(height * bRatio), height), 0, 0);
                }
                return nb;
            }

        }

        public static Bitmap CutColorBits(Bitmap b, Coloring.ColorEncoding colorEncoding)
        {
            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    b.SetPixel(x, y, Coloring.CutBits(b.GetPixel(x, y), colorEncoding));
                }
            }
            return b;
        }
    }
}
