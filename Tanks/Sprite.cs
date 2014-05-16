using System;
using System.Drawing;
using System.Collections;
using System.Drawing.Imaging;

namespace Tanks
{
    public class Sprite
    {
        public ArrayList frames;

        public Sprite(String fileName, int length, int s)
        {
            Bitmap pic = new Bitmap(fileName);
            pic.SetResolution(dpi, dpi);
            frames = new ArrayList();
            for (int i = 0; i < length; i++)
            {
                Rectangle frame = new Rectangle(i * s, 0, s, s);
                frames.Add(pic.Clone(frame, PixelFormat.Format32bppArgb));

            }
        }

        public static int dpi = 96;

    }

}
