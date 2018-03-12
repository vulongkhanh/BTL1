-- Tạo database
create database ThuViendemo2
go
use ThuViendemo2
go
--TẠO BẢNG BẰNG CÂU LỆNH
CREATE table TheThuVien(
idThe char(10) not null primary key,
HoTen nvarchar(50),
NgaySinh date,
GioiTinh nvarchar(50),
NgayLap date,
HanDung date
)
 
CREATE table NhanVien(
idNV char(10) not null primary key,
TenNV nvarchar(50),
 NgaySinh date,
  GioiTinh nvarchar(50),
   SoDT nvarchar(50),
   DiaChi nvarchar(50)
 
)

CREATE table MuonTraSach(
idPMT char(10) not null primary key,
NgayMuon date,
NgayTra date,
idThe char(10) not null REFERENCES TheThuVien(idThe),
idNV char(10) not null  REFERENCES NhanVien(idNV)
)

CREATE table NXB(
idNXB char(10) not null primary key,
TenNXB nvarchar(50),
NgayNhap date,
SoBan nvarchar(50),
GiaSach nvarchar(50),
SoDT nvarchar(50),
DiaChi nvarchar(50) 

)
CREATE table TacGia(
idTG char(10) not null primary key,
TenTG nvarchar(50),
NgayKiHopDong date,
NgayHetHopDong date,
SoDT nvarchar(50),
DiaChi nvarchar(50) 

)
CREATE table NgonNgu(
idNN char(10) not null primary key,
TenNN nvarchar(50)

)
CREATE table ViTriSach(
idVT char(10) not null primary key,
TenVT nvarchar(50)

)
CREATE table TheLoai(
idLS char(10) not null primary key,
TenTL nvarchar(50)

)
CREATE table TuaSach(
idTS char(10) not null primary key,
TenTS nvarchar(50),
SoTrang nvarchar(50),
idNXB  char(10) not null  REFERENCES NXB(idNXB),
idNN char(10) not null  REFERENCES NgonNgu(idNN), 
idVT  char(10) not null REFERENCES ViTriSach(idVT), 
idLS char(10) not null REFERENCES TheLoai(idLS)
)

CREATE table TG_TS(
idTG char(10) not null ,
idTS char(10) not null REFERENCES TacGia(idTG),
primary key (idTG)
idTS char(10) not null REFERENCES TuaSach(idTS)
)

CREATE table Sach(
SoCaBiet char(10) not null primary key,
TinhTrangSach nvarchar(50),
TinhTrangMuon nvarchar(50),
SoLuong nvarchar(50),
idTS char(10) not null REFERENCES TuaSach(idTS)

)
CREATE table CTPMSach(
idCTPM char (10) not null primary key,
idPMT char(10) not null REFERENCES MuonTraSach(idPMT),
SoCaBiet char(10) not null REFERENCES Sach(SoCaBiet),

)
go

--INSERT DỮ LIỆU BẰNG CÂU LỆNH
--1. thủ tục Insert Thẻ thư viện
CREATE PROC ThemTheThuVien(@idThe char(10), @HoTen Nvarchar(50), @NgaySinh date, @GioiTinh nvarchar(50), @NgayLap date, @HanDung date)
AS
BEGIN
	Insert into TheThuVien( idThe, HoTen, NgaySinh, GioiTinh, NgayLap, HanDung)
	Values (@idThe, @HoTen, @NgaySinh, @GioiTinh, @NgayLap, @HanDung)
END
go
execute ThemTheThuVien @idThe= 't001', @HoTen = N'Vũ Long Khánh', @NgaySinh = N'1997-12-24', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't002', @HoTen = N'Nguyễn Văn Phúc', @NgaySinh = N'1997-01-01', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't003', @HoTen = N'Đặng Văn Công', @NgaySinh = N'1997-03-04', @GioiTinh = N'Nữ', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't004', @HoTen = N'Nguyễn Thành Hiệp', @NgaySinh = N'1997-01-02', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't005', @HoTen = N'Nguyễn Văn Quyền', @NgaySinh = N'1997-07-11', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't006', @HoTen = N'Nguyễn văn Hòa', @NgaySinh = N'1997-09-24', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't007', @HoTen = N'Lưu Đình Phong', @NgaySinh = N'1994-05-20', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't008', @HoTen = N'Trần Đức Sọ', @NgaySinh = N'1993-06-04', @GioiTinh = N'nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't009', @HoTen = N'Phạm Nhữ Chiến', @NgaySinh = N'1997-11-24', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
execute ThemTheThuVien @idThe= 't010', @HoTen = N'Bùi Minh Hiếu', @NgaySinh = N'1997-09-11', @GioiTinh = N'Nữ', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
go

