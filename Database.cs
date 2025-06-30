using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuanLiSinhVien
{

    public class DatabaseHelper
    {
        public static string chuoiKetNoi = "1Data Source=DESKTOP-V5GILFN\\SQLEXPRESS;Initial Catalog=QuanLiSinhVienFinall_DoAnCuoiKi242;Integrated Security=True;TrustServerCertificate=True";
        public SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }

        // SINH VIÊNNNNN-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public class SinhVien
        {
            public string MaSV { get; set; }
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public bool GioiTinh { get; set; }
            public string DiaChi { get; set; }
            public string DienThoai { get; set; }
            public string Email { get; set; }
            public string QuocGia { get; set; }
            public string DanToc { get; set; }
            public string TonGiao { get; set; }
            public string MaKhoa { get; set; }
        }

        public static DataTable LayMonHocTinhHocPhi(string maSV)
        {
            DataTable monHoc = new DataTable();
            string truyVan = @"
    SELECT MH.MaMH, MH.TenMH, MH.GiaTinChi, MH.SoTinChi 
    FROM MonHoc MH 
    JOIN LichHoc LH ON MH.MaMH = LH.MaMH
    WHERE LH.MaSV = @maSV";

            using (SqlConnection ketnoi = new SqlConnection(chuoiKetNoi))
            {
                ketnoi.Open();
                using (SqlCommand lenh = new SqlCommand(truyVan, ketnoi))
                {
                    lenh.Parameters.AddWithValue("@maSV", maSV);
                    using (SqlDataAdapter boThichNghi = new SqlDataAdapter(lenh))
                    {
                        boThichNghi.Fill(monHoc);
                    }
                }
            }
            return monHoc;
        }
        public static DataTable GetDanhSachCauHoi()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT MaSV, MaCauHoi, NoiDungCauHoi, NgayTao, MaMH FROM CauHoi";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi)) 
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    //cmd.Parameters.AddWithValue("@MaMH", maMH);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable GetThongTinNguoiDatCauHoi(int maCauHoi)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT SV.HoTen AS TenSV, SV.MaSV 
        FROM CauHoi CH
        JOIN SinhVien SV ON CH.MaSV = SV.MaSV
        WHERE CH.MaCauHoi = @MaCauHoi";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable GetThongTinTraLoi(int maCauHoi)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            GV.HoTen AS TenGV, 
            TL.NoiDungTraLoi
        FROM 
            TraLoi TL
        JOIN 
            GiangVien GV ON TL.MaGV = GV.MaGV
        WHERE 
            TL.MaCauHoi = @MaCauHoi";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


        public static DataTable GetKetQuaHocTap(string maSV)
        {
            DataTable dt = new DataTable();
            string query = "SELECT MaMH, TenMH, Diem, DiemChu FROM KetQua WHERE MaSV = @maSV";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSV", maSV); // Quan trọng: Phải có dòng này
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable HienTTSV(string maSV)
        {
            DataTable thongTinSinhVien = new DataTable();
            string truyVan = @"SELECT HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, MaKhoa FROM SinhVien WHERE MaSV = @maSV";

            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            using (SqlCommand lenh = new SqlCommand(truyVan, ketNoi))
            {
                lenh.Parameters.AddWithValue("@maSV", maSV);
                SqlDataAdapter boThichNghi = new SqlDataAdapter(lenh);
                boThichNghi.Fill(thongTinSinhVien);
            }

            return thongTinSinhVien;
        }
        public static DataTable GetLichHoc(string maSV)
        {
            DataTable lichHoc = new DataTable();
            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                string query = @"SELECT LichHoc.MaMH, MonHoc.TenMH, LichHoc.NgayHoc,  LichHoc.ThoiGianBatDau, LichHoc.ThoiGianKetThuc, LichHoc.PhongHoc
                             FROM LichHoc
                             JOIN MonHoc ON LichHoc.MaMH = MonHoc.MaMH
                             WHERE LichHoc.MaSV = @MaSV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(lichHoc);
                }
            }
            return lichHoc;
        }
        public bool DangNhap(string tenDangNhap, string matKhau, out string vaiTro, out string hoTenDayDu)
        {
            vaiTro = null;
            hoTenDayDu = null;
            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            {
                ketNoi.Open();
                string truyVan = "SELECT HoTen FROM SinhVien WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau";

                using (SqlCommand lenh = new SqlCommand(truyVan, ketNoi))
                {
                    lenh.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                    lenh.Parameters.AddWithValue("@matKhau", matKhau);

                    using (SqlDataReader docDuLieu = lenh.ExecuteReader())
                    {
                        if (docDuLieu.HasRows)
                        {
                            docDuLieu.Read();
                            hoTenDayDu = docDuLieu["HoTen"].ToString();
                            vaiTro = "SinhVien"; // Gán vai trò
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static SinhVien LaySinhVienBangTenDangNhap(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            SinhVien sinhVien = null;
            string truyVan = "SELECT * FROM SinhVien WHERE TenDangNhap = @tenDangNhap";

            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand(truyVan, ketNoi))
                {

                    lenh.Parameters.AddWithValue("@tenDangNhap", tenDangNhap.Trim());

                    using (SqlDataReader docDuLieu = lenh.ExecuteReader())
                    {
                        if (docDuLieu.Read())
                        {
                            sinhVien = new SinhVien
                            {
                                MaSV = docDuLieu["MaSV"].ToString(),
                                TenDangNhap = docDuLieu["TenDangNhap"].ToString(),
                                HoTen = docDuLieu["HoTen"].ToString(),
                                NgaySinh = docDuLieu["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(docDuLieu["NgaySinh"]) : DateTime.MinValue,
                                GioiTinh = docDuLieu["GioiTinh"] != DBNull.Value && Convert.ToBoolean(docDuLieu["GioiTinh"]),
                                DiaChi = docDuLieu["DiaChi"].ToString(),
                                DienThoai = docDuLieu["DienThoai"].ToString(),
                                MaKhoa = docDuLieu["MaKhoa"].ToString(),
                                DanToc = docDuLieu["DanToc"].ToString(),
                                Email = docDuLieu["Email"].ToString(),
                                TonGiao = docDuLieu["TonGiao"].ToString()
                            };
                        }
                    }
                }
            }
            return sinhVien;
        }

        // GIẢNG VIÊNNNN--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool Login(string username, string password, out string role, out string hoTenDayDu)
        {
            role = null;
            hoTenDayDu = null;
            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                string query = "SELECT HoTen FROM GiangVien WHERE TenDangNhap = @username AND MatKhau = @password ";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    if (reader.HasRows)
                    {
                            reader.Read();
                            hoTenDayDu = reader["HoTen"].ToString();
                            role = "GiangVien"; 
                            return true;
                        }
                }
            }
            return false;
        }
        public class GiangVien
        {
            public string MaGV { get; set; }
            public string TenDangNhap { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public bool GioiTinh { get; set; }
            public string DienThoai { get; set; }
            public string MaMH { get; set; }
            public string Email { get; set; }
            public string DanToc { get; set; }
            public string TonGiao { get; set; }
            public string Picture { get; set; }
      

        }
        //TEST GIANGVIEN ĐỂ TRONG TRƯỚC    
        public static GiangVien GetGiangVienByUsername(string username)
        {
            GiangVien gv = null;
            string query = "SELECT * FROM GiangVien WHERE TenDangNhap = @username";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gv = new GiangVien
                            {
                                MaGV = reader["MaGV"].ToString(),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                GioiTinh = Convert.ToBoolean(reader["GioiTinh"]),
                                DienThoai = reader["DienThoai"].ToString(),
                                Email = reader["email"].ToString(),
                                Picture = reader["Picture"].ToString(),
                                TonGiao = reader["TonGiao"].ToString(),
                                DanToc = reader["DanToc"].ToString(),
                                MaMH = reader["MaMH"].ToString()

                            };
                        }
                    }
                }
            }
            return gv;

        }

        public static DataTable HienTTGV(string maGV)
        {
            DataTable thongTinGiangVien = new DataTable();
            string truyVan = @"SELECT HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, Email, DanToc, TonGiao FROM GiangVien WHERE MaGV = @maGV";

            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand(truyVan, ketNoi))
                {
                    lenh.Parameters.AddWithValue("@maGV", maGV);
                    using (SqlDataAdapter boThichNghi = new SqlDataAdapter(lenh))
                    {
                        boThichNghi.Fill(thongTinGiangVien);
                    }
                }
            }
            return thongTinGiangVien;
        }

        public static bool UpdateGiangVien(GiangVien gv)
        {
            string query = @"UPDATE GiangVien 
                    SET HoTen = @HoTen, 
                        NgaySinh = @NgaySinh, 
                        DienThoai = @DienThoai,
                        GioiTinh = @GioiTinh,
                        Email = @Email,
                        Picture = @Picture,
                        DanToc= @DanToc,
                        TonGiao= @TonGiao
                    WHERE MaGV = @MaGV";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", gv.HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", gv.NgaySinh);
                    cmd.Parameters.AddWithValue("@DienThoai", gv.DienThoai);
                    cmd.Parameters.AddWithValue("@GioiTinh", gv.GioiTinh);
                    cmd.Parameters.AddWithValue("@Email", gv.Email);
                    cmd.Parameters.AddWithValue("@MaGV", gv.MaGV);
                    cmd.Parameters.AddWithValue("@Picture", gv.Picture);
                    cmd.Parameters.AddWithValue("@TonGiao", gv.TonGiao);
                    cmd.Parameters.AddWithValue("@DanToc", gv.DanToc);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công ít nhất 1 dòng
                }
            }
        }
        public static DataTable GetDiemSinhVien(string maGV)
        {
            DataTable dt = new DataTable();
            string MaKhoa = "";
            if (maGV == "GV001") MaKhoa = "CNTT";
            else if (maGV == "GV002") MaKhoa = "DC";

            string query = @"SELECT sv.MaSV, sv.HoTen, kh.TenKhoa, mh.MaMH, mh.TenMH, kq.Diem
                FROM SinhVien sv
                JOIN Khoa kh ON sv.MaKhoa = kh.MaKhoa
                JOIN MonHoc mh ON kh.MaKhoa = mh.MaKhoa
                JOIN KetQua kq ON sv.MaSV = kq.MaSV AND mh.MaMH = kq.MaMH
                WHERE kh.MaKhoa = @MaKhoa
                AND (
                    (kh.MaKhoa = 'CNTT' AND mh.MaMH IN ('MH001','MH002','MH003'))
                    OR
                    (kh.MaKhoa = 'DC' AND mh.MaMH IN ('MH004','MH005','MH006'))
                )";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", MaKhoa);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        // Có thể thêm dòng log ở đây để debug
                        Debug.WriteLine("Không có dữ liệu từ database");
                    }
                }
            }
            return dt;
        }

        public static bool UpdateDiemSinhVien(string maSV, string maMH, float diemMoi)
        {
            try
            {
                string query = @"UPDATE KetQua 
                 SET Diem = @Diem
                 WHERE MaSV = @MaSV AND MaMH = @MaMH"; // Đảm bảo có cả 2 điều kiện

                using (SqlConnection connection = new SqlConnection(chuoiKetNoi))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaMH", maMH); // Thêm parameter này
                    cmd.Parameters.AddWithValue("@Diem", diemMoi);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Debug số bản ghi bị ảnh hưởng
                    Debug.WriteLine($"Số bản ghi đã update: {rowsAffected}");

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi UpdateDiemSinhVien: " + ex.Message);
                return false;
            }
        }


        public static DataTable GetSinhVienTheoKhoa(string maGV)
        {
            DataTable dt = new DataTable();
            string maKhoa = "";


            if (maGV == "GV001") maKhoa = "CNTT";
            else if (maGV == "GV002") maKhoa = "DC";

            string query = @"
    SELECT SV.MaSV, SV.HoTen, SV.NgaySinh, SV.GioiTinh, SV.DiaChi, SV.DienThoai, SV.Email, K.TenKhoa
    FROM SinhVien SV
    JOIN Khoa K ON SV.MaKhoa = K.MaKhoa
    WHERE K.MaKhoa = @MaKhoa";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
        

        // Xóa sinh viên
        public static bool XoaSinhVien(string maSV)
        {
            string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        
    }
}