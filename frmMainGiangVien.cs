using QuanLiSinhVien;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using GiangVien = QuanLiSinhVien.DatabaseHelper.GiangVien;



namespace DoAnCuoiKi242
{
    public partial class frmMainGiangVien : Form
    {
        private string currentUsername; // Lưu username
        public frmMainGiangVien(string username)
        {
            InitializeComponent();
            this.currentUsername = username;
            this.IsMdiContainer = true; // Đặt form này làm MDI Container
        }

        //SỬA DESIGN
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (currentFormChild != null)
            {
                currentFormChild.Close();
                currentFormChild = null;
            }

           

        }

        private void xemHồSơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien gvInfo = DatabaseHelper.LayGiangVienBangMa(currentUsername); // Lấy dữ liệu mới nhất
            if (gvInfo != null)
            {
                
                OpenChildForm(new ThongTinGiangVien(gvInfo)); // Hiển thị thông tin mới
                labelTrangChu.Text = "Thông tin giảng viên";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin giảng viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chỉnhSửaThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien gvInfo = DatabaseHelper.LayGiangVienBangMa(currentUsername);
            if (gvInfo != null)
            {
                ThongTinGiangVien thongTinGV = new ThongTinGiangVien(gvInfo); // Xem hồ sơ trước
                OpenChildForm(new ChinhSuaThongTinGiangVien(gvInfo, thongTinGV)); // Mở form chỉnh sửa
                labelTrangChu.Text = "Chỉnh sửa hồ sơ";

            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin giảng viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quảnLíLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien DSSV = DatabaseHelper.LayGiangVienBangMa(currentUsername);
            if (DSSV != null)
            {
                DSSVoGiangVien thongTinGV = new DSSVoGiangVien(DSSV); // Xem hồ sơ trước
                OpenChildForm(new DSSVoGiangVien(DSSV)); // Mở form chỉnh sửa
                labelTrangChu.Text = "Danh sách sinh viên";

            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin giảng viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sửaĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien gvInfo = DatabaseHelper.LayGiangVienBangMa(currentUsername);
            if (gvInfo != null)
            {
                // Truyền MaGV (string) thay vì đối tượng GiangVien
                OpenChildForm(new DiemSuaGV(gvInfo.MaGV)); // Sửa ở đây
                labelTrangChu.Text = "Chỉnh sửa điểm";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin giảng viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frmLogin = new Form1();
            frmLogin.ShowDialog();
            this.Close();
        }

        private void tắtỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void giangVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.giangVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quanLiSinhVien1_DoAnCuoiKi242DataSet);

        }

        private void frmMainGiangVien_Load(object sender, EventArgs e)
        {
            LoadThongTinGiangVien();
        }
        private void LoadThongTinGiangVien()
        {
            GiangVien gvInfo = DatabaseHelper.LayGiangVienBangMa(currentUsername);
            if (gvInfo != null)
            {
                
                maGVTextBox.Text = gvInfo.MaGV;
                hoTenTextBox.Text = gvInfo.HoTen;
                emailTextBox1.Text = gvInfo.Email;
                dienThoaiTextBox.Text = gvInfo.DienThoai;
            }
        }
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maGVTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void thắcMắcSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien gvInfo = DatabaseHelper.LayGiangVienBangMa(currentUsername);
            if (gvInfo != null)
            {
                // Truyền MaGV (string) thay vì đối tượng GiangVien
                OpenChildForm(new TraLoiCauHoiGV(gvInfo.MaGV)); // Sửa ở đây
                labelTrangChu.Text = "Diễn đàn";
            }
            else
            {
                MessageBox.Show("Không tìm thấy diễn đàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thôngBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien gvInfo = DatabaseHelper.LayGiangVienBangMa(currentUsername);
            if (gvInfo != null)
            {
                // Truyền MaGV (string) thay vì đối tượng GiangVien
                OpenChildForm(new ThongBaoGiangVien(gvInfo.MaGV));
                labelTrangChu.Text = "Thông báo";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông báo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien gvInfo = DatabaseHelper.LayGiangVienBangMa(currentUsername);
            if (gvInfo != null)
            {
                // Truyền MaGV (string) thay vì đối tượng GiangVien
                OpenChildForm(new ThemMon(gvInfo));
                labelTrangChu.Text = "Thông báo";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông báo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
