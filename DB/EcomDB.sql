USE [master]
GO
/****** Object:  Database [EComMgmt]    Script Date: 5/18/2023 3:49:24 AM ******/
CREATE DATABASE [EComMgmt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EComMgmt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\EComMgmt.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EComMgmt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\EComMgmt_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EComMgmt] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EComMgmt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EComMgmt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EComMgmt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EComMgmt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EComMgmt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EComMgmt] SET ARITHABORT OFF 
GO
ALTER DATABASE [EComMgmt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EComMgmt] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EComMgmt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EComMgmt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EComMgmt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EComMgmt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EComMgmt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EComMgmt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EComMgmt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EComMgmt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EComMgmt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EComMgmt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EComMgmt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EComMgmt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EComMgmt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EComMgmt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EComMgmt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EComMgmt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EComMgmt] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EComMgmt] SET  MULTI_USER 
GO
ALTER DATABASE [EComMgmt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EComMgmt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EComMgmt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EComMgmt] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EComMgmt]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/18/2023 3:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](max) NULL,
	[Detail] [varchar](max) NULL,
	[CatUrl] [varchar](max) NULL,
	[ImageName] [varchar](50) NULL,
	[ImageFormat] [varchar](50) NULL,
	[Image] [varbinary](max) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatdDate] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/18/2023 3:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatdDate] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/18/2023 3:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[RoleId] [int] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatdDate] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Detail], [CatUrl], [ImageName], [ImageFormat], [Image], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (1, N'c1', N'c1 d', N'asdasd', N'asd', NULL, NULL, N'aasd', CAST(N'2021-12-12 00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Detail], [CatUrl], [ImageName], [ImageFormat], [Image], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (2, N'c12', N'c1 d2', N'asdasd', N'asd', NULL, NULL, N'aasd', CAST(N'2021-12-12 00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Detail], [CatUrl], [ImageName], [ImageFormat], [Image], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (3, N'c13', N'c1 d3', N'asdasd', N'asd', NULL, NULL, N'aasd', CAST(N'2021-12-12 00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Detail], [CatUrl], [ImageName], [ImageFormat], [Image], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (4, N'c14', N'c1 d4', N'asdasd', N'asd', NULL, NULL, N'aasd', CAST(N'2021-12-12 00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Detail], [CatUrl], [ImageName], [ImageFormat], [Image], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (5, N'cat3 ', N'cat3 detail', NULL, NULL, NULL, NULL, N'israr', CAST(N'2023-05-17 11:14:59.723' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (2, N'Admin', N'2021-11-11', CAST(N'2021-11-11 00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Role] ([RoleId], [RoleName], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (3, N'Emp', N'2021-11-11', CAST(N'2021-11-11 00:00:00.000' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [EmailAddress], [Password], [DOB], [RoleId], [CreatedBy], [CreatdDate], [LastModifiedBy], [LastModifiedDate], [IsActive]) VALUES (1, N'a', N'a', N'a', NULL, 2, N'2021-11-11', CAST(N'2021-11-11 00:00:00.000' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
USE [master]
GO
ALTER DATABASE [EComMgmt] SET  READ_WRITE 
GO
