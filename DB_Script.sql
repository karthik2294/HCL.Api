USE [master]
GO
/****** Object:  Database [HCL]    Script Date: 01-04-2021 12:43:04 PM ******/
CREATE DATABASE [HCL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HCL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HCL.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HCL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HCL_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HCL] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HCL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HCL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HCL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HCL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HCL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HCL] SET ARITHABORT OFF 
GO
ALTER DATABASE [HCL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HCL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HCL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HCL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HCL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HCL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HCL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HCL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HCL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HCL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HCL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HCL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HCL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HCL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HCL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HCL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HCL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HCL] SET RECOVERY FULL 
GO
ALTER DATABASE [HCL] SET  MULTI_USER 
GO
ALTER DATABASE [HCL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HCL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HCL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HCL] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HCL] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HCL', N'ON'
GO
USE [HCL]
GO
/****** Object:  Schema [Employee]    Script Date: 01-04-2021 12:43:04 PM ******/
CREATE SCHEMA [Employee]
GO
/****** Object:  Table [Employee].[Contact]    Script Date: 01-04-2021 12:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Employee].[Contact](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](320) NOT NULL,
	[Phone] [nchar](10) NOT NULL,
	[Address] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Employee.Contact] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Employee].[uspGetContacts]    Script Date: 01-04-2021 12:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Employee].[uspGetContacts] 
(
@EmployeeId int = -1
)
/*

Purpose					:	To get Employee Contact information.

EXEC [Employee].[uspGetContacts]

*/

AS        
BEGIN
	SET NOCOUNT ON;

		SELECT * FROM [Employee].[Contact]	c
		where c.EmployeeId = CASE WHEN @EmployeeId = -1 THEN c.EmployeeId ELSE @EmployeeId END	

END

GO
USE [master]
GO
ALTER DATABASE [HCL] SET  READ_WRITE 
GO

USE [HCL]
GO

GO
SET IDENTITY_INSERT [Employee].[Contact] ON 

GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (1, N'karthikeyan', N'karthiiii22@gmail.com', N'9894686893', N'7a, Mulligrampattu Road, Nellikuppam, Cuddalore.')
GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (2, N'Soundarya', N'soundarya76@gmail.com', N'9445275594', N'22/20 Permul Koil Street, Valavanur')
GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (4, N'John Jonas', N'johnathan@gmali.com', N'8678344482', N'2c, Busy Steert, Pondicherry')
GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (5, N'Rick Burns', N'burn.rick23@gmali.com', N'7228947921', N'12/24 A, Second Mount Road, Brooklyn')
GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (6, N'Troy', N'troycareers22@gmali.com', N'8237446359', N'20 H, Salem Block, Chicago')
GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (7, N'Jonathans', N'jonasdark22@gmail.com', N'8678344482', N'2c, vazhapattu Steert, Pondicherry')
GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (8, N'Rick anderson', N'anderson.rookie@gmail.com', N'7228947921', N'12/24 A, Second Mount Road, Brooklyn')
GO
INSERT [Employee].[Contact] ([EmployeeId], [Name], [Email], [Phone], [Address]) VALUES (9, N'Sam troy', N'samtrost96@gmail.com', N'7455993312', N'20 H, east sweden block, La Cross')
GO
SET IDENTITY_INSERT [Employee].[Contact] OFF
GO