--2. thủ tục Insert Nhân Viên
CREATE PROC ThemNhanVien(@idNV char(10),@TenNV nvarchar(50),@NgaySinh date,@GioiTinh nvarchar(50),@SoDT nvarchar(50), @DiaChi nvarchar(50))
AS
BEGIN
	Insert into NhanVien( idNV, TenNV, NgaySinh, GioiTinh, SoDT, DiaChi)
	Values (@idNV, @TenNV, @NgaySinh, @GioiTinh, @SoDT, @DiaChi)
END
go
execute ThemNhanVien @idNV='nv001', @TenNV=N'Đặng Văn Công', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nữ', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemNhanVien @idNV='nv002', @TenNV=N'Vũ Long Khánh', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nam', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemNhanVien @idNV='nv003', @TenNV=N'Nguyễn Văn Phúc', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nữ', @SoDT='1122334455', @DiaChi= N'Phú Thọ'
execute ThemNhanVien @idNV='nv004', @TenNV=N'Nguyễn Thành Hiệp', @NgaySinh=N'1997-01-02', @GioiTinh=N'Nam', @SoDT='1122334455', @DiaChi= N'Hà Nội'
execute ThemNhanVien @idNV='nv005', @TenNV=N'Nguyễn Văn Quyền', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nữ', @SoDT='1122334455', @DiaChi= N'Hà Nam '
execute ThemNhanVien @idNV='nv006', @TenNV=N'Nguyễn văn Hòa', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nam', @SoDT='1122334455', @DiaChi= N'Hà Nội'
execute ThemNhanVien @idNV='nv007', @TenNV=N'Lưu Đình Phong', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nam', @SoDT='1122334455', @DiaChi= N'Vĩnh Phúc'
execute ThemNhanVien @idNV='nv008', @TenNV=N'Trần Đức Sọ', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nam', @SoDT='1122334455', @DiaChi= N'Phú Thọ'
execute ThemNhanVien @idNV='nv009', @TenNV=N'Phạm Nhữ Chiến', @NgaySinh=N'1997-11-24', @GioiTinh=N'Nam', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemNhanVien @idNV='nv010', @TenNV=N'Bùi Minh Hiếu', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nữ', @SoDT='1122334455', @DiaChi= N'Hòa Bình'
go

--3. thủ tục Insert Mượn trả sách
CREATE PROC ThemMuonTraSach( @idPMT char(10),@NgayMuon date,@NgayTra date,@idThe char(10),@idNV char(10))
AS
BEGIN
	Insert into MuonTraSach ( idPMT, NgayMuon, NgayTra, idThe, idNV)
	Values ( @idPMT, @NgayMuon, @NgayTra, @idThe, @idNV)
END
go
execute ThemMuonTraSach @idPMT= 'pmt001', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't001', @idNV = 'nv001'
execute ThemMuonTraSach @idPMT= 'pmt002', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't002', @idNV = 'nv002'
execute ThemMuonTraSach @idPMT= 'pmt003', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't003', @idNV = 'nv003'
execute ThemMuonTraSach @idPMT= 'pmt004', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't004', @idNV = 'nv004'
execute ThemMuonTraSach @idPMT= 'pmt005', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't005', @idNV = 'nv005'
execute ThemMuonTraSach @idPMT= 'pmt006', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't006', @idNV = 'nv006'
execute ThemMuonTraSach @idPMT= 'pmt007', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't007', @idNV = 'nv007'
execute ThemMuonTraSach @idPMT= 'pmt008', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't008', @idNV = 'nv008'
execute ThemMuonTraSach @idPMT= 'pmt009', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't009', @idNV = 'nv009'
execute ThemMuonTraSach @idPMT= 'pmt010', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't010', @idNV = 'nv010'

