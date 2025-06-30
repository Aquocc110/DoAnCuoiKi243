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
    public partial class DatCauHoi : Form
    {

        private string maSinhVien;
        public DatCauHoi(string maSinhVien)
        {
            this.maSinhVien = maSinhVien;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DatCauHoi_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            txtThem.Visible = false;
            btnXacNhan.Visible = false;
            cmbThem.Visible = false;

            // Load dữ liệu
            DataTable dtCauHoi = DatabaseHelper.GetDanhSachCauHoi();
            dgrvCauHoi.DataSource = dtCauHoi;

            if (dgrvCauHoi.Columns.Contains("MaCauHoi"))
            {
                dgrvCauHoi.Columns["MaCauHoi"].Visible = false;
            }

            // === THÊM CODE STYLE VÀO ĐÂY ===
            dgrvCauHoi.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgrvCauHoi.BackgroundColor = Color.White;
            dgrvCauHoi.BorderStyle = BorderStyle.None;
            dgrvCauHoi.EnableHeadersVisualStyles = false;

            // Header style
           
            dgrvCauHoi.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgrvCauHoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgrvCauHoi.ColumnHeadersHeight = 35;

            // Alternating rows
            dgrvCauHoi.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Alignment
            dgrvCauHoi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgrvCauHoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Đặt tên cột
            if (dgrvCauHoi.Columns.Contains("NoiDungCauHoi"))
                dgrvCauHoi.Columns["NoiDungCauHoi"].HeaderText = "Nội dung câu hỏi";
            if (dgrvCauHoi.Columns.Contains("NgayTao"))
            {
                dgrvCauHoi.Columns["NgayTao"].HeaderText = "Ngày tạo";
                dgrvCauHoi.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // Auto size
            dgrvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // ===============================

            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            LoadMonHocForCmbThem();
            LoadMonHoc();
        }

        private void dgrvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int maCauHoi = Convert.ToInt32(dgrvCauHoi.Rows[e.RowIndex].Cells["MaCauHoi"].Value);

                DataTable dtNguoiDat = DatabaseHelper.GetThongTinNguoiDatCauHoi(maCauHoi);

                if (dtNguoiDat.Rows.Count > 0)
                {
                    label2.Text = "" + dtNguoiDat.Rows[0]["TenSV"].ToString();
                }
                else
                {
                    label2.Text = "Chưa xác định người đặt câu hỏi.";
                }

                DataTable dtTraLoi = DatabaseHelper.GetThongTinTraLoi(maCauHoi);

                if (dtTraLoi.Rows.Count > 0)
                {
                    string tenGV = dtTraLoi.Rows[0]["TenGV"].ToString();
                    string noiDungTraLoi = dtTraLoi.Rows[0]["NoiDungTraLoi"].ToString();
                    lblTraloi.Text = $"Giảng viên: {tenGV} - Câu trả lời: \n {noiDungTraLoi}";
                }
                else
                {
                    lblTraloi.Text = "Chưa có câu trả lời cho câu hỏi này.";
                }
               
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue.ToString() != "")
            {
                string maMH = comboBox1.SelectedValue.ToString();

                string query = "SELECT MaCauHoi, NoiDungCauHoi, NgayTao FROM CauHoi WHERE MaMH = @MaMH";
                DataTable dt = new DataTable();

                DatabaseHelper dbHelper = new DatabaseHelper();
                using (SqlConnection conn = dbHelper.TaoKetNoi())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                dgrvCauHoi.DataSource = dt;
            }
            else
            {
                string query = "SELECT MaCauHoi, NoiDungCauHoi, NgayTao FROM CauHoi";
                DataTable dt = new DataTable();
                DatabaseHelper dbHelper = new DatabaseHelper();
                using (SqlConnection conn = dbHelper.TaoKetNoi())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                dgrvCauHoi.DataSource = dt;
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            txtThem.Visible= true;
            btnXacNhan.Visible= true;
            cmbThem.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtThem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

           
            if (string.IsNullOrWhiteSpace(txtThem.Text) || cmbThem.SelectedValue == null || cmbThem.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi và chọn môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string noiDungCauHoi = txtThem.Text;
            string maMH = cmbThem.SelectedValue.ToString();
            string maSV = maSinhVien; 

            string query = "INSERT INTO CauHoi (NoiDungCauHoi, NgayTao, MaSV, MaMH) VALUES (@NoiDungCauHoi, @NgayTao, @MaSV, @MaMH)";

            DatabaseHelper dbHelper = new DatabaseHelper();
            using (SqlConnection conn = dbHelper.TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NoiDungCauHoi", noiDungCauHoi);
                    cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaMH", maMH);

                    cmd.ExecuteNonQuery(); 
                }
            }

            DataTable dtCauHoi = DatabaseHelper.GetDanhSachCauHoi();
            dgrvCauHoi.DataSource = dtCauHoi;

            LoadMonHoc();
         
            btnXacNhan.Visible = false;
            label4.Visible = false;
            txtThem.Visible = false;
            cmbThem.Visible = false;

            MessageBox.Show("Câu hỏi đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void LoadMonHoc()
        {
          
            DataTable dt = new DataTable();
            dt.Columns.Add("MaMH", typeof(string));  
            dt.Columns.Add("TenMH", typeof(string)); 

          
            DataRow row = dt.NewRow();
            row["MaMH"] = DBNull.Value;  
            row["TenMH"] = "Lọc Môn Học"; 
            dt.Rows.Add(row);

            string query = "SELECT MaMH, TenMH FROM MonHoc";
            DatabaseHelper dbHelper = new DatabaseHelper();
            using (SqlConnection conn = dbHelper.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt); 
            }

            comboBox1.DisplayMember = "TenMH";   
            comboBox1.ValueMember = "MaMH";      
            comboBox1.DataSource = dt;           
            comboBox1.SelectedIndex = 0;         
        }

        private void LoadMonHocForCmbThem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaMH", typeof(string));
            dt.Columns.Add("TenMH", typeof(string));

            DataRow row = dt.NewRow();
            row["MaMH"] = DBNull.Value;
            row["TenMH"] = "Chọn Môn";
            dt.Rows.Add(row);

            string query = "SELECT MaMH, TenMH FROM MonHoc";
            DatabaseHelper dbHelper = new DatabaseHelper();
            using (SqlConnection conn = dbHelper.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            cmbThem.DisplayMember = "TenMH";
            cmbThem.ValueMember = "MaMH";
            cmbThem.DataSource = dt;
            cmbThem.SelectedIndex = 0;
        }

        private void cmbThem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThem.SelectedValue != null && cmbThem.SelectedValue.ToString() != "")
            {
                string maMH = cmbThem.SelectedValue.ToString();

                string query = "SELECT MaCauHoi, NoiDungCauHoi, NgayTao FROM CauHoi WHERE MaMH = @MaMH";
                DataTable dt = new DataTable();

                DatabaseHelper dbHelper = new DatabaseHelper();
                using (SqlConnection conn = dbHelper.TaoKetNoi())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                dgrvCauHoi.DataSource = dt;
            }
            else
            {
                string query = "SELECT MaCauHoi, NoiDungCauHoi, NgayTao FROM CauHoi";
                DataTable dt = new DataTable();

                DatabaseHelper dbHelper = new DatabaseHelper();
                using (SqlConnection conn = dbHelper.TaoKetNoi())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                dgrvCauHoi.DataSource = dt;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgrvCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

