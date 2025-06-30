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
    public partial class frmDNGV : Form
    {
        public frmDNGV()
        {
            InitializeComponent();
        }

        private DatabaseHelper dbHelper = new DatabaseHelper();
        public static string CurrentUsername { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 open = new Form1();
            open.ShowDialog();
        }

        private void tắtỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tắtỨngDụngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void frmDNGV_Load(object sender, EventArgs e)
        {

        }

        private void bttnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoanGV.Text;
            string password = txtMatKhauGV.Text;

            if (dbHelper.Login(username, password, out string role, out string hoTenDayDu))
            {
                MessageBox.Show($"Đăng nhập thành công! Chào mừng: {hoTenDayDu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CurrentUsername = username; // Lưu lại username

                this.Hide();
                frmMainGiangVien mainForm = new frmMainGiangVien(CurrentUsername);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
