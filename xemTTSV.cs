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
    public partial class xemTTSV : Form
    {
        private SinhVien sinhVien;
        public xemTTSV(SinhVien sv)
        {
            InitializeComponent();
            this.sinhVien = sv;
        }

        private void xemTTSV_Load(object sender, EventArgs e)
        {
            if (sinhVien != null)
            {
                txtHoTen.Text = sinhVien.HoTen ?? "";
                txtMaSV.Text = sinhVien.MaSV ?? "";
                txtNgaySInh.Text = sinhVien.NgaySinh.ToString("dd/MM/yyyy") ?? "";
                txtGioiTinh.Text = sinhVien.GioiTinh ? "Nam" : "Nữ";
                txtDiaChi.Text = sinhVien.DiaChi ?? "";
                txtDienThoai.Text = sinhVien.DienThoai ?? "";
                txtMaKhoa.Text = sinhVien.MaKhoa ?? "";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
