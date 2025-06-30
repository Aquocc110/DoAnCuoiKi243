using QuanLiSinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLiSinhVien.DatabaseHelper;

namespace DoAnCuoiKi242
{
    public partial class DiemSV : Form
    {
        private SinhVien sinhVien;
        private string maSinhVien;
        public DiemSV(string maSinhVien)
        {
            InitializeComponent();
            this.maSinhVien = maSinhVien;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush butVe = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1.DefaultCellStyle.Font, butVe, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDiemSinhVien()
        {
            DataTable bangDiem = DatabaseHelper.GetKetQuaHocTap(maSinhVien);

            if (bangDiem != null && bangDiem.Rows.Count > 0)
            {
                // === CÀI ĐẶT STYLE CHO DATAGRIDVIEW ===
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.EnableHeadersVisualStyles = false;

                // Header style
                
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dataGridView1.ColumnHeadersHeight = 35;

                // Alternating rows
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

                // Alignment
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Auto size
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // =====================================

                dataGridView1.DataSource = bangDiem;

                // Đặt tên cột
                dataGridView1.Columns["MaMH"].HeaderText = "Mã môn học";
                dataGridView1.Columns["TenMH"].HeaderText = "Tên môn học";
                dataGridView1.Columns["Diem"].HeaderText = "Điểm";
                dataGridView1.Columns["DiemChu"].HeaderText = "Điểm chữ";

                // Tính GPA (giữ nguyên phần code hiện có của bạn)
                double tongDiem = 0;
                int soMon = 0;
                foreach (DataRow row in bangDiem.Rows)
                {
                    if (double.TryParse(row["Diem"].ToString(), out double diem))
                    {
                        tongDiem += diem;
                        soMon++;
                    }
                }
                txtGPA.Text = (soMon > 0 ? (tongDiem / soMon).ToString("0.00") : "0.00");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGPA.Text = "0.00";
            }
        }


        private void DiemSV_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            this.TopMost = true;    
            LoadDiemSinhVien();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool isFirstClick = true;

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                label1.Visible = true;
                button1.Text = "Tắt thông tin";
            }
            else
            {
                label1.Visible = false;
                button1.Text = "Thắc mắc?";
            }

            // Đảo trạng thái sau mỗi lần click
            isFirstClick = !isFirstClick;
        }

    }
}
