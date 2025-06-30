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
    public partial class TThocBong : Form
    {
        private string maSinhVien;
        public TThocBong(string maSinhVien)
        {
            this.maSinhVien = maSinhVien;
            InitializeComponent();
        }

        private void TThocBong_Load(object sender, EventArgs e)
        {
            HienThiHocBong();
        }

        private void label1_Click(object sender, EventArgs e)
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
        private void HienThiHocBong()
        {
            string maSV = maSinhVien;
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Không tìm thấy mã sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            double diemGPA = TinhDiem(maSV);
        
       
            lblDiem.Text = $"GPA: {diemGPA:N2} ";
            if (diemGPA >= 9.0)
            {
                lblThongBao.Text = "Nhận được học bổng 70% học phí";
              
            }
            else
            {
                lblThongBao.Text = "Nhận được học bổng 30% học phí";
              
            }


        }
    }
}
