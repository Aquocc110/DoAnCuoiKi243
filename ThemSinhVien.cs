using QuanLiSinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;




namespace DoAnCuoiKi242
{
    public partial class ThemSinhVien : Form
    {
       
        private string maGiangVien;
        

        public ThemSinhVien(string maGV)
        {
            InitializeComponent();
            maGiangVien = maGV;
        }
        private void ThemSinhVien_Load(object sender, EventArgs e)
        {
           
        }
       

        private void bttnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường dữ liệu
            if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtGioiTinh.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gioiTinhText = txtGioiTinh.Text.ToLower();
            bool gioiTinh = false;
            if (gioiTinhText == "nam")
                gioiTinh = true;
            else if (gioiTinhText == "nữ")
                gioiTinh = false;
            else
            {
                MessageBox.Show("Giới tính phải là 'Nam' hoặc 'Nữ'", "Lỗi giới tính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng sinh viên
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtTen.Text;
            sv.NgaySinh = dateTimePicker1.Value;
            sv.GioiTinh = gioiTinh;
            sv.DiaChi = txtDiaChi.Text;
            sv.DienThoai = txtDienThoai.Text;
            sv.Email = txtEmail.Text;
            sv.MaKhoa = txtKhoa.Text;

            try
            {
                // Thêm sinh viên vào cơ sở dữ liệu
                string query = @"INSERT INTO SinhVien 
                        (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, Email, MaKhoa)
                        VALUES 
                        (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @DienThoai, @Email, @MaKhoa)";

                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                        cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                        cmd.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
                        cmd.Parameters.AddWithValue("@DienThoai", sv.DienThoai);
                        cmd.Parameters.AddWithValue("@Email", sv.Email);
                        cmd.Parameters.AddWithValue("@MaKhoa", sv.MaKhoa);

                        // Thực thi câu lệnh SQL và kiểm tra kết quả
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form sau khi thêm thành công
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }
        
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void MaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
