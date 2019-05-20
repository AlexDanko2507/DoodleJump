using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace testJump
{
    public partial class Scores : Form
    {
        Font myFont;
        Font myFont2;
        string fileScores = "Scores.txt";
        string fileNames = "Names.txt";
        string[] scores;
        string[] names;
        int xEnd = 400;
        int yStart = 145;

        public Scores()
        {
            InitializeComponent();
            FontLoad2();
            label1.Parent = pictureBox7;
            label2.Parent = pictureBox7;
            pictureBox3.Parent = pictureBox7;
            pictureBox4.Parent = pictureBox7;
            pictureBox5.Parent = pictureBox7;
            pictureBox6.Parent = pictureBox7;
            buttonCancel.Parent = pictureBox7;
            pictureBox1.Parent = pictureBox7;
            pictureBox2.Parent = pictureBox7;
            label1.Font = myFont2;
            label2.Font = myFont2;
            scores = File.ReadAllLines(fileScores);
            names = File.ReadAllLines(fileNames);
            FontLoad();
            printScores();
        }

        private void printScores()
        {
            int k = yStart;
            for (int i = 0; i < 10; i++)
            {
                if (Convert.ToInt32(scores[i]) != 0)
                {
                    createNames(k, Convert.ToString(i + 1) + ". " + names[i]);
                    createScores(xEnd, k, scores[i]);
                }
                else
                {
                    break;
                }
                k += 40;
            }
        }

        private void createNames(int y, string t)
        {
            Label lb = new Label();
            lb.Font = myFont;
            lb.AutoSize = true;
            lb.Left = 36;
            lb.Top = y;
            lb.Text = t;
            this.Controls.Add(lb);
            lb.Parent = pictureBox7;
            lb.BringToFront();   
            lb.BackColor = Color.Transparent;
        }

        private void createScores(int x, int y, string t)
        {
            Label lb1 = new Label();
            lb1.Font = myFont;
            lb1.AutoSize = true;
            lb1.Text = t;
            lb1.Left = x - lb1.PreferredWidth;
            lb1.Top = y;
            this.Controls.Add(lb1);
            lb1.Parent = pictureBox7;
            lb1.BringToFront(); 
            lb1.BackColor = Color.Transparent;
        }

        private void FontLoad()
        {
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Properties.Resources.DoodleJump);
            PrivateFontCollection custom_font = new PrivateFontCollection();
            custom_font.AddFontFile(fileName);
            myFont = new Font(custom_font.Families[0], 28F, System.Drawing.FontStyle.Bold);
        }

        private void FontLoad2()
        {
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Properties.Resources.DoodleJump);
            PrivateFontCollection custom_font = new PrivateFontCollection();
            custom_font.AddFontFile(fileName);
            myFont2 = new Font(custom_font.Families[0], 22.5F, System.Drawing.FontStyle.Bold);
        }

        private void Scores_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonCancel_MouseHover(object sender, EventArgs e)
        {
            buttonCancel.Image = Properties.Resources.cancel_on_2x;
            buttonCancel.Invalidate();
        }

        private void buttonCancel_MouseLeave(object sender, EventArgs e)
        {
            buttonCancel.Image = Properties.Resources.cancel_2x;
            buttonCancel.Invalidate();
        }

        private void buttonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CheckRecord.CheckForm)
            {
                Menu mn = new Menu();
                mn.Show();
                Hide();
            }
            else
            {
                GameEnd gm = new GameEnd();
                gm.Show();
                Hide();
            }
        }
    }
}
