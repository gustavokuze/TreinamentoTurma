USE [master]
GO

/****** Object:  Database [treinamento]    Script Date: 21/11/2018 15:25:20 ******/
CREATE DATABASE [treinamento]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'treinamento', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\treinamento.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'treinamento_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\treinamento_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [treinamento] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [treinamento].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [treinamento] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [treinamento] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [treinamento] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [treinamento] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [treinamento] SET ARITHABORT OFF 
GO

ALTER DATABASE [treinamento] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [treinamento] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [treinamento] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [treinamento] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [treinamento] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [treinamento] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [treinamento] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [treinamento] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [treinamento] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [treinamento] SET  ENABLE_BROKER 
GO

ALTER DATABASE [treinamento] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [treinamento] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [treinamento] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [treinamento] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [treinamento] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [treinamento] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [treinamento] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [treinamento] SET RECOVERY FULL 
GO

ALTER DATABASE [treinamento] SET  MULTI_USER 
GO

ALTER DATABASE [treinamento] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [treinamento] SET DB_CHAINING OFF 
GO

ALTER DATABASE [treinamento] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [treinamento] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [treinamento] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [treinamento] SET QUERY_STORE = OFF
GO

ALTER DATABASE [treinamento] SET  READ_WRITE 
GO

