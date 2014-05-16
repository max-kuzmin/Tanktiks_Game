using System;
using System.Drawing;
using System.Collections;

namespace Tanks
{    abstract public class Blocks
    {
        public Battlefield field;
        public Point xy;

        public int id;

        public int health;
        public int curFrame;
        public int destroyed = 0;

        protected Blocks(Battlefield field1, int x1, int y1)
        {
            field = field1;
            xy.X = x1 * 32;
            xy.Y = y1 * 32;
        }

        public abstract void Show();
        public abstract void Damage(int power);

    }

    public class Grass : Blocks
    {

        static Sprite texture = new Sprite("Textures\\grass.png", 1, 32);
        public Grass(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 1;

        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[0] as Bitmap), xy);

        }

        public override void Damage(int power)
        {
        }
    }

    public class Brick : Blocks
    {

        static Sprite texture = new Sprite("Textures\\brick.png", 3, 32);
        public Brick(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 2;

            health = 15;

            curFrame = 0;

        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);

        }

        public override void Damage(int power)
        {
            health -= power;
            if (health <= 0)
            {
                (field.BlocksArr[xy.Y / 32] as ArrayList)[xy.X / 32] = new Grass(field, xy.X / 32, xy.Y / 32);
                field.ExplArr.Add(new Explosion(field, xy.X, xy.Y, 1));
                destroyed = 1;
            }
            else if (health <= 5)
            {
                curFrame = 2;
            }
            else if (health <= 10)
            {
                curFrame = 1;
            }
        }

    }

    public class Stone : Blocks
    {

        static Sprite texture = new Sprite("Textures\\stone.png", 3, 32);
        public Stone(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 3;

            health = 50;
            curFrame = 0;

        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);

        }

        public override void Damage(int power)
        {
            health -= power;
            if (health <= 0)
            {
                (field.BlocksArr[xy.Y / 32] as ArrayList)[xy.X / 32] = new Grass(field, xy.X / 32, xy.Y / 32);
                field.ExplArr.Add(new Explosion(field, xy.X, xy.Y, 1));
                destroyed = 1;
            }
            else if (health <= 15)
            {
                curFrame = 2;
            }
            else if (health <= 35)
            {
                curFrame = 1;
            }
        }
    }

    public class Water : Blocks
    {

        static Sprite texture = new Sprite("Textures\\water.png", 2, 32);
        public Water(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 4;
            curFrame = 0;

        }

        int frameTime = 0;
        public override void Show()
        {
            frameTime++;
            switch (frameTime)
            {
                case 15: curFrame = 0;
                    break;
                case 30: curFrame = 1;
                    frameTime = 0;
                    break;
            }
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);
        }

        public override void Damage(int power)
        {

        }

    }

    public class Ice : Blocks
    {

        static Sprite texture = new Sprite("Textures\\ice.png", 1, 32);
        public Ice(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 5;

        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[0] as Bitmap), xy);

        }

        public override void Damage(int power)
        {
        }
    }

    public class GreenFlag : Blocks
    {

        static Sprite texture = new Sprite("Textures\\flag.png", 4, 32);
        public GreenFlag(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 6;

            health = 20;

            curFrame = 0;
            EndEventHandler += field.curGame.EndLvl;

        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[curFrame] as Bitmap), xy);

        }

        public event EventHandler<EndEventArgs> EndEventHandler;

        public override void Damage(int power)
        {
            health -= power;
            if (health <= 0)
            {
                (field.BlocksArr[xy.Y / 32] as ArrayList)[xy.X / 32] = new Grass(field, xy.X / 32, xy.Y / 32);
                field.ExplArr.Add(new Explosion(field, xy.X, xy.Y, 1));
                destroyed = 1;
                EndEventArgs e = new EndEventArgs(2);
                EndEventHandler(this, e);
            }
            else if (health <= 5)
            {
                curFrame = 3;
            }
            else if (health <= 10)
            {
                curFrame = 2;
            }
            else if (health <= 15)
            {
                curFrame = 1;
            }
        }

    }

    public class RedSpawn : Blocks
    {

        static Sprite texture = new Sprite("Textures\\redSpawn.png", 1, 32);
        public RedSpawn(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 1;

        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[0] as Bitmap), xy);

        }

        public override void Damage(int power)
        {
        }
    }

    public class GreenSpawn : Blocks
    {

        static Sprite texture = new Sprite("Textures\\greenSpawn.png", 1, 32);
        public GreenSpawn(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            id = 1;

        }

        public override void Show()
        {
            field.gBuf.Graphics.DrawImage((texture.frames[0] as Bitmap), xy);

        }

        public override void Damage(int power)
        {
        }
    }
}