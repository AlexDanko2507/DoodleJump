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
    public partial class About : Form
    {
        Font myFont;
        public About()
        {
            InitializeComponent();
            FontLoad();
            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            label4.Font = myFont;
        }

        private void FontLoad()
        {
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Properties.Resources.DoodleJump);
            PrivateFontCollection custom_font = new PrivateFontCollection();
            custom_font.AddFontFile(fileName);
            myFont = new Font(custom_font.Families[0], 36F, System.Drawing.FontStyle.Bold);
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void About_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Menu mn = new Menu();
                mn.Show();
                Hide();
            }
        }
    }
}
