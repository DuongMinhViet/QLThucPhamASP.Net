
create database QLThucPham

use QLThucPham
go

create table tblProduct(
	MaSanPham int Primary key,
	MaDanhMuc int,
	TenSanPham nvarchar(100) not null,
	DonGiaban money not null,
	SoLuong int not null,
	DonViTinh nvarchar(30) not null,
	Anh nvarchar(max)
);
Go


create table tblProductCategory(
	MaDanhMuc int Primary key,
	TenDanhMuc nvarchar(50) not null,
);
go

Create table tblShippingUnit(
	MaDonVi int Primary key,
	TenDonVi nvarchar(100) not null,
);
GO

Create table tblBill(
	SoHD int Primary key,
	MaKhachHang int,
	NgayBan Datetime not null,
);
go
create table tblBillDetails(
	SoHD int,
	MaSanPham int,
	MaDonVi int,
	SoLuongBan int not null,
	KhuyenMai float,
);
go

create table tblCustomer(
	MaKhachHang int PRIMARY KEY,
	TenKhachHang nvarchar(100) not null,
	SoDienThoai nvarchar(50) not null,
	Email nvarchar(100),
	Pass nvarchar(50),
	DiaChi nvarchar(max)
);
go

create table tblAdmin(
	idAdmin int primary key,
	Username nvarchar(50),
	Password nvarchar(50)
)
Go
create table tblPagination(
	keyword nvarchar(50) not null,
	value int
)
Go

ALter TABLE tblProduct
ADD Foreign key(MaDanhMuc) references tblProductCategory(MaDanhMuc)
Alter table tblBill
ADD foreign key(MaKhachHang) references tblCustomer(MaKhachHang)
ALTER TABLE tblBillDetails
add foreign key(SoHD) references tblBill(SoHD),
foreign key(MaSanPham) references tblProduct(MaSanPham),
foreign key(MaDonVi) references tblShippingUnit(MaDonVi)


insert into tblProductCategory values (1,N'Rau củ'),
									  (2,N'Hoa quả'),
									  (3,N'Hải sản'),
									  (4,N'Các loại hạt'),
									  (5,N'Thực phẩm tươi sống')

insert into tblProduct values (1,1,N'Chanh tươi',15000,50,N'200gram', N'Chanh tươi.jpg'),
							  (2,1,N'Dưa lưới nhập khẩu Thái Lan',90000,50,N'Quả',N'Dưa lưới nhập khẩu Thái Lan.jpg'),
							  (3,1,N'Hành tây đặc biệt',55000,50,N'Củ',N'Hành tây đặc biệt.jpg'),
							  (4,1,N'Nho Mỹ nhập khẩu',265000,50,N'Kg/Hộp',N'Nho Mỹ nhập khẩu.jpg'),
							  (5,1,N'Rau cải bẹ xanh non',20000,50,N'200gram',N'Rau cải bẹ xanh non.jpg'),
							  (6,1,N'Súp lơ trắng',20000,50,N'Cây',N'Súp lơ trắng.jpg'),
							  (7,2,N'Cam Navel ruột vàng',340000,50,N'Kg/Hộp',N'Cam Navel ruột vàng.jpg'),
							  (8,2,N'Đào đỏ Mỹ',39000,50,N'Kg/Hộp',N'Đào đỏ Mỹ.jpg'),
							  (9,2,N'Dâu tây Đà Lạt',350000,50,N'Kg/Hộp',N'Dâu tây Đà Lạt.jpg'),
							  (10,2,N'Lê xanh Mỹ',230000,50,N'Kg/Hộp',N'Lê xanh Mỹ.jpg'),
							  (11,2,N'Lựu đỏ Nam Phi nhập khẩu',115000,50,N'Kg/Hộp',N'Lựu đỏ Nam Phi nhập khẩu.jpg'),
							  (12,2,N'Táo xanh Mỹ',220000,50,N'Kg/Hộp',N'Táo xanh Mỹ.jpg'),
							  (13,2,N'Vải thiều Thanh Hà',79000,50,N'Kg/Hộp',N'Vải thiều Thanh Hà.jpg'),
							  (14,3,N'Cá hồi Mỹ',800000,50,N'500gram',N'Cá hồi Mỹ.jpg'),
							  (15,3,N'Cá hồi',600000,50,N'500gram',N'Cá hồi.jpg'),
							  (16,3,N'Cua bể',250000,50,N'500gram',N'Cua bể.jpg'),
							  (17,3,N'Mực Thanh Hoá',80000,50,N'500gram',N'Mực Thanh Hoá.jpg'),
							  (18,3,N'Tôm biển',350000,50,N'500gram',N'Tôm biển.jpg'),
							  (19,4,N'Hạt điều khô',140000,50,N'500gram/Túi',N'Hạt điều khô.jpg'),
							  (20,4,N'Hạt điều trắng',190000,50,N'500gram/Túi',N'Hạt điều trắng.jpg'),
							  (21,4,N'Hạt hạnh nhân',160000,50,N'500gram/Túi',N'Hạt hạnh nhân.jpg'),
							  (22,4,N'Quả óc chó',215000,50,N'500gram/Túi',N'Quả óc chó.jpg'),
							  (23,5,N'Ba chỉ bò Mỹ',400000,50,N'500gram/Hộp',N'Ba chỉ bò Mỹ.jpg'),
							  (24,5,N'Sườn lợn Brazil',215000,50,N'500gram/Hộp',N'Sườn lợn Brazil.jpg'),
							  (25,5,N'Thịt bò Canada nhập khẩu',300000,50,N'500gram/Hộp',N'Thịt bò Canada nhập khẩu.jpg'),
							  (26,5,N'Thịt bò Kobe',600000,50,N'500gram/Hộp',N'Thịt bò Kobe.jpg'),
							  (27,5,N'Thịt bò Mỹ',365000,50,N'500gram/Hộp',N'Thịt bò Mỹ.jpg'),
							  (28,5,N'Thịt bò thăn',360000,50,N'500gram/Hộp',N'Thịt bò thăn.jpg'),
							  (29,5,N'Thịt lơn nạc vai',100000,50,N'500gram/Hộp',N'Thịt lợn nạc vai.jpg')
							  

insert into tblShippingUnit values(1,N'Giao hàng tiết kiệm'),
								  (2,N'Ahamove'),
								  (3,N'GrapExpress'),
								  (4,'LoShip')
								   
insert into tblCustomer values(1,N'Minh Việt','0965990497','minhviet@gmail.com','123456',N'Hà Nội'),
							(2,N'Thị Nhung','0965990497','thinhung@gmail.com','123456',N'Hà Nội'),
							(3,N'Thế Lộc','0965990497','theloc@gmail.com','123456',null)
							  

insert into tblAdmin values(1,'Admin','Admin')
insert into tblPagination values ('So dong moi trang',5)

