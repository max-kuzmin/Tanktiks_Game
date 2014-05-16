using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tanks
{    public partial class ScoreForm : Form
    {

        XmlSerializer serializer;
        TextWriter writer;
        FileStream reader;
        TopFile topScores;
        int score;
        int topPlace;

        public ScoreForm(int side, int score0)
        {

            InitializeComponent();

            score = score0;

            if (side == 2)
            {
                winLab.Text = "Вы проиграли!";
                winLab.ForeColor = Color.Red;
            }
            else
            {
                winLab.Text = "Вы победили!";
                winLab.ForeColor = Color.Blue;
            }
            scoreLab.Text = "Счет игры: " + score.ToString();

            if (Game.saveScores == 1)
            {
                try
                {
                    serializer = new XmlSerializer(typeof(TopFile));
                    reader = new FileStream("TopScores.xml", FileMode.Open);
                    topScores = serializer.Deserialize(reader) as TopFile;
                    reader.Close();
                }
                catch
                {
                    topScores = new TopFile();
                    writer = new StreamWriter("TopScores.xml");
                    serializer.Serialize(writer, topScores);
                    writer.Close();
                }

                for (int i = 0; i < 10; i++)
                {
                    if (score >= topScores.scores[i])
                    {
                        topPlace = i;
                        cancelBut.Click += AddTop;
                        goMenuBut.Click += AddTop;
                        winLab.Text += " Лучший счет!";
                        nameBox.Visible = true;
                        enterName.Visible = true;

                        for (int k = 9; k > i; k--)
                        {
                            topScores.scores[k] = topScores.scores[k - 1];
                            topScores.names[k] = topScores.names[k - 1];
                        }

                        break;
                    }
                }
            }

        }

        string tempText = "Игрок";

        private void AddTop(object sender, EventArgs e)
        {
            writer = new StreamWriter("TopScores.xml");
            topScores.names[topPlace] = tempText.Normalize();
            topScores.scores[topPlace] = score;

            serializer.Serialize(writer, topScores);

            writer.Close();

        }

        private void goMenuBut_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            tempText = nameBox.Text;
        }

    }
}