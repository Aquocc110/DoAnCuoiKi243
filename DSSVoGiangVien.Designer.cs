namespace DoAnCuoiKi242
{
    partial class DSSVoGiangVien
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.quanLiSinhVien1_DoAnCuoiKi242DataSet = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSet();
            this.giangVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.giangVienTableAdapter = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter();
            this.tableAdapterManager = new DoAnCuoiKi242.QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnXoa = new System.Windows.Forms.Button();
            maGVLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // maGVLabel
            // 
            maGVLabel.AutoSize = true;
            maGVLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            maGVLabel.Location = new System.Drawing.Point(56, 5);
            maGVLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            maGVLabel.Name = "maGVLabel";
            maGVLabel.Size = new System.Drawing.Size(118, 21);
            maGVLabel.TabIndex = 3;
            maGVLabel.Text = "Danh sách lớp";
            maGVLabel.Click += new System.EventHandler(this.maGVLabel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 28);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(845, 192);
            this.dataGridView1.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(733, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "Đạo đức - Ý chí - Sáng tạo";
            // 
            // bttnXoa
            // 
            this.bttnXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnXoa.Location = new System.Drawing.Point(60, 253);
            this.bttnXoa.Name = "bttnXoa";
            this.bttnXoa.Size = new System.Drawing.Size(82, 28);
            this.bttnXoa.TabIndex = 51;
            this.bttnXoa.Text = "Xóa";
            this.bttnXoa.UseVisualStyleBackColor = true;
            this.bttnXoa.Click += new System.EventHandler(this.bttnXoa_Click);
            // 
            // DSSVoGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 459);
            this.Controls.Add(this.bttnXoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(maGVLabel);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DSSVoGiangVien";
            this.Text = "DSSVoGiangVien";
            this.Load += new System.EventHandler(this.DSSVoGiangVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiSinhVien1_DoAnCuoiKi242DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giangVienBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSet quanLiSinhVien1_DoAnCuoiKi242DataSet;
        private System.Windows.Forms.BindingSource giangVienBindingSource;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.GiangVienTableAdapter giangVienTableAdapter;
        private QuanLiSinhVien1_DoAnCuoiKi242DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttnXoa;
    }
}