go
----4. thủ tục Insert Thanh Lí
--CREATE PROC ThemThanhLi(@idTL char(10), @TenSach nvarchar(50), @NgayThanhLy date, @LyDo nvarchar(50))
--AS
--BEGIN
--	Insert into ThanhLi( idTL, TenSach, NgayThanhLy, LyDo)
--	Values (@idTL, @TenSach, @NgayThanhLy, @LyDo)
--END
--go
--execute ThemThanhLi @idTL='tl001', @TenSach=N'Trà sữa cho tâm hồn', @NgayThanhLy=N'1997-12-24', @LyDo=N'Bị hỏng'
--execute ThemThanhLi @idTL='tl002', @TenSach=N'Lão Hạc', @NgayThanhLy=N'1997-12-24', @LyDo=N'Buồn'
--execute ThemThanhLi @idTL='tl003', @TenSach=N'Hồi đó ở Sa Kỳ', @NgayThanhLy=N'1997-12-24', @LyDo=N'Khó hiểu'
--execute ThemThanhLi @idTL='tl004', @TenSach=N'Tấm Cám', @NgayThanhLy=N'1997-12-24', @LyDo=N'Thích'
--execute ThemThanhLi @idTL='tl005', @TenSach=N'Hóa 10', @NgayThanhLy=N'2005-01-05', @LyDo=N'Bị hỏng'
--execute ThemThanhLi @idTL='tl006', @TenSach=N'Đắc Nhân Tâm', @NgayThanhLy=N'1997-12-24', @LyDo=N'Bị hỏng'
--execute ThemThanhLi @idTL='tl007', @TenSach=N'Truyện Kiều', @NgayThanhLy=N'2010-01-4', @LyDo=N'Buồn'
--execute ThemThanhLi @idTL='tl008', @TenSach=N'Truyện Cổ tích Thạch Sanh', @NgayThanhLy=N'2000-03-11', @LyDo=N'Bị Hỏng'
--execute ThemThanhLi @idTL='tl009', @TenSach=N'Toán 12', @NgayThanhLy=N'2017-12-29', @LyDo=N'Hết hạn'
--execute ThemThanhLi @idTL='tl010', @TenSach=N'Anh', @NgayThanhLy=N'2017-06-28', @LyDo=N'Nâng Cấp'

--go
--5. thủ tục Insert NXB
CREATE PROC ThemNXB(@idNXB char(10),@TenNXB nvarchar(50),@NgayNhap date,@SoBan nvarchar(50),@GiaSach nvarchar(50),@SoDT nvarchar(50),@DiaChi nvarchar(50) )
AS
BEGIN
	Insert into NXB(idNXB, TenNXB, NgayNhap, SoBan, GiaSach, SoDT, DiaChi)
	Values (@idNXB, @TenNXB, @NgayNhap, @SoBan, @GiaSach, @SoDT, @DiaChi)
END
go
execute ThemNXB @idNXB='nxb001', @TenNXB=N'NXB Giáo Dục', @NgayNhap=N'1997-12-24', @SoBan='50', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Nam Định'
execute ThemNXB @idNXB='nxb002', @TenNXB=N'NXB Giáo Dục', @NgayNhap=N'1997-12-24', @SoBan='46', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Hà Nội'
execute ThemNXB @idNXB='nxb003', @TenNXB=N'NXB Giáo Dục', @NgayNhap=N'1997-12-24', @SoBan='50', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'HCM'
execute ThemNXB @idNXB='nxb004', @TenNXB=N'NXB Kim Đồng', @NgayNhap=N'1997-12-24', @SoBan='150', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Lào Cai'
execute ThemNXB @idNXB='nxb005', @TenNXB=N'NXB Kim Đồng', @NgayNhap=N'1997-12-24', @SoBan='500', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Nam Định'
execute ThemNXB @idNXB='nxb006', @TenNXB=N'NXB Giáo Dục', @NgayNhap=N'1997-12-24', @SoBan='500', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Nam Định'
execute ThemNXB @idNXB='nxb007', @TenNXB=N'NXB Giáo Dục', @NgayNhap=N'1997-12-24', @SoBan='460', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Hà Nội'
execute ThemNXB @idNXB='nxb008', @TenNXB=N'NXB Giáo Dục', @NgayNhap=N'1997-12-24', @SoBan='550', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'HCM'
execute ThemNXB @idNXB='nxb009', @TenNXB=N'NXB Trẻ', @NgayNhap=N'1997-12-24', @SoBan='510', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Lào Cai'
execute ThemNXB @idNXB='nxb010', @TenNXB=N'NXB Nhân Dân', @NgayNhap=N'1997-12-24', @SoBan='120', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Nam Định'
go
--6. thủ tục Insert Tác giả
CREATE PROC ThemTacGia(@idTG char(10),@TenTG nvarchar(50),@NgayKiHopÐong date,@NgayHetHopÐong date,@SoDT nvarchar(50),@DiaChi nvarchar(50) )
AS
BEGIN
	Insert into TacGia( idTG, TenTG, NgayKiHopDong, NgayHetHopDong, SoDT, DiaChi)
	Values (@idTG, @TenTG, @NgayKiHopÐong, @NgayHetHopÐong, @SoDT, @DiaChi)
END
go
execute ThemTacGia @idTG='tg001', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg002', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg003', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg004', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg005', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg006', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg007', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg008', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg009', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
execute ThemTacGia @idTG='tg010', @TenTG=N'Phạm Nhữ Chiến', @NgayKiHopÐong=N'1997-12-24', @NgayHetHopÐong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'
go

