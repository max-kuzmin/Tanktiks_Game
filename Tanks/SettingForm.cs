using System;
using System.Windows.Forms;

namespace Tanks
{    public partial class SettingForm : Form
    {
        public SettingFile settingNew;

        public SettingForm(SettingFile setting)
        {
            InitializeComponent();

            settingNew = setting;
            unlimRedBut.Checked = settingNew.unlimEnemy;
            if (settingNew.keys == 1) arrowsBut.Checked = true;
            else if (settingNew.keys == 0) wasdBut.Checked = true;
            bonusRedBut.Checked = settingNew.bonusesEnemy;
            collisionBut.Checked = settingNew.collisionTanks;
            if (settingNew.difficulty == 0) easyBut.Checked = true;
            else if (settingNew.difficulty == 1) normBut.Checked = true;
            else hardBut.Checked = true;
            checkBoxBullets.Checked = settingNew.collisionBullets;

        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okBut_Click(object sender, EventArgs e)
        {
            settingNew.unlimEnemy = unlimRedBut.Checked;
            if (arrowsBut.Checked == true) settingNew.keys = 1;
            else if (wasdBut.Checked == true) settingNew.keys = 0;

            settingNew.bonusesEnemy = bonusRedBut.Checked;
            settingNew.collisionTanks = collisionBut.Checked;
            if (easyBut.Checked == true) settingNew.difficulty = 0;
            else if (normBut.Checked == true) settingNew.difficulty = 1;
            else settingNew.difficulty = 2;

            settingNew.collisionBullets = checkBoxBullets.Checked;

            Close();
        }
    }

    public class SettingFile
    {
        public SettingFile() { }
        public int difficulty = 1;
        public int keys = 0;
        public bool unlimEnemy = false;
        public bool collisionTanks = true;
        public bool bonusesEnemy = true;
        public bool collisionBullets = true;
    }
}