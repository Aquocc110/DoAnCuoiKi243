﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiSinhVien
{

    public class DatabaseHelper
    {
        public static string chuoiKetNoi = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog = DoAnLapTrinh1_2431; Integrated Security = True; TrustServerCertificate=True";
        public SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }

        // SINH VIÊNNNNN-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public class SinhVien
        {
            public string MaSV { get; set; }
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

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();

                string query = "SELECT VaiTro, MaLienKet FROM DangNhap WHERE TenDangNhap = @username AND MatKhau = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", tenDangNhap);
                    cmd.Parameters.AddWithValue("@password", matKhau);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            vaiTro = reader["VaiTro"].ToString();
                            string maLienKet = reader["MaLienKet"].ToString();

                            if (vaiTro == "SinhVien")
                            {
                                hoTenDayDu = LayHoTenSinhVien(maLienKet);
                            }
                            else if (vaiTro == "GiangVien")
                            {
                                hoTenDayDu = LayHoTenGiangVien(maLienKet);
                            }

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private string LayHoTenSinhVien(string maSV)
        {
            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                string query = "SELECT HoTen FROM SinhVien WHERE MaSV = @maSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSV", maSV);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        private string LayHoTenGiangVien(string maGV)
        {
            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                string query = "SELECT HoTen FROM GiangVien WHERE MaGV = @maGV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maGV", maGV);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        public static SinhVien LaySinhVienBangMa(string maSV)
        {
            SinhVien sinhVien = null;
            string truyVan = "SELECT * FROM SinhVien WHERE MaSV = @maSV";

            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand(truyVan, ketNoi))
                {
                    lenh.Parameters.AddWithValue("@maSV", maSV);

                    using (SqlDataReader docDuLieu = lenh.ExecuteReader())
                    {
                        if (docDuLieu.Read())
                        {
                            sinhVien = new SinhVien
                            {
                                MaSV = docDuLieu["MaSV"].ToString(),
                                HoTen = docDuLieu["HoTen"].ToString(),
                                NgaySinh = Convert.ToDateTime(docDuLieu["NgaySinh"]),
                                GioiTinh = Convert.ToBoolean(docDuLieu["GioiTinh"]),
                                DiaChi = docDuLieu["DiaChi"].ToString(),
                                DienThoai = docDuLieu["DienThoai"].ToString(),
                                Email = docDuLieu["Email"].ToString(),
                                MaKhoa = docDuLieu["MaKhoa"].ToString(),
                                DanToc = docDuLieu["DanToc"].ToString(),
                                TonGiao = docDuLieu["TonGiao"].ToString()
                            };
                        }
                    }
                }
            }
            return sinhVien;
        }

        public static GiangVien LayGiangVienBangMa(string maGV)
        {
            GiangVien giangVien = null;
            string query = "SELECT * FROM GiangVien WHERE MaGV = @maGV";

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maGV", maGV);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            giangVien = new GiangVien
                            {
                                MaGV = reader["MaGV"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : DateTime.MinValue,
                                GioiTinh = reader["GioiTinh"] != DBNull.Value && Convert.ToBoolean(reader["GioiTinh"]),
                                DienThoai = reader["DienThoai"].ToString(),
                                Email = reader["Email"].ToString(),
                                DanToc = reader["DanToc"].ToString(),
                                TonGiao = reader["TonGiao"].ToString(),
                                Picture = reader["Picture"].ToString(),
                                MaMH = reader["MaMH"].ToString()
                            };
                        }
                    }
                }
            }

            return giangVien;
        }


        // GIẢNG VIÊNNNN--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public class GiangVien
        {
            public string MaGV { get; set; }
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
        public static DataTable LayTatCaMonHoc()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT MaMH, TenMH, GiaTinChi, SoTinChi
        FROM MonHoc
        ORDER BY TenMH";  

            using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


    }
}