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

namespace DoAnCuoiKi242
{
    public partial class TraLoiCauHoiGV : Form
    {
        private string currentUsername;
        public TraLoiCauHoiGV(string username)
        {
            InitializeComponent();
            this.currentUsername = username;
        }

        private void TraLoiCauHoiGV_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            btnLuu.Visible = false;
            txtTraLoi.Visible = false;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LoadDanhSachCauHoiChuaTraLoi();
            // Tùy chỉnh giao diện DataGridView dgvCauHoi
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCauHoi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCauHoi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvCauHoi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCauHoi.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCauHoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCauHoi.BackgroundColor = Color.White;
            dgvCauHoi.ForeColor = Color.Black;
            dgvCauHoi.GridColor = Color.Black; // viền ô màu đen
            dgvCauHoi.CellBorderStyle = DataGridViewCellBorderStyle.Single; // viền ô toàn bộ

            dgvCauHoi.EnableHeadersVisualStyles = false;
            dgvCauHoi.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvCauHoi.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCauHoi.ColumnHeadersHeight = 35;
            dgvCauHoi.BorderStyle = BorderStyle.FixedSingle;

            dgvCauHoi.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCauHoi.RowTemplate.Height = 32;
            dgvCauHoi.RowTemplate.MinimumHeight = 32;
            if (dgvCauHoi.Columns.Contains("NoiDungCauHoi"))
            {
                dgvCauHoi.Columns["NoiDungCauHoi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvCauHoi.Columns.Contains("TenMH"))
            {
                dgvCauHoi.Columns["TenMH"].Width = 150;
            }

        }

        private void LoadDanhSachCauHoiChuaTraLoi()
        {
            string query = @"
        SELECT c.MaCauHoi, c.NoiDungCauHoi, sv.HoTen, mh.TenMH 
        FROM CauHoi c
        JOIN SinhVien sv ON c.MaSV = sv.MaSV
        JOIN MonHoc mh ON c.MaMH = mh.MaMH
        LEFT JOIN TraLoi t ON c.MaCauHoi = t.MaCauHoi
        WHERE t.MaCauHoi IS NULL"; // Chỉ lấy câu hỏi chưa có câu trả lời

            DataTable dt = new DataTable();

            DatabaseHelper dbHelper = new DatabaseHelper();
            using (SqlConnection conn = dbHelper.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            dgvCauHoi.DataSource = dt;  // Gán dữ liệu vào DataGridView
        }



        private void dgvCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maCauHoi = dgvCauHoi.Rows[e.RowIndex].Cells["MaCauHoi"].Value != DBNull.Value
    ? Convert.ToInt32(dgvCauHoi.Rows[e.RowIndex].Cells["MaCauHoi"].Value)
    : 0;

                string tenSinhVien = dgvCauHoi.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                string noiDungCauHoi = dgvCauHoi.Rows[e.RowIndex].Cells["NoiDungCauHoi"].Value.ToString();

                lblNgHoi.Text = $"Người đặt câu hỏi: {tenSinhVien}";
                lblCauHoi.Text = noiDungCauHoi;
                // Tải câu trả lời cho câu hỏi nếu có
                LoadCauTraLoi(maCauHoi);
            }
        }
        private void LoadCauTraLoi(int maCauHoi)
        {
            string query = "SELECT NoiDungTraLoi FROM TraLoi WHERE MaCauHoi = @MaCauHoi";
            DataTable dt = new DataTable();

            DatabaseHelper dbHelper = new DatabaseHelper();
            using (SqlConnection conn = dbHelper.TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            if (dt.Rows.Count > 0)
            {
                string noiDungTraLoi = dt.Rows[0]["NoiDungTraLoi"].ToString();
                txtTraLoi.Text = noiDungTraLoi;  // Giả sử có một TextBox để hiển thị câu trả lời
            }
            else
            {
                txtTraLoi.Text = "Chưa có câu trả lời.";
            }
        }

        private void lblCauHoi_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvCauHoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCauHoi = Convert.ToInt32(dgvCauHoi.SelectedRows[0].Cells["MaCauHoi"].Value);
            string noiDungTraLoi = txtTraLoi.Text.Trim();
            string maGV = currentUsername; // Giả sử mã giảng viên đăng nhập, cần thay bằng mã thực tế

            if (string.IsNullOrEmpty(noiDungTraLoi))
            {
                MessageBox.Show("Vui lòng nhập nội dung trả lời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string checkQuery = "SELECT COUNT(*) FROM TraLoi WHERE MaCauHoi = @MaCauHoi";
            string query;

            using (SqlConnection conn = new DatabaseHelper().TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {

                        query = "UPDATE TraLoi SET NoiDungTraLoi = @NoiDungTraLoi, NgayTao = GETDATE() WHERE MaCauHoi = @MaCauHoi";
                    }
                    else
                    {

                        query = "INSERT INTO TraLoi (MaCauHoi, MaGV, NoiDungTraLoi, NgayTao) VALUES (@MaCauHoi, @MaGV, @NoiDungTraLoi, GETDATE())";
                    }
                }

                // Thực thi câu lệnh
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                    cmd.Parameters.AddWithValue("@MaGV", maGV);
                    cmd.Parameters.AddWithValue("@NoiDungTraLoi", noiDungTraLoi);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Lưu câu trả lời thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachCauHoiChuaTraLoi(); // Refresh danh sách
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnLuu.Visible = false;
                txtTraLoi.Visible = false;
                label2.Visible = false;
            }
        }

        private void btnTraLoi_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            btnLuu.Visible = true;
            txtTraLoi.Visible = true;
        }
    }
}

