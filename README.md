# SimpleBlogPRoject
- Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?
Repository & UnitOfWork, Singleton, Abstract
- Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek
yazabilir misiniz?
Linq -> profesyonel hayatımda kullanıyorum, hem db hem C# tarafında elimdeki veriye sorgu atmak için kullanıyorum, 
EntityFramework -> db ilişkilerini yönetmek için kullanıyorum profesyonel hayatımda, 
Autofac -> hem profesyonel hem de kişisel geliştirmelerimde dependency injection olarak kullanıyorum, 
Newtonsoft -> hem profesyonel hem de kişisel geliştirmelerimde json converter olarak kullanıyorum.
- Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?
Loglama eksik kaldı onu eklemek isterdim. Ayrıca hata kontrolleri, ayrıntılı durum mesajları dönmek isterdim. bi metot false döndü ama niye döndü gibi.
Global hata yakalama yapacaktım yetişmedi.
- Eklemek istediğiniz bir yorumunuz var mı?
yok



Gerekli veritabanı scriptleri

USE [master]
GO
/****** Object:  Database [simpleblogproject]    Script Date: 6/30/2020 9:44:44 AM ******/
CREATE DATABASE [simpleblogproject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'simpleblogproject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\simpleblogproject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'simpleblogproject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\simpleblogproject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [simpleblogproject] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [simpleblogproject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [simpleblogproject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [simpleblogproject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [simpleblogproject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [simpleblogproject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [simpleblogproject] SET ARITHABORT OFF 
GO
ALTER DATABASE [simpleblogproject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [simpleblogproject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [simpleblogproject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [simpleblogproject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [simpleblogproject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [simpleblogproject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [simpleblogproject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [simpleblogproject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [simpleblogproject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [simpleblogproject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [simpleblogproject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [simpleblogproject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [simpleblogproject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [simpleblogproject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [simpleblogproject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [simpleblogproject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [simpleblogproject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [simpleblogproject] SET RECOVERY FULL 
GO
ALTER DATABASE [simpleblogproject] SET  MULTI_USER 
GO
ALTER DATABASE [simpleblogproject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [simpleblogproject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [simpleblogproject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [simpleblogproject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [simpleblogproject] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'simpleblogproject', N'ON'
GO
ALTER DATABASE [simpleblogproject] SET QUERY_STORE = OFF
GO
USE [simpleblogproject]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [simpleblogproject]
GO
/****** Object:  User [sa]    Script Date: 6/30/2020 9:44:44 AM ******/
CREATE USER [sa] FOR LOGIN [sa] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 6/30/2020 9:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BloggerId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ShortDescription] [nvarchar](500) NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogger]    Script Date: 6/30/2020 9:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BloggerName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Blogger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPost]    Script Date: 6/30/2020 9:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/30/2020 9:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_BlogPost_Mapping]    Script Date: 6/30/2020 9:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_BlogPost_Mapping](
	[Category_Id] [int] NOT NULL,
	[BlogPost_Id] [int] NOT NULL,
 CONSTRAINT [PK_Category_BlogPost_Mapping] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC,
	[BlogPost_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 6/30/2020 9:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogPostId] [int] NOT NULL,
	[CommenterName] [nvarchar](255) NOT NULL,
	[CommenterEmail] [varchar](255) NOT NULL,
	[CommentBody] [nvarchar](max) NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[Approved] [bit] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 6/30/2020 9:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[EncryptedInfo] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([Id], [BloggerId], [Name], [ShortDescription], [CreatedOnUtc]) VALUES (1, 1, N'kişisel blogum', N'gündelik hayatımı anlatıyorum', CAST(N'2020-06-29T08:43:57.553' AS DateTime))
SET IDENTITY_INSERT [dbo].[Blog] OFF
SET IDENTITY_INSERT [dbo].[Blogger] ON 

INSERT [dbo].[Blogger] ([Id], [BloggerName], [Email], [CreatedOnUtc]) VALUES (1, N'Kürşat Akıncı', N'kursatakinci.126@gmail.com', CAST(N'2020-06-29T06:10:32.590' AS DateTime))
SET IDENTITY_INSERT [dbo].[Blogger] OFF
SET IDENTITY_INSERT [dbo].[BlogPost] ON 

INSERT [dbo].[BlogPost] ([Id], [BlogId], [Title], [Body], [CreatedOnUtc]) VALUES (1, 1, N'Deneme Post Başlığı', N'DEneme Post içeriği', CAST(N'2020-06-29T08:56:11.870' AS DateTime))
SET IDENTITY_INSERT [dbo].[BlogPost] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([Id], [BlogPostId], [CommenterName], [CommenterEmail], [CommentBody], [CreatedOnUtc], [Approved]) VALUES (1, 1, N'Kürşat Akıncı', N'kursatakinci.126@gmail.com', N'Çok güzel post', CAST(N'2020-06-29T09:01:10.983' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([Id], [UserName], [EncryptedInfo]) VALUES (1, N'kursatakinci', N'c6vp4tQYYR8oSypszeBnKgYjG2pc7Q4JKhaxJV3jDPY=')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_Approved]  DEFAULT ((0)) FOR [Approved]
GO
USE [master]
GO
ALTER DATABASE [simpleblogproject] SET  READ_WRITE 
GO
