USE [master]
GO
/****** Object:  Database [db_Apotek]    Script Date: 19/07/2022 13:36:31 ******/
CREATE DATABASE [db_Apotek]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_Apotek', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_Apotek.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_Apotek_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_Apotek_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_Apotek] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_Apotek].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_Apotek] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_Apotek] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_Apotek] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_Apotek] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_Apotek] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_Apotek] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_Apotek] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_Apotek] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_Apotek] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_Apotek] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_Apotek] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_Apotek] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_Apotek] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_Apotek] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_Apotek] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_Apotek] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_Apotek] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_Apotek] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_Apotek] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_Apotek] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_Apotek] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_Apotek] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_Apotek] SET RECOVERY FULL 
GO
ALTER DATABASE [db_Apotek] SET  MULTI_USER 
GO
ALTER DATABASE [db_Apotek] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_Apotek] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_Apotek] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_Apotek] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_Apotek] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_Apotek] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_Apotek', N'ON'
GO
ALTER DATABASE [db_Apotek] SET QUERY_STORE = OFF
GO
USE [db_Apotek]
GO
/****** Object:  Table [dbo].[Tbl_log]    Script Date: 19/07/2022 13:36:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_log](
	[Id_log] [int] IDENTITY(1,1) NOT NULL,
	[Waktu] [date] NOT NULL,
	[Aktifitas] [nvarchar](50) NOT NULL,
	[Id_User] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_log] PRIMARY KEY CLUSTERED 
(
	[Id_log] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Obat]    Script Date: 19/07/2022 13:36:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Obat](
	[Id_Obat] [int] IDENTITY(1,1) NOT NULL,
	[Kode_Obat] [nvarchar](50) NOT NULL,
	[Nama_Obat] [nvarchar](50) NOT NULL,
	[Expired_Date] [date] NOT NULL,
	[Jumlah] [bigint] NOT NULL,
	[Harga] [bigint] NOT NULL,
 CONSTRAINT [PK_Tbl_Obat] PRIMARY KEY CLUSTERED 
(
	[Id_Obat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Resep]    Script Date: 19/07/2022 13:36:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Resep](
	[Id_Resep] [int] IDENTITY(1,1) NOT NULL,
	[No_Resep] [nvarchar](50) NOT NULL,
	[Tgl_Resep] [date] NOT NULL,
	[Nama_Dokter] [nvarchar](50) NOT NULL,
	[Nama_Pasien] [varchar](50) NOT NULL,
	[Nama_ObatDibeli] [nvarchar](50) NOT NULL,
	[Jumlah_ObatDibeli] [bigint] NOT NULL,
	[Id_Obat] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Resep] PRIMARY KEY CLUSTERED 
(
	[Id_Resep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Transaksi]    Script Date: 19/07/2022 13:36:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Transaksi](
	[Id_Transaksi] [int] IDENTITY(1,1) NOT NULL,
	[No_Transaksi] [nvarchar](50) NOT NULL,
	[Tgl_Transaksi] [date] NOT NULL,
	[Total_Bayar] [bigint] NOT NULL,
	[Id_User] [int] NOT NULL,
	[Id_Obat] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Transaksi] PRIMARY KEY CLUSTERED 
(
	[Id_Transaksi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 19/07/2022 13:36:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[Id_User] [int] IDENTITY(1,1) NOT NULL,
	[Tipe_User] [nvarchar](50) NOT NULL,
	[Nama_User] [nvarchar](50) NOT NULL,
	[Alamat] [nvarchar](150) NOT NULL,
	[Telepon] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_log] ON 

INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (1, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (2, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (3, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (4, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (5, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (6, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (7, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (8, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (9, CAST(N'2022-07-19' AS Date), N'Login', 2)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (10, CAST(N'2022-07-19' AS Date), N'Login', 2)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (11, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (12, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (13, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (14, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (15, CAST(N'2022-07-19' AS Date), N'Login', 2)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (16, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (17, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (18, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (19, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (20, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (21, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (22, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (23, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (24, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (25, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (26, CAST(N'2022-07-19' AS Date), N'Login', 3)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (27, CAST(N'2022-07-19' AS Date), N'Login', 2)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (28, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (29, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (30, CAST(N'2022-07-19' AS Date), N'Login', 1)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (31, CAST(N'2022-07-19' AS Date), N'Login', 2)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (32, CAST(N'2022-07-19' AS Date), N'Login', 2)
INSERT [dbo].[Tbl_log] ([Id_log], [Waktu], [Aktifitas], [Id_User]) VALUES (33, CAST(N'2022-07-19' AS Date), N'Login', 2)
SET IDENTITY_INSERT [dbo].[Tbl_log] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Obat] ON 

INSERT [dbo].[Tbl_Obat] ([Id_Obat], [Kode_Obat], [Nama_Obat], [Expired_Date], [Jumlah], [Harga]) VALUES (3, N'K001', N'Sanmol', CAST(N'2024-06-13' AS Date), 12, 10000)
INSERT [dbo].[Tbl_Obat] ([Id_Obat], [Kode_Obat], [Nama_Obat], [Expired_Date], [Jumlah], [Harga]) VALUES (4, N'K002', N'Paracetamol', CAST(N'2023-02-10' AS Date), 30, 5000)
INSERT [dbo].[Tbl_Obat] ([Id_Obat], [Kode_Obat], [Nama_Obat], [Expired_Date], [Jumlah], [Harga]) VALUES (6, N'K003', N'Panadol', CAST(N'2022-01-01' AS Date), 30, 5000)
SET IDENTITY_INSERT [dbo].[Tbl_Obat] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Resep] ON 

INSERT [dbo].[Tbl_Resep] ([Id_Resep], [No_Resep], [Tgl_Resep], [Nama_Dokter], [Nama_Pasien], [Nama_ObatDibeli], [Jumlah_ObatDibeli], [Id_Obat]) VALUES (2, N'R001', CAST(N'2022-07-19' AS Date), N'Budi', N'Ani', N'Sanmol', 3, 6)
SET IDENTITY_INSERT [dbo].[Tbl_Resep] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Transaksi] ON 

INSERT [dbo].[Tbl_Transaksi] ([Id_Transaksi], [No_Transaksi], [Tgl_Transaksi], [Total_Bayar], [Id_User], [Id_Obat]) VALUES (4, N'07  /19  /  2022', CAST(N'2022-07-19' AS Date), 10000, 3, 4)
SET IDENTITY_INSERT [dbo].[Tbl_Transaksi] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([Id_User], [Tipe_User], [Nama_User], [Alamat], [Telepon], [Username], [Password]) VALUES (1, N'Admin', N'Arief', N'Jakarta', N'085221367400', N'Arief', N'arief')
INSERT [dbo].[Tbl_User] ([Id_User], [Tipe_User], [Nama_User], [Alamat], [Telepon], [Username], [Password]) VALUES (2, N'Apoteker', N'Dimas', N'Semarang', N'0812345678', N'Dimas', N'dimas')
INSERT [dbo].[Tbl_User] ([Id_User], [Tipe_User], [Nama_User], [Alamat], [Telepon], [Username], [Password]) VALUES (3, N'Kasir', N'Adi', N'Bogor', N'087654321', N'Adi', N'adi')
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
GO
ALTER TABLE [dbo].[Tbl_log]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_log_Tbl_User] FOREIGN KEY([Id_User])
REFERENCES [dbo].[Tbl_User] ([Id_User])
GO
ALTER TABLE [dbo].[Tbl_log] CHECK CONSTRAINT [FK_Tbl_log_Tbl_User]
GO
ALTER TABLE [dbo].[Tbl_Resep]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Resep_Tbl_Obat] FOREIGN KEY([Id_Obat])
REFERENCES [dbo].[Tbl_Obat] ([Id_Obat])
GO
ALTER TABLE [dbo].[Tbl_Resep] CHECK CONSTRAINT [FK_Tbl_Resep_Tbl_Obat]
GO
ALTER TABLE [dbo].[Tbl_Transaksi]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Transaksi_Tbl_Obat] FOREIGN KEY([Id_Obat])
REFERENCES [dbo].[Tbl_Obat] ([Id_Obat])
GO
ALTER TABLE [dbo].[Tbl_Transaksi] CHECK CONSTRAINT [FK_Tbl_Transaksi_Tbl_Obat]
GO
ALTER TABLE [dbo].[Tbl_Transaksi]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Transaksi_Tbl_User] FOREIGN KEY([Id_User])
REFERENCES [dbo].[Tbl_User] ([Id_User])
GO
ALTER TABLE [dbo].[Tbl_Transaksi] CHECK CONSTRAINT [FK_Tbl_Transaksi_Tbl_User]
GO
USE [master]
GO
ALTER DATABASE [db_Apotek] SET  READ_WRITE 
GO
