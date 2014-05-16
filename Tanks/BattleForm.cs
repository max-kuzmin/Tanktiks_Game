using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tanks
{    public partial class BattleForm : Form
    {

        Game curGame;

        public Graphics g;
        Form parentForm;

        public BattleForm(Form parentForm0)
        {
            InitializeComponent();
            parentForm = parentForm0;

            g = DrawField.CreateGraphics();

            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.Low;

        }

        public void NewSingleGame(int gameType)
        {
            if (curGame != null) curGame.Stop();
            if (gameType == 0)
            {
                string[] gameLvls = { "Levels\\lvl1.txt", "Levels\\lvl2.txt", "Levels\\lvl3.txt" };
                curGame = new Game(this, g, gameLvls);
                parentForm.Hide();
                Show();
                Activate();
                Game.saveScores = 1;
            }
            else if (gameType == 1)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = true;
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string[] gameLvls = open.FileNames;
                    curGame = new Game(this, g, gameLvls);
                    if (curGame.curBF != null)
                    {
                        parentForm.Hide();
                        Show();
                        Activate();
                    }
                }
                Game.saveScores = 0;

            }

        }

        private void DrawField_Click(object sender, EventArgs e)
        {

        }

        private void DrawField_Resize(object sender, EventArgs e)
        {
            if (curGame != null && curGame.curBF != null && DrawField.Width > 32 && DrawField.Height > 32)
            {
                curGame.curBF.Scale(DrawField.Width, DrawField.Height);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult d = MessageBox.Show("Завершить текущую игру?", "Подтвердите выход", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                curGame.Stop();
                Hide();
                parentForm.Show();
                parentForm.Activate();
            }

        }

        internal void CloseByForm(object sender, EventArgs e)
        {
            if (curGame != null) curGame.Stop();
            Hide();
            parentForm.Show();
            parentForm.Activate();

        }

        internal void EnableActivate(object sender, FormClosingEventArgs e)
        {
            Enabled = true;

        }

    }
}