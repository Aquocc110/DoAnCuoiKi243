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
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class ThongBaoGiangVien : Form
    {
        private string maGV;
        private int selectedMaTB = -1;
        public ThongBaoGiangVien(string maGV)
        {
            this.maGV = maGV;
            InitializeComponent();
        }

        private void ThongBaoGiangVien_Load(object sender, EventArgs e)
        {
            dgrvTieuDe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            btnLuu.Visible = false;
            LoadThongBao();
            dgrvTieuDe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgrvTieuDe.CellClick += dgrvTieuDe_CellClick;   
        }
        private void LoadThongBao()
        {
            
            string query = "SELECT MaTB, TieuDe, ndThongBao, NgayTao FROM ThongBao ORDER BY NgayTao DESC";
            DataTable dt = new DataTable();

            DatabaseHelper dbHelper = new DatabaseHelper();
            using (SqlConnection conn = dbHelper.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            // Gán DataTable cho DataGridView
            dgrvTieuDe.DataSource = dt;
            FormatDataGridView();


            if (dgrvTieuDe.Columns.Contains("MaTB"))
                dgrvTieuDe.Columns["MaTB"].Visible = false;
            if (dgrvTieuDe.Columns.Contains("ndThongBao"))
                dgrvTieuDe.Columns["ndThongBao"].Visible = false;
        }


        private void dgrvTieuDe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrvTieuDe.Rows.Count)
            {
                if (dgrvTieuDe.Rows[e.RowIndex].IsNewRow)
                    return;

                DataGridViewRow selectedRow = dgrvTieuDe.Rows[e.RowIndex];

                bool isEmpty = true;
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }
                dgrvTieuDe.AllowUserToAddRows = false;


                if (isEmpty)
                {
                    dgrvTieuDe.Rows.RemoveAt(e.RowIndex);
                }
            }
            if (e.RowIndex >= 0)
            {
                int maTB = Convert.ToInt32(dgrvTieuDe.Rows[e.RowIndex].Cells["MaTB"].Value);

                // Lưu lại để cập nhật sau này
                selectedMaTB = maTB;

                // Gọi SQL để lấy đầy đủ nội dung
                string query = "SELECT TieuDe, ndThongBao FROM ThongBao WHERE MaTB = @MaTB";
                using (SqlConnection conn = new DatabaseHelper().TaoKetNoi())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTB", maTB);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string tieuDe = reader["TieuDe"].ToString();
                            string ndThongBao = reader["ndThongBao"].ToString();

                            txtTieuDe.Text = tieuDe;
                            txtNoiDung.Text = ndThongBao;

                           
                            lblTieuDe.Text = tieuDe;
                            lblNoiDung.Text = ndThongBao;
                        }
                    }
                }
            }
        }

      
            private void btnLuu_Click(object sender, EventArgs e)
           {
            string tieuDe = txtTieuDe.Text.Trim();
            string ndThongBao = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(ndThongBao))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tiêu đề và nội dung!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO ThongBao (TieuDe, ndThongBao, NgayTao, MaGV) VALUES (@TieuDe, @ndThongBao, GETDATE(), @MaGV)";

            using (SqlConnection conn = new DatabaseHelper().TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@ndThongBao", ndThongBao);
                    cmd.Parameters.AddWithValue("@MaGV", maGV); // Lưu người đang đăng nhập

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã lưu thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThongBao(); // Làm mới danh sách nếu có
                        txtTieuDe.Clear();
                        txtNoiDung.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnLuu.Visible=false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaTB == -1)
            {
                MessageBox.Show("Vui lòng chọn một thông báo để cập nhật.");
                return;
            }

            string tieuDe = txtTieuDe.Text.Trim();
            string ndThongBao = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(ndThongBao))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = "UPDATE ThongBao SET TieuDe = @TieuDe, ndThongBao = @NoiDung WHERE MaTB = @MaTB AND MaGV = @MaGV";

            using (SqlConnection conn = new DatabaseHelper().TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@NoiDung", ndThongBao);
                    cmd.Parameters.AddWithValue("@MaTB", selectedMaTB);
                    cmd.Parameters.AddWithValue("@MaGV", maGV); // Chỉ cho phép người tạo cập nhật

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadThongBao();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại hoặc bạn không có quyền!");
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtNoiDung.Text = "";
            txtTieuDe.Text = "";
            btnLuu.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaTB == -1)
            {
                MessageBox.Show("Vui lòng chọn một thông báo để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông báo này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM ThongBao WHERE MaTB = @MaTB AND MaGV = @MaGV"; // Xóa chỉ khi đúng MaGV

                using (SqlConnection conn = new DatabaseHelper().TaoKetNoi())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTB", selectedMaTB);
                        cmd.Parameters.AddWithValue("@MaGV", maGV); // Chỉ cho phép người tạo xóa

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa thông báo thành công!");
                            LoadThongBao(); // Làm mới danh sách thông báo
                            txtTieuDe.Clear();
                            txtNoiDung.Clear();
                            selectedMaTB = -1; // Reset MaTB
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại hoặc bạn không có quyền!");
                        }
                    }
                }
            }
        }

        private void dgrvTieuDe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
         private void FormatDataGridView()
        {
            
            dgrvTieuDe.Columns["TieuDe"].HeaderText = "Tiêu Đề";
            dgrvTieuDe.Columns["NgayTao"].HeaderText = "Ngày Tạo";

            if (dgrvTieuDe.Columns.Contains("MaMH"))
            {
                dgrvTieuDe.Columns["MaMH"].Visible = false;
            }


            // Căn chỉnh chung
            dgrvTieuDe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgrvTieuDe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgrvTieuDe.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgrvTieuDe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgrvTieuDe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Font & màu
            dgrvTieuDe.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgrvTieuDe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgrvTieuDe.BackgroundColor = Color.White;
            dgrvTieuDe.ForeColor = Color.Black;
            dgrvTieuDe.GridColor = Color.Black; // viền ô màu đen
            dgrvTieuDe.CellBorderStyle = DataGridViewCellBorderStyle.Single; // viền ô toàn bộ

            // Header
            dgrvTieuDe.EnableHeadersVisualStyles = false;
            dgrvTieuDe.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgrvTieuDe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgrvTieuDe.ColumnHeadersHeight = 35;
            dgrvTieuDe.BorderStyle = BorderStyle.FixedSingle;

            // Dòng xen kẽ
            dgrvTieuDe.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Kích thước hàng
            dgrvTieuDe.RowTemplate.Height = 32;
            dgrvTieuDe.RowTemplate.MinimumHeight = 32;

            // Cột cụ thể
            dgrvTieuDe.Columns["TieuDe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrvTieuDe.Columns["NgayTao"].Width = 150;

        }

    }
}

