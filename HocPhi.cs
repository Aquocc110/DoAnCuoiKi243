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

namespace DoAnCuoiKi242
{
    public partial class HocPhi : Form
    {
        private string maSinhVien;
        public HocPhi(string maSinhVien)
        {
            InitializeComponent();
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            this.maSinhVien = maSinhVien;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush butVe = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1.DefaultCellStyle.Font, butVe, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        private void loadHocPhi()
        {
            DataTable BangHocPhi = DatabaseHelper.LayMonHocTinhHocPhi(maSinhVien);

            if (BangHocPhi != null)
            {
                if (BangHocPhi.Rows.Count > 0)
                {
                    // === CÀI ĐẶT STYLE CHO DATAGRIDVIEW ===
                    dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    dataGridView1.BackgroundColor = Color.White;
                    dataGridView1.BorderStyle = BorderStyle.None;
                    dataGridView1.EnableHeadersVisualStyles = false;

                    // Header style
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dataGridView1.ColumnHeadersHeight = 35;

                    // Alternating rows
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

                    // Alignment
                    dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Auto size
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    // =====================================

                    dataGridView1.DataSource = BangHocPhi;

                    // Đặt tên cột
                    dataGridView1.Columns["MaMH"].HeaderText = "Mã môn học";
                    dataGridView1.Columns["TenMH"].HeaderText = "Tên môn học";
                    dataGridView1.Columns["GiaTinChi"].HeaderText = "Giá tín chỉ";
                    dataGridView1.Columns["SoTinChi"].HeaderText = "Số tín chỉ";

                    // Định dạng cột số
                    if (dataGridView1.Columns.Contains("GiaTinChi"))
                    {
                        dataGridView1.Columns["GiaTinChi"].DefaultCellStyle.Format = "N0";
                        dataGridView1.Columns["GiaTinChi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if (dataGridView1.Columns.Contains("SoTinChi"))
                    {
                        dataGridView1.Columns["SoTinChi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Tính tổng học phí
                    double tongHocPhi = 0;
                    foreach (DataRow row in BangHocPhi.Rows)
                    {
                        if (double.TryParse(row["GiaTinChi"].ToString(), out double giaTinChi) &&
                            double.TryParse(row["SoTinChi"].ToString(), out double soTinChi))
                        {
                            tongHocPhi += giaTinChi * soTinChi;
                        }
                    }

                    lblTongHocPhi.Text = $"{tongHocPhi:N0} VNĐ";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu học phí cho sinh viên này.");
                }
            }
            else
            {
                MessageBox.Show("Lỗi: DataTable bị null.");
            }
        }


        private void HocPhi_Load(object sender, EventArgs e)
        {
           loadHocPhi();
            HienThiHocBong();
           
        }

        private void Tổn(object sender, EventArgs e)
        {

        }
        public static double TinhDiem(string maSV)
        {
            DataTable bangDiem = DatabaseHelper.GetKetQuaHocTap(maSV);

            double tongDiem = 0;
            int soMonHoc = 0;

            
            foreach (DataRow row in bangDiem.Rows)
            {
                if (double.TryParse(row["Diem"].ToString(), out double diem))
                {
                    tongDiem += diem;
                    soMonHoc++;
                }
            }

            return (soMonHoc > 0) ? (tongDiem / soMonHoc) : 0;
           
        }

        public static double TinhTongHocPhi(string maSV)
        {
            DataTable BangHocPhi = DatabaseHelper.LayMonHocTinhHocPhi(maSV);
            double tongHocPhi = 0;

            if (BangHocPhi != null && BangHocPhi.Rows.Count > 0)
            {
          
                foreach (DataRow row in BangHocPhi.Rows)
                {
                    if (double.TryParse(row["GiaTinChi"].ToString(), out double giaTinChi) &&
                        double.TryParse(row["SoTinChi"].ToString(), out double soTinChi))
                    {
                        tongHocPhi += giaTinChi * soTinChi;
                    }
                }
            }
            return tongHocPhi;
        }

        public static double TinhMucHocBong(string maSV)
        {
            double gpa = TinhDiem(maSV);
            double hocPhi = TinhTongHocPhi(maSV);
            double hocBong = 0;

            if (gpa >= 9.0)
            {
                hocBong = hocPhi * 0.7;
            }
            else if (gpa >= 8.0)
            {
                hocBong = hocPhi * 0.3;
            }
            else
            {
              
                hocBong = 0;
            }

            return hocBong;
        }


        private void HienThiHocBong()
        {
            string maSV = maSinhVien;
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Không tìm thấy mã sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double hocBong = TinhMucHocBong(maSV);
            double diemGPA = TinhDiem(maSV);
            double hocphi = TinhTongHocPhi(maSV);
            lblHocBong.Text = $"Học bổng: {hocBong:N0} VND";
            lblHocBong.Visible = true;
            lblGpa.Text = $"GPA: {diemGPA:N2} ";
            if(diemGPA>=9.0)
            {
                lblCoKhong.Text = "Nhận được học bổng 70% học phí";
                lblPhaiDong.Text = $" {hocphi - hocBong:N0} VNĐ";
            }
            else
            {
                lblCoKhong.Text = "Nhận được học bổng 30% học phí";
                lblPhaiDong.Text = $" {hocphi - hocBong:N0} VNĐ";
            }
          

        }

        private void lblPhaiDong_Click(object sender, EventArgs e)
        {

        }
    }
}
