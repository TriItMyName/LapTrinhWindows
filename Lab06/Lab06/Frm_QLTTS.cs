using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab06.Model;

namespace Lab06
{
    public partial class Frm_QLTTS : Form
    {
        private string defualtSreachText = "Tìm Kiếm Theo Tên/Mã sách";

        private Model_LibraryManager context;

        public Frm_QLTTS()
        {
            InitializeComponent();
            context = new Model_LibraryManager();
        }

        private void Frm_QLTTS_Load(object sender, EventArgs e)
        {
            try
            {
                List<LoaiSach> loaiSaches = context.LoaiSaches.ToList();
                List<Sach> saches = context.Saches.ToList();
                FillFindLoaiSach(loaiSaches);
                BindGrid(saches);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFindLoaiSach(List<LoaiSach> listLoai)
        {
            listLoai = context.LoaiSaches.ToList();
            cmbTypeBock.DataSource = listLoai;
            cmbTypeBock.DisplayMember = "TenLoai";
            cmbTypeBock.ValueMember = "MaLoai";
            cmbTypeBock.SelectedIndex = -1;
        }

        private void BindGrid(List<Sach> listSach)
        {
            dgvListBock.Rows.Clear();
            foreach (Sach sach in listSach)
            {
                int index = dgvListBock.Rows.Add();
                dgvListBock.Rows[index].Cells[0].Value = sach.MaSach;
                dgvListBock.Rows[index].Cells[1].Value = sach.TenSach;
                dgvListBock.Rows[index].Cells[2].Value = sach.NamXB;
                dgvListBock.Rows[index].Cells[3].Value = sach.LoaiSach.TenLoai;
            }
        }

        private void ClearDate()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDate.Text = "";
            txtSearch.Text = defualtSreachText;
            txtSearch.ForeColor = Color.Gray;
            cmbTypeBock.SelectedIndex = -1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string textsearch = txtSearch.Text;
            SearchBockByNameOrID(textsearch);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == defualtSreachText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = defualtSreachText;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void SearchBockByNameOrID(string textsearch)
        {
            if (string.IsNullOrWhiteSpace(textsearch) || textsearch == defualtSreachText)
            {
                foreach (DataGridViewRow row in dgvListBock.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            foreach (DataGridViewRow row in dgvListBock.Rows)
            {
                if (row.IsNewRow) continue;

                bool isVisible = row.Cells[0].Value != null && row.Cells[0].Value.ToString().IndexOf(textsearch, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 row.Cells[1].Value != null && row.Cells[1].Value.ToString().IndexOf(textsearch, StringComparison.OrdinalIgnoreCase) >= 0;

                row.Visible = isVisible;
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListBock.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                    txtID.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                    txtName.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null)
                    txtDate.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != null)
                    cmbTypeBock.Text = row.Cells[3].Value.ToString();
            }
        }

        private bool IsVailidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtDate.Text) || cmbTypeBock.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsVailidateInput()) return;

                var bock = context.Saches.Find(txtID.Text);
                if (bock != null)
                {
                    MessageBox.Show("Mã sách đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Sach sach = new Sach()
                {
                    MaSach = txtID.Text,
                    TenSach = txtName.Text,
                    NamXB = int.Parse(txtDate.Text),
                    MaLoai = (int)cmbTypeBock.SelectedValue
                };

                context.Saches.Add(sach);
                context.SaveChanges();
                MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid(context.Saches.ToList());
                ClearDate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsVailidateInput()) return;

                var sach = context.Saches.Find(txtID.Text);
                if (sach != null)
                {
                    sach.TenSach = txtName.Text;
                    sach.NamXB = int.Parse(txtDate.Text);
                    sach.MaLoai = (int)cmbTypeBock.SelectedValue;

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.Saches.ToList());
                    ClearDate();
                }
                else
                {
                    MessageBox.Show("Mã sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var sach = context.Saches.Find(txtID.Text);

                if (sach != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No) return;

                    context.Saches.Remove(sach);
                    context.SaveChanges();
                    MessageBox.Show("Xóa sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.Saches.ToList());
                    ClearDate();
                }
                else
                {
                    MessageBox.Show("Mã sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearDate();
        }
    }
}
