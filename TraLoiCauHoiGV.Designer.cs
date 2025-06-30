namespace DoAnCuoiKi242
{
    partial class TraLoiCauHoiGV
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
            this.dgvCauHoi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTraLoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTraLoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCauHoi = new System.Windows.Forms.Label();
            this.lblNgHoi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCauHoi
            // 
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCauHoi.Location = new System.Drawing.Point(75, 24);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.Size = new System.Drawing.Size(504, 175);
            this.dgvCauHoi.TabIndex = 0;
            this.dgvCauHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellClick);
            this.dgvCauHoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách câu hỏi";
            // 
            // btnTraLoi
            // 
            this.btnTraLoi.BackColor = System.Drawing.Color.Firebrick;
            this.btnTraLoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraLoi.ForeColor = System.Drawing.Color.White;
            this.btnTraLoi.Location = new System.Drawing.Point(488, 220);
            this.btnTraLoi.Name = "btnTraLoi";
            this.btnTraLoi.Size = new System.Drawing.Size(91, 43);
            this.btnTraLoi.TabIndex = 2;
            this.btnTraLoi.Text = "Trả lời";
            this.btnTraLoi.UseVisualStyleBackColor = false;
            this.btnTraLoi.Click += new System.EventHandler(this.btnTraLoi_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Firebrick;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(391, 220);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(91, 43);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTraLoi
            // 
            this.txtTraLoi.Location = new System.Drawing.Point(75, 220);
            this.txtTraLoi.Multiline = true;
            this.txtTraLoi.Name = "txtTraLoi";
            this.txtTraLoi.Size = new System.Drawing.Size(288, 43);
            this.txtTraLoi.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhập câu trả lời";
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCauHoi.Location = new System.Drawing.Point(677, 87);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(189, 68);
            this.lblCauHoi.TabIndex = 6;
            this.lblCauHoi.Click += new System.EventHandler(this.lblCauHoi_Click);
            // 
            // lblNgHoi
            // 
            this.lblNgHoi.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNgHoi.Location = new System.Drawing.Point(677, 28);
            this.lblNgHoi.Name = "lblNgHoi";
            this.lblNgHoi.Size = new System.Drawing.Size(189, 40);
            this.lblNgHoi.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(733, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Đạo đức - Ý chí - Sáng tạo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(677, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Người hỏi: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(677, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Chi tiết câu hỏi:";
            // 
            // TraLoiCauHoiGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 459);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNgHoi);
            this.Controls.Add(this.lblCauHoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTraLoi);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnTraLoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCauHoi);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TraLoiCauHoiGV";
            this.Text = "TraLoiCauHoiGV";
            this.Load += new System.EventHandler(this.TraLoiCauHoiGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCauHoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTraLoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTraLoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCauHoi;
        private System.Windows.Forms.Label lblNgHoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}