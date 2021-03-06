USE [QLBanDoDa]
GO
/****** Object:  Table [dbo].[tChatLieu]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChatLieu](
	[MaCL] [nvarchar](30) NOT NULL,
	[TenCL] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tChatLieu] PRIMARY KEY CLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tChiTietHDB]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHDB](
	[MaHDB] [nvarchar](30) NOT NULL,
	[MaSP] [nvarchar](30) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [int] NOT NULL,
	[KhuyenMai] [float] NULL,
	[DonGia] [int] NOT NULL,
 CONSTRAINT [PK_tChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tChiTietHDN]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHDN](
	[MaHDN] [nvarchar](30) NOT NULL,
	[MaSP] [nvarchar](30) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [int] NOT NULL,
	[ThanhTien] [int] NOT NULL,
	[KhuyenMai] [float] NOT NULL,
 CONSTRAINT [PK_tChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tHoaDonBan]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDonBan](
	[MaHDB] [nvarchar](30) NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[MaNVV] [nvarchar](30) NOT NULL,
	[MaKH] [nvarchar](30) NOT NULL,
	[Tongtien] [int] NOT NULL,
 CONSTRAINT [PK_tHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tHoaDonNhap]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDonNhap](
	[MaHDN] [nvarchar](30) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[MaNVV] [nvarchar](30) NOT NULL,
	[MaNCC] [nvarchar](30) NOT NULL,
	[Tongtien] [int] NOT NULL,
 CONSTRAINT [PK_tHoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tKhachHang]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tKhachHang](
	[MaKH] [nvarchar](30) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_tKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tLoai]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLoai](
	[MaLoai] [nvarchar](30) NOT NULL,
	[TenLoai] [nvarchar](30) NULL,
 CONSTRAINT [PK_tLoai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tLogin]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLogin](
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_tLogin] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tMauSac]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMauSac](
	[MaMau] [nvarchar](30) NOT NULL,
	[TenMau] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tMauSac] PRIMARY KEY CLUSTERED 
(
	[MaMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tNhaCungCap]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhaCungCap](
	[MaNCC] [nvarchar](30) NOT NULL,
	[TenNCC] [nvarchar](30) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SĐT] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tNhanVien]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhanVien](
	[MaNVV] [nvarchar](30) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[MaQue] [nvarchar](50) NOT NULL,
	[SDT] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNVV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tNuocSX]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNuocSX](
	[MaNuoc] [nvarchar](30) NOT NULL,
	[TenNuoc] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tNuocSX] PRIMARY KEY CLUSTERED 
(
	[MaNuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tQue]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tQue](
	[MaQue] [nvarchar](50) NOT NULL,
	[TenQue] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tQue] PRIMARY KEY CLUSTERED 
(
	[MaQue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tSanPham]    Script Date: 4/10/2022 9:52:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSanPham](
	[MaSP] [nvarchar](30) NOT NULL,
	[TenSP] [nvarchar](30) NOT NULL,
	[MaLoai] [nvarchar](30) NOT NULL,
	[MaNuoc] [nvarchar](30) NOT NULL,
	[MaCL] [nvarchar](30) NOT NULL,
	[GiaNhap] [int] NOT NULL,
	[GiaBan] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[MaMau] [nvarchar](30) NOT NULL,
	[HinhAnh] [nvarchar](30) NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tSanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tChatLieu] ([MaCL], [TenCL]) VALUES (N'CL01', N'Da bò')
INSERT [dbo].[tChatLieu] ([MaCL], [TenCL]) VALUES (N'CL02', N'Da cá sấu')
INSERT [dbo].[tChatLieu] ([MaCL], [TenCL]) VALUES (N'CL03', N'Da tổng hợp')
INSERT [dbo].[tChatLieu] ([MaCL], [TenCL]) VALUES (N'CL04', N'Da cừu')
INSERT [dbo].[tChatLieu] ([MaCL], [TenCL]) VALUES (N'CL06', N'Da sư tử')
INSERT [dbo].[tChatLieu] ([MaCL], [TenCL]) VALUES (N'CL07', N'Da ngựa')
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaSP], [SoLuong], [ThanhTien], [KhuyenMai], [DonGia]) VALUES (N'HDB11252021_223547', N'SP02', 4, 6000000, 0, 1500000)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaSP], [SoLuong], [ThanhTien], [KhuyenMai], [DonGia]) VALUES (N'HDB11282021_105923', N'SP01', 2, 5000000, 0, 2500000)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaSP], [SoLuong], [ThanhTien], [KhuyenMai], [DonGia]) VALUES (N'HDB11282021_105943', N'SP03', 1, 900000, 10, 1000000)
INSERT [dbo].[tChiTietHDN] ([MaHDN], [MaSP], [SoLuong], [DonGia], [ThanhTien], [KhuyenMai]) VALUES (N'HDN01', N'SP01', 7, 1000000, 7000000, 0)
INSERT [dbo].[tChiTietHDN] ([MaHDN], [MaSP], [SoLuong], [DonGia], [ThanhTien], [KhuyenMai]) VALUES (N'HDN11252021_143833', N'SP02', 6, 1000000, 6000000, 0)
INSERT [dbo].[tHoaDonBan] ([MaHDB], [NgayBan], [MaNVV], [MaKH], [Tongtien]) VALUES (N'HDB11252021_223547', CAST(N'2021-11-26 00:00:00.000' AS DateTime), N'NV01', N'KH06', 6000000)
INSERT [dbo].[tHoaDonBan] ([MaHDB], [NgayBan], [MaNVV], [MaKH], [Tongtien]) VALUES (N'HDB11282021_105923', CAST(N'2021-01-01 00:00:00.000' AS DateTime), N'NV03', N'KH07', 5000000)
INSERT [dbo].[tHoaDonBan] ([MaHDB], [NgayBan], [MaNVV], [MaKH], [Tongtien]) VALUES (N'HDB11282021_105943', CAST(N'2021-11-20 00:00:00.000' AS DateTime), N'NV06', N'KH02', 900000)
INSERT [dbo].[tHoaDonNhap] ([MaHDN], [NgayNhap], [MaNVV], [MaNCC], [Tongtien]) VALUES (N'HDN01', CAST(N'2021-10-25 00:00:00.000' AS DateTime), N'NV01', N'N01', 10000000)
INSERT [dbo].[tHoaDonNhap] ([MaHDN], [NgayNhap], [MaNVV], [MaNCC], [Tongtien]) VALUES (N'HDN11252021_143833', CAST(N'2021-11-25 00:00:00.000' AS DateTime), N'NV01', N'N04', 6000000)
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH01', N'Nguyễn Tuấn Minh', N'Hà Nội', N'01234567')
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH02', N'Nguyễn Kim Đạt', N'Thanh Hóa', N'01236789')
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH03', N'Trương Minh Hiếu', N'Thái Bình', N'0392417241')
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH04', N'Nguyễn Đức Bảo Sai', N'Bắc Ninh', N'09284342788')
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH05', N'Nguyễn Văn Thủy', N'Bắc Giang', N'036473828')
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH06', N'Lê Kiến Trúc', N'Thái Bình', N'09238437437')
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH07', N'Nguyễn Đại Nhân', N'Hà Nội', N'039823372')
INSERT [dbo].[tLoai] ([MaLoai], [TenLoai]) VALUES (N'L01', N'Ví')
INSERT [dbo].[tLoai] ([MaLoai], [TenLoai]) VALUES (N'L02', N'Thắt lưng')
INSERT [dbo].[tLoai] ([MaLoai], [TenLoai]) VALUES (N'L03', N'Mũ')
INSERT [dbo].[tLoai] ([MaLoai], [TenLoai]) VALUES (N'L04', N'Túi')
INSERT [dbo].[tLoai] ([MaLoai], [TenLoai]) VALUES (N'L05', N'Giày')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'ABC', N'123')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'dat', N'dat123')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'DoVanLuong', N'Luong123')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'HaVanTuan', N'Tuan123')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'hieu', N'e36a688e4838c0f47f7eca369706d43b')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'NguyenDat', N'dat123')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'NguyenKimDat', N'f9be2354b8980fa8952979a5d93a7762')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'NguyenTuanMinh', N'TuanMinh123')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'NTM', N'9cb1d2fee961ffa9f6c4426fa7aa4118')
INSERT [dbo].[tLogin] ([TenDangNhap], [MatKhau]) VALUES (N'TruongMinhHieu', N'Truonghieu123')
INSERT [dbo].[tMauSac] ([MaMau], [TenMau]) VALUES (N'C01', N'Đỏ')
INSERT [dbo].[tMauSac] ([MaMau], [TenMau]) VALUES (N'C02', N'Nâu')
INSERT [dbo].[tMauSac] ([MaMau], [TenMau]) VALUES (N'C03', N'Xanh dương')
INSERT [dbo].[tMauSac] ([MaMau], [TenMau]) VALUES (N'C04', N'Hồng')
INSERT [dbo].[tMauSac] ([MaMau], [TenMau]) VALUES (N'C05', N'Đen')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SĐT]) VALUES (N'N01', N'Thăng Long', N'Hà Nội', N'0322123456')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SĐT]) VALUES (N'N02', N'Manufacturer ', N'London', N'004412344')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SĐT]) VALUES (N'N03', N'Little Girl', N'Washington DC', N'0162351156')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SĐT]) VALUES (N'N04', N'Big Boys', N'Berlin', N'03984744637')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SĐT]) VALUES (N'N05', N'Hải Hà', N'Hồ Chí Minh', N'0123456789')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SĐT]) VALUES (N'N06', N'Minh', N'Hà Nội', N'030223424')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV01', N'Thiều Trần Cường', N'Hà Nội', N'Nam', CAST(N'2001-03-12 00:00:00.000' AS DateTime), N'Q01', N'53123153151')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV02', N'Nguyễn Quang Tùng', N'Hà Nội', N'Nam', CAST(N'2002-05-21 00:00:00.000' AS DateTime), N'Q01', N'5415213212')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV03', N'Thiều Khánh Ly', N'Thanh Hóa', N'Nữ', CAST(N'2001-07-06 00:00:00.000' AS DateTime), N'Q03', N'331121141')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV04', N'Phạm Văn Huy', N'Thái Bình', N'Nam', CAST(N'1999-09-08 00:00:00.000' AS DateTime), N'Q02', N'1234541215')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV05', N'Hà Văn Đại', N'Thái Bình', N'Nam', CAST(N'2000-07-05 00:00:00.000' AS DateTime), N'Q02', N'838283738')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV06', N'Nguyễn Thị Tâm', N'Thanh Hóa', N'Nữ', CAST(N'2000-09-07 00:00:00.000' AS DateTime), N'Q03', N'09338828')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV07', N'Nguyễn Khánh Toán', N'Thanh Hóa', N'Nam', CAST(N'1991-07-09 00:00:00.000' AS DateTime), N'Q03', N'09393439')
INSERT [dbo].[tNhanVien] ([MaNVV], [TenNV], [DiaChi], [GioiTinh], [NgaySinh], [MaQue], [SDT]) VALUES (N'NV08', N'Nguyễn Việt Hàng', N'Hà Nội', N'Nữ', CAST(N'2001-01-01 00:00:00.000' AS DateTime), N'Q02', N'0361241349')
INSERT [dbo].[tNuocSX] ([MaNuoc], [TenNuoc]) VALUES (N'NSX01', N'Anh')
INSERT [dbo].[tNuocSX] ([MaNuoc], [TenNuoc]) VALUES (N'NSX02', N'Mĩ')
INSERT [dbo].[tNuocSX] ([MaNuoc], [TenNuoc]) VALUES (N'NSX03', N'Việt Nam')
INSERT [dbo].[tNuocSX] ([MaNuoc], [TenNuoc]) VALUES (N'NSX04', N'Đức')
INSERT [dbo].[tNuocSX] ([MaNuoc], [TenNuoc]) VALUES (N'NSX05', N'Pháp')
INSERT [dbo].[tQue] ([MaQue], [TenQue]) VALUES (N'Q01', N'Hà Nội')
INSERT [dbo].[tQue] ([MaQue], [TenQue]) VALUES (N'Q02', N'Thái Bình')
INSERT [dbo].[tQue] ([MaQue], [TenQue]) VALUES (N'Q03', N'Thanh Hóa')
INSERT [dbo].[tQue] ([MaQue], [TenQue]) VALUES (N'Q04', N'Hà Nam')
INSERT [dbo].[tQue] ([MaQue], [TenQue]) VALUES (N'Q05', N'Bắc Giang')
INSERT [dbo].[tSanPham] ([MaSP], [TenSP], [MaLoai], [MaNuoc], [MaCL], [GiaNhap], [GiaBan], [SoLuong], [MaMau], [HinhAnh], [GhiChu]) VALUES (N'SP01', N'Ví da cá sấu', N'L01', N'NSX01', N'CL02', 2000000, 2500000, 11, N'C02', N'vi.jpg', N'chất lượng')
INSERT [dbo].[tSanPham] ([MaSP], [TenSP], [MaLoai], [MaNuoc], [MaCL], [GiaNhap], [GiaBan], [SoLuong], [MaMau], [HinhAnh], [GhiChu]) VALUES (N'SP02', N'Thắt lung da trơn', N'L02', N'NSX02', N'CL01', 1000000, 1500000, 6, N'C01', N'That.jpg', N'đẳng cấp')
INSERT [dbo].[tSanPham] ([MaSP], [TenSP], [MaLoai], [MaNuoc], [MaCL], [GiaNhap], [GiaBan], [SoLuong], [MaMau], [HinhAnh], [GhiChu]) VALUES (N'SP03', N'Mũ cao bồi', N'L03', N'NSX03', N'CL04', 500000, 1000000, 9, N'C04', N'mu.jpg', N'sang')
INSERT [dbo].[tSanPham] ([MaSP], [TenSP], [MaLoai], [MaNuoc], [MaCL], [GiaNhap], [GiaBan], [SoLuong], [MaMau], [HinhAnh], [GhiChu]) VALUES (N'SP04', N'Túi Gucci', N'L02', N'NSX03', N'CL02', 10000, 20000, 4, N'C02', N'tui.jpg', N'chất quá')
INSERT [dbo].[tSanPham] ([MaSP], [TenSP], [MaLoai], [MaNuoc], [MaCL], [GiaNhap], [GiaBan], [SoLuong], [MaMau], [HinhAnh], [GhiChu]) VALUES (N'SP05', N'Minh', N'L05', N'NSX01', N'CL02', 1, 2, 0, N'C03', N'', N'2')
