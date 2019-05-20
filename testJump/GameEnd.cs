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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace testJump
{
    public partial class GameEnd : Form
    {
        Font myFont;
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);
        string fileScores = "Scores.txt";
        string fileNames = "Names.txt";
        string[] scores;
        string[] names;

        public GameEnd()
        {
            InitializeComponent();
            FontLoad();
            buttonScores.Parent = pictureBox2;
            buttonResume.Parent = pictureBox2;
            buttonMenu.Parent = pictureBox2;
            pictureBox1.Parent = pictureBox2;
            yourscore.Parent = pictureBox2;
            highscore.Parent = pictureBox2;
            label3.Parent = pictureBox2;
            textBox1.Parent = pictureBox2;
            label1.Parent = pictureBox2;
            label2.Parent = pictureBox2;
            yourscore.Font = myFont;
            highscore.Font = myFont;
            label3.Font = myFont;
            label2.Font = myFont;
            textBox1.Font = myFont;
            label1.Font = myFont;
            textBox1.Text = "doodler";
            label2.Visible = false;
            textBox1.MaxLength = 10;
            if (CheckRecord.Value)
            {
                scores = File.ReadAllLines(fileScores);
                names = File.ReadAllLines(fileNames);
                yourscore.Text = "your score: " + scores[scores.Length - 1];
                if (Convert.ToInt32(scores[scores.Length - 1]) > Convert.ToInt32(scores[0]))
                    highscore.Text = "high score: " + scores[scores.Length - 1];
                else
                    highscore.Text = "high score: " + scores[0];
                if (CheckRecord.CheckBack)
                {
                    yourscore.Text = "your score: " + Convert.ToString(CheckRecord.Scores);
                    textBox1.Text = CheckRecord.Name;
                    label2.Text = textBox1.Text;
                    textBox1.Enabled = false;
                    label2.ForeColor = Color.Gray;
                }
                textBox1.Visible = true;
                label2.Visible = true;
            }
            else
            {
                yourscore.Visible = false;
                highscore.Visible = false;
                label3.Visible = false;
                textBox1.Visible = false;
                label1.Visible = true;
            }
        }

        private void GameEnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Swap(string[] s, int i, int j)
        {
            string glass = s[i];
            s[i] = s[j];
            s[j] = glass;
        }

        private void ShakerSort(string[] s, string[] n)
        {
            int left = 0,
                right = s.Length - 1,
                count = 0;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (Convert.ToInt32(s[i]) < Convert.ToInt32(s[i + 1]))
                    {
                        Swap(s, i, i + 1);
                        Swap(n, i, i + 1);
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (Convert.ToInt32(s[i - 1]) < Convert.ToInt32(s[i]))
                    {
                        Swap(s, i - 1, i);
                        Swap(n, i - 1, i);
                    }
                }
                left++;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Enabled = false;
                names[names.Length - 1] = textBox1.Text;
                ShakerSort(scores, names);
                File.WriteAllLines(fileScores, scores);
                File.WriteAllLines(fileNames, names);
                CheckRecord.Name = textBox1.Text;
                CheckRecord.CheckBack = true;
                label2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label2.Text = " ";
            }
            else
            {
                label2.Text = textBox1.Text;
            }
            if (textBox1.Text.Length == 10)
                HideCaret(textBox1.Handle);
            else
                ShowCaret(textBox1.Handle);
        }

        private void buttonMenu_MouseHover(object sender, EventArgs e)
        {
            buttonMenu.Image = Properties.Resources.menu_on_2x;
            buttonMenu.Invalidate();
        }

        private void buttonMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonMenu.Image = Properties.Resources.menu_2x;
            buttonMenu.Invalidate();
        }

        private void buttonResume_MouseHover(object sender, EventArgs e)
        {
            buttonResume.Image = Properties.Resources.play_again_on_2x;
            buttonResume.Invalidate();
        }

        private void buttonResume_MouseLeave(object sender, EventArgs e)
        {
            buttonResume.Image = Properties.Resources.play_again_2x;
            buttonResume.Invalidate();
        }

        private void buttonMenu_MouseClick(object sender, MouseEventArgs e)
        {
            CheckRecord.CheckBack = false;
            Menu mn = new Menu();
            mn.Show();
            Hide();
        }

        private void buttonResume_MouseClick(object sender, MouseEventArgs e)
        {
            CheckRecord.CheckBack = false;
            Form1 frm = new Form1();
            frm.Show();
            Hide();
        }

        private void FontLoad()
        {
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Properties.Resources.DoodleJump);
            PrivateFontCollection custom_font = new PrivateFontCollection();
            custom_font.AddFontFile(fileName);
            myFont = new Font(custom_font.Families[0], 28F, System.Drawing.FontStyle.Bold);
        }

        private void buttonScores_MouseHover(object sender, EventArgs e)
        {
            buttonScores.Image = Properties.Resources.scoreOn_2x;
            buttonScores.Invalidate();
        }

        private void buttonScores_MouseLeave(object sender, EventArgs e)
        {
            buttonScores.Image = Properties.Resources.score2x;
            buttonScores.Invalidate();
        }

        private void buttonScores_MouseClick(object sender, MouseEventArgs e)
        {
            Scores scr = new Scores();
            scr.Show();
            Hide();
            CheckRecord.CheckForm = true;
        }
    }
}
