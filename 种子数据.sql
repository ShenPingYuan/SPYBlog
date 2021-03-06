USE [master]
GO
/****** Object:  Database [db_SPYBlog]    Script Date: 2019/12/14 19:12:41 ******/
CREATE DATABASE [db_SPYBlog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_SPYBlog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\db_SPYBlog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_SPYBlog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\db_SPYBlog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [db_SPYBlog] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_SPYBlog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_SPYBlog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_SPYBlog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_SPYBlog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_SPYBlog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_SPYBlog] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_SPYBlog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_SPYBlog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_SPYBlog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_SPYBlog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_SPYBlog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_SPYBlog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_SPYBlog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_SPYBlog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_SPYBlog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_SPYBlog] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_SPYBlog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_SPYBlog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_SPYBlog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_SPYBlog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_SPYBlog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_SPYBlog] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [db_SPYBlog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_SPYBlog] SET RECOVERY FULL 
GO
ALTER DATABASE [db_SPYBlog] SET  MULTI_USER 
GO
ALTER DATABASE [db_SPYBlog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_SPYBlog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_SPYBlog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_SPYBlog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_SPYBlog] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_SPYBlog', N'ON'
GO
ALTER DATABASE [db_SPYBlog] SET QUERY_STORE = OFF
GO
USE [db_SPYBlog]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019/12/14 19:12:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 2019/12/14 19:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](128) NULL,
	[Content] [nvarchar](max) NULL,
	[ViewCount] [int] NOT NULL,
	[Sort] [nvarchar](10) NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[Source] [nvarchar](128) NULL,
	[SeoTitle] [nvarchar](128) NULL,
	[SeoKeyword] [nvarchar](256) NULL,
	[SeoDescription] [nvarchar](512) NULL,
	[AddManagerId] [int] NOT NULL,
	[AddTime] [datetime2](7) NOT NULL,
	[ModifyManagerId] [int] NULL,
	[ModifyTime] [datetime2](7) NULL,
	[IsTop] [bit] NOT NULL,
	[IsSlide] [bit] NOT NULL,
	[IsRed] [bit] NOT NULL,
	[IsPublish] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2019/12/14 19:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2019/12/14 19:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2019/12/14 19:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2019/12/14 19:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](50) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[UserId] [nvarchar](50) NOT NULL,
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[NickName] [nvarchar](20) NULL,
	[RoleName] [nvarchar](20) NULL,
	[Sex] [nvarchar](max) NULL,
	[IsInUsing] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[EndTime] [nvarchar](max) NULL,
	[UserDescription] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Area] [nvarchar](max) NULL,
	[RealName] [nvarchar](max) NULL,
	[BirthDate] [nvarchar](max) NULL,
	[UserFaceImgUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](50) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[children]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[children](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_children] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentReply]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentReply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QQ] [nvarchar](11) NOT NULL,
	[HeadImageUrl] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[NickName] [nvarchar](20) NOT NULL,
	[CommentDateTime] [datetime2](7) NOT NULL,
	[CommentTime] [nvarchar](max) NULL,
	[Supports] [int] NOT NULL,
	[CommentId] [int] NOT NULL,
 CONSTRAINT [PK_CommentReply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[QQ] [nvarchar](11) NOT NULL,
	[HeadImageUrl] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[NickName] [nvarchar](20) NOT NULL,
	[CommentDateTime] [datetime2](7) NOT NULL,
	[CommentTime] [nvarchar](max) NULL,
	[Supports] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desks]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
 CONSTRAINT [PK_Desks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parents]    Script Date: 2019/12/14 19:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_parents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[relationShips]    Script Date: 2019/12/14 19:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[relationShips](
	[ChildID] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
 CONSTRAINT [PK_relationShips] PRIMARY KEY CLUSTERED 
(
	[ChildID] ASC,
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 2019/12/14 19:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteInfo]    Script Date: 2019/12/14 19:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColumnCount] [int] NOT NULL,
	[CommentCount] [int] NOT NULL,
	[ArticleCount] [int] NOT NULL,
	[TagCount] [int] NOT NULL,
	[Views] [int] NOT NULL,
	[CenterTitle] [nvarchar](100) NULL,
	[Motto] [nvarchar](50) NULL,
 CONSTRAINT [PK_SiteInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2019/12/14 19:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[DeskID] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 2019/12/14 19:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[Src] [nvarchar](max) NOT NULL,
	[IsInChina] [nvarchar](max) NULL,
	[IsOpen] [bit] NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 2019/12/14 19:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[SchoolID] [int] NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191207075325_init', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191208170139_init1', N'2.2.6-servicing-10079')
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Category], [Title], [description], [ImageUrl], [Content], [ViewCount], [Sort], [UserId], [Source], [SeoTitle], [SeoKeyword], [SeoDescription], [AddManagerId], [AddTime], [ModifyManagerId], [ModifyTime], [IsTop], [IsSlide], [IsRed], [IsPublish], [IsDeleted]) VALUES (1, N'计算机', N'这篇文章用来测试啦', N'这篇文章用来测试啦这篇文章用来测试啦这篇文章用来测试啦', N'https://localhost:5003/file/upload/images/20191201/201912012353517963507.jpg', N'<h4 class="body-title">概要</h4><p>大致过程:把U盘插入USB接口，再用我给的软件(<span class="note">后面给出</span>)把PE系统（<span class="note">一种维护系统的系统</span>）写入到U盘，再把Windows系统镜像文件(<span class="note">后面给出</span>)放到这个U盘里，再进入到这个PE系统，通过里面的工具，把Windows系统镜像文件安装到对应的硬盘上,提示成功后，关机，把U盘，开机，over；</p><h4 class="body-title">步骤一:制作杏雨梨云U盘PE系统</h4><p>❀准备一个16GB以上大小的U盘，并将里面重要内容全部备份(<span class="note">U盘在制作成PE系统时会被格式化</span>)</p><p>❀下载杏雨梨云PE系统制作工具，点击右侧下载 &nbsp;<a class="btn btn-success" href target="_blank">点我下载</a></p><p>❀下载后得到压缩包，不要解压，先关闭防火墙，关闭杀毒软件，再解压，运行解压得到的文件夹中的“杏雨梨云启动维护系统.exe”</p><p><img src="/images/computer/computer_1/01.jpg" alt=""/></p><p><span class="note-hot">关闭防火墙</span></p><p><img src="/images/computer/computer_1/02.jpg" height="925" width="1045"/></p><p><span class="note-hot">然后</span></p><p><img src="/images/computer/computer_1/03.jpg" height="518" width="853"/></p><p><span class="note-hot">解压杏雨梨云解压包后得到如下文件，运行程序</span></p><p><img src="/images/computer/computer_1/04.jpg" height="166" width="617"/></p><p><span class="note-hot">运行</span></p><p><img src="/images/computer/computer_1/05.jpg" height="454" width="486"/></p><p>❀选择你先前准备好的U盘，选择全新安装到U盘，点击开始后等待屏幕下方的进度条走完就OK</p><p><span class="note-hot">等进度条走完</span></p><p><img src="/images/computer/computer_1/06.jpg" alt=""/></p><p><span class="note-hot">PE系统制作成功</span></p><p><img src="/images/computer/computer_1/07.jpg" alt=""/></p><p><span class="note-hot">打开U盘里面有如下文件</span></p><p><img src="/images/computer/computer_1/08.jpg" height="103" width="618"/></p><h4 class="body-title">步骤二:下载Windows 系统镜像文件</h4><p>❀你要把系统安装到U盘，那总得要有系统吧，有个叫做&quot;<a class="btn btn-success" href="https://msdn.itellyou.cn/" target="_blank">I Tell You(点击直达)</a>&quot;的网站就很不错了，
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;这个网站的所有资源都是免费的，而且是官网原版的，可以说是很良心了。回到主题，系统呢？。。</p><p>1、进入Itellyou官网，点击“操作系统”</p><p><img src="/images/computer/computer_1/itellyou0.png" height="295" width="271"/></p><p>2、选择你要的Windows版本，建议下载Version1903（Windows10每年五月和十月推送03和09更新(从1703开始,1703之前是1611,1607,1507.win10是15年7月31日发布)
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;每个03版本享受18个月技术与服务支持,每个09版本享受30个月技术与服务支持.
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;在支持结束后,所有win10版本依然享受安全更新,以服务不愿升级win10版本的人,使他们的电脑能够抵御最新病毒的侵害,修复漏洞.
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;关于为什么你觉得win10不是新版本号取代旧版本.我想问问你,当你的电脑提示有更新可用时,是不是第一时间去安装.不是新版本号没有取代旧版本,而是你不愿更新罢了.
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;win10-1703，1709，1803，1809，1903的区别就在于新功能不同，UI不同。易用性不同。越新的版本，越好用，新功能越多。
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;例如：1903）</p><p><img src="/images/computer/computer_1/itellyou1.png" height="516" width="271"/></p><p>3、这里建议(并不一定)选择我给的勾选项（注：具体怎么选择：
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;1.<a href="https://blog.csdn.net/liubing8609/article/details/80822539" target="_blank">Windows 10版本business_editions和consumer_editions的区别？</a>
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;2.运行电脑的CPU是32位的就选择&quot;x86&quot;的，64位的就选择&quot;x64&quot;的,<span class="note">现在基本都是64位的</span></p><p><img src="/images/computer/computer_1/itellyou2.png" height="211" width="855"/></p><p>4、如果你的电脑上安装了迅雷，复制这段连接直接打开迅雷就会弹出下载连接，如果没安装就先安装个迅雷（<a href="https://www.xunlei.com/" target="_blank">迅雷官网</a>）</p><p><img src="/images/computer/computer_1/itellyou3.png" height="200" width="736"/></p><p><span class="note-hot">将下载的Windows10镜像文件复制到U盘中(<span class="note">大小接近5GB</span>)</span></p><p><img src="/images/computer/computer_1/09.jpg" height="119" width="612"/></p><h4 class="body-title">步骤三:在将要重装系统的电脑上启动U盘PE系统</h4><p>❀将PE系统U盘插入将要重装系统的电脑上，电脑关机，按开机键并进入到系统启动选项(<span class="note">按下开机键后松开，再按下对应的启动按键不松开直到进入启动选项，不同电脑启动选项不同，查下表</span>)</p><p><img src="/images/computer/computer_1/10.jpg" height="518" width="563"/></p><p>❀进入启动选项后会看到类似如下界面，并选择你的U盘，然后按下Enter就会进入杏雨梨云PE系统</p><p><img src="/images/computer/computer_1/11.jpg" alt=""/></p><p><span class="note-hot">成功进入PE系统界面</span></p><p><img src="/images/computer/computer_1/15.jpg" alt=""/></p><h4 class="body-title">步骤四:磁盘分区</h4><p>❀找到diskgenius这个快捷方式并打开</p><p><img src="/images/computer/computer_1/12.jpg" height="343" width="743"/></p><p>❀进入Diskgenius后，选择你要安装系统的磁盘，一般选择固态硬盘，然后再点击快速分区，这个盘符将会被清空</p><p><img src="/images/computer/computer_1/13.jpg" height="562" width="840"/></p><p>❀（1）然后如果是老机子就选择MBR，新机子就选择GUIP，（2）然后再选择分区，建议固态硬盘就分一个区，即将整个盘作为系统盘，就是大家所说的C盘，（3）然后如果你的硬盘是固态硬盘，对齐分区到此扇区的整数倍 就选择4096，即4k对齐，然后点击确定，最后退出diskgenius（注：MBR是传统的硬盘使用方式，只支持一个硬盘上最多4个主分区，而GUID就是新兴的GPT方式，支持的主分区数量没有限制。 如果主板较老只支持BIOS，就选MBR，如果是新主板，支持UEFI，就可以选GUID。）</p><p><img src="/images/computer/computer_1/14.jpg" height="472" width="700"/></p><h4 class="body-title">步骤五:一键重装系统</h4><p>❀双击桌面上的一键重装</p><p><img src="/images/computer/computer_1/16.jpg" alt=""/></p><p>❀点击选择，去U盘里，找到先前放在U盘中的Windows镜像文件(<span class="note">cn_windows_10_consumer_edition_version_1903_updated_june_2019_x64_dvd_cedfd58d.iso</span>),再选择版本，最好选择专业版，然后再在系统分区那里选择将要把系统安装到的分好区的硬盘分区(<span class="note">有点绕口</span>),最后点击确定</p><p><img src="/images/computer/computer_1/17.jpg" alt=""/></p><h4 class="body-title">步骤六:重启电脑</h4><p>❀提示安装成功后，关机，拔出U盘，重启电脑，将会看到如下界面</p><p><img src="/images/computer/computer_1/18.jpg" height="360" width="681"/></p><p><span class="note-hot">什么，你看不到上面界面,对不起，再见(<span class="note">你还可以一包辣条手把手教学</span>)</span></p><h4 class="body-title">步骤七:激活系统</h4><p>❀下载我提供的激活工具 <a class="btn btn-success" href="https://www.baidu.com" target="_blank">点我下载</a>，连接网络，解压下载的压缩包，双击里面可执行文件，提示成功，激活成功！</p><p><img src="/images/computer/computer_1/20.jpg" height="162" width="644"/></p><p><span class="note-hot">激活成功</span></p><p><img src="/images/computer/computer_1/19.jpg" height="688" width="757"/></p><h4 class="body-title">关于版权</h4><p>特别声明：本站所有源于网络的内容都会注明出处，
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;如果发现本站有任何侵犯您利益的内容，请及时邮件或QQ:2439739932留言联系 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<a href="http://wpa.qq.com/msgrd?v=3&uin=2439739932&site=qq&menu=yes" target="_blank" style="text-decoration: none"></a>，我会第一时间删除所有相关内容。
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;当然，作者是个喜欢分享的人，如果您转载或者分享本站的内容，请务必以超链接形式标明源文出处，非常感谢！</p><h4 class="body-title">联系方式</h4><p>❀QQ：110，电话：110。欢迎联系</p>', 0, N'0', N'cff0b55a-cce6-4ded-a696-f2b4ee45295b', NULL, NULL, NULL, NULL, 1, CAST(N'2019-11-30T12:47:07.0000000' AS DateTime2), NULL, NULL, 1, 0, 0, 0, 0)
INSERT [dbo].[Articles] ([Id], [Category], [Title], [description], [ImageUrl], [Content], [ViewCount], [Sort], [UserId], [Source], [SeoTitle], [SeoKeyword], [SeoDescription], [AddManagerId], [AddTime], [ModifyManagerId], [ModifyTime], [IsTop], [IsSlide], [IsRed], [IsPublish], [IsDeleted]) VALUES (5, N'关于我', N'关于我', N'站长的基本信息', N'https://localhost:5003/file/upload/images/20191202/201912021500115676289.jpg', N'<h4 class="body-title">关于自己</h4><p>❀一个喜欢IT的90后男生</p><p>❀一个爱折腾的人</p><p>❀对IT技术灰常的感兴趣</p><h4 class="body-title">关于博客</h4><p>❀域名：www.spystudy.cn</p><p>❀服务器：腾讯云服务器</p><p>❀备案号：蜀ICP备19017410号</p><p>❀程序语言：C#</p><h4 class="body-title">联系方式</h4><p>❀QQ：110，电话：110。常联系</p>', 0, N'0', N'cff0b55a-cce6-4ded-a696-f2b4ee45295b', NULL, NULL, NULL, NULL, 1, CAST(N'2019-12-02T14:59:03.0000000' AS DateTime2), NULL, NULL, 1, 0, 0, 0, 0)
INSERT [dbo].[Articles] ([Id], [Category], [Title], [description], [ImageUrl], [Content], [ViewCount], [Sort], [UserId], [Source], [SeoTitle], [SeoKeyword], [SeoDescription], [AddManagerId], [AddTime], [ModifyManagerId], [ModifyTime], [IsTop], [IsSlide], [IsRed], [IsPublish], [IsDeleted]) VALUES (6, N'留言板', N'留言板', N'说下你想说的内容', N'https://localhost:5003/file/upload/images/20191202/201912021522502151404.jpg', N'<h1 style="text-align: center; margin-top: 20px;margin-bottom: 40px;">留言板</h1><h4 class="body-title">关于留言</h4><p>❀合法内容，想说什么就说什么,不要害羞</p><p>❀输入QQ号自动获取QQ昵称和头像</p><h4 class="body-title">关于提问</h4><p>❀所有问题都可，但不一定回答(或许是太难)</p><h4 class="body-title">联系方式</h4><p>❀QQ：110，电话：110。欢迎联系</p>', 0, N'0', N'cff0b55a-cce6-4ded-a696-f2b4ee45295b', NULL, NULL, NULL, NULL, 1, CAST(N'2019-12-02T15:22:24.0000000' AS DateTime2), NULL, NULL, 1, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Articles] OFF
INSERT [dbo].[AspNetUsers] ([UserId], [Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [NickName], [RoleName], [Sex], [IsInUsing], [CreateTime], [EndTime], [UserDescription], [Province], [City], [Area], [RealName], [BirthDate], [UserFaceImgUrl]) VALUES (N'cff0b55a-cce6-4ded-a696-f2b4ee45295b', N'cf460efa-72d7-4b27-9a81-5d98e764ca5b', N'2439739932', N'2439739932', N'2439739932@qq.com', N'2439739932@QQ.COM', 0, N'AQAAAAEAACcQAAAAEF1D34UudwAJZnG5dsonlk0tUHH6XHOMM3J2s6RqWKqL76vgUoHZ69ulam76Eg7tSA==', N'OVMOFLKGRDTA2QPHDK7ZXDMWYRIXBIIC', N'e957456d-fff4-4f13-8e28-883a0c35455a', N'13458386910', 0, 0, NULL, 1, 0, N'用一生下载你', NULL, N'男', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'2019年12月14日 19:05:54', NULL, NULL, NULL, NULL, N'沈平元', N'2019年12月02日', NULL)
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([CommentId], [QQ], [HeadImageUrl], [Content], [NickName], [CommentDateTime], [CommentTime], [Supports], [ArticleId]) VALUES (1, N'2439739932', N'http://q1.qlogo.cn/g?b=qq&nk=2439739932&s=100', N'沈平元，我爱你', N'用一生下载你', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'2019/11/30 下午12:51:43', 0, 1)
INSERT [dbo].[Comments] ([CommentId], [QQ], [HeadImageUrl], [Content], [NickName], [CommentDateTime], [CommentTime], [Supports], [ArticleId]) VALUES (9, N'123456', N'http://q1.qlogo.cn/g?b=qq&nk=123456&s=100', N'腾讯无敌，我腾讯超六', N'腾旭无敌', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'2019/11/30 下午3:00:03', 0, 1)
INSERT [dbo].[Comments] ([CommentId], [QQ], [HeadImageUrl], [Content], [NickName], [CommentDateTime], [CommentTime], [Supports], [ArticleId]) VALUES (10, N'123456', N'http://q1.qlogo.cn/g?b=qq&nk=123456&s=100', N'42134512', N'2431', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'2019/11/30 下午3:31:02', 0, 1)
INSERT [dbo].[Comments] ([CommentId], [QQ], [HeadImageUrl], [Content], [NickName], [CommentDateTime], [CommentTime], [Supports], [ArticleId]) VALUES (11, N'24397', N'http://q1.qlogo.cn/g?b=qq&nk=24397&s=100', N'我华为不想说话', N'华为', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'2019/12/2 下午1:41:56', 0, 1)
INSERT [dbo].[Comments] ([CommentId], [QQ], [HeadImageUrl], [Content], [NickName], [CommentDateTime], [CommentTime], [Supports], [ArticleId]) VALUES (12, N'123456', N'http://q1.qlogo.cn/g?b=qq&nk=123456&s=100', N'既然这样，那我腾讯助你一臂之力', N'腾讯', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'2019/12/2 下午3:04:23', 0, 5)
INSERT [dbo].[Comments] ([CommentId], [QQ], [HeadImageUrl], [Content], [NickName], [CommentDateTime], [CommentTime], [Supports], [ArticleId]) VALUES (13, N'24397', N'http://q1.qlogo.cn/g?b=qq&nk=24397&s=100', N'怎么了，我华为就是六', N'华为', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'2019/12/2 下午3:30:00', 0, 6)
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[SiteInfo] ON 

INSERT [dbo].[SiteInfo] ([Id], [ColumnCount], [CommentCount], [ArticleCount], [TagCount], [Views], [CenterTitle], [Motto]) VALUES (1, 17, 6, 3, 26, 183, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SiteInfo] OFF
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (11, N'Java学习路线', N'http://bbs.itheima.com/thread-386464-1-1.html', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (12, N'.Net学习路线', N'https://cloud.tencent.com/developer/article/1475594', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (13, N'腾讯云', N'https://cloud.tencent.com/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (14, N'抠图去背景', N'https://www.remove.bg/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (15, N'I Tell You', N'https://msdn.itellyou.cn/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (16, N'论文期刊（cn-ki）', N'https://www.cn-ki.net/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (17, N'今日热榜', N'https://tophub.today/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (18, N'百宝箱', N'http://www.addog.vip/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (19, N'在线万能工具箱', N'https://www.toolnb.com/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (20, N'第一PPT', N'http://www.1ppt.com/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (21, N'沃客导航', N'https://www.9178.work/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (22, N'免费logo设计', N'http://www.60logo.com/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (23, N'我要自学网', N'https://www.51zxw.net/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (24, N'在线文件转换', N'http://www.alltoall.net/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (25, N'四川师范大学教务处主页', N'http://jwc.sicnu.edu.cn/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (26, N'阿里云', N'https://account.aliyun.com/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (27, N'最强打字', N'https://www.typingclub.com/', N'国外', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (28, N'MikuTools-工具集合', N'https://tools.miku.ac/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (29, N'最强资源搜索', N'https://www.lsdhss.com/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (30, N'阿里云图标库', N'https://www.iconfont.cn/', N'国内', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (31, N'YouTube', N'https://www.youtube.com/', N'国外', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (32, N'google商店', N'https://chrome.google.com/webstore/', N'国外', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (33, N'KuLi云', N'https://cllo.space/', N'国外', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (34, N'Gmail', N'https://mail.google.com/mail/', N'国外', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (35, N'Twitter', N'https://twitter.com/', N'国外', 1)
INSERT [dbo].[Tags] ([Id], [Name], [Src], [IsInChina], [IsOpen]) VALUES (36, N'Facebook(脸书)', N'https://www.facebook.com/', N'国外', 1)
SET IDENTITY_INSERT [dbo].[Tags] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Articles_UserId]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_Articles_UserId] ON [dbo].[Articles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2019/12/14 19:12:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_AspNetUsers_Id]    Script Date: 2019/12/14 19:12:50 ******/
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [AK_AspNetUsers_Id] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2019/12/14 19:12:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CommentReply_CommentId]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_CommentReply_CommentId] ON [dbo].[CommentReply]
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_ArticleId]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_ArticleId] ON [dbo].[Comments]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_relationShips_ParentID]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_relationShips_ParentID] ON [dbo].[relationShips]
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_DeskID]    Script Date: 2019/12/14 19:12:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students_DeskID] ON [dbo].[Students]
(
	[DeskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_SchoolID]    Script Date: 2019/12/14 19:12:50 ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_SchoolID] ON [dbo].[Teachers]
