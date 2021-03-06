IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'MRLPublish')
	DROP DATABASE [MRLPublish]
GO

CREATE DATABASE [MRLPublish]  ON (NAME = N'MRLPublish_Data', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL\data\MRLPublish_Data.MDF' , SIZE = 3, FILEGROWTH = 10%) LOG ON (NAME = N'MRLPublish_Log', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL\data\MRLPublish_Log.LDF' , SIZE = 19, FILEGROWTH = 10%)
 COLLATE Chinese_Taiwan_Stroke_CI_AS
GO

exec sp_dboption N'MRLPublish', N'autoclose', N'false'
GO

exec sp_dboption N'MRLPublish', N'bulkcopy', N'false'
GO

exec sp_dboption N'MRLPublish', N'trunc. log', N'false'
GO

exec sp_dboption N'MRLPublish', N'torn page detection', N'true'
GO

exec sp_dboption N'MRLPublish', N'read only', N'false'
GO

exec sp_dboption N'MRLPublish', N'dbo use', N'false'
GO

exec sp_dboption N'MRLPublish', N'single', N'false'
GO

exec sp_dboption N'MRLPublish', N'autoshrink', N'false'
GO

exec sp_dboption N'MRLPublish', N'ANSI null default', N'false'
GO

exec sp_dboption N'MRLPublish', N'recursive triggers', N'false'
GO

exec sp_dboption N'MRLPublish', N'ANSI nulls', N'false'
GO

exec sp_dboption N'MRLPublish', N'concat null yields null', N'false'
GO

exec sp_dboption N'MRLPublish', N'cursor close on commit', N'false'
GO

exec sp_dboption N'MRLPublish', N'default to local cursor', N'false'
GO

exec sp_dboption N'MRLPublish', N'quoted identifier', N'false'
GO

exec sp_dboption N'MRLPublish', N'ANSI warnings', N'false'
GO

exec sp_dboption N'MRLPublish', N'auto create statistics', N'true'
GO

exec sp_dboption N'MRLPublish', N'auto update statistics', N'true'
GO

