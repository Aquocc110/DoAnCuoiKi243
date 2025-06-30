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
    public partial class ChinhSuaHoSo : Form
    {
        private GiangVien giangVien;
        private ThôngTinGV thongTinGV; // Để cập nhật lại form xem hồ sơ sau khi lưu
        public ChinhSuaHoSo(GiangVien gv, ThôngTinGV thongTin)
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
            txtMaMH.Text = giangVien.MaMH;
        }

        private void ChinhSuaHoSo_Load(object sender, EventArgs e)
        {

        }

        private void bttnLuu_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin giảng viên từ form chỉnh sửa
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

            // Cập nhật lại form xem hồ sơ
            thongTinGV.CapNhatThongTin(giangVien);

            MessageBox.Show("Thông tin đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Đóng form chỉnh sửa
        }
    }

}
