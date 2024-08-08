USE [master]
GO
/****** Object:  Database [DB_PHE_ADS]    Script Date: 2/17/2023 3:35:35 PM ******/
CREATE DATABASE [DB_PHE_ADS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_PHE_ADS', FILENAME = N'D:\SQLDATA\MSSQL13.PHESQLCLUDB\MSSQL\DATA\DB_PHE_ADS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_PHE_ADS_log', FILENAME = N'D:\SQLDATA\MSSQL13.PHESQLCLUDB\MSSQL\Log\DB_PHE_ADS_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DB_PHE_ADS] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_PHE_ADS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_PHE_ADS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_PHE_ADS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_PHE_ADS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_PHE_ADS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_PHE_ADS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_PHE_ADS] SET  MULTI_USER 
GO
ALTER DATABASE [DB_PHE_ADS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_PHE_ADS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_PHE_ADS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_PHE_ADS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_PHE_ADS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_PHE_ADS] SET QUERY_STORE = OFF
GO
USE [DB_PHE_ADS]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [nchar](5) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departement]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departement](
	[DepartementId] [int] IDENTITY(1,1) NOT NULL,
	[DepartementName] [varchar](255) NULL,
 CONSTRAINT [PK_Departement] PRIMARY KEY CLUSTERED 
(
	[DepartementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](255) NULL,
	[EmpPosition] [varchar](255) NULL,
	[DepartementId] [int] NULL,
	[Birthdate] [datetime] NULL,
	[OrgUnitId] [int] NULL,
	[Score] [decimal](14, 4) NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[PostalCode] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[IsActive] [bit] NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeEducation]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeEducation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [int] NULL,
	[School] [varchar](255) NULL,
	[Degree] [varchar](255) NULL,
	[FieldOfStudy] [varchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeEducation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](255) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Region]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[RegionID] [int] NOT NULL,
	[RegionDescription] [nchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Territories]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Territories](
	[TerritoryID] [nvarchar](20) NOT NULL,
	[TerritoryDescription] [nchar](50) NOT NULL,
	[RegionID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Workers]    Script Date: 2/17/2023 3:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](20) NULL,
	[FirstName] [nvarchar](10) NULL,
	[Title] [nvarchar](30) NULL,
	[TitleOfCourtesy] [nvarchar](25) NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[HomePhone] [nvarchar](24) NULL,
	[Extension] [nvarchar](4) NULL,
	[Notes] [ntext] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'ALFKI', N'Alfreds Futterkiste', N'Maria Anders', N'Sales Representative', N'Obere Str. 57', N'Berlin', NULL, N'12209', N'Germany', N'030-0074321', N'030-0076545')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'ANATR', N'Ana Trujillo Emparedados y helados', N'Ana Trujillo', N'Owner', N'Avda. de la Constitución 2222', N'México D.F.', NULL, N'05021', N'Mexico', N'(5) 555-4729', N'(5) 555-3745')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'ANTON', N'Antonio Moreno Taquería', N'Antonio Moreno', N'Owner', N'Mataderos  2312', N'México D.F.', NULL, N'05023', N'Mexico', N'(5) 555-3932', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'AROUT', N'Around the Horn', N'Thomas Hardy', N'Sales Representative', N'120 Hanover Sq.', N'London', NULL, N'WA1 1DP', N'UK', N'(171) 555-7788', N'(171) 555-6750')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'BERGS', N'Berglunds snabbköp', N'Christina Berglund', N'Order Administrator', N'Berguvsvägen  8', N'Luleå', NULL, N'S-958 22', N'Sweden', N'0921-12 34 65', N'0921-12 34 67')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'BLAUS', N'Blauer See Delikatessen', N'Hanna Moos', N'Sales Representative', N'Forsterstr. 57', N'Mannheim', NULL, N'68306', N'Germany', N'0621-08460', N'0621-08924')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'BLONP', N'Blondesddsl père et fils', N'Frédérique Citeaux', N'Marketing Manager', N'24, place Kléber', N'Strasbourg', NULL, N'67000', N'France', N'88.60.15.31', N'88.60.15.32')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'BOLID', N'Bólido Comidas preparadas', N'Martín Sommer', N'Owner', N'C/ Araquil, 67', N'Madrid', NULL, N'28023', N'Spain', N'(91) 555 22 82', N'(91) 555 91 99')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'BONAP', N'Bon app''', N'Laurence Lebihan', N'Owner', N'12, rue des Bouchers', N'Marseille', NULL, N'13008', N'France', N'91.24.45.40', N'91.24.45.41')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'BOTTM', N'Bottom-Dollar Markets', N'Elizabeth Lincoln', N'Accounting Manager', N'23 Tsawassen Blvd.', N'Tsawassen', N'BC', N'T2F 8M4', N'Canada', N'(604) 555-4729', N'(604) 555-3745')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'BSBEV', N'B''s Beverages', N'Victoria Ashworth', N'Sales Representative', N'Fauntleroy Circus', N'London', NULL, N'EC2 5NT', N'UK', N'(171) 555-1212', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'CACTU', N'Cactus Comidas para llevar', N'Patricio Simpson', N'Sales Agent', N'Cerrito 333', N'Buenos Aires', NULL, N'1010', N'Argentina', N'(1) 135-5555', N'(1) 135-4892')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'CENTC', N'Centro comercial Moctezuma', N'Francisco Chang', N'Marketing Manager', N'Sierras de Granada 9993', N'México D.F.', NULL, N'05022', N'Mexico', N'(5) 555-3392', N'(5) 555-7293')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'CHOPS', N'Chop-suey Chinese', N'Yang Wang', N'Owner', N'Hauptstr. 29', N'Bern', NULL, N'3012', N'Switzerland', N'0452-076545', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'COMMI', N'Comércio Mineiro', N'Pedro Afonso', N'Sales Associate', N'Av. dos Lusíadas, 23', N'Sao Paulo', N'SP', N'05432-043', N'Brazil', N'(11) 555-7647', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'CONSH', N'Consolidated Holdings', N'Elizabeth Brown', N'Sales Representative', N'Berkeley Gardens 12  Brewery', N'London', NULL, N'WX1 6LT', N'UK', N'(171) 555-2282', N'(171) 555-9199')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'DRACD', N'Drachenblut Delikatessen', N'Sven Ottlieb', N'Order Administrator', N'Walserweg 21', N'Aachen', NULL, N'52066', N'Germany', N'0241-039123', N'0241-059428')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'DUMON', N'Du monde entier', N'Janine Labrune', N'Owner', N'67, rue des Cinquante Otages', N'Nantes', NULL, N'44000', N'France', N'40.67.88.88', N'40.67.89.89')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'EASTC', N'Eastern Connection', N'Ann Devon', N'Sales Agent', N'35 King George', N'London', NULL, N'WX3 6FW', N'UK', N'(171) 555-0297', N'(171) 555-3373')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'ERNSH', N'Ernst Handel', N'Roland Mendel', N'Sales Manager', N'Kirchgasse 6', N'Graz', NULL, N'8010', N'Austria', N'7675-3425', N'7675-3426')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FAMIA', N'Familia Arquibaldo', N'Aria Cruz', N'Marketing Assistant', N'Rua Orós, 92', N'Sao Paulo', N'SP', N'05442-030', N'Brazil', N'(11) 555-9857', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FISSA', N'FISSA Fabrica Inter. Salchichas S.A.', N'Diego Roel', N'Accounting Manager', N'C/ Moralzarzal, 86', N'Madrid', NULL, N'28034', N'Spain', N'(91) 555 94 44', N'(91) 555 55 93')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FOLIG', N'Folies gourmandes', N'Martine Rancé', N'Assistant Sales Agent', N'184, chaussée de Tournai', N'Lille', NULL, N'59000', N'France', N'20.16.10.16', N'20.16.10.17')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FOLKO', N'Folk och fä HB', N'Maria Larsson', N'Owner', N'Åkergatan 24', N'Bräcke', NULL, N'S-844 67', N'Sweden', N'0695-34 67 21', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FRANK', N'Frankenversand', N'Peter Franken', N'Marketing Manager', N'Berliner Platz 43', N'München', NULL, N'80805', N'Germany', N'089-0877310', N'089-0877451')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FRANR', N'France restauration', N'Carine Schmitt', N'Marketing Manager', N'54, rue Royale', N'Nantes', NULL, N'44000', N'France', N'40.32.21.21', N'40.32.21.20')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FRANS', N'Franchi S.p.A.', N'Paolo Accorti', N'Sales Representative', N'Via Monte Bianco 34', N'Torino', NULL, N'10100', N'Italy', N'011-4988260', N'011-4988261')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'FURIB', N'Furia Bacalhau e Frutos do Mar', N'Lino Rodriguez', N'Sales Manager', N'Jardim das rosas n. 32', N'Lisboa', NULL, N'1675', N'Portugal', N'(1) 354-2534', N'(1) 354-2535')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'GALED', N'Galería del gastrónomo', N'Eduardo Saavedra', N'Marketing Manager', N'Rambla de Cataluña, 23', N'Barcelona', NULL, N'08022', N'Spain', N'(93) 203 4560', N'(93) 203 4561')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'GODOS', N'Godos Cocina Típica', N'José Pedro Freyre', N'Sales Manager', N'C/ Romero, 33', N'Sevilla', NULL, N'41101', N'Spain', N'(95) 555 82 82', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'GOURL', N'Gourmet Lanchonetes', N'André Fonseca', N'Sales Associate', N'Av. Brasil, 442', N'Campinas', N'SP', N'04876-786', N'Brazil', N'(11) 555-9482', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'GREAL', N'Great Lakes Food Market', N'Howard Snyder', N'Marketing Manager', N'2732 Baker Blvd.', N'Eugene', N'OR', N'97403', N'USA', N'(503) 555-7555', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'GROSR', N'GROSELLA-Restaurante', N'Manuel Pereira', N'Owner', N'5ª Ave. Los Palos Grandes', N'Caracas', N'DF', N'1081', N'Venezuela', N'(2) 283-2951', N'(2) 283-3397')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'HANAR', N'Hanari Carnes', N'Mario Pontes', N'Accounting Manager', N'Rua do Paço, 67', N'Rio de Janeiro', N'RJ', N'05454-876', N'Brazil', N'(21) 555-0091', N'(21) 555-8765')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'HILAA', N'HILARION-Abastos', N'Carlos Hernández', N'Sales Representative', N'Carrera 22 con Ave. Carlos Soublette #8-35', N'San Cristóbal', N'Táchira', N'5022', N'Venezuela', N'(5) 555-1340', N'(5) 555-1948')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'HUNGC', N'Hungry Coyote Import Store', N'Yoshi Latimer', N'Sales Representative', N'City Center Plaza 516 Main St.', N'Elgin', N'OR', N'97827', N'USA', N'(503) 555-6874', N'(503) 555-2376')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'HUNGO', N'Hungry Owl All-Night Grocers', N'Patricia McKenna', N'Sales Associate', N'8 Johnstown Road', N'Cork', N'Co. Cork', NULL, N'Ireland', N'2967 542', N'2967 3333')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'ISLAT', N'Island Trading', N'Helen Bennett', N'Marketing Manager', N'Garden House Crowther Way', N'Cowes', N'Isle of Wight', N'PO31 7PJ', N'UK', N'(198) 555-8888', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'KOENE', N'Königlich Essen', N'Philip Cramer', N'Sales Associate', N'Maubelstr. 90', N'Brandenburg', NULL, N'14776', N'Germany', N'0555-09876', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LACOR', N'La corne d''abondance', N'Daniel Tonini', N'Sales Representative', N'67, avenue de l''Europe', N'Versailles', NULL, N'78000', N'France', N'30.59.84.10', N'30.59.85.11')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LAMAI', N'La maison d''Asie', N'Annette Roulet', N'Sales Manager', N'1 rue Alsace-Lorraine', N'Toulouse', NULL, N'31000', N'France', N'61.77.61.10', N'61.77.61.11')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LAUGB', N'Laughing Bacchus Wine Cellars', N'Yoshi Tannamuri', N'Marketing Assistant', N'1900 Oak St.', N'Vancouver', N'BC', N'V3F 2K1', N'Canada', N'(604) 555-3392', N'(604) 555-7293')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LAZYK', N'Lazy K Kountry Store', N'John Steel', N'Marketing Manager', N'12 Orchestra Terrace', N'Walla Walla', N'WA', N'99362', N'USA', N'(509) 555-7969', N'(509) 555-6221')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LEHMS', N'Lehmanns Marktstand', N'Renate Messner', N'Sales Representative', N'Magazinweg 7', N'Frankfurt a.M.', NULL, N'60528', N'Germany', N'069-0245984', N'069-0245874')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LETSS', N'Let''s Stop N Shop', N'Jaime Yorres', N'Owner', N'87 Polk St. Suite 5', N'San Francisco', N'CA', N'94117', N'USA', N'(415) 555-5938', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LILAS', N'LILA-Supermercado', N'Carlos González', N'Accounting Manager', N'Carrera 52 con Ave. Bolívar #65-98 Llano Largo', N'Barquisimeto', N'Lara', N'3508', N'Venezuela', N'(9) 331-6954', N'(9) 331-7256')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LINOD', N'LINO-Delicateses', N'Felipe Izquierdo', N'Owner', N'Ave. 5 de Mayo Porlamar', N'I. de Margarita', N'Nueva Esparta', N'4980', N'Venezuela', N'(8) 34-56-12', N'(8) 34-93-93')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'LONEP', N'Lonesome Pine Restaurant', N'Fran Wilson', N'Sales Manager', N'89 Chiaroscuro Rd.', N'Portland', N'OR', N'97219', N'USA', N'(503) 555-9573', N'(503) 555-9646')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'MAGAA', N'Magazzini Alimentari Riuniti', N'Giovanni Rovelli', N'Marketing Manager', N'Via Ludovico il Moro 22', N'Bergamo', NULL, N'24100', N'Italy', N'035-640230', N'035-640231')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'MAISD', N'Maison Dewey', N'Catherine Dewey', N'Sales Agent', N'Rue Joseph-Bens 532', N'Bruxelles', NULL, N'B-1180', N'Belgium', N'(02) 201 24 67', N'(02) 201 24 68')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'MEREP', N'Mère Paillarde', N'Jean Fresnière', N'Marketing Assistant', N'43 rue St. Laurent', N'Montréal', N'Québec', N'H1J 1C3', N'Canada', N'(514) 555-8054', N'(514) 555-8055')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'MORGK', N'Morgenstern Gesundkost', N'Alexander Feuer', N'Marketing Assistant', N'Heerstr. 22', N'Leipzig', NULL, N'04179', N'Germany', N'0342-023176', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'NORTS', N'North/South', N'Simon Crowther', N'Sales Associate', N'South House 300 Queensbridge', N'London', NULL, N'SW7 1RZ', N'UK', N'(171) 555-7733', N'(171) 555-2530')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'OCEAN', N'Océano Atlántico Ltda.', N'Yvonne Moncada', N'Sales Agent', N'Ing. Gustavo Moncada 8585 Piso 20-A', N'Buenos Aires', NULL, N'1010', N'Argentina', N'(1) 135-5333', N'(1) 135-5535')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'OLDWO', N'Old World Delicatessen', N'Rene Phillips', N'Sales Representative', N'2743 Bering St.', N'Anchorage', N'AK', N'99508', N'USA', N'(907) 555-7584', N'(907) 555-2880')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'OTTIK', N'Ottilies Käseladen', N'Henriette Pfalzheim', N'Owner', N'Mehrheimerstr. 369', N'Köln', NULL, N'50739', N'Germany', N'0221-0644327', N'0221-0765721')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'PARIS', N'Paris spécialités', N'Marie Bertrand', N'Owner', N'265, boulevard Charonne', N'Paris', NULL, N'75012', N'France', N'(1) 42.34.22.66', N'(1) 42.34.22.77')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'PERIC', N'Pericles Comidas clásicas', N'Guillermo Fernández', N'Sales Representative', N'Calle Dr. Jorge Cash 321', N'México D.F.', NULL, N'05033', N'Mexico', N'(5) 552-3745', N'(5) 545-3745')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'PICCO', N'Piccolo und mehr', N'Georg Pipps', N'Sales Manager', N'Geislweg 14', N'Salzburg', NULL, N'5020', N'Austria', N'6562-9722', N'6562-9723')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'PRINI', N'Princesa Isabel Vinhos', N'Isabel de Castro', N'Sales Representative', N'Estrada da saúde n. 58', N'Lisboa', NULL, N'1756', N'Portugal', N'(1) 356-5634', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'qq   ', N'qq', N'qq', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'QUEDE', N'Que Delícia', N'Bernardo Batista', N'Accounting Manager', N'Rua da Panificadora, 12', N'Rio de Janeiro', N'RJ', N'02389-673', N'Brazil', N'(21) 555-4252', N'(21) 555-4545')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'QUEEN', N'Queen Cozinha', N'Lúcia Carvalho', N'Marketing Assistant', N'Alameda dos Canàrios, 891', N'Sao Paulo', N'SP', N'05487-020', N'Brazil', N'(11) 555-1189', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'QUICK', N'QUICK-Stop', N'Horst Kloss', N'Accounting Manager', N'Taucherstraße 10', N'Cunewalde', NULL, N'01307', N'Germany', N'0372-035188', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'RANCH', N'Rancho grande', N'Sergio Gutiérrez', N'Sales Representative', N'Av. del Libertador 900', N'Buenos Aires', NULL, N'1010', N'Argentina', N'(1) 123-5555', N'(1) 123-5556')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'RATTC', N'Rattlesnake Canyon Grocery', N'Paula Wilson', N'Assistant Sales Representative', N'2817 Milton Dr.', N'Albuquerque', N'NM', N'87110', N'USA', N'(505) 555-5939', N'(505) 555-3620')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'REGGC', N'Reggiani Caseifici', N'Maurizio Moroni', N'Sales Associate', N'Strada Provinciale 124', N'Reggio Emilia', NULL, N'42100', N'Italy', N'0522-556721', N'0522-556722')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'RICAR', N'Ricardo Adocicados', N'Janete Limeira', N'Assistant Sales Agent', N'Av. Copacabana, 267', N'Rio de Janeiro', N'RJ', N'02389-890', N'Brazil', N'(21) 555-3412', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'RICSU', N'Richter Supermarkt', N'Michael Holz', N'Sales Manager', N'Grenzacherweg 237', N'Genève', NULL, N'1203', N'Switzerland', N'0897-034214', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'ROMEY', N'Romero y tomillo', N'Alejandra Camino', N'Accounting Manager', N'Gran Vía, 1', N'Madrid', NULL, N'28001', N'Spain', N'(91) 745 6200', N'(91) 745 6210')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'SANTG', N'Santé Gourmet', N'Jonas Bergulfsen', N'Owner', N'Erling Skakkes gate 78', N'Stavern', NULL, N'4110', N'Norway', N'07-98 92 35', N'07-98 92 47')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'SAVEA', N'Save-a-lot Markets', N'Jose Pavarotti', N'Sales Representative', N'187 Suffolk Ln.', N'Boise', N'ID', N'83720', N'USA', N'(208) 555-8097', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'SEVES', N'Seven Seas Imports', N'Hari Kumar', N'Sales Manager', N'90 Wadhurst Rd.', N'London', NULL, N'OX15 4NB', N'UK', N'(171) 555-1717', N'(171) 555-5646')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'SIMOB', N'Simons bistro', N'Jytte Petersen', N'Owner', N'Vinbæltet 34', N'Kobenhavn', NULL, N'1734', N'Denmark', N'31 12 34 56', N'31 13 35 57')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'SPECD', N'Spécialités du monde', N'Dominique Perrier', N'Marketing Manager', N'25, rue Lauriston', N'Paris', NULL, N'75016', N'France', N'(1) 47.55.60.10', N'(1) 47.55.60.20')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'SPLIR', N'Split Rail Beer & Ale', N'Art Braunschweiger', N'Sales Manager', N'P.O. Box 555', N'Lander', N'WY', N'82520', N'USA', N'(307) 555-4680', N'(307) 555-6525')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'SUPRD', N'Suprêmes délices', N'Pascale Cartrain', N'Accounting Manager', N'Boulevard Tirou, 255', N'Charleroi', NULL, N'B-6000', N'Belgium', N'(071) 23 67 22 20', N'(071) 23 67 22 21')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'THEBI', N'The Big Cheese', N'Liz Nixon', N'Marketing Manager', N'89 Jefferson Way Suite 2', N'Portland', N'OR', N'97201', N'USA', N'(503) 555-3612', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'THECR', N'The Cracker Box', N'Liu Wong', N'Marketing Assistant', N'55 Grizzly Peak Rd.', N'Butte', N'MT', N'59801', N'USA', N'(406) 555-5834', N'(406) 555-8083')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'TOMSP', N'Toms Spezialitäten', N'Karin Josephs', N'Marketing Manager', N'Luisenstr. 48', N'Münster', NULL, N'44087', N'Germany', N'0251-031259', N'0251-035695')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'TORTU', N'Tortuga Restaurante', N'Miguel Angel Paolino', N'Owner', N'Avda. Azteca 123', N'México D.F.', NULL, N'05033', N'Mexico', N'(5) 555-2933', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'TRADH', N'Tradição Hipermercados', N'Anabela Domingues', N'Sales Representative', N'Av. Inês de Castro, 414', N'Sao Paulo', N'SP', N'05634-030', N'Brazil', N'(11) 555-2167', N'(11) 555-2168')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'TRAIH', N'Trail''s Head Gourmet Provisioners', N'Helvetius Nagy', N'Sales Associate', N'722 DaVinci Blvd.', N'Kirkland', N'WA', N'98034', N'USA', N'(206) 555-8257', N'(206) 555-2174')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'VAFFE', N'Vaffeljernet', N'Palle Ibsen', N'Sales Manager', N'Smagsloget 45', N'Århus', NULL, N'8200', N'Denmark', N'86 21 32 43', N'86 22 33 44')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'VICTE', N'Victuailles en stock', N'Mary Saveley', N'Sales Agent', N'2, rue du Commerce', N'Lyon', NULL, N'69004', N'France', N'78.32.54.86', N'78.32.54.87')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'VINET', N'Vins et alcools Chevalier', N'Paul Henriot', N'Accounting Manager', N'59 rue de l''Abbaye', N'Reims', NULL, N'51100', N'France', N'26.47.15.10', N'26.47.15.11')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'WANDK', N'Die Wandernde Kuh', N'Rita Müller', N'Sales Representative', N'Adenauerallee 900', N'Stuttgart', NULL, N'70563', N'Germany', N'0711-020361', N'0711-035428')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'WARTH', N'Wartian Herkku', N'Pirkko Koskitalo', N'Accounting Manager', N'Torikatu 38', N'Oulu', NULL, N'90110', N'Finland', N'981-443655', N'981-443655')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'WELLI', N'Wellington Importadora', N'Paula Parente', N'Sales Manager', N'Rua do Mercado, 12', N'Resende', N'SP', N'08737-363', N'Brazil', N'(14) 555-8122', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'WHITC', N'White Clover Markets', N'Karl Jablonski', N'Owner', N'305 - 14th Ave. S. Suite 3B', N'Seattle', N'WA', N'98128', N'USA', N'(206) 555-4112', N'(206) 555-4115')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'WILMK', N'Wilman Kala', N'Matti Karttunen', N'Owner/Marketing Assistant', N'Keskuskatu 45', N'Helsinki', NULL, N'21240', N'Finland', N'90-224 8858', N'90-224 8858')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'WOLZA', N'Wolski  Zajazd', N'Zbyszek Piestrzeniewicz', N'Owner', N'ul. Filtrowa 68', N'Warszawa', NULL, N'01-012', N'Poland', N'(26) 642-7012', N'(26) 642-7012')
