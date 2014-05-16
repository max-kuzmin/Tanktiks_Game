using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks
{    public class Game
    {
        public int greenScore;
        public Battlefield curBF;
        public String lvl;
        public int lvlNum = 0;
        public int greenLifes;
        public int redLifes;

        public string[] singleLvls = { "lvl1.txt", "lvl2.txt", "lvl3.txt", "lvl4.txt", "lvl5.txt", "lvl6.txt", "lvl7.txt", "lvl8.txt" };
        Graphics g;
        BattleForm parForm;
        int changeLvlBlock = 0;
        public static int saveScores = 1;

        public Game(BattleForm parForm0, Graphics g0, string[] gameLvls)
        {
            parForm = parForm0;
            g = g0;
            greenLifes = 3;
            if (MenuForm.unlimEnemySet == true) redLifes = 999999;
            else redLifes = 7 * (MenuForm.difficultySet + 1);

            greenScore = 0;
            singleLvls = gameLvls;
            ChangeLvl();
        }

        public void Stop()
        {
            if (curBF != null) curBF.timer.Stop();
        }

        public void ChangeLvl()
        {
            if (curBF != null && curBF.endInfoTime == -1)
            {
                curBF.endInfoTime = 0;
                changeLvlBlock = 1;
            }
            else
            {

                if (curBF != null) Stop();
                lvl = singleLvls[lvlNum];
                try
                {
                    curBF = new Battlefield(g, this);
                }
                catch
                {
                    MessageBox.Show("Ошибка загрузки уровня.\nВозможно файл составлен неверно.");
                    parForm.CloseByForm(null, new EventArgs());
                    return;
                }
                parForm.ClientSize = new Size(curBF.cellsX * 32, curBF.cellsY * 32);
                curBF.Scale(parForm.DrawField.Width, parForm.DrawField.Height);
                parForm.SetDesktopLocation(Screen.PrimaryScreen.WorkingArea.Width / 2 - parForm.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - parForm.Height / 2);
                curBF.endInfoTime = -1;
                changeLvlBlock = 0;
            }
        }

        public void EndLvl(object sender, EndEventArgs e)
        {
            if (changeLvlBlock == 0)
            {
                if (e.side == 1)
                {
                    if ((lvlNum + 1) < singleLvls.Length)
                    {
                        lvlNum++;
                        ChangeLvl();
                        if (lvlNum != 0) greenScore += 10000;
                        redLifes = 7 * (MenuForm.difficultySet + 1);
                    }
                    else
                    {

                        ScoreForm f = new ScoreForm(1, greenScore);
                        f.goMenuBut.Click += parForm.CloseByForm;
                        parForm.Enabled = false;

                        f.FormClosing += parForm.EnableActivate;
                        f.Show();
                        f.Activate();
                        changeLvlBlock = 1;
                    }
                }
                else
                {

                    ScoreForm f = new ScoreForm(2, greenScore);
                    f.goMenuBut.Click += parForm.CloseByForm;

                    parForm.Enabled = false;
                    f.Show();
                    f.Activate();
                    f.FormClosing += parForm.EnableActivate;

                    changeLvlBlock = 1;

                }
            }
        }

    }
}