using prjMDA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMDA
{
    public partial class MDA : Form
    {
        public MDA()
        {
            InitializeComponent();
            toolStrip1.Renderer = new MDASr();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
       {
            導演 f = new 導演();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            演員類 f = new 演員類();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //FormMain f = new FormMain();
            //f.MdiParent = this;
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();
            
        }
    }
}
