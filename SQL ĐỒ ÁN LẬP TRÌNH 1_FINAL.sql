﻿﻿
DROP DATABASE IF EXISTS DoAnLapTrinh1_2431;
GO


CREATE DATABASE DoAnLapTrinh1_2431;
GO

USE DoAnLapTrinh1_2431;
GO


DROP TABLE IF EXISTS KetQua;
DROP TABLE IF EXISTS LopHoc;
DROP TABLE IF EXISTS SinhVien;
DROP TABLE IF EXISTS GiangVien;
DROP TABLE IF EXISTS MonHoc;
DROP TABLE IF EXISTS Khoa;
DROP TABLE IF EXISTS LichHoc;
DROP TABLE IF EXISTS TraLoi;
DROP TABLE IF EXISTS CauHoi;
DROP TABLE IF EXISTS ThongBao;
GO

-- Bảng Khoa
CREATE TABLE Khoa (
    MaKhoa VARCHAR(50) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);
GO

-- Bảng SinhVien
CREATE TABLE SinhVien (
    MaSV NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL,
    DiaChi NVARCHAR(100),
    DienThoai VARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    QuocGia NVARCHAR(50),
    DanToc NVARCHAR(50),
    TonGiao NVARCHAR(50),
    MaKhoa VARCHAR(50) REFERENCES Khoa(MaKhoa) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- Bảng Môn học
CREATE TABLE MonHoc (
    MaMH VARCHAR(50) PRIMARY KEY,           -- Mã môn học
    TenMH NVARCHAR(100) NOT NULL,           -- Tên môn học
    SoTiet INT NOT NULL,                    -- Số tiết học
    GiaTinChi DECIMAL(10,2),                -- Giá tiền mỗi tín chỉ
    SoTinChi INT,                           -- Số tín chỉ
    MaKhoa VARCHAR(50),                     -- Mã khoa giảng dạy
    CONSTRAINT FK_MonHoc_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

CREATE TABLE LichHoc (
    MaLichHoc INT IDENTITY(1,1) PRIMARY KEY, 
    MaMH VARCHAR(50) NOT NULL,               
    NgayHoc DATE NOT NULL,                
    ThoiGianBatDau TIME NOT NULL,          
    ThoiGianKetThuc TIME NOT NULL,         
    PhongHoc NVARCHAR(50) NOT NULL,        
    MaGV VARCHAR(50)                      
	);
	GO
	
	ALTER TABLE LichHoc ADD MaSV VARCHAR(50);
GO


-- Bảng GiangVien
CREATE TABLE GiangVien (
    MaGV NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL,
    DienThoai VARCHAR(20) UNIQUE NOT NULL,
	Email NVARCHAR(100) UNIQUE,
	Picture NVARCHAR(MAX) NULL,
	DanToc NVARCHAR(50),
    TonGiao NVARCHAR(50),
    MaMH VARCHAR(50) REFERENCES MonHoc(MaMH) ON DELETE SET NULL ON UPDATE CASCADE
	
);
GO



-- Bảng KetQua
CREATE TABLE KetQua (
    MaSV NVARCHAR(50),
    MaMH VARCHAR(50),
    TenMH NVARCHAR(100),
    Diem DECIMAL(4,2) CHECK (Diem BETWEEN 0 AND 10),
    PRIMARY KEY (MaSV, MaMH),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH) ON DELETE CASCADE ON UPDATE CASCADE
);
GO
ALTER TABLE KetQua ADD DiemChu NVARCHAR(2) DEFAULT N'F' NOT NULL;


CREATE TABLE DangNhap (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(50) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL CHECK (VaiTro IN ('SinhVien', 'GiangVien')),
    MaLienKet NVARCHAR(50) NOT NULL -- MaSV hoặc MaGV tùy VaiTro
);



-- Thêm dữ liệu mẫu
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES 
('CNTT', N'Công nghệ thông tin'),
('DC', N'Đại cương');

-- Sau khi đã ALTER TABLE và xóa 2 cột
INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, Email, QuocGia, DanToc, TonGiao, MaKhoa) VALUES 
('SV001', N'Lê Phan Anh Quốc', '2006-10-01', 1, N'Đắk Lắk', '0769459179', 'conlauban@gmail.com', N'Việt Nam', N'Kinh', N'Thiên Chúa Giáo', 'CNTT'),
('SV002', N'Trần Thị B', '2001-09-15', 0, N'Hà Nội', '0912345678', 'tranthib@gmail.com', N'Việt Nam', N'Tày', N'Phật giáo', 'DC'),
('SV003', N'Nguyễn Hoàng Duy', '2006-03-12', 1, N'TP. Hồ Chí Minh', '0923456789', 'hoangvanc@gmail.com', N'Việt Nam', N'Nùng', N'Thiên Chúa giáo', 'CNTT'),
('SV004', N'Lê Thanh D', '2002-07-18', 1, N'Huế', '0934567890', 'lethanhd@gmail.com', N'Việt Nam', N'Kinh', N'Không', 'CNTT'),
('SV005', N'Phạm Minh E', '2001-11-22', 1, N'Cần Thơ', '0945678901', 'phammine@gmail.com', N'Việt Nam', N'Khmer', N'Phật giáo', 'DC'),
('SV006', N'Ngô Bảo F', '2003-01-10', 1, N'Bắc Giang', '0956789012', 'ngobaof@gmail.com', N'Việt Nam', N'H Mông', N'Tin Lành', 'CNTT'),
('SV007', N'Bùi Thị G', '2002-08-30', 0, N'Đồng Nai', '0967890123', 'buithig@gmail.com', N'Việt Nam', N'Kinh', N'Không', 'DC');