(
	[SchoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserId])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CommentReply]  WITH CHECK ADD  CONSTRAINT [FK_CommentReply_Comments_CommentId] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comments] ([CommentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CommentReply] CHECK CONSTRAINT [FK_CommentReply_Comments_CommentId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Articles_ArticleId]
GO
ALTER TABLE [dbo].[relationShips]  WITH CHECK ADD  CONSTRAINT [FK_relationShips_children_ChildID] FOREIGN KEY([ChildID])
REFERENCES [dbo].[children] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[relationShips] CHECK CONSTRAINT [FK_relationShips_children_ChildID]
GO
ALTER TABLE [dbo].[relationShips]  WITH CHECK ADD  CONSTRAINT [FK_relationShips_parents_ParentID] FOREIGN KEY([ParentID])
REFERENCES [dbo].[parents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[relationShips] CHECK CONSTRAINT [FK_relationShips_parents_ParentID]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Desks_DeskID] FOREIGN KEY([DeskID])
REFERENCES [dbo].[Desks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Desks_DeskID]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Schools_SchoolID] FOREIGN KEY([SchoolID])
REFERENCES [dbo].[Schools] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Schools_SchoolID]
GO
USE [master]
GO
ALTER DATABASE [db_SPYBlog] SET  READ_WRITE 
GO