SET IDENTITY_INSERT [dbo].[Departement] ON 

INSERT [dbo].[Departement] ([DepartementId], [DepartementName]) VALUES (1, N'Human Resources')
INSERT [dbo].[Departement] ([DepartementId], [DepartementName]) VALUES (2, N'Information Technology')
INSERT [dbo].[Departement] ([DepartementId], [DepartementName]) VALUES (3, N'Supply Chain Management')
INSERT [dbo].[Departement] ([DepartementId], [DepartementName]) VALUES (4, N'HSSE')
INSERT [dbo].[Departement] ([DepartementId], [DepartementName]) VALUES (5, N'Drilling Operations')
INSERT [dbo].[Departement] ([DepartementId], [DepartementName]) VALUES (6, N'Coorporate Secretary')
INSERT [dbo].[Departement] ([DepartementId], [DepartementName]) VALUES (7, N'Business Relation')
SET IDENTITY_INSERT [dbo].[Departement] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmpId], [EmpName], [EmpPosition], [DepartementId], [Birthdate], [OrgUnitId], [Score], [Address], [City], [PostalCode], [Phone], [Email], [IsActive], [Role]) VALUES (1, N'Michael Forst', N'Staff', 1, CAST(N'1993-02-17T00:00:00.000' AS DateTime), 2, CAST(90.0000 AS Decimal(14, 4)), N'St. Boston 12', N'Boston', NULL, N'+92 213122', N'mcforst@gmail.com', 1, 3)
INSERT [dbo].[Employee] ([EmpId], [EmpName], [EmpPosition], [DepartementId], [Birthdate], [OrgUnitId], [Score], [Address], [City], [PostalCode], [Phone], [Email], [IsActive], [Role]) VALUES (2, N'Adit Rahman', N'Analyst', 7, CAST(N'1982-02-15T00:00:00.000' AS DateTime), 1, CAST(10.0000 AS Decimal(14, 4)), N'Tebet', N'Jakarta', NULL, N'09232198731', N'adit@gmail.com', 0, 3)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeEducation] ON 

