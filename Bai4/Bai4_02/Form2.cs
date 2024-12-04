using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bai4_02
{
    public partial class Form2 : Form
    {
        public Form1.delPassData PassData { get; internal set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnAccpet_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id) && int.TryParse(txtLuong.Text, out int luong))
            {
                string name = txtName.Text;

                if (!string.IsNullOrWhiteSpace(name))
                {
                    PassData?.Invoke(id, name, luong);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên không hợp lê", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị số hợp lệ cho ID và Lương.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeline_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn từ chối đầu vào không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
