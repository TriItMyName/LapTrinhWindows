using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Bai6_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetSelectedRows(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvStudent.Rows.Count)
            {
                DataGridViewRow row = dgvStudent.Rows[rowIndex];

                txtID.Text = row.Cells["MSSV"].Value.ToString();
                txtName.Text = row.Cells["HoTen"].Value.ToString();
                txtAverageScore.Text = row.Cells["DTB"].Value.ToString();

                cmbFacuLty.SelectedItem = row.Cells["TenKhoa"].Value.ToString();
            }
        }

        private void ClearTextBox()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAverageScore.Text = "";
            cmbFacuLty.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-4RVSMBB;Initial Catalog=QL_SV;Integrated Security=True;TrustServerCertificate=True";
            string query = @"
                        SELECT sv.MSSV, sv.HoTen, sv.DTB, k.TenKhoa 
                        FROM SinhVien sv
                        JOIN Khoa k ON sv.MaKhoa = k.MaKhoa";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dgvStudent.Columns.Clear();
                dgvStudent.Columns.Add("MSSV", "MSSV");
                dgvStudent.Columns.Add("HoTen", "HoTen");
                dgvStudent.Columns.Add("DTB", "DTB");
                dgvStudent.Columns.Add("TenKhoa", "TenKhoa");

                foreach (DataRow row in dataTable.Rows)
                {
                    dgvStudent.Rows.Add(row["MSSV"], row["HoTen"], row["DTB"], row["TenKhoa"]);
                }
            }
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetSelectedRows(e.RowIndex);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-4RVSMBB;Initial Catalog=QL_SV;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO SinhVien (MSSV, HoTen, DTB, MaKhoa) VALUES (@MSSV, @HoTen, @DTB, (SELECT MaKhoa FROM Khoa WHERE TenKhoa = @TenKhoa))";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MSSV", txtID.Text);
                        command.Parameters.AddWithValue("@HoTen", txtName.Text);
                        command.Parameters.AddWithValue("@DTB", txtAverageScore.Text);
                        command.Parameters.AddWithValue("@TenKhoa", cmbFacuLty.SelectedItem.ToString());

                        command.ExecuteNonQuery();
                    }
                }

                Form1_Load(sender, e);
                MessageBox.Show("Thêm sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-4RVSMBB;Initial Catalog=QL_SV;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE SinhVien SET HoTen = @HoTen, DTB = @DTB, MaKhoa = (SELECT MaKhoa FROM Khoa WHERE TenKhoa = @TenKhoa) WHERE MSSV = @MSSV";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MSSV", txtID.Text);
                        command.Parameters.AddWithValue("@HoTen", txtName.Text);
                        command.Parameters.AddWithValue("@DTB", txtAverageScore.Text);
                        command.Parameters.AddWithValue("@TenKhoa", cmbFacuLty.SelectedItem.ToString());

                        command.ExecuteNonQuery();
                    }
                }

                Form1_Load(sender, e);
                MessageBox.Show("Cập nhật sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = "Data Source=DESKTOP-4RVSMBB;Initial Catalog=QL_SV;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM SinhVien WHERE MSSV = @MSSV";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MSSV", txtID.Text);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa Sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy Sinh viên.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