use [MRLPublish]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[1_o_detail_v]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[1_o_detail_v]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[1_otp1_v]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[1_otp1_v]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[book]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[book]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bookp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bookp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[btp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_cust]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_cust]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_lost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_obtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_obtp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_od]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_od]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_or]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_order]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_ores]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_ores]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_otp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_otp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_ramt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_ramt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_remail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_remail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_clr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_clr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_cont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_cont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_lost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_lprior]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_lprior]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_ltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_ltp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_njtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_njtp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_or]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pgsize]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pgsize]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pub]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pub]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_adr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_adr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_cont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_cont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_freebk]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_freebk]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_lost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_or]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_ramt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_ramt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_remail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_remail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_rtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_rtp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cust]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cust]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ia]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iad]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[iad]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ias]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ias]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[itp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[itp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mailer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mailer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mfr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mfr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mltp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mtp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatcol]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatcol]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatedt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatedt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatfmt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatfmt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcattbl]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcattbl]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatvld]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatvld]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proj]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[proj]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[py]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[py]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pyd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pyd]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pyseq]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pyseq]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pytp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pytp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[refd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[refd]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[refm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[refm]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapiv]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapiv]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapivd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapivd]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapvou]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapvou]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[srspn]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[srspn]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[syscd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[syscd]
GO

if not exists (select * from dbo.sysusers where name = N'mrlpub' and uid < 16382)
	EXEC sp_grantdbaccess N'mrlpub', N'mrlpub'
GO

if not exists (select * from dbo.sysusers where name = N'webuser' and uid < 16382)
	EXEC sp_grantdbaccess N'webuser', N'webuser'
GO

GRANT  CREATE VIEW ,  CREATE PROCEDURE  TO [webuser]
GO

exec sp_addrolemember N'db_owner', N'mrlpub'
GO

CREATE TABLE [dbo].[book] (
	[bk_bkid] [int] IDENTITY (1, 1) NOT NULL ,
	[bk_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bk_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[bookp] (
	[bkp_bkpid] [int] IDENTITY (1, 1) NOT NULL ,
	[bkp_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkp_date] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkp_pno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[btp] (
	[btp_btpid] [int] IDENTITY (1, 1) NOT NULL ,
	[btp_btpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[btp_nm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_cust] (
	[cust_custid] [int] IDENTITY (1, 1) NOT NULL ,
	[cust_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_nm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_regdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_fgoi] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_fgoe] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_otp1seq1] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_otp1seq2] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_otp1seq3] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_otp1seq9] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_itpcd] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_btpcd] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_lost] (
	[lst_lstid] [int] IDENTITY (1, 1) NOT NULL ,
	[lst_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_oditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_rea] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_obtp] (
	[obtp_obtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[obtp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpnm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_od] (
	[od_odid] [int] IDENTITY (1, 1) NOT NULL ,
	[od_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_oditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_btpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_remark] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_amt] [real] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_or] (
	[or_orid] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_nm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_addr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_order] (
	[o_oid] [int] IDENTITY (1, 1) NOT NULL ,
	[o_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp2cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_inm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_ijbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_idddr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_izip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_itel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_ifax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_icell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_iemail] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_pytpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_fgpreinv] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_oldvdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_empno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_xmldata] [ntext] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_orescd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_ores] (
	[ores_oresid] [int] IDENTITY (1, 1) NOT NULL ,
	[ores_orescd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ores_oresnm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_otp] (
	[otp_otpid] [int] IDENTITY (1, 1) NOT NULL ,
	[otp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp1nm] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp2cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp2nm] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_ramt] (
	[ra_raid] [int] IDENTITY (1, 1) NOT NULL ,
	[ra_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_oditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_mnt] [int] NOT NULL ,
	[ra_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c1_remail] (
	[rm_rmid] [int] IDENTITY (1, 1) NOT NULL ,
	[rm_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_oditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_clr] (
	[clr_clrid] [int] IDENTITY (1, 1) NOT NULL ,
	[clr_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clr_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_cont] (
	[cont_contid] [int] IDENTITY (1, 1) NOT NULL ,
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_conttp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_signdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_empno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aunm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_auemail] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_totjtm] [int] NOT NULL ,
	[cont_madejtm] [int] NOT NULL ,
	[cont_restjtm] [int] NOT NULL ,
	[cont_disc] [int] NOT NULL ,
	[cont_freetm] [int] NOT NULL ,
	[cont_freebkamt] [int] NOT NULL ,
	[cont_fgclosed] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_tottm] [int] NOT NULL ,
	[cont_pubtm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_chgjtm] [int] NOT NULL ,
	[cont_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_totamt] [real] NOT NULL ,
	[cont_pubamt] [real] NOT NULL ,
	[cont_chgamt] [real] NOT NULL ,
	[cont_paidamt] [real] NOT NULL ,
	[cont_restamt] [real] NOT NULL ,
	[cont_clrtm] [int] NOT NULL ,
	[cont_menotm] [int] NOT NULL ,
	[cont_getclrtm] [int] NOT NULL ,
	[cont_oldcontno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_irnm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_iraddr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_irzip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_irtel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_irfax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_ircell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_iremail] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgfixpg] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgpayonce] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_lost] (
	[lst_lstid] [int] NOT NULL ,
	[lst_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_rea] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_lprior] (
	[lp_lpid] [int] IDENTITY (1, 1) NOT NULL ,
	[lp_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_priorseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_ltp] (
	[ltp_ltpid] [int] IDENTITY (1, 1) NOT NULL ,
	[ltp_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ltp_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_njtp] (
	[njtp_njtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[njtp_njtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[njtp_nm] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_or] (
	[or_orid] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_nm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_addr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_pubmnt] [int] NOT NULL ,
	[or_unpubmnt] [int] NOT NULL ,
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_pgsize] (
	[pgs_pgsid] [int] IDENTITY (1, 1) NOT NULL ,
	[pgs_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs_nm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c2_pub] (
	[pub_pubid] [int] IDENTITY (1, 1) NOT NULL ,
	[pub_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_date] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pubseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pgno] [int] NOT NULL ,
	[pub_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_adamt] [real] NOT NULL ,
	[pub_chgamt] [real] NOT NULL ,
	[pub_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_origjno] [int] NOT NULL ,
	[pub_origjbkno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_chgjno] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fgrechg] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_njtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fginved] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fginvself] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_remark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_mnt] [int] NOT NULL ,
	[pub_fgfixpg] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_adr] (
	[adr_adrid] [int] IDENTITY (1, 1) NOT NULL ,
	[adr_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_invamt] [real] NOT NULL ,
	[adr_adcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_keyword] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_alttext] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_imgurl] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_navurl] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_urlcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_txtadcont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_txtadcontnm] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_impr] [int] NOT NULL ,
	[adr_fgfixad] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_adamt] [real] NOT NULL ,
	[adr_desamt] [real] NOT NULL ,
	[adr_chgamt] [real] NOT NULL ,
	[adr_remark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fginved] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fginvself] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_cont] (
	[cont_contid] [int] IDENTITY (1, 1) NOT NULL ,
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_conttp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_signdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_empno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_empemail] [char] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_pubcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aunm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_auemail] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_disc] [int] NOT NULL ,
	[cont_freetm] [int] NOT NULL ,
	[cont_tottm] [int] NOT NULL ,
	[cont_pubtm] [int] NOT NULL ,
	[cont_totamt] [real] NOT NULL ,
	[cont_paidamt] [real] NOT NULL ,
	[cont_ccont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_csdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_atp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_matp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_custnm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_custjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_custaddr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_custzip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_irnm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_iraddr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_irzip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_irtel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgclosed] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_adremark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_pdcont] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_freebk] (
	[fbk_fbkid] [int] IDENTITY (1, 1) NOT NULL ,
	[fbk_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fbk_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fbk_fbkitem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fbk_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fbk_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fbk_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fbk_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_lost] (
	[lst_lstid] [int] IDENTITY (1, 1) NOT NULL ,
	[lst_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fbkitem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_rea] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_or] (
	[or_orid] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_nm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_addr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_ramt] (
	[ma_raid] [int] NOT NULL ,
	[ma_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_fbkitem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_pubmnt] [int] NOT NULL ,
	[ma_unpubmnt] [int] NOT NULL ,
	[ma_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_mtpcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_remail] (
	[rm_rmid] [int] IDENTITY (1, 1) NOT NULL ,
	[rm_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_mseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_rtp] (
	[rtp_rtpid] [int] NOT NULL ,
	[rtp_rtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rtp_nm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cust] (
	[cust_custid] [int] IDENTITY (1, 1) NOT NULL ,
	[cust_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_nm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_regdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_itpcd] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_btpcd] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_rtpcd] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ia] (
	[ia_iaid] [int] NOT NULL ,
	[ia_syscd] [varchar] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iasdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iasseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iaitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iano] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_refno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_pyno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_pyseq] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_pyat] [real] NOT NULL ,
	[ia_ivat] [real] NOT NULL ,
	[ia_invno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_invdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_fgitri] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rnm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_raddr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rzip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rtel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_fgnonauto] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[iad] (
	[iad_iadid] [int] NOT NULL ,
	[iad_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_iano] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_iaditem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_fk1] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_fk2] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_fk3] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_fk4] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_desc] [varchar] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_qty] [int] NOT NULL ,
	[iad_unit] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iad_uprice] [real] NOT NULL ,
	[iad_amt] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ias] (
	[ias_iasid] [int] NOT NULL ,
	[ias_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_iasdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_iasseq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_toitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[itp] (
	[itp_itpid] [int] IDENTITY (1, 1) NOT NULL ,
	[itp_itpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[itp_nm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[mailer] (
	[ml_mlid] [int] IDENTITY (1, 1) NOT NULL ,
	[ml_mlcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ml_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[mfr] (
	[mfr_mfrid] [int] IDENTITY (1, 1) NOT NULL ,
	[mfr_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_iaddr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_izip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respnm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respnjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_regdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[mltp] (
	[mltp_mltpid] [int] IDENTITY (1, 1) NOT NULL ,
	[mltp_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mltp_mlcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mltp_mltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[mtp] (
	[mtp_mtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[mtp_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mtp_nm] [char] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pbcatcol] (
	[pbc_tnam] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_tid] [int] NULL ,
	[pbc_ownr] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_cnam] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_cid] [smallint] NULL ,
	[pbc_labl] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_lpos] [smallint] NULL ,
	[pbc_hdr] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_hpos] [smallint] NULL ,
	[pbc_jtfy] [smallint] NULL ,
	[pbc_mask] [varchar] (31) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_case] [smallint] NULL ,
	[pbc_hght] [smallint] NULL ,
	[pbc_wdth] [smallint] NULL ,
	[pbc_ptrn] [varchar] (31) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_bmap] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_init] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_cmnt] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_edit] [varchar] (31) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbc_tag] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pbcatedt] (
	[pbe_name] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbe_edit] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbe_type] [smallint] NOT NULL ,
	[pbe_cntr] [int] NULL ,
	[pbe_seqn] [smallint] NOT NULL ,
	[pbe_flag] [int] NULL ,
	[pbe_work] [char] (32) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pbcatfmt] (
	[pbf_name] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbf_frmt] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbf_type] [smallint] NOT NULL ,
	[pbf_cntr] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pbcattbl] (
	[pbt_tnam] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbt_tid] [int] NULL ,
	[pbt_ownr] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbd_fhgt] [smallint] NULL ,
	[pbd_fwgt] [smallint] NULL ,
	[pbd_fitl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbd_funl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbd_fchr] [smallint] NULL ,
	[pbd_fptc] [smallint] NULL ,
	[pbd_ffce] [char] (32) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbh_fhgt] [smallint] NULL ,
	[pbh_fwgt] [smallint] NULL ,
	[pbh_fitl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbh_funl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbh_fchr] [smallint] NULL ,
	[pbh_fptc] [smallint] NULL ,
	[pbh_ffce] [char] (32) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbl_fhgt] [smallint] NULL ,
	[pbl_fwgt] [smallint] NULL ,
	[pbl_fitl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbl_funl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbl_fchr] [smallint] NULL ,
	[pbl_fptc] [smallint] NULL ,
	[pbl_ffce] [char] (32) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pbt_cmnt] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pbcatvld] (
	[pbv_name] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbv_vald] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbv_type] [smallint] NOT NULL ,
	[pbv_cntr] [int] NULL ,
	[pbv_msg] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[proj] (
	[proj_projid] [int] IDENTITY (1, 1) NOT NULL ,
	[proj_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_cont] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[py] (
	[py_pyid] [int] IDENTITY (1, 1) NOT NULL ,
	[py_pyno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_amt] [real] NOT NULL ,
	[py_pytpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_moseq] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_moitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_chkno] [char] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_chkbnm] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_chkdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_waccno] [char] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_wdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_wbcd] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_ccno] [char] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_cctp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_ccauthcd] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_ccvdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_fgprinted] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pysdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pysseq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pyditem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pyd] (
	[pyd_pydid] [int] IDENTITY (1, 1) NOT NULL ,
	[pyd_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_pyno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_pyditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_invno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pyseq] (
	[pys_pysid] [int] IDENTITY (1, 1) NOT NULL ,
	[pys_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_pysdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_pysseq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_toitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[pytp] (
	[pytp_pytpid] [int] IDENTITY (1, 1) NOT NULL ,
	[pytp_pytpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pytp_nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[refd] (
	[rd_rdid] [int] IDENTITY (1, 1) NOT NULL ,
	[rd_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_accdcr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_descr] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_idescr] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_iunit] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_iremark] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[refm] (
	[rm_rmid] [int] IDENTITY (1, 1) NOT NULL ,
	[rm_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_remark] [varchar] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_deptcd] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_accddr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_idescr] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_iunit] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_iremark] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[sapiv] (
	[iv_orgcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_type] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_seq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_infno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_ref] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_invtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_remark] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_cusno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_title] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_address] [char] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_saleamt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_taxamt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_invoamt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_curr] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_rate] [char] (9) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_prtctl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_postdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_accddr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_attach] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_exptype] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_expremark] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[sapivd] (
	[ivd_infno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iseq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_idescr] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iunit] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iqty] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iuniprice] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iremark] [char] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[sapvou] (
	[vou_infno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_vseq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_accdcr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_costctr] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_contno] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_period] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_amt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_descr] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[vou_alloc] [char] (18) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[srspn] (
	[srspn_id] [int] IDENTITY (1, 1) NOT NULL ,
	[srspn_empno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_cname] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_tel] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_atype] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_orgcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_deptcd] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[syscd] (
	[sys_sysid] [int] IDENTITY (1, 1) NOT NULL ,
	[sys_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[sys_nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[book] WITH NOCHECK ADD 
	CONSTRAINT [PK_Publish] PRIMARY KEY  CLUSTERED 
	(
		[bk_bkid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[bookp] WITH NOCHECK ADD 
	CONSTRAINT [PK_bookp] PRIMARY KEY  CLUSTERED 
	(
		[bkp_bkpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[btp] WITH NOCHECK ADD 
	CONSTRAINT [PK_BusinessType] PRIMARY KEY  CLUSTERED 
	(
		[btp_btpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_cust] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_cust] PRIMARY KEY  CLUSTERED 
	(
		[cust_custid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_lost] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_MailLostBook] PRIMARY KEY  CLUSTERED 
	(
		[lst_lstid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_obtp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_OrderBookType] PRIMARY KEY  CLUSTERED 
	(
		[obtp_obtpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_od] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_od] PRIMARY KEY  CLUSTERED 
	(
		[od_syscd],
		[od_custno],
		[od_otp1cd],
		[od_otp1seq],
		[od_oditem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_Receiver] PRIMARY KEY  CLUSTERED 
	(
		[or_orid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_order] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_order] PRIMARY KEY  CLUSTERED 
	(
		[o_syscd],
		[o_custno],
		[o_otp1cd],
		[o_otp1seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_otp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_otp] PRIMARY KEY  CLUSTERED 
	(
		[otp_otpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_ramt] WITH NOCHECK ADD 
	CONSTRAINT [PK_MailAmount] PRIMARY KEY  CLUSTERED 
	(
		[ra_raid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_remail] WITH NOCHECK ADD 
	CONSTRAINT [PK_ReMailBook] PRIMARY KEY  CLUSTERED 
	(
		[rm_rmid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_clr] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_ADColor] PRIMARY KEY  CLUSTERED 
	(
		[clr_clrid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_cont] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_Contract] PRIMARY KEY  CLUSTERED 
	(
		[cont_contid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_lost] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_lost] PRIMARY KEY  CLUSTERED 
	(
		[lst_lstid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_lprior] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_lprior] PRIMARY KEY  CLUSTERED 
	(
		[lp_lpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_ltp] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_LayoutType] PRIMARY KEY  CLUSTERED 
	(
		[ltp_ltpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_njtp] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_NewJourType] PRIMARY KEY  CLUSTERED 
	(
		[njtp_njtpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_or] PRIMARY KEY  CLUSTERED 
	(
		[or_orid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_pgsize] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_pgsize] PRIMARY KEY  CLUSTERED 
	(
		[pgs_pgsid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_pub] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_Publish] PRIMARY KEY  CLUSTERED 
	(
		[pub_pubid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_adr] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_adr] PRIMARY KEY  CLUSTERED 
	(
		[adr_adrid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_cont] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_cont_1] PRIMARY KEY  CLUSTERED 
	(
		[cont_contid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_freebk] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_freebk] PRIMARY KEY  CLUSTERED 
	(
		[fbk_fbkid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_lost] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_lost] PRIMARY KEY  CLUSTERED 
	(
		[lst_lstid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_or] PRIMARY KEY  CLUSTERED 
	(
		[or_orid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_remail] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_remail] PRIMARY KEY  CLUSTERED 
	(
		[rm_rmid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cust] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_Customer] PRIMARY KEY  CLUSTERED 
	(
		[cust_custid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[itp] WITH NOCHECK ADD 
	CONSTRAINT [PK_IndCode] PRIMARY KEY  CLUSTERED 
	(
		[itp_itpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mailer] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_Mailer] PRIMARY KEY  CLUSTERED 
	(
		[ml_mlid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mfr] WITH NOCHECK ADD 
	CONSTRAINT [PK_Mfr] PRIMARY KEY  CLUSTERED 
	(
		[mfr_mfrid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mltp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_MLTp] PRIMARY KEY  CLUSTERED 
	(
		[mltp_mltpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mtp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_MailType] PRIMARY KEY  CLUSTERED 
	(
		[mtp_mtpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[proj] WITH NOCHECK ADD 
	CONSTRAINT [PK_Proj] PRIMARY KEY  CLUSTERED 
	(
		[proj_syscd],
		[proj_bkcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[py] WITH NOCHECK ADD 
	CONSTRAINT [PK_Payment] PRIMARY KEY  CLUSTERED 
	(
		[py_pyid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[pyd] WITH NOCHECK ADD 
	CONSTRAINT [PK_pyd] PRIMARY KEY  CLUSTERED 
	(
		[pyd_pydid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[pyseq] WITH NOCHECK ADD 
	CONSTRAINT [PK_pyseq] PRIMARY KEY  CLUSTERED 
	(
		[pys_pysid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[pytp] WITH NOCHECK ADD 
	CONSTRAINT [PK_PaymentMethod] PRIMARY KEY  CLUSTERED 
	(
		[pytp_pytpid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[refd] WITH NOCHECK ADD 
	CONSTRAINT [pkrefd] PRIMARY KEY  CLUSTERED 
	(
		[rd_syscd],
		[rd_projno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[refm] WITH NOCHECK ADD 
	CONSTRAINT [pkrefm] PRIMARY KEY  CLUSTERED 
	(
		[rm_syscd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sapiv] WITH NOCHECK ADD 
	CONSTRAINT [pksapiv] PRIMARY KEY  CLUSTERED 
	(
		[iv_orgcd],
		[iv_infno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sapivd] WITH NOCHECK ADD 
	CONSTRAINT [pksapivd] PRIMARY KEY  CLUSTERED 
	(
		[ivd_infno],
		[ivd_iseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sapvou] WITH NOCHECK ADD 
	CONSTRAINT [pksapvou] PRIMARY KEY  CLUSTERED 
	(
		[vou_infno],
		[vou_vseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[srspn] WITH NOCHECK ADD 
	CONSTRAINT [PK_srspn] PRIMARY KEY  CLUSTERED 
	(
		[srspn_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[syscd] WITH NOCHECK ADD 
	CONSTRAINT [PK_SystemCode] PRIMARY KEY  CLUSTERED 
	(
		[sys_sysid]
	)  ON [PRIMARY] 
GO

 CREATE  UNIQUE  CLUSTERED  INDEX [pbcatedt_idx] ON [dbo].[pbcatedt]([pbe_name], [pbe_seqn]) ON [PRIMARY]
GO

 CREATE  UNIQUE  CLUSTERED  INDEX [pbcatfmt_idx] ON [dbo].[pbcatfmt]([pbf_name]) ON [PRIMARY]
GO

 CREATE  UNIQUE  CLUSTERED  INDEX [pbcatvld_idx] ON [dbo].[pbcatvld]([pbv_name]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[c1_cust] WITH NOCHECK ADD 
	CONSTRAINT [DF_1_cust_cust_custno] DEFAULT ('') FOR [cust_custno],
	CONSTRAINT [DF_1_cust_cust_nm] DEFAULT ('') FOR [cust_nm],
	CONSTRAINT [DF_1_cust_cust_jbti] DEFAULT ('') FOR [cust_jbti],
	CONSTRAINT [DF_1_cust_cust_mfrno] DEFAULT ('') FOR [cust_mfrno],
	CONSTRAINT [DF_1_cust_cust_tel] DEFAULT ('') FOR [cust_tel],
	CONSTRAINT [DF_1_cust_cust_fax] DEFAULT ('') FOR [cust_fax],
	CONSTRAINT [DF_1_cust_cust_cell] DEFAULT ('') FOR [cust_cell],
	CONSTRAINT [DF_1_cust_cust_email] DEFAULT ('') FOR [cust_email],
	CONSTRAINT [DF_1_cust_cust_regdate] DEFAULT ('') FOR [cust_regdate],
	CONSTRAINT [DF_1_cust_cust_moddate] DEFAULT ('') FOR [cust_moddate],
	CONSTRAINT [DF_1_cust_cust_fgoi] DEFAULT ('0') FOR [cust_fgoi],
	CONSTRAINT [DF_1_cust_cust_fgoe] DEFAULT ('0') FOR [cust_fgoe],
	CONSTRAINT [DF_1_cust_cust_otp1seq1] DEFAULT ('') FOR [cust_otp1seq1],
	CONSTRAINT [DF_1_cust_cust_otp1seq2] DEFAULT ('') FOR [cust_otp1seq2],
	CONSTRAINT [DF_1_cust_cust_otp1seq3] DEFAULT ('') FOR [cust_otp1seq3],
	CONSTRAINT [DF_1_cust_cust_otp1seq9] DEFAULT ('') FOR [cust_otp1seq9],
	CONSTRAINT [DF_1_cust_cust_itpcd] DEFAULT ('') FOR [cust_itpcd],
	CONSTRAINT [DF_1_cust_cust_btpcd] DEFAULT ('') FOR [cust_btpcd]
GO

ALTER TABLE [dbo].[c1_od] WITH NOCHECK ADD 
	CONSTRAINT [DF_1_od_od_remark] DEFAULT ('') FOR [od_remark]
GO

 CREATE  UNIQUE  INDEX [pbcatcol_idx] ON [dbo].[pbcatcol]([pbc_tnam], [pbc_ownr], [pbc_cnam]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pbcattbl_idx] ON [dbo].[pbcattbl]([pbt_tnam], [pbt_ownr]) ON [PRIMARY]
GO

 CREATE  INDEX [idsapiv1] ON [dbo].[sapiv]([iv_orgcd], [iv_type], [iv_yyyymm], [iv_seq]) ON [PRIMARY]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[book]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[book]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[bookp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[bookp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[btp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[btp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_cust]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_cust]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_lost]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_lost]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_obtp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_obtp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_od]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_od]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_or]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_order]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_order]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ores]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ores]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_otp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_otp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ramt]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ramt]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_remail]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_remail]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_clr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_clr]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_cont]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_cont]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lost]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lost]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lprior]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lprior]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_ltp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_ltp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_njtp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_njtp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_or]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pgsize]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pgsize]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pub]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pub]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_adr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_adr]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_cont]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_cont]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_freebk]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_freebk]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_lost]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_lost]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_or]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_ramt]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_ramt]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_remail]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_remail]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_rtp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_rtp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[cust]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[cust]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ia]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ia]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[iad]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[iad]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ias]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ias]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[itp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[itp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mailer]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mailer]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mfr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mfr]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mltp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mltp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mtp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mtp]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatcol]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatcol]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatcol]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatedt]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatedt]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatedt]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatfmt]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatfmt]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatfmt]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcattbl]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcattbl]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcattbl]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatvld]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatvld]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatvld]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[proj]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[py]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[py]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyd]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyd]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyseq]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyseq]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pytp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pytp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refd]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refm]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapiv]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapiv]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapivd]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapivd]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapvou]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapvou]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[srspn]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[srspn]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[syscd]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[syscd]  TO [mrlpub]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.otp1
