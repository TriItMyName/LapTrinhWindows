using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string sdt = txtSDT.Text;

            ListViewItem item = new ListViewItem(ho);
            item.SubItems.Add(ten);
            item.SubItems.Add(sdt);

            lvDSSV.Items.Add(item);
        }

        private void lvDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lvDSSV.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDSSV.SelectedItems[0];
                selectedItem.Text = txtHo.Text;
                selectedItem.SubItems[1].Text = txtTen.Text;
                selectedItem.SubItems[2].Text = txtSDT.Text;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvDSSV.SelectedItems.Count > 0)
            {
                lvDSSV.Items.Remove(lvDSSV.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

