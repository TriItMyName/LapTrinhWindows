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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnXuatTT_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string ngaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            string gioiTinh = cbNam.Checked ? "Nam" : cbNu.Checked ? "Nữ" : "Không xác định";

            List<string> soThichList = new List<string>();
            if (cbSoThich1.Checked) soThichList.Add(cbSoThich1.Text);
            if (cbSoThich2.Checked) soThichList.Add(cbSoThich2.Text);
            if (cbSoThich3.Checked) soThichList.Add(cbSoThich3.Text);
            // Add more checkboxes as needed

            string soThich = string.Join(", ", soThichList);

            string thongTin = $"Họ tên: {hoTen}\nNgày sinh: {ngaySinh}\nGiới tính: {gioiTinh}\nSở thích: {soThich}";
            MessageBox.Show(thongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
