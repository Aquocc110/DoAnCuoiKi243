namespace DoAnCuoiKi242
{
    partial class ChinhSuaThongTinGiangVien
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label maGVLabel;
            System.Windows.Forms.Label hoTenLabel;
            System.Windows.Forms.Label ngaySinhLabel;
            System.Windows.Forms.Label gioiTinhLabel;
            System.Windows.Forms.Label dienThoaiLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.bttnLuu = new System.Windows.Forms.Button();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSet();
            this.giangVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.giangVienTableAdapter = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter();
            this.tableAdapterManager = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.bttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDanToc = new System.Windows.Forms.TextBox();
            this.txtTonGiao = new System.Windows.Forms.TextBox();
            maGVLabel = new System.Windows.Forms.Label();
            hoTenLabel = new System.Windows.Forms.Label();
            ngaySinhLabel = new System.Windows.Forms.Label();
            gioiTinhLabel = new System.Windows.Forms.Label();
            dienThoaiLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // maGVLabel
            // 
            maGVLabel.AutoSize = true;
            maGVLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            maGVLabel.Location = new System.Drawing.Point(237, 48);
            maGVLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            maGVLabel.Name = "maGVLabel";
            maGVLabel.Size = new System.Drawing.Size(73, 25);
            maGVLabel.TabIndex = 33;
            maGVLabel.Text = "Mã GV:";
            // 
            // hoTenLabel
            // 
            hoTenLabel.AutoSize = true;
            hoTenLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hoTenLabel.Location = new System.Drawing.Point(237, 84);
            hoTenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            hoTenLabel.Name = "hoTenLabel";
            hoTenLabel.Size = new System.Drawing.Size(74, 25);
            hoTenLabel.TabIndex = 35;
            hoTenLabel.Text = "Họ Tên:";
            // 
            // ngaySinhLabel
            // 
            ngaySinhLabel.AutoSize = true;
            ngaySinhLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ngaySinhLabel.Location = new System.Drawing.Point(237, 114);
            ngaySinhLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ngaySinhLabel.Name = "ngaySinhLabel";
            ngaySinhLabel.Size = new System.Drawing.Size(102, 25);
            ngaySinhLabel.TabIndex = 37;
            ngaySinhLabel.Text = "Ngày Sinh:";
            // 
            // gioiTinhLabel
            // 
            gioiTinhLabel.AutoSize = true;
            gioiTinhLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gioiTinhLabel.Location = new System.Drawing.Point(551, 45);
            gioiTinhLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            gioiTinhLabel.Name = "gioiTinhLabel";
            gioiTinhLabel.Size = new System.Drawing.Size(92, 25);
            gioiTinhLabel.TabIndex = 38;
            gioiTinhLabel.Text = "Giới Tính:";
            // 
            // dienThoaiLabel
            // 
            dienThoaiLabel.AutoSize = true;
            dienThoaiLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dienThoaiLabel.Location = new System.Drawing.Point(551, 85);
            dienThoaiLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dienThoaiLabel.Name = "dienThoaiLabel";
            dienThoaiLabel.Size = new System.Drawing.Size(107, 25);
            dienThoaiLabel.TabIndex = 39;
            dienThoaiLabel.Text = "Điện Thoại:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.Location = new System.Drawing.Point(551, 116);
            emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(62, 25);
            emailLabel.TabIndex = 45;
            emailLabel.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(237, 154);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 25);
            label2.TabIndex = 49;
            label2.Text = "Dân Tộc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(551, 154);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(86, 25);
            label3.TabIndex = 50;
            label3.Text = "Tôn Giáo";
            // 
            // bttnLuu
            // 
            this.bttnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bttnLuu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnLuu.ForeColor = System.Drawing.Color.White;
            this.bttnLuu.Location = new System.Drawing.Point(765, 221);
            this.bttnLuu.Margin = new System.Windows.Forms.Padding(2);
            this.bttnLuu.Name = "bttnLuu";
            this.bttnLuu.Size = new System.Drawing.Size(79, 39);
            this.bttnLuu.TabIndex = 43;
            this.bttnLuu.Text = "Lưu";
            this.bttnLuu.UseVisualStyleBackColor = false;
            this.bttnLuu.Click += new System.EventHandler(this.bttnLuu_Click);
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGioiTinh.Location = new System.Drawing.Point(636, 39);
            this.txtGioiTinh.Margin = new System.Windows.Forms.Padding(2);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(208, 32);
            this.txtGioiTinh.TabIndex = 42;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.Location = new System.Drawing.Point(321, 114);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(2);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(208, 32);
            this.txtNgaySinh.TabIndex = 41;
            // 
            // txtMaGV
            // 
            this.txtMaGV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGV.Location = new System.Drawing.Point(321, 39);
            this.txtMaGV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(208, 32);
            this.txtMaGV.TabIndex = 34;
            this.txtMaGV.TextChanged += new System.EventHandler(this.txtMaGV_TextChanged);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(321, 75);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(208, 32);
            this.txtHoTen.TabIndex = 36;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienThoai.Location = new System.Drawing.Point(636, 73);
            this.txtDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(208, 32);
            this.txtDienThoai.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DoAnCuoiKi242.Properties.Resources.tải_xuống__3_1;
            this.pictureBox1.Location = new System.Drawing.Point(30, 48);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // quanLiSinhVien1_DoAnCuoiKi242DataSet
            // 
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet.DataSetName = "QuanLiSinhVien1_DoAnCuoiKi242DataSet";
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // giangVienBindingSource
            // 
            this.giangVienBindingSource.DataMember = "GiangVien";
            this.giangVienBindingSource.DataSource = this.quanLiSinhVien1_DoAnCuoiKi242DataSet;
            // 
            // giangVienTableAdapter
            // 
            this.giangVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.GiangVienTableAdapter = this.giangVienTableAdapter;
            this.tableAdapterManager.KetQuaTableAdapter = null;
            this.tableAdapterManager.KhoaTableAdapter = null;
            this.tableAdapterManager.LichHocTableAdapter = null;
            this.tableAdapterManager.MonHocTableAdapter = null;
            this.tableAdapterManager.SinhVienTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "Email", true));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(636, 110);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 32);
            this.txtEmail.TabIndex = 46;
            // 
            // bttn
            // 
            this.bttn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bttn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn.ForeColor = System.Drawing.Color.White;
            this.bttn.Location = new System.Drawing.Point(64, 221);
            this.bttn.Margin = new System.Windows.Forms.Padding(2);
            this.bttn.Name = "bttn";
            this.bttn.Size = new System.Drawing.Size(90, 40);
            this.bttn.TabIndex = 47;
            this.bttn.Text = "Đổi ảnh";
            this.bttn.UseVisualStyleBackColor = false;
            this.bttn.Click += new System.EventHandler(this.bttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(733, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Đạo đức - Ý chí - Sáng tạo";
            // 
            // txtDanToc
            // 
            this.txtDanToc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanToc.Location = new System.Drawing.Point(321, 154);
            this.txtDanToc.Margin = new System.Windows.Forms.Padding(2);
            this.txtDanToc.Name = "txtDanToc";
            this.txtDanToc.Size = new System.Drawing.Size(208, 32);
            this.txtDanToc.TabIndex = 51;
            // 
            // txtTonGiao
            // 
            this.txtTonGiao.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTonGiao.Location = new System.Drawing.Point(636, 151);
            this.txtTonGiao.Margin = new System.Windows.Forms.Padding(2);
            this.txtTonGiao.Name = "txtTonGiao";
            this.txtTonGiao.Size = new System.Drawing.Size(208, 32);
            this.txtTonGiao.TabIndex = 52;
            // 
            // ChinhSuaThongTinGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 459);
            this.Controls.Add(this.txtTonGiao);
            this.Controls.Add(this.txtDanToc);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttn);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bttnLuu);
            this.Controls.Add(this.txtGioiTinh);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(maGVLabel);
            this.Controls.Add(this.txtMaGV);
            this.Controls.Add(hoTenLabel);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(ngaySinhLabel);
            this.Controls.Add(gioiTinhLabel);
            this.Controls.Add(dienThoaiLabel);
            this.Controls.Add(this.txtDienThoai);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChinhSuaThongTinGiangVien";
            this.Text = "ChinhSuaThongTinGiangVien";
            this.Load += new System.EventHandler(this.ChinhSuaThongTinGiangVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnLuu;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.PictureBox pictureBox1;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSet quanLiSinhVien1_DoAnCuoiKi242DataSet;
        private System.Windows.Forms.BindingSource giangVienBindingSource;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter giangVienTableAdapter;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button bttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanToc;
        private System.Windows.Forms.TextBox txtTonGiao;
    }
}