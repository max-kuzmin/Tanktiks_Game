using System;
using System.Drawing;

namespace Tanks
{    abstract public class Bonus
    {
        public Battlefield field;
        public Point xy;
        public int id;
        protected int curFrame = 0;
        int frameTimer = 10;

        public event EventHandler<GetBonusEventArgs> GetBonusEventHandler;

        protected Bonus(Battlefield field1, int x1, int y1)
        {
            field = field1;
            xy.X = x1 * 32;
            xy.Y = y1 * 32;

            for (int i = 0; i < field.TanksArr.Count; i++)
            {
                GetBonusEventHandler += (field.TanksArr[i] as Tanks).BonusGiven;
            }

        }

        public void Frames()
        {
            if (frameTimer == 0)
            {
                if (curFrame == 0) curFrame = 1;
                else curFrame = 0;
                frameTimer = 10;
            }

            frameTimer--;
            GetBonusF();
        }

        public abstract void Show();
        public void GetBonusF()
        {
            for (int i = 0; i < field.TanksArr.Count; i++)
            {
                Tanks tank0 = field.TanksArr[i] as Tanks;
                if ((tank0.xy.X + 32) > xy.X && tank0.xy.X < (xy.X + 32) && (tank0.xy.Y + 32) > xy.Y && tank0.xy.Y < (xy.Y + 32))
                {
                    GetBonusEventArgs e = new GetBonusEventArgs(tank0);
                    GetBonusEventHandler(this, e);

                    field.BonusArr.Remove(this);
                }
            }
        }

    }

    public class Health : Bonus
    {
        static Sprite texture = new Sprite("Textures\\health.png", 2, 32);

        public Health(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 1;
        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);
            Frames();
        }

    }

    public class Speed : Bonus
    {
        static Sprite texture = new Sprite("Textures\\speed.png", 2, 32);

        public Speed(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 2;
        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);
            Frames();
        }

    }

    public class GunSpeed : Bonus
    {
        static Sprite texture = new Sprite("Textures\\gunSpeed.png", 2, 32);

        public GunSpeed(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 3;
        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);
            Frames();
        }

    }

    public class BulletPower : Bonus
    {
        static Sprite texture = new Sprite("Textures\\bulletDamage.png", 2, 32);

        public BulletPower(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 4;
        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);
            Frames();
        }

    }

    public class BulletSpeed : Bonus
    {
        static Sprite texture = new Sprite("Textures\\bulletSpeed.png", 2, 32);

        public BulletSpeed(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 5;
        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);
            Frames();
        }

    }

    public class FlagDefend : Bonus
    {
        static Sprite texture = new Sprite("Textures\\flagDefend.png", 2, 32);

        public FlagDefend(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 6;
        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);
            Frames();
        }

    }

    public class GetBonusEventArgs : EventArgs
    {
        public Tanks that;
        public GetBonusEventArgs(Tanks that0)
        {
            that = that0;
        }
    }
}