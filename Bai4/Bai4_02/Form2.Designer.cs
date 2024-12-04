namespace Bai4_02
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblID = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.lblLuong = new System.Windows.Forms.Label();
            this.btnAccpet = new System.Windows.Forms.Button();
            this.btnDeline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(39, 40);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(59, 23);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(139, 37);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(413, 22);
            this.txtId.TabIndex = 1;
            this.txtId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(39, 89);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Họ và Tên";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(139, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(413, 22);
            this.txtName.TabIndex = 3;
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(187, 148);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(365, 22);
            this.txtLuong.TabIndex = 4;
            // 
            // lblLuong
            // 
            this.lblLuong.Location = new System.Drawing.Point(39, 151);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(103, 23);
            this.lblLuong.TabIndex = 5;
            this.lblLuong.Text = "Lương Cơ Bản";
            // 
            // btnAccpet
            // 
            this.btnAccpet.Location = new System.Drawing.Point(66, 211);
            this.btnAccpet.Name = "btnAccpet";
            this.btnAccpet.Size = new System.Drawing.Size(99, 52);
            this.btnAccpet.TabIndex = 7;
            this.btnAccpet.Text = "Đồng ý";
            this.btnAccpet.UseVisualStyleBackColor = true;
            this.btnAccpet.Click += new System.EventHandler(this.btnAccpet_Click);
            // 
            // btnDeline
            // 
            this.btnDeline.Location = new System.Drawing.Point(453, 211);
            this.btnDeline.Name = "btnDeline";
            this.btnDeline.Size = new System.Drawing.Size(99, 52);
            this.btnDeline.TabIndex = 8;
            this.btnDeline.Text = "Từ Chối";
            this.btnDeline.UseVisualStyleBackColor = true;
            this.btnDeline.Click += new System.EventHandler(this.btnDeline_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 326);
            this.Controls.Add(this.btnDeline);
            this.Controls.Add(this.btnAccpet);
            this.Controls.Add(this.lblLuong);
            this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblID);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.Button btnAccpet;
        private System.Windows.Forms.Button btnDeline;
    }
}