USE [QL_BANHANG]
GO
/****** Object:  Table [dbo].[BINHLUAN]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BINHLUAN](
	[MABL] [int] IDENTITY(1,1) NOT NULL,
	[NOIDUNGBL] [nvarchar](255) NULL,
	[MAKH] [int] NULL,
	[MASP] [int] NULL,
 CONSTRAINT [PK_BINHLUAN] PRIMARY KEY CLUSTERED 
(
	[MABL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHITIETDONDATHANG]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDONDATHANG](
	[MACHITIETDDH] [int] IDENTITY(1,1) NOT NULL,
	[MADDH] [int] NULL,
	[MASP] [int] NULL,
	[TENSP] [nvarchar](150) NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [int] NULL,
 CONSTRAINT [PK_CHITIETDONDATHANG] PRIMARY KEY CLUSTERED 
(
	[MACHITIETDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHITIETPHIEUNHAP]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUNHAP](
	[MACHITIETPN] [int] IDENTITY(1,1) NOT NULL,
	[MAPN] [int] NULL,
	[MASP] [int] NULL,
	[DONGIANHAP] [int] NULL,
	[SOLUONGNHAP] [int] NULL,
 CONSTRAINT [PK_CHITIETPHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MACHITIETPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[dangnhap]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dangnhap](
	[taikhoan] [char](50) NOT NULL,
	[matkhau] [char](50) NULL,
	[tenadmin] [nvarchar](100) NULL,
 CONSTRAINT [PK_dangnhap] PRIMARY KEY CLUSTERED 
(
	[taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DONDATHANG]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONDATHANG](
	[MADDH] [int] IDENTITY(1,1) NOT NULL,
	[NGAYDAT] [datetime] NULL,
	[TINHTRANGGIAOHANG] [bit] NULL,
	[NGAYGIAO] [datetime] NULL,
	[DATHANHTOAN] [bit] NULL,
	[MAKH] [int] NULL,
	[UUDAI] [int] NULL,
 CONSTRAINT [PK_DONDATHANG] PRIMARY KEY CLUSTERED 
(
	[MADDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[editorabout]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[editorabout](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[textabout] [nvarchar](max) NULL,
 CONSTRAINT [pk_editorabout] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [int] IDENTITY(1,1) NOT NULL,
	[TAIKHOAN] [varchar](50) NULL,
	[MATKHAU] [varchar](50) NULL,
	[HOTEN] [nvarchar](100) NULL,
	[DIACHI] [nvarchar](255) NULL,
	[EMAIL] [varchar](40) NULL,
	[SODIENTHOAI] [varchar](12) NULL,
	[PHANQUYEN] [int] NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAISANPHAM]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISANPHAM](
	[MALOAISP] [int] IDENTITY(1,1) NOT NULL,
	[TENLOAI] [nvarchar](100) NULL,
	[ICON] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOAISANPHAM] PRIMARY KEY CLUSTERED 
(
	[MALOAISP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHASANXUAT]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHASANXUAT](
	[MANSX] [int] IDENTITY(1,1) NOT NULL,
	[TENNSX] [nvarchar](255) NULL,
	[THONGTIN] [nvarchar](255) NULL,
	[LOGO] [nvarchar](max) NULL,
 CONSTRAINT [PK_NHASANXUAT] PRIMARY KEY CLUSTERED 
(
	[MANSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MAPN] [int] IDENTITY(1,1) NOT NULL,
	[NGAYNHAP] [datetime] NULL,
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MAPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 11/27/2019 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MASP] [int] IDENTITY(1,1) NOT NULL,
	[TENSP] [nvarchar](150) NULL,
	[DONGIA] [int] NULL,
	[NGAYCAPNHAT] [datetime] NULL,
	[MOTA] [nvarchar](max) NULL,
	[HINHANH] [nvarchar](max) NULL,
	[SOLUONGTON] [int] NULL,
	[LUOTXEM] [int] NULL,
	[LUOTBINHCHON] [int] NULL,
	[LUOTBINHLUAN] [int] NULL,
	[NGUYENLIEUBANH] [nvarchar](max) NULL,
	[MALOAISP] [int] NULL,
	[MANSX] [int] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[dangnhap] ([taikhoan], [matkhau], [tenadmin]) VALUES (N'bao                                               ', N'123456                                            ', N'Phạm Văn Lê Bảo')
SET IDENTITY_INSERT [dbo].[DONDATHANG] ON 

INSERT [dbo].[DONDATHANG] ([MADDH], [NGAYDAT], [TINHTRANGGIAOHANG], [NGAYGIAO], [DATHANHTOAN], [MAKH], [UUDAI]) VALUES (2, CAST(0x0000A9E700000000 AS DateTime), 0, CAST(0x0000A9E700000000 AS DateTime), 0, 2, 12312)
SET IDENTITY_INSERT [dbo].[DONDATHANG] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MAKH], [TAIKHOAN], [MATKHAU], [HOTEN], [DIACHI], [EMAIL], [SODIENTHOAI], [PHANQUYEN]) VALUES (2, N'dfádfs', N'sd', N'ádf', N'ádfsdfad', N'fdfhghkhjk@gmail.com', N'1313212314', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [TAIKHOAN], [MATKHAU], [HOTEN], [DIACHI], [EMAIL], [SODIENTHOAI], [PHANQUYEN]) VALUES (3, N'dfádfs', N'sd', N'dsafd', N'ádfsdfa', N'fdfhghkhjk@gmail.com', N'2312312', NULL)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[LOAISANPHAM] ON 

INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAI], [ICON]) VALUES (1, N'Bánh Kem', N'cxvxcsdfgf')
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAI], [ICON]) VALUES (2, N'Bánh Quy', N'kjn,m')
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAI], [ICON]) VALUES (3, N'Bánh Mỳ', N'sfdvf')
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAI], [ICON]) VALUES (7, N'Bánh Ke', N'sdfa')
SET IDENTITY_INSERT [dbo].[LOAISANPHAM] OFF
SET IDENTITY_INSERT [dbo].[NHASANXUAT] ON 

INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [THONGTIN], [LOGO]) VALUES (5, N'Bud’s Ice Cream', NULL, NULL)
SET IDENTITY_INSERT [dbo].[NHASANXUAT] OFF
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] ON 

INSERT [dbo].[PHIEUNHAP] ([MAPN], [NGAYNHAP]) VALUES (26, CAST(0x0000A9E70000EB8C AS DateTime))
INSERT [dbo].[PHIEUNHAP] ([MAPN], [NGAYNHAP]) VALUES (27, CAST(0x0000A9E7000152AC AS DateTime))
INSERT [dbo].[PHIEUNHAP] ([MAPN], [NGAYNHAP]) VALUES (28, CAST(0x0000A9E700015504 AS DateTime))
INSERT [dbo].[PHIEUNHAP] ([MAPN], [NGAYNHAP]) VALUES (29, CAST(0x0000AA0200015888 AS DateTime))
INSERT [dbo].[PHIEUNHAP] ([MAPN], [NGAYNHAP]) VALUES (30, CAST(0x0000A9E70168AE60 AS DateTime))
INSERT [dbo].[PHIEUNHAP] ([MAPN], [NGAYNHAP]) VALUES (31, CAST(0x0000A9E7016C50D8 AS DateTime))
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] OFF
SET IDENTITY_INSERT [dbo].[SANPHAM] ON 

INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (46, N'Kolache Cookies', 78, CAST(0x0000AAB000000000 AS DateTime), N'Bánh ngọt son sò madelleines còn được mệnh danh là “nàng thơ trong tiệc trà Pháp”.', N'bq16.jpg', 22, NULL, 4, 4, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (47, N'Gulab Cookies', 60, CAST(0x0000A9E400000000 AS DateTime), N'Bánh opera cũng là một trong những loại bánh nổi tiếng của nước Pháp. Nó được làm từ nhiều lớp bánh xốp hạnh nhân ngâm trong si rô cà phê, kèm cả lớp ganache hoặc kem bơ cà phê.', N'bq17.jpg', 43, 3, 2, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (48, N'Buxndnernusstorte Cookies', 99, CAST(0x0000A9F100000000 AS DateTime), N'Được làm từ lòng trắng trứng, đường bột, đường cát, bột hạnh nhân và thêm màu thực phẩm. Nhân bánh thường được lấp đầy với mứt, ganache hoặc kem bơ kẹp giữa hai mặt bánh.', N'bq18.jpg', 42, NULL, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (49, N'Masala Cookies', 80, CAST(0x0000A9E500000000 AS DateTime), N'Khi thưởng thức macaron, người ta có thể tìm thấy từ những hương vị truyền thống như mâm xôi, sô cô la, cho đến những hương vị mới như nấm và trà xanh.', N'bq19.jpg', 41, 2, 12321, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (50, N'Dosa Cookies', 100, CAST(0x0000A9F500000000 AS DateTime), N'Macaron là loại bánh có lẽ chinh phục được nhiều những thực khách khó tính nhất, cách làm macaron không hề dễ, vì vậy để có được những chiếc bánh thành công đòi hỏi vô vàn yếu tố.', N'bq20.jpg', 12, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (51, N'Velvet Cookies', 59, CAST(0x0000AB0D00000000 AS DateTime), N'Công thức chế biến loại bánh này sau đó đã được người Pháp chỉnh sửa lại và tạo ra món bánh sừng bò xốp mềm, ngậy thơm mùi bơ. ', N'bq21.jpg', 40, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (52, N'Cupcake Cookies', 66, CAST(0x0000AB1800000000 AS DateTime), N'Các nghệ nhân cho một khối lượng bơ khá lớn vào bột và gấp nó lại thật nhiều lần, bởi vậy bánh sừng bò có kết cấu rất xốp, thơm ngon ngậy béo.', N'bq22.jpg', 58, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (53, N'Yokan Cookies', 39, CAST(0x0000AAFC00000000 AS DateTime), N'Nhắc đến nước Pháp hẳn ai cũng nghĩ đến món bánh sừng bò nổi tiếng, tuy nhiên Croissant lại được sinh ra tại Áo, dưới cái tên “kipferl”.', N'bq23.jpg', 90, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (54, N'Velet Cookies', 74, CAST(0x0000AA8B00000000 AS DateTime), N'Đúng như tên gọi của mình, những chiếc bánh Red Velvet mang một màu đỏ nhung thật nồng nàn, say đắm.', N'bq24.jpg', 50, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (55, N'Croissant Cookies', 55, CAST(0x0000AB110007D634 AS DateTime), N'Red Velvet là sự kết hợp hài hòa của từng lớp bánh đỏ thắm đan xen với những lớp kem trắng mịn, bồng bềnh trông thật thích mắt và ngon miệng.', N'bq25.jpg', 6, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (56, N'Macaron Cookies', 120, CAST(0x0000AAB000000000 AS DateTime), N'Hôm nay hãy cùng Massageishealthy dạo một vòng nước Pháp và tìm hiểu về các loại bánh ngọt Pháp nổi tiếng, ngon nhất nước Pháp làm động lòng người nhé!', N'bq26.jpg', 22, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (57, N'Opera Cookies', 111, CAST(0x0000A9E400000000 AS DateTime), N'Nền ẩm thực Pháp luôn có sự hấp dẫn tuyệt vời với bất cứ ai yêu thích và muốn trải nghiệm các văn hoá ẩm thực khác nhau. Vừa toát lên sự cổ điển, sang trọng vừa chứa đựng sự ngọt ngào,', N'bq27.jpg', 43, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (58, N'Madelleines Cookies', 88, CAST(0x0000A9F100000000 AS DateTime), N'ược xuất xứ từ nước Pháp, một nơi có nền ẩm thực vô cùng phong phú và đa dạng. Là một loại bánh rất mỏng, dẹt, thường được làm từ bột mỳ, trứng, sữa và bơ.', N'bq28.jpg', 39, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (59, N'Amann Cookies', 30, CAST(0x0000A9E500000000 AS DateTime), N'Nhắc đến nước Pháp hẳn ai cũng nghĩ đến món bánh sừng bò nổi tiếng, tuy nhiên Croissant lại được sinh ra tại Áo, dưới cái tên “kipferl”.', N'bq29.jpg', 41, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (60, N'Tarte Cookies', 111, CAST(0x0000A9F500000000 AS DateTime), N'Công thức chế biến loại bánh này sau đó đã được người Pháp chỉnh sửa lại và tạo ra món bánh sừng bò xốp mềm, ngậy thơm mùi bơ. ', N'bq30.jpg', 12, 2, 0, 0, N'Bánh Quy nguồn gốc từ nước Anh. Lúc đó bánh được sử dụng chủ yếu làm thức ăn cho các thủy thủ trong các chuyến đi biển dài ngày. Những chiếc bánh đầu tiên được làm ra chỉ từ một số ít nguyên liệu như: bột mì, muối và nước, và muốn ăn được chúng phải ngâm vào các loại nước uống như: trà, sữa,nước,…', 2, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (61, N'White Bread', 100, CAST(0x0000AA2E00000000 AS DateTime), N'Nhân bánh có thể được làm từ đậu đổ, đậu trắng hoặc dâu tây hay một số loại hoa quả khác kết hợp với đậu đỏ. Lớp vỏ bên ngoài mềm, dai là nét đặc trưng ', N'Bánh mỳ 2.jpg', 20, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (62, N'Wheat Bread', 120, CAST(0x0000AA7500000000 AS DateTime), N'Tiramisu là một loại bánh ngọt tráng miệng rất nổi tiếng của Italia. Sản phẩm là sự kết hợp hòa quyện giữa hương thơm của cà phê, rượu nhẹ và vị béo của trứng cùng kem phô mai.', N'Bánh mỳ.jpg', 12, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (63, N'Rye Bread', 20, CAST(0x0000AAA600000000 AS DateTime), N'Chỉ cần cắn một miếng, bạn sẽ cảm nhận được tất cả các hương vị đó hòa quyện cùng một, chính vì thế người ta còn ví món bánh này là “Thiên đường trong miệng của bạn” nên nhất định phải thử một lần nhé.', N'Bánh mỳ 3.jpg', 23, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (64, N'Breadsticks ', 40, CAST(0x0000AA3A00000000 AS DateTime), N'Đây là một loại bánh ngọt của Pháp, bánh được làm từ lòng trắng trứng, đường bột, đường cát, bột hạnh nhân và một ít phẩm màu tự nhiên. Nhân bánh thường là mứt, chocolate hoặc kem bơ kẹp ở giữa.', N'Bánh mỳ 4.jpg', 20, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (65, N'Donut', 34, CAST(0x0000AA9300000000 AS DateTime), N'Với vị giòn tan của vỏ bánh, béo ngậy của phần nhân, cùng vẻ ngoài đáng yêu và nhiều màu sắc bắt mắt, đây là một món bánh đặc trưng trong các cửa hàng bánh ngọt tại Pháp.', N'Bánh mỳ 5.jpg', 43, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (66, N'Bagels', 90, CAST(0x0000AAB300000000 AS DateTime), N'Đây là một loại bánh xốp được tạo ra bởi chocolate tuyệt hảo nhất nước Áo. Bánh có vị ngọt dịu nhẹ, gồm nhiều lớp bánh được làm từ bánh mì và bánh sữa chocolate, xen lẫn giữa các lớp bánh là mứt mơ. ', N'Bánh mỳ 6.jpg', 12, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (67, N'French Bread', 80, CAST(0x0000AA2D00000000 AS DateTime), N'Món bánh chocolate này nổi tiếng và thành phố Vienna đã ấn định tổ chức một ngày Sachertorte quốc gia, vào ngày 5/12 hàng năm.', N'Bánh mỳ 7.jpg', 53, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (68, N'Whole Grain Bread', 70, CAST(0x0000AAC700000000 AS DateTime), N'Bánh có vị ngọt nhẹ, giống như bánh trứng đường, nhưng nó sử dụng nguyên liệu là bột ngô nên rất xốp và mềm ở bên trong, giòn ở bên ngoài. ', N'Bánh mỳ 8.jpg', 33, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (69, N'Rolls', 65, CAST(0x0000AA0B00000000 AS DateTime), N'Bánh bao gồm nhiều lớp bánh bông lan chocolate xen kẽ giữa các lớp kem tươi trộn với anh đào, sau đó nó được phủ một lớp kem trên cùng, rồi được trang trí bằng quả anh đào đen và chocolate vụn.', N'Bánh mỳ 9.jpg', 8, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (70, N'Swiss roll', 92, CAST(0x0000A9CD00000000 AS DateTime), N'Vỏ của chiếc bánh tart nhỏ bé này được làm từ chocolate ganache đen, hạt hạnh nhân nghiền nhuyễn trong khi bề mặt của chiếc bánh được phủ một lớp đường đông lạnh màu xanh ngọc rất bắt mắt.', N'Bánh mỳ 10.jpg', 34, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (71, N'Tarte  Bread', 23, CAST(0x0000AA2E00000000 AS DateTime), N'Những chiếc bánh nhân trái cây đến từ miền Nam Hà Lan này có kết cấu mềm, đơn giản và thường làm từ hỗn hợp trứng, sữa và một ít bánh quy.“Vỏ bánh Limburg Pie không giòn. ', N'bm11.jpg', 20, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (72, N'Saint Bread', 60, CAST(0x0000AA7500000000 AS DateTime), N'Trong một ngày mưa lạnh, quả thật rất lý tưởng khi vừa nhâm nhi một miếng bánh Limburg Pie ngọt ngào vị mơ, táo hay anh đào cùng một ngụm cà phê nóng đăng đắng và thưởng thức cái lạnh se se đang thấm vào người.', N'bm12.jpg', 12, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (73, N'Flottante Bread', 78, CAST(0x0000AAA600000000 AS DateTime), N'Đây là loại bánh ngọt được làm chủ yếu từ phô mai, tạo vị béo ngậy. Phía trên người ta có thể phủ thêm mứt. Chiếc bánh pho mát kem được làm từ những năm 1800 và trở thành một trong những món bánh quen thuộc của người dân New York.', N'bm13.jpg', 23, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (74, N'Meringues', 89, CAST(0x0000AA3A00000000 AS DateTime), N'Ban đầu, bánh được làm để phục vụ hoàng gia, được làm từ mứt, trứng, sữa, kem và cốt bánh bông lan, bao phủ phía trên là lớp bánh hạnh nhân (thường có màu xanh). ', N'bm14.jpg', 20, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIA], [NGAYCAPNHAT], [MOTA], [HINHANH], [SOLUONGTON], [LUOTXEM], [LUOTBINHCHON], [LUOTBINHLUAN], [NGUYENLIEUBANH], [MALOAISP], [MANSX]) VALUES (75, N'Soufflé', 66, CAST(0x0000AA9300000000 AS DateTime), N'Được làm từ bột mì, đường và trứng đôi khi được phủ thêm bột nướng bánh hay nhúng vào rượu rum.', N'bm15.jpg', 43, 2, 0, 0, N'Bánh mì (bread): là các loại bánh được hình thành từ các loại nguyên liệu cơ bản như bột mì, men, muối, nước và các nguyên liệu bổ sung khác để tạo nên một dạng bánh xốp, dai, giòn và đặc trưng theo từng loại. Bánh mì có hai loại chính là bánh mì lạt và bánh mì ngọt.', 3, 5)
SET IDENTITY_INSERT [dbo].[SANPHAM] OFF
ALTER TABLE [dbo].[BINHLUAN]  WITH CHECK ADD  CONSTRAINT [FK_BINHLUAN_KHACHHANG] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[BINHLUAN] CHECK CONSTRAINT [FK_BINHLUAN_KHACHHANG]
GO
ALTER TABLE [dbo].[BINHLUAN]  WITH CHECK ADD  CONSTRAINT [FK_BINHLUAN_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[BINHLUAN] CHECK CONSTRAINT [FK_BINHLUAN_SANPHAM]
GO
ALTER TABLE [dbo].[CHITIETDONDATHANG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONDATHANG_DONDATHANG] FOREIGN KEY([MADDH])
REFERENCES [dbo].[DONDATHANG] ([MADDH])
GO
ALTER TABLE [dbo].[CHITIETDONDATHANG] CHECK CONSTRAINT [FK_CHITIETDONDATHANG_DONDATHANG]
GO
ALTER TABLE [dbo].[CHITIETDONDATHANG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONDATHANG_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CHITIETDONDATHANG] CHECK CONSTRAINT [FK_CHITIETDONDATHANG_SANPHAM]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP_PHIEUNHAP] FOREIGN KEY([MAPN])
REFERENCES [dbo].[PHIEUNHAP] ([MAPN])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP_PHIEUNHAP]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP_SANPHAM]
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONDATHANG_KHACHHANG] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DONDATHANG] CHECK CONSTRAINT [FK_DONDATHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISANPHAM] FOREIGN KEY([MALOAISP])
REFERENCES [dbo].[LOAISANPHAM] ([MALOAISP])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISANPHAM]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_NHASANXUAT] FOREIGN KEY([MANSX])
REFERENCES [dbo].[NHASANXUAT] ([MANSX])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_NHASANXUAT]
GO
