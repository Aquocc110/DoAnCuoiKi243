namespace DoAnCuoiKi242
{
    partial class xemTTGV
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
            System.Windows.Forms.Label maMHLabel;
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSet();
            this.giangVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.giangVienTableAdapter = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter();
            this.tableAdapterManager = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.bttnLuu = new System.Windows.Forms.Button();
            maGVLabel = new System.Windows.Forms.Label();
            hoTenLabel = new System.Windows.Forms.Label();
            ngaySinhLabel = new System.Windows.Forms.Label();
            gioiTinhLabel = new System.Windows.Forms.Label();
            dienThoaiLabel = new System.Windows.Forms.Label();
            maMHLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // maGVLabel
            // 
            maGVLabel.AutoSize = true;
            maGVLabel.Location = new System.Drawing.Point(220, 115);
            maGVLabel.Name = "maGVLabel";
            maGVLabel.Size = new System.Drawing.Size(51, 16);
            maGVLabel.TabIndex = 1;
            maGVLabel.Text = "Ma GV:";
            // 
            // hoTenLabel
            // 
            hoTenLabel.AutoSize = true;
            hoTenLabel.Location = new System.Drawing.Point(220, 143);
            hoTenLabel.Name = "hoTenLabel";
            hoTenLabel.Size = new System.Drawing.Size(55, 16);
            hoTenLabel.TabIndex = 7;
            hoTenLabel.Text = "Ho Ten:";
            // 
            // ngaySinhLabel
            // 
            ngaySinhLabel.AutoSize = true;
            ngaySinhLabel.Location = new System.Drawing.Point(220, 172);
            ngaySinhLabel.Name = "ngaySinhLabel";
            ngaySinhLabel.Size = new System.Drawing.Size(72, 16);
            ngaySinhLabel.TabIndex = 9;
            ngaySinhLabel.Text = "Ngay Sinh:";
            // 
            // gioiTinhLabel
            // 
            gioiTinhLabel.AutoSize = true;
            gioiTinhLabel.Location = new System.Drawing.Point(220, 201);
            gioiTinhLabel.Name = "gioiTinhLabel";
            gioiTinhLabel.Size = new System.Drawing.Size(63, 16);
            gioiTinhLabel.TabIndex = 11;
            gioiTinhLabel.Text = "Gioi Tinh:";
            // 
            // dienThoaiLabel
            // 
            dienThoaiLabel.AutoSize = true;
            dienThoaiLabel.Location = new System.Drawing.Point(220, 229);
            dienThoaiLabel.Name = "dienThoaiLabel";
            dienThoaiLabel.Size = new System.Drawing.Size(76, 16);
            dienThoaiLabel.TabIndex = 13;
            dienThoaiLabel.Text = "Dien Thoai:";
            // 
            // maMHLabel
            // 
            maMHLabel.AutoSize = true;
            maMHLabel.Location = new System.Drawing.Point(220, 257);
            maMHLabel.Name = "maMHLabel";
            maMHLabel.Size = new System.Drawing.Size(53, 16);
            maMHLabel.TabIndex = 15;
            maMHLabel.Text = "Ma MH:";
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
            this.tableAdapterManager.LopHocTableAdapter = null;
            this.tableAdapterManager.MonHocTableAdapter = null;
            this.tableAdapterManager.SinhVienTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // txtMaGV
            // 
            this.txtMaGV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "MaGV", true));
            this.txtMaGV.Location = new System.Drawing.Point(332, 112);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(200, 22);
            this.txtMaGV.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "HoTen", true));
            this.txtHoTen.Location = new System.Drawing.Point(332, 140);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 22);
            this.txtHoTen.TabIndex = 8;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "DienThoai", true));
            this.txtDienThoai.Location = new System.Drawing.Point(332, 226);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(200, 22);
            this.txtDienThoai.TabIndex = 14;
            // 
            // txtMaMH
            // 
            this.txtMaMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "MaMH", true));
            this.txtMaMH.Location = new System.Drawing.Point(332, 254);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(200, 22);
            this.txtMaMH.TabIndex = 16;
            this.txtMaMH.TextChanged += new System.EventHandler(this.maMHTextBox_TextChanged);
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "HoTen", true));
            this.txtNgaySinh.Location = new System.Drawing.Point(332, 172);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(200, 22);
            this.txtNgaySinh.TabIndex = 17;
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "HoTen", true));
            this.txtGioiTinh.Location = new System.Drawing.Point(332, 201);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(200, 22);
            this.txtGioiTinh.TabIndex = 18;
            // 
            // bttnLuu
            // 
            this.bttnLuu.Location = new System.Drawing.Point(641, 339);
            this.bttnLuu.Name = "bttnLuu";
            this.bttnLuu.Size = new System.Drawing.Size(75, 23);
            this.bttnLuu.TabIndex = 19;
            this.bttnLuu.Text = "Lưu";
            this.bttnLuu.UseVisualStyleBackColor = true;
            // 
            // xemTTGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Controls.Add(maMHLabel);
            this.Controls.Add(this.txtMaMH);
            this.Name = "xemTTGV";
            this.Text = "xemTTGV";
            this.Load += new System.EventHandler(this.xemTTGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QuanLiSinhVien1_DoAnCuoiKi242DataSet quanLiSinhVien1_DoAnCuoiKi242DataSet;
        private System.Windows.Forms.BindingSource giangVienBindingSource;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter giangVienTableAdapter;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Button bttnLuu;
    }
}