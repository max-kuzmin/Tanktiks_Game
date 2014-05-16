using System;
using System.Drawing;
using System.Collections;
	
namespace Tanks
{    abstract public class Tanks
    {

        protected Battlefield field;
        public Point xy;
        public int rotation = 0;
        public int cellX, cellY;
        public int health, speed, gunSpeed;
        public int bulletPower = 5;
        public int bulletSpeed = 5;
        protected int curFrame;
        protected int anim = 0;
        protected int frameD = 0;
        public int side;

        public event EventHandler<KilledEventArgs> KilledEventHandler;

        protected Tanks(Battlefield field1, int x1, int y1)
        {
            field = field1;
            cellX = x1;
            cellY = y1;
            xy.X = x1 * 32;
            xy.Y = y1 * 32;

            for (int k = 0; k < field.BonusArr.Count; k++)
            {
                (field.BonusArr[k] as Bonus).GetBonusEventHandler += BonusGiven;
            }

            KilledEventHandler += field.TankKilled;
        }

        public abstract void Go();
        protected abstract bool NoOtherTanks(int goSide);

        public abstract void ShotCheck();

        public void Damage(object sender, HitTankEventArgs e)
        {
            if (this == e.that && (sender as Bullet).side != side)
            {
                health -= e.power;
                if (health > 0)
                {
                    if (health <= 10)
                    {
                        frameD = 8;
                    }
                }
                else
                {
                    field.TanksArr.Remove(this);

                    field.ExplArr.Add(new Explosion(field, xy.X, xy.Y, 1));

                    KilledEventArgs e2 = new KilledEventArgs(side);
                    KilledEventHandler(this, e2);

                }
                field.BulletsArr.Remove(sender);
                field.ExplArr.Add(new Explosion(field, (sender as Bullet).xy.X, (sender as Bullet).xy.Y, 0));
                if (side == 2) field.curGame.greenScore += 10;
            }
        }

        public void BonusGiven(object sender, GetBonusEventArgs e)
        {
            if (e.that == this)
            {

                BonusEffect((sender as Bonus).id);

            }
        }

        protected abstract void BonusEffect(int myBonus);

    }

    public class GreenTank : Tanks
    {

        static Sprite texture = new Sprite("Textures\\greentank.png", 16, 32);

        int[,] keysArr = { { 87, 65, 83, 68 }, { 38, 37, 40, 39 } };

        public GreenTank(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            side = 1;
            health = 20 + (2 - MenuForm.difficultySet) * 5;
            speed = 2;
            if (MenuForm.difficultySet != 2) gunSpeed = 6;
            else gunSpeed = 8;
            curFrame = 0;
        }
        public int canShot = 5;
        private int key = 0;
        public int goKey
        {
            get
            {
                return key;
            }
            set
            {
                if (value != 16)
                {
                    key = value;

                }
            }
        }

        int prevKey = 0;
        int nextKey = 0;
        int slide = 11;
        int stopFlag = 0;

