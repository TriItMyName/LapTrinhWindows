using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5_02
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            RegisterShortcuts();
        }

        private void InitializeCustomComponents()
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbFonts.Items.Add(font.Name);
            }
            cmbFonts.SelectedItem = "Tahoma";

            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            foreach (int size in sizes)
            {
                cmbSize.Items.Add(size);
            }

            cmbSize.SelectedItem = 14;

            richTextBox1.Font = new Font("Tahoma", 14);

            cmbFonts.SelectedIndexChanged += (s, e) => UpdateFont();
            cmbSize.SelectedIndexChanged += (s, e) => UpdateFont();
        }

        private void UpdateFont()
        {
            if (cmbFonts.SelectedItem != null && cmbSize.SelectedItem != null)
            {
                string selectedFont = cmbFonts.SelectedItem.ToString();
                float selectedSize = Convert.ToSingle(cmbSize.SelectedItem);
                richTextBox1.Font = new Font(selectedFont, selectedSize);
            }
        }

        private void RegisterShortcuts()
        {
            this.KeyPreview = true;
            this.KeyDown += (sender, e) =>
            {
                if (e.Control && e.KeyCode == Keys.N)
                {
                    CreateTextToolStripMenuItem_Click(sender, e);
                    e.Handled = true;
                }
                else if (e.Control && e.KeyCode == Keys.O)
                {
                    OpenToolStripMenuItem_Click(sender, e);
                    e.Handled = true;
                }
                else if (e.Control && e.KeyCode == Keys.S)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                    e.Handled = true;
                }
            };
        }

        private void FormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.ShowApply = true;
            fontDialog.ShowEffects = true;
            fontDialog.ShowHelp = true;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
                richTextBox1.ForeColor = fontDialog.Color;
            }
        }

        private void CreateTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Font = new Font("Tahoma", 14);
            currentFilePath = null;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                richTextBox1.Text = System.IO.File.ReadAllText(currentFilePath);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath == null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        System.IO.File.WriteAllText(currentFilePath, richTextBox1.Text);
                        MessageBox.Show("File lưu thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFilePath);
                System.IO.File.WriteAllText(currentFilePath, richTextBox1.Text);
                MessageBox.Show("File lưu thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Font = new Font("Tahoma", 14);
            currentFilePath = null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (currentFilePath == null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        System.IO.File.WriteAllText(currentFilePath, richTextBox1.Text);
                        MessageBox.Show("File lưu thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFilePath);
                System.IO.File.WriteAllText(currentFilePath, richTextBox1.Text);
                MessageBox.Show("File lưu thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ToggleBold_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void ToggleItalic_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void ToggleUnderline_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;
                if (richTextBox1.SelectionFont.Style.HasFlag(style))
                {
                    newFontStyle = currentFont.Style & ~style;
                }
                else
                {
                    newFontStyle = currentFont.Style | style;
                }
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }
    }
}
