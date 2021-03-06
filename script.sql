USE [master]
GO
/****** Object:  Database [Schedure]    Script Date: 2018-09-30 17:27:28 ******/
CREATE DATABASE [Schedure]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'Schedure', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Schedure.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'Schedure_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Schedure_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Schedure] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Schedure].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Schedure] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Schedure] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Schedure] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Schedure] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Schedure] SET ARITHABORT OFF 
GO
ALTER DATABASE [Schedure] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Schedure] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Schedure] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Schedure] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Schedure] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Schedure] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Schedure] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Schedure] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Schedure] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Schedure] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Schedure] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Schedure] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Schedure] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Schedure] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Schedure] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Schedure] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Schedure] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Schedure] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Schedure] SET  MULTI_USER 
GO
ALTER DATABASE [Schedure] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Schedure] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Schedure] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Schedure] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Schedure] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Schedure]
GO
/****** Object:  Table [dbo].[Account_BenhNhan]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_BenhNhan](
	[IDAccountBN] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[BenhNhan_Id] [int] NULL,
	[Token] [nvarchar](50) NULL,
	[TokenExpiration] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[IDAccountBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account_NhanVien]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_NhanVien](
	[IDAccountNV] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[NhanVien_Id] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[IDPosition] [int] NULL,
	[Token] [nvarchar](50) NULL,
	[TokenExpiration] [datetime] NULL,
 CONSTRAINT [PK_Account_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IDAccountNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuyenKhoa]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenKhoa](
	[IDChuyenKhoa] [int] IDENTITY(1,1) NOT NULL,
	[Avatar] [nvarchar](500) NULL,
	[Name] [nvarchar](50) NULL,
	[TimeUse] [int] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Specia] PRIMARY KEY CLUSTERED 
(
	[IDChuyenKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InfoHospital]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoHospital](
	[IDInfoHospital] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Avatar] [nvarchar](500) NULL,
	[Adress] [nvarchar](500) NULL,
	[Hotline] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[WorkStart] [time](7) NULL,
	[WorkEnd] [time](7) NULL,
 CONSTRAINT [PK_InfoHospital] PRIMARY KEY CLUSTERED 
(
	[IDInfoHospital] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichLamViec]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichLamViec](
	[IDLich] [int] IDENTITY(1,1) NOT NULL,
	[NhanVien_Id] [int] NULL,
	[IDTimeSlot] [int] NULL,
	[Creater_Id] [int] NULL,
	[CreaterDate] [datetime] NULL,
	[Date] [datetime] NULL,
	[Status] [nchar](10) NULL,
	[IDPhongKham] [int] NULL,
 CONSTRAINT [PK_LichLamViec] PRIMARY KEY CLUSTERED 
(
	[IDLich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[IDPhongBan] [int] NOT NULL,
	[IDChuyenKhoa] [int] NULL,
	[PhongBan_Id] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[TenPhongBan] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongKham] PRIMARY KEY CLUSTERED 
(
	[IDPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Position]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[IDPosition] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [nvarchar](500) NULL,
	[QL_Bac_Si] [bit] NULL,
	[QL_Chuyen_Khoa] [bit] NULL,
	[Xem_KQCLS] [bit] NULL,
	[QL_Lich_Lam_Viec] [bit] NULL,
	[QL_Phong_Ban] [bit] NULL,
	[QL_Dang_Ky] [bit] NULL,
	[QL_Thoi_Gian_Lam] [bit] NULL,
	[QL_Thong_Tin_Benh_Vien] [bit] NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[IDPosition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Register]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[IDRegister] [int] IDENTITY(1,1) NOT NULL,
	[IDAccountBN] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Message] [nvarchar](500) NULL,
	[Status] [nvarchar](50) NULL,
	[IDLich] [int] NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[NgayKham] [date] NULL,
	[Status_Patient] [nvarchar](50) NULL,
	[Patient_name] [nvarchar](50) NULL,
	[NhanVien_Id] [int] NULL,
	[IDChuyenKhoa] [int] NULL,
 CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED 
(
	[IDRegister] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[IDTimeSlot] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[HourStart] [time](7) NULL,
	[HourEnd] [time](7) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[IDTimeSlot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Account_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_Account_NhanVien_Position] FOREIGN KEY([IDPosition])
REFERENCES [dbo].[Position] ([IDPosition])
GO
ALTER TABLE [dbo].[Account_NhanVien] CHECK CONSTRAINT [FK_Account_NhanVien_Position]
GO
ALTER TABLE [dbo].[LichLamViec]  WITH CHECK ADD  CONSTRAINT [FK_LichLamViec_TimeSlot] FOREIGN KEY([IDTimeSlot])
REFERENCES [dbo].[TimeSlot] ([IDTimeSlot])
GO
ALTER TABLE [dbo].[LichLamViec] CHECK CONSTRAINT [FK_LichLamViec_TimeSlot]
GO
ALTER TABLE [dbo].[PhongBan]  WITH CHECK ADD  CONSTRAINT [FK_PhongKham_ChuyenKhoa] FOREIGN KEY([IDChuyenKhoa])
REFERENCES [dbo].[ChuyenKhoa] ([IDChuyenKhoa])
GO
ALTER TABLE [dbo].[PhongBan] CHECK CONSTRAINT [FK_PhongKham_ChuyenKhoa]
GO
ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_Account] FOREIGN KEY([IDAccountBN])
REFERENCES [dbo].[Account_BenhNhan] ([IDAccountBN])
GO
ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_Account]
GO
ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_LichLamViec] FOREIGN KEY([IDLich])
REFERENCES [dbo].[LichLamViec] ([IDLich])
GO
ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_LichLamViec]
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_BenhNhan_Insert]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Account_BenhNhan_Insert]
@Password NVARCHAR(50),
@Email NVARCHAR(50),
@MaYTe NVARCHAR(50)
AS
BEGIN
DECLARE @BenhNhan_Id INT = (SELECT TOP 1 BenhNhan_Id FROM eHospital_HuuNghi_Dictionary.dbo.DM_BenhNhan WHERE SoVaoVien = @MaYTe) 

	DECLARE @TABLE TABLE(
	IDAccountBN INT
	)

IF(@BenhNhan_Id IS NOT NULL)
	BEGIN



		INSERT dbo.Account_BenhNhan
			( Username ,
			  Password ,
			  Email ,
			  Status ,
			  BenhNhan_Id
			)
			OUTPUT Inserted.IDAccountBN INTO @TABLE
	VALUES  ( @MaYTe , -- Username - nvarchar(50)
			  @Password , -- Password - nvarchar(50)
			  @Email , -- Email - nvarchar(50)
			  N'CONFIRM' , -- Status - nvarchar(50)
			  @BenhNhan_Id  -- BenhNhan_Id - int
			)
			
			PRINT	'SUCCESS'

	end
ELSE PRINT	'FAIL'	

	SELECT TOP 1 IDAccountBN  FROM @TABLE
END	
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_NhanVien_GetAllOrByID]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Account_NhanVien_GetAllOrByID]
@IDAccountNV INT
AS
SELECT nv.* , src.MaNhanVien, src.TenNhanVien, po.Name, po.Status Position_Status FROM dbo.Account_NhanVien nv
LEFT JOIN eHospital_HuuNghi_Dictionary.dbo.NhanVien src ON src.NhanVien_Id = nv.NhanVien_Id
JOIN dbo.Position po ON po.IDPosition = nv.IDPosition
WHERE nv.Status != 'DELETE' AND (@IDAccountNV IS NULL OR nv.IDAccountNV = @IDAccountNV)
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_NhanVien_GetSource]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Account_NhanVien_GetSource]
AS
SELECT src.MaNhanVien, src.TenNhanVien ,src.NhanVien_Id FROM eHospital_HuuNghi_Dictionary.dbo.NhanVien src
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_NhanVien_Insert]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Account_NhanVien_Insert]
@Password  nvarchar(50)
,@MaNhanVien  NVARCHAR(50)
,@IDPosition  int
AS
BEGIN

DECLARE @NhanVien_Id INT = (SELECT TOP 1 NhanVien_Id FROM eHospital_HuuNghi_Dictionary.dbo.NhanVien WHERE MaNhanVien = @MaNhanVien)

IF @NhanVien_Id IS NOT NULL
BEGIN
INSERT dbo.Account_NhanVien
        ( Username ,
          Password ,
          NhanVien_Id ,
          Status ,
          IDPosition
        )
VALUES  ( @MaNhanVien , -- Username - nvarchar(50)
          @Password , -- Password - nvarchar(50)
          @NhanVien_Id , -- NhanVien_Id - int
          N'ACTIVE' , -- Status - nvarchar(50)
          @IDPosition  -- IDPosition - int
        )

		PRINT 'SUCCESS'
END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_BacSi_GetAll]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BacSi_GetAll]

AS 
SELECT
 bs.NhanVien_Id
 , nv.MaNhanVien
 , nv.TenNhanVien
 , pb.IDPhongBan
 , pb.PhongBan_Id
 , pb.Status AS PhongBan_Status
 , pn_src.TenPhongBan
 , ck.Name
 , ck.IDChuyenKhoa
 , ck.Status ChuyenKhoa_Status
 , ck.TimeUse
 
 from eHospital_HuuNghi_Dictionary.dbo.DM_PhongKham_BacSi bs
join eHospital_HuuNghi_Dictionary.dbo.NhanVien nv on bs.NhanVien_Id= nv.NhanVien_Id
JOIN eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan pn_src ON pn_src.PhongBan_Id = nv.PhongBan_Id
JOIN dbo.PhongBan pb ON pb.PhongBan_Id = bs.PhongBan_Id
JOIN	dbo.ChuyenKhoa ck ON ck.IDChuyenKhoa = pb.IDChuyenKhoa

GO
/****** Object:  StoredProcedure [dbo].[SP_BacSi_GetByPhongBan_Id]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BacSi_GetByPhongBan_Id]
@PhongBan_Id int
AS 
SELECT
 bs.NhanVien_Id
 , nv.MaNhanVien
 , nv.TenNhanVien
 , pb.IDPhongBan
 , pb.PhongBan_Id
 , pb.Status AS PhongBan_Status
 , pn_src.TenPhongBan
 , ck.Name
 , ck.IDChuyenKhoa
 , ck.Status ChuyenKhoa_Status
 , ck.TimeUse
 
 from eHospital_HuuNghi_Dictionary.dbo.DM_PhongKham_BacSi bs
join eHospital_HuuNghi_Dictionary.dbo.NhanVien nv on bs.NhanVien_Id= nv.NhanVien_Id
JOIN eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan pn_src ON pn_src.PhongBan_Id = nv.PhongBan_Id
JOIN dbo.PhongBan pb ON pb.PhongBan_Id = bs.PhongBan_Id
JOIN	dbo.ChuyenKhoa ck ON ck.IDChuyenKhoa = pb.IDChuyenKhoa
where bs.PhongBan_Id = @PhongBan_Id

GO
/****** Object:  StoredProcedure [dbo].[SP_ChuyenKhoa_GetAll]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ChuyenKhoa_GetAll]

AS
SELECT 
khoa.IDChuyenKhoa,
khoa.Name AS ChuyenKhoa_Name,
khoa.Status AS ChuyenKhoa_Status,
khoa.TimeUse,
khoa.Avatar,

pb.PhongBan_Id,
pb.TenPhongBan,

bs.NhanVien_Id,
nv.TenNhanVien,

lich.IDLich,
lich.Status AS LichLamViec_Status,
lich.Date,

times.Name AS TimeSplot_Name,
times.HourStart,
times.HourEnd,
times.Status AS TimeSlot_Status


 FROM dbo.ChuyenKhoa khoa
 JOIN dbo.PhongBan pb_ext ON pb_ext.IDChuyenKhoa = khoa.IDChuyenKhoa
 JOIN eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan pb ON pb.PhongBan_Id = pb_ext.PhongBan_Id
 JOIN eHospital_HuuNghi_Dictionary.dbo.DM_PhongKham_BacSi bs ON bs.PhongBan_Id = pb.PhongBan_Id
 JOIN eHospital_HuuNghi_Dictionary.dbo.NhanVien nv ON nv.NhanVien_Id = bs.NhanVien_Id
 JOIN dbo.LichLamViec lich ON lich.NhanVien_Id = bs.NhanVien_Id
 JOIN dbo.TimeSlot times ON times.IDTimeSlot = lich.IDTimeSlot

GO
/****** Object:  StoredProcedure [dbo].[SP_DM_BenhNhan_GetByMaYTe]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DM_BenhNhan_GetByMaYTe]
@MaYTe NVARCHAR(20)
AS 

SELECT TOP 1 bn.[BenhNhan_Id]
      ,[MaYTe]
      ,[MaBenhVien]
      ,[SoVaoVien]
      ,[TenBenhNhan]
      ,[Ho]
      ,[Ten]
      ,[GioiTinh]
      ,[NgaySinh]
      ,[NamSinh]
      ,[DiaChi] 
      ,[VietKieu]
      ,[CMND]
      ,[TenKhongDau]
      ,[GhiChu]
      ,[TienSuBenh]
      ,[Email]
      ,[ChucVu]
	  , bh.SoThe as N'SoThe_BHYT'
	  , bh.NgayHieuLuc as N'NgayHieuLuc_BHYT'
	  , bh.NgayHetHieuLuc as N'NgayHetHieuLuc_BHYT'
  FROM [eHospital_HuuNghi_Dictionary].[dbo].[DM_BenhNhan] bn
  left join [eHospital_HuuNghi_Dictionary].[dbo].DM_BenhNhan_BHYT bh on bn.BenhNhan_Id= bh.BenhNhan_Id
	WHERE bn.SoVaoVien = @MaYTe
GO
/****** Object:  StoredProcedure [dbo].[SP_DM_PhongBan_GetByPhongBan_Id]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DM_PhongBan_GetByPhongBan_Id]
@PhongBan_Id int
AS
SELECT PhongBan_Id, MaPhongBan, TenPhongBan, TenKhongDau 
FROM eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan 
WHERE Cap=2 and LoaiPhongBan_Id= 566 and TamNgung=0 
AND PhongBan_Id = @PhongBan_Id
GO
/****** Object:  StoredProcedure [dbo].[sp_LayChanDoanKhamLS]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  Procedure [dbo].[sp_LayChanDoanKhamLS] 
(
	--@BenhNhan_Id int =null,
	--@TuNgay date=null,
	--@DenNgay date=null
	@KhamBenh_Id int = null
)
as


 
 select 

	DM_BenhNhan.TenBenhNhan as TenBenhNhan,
	DM_BenhNhan.SoVaoVien,
	DM_BenhNhan.BenhNhan_Id ,
	DM_BenhNhan.SoVaoVien as MaYTe,
	Tuoi = LTRIM (STR ((DATEPART (yyyy, GETDATE())		- DM_BenhNhan.NamSinh)))
		,  GioiTinh = (case when DM_BenhNhan.GioiTinh= 'T' then N'Nam' else N'Nữ' end) --dbo.GetTenGioiTinh('VI',DM_BenhNhan.GioiTinh) as GioiTinh,
       , DM_BenhNhan.DiaChi as DiaChi,
	SoDienThoai, 
	KhamBenh.ThoiGianKham, 
	noiDung.TenDichVu as NoiDungKham,
	KhamBenh.TrieuChungLamSang,
	isnull(KhamBenh.ChanDoanKhoaKham,ICD.TenICD) as ChanDoanKhoaKham,
	 PhongKham.TenPhongBan as TenPhongBan,
	HuyetAp = cast(KhamBenh.HuyetApThap as varchar(4)) + '/' + 	cast(KhamBenh.HuyetApCao as varchar(4)) ,
	KhamBenh.Mach, 
	KhamBenh.NhietDo, KhamBenh.NhipTho,
	KhamBenh.ChieuCao, KhamBenh.CanNang,
	Isnull(TiepNhan.SoBHYT,'') as SoBHYT,
	TiepNhan.NguoiLienHe,	
	case when ( SoNgayHenTaiKham > 0)
           then N'Hẹn tái khám ' + cast(SoNgayHenTaiKHam as nvarchar) + N' ngày' --+ ' ('  + 
			+ ' (' + cast(day(dateadd(day,SoNgayHenTaiKham,NgayKham)) as nvarchar(4))
			+ '/' + cast(month(dateadd(day,SoNgayHenTaiKham,NgayKham)) as nvarchar(4))
			+ '/' + cast(year(dateadd(day,SoNgayHenTaiKham,NgayKham)) as nvarchar(4))
			+ ')'  end as NgayHenTaiKham,
	--GioiTinh = case when DM_BenhNhan.GioiTinh= 'T' then N'Nam' else N'Nữ' end ,
	MaBenh= case when icd.MaICD is not null then  icd.MaICD + ' - ' + icd.TenICD  end ,
	MaBenhPhu = case when icd_phu.MaICD is not null then icd_phu.MaICD + ' - ' + icd_phu.TenICD end
--------------------------------------------------

 from  eHospital_HuuNghi.dbo.KhamBenh 
  left join eHospital_HuuNghi_Dictionary.dbo.DM_BenhNhan on KhamBenh.BenhNhan_Id = DM_BenhNhan.BenhNhan_Id -- co trong csdl da gui
  left join eHospital_HuuNghi.dbo.TiepNhan  on TiepNhan.TiepNhan_Id= KhamBenh.TiepNhan_Id 
 left join eHospital_HuuNghi_Dictionary.dbo.DM_ICD icd on KhamBenh.ChanDoanICD_Id = icd.ICD_Id -- co trong csdl da gui
	left join eHospital_HuuNghi_Dictionary.dbo.DM_DichVu noiDung on KhamBenh.DichVu_Id = noiDung.DichVu_Id  -- co trong csdl da gui
 left join eHospital_HuuNghi_Dictionary.dbo.DM_ICD icd_phu on icd_phu.ICD_Id = KhamBenh.ChanDoanPhuICD_Id -- co trong csdl da gui
 left join eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan PhongKham on PhongKham.PhongBan_id = KhamBenh.PhongBan_id -- co trong csdl da gui
  where
  KhamBenh_Id=@KhamBenh_Id
 --  KhamBenh.BenhNhan_Id = @BenhNhan_Id
 --and KhamBenh.NgayKham between  @TuNgay and @DenNgay
 --where KhamBenh.BenhNhan_Id = 44023
 --and KhamBenh.NgayKham= '20180922'


--select * from DM_BenhNhan where SoVaoVien='09020068'
GO
/****** Object:  StoredProcedure [dbo].[SP_LayKetQuaCLS]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  Procedure [dbo].[SP_LayKetQuaCLS] 
(
	@khambenh_id int =null
)
as

SELECT	
			
			NoiDung = REPLACE(isnull(con.TenDichVu,dv.TenDichVu), CHAR(0x1F) + CHAR(10)+CHAR(13), '')
			, KetQua = case when ct.ketqua is null then kq.ketluaN	else ct.ketqua end
			, ct.MucBinhThuong as CSBT
			, ct.BatThuong as TienSu
			, dv.DonViTinh as DonViTinh
			,  ndv.TenNhomDichVu
			--, ma_may = dvmap.MaThietBi
			, mo_ta = kq.mota
			, ket_luan = kq.ketluaN															
			, ngay_kq=CONVERT(DATETIME, isnull(kq.ThoiGianThucHien, yc.ThoiGianYeuCau))						
	
	From	(
				Select	XacNhanChiPhi_id, xnhan.TiepNhan_Id
				From	eHospital_HuuNghi.dbo.XacNhanChiPhi xnhan 
				JOIN eHospital_HuuNghi.dbo.KhamBenh on xnhan.TiepNhan_Id = KhamBenh.TiepNhan_Id  
				Where	KhamBenh.khambenh_id = @khambenh_id
			) xn
		left Join	eHospital_HuuNghi.dbo.XacNhanChiPhiChiTiet xnct On xnct.XacNhanChiPhi_Id = xn.XacNhanChiPhi_Id and xnct.DonGiaHoTroChiTra>0
		left JOIN	eHospital_HuuNghi.dbo.VienPhiNoiTru_Loai_IDRef LI ON LI.Loai_IDRef = xnct.Loai_IDRef and xnct.DonGiaHoTroChiTra>0
		left JOIN	eHospital_HuuNghi.dbo.TiepNhan tn ON tn.TiepNhan_Id = xn.TiepNhan_Id
		left JOIN eHospital_HuuNghi_Dictionary.dbo.DM_BenhNhan bn ON tn.BenhNhan_Id = bn.BenhNhan_Id
	
		left join eHospital_HuuNghi_Dictionary.dbo.DM_DichVu dv on dv.DichVu_Id = xnct.NoiDung_Id
		 AND LI.PhanNhom = 'DV'
		left join eHospital_HuuNghi_Dictionary.dbo.DM_NhomDichVu ndv on ndv.NhomDichVu_Id = dv.NhomDichVu_Id
		left join eHospital_HuuNghi_Dictionary.dbo.DM_DIchVU con on con.CapTren_Id = dv.DichVu_ID
	
		left join  eHospital_HuuNghi.dbo.CLSYeuCauChiTiet clsyc on clsyc.YeuCauChiTiet_Id=xnct.IDRef and xnct.Loai_IDRef='A'
		left join eHospital_HuuNghi.dbo.CLSYeuCau yc on yc.CLSYeuCau_Id=clsyc.CLSYeuCau_Id
		left join eHospital_HuuNghi.dbo.CLSKetQua kq (Nolock) on kq.CLSYeuCau_Id=yc.CLSYeuCau_Id
		left join eHospital_HuuNghi.dbo.clsketquachitiet ct (nolock) on ct.clsketqua_id = kq.clsketqua_id and ct.DichVU_Id = isnull(con.DichVU_ID,dv.DichVU_ID)


	WHERE	1=1
	and xnct.DonGiaHoTroChiTra > 0
	AND (xnct.DonGiaHoTro * xnct.SoLuong) <> 0
		--and ndv.LoaiDichVu_Id = 2
		and ct.KetQua is not null

	

GO
/****** Object:  StoredProcedure [dbo].[sp_LayNgayKhamTuNgayDenNgay]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  Procedure [dbo].[sp_LayNgayKhamTuNgayDenNgay] 
(
	@BenhNhan_Id int =null,
	@TuNgay date=null,
	@DenNgay date=null
)
as


 
 select 
 KhamBenh.KhamBenh_Id,
	DM_BenhNhan.TenBenhNhan as TenBenhNhan,
	DM_BenhNhan.SoVaoVien as MaYTe,
	Tuoi = LTRIM (STR ((DATEPART (yyyy, GETDATE())		- DM_BenhNhan.NamSinh))),
 GioiTinh = case when DM_BenhNhan.GioiTinh= 'T' then N'Nam' else N'Nữ' end,
        DM_BenhNhan.DiaChi as DiaChi,
	SoDienThoai, 
	KhamBenh.ThoiGianKham, 
	--noiDung.TenDichVu as NoiDungKham,
	KhamBenh.TrieuChungLamSang,
	--isnull(KhamBenh.ChanDoanKhoaKham,ICD.TenICD) as ChanDoanKhoaKham,
	 PhongKham.TenPhongBan as TenPhongBan,
	HuyetAp = cast(KhamBenh.HuyetApThap as varchar(4)) + '/' + 	cast(KhamBenh.HuyetApCao as varchar(4)) ,
	KhamBenh.Mach, 
	KhamBenh.NhietDo, KhamBenh.NhipTho,
	KhamBenh.ChieuCao, KhamBenh.CanNang,
	Isnull(TiepNhan.SoBHYT,'') as SoBHYT,
	TiepNhan.NguoiLienHe,	
	case when ( SoNgayHenTaiKham > 0)
           then N'Hẹn tái khám ' + cast(SoNgayHenTaiKHam as nvarchar) + N' ngày' --+ ' ('  + 
			+ ' (' + cast(day(dateadd(day,SoNgayHenTaiKham,NgayKham)) as nvarchar(4))
			+ '/' + cast(month(dateadd(day,SoNgayHenTaiKham,NgayKham)) as nvarchar(4))
			+ '/' + cast(year(dateadd(day,SoNgayHenTaiKham,NgayKham)) as nvarchar(4))
			+ ')'  end as NgayHenTaiKham
	--,GioiTinh = case when DM_BenhNhan.GioiTinh= 'T' then N'Nam' else N'Nữ' end
	--MaBenh= case when icd.MaICD is not null then  icd.MaICD + ' - ' + icd.TenICD  end ,
	--MaBenhPhu = case when icd_phu.MaICD is not null then icd_phu.MaICD + ' - ' + icd_phu.TenICD end
--------------------------------------------------

 from eHospital_HuuNghi.dbo.KhamBenh 
  left JOIN eHospital_HuuNghi_Dictionary.dbo.DM_BenhNhan DM_BenhNhan on KhamBenh.BenhNhan_Id = DM_BenhNhan.BenhNhan_Id -- co trong csdl da gui
  left join eHospital_HuuNghi.dbo.TiepNhan  on TiepNhan.TiepNhan_Id= KhamBenh.TiepNhan_Id 
 --left join DM_ICD icd on KhamBenh.ChanDoanICD_Id = icd.ICD_Id -- co trong csdl da gui
	--left join DM_DichVu noiDung on KhamBenh.DichVu_Id = noiDung.DichVu_Id  -- co trong csdl da gui
 --left join DM_ICD icd_phu on icd_phu.ICD_Id = KhamBenh.ChanDoanPhuICD_Id -- co trong csdl da gui
 left JOIN eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan PhongKham on PhongKham.PhongBan_id = KhamBenh.PhongBan_id -- co trong csdl da gui
  where (@BenhNhan_Id IS NULL OR  KhamBenh.BenhNhan_Id = @BenhNhan_Id)
 and KhamBenh.NgayKham between  @TuNgay and @DenNgay
 --where KhamBenh.BenhNhan_Id = 44023
 --and KhamBenh.NgayKham= '20180922'


--select * from DM_BenhNhan where SoVaoVien='09020068'
GO
/****** Object:  StoredProcedure [dbo].[SP_LichLamViec_GetAllOrID]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LichLamViec_GetAllOrID]
@IDLich INT
AS
SELECT 
lich.IDLich
, lich.NhanVien_Id
, lich.IDTimeSlot
, lich.Creater_Id
, lich.CreaterDate
, lich.Date
, lich.Status LichLamViec_Status
, lich.IDPhongKham

, pb.TenPhongBan
, pb.IDPhongBan


, ck.Name ChuyenKhoa_Name
, ck.IDChuyenKhoa

, time.Name
, time.HourStart
, time.HourEnd
, time.Status AS TimeSlot_Status

, nv.TenNhanVien
, nv.PhongBan_Id

FROM dbo.LichLamViec lich
JOIN dbo.TimeSlot time ON	time.IDTimeSlot = lich.IDTimeSlot
JOIN eHospital_HuuNghi_Dictionary.dbo.NhanVien nv ON nv.NhanVien_Id = lich.NhanVien_Id
JOIN dbo.PhongBan pb ON pb.IDPhongBan = lich.IDPhongKham
JOIN dbo.ChuyenKhoa ck ON ck.IDChuyenKhoa = pb.IDChuyenKhoa
WHERE @IDLich IS NULL OR lich.IDLich = @IDLich
GO
/****** Object:  StoredProcedure [dbo].[SP_LichLamViec_GetByPhongBan_Id]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LichLamViec_GetByPhongBan_Id]
@PhongBan_Id INT,
@date DATE
AS
SELECT 
lich.IDLich
, lich.NhanVien_Id
, lich.IDTimeSlot
, lich.Creater_Id
, lich.CreaterDate
, lich.Date
, lich.Status LichLamViec_Status
, lich.IDPhongKham

, time.Name
, time.HourStart
, time.HourEnd
, time.Status AS TimeSlot_Status

, nv.TenNhanVien
, nv.PhongBan_Id

FROM dbo.LichLamViec lich
JOIN dbo.TimeSlot time ON	time.IDTimeSlot = lich.IDTimeSlot
JOIN eHospital_HuuNghi_Dictionary.dbo.NhanVien nv ON nv.NhanVien_Id = lich.NhanVien_Id
WHERE lich.IDPhongKham = @PhongBan_Id 
AND (@date IS NULL or CONVERT(DATE,lich.Date) = CONVERT(DATE,@date))
GO
/****** Object:  StoredProcedure [dbo].[SP_PhongBan_GetAll]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_PhongBan_GetAll]
AS
SELECT 
pb.PhongBan_Id
, src.MaPhongBan
, src.TenPhongBan
, src.TenKhongDau 
, ck.Name
, ck.IDChuyenKhoa
, ck.Status AS ChuyenKhoa_Status
, pb.IDPhongBan
, pb.Status AS PhongBan_Status
FROM eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan src
JOIN dbo.PhongBan pb ON pb.PhongBan_Id = src.PhongBan_Id
JOIN dbo.ChuyenKhoa ck ON ck.IDChuyenKhoa = pb.IDChuyenKhoa
WHERE Cap=2 and LoaiPhongBan_Id= 566 and TamNgung=0 
GO
/****** Object:  StoredProcedure [dbo].[SP_PhongBan_GetSource]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_PhongBan_GetSource]
AS
SELECT PhongBan_Id, MaPhongBan, TenPhongBan, TenKhongDau 
FROM eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan 
WHERE Cap=2 and LoaiPhongBan_Id= 566 and TamNgung=0 
GO
/****** Object:  StoredProcedure [dbo].[SP_PhongBan_Insert]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_PhongBan_Insert]
@IDChuyenKhoa   int
, @PhongBan_Id  int
AS
IF(NOT EXISTS(SELECT PhongBan_Id FROM dbo.PhongBan WHERE PhongBan_Id = @PhongBan_Id))
BEGIN

DECLARE @TenPhongBan NVARCHAR(500) = (SELECT TenPhongBan FROM eHospital_HuuNghi_Dictionary.dbo.DM_PhongBan WHERE PhongBan_Id = @PhongBan_Id) 

IF @TenPhongBan IS NOT NULL

INSERT INTO dbo.PhongBan
        ( 
        IDPhongBan,
          IDChuyenKhoa ,
          PhongBan_Id ,
          Status ,
          TenPhongBan
        )
VALUES  ( 
@PhongBan_Id , 
          @IDChuyenKhoa  ,
          @PhongBan_Id , 
          N'ACTIVE' , -- Status - nvarchar(50)
          @TenPhongBan  -- TenPhongBan - nvarchar(50)
        )

		END
        
GO
/****** Object:  StoredProcedure [dbo].[SP_Register_GetAllOrBy]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Register_GetAllOrBy]
@start DATETIME
,@end DATETIME
,@Status NVARCHAR(50)
,@IDPhongBan INT
,@IDRegiter INT
,@IDAccount INT
AS

SELECT 
dbo.Register.IDRegister
,dbo.Register.IDAccountBN
,dbo.Register.CreateDate
,dbo.Register.Message
,dbo.Register.Status
,dbo.Register.IDLich
,dbo.Register.Phone
,dbo.Register.NgayKham
,dbo.Register.Status_Patient
,dbo.Register.Patient_name
,dbo.Register.NhanVien_Id
,dbo.Register.IDChuyenKhoa

,ck.Name ChuyenKhoa_Name

,dbo.PhongBan.TenPhongBan

,nv.TenNhanVien

,lich.Status LichLamViec_Status
,lich.IDPhongKham

,time.Name TimeSlot_Name
,time.HourStart
,time.HourEnd
,time.Status TimeSlot_Status

, bn.Username

FROM dbo.Register
LEFT JOIN eHospital_HuuNghi_Dictionary.dbo.NhanVien nv ON nv.NhanVien_Id = Register.NhanVien_Id
LEFT JOIN dbo.LichLamViec lich ON lich.IDLich = Register.IDLich
LEFT JOIN dbo.PhongBan ON PhongBan.IDPhongBan = lich.IDPhongKham
LEFT JOIN dbo.ChuyenKhoa ck ON ck.IDChuyenKhoa = PhongBan.IDChuyenKhoa
LEFT JOIN dbo.TimeSlot time ON time.IDTimeSlot = lich.IDTimeSlot
LEFT JOIN dbo.Account_BenhNhan bn ON bn.IDAccountBN = Register.IDAccountBN
WHERE 
(
@IDRegiter IS NOT NULL AND IDRegister = @IDRegiter
)
OR 
(
@IDRegiter IS NULL
AND (@IDAccount IS NULL OR dbo.Register.IDAccountBN = @IDAccount)
AND CONVERT(DATE, dbo.Register.CreateDate) BETWEEN  CONVERT(DATE, @start) and CONVERT(DATE,@end)
AND (@Status IS NULL or dbo.Register.Status = @Status)
AND (@IDPhongBan IS NULL OR lich.IDPhongKham = @IDPhongBan)
)
ORDER BY dbo.Register.NgayKham
GO
/****** Object:  StoredProcedure [dbo].[SP_Register_Insert]    Script Date: 2018-09-30 17:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Register_Insert]
@IDAccountBN int,
@MaYTe NVARCHAR(50),
          @Message NVARCHAR(500),
          @Status NVARCHAR(50),
          @IDLich int,
         @Phone NVARCHAR(12),
          @NgayKham DATE,
          @Status_Patient NVARCHAR(50),
          @Patient_name NVARCHAR(50),
         @NhanVien_Id int,
          @IDChuyenKhoa int
AS BEGIN



IF @IDAccountBN IS NULL AND @MaYTe IS NOT NULL
IF not EXISTS(SELECT * FROM eHospital_HuuNghi_Dictionary.dbo.DM_BenhNhan WHERE SoVaoVien = @MaYTe) 
BEGIN
	PRINT 'ko thay ma y te'
	SET @MaYTe = NULL
end
ELSE 
BEGIN
	PRINT @MaYTe
	SET @Patient_name += ' ('+@MaYTe+')'
end

IF @IDAccountBN IS NOT NULL OR @MaYTe IS NOT NULL
	INSERT dbo.Register
        ( IDAccountBN ,
          CreateDate ,
          Message ,
          Status ,
          IDLich ,
          Phone ,
          NgayKham ,
          Status_Patient ,
          Patient_name ,
          NhanVien_Id ,
          IDChuyenKhoa
        )
VALUES  ( @IDAccountBN , -- IDAccountBN - int
          GETDATE() , -- CreateDate - datetime
          @Message , -- Message - nvarchar(500)
          @Status , -- Status - nvarchar(50)
          @IDLich , -- IDLich - int
          @Phone , -- Phone - nvarchar(12)
          @NgayKham , -- NgayKham - date
          @Status_Patient , -- Status_Patient - nvarchar(50)
          @Patient_name , -- Patient_name - nvarchar(50)
          @NhanVien_Id , -- NhanVien_Id - int
          @IDChuyenKhoa  -- IDChuyenKhoa - int
        )

		end
GO
USE [master]
GO
ALTER DATABASE [Schedure] SET  READ_WRITE 
GO
