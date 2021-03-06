CREATE DATABASE QLBanDoDa4
USE [QLBanDoDa4]
GO
/****** Object:  Table [dbo].[tChatLieu]    Script Date: 10/26/2021 4:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChatLieu](
	[MaCL] [nvarchar](30) NOT NULL,
	[Tên CL] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tChatLieu] PRIMARY KEY CLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tChiTietHDB]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHDB](
	[MaHDB] [nvarchar](30) NOT NULL,
	[MaSP] [nvarchar](30) NOT NULL,
	[Số lượng] [int] NOT NULL,
	[Thành tiền] [int] NOT NULL,
	[Khuyến mãi] [float] NULL,
	[Đơn giá] [int] NOT NULL,
 CONSTRAINT [PK_tChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tChiTietHDN]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHDN](
	[MaHDN] [nvarchar](30) NOT NULL,
	[MaSP] [nvarchar](30) NOT NULL,
	[Số lượng] [int] NOT NULL,
	[Đơn giá] [int] NOT NULL,
	[Thành tiền] [int] NOT NULL,
	[Khuyến mãi] [float] NOT NULL,
 CONSTRAINT [PK_tChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tHoaDonBan]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDonBan](
	[MaHDB] [nvarchar](30) NOT NULL,
	[Ngày bán] [datetime] NOT NULL,
	[Mã NV] [nvarchar](30) NOT NULL,
	[Mã KH] [nvarchar](30) NOT NULL,
	[Tổng tiền] [int] NOT NULL,
 CONSTRAINT [PK_tHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tHoaDonNhap]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDonNhap](
	[MaHDN] [nvarchar](30) NOT NULL,
	[Ngày nhập] [datetime] NOT NULL,
	[MaNV] [nvarchar](30) NOT NULL,
	[MaNCC] [nvarchar](30) NOT NULL,
	[Tổng tiền] [int] NOT NULL,
 CONSTRAINT [PK_tHoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tKhachHang]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tKhachHang](
	[MaKH] [nvarchar](30) NOT NULL,
	[Tên KH] [nvarchar](50) NOT NULL,
	[Địa chỉ] [nvarchar](50) NOT NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_tKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tLoai]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLoai](
	[MaLoai] [nvarchar](30) NOT NULL,
	[Tên Loại] [nvarchar](30) NULL,
 CONSTRAINT [PK_tLoai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tMauSac]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMauSac](
	[MaMau] [nvarchar](30) NOT NULL,
	[Tên màu] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tMauSac] PRIMARY KEY CLUSTERED 
(
	[MaMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tNhaCungCap]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhaCungCap](
	[MaNCC] [nvarchar](30) NOT NULL,
	[TenNCC] [nvarchar](30) NOT NULL,
	[Địa chỉ] [nvarchar](50) NOT NULL,
	[SĐT] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tNhanVien]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhanVien](
	[MaNV] [nvarchar](30) NOT NULL,
	[Tên NV] [nvarchar](50) NOT NULL,
	[Địa chỉ] [nvarchar](50) NOT NULL,
	[Giới tính] [nvarchar](50) NOT NULL,
	[Ngày Sinh] [datetime] NOT NULL,
	[MaQue] [nvarchar](50) NOT NULL,
	[SĐT] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tNuocSX]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNuocSX](
	[MaNuoc] [nvarchar](30) NOT NULL,
	[Tên nước] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tNuocSX] PRIMARY KEY CLUSTERED 
(
	[MaNuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tQue]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tQue](
	[MaQue] [nvarchar](50) NOT NULL,
	[Tên Quê] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tQue] PRIMARY KEY CLUSTERED 
(
	[MaQue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tSanPham]    Script Date: 10/26/2021 4:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSanPham](
	[MaSP] [nvarchar](30) NOT NULL,
	[Tên SP] [nvarchar](30) NOT NULL,
	[MaLoai] [nvarchar](30) NOT NULL,
	[MaNuoc] [nvarchar](30) NOT NULL,
	[MaCL] [nvarchar](30) NOT NULL,
	[Giá nhập] [int] NOT NULL,
	[Giá bán] [int] NOT NULL,
	[Số lượng] [int] NOT NULL,
	[MaMau] [nvarchar](30) NOT NULL,
	[Hình ảnh] [nvarchar](30) NULL,
 CONSTRAINT [PK_tSanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tChatLieu] ([MaCL], [Tên CL]) VALUES (N'CL01', N'Da bò')
INSERT [dbo].[tChatLieu] ([MaCL], [Tên CL]) VALUES (N'CL02', N'Da cá sấu')
INSERT [dbo].[tChatLieu] ([MaCL], [Tên CL]) VALUES (N'CL03', N'Da tổng hợp')
INSERT [dbo].[tChatLieu] ([MaCL], [Tên CL]) VALUES (N'CL04', N'Da cừu')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [Ngày bán], [Mã NV], [Mã KH], [Tổng tiền]) VALUES (N'HDB01', CAST(N'2021-03-12 00:00:00.000' AS DateTime), N'1', N'1', 1)
INSERT [dbo].[tHoaDonNhap] ([MaHDN], [Ngày nhập], [MaNV], [MaNCC], [Tổng tiền]) VALUES (N'HDN01', CAST(N'2021-10-25 00:00:00.000' AS DateTime), N'NV01', N'N01', 1000000)
INSERT [dbo].[tHoaDonNhap] ([MaHDN], [Ngày nhập], [MaNV], [MaNCC], [Tổng tiền]) VALUES (N'HDN02', CAST(N'2021-02-23 00:00:00.000' AS DateTime), N'NV02', N'N03', 5000000)
INSERT [dbo].[tHoaDonNhap] ([MaHDN], [Ngày nhập], [MaNV], [MaNCC], [Tổng tiền]) VALUES (N'HDN03', CAST(N'2020-01-05 00:00:00.000' AS DateTime), N'NV04', N'N02', 2000000)
INSERT [dbo].[tKhachHang] ([MaKH], [Tên KH], [Địa chỉ], [SDT]) VALUES (N'KH01', N'Nguyễn Tuấn Minh', N'Hà Nội', NULL)
INSERT [dbo].[tKhachHang] ([MaKH], [Tên KH], [Địa chỉ], [SDT]) VALUES (N'KH02', N'Nguyễn Kim Đạt', N'Thanh Hóa', NULL)
INSERT [dbo].[tKhachHang] ([MaKH], [Tên KH], [Địa chỉ], [SDT]) VALUES (N'KH03', N'Trương Minh Hiếu', N'Thái Bình', NULL)
INSERT [dbo].[tKhachHang] ([MaKH], [Tên KH], [Địa chỉ], [SDT]) VALUES (N'KH04', N'Nguyễn Đức Bảo Sơn', N'Bắc Ninh', NULL)
INSERT [dbo].[tKhachHang] ([MaKH], [Tên KH], [Địa chỉ], [SDT]) VALUES (N'KH05', N'Nguyễn Văn Thủy', N'Bắc Giang', NULL)
INSERT [dbo].[tKhachHang] ([MaKH], [Tên KH], [Địa chỉ], [SDT]) VALUES (N'KH06', N'Lê Kiến Trúc', N'Thái Binh', NULL)
INSERT [dbo].[tLoai] ([MaLoai], [Tên Loại]) VALUES (N'L01', N'Ví')
INSERT [dbo].[tLoai] ([MaLoai], [Tên Loại]) VALUES (N'L02', N'Thắt lưng')
INSERT [dbo].[tLoai] ([MaLoai], [Tên Loại]) VALUES (N'L03', N'Mũ')
INSERT [dbo].[tLoai] ([MaLoai], [Tên Loại]) VALUES (N'L04', N'Túi')
INSERT [dbo].[tLoai] ([MaLoai], [Tên Loại]) VALUES (N'L05', N'Giày')
INSERT [dbo].[tMauSac] ([MaMau], [Tên màu]) VALUES (N'C01', N'Đỏ')
INSERT [dbo].[tMauSac] ([MaMau], [Tên màu]) VALUES (N'C02', N'Nâu')
INSERT [dbo].[tMauSac] ([MaMau], [Tên màu]) VALUES (N'C03', N'Xanh dương')
INSERT [dbo].[tMauSac] ([MaMau], [Tên màu]) VALUES (N'C04', N'Hồng')
INSERT [dbo].[tMauSac] ([MaMau], [Tên màu]) VALUES (N'C05', N'Đen')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [Địa chỉ], [SĐT]) VALUES (N'N01', N'Thăng Long', N'Hà Nội', N'0322123456')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [Địa chỉ], [SĐT]) VALUES (N'N02', N'Manufacturer ', N'London', N'0044123')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [Địa chỉ], [SĐT]) VALUES (N'N03', N'Little Girl', N'Washington DC', N'0162351')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [Địa chỉ], [SĐT]) VALUES (N'N04', N'Big Boy', N'Berlin', N'1561151')
INSERT [dbo].[tNhanVien] ([MaNV], [Tên NV], [Địa chỉ], [Giới tính], [Ngày Sinh], [MaQue], [SĐT]) VALUES (N'NV01', N'Thiều Trần Cường', N'Hà Nội', N'Nam', CAST(N'2001-03-12 00:00:00.000' AS DateTime), N'Q01', N'53123153151')
INSERT [dbo].[tNhanVien] ([MaNV], [Tên NV], [Địa chỉ], [Giới tính], [Ngày Sinh], [MaQue], [SĐT]) VALUES (N'NV02', N'Nguyễn Quang Trung', N'Hà Nội', N'Nam', CAST(N'2002-05-21 00:00:00.000' AS DateTime), N'Q01', N'5415213212')
INSERT [dbo].[tNhanVien] ([MaNV], [Tên NV], [Địa chỉ], [Giới tính], [Ngày Sinh], [MaQue], [SĐT]) VALUES (N'NV03', N'Thiều Khánh Ly', N'Thanh Hóa', N'Nữ', CAST(N'2001-11-22 00:00:00.000' AS DateTime), N'Q03', N'3311211412')
INSERT [dbo].[tNhanVien] ([MaNV], [Tên NV], [Địa chỉ], [Giới tính], [Ngày Sinh], [MaQue], [SĐT]) VALUES (N'NV04', N'Phạm Văn Huy', N'Thái Bình', N'Nam', CAST(N'2000-01-01 00:00:00.000' AS DateTime), N'Q02', N'1234541215')
INSERT [dbo].[tNuocSX] ([MaNuoc], [Tên nước]) VALUES (N'NSX01', N'Anh')
INSERT [dbo].[tNuocSX] ([MaNuoc], [Tên nước]) VALUES (N'NSX02', N'Mĩ')
INSERT [dbo].[tNuocSX] ([MaNuoc], [Tên nước]) VALUES (N'NSX03', N'Việt Nam')
INSERT [dbo].[tNuocSX] ([MaNuoc], [Tên nước]) VALUES (N'NSX04', N'Đức')
INSERT [dbo].[tQue] ([MaQue], [Tên Quê]) VALUES (N'Q01', N'Hà Nội')
INSERT [dbo].[tQue] ([MaQue], [Tên Quê]) VALUES (N'Q02', N'Thái Bình')
INSERT [dbo].[tQue] ([MaQue], [Tên Quê]) VALUES (N'Q03', N'Thanh Hóa')
INSERT [dbo].[tQue] ([MaQue], [Tên Quê]) VALUES (N'Q04', N'Hà Nam')
INSERT [dbo].[tQue] ([MaQue], [Tên Quê]) VALUES (N'Q05', N'Bắc Giang')
INSERT [dbo].[tSanPham] ([MaSP], [Tên SP], [MaLoai], [MaNuoc], [MaCL], [Giá nhập], [Giá bán], [Số lượng], [MaMau], [Hình ảnh]) VALUES (N'SP01', N'Ví da cá sấu', N'L01', N'NSX01', N'CL02', 2000000, 2500000, 12, N'C02', NULL)
INSERT [dbo].[tSanPham] ([MaSP], [Tên SP], [MaLoai], [MaNuoc], [MaCL], [Giá nhập], [Giá bán], [Số lượng], [MaMau], [Hình ảnh]) VALUES (N'SP02', N'Thắt lung da trơn', N'L02', N'NSX02', N'CL01', 1000000, 1500000, 10, N'C01', NULL)
INSERT [dbo].[tSanPham] ([MaSP], [Tên SP], [MaLoai], [MaNuoc], [MaCL], [Giá nhập], [Giá bán], [Số lượng], [MaMau], [Hình ảnh]) VALUES (N'SP03', N'Mũ cao bồi', N'L03', N'NSX03', N'CL03', 500000, 1000000, 6, N'C04', NULL)
INSERT [dbo].[tSanPham] ([MaSP], [Tên SP], [MaLoai], [MaNuoc], [MaCL], [Giá nhập], [Giá bán], [Số lượng], [MaMau], [Hình ảnh]) VALUES (N'SP04', N'Túi Gucci', N'L04', N'NSX05', N'CL03', 1000000, 2000000, 16, N'C03', NULL)
