namespace DoAnCuoiKi242
{
    partial class frmMainGiangVien
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
            System.Windows.Forms.Label dienThoaiLabel;
            System.Windows.Forms.Label hoTenLabel;
            System.Windows.Forms.Label maGVLabel;
            System.Windows.Forms.Label emailLabel;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chỉnhSửaThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíLớpHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchSinhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thắcMắcSinhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngBáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tắtỨngDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTrangChu = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.maGVTextBox = new System.Windows.Forms.TextBox();
            this.giangVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSet();
            this.emailTextBox1 = new System.Windows.Forms.TextBox();
            this.dienThoaiTextBox = new System.Windows.Forms.TextBox();
            this.hoTenTextBox = new System.Windows.Forms.TextBox();
            this.giangVienTableAdapter = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter();
            this.tableAdapterManager = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager();
            dienThoaiLabel = new System.Windows.Forms.Label();
            hoTenLabel = new System.Windows.Forms.Label();
            maGVLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dienThoaiLabel
            // 
            dienThoaiLabel.AutoSize = true;
            dienThoaiLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dienThoaiLabel.Location = new System.Drawing.Point(388, 28);
            dienThoaiLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dienThoaiLabel.Name = "dienThoaiLabel";
            dienThoaiLabel.Size = new System.Drawing.Size(96, 23);
            dienThoaiLabel.TabIndex = 12;
            dienThoaiLabel.Text = "Điện Thoại:";
            // 
            // hoTenLabel
            // 
            hoTenLabel.AutoSize = true;
            hoTenLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hoTenLabel.Location = new System.Drawing.Point(82, 59);
            hoTenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            hoTenLabel.Name = "hoTenLabel";
            hoTenLabel.Size = new System.Drawing.Size(67, 23);
            hoTenLabel.TabIndex = 6;
            hoTenLabel.Text = "Họ Tên:";
            // 
            // maGVLabel
            // 
            maGVLabel.AutoSize = true;
            maGVLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            maGVLabel.Location = new System.Drawing.Point(82, 25);
            maGVLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            maGVLabel.Name = "maGVLabel";
            maGVLabel.Size = new System.Drawing.Size(117, 23);
            maGVLabel.TabIndex = 0;
            maGVLabel.Text = "Mã Giáo Viên:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.Location = new System.Drawing.Point(391, 61);
            emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(55, 23);
            emailLabel.TabIndex = 13;
            emailLabel.Text = "Email:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuStrip1.Font = new System.Drawing.Font("Sitka Heading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.quảnLíLớpHọcToolStripMenuItem,
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(902, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.chỉnhSửaThôngTinToolStripMenuItem});
            this.thôngTinCáNhânToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thôngTinCáNhânToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(173, 27);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân ";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(252, 28);
            this.trangChủToolStripMenuItem.Text = "Trang chủ ";
            this.trangChủToolStripMenuItem.Click += new System.EventHandler(this.trangChủToolStripMenuItem_Click);
            // 
            // chỉnhSửaThôngTinToolStripMenuItem
            // 
            this.chỉnhSửaThôngTinToolStripMenuItem.Name = "chỉnhSửaThôngTinToolStripMenuItem";
            this.chỉnhSửaThôngTinToolStripMenuItem.Size = new System.Drawing.Size(252, 28);
            this.chỉnhSửaThôngTinToolStripMenuItem.Text = "Chỉnh sửa thông tin";
            this.chỉnhSửaThôngTinToolStripMenuItem.Click += new System.EventHandler(this.chỉnhSửaThôngTinToolStripMenuItem_Click);
            // 
            // quảnLíLớpHọcToolStripMenuItem
            // 
            this.quảnLíLớpHọcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchSinhViênToolStripMenuItem,
            this.sửaĐiểmToolStripMenuItem,
            this.thắcMắcSinhViênToolStripMenuItem,
            this.thôngBáoToolStripMenuItem});
            this.quảnLíLớpHọcToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLíLớpHọcToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.quảnLíLớpHọcToolStripMenuItem.Name = "quảnLíLớpHọcToolStripMenuItem";
            this.quảnLíLớpHọcToolStripMenuItem.Size = new System.Drawing.Size(146, 27);
            this.quảnLíLớpHọcToolStripMenuItem.Text = "Quản lí lớp học";
            this.quảnLíLớpHọcToolStripMenuItem.Click += new System.EventHandler(this.quảnLíLớpHọcToolStripMenuItem_Click);
            // 
            // danhSáchSinhViênToolStripMenuItem
            // 
            this.danhSáchSinhViênToolStripMenuItem.Name = "danhSáchSinhViênToolStripMenuItem";
            this.danhSáchSinhViênToolStripMenuItem.Size = new System.Drawing.Size(250, 28);
            this.danhSáchSinhViênToolStripMenuItem.Text = "Danh sách sinh viên";
            this.danhSáchSinhViênToolStripMenuItem.Click += new System.EventHandler(this.danhSáchSinhViênToolStripMenuItem_Click);
            // 
            // sửaĐiểmToolStripMenuItem
            // 
            this.sửaĐiểmToolStripMenuItem.Name = "sửaĐiểmToolStripMenuItem";
            this.sửaĐiểmToolStripMenuItem.Size = new System.Drawing.Size(250, 28);
            this.sửaĐiểmToolStripMenuItem.Text = "Sửa điểm";
            this.sửaĐiểmToolStripMenuItem.Click += new System.EventHandler(this.sửaĐiểmToolStripMenuItem_Click);
            // 
            // thắcMắcSinhViênToolStripMenuItem
            // 
            this.thắcMắcSinhViênToolStripMenuItem.Name = "thắcMắcSinhViênToolStripMenuItem";
            this.thắcMắcSinhViênToolStripMenuItem.Size = new System.Drawing.Size(250, 28);
            this.thắcMắcSinhViênToolStripMenuItem.Text = "Thắc mắc sinh viên";
            this.thắcMắcSinhViênToolStripMenuItem.Click += new System.EventHandler(this.thắcMắcSinhViênToolStripMenuItem_Click);
            // 
            // thôngBáoToolStripMenuItem
            // 
            this.thôngBáoToolStripMenuItem.Name = "thôngBáoToolStripMenuItem";
            this.thôngBáoToolStripMenuItem.Size = new System.Drawing.Size(250, 28);
            this.thôngBáoToolStripMenuItem.Text = "Thông báo ";
            this.thôngBáoToolStripMenuItem.Click += new System.EventHandler(this.thôngBáoToolStripMenuItem_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.tắtỨngDụngToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(99, 27);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            this.hệThốngToolStripMenuItem.Click += new System.EventHandler(this.hệThốngToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(204, 28);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // tắtỨngDụngToolStripMenuItem
            // 
            this.tắtỨngDụngToolStripMenuItem.Name = "tắtỨngDụngToolStripMenuItem";
            this.tắtỨngDụngToolStripMenuItem.Size = new System.Drawing.Size(204, 28);
            this.tắtỨngDụngToolStripMenuItem.Text = "Tắt ứng dụng";
            this.tắtỨngDụngToolStripMenuItem.Click += new System.EventHandler(this.tắtỨngDụngToolStripMenuItem_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Navy;
            this.panelTop.Controls.Add(this.labelTrangChu);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 29);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(902, 43);
            this.panelTop.TabIndex = 1;
            // 
            // labelTrangChu
            // 
            this.labelTrangChu.AutoSize = true;
            this.labelTrangChu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrangChu.ForeColor = System.Drawing.Color.White;
            this.labelTrangChu.Location = new System.Drawing.Point(2, 10);
            this.labelTrangChu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTrangChu.Name = "labelTrangChu";
            this.labelTrangChu.Size = new System.Drawing.Size(238, 32);
            this.labelTrangChu.TabIndex = 0;
            this.labelTrangChu.Text = "Trang chủ giảng viên";
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Controls.Add(this.label1);
            this.panelBody.Controls.Add(this.pictureBox1);
            this.panelBody.Controls.Add(emailLabel);
            this.panelBody.Controls.Add(this.maGVTextBox);
            this.panelBody.Controls.Add(this.emailTextBox1);
            this.panelBody.Controls.Add(this.dienThoaiTextBox);
            this.panelBody.Controls.Add(maGVLabel);
            this.panelBody.Controls.Add(dienThoaiLabel);
            this.panelBody.Controls.Add(this.hoTenTextBox);
            this.panelBody.Controls.Add(hoTenLabel);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 72);
            this.panelBody.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(902, 387);
            this.panelBody.TabIndex = 2;
            this.panelBody.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBody_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(709, 370);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Giảng viên - Truyền lửa tri thức";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::DoAnCuoiKi242.Properties.Resources.vanlang;
            this.pictureBox1.Location = new System.Drawing.Point(176, 152);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(603, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // maGVTextBox
            // 
            this.maGVTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.maGVTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "MaGV", true));
            this.maGVTextBox.Enabled = false;
            this.maGVTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maGVTextBox.Location = new System.Drawing.Point(176, 25);
            this.maGVTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.maGVTextBox.Name = "maGVTextBox";
            this.maGVTextBox.Size = new System.Drawing.Size(185, 29);
            this.maGVTextBox.TabIndex = 1;
            this.maGVTextBox.TextChanged += new System.EventHandler(this.maGVTextBox_TextChanged);
            // 
            // giangVienBindingSource
            // 
            this.giangVienBindingSource.DataMember = "GiangVien";
            this.giangVienBindingSource.DataSource = this.quanLiSinhVien1_DoAnCuoiKi242DataSet;
            // 
            // quanLiSinhVien1_DoAnCuoiKi242DataSet
            // 
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet.DataSetName = "QuanLiSinhVien1_DoAnCuoiKi242DataSet";
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // emailTextBox1
            // 
            this.emailTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.emailTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "Email", true));
            this.emailTextBox1.Enabled = false;
            this.emailTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox1.Location = new System.Drawing.Point(465, 59);
            this.emailTextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.emailTextBox1.Name = "emailTextBox1";
            this.emailTextBox1.Size = new System.Drawing.Size(185, 29);
            this.emailTextBox1.TabIndex = 14;
            this.emailTextBox1.TextChanged += new System.EventHandler(this.emailTextBox1_TextChanged);
            // 
            // dienThoaiTextBox
            // 
            this.dienThoaiTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.dienThoaiTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "DienThoai", true));
            this.dienThoaiTextBox.Enabled = false;
            this.dienThoaiTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienThoaiTextBox.Location = new System.Drawing.Point(465, 25);
            this.dienThoaiTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dienThoaiTextBox.Name = "dienThoaiTextBox";
            this.dienThoaiTextBox.Size = new System.Drawing.Size(185, 29);
            this.dienThoaiTextBox.TabIndex = 13;
            // 
            // hoTenTextBox
            // 
            this.hoTenTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.hoTenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.giangVienBindingSource, "HoTen", true));
            this.hoTenTextBox.Enabled = false;
            this.hoTenTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoTenTextBox.Location = new System.Drawing.Point(176, 58);
            this.hoTenTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.hoTenTextBox.Name = "hoTenTextBox";
            this.hoTenTextBox.Size = new System.Drawing.Size(185, 29);
            this.hoTenTextBox.TabIndex = 7;
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
            // frmMainGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 459);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmMainGiangVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Giảng Viên";
            this.Load += new System.EventHandler(this.frmMainGiangVien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chỉnhSửaThôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíLớpHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchSinhViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tắtỨngDụngToolStripMenuItem;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTrangChu;
        private System.Windows.Forms.Panel panelBody;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSet quanLiSinhVien1_DoAnCuoiKi242DataSet;
        private System.Windows.Forms.BindingSource giangVienBindingSource;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter giangVienTableAdapter;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.TextBox dienThoaiTextBox;
        private System.Windows.Forms.TextBox hoTenTextBox;
        private System.Windows.Forms.TextBox maGVTextBox;
        private System.Windows.Forms.TextBox emailTextBox1;
        private System.Windows.Forms.ToolStripMenuItem thắcMắcSinhViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngBáoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}