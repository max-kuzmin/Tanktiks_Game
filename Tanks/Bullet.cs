using System;
using System.Drawing;
using System.Collections;

namespace Tanks
{    public class Bullet
    {
        public int side;
        public Point xy;
        protected int rotation;

        static Sprite texture = new Sprite("Textures\\bullet.png", 4, 8);
        protected Battlefield field;
        int curFrame;
        private int WW, WH;
        int power = 5;
        int bulletSpeed = 4;

        public event EventHandler<HitTankEventArgs> HitTankEventHandler;
        public event EventHandler<HitBulletEventArgs> HitBulletEventHandler;

        public Bullet(Battlefield field1, Tanks tank, int power0, int bulletSpeed0)
        {
            field = field1;
            power = power0;
            bulletSpeed = bulletSpeed0;
            side = tank.side;
            rotation = tank.rotation;
            WW = field1.cellsX * 32;
            WH = field1.cellsY * 32;
            switch (rotation)
            {
                case 0:
                    xy.X = tank.xy.X + 13;
                    xy.Y = tank.xy.Y - 7;
                    curFrame = 0;
                    break;
                case 1:
                    xy.X = tank.xy.X + 31;
                    xy.Y = tank.xy.Y + 13;

                    curFrame = 1;
                    break;
                case 2:
                    xy.X = tank.xy.X + 13;
                    xy.Y = tank.xy.Y + 31;

                    curFrame = 2;
                    break;
                case 3:
                    xy.X = tank.xy.X - 7;
                    xy.Y = tank.xy.Y + 13;

                    curFrame = 3;
                    break;

            }

            for (int i = 0; i < field.TanksArr.Count; i++)
            {

                HitTankEventHandler += (field.TanksArr[i] as Tanks).Damage;
            }

            for (int j = 0; j < field.BulletsArr.Count; j++)
            {

                HitBulletEventHandler += (field.BulletsArr[j] as Bullet).HitBullet;
                (field.BulletsArr[j] as Bullet).HitBulletEventHandler += HitBullet;

            }

        }

        public void Go()
        {
            if (xy.X > 0 && xy.Y > 0 && xy.X + 8 < WW && xy.Y + 8 < WH)
            {
                switch (rotation)
                {
                    case 0: xy.Y -= bulletSpeed; break;
                    case 1: xy.X += bulletSpeed; break;
                    case 2: xy.Y += bulletSpeed; break;
                    case 3: xy.X -= bulletSpeed; break;
                }

                Hit();
                HitTankF();
                if (MenuForm.collisionBulletsSet == true)
                {
                    HitBulletF();
                }

                field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);

            }

            else
            {
                field.BulletsArr.Remove(this);
            }

        }

        int detected = 0;
        int steps = 0;
        Blocks target = null;

        void Hit()
        {

            if (detected == 0)
            {
                detected = 1;
                target = null;
                switch (rotation)
                {
                    case 0:

                        if ((xy.Y + 8) > 32 - bulletSpeed)
                        {
                            target = ((field.BlocksArr[(xy.Y + 8 + bulletSpeed) / 32 - 1] as ArrayList)[(xy.X + 2) / 32] as Blocks);

                            steps = (xy.Y + 8) - (target.xy.Y + 32);

                        }

                        break;

                    case 1:
                        if (xy.X < (WW - 32) + bulletSpeed)
                        {
                            target = ((field.BlocksArr[(xy.Y + 2) / 32] as ArrayList)[(xy.X - bulletSpeed) / 32 + 1] as Blocks);

                            steps = target.xy.X - xy.X;

                        }
                        break;

                    case 2:
                        if (xy.Y < (WH - 32) + bulletSpeed)
                        {
                            target = ((field.BlocksArr[(xy.Y - bulletSpeed) / 32 + 1] as ArrayList)[(xy.X + 2) / 32] as Blocks);

                            steps = target.xy.Y - xy.Y;

                        }
                        break;

                    case 3:
                        if ((xy.X + 8) > 32 - bulletSpeed)
                        {
                            target = ((field.BlocksArr[(xy.Y + 2) / 32] as ArrayList)[(xy.X + 8 + bulletSpeed) / 32 - 1] as Blocks);

                            steps = (xy.X + 8) - (target.xy.X + 32);

                        }
                        break;

                }
            }
            if (target != null)
            {
                if (steps <= 0)
                {
                    if ((target.id == 2 || target.id == 3 || target.id == 6) && target.destroyed == 0)
                    {
                        target.Damage(power);
                        field.BulletsArr.Remove(this);
                        field.ExplArr.Add(new Explosion(field, xy.X, xy.Y, 0));

                        if (side == 1) { field.curGame.greenScore += 1; }
                    }
                    else
                    {
                        detected = 0;
                    }
                }
                steps -= bulletSpeed;

            }

        }

        void HitTankF()
        {
            for (int i = 0; i < field.TanksArr.Count; i++)
            {
                Tanks target = (field.TanksArr[i] as Tanks);
                if (target.xy.X < (xy.X + 4) && (target.xy.X + 32) > (xy.X + 4) && target.xy.Y < (xy.Y + 4) && (target.xy.Y + 32) > (xy.Y + 4))
                {
                    HitTankEventArgs e = new HitTankEventArgs(target, power);
                    HitTankEventHandler(this, e);

                }
            }

        }

        void HitBulletF()
        {
            for (int i = 0; i < field.BulletsArr.Count; i++)
            {
                if (field.BulletsArr[i] != this && (field.BulletsArr[i] as Bullet).side != this.side)
                {
                    Bullet target = (field.BulletsArr[i] as Bullet);
                    if (target.xy.X < (xy.X + 6) && (target.xy.X + 6) > (xy.X) && target.xy.Y < (xy.Y + 6) && (target.xy.Y + 6) > (xy.Y))
                    {
                        HitBulletEventArgs e = new HitBulletEventArgs(target);
                        HitBulletEventHandler(this, e);

                        field.curGame.greenScore += 5;
                    }
                }
            }
        }

        void HitBullet(object sender, HitBulletEventArgs e)
        {
            if (this == e.that)
            {
                field.BulletsArr.Remove(sender);
                field.BulletsArr.Remove(e.that);
                field.ExplArr.Add(new Explosion(field, (sender as Bullet).xy.X, (sender as Bullet).xy.Y, 0));
            }
        }

    }

    public class HitTankEventArgs : EventArgs
    {
        public Tanks that;
        public int power;
        public HitTankEventArgs(Tanks that0, int power0)
        {
            that = that0;
            power = power0;
        }
    }

    public class HitBulletEventArgs : EventArgs
    {
        public Bullet that;
        public HitBulletEventArgs(Bullet that0)
        {
            that = that0;
        }
    }

}

