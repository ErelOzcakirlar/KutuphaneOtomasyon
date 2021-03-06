USE [KutuphaneOtomasyon]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](20) NOT NULL,
	[Aciklama] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kiralama]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kiralama](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KitapID] [int] NOT NULL,
	[UyeID] [int] NOT NULL,
	[TeslimDurumu] [bit] NOT NULL,
 CONSTRAINT [PK_Kiralama] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KiralamaDetay]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KiralamaDetay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KiralamaTarihi] [date] NOT NULL,
	[VarsayilanTeslim] [date] NOT NULL,
	[TeslimTarihi] [date] NULL,
	[Deformasyon] [bit] NULL,
	[KiraOdemesi] [int] NULL,
	[GecikmeOdemesi] [int] NULL,
	[HasarOdemesi] [int] NULL,
 CONSTRAINT [PK_KiralamaDetay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kitap]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[BasimYili] [nchar](4) NOT NULL,
	[YayineviID] [int] NOT NULL,
	[KategoriID] [int] NOT NULL,
	[SayfaSayisi] [int] NOT NULL,
	[HasarDurumu] [bit] NOT NULL,
	[KiralamaDurumu] [bit] NOT NULL,
	[Ucret] [decimal](18, 2) NOT NULL,
	[Ozet] [nvarchar](max) NULL,
	[Kapak] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kitap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KitapYazar]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitapYazar](
	[KitapID] [int] NOT NULL,
	[YazarID] [int] NOT NULL,
 CONSTRAINT [PK_KitapYazar] PRIMARY KEY CLUSTERED 
(
	[KitapID] ASC,
	[YazarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Odeme]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odeme](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tarih] [date] NOT NULL,
	[UyeID] [int] NOT NULL,
	[Aciklama] [nvarchar](15) NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[OdemeTipi] [int] NOT NULL,
 CONSTRAINT [PK_Odeme] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OdemeTipi]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeTipi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_OdemeTipi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uye]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uye](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Soyadi] [nvarchar](50) NOT NULL,
	[TCKimlikNo] [nchar](11) NOT NULL,
	[Adresi] [nvarchar](max) NULL,
	[Telefon] [nvarchar](20) NULL,
	[UyelikTarihi] [date] NOT NULL,
 CONSTRAINT [PK_Uye] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Yayinevi]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yayinevi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Adresi] [nvarchar](max) NULL,
	[KurulusYili] [nchar](4) NULL,
 CONSTRAINT [PK_Yayinevi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Yazar]    Script Date: 3.5.2014 14:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yazar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Soyadi] [nvarchar](50) NOT NULL,
	[Ozgecmis] [nvarchar](max) NULL,
 CONSTRAINT [PK_Yazar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Kiralama]  WITH CHECK ADD  CONSTRAINT [FK_Kiralama_Kitap] FOREIGN KEY([KitapID])
REFERENCES [dbo].[Kitap] ([ID])
GO
ALTER TABLE [dbo].[Kiralama] CHECK CONSTRAINT [FK_Kiralama_Kitap]
GO
ALTER TABLE [dbo].[Kiralama]  WITH CHECK ADD  CONSTRAINT [FK_Kiralama_Uye] FOREIGN KEY([UyeID])
REFERENCES [dbo].[Uye] ([ID])
GO
ALTER TABLE [dbo].[Kiralama] CHECK CONSTRAINT [FK_Kiralama_Uye]
GO
ALTER TABLE [dbo].[KiralamaDetay]  WITH CHECK ADD  CONSTRAINT [FK_KiralamaDetay_Kiralama] FOREIGN KEY([ID])
REFERENCES [dbo].[Kiralama] ([ID])
GO
ALTER TABLE [dbo].[KiralamaDetay] CHECK CONSTRAINT [FK_KiralamaDetay_Kiralama]
GO
ALTER TABLE [dbo].[KiralamaDetay]  WITH CHECK ADD  CONSTRAINT [FK_KiralamaDetay_Odeme] FOREIGN KEY([KiraOdemesi])
REFERENCES [dbo].[Odeme] ([ID])
GO
ALTER TABLE [dbo].[KiralamaDetay] CHECK CONSTRAINT [FK_KiralamaDetay_Odeme]
GO
ALTER TABLE [dbo].[KiralamaDetay]  WITH CHECK ADD  CONSTRAINT [FK_KiralamaDetay_Odeme1] FOREIGN KEY([GecikmeOdemesi])
REFERENCES [dbo].[Odeme] ([ID])
GO
ALTER TABLE [dbo].[KiralamaDetay] CHECK CONSTRAINT [FK_KiralamaDetay_Odeme1]
GO
ALTER TABLE [dbo].[KiralamaDetay]  WITH CHECK ADD  CONSTRAINT [FK_KiralamaDetay_Odeme2] FOREIGN KEY([HasarOdemesi])
REFERENCES [dbo].[Odeme] ([ID])
GO
ALTER TABLE [dbo].[KiralamaDetay] CHECK CONSTRAINT [FK_KiralamaDetay_Odeme2]
GO
ALTER TABLE [dbo].[Kitap]  WITH CHECK ADD  CONSTRAINT [FK_Kitap_Kategori] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategori] ([ID])
GO
ALTER TABLE [dbo].[Kitap] CHECK CONSTRAINT [FK_Kitap_Kategori]
GO
ALTER TABLE [dbo].[Kitap]  WITH CHECK ADD  CONSTRAINT [FK_Kitap_Yayinevi] FOREIGN KEY([YayineviID])
REFERENCES [dbo].[Yayinevi] ([ID])
GO
ALTER TABLE [dbo].[Kitap] CHECK CONSTRAINT [FK_Kitap_Yayinevi]
GO
ALTER TABLE [dbo].[KitapYazar]  WITH CHECK ADD  CONSTRAINT [FK_KitapYazar_Kitap] FOREIGN KEY([KitapID])
REFERENCES [dbo].[Kitap] ([ID])
GO
ALTER TABLE [dbo].[KitapYazar] CHECK CONSTRAINT [FK_KitapYazar_Kitap]
GO
ALTER TABLE [dbo].[KitapYazar]  WITH CHECK ADD  CONSTRAINT [FK_KitapYazar_Yazar] FOREIGN KEY([YazarID])
REFERENCES [dbo].[Yazar] ([ID])
GO
ALTER TABLE [dbo].[KitapYazar] CHECK CONSTRAINT [FK_KitapYazar_Yazar]
GO
ALTER TABLE [dbo].[Odeme]  WITH CHECK ADD  CONSTRAINT [FK_Odeme_OdemeTipi] FOREIGN KEY([OdemeTipi])
REFERENCES [dbo].[OdemeTipi] ([ID])
GO
ALTER TABLE [dbo].[Odeme] CHECK CONSTRAINT [FK_Odeme_OdemeTipi]
GO
ALTER TABLE [dbo].[Odeme]  WITH CHECK ADD  CONSTRAINT [FK_Odeme_Uye] FOREIGN KEY([UyeID])
REFERENCES [dbo].[Uye] ([ID])
GO
ALTER TABLE [dbo].[Odeme] CHECK CONSTRAINT [FK_Odeme_Uye]
GO
