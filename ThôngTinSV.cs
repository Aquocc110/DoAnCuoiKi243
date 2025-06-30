using QuanLiSinhVien;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class ThôngTinSV : Form
    {

        private string maSV;
        public ThôngTinSV(string maSV)
        {
            InitializeComponent();
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            this.maSV = maSV;
        }

        private void ThôngTinSV_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            LoadTTSinhVien();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = DateTime.Parse(txtNgaySInh.Text);
            bool gioiTinh = txtGioiTinh.Text.Trim().ToLower() == "nam";
            string diaChi = txtDiaChi.Text;
            string dienThoai = txtDienThoai.Text;
            string maKhoa = txtMaKhoa.Text;
            bool isUpdated = DatabaseHelper.CapNhatSinhVien(maSV, hoTen, ngaySinh, gioiTinh, diaChi, dienThoai, maKhoa);

            this.Hide();
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadTTSinhVien()
        {
            DataTable bangDuLieu = DatabaseHelper.HienTTSV(maSV);

            if (bangDuLieu != null && bangDuLieu.Rows.Count > 0)
            {
                DataTable bangChuyenDoi = new DataTable();

                // Tạo cột đầu tiên chứa tên thuộc tính (VD: "Mã SV", "Họ Tên", ...)
                bangChuyenDoi.Columns.Add("Thông tin");

                // Thêm cột cho mỗi sinh viên (thường chỉ có 1 dòng do tìm theo `maSV`)
                for (int i = 0; i < bangDuLieu.Rows.Count; i++)
                {
                    bangChuyenDoi.Columns.Add("SV " + (i + 1));
                }

                // Đảo dữ liệu: Duyệt qua từng cột của bảng gốc và biến chúng thành hàng của bảng mới
                foreach (DataColumn cot in bangDuLieu.Columns)
                {
                    DataRow dongMoi = bangChuyenDoi.NewRow();
                    dongMoi[0] = cot.ColumnName; // Đặt tên thuộc tính ở cột đầu tiên

                    for (int i = 0; i < bangDuLieu.Rows.Count; i++)
                    {
                        dongMoi[i + 1] = bangDuLieu.Rows[i][cot]; // Gán giá trị tương ứng từ bảng gốc
                    }

                    bangChuyenDoi.Rows.Add(dongMoi);
                }

                // Gán lại dữ liệu đã đảo cho DataGridView
                dataGridView1.DataSource = bangChuyenDoi;

                // Ẩn tiêu đề cột để tránh nhầm lẫn
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush butVe = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1.DefaultCellStyle.Font, butVe, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

            Visible = false;
        }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {
            txtMaKhoa.Hide();
        }

        private void txtMaKhoa_TextChanged(object sender, EventArgs e)
        {
            txtHoTen.Hide();
        }

        private void txtNgaySInh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