--7. thủ tục Insert Ngôn ngữ
CREATE PROC ThemNgonNgu(@idNN char(10), @TenNN nvarchar(50))
AS
BEGIN
	Insert into NgonNgu(idNN, TenNN)
	Values (@idNN, @TenNN)
END
go
execute ThemNgonNgu @idNN='nn001', @TenNN=N'Nguyễn Văn Phúc'
execute ThemNgonNgu @idNN='nn002', @TenNN=N'f'
execute ThemNgonNgu @idNN='nn003', @TenNN=N'g'
execute ThemNgonNgu @idNN='nn004', @TenNN=N'hc'
execute ThemNgonNgu @idNN='nn005', @TenNN=N'j'
execute ThemNgonNgu @idNN='nn006', @TenNN=N'Nguyễn Văn Phúc'
execute ThemNgonNgu @idNN='nn007', @TenNN=N'f'
execute ThemNgonNgu @idNN='nn008', @TenNN=N'g'
execute ThemNgonNgu @idNN='nn009', @TenNN=N'hc'
execute ThemNgonNgu @idNN='nn010', @TenNN=N'j'
go

--8. thủ tục Insert vị trí sách
CREATE PROC ThemViTriSach(@idVT char(10),@TenVT nvarchar(50))
AS
BEGIN
	Insert into ViTriSach(idVT, TenVT)
	Values (@idVT, @TenVT)
END
go
execute ThemViTriSach @idVT='vt001', @TenVT=N'qqqq'
execute ThemViTriSach @idVT='vt002', @TenVT=N'qadqqq'
execute ThemViTriSach @idVT='vt003', @TenVT=N'qfgqqq'
execute ThemViTriSach @idVT='vt004', @TenVT=N'qqfdgqq'
execute ThemViTriSach @idVT='vt005', @TenVT=N'qqhfdhqq'
execute ThemViTriSach @idVT='vt006', @TenVT=N'qqqq'
execute ThemViTriSach @idVT='vt007', @TenVT=N'qadqqq'
execute ThemViTriSach @idVT='vt008', @TenVT=N'qfgqqq'
execute ThemViTriSach @idVT='vt009', @TenVT=N'qqfdgqq'
execute ThemViTriSach @idVT='vt010', @TenVT=N'qqhfdhqq'
go
--9.thủ tục Insert thể loại
CREATE PROC ThemTheLoai(@idLS char(10), @TenTL nvarchar(50))
AS
BEGIN
	Insert into TheLoai(idLS, TenTL)
	Values (@idLS, @TenTL)
END
go
execute ThemTheLoai @idLS='ls001', @TenTL=N'Trinh Thám'
execute ThemTheLoai @idLS='ls002', @TenTL=N'Tiểu thuyết'
execute ThemTheLoai @idLS='ls003', @TenTL=N'Ngôn tình'
execute ThemTheLoai @idLS='ls004', @TenTL=N'Khám phá'
execute ThemTheLoai @idLS='ls005', @TenTL=N'thực phẩm'
execute ThemTheLoai @idLS='ls006', @TenTL=N'Trinh Thám'
execute ThemTheLoai @idLS='ls007', @TenTL=N'Tiểu thuyết'
execute ThemTheLoai @idLS='ls008', @TenTL=N'Ngôn tình'
execute ThemTheLoai @idLS='ls009', @TenTL=N'Khám phá'
execute ThemTheLoai @idLS='ls010', @TenTL=N'thực phẩm'
go

--10. thủ tục Insert tựa sách
CREATE PROC ThemTuaSach(@idTS char(10),@TenTS nvarchar(50),@SoTrang nvarchar(50), @idNXB  char(10),@idNN char(10), @idVT char(10), @idLS char(10))
AS
BEGIN
	Insert into TuaSach(idTS, TenTS, SoTrang, idNXB, idNN, idVT, idLS)
	Values (@idTS, @TenTS, @SoTrang, @idNXB, @idNN, @idVT, @idLS)
