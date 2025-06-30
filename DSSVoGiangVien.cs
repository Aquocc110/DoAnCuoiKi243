using QuanLiSinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class DSSVoGiangVien : Form
    {
        private GiangVien giangVien;
        private DatabaseHelper databaseHelper;
        public DSSVoGiangVien(GiangVien gv)
        {
            InitializeComponent();
            this.giangVien = gv;
            this.databaseHelper = new DatabaseHelper();
            LoadDanhSachSinhVien(giangVien.MaGV);
            ConfigureDataGridView();
        }
        private void ConfigureDataGridView()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void DSSVoGiangVien_Load(object sender, EventArgs e)
        {
            string maGV = giangVien.MaGV;
            LoadDanhSachSinhVien(maGV);
            LoadThongTin();
            // Tùy chỉnh giao diện DataGridView dataGridView1
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["MaSV"].Width = 60; 
            dataGridView1.Columns["HoTen"].Width = 140;
            dataGridView1.Columns["Email"].Width = 160;
            
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.GridColor = Color.Black; 
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single; 

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.RowTemplate.MinimumHeight = 32;
        }
        private void LoadDanhSachSinhVien(string maGV)
        {
            DataTable dtSinhVien = DatabaseHelper.GetSinhVienTheoKhoa(maGV);

            if (dtSinhVien.Rows.Count > 0)
            {
                // Thêm cột hiển thị giới tính
                if (!dtSinhVien.Columns.Contains("GioiTinhHienThi"))
                    dtSinhVien.Columns.Add("GioiTinhHienThi", typeof(string));

                foreach (DataRow row in dtSinhVien.Rows)
                {
                    int gioiTinh = Convert.ToInt32(row["GioiTinh"]);
                    row["GioiTinhHienThi"] = (gioiTinh == 0) ? "Nữ" : "Nam";
                }

                dataGridView1.DataSource = dtSinhVien;
                FormatDataGridView();
            }
            else
            {
                MessageBox.Show("Không có sinh viên nào thuộc khoa này!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
        }

        private void giangVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.giangVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quanLiSinhVien1_DoAnCuoiKi242DataSet);

        }
        private void FormatDataGridView()
        {
            dataGridView1.Columns["MaSV"].HeaderText = "Mã SV";
            dataGridView1.Columns["HoTen"].HeaderText = "Họ và tên";
            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["DienThoai"].HeaderText = "Điện thoại";

            // Ẩn cột gốc "GioiTinh" (kiểu số)
            if (dataGridView1.Columns.Contains("GioiTinh"))
                dataGridView1.Columns["GioiTinh"].Visible = false;

            // Cột hiển thị giới tính
            if (dataGridView1.Columns.Contains("GioiTinhHienThi"))
            {
                dataGridView1.Columns["GioiTinhHienThi"].HeaderText = "Giới tính (x = Nữ)";
                dataGridView1.Columns["GioiTinhHienThi"].DisplayIndex = dataGridView1.Columns["NgaySinh"].DisplayIndex + 1;
            }

            dataGridView1.Columns["TenKhoa"].HeaderText = "Khoa";



            // Canh giữa cột Ngày sinh và Giới tính
            if (dataGridView1.Columns.Contains("NgaySinh"))
                dataGridView1.Columns["NgaySinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dataGridView1.Columns.Contains("GioiTinhHienThi"))
                dataGridView1.Columns["GioiTinhHienThi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void maGVLabel_Click(object sender, EventArgs e)
        {

        }

        private void maGVTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadThongTin()
        {

        }

        private void bttnThem_Click(object sender, EventArgs e)
        {
            var formThem = new ThemSinhVien(giangVien.MaGV);
            formThem.ShowDialog();
            LoadDanhSachSinhVien(giangVien.MaGV); // Refresh sau khi thêm
        }


        private void bttnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã sinh viên từ dòng đang chọn
            string maSV = dataGridView1.SelectedRows[0].Cells["MaSV"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên có mã {maSV} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool daXoa = XoaSinhVien(maSV);
                if (daXoa)
                {
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
