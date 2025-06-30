using QuanLiSinhVien; // Thêm dòng này
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class ThongTinGiangVien : Form
    {
        private GiangVien giangVien;

        public ThongTinGiangVien(GiangVien gv)
        {
            InitializeComponent();
            this.giangVien = gv;
            LoadThongTin(); // Gọi phương thức load thông tin ngay khi khởi tạo
        }

        private void LoadThongTin()
        {
            txtMaGV.Text = giangVien.MaGV;
            txtHoTen.Text = giangVien.HoTen;
            txtNgaySinh.Text = giangVien.NgaySinh.ToString("dd/MM/yyyy");
            txtGioiTinh.Text = giangVien.GioiTinh ? "Nam" : "Nữ";
            txtDienThoai.Text = giangVien.DienThoai;
            txtEmail.Text = giangVien.Email;

            if (!string.IsNullOrEmpty(giangVien.Picture) && File.Exists(giangVien.Picture))
            {
                pictureBox1.Image = Image.FromFile(giangVien.Picture);
            }
            else
            {

            }

        }

        private void ThongTinGiangVien_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }


        // Thêm phương thức cập nhật thông tin (nếu cần)
        public void CapNhatThongTin(GiangVien gvMoi)
        {
            this.giangVien = gvMoi;
            LoadThongTin();
        }

        private void txtMaGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void giangVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.giangVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quanLiSinhVien1_DoAnCuoiKi242DataSet);

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}