AS
SELECT DISTINCT otp_otp1cd, otp_otp1nm
FROM             dbo.[1_otp]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[1_otp1_v]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[1_otp1_v]  TO [mrlpub]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.[1_o_detail_v]
AS
SELECT         dbo.[1_order].o_custno, dbo.[1_order].o_mfrno, dbo.[1_order].o_inm, 
                          dbo.[1_order].o_ijbti, dbo.pytp.pytp_nm, dbo.[1_order].o_otp1seq, 
                          dbo.[1_od].od_oditem, dbo.[1_od].od_sdate, dbo.[1_od].od_edate, 
                          dbo.[1_obtp].obtp_obtpnm, dbo.[1_od].od_projno, dbo.[1_od].od_amt, 
                          dbo.[1_otp1_v].otp_otp1nm, dbo.[1_otp].otp_otp2nm
FROM             dbo.[1_order] INNER JOIN
                          dbo.[1_od] ON dbo.[1_order].o_custno = dbo.[1_od].od_custno AND 
                          dbo.[1_order].o_syscd = dbo.[1_od].od_syscd AND 
                          dbo.[1_order].o_otp1cd = dbo.[1_od].od_otp1cd AND 
                          dbo.[1_order].o_otp1seq = dbo.[1_od].od_otp1seq INNER JOIN
                          dbo.pytp ON dbo.[1_order].o_pytpcd = dbo.pytp.pytp_pytpcd INNER JOIN
                          dbo.[1_otp1_v] ON 
                          dbo.[1_order].o_otp1cd = dbo.[1_otp1_v].otp_otp1cd INNER JOIN
                          dbo.[1_otp] ON dbo.[1_order].o_otp2cd = dbo.[1_otp].otp_otp2cd AND 
                          dbo.[1_order].o_otp1cd = dbo.[1_otp].otp_otp1cd INNER JOIN
                          dbo.[1_obtp] ON dbo.[1_od].od_otp1cd = dbo.[1_obtp].obtp_otp1cd AND 
                          dbo.[1_od].od_btpcd = dbo.[1_obtp].obtp_obtpcd

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[1_o_detail_v]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[1_o_detail_v]  TO [mrlpub]
GO

