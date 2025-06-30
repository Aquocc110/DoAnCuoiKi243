using QuanLiSinhVien;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;
using GiangVien = QuanLiSinhVien.DatabaseHelper.GiangVien;

namespace DoAnCuoiKi242
{
    public partial class DiemSuaGV : Form
    {
        private GiangVien gvInfo;
        private string maGV;
        private string maSVDangChon = "";
        private string maMHDangChon = ""; // Thêm biến toàn cục này
        private DataTable diemTable; // Lưu dữ liệu điểm để lọc
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // Sự kiện để vẽ lại số thứ tự ở cột RowHeader của DataGridView
        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush butVe = new SolidBrush(dataGridView2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView2.DefaultCellStyle.Font, butVe, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        // Sự kiện vẽ lại số thứ tự cho RowHeader (dòng đầu tiên của DataGridView)
        private void dataGridView2_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(dataGridView2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                    dataGridView2.DefaultCellStyle.Font, brush,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        public DiemSuaGV(string maGV)
        {
            InitializeComponent();
            this.maGV = maGV;

        }
        private void DiemSuaGV_Load(object sender, EventArgs e)
        {
            LoadMonHoc(maGV);
            LoadDiemSinhVien(maGV);
            // Tùy chỉnh giao diện DataGridView dataGridView2
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ForeColor = Color.Black;
            dataGridView2.GridColor = Color.Black; // viền ô màu đen
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single; // viền ô toàn bộ

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnHeadersHeight = 35;
            dataGridView2.BorderStyle = BorderStyle.FixedSingle;

            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.RowTemplate.Height = 32;
            dataGridView2.RowTemplate.MinimumHeight = 32;

            // Tự động điều chỉnh cột "NoiDungCauHoi" cho đẹp, nếu có
            if (dataGridView2.Columns.Contains("NoiDungCauHoi"))
            {
                dataGridView2.Columns["NoiDungCauHoi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Đặt chiều rộng cột ngày hoặc các cột cần cố định (ví dụ "TenMH")
            if (dataGridView2.Columns.Contains("TenMH"))
            {
                dataGridView2.Columns["TenMH"].Width = 150;
            }

        }

        private void LoadMonHoc(string maGV)
        {
            comboBoxMonHoc.Items.Clear();

            if (maGV == "GV001") // Giảng viên Khoa CNTT
            {
                comboBoxMonHoc.Items.Add("Lập trình C#");
                comboBoxMonHoc.Items.Add("Cơ sở dữ liệu");
                comboBoxMonHoc.Items.Add("Nhập môn AI");
            }
            else if (maGV == "GV002") // Giảng viên Khoa Đại Cương
            {
                comboBoxMonHoc.Items.Add("Triết học Mác-Lênin");
                comboBoxMonHoc.Items.Add("Toán cao cấp");
                comboBoxMonHoc.Items.Add("Tiếng Anh chuyên ngành");
            }

            if (comboBoxMonHoc.Items.Count > 0)
                comboBoxMonHoc.SelectedIndex = 0; // Chọn mặc định

            comboBoxMonHoc.SelectedIndexChanged += comboBoxMonHoc_SelectedIndexChanged; // Gắn sự kiện khi chọn môn học
        }


        private void LoadDiemSinhVien(string maGV)
        {
            try
            {
                diemTable = DatabaseHelper.GetDiemSinhVien(maGV); // Lưu vào biến toàn cục

                if (diemTable != null && diemTable.Rows.Count > 0)
                {
                    dataGridView2.DataSource = diemTable;
                    FormatDataGridView();
                }
                else
                {
                    dataGridView2.DataSource = null;
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void FormatDataGridView()
        {
            dataGridView2.Columns["MaSV"].HeaderText = "Mã SV";
            dataGridView2.Columns["HoTen"].HeaderText = "Họ và tên";
            dataGridView2.Columns["TenKhoa"].HeaderText = "Khoa";
            dataGridView2.Columns["TenMH"].HeaderText = "Môn học";
            dataGridView2.Columns["Diem"].HeaderText = "Điểm";

            if (dataGridView2.Columns.Contains("MaMH"))
            {
                dataGridView2.Columns["MaMH"].Visible = false;
            }

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.EnableHeadersVisualStyles = false;

            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView2.DefaultCellStyle.BackColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự căn cột

            // Kẻ ô đẹp hơn
            dataGridView2.GridColor = Color.LightGray;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.RowTemplate.Height = 28;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                maSVDangChon = row.Cells["MaSV"].Value.ToString();
                maMHDangChon = row.Cells["MaMH"].Value.ToString();
                textBox1.Text = row.Cells["HoTen"].Value.ToString();
                textBox2.Text = row.Cells["Diem"].Value.ToString();
            }
        }

        private void bttnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maSVDangChon) && !string.IsNullOrEmpty(maMHDangChon) && !string.IsNullOrEmpty(textBox2.Text))
            {
                float diemMoi;
                if (float.TryParse(textBox2.Text, out diemMoi))
                {
                    // Dùng maMHDangChon thay vì lấy từ DataGridView
                    bool isSuccess = DatabaseHelper.UpdateDiemSinhVien(maSVDangChon, maMHDangChon, diemMoi);

                    if (isSuccess)
                    {
                        MessageBox.Show("Đã sửa điểm thành công!");
                        LoadDiemSinhVien(maGV);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi điểm để sửa.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập điểm hợp lệ (từ 0 đến 10)");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên và nhập điểm mới");
            }
        }
        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (diemTable != null)
            {
                string monHocChon = comboBoxMonHoc.SelectedItem.ToString();
                DataView dv = diemTable.DefaultView;
                dv.RowFilter = $"TenMH = '{monHocChon}'"; // Lọc dữ liệu theo môn học
                dataGridView2.DataSource = dv.ToTable();
            }
        }
    }
}