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
    public partial class ThemMon : Form
    {
        private GiangVien giangVien;
          private DatabaseHelper databaseHelper;
        public ThemMon(GiangVien gv)
        {
            InitializeComponent();
            this.giangVien = gv;
            this.databaseHelper = new DatabaseHelper();
            LoadDanhSachMonHoc();

        }

        private void ThemMon_Load(object sender, EventArgs e)
        {
            string maGV = giangVien.MaGV;
            LoadDanhSachMonHoc();
        }
        private void LoadDanhSachMonHoc()
        {
            try
            {
                DataTable dt = DatabaseHelper.LayTatCaMonHoc();
                if (dt.Rows.Count > 0)
                    dgrvMonHoc.DataSource = dt;
                else
                    MessageBox.Show("Chưa có môn học nào trong cơ sở dữ liệu.", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load môn học: " + ex.Message, "Lỗi");
            }
        }

    }
}