END
go
execute ThemTuaSach @idTS='ts001', @TenTS=N'Conan', @SoTrang='50', @idNXB='nxb001', @idNN='nn001', @idVT='vt001', @idLS='ls001'
execute ThemTuaSach @idTS='ts002', @TenTS=N'a', @SoTrang='50', @idNXB='nxb002', @idNN='nn002', @idVT='vt002', @idLS='ls002'
execute ThemTuaSach @idTS='ts003', @TenTS=N'b', @SoTrang='50', @idNXB='nxb003', @idNN='nn003', @idVT='vt003', @idLS='ls003'
execute ThemTuaSach @idTS='ts004', @TenTS=N'c', @SoTrang='50', @idNXB='nxb004', @idNN='nn004', @idVT='vt004', @idLS='ls004'
execute ThemTuaSach @idTS='ts005', @TenTS=N'd', @SoTrang='50', @idNXB='nxb005', @idNN='nn005', @idVT='vt005', @idLS='ls005'
execute ThemTuaSach @idTS='ts006', @TenTS=N'Conan', @SoTrang='50', @idNXB='nxb006', @idNN='nn006', @idVT='vt006', @idLS='ls006'
execute ThemTuaSach @idTS='ts007', @TenTS=N'a', @SoTrang='50', @idNXB='nxb007', @idNN='nn007', @idVT='vt007', @idLS='ls007'
execute ThemTuaSach @idTS='ts008', @TenTS=N'b', @SoTrang='50',@idNXB='nxb008', @idNN='nn008', @idVT='vt008', @idLS='ls008'
execute ThemTuaSach @idTS='ts009', @TenTS=N'c', @SoTrang='50', @idNXB='nxb009', @idNN='nn009', @idVT='vt009', @idLS='ls009'
execute ThemTuaSach @idTS='ts010', @TenTS=N'd', @SoTrang='50', @idNXB='nxb010', @idNN='nn010', @idVT='vt010', @idLS='ls010'
go

--11. thủ tục Insert sách
CREATE PROC ThemSach(@SoCaBiet char(10),@TinhTrangSach nvarchar(50),@TinhTrangMuon nvarchar(50),@SoLuong nvarchar(50),@idTS char(10))
AS
BEGIN
	Insert into Sach(SoCaBiet, TinhTrangSach, TinhTrangMuon, SoLuong, idTS)
	Values ( @SoCaBiet, @TinhTrangSach, @TinhTrangMuon, @SoLuong, @idTS)
END
go
execute ThemSach @SoCaBiet='scb001', @TinhTrangSach=N'Cũ',@TinhTrangMuon=N'Có thể mượn',@SoLuong='50', @idTS='ts001'
execute ThemSach @SoCaBiet='scb002', @TinhTrangSach=N'Mới',@TinhTrangMuon=N'Có thể mượn',@SoLuong='50', @idTS='ts002'
execute ThemSach @SoCaBiet='scb003', @TinhTrangSach=N'Mới',@TinhTrangMuon=N'Không thể mượn',@SoLuong='50', @idTS='ts003'
execute ThemSach @SoCaBiet='scb004', @TinhTrangSach=N'Cũ',@TinhTrangMuon=N'Có thể mượn',@SoLuong='50', @idTS='ts004'
execute ThemSach @SoCaBiet='scb005', @TinhTrangSach=N'Cũ',@TinhTrangMuon=N'Có thể mượn',@SoLuong='50', @idTS='ts005'
execute ThemSach @SoCaBiet='scb006', @TinhTrangSach=N'Cũ',@TinhTrangMuon=N'Không thể mượn',@SoLuong='50', @idTS='ts006'
execute ThemSach @SoCaBiet='scb007', @TinhTrangSach=N'Mới',@TinhTrangMuon=N'Có thể mượn',@SoLuong='50', @idTS='ts003'
execute ThemSach @SoCaBiet='scb008', @TinhTrangSach=N'Cũ',@TinhTrangMuon=N'Không thể mượn',@SoLuong='50', @idTS='ts003'
execute ThemSach @SoCaBiet='scb009', @TinhTrangSach=N'Mới',@TinhTrangMuon=N'Có thể mượn',@SoLuong='50', @idTS='ts004'
execute ThemSach @SoCaBiet='scb010', @TinhTrangSach=N'Cũ',@TinhTrangMuon=N'Có thể mượn',@SoLuong='50', @idTS='ts001'
go

--12.thủ tục Insert chi tiết phiếu mượn
CREATE PROC ThemCTPMSach(@idCTPM char(10), @idPMT char(10),@SoCaBiet char(10))
AS
BEGIN
	Insert into CTPMSach(idCTPM, idPMT, SoCaBiet)
	Values (@idCTPM,@idPMT, @SoCaBiet)
