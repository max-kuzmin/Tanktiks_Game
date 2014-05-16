using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Tanks
{    public class Battlefield
    {
        public int cellsX, cellsY;
        public Graphics g;
        public ArrayList BlocksArr = new ArrayList();
        public ArrayList TanksArr = new ArrayList();
        public ArrayList BulletsArr = new ArrayList();
        public ArrayList ExplArr = new ArrayList();
        public ArrayList BonusArr = new ArrayList();
        public ArrayList RedSpawnArr = new ArrayList();
        public ArrayList GreenSpawnArr = new ArrayList();

        int infoTime = 200;

        public GreenTank playerTank;
        public GreenFlag greenFlag;

        private int redSpawned;

        public Game curGame;
        public int endInfoTime = -1;

        public int[,] mapAI;

        public event EventHandler<EndEventArgs> EndEventHandler;

        public Timer timer = new Timer();

        Random bonusRand = new Random();
        int bonusTimer = 100;

        private BufferedGraphicsContext context = new BufferedGraphicsContext();
        public BufferedGraphics gBuf;

        [DllImport("USER32.dll")]
        static extern short GetAsyncKeyState(int keyCode);

        private void KeyDown(object sender, EventArgs e)
        {

            if (playerTank != null)
            {
                int keyCur = 0;

                if (MenuForm.keysSet == 0)
                {
                    if (GetAsyncKeyState(0x57) != 0) keyCur = 87;
                    else if (GetAsyncKeyState(0x41) != 0) keyCur = 65;
                    else if (GetAsyncKeyState(0x53) != 0) keyCur = 83;
                    else if (GetAsyncKeyState(0x44) != 0) keyCur = 68;
                }
                else
                {
                    if (GetAsyncKeyState(0x26) != 0) keyCur = 38;
                    else if (GetAsyncKeyState(0x25) != 0) keyCur = 37;
                    else if (GetAsyncKeyState(0x28) != 0) keyCur = 40;
                    else if (GetAsyncKeyState(0x27) != 0) keyCur = 39;
                }

                playerTank.goKey = keyCur;

                if (GetAsyncKeyState(0xA0) != 0 || GetAsyncKeyState(0xA1) != 0) curGame.curBF.playerTank.Shot();
            }
        }

        public Battlefield(Graphics field1, Game curGame0)
        {

            g = field1;
            curGame = curGame0;

            EndEventHandler += curGame.EndLvl;
            StreamReader file;

            file = File.OpenText(curGame.lvl);

            cellsX = Convert.ToInt32(file.ReadLine());
            cellsY = Convert.ToInt32(file.ReadLine());

            for (int y = 0; y < cellsY; y++)
            {
                BlocksArr.Add(new ArrayList());
                string textLVL = file.ReadLine();
                for (int x = 0; x < cellsX; x++)
                {
                    char letter = Char.ToUpper(textLVL[x]);
                    switch (letter)
                    {
                        case '.': (BlocksArr[y] as ArrayList).Add(new Grass(this, x, y)); break;
                        case 'B': (BlocksArr[y] as ArrayList).Add(new Brick(this, x, y)); break;
                        case 'S': (BlocksArr[y] as ArrayList).Add(new Stone(this, x, y)); break;
                        case 'W': (BlocksArr[y] as ArrayList).Add(new Water(this, x, y)); break;
                        case 'I': (BlocksArr[y] as ArrayList).Add(new Ice(this, x, y)); break;
                        case 'G':
                            var temp = new GreenSpawn(this, x, y);
                            (BlocksArr[y] as ArrayList).Add(temp);
                            GreenSpawnArr.Add(temp);
                            break;
                        case 'R':
                            var temp2 = new RedSpawn(this, x, y);
                            (BlocksArr[y] as ArrayList).Add(temp2);
                            RedSpawnArr.Add(temp2);
                            redSpawnNum++;
                            break;
                        case 'F': greenFlag = new GreenFlag(this, x, y);
                            (BlocksArr[y] as ArrayList).Add(greenFlag);

                            break;
                        default: throw new IOException();

                    }
                }
            }

            file.Close();

            if (greenFlag == null || RedSpawnArr == null || GreenSpawnArr == null)
            {
                throw new IOException();
            }

            redSpawned = RedSpawnArr.Count;

            gBuf = context.Allocate(g, new Rectangle(0, 0, cellsX * 32, cellsY * 32));

            Sprite.dpi = (int)g.DpiX;

            timer.Interval = 30;
            timer.Tick += new EventHandler(GetFrame);

            for (int i = 0; i < (int)(redSpawned - (2 - MenuForm.difficultySet) * redSpawned / 4); i++)
            {
                Point pos = (RedSpawnArr[redSpawnNext] as RedSpawn).xy;
                TanksArr.Add(new RedTank(this, pos.X / 32, pos.Y / 32));
                if (redSpawnNext < (redSpawnNum - 1)) redSpawnNext++;
                else redSpawnNext = 0;

            }

            Point pos2 = (GreenSpawnArr[0] as GreenSpawn).xy;
            playerTank = new GreenTank(this, pos2.X / 32, pos2.Y / 32);
            TanksArr.Add(playerTank);

            timer.Tick += KeyDown;

            timer.Start();

        }

        private int redSpawnNum = 0;
        private int redSpawnNext = 0;

        public void Scale(int sizeX, int sizeY)
        {

            float scaleX = (float)(sizeX / cellsX) / 32;
            float scaleY = (float)(sizeY / cellsY) / 32;

            gBuf = context.Allocate(g, new Rectangle(0, 0, sizeX / cellsX * cellsX, sizeY / cellsY * cellsY));

            gBuf.Graphics.ScaleTransform(scaleX, scaleY);

            gBuf.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            gBuf.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            gBuf.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            gBuf.Graphics.InterpolationMode = InterpolationMode.Low;

        }

        public void TankKilled(object sender, KilledEventArgs e)
        {
            if (e.side == 1)
            {
                curGame.greenLifes--;
                if (curGame.greenLifes <= 0)
                {
                    EndEventArgs e2 = new EndEventArgs(2);
                    EndEventHandler(this, e2);
                }
                else
                {
                    Point pos = (GreenSpawnArr[0] as GreenSpawn).xy;
                    playerTank = new GreenTank(this, pos.X / 32, pos.Y / 32);
                    TanksArr.Add(playerTank);
                }

            }

            else
            {
                curGame.greenScore += 100;
                curGame.redLifes--;
                if (curGame.redLifes <= 0)
                {

                    EndEventArgs e2 = new EndEventArgs(1);
                    EndEventHandler(this, e2);

                }
                else if (curGame.redLifes >= (int)(redSpawned - (2 - MenuForm.difficultySet) * redSpawned / 4))
                {
                    Point pos = (RedSpawnArr[redSpawnNext] as RedSpawn).xy;
                    TanksArr.Add(new RedTank(this, pos.X / 32, pos.Y / 32));
                    if (redSpawnNext < (redSpawnNum - 1)) redSpawnNext++;
                    else redSpawnNext = 0;

                }
            }

        }

        public void GetFrame(object source, EventArgs e)
        {

            gBuf.Render(g);

            bonusTimer--;

            if (bonusTimer == 0)
            {
                bonusTimer = 300;
                if (BonusArr.Count >= 3) BonusArr.RemoveAt(0);
                switch ((new Random()).Next(6))
                {
                    case 0: BonusArr.Add(new Health(this, bonusRand.Next(cellsX), bonusRand.Next(cellsY))); break;
                    case 1: BonusArr.Add(new Speed(this, bonusRand.Next(cellsX), bonusRand.Next(cellsY))); break;
                    case 2: BonusArr.Add(new GunSpeed(this, bonusRand.Next(cellsX), bonusRand.Next(cellsY))); break;
                    case 3: BonusArr.Add(new BulletPower(this, bonusRand.Next(cellsX), bonusRand.Next(cellsY))); break;
                    case 4: BonusArr.Add(new BulletSpeed(this, bonusRand.Next(cellsX), bonusRand.Next(cellsY))); break;
                    case 5: BonusArr.Add(new FlagDefend(this, bonusRand.Next(cellsX), bonusRand.Next(cellsY))); break;
                }
            }

            for (int i = 0; i < BlocksArr.Count; i++)
            {
                for (int j = 0; j < (BlocksArr[i] as ArrayList).Count; j++)
                {
                    ((BlocksArr[i] as ArrayList)[j] as Blocks).Show();
                }
            }

            for (int i = 0; i < TanksArr.Count; i++)
            {
                (TanksArr[i] as Tanks).Go();
                (TanksArr[i] as Tanks).ShotCheck();
            }
            for (int i = 0; i < BonusArr.Count; i++)
            {
                (BonusArr[i] as Bonus).Show();
            }
            for (int i = 0; i < BulletsArr.Count; i++)
            {
                (BulletsArr[i] as Bullet).Go();
            }
            for (int i = 0; i < ExplArr.Count; i++)
            {
                (ExplArr[i] as Explosion).Show();
            }

            DrawUI();
            if (infoTime > 0)
            {
                infoTime--;
                ShowLvlInfo(0);
            }

            if (endInfoTime >= 0)
            {
                endInfoTime++;
                ShowLvlInfo(1);
                if (endInfoTime >= 200) curGame.ChangeLvl();
            }

        }

        public void Defend(int side)
        {
            if (side == 1)
            {
                for (int xx = -1; xx <= 1; xx++)
                {
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        if ((xx != 0 || yy != 0) && (greenFlag.xy.X / 32 + xx) <= (cellsX - 1) && (greenFlag.xy.Y / 32 + yy) <= (cellsY - 1) && (greenFlag.xy.X / 32 + xx) >= 0 && (greenFlag.xy.Y / 32 + yy) >= 0)
                        {
                            Blocks b = ((BlocksArr[greenFlag.xy.Y / 32 + yy] as ArrayList)[greenFlag.xy.X / 32 + xx] as Blocks);
                            if (b.id == 1)
                            {
                                (BlocksArr[greenFlag.xy.Y / 32 + yy] as ArrayList)[greenFlag.xy.X / 32 + xx] = new Brick(this, greenFlag.xy.X / 32 + xx, greenFlag.xy.Y / 32 + yy);
                            }
                            else if (b.health > 0 && b.health < 20)
                                b.health = 15;
                            b.curFrame = 0;
                            {

                            }
                        }
                    }
                }
            }
            else
            {
                for (int xx = -1; xx <= 1; xx++)
                {
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        if ((xx != 0 || yy != 0) && (greenFlag.xy.X / 32 + xx) <= (cellsX - 1) && (greenFlag.xy.Y / 32 + yy) <= (cellsY - 1) && (greenFlag.xy.X / 32 + xx) >= 0 && (greenFlag.xy.Y / 32 + yy) >= 0)
                        {
                            Blocks b = ((BlocksArr[greenFlag.xy.Y / 32 + yy] as ArrayList)[greenFlag.xy.X / 32 + xx] as Blocks);
                            if (b.id == 3 || b.id == 2)
                            {
                                b.health = 1;
                                b.curFrame = 2;
                            }
                        }
                    }
                }
            }
        }

        public void DrawUI()
        {
            Color c = Color.FromArgb(96, 255, 255, 255);
            Font f = new Font("Helvetica", 25, FontStyle.Bold);
            Brush b = new SolidBrush(c);

            Point p = new Point(5, 5);
            String sScore = curGame.greenScore.ToString();
            String sHealth = "♥ˣ" + curGame.greenLifes.ToString();
            String sRed = "♠ˣ" + curGame.redLifes.ToString();

            gBuf.Graphics.DrawString(sScore, f, b, p);

            Point p2 = new Point(cellsX * 32 - 80, cellsY * 32 - 40);
            gBuf.Graphics.DrawString(sHealth, f, b, p2);

            Point p3 = new Point(cellsX * 32 - 90, 5);
            gBuf.Graphics.DrawString(sRed, f, b, p3);

        }

        public void ShowLvlInfo(int i)
        {
            Color c = Color.FromArgb(160, 0, 0, 0);
            Font f = new Font("Helvetica", 25, FontStyle.Bold);
            Brush b = new SolidBrush(c);

            Point p = new Point((cellsX * 32 - 180) / 2, (cellsY * 32 - 60) / 2);
            String sLvl = "УРОВЕНЬ " + (curGame.lvlNum + 1).ToString();
            String sWait = "УРОВЕНЬ ПРОЙДЕН";
            Point p2 = new Point((cellsX * 32 - 300) / 2, (cellsY * 32 - 60) / 2);

            if (i == 0)
            {
                gBuf.Graphics.DrawString(sLvl, f, b, p);
            }
            else
            {
                gBuf.Graphics.DrawString(sWait, f, b, p2);
            }

        }
    }

    public class EndEventArgs : EventArgs
    {
        public int side;
        public EndEventArgs(int side0)
        {
            side = side0;
        }
    }
}