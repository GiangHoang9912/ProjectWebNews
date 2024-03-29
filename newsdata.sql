USE [master]
GO
/****** Object:  Database [ProjectNews]    Script Date: 3/23/2020 4:05:06 AM ******/
CREATE DATABASE [ProjectNews]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectNews', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectNews.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectNews_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectNews_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectNews] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectNews].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectNews] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectNews] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectNews] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectNews] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectNews] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectNews] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectNews] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectNews] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectNews] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectNews] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectNews] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectNews] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectNews] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectNews] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectNews] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectNews] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectNews] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectNews] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectNews] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectNews] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectNews] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectNews] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectNews] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectNews] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectNews] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectNews] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectNews] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectNews] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectNews] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectNews', N'ON'
GO
ALTER DATABASE [ProjectNews] SET QUERY_STORE = OFF
GO
USE [ProjectNews]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/23/2020 4:05:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[Passwords] [nvarchar](50) NOT NULL,
	[RuleID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikeNumber]    Script Date: 3/23/2020 4:05:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikeNumber](
	[NewsID] [int] IDENTITY(1,1) NOT NULL,
	[LikeNumber] [int] NOT NULL,
 CONSTRAINT [PK_LikeNumber] PRIMARY KEY CLUSTERED 
(
	[NewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 3/23/2020 4:05:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsID] [int] IDENTITY(1,1) NOT NULL,
	[NewsTitle] [nvarchar](max) NOT NULL,
	[TypeID] [int] NOT NULL,
	[NewsContent] [nvarchar](max) NOT NULL,
	[NewsImage] [nvarchar](150) NULL,
	[StartDate] [datetime] NOT NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsType]    Script Date: 3/23/2020 4:05:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_NewsType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rules]    Script Date: 3/23/2020 4:05:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rules](
	[RuleID] [int] NOT NULL,
	[RuleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[RuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/23/2020 4:05:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](150) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (1, N'aa', N'aa', 1, 1)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (2, N'phamtien', N'123', 2, 3)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (3, N'kim', N'123', 3, 2)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (4, N'aa', N'123456789', 3, 4)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (6, N'dad', N'asdf', 1, 4)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (7, N'Giang123456', N'123456789', 3, 6)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (8, N'Gianghoang123', N'123456789', 3, 7)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (9, N'Giang123', N'123456789', 3, 8)
INSERT [dbo].[Account] ([AccountID], [AccountName], [Passwords], [RuleID], [UserID]) VALUES (10, N'Gianghh', N'12091999', 3, 9)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[LikeNumber] ON 

INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (1, 100)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (2, 50)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (3, 100)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (4, 100)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (5, 200)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (6, 200)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (7, 200)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (8, 200)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (9, 100)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (10, 200)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (11, 200)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (12, 100)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (13, 200)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (14, 300)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (15, 100)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (16, 300)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (17, 310)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (18, 310)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (19, 31)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (20, 31)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (21, 31)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (22, 31)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (23, 312)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (24, 312)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (25, 123)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (26, 12)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (27, 3)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (28, 123)
INSERT [dbo].[LikeNumber] ([NewsID], [LikeNumber]) VALUES (29, 23)
SET IDENTITY_INSERT [dbo].[LikeNumber] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (1, N'Số ca nhiễm COVID-19 ở Hàn Quốc tăng lên 7.382, đã có 51 người chết', 1, N'Cơ quan Quản lý và Phòng chống Dịch bệnh Hàn Quốc (KCDC) sáng 9/3 cho biết tổng số ca nhiễm chủng mới của virus corona (SARS-CoV-2) gây bệnh viêm đường hô hấp cấp COVID-19 tại nước này tăng thêm 69 ca lên 7.382 ca. Số ca nhiễm đã giảm so với những ngày trước.

Tổng số ca tử vong do dịch bệnh viêm đường hô hấp cấp COVID-19 tại Hàn Quốc là 51 người. Cũng theo KCDC, đã có thêm 36 người phục hồi hoàn toàn và được ra viện, nâng tổng số người ra viện lên 166 người.

Phần lớn số ca nhiễm SARS-CoV-2 là ở các thành phố Daegu, Cheongdo và Gyeongsan. Thủ đô Seoul và tỉnh Gyeonggi bao quanh đều có hơn 120 ca nhiễm.

[Hàn Quốc tiếp tục ghi nhận thêm gần 200 ca nhiễm COVID-19]

Theo số liệu của Bộ Ngoại giao Hàn Quốc, tổng cộng đã có 103 quốc gia và vùng lãnh thổ áp đặt các lệnh cấm nhập cảnh hoặc thủ tục cách ly đối với các du khách từ Hàn Quốc.

Còn theo Tổng Giám đốc KCDC Jeong Eun-kyeong, có thể còn quá sớm để kết luận sự lây lan dịch COVID 19 ở Hàn Quốc đang giảm dần.

Bà Jeong lưu ý sự sụt giảm số ca ghi nhận mắc COVID-19 trong ngày qua là do số lượng các trường hợp liên quan đến giáo phái Tân Thiên Địa ở thành phố Daegu giảm.

Bà cho hay: "Số lượng bệnh nhân mới đang giảm dần do việc xét nghiệm các tín đồ của giáo phái này sắp kết thúc."

Tuy nhiên, bà cho rằng sự gia tăng số lượng bệnh nhân COVID 19 ở Hàn Quốc có thể lại nhanh chóng tăng lên nếu có một ổ dịch mới, điều mà bà cho rằng vẫn còn rất nhiều khả năng xảy ra.

Hiện, tất cả các bộ ngành ở Hàn Quốc đã bố trí ca trực làm việc 24/24 để kịp thời xử lý những vấn đề nảy sinh trong cuộc chiến chống dịch COVID 19./.', N'News1.jpg', CAST(N'2020-09-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (2, N'Thêm 14 người mắc Covid-19, cả nước có 113 bệnh nhân', 1, N'Tối 22/3, Bộ Y tế đã 2 lần công bố ca bệnh mới, nâng tổng số người mắc Covid-19 ở Việt Nam lên 113 trường hợp. Đáng chú ý, 6 người mắc mới là bệnh nhân tại Hà Nội, 1 người ở TP.HCM, 1 người ở Nam Định và 6 người là khách trên các chuyến bay từ Anh, Malaysia về Cần Thơ. 5 trong số 6 bệnh nhân ở Hà Nội và 1 bệnh nhân ở Nam Định là du học sinh trở về từ Anh, Mỹ, Pháp.

Nhiều bệnh nhân có kết quả xét nghiệm lần đầu âm tính, sau đó trong thời gian cách ly có xuất hiện triệu chứng bệnh và được xác định dương tính với SARS-CoV-2.

Đa số bệnh nhân có tình trạng sức khỏe ổn định, đang được cách ly điều trị tại các bệnh viện ở Việt Nam.', N'News2.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (3, N'Ký túc xá đẹp nhất Hà Nội thành khu cách ly tập trung', 1, N'Ký túc xá Đại học FPT với quy mô 4 tòa nhà 5 tầng được sử dụng làm khu cách ly tập trung cho khoảng 2.000 người từ ngày 23/3.
UBND Hà Nội vừa ban hành quyết định thành lập khu cách ly tập trung tại Ký túc xá Đại học FPT.

Khu cách ly tập trung này nằm trong Khu công nghệ cao Hòa Lạc, huyện Thạch Thất, đảm bảo về cơ sở vật chất cho công tác cách ly đối với người từ vùng có dịch về hoặc người có yếu tố dịch tễ cần phải cách ly.Khu cách ly sử dụng 4 tòa cao 5 tầng với quy mô 2.000 chỗ. Thành phố bố trí 40 cán bộ an ninh, 30 cán bộ điều hành, phục vụ; một đội y tế dự phòng, 2 đội đảm bảo y tế tại khu cách ly, tiếp nhận cách ly từ ngày 23/3 đến khi dịch kết thúc. Ký túc xá Đại học FPT được đánh là một trong những ký túc xá đẹp nhất Hà Nội.

UBND Hà Nội giao Bộ Tư lệnh Thủ đô thành lập tổ chức quản lý, vận hành và phục vụ khu cách ly tập trung; Đại học FPT hướng dẫn tuyên truyền cho nhân viên, sinh viên biết và thực hiện nghiêm túc quy định của khu cách ly.

Ban quản lý Khu công nghệ cao Hòa Lạc có trách nhiệm chỉ đạo các đơn vị trực thuộc đảm bảo chức năng để thu gom và tiêu hủy rác thải tại khu cách ly, đảm bảo đúng quy định, tránh lây nhiễm chéo.

Trước đó, thành phố đã bố trí thêm 3 khu cách ly tập trung với quy mô 10.100 chỗ tại khu nhà ở cho học sinh, sinh viên Pháp Vân - Tứ Hiệp (quận Hoàng Mai); khu nhà ở sinh viên Mỹ Đình II (quận Nam Từ Liêm); Trường Cao đẳng nghề Công nghệ cao Hà Nội (quận Nam Từ Liêm) và Trường Trung cấp nghề số 18 (huyện Thanh Trì).

Dự kiến, trong 2 tuần tới, Hà Nội đón khoảng 20.000 công dân nhập cảnh vào Hà Nội thông qua cửa khẩu sân bay Nội Bài. Chủ tịch Hà Nội cho biết thành phố đã gấp rút chuẩn bị các cơ sở, vật chất phục vụ công tác phân luồng, sàng lọc xét nghiệm sớm để cách ly tập trung người về từ nước ngoài.

Thành phố cũng đang xem xét mua thêm 200.000 bộ kit xét nghiệm nhanh Covid-19 để xét nghiệm cho người cách ly.

Tính đến 10h ngày 22/3, Việt Nam ghi nhận 94 trường hợp dương tính với Covid-19, trong đó có 17 trường hợp đã hồi phục và xuất viện. Hà Nội hiện là địa phương có nhiều nhất ca mắc Covid-19 với 28 trường hợp và cũng là địa phương đầu tiên có 2 nhân viên y tế bị nhiễm.', N'News3.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (4, N'Văn Toàn và fan ủng hộ 150 triệu đồng chống dịch', 2, N'Tiền đạo của HAGL có mặt ở Ủy ban Trung ương Mặt trận Tổ quốc Việt Nam để trực tiếp cùng cổ động viên trao số tiền nhằm ủng hộ chiến dịch chống dịch Covid-19.
Sáng 22/3, Văn Toàn mặc áo sơ-mi trắng đến văn phòng của Trung ương Mặt trận Tổ quốc Việt Nam tại Hà Nội để làm một hoạt động thiết thực chống dịch Covid-19. Anh và người hâm mộ ủng hộ hơn 150 triệu đồng.

Đây là số tiền mà tuyển thủ Việt Nam đã huy động được trong vòng 4 ngày. Trước khi đến trao số tiền 130 triệu đồng, tài khoản của Văn Toàn nhận thêm nhiều tấm lòng khác ngay trong buổi sáng, nên tổng cộng là hơn 150 triệu đồng.Văn Toàn chia sẻ khi được Phó chủ tịch Ủy ban Trung ương Mặt trận Tổ quốc Việt Nam, ông Phùng Khánh Tài, tiếp đón: "Cầu thủ sau bao ngày thi đấu trở về, nhận được sự quan tâm, lòng nhiệt huyết của người hâm mộ dành cho mình, tôi thấy hai tiếng Tổ quốc, hai tiếng đồng bào thật thiêng liêng và ấm áp, chính từ đây tinh thần dân tộc luôn thôi thúc mỗi cầu thủ".

Ông Phùng Khánh Tài tiếp nhận và nhấn mạnh: "Sức mạnh đại đoàn kết và tinh thần tương thân tương ái của người Việt Nam đang được phát huy mạnh mẽ trong thời điểm này, mỗi người một tấm lòng, mỗi người một sự chung tay trong đấu tranh đẩy lùi dịch bệnh".

Văn Toàn là cầu thủ đầu tiên mở cuộc huy động trên trang cá nhân của mình. Anh nhận được rất nhiều sự ủng hộ của fan, cổ động viên trung thành của mình. 4 ngày là thời gian không dài để Văn Toàn nhận được số tiền trên.

Rất nhiều cầu thủ khác, bằng hình thức khác nhau cũng đã ủng hộ, đóng góp, chung tay vào chiến dịch chống dịch bệnh Covid-19. Một số người chọn cách nhắn tin ủng hộ, một số khác chuyển khoản tiền mặt vào tài khoản của các tổ chức chính phủ.', N'News4.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (5, N'Nhan sắc dàn mỹ nhân từng hẹn hò với Ronaldo', 2, N'Trước khi ổn định với hôn thê Georgina Rodriguez, Cristiano Ronaldo cặp kè với nhiều người mẫu và hoa hậu.Merche Romero hẹn hò Ronaldo từ tháng 1/2005 đến tháng 9/2006. Cả hai thường xuyên bị báo giới xứ sở sương mù bắt gặp đi với nhau trong các kỳ nghỉ. Romero hơn Ronaldo 9 tuổi và là người dẫn chương trình tại Tây Ban Nha.Hoa hậu Xứ Wales, Imogen Thomas, từng qua lại với CR7 vào năm 2006 khi ngôi sao người Bồ Đào Nha vẫn khoác áo MU. Song sau này cả hai vẫn dính vào tin đồn tình ái nhiều lần khi CR7 chuyển sang khoác áo Real Madrid.Gemma Atkinson là một trong những cô bồ nổi tiếng nhất của Ronaldo. Chân dài người Anh là nữ diễn viên nổi tiếng, người dẫn chương trình và cả siêu mẫu nội y. Ronaldo từng dẫn Atkinson về ra mắt mẹ với ý định "đưa nàng về dinh", song mối tình giữa cặp đôi trai tài gái sắc này chỉ kéo dài 4 tháng ở giai đoạn giữa năm 2007.Maria Sharapova cũng từng dính vào tin đồn cặp kè với Ronaldo vào năm 2007. Dẫu vậy, cả hai cũng chỉ được cho là qua lại trong vài tuần.Sau nhiều tin đồn tình ái, Ronaldo cũng dừng chân với siêu mẫu Nerreira Gallardo vào đầu năm 2008. Dẫu vậy, mối tình này cũng không kéo dài lâu khi cả hai đều có lối sống phóng túng.', N'News5.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (6, N'De Gea vào danh sách những thủ môn cứu thua nhiều nhất mùa này', 2, N'David de Gea cùng các đồng đội hướng tới mục tiêu giúp MU giành suất dự Champions League mùa tới. 3 điểm là khoảng cách giữa “Quỷ đỏ” và đội xếp ngay phía trên Chelsea.Kasper Schmeichel (Leicester City): Anh không vắng mặt bất cứ trận nào trong 29 vòng đấu cho đến khi Premier League tạm hoãn. Màn trình diễn xuất sắc của thủ thành người Đan Mạch góp phần giúp Leicester City có mặt trong top 3 đội đầu bảng và sẵn sàng cạnh tranh suất dự Champions League mùa tới.Marc-andre Ter Stegen (Barcelona): Thủ môn người Đức là sự lựa chọn số một trong khung thành Barca. Anh cùng đội chủ sân Nou Camp đang dẫn đầu bảng xếp hạng La Liga khi hơn đội bám đuổi Real Madrid 2 điểm (58 so với 56).David de Gea (Man United): Anh không còn giữ phong độ cao nhất, nhưng vẫn có những pha cứu thua xuất sắc trong màu áo MU. Ở 10 trận gần nhất, “Quỷ đỏ” đang có thành tích bất bại, qua đó nâng số điểm lên 45 và chỉ còn cách top 4 Premier League đúng một trận thắng.Wojciech Szczesny (Juventus): Trước khi Serie A tạm hoãn, Juventus đang dẫn đầu bảng xếp hạng khi hơn đội bám đuổi Lazio đúng 1 điểm (63 so với 62). Hiện Szczesny là một trong những thủ môn để thủng lưới ít nhất mùa này khi Juventus nhận 24 bàn thua.Bernd Leno (Arsenal): Anh chưa vắng mặt bất cứ trận nào sau 28 vòng đã đấu của Arsenal ở Premier League mùa này. Tuy nhiên, thủ thành người Đức không thể giúp đội chủ sân Emirates có vị trí tốt trong cuộc đua giành suất dự Champions League mùa tới khi kém top 4 tới 7 điểm dù thi đấu ít hơn một trận.', N'News6.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (7, N'Đế chế đồ hiệu Pháp đặt mua 40 triệu khẩu trang từ Trung Quốc', 3, N'Trước đó, LVMH cũng tận dụng các nhà máy mỹ phẩm và nước hoa của hãng để sản xuất nước rửa tay khử trùng miễn phí cho các bệnh viện tại Pháp.
Theo Reuters, LVMH - tập đoàn hàng xa xỉ lớn nhất thế giới - vừa đặt mua 40 triệu USD khẩu trang y tế từ một nhà cung cấp Trung Quốc để giúp nước Pháp đương đầu với dịch Covid-19.

LVMH cho biết 10 triệu khẩu trang đầu tiên của đơn hàng này sẽ được chuyển tới Pháp trong vài ngày tới và được trao cho cơ quan y tế Pháp. Chúng sẽ được phát cho người dân nước này vào đầu tuần tới.

Phần còn lại sẽ được chuyển tới trong những tuần tiếp theo. Đây là đơn hàng hợp tác giữa LVMH và chính phủ Pháp, trong đó một phần sẽ được chính phủ chi trả.

LVMH - công ty mẹ của các thương hiệu như Louis Vuitton, Christian Dior và thuộc sở hữu của tỷ phú Bernard Arnault - cũng tận dụng các nhà máy nước hoa và mỹ phẩm của hãng để sản xuất nước rửa tay khử trùng và cung cấp miễn phí cho các bệnh viện tại Pháp."Để đặt hàng khẩu trang trong thời điểm cực kỳ khó khăn này và đảm bảo việc sản xuất chúng bắt đầu ngày hôm nay, CEO Bernard Arnault đã thu xếp để LVMH chi trả toàn bộ đơn hàng trong tuần đầu tiên với tổng chi phí 5 triệu euro (5,4 triệu USD)”, LVMH cho biết.

Các quốc gia trên khắp thế giới đang vật lộn với cuộc khủng hoảng y tế cộng đồng lớn nhất kể từ đại dịch cúm năm 1918, với nguồn cung thiết bị y tế và dụng cụ bảo hộ thiếu trầm trọng. Pháp đã ban hành lệnh phong toả chưa từng có hôm 17/3.

Ngoài LVMH, một số công ty khác cũng cho biết sẵn sàng quyên góp vật tư y tế cho hệ thống bệnh viện. Trước tình hình dịch bệnh ngày càng diễn biến phức tạp, người dân Pháp đổ xô đi mua nước rửa tay.

Các nhà sản xuất khắp nước Pháp cũng đang tăng cường tuyển dụng công nhân, đẩy nhanh tiến độ sản xuất nhằm đáp ứng nhu cầu nước rửa tay tăng cao của thị trường.', N'News7.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (8, N'Ái nữ chủ tịch PNJ chi trăm tỷ mua cổ phiếu khi giá xuống sâu', 3, N'Con gái Chủ tịch HĐQT PNJ Cao Thị Ngọc Dung muốn mua 2 triệu cổ phiếu của doanh nghiệp vàng bạc đá quý này khi thị giá về mức đáy hơn hai năm qua.
Bà Trần Phương Ngọc Thảo vừa đăng ký mua 2 triệu cổ phiếu của Công ty Cổ phần Vàng bạc Đá quý Phú Nhuận (PNJ) từ 25/3 đến 24/4 theo phương thức khớp lệnh hoặc thỏa thuận nhằm phục vụ nhu cầu cá nhân.

Trước khi thực hiện giao dịch, bà Thảo đang giữ 4,7 triệu cổ phiếu PNJ, tương đương tỷ lệ sở hữu 2,1%. Nếu thực hiện giao dịch mua thành công như đăng ký, bà Thảo sẽ nắm 3% vốn PNJ, tương đương 6,7 triệu cổ phần.

Bà Thảo là con gái của Chủ tịch HĐQT PNJ Cao Thị Ngọc Dung và cựu Tổng giám đốc Ngân hàng Đông Á Trần Phương Bình. Một ái nữ khác của gia đình chủ tịch PNJ là bà Trần Phương Ngọc Giao hiện giữ 3,2% vốn tại doanh nghiệp vàng bạc đá quý này.

Bà Dung cũng là cổ đông lớn nhất của PNJ với tỷ lệ sở hữu 9%. Như vậy, gia đình bà chủ PNJ đang sở hữu tổng cộng 14,2% cổ phần doanh nghiệp này. Sau giao dịch của bà Thảo, tỷ lệ sở hữu của bà Dung cùng hai con gái tại PNJ có thể vượt 15%.

Từng chạm mốc 92.000 đồng/cổ phiếu trước Tết âm lịch, nhưng giá cổ phiếu PNJ bắt đầu đi xuống trước khi lao dốc mạnh trong 2 tuần vừa qua theo đà ảm đạm chung của thị trường chứng khoán.

Chỉ sau 10 phiên giao dịch, cổ phiếu PNJ đã mất 80% giá trị, chỉ tăng 2 phiên và giảm giá 8 phiên, bao gồm 4 phiên giảm kịch biên độ.Kết thúc phiên giao dịch ngày 20/3, cổ phiếu PNJ hiện được giao dịch ở vùng giá 55.000 đồng. Với mức già này, số tiền con gái chủ tịch PNJ dự kiến chi ra để gom 2 triệu cổ phần công ty có thể lên tới 110 tỷ đồng.

Mới đây, PNJ cũng thông qua việc tạm ứng cổ tứng 2019 đợt 2 bằng tiền mặt với tỷ lệ 10%, tương đương mỗi cổ phiếu nhận 1.000 đồng. Số tiền PNJ chi ra để trả cổ tức lần này hơn 225 tỷ đồng. Trong đó, bà Dung cùng hai con gái sẽ nhận về tổng cộng hơn 30 tỷ đồng tiền mặt.

Theo kế hoạch kinh doanh năm 2020, PNJ đặt chỉ tiêu doanh thu thuần 19.020 tỷ đồng và lợi nhuận sau thuế 1.350 tỷ đồng. So với kết quả 2019, doanh thu và lợi nhuận mục tiêu tăng 12% và 13%.', N'News8.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (9, N'Người mua giảm, bất động sản không có dấu hiệu hạ giá', 3, N'Giá bất động sản tại TP.HCM vẫn ghi nhận tăng nhẹ trong khi nhu cầu mua giảm sút rõ rệt.
Theo dữ liệu nghiên cứu của Batdongsan.com, trong khi nhu cầu mua bất động sản 2 tháng đầu năm có dấu hiệu giảm sút, giá bất động sản vẫn có xu hướng tăng.

Theo đó, tại TP.HCM, chung cư là phân khúc được tìm kiếm nhiều nhất trên thị trường. Mặc dù vậy, mức quan tâm dành cho sản phẩm này đã giảm 4,6%, riêng nhà phố giảm đến 35% so với cùng kỳ, đặc biệt phân khúc đất nền có mức độ quan tâm giảm gần 50%.

Đáng chú ý, dù xu hướng tìm kiếm bất động sản đang giảm khá mạnh, giá bán nhà đất tại TP.HCM vẫn tăng cao. Riêng trong tháng 2, giá căn hộ tại TP.HCM tăng 10,9% so với cùng kỳ 2019, giá trung bình hơn 44 triệu đồng/m2. Đất nền, nhà phố dù gặp khó trong việc ra hàng nhưng giá vẫn neo ở mức cao, không có dấu hiệu giảm.Lý giải về nghịch lý của thị trường, ông Đinh Minh Tuấn, Giám đốc Batdongsan.com.vn tại TP.HCM cho biết, sự sụt giảm giao dịch đến từ nhu cầu mua bất động sản giảm mạnh, các nhà đầu tư ưu tiên giữ tiền để phòng tránh rủi ro. Không chỉ với nhà đất, các kênh đầu tư khác như chứng khoán, ngoại tệ, vàng cũng có dấu hiệu chuyển về trạng thái phòng ngự.

Ở một khía cạnh khác, nhu cầu tìm mua nhà ở thực tại TP.HCM vẫn đang cao hơn rất nhiều so với lượng sản phẩm chào bán hiện có trên thị trường. Điều này giúp nhiều chủ đầu tư tự tin khi đưa ra mức giá bán cao. Bên cạnh đó, với những nhà đầu tư thứ cấp đang sở hữu căn hộ, nếu không chịu áp lực từ đòn bẩy tài chính, phần lớn vẫn tin tưởng về thanh khoản thị trường sau khi dịch bệnh được kiểm soát nên không muốn giảm giá.

Tập đoàn tư vấn bất động sản JLL cũng mới đưa ra nhận định tác động của cú sốc Covid-19 đối với từng phân khúc bất động sản.

Đối với thị trường vốn, đơn vị này dự báo hoạt động đầu tư có thể chậm lại trong nửa đầu năm 2020 do các nhà đầu tư do dự trước tình hình bất ổn của nền kinh tế.

Trong khi các lĩnh vực như bán lẻ và khách sạn bị ảnh hưởng nặng nề, các nhà đầu tư nghiêng về những tài sản trú ẩn an toàn, cân nhắc về rủi ro cũng như ổn định thu nhập và khả năng vận hành. Chính vì vậy, trước những biến động kinh tế lớn như hiện nay, các nhà đầu tư có xu hướng phân bổ vốn vào bất động sản nhiều hơn theo thời gian do biên lợi nhuận hấp dẫn hơn so với các loại tài sản khác.

Cụ thể, ở phân khúc nhà ở, mặc dù mật độ dân số cao và không gian chung lớn có khả năng làm tăng nguy cơ lây nhiễm dịch bệnh, bất động sản nhà ở vẫn được xem là kênh đầu tư tốt, thu lợi nhuận từ tiền thuê ổn định và có khả năng điều chỉnh linh hoạt giá thuê để đảm bảo tỷ lệ lấp đầy.

Bên cạnh đó, nhu cầu nhà ở vốn là nhu cầu ổn định, ít bị ảnh hưởng bởi các tác động từ thị trường.

Tuy nhiên, đối với nhóm nhà phố cho thuê, thị trường ghi nhận một bộ phận lớn chủ mặt bằng đã điều chỉnh giá thuê do hoạt động kinh doanh của khách thuê bị ảnh hưởng nặng nề từ dịch Covid-19. Khảo sát gần đây của Savills Việt Nam cho thấy nhiều chủ nhà đã chấp nhận miễn phí ít nhất 1 tháng tiền nhà hoặc giảm 30-50% giá thuê hàng tháng cho khách kinh doanh ngành ăn uống, cửa hàng tiện lợi.

', N'News9.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (10, N'Mẫu ảnh, rich kid nổi tiếng MXH được cách ly khi trở về từ Mỹ, Anh', 1, N'Jessie Hiền Khanh, Tuệ Anh, Hải Tú là mẫu ảnh, rich kid khá nổi tiếng trên mạng xã hội. Hiện tại, họ đều thuộc diện cách ly tập trung sau khi về nước.Đinh Hiền Khanh (sinh năm 1995) là cô gái khá nổi tiếng trong cộng đồng "con nhà giàu Việt Nam". 9X tốt nghiệp chuyên ngành Quản trị kinh doanh của trường đại học George Washington (Mỹ). Hiện tại, cô học cao học và thử sức ở lĩnh vực vẽ màu và woodworking. Mùa dịch lần này, Hiền Khanh cũng về nước như số đông du học sinh khác. Hiện tại, cô được cách ly tại Pháp Vân (Hà Nội).Trên trang cá nhân, 9X chia sẻ bức ảnh chụp tại phòng cách ly. Theo lời Hiền Khanh, cô vẫn rất khỏe.Nguyễn Tuệ Anh (sinh năm 2001) - mẫu ảnh từng xuất hiện trên Vogue Online - là du học sinh trở về từ Anh, hiện thuộc diện cách ly tập trung tại Hà Nội. Trên story cá nhân, Tuệ Anh cập nhật tình hình của bản thân. Cô bày tỏ sự lo lắng khi chưa biết khi nào có thể trở lại Anh để học tập. 10X bày tỏ nỗi nhớ gia đình, bạn bè bởi dù về nước nhưng cô chưa được gặp người thân.Tuy nhiên, Tuệ Anh nhanh chóng thích nghi với cuộc sống mới ở khu cách ly. Giống như nhiều du học sinh khác, 10X cảm thấy may mắn khi có thể về nước vào thời điểm châu Âu bùng phát dịch bệnh.Hải Tú (sinh năm 1997) là mẫu ảnh khá nổi tiếng ở Sài Gòn. Cô được biết đến là gương mặt look book cá tính, sở hữu vóc dáng mảnh mai. Hiện tại, 9X là du học sinh tại Đức. Về Việt Nam lần này, Hải Tú cũng được cách ly giống nhiều du học sinh khác. Trên trang cá nhân, cô chia sẻ 10 điều nhận ra sau một tuần ở nơi tập trung.Theo lời Hải Tú, từ khi cách ly, cô ăn uống điều độ, tập thể dục chăm chỉ, da đẹp hơn, quen thêm nhiều bạn, biết trân trọng sức khỏe bản thân... Trên trang cá nhân, 9X liên tục cập nhật cuộc sống ở khu vực cách ly tập trung và bày tỏ sự lạc quan, tích cực.', N'News10.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (11, N'Trọng Hùng - hot boy của đội tuyển Việt Nam', 2, N'Không chỉ đá bóng hay, tiền vệ Nguyễn Trọng Hùng còn gây ấn tượng bởi vẻ ngoài điển trai cùng nhiều khả năng như ca hát, vẽ tranh hay cắt tóc.Nguyễn Trọng Hùng (biệt danh: Tý Anh) sinh ngày 3/10/1997 tại thành phố Thanh Hóa, tỉnh Thanh Hóa. Cầu thủ này đến với bóng đá năm 12 tuổi và từng ăn tập tại lò PVF cùng nhiều tuyển thủ U23 Việt Nam như Hà Đức Chinh, Bùi Tiến Dụng, Phan Văn Biểu hay Trương Văn Thái Quý. Năm 14 tuổi, Trọng Hùng trở về tập luyện cùng đội trẻ Thanh Hóa. Mùa giải 2019, "Tý Anh" được đôn lên đội một và có mùa giải V.League đầu tiên. .Trọng Hùng là con thứ 2 trong gia đình có 3 anh chị em. Ngoài chị cả, Trọng Hùng còn có em trai là Nguyễn Trọng Phú (trái). Trọng Phú (biệt danh: Tý Em) từng tập luyện tại học viện PVF và cũng đang khoác áo CLB Thanh Hóa giống anh trai. Ảnh: Thế Anh.Mới có mùa giải đầu tiên tại V.League, nhưng Trọng Hùng tạo dấu ấn với người hâm mộ. Ngoài 3 bàn thắng cùng những màn trình diễn ấn tượng, "Tý Anh" còn được chú ý bởi ngoại hình sáng, nụ cười duyên cùng chiếc răng khểnh. Anh là một trong những cầu thủ "gây thương nhớ" trong lòng CĐV nữ ở mùa giải qua.Không chỉ sở hữu đôi chân mềm mại, uyển chuyển, Trọng Hùng còn là người rất khéo tay. Chia sẻ với Zing.vn, cầu thủ này cho biết từng đạt giải ở các cuộc thi vẽ và viết chữ đẹp cấp tỉnh hồi còn ở tiểu học.Lớn lên, một trong những sở thích lớn nhất của Trọng Hùng ngoài bóng đá là cắt tóc. "Tý Anh" cho biết thường tự xem những clip dạy cắt tóc trên mạng, sau đó áp dụng thực hành với chính đồng đội.', N'News11.jpg', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[News] ([NewsID], [NewsTitle], [TypeID], [NewsContent], [NewsImage], [StartDate], [AccountID]) VALUES (13, N'sasa', 2, N'dasdasd', N'dasasd', CAST(N'2020-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[NewsType] ON 

INSERT [dbo].[NewsType] ([TypeID], [TypeName]) VALUES (1, N'Xã Hội')
INSERT [dbo].[NewsType] ([TypeID], [TypeName]) VALUES (2, N'Thể Thao')
INSERT [dbo].[NewsType] ([TypeID], [TypeName]) VALUES (3, N'Kinh Tế')
SET IDENTITY_INSERT [dbo].[NewsType] OFF
INSERT [dbo].[Rules] ([RuleID], [RuleName]) VALUES (1, N'Admin')
INSERT [dbo].[Rules] ([RuleID], [RuleName]) VALUES (2, N'Users')
INSERT [dbo].[Rules] ([RuleID], [RuleName]) VALUES (3, N'Journalist')
INSERT [dbo].[Rules] ([RuleID], [RuleName]) VALUES (4, N'Guess')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (1, N'Nguyễn Hoàng Giang', CAST(N'1999-09-12T00:00:00.000' AS DateTime), N'GiangHoang.9955@gmail.com', N'0819169868')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (2, N'Kim Ngoc Anh', CAST(N'1999-07-27T00:00:00.000' AS DateTime), N'KimNgocAnh@gmail.com', N'0928936192')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (3, N'Nguyễn Phạm Tiến', CAST(N'1999-10-08T00:00:00.000' AS DateTime), N'NguyenPhamTien@gmail.com', N'0182639871')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (4, N'giang hoang', CAST(N'2002-03-10T00:00:00.000' AS DateTime), N'gianghoang@gmial.com', N'0938479388')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (6, N'trong lap', CAST(N'2002-03-10T00:00:00.000' AS DateTime), N'tronglap@gmail.com', N'09128738791')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (7, N'gianghoangnguyen', CAST(N'2002-03-10T00:00:00.000' AS DateTime), N'giangohajksj@gmail.com', N'01982739881')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (8, N'Giang Hoang', CAST(N'2002-03-10T00:00:00.000' AS DateTime), N'GiangHoang@gmail.com', N'0912')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (9, N'Giang Hoang', CAST(N'2002-03-17T00:00:00.000' AS DateTime), N'GiangHoang.9955@gmail.com', N'0819169868')
INSERT [dbo].[Users] ([UserID], [UserName], [DOB], [Email], [Phone]) VALUES (10, N'GiangHoang', CAST(N'2002-03-17T00:00:00.000' AS DateTime), N'guadhfkjaskd@gmail.com', N'0819169868')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Rule] FOREIGN KEY([RuleID])
REFERENCES [dbo].[Rules] ([RuleID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Rule]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Users_UsersID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Users_UsersID]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Account]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_LikeNumber] FOREIGN KEY([NewsID])
REFERENCES [dbo].[LikeNumber] ([NewsID])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_LikeNumber]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_NewsType] FOREIGN KEY([TypeID])
REFERENCES [dbo].[NewsType] ([TypeID])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_NewsType]
GO
USE [master]
GO
ALTER DATABASE [ProjectNews] SET  READ_WRITE 
GO