        public override void Go()
        {

            if (stopFlag == 0)
            {

                int speedX = 0;
                int speedY = 0;

                if (((field.BlocksArr[(xy.Y + 16) / 32] as ArrayList)[(xy.X + 16) / 32] as Blocks).id == 5)
                {
                    if (slide > 30) slide = 0;

                    nextKey = key;

                    if (slide < 30)
                    {
                        key = prevKey;
                    }
                    else if (slide >= 30)
                    {
                        key = nextKey;
                    }

                    slide++;

                }
                else if (slide > 0) slide = 0;

                if (key == keysArr[MenuForm.keysSet, 0])
                {
                    if (xy.Y > 0 && NoOtherTanks(0))
                    {

                        int corner1 = ((field.BlocksArr[(xy.Y - 1) / 32] as ArrayList)[(xy.X + 1) / 32] as Blocks).id;
                        int corner2 = ((field.BlocksArr[(xy.Y - 1) / 32] as ArrayList)[(xy.X + 31) / 32] as Blocks).id;
                        int corner0 = ((field.BlocksArr[(xy.Y - 1) / 32] as ArrayList)[(xy.X + 16) / 32] as Blocks).id;

                        if ((corner1 == 1 || corner1 == 5) && (corner2 == 1 || corner2 == 5))
                        {
                            speedY = -speed;

                            anim++;
                        }
                        else if ((corner1 != 1 && corner1 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedX = speed;
                        }
                        else if ((corner2 != 1 && corner2 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedX = -speed;
                        }

                    }
                    curFrame = (curFrame != 0 && curFrame != 4) ? 0 : curFrame;

                    rotation = 0;
                }
                else if (key == keysArr[MenuForm.keysSet, 1])
                {
                    if (xy.X > 0 && NoOtherTanks(3))
                    {
                        int corner1 = ((field.BlocksArr[(xy.Y + 1) / 32] as ArrayList)[(xy.X - 1) / 32] as Blocks).id;
                        int corner2 = ((field.BlocksArr[(xy.Y + 31) / 32] as ArrayList)[(xy.X - 1) / 32] as Blocks).id;
                        int corner0 = ((field.BlocksArr[(xy.Y + 16) / 32] as ArrayList)[(xy.X - 1) / 32] as Blocks).id;

                        if ((corner1 == 1 || corner1 == 5) && (corner2 == 1 || corner2 == 5))
                        {
                            speedX = -speed;
                            anim++;
                        }

                        else if ((corner1 != 1 && corner1 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedY = speed;
                        }
                        else if ((corner2 != 1 && corner2 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedY = -speed;
                        }

                    }
                    curFrame = (curFrame != 3 && curFrame != 7) ? 3 : curFrame;

                    rotation = 3;
                }
                else if (key == keysArr[MenuForm.keysSet, 2])
                {
                    if (xy.Y < (field.cellsY - 1) * 32 && NoOtherTanks(2))
                    {
                        int corner1 = ((field.BlocksArr[(xy.Y + 33) / 32] as ArrayList)[(xy.X + 1) / 32] as Blocks).id;
                        int corner2 = ((field.BlocksArr[(xy.Y + 33) / 32] as ArrayList)[(xy.X + 31) / 32] as Blocks).id;
                        int corner0 = ((field.BlocksArr[(xy.Y + 33) / 32] as ArrayList)[(xy.X + 16) / 32] as Blocks).id;

                        if ((corner1 == 1 || corner1 == 5) && (corner2 == 1 || corner2 == 5))
                        {
                            speedY = speed;
                            anim++;
                        }

                        else if ((corner1 != 1 && corner1 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedX = speed;
                        }
                        else if ((corner2 != 1 && corner2 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedX = -speed;
                        }

                    }
                    curFrame = (curFrame != 2 && curFrame != 6) ? 2 : curFrame;
                    rotation = 2;
                }
                else if (key == keysArr[MenuForm.keysSet, 3])
                {
                    if (xy.X < (field.cellsX - 1) * 32 && NoOtherTanks(1))
                    {
                        int corner1 = ((field.BlocksArr[(xy.Y + 1) / 32] as ArrayList)[(xy.X + 33) / 32] as Blocks).id;
                        int corner2 = ((field.BlocksArr[(xy.Y + 31) / 32] as ArrayList)[(xy.X + 33) / 32] as Blocks).id;
                        int corner0 = ((field.BlocksArr[(xy.Y + 16) / 32] as ArrayList)[(xy.X + 33) / 32] as Blocks).id;

                        if ((corner1 == 1 || corner1 == 5) && (corner2 == 1 || corner2 == 5))
                        {
                            speedX = speed;
                            anim++;
                        }
                        else if ((corner1 != 1 && corner1 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedY = speed;
                        }
                        else if ((corner2 != 1 && corner2 != 5) && (corner0 == 1 || corner0 == 5))
                        {
                            speedY = -speed;
                        }

                    }
                    curFrame = (curFrame != 1 && curFrame != 5) ? 1 : curFrame;
                    rotation = 1;

                }

                if (anim == 5 && (key == keysArr[MenuForm.keysSet, 0] || key == keysArr[MenuForm.keysSet, 1] || key == keysArr[MenuForm.keysSet, 2] || key == keysArr[MenuForm.keysSet, 3]))
                {
                    if (curFrame < 4)
                    {
                        curFrame += 4;
                    }
                    else
                    {
                        curFrame -= 4;
                    }
                    anim = 0;
                }

                prevKey = key;

                xy.X += speedX;
                xy.Y += speedY;
            }
            else stopFlag = 0;

            field.gBuf.Graphics.DrawImage((texture.frames[(curFrame + frameD)] as Bitmap), xy);

        }

        public override void ShotCheck()
        {
            if (canShot < 10 * gunSpeed)
            {
                canShot++;
            }
        }

        public void Shot(/*int Key*/)
        {
            if (/*Key == 16 &&*/ canShot >= 10 * gunSpeed)
            {
                field.BulletsArr.Add(new Bullet(field, this, bulletPower, bulletSpeed));
                canShot = 0;
            }

        }

        protected override void BonusEffect(int myBonus)
        {
            switch (myBonus)
            {
                case 1:

                    field.curGame.greenLifes++;
                    if (MenuForm.difficultySet != 2)
                    {
                        health = 20;
                        frameD = 0;
                    }
                    break;
                case 2: speed = 4;
                    xy.X = xy.X / 4 * 4;
                    xy.Y = xy.Y / 4 * 4;
                    break;
                case 3: gunSpeed = 2;
                    break;
                case 4: bulletPower = 10;
                    break;
                case 5: bulletSpeed = 8;
                    break;
                case 6: field.Defend(side);
                    break;
            }
            field.curGame.greenScore += 25;
        }

        override protected bool NoOtherTanks(int goSide)
        {
            if (MenuForm.collisionTanksSet == true)
            {

                for (int i = 0; i < field.TanksArr.Count; i++)
                {
                    if (this != field.TanksArr[i] as Tanks)
                    {

                        switch (goSide)
                        {
                            case 0:
                                if (((xy.X + 6 >= (field.TanksArr[i] as Tanks).xy.X && xy.X + 6 <= (field.TanksArr[i] as Tanks).xy.X + 32) || (xy.X + 26 >= (field.TanksArr[i] as Tanks).xy.X && xy.X + 26 <= (field.TanksArr[i] as Tanks).xy.X + 32)) && xy.Y - 1 <= (field.TanksArr[i] as Tanks).xy.Y + 32 && xy.Y - 1 >= (field.TanksArr[i] as Tanks).xy.Y + 26)
                                    return false;
                                break;

                            case 2:
                                if (((xy.X + 6 >= (field.TanksArr[i] as Tanks).xy.X && xy.X + 6 <= (field.TanksArr[i] as Tanks).xy.X + 32) || (xy.X + 26 >= (field.TanksArr[i] as Tanks).xy.X && xy.X + 26 <= (field.TanksArr[i] as Tanks).xy.X + 32)) && xy.Y + 1 + 32 >= (field.TanksArr[i] as Tanks).xy.Y && xy.Y + 1 + 32 <= (field.TanksArr[i] as Tanks).xy.Y + 6)
                                    return false;
                                break;

                            case 3:
                                if (((xy.Y + 6 >= (field.TanksArr[i] as Tanks).xy.Y && xy.Y + 6 <= (field.TanksArr[i] as Tanks).xy.Y + 32) || (xy.Y + 26 >= (field.TanksArr[i] as Tanks).xy.Y && xy.Y + 26 <= (field.TanksArr[i] as Tanks).xy.Y + 32)) && xy.X - 1 <= (field.TanksArr[i] as Tanks).xy.X + 32 && xy.X - 1 >= (field.TanksArr[i] as Tanks).xy.X + 26)
                                    return false;
                                break;

                            case 1:
                                if (((xy.Y + 6 >= (field.TanksArr[i] as Tanks).xy.Y && xy.Y + 6 <= (field.TanksArr[i] as Tanks).xy.Y + 32) || (xy.Y + 26 >= (field.TanksArr[i] as Tanks).xy.Y && xy.Y + 26 <= (field.TanksArr[i] as Tanks).xy.Y + 32)) && xy.X + 1 + 32 >= (field.TanksArr[i] as Tanks).xy.X && xy.X + 1 + 32 <= (field.TanksArr[i] as Tanks).xy.X + 6)
                                    return false;
                                break;
                        }

                    }

                }
            }

            return true;
        }

    }

    public class RedTank : Tanks
    {
        private Random rand;

        static Sprite texture = new Sprite("Textures\\redtank.png", 16, 32);

        public int shotTimer = 5;
        private int go = 0, goX = 0, goY = 0;

        private int seeEnemy = 0;
        private int stopToShot = 0;
        int nextStep;
        int dX = 2, dY = 2;
        int justShot = 0;
        public RedTank(Battlefield field1, int x1, int y1)
            : base(field1, x1, y1)
        {
            health = 10 + 5 * (MenuForm.difficultySet);
            speed = 1;
            gunSpeed = 10;
            rand = new Random(cellX * cellY);
            side = 2;
            go = rand.Next(0, 32);
            curFrame = 0;

        }
        public override void Go()
        {
            if (go == 0)
            {

                if (seeEnemy == 1)
                {
                    nextStep = -1;
                }
                else
                {

                    nextStep = tankAI();

                }
                switch (nextStep)
                {
                    case 1:
                        if (cellX < (field.cellsX - 1) && (((field.BlocksArr[cellY] as ArrayList)[cellX + 1] as Blocks).id == 1 || ((field.BlocksArr[cellY] as ArrayList)[cellX + 1] as Blocks).id == 5))
                        {
                            goX = speed;
                            goY = 0;
                            cellX++;
                            go = 32 / speed;

                            curFrame = (curFrame != 1 && curFrame != 5) ? 1 : curFrame;
                        }
                        break;

                    case 3:
                        if (cellX > 0 && (((field.BlocksArr[cellY] as ArrayList)[cellX - 1] as Blocks).id == 1 || ((field.BlocksArr[cellY] as ArrayList)[cellX - 1] as Blocks).id == 5))
                        {
                            goX = -speed;
                            goY = 0;
                            cellX--;
                            go = 32 / speed;

                            curFrame = (curFrame != 3 && curFrame != 7) ? 3 : curFrame;

                        }
                        break;
                    case 0:
                        if (cellY > 0 && (((field.BlocksArr[cellY - 1] as ArrayList)[cellX] as Blocks).id == 1 || ((field.BlocksArr[cellY - 1] as ArrayList)[cellX] as Blocks).id == 5))
                        {
                            goX = 0;
                            goY = -speed;
                            cellY--;
                            go = 32 / speed;

                            curFrame = (curFrame != 0 && curFrame != 4) ? 0 : curFrame;

                        }
                        break;
                    case 2:
                        if (cellY < (field.cellsY - 1) && (((field.BlocksArr[cellY + 1] as ArrayList)[cellX] as Blocks).id == 1 || ((field.BlocksArr[cellY + 1] as ArrayList)[cellX] as Blocks).id == 5))
                        {
                            goX = 0;
                            goY = speed;
                            cellY++;
                            go = 32 / speed;

                            curFrame = (curFrame != 2 && curFrame != 6) ? 2 : curFrame;
                        }
                        break;
                    case -1:
                        goX = 0;
                        goY = 0;
                        go = 30;

                        curFrame = rotation;

                        seeEnemy = 0;
                        stopToShot = 1;
                        break;
                }

            }
            else
            {
                if (seeEnemy == 0) { stopToShot = 0; }
                xy.X += goX;
                xy.Y += goY;
                go--;
            }

            if (nextStep != -1 && (goX != 0 || goY != 0))
            {
                anim++;
                if (anim == 5)
                {
                    if (curFrame < 4)
                    {
                        curFrame += 4;
                    }
                    else
                    {
                        curFrame -= 4;
                    }
                    anim = 0;
                }
            }

            field.gBuf.Graphics.DrawImage((texture.frames[(curFrame + frameD)] as Bitmap), xy);
        }

        int wall = 0;

        public override void ShotCheck()
        {
            if (shotTimer < 10 * gunSpeed)
            {
                shotTimer++;
            }

            if (field.playerTank.xy.X <= xy.X + 16 && field.playerTank.xy.X + 32 >= xy.X + 16)
            {
                int first, second;
                if (xy.Y < field.playerTank.xy.Y)
                {
                    first = xy.Y;
                    second = (field.playerTank.xy.Y + 16);
                    rotation = 2;
                }
                else
                {
                    first = (field.playerTank.xy.Y + 16);
                    second = xy.Y;
                    rotation = 0;
                }

                wall = 0;
                for (int i = (first / 32) + 1; i < (second / 32); i++)
                {
                    if (((field.BlocksArr[i] as ArrayList)[(xy.X + 16) / 32] as Blocks).id != 1 && ((field.BlocksArr[i] as ArrayList)[(xy.X + 16) / 32] as Blocks).id != 4 && ((field.BlocksArr[i] as ArrayList)[(xy.X + 16) / 32] as Blocks).id != 5)
                    {
                        wall = 1;
                        break;
                    }
                }

                if (wall == 0)
                {
                    seeEnemy = 1;
                    Shot();
                }

            }

            else if (field.playerTank.xy.Y <= xy.Y + 16 && field.playerTank.xy.Y + 32 >= xy.Y + 16)
            {

                int first, second;
                if (xy.X < field.playerTank.xy.X)
                {
                    first = xy.X;
                    second = (field.playerTank.xy.X + 16);
                    rotation = 1;
                }
                else
                {
                    first = (field.playerTank.xy.X + 16);
                    second = xy.X;
                    rotation = 3;
                }

                wall = 0;
                for (int i = (first / 32) + 1; i < (second / 32); i++)
                {
                    if (((field.BlocksArr[(xy.Y + 16) / 32] as ArrayList)[i] as Blocks).id != 1 && ((field.BlocksArr[(xy.Y + 16) / 32] as ArrayList)[i] as Blocks).id != 4 && ((field.BlocksArr[(xy.Y + 16) / 32] as ArrayList)[i] as Blocks).id != 5)
                    {
                        wall = 1;
                        break;
                    }
                }

                if (wall == 0)
                {
                    seeEnemy = 1;
                    Shot();
                }

            }

            if (justShot == 1)
            {
                seeEnemy = 1;
                justShot = 0;
                Shot();
            }

        }

        public void Shot()
        {
            if (shotTimer >= 10 * gunSpeed && stopToShot == 1)
            {
                field.BulletsArr.Add(new Bullet(field, this, bulletPower, bulletSpeed));
                shotTimer = 0;
                stopToShot = 0;
            }

        }

        protected int tankAI()
        {
            int next = -2;
            int loopFlag = 0;

            while (next == -2)
            {
                int[] fl = { 0, 0, 0, 0 };
                int way = 0;
                loopFlag++;
                if (loopFlag == 3)
                {
                    next = -1;
                    return next;
                }

                int dXf = cellX - field.greenFlag.xy.X / 32;
                int dYf = cellY - field.greenFlag.xy.Y / 32;
                int nn = rand.Next(100);

                if (dX == dXf && dY == dYf && Math.Abs(dXf) == 0 && Math.Abs(dYf) <= 2)
                {
                    if (nn < chanceArr[MenuForm.difficultySet, 0])
                    {
                        if (dYf < 0) rotation = 2;
                        else rotation = 0;
                        curFrame = rotation;
                        next = -1;
                        justShot = 1;
                    }
                    else target();
                }
                else if (dX == dXf && dY == dYf && Math.Abs(dXf) <= 2 && Math.Abs(dYf) == 0)
                {
                    if (nn < chanceArr[MenuForm.difficultySet, 0])
                    {
                        if (dXf < 0) rotation = 1;
                        else rotation = 3;
                        curFrame = rotation;
                        next = -1;
                        justShot = 1;
                    }
                    else target();
                }

                else if (!(Math.Abs(dX) == 0 && Math.Abs(dY) == 0))
                {
                    while ((fl[0] == 0 || fl[1] == 0 || fl[2] == 0 || fl[3] == 0) && way == 0)
                    {

                        switch (rand.Next(4))
                        {
                            case 0: if (dX > 0 && (cellX - 1) >= 0 && (((field.BlocksArr[cellY] as ArrayList)[cellX - 1] as Blocks).id == 1 || ((field.BlocksArr[cellY] as ArrayList)[cellX - 1] as Blocks).id == 5) && NoOtherTanks(3)) { next = 3; dX--; way = 1; }
                                else { fl[0] = 1; }
                                break;
                            case 1: if (dX < 0 && (cellX + 1) < field.cellsX && (((field.BlocksArr[cellY] as ArrayList)[cellX + 1] as Blocks).id == 1 || ((field.BlocksArr[cellY] as ArrayList)[cellX + 1] as Blocks).id == 5) && NoOtherTanks(1)) { next = 1; dX++; way = 1; }
                                else { fl[1] = 1; }
                                break;
                            case 2: if (dY > 0 && (cellY - 1) >= 0 && (((field.BlocksArr[cellY - 1] as ArrayList)[cellX] as Blocks).id == 1 || ((field.BlocksArr[cellY - 1] as ArrayList)[cellX] as Blocks).id == 5) && NoOtherTanks(0)) { next = 0; dY--; way = 1; }
                                else { fl[2] = 1; }
                                break;
                            case 3: if (dY < 0 && (cellY + 1) < field.cellsY && (((field.BlocksArr[cellY + 1] as ArrayList)[cellX] as Blocks).id == 1 || ((field.BlocksArr[cellY + 1] as ArrayList)[cellX] as Blocks).id == 5) && NoOtherTanks(2)) { next = 2; dY++; way = 1; }
                                else { fl[3] = 1; }
                                break;
                        }
                    }

                    if (way == 0)
                    {
                        int[] fl2 = { 0, 0, 0, 0 };
                        int n = rand.Next(100);
                        if (n < chanceArr[MenuForm.difficultySet, 1])
                        {
                            while ((fl2[0] == 0 || fl2[1] == 0 || fl2[2] == 0 || fl2[3] == 0) && way == 0)
                            {
                                switch (rand.Next(4))
                                {
                                    case 0: if ((cellX - 1) >= 0 && (((field.BlocksArr[cellY] as ArrayList)[cellX - 1] as Blocks).id == 3 || ((field.BlocksArr[cellY] as ArrayList)[cellX - 1] as Blocks).id == 2))
                                        {
                                            rotation = 3;
                                            curFrame = rotation;
                                            next = -1;
                                            way = 1;
                                            justShot = 1;
                                        }
                                        else { fl2[0] = 1; }
                                        break;
                                    case 1: if ((cellX + 1) < field.cellsX && (((field.BlocksArr[cellY] as ArrayList)[cellX + 1] as Blocks).id == 3 || ((field.BlocksArr[cellY] as ArrayList)[cellX + 1] as Blocks).id == 2))
                                        {
                                            rotation = 1;
                                            curFrame = rotation;
                                            next = -1;
                                            way = 1;
                                            justShot = 1;
                                        }
                                        else { fl2[1] = 1; }
                                        break;
                                    case 2: if ((cellY - 1) >= 0 && (((field.BlocksArr[cellY - 1] as ArrayList)[cellX] as Blocks).id == 3 || ((field.BlocksArr[cellY - 1] as ArrayList)[cellX] as Blocks).id == 2))
                                        {
                                            rotation = 0;
                                            curFrame = rotation;
                                            next = -1;
                                            way = 1;
                                            justShot = 1;
                                        }
                                        else { fl2[2] = 1; }
                                        break;
                                    case 3: if ((cellY + 1) < field.cellsY && (((field.BlocksArr[cellY + 1] as ArrayList)[cellX] as Blocks).id == 3 || ((field.BlocksArr[cellY + 1] as ArrayList)[cellX] as Blocks).id == 2))
                                        {
                                            rotation = 2;
                                            curFrame = rotation;
                                            next = -1;
                                            way = 1;
                                            justShot = 1;
                                        }
                                        else { fl2[3] = 1; }
                                        break;

                                }
                            }
                        }

                        if (way == 0) { target(); }
                    }

                }
                else
                {
                    target();
                }

            }

            return next;

        }

        override protected bool NoOtherTanks(int goSide)
        {
            if (MenuForm.collisionTanksSet == true)
            {
                for (int i = 0; i < field.TanksArr.Count; i++)
                {
                    if (this != field.TanksArr[i] as Tanks)
                    {
                        int xx = cellX, yy = cellY;
                        switch (goSide)
                        {
                            case 0: xx = cellX; yy = cellY - 1; break;
                            case 1: xx = cellX + 1; yy = cellY; break;
                            case 2: xx = cellX; yy = cellY + 1; break;
                            case 3: xx = cellX - 1; yy = cellY; break;
                        }
                        if (xx == (field.TanksArr[i] as Tanks).cellX && yy == (field.TanksArr[i] as Tanks).cellY)
                        {

                            return false;
                        }
                    }
                }
            }
            return true;
        }

        void target()
        {
            int n = rand.Next(100);

            if (n < chanceArr[MenuForm.difficultySet, 2])
            {
                dX = cellX - field.greenFlag.xy.X / 32;
                dY = cellY - field.greenFlag.xy.Y / 32;
            }
            else if (n < chanceArr[MenuForm.difficultySet, 3])
            {
                dX = cellX - field.playerTank.xy.X / 32;
                dY = cellY - field.playerTank.xy.Y / 32;
            }
            else if (n < chanceArr[MenuForm.difficultySet, 4] && field.BonusArr.Count > 0 && MenuForm.bonusesEnemySet == true)
            {
                int bon = rand.Next(field.BonusArr.Count);
                dX = cellX - (field.BonusArr[bon] as Bonus).xy.X / 32;
                dY = cellY - (field.BonusArr[bon] as Bonus).xy.Y / 32;
            }
            else
            {
                dX = cellX - rand.Next(field.cellsX);
                dY = cellY - rand.Next(field.cellsY);
            }
        }

        int[,] chanceArr = {{60, 60, 25, 50, 70},
                                {75, 75, 40, 65, 85},
                                {90, 90, 55, 80, 100}};

        protected override void BonusEffect(int myBonus)
        {

            if (MenuForm.bonusesEnemySet == true)
            {
                switch (myBonus)
                {
                    case 1:

                        field.curGame.redLifes++;
                        break;
                    case 2: speed = 2;

                        break;
                    case 3: gunSpeed = 2;
                        break;
                    case 4: bulletPower = 10;
                        break;
                    case 5: bulletSpeed = 8;
                        break;
                    case 6: field.Defend(side);
                        break;
                }
            }
        }
    }

    public class KilledEventArgs : EventArgs
    {
        public int side;
        public KilledEventArgs(int side0)
        {
            side = side0;
        }
    }

}