INSERT INTO MonHoc (MaMH, TenMH, SoTiet, GiaTinChi, SoTinChi, MaKhoa) VALUES 
('MH001', N'Lập trình C#', 45, 500000, 3,'CNTT'),
('MH002', N'Cơ sở dữ liệu', 60, 600000, 4,'CNTT'),
('MH003', N'Nhập môn AI', 50, 550000, 4,'CNTT'),
('MH004', N'Triết học Mác-Lênin', 45, 400000, 2,'DC'),
('MH005', N'Toán cao cấp', 60, 450000, 3,'DC'),
('MH006', N'Tiếng Anh chuyên ngành', 50, 500000, 3,'DC');
GO


-- Sau khi đã ALTER TABLE và xóa 2 cột
INSERT INTO GiangVien (MaGV, HoTen, NgaySinh, GioiTinh, DienThoai, Email, DanToc, TonGiao, MaMH) VALUES 
('GV001', N'Nguyễn Thị Thanh', '1980-11-20', 1, '0987654321', 'phamvanc@example.com','Kinh','Không', 'MH001'),
('GV002', N'Lê Thị D', '1985-04-25', 0, '0976543210', 'lethid@example.com','Kinh','Phật giáo', 'MH002');

INSERT INTO KetQua (MaSV, MaMH, TenMH, Diem) VALUES 
-- SV001 (CNTT)
('SV001', 'MH001', N'Lập trình C#', 8.5),
('SV001', 'MH002', N'Cơ sở dữ liệu', 7.5),
('SV001', 'MH003', N'Nhập môn AI', 8.0),
('SV001', 'MH005', N'Toán cao cấp', 7.9), -- thiếu -> thêm
('SV001', 'MH006', N'Tiếng Anh chuyên ngành', 8.2), -- thiếu -> thêm

-- SV002 (QTKD)
('SV002', 'MH004', N'Triết học Mác-Lênin', 7.2),
('SV002', 'MH005', N'Toán cao cấp', 8.0),
('SV002', 'MH006', N'Tiếng Anh chuyên ngành', 7.4),
('SV002', 'MH001', N'Lập trình C#', 6.8), -- thiếu -> thêm
('SV002', 'MH002', N'Cơ sở dữ liệu', 7.3), -- thiếu -> thêm
('SV002', 'MH003', N'Nhập môn AI', 7.5), -- thiếu -> thêm