END
go
execute ThemCTPMSach @idCTPM = 'ctpm001',@idPMT='pmt001', @SoCaBiet='scb001'
execute ThemCTPMSach @idCTPM = 'ctpm002',@idPMT='pmt002', @SoCaBiet='scb002'
execute ThemCTPMSach @idCTPM = 'ctpm003',@idPMT='pmt003', @SoCaBiet='scb003'
execute ThemCTPMSach @idCTPM = 'ctpm004',@idPMT='pmt004', @SoCaBiet='scb004'
execute ThemCTPMSach @idCTPM = 'ctpm005',@idPMT='pmt005', @SoCaBiet='scb005'
execute ThemCTPMSach @idCTPM = 'ctpm006',@idPMT='pmt006', @SoCaBiet='scb006'
execute ThemCTPMSach @idCTPM = 'ctpm007',@idPMT='pmt007', @SoCaBiet='scb007'
execute ThemCTPMSach @idCTPM = 'ctpm008',@idPMT='pmt008', @SoCaBiet='scb008'
execute ThemCTPMSach @idCTPM = 'ctpm009',@idPMT='pmt009', @SoCaBiet='scb009'
execute ThemCTPMSach @idCTPM = 'ctpm010',@idPMT='pmt010', @SoCaBiet='scb010'
go

--12.thủ tục Insert chi tiết phiếu mượn
CREATE PROC ThemTG_TS(@idTGTS char(10), @idTG char(10),@idTS char(10))
AS
BEGIN
	Insert into TG_TS(idTGTS, idTG, idTS)
	Values (@idTGTS,@idTG, @idTS)
END
go
execute ThemTG_TS @idTGTS = 'tgts001',@idTG='tg001', @idTS='ts001'
execute ThemTG_TS @idTGTS = 'tgts002',@idTG='tg002', @idTS='ts002'
execute ThemTG_TS @idTGTS = 'tgts003',@idTG='tg003', @idTS='ts003'
execute ThemTG_TS @idTGTS = 'tgts004',@idTG='tg004', @idTS='ts004'
execute ThemTG_TS @idTGTS = 'tgts005',@idTG='tg005', @idTS='ts005'
execute ThemTG_TS @idTGTS = 'tgts006',@idTG='tg006', @idTS='ts006'
execute ThemTG_TS @idTGTS = 'tgts007',@idTG='tg007', @idTS='ts007'
execute ThemTG_TS @idTGTS = 'tgts008',@idTG='tg008', @idTS='ts008'
execute ThemTG_TS @idTGTS = 'tgts009',@idTG='tg009', @idTS='ts009'
execute ThemTG_TS @idTGTS = 'tgts010',@idTG='tg010', @idTS='ts010'
go


----------------------UPDATE DỮ LIỆU BẰNG CÂU LỆNH----------------------------------------------

------UPDATE Bảng Thẻ thư viện-----
go
CREATE PROC EDITTheThuVien(@idThe char(10), @HoTen Nvarchar(50), @NgaySinh date, @GioiTinh nvarchar(50), @NgayLap date, @HanDung date)
AS
BEGIN
	Update TheThuVien
	set  HoTen= @HoTen, NgaySinh= @NgaySinh, GioiTinh = @GioiTinh, NgayLap = @NgayLap, HanDung = @HanDung
	Where idThe=@idThe
END
go
execute EDITTheThuVien @idThe= 't001', @HoTen = N'Vũ Long Khánh', @NgaySinh = N'1997-12-24', @GioiTinh = N'Nam', @NgayLap = N'2017-01-01', @HanDung = N'2018-01-01'
go

--2. thủ tục UPDATE Nhân Viên
CREATE PROC EditNhanVien(@idNV char(10),@TenNV nvarchar(50),@NgaySinh date,@GioiTinh nvarchar(50),@SoDT nvarchar(50), @DiaChi nvarchar(50))
AS
BEGIN
    update NhanVien
	SET TenNV =@TenNV, NgaySinh=@NgaySinh, GioiTinh = @GioiTinh, SoDT =@SoDT, DiaChi=@DiaChi
	Where idNV=@idNV
END
go
execute EditNhanVien @idNV='nv001', @TenNV=N'Đặng Văn Công', @NgaySinh=N'1997-01-01', @GioiTinh=N'Nữ', @SoDT='1122334455', @DiaChi= N'Nam Định'
go
--3. thủ tục UPDATE Mượn trả sách
CREATE PROC EDITMuonTraSach( @idPMT char(10),@NgayMuon date,@NgayTra date,@idThe char(10),@idNV char(10))
AS
BEGIN
	UPDATE MuonTraSach
	set  NgayMuon=@NgayMuon, NgayTra = @NgayTra , idThe=@idThe, idNV=@idNV
	where idPMT= @idPMT
