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
    public partial class ThôngTinGV : Form
    {
        private GiangVien giangVien;
        public ThôngTinGV(GiangVien gv)
        {
            InitializeComponent();
            this.giangVien = gv; // Gán giảng viên
        }

        private void ThôngTinGV_Load(object sender, EventArgs e)
        {
            this.giangVienTableAdapter.Fill(this.quanLiSinhVien1_DoAnCuoiKi242DataSet.GiangVien);
             if (giangVien != null)
            {
                txtHoTen.Text = giangVien.HoTen ?? "";
                txtMaGV.Text = giangVien.MaGV ?? "";
                txtNgaySinh.Text = giangVien.NgaySinh.ToString("dd/MM/yyyy") ?? "";
                txtGioiTinh.Text = giangVien.GioiTinh ? "Nam" : "Nữ";
                txtDienThoai.Text = giangVien.DienThoai ?? "";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void giangVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.giangVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quanLiSinhVien1_DoAnCuoiKi242DataSet);

        }

        private void giangVienBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.giangVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quanLiSinhVien1_DoAnCuoiKi242DataSet);

        }

        private void gioiTinhCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
