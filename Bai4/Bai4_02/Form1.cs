using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4_02
{
    public partial class Form1 : Form
    {
        public delegate void delPassData(int id, string name, int luong);

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        List<NhanVien> NV;

        private void Form1_Load(object sender, EventArgs e)
        {
            NV = new List<NhanVien>();

            NV.Add(new NhanVien(1, "Nguyen Van A", 1000));
            NV.Add(new NhanVien(2, "Nguyen Van B", 2000));

            dtgNhanVien.DataSource = NV;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.PassData = new delPassData(AddNhanVien);
            frm.Show();
        }

        public void AddNhanVien(int id, string name, int luong)
        {
            NV.Add(new NhanVien(id, name, luong));
            dtgNhanVien.DataSource = null; // Reset the DataSource to refresh the DataGridView
            dtgNhanVien.DataSource = NV;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.PassData = new delPassData(EditNhanVien);
            frm.Show();
        }

        public void EditNhanVien(int id, string name, int luong)
        {
            NhanVien nv = NV.FirstOrDefault(x => x.ID1 == id);
            if (nv != null)
            {
                nv.Name1 = name;
                nv.Luong1 = luong;
                dtgNhanVien.DataSource = null; // Reset the DataSource to refresh the DataGridView
                dtgNhanVien.DataSource = NV;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dtgNhanVien.SelectedRows.Count > 0)
            {
                int selectedIndex = dtgNhanVien.SelectedRows[0].Index;
                int id = int.Parse(dtgNhanVien[0, selectedIndex].Value.ToString());
                NhanVien nv = NV.FirstOrDefault(x => x.ID1 == id);
                if (nv != null)
                {
                    NV.Remove(nv);
                    dtgNhanVien.DataSource = null; // Reset the DataSource to refresh the DataGridView
                    dtgNhanVien.DataSource = NV;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đóng hay không?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