-- SV003 (CNTT)
('SV003', 'MH001', N'Lập trình C#', 7.5),
('SV003', 'MH002', N'Cơ sở dữ liệu', 6.8),
('SV003', 'MH003', N'Nhập môn AI', 7.3),
('SV003', 'MH004', N'Triết học Mác-Lênin', 6.7), -- thiếu -> thêm
('SV003', 'MH005', N'Toán cao cấp', 8.0), -- thiếu -> thêm

-- SV004 (CNTT)
('SV004', 'MH001', N'Lập trình C#', 7.0),
('SV004', 'MH002', N'Cơ sở dữ liệu', 7.2),
('SV004', 'MH003', N'Nhập môn AI', 7.5),
('SV004', 'MH006', N'Tiếng Anh chuyên ngành', 7.2), -- thiếu -> thêm

-- SV005 (QTKD)
('SV005', 'MH004', N'Triết học Mác-Lênin', 7.4),
('SV005', 'MH005', N'Toán cao cấp', 7.8),
('SV005', 'MH006', N'Tiếng Anh chuyên ngành', 7.7),

-- SV006 (CNTT)
('SV006', 'MH001', N'Lập trình C#', 7.4),
('SV006', 'MH002', N'Cơ sở dữ liệu', 8.0),
('SV006', 'MH003', N'Nhập môn AI', 7.6),
('SV006', 'MH004', N'Triết học Mác-Lênin', 7.4), -- thiếu -> thêm
('SV006', 'MH005', N'Toán cao cấp', 8.1), -- thiếu -> thêm

-- SV007 (QTKD)
('SV007', 'MH004', N'Triết học Mác-Lênin', 7.7),
('SV007', 'MH005', N'Toán cao cấp', 8.0),
('SV007', 'MH006', N'Tiếng Anh chuyên ngành', 8.7),
('SV007', 'MH001', N'Lập trình C#', 7.6), -- thiếu -> thêm
('SV007', 'MH003', N'Nhập môn AI', 8.3); -- thiếu -> thêm
GO
INSERT INTO LichHoc (MaMH, NgayHoc, ThoiGianBatDau, ThoiGianKetThuc, PhongHoc, MaGV, MaSV) 
VALUES 
-- SV001
('MH001', '2025-04-01', '08:00:00', '10:00:00', N'P101', 'GV001', 'SV001'),
('MH002', '2025-04-02', '13:30:00', '15:30:00', N'P102', 'GV002', 'SV001'),
('MH003', '2025-04-03', '10:00:00', '12:00:00', N'P103', 'GV003', 'SV001'),
('MH005', '2025-04-05', '13:30:00', '15:30:00', N'P105', 'GV005', 'SV001'),
('MH006', '2025-04-06', '10:00:00', '12:00:00', N'P106', 'GV006', 'SV001'),

-- SV002
('MH001', '2025-04-01', '08:00:00', '10:00:00', N'P101', 'GV001', 'SV002'),
('MH002', '2025-04-02', '13:30:00', '15:30:00', N'P102', 'GV002', 'SV002'),
('MH003', '2025-04-03', '10:00:00', '12:00:00', N'P103', 'GV003', 'SV002'),
('MH005', '2025-04-05', '13:30:00', '15:30:00', N'P105', 'GV005', 'SV002'),

-- SV003
('MH004', '2025-04-04', '08:00:00', '10:00:00', N'P104', 'GV004', 'SV003'),
('MH005', '2025-04-05', '13:30:00', '15:30:00', N'P105', 'GV005', 'SV003'),

-- SV004
('MH001', '2025-04-01', '08:00:00', '10:00:00', N'P101', 'GV001', 'SV004'),
('MH002', '2025-04-02', '13:30:00', '15:30:00', N'P102', 'GV002', 'SV004'),
('MH006', '2025-04-06', '10:00:00', '12:00:00', N'P106', 'GV006', 'SV004'),

