using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tanks
{    public partial class MenuForm : Form
    {
        BattleForm mainGameForm;

        XmlSerializer serializer;
        TextWriter writer;
        FileStream reader;
        SettingFile setting;
        SettingForm s;

        public static bool unlimEnemySet;
        public static int keysSet;
        public static bool bonusesEnemySet;
        public static bool collisionTanksSet;
        public static int difficultySet;
        public static bool collisionBulletsSet;

        public MenuForm()
        {
            InitializeComponent();
            mainGameForm = new BattleForm(this);

            try
            {
                serializer = new XmlSerializer(typeof(SettingFile));
                reader = new FileStream("Setting.xml", FileMode.Open);
                setting = serializer.Deserialize(reader) as SettingFile;
                reader.Close();
                SetSetting();
            }
            catch
            {
                if (reader != null) reader.Close();
                setting = new SettingFile();
                writer = new StreamWriter("Setting.xml");
                serializer.Serialize(writer, setting);
                writer.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            mainGameForm.Show();
            mainGameForm.NewSingleGame(0);
            Hide();
            mainGameForm.Activate();

        }

        private void topBut_Click(object sender, EventArgs e)
        {
            TopForm t = new TopForm();
            t.Show();
            t.Activate();
            Enabled = false;
            t.FormClosing += enableActivate;

        }

        private void enableActivate(object sender, EventArgs e)
        {
            Enabled = true;
            Activate();
        }

        private void loadLvlBut_Click(object sender, EventArgs e)
        {

            mainGameForm.NewSingleGame(1);

        }

        private void helpBut_Click(object sender, EventArgs e)
        {
            HelpForm f = new HelpForm();
            String appdir = Path.GetDirectoryName(Application.ExecutablePath);
            String myfile = Path.Combine(appdir, "help.html");
            f.helpContent.Url = new Uri("file:///" + myfile);
            f.Show();
        }

        private void UpdateSetting(object sender, EventArgs e)
        {
            serializer = new XmlSerializer(typeof(SettingFile));
            writer = new StreamWriter("Setting.xml");
            serializer.Serialize(writer, setting);
            writer.Close();

            SetSetting();

        }

        private void SetSetting()
        {
            unlimEnemySet = setting.unlimEnemy;
            keysSet = setting.keys;
            bonusesEnemySet = setting.bonusesEnemy;
            collisionTanksSet = setting.collisionTanks;
            difficultySet = setting.difficulty;
            collisionBulletsSet = setting.collisionBullets;
        }

        private void settingBut_Click(object sender, EventArgs e)
        {
            s = new SettingForm(setting);
            s.Show();
            Enabled = false;

            s.okBut.Click += UpdateSetting;
            s.FormClosing += enableActivate;
        }
    }
}