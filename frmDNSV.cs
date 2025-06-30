using QuanLiSinhVien;
using System;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class frmDNSV : Form
    {
        private void frmDNSV_Load(object sender, EventArgs e)
        {
          
        }

        private DatabaseHelper dbHelper = new DatabaseHelper();
        public static string CurrentUsername { get; private set; } 

        public frmDNSV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 open =new Form1();
            open.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoanSV.Text;
            string password = txtMatKhauSV.Text;

            if (dbHelper.DangNhap(username, password, out string vaiTro, out string fullName))
            {
                MessageBox.Show($"Đăng nhập thành công! Chào mừng: {fullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CurrentUsername = username; 

                this.Hide();
                SinhVien sinhVien = DatabaseHelper.LaySinhVienBangTenDangNhap(CurrentUsername);
                frmMainSinhVien mainForm = new frmMainSinhVien(sinhVien);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tắtỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