-- SV005
('MH006', '2025-04-06', '10:00:00', '12:00:00', N'P106', 'GV006', 'SV005'),

-- SV006
('MH002', '2025-04-02', '13:30:00', '15:30:00', N'P102', 'GV002', 'SV006'),
('MH003', '2025-04-03', '10:00:00', '12:00:00', N'P103', 'GV003', 'SV006'),
('MH004', '2025-04-04', '08:00:00', '10:00:00', N'P104', 'GV004', 'SV006'),
('MH005', '2025-04-05', '13:30:00', '15:30:00', N'P105', 'GV005', 'SV006'),

-- SV007
('MH001', '2025-04-01', '08:00:00', '10:00:00', N'P101', 'GV001', 'SV007'),
('MH003', '2025-04-03', '10:00:00', '12:00:00', N'P103', 'GV003', 'SV007'),
('MH005', '2025-04-05', '13:30:00', '15:30:00', N'P105', 'GV005', 'SV007'),
('MH006', '2025-04-06', '10:00:00', '12:00:00', N'P106', 'GV006', 'SV007');


UPDATE KetQua
SET DiemChu = 
    CASE 
        WHEN Diem >= 9.0 THEN N'A+'
        WHEN Diem >= 8.0 THEN N'A'
        WHEN Diem >= 7.0 THEN N'B'
        WHEN Diem >= 6.0 THEN N'C'
        WHEN Diem >= 5.0 THEN N'D'
        ELSE N'F'
    END;
	





-- Tạo bảng CauHoi
CREATE TABLE CauHoi (
        MaCauHoi INT IDENTITY(1,1) PRIMARY KEY,
    NoiDungCauHoi NVARCHAR(500),
    NgayTao DATETIME,
    MaSV NVARCHAR(50),
    MaMH VARCHAR(50)
);

-- Tạo bảng TraLoi
CREATE TABLE TraLoi (
       MaTraLoi INT IDENTITY(1,1) PRIMARY KEY,
    NoiDungTraLoi NVARCHAR(500),
    NgayTao DATETIME,
    MaCauHoi INT,
    MaGV NVARCHAR(50)
);

INSERT INTO CauHoi (MaSV, NoiDungCauHoi, NgayTao, MaMH)
VALUES
    ('SV001', N'Giải thích khái niệm JOIN trong SQL?', GETDATE(), 'MH001'),
    ('SV002', N'Giải thích các loại kết nối trong SQL (INNER JOIN, LEFT JOIN, RIGHT JOIN)?', GETDATE(), 'MH002'),
    ('SV003', N'AI là gì và các phương pháp cơ bản trong AI?', GETDATE(), 'MH003'),
    ('SV004', N'Giải thích quan điểm của Mác về sự phát triển của xã hội?', GETDATE(), 'MH004'),
    ('SV005', N'Giải thích định lý Hopital trong toán học?', GETDATE(), 'MH005'),
    ('SV006', N'Giới thiệu các thuật ngữ phổ biến trong Tiếng Anh chuyên ngành CNTT?', GETDATE(), 'MH006');

