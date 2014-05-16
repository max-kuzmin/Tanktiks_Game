using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Tanks
{    public partial class TopForm : Form
    {
        XmlSerializer serializer;
        FileStream reader;
        TopFile topScores;
        TextWriter writer;

        public TopForm()
        {
            InitializeComponent();

            serializer = new XmlSerializer(typeof(TopFile));
            try
            {
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
                ListViewItem item;
                if (topScores.names[i] != null)
                {
                    item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(topScores.names[i]);
                    item.SubItems.Add(topScores.scores[i].ToString());
                }
                else
                {
                    item = new ListViewItem("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                }
                listTop.Items.Add(item);
            }

        }

        private void TopOk_Click(object sender, EventArgs e)
        {

            Close();
        }
    }

    public class TopFile
    {
        public string[] names;
        public int[] scores;

        public TopFile()
        {
            names = new string[10];
            scores = new int[10];
        }

    }
}