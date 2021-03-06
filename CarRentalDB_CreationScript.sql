USE [master]
GO
/****** Object:  Database [CarRentalDB]    Script Date: 10/11/2020 10:54:26 PM ******/
CREATE DATABASE [CarRentalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRentalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarRentalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRentalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarRentalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarRentalDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRentalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRentalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRentalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRentalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRentalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRentalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRentalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRentalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRentalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRentalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRentalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRentalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRentalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRentalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRentalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRentalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRentalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRentalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRentalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRentalDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CarRentalDB] SET  MULTI_USER 
GO
ALTER DATABASE [CarRentalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRentalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRentalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRentalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRentalDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CarRentalDB', N'ON'
GO
ALTER DATABASE [CarRentalDB] SET QUERY_STORE = OFF
GO
USE [CarRentalDB]
GO
/****** Object:  Table [dbo].[VehicleBrands]    Script Date: 10/11/2020 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleBrands](
	[IDBrand] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_VehicleBrands] PRIMARY KEY CLUSTERED 
(
	[IDBrand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleColors]    Script Date: 10/11/2020 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleColors](
	[IDColor] [int] IDENTITY(1,1) NOT NULL,
	[VehicleColor] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_VehicleColors_1] PRIMARY KEY CLUSTERED 
(
	[IDColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleFuelTypes]    Script Date: 10/11/2020 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleFuelTypes](
	[VehicleFuelTypeName] [nvarchar](255) NOT NULL,
	[Observations] [nvarchar](255) NULL,
 CONSTRAINT [PK_VehicleFuelTypes] PRIMARY KEY CLUSTERED 
(
	[VehicleFuelTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleModels]    Script Date: 10/11/2020 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleModels](
	[IDModel] [int] IDENTITY(1,1) NOT NULL,
	[IDBrand] [int] NOT NULL,
	[ModelName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_VehicleModels_1] PRIMARY KEY CLUSTERED 
(
	[IDModel] ASC,
	[IDBrand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 10/11/2020 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[SerialNumber] [nvarchar](17) NOT NULL,
	[IDModel] [int] NOT NULL,
	[IDBrand] [int] NOT NULL,
	[VehicleFuelTypeName] [nvarchar](255) NOT NULL,
	[IDColor] [int] NOT NULL,
	[Observations] [nvarchar](255) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[SerialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[VehicleBrands] ON 

INSERT [dbo].[VehicleBrands] ([IDBrand], [BrandName]) VALUES (1, N'Volkswagen')
INSERT [dbo].[VehicleBrands] ([IDBrand], [BrandName]) VALUES (2, N'Toyota    ')
INSERT [dbo].[VehicleBrands] ([IDBrand], [BrandName]) VALUES (3, N'Mercedes  ')
INSERT [dbo].[VehicleBrands] ([IDBrand], [BrandName]) VALUES (4, N'Tesla     ')
SET IDENTITY_INSERT [dbo].[VehicleBrands] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleColors] ON 

INSERT [dbo].[VehicleColors] ([IDColor], [VehicleColor]) VALUES (1, N'White')
INSERT [dbo].[VehicleColors] ([IDColor], [VehicleColor]) VALUES (2, N'Blue')
INSERT [dbo].[VehicleColors] ([IDColor], [VehicleColor]) VALUES (3, N'Red')
INSERT [dbo].[VehicleColors] ([IDColor], [VehicleColor]) VALUES (4, N'Black')
INSERT [dbo].[VehicleColors] ([IDColor], [VehicleColor]) VALUES (5, N'Green')
INSERT [dbo].[VehicleColors] ([IDColor], [VehicleColor]) VALUES (6, N'Pink')
INSERT [dbo].[VehicleColors] ([IDColor], [VehicleColor]) VALUES (7, N'Grey')
SET IDENTITY_INSERT [dbo].[VehicleColors] OFF
GO
INSERT [dbo].[VehicleFuelTypes] ([VehicleFuelTypeName], [Observations]) VALUES (N'Diesel', N'fuel')
INSERT [dbo].[VehicleFuelTypes] ([VehicleFuelTypeName], [Observations]) VALUES (N'Electric', NULL)
INSERT [dbo].[VehicleFuelTypes] ([VehicleFuelTypeName], [Observations]) VALUES (N'Petrol', N'-')
GO
SET IDENTITY_INSERT [dbo].[VehicleModels] ON 

INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (1, 1, N'Arteon')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (2, 1, N'Golf')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (3, 1, N'Polo')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (4, 1, N'Passat')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (5, 2, N'Auris')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (6, 2, N'Yaris')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (7, 2, N'Corolla')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (8, 3, N'Benz')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (9, 3, N'AMG')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (10, 3, N'CLA')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (11, 3, N'S Class')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (12, 4, N'Model 3')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (13, 4, N'Model S')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (14, 4, N'Model X')
INSERT [dbo].[VehicleModels] ([IDModel], [IDBrand], [ModelName]) VALUES (15, 4, N'Model Y')
SET IDENTITY_INSERT [dbo].[VehicleModels] OFF
GO
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'12312312312312312', 6, 2, N'Diesel', 1, N'tested')
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'29873617482935155', 1, 1, N'Diesel', 1, N'-')
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'90909090909090909', 12, 4, N'Electric', 6, N'-')
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'JKPWOEIQRLS84U6', 14, 4, N'Electric', 1, N'-')
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'KM76572939IOPWKSI', 9, 3, N'Petrol', 2, N'none')
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'OIUYTREWQASDFGHJK', 8, 3, N'Diesel', 2, N'-')
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'PKY77SD52KP089233', 5, 2, N'Petrol', 2, N'-')
INSERT [dbo].[Vehicles] ([SerialNumber], [IDModel], [IDBrand], [VehicleFuelTypeName], [IDColor], [Observations]) VALUES (N'POT73617UIO935155', 3, 1, N'Diesel', 4, N'-')
GO
ALTER TABLE [dbo].[VehicleModels]  WITH CHECK ADD  CONSTRAINT [FK_VehicleModels_VehicleBrands1] FOREIGN KEY([IDBrand])
REFERENCES [dbo].[VehicleBrands] ([IDBrand])
GO
ALTER TABLE [dbo].[VehicleModels] CHECK CONSTRAINT [FK_VehicleModels_VehicleBrands1]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleColors1] FOREIGN KEY([IDColor])
REFERENCES [dbo].[VehicleColors] ([IDColor])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleColors1]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleFuelTypes] FOREIGN KEY([VehicleFuelTypeName])
REFERENCES [dbo].[VehicleFuelTypes] ([VehicleFuelTypeName])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleFuelTypes]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleModels] FOREIGN KEY([IDModel], [IDBrand])
REFERENCES [dbo].[VehicleModels] ([IDModel], [IDBrand])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleModels]
GO
USE [master]
GO
ALTER DATABASE [CarRentalDB] SET  READ_WRITE 
GO