INSERT INTO TraLoi (NoiDungTraLoi, NgayTao, MaCauHoi, MaGV)
VALUES
    -- Câu hỏi 1 đến 3 (GV001)
    (N'JOIN trong SQL được dùng để kết hợp dữ liệu từ nhiều bảng dựa trên một điều kiện chung.', GETDATE(), 1, 'GV001'),
    (N'INNER JOIN kết hợp các bản ghi có giá trị chung giữa các bảng. LEFT JOIN trả về tất cả các bản ghi từ bảng bên trái và khớp từ bảng bên phải, nếu không có thì điền NULL. RIGHT JOIN tương tự như LEFT JOIN nhưng cho bảng bên phải.', GETDATE(), 2, 'GV001'),
    (N'AI (Artificial Intelligence) là khả năng của một hệ thống máy tính thực hiện các công việc mà thường đòi hỏi trí thông minh của con người như học, suy luận, và nhận thức.', GETDATE(), 3, 'GV001'),

    -- Câu hỏi 4 đến 6 (GV002)
    (N'Mác cho rằng xã hội phát triển theo một quy luật khách quan, thông qua các giai đoạn từ cộng sản nguyên thủy, đến chủ nghĩa tư bản, xã hội chủ nghĩa và cuối cùng là cộng sản chủ nghĩa.', GETDATE(), 4, 'GV002'),
    (N'Định lý Hopital giúp giải quyết các giới hạn dạng vô định 0/0 hoặc vô cùng/vô cùng bằng cách lấy đạo hàm của tử số và mẫu số rồi tính giới hạn', GETDATE(), 5, 'GV002'),
    (N'Thường xuyên sử dụng các thuật ngữ như "algorithm", "machine learning", "neural networks", "data analysis", "deep learning".', GETDATE(), 6, 'GV002');


-- Tạo bảng ThongBao với cột tiêu đề
CREATE TABLE ThongBao (
    MaTB INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe NVARCHAR(255),
    ndThongBao NVARCHAR(500),
    NgayTao DATETIME,
    MaGV NVARCHAR(50)
);

-- Dữ liệu mẫu 1:
INSERT INTO ThongBao (TieuDe, ndThongBao, NgayTao, MaGV)
VALUES (N'Buổi họp toàn trường', N'Hôm nay có buổi họp toàn trường lúc 14:00.', GETDATE(), 'GV001');

-- Dữ liệu mẫu 2:
INSERT INTO ThongBao (TieuDe, ndThongBao, NgayTao, MaGV)
VALUES (N'Hạn nộp bài kiểm tra', N'Hạn chót nộp bài kiểm tra cuối kỳ vào ngày 10/5.', GETDATE(), 'GV002');

-- Dữ liệu mẫu 3:
INSERT INTO ThongBao (TieuDe, ndThongBao, NgayTao, MaGV)
VALUES (N'Thông báo nghỉ học', N'Hôm nay trường đóng cửa vì lý do bảo trì.', GETDATE(), 'GV002');

-- Dữ liệu mẫu 4:
INSERT INTO ThongBao (TieuDe, ndThongBao, NgayTao, MaGV)
VALUES (N'Buổi họp phụ huynh', N'Buổi họp phụ huynh sẽ diễn ra vào ngày mai lúc 18:00.', GETDATE(), 'GV001');

-- Dữ liệu mẫu 5:
INSERT INTO ThongBao (TieuDe, ndThongBao, NgayTao, MaGV)
VALUES (N'Cập nhật lịch thi', N'Lịch thi cuối học kỳ đã được cập nhật, vui lòng kiểm tra trên website trường.', GETDATE(), 'GV001');

-- Dữ liệu mẫu 6:
INSERT INTO ThongBao (TieuDe, ndThongBao, NgayTao, MaGV)
VALUES (N'Mượn sách thư viện', N'Vui lòng trả sách thư viện đúng hạn để tránh bị phạt.', GETDATE(), 'GV001');




INSERT INTO DangNhap (TenDangNhap, MatKhau, VaiTro, MaLienKet)
VALUES 
-- Giảng viên
('gv001', '123456', 'GiangVien', 'GV001'),
('gv002', 'abcdef', 'GiangVien', 'GV002'),

-- Sinh viên
('sv001', 'sv001', 'SinhVien', 'SV001'),
('sv002', 'sv002', 'SinhVien', 'SV002'),
('sv003', 'sv003', 'SinhVien', 'SV003'),
('sv004', 'sv004', 'SinhVien', 'SV004'),
('sv005', 'sv005', 'SinhVien', 'SV005'),
('sv006', 'sv006', 'SinhVien', 'SV006'),
('sv007', 'sv007', 'SinhVien', 'SV007');
