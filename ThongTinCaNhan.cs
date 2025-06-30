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
    public partial class ThongTinCaNhan : Form
    {
        private SinhVien sinhVien;
        private string currentUsername;
        public static frmMainSinhVien Instance { get; private set; }
        public ThongTinCaNhan(SinhVien sv)
        {
            InitializeComponent();
            this.sinhVien = sv;
        }

        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            if (sinhVien != null)
            {
                currentUsername = sinhVien.TenDangNhap;

                txtHoTen.Text = sinhVien.HoTen;
                txtMaSV.Text = sinhVien.MaSV;
                txtNgaySInh.Text = sinhVien.NgaySinh.ToString("dd/MM/yyyy");
                txtGioiTinh.Text = sinhVien.GioiTinh ? "Nam" : "Nữ";
                txtDiaChi.Text = sinhVien.DiaChi;
                txtDienThoai.Text = sinhVien.DienThoai;
                txtMaKhoa.Text = sinhVien.MaKhoa ?? "";
                txtDanToc.Text = sinhVien.DanToc;
                txtEmail.Text = sinhVien.Email;
                txtTonGiao.Text = sinhVien.TonGiao ?? "";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

