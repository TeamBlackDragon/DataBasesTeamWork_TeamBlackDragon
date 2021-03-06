USE [master]
GO
/****** Object:  Database [TeamworkBlackDragon]    Script Date: 25.8.2014 �. 10:53:20 �. ******/
CREATE DATABASE [TeamworkBlackDragon]
GO
ALTER DATABASE [TeamworkBlackDragon] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TeamworkBlackDragon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TeamworkBlackDragon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET ARITHABORT OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TeamworkBlackDragon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TeamworkBlackDragon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TeamworkBlackDragon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TeamworkBlackDragon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TeamworkBlackDragon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET RECOVERY FULL 
GO
ALTER DATABASE [TeamworkBlackDragon] SET  MULTI_USER 
GO
ALTER DATABASE [TeamworkBlackDragon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TeamworkBlackDragon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TeamworkBlackDragon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TeamworkBlackDragon] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TeamworkBlackDragon', N'ON'
GO
USE [TeamworkBlackDragon]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 25.8.2014 �. 10:53:20 �. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 25.8.2014 �. 10:53:20 �. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [text] NULL,
	[Price] [money] NOT NULL,
	[NinjaId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[IsSuccessfull] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ninjas]    Script Date: 25.8.2014 �. 10:53:20 �. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ninjas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[KillCount] [int] NOT NULL,
	[WeaponOfChoice] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[SpecialityId] [int] NOT NULL,
	[MinimalPersonalPrice] [money] NOT NULL,
 CONSTRAINT [PK_Ninjas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Speciality]    Script Date: 25.8.2014 �. 10:53:20 �. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speciality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MinimalCompanyPrice] [money] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Speciality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Clients]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Ninjas] FOREIGN KEY([NinjaId])
REFERENCES [dbo].[Ninjas] ([Id])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Ninjas]
GO
ALTER TABLE [dbo].[Ninjas]  WITH CHECK ADD  CONSTRAINT [FK_Ninjas_Speciality1] FOREIGN KEY([SpecialityId])
REFERENCES [dbo].[Speciality] ([Id])
GO
ALTER TABLE [dbo].[Ninjas] CHECK CONSTRAINT [FK_Ninjas_Speciality1]
GO
USE [master]
GO
ALTER DATABASE [TeamworkBlackDragon] SET  READ_WRITE 
GO
