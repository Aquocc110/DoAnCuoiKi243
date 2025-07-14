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
using System.IO;
using GiangVien = QuanLiSinhVien.DatabaseHelper.GiangVien;
namespace DoAnCuoiKi242
{
    public partial class ChinhSuaThongTinGiangVien : Form
    {
        private GiangVien giangVien;
        private ThongTinGiangVien thongTinGV; // Để cập nhật lại form xem hồ sơ sau khi lưu
        public ChinhSuaThongTinGiangVien(GiangVien gv, ThongTinGiangVien thongTin)
        {
            InitializeComponent();
            this.giangVien = gv;
            this.thongTinGV = thongTin;
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            txtMaGV.Text = giangVien.MaGV;
            txtHoTen.Text = giangVien.HoTen;
            txtNgaySinh.Text = giangVien.NgaySinh.ToString("dd/MM/yyyy");
            txtGioiTinh.Text = giangVien.GioiTinh ? "Nam" : "Nữ";
            txtDienThoai.Text = giangVien.DienThoai;
            txtEmail.Text = giangVien.Email;
            txtDanToc.Text=giangVien.DanToc;
            txtTonGiao.Text=giangVien.TonGiao;

            if (!string.IsNullOrEmpty(giangVien.Picture) && File.Exists(giangVien.Picture))
            {
                pictureBox1.Image = Image.FromFile(giangVien.Picture);
            }
            else
            {

            }
        }

        private void ChinhSuaThongTinGiangVien_Load(object sender, EventArgs e)
        {
            LoadThongTin();

        }

        private void bttnLuu_Click(object sender, EventArgs e)
        {
            giangVien.HoTen = txtHoTen.Text;
            if (DateTime.TryParse(txtNgaySinh.Text, out DateTime ngaySinhMoi))
            {
                giangVien.NgaySinh = ngaySinhMoi;
            }
            else
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            giangVien.DienThoai = txtDienThoai.Text;

            // **Debug: Kiểm tra trước khi cập nhật**
            Console.WriteLine($"Trước khi cập nhật: {giangVien.HoTen}, {giangVien.NgaySinh}, {giangVien.DienThoai}");

            bool capNhatThanhCong = DatabaseHelper.UpdateGiangVien(giangVien);

            if (capNhatThanhCong)
            {
                Console.WriteLine("Cập nhật thành công!");

                // **Lấy dữ liệu mới từ database**
                GiangVien gvMoi = DatabaseHelper.LayGiangVienBangMa(giangVien.MaGV);

                if (gvMoi != null)
                {
                    thongTinGV.CapNhatThongTin(gvMoi); // Cập nhật thông tin mới vào form xem hồ sơ
                }

                MessageBox.Show("Thông tin đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                Console.WriteLine("Cập nhật thất bại!");
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void giangVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.giangVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quanLiSinhVien1_DoAnCuoiKi242DataSet);

        }

        private void txtMaGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(filePath); // thay bằng đúng tên PictureBox bạn đang dùng
                giangVien.Picture = filePath; // cập nhật đường dẫn ảnh vào đối tượng
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
