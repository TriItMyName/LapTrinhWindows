using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Filter = "Image Files|*.bmp;*.jpg";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                Form2 frm = new Form2(openf.FileName);
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
