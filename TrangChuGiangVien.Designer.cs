namespace DoAnCuoiKi242
{
    partial class TrangChuGiangVien
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
            System.Windows.Forms.Label dienThoaiLabel;
            System.Windows.Forms.Label hoTenLabel;
            System.Windows.Forms.Label maGVLabel;
            System.Windows.Forms.Label emailLabel;
            this.dienThoaiTextBox = new System.Windows.Forms.TextBox();
            this.hoTenTextBox = new System.Windows.Forms.TextBox();
            this.maGVTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox1 = new System.Windows.Forms.TextBox();
            this.panelTop2 = new System.Windows.Forms.Panel();
            dienThoaiLabel = new System.Windows.Forms.Label();
            hoTenLabel = new System.Windows.Forms.Label();
            maGVLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            this.panelTop2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dienThoaiTextBox
            // 
            this.dienThoaiTextBox.Location = new System.Drawing.Point(514, 22);
            this.dienThoaiTextBox.Name = "dienThoaiTextBox";
            this.dienThoaiTextBox.Size = new System.Drawing.Size(200, 22);
            this.dienThoaiTextBox.TabIndex = 13;
            // 
            // dienThoaiLabel
            // 
            dienThoaiLabel.AutoSize = true;
            dienThoaiLabel.Location = new System.Drawing.Point(402, 25);
            dienThoaiLabel.Name = "dienThoaiLabel";
            dienThoaiLabel.Size = new System.Drawing.Size(72, 16);
            dienThoaiLabel.TabIndex = 12;
            dienThoaiLabel.Text = "Điện Thoại";
            // 
            // hoTenTextBox
            // 
            this.hoTenTextBox.Location = new System.Drawing.Point(165, 61);
            this.hoTenTextBox.Name = "hoTenTextBox";
            this.hoTenTextBox.Size = new System.Drawing.Size(200, 22);
            this.hoTenTextBox.TabIndex = 7;
            // 
            // hoTenLabel
            // 
            hoTenLabel.AutoSize = true;
            hoTenLabel.Location = new System.Drawing.Point(53, 64);
            hoTenLabel.Name = "hoTenLabel";
            hoTenLabel.Size = new System.Drawing.Size(52, 16);
            hoTenLabel.TabIndex = 6;
            hoTenLabel.Text = "Họ Tên";
            // 
            // maGVTextBox
            // 
            this.maGVTextBox.Location = new System.Drawing.Point(165, 19);
            this.maGVTextBox.Name = "maGVTextBox";
            this.maGVTextBox.Size = new System.Drawing.Size(200, 22);
            this.maGVTextBox.TabIndex = 1;
            // 
            // maGVLabel
            // 
            maGVLabel.AutoSize = true;
            maGVLabel.Location = new System.Drawing.Point(53, 22);
            maGVLabel.Name = "maGVLabel";
            maGVLabel.Size = new System.Drawing.Size(88, 16);
            maGVLabel.TabIndex = 0;
            maGVLabel.Text = "Mã Giáo Viên";
            // 
            // emailTextBox1
            // 
            this.emailTextBox1.Location = new System.Drawing.Point(514, 64);
            this.emailTextBox1.Name = "emailTextBox1";
            this.emailTextBox1.Size = new System.Drawing.Size(200, 22);
            this.emailTextBox1.TabIndex = 14;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(406, 67);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(44, 16);
            emailLabel.TabIndex = 13;
            emailLabel.Text = "Email:";
            // 
            // panelTop2
            // 
            this.panelTop2.Controls.Add(emailLabel);
            this.panelTop2.Controls.Add(this.emailTextBox1);
            this.panelTop2.Controls.Add(maGVLabel);
            this.panelTop2.Controls.Add(this.maGVTextBox);
            this.panelTop2.Controls.Add(hoTenLabel);
            this.panelTop2.Controls.Add(this.hoTenTextBox);
            this.panelTop2.Controls.Add(dienThoaiLabel);
            this.panelTop2.Controls.Add(this.dienThoaiTextBox);
            this.panelTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop2.Location = new System.Drawing.Point(0, 0);
            this.panelTop2.Name = "panelTop2";
            this.panelTop2.Size = new System.Drawing.Size(800, 108);
            this.panelTop2.TabIndex = 1;
            // 
            // TrangChuGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTop2);
            this.Name = "TrangChuGiangVien";
            this.Text = "TrangChuGiangVien";
            this.Load += new System.EventHandler(this.TrangChuGiangVien_Load);
            this.panelTop2.ResumeLayout(false);
            this.panelTop2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox dienThoaiTextBox;
        private System.Windows.Forms.TextBox hoTenTextBox;
        private System.Windows.Forms.TextBox maGVTextBox;
        private System.Windows.Forms.TextBox emailTextBox1;
        private System.Windows.Forms.Panel panelTop2;
    }
}