END
go
execute EDITMuonTraSach @idPMT= 'pmt001', @NgayMuon = '2017-02-12', @NgayTra = '2017-10-12', @idThe = 't001', @idNV = 'nv001'
go
--4. thủ tục UPDATE Thanh Lí
--CREATE PROC EDITThanhLi(@idTL char(10), @TenSach nvarchar(50), @NgayThanhLy date, @LyDo nvarchar(50))
--AS
--BEGIN
--	UPDATE ThanhLi
--	SET TenSach=@TenSach, NgayThanhLy= @NgayThanhLy, LyDo=@LyDo
--	where idTL=@idTL
--END
--go
--execute EDITThanhLi @idTL='tl001', @TenSach=N'Trà sữa cho tâm hồn', @NgayThanhLy=N'1997-12-24', @LyDo=N'Bị hỏng'

--go
--5. thủ tục UPDATE NXB
CREATE PROC EDITNXB(@idNXB char(10),@TenNXB nvarchar(50),@NgayNhap date,@SoBan nvarchar(50),@GiaSach nvarchar(50),@SoDT nvarchar(50),@DiaChi nvarchar(50) )
AS
BEGIN
	UPDATE NXB
	SET TenNXB=@TenNXB, NgayNhap= @NgayNhap, SoBan =@SoBan, GiaSach= @GiaSach, SoDT=@SoDT, DiaChi=@DiaChi
	WHERE idNXB = @idNXB
END
go
execute EDITNXB @idNXB='nxb001', @TenNXB=N'NXB Giáo Dục', @NgayNhap=N'1997-12-24', @SoBan='50', @GiaSach='1122334455',@SoDT='012346546', @DiaChi= N'Nam Định'

go
--6. thủ tục UPDATE Tác giả
CREATE PROC EDITTacGia(@idTG char(10),@TenTG nvarchar(50),@NgayKiHopDong date,@NgayHetHopDong date,@SoDT nvarchar(50),@DiaChi nvarchar(50) )
AS
BEGIN
	UPDATE TacGia
	SET TenTG=@TenTG, NgayKiHopDong =@NgayKiHopDong, NgayHetHopDong=@NgayHetHopDong, SoDT=@SoDT, DiaChi=@DiaChi
	Where idTG=@idTG
END
go
execute EDITTacGia @idTG='tg010', @TenTG=N'Vũ Long Khánh', @NgayKiHopDong=N'1997-12-24', @NgayHetHopDong=N'1997-12-24', @SoDT='1122334455', @DiaChi= N'Nam Định'

go
--7. thủ tục UPDATE Ngôn ngữ
CREATE PROC EDITNgonNgu(@idNN char(10), @TenNN nvarchar(50))
AS
BEGIN
	UPDATE NgonNgu
	SET TenNN=@TenNN
	WHere idNN=@idNN
END
go
execute EDITNgonNgu @idNN='nn001', @TenNN=N'Nguyễn Văn Phúc'
go

--8. thủ tục UPDATE vị trí sách
CREATE PROC EDITViTriSach(@idVT char(10),@TenVT nvarchar(50))
AS
BEGIN
	UPDATE ViTriSach
	SET TenVT=@TenVT
	WHERE idVT =@idVT
END
go
execute EDITViTriSach @idVT='vt001', @TenVT=N'qqqq'

go
--9.thủ tục UPDATE thể loại
CREATE PROC EDITTheLoai(@idLS char(10), @TenTL nvarchar(50))
AS
BEGIN
	UPDATE TheLoai
	SET TenTL=@TenTL
	Where idLS=@idLS
END
go
execute EDITTheLoai @idLS='ls001', @TenTL=N'Trinh Thám'
go

--10. thủ tục UPDATE tựa sách
CREATE PROC EDITTuaSach(@idTS char(10),@TenTS nvarchar(50),@SoTrang nvarchar(50), @idNXB  char(10),@idNN char(10), @idVT char(10), @idLS char(10))
AS
BEGIN
	UPDATE TuaSach
	SET TenTS= @TenTS, SoTrang =@SoTrang, idNXB= @idNXB, idNN= @idNN, idVT =@idVT, idLS=@idLS
	WHERe idLS=@idTS
END
go
execute EDITTuaSach @idTS='ts001', @TenTS=N'Conan', @SoTrang='50', @idNXB='nxb001', @idNN='nn001', @idVT='vt001', @idLS='ls001'
go
--11. thủ tục UPDATE sách
CREATE PROC EDITSach(@SoCaBiet char(10),@TinhTrangSach nvarchar(50),@TinhTrangMuon nvarchar(50),@SoLuong nvarchar(50),@idTS char(10))
AS
BEGIN
	UPDATE Sach
	SET TinhTrangSach =@TinhTrangSach, TinhTrangMuon =@TinhTrangMuon, SoLuong =@SoLuong, idTS =@idTS
	Where SoCaBiet=@SoCaBiet
