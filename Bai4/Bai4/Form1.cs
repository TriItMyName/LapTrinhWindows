using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Form1 : Form
    {
        public delegate void delPassData(TextBox text);
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        List<Student> students = new List<Student>();
        private void Form1_Load(object sender, EventArgs e)
        {
            students = new List<Student>();

            students.Add(new Student { ID = 1, Name = "A", Age = 20 });
            students.Add(new Student { ID = 2, Name = "B", Age = 21 });
            students.Add(new Student { ID = 3, Name = "C", Age = 22 });

            dtgStudent.DataSource = students;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                ID = int.Parse(txtId.Text),
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text)
            };
            students.Add(student);
            dtgStudent.DataSource = new BindingList<Student>(students);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtgStudent.SelectedRows.Count > 0)
            {
                int selectedIndex = dtgStudent.SelectedRows[0].Index;
                int id = int.Parse(dtgStudent[0, selectedIndex].Value.ToString());

                Student student = students.FirstOrDefault(s => s.ID == id);
                if (student != null)
                {
                    student.Name = txtName.Text;
                    student.Age = int.Parse(txtAge.Text);
                    dtgStudent.DataSource = new BindingList<Student>(students);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgStudent.SelectedRows.Count > 0)
            {
                int selectedIndex = dtgStudent.SelectedRows[0].Index;
                int id = int.Parse(dtgStudent[0, selectedIndex].Value.ToString());

                Student student = students.FirstOrDefault(s => s.ID == id);
                if (student != null)
                {
                    students.Remove(student);
                    dtgStudent.DataSource = new BindingList<Student>(students);
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            delPassData del = new delPassData(frm.funData);
            del(this.txtName);
            frm.Show();
        }
    }
}
