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
    class Red : Platforms
    {

        public Red()
        {
            setSkin(Properties.Resources.red.Clone(new Rectangle(0, 0, 114, 30), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
            setHP(4);
        }

    }
}
