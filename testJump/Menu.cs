using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testJump
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            buttonPlay.Parent = pictureBox14;
            buttonOptions.Parent = pictureBox14;
            pictureBox13.Parent = pictureBox14;
            buttonScores.Parent = pictureBox14;
            pictureBox1.Parent = pictureBox14;
            pictureBox2.Parent = pictureBox14;
            pictureBox3.Parent = pictureBox14;
            pictureBox4.Parent = pictureBox14;
            pictureBox5.Parent = pictureBox14;
            pictureBox6.Parent = pictureBox14;
            pictureBox7.Parent = pictureBox14;
            pictureBox8.Parent = pictureBox14;
            pictureBox9.Parent = pictureBox14;
            pictureBox10.Parent = pictureBox14;
            pictureBox11.Parent = pictureBox14;
            pictureBox12.Parent = pictureBox14;
        }

        private void buttonPlay_MouseHover(object sender, EventArgs e)
        {
            buttonPlay.Image = testJump.Properties.Resources.play_on_2x;
            buttonPlay.Invalidate();
        }

        private void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            buttonPlay.Image = testJump.Properties.Resources.play_2x;
            buttonPlay.Invalidate();
        }

        private void buttonPlay_MouseClick(object sender, MouseEventArgs e)
        {    
            Form1 frm = new Form1();
            frm.Show();
            frm.Refresh();
            Hide();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonOptions_MouseClick(object sender, MouseEventArgs e)
        {
            //Options opt = new Options();
            //opt.Show();
            //Hide();
        }

        private void buttonOptions_MouseLeave(object sender, EventArgs e)
        {
            buttonOptions.Image = testJump.Properties.Resources.options_2x;
            buttonOptions.Invalidate();
        }

        private void buttonScores_MouseClick(object sender, MouseEventArgs e)
        {
            testJump.Scores scr = new testJump.Scores();
            scr.Show();
            Hide();
            //CheckRecord.CheckForm = false;
        }

        private void buttonScores_MouseLeave(object sender, EventArgs e)
        {
            buttonScores.Image = testJump.Properties.Resources.score2x;
            buttonScores.Invalidate();
        }

        private void buttonOptions_MouseHover(object sender, EventArgs e)
        {
            buttonOptions.Image = testJump.Properties.Resources.options_on_2x;
            buttonOptions.Invalidate();
        }

        private void buttonScores_MouseHover(object sender, EventArgs e)
        {
            buttonScores.Image = testJump.Properties.Resources.scoreOn_2x;
            buttonScores.Invalidate();
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help h = new Help();
                h.Show();
                Hide();
            }

            if (e.KeyCode == Keys.F2)
            {
                About ab = new About();
                ab.Show();
                Hide();
            }
        }
    }
}
