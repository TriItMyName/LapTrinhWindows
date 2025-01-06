using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL.Entities;

namespace _3Layer_S4
{
    public partial class Frm_QLSP : Form
    {
        private readonly SanPham sanPham = new SanPham();
        private readonly LoaiSanPham loaiSP = new LoaiSanPham();

        public Frm_QLSP()
        {
            InitializeComponent();
        }

        private void Frm_QLSP_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvLoaiSP);
                var listLoaiSP = loaiSP.GetAll();
                var listSanPham = sanPham.GetAll();
                FillFalcultyCombobox(listLoaiSP);
                BinhdGrid(listSanPham);
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFalcultyCombobox(List<LoaiSP> listloaiSP)
        {
            cboLoaiSP.DataSource = listloaiSP;
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";
            cboLoaiSP.SelectedIndex = -1;
        }

        private void BinhdGrid(List<Sanpham> listsanPhams)
        {
            dgvLoaiSP.Rows.Clear();
            foreach (var item in listsanPhams)
            {
                int index = dgvLoaiSP.Rows.Add();
                dgvLoaiSP.Rows[index].Cells[0].Value = item.MaSP;
                dgvLoaiSP.Rows[index].Cells[1].Value = item.TenSP;
                dgvLoaiSP.Rows[index].Cells[2].Value = item.Ngaynhap;
                dgvLoaiSP.Rows[index].Cells[3].Value = item.LoaiSP != null ? item.LoaiSP.TenLoai : "Unknown";
            }
        }

        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiSP.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(row.Cells[2].Value);
                cboLoaiSP.Text = row.Cells[3].Value.ToString();
            }
        }

        private void ClearInput()
        {
            txtID.Text = "";
            txtName.Text = "";
            dtpDate.Value = DateTime.Now;
            cboLoaiSP.SelectedIndex = -1;
        }

        private bool IsVailidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text) || cboLoaiSP.SelectedIndex == -1)
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

                var sp = sanPham.GetByID(txtID.Text);
                if (sp != null)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Sanpham sanpham = new Sanpham
                {
                    MaSP = txtID.Text,
                    TenSP = txtName.Text,
                    Ngaynhap = dtpDate.Value,
                    MaLoai = cboLoaiSP.SelectedValue.ToString()
                };

                sanPham.Add(sanpham);
                BinhdGrid(sanPham.GetAll());
                btnSave.Enabled = true;
                btnNoSave.Enabled = true;

                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                var sp = sanPham.GetByID(txtID.Text);
                if (sp == null)
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Sanpham sanpham = new Sanpham
                {
                    MaSP = txtID.Text,
                    TenSP = txtName.Text,
                    Ngaynhap = dtpDate.Value,
                    MaLoai = cboLoaiSP.SelectedValue.ToString()
                };

                sanPham.Update(sanpham);
                BinhdGrid(sanPham.GetAll());
                btnSave.Enabled = true;
                btnNoSave.Enabled = true;

                MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var sp = sanPham.GetByID(txtID.Text);

                if (sp != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.No) return;

                    sanPham.Delete(sp.MaSP);
                    BinhdGrid(sanPham.GetAll());
                    btnSave.Enabled = true;
                    btnNoSave.Enabled = true;

                    MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sanPham.Save();
                MessageBox.Show("Lưu thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                btnSave.Enabled = false;
                btnNoSave.Enabled = false;
                BinhdGrid(sanPham.GetAll());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Không lưu thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                btnSave.Enabled = false;
                btnNoSave.Enabled = false;
                BinhdGrid(sanPham.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            { 
                string search = txtSearch.Text;
                if (string.IsNullOrWhiteSpace(search))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var listSanPham = sanPham.GetAll().Where(p => p.TenSP.ToLower().Contains(search.ToLower())).ToList();

                if (listSanPham.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                BinhdGrid(listSanPham);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
