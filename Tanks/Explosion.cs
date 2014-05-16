using System.Drawing;

namespace Tanks
{    public class Explosion
    {
        public Battlefield field;
        protected Point xy;
        protected int curFrame = 0;
        static Sprite[] texture = { new Sprite("Textures\\smallexplosion.png", 16, 8), new Sprite("Textures\\largeexplosion.png", 16, 32) };
        int t;

        public Explosion(Battlefield field1, int x1, int y1, int type1)
        {
            field = field1;
            xy.X = x1;
            xy.Y = y1;
            t = type1;
        }

        public void Show()
        {
            if (curFrame < 16)
            {
                field.gBuf.Graphics.DrawImage((texture[t].frames[curFrame] as Bitmap), xy);
            }
            else
            {
                field.ExplArr.Remove(this);
            }
            curFrame++;

        }

    }

}
