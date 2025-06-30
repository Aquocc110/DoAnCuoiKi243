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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAnCuoiKi242
{
    public partial class ThongBaoSinhVien : Form
    {
        private string currentUsername;
        public ThongBaoSinhVien(string username)
        {

            InitializeComponent();
            this.currentUsername = username;
            LoadThongBao(); // Load thông báo khi form được mở
        }

        private void ThongBaoSinhVien_Load(object sender, EventArgs e)
        {
           FormatDataGridView();
        }
        private void FormatDataGridView()
        {
            // Kiểm tra nếu có dữ liệu
            if (dataGridView1.Columns.Count == 0) return;

            try
            {
                // Tạm thời tắt tự động resize
               dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
               dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                // Đặt tên cột
                dataGridView1.Columns["MaTB"].HeaderText = "Mã TB";
                dataGridView1.Columns["TieuDe"].HeaderText = "Tiêu Đề";
                dataGridView1.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                

                // Cấu hình hiển thị
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
               dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
               dataGridView1.EnableHeadersVisualStyles = false;

               dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
               dataGridView1.DefaultCellStyle.BackColor = Color.White;
               dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
               dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Cấu hình kích thước
               dataGridView1.RowTemplate.Height = 28;
               dataGridView1.RowTemplate.MinimumHeight = 28;
               dataGridView1.GridColor = Color.LightGray;
               dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                // Bật lại chế độ tự động điều chỉnh
               dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
               dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Đặc biệt xử lý cho cột nội dung
                if (dataGridView1.Columns.Contains("NoiDungCauHoi"))
                {
                   dataGridView1.Columns["NoiDungCauHoi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Refresh lại DataGridView
               dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi định dạng DataGridView: " + ex.Message);
            }
        }
        private void LoadThongBao()
        {
            string query = "SELECT MaTB, TieuDe, NgayTao FROM ThongBao";
            DataTable dt = new DataTable();

            using (SqlConnection conn = new DatabaseHelper().TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            // Gán dữ liệu vào DataGridView
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                if (dataGridView1.Rows[e.RowIndex].IsNewRow)
                    return;

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                bool isEmpty = true;
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }
                dataGridView1.AllowUserToAddRows = false;

             
                if (isEmpty)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
            if (e.RowIndex >= 0)
            {
             
                int maTB = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaTB"].Value);

                string query = @"
            SELECT t.TieuDe, t.ndThongBao, g.HoTen, t.MaGV 
            FROM ThongBao t
            INNER JOIN GiangVien g ON t.MaGV = g.MaGV
            WHERE t.MaTB = @MaTB";

                using (SqlConnection conn = new DatabaseHelper().TaoKetNoi())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTB", maTB);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTieuDe.Text = reader["TieuDe"].ToString();
                                lblNoiDung.Text = reader["ndThongBao"].ToString();

                                string maGV = reader["MaGV"].ToString();
                                lblGiangVien.Text = "Giảng viên: " + reader["HoTen"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void lblGiangVien_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }

        private void lblNoiDung_Click(object sender, EventArgs e)
        {

        }
    }
}
