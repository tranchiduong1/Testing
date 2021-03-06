USE master
GO
/****** Object:  Database [QLPetMarket]    Script Date: 10/18/2018 6:44:34 PM ******/
CREATE DATABASE [QuanLiPetMarket] ON  PRIMARY 
( NAME = N'QLPetMarket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLPetMarket.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPetMarket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLPetMarket_log.ldf' , SIZE = 2560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPetMarket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPetMarket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLPetMarket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLPetMarket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLPetMarket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLPetMarket] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLPetMarket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLPetMarket] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLPetMarket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLPetMarket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLPetMarket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLPetMarket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLPetMarket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLPetMarket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLPetMarket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLPetMarket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLPetMarket] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLPetMarket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLPetMarket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLPetMarket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLPetMarket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLPetMarket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLPetMarket] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLPetMarket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLPetMarket] SET RECOVERY FULL 
GO
ALTER DATABASE [QLPetMarket] SET  MULTI_USER 
GO
ALTER DATABASE [QLPetMarket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLPetMarket] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLPetMarket', N'ON'
GO
USE [QLPetMarket]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/18/2018 6:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHDBan] [nvarchar](30) NOT NULL,
	[MaNhanVien] [int] NULL,
	[NgayBan] [datetime] NULL,
	[MaKhachHang] [nvarchar](10) NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonChiTiet]    Script Date: 10/18/2018 6:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonChiTiet](
	[MaHDBan] [nvarchar](30) NOT NULL,
	[MaSanPham] [nvarchar](50) NOT NULL,
	[SoLuong] [float] NULL,
	[DonGia] [float] NULL,
	[GiamGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_HoaDonChiTiet] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 10/18/2018 6:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](10) NOT NULL,
	[HoKhachHang] [nvarchar](50) NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[DienThoai] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 10/18/2018 6:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSanPham] [nvarchar](50) NOT NULL,
	[TenLoaiSanPham] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/18/2018 6:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] NOT NULL,
	[HoNhanVien] [nvarchar](20) NOT NULL,
	[TenNhanVien] [nvarchar](10) NOT NULL,
	[ChucDanh] [nvarchar](30) NULL,
	[NgaySinh] [date] NULL,
	[NgayBatDauLamViec] [datetime] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](60) NULL,
	[SoDienThoai] [nvarchar](10) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/18/2018 6:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [nvarchar](50) NOT NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[MaLoaiSanPham] [nvarchar](50) NULL,
	[SoLuongTonKho] [float] NULL,
	[DonGiaNhap] [float] NULL,
	[DonGiaBan] [float] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoanNhanVien]    Script Date: 10/18/2018 6:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanNhanVien](
	[TaiKhoan] [nvarchar](16) NOT NULL,
	[MatKhau] [nchar](8) NULL,
 CONSTRAINT [PK_TaiKhoanNhanVien] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HD01', 1651010034, CAST(0x0000A92F00000000 AS DateTime), N'KH01', 50000)
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HD02', 1651010144, CAST(0x0000A93000000000 AS DateTime), N'KH02', 150000)
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HD03', 1651010144, CAST(0x0000A93200000000 AS DateTime), N'KH03', 155000)
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HD04', 1651010034, CAST(0x0000A93700000000 AS DateTime), N'KH04', 40000000)
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HD05', 1651010144, CAST(0x0000A93900000000 AS DateTime), N'KH05', 100000)
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HD06', 1651010034, CAST(0x0000A94200000000 AS DateTime), N'KH06', 1750000)
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HD098', 1651010034, CAST(0x0000000000000000 AS DateTime), N'KH01', 1234)
INSERT [dbo].[HoaDon] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhachHang], [TongTien]) VALUES (N'HDHD', 1651010034, CAST(0x0000A97600000000 AS DateTime), N'KH03', 0)
INSERT [dbo].[HoaDonChiTiet] ([MaHDBan], [MaSanPham], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HD01', N'CSCM01', 10, 5000, 0, 50000)
INSERT [dbo].[HoaDonChiTiet] ([MaHDBan], [MaSanPham], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HD02', N'DDCM01', 5, 30000, 0, 150000)
INSERT [dbo].[HoaDonChiTiet] ([MaHDBan], [MaSanPham], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HD03', N'DPCM02', 1, 155000, 0, 155000)
INSERT [dbo].[HoaDonChiTiet] ([MaHDBan], [MaSanPham], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HD04', N'PKCM04', 1, 40000000, 1400000, 38600000)
INSERT [dbo].[HoaDonChiTiet] ([MaHDBan], [MaSanPham], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HD05', N'TACM02', 4, 25000, 0, 100000)
INSERT [dbo].[HoaDonChiTiet] ([MaHDBan], [MaSanPham], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HD06', N'TACM01', 1, 1750000, 0, 1750000)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH', N'LêLai', N'', N'', N'')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH01', N'Lê', N'Khôi', N'1 đường Lê Khôi', N'123456789')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH02', N'Lê', N'Sao', N'2 đường Lê Sao', N'987654321')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH03', N'Lê ', N'Niệm', N'3 đường Lê Niệm', N'963258741')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH04', N'Lê', N'Thiệt', N'4 đường Lê Thiệt', N'147852369')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH05', N'Lê', N'Lai', N'5 đường Lê Lai', N'9874456321')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH06', N'Lê', N'Thúc Hoạch', N'6 đường Lê Thúc Hoạch', N'321456978')
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (N'KH07', N'Lê', N'Lợi', N'7 đường Lê Lợi', N'123654789')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'CMDM', N'chó')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'CSCM', N'Chăm sóc chó mèo')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'DDCM', N'Đồ dùng chó mèo')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'DPCM', N'Dược phẩm chó mèo')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'PKCM', N'Phụ kiện chó mèo')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'TACM', N'Thức ăn chó mèo')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoNhanVien], [TenNhanVien], [ChucDanh], [NgaySinh], [NgayBatDauLamViec], [GioiTinh], [DiaChi], [SoDienThoai]) VALUES (1651010034, N'Trần ', N'Chí Dương', N'Giám đốc điều hành', CAST(0x2F210B00 AS Date), NULL, N'Nam', N'477 Âu Cơ', N'0768288714')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoNhanVien], [TenNhanVien], [ChucDanh], [NgaySinh], [NgayBatDauLamViec], [GioiTinh], [DiaChi], [SoDienThoai]) VALUES (1651010090, N'Bành ', N'Gia Mãn', N'Bảo vệ', CAST(0xA2210B00 AS Date), NULL, N'Nam', N'90/19', NULL)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoNhanVien], [TenNhanVien], [ChucDanh], [NgaySinh], [NgayBatDauLamViec], [GioiTinh], [DiaChi], [SoDienThoai]) VALUES (1651010091, N'Nguyễn', N'Phương Vy', N'Lao công', NULL, NULL, N'Nữ', N'Tây Ninh', NULL)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoNhanVien], [TenNhanVien], [ChucDanh], [NgaySinh], [NgayBatDauLamViec], [GioiTinh], [DiaChi], [SoDienThoai]) VALUES (1651010144, N'Phùng', N'Minh Thư', N'Nhân viên bán hàng', NULL, NULL, N'Nữ', N'Cần thơ', NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'CSCM01', N'Miếng lót vệ sinh', N'CSCM', 3000, 1000, 5000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'CSCM02', N'Sữa tắm trị nấm', N'CSCM', 230, 1100, 10000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'CSCM03', N'Kẹp hốt phân ', N'CSCM', 30, 12000, 80000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'DDCM01', N'Tả bỉm', N'DDCM', 50, 3000, 30000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'DDCM02', N'Cát vệ sinh', N'DDCM', 20, 10000, 60000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'DPCM01', N'Thuốc tẩy giun', N'DPCM', 40, 700, 5000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'DPCM02', N'Thuốc trị ghẻ', N'DPCM', 5, 40000, 155000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'DPCM03', N'Thuốc trị rận', N'DPCM', 12, 35000, 150000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'PKCM01', N'Rọ mõm hình mỏ vịt', N'PKCM', 30, 12500, 150000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'PKCM02', N'Lục lạc thần bí', N'PKCM', 40, 2000, 25000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'PKCM03', N'Balo yên ngựa cho chó', N'PKCM', 7, 110000, 350000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'PKCM04', N'Dây cương xích vàng 24k', N'PKCM', 1, 7000000, 40000000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'TACM01', N'Whey protein cho chó', N'TACM', 600, 200000, 1750000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [SoLuongTonKho], [DonGiaNhap], [DonGiaBan]) VALUES (N'TACM02', N'Xương dinh dưỡng', N'TACM', 120, 4000, 25000)
INSERT [dbo].[TaiKhoanNhanVien] ([TaiKhoan], [MatKhau]) VALUES (N'1651010034duong', N'duong123')
INSERT [dbo].[TaiKhoanNhanVien] ([TaiKhoan], [MatKhau]) VALUES (N'1651010090man', N'man12345')
INSERT [dbo].[TaiKhoanNhanVien] ([TaiKhoan], [MatKhau]) VALUES (N'1651010144thu', N'thu12345')
INSERT [dbo].[TaiKhoanNhanVien] ([TaiKhoan], [MatKhau]) VALUES (N'1651010172vy', N'vy123456')
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_HoaDon] FOREIGN KEY([MaHDBan])
REFERENCES [dbo].[HoaDon] ([MaHDBan])
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_HoaDon]
GO
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_SanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSanPham])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
USE [master]
GO
ALTER DATABASE [QLPetMarket] SET  READ_WRITE 
GO