END
go
execute EDITSach @SoCaBiet='scb001', @TinhTrangSach=N'Cũ', @TinhTrangMuon=N'Có Thể Mượn', @SoLuong=N'52', @idTS='ts001'
go

CREATE PROC EDITTGTS (@idTGTS char(10),@idTG char(10),@idTS char(10))
AS
BEGIN
	UPDATE TG_TS
	SEt idTG=@idTG, idTS=@idTS
	Where idTGTS= @idTGTS
END
go
execute EDITTGTS @idTGTS='tgts005',@idTG='tg004', @idTS='ts006'

go
--12.thủ tục UPDATE chi tiết phiếu mượn
CREATE PROC EDITCTPMSach (@idCTPM char(10),@idPMT char(10),@SoCaBiet char(10))
AS
BEGIN
	UPDATE CTPMSach
	SEt SoCaBiet=@SoCaBiet, idPMT=@idPMT
	Where idCTPM= @idCTPM
END
go
execute EDITCTPMSach @idCTPM='ctpm005',@idPMT='pmt001', @SoCaBiet='scb001'


--- delete dữ liệu ---- KHÔNG THỬ ------------------------------
--1.xóa thẻ thư viện
go
CREATE PROC DeleteTheThuVien(@idThe varchar(10))
AS
BEGIN
	DELETE FROM TheThuVien Where (idThe= @idThe)
END
go
execute DeleteTheThuVien @idThe= ''
go
--2.xóa thẻ Nhân viên
go
CREATE PROC DeleteNhanVien(@idNV varchar(10))
AS
BEGIN
	DELETE FROM NhanVien Where (idNV= @idNV)
END
go
execute DeleteNhanVien @idNV= ''
go
--3.xóa thẻ mượn trả sách
go
CREATE PROC DeleteMuonTraSach(@idPMT varchar(10))
AS
BEGIN
	DELETE FROM MuonTraSach Where (idPMT= @idPMT)
END
go
execute DeleteMuonTraSach @idPMT= ''
go
----4. thủ tục DELETE Thanh Lí
--CREATE PROC DELETEThanhLi(@idTL char(10))
--AS
--BEGIN
--	DELETE FROM ThanhLi Where (idTL=@idTL)
--END
--go
--execute DELETEThanhLi @idTL= ''
--go
--5. thủ tục DELETE NXB
CREATE PROC DELETENXB(@idNXB char(10))
AS
BEGIN
	DELETE FROM NXB Where (idNXB=@idNXB)
END
go
execute DELETENXB @idNXB= ''
go
--6. thủ tục DELETE Tác giả
CREATE PROC DELETETacGia(@idTG char(10) )
AS
BEGIN
	DELETE FROM TacGia Where (idTG=@idTG)
END
go
execute DELETETacGia @idTG= ''
go
--7. thủ tục DELETE Ngôn ngữ
CREATE PROC DELETENgonNgu(@idNN char(10))
AS
BEGIN
	DELETE FROM NgonNgu Where (idNN=@idNN)
END
go
execute DELETENgonNgu @idNN= ''
go
--8. thủ tục Delete vị trí sách
CREATE PROC DeleteViTriSach(@idVT char(10))
AS
BEGIN
	DELETE FROM ViTriSach Where (idVT=@idVT)
END
go
execute DeleteViTriSach @idVT= ''
go

--9.thủ tục Delete thể loại
CREATE PROC DELETETheLoai(@idLS char(10))
AS
BEGIN
	DELETE FROM TheLoai Where (idLS=@idLS)
END
go
execute DELETETheLoai @idLS= ''
go
--10. thủ tục DELETE tựa sách
CREATE PROC DELETETuaSach(@idTS char(10))
AS
BEGIN
	DELETE FROM TuaSach Where (idTS=@idTS)
END
go
execute DELETETuaSach @idTS= ''
go
--11. thủ tục DELETE sách
CREATE PROC DELETESach(@SoCaBiet char(10))
AS
BEGIN
	DELETE FROM Sach Where (SoCaBiet=@SoCaBiet)
END
go
execute DELETESach @SoCaBiet= ''
go
--12.thủ tục DELETE chi tiết phiếu mượn
CREATE PROC DELETECTPMSach(@idCTPM char(10))
AS
BEGIN
	DELETE FROM CTPMSach Where (idCTPM=@idCTPM)
END
go
execute DELETECTPMSach @idCTPM= ''
go

CREATE PROC DELETETGTS(@idTGTS char(10))
AS
BEGIN
	DELETE FROM TG_TS Where (idTGTS=@idTGTS)
END
go
execute DELETETGTS @idTGTS= ''
go