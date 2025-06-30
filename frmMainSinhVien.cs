using QuanLiSinhVien;
using System;
using System.Data;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class frmMainSinhVien : Form
    {
        private string currentUsername;
        private SinhVien sinhVien;
        public static frmMainSinhVien Instance { get; private set; }
        public frmMainSinhVien(SinhVien sv)
        {
            InitializeComponent();
            this.sinhVien = sv;
            Instance = this;
        }
        private Form ChildForm;
        public  void openChildForm1(Form childForm)
        {
            if (ChildForm != null)
            {
                ChildForm.Close();
            }
            ChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelbody.Controls.Add(childForm);
            panelbody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void LoadLichHoc()
        {
            if (sinhVien != null && !string.IsNullOrEmpty(sinhVien.MaSV))
            {
                dgrvLichHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                DataTable dtLichHoc = GetLichHoc(sinhVien.MaSV);
                dgrvLichHoc.DataSource = dtLichHoc;

                dgrvLichHoc.Columns["MaMH"].HeaderText = "Mã môn học";
                dgrvLichHoc.Columns["TenMH"].HeaderText = "Tên môn học";
                dgrvLichHoc.Columns["NgayHoc"].HeaderText = "Ngày học";
                dgrvLichHoc.Columns["ThoiGianBatDau"].HeaderText = "Giờ bắt đầu";
                dgrvLichHoc.Columns["ThoiGianKetThuc"].HeaderText = "Giờ kết thúc";
                dgrvLichHoc.Columns["PhongHoc"].HeaderText = "Phòng học";

            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {
            // Để trống nếu không cần xử lý gì
        }
        private void frmMainSinhVien_Load(object sender, EventArgs e)
        {

            if (sinhVien != null)
            {
                currentUsername = sinhVien.TenDangNhap;
                txtHoTen.Text = sinhVien.HoTen;
                txtMaSV.Text = sinhVien.MaSV;
                txtMaKhoa.Text = sinhVien.MaKhoa;
                txtEmail.Text = sinhVien.Email;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (sinhVien != null)
            {

                LoadLichHoc();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
            

        private void xemĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (sinhVien != null && !string.IsNullOrEmpty(sinhVien.MaSV))
            {
                try
                        
                   
                {
                    if (label1.Text == "Điểm sinh viên")
                    {
                        MessageBox.Show("Bạn đang ở trang Điểm rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    openChildForm1(new DiemSV(sinhVien.MaSV));
                    label1.Text = "Điểm sinh viên";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở form điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tắtỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                DialogResult thoat = MessageBox.Show("Bạn có chắc muốn thoát không","Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thoat == DialogResult.Yes) 
                
                {
                    Application.Exit();
                }
            }

            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStripfrmMainSinhVien_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panelbody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trangChủSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Trang chủ sinh viên")
            {
                MessageBox.Show("Bạn đang ở Trang chủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            if (ChildForm != null)
            {
                label1.Text = "Trang chủ sinh viên";
                ChildForm.Close();
            }
        }

        private void thôngTinSinhViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (sinhVien != null && !string.IsNullOrEmpty(sinhVien.MaSV))
            {
                try
                {
                    if (label1.Text == "Thông tin sinh viên")
                    {
                        MessageBox.Show("Bạn đang ở trang thông tin rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    openChildForm1(new ThongTinCaNhan(sinhVien));
                    label1.Text = "Thông tin sinh viên";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở form Thông tin cá nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 open = new Form1();
            this.Close();
            open.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgrvLichHoc_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                dgrvLichHoc.ClearSelection();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void họcPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sinhVien != null && !string.IsNullOrEmpty(sinhVien.MaSV))
            {
                try
                {
                    if (label1.Text == "Học Phí")
                    {
                        MessageBox.Show("Bạn đang ở trang Học Phí rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    openChildForm1(new HocPhi(sinhVien.MaSV));
                    label1.Text = "Học phí";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở form Học Phí: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void xemThôngTinGiảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void họcBổngGiảmHọcPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sinhVien != null && !string.IsNullOrEmpty(sinhVien.MaSV))
            {
                try
                {
                    if (label1.Text == "TT học bổng")
                    {
                        MessageBox.Show("Bạn đang ở TT học bổng rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    openChildForm1(new TThocBong(sinhVien.MaSV));
                    label1.Text = "Thông tin học bổng";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở form TT học bổng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void điểmSốToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cácMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sinhVien != null && !string.IsNullOrEmpty(sinhVien.MaSV))
            {
                try
                {
                    if (label1.Text == "Diễn đàn")
                    {
                        MessageBox.Show("Bạn đang ở diễn đàn rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    openChildForm1(new DatCauHoi(sinhVien.MaSV)); //sinhVien.MaSV
                    label1.Text = "Diễn đàn";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở form diễn đàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thôngBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sinhVien != null && !string.IsNullOrEmpty(sinhVien.MaSV))
            {
                try
                {
                    if (label1.Text == "Thông báo")
                    {
                        MessageBox.Show("Bạn đang ở thông báo rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    openChildForm1(new ThongBaoSinhVien(sinhVien.MaSV)); //sinhVien.MaSV
                    label1.Text = "Thông Báo";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở form Thông báo rồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