INSERT [dbo].[EmployeeEducation] ([Id], [EmpId], [School], [Degree], [FieldOfStudy], [StartDate], [EndDate]) VALUES (1, 1, N'Univ. ABC', N'S1', N'HC', CAST(N'2000-02-17T00:00:00.000' AS DateTime), CAST(N'2005-02-17T00:00:00.000' AS DateTime))
INSERT [dbo].[EmployeeEducation] ([Id], [EmpId], [School], [Degree], [FieldOfStudy], [StartDate], [EndDate]) VALUES (2, 2, N'Univ. abc', N'S1', N'BR', CAST(N'2001-01-01T00:00:00.000' AS DateTime), CAST(N'2005-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[EmployeeEducation] OFF
INSERT [dbo].[Region] ([RegionID], [RegionDescription]) VALUES (1, N'Eastern                                           ')
INSERT [dbo].[Region] ([RegionID], [RegionDescription]) VALUES (2, N'Western                                           ')
INSERT [dbo].[Region] ([RegionID], [RegionDescription]) VALUES (3, N'Northern                                          ')
INSERT [dbo].[Region] ([RegionID], [RegionDescription]) VALUES (4, N'Southern                                          ')
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'01581', N'Westboro                                          ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'01730', N'Bedford                                           ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'01833', N'Georgetow                                         ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'02116', N'Boston                                            ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'02139', N'Cambridge                                         ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'02184', N'Braintree                                         ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'02903', N'Providence                                        ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'03049', N'Hollis                                            ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'03801', N'Portsmouth                                        ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'06897', N'Wilton                                            ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'07960', N'Morristown                                        ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'08837', N'Edison                                            ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'10019', N'New York                                          ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'10038', N'New York                                          ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'11747', N'Mellvile                                          ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'14450', N'Fairport                                          ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'19428', N'Philadelphia                                      ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'19713', N'Neward                                            ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'20852', N'Rockville                                         ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'27403', N'Greensboro                                        ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'27511', N'Cary                                              ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'29202', N'Columbia                                          ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'30346', N'Atlanta                                           ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'31406', N'Savannah                                          ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'32859', N'Orlando                                           ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'33607', N'Tampa                                             ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'40222', N'Louisville                                        ', 1)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'44122', N'Beachwood                                         ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'45839', N'Findlay                                           ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'48075', N'Southfield                                        ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'48084', N'Troy                                              ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'48304', N'Bloomfield Hills                                  ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'53404', N'Racine                                            ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'55113', N'Roseville                                         ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'55439', N'Minneapolis                                       ', 3)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'60179', N'Hoffman Estates                                   ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'60601', N'Chicago                                           ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'72716', N'Bentonville                                       ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'75234', N'Dallas                                            ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'78759', N'Austin                                            ', 4)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'80202', N'Denver                                            ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'80909', N'Colorado Springs                                  ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'85014', N'Phoenix                                           ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'85251', N'Scottsdale                                        ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'90405', N'Santa Monica                                      ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'94025', N'Menlo Park                                        ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'94105', N'San Francisco                                     ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'95008', N'Campbell                                          ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'95054', N'Santa Clara                                       ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'95060', N'Santa Cruz                                        ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'98004', N'Bellevue                                          ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'98052', N'Redmond                                           ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'98104', N'Seattle                                           ', 2)
INSERT [dbo].[Territories] ([TerritoryID], [TerritoryDescription], [RegionID]) VALUES (N'123', N'q                                                 ', 1)
SET IDENTITY_INSERT [dbo].[Workers] ON 

INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (1, N'Davolio', N'Nancy', N'Sales Representative', N'Ms.', CAST(N'1948-12-08T00:00:00.000' AS DateTime), CAST(N'1992-05-01T00:00:00.000' AS DateTime), N'507 - 20th Ave. E.
Apt. 2A', N'Seattle', N'WA', N'98122', N'USA', N'(206) 555-9857', N'5467', N'Education includes a BA in psychology from Colorado State University in 1970.  She also completed "The Art of the Cold Call."  Nancy is a member of Toastmasters International.')
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (3, N'Leverling', N'Janet', NULL, NULL, CAST(N'1963-08-31T00:00:00.000' AS DateTime), CAST(N'1992-04-01T00:00:00.000' AS DateTime), NULL, N'Kirkland', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (4, N'Peacock', N'Margaret', N'Sales Representative', N'Mrs.', CAST(N'1937-09-19T00:00:00.000' AS DateTime), CAST(N'1993-05-03T00:00:00.000' AS DateTime), N'4110 Old Redmond Rd.', N'Redmond', N'WA', N'98052', N'USA', N'(206) 555-8122', N'5176', N'Margaret holds a BA in English literature from Concordia College (1958) and an MA from the American Institute of Culinary Arts (1966).  She was assigned to the London office temporarily from July through November 1992.')
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (5, N'Buchanan', N'Steven', N'Sales Manager', N'Mr.', CAST(N'1955-03-04T00:00:00.000' AS DateTime), CAST(N'1993-10-17T00:00:00.000' AS DateTime), N'14 Garrett Hill', N'London', NULL, N'SW1 8JR', N'UK', N'(71) 555-4848', N'3453', N'Steven Buchanan graduated from St. Andrews University, Scotland, with a BSC degree in 1976.  Upon joining the company as a sales representative in 1992, he spent 6 months in an orientation program at the Seattle office and then returned to his permanent post in London.  He was promoted to sales manager in March 1993.  Mr. Buchanan has completed the courses "Successful Telemarketing" and "International Sales Management."  He is fluent in French.')
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (7, N'King', N'Robert', N'Sales Representative', N'Mr.', CAST(N'1960-05-29T00:00:00.000' AS DateTime), CAST(N'1994-01-02T00:00:00.000' AS DateTime), N'Edgeham Hollow
Winchester Way', N'London', NULL, N'RG1 9SP', N'UK', N'(71) 555-5598', N'465', N'Robert King served in the Peace Corps and traveled extensively before completing his degree in English at the University of Michigan in 1992, the year he joined the company.  After completing a course entitled "Selling in Europe," he was transferred to the London office in March 1993.')
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (8, N'Callahan', N'Laura', N'Inside Sales Coordinator', N'Ms.', CAST(N'1958-01-09T00:00:00.000' AS DateTime), CAST(N'1994-03-05T00:00:00.000' AS DateTime), N'4726 - 11th Ave. N.E.', N'Seattle', N'WA', N'98105', N'USA', N'(206) 555-1189', N'2344', N'Laura received a BA in psychology from the University of Washington.  She has also completed a course in business French.  She reads and writes French.')
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (10, N'Andrian', N'Taufik', N'IT Dev Engineer', N'Mr.', CAST(N'1993-12-01T00:00:00.000' AS DateTime), CAST(N'2022-10-18T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (13, N'Net', N'Darwin', NULL, NULL, CAST(N'1991-01-31T00:00:00.000' AS DateTime), CAST(N'2023-01-31T00:00:00.000' AS DateTime), NULL, N'LA', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (14, N'Test', N'Oke', N'IT Dev Engineer', N'Mr.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (15, N'Mudryk', N'David', NULL, NULL, CAST(N'1994-01-05T00:00:00.000' AS DateTime), CAST(N'2023-01-05T00:00:00.000' AS DateTime), NULL, N'New York', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (16, N'Cruyf', N'Johan', N'Manager', N'Mr.', CAST(N'1982-03-31T00:00:00.000' AS DateTime), CAST(N'2023-01-06T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Workers] ([EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Notes]) VALUES (17, N'test', N'test', N'mr', N'test', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Workers] OFF
/****** Object:  Index [PK_Region]    Script Date: 2/17/2023 3:35:38 PM ******/
ALTER TABLE [dbo].[Region] ADD  CONSTRAINT [PK_Region] PRIMARY KEY NONCLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_Territories]    Script Date: 2/17/2023 3:35:38 PM ******/
ALTER TABLE [dbo].[Territories] ADD  CONSTRAINT [PK_Territories] PRIMARY KEY NONCLUSTERED 
(
	[TerritoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Departement] FOREIGN KEY([DepartementId])
REFERENCES [dbo].[Departement] ([DepartementId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Departement]
GO
ALTER TABLE [dbo].[EmployeeEducation]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeEducation_Employee] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([EmpId])
GO
ALTER TABLE [dbo].[EmployeeEducation] CHECK CONSTRAINT [FK_EmployeeEducation_Employee]
GO
ALTER TABLE [dbo].[Territories]  WITH CHECK ADD  CONSTRAINT [FK_Territories_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
ALTER TABLE [dbo].[Territories] CHECK CONSTRAINT [FK_Territories_Region]
GO
ALTER TABLE [dbo].[Workers]  WITH NOCHECK ADD  CONSTRAINT [CK_Birthdate] CHECK  (([BirthDate]<getdate()))
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [CK_Birthdate]
GO
USE [master]
GO
ALTER DATABASE [DB_PHE_ADS] SET  READ_WRITE 
GO
