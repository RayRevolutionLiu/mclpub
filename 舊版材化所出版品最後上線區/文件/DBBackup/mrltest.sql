/****** Object:  Database mrltest    Script Date: 2002/7/6 上午 11:20:47 ******/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'mrltest')
	DROP DATABASE [mrltest]
GO

CREATE DATABASE [mrltest]  ON (NAME = N'mrltest_Data', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL\data\mrltest_Data.MDF' , SIZE = 73, MAXSIZE = 80, FILEGROWTH = 10%) LOG ON (NAME = N'mrltest_Log', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL\data\mrltest_Log.LDF' , SIZE = 51, FILEGROWTH = 10%)
 COLLATE Chinese_Taiwan_Stroke_CI_AS
GO

exec sp_dboption N'mrltest', N'autoclose', N'false'
GO

exec sp_dboption N'mrltest', N'bulkcopy', N'false'
GO

exec sp_dboption N'mrltest', N'trunc. log', N'false'
GO

exec sp_dboption N'mrltest', N'torn page detection', N'true'
GO

exec sp_dboption N'mrltest', N'read only', N'false'
GO

exec sp_dboption N'mrltest', N'dbo use', N'false'
GO

exec sp_dboption N'mrltest', N'single', N'false'
GO

exec sp_dboption N'mrltest', N'autoshrink', N'false'
GO

exec sp_dboption N'mrltest', N'ANSI null default', N'false'
GO

exec sp_dboption N'mrltest', N'recursive triggers', N'false'
GO

exec sp_dboption N'mrltest', N'ANSI nulls', N'false'
GO

exec sp_dboption N'mrltest', N'concat null yields null', N'false'
GO

exec sp_dboption N'mrltest', N'cursor close on commit', N'false'
GO

exec sp_dboption N'mrltest', N'default to local cursor', N'false'
GO

exec sp_dboption N'mrltest', N'quoted identifier', N'false'
GO

exec sp_dboption N'mrltest', N'ANSI warnings', N'false'
GO

exec sp_dboption N'mrltest', N'auto create statistics', N'true'
GO

exec sp_dboption N'mrltest', N'auto update statistics', N'true'
GO

use [mrltest]
GO

/****** Object:  User Defined Function dbo.fn_c2_contAll    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_contAll]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_contAll]
GO

/****** Object:  User Defined Function dbo.fn_c2_contBasic    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_contBasic]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_contBasic]
GO

/****** Object:  User Defined Function dbo.fn_c1_od    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c1_od]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c1_od]
GO

/****** Object:  User Defined Function dbo.fn_c1_or    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c1_or]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c1_or]
GO

/****** Object:  User Defined Function dbo.fn_c1_order    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c1_order]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c1_order]
GO

/****** Object:  User Defined Function dbo.fn_c2_cust    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_cust]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_cust]
GO

/****** Object:  User Defined Function dbo.fn_c2_im    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_im]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_im]
GO

/****** Object:  User Defined Function dbo.fn_c2_mfr    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_mfr]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_mfr]
GO

/****** Object:  User Defined Function dbo.fn_c2_or    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_or]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_or]
GO

/****** Object:  User Defined Function dbo.fn_c2_pub    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_pub]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_pub]
GO

/****** Object:  User Defined Function dbo.fn_c2_pubEmpty    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c2_pubEmpty]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c2_pubEmpty]
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_004    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2trans_004]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2trans_004]
GO

/****** Object:  Stored Procedure dbo.sp_c1_0clear_c1cust_4seq    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_0clear_c1cust_4seq]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_0clear_c1cust_4seq]
GO

/****** Object:  Stored Procedure dbo.sp_c1_0trans_ready    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_0trans_ready]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_0trans_ready]
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_001    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_1trans_001]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_1trans_001]
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_002    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_1trans_002]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_1trans_002]
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_003    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_1trans_003]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_1trans_003]
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_004    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_1trans_004]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_1trans_004]
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_005    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_1trans_005]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_1trans_005]
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_001    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_2trans_001]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_2trans_001]
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_002    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_2trans_002]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_2trans_002]
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_003    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_2trans_003]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_2trans_003]
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_004    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_2trans_004]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_2trans_004]
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_005    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_2trans_005]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_2trans_005]
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_006    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_2trans_006]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_2trans_006]
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_007    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_2trans_007]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_2trans_007]
GO

/****** Object:  Stored Procedure dbo.sp_c1_order    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_order]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_order]
GO

/****** Object:  Stored Procedure dbo.sp_c2_xml_call_fns    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_xml_call_fns]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_xml_call_fns]
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_001    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2trans_001]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2trans_001]
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_002    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2trans_002]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2trans_002]
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_003    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2trans_003]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2trans_003]
GO

/****** Object:  View dbo.v_t2_pub    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_t2_pub]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_t2_pub]
GO

/****** Object:  Table [dbo].[Results]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Results]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Results]
GO

/****** Object:  Table [dbo].[Sheet1$]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sheet1$]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Sheet1$]
GO

/****** Object:  Table [dbo].[Sheet2$]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sheet2$]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Sheet2$]
GO

/****** Object:  Table [dbo].[WebMember]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WebMember]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[WebMember]
GO

/****** Object:  Table [dbo].[WebMember_ori]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WebMember_ori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[WebMember_ori]
GO

/****** Object:  Table [dbo].[book]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[book]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[book]
GO

/****** Object:  Table [dbo].[bookp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bookp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bookp]
GO

/****** Object:  Table [dbo].[btp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[btp]
GO

/****** Object:  Table [dbo].[c1_1_delete]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_1_delete]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_1_delete]
GO

/****** Object:  Table [dbo].[c1_2_delete]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_2_delete]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_2_delete]
GO

/****** Object:  Table [dbo].[c1_cust]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_cust]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_cust]
GO

/****** Object:  Table [dbo].[c1_lost]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_lost]
GO

/****** Object:  Table [dbo].[c1_obtp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_obtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_obtp]
GO

/****** Object:  Table [dbo].[c1_od]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_od]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_od]
GO

/****** Object:  Table [dbo].[c1_or]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_or]
GO

/****** Object:  Table [dbo].[c1_order]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_order]
GO

/****** Object:  Table [dbo].[c1_order_special]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_order_special]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_order_special]
GO

/****** Object:  Table [dbo].[c1_ores]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_ores]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_ores]
GO

/****** Object:  Table [dbo].[c1_otp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_otp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_otp]
GO

/****** Object:  Table [dbo].[c1_ramt]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_ramt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_ramt]
GO

/****** Object:  Table [dbo].[c1_remail]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_remail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_remail]
GO

/****** Object:  Table [dbo].[c2_clr]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_clr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_clr]
GO

/****** Object:  Table [dbo].[c2_cont]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_cont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_cont]
GO

/****** Object:  Table [dbo].[c2_lost]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_lost]
GO

/****** Object:  Table [dbo].[c2_lprior]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_lprior]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_lprior]
GO

/****** Object:  Table [dbo].[c2_ltp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_ltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_ltp]
GO

/****** Object:  Table [dbo].[c2_njtp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_njtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_njtp]
GO

/****** Object:  Table [dbo].[c2_or]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_or]
GO

/****** Object:  Table [dbo].[c2_pgsize]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pgsize]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pgsize]
GO

/****** Object:  Table [dbo].[c2_pub]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pub]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pub]
GO

/****** Object:  Table [dbo].[cust]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cust]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cust]
GO

/****** Object:  Table [dbo].[hicard]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[hicard]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[hicard]
GO

/****** Object:  Table [dbo].[ia]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ia]
GO

/****** Object:  Table [dbo].[iad]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iad]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[iad]
GO

/****** Object:  Table [dbo].[ias]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ias]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ias]
GO

/****** Object:  Table [dbo].[inftmp20]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[inftmp20]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[inftmp20]
GO

/****** Object:  Table [dbo].[inv20]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[inv20]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[inv20]
GO

/****** Object:  Table [dbo].[invmfr]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[invmfr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[invmfr]
GO

/****** Object:  Table [dbo].[itp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[itp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[itp]
GO

/****** Object:  Table [dbo].[mailer]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mailer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mailer]
GO

/****** Object:  Table [dbo].[mfr]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mfr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mfr]
GO

/****** Object:  Table [dbo].[mfr1a]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mfr1a]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mfr1a]
GO

/****** Object:  Table [dbo].[mfr_imr]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mfr_imr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mfr_imr]
GO

/****** Object:  Table [dbo].[mltp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mltp]
GO

/****** Object:  Table [dbo].[mtp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mtp]
GO

/****** Object:  Table [dbo].[or_trans_test]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[or_trans_test]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[or_trans_test]
GO

/****** Object:  Table [dbo].[pbcatcol]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatcol]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatcol]
GO

/****** Object:  Table [dbo].[pbcatedt]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatedt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatedt]
GO

/****** Object:  Table [dbo].[pbcatfmt]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatfmt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatfmt]
GO

/****** Object:  Table [dbo].[pbcattbl]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcattbl]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcattbl]
GO

/****** Object:  Table [dbo].[pbcatvld]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatvld]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatvld]
GO

/****** Object:  Table [dbo].[proj]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proj]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[proj]
GO

/****** Object:  Table [dbo].[py]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[py]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[py]
GO

/****** Object:  Table [dbo].[pyd]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pyd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pyd]
GO

/****** Object:  Table [dbo].[pyseq]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pyseq]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pyseq]
GO

/****** Object:  Table [dbo].[pytp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pytp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pytp]
GO

/****** Object:  Table [dbo].[refd]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[refd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[refd]
GO

/****** Object:  Table [dbo].[refm]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[refm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[refm]
GO

/****** Object:  Table [dbo].[retn_imr]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[retn_imr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[retn_imr]
GO

/****** Object:  Table [dbo].[rtp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[rtp]
GO

/****** Object:  Table [dbo].[sapiv]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapiv]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapiv]
GO

/****** Object:  Table [dbo].[sapivd]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapivd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapivd]
GO

/****** Object:  Table [dbo].[saplog]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[saplog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[saplog]
GO

/****** Object:  Table [dbo].[sapvou]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapvou]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapvou]
GO

/****** Object:  Table [dbo].[srspn]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[srspn]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[srspn]
GO

/****** Object:  Table [dbo].[syscd]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[syscd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[syscd]
GO

/****** Object:  Table [dbo].[t2_bookp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_bookp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_bookp]
GO

/****** Object:  Table [dbo].[t2_btp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_btp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_btp]
GO

/****** Object:  Table [dbo].[t2_clr]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_clr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_clr]
GO

/****** Object:  Table [dbo].[t2_cont]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_cont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_cont]
GO

/****** Object:  Table [dbo].[t2_cust]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_cust]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_cust]
GO

/****** Object:  Table [dbo].[t2_ia]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_ia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_ia]
GO

/****** Object:  Table [dbo].[t2_itp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_itp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_itp]
GO

/****** Object:  Table [dbo].[t2_ltp]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_ltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_ltp]
GO

/****** Object:  Table [dbo].[t2_or]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_or]
GO

/****** Object:  Table [dbo].[t2_pub]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_pub]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_pub]
GO

/****** Object:  Table [dbo].[t2_pub_orig]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_pub_orig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_pub_orig]
GO

/****** Object:  Table [dbo].[t2_security]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t2_security]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t2_security]
GO

/****** Object:  Table [dbo].[t_class1]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_class1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_class1]
GO

/****** Object:  Table [dbo].[t_class2]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_class2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_class2]
GO

/****** Object:  Table [dbo].[t_cono]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_cono]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_cono]
GO

/****** Object:  Table [dbo].[t_cono_e]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_cono_e]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_cono_e]
GO

/****** Object:  Table [dbo].[t_imr0506v5]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_imr0506v5]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_imr0506v5]
GO

/****** Object:  Table [dbo].[t_imr1]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_imr1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_imr1]
GO

/****** Object:  Table [dbo].[t_imr2]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_imr2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_imr2]
GO

/****** Object:  Table [dbo].[t_imr20508v5]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_imr20508v5]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_imr20508v5]
GO

/****** Object:  Table [dbo].[t_order_2]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_order_2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_order_2]
GO

/****** Object:  Table [dbo].[t_pb1]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pb1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pb1]
GO

/****** Object:  Table [dbo].[t_pb1b]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pb1b]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pb1b]
GO

/****** Object:  Table [dbo].[t_pb2]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pb2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pb2]
GO

/****** Object:  Table [dbo].[t_pb2_copy]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pb2_copy]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pb2_copy]
GO

/****** Object:  Table [dbo].[t_pb2a]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pb2a]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pb2a]
GO

/****** Object:  Table [dbo].[t_pbupd1]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pbupd1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pbupd1]
GO

/****** Object:  Table [dbo].[t_pbupd1a]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pbupd1a]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pbupd1a]
GO

/****** Object:  Table [dbo].[t_pbupd1b]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pbupd1b]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pbupd1b]
GO

/****** Object:  Table [dbo].[t_pbupd2]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pbupd2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pbupd2]
GO

/****** Object:  Table [dbo].[t_pbupd2_0502]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_pbupd2_0502]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_pbupd2_0502]
GO

/****** Object:  Table [dbo].[t_type1]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_type1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_type1]
GO

/****** Object:  Table [dbo].[t_type2]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_type2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_type2]
GO

/****** Object:  Table [dbo].[t_use_cono]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_use_cono]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_use_cono]
GO

/****** Object:  Table [dbo].[t_use_order]    Script Date: 2002/7/6 上午 11:21:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[t_use_order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[t_use_order]
GO

/****** Object:  Login mrlpub    Script Date: 2002/7/6 上午 11:20:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'mrlpub')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'mrltest1', @loginlang = N'繁體中文'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'mrlpub', null, @logindb, @loginlang
END
GO

/****** Object:  Login test    Script Date: 2002/7/6 上午 11:20:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'test')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'繁體中文'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'test', null, @logindb, @loginlang
END
GO

/****** Object:  Login uclmis    Script Date: 2002/7/6 上午 11:20:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'uclmis')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'iwcom', @loginlang = N'繁體中文'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'uclmis', null, @logindb, @loginlang
END
GO

/****** Object:  Login webuser    Script Date: 2002/7/6 上午 11:20:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'webuser')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'common', @loginlang = N'繁體中文'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'webuser', null, @logindb, @loginlang
END
GO

/****** Object:  User dbo    Script Date: 2002/7/6 上午 11:20:48 ******/
/****** Object:  User mrlpub    Script Date: 2002/7/6 上午 11:20:48 ******/
if not exists (select * from dbo.sysusers where name = N'mrlpub' and uid < 16382)
	EXEC sp_grantdbaccess N'mrlpub', N'mrlpub'
GO

GRANT  CREATE FUNCTION ,  CREATE TABLE ,  CREATE VIEW ,  CREATE PROCEDURE ,  CREATE DEFAULT ,  CREATE RULE  TO [mrlpub]
GO

/****** Object:  User test    Script Date: 2002/7/6 上午 11:20:48 ******/
if not exists (select * from dbo.sysusers where name = N'test' and uid < 16382)
	EXEC sp_grantdbaccess N'test', N'test'
GO

/****** Object:  User webuser    Script Date: 2002/7/6 上午 11:20:48 ******/
if not exists (select * from dbo.sysusers where name = N'webuser' and uid < 16382)
	EXEC sp_grantdbaccess N'webuser', N'webuser'
GO

GRANT  CREATE TABLE ,  CREATE VIEW ,  CREATE PROCEDURE ,  CREATE DEFAULT ,  CREATE RULE  TO [webuser]
GO

/****** Object:  User test    Script Date: 2002/7/6 上午 11:20:48 ******/
exec sp_addrolemember N'db_datareader', N'test'
GO

/****** Object:  User mrlpub    Script Date: 2002/7/6 上午 11:20:48 ******/
exec sp_addrolemember N'db_owner', N'mrlpub'
GO

/****** Object:  User webuser    Script Date: 2002/7/6 上午 11:20:48 ******/
exec sp_addrolemember N'db_owner', N'webuser'
GO

/****** Object:  Table [dbo].[Results]    Script Date: 2002/7/6 上午 11:21:50 ******/
CREATE TABLE [dbo].[Results] (
	[o_oid] [int] NOT NULL ,
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

/****** Object:  Table [dbo].[Sheet1$]    Script Date: 2002/7/6 上午 11:21:59 ******/
CREATE TABLE [dbo].[Sheet1$] (
	[F1] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_syscd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_contno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_conttp] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_bkcd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_signdate] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_empno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_mfrno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_aunm] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_autel] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_aufax] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_aucell] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_auemail] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_sdate] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_edate] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_totjtm] [float] NULL ,
	[cont_madejtm] [float] NULL ,
	[cont_restjtm] [float] NULL ,
	[cont_disc] [float] NULL ,
	[cont_freetm] [float] NULL ,
	[cont_fgclosed] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_tottm] [float] NULL ,
	[cont_pubtm] [float] NULL ,
	[cont_resttm] [float] NULL ,
	[cont_chgjtm] [float] NULL ,
	[cont_custno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_totamt] [float] NULL ,
	[cont_pubamt] [float] NULL ,
	[cont_chgamt] [float] NULL ,
	[cont_paidamt] [float] NULL ,
	[cont_restamt] [float] NULL ,
	[cont_clrtm] [float] NULL ,
	[cont_menotm] [float] NULL ,
	[cont_getclrtm] [float] NULL ,
	[cont_oldcontno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_moddate] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_fgpayonce] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_modempno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_inm] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_iaddr] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_izip] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_respnm] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_respjbti] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_tel] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_fax] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[mfr_regdate] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_nm] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_jbti] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_mfrno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_tel] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_fax] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_cell] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_email] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_regdate] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_moddate] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_itpcd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_btpcd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_rtpcd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_oldcustno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cust_origsyscd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_oritem] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_inm] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_nm] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_jbti] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_addr] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_zip] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_tel] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_fax] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_cell] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_email] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_mtpcd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[or_pubcnt] [float] NULL ,
	[or_unpubcnt] [float] NULL ,
	[or_fgmosea] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_imseq] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_mfrno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_nm] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_jbti] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_zip] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_addr] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_tel] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_fax] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_cell] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_email] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_invcd] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_taxtp] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[im_fgitri] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sheet2$]    Script Date: 2002/7/6 上午 11:22:00 ******/
CREATE TABLE [dbo].[Sheet2$] (
	[aa] [nvarchar] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[orderno] [nvarchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[order_date_e] [nvarchar] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[order_date_b] [nvarchar] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[amt] [float] NULL ,
	[remark] [nvarchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[choice] [nvarchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[update_temp] [nvarchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[o_date] [nvarchar] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[name] [nvarchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[title] [nvarchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cono] [nvarchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[co] [nvarchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[address] [nvarchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[WebMember]    Script Date: 2002/7/6 上午 11:22:01 ******/
CREATE TABLE [dbo].[WebMember] (
	[userid] [varchar] (15) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[password] [varchar] (9) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ssn] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[company] [varchar] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[address] [varchar] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[job_title] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[department] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[email] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[tel] [varchar] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fax_no] [varchar] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_head] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_addr] [varchar] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_no] [varchar] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[job_class] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[register_date] [datetime] NULL ,
	[terminate_date] [datetime] NULL ,
	[start_date] [datetime] NULL ,
	[basic_fee] [int] NULL ,
	[pre_pay] [int] NULL ,
	[spend] [int] NULL ,
	[remark] [varchar] (128) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[news] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_date] [datetime] NULL ,
	[mem_from] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[ipcontrol] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[web_id] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[WebMember_ori]    Script Date: 2002/7/6 上午 11:22:02 ******/
CREATE TABLE [dbo].[WebMember_ori] (
	[userid] [varchar] (15) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[password] [varchar] (9) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ssn] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[company] [varchar] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[address] [varchar] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[job_title] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[department] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[email] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[tel] [varchar] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fax_no] [varchar] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_head] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_addr] [varchar] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_no] [varchar] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[job_class] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[register_date] [datetime] NULL ,
	[terminate_date] [datetime] NULL ,
	[start_date] [datetime] NULL ,
	[basic_fee] [int] NULL ,
	[pre_pay] [int] NULL ,
	[spend] [int] NULL ,
	[remark] [varchar] (128) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[news] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_date] [datetime] NULL ,
	[mem_from] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[ipcontrol] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[web_id] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[book]    Script Date: 2002/7/6 上午 11:22:03 ******/
CREATE TABLE [dbo].[book] (
	[bk_bkid] [int] IDENTITY (1, 1) NOT NULL ,
	[bk_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bk_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[bookp]    Script Date: 2002/7/6 上午 11:22:04 ******/
CREATE TABLE [dbo].[bookp] (
	[bkp_bkpid] [int] IDENTITY (1, 1) NOT NULL ,
	[bkp_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkp_date] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkp_pno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[btp]    Script Date: 2002/7/6 上午 11:22:05 ******/
CREATE TABLE [dbo].[btp] (
	[btp_btpid] [int] IDENTITY (1, 1) NOT NULL ,
	[btp_btpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[btp_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_1_delete]    Script Date: 2002/7/6 上午 11:22:05 ******/
CREATE TABLE [dbo].[c1_1_delete] (
	[orderno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[delete_mark] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_2_delete]    Script Date: 2002/7/6 上午 11:22:06 ******/
CREATE TABLE [dbo].[c1_2_delete] (
	[orderno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[delete_mark] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_cust]    Script Date: 2002/7/6 上午 11:22:07 ******/
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
	[cust_itpcd] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_btpcd] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_oldcustno1] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_oldcustno2] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_lost]    Script Date: 2002/7/6 上午 11:22:09 ******/
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

/****** Object:  Table [dbo].[c1_obtp]    Script Date: 2002/7/6 上午 11:22:10 ******/
CREATE TABLE [dbo].[c1_obtp] (
	[obtp_obtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[obtp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpnm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_od]    Script Date: 2002/7/6 上午 11:22:10 ******/
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

/****** Object:  Table [dbo].[c1_or]    Script Date: 2002/7/6 上午 11:22:11 ******/
CREATE TABLE [dbo].[c1_or] (
	[or_orid] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_inm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_nm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_addr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_order]    Script Date: 2002/7/6 上午 11:22:13 ******/
CREATE TABLE [dbo].[c1_order] (
	[o_oid] [int] IDENTITY (1, 1) NOT NULL ,
	[o_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp2cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_inm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_ijbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_iaddr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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
	[o_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_cancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_indate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_iano] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_special] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_order_special]    Script Date: 2002/7/6 上午 11:22:15 ******/
CREATE TABLE [dbo].[c1_order_special] (
	[o_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_ores]    Script Date: 2002/7/6 上午 11:22:15 ******/
CREATE TABLE [dbo].[c1_ores] (
	[ores_oresid] [int] IDENTITY (1, 1) NOT NULL ,
	[ores_orescd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ores_oresnm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_otp]    Script Date: 2002/7/6 上午 11:22:16 ******/
CREATE TABLE [dbo].[c1_otp] (
	[otp_otpid] [int] IDENTITY (1, 1) NOT NULL ,
	[otp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp1nm] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp2cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp2nm] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_ramt]    Script Date: 2002/7/6 上午 11:22:17 ******/
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

/****** Object:  Table [dbo].[c1_remail]    Script Date: 2002/7/6 上午 11:22:18 ******/
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

/****** Object:  Table [dbo].[c2_clr]    Script Date: 2002/7/6 上午 11:22:19 ******/
CREATE TABLE [dbo].[c2_clr] (
	[clr_clrid] [int] IDENTITY (1, 1) NOT NULL ,
	[clr_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clr_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_cont]    Script Date: 2002/7/6 上午 11:22:20 ******/
CREATE TABLE [dbo].[c2_cont] (
	[cont_contid] [int] IDENTITY (1, 1) NOT NULL ,
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_conttp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_signdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aunm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_auemail] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_totjtm] [int] NOT NULL ,
	[cont_madejtm] [int] NOT NULL ,
	[cont_restjtm] [int] NOT NULL ,
	[cont_disc] [real] NOT NULL ,
	[cont_freetm] [int] NOT NULL ,
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
	[cont_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgpayonce] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_xmldata] [ntext] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_modempno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_lost]    Script Date: 2002/7/6 上午 11:22:23 ******/
CREATE TABLE [dbo].[c2_lost] (
	[lst_lstid] [int] IDENTITY (1, 1) NOT NULL ,
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

/****** Object:  Table [dbo].[c2_lprior]    Script Date: 2002/7/6 上午 11:22:24 ******/
CREATE TABLE [dbo].[c2_lprior] (
	[lp_lpid] [int] IDENTITY (1, 1) NOT NULL ,
	[lp_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_priorseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_ltp]    Script Date: 2002/7/6 上午 11:22:25 ******/
CREATE TABLE [dbo].[c2_ltp] (
	[ltp_ltpid] [int] IDENTITY (1, 1) NOT NULL ,
	[ltp_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ltp_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_njtp]    Script Date: 2002/7/6 上午 11:22:26 ******/
CREATE TABLE [dbo].[c2_njtp] (
	[njtp_njtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[njtp_njtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[njtp_nm] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_or]    Script Date: 2002/7/6 上午 11:22:27 ******/
CREATE TABLE [dbo].[c2_or] (
	[or_orid] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_inm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_addr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_pubcnt] [int] NOT NULL ,
	[or_unpubcnt] [int] NOT NULL ,
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_pgsize]    Script Date: 2002/7/6 上午 11:22:28 ******/
CREATE TABLE [dbo].[c2_pgsize] (
	[pgs_pgsid] [int] IDENTITY (1, 1) NOT NULL ,
	[pgs_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs_nm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_pub]    Script Date: 2002/7/6 上午 11:22:29 ******/
CREATE TABLE [dbo].[c2_pub] (
	[pub_pubid] [int] IDENTITY (1, 1) NOT NULL ,
	[pub_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pubseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pgno] [int] NOT NULL ,
	[pub_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_adamt] [real] NOT NULL ,
	[pub_chgamt] [real] NOT NULL ,
	[pub_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_origbkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_origjno] [int] NOT NULL ,
	[pub_origjbkno] [int] NOT NULL ,
	[pub_chgbkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_chgjno] [int] NOT NULL ,
	[pub_chgjbkno] [int] NOT NULL ,
	[pub_fgrechg] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_njtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fginved] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fginvself] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_remark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fgfixpg] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_modempno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_imseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fgupdated] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[cust]    Script Date: 2002/7/6 上午 11:22:30 ******/
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
	[cust_itpcd] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_btpcd] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_rtpcd] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_oldcustno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_origsyscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[hicard]    Script Date: 2002/7/6 上午 11:22:31 ******/
CREATE TABLE [dbo].[hicard] (
	[empno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[check_code] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cname] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[id_no] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[card_check] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[card_no] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[get_date] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[birth_d] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ia]    Script Date: 2002/7/6 上午 11:22:32 ******/
CREATE TABLE [dbo].[ia] (
	[ia_iaid] [int] IDENTITY (1, 1) NOT NULL ,
	[ia_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iasdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iasseq] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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
	[ia_fgitri] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rnm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_raddr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rzip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rtel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_fgnonauto] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_status] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_cname] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_tel] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_contno] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[iad]    Script Date: 2002/7/6 上午 11:22:34 ******/
CREATE TABLE [dbo].[iad] (
	[iad_iadid] [int] IDENTITY (1, 1) NOT NULL ,
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

/****** Object:  Table [dbo].[ias]    Script Date: 2002/7/6 上午 11:22:35 ******/
CREATE TABLE [dbo].[ias] (
	[ias_iasid] [int] IDENTITY (1, 1) NOT NULL ,
	[ias_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_iasdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_iasseq] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_toitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_cancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[inftmp20]    Script Date: 2002/7/6 上午 11:22:36 ******/
CREATE TABLE [dbo].[inftmp20] (
	[inf20_orgcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_type] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_seq] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_infno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_ref] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_invtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_remark] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_cusno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_title] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_address] [char] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_saleamt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_taxamt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_invoamt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_curr] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_rate] [char] (9) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_prtctl] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_postdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_accddr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_attach] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_exptype] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_expremark] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_vseq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_accdcr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_costctr] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_contno] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_period] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_amt] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_descr] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_alloc] [char] (18) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_iseq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_idescr] [char] (200) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_iunit] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_iqty] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_iuniprice] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[inf20_iremark] [char] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[inv20]    Script Date: 2002/7/6 上午 11:22:37 ******/
CREATE TABLE [dbo].[inv20] (
	[inv20_cusno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_contno] [char] (13) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_period] [char] (12) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_fy] [char] (4) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_docno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_item] [char] (3) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_invno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_postdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_type] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_dept] [char] (7) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_amt] [float] NOT NULL ,
	[inv20_chkno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv20_trndt] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[invmfr]    Script Date: 2002/7/6 上午 11:22:38 ******/
CREATE TABLE [dbo].[invmfr] (
	[im_imid] [int] IDENTITY (1, 1) NOT NULL ,
	[im_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_imseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_zip] [varchar] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_addr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_fgitri] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[itp]    Script Date: 2002/7/6 上午 11:22:39 ******/
CREATE TABLE [dbo].[itp] (
	[itp_itpid] [int] IDENTITY (1, 1) NOT NULL ,
	[itp_itpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[itp_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mailer]    Script Date: 2002/7/6 上午 11:22:40 ******/
CREATE TABLE [dbo].[mailer] (
	[ml_mlid] [int] IDENTITY (1, 1) NOT NULL ,
	[ml_mlcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ml_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mfr]    Script Date: 2002/7/6 上午 11:22:41 ******/
CREATE TABLE [dbo].[mfr] (
	[mfr_mfrid] [int] IDENTITY (1, 1) NOT NULL ,
	[mfr_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_iaddr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_izip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respnm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_regdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mfr1a]    Script Date: 2002/7/6 上午 11:22:42 ******/
CREATE TABLE [dbo].[mfr1a] (
	[mfr_mfrid] [int] IDENTITY (1, 1) NOT NULL ,
	[mfr_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_iaddr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_izip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respnm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_regdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mfr_imr]    Script Date: 2002/7/6 上午 11:22:43 ******/
CREATE TABLE [dbo].[mfr_imr] (
	[mfr_mfrid] [int] NOT NULL ,
	[mfr_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_iaddr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_izip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respnm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_respjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_regdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mltp]    Script Date: 2002/7/6 上午 11:22:43 ******/
CREATE TABLE [dbo].[mltp] (
	[mltp_mltpid] [int] IDENTITY (1, 1) NOT NULL ,
	[mltp_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mltp_mlcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mltp_mltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mtp]    Script Date: 2002/7/6 上午 11:22:44 ******/
CREATE TABLE [dbo].[mtp] (
	[mtp_mtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[mtp_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mtp_nm] [char] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[or_trans_test]    Script Date: 2002/7/6 上午 11:22:45 ******/
CREATE TABLE [dbo].[or_trans_test] (
	[syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pbcatcol]    Script Date: 2002/7/6 上午 11:22:46 ******/
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

/****** Object:  Table [dbo].[pbcatedt]    Script Date: 2002/7/6 上午 11:22:47 ******/
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

/****** Object:  Table [dbo].[pbcatfmt]    Script Date: 2002/7/6 上午 11:22:48 ******/
CREATE TABLE [dbo].[pbcatfmt] (
	[pbf_name] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbf_frmt] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbf_type] [smallint] NOT NULL ,
	[pbf_cntr] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pbcattbl]    Script Date: 2002/7/6 上午 11:22:48 ******/
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

/****** Object:  Table [dbo].[pbcatvld]    Script Date: 2002/7/6 上午 11:22:49 ******/
CREATE TABLE [dbo].[pbcatvld] (
	[pbv_name] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbv_vald] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbv_type] [smallint] NOT NULL ,
	[pbv_cntr] [int] NULL ,
	[pbv_msg] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[proj]    Script Date: 2002/7/6 上午 11:22:50 ******/
CREATE TABLE [dbo].[proj] (
	[proj_projid] [int] IDENTITY (1, 1) NOT NULL ,
	[proj_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_fgitri] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[proj_cont] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[py]    Script Date: 2002/7/6 上午 11:22:51 ******/
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
	[py_cctp] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_ccauthcd] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_ccvdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_fgprinted] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pysdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pysseq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pyditem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pyd]    Script Date: 2002/7/6 上午 11:22:52 ******/
CREATE TABLE [dbo].[pyd] (
	[pyd_pydid] [int] IDENTITY (1, 1) NOT NULL ,
	[pyd_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_pyno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_pyditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_invno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pyseq]    Script Date: 2002/7/6 上午 11:22:53 ******/
CREATE TABLE [dbo].[pyseq] (
	[pys_pysid] [int] IDENTITY (1, 1) NOT NULL ,
	[pys_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_pysdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_pysseq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_toitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pytp]    Script Date: 2002/7/6 上午 11:22:53 ******/
CREATE TABLE [dbo].[pytp] (
	[pytp_pytpid] [int] IDENTITY (1, 1) NOT NULL ,
	[pytp_pytpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pytp_nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[refd]    Script Date: 2002/7/6 上午 11:22:54 ******/
CREATE TABLE [dbo].[refd] (
	[rd_rdid] [int] IDENTITY (1, 1) NOT NULL ,
	[rd_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_accdcr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_descr] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[refm]    Script Date: 2002/7/6 上午 11:22:55 ******/
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

/****** Object:  Table [dbo].[retn_imr]    Script Date: 2002/7/6 上午 11:22:55 ******/
CREATE TABLE [dbo].[retn_imr] (
	[aa] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[orderno] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[order_date_e] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[order_date_b] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[amt] [float] NULL ,
	[remark] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[choice] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[update_temp] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[o_date] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[name] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[title] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cono] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[co] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[address] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[rtp]    Script Date: 2002/7/6 上午 11:22:56 ******/
CREATE TABLE [dbo].[rtp] (
	[rtp_rtpid] [int] NOT NULL ,
	[rtp_rtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rtp_nm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[sapiv]    Script Date: 2002/7/6 上午 11:22:57 ******/
CREATE TABLE [dbo].[sapiv] (
	[iv_orgcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_type] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iv_seq] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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

/****** Object:  Table [dbo].[sapivd]    Script Date: 2002/7/6 上午 11:22:58 ******/
CREATE TABLE [dbo].[sapivd] (
	[ivd_infno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iseq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_idescr] [char] (200) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iunit] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iqty] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iuniprice] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivd_iremark] [char] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[saplog]    Script Date: 2002/7/6 上午 11:22:59 ******/
CREATE TABLE [dbo].[saplog] (
	[sap_type] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[sap_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[sap_seq] [int] NOT NULL ,
	[sap_smark] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[sap_uid] [char] (15) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[sap_moddate] [datetime] NULL ,
	[sap_orgcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[sapvou]    Script Date: 2002/7/6 上午 11:23:00 ******/
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

/****** Object:  Table [dbo].[srspn]    Script Date: 2002/7/6 上午 11:23:00 ******/
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

/****** Object:  Table [dbo].[syscd]    Script Date: 2002/7/6 上午 11:23:01 ******/
CREATE TABLE [dbo].[syscd] (
	[sys_sysid] [int] IDENTITY (1, 1) NOT NULL ,
	[sys_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[sys_nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_bookp]    Script Date: 2002/7/6 上午 11:23:02 ******/
CREATE TABLE [dbo].[t2_bookp] (
	[yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_btp]    Script Date: 2002/7/6 上午 11:23:03 ******/
CREATE TABLE [dbo].[t2_btp] (
	[btpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[btp] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_clr]    Script Date: 2002/7/6 上午 11:23:04 ******/
CREATE TABLE [dbo].[t2_clr] (
	[seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clr] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_cont]    Script Date: 2002/7/6 上午 11:23:05 ******/
CREATE TABLE [dbo].[t2_cont] (
	[cont] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[empno] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[signdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[custno] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[custnm] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[aunm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[autel] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[aufax] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[aucell] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[au_bdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[au_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[disc] [real] NOT NULL ,
	[freetm] [int] NOT NULL ,
	[totjtm] [int] NOT NULL ,
	[madejtm] [int] NOT NULL ,
	[tottm] [int] NOT NULL ,
	[pubtm] [int] NOT NULL ,
	[totamt] [numeric](18, 0) NOT NULL ,
	[paidamt] [numeric](18, 0) NOT NULL ,
	[chgamt] [numeric](18, 0) NOT NULL ,
	[pubmnt] [int] NOT NULL ,
	[freemnt] [int] NOT NULL ,
	[closerk] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[invno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clrtm] [int] NOT NULL ,
	[getclrtm] [int] NOT NULL ,
	[menotm] [int] NOT NULL ,
	[iano] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_cust]    Script Date: 2002/7/6 上午 11:23:06 ******/
CREATE TABLE [dbo].[t2_cust] (
	[custno] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[jbti] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfrnm] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iraddr] [char] (200) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tel] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[movetel] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fax] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[e_mail] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[irzip] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[itpcd] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[btpcd] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[createdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[irnm] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[respnjbti] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_remk] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_ia]    Script Date: 2002/7/6 上午 11:23:07 ******/
CREATE TABLE [dbo].[t2_ia] (
	[iano] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[yymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[color] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cra_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_title] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iaddr] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fvat] [numeric](18, 0) NOT NULL ,
	[ivat] [numeric](18, 0) NOT NULL ,
	[pyat] [numeric](18, 0) NOT NULL ,
	[op] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pjfy] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pjno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[costcenter] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[contno] [char] (14) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[trans_flag] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srce_code] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[aunm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[irnm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[empno] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_itp]    Script Date: 2002/7/6 上午 11:23:08 ******/
CREATE TABLE [dbo].[t2_itp] (
	[itpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[itp] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_ltp]    Script Date: 2002/7/6 上午 11:23:09 ******/
CREATE TABLE [dbo].[t2_ltp] (
	[seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_or]    Script Date: 2002/7/6 上午 11:23:10 ******/
CREATE TABLE [dbo].[t2_or] (
	[contno] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[addr] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mtpcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[datasrce] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[buy_mnt] [int] NOT NULL ,
	[free_mnt] [int] NOT NULL ,
	[fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_pub]    Script Date: 2002/7/6 上午 11:23:11 ******/
CREATE TABLE [dbo].[t2_pub] (
	[cont] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[yymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clr] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[page] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adamt] [numeric](18, 0) NOT NULL ,
	[chgamt] [numeric](18, 0) NOT NULL ,
	[bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[origjno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[origjbkno] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[chgjno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[remark] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iano] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs_mnt] [int] NOT NULL ,
	[remark2] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_mnt] [int] NOT NULL ,
	[okflag] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_pub_orig]    Script Date: 2002/7/6 上午 11:23:12 ******/
CREATE TABLE [dbo].[t2_pub_orig] (
	[cont] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[yymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clr] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[page] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adamt] [numeric](18, 0) NOT NULL ,
	[chgamt] [numeric](18, 0) NOT NULL ,
	[bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[origjno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[origjbkno] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[chgjno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ivno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[remark] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iano] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs_mnt] [int] NOT NULL ,
	[remark2] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_mnt] [int] NOT NULL ,
	[okflag] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t2_security]    Script Date: 2002/7/6 上午 11:23:13 ******/
CREATE TABLE [dbo].[t2_security] (
	[s_code] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[empno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[secu] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ext] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_class1]    Script Date: 2002/7/6 上午 11:23:14 ******/
CREATE TABLE [dbo].[t_class1] (
	[class] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[class_desc] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_class2]    Script Date: 2002/7/6 上午 11:23:15 ******/
CREATE TABLE [dbo].[t_class2] (
	[class] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[class_desc] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_cono]    Script Date: 2002/7/6 上午 11:23:16 ******/
CREATE TABLE [dbo].[t_cono] (
	[cono] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_cono_e]    Script Date: 2002/7/6 上午 11:23:17 ******/
CREATE TABLE [dbo].[t_cono_e] (
	[cono] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_imr0506v5]    Script Date: 2002/7/6 上午 11:23:17 ******/
CREATE TABLE [dbo].[t_imr0506v5] (
	[aa] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[orderno] [nvarchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [nvarchar] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [nvarchar] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[amt] [float] NULL ,
	[remark] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[choice] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[update_temp] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[o_date] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[name] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[title] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cono] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[co] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[address] [nvarchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_imr1]    Script Date: 2002/7/6 上午 11:23:19 ******/
CREATE TABLE [dbo].[t_imr1] (
	[aa] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[title] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cono] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[address] [char] (250) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_imr2]    Script Date: 2002/7/6 上午 11:23:20 ******/
CREATE TABLE [dbo].[t_imr2] (
	[aa] [varchar] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[title] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cono] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[address] [char] (250) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_imr20508v5]    Script Date: 2002/7/6 上午 11:23:21 ******/
CREATE TABLE [dbo].[t_imr20508v5] (
	[aa] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[orderno] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [varchar] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [varchar] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[amt] [float] NULL ,
	[remark] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[choice] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[update_temp] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[o_date] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[name] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[title] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cono] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[co] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[address] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_order_2]    Script Date: 2002/7/6 上午 11:23:21 ******/
CREATE TABLE [dbo].[t_order_2] (
	[orderno] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pb1]    Script Date: 2002/7/6 上午 11:23:22 ******/
CREATE TABLE [dbo].[t_pb1] (
	[orderno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[title] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[address] [char] (250) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tel] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[movetel] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fax] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[e_mail] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orderno_temp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[addr_id] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cono] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[coman] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[delete_mark] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pb1b]    Script Date: 2002/7/6 上午 11:23:23 ******/
CREATE TABLE [dbo].[t_pb1b] (
	[orderno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[title] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[address] [char] (250) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tel] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[movetel] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fax] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[e_mail] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orderno_temp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[addr_id] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cono] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[coman] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pb2]    Script Date: 2002/7/6 上午 11:23:24 ******/
CREATE TABLE [dbo].[t_pb2] (
	[orderno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[title] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[address] [char] (250) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tel] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[movetel] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fax] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[e_mail] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orderno_temp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[addr_id] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cono] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[coman] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pb2_copy]    Script Date: 2002/7/6 上午 11:23:25 ******/
CREATE TABLE [dbo].[t_pb2_copy] (
	[aa] [varchar] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[title] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cono] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[address] [char] (250) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pb2a]    Script Date: 2002/7/6 上午 11:23:26 ******/
CREATE TABLE [dbo].[t_pb2a] (
	[orderno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[title] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[co] [char] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[address] [char] (250) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tel] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[movetel] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fax] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[e_mail] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orderno_temp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[addr_id] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cono] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[coman] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[new_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pbupd1]    Script Date: 2002/7/6 上午 11:23:27 ******/
CREATE TABLE [dbo].[t_pbupd1] (
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pbupd1a]    Script Date: 2002/7/6 上午 11:23:28 ******/
CREATE TABLE [dbo].[t_pbupd1a] (
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pbupd1b]    Script Date: 2002/7/6 上午 11:23:29 ******/
CREATE TABLE [dbo].[t_pbupd1b] (
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pbupd2]    Script Date: 2002/7/6 上午 11:23:30 ******/
CREATE TABLE [dbo].[t_pbupd2] (
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_pbupd2_0502]    Script Date: 2002/7/6 上午 11:23:31 ******/
CREATE TABLE [dbo].[t_pbupd2_0502] (
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_e] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[order_date_b] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[amt] [real] NOT NULL ,
	[remark] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[choice] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[update_temp] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_type1]    Script Date: 2002/7/6 上午 11:23:32 ******/
CREATE TABLE [dbo].[t_type1] (
	[class] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[type1] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[type2] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_type2]    Script Date: 2002/7/6 上午 11:23:33 ******/
CREATE TABLE [dbo].[t_type2] (
	[class] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[type1] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[type2] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_use_cono]    Script Date: 2002/7/6 上午 11:23:33 ******/
CREATE TABLE [dbo].[t_use_cono] (
	[cono] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[t_use_order]    Script Date: 2002/7/6 上午 11:23:34 ******/
CREATE TABLE [dbo].[t_use_order] (
	[orderno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[c1_1_delete] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_1_delete] PRIMARY KEY  CLUSTERED 
	(
		[orderno],
		[date_b],
		[date_e]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_2_delete] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_2_delete] PRIMARY KEY  CLUSTERED 
	(
		[orderno],
		[date_b],
		[date_e]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_od] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_od] PRIMARY KEY  CLUSTERED 
	(
		[od_syscd],
		[od_custno],
		[od_otp1cd],
		[od_otp1seq],
		[od_oditem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_or] PRIMARY KEY  CLUSTERED 
	(
		[or_syscd],
		[or_custno],
		[or_otp1cd],
		[or_otp1seq],
		[or_oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_order] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_order] PRIMARY KEY  CLUSTERED 
	(
		[o_syscd],
		[o_custno],
		[o_otp1cd],
		[o_otp1seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_ramt] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_ramt] PRIMARY KEY  CLUSTERED 
	(
		[ra_syscd],
		[ra_custno],
		[ra_otp1cd],
		[ra_otp1seq],
		[ra_oditem],
		[ra_oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_clr] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_clr] PRIMARY KEY  CLUSTERED 
	(
		[clr_clrcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_cont] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_cont] PRIMARY KEY  CLUSTERED 
	(
		[cont_syscd],
		[cont_contno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_lost] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_lost] PRIMARY KEY  CLUSTERED 
	(
		[lst_syscd],
		[lst_contno],
		[lst_oritem],
		[lst_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_lprior] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_lprior] PRIMARY KEY  CLUSTERED 
	(
		[lp_bkcd],
		[lp_priorseq],
		[lp_clrcd],
		[lp_ltpcd],
		[lp_pgscd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_ltp] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_ltp] PRIMARY KEY  CLUSTERED 
	(
		[ltp_ltpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_njtp] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_njtp] PRIMARY KEY  CLUSTERED 
	(
		[njtp_njtpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_or] PRIMARY KEY  CLUSTERED 
	(
		[or_syscd],
		[or_contno],
		[or_oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_pgsize] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_pgsize] PRIMARY KEY  CLUSTERED 
	(
		[pgs_pgscd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_pub] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_pub] PRIMARY KEY  CLUSTERED 
	(
		[pub_syscd],
		[pub_contno],
		[pub_yyyymm],
		[pub_pubseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cust] WITH NOCHECK ADD 
	CONSTRAINT [PK_cust] PRIMARY KEY  CLUSTERED 
	(
		[cust_custno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ia] WITH NOCHECK ADD 
	CONSTRAINT [PK_ia] PRIMARY KEY  CLUSTERED 
	(
		[ia_syscd],
		[ia_iano]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[iad] WITH NOCHECK ADD 
	CONSTRAINT [PK_iad] PRIMARY KEY  CLUSTERED 
	(
		[iad_syscd],
		[iad_iano],
		[iad_iaditem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ias] WITH NOCHECK ADD 
	CONSTRAINT [PK_ias] PRIMARY KEY  CLUSTERED 
	(
		[ias_iasdate],
		[ias_iasseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[inv20] WITH NOCHECK ADD 
	CONSTRAINT [pkinv20] PRIMARY KEY  CLUSTERED 
	(
		[inv20_cusno],
		[inv20_projno],
		[inv20_contno],
		[inv20_period],
		[inv20_docno],
		[inv20_item]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[invmfr] WITH NOCHECK ADD 
	CONSTRAINT [PK_invmfr] PRIMARY KEY  CLUSTERED 
	(
		[im_syscd],
		[im_contno],
		[im_imseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mfr] WITH NOCHECK ADD 
	CONSTRAINT [PK_mfr1] PRIMARY KEY  CLUSTERED 
	(
		[mfr_mfrno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mfr1a] WITH NOCHECK ADD 
	CONSTRAINT [PK_mfr] PRIMARY KEY  CLUSTERED 
	(
		[mfr_mfrno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[or_trans_test] WITH NOCHECK ADD 
	CONSTRAINT [PK_or_trans_test] PRIMARY KEY  CLUSTERED 
	(
		[syscd],
		[custno],
		[otp1cd],
		[otp1seq],
		[oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_bookp] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_bookp] PRIMARY KEY  CLUSTERED 
	(
		[yyyymm],
		[bkcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_btp] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_btp] PRIMARY KEY  CLUSTERED 
	(
		[btpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_clr] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_clr] PRIMARY KEY  CLUSTERED 
	(
		[seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_cont] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_cont] PRIMARY KEY  CLUSTERED 
	(
		[cont]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_cust] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_cust] PRIMARY KEY  CLUSTERED 
	(
		[custno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_ia] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_ia] PRIMARY KEY  CLUSTERED 
	(
		[iano],
		[yymm],
		[color]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_itp] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_itp] PRIMARY KEY  CLUSTERED 
	(
		[itpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_ltp] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_ltp] PRIMARY KEY  CLUSTERED 
	(
		[seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_or] PRIMARY KEY  CLUSTERED 
	(
		[contno],
		[name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_pub] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_pub] PRIMARY KEY  CLUSTERED 
	(
		[cont],
		[yymm],
		[clr]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_pub_orig] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_pub_orig] PRIMARY KEY  CLUSTERED 
	(
		[cont],
		[yymm],
		[clr]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t2_security] WITH NOCHECK ADD 
	CONSTRAINT [PK_t2_security] PRIMARY KEY  CLUSTERED 
	(
		[s_code]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_class1] WITH NOCHECK ADD 
	CONSTRAINT [PK_t_class1] PRIMARY KEY  CLUSTERED 
	(
		[class]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_imr0506v5] WITH NOCHECK ADD 
	CONSTRAINT [PK_t_imr0506v5] PRIMARY KEY  CLUSTERED 
	(
		[orderno],
		[order_date_e]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_pb1b] WITH NOCHECK ADD 
	CONSTRAINT [PK_pb1] PRIMARY KEY  CLUSTERED 
	(
		[orderno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_pb2] WITH NOCHECK ADD 
	CONSTRAINT [PK_t_pb2] PRIMARY KEY  CLUSTERED 
	(
		[orderno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_pbupd1] WITH NOCHECK ADD 
	CONSTRAINT [PK_t_pbupd1] PRIMARY KEY  CLUSTERED 
	(
		[orderno],
		[order_date_e]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_pbupd1a] WITH NOCHECK ADD 
	CONSTRAINT [PK_t_pbupd1a] PRIMARY KEY  CLUSTERED 
	(
		[orderno],
		[order_date_e],
		[order_date_b]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_pbupd2] WITH NOCHECK ADD 
	CONSTRAINT [PK_t_pbupd2] PRIMARY KEY  CLUSTERED 
	(
		[orderno],
		[order_date_e]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[t_type1] WITH NOCHECK ADD 
	CONSTRAINT [PK_t_type1] PRIMARY KEY  CLUSTERED 
	(
		[class]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_cust] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_cust_cust_oldcustno] DEFAULT ('') FOR [cust_oldcustno1],
	CONSTRAINT [DF_c1_cust_cust_bkcd] DEFAULT ('') FOR [cust_oldcustno2]
GO

ALTER TABLE [dbo].[c1_or] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_or_or_inm] DEFAULT ('') FOR [or_inm]
GO

ALTER TABLE [dbo].[c1_order] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_order_o_cancel] DEFAULT ('') FOR [o_cancel],
	CONSTRAINT [DF_c1_order_o_indate] DEFAULT ('') FOR [o_indate],
	CONSTRAINT [DF_c1_order_o_iano] DEFAULT ('') FOR [o_iano],
	CONSTRAINT [DF_c1_order_o_special] DEFAULT ('') FOR [o_special]
GO

ALTER TABLE [dbo].[c2_clr] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_clr_clr_clrcd] DEFAULT ('') FOR [clr_clrcd],
	CONSTRAINT [DF_c2_clr_clr_nm] DEFAULT ('') FOR [clr_nm]
GO

ALTER TABLE [dbo].[c2_cont] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_cont_cont_syscd] DEFAULT ('C2') FOR [cont_syscd],
	CONSTRAINT [DF_c2_cont_cont_contno] DEFAULT ('') FOR [cont_contno],
	CONSTRAINT [DF_c2_cont_cont_conttp] DEFAULT ('') FOR [cont_conttp],
	CONSTRAINT [DF_c2_cont_cont_bkcd] DEFAULT ('') FOR [cont_bkcd],
	CONSTRAINT [DF_c2_cont_cont_signdate] DEFAULT ('') FOR [cont_signdate],
	CONSTRAINT [DF_c2_cont_cont_empno] DEFAULT ('') FOR [cont_empno],
	CONSTRAINT [DF_c2_cont_cont_mfrno] DEFAULT ('') FOR [cont_mfrno],
	CONSTRAINT [DF_c2_cont_cont_aunm] DEFAULT ('') FOR [cont_aunm],
	CONSTRAINT [DF_c2_cont_cont_autel] DEFAULT ('') FOR [cont_autel],
	CONSTRAINT [DF_c2_cont_cont_aufax] DEFAULT ('') FOR [cont_aufax],
	CONSTRAINT [DF_c2_cont_cont_aucell] DEFAULT ('') FOR [cont_aucell],
	CONSTRAINT [DF_c2_cont_cont_auemail] DEFAULT ('') FOR [cont_auemail],
	CONSTRAINT [DF_c2_cont_cont_sdate] DEFAULT ('') FOR [cont_sdate],
	CONSTRAINT [DF_c2_cont_cont_edate] DEFAULT ('') FOR [cont_edate],
	CONSTRAINT [DF_c2_cont_cont_totjtm] DEFAULT ('') FOR [cont_totjtm],
	CONSTRAINT [DF_c2_cont_cont_madejtm] DEFAULT ('') FOR [cont_madejtm],
	CONSTRAINT [DF_c2_cont_cont_restjtm] DEFAULT ('') FOR [cont_restjtm],
	CONSTRAINT [DF_c2_cont_cont_disc] DEFAULT ('') FOR [cont_disc],
	CONSTRAINT [DF_c2_cont_cont_freetm] DEFAULT ('') FOR [cont_freetm],
	CONSTRAINT [DF_c2_cont_cont_fgclosed] DEFAULT ('0') FOR [cont_fgclosed],
	CONSTRAINT [DF_c2_cont_cont_tottm] DEFAULT ('') FOR [cont_tottm],
	CONSTRAINT [DF_c2_cont_cont_pubtm] DEFAULT ('') FOR [cont_pubtm],
	CONSTRAINT [DF_c2_cont_cont_resttm] DEFAULT ('') FOR [cont_resttm],
	CONSTRAINT [DF_c2_cont_cont_chgjtm] DEFAULT ('') FOR [cont_chgjtm],
	CONSTRAINT [DF_c2_cont_cont_custno] DEFAULT ('') FOR [cont_custno],
	CONSTRAINT [DF_c2_cont_cont_totamt] DEFAULT ('') FOR [cont_totamt],
	CONSTRAINT [DF_c2_cont_cont_pubamt] DEFAULT ('') FOR [cont_pubamt],
	CONSTRAINT [DF_c2_cont_cont_chgamt] DEFAULT ('') FOR [cont_chgamt],
	CONSTRAINT [DF_c2_cont_cont_paidamt] DEFAULT ('') FOR [cont_paidamt],
	CONSTRAINT [DF_c2_cont_cont_restamt] DEFAULT ('') FOR [cont_restamt],
	CONSTRAINT [DF_c2_cont_cont_clrtm] DEFAULT ('') FOR [cont_clrtm],
	CONSTRAINT [DF_c2_cont_cont_menotm] DEFAULT ('') FOR [cont_menotm],
	CONSTRAINT [DF_c2_cont_cont_getclrtm] DEFAULT ('') FOR [cont_getclrtm],
	CONSTRAINT [DF_c2_cont_cont_oldcontno] DEFAULT ('') FOR [cont_oldcontno],
	CONSTRAINT [DF_c2_cont_cont_moddate] DEFAULT ('') FOR [cont_moddate],
	CONSTRAINT [DF_c2_cont_cont_fgpayonce] DEFAULT ('0') FOR [cont_fgpayonce],
	CONSTRAINT [DF_c2_cont_cont_xmldata] DEFAULT ('') FOR [cont_xmldata],
	CONSTRAINT [DF_c2_cont_cont_modempno] DEFAULT ('') FOR [cont_modempno]
GO

ALTER TABLE [dbo].[c2_lost] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_lost_lst_syscd] DEFAULT ('C2') FOR [lst_syscd],
	CONSTRAINT [DF_c2_lost_lst_contno] DEFAULT ('') FOR [lst_contno],
	CONSTRAINT [DF_c2_lost_lst_oritem] DEFAULT ('') FOR [lst_oritem],
	CONSTRAINT [DF_c2_lost_lst_seq] DEFAULT ('') FOR [lst_seq],
	CONSTRAINT [DF_c2_lost_lst_cont] DEFAULT ('') FOR [lst_cont],
	CONSTRAINT [DF_c2_lost_lst_date] DEFAULT ('') FOR [lst_date],
	CONSTRAINT [DF_c2_lost_lst_rea] DEFAULT ('') FOR [lst_rea],
	CONSTRAINT [DF_c2_lost_lst_fgsent] DEFAULT ('0') FOR [lst_fgsent]
GO

ALTER TABLE [dbo].[c2_lprior] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_lprior_lp_bkcd] DEFAULT ('') FOR [lp_bkcd],
	CONSTRAINT [DF_c2_lprior_lp_priorseq] DEFAULT ('') FOR [lp_priorseq],
	CONSTRAINT [DF_c2_lprior_lp_clrcd] DEFAULT ('') FOR [lp_clrcd],
	CONSTRAINT [DF_c2_lprior_lp_ltpcd] DEFAULT ('') FOR [lp_ltpcd],
	CONSTRAINT [DF_c2_lprior_lp_pgscd] DEFAULT ('') FOR [lp_pgscd]
GO

ALTER TABLE [dbo].[c2_ltp] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_ltp_ltp_ltpcd] DEFAULT ('') FOR [ltp_ltpcd],
	CONSTRAINT [DF_c2_ltp_ltp_nm] DEFAULT ('') FOR [ltp_nm]
GO

ALTER TABLE [dbo].[c2_njtp] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_njtp_njtp_njtpcd] DEFAULT ('') FOR [njtp_njtpcd],
	CONSTRAINT [DF_c2_njtp_njtp_nm] DEFAULT ('') FOR [njtp_nm]
GO

ALTER TABLE [dbo].[c2_or] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_or_or_syscd] DEFAULT ('(''C2)') FOR [or_syscd],
	CONSTRAINT [DF_c2_or_or_contno] DEFAULT ('') FOR [or_contno],
	CONSTRAINT [DF_c2_or_or_oritem] DEFAULT ('') FOR [or_oritem],
	CONSTRAINT [DF_c2_or_or_inm] DEFAULT ('') FOR [or_inm],
	CONSTRAINT [DF_c2_or_or_nm] DEFAULT ('') FOR [or_nm],
	CONSTRAINT [DF_c2_or_or_jbti] DEFAULT ('') FOR [or_jbti],
	CONSTRAINT [DF_c2_or_or_addr] DEFAULT ('') FOR [or_addr],
	CONSTRAINT [DF_c2_or_or_zip] DEFAULT ('') FOR [or_zip],
	CONSTRAINT [DF_c2_or_or_tel] DEFAULT ('') FOR [or_tel],
	CONSTRAINT [DF_c2_or_or_fax] DEFAULT ('') FOR [or_fax],
	CONSTRAINT [DF_c2_or_or_cell] DEFAULT ('') FOR [or_cell],
	CONSTRAINT [DF_c2_or_or_email] DEFAULT ('') FOR [or_email],
	CONSTRAINT [DF_c2_or_or_mtpcd] DEFAULT ('') FOR [or_mtpcd],
	CONSTRAINT [DF_c2_or_or_unpubcnt] DEFAULT ('') FOR [or_unpubcnt],
	CONSTRAINT [DF_c2_or_or_fgmosea] DEFAULT ('0') FOR [or_fgmosea]
GO

ALTER TABLE [dbo].[c2_pgsize] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_pgsize_pgs_pgscd] DEFAULT ('') FOR [pgs_pgscd],
	CONSTRAINT [DF_c2_pgsize_pgs_nm] DEFAULT ('') FOR [pgs_nm]
GO

ALTER TABLE [dbo].[c2_pub] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_pub_pub_syscd] DEFAULT ('C2') FOR [pub_syscd],
	CONSTRAINT [DF_c2_pub_pub_contno] DEFAULT ('') FOR [pub_contno],
	CONSTRAINT [DF_c2_pub_pub_yyyymm] DEFAULT ('') FOR [pub_yyyymm],
	CONSTRAINT [DF_c2_pub_pub_pubseq] DEFAULT ('') FOR [pub_pubseq],
	CONSTRAINT [DF_c2_pub_pub_pgno] DEFAULT ('') FOR [pub_pgno],
	CONSTRAINT [DF_c2_pub_pub_ltpcd] DEFAULT ('') FOR [pub_ltpcd],
	CONSTRAINT [DF_c2_pub_pub_clrcd] DEFAULT ('') FOR [pub_clrcd],
	CONSTRAINT [DF_c2_pub_pub_pgscd] DEFAULT ('') FOR [pub_pgscd],
	CONSTRAINT [DF_c2_pub_pub_adamt] DEFAULT ('') FOR [pub_adamt],
	CONSTRAINT [DF_c2_pub_pub_chgamt] DEFAULT ('') FOR [pub_chgamt],
	CONSTRAINT [DF_c2_pub_pub_drafttp] DEFAULT ('') FOR [pub_drafttp],
	CONSTRAINT [DF_c2_pub_pub_origbkcd] DEFAULT ('') FOR [pub_origbkcd],
	CONSTRAINT [DF_c2_pub_pub_origjno] DEFAULT ('') FOR [pub_origjno],
	CONSTRAINT [DF_c2_pub_pub_origjbkno] DEFAULT ('') FOR [pub_origjbkno],
	CONSTRAINT [DF_c2_pub_pub_chgbkcd] DEFAULT ('') FOR [pub_chgbkcd],
	CONSTRAINT [DF_c2_pub_pub_chgjno] DEFAULT ('') FOR [pub_chgjno],
	CONSTRAINT [DF_c2_pub_pub_chgjbkno] DEFAULT ('') FOR [pub_chgjbkno],
	CONSTRAINT [DF_c2_pub_pub_fgrechg] DEFAULT ('') FOR [pub_fgrechg],
	CONSTRAINT [DF_c2_pub_pub_fggot] DEFAULT ('0') FOR [pub_fggot],
	CONSTRAINT [DF_c2_pub_pub_njtpcd] DEFAULT ('') FOR [pub_njtpcd],
	CONSTRAINT [DF_c2_pub_pub_costctr] DEFAULT ('') FOR [pub_costctr],
	CONSTRAINT [DF_c2_pub_pub_fginved] DEFAULT ('0') FOR [pub_fginved],
	CONSTRAINT [DF_c2_pub_pub_fginvself] DEFAULT ('0') FOR [pub_fginvself],
	CONSTRAINT [DF_c2_pub_pub_pno] DEFAULT ('') FOR [pub_pno],
	CONSTRAINT [DF_c2_pub_pub_remark] DEFAULT ('') FOR [pub_remark],
	CONSTRAINT [DF_c2_pub_pub_fgfixpg] DEFAULT ('0') FOR [pub_fgfixpg],
	CONSTRAINT [DF_c2_pub_pub_moddate] DEFAULT ('') FOR [pub_moddate],
	CONSTRAINT [DF_c2_pub_pub_modempno] DEFAULT ('') FOR [pub_modempno],
	CONSTRAINT [DF_c2_pub_pub_bkcd] DEFAULT ('01') FOR [pub_bkcd],
	CONSTRAINT [DF_c2_pub_pub_imseq] DEFAULT ('') FOR [pub_imseq],
	CONSTRAINT [DF_c2_pub_pub_fgupdated] DEFAULT ('0') FOR [pub_fgupdated]
GO

ALTER TABLE [dbo].[cust] WITH NOCHECK ADD 
	CONSTRAINT [DF_cust_cust_oldcustno] DEFAULT ('') FOR [cust_oldcustno],
	CONSTRAINT [DF_cust_cust_origsyscd] DEFAULT ('') FOR [cust_origsyscd]
GO

ALTER TABLE [dbo].[ia] WITH NOCHECK ADD 
	CONSTRAINT [DF_ia_ia_syscd] DEFAULT ('') FOR [ia_syscd],
	CONSTRAINT [DF_ia_ia_iasdate] DEFAULT ('') FOR [ia_iasdate],
	CONSTRAINT [DF_ia_ia_iasseq] DEFAULT ('') FOR [ia_iasseq],
	CONSTRAINT [DF_ia_ia_iaitem] DEFAULT ('') FOR [ia_iaitem],
	CONSTRAINT [DF_ia_ia_iano] DEFAULT ('') FOR [ia_iano],
	CONSTRAINT [DF_ia_ia_refno] DEFAULT ('') FOR [ia_refno],
	CONSTRAINT [DF_ia_ia_mfrno] DEFAULT ('') FOR [ia_mfrno],
	CONSTRAINT [DF_ia_ia_pyno] DEFAULT ('') FOR [ia_pyno],
	CONSTRAINT [DF_ia_ia_pyseq] DEFAULT ('') FOR [ia_pyseq],
	CONSTRAINT [DF_ia_ia_pyat] DEFAULT ('') FOR [ia_pyat],
	CONSTRAINT [DF_ia_ia_ivat] DEFAULT ('') FOR [ia_ivat],
	CONSTRAINT [DF_ia_ia_invno] DEFAULT ('') FOR [ia_invno],
	CONSTRAINT [DF_ia_ia_invdate] DEFAULT ('') FOR [ia_invdate],
	CONSTRAINT [DF_ia_ia_fgitri] DEFAULT ('') FOR [ia_fgitri],
	CONSTRAINT [DF_ia_ia_rnm] DEFAULT ('') FOR [ia_rnm],
	CONSTRAINT [DF_ia_ia_raddr] DEFAULT ('') FOR [ia_raddr],
	CONSTRAINT [DF_ia_ia_rzip] DEFAULT ('') FOR [ia_rzip],
	CONSTRAINT [DF_ia_ia_rjbti] DEFAULT ('') FOR [ia_rjbti],
	CONSTRAINT [DF_ia_ia_rtel] DEFAULT ('') FOR [ia_rtel],
	CONSTRAINT [DF_ia_ia_fgnonauto] DEFAULT ('') FOR [ia_fgnonauto],
	CONSTRAINT [DF_ia_ia_invcd] DEFAULT ('') FOR [ia_invcd],
	CONSTRAINT [DF_ia_ia_taxtp] DEFAULT ('') FOR [ia_taxtp],
	CONSTRAINT [DF_ia_ia_status] DEFAULT ('') FOR [ia_status],
	CONSTRAINT [DF_ia_ia_empno] DEFAULT ('') FOR [ia_cname],
	CONSTRAINT [DF_ia_ia_tel] DEFAULT ('') FOR [ia_tel],
	CONSTRAINT [DF_ia_ia_contno] DEFAULT ('') FOR [ia_contno]
GO

ALTER TABLE [dbo].[iad] WITH NOCHECK ADD 
	CONSTRAINT [DF_iad_iad_syscd] DEFAULT ('C') FOR [iad_syscd],
	CONSTRAINT [DF_iad_iad_iano] DEFAULT ('') FOR [iad_iano],
	CONSTRAINT [DF_iad_iad_iaditem] DEFAULT ('') FOR [iad_iaditem],
	CONSTRAINT [DF_iad_iad_fk1] DEFAULT ('') FOR [iad_fk1],
	CONSTRAINT [DF_iad_iad_fk2] DEFAULT ('') FOR [iad_fk2],
	CONSTRAINT [DF_iad_iad_fk3] DEFAULT ('') FOR [iad_fk3],
	CONSTRAINT [DF_iad_iad_fk4] DEFAULT ('') FOR [iad_fk4],
	CONSTRAINT [DF_iad_iad_projno] DEFAULT ('') FOR [iad_projno],
	CONSTRAINT [DF_iad_iad_costctr] DEFAULT ('') FOR [iad_costctr],
	CONSTRAINT [DF_iad_iad_desc] DEFAULT ('') FOR [iad_desc],
	CONSTRAINT [DF_iad_iad_qty] DEFAULT ('') FOR [iad_qty],
	CONSTRAINT [DF_iad_iad_unit] DEFAULT ('') FOR [iad_unit],
	CONSTRAINT [DF_iad_iad_uprice] DEFAULT ('') FOR [iad_uprice],
	CONSTRAINT [DF_iad_iad_amt] DEFAULT ('') FOR [iad_amt]
GO

ALTER TABLE [dbo].[ias] WITH NOCHECK ADD 
	CONSTRAINT [DF_ias_ias_syscd] DEFAULT ('C') FOR [ias_syscd],
	CONSTRAINT [DF_ias_ias_iasdate] DEFAULT ('') FOR [ias_iasdate],
	CONSTRAINT [DF_ias_ias_iasseq] DEFAULT ('') FOR [ias_iasseq],
	CONSTRAINT [DF_ias_ias_toitem] DEFAULT ('') FOR [ias_toitem],
	CONSTRAINT [DF_ias_ias_cancel] DEFAULT ('') FOR [ias_cancel]
GO

ALTER TABLE [dbo].[mfr] WITH NOCHECK ADD 
	CONSTRAINT [DF_mfr1_mfr_iaddr] DEFAULT ('') FOR [mfr_iaddr]
GO

ALTER TABLE [dbo].[mfr1a] WITH NOCHECK ADD 
	CONSTRAINT [DF_mfr_mfr_iaddr] DEFAULT ('') FOR [mfr_iaddr]
GO

ALTER TABLE [dbo].[or_trans_test] WITH NOCHECK ADD 
	CONSTRAINT [DF_or_trans_test_syscd] DEFAULT ('') FOR [syscd],
	CONSTRAINT [DF_or_trans_test_custno] DEFAULT ('') FOR [custno],
	CONSTRAINT [DF_or_trans_test_otp1cd] DEFAULT ('') FOR [otp1cd],
	CONSTRAINT [DF_or_trans_test_otp1seq] DEFAULT ('') FOR [otp1seq],
	CONSTRAINT [DF_or_trans_test_oritem] DEFAULT ('') FOR [oritem]
GO

ALTER TABLE [dbo].[t_pb1b] WITH NOCHECK ADD 
	CONSTRAINT [DF_t_pb1_new_custno] DEFAULT ('') FOR [new_custno]
GO

ALTER TABLE [dbo].[t_pb2] WITH NOCHECK ADD 
	CONSTRAINT [DF_t_pb2_new_custno] DEFAULT ('') FOR [new_custno]
GO

 CREATE  UNIQUE  INDEX [c1_order_x] ON [dbo].[c1_order_special]([o_syscd], [o_custno], [o_otp1cd], [o_otp1seq]) ON [PRIMARY]
GO

 CREATE  INDEX [idinvno] ON [dbo].[inv20]([inv20_invno]) ON [PRIMARY]
GO

 CREATE  INDEX [idprojno] ON [dbo].[inv20]([inv20_projno]) ON [PRIMARY]
GO

 CREATE  INDEX [idcontno] ON [dbo].[inv20]([inv20_contno], [inv20_period]) ON [PRIMARY]
GO

 CREATE  INDEX [idchkno] ON [dbo].[inv20]([inv20_chkno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [mfr_x] ON [dbo].[mfr_imr]([mfr_mfrno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pk_cono] ON [dbo].[t_cono]([cono]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pk_conoe] ON [dbo].[t_cono_e]([cono]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_pb1_x] ON [dbo].[t_imr1]([orderno], [order_date_e]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_pb2_x] ON [dbo].[t_imr2]([orderno], [order_date_e]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_imr0506v5_x] ON [dbo].[t_imr20508v5]([orderno], [order_date_e]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pk_order2] ON [dbo].[t_order_2]([orderno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_pb1_x] ON [dbo].[t_pb1]([orderno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_pb2_x] ON [dbo].[t_pb2_copy]([orderno], [order_date_e]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_pb2_x] ON [dbo].[t_pb2a]([orderno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_pbupd1_x] ON [dbo].[t_pbupd1b]([orderno], [order_date_e]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [t_pbupd2_x] ON [dbo].[t_pbupd2_0502]([orderno], [order_date_e]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pk_cono] ON [dbo].[t_use_cono]([cono]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pk_use_order] ON [dbo].[t_use_order]([orderno]) ON [PRIMARY]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Results]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[Results]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[Sheet1$]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[Sheet2$]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[WebMember]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[WebMember]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[WebMember_ori]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[WebMember_ori]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[book]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[book]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[bookp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[bookp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[btp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[btp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_1_delete]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_1_delete]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_2_delete]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_2_delete]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_cust]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_cust]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_lost]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_lost]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_obtp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_obtp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_od]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_od]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_or]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_order]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_order]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ores]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_ores]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_otp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_otp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ramt]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_ramt]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_remail]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[c1_remail]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[c2_clr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_cont]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[c2_lost]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[c2_lprior]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[c2_ltp]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[c2_njtp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_or]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[c2_pgsize]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pub]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[cust]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[cust]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[hicard]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[hicard]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ia]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ia]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[iad]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[iad]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ias]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[ias]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inftmp20]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[inftmp20]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inv20]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[inv20]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[invmfr]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[itp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[itp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mailer]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[mailer]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[mfr]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mfr1a]  TO [public]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mfr1a]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mfr1a]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[mfr_imr]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mltp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[mltp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mtp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[mtp]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[or_trans_test]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatcol]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pbcatcol]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatedt]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pbcatedt]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatfmt]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pbcatfmt]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcattbl]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pbcattbl]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatvld]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pbcatvld]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[proj]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[proj]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[py]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[py]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyd]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pyd]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyseq]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pyseq]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pytp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[pytp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refd]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[refd]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refm]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[refm]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[retn_imr]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[rtp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[rtp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapiv]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[sapiv]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapivd]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[sapivd]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[saplog]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[saplog]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapvou]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[sapvou]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[srspn]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[srspn]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[syscd]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[syscd]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_bookp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_bookp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_btp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_btp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_clr]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_clr]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_cont]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_cont]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_cust]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_cust]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_ia]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_ia]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_itp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_itp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_ltp]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_ltp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_or]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_or]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_pub]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_pub]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_pub_orig]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_pub_orig]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t2_security]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t2_security]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_class1]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_class1]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_class2]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_class2]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_cono]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_cono_e]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_imr0506v5]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_imr1]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_imr2]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_imr20508v5]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_order_2]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pb1]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_pb1]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pb1b]  TO [public]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pb1b]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pb1b]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pb2]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pb2]  TO [mrlpub]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pb2]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_pb2_copy]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_pb2a]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pbupd1]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_pbupd1]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pbupd1a]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_pbupd1a]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pbupd1b]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_pbupd1b]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_pbupd2]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_pbupd2]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_pbupd2_0502]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_type1]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_type1]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[t_type2]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[t_type2]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_use_cono]  TO [webuser]
GO

GRANT  SELECT  ON [dbo].[t_use_order]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_t2_pub    Script Date: 2002/7/6 上午 11:23:35 ******/

/****** Object:  View dbo.v_t2_pub    Script Date: 2002/5/2 AM 08:48:23 ******/

CREATE VIEW dbo.v_t2_pub
AS
SELECT cont, yymm, clr, page, pgs, adamt, chgamt, '0' + bkcd AS bkcd, origjno, origjbkno, 
                  chgjno, ivno, remark, iano, pgs_mnt, remark2, new_mnt, okflag, moddate
FROM     dbo.t2_pub



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[v_t2_pub]  TO [mrlpub]
GO

GRANT  SELECT  ON [dbo].[v_t2_pub]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_0clear_c1cust_4seq    Script Date: 2002/7/6 上午 11:23:35 ******/

/****** Object:  Stored Procedure dbo.sp_c1_0clear_c1cust_4seq    Script Date: 2002/5/2 AM 08:48:24 ******/
CREATE proc dbo.sp_c1_0clear_c1cust_4seq
As
UPDATE c1_cust  
     SET cust_otp1seq1 = '000'   
UPDATE c1_cust  
     SET cust_otp1seq2 = '000' 
UPDATE c1_cust  
     SET cust_otp1seq3 = '000' 
UPDATE c1_cust  
     SET cust_otp1seq9 = '000' 
 DELETE FROM c1_order  
 DELETE FROM c1_or
 DELETE FROM c1_od
 DELETE FROM c1_ramt
 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_0clear_c1cust_4seq]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_0clear_c1cust_4seq]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.sp_c1_0trans_ready    Script Date: 2002/7/6 上午 11:23:35 ******/
/****** Object:  Stored Procedure dbo.sp_c1_0trans_ready    Script Date: 2002/5/2 AM 08:48:24 ******/
/*set ansi_nulls on*/
CREATE proc dbo.sp_c1_0trans_ready
As

begin 
set nocount on
delete from  itridpa.mrlpub.dbo.mfr
delete from  itridpa.mrlpub.dbo.c1_cust
delete from  itridpa.mrlpub.dbo.c1_order
delete from  itridpa.mrlpub.dbo.c1_od
delete from  itridpa.mrlpub.dbo.c1_or
delete from  itridpa.mrlpub.dbo.c1_ramt  

insert into  itridpa.mrlpub.dbo.mfr(
         mfr_mfrno,   
         mfr_inm,   
         mfr_iaddr,   
         mfr_izip,   
         mfr_respnm,   
         mfr_respjbti,   
         mfr_tel,   
         mfr_fax,   
         mfr_regdate)  
  SELECT mfr_mfrno,   
         mfr_inm,   
         mfr_iaddr,   
         mfr_izip,   
         mfr_respnm,   
         mfr_respjbti,   
         mfr_tel,   
         mfr_fax,   
         mfr_regdate  
 FROM isccom1.mrltest.dbo.mfr

insert into  itridpa.mrlpub.dbo.c1_cust(   cust_custno,   
           cust_nm,   
           cust_jbti,   
           cust_mfrno,   
           cust_tel,   
           cust_fax,   
           cust_cell,   
           cust_email,   
           cust_regdate,   
           cust_moddate,   
           cust_fgoi,   
           cust_fgoe,   
           cust_otp1seq1,   
           cust_otp1seq2,   
           cust_otp1seq3,   
           cust_otp1seq9,   
           cust_itpcd,   
           cust_btpcd,   
           cust_oldcustno1,   
           cust_oldcustno2  )  
   SELECT   cust_custno,   
           cust_nm,   
           cust_jbti,   
           cust_mfrno,   
           cust_tel,   
           cust_fax,   
           cust_cell,   
           cust_email,   
           cust_regdate,   
           cust_moddate,   
           cust_fgoi,   
           cust_fgoe,   
           cust_otp1seq1,   
           cust_otp1seq2,   
           cust_otp1seq3,   
           cust_otp1seq9,   
           cust_itpcd,   
           cust_btpcd,   
           cust_oldcustno1,   
           cust_oldcustno2  
    FROM isccom1.mrltest.dbo.c1_cust

insert into  itridpa.mrlpub.dbo.c1_order(   o_syscd,   
            o_custno,   
            o_otp1cd,   
            o_otp1seq,   
            o_otp2cd,   
            o_mfrno,   
            o_inm,   
            o_ijbti,   
            o_iaddr,   
            o_izip,   
            o_itel,   
            o_ifax,   
            o_icell,   
            o_iemail,   
            o_pytpcd,   
            o_fgpreinv,   
            o_date,   
            o_moddate,   
            o_oldvdate,   
            o_empno,   
            o_xmldata,   
            o_orescd,   
            o_invcd,   
            o_taxtp, 
o_cancel,   
            o_indate,   
            o_iano  )  
  SELECT    o_syscd,   
            o_custno,   
            o_otp1cd,   
            o_otp1seq,   
            o_otp2cd,   
            o_mfrno,   
            o_inm,   
            o_ijbti,   
            o_iaddr,   
            o_izip,   
            o_itel,   
            o_ifax,   
            o_icell,   
            o_iemail,   
            o_pytpcd,   
            o_fgpreinv,   
            o_date,   
            o_moddate,   
            o_oldvdate,   
            o_empno,   
            o_xmldata,   
            o_orescd,   
            o_invcd,   
            o_taxtp,
            '0','',''  
    FROM  isccom1.mrltest.dbo.c1_order   



insert into  itridpa.mrlpub.dbo.c1_od(   od_syscd,   
            od_custno,   
            od_otp1cd,   
            od_otp1seq,   
            od_oditem,   
            od_sdate,   
            od_edate,   
            od_btpcd,   
            od_projno,   
            od_costctr,   
            od_remark,   
            od_amt  )  
  SELECT    od_syscd,   
            od_custno,   
            od_otp1cd,   
            od_otp1seq,   
            od_oditem,   
            od_sdate,   
            od_edate,   
            od_btpcd,   
            od_projno,   
            od_costctr,   
            od_remark,   
            od_amt  
    FROM isccom1.mrltest.dbo.c1_od   


insert into  itridpa.mrlpub.dbo.c1_or(   or_syscd,   
            or_custno,   
            or_otp1cd,   
            or_otp1seq,   
            or_oritem,   
            or_inm,   
            or_nm,   
            or_jbti,   
            or_addr,   
            or_zip,   
            or_tel,   
            or_fax,   
            or_cell,   
            or_email,   
            or_fgmosea )  
  SELECT    or_syscd,   
            or_custno,   
            or_otp1cd,   
            or_otp1seq,   
            or_oritem,   
            or_inm,   
            or_nm,   
            or_jbti,   
            or_addr,   
            or_zip,   
            or_tel,   
            or_fax,   
            or_cell,   
            or_email,   
            or_fgmosea  
    FROM  isccom1.mrltest.dbo.c1_or   
 
insert into  itridpa.mrlpub.dbo.c1_ramt(   ra_syscd,   
           ra_custno,   
           ra_otp1cd,   
           ra_otp1seq,   
           ra_oditem,   
           ra_oritem,   
           ra_mnt,   
           ra_mtpcd  )
SELECT   ra_syscd,   
           ra_custno,   
           ra_otp1cd,   
           ra_otp1seq,   
           ra_oditem,   
           ra_oritem,   
           ra_mnt,   
           ra_mtpcd  
    FROM  isccom1.mrltest.dbo.c1_ramt   

  

set nocount off

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_0trans_ready]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_001    Script Date: 2002/7/6 上午 11:23:36 ******/

/****** Object:  Stored Procedure dbo.sp_c1_1trans_001    Script Date: 2002/5/2 AM 08:48:24 ******/

CREATE proc dbo.sp_c1_1trans_001 

/*delete 有mark之t_pb1*/
as
begin 
delete from  t_pb1
where t_pb1.orderno  in (  
SELECT t_pb1.orderno  
    FROM t_pb1,   
         c1_1_delete  
   WHERE ( t_pb1.orderno = c1_1_delete.orderno ) and  
         ( ( c1_1_delete.delete_mark = '*' ) ) )   



end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_001]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_001]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_002    Script Date: 2002/7/6 上午 11:23:36 ******/

/****** Object:  Stored Procedure dbo.sp_c1_1trans_002    Script Date: 2002/5/2 AM 08:48:25 ******/

CREATE proc dbo.sp_c1_1trans_002 
as
begin 
set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
DECLARE   @s_custno char(6), @custno int

select @custno = 0
 
/*產生c1_cust for 工材*/

begin  distributed transaction  tran_1
 
DECLARE  order_cursor  CURSOR FOR            
 SELECT
         orderno,
         name,   
         title,      
         tel,   
         fax,   
         movetel,   
         e_mail,   
         new_date,   
         orderno_temp,
         cono 
    FROM  t_pb1
   WHERE (substring (orderno,1,1)  <>  'E' )
/* open the cursor */
open order_cursor
/* Declare some variables to hold results.*/
DECLARE   @orderno char(7), @name char(60), @title char(12)  
DECLARE  @tel char(25), @fax char(25), @movetel char(50)
DECLARE  @e_mail char(50), @new_date char(8), @cono char(10)
DECLARE  @orderno_temp char(2) 



/* get the first row from the cursor */
FETCH  NEXT FROM  order_cursor INTO
         @orderno, @name, @title,   @tel,   @fax,   @movetel,   
         @e_mail,   @new_date, @orderno_temp, @cono 

WHILE (@@FETCH_STATUS = 0)
BEGIN
select @custno = @custno + 1
select @s_custno =  convert(char(6), @custno) 
SELECT  @s_custno  = 
      CASE 
         WHEN @custno> 0 and @custno < 10 THEN '00000' + @s_custno
         WHEN  @custno > 9 and @custno < 100 THEN '0000' + @s_custno   
         WHEN  @custno >99 and @custno < 1000 THEN '000' + @s_custno
         WHEN  @custno > 999 and @custno < 10000 THEN '00' + @s_custno
         WHEN  @custno > 9999 and @custno < 100000 THEN '0' + @s_custno      
      END  


Insert  into  c1_cust (cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email,
 cust_regdate, cust_moddate, cust_fgoi, cust_fgoe, cust_oldcustno1, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9,
 cust_itpcd, cust_btpcd,cust_oldcustno2)  
values (@s_custno, @name, @title, @cono, @tel, @fax, @movetel,
@e_mail, @new_date, @new_date, '1', '0', @orderno, '000', '000',
 '000', '000', '', '','')



FETCH  NEXT FROM  order_cursor INTO
         @orderno, @name, @title,   @tel,   @fax,   @movetel,   
         @e_mail,   @new_date, @orderno_temp, @cono 

END
/*SET IDENTITY_INSERT c1_cust off */
commit transaction  tran_1 
CLOSE  order_cursor                                                                                                                                     
DEALLOCATE  order_cursor
                       
set nocount off 
           
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_002]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_002]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_003    Script Date: 2002/7/6 上午 11:23:36 ******/

/****** Object:  Stored Procedure dbo.sp_c1_1trans_003    Script Date: 2002/5/2 AM 08:48:25 ******/

CREATE proc dbo.sp_c1_1trans_003
/*將新的客戶編號寫回t_pb1 */
as
begin 
UPDATE t_pb1  
     SET new_custno =  ''  
    FROM t_pb1

UPDATE t_pb1  
     SET new_custno =  c1_cust.cust_custno  
    FROM t_pb1,   
         c1_cust  
   WHERE ( t_pb1.orderno = c1_cust.cust_oldcustno1 ) 

end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_003]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_003]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_004    Script Date: 2002/7/6 上午 11:23:36 ******/

/****** Object:  Stored Procedure dbo.sp_c1_1trans_004    Script Date: 2002/5/2 AM 08:48:25 ******/

/*產生工材訂單主檔,明細,收件人檔,收件數量檔(c1_order, c1_od, c1_or, c1_ramt)*/
CREATE proc dbo.sp_c1_1trans_004
as
begin 

set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
/*FOR t_pb1-- Declare some variables to hold results.*/
DECLARE   @orderno char(7), @name char(60), @title char(12), @address char(250) 
DECLARE  @tel char(25), @fax char(25), @movetel char(50)
DECLARE  @e_mail char(50), @new_date char(8), @addr_id char(3), @cono char(10)


/* for c1_cust */
DECLARE   @custno char(6)

/* for t_pbupd1 --Declare some variables to hold results.*/
DECLARE   @order_date_e char(8), @order_date_b char(8), @amt real  
DECLARE  @remark char(20), @o_date char(8)

/*-----*/
DECLARE  @seq int, @s_seq char(3), @otp1cd char(2), @otp2cd char(2)
DECLARE  @fgmosea char(1), @mtpcd char(2), @orderno_temp char(7)
DECLARE  @mnt int
 
/*產生c1_order  for 工材*/

begin  distributed transaction  tran_1
 
DECLARE  pb_cursor  CURSOR FOR            
   SELECT a.orderno,   
          a.name,   
          a.title,   
          a.address,   
          a.tel,   
          a.movetel,   
          a.fax,   
          a.e_mail,   
          a.new_date,   
          a.addr_id,   
          a.cono,   
          b.order_date_e,   
          b.order_date_b,   
          b.amt,   
          b.remark,   
          b.o_date,   
          a.new_custno  
    FROM t_pb1   a,   
         t_pbupd1
   b 
   WHERE (a.orderno = b.orderno ) and  
           (substring ( a.orderno,1,1)  <>  'E' )    
open  pb_cursor

/* get the first row from the cursor */
FETCH  NEXT FROM  pb_cursor into
         @orderno,   
         @name,   
         @title,   
         @address,   
         @tel,   
         @movetel,   
         @fax,   
         @e_mail,   
         @new_date,   
         @addr_id,   
         @cono,   
         @order_date_e,   
         @order_date_b,   
         @amt,   
         @remark,   
         @o_date,   
         @custno   
select @orderno_temp = '0'  


WHILE (@@FETCH_STATUS = 0)
BEGIN
/* 訂單序號*/
/*對於一個新客戶之訂單,且此客戶之訂單又不是t_pb1之第一筆*/
/*將(客戶代碼+訂購類別一)之目前之序號存回到 c1_cust中*/
if @orderno <> @orderno_temp and @orderno_temp <>'0'
begin 
  if @otp1cd = '01' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq1 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
  else if @otp1cd = '02' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
else if @otp1cd = '03' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
end
/*對於一個新客戶之訂單*/
if @orderno <> @orderno_temp  

begin
/*訂購類別一@otp1cd */
select @otp1cd =
case
         when substring(@orderno,1,1) 
in ('A', 'B','C', 'D', 'E', 'F', 'G')
then '01'
when substring(@orderno,1,1) 
in ('H', 'I', 'J','K', 'L', 'M', 'N', 'O', 'P')
then '02'
ELSE '03'
END
 


/*找訂購類別二代碼o_otp2cd*/
select @otp2cd =
     case
when substring(@orderno,1,1) 
in ('N')
then '09'
when substring(@orderno,1,1) 
in ('J')
then '08'
when substring(@orderno,1,1) 
in ('H', 'P')
then '05'
when substring(@orderno,1,1) 
in ('O')
then '04'
when substring(@orderno,1,2) 
in ('FA', 'M0')
then '03'
when substring(@orderno,1,1) 
in ('F', 'K')
then '02'

ELSE '01'
END
/*以訂購類別一代碼@otp1cd 找出目前此(客戶+訂購類別一)之序號*/
if @otp1cd = '01' 
begin 
  select @s_seq = c1_cust.cust_otp1seq1  
    FROM c1_cust  
   WHERE c1_cust.cust_custno = @custno
end
else if @otp1cd = '02' 
begin 
  select @s_seq = c1_cust.cust_otp1seq2  
    FROM c1_cust  
   WHERE c1_cust.cust_custno = @custno 
end
else if @otp1cd = '03' 
begin 
  select @s_seq = c1_cust.cust_otp1seq3  
    FROM c1_cust  
   WHERE c1_cust.cust_custno = @custno 
end
/*----end for-----找出目前此(客戶+訂購類別一)之序號*/  
select @seq = convert(int, @s_seq) 
select @orderno_temp = @orderno
end
/*------end for 新客戶之訂單*/
select @seq = @seq + 1
select @s_seq =  convert(char(3), @seq) 
SELECT  @s_seq  = 
      CASE 
         WHEN @seq > 0 and @seq < 10 THEN '00' + @s_seq
         WHEN  @seq > 9 and @seq < 100 THEN '0' + @s_seq             
      END  

/*訂單主檔*/
Insert  into  c1_order (o_syscd,   
         o_custno,   
         o_otp1cd,   
         o_otp1seq,   
         o_otp2cd,   
         o_mfrno,   
         o_inm,   
         o_ijbti,   
         o_iaddr,   
         o_izip,   
         o_itel,   
         o_ifax,   
         o_icell,   
         o_iemail,   
         o_pytpcd,   
         o_fgpreinv,   
         o_date,   
         o_moddate,   
         o_oldvdate,   
         o_empno,   
         o_xmldata,   
         o_orescd,   
         o_invcd,   
         o_taxtp  )  
values ('C1', @custno, @otp1cd, @s_seq, @otp2cd,
@cono, @name, @title, @address, @addr_id, @tel, @fax, @movetel,
@e_mail, '99', '9', @o_date, @new_date, @o_date, '999999', '', '1', '9', '9')
/*雜誌收件人檔*/
select @fgmosea =
     CASE
         when substring(@orderno,1,2) 
in ('EB', 'G0','H0', 'I0')
then '1'
ELSE '0'
END
Insert  into  c1_or( 
         or_syscd,   
         or_custno,   
         or_otp1cd,   
         or_otp1seq,   
         or_oritem,   
         or_nm,   
         or_jbti,   
         or_addr,   
         or_zip,   
         or_tel,   
         or_fax,   
         or_cell,   
         or_email,   
         or_fgmosea  )  
values ('C1', @custno, @otp1cd, @s_seq, '01', 
@name, @title, @address, @addr_id, @tel, @fax, @movetel,
@e_mail, @fgmosea)

/*訂購明細檔select @btpcd = @otp1cd + '1'-----不要*/
Insert  into  c1_od(   
         od_syscd,   
         od_custno,   
         od_otp1cd,   
         od_otp1seq,   
         od_oditem,   
         od_sdate,   
         od_edate,   
         od_btpcd,   
         od_projno,   
         od_costctr,   
         od_remark,   
         od_amt     
        )  
values ('C1', @custno, @otp1cd, @s_seq, '01',
@order_date_b, @order_date_e, '01', 'ZZZZZZZZZZ', 'ZZZZZZZ', @remark, @amt)

/*郵寄數量檔*/
select @mtpcd =
     CASE
         when substring(@orderno,1,2) 
in ('C0', 'EC','J0')
then '19'
when substring(@orderno,1,2) 
in ('D0', 'EA')
then '12'
when substring(@orderno,1,2) 
in ('EB', 'G0','H0', 'I0')
then '21'
ELSE '11'
END
select @mnt =
     CASE
         when substring(@orderno,1,2) = 'BA'
then 99
     else 1
end 
Insert  into  c1_ramt(    
         ra_syscd,   
         ra_custno,   
         ra_otp1cd,   
         ra_otp1seq,   
         ra_oditem,   
         ra_oritem,   
         ra_mnt,   
         ra_mtpcd    )  
values ('C1', @custno, @otp1cd, @s_seq, '01', '01',1, @mtpcd)



FETCH  NEXT FROM  pb_cursor into
         @orderno,   
         @name,   
         @title,   
         @address,   
         @tel,   
         @movetel,   
         @fax,   
         @e_mail,   
         @new_date,   
         @addr_id,   
         @cono,   
         @order_date_e,   
         @order_date_b,   
         @amt,   
         @remark,   
         @o_date,   
         @custno  

END

if @otp1cd = '01' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq1 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
  else if @otp1cd = '02' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
else if @otp1cd = '03' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end


/*SET IDENTITY_INSERT c1_cust off */
commit transaction  tran_1 
CLOSE  pb_cursor                                                                                                                                     
DEALLOCATE  PB_cursor
                       
set nocount off            

          
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_004]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_004]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_1trans_005    Script Date: 2002/7/6 上午 11:23:37 ******/

/****** Object:  Stored Procedure dbo.sp_c1_1trans_005    Script Date: 2002/5/2 AM 08:48:25 ******/

/*update工材客戶檔之各種工材_訂購類別一之訂單客戶序號*/
CREATE proc dbo.sp_c1_1trans_005
as
begin 

set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
/*FOR t_pb1-- Declare some variables to hold results.*/
DECLARE   @custno  char(6),   
            @otp1cd  char(2),   
            @otp1seq  char(3)

begin  distributed transaction  tran_1
 
DECLARE  order_cursor  CURSOR FOR            
     SELECT c1_order.o_custno,   
         c1_order.o_otp1cd,   
         max(c1_order.o_otp1seq)  
    FROM c1_order  
GROUP BY c1_order.o_custno,   
         c1_order.o_otp1cd  
ORDER BY c1_order.o_custno ASC,   
         c1_order.o_otp1cd ASC   
      
open  order_cursor

/* get the first row from the cursor */
FETCH  NEXT FROM  order_cursor into
         @custno,   
            @otp1cd,   
            @otp1seq
           
WHILE (@@FETCH_STATUS = 0)
BEGIN

/*將(客戶代碼+訂購類別一)之目前之序號存回到 c1_cust中*/
if @otp1cd = '01' 
begin
UPDATE c1_cust  
     SET cust_otp1seq1 = @otp1seq  
   WHERE c1_cust.cust_custno = @custno
end 
else if @otp1cd = '02' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @otp1seq  
       WHERE c1_cust.cust_custno = @custno
    end
else if @otp1cd = '03' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq3 = @otp1seq  
       WHERE c1_cust.cust_custno = @custno
    end




FETCH  NEXT FROM  order_cursor into
         @custno,   
            @otp1cd,   
            @otp1seq
  
       

END
commit transaction  tran_1 
CLOSE  order_cursor                                                                                                                                     
DEALLOCATE  order_cursor
                       
set nocount off            

          
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_005]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_1trans_005]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_001    Script Date: 2002/7/6 上午 11:23:37 ******/

/****** Object:  Stored Procedure dbo.sp_c1_2trans_001    Script Date: 2002/5/2 AM 08:48:25 ******/

CREATE proc dbo.sp_c1_2trans_001 

/*delete 有mark之t_pb2*/
as
begin 
delete from  t_pb2
where t_pb2.orderno  in (  
SELECT t_pb2.orderno  
    FROM t_pb2,   
         c1_2_delete  
   WHERE ( t_pb2.orderno = c1_2_delete.orderno ) and  
         ( ( c1_2_delete.delete_mark = '*' ) ) )   



end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_001]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_001]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_002    Script Date: 2002/7/6 上午 11:23:37 ******/

/****** Object:  Stored Procedure dbo.sp_c1_2trans_002    Script Date: 2002/5/2 AM 08:48:25 ******/

CREATE proc dbo.sp_c1_2trans_002   
as
begin
/*先將t_pb2之 new_custno <-- ''  */

UPDATE t_pb2  
     SET new_custno = ''  ;
/*將t_pb1與t_pb2之客戶姓名,公司名,地址做比對,比對到者將t_pb1新客戶編號copy到t_pb2*/

UPDATE t_pb2  
     SET new_custno =  t_pb1.new_custno 
    FROM t_pb1,   
         t_pb2   
        
   WHERE ( t_pb1.name = t_pb2.name ) and  
         ( t_pb1.co = t_pb2.co ) and  
         ( t_pb1.address = t_pb2.address ) and  
         ( ( t_pb2.name <> '' ) AND  
         ( substring(t_pb2.orderno,1,1) <> 'E' ) )

   


UPDATE t_pb2  
     SET new_custno =  t_pb1.new_custno 
FROM t_pb1,   
         t_pb2
   
   WHERE ( t_pb1.name = t_pb2.name ) and  
         ( t_pb1.co = t_pb2.co ) and  
         ( t_pb1.address = t_pb2.address ) and  
         ( ( t_pb2.name = '' ) AND  
         ( t_pb2.co <> '' ) AND  
         ( substring(t_pb2.orderno,1,1) <> 'E' ) )   
 

end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_002]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_002]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_003    Script Date: 2002/7/6 上午 11:23:37 ******/

/****** Object:  Stored Procedure dbo.sp_c1_2trans_003    Script Date: 2002/5/2 AM 08:48:26 ******/

CREATE proc dbo.sp_c1_2trans_003 

as
begin 
set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
UPDATE c1_cust  
     SET cust_oldcustno2 = orderno  
 
    FROM c1_cust,   
         t_pb2  
   WHERE ( c1_cust.cust_custno = t_pb2.new_custno ) 
 
set nocount off
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_003]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_003]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_004    Script Date: 2002/7/6 上午 11:23:38 ******/

/****** Object:  Stored Procedure dbo.sp_c1_2trans_004    Script Date: 2002/5/2 AM 08:48:26 ******/

CREATE proc dbo.sp_c1_2trans_004 
/*將新的客戶編號(c1_cust)回寫到t_pb2*/


as
begin 
set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
DECLARE   @s_custno char(6), @custno int
select  @custno = convert(int,  max(cust_custno)) from c1_cust
 
/*產生c1_cust for 電材*/

begin  distributed transaction  tran_1
 
DECLARE  order_cursor  CURSOR FOR            
 SELECT
         orderno,
         name,   
         title,      
         tel,   
         fax,   
         movetel,   
         e_mail,   
         new_date,   
         orderno_temp,
         cono,
         new_custno 
    FROM  t_pb2
   WHERE (substring (orderno,1,1)  <>  'E' )    
/* open the cursor */
open order_cursor
/* Declare some variables to hold results.*/
DECLARE   @orderno char(7), @name char(60), @title char(12)  
DECLARE  @tel char(25), @fax char(25), @movetel char(50)
DECLARE  @e_mail char(50), @new_date char(8), @cono char(10),@newcustno char(6)
DECLARE  @orderno_temp char(2) 



/* get the first row from the cursor */
FETCH  NEXT FROM  order_cursor INTO
         @orderno, @name, @title,   @tel,   @fax,   @movetel,   
         @e_mail,   @new_date, @orderno_temp, @cono, @newcustno 

WHILE (@@FETCH_STATUS = 0)
BEGIN
if @newcustno = '' 
begin 

select @custno = @custno + 1
select @s_custno =  convert(char(6), @custno) 
SELECT  @s_custno  = 
      CASE 
         WHEN @custno> 0 and @custno < 10 THEN '00000' + @s_custno
         WHEN  @custno > 9 and @custno < 100 THEN '0000' + @s_custno   
         WHEN  @custno >99 and @custno < 1000 THEN '000' + @s_custno
         WHEN  @custno > 999 and @custno < 10000 THEN '00' + @s_custno
         WHEN  @custno > 9999 and @custno < 100000 THEN '0' + @s_custno      
      END  


Insert  into  c1_cust (cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate,
 cust_moddate, cust_fgoi, cust_fgoe, cust_oldcustno1, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9,
 cust_itpcd, cust_btpcd, cust_oldcustno2)  
values (@s_custno, @name, @title, @cono, @tel, @fax, @movetel,
@e_mail, @new_date, @new_date, '1', '0', '', '000', '000',
 '000', '000', '', '',@orderno)

end 

FETCH  NEXT FROM  order_cursor INTO
         @orderno, @name, @title,   @tel,   @fax,   @movetel,   
         @e_mail,   @new_date, @orderno_temp, @cono, @newcustno 

END
/*SET IDENTITY_INSERT c1_cust off */
commit transaction  tran_1 
CLOSE  order_cursor                                                                                                                                     
DEALLOCATE  order_cursor
                       
set nocount off            
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_004]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_004]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_005    Script Date: 2002/7/6 上午 11:23:38 ******/

/****** Object:  Stored Procedure dbo.sp_c1_2trans_005    Script Date: 2002/5/2 AM 08:48:26 ******/

CREATE proc dbo.sp_c1_2trans_005 
/*將新的客戶編號(c1_cust)回寫到t_pb2*/

as
begin 
UPDATE t_pb2  
     SET new_custno =  c1_cust.cust_custno  
    FROM t_pb2,   
         c1_cust  
   WHERE ( t_pb2.orderno = c1_cust.cust_oldcustno2 )  

end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_005]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_005]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_006    Script Date: 2002/7/6 上午 11:23:38 ******/

/****** Object:  Stored Procedure dbo.sp_c1_2trans_006    Script Date: 2002/5/2 AM 08:48:26 ******/

CREATE proc dbo.sp_c1_2trans_006
/*產生電材訂單主檔,明細,收件人檔,收件數量檔(c1_order, c1_od, c1_or, c1_ramt)*/
as
begin 

set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
/*FOR t_pb1-- Declare some variables to hold results.*/
DECLARE   @orderno char(7), @name char(60), @title char(12), @address char(250) 
DECLARE  @tel char(25), @fax char(25), @movetel char(50)
DECLARE  @e_mail char(50), @new_date char(8), @addr_id char(3), @cono char(10)


/* for c1_cust */
DECLARE   @custno char(6)

/* for t_pbupd1 --Declare some variables to hold results.*/
DECLARE   @order_date_e char(8), @order_date_b char(8), @amt real  
DECLARE  @remark char(20), @o_date char(8)

/*-----*/
DECLARE  @seq int, @s_seq char(3), @otp1cd char(2), @otp2cd char(2)
DECLARE  @fgmosea char(1), @mtpcd char(2), @orderno_temp char(7)
DECLARE  @mnt int
 
/*產生c1_order  for 工材*/

begin  distributed transaction  tran_1
 
DECLARE  pb_cursor  CURSOR FOR            
   SELECT a.orderno,   
          a.name,   
          a.title,   
          a.address,   
          a.tel,   
          a.movetel,   
          a.fax,   
          a.e_mail,   
          a.new_date,   
          a.addr_id,   
          a.cono,   
          b.order_date_e,   
          b.order_date_b,   
          b.amt,   
          b.remark,   
          b.o_date,   
          a.new_custno  
    FROM t_pb2   a,   
         t_pbupd2  b 
   WHERE (a.orderno = b.orderno ) and  
           (substring ( a.orderno,1,1)  <>  'E' )    
open  pb_cursor

/* get the first row from the cursor */
FETCH  NEXT FROM  pb_cursor into
         @orderno,   
         @name,   
         @title,   
         @address,   
         @tel,   
         @movetel,   
         @fax,   
         @e_mail,   
         @new_date,   
         @addr_id,   
         @cono,   
         @order_date_e,   
         @order_date_b,   
         @amt,   
         @remark,   
         @o_date,   
         @custno   
select @orderno_temp = '0'  


WHILE (@@FETCH_STATUS = 0)
BEGIN
/* 訂單序號*/
/*對於一個新客戶之訂單,且此客戶之訂單又不是t_pb2之第一筆*/
/*將(客戶代碼+訂購類別一)之目前之序號存回到 c1_cust中*/
/* 由於不明原因此段run 後沒update,所以有下一支store procedure

if @orderno <> @orderno_temp and @orderno_temp <>'0'
begin 
  if @otp1cd = '01' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq1 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
  else if @otp1cd = '02' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
else if @otp1cd = '03' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
end
*/
/*對於一個新客戶之訂單*/
if @orderno <> @orderno_temp  

begin
/*訂購類別一@otp1cd */
select @otp1cd =
case
         when substring(@orderno,1,1) 
in ('A', 'B','C', 'D', 'E', 'F', 'G')
then '01'
when substring(@orderno,1,1) 
in ('H', 'I', 'J','K', 'L', 'M', 'N', 'O', 'P')
then '02'
ELSE '03'
END
 


/*找訂購類別二代碼o_otp2cd*/
select @otp2cd =
     case
when substring(@orderno,1,1) 
in ('N')
then '09'
when substring(@orderno,1,1) 
in ('J')
then '08'
when substring(@orderno,1,1) 
in ('H', 'P')
then '05'
when substring(@orderno,1,1) 
in ('O')
then '04'
when substring(@orderno,1,2) 
in ('FA', 'M0')
then '03'
when substring(@orderno,1,1) 
in ('F', 'K')
then '02'

ELSE '01'
END
/*以訂購類別一代碼@otp1cd 找出目前此(客戶+訂購類別一)之序號*/
if @otp1cd = '01' 
begin 
  select @s_seq = c1_cust.cust_otp1seq1  
    FROM c1_cust  
   WHERE c1_cust.cust_custno = @custno
end
else if @otp1cd = '02' 
begin 
  select @s_seq = c1_cust.cust_otp1seq2  
    FROM c1_cust  
   WHERE c1_cust.cust_custno = @custno 
end
else if @otp1cd = '03' 
begin 
  select @s_seq = c1_cust.cust_otp1seq3  
    FROM c1_cust  
   WHERE c1_cust.cust_custno = @custno 
end
/*----end for-----找出目前此(客戶+訂購類別一)之序號*/  
select @seq = convert(int, @s_seq) 
select @orderno_temp = @orderno
end
/*------end for 新客戶之訂單*/
select @seq = @seq + 1
select @s_seq =  convert(char(3), @seq) 
SELECT  @s_seq  = 
      CASE 
         WHEN @seq > 0 and @seq < 10 THEN '00' + @s_seq
         WHEN  @seq > 9 and @seq < 100 THEN '0' + @s_seq             
      END  

/*訂單主檔*/
Insert  into  c1_order (o_syscd,   
         o_custno,   
         o_otp1cd,   
         o_otp1seq,   
         o_otp2cd,   
         o_mfrno,   
         o_inm,   
         o_ijbti,   
         o_iaddr,   
         o_izip,   
         o_itel,   
         o_ifax,   
         o_icell,   
         o_iemail,   
         o_pytpcd,   
         o_fgpreinv,   
         o_date,   
         o_moddate,   
         o_oldvdate,   
         o_empno,   
         o_xmldata,   
         o_orescd,   
         o_invcd,   
         o_taxtp  )  
values ('C1', @custno, @otp1cd, @s_seq, @otp2cd,
@cono, @name, @title, @address, @addr_id, @tel, @fax, @movetel,
@e_mail, '99', '9', @o_date, @new_date, @o_date, '999999', '', '1', '9', '9')
/*雜誌收件人檔*/
select @fgmosea =
     CASE
         when substring(@orderno,1,2) 
in ('EB', 'G0','H0', 'I0')
then '1'
ELSE '0'
END
Insert  into  c1_or( 
         or_syscd,   
         or_custno,   
         or_otp1cd,   
         or_otp1seq,   
         or_oritem,   
         or_nm,   
         or_jbti,   
         or_addr,   
         or_zip,   
         or_tel,   
         or_fax,   
         or_cell,   
         or_email,   
         or_fgmosea  )  
values ('C1', @custno, @otp1cd, @s_seq, '01', 
@name, @title, @address, @addr_id, @tel, @fax, @movetel,
@e_mail, @fgmosea)

/*訂購明細檔select @btpcd = @otp1cd + '1'-----不要*/
Insert  into  c1_od(   
         od_syscd,   
         od_custno,   
         od_otp1cd,   
         od_otp1seq,   
         od_oditem,   
         od_sdate,   
         od_edate,   
         od_btpcd,   
         od_projno,   
         od_costctr,   
         od_remark,   
         od_amt     
        )  
values ('C1', @custno, @otp1cd, @s_seq, '01',
@order_date_b, @order_date_e, '02', 'ZZZZZZZZZZ', 'ZZZZZZZ', @remark, @amt)

/*郵寄數量檔*/
select @mtpcd =
     CASE
         when substring(@orderno,1,2) 
in ('C0', 'EC','J0')
then '19'
when substring(@orderno,1,2) 
in ('D0', 'EA')
then '12'
when substring(@orderno,1,2) 
in ('EB', 'G0','H0', 'I0')
then '21'
ELSE '11'
END
select @mnt =
     CASE
         when substring(@orderno,1,2) = 'BA'
then 99
     else 1
end 
Insert  into  c1_ramt(    
         ra_syscd,   
         ra_custno,   
         ra_otp1cd,   
         ra_otp1seq,   
         ra_oditem,   
         ra_oritem,   
         ra_mnt,   
         ra_mtpcd    )  
values ('C1', @custno, @otp1cd, @s_seq, '01', '01',1, @mtpcd)



FETCH  NEXT FROM  pb_cursor into
         @orderno,   
         @name,   
         @title,   
         @address,   
         @tel,   
         @movetel,   
         @fax,   
         @e_mail,   
         @new_date,   
         @addr_id,   
         @cono,   
         @order_date_e,   
         @order_date_b,   
         @amt,   
         @remark,   
         @o_date,   
         @custno  

END

/*
if @otp1cd = '01' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq1 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
  else if @otp1cd = '02' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end
else if @otp1cd = '03' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @s_seq  
       WHERE c1_cust.cust_custno = @orderno_temp
    end

*/
/*SET IDENTITY_INSERT c1_cust off */
commit transaction  tran_1 
CLOSE  pb_cursor                                                                                                                                     
DEALLOCATE  PB_cursor
                       
set nocount off            

          
end
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_006]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_006]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_2trans_007    Script Date: 2002/7/6 上午 11:23:38 ******/

/****** Object:  Stored Procedure dbo.sp_c1_2trans_007    Script Date: 2002/5/2 AM 08:48:27 ******/

/*update工材客戶檔之各種工材_訂購類別一之訂單客戶序號 */
/*與sp_c1_1trans_005同,也可不必run sp_c1_1trans_005,以此sp一次完成*/ 
CREATE proc dbo.sp_c1_2trans_007
as
begin 

set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
/*FOR t_pb1-- Declare some variables to hold results.*/
DECLARE   @custno  char(6),   
            @otp1cd  char(2),   
            @otp1seq  char(3)

begin  distributed transaction  tran_1
 
DECLARE  order_cursor  CURSOR FOR            
     SELECT c1_order.o_custno,   
         c1_order.o_otp1cd,   
         max(c1_order.o_otp1seq)  
    FROM c1_order  
GROUP BY c1_order.o_custno,   
         c1_order.o_otp1cd  
ORDER BY c1_order.o_custno ASC,   
         c1_order.o_otp1cd ASC   
      
open  order_cursor

/* get the first row from the cursor */
FETCH  NEXT FROM  order_cursor into
         @custno,   
            @otp1cd,   
            @otp1seq
           
WHILE (@@FETCH_STATUS = 0)
BEGIN

/*將(客戶代碼+訂購類別一)之目前之序號存回到 c1_cust中*/
if @otp1cd = '01' 
begin
UPDATE c1_cust  
     SET cust_otp1seq1 = @otp1seq  
   WHERE c1_cust.cust_custno = @custno
end 
else if @otp1cd = '02' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq2 = @otp1seq  
       WHERE c1_cust.cust_custno = @custno
    end
else if @otp1cd = '03' 
    begin 
       UPDATE c1_cust  
       SET cust_otp1seq3 = @otp1seq  
       WHERE c1_cust.cust_custno = @custno
    end




FETCH  NEXT FROM  order_cursor into
         @custno,   
            @otp1cd,   
            @otp1seq
  
       

END
commit transaction  tran_1 
CLOSE  order_cursor                                                                                                                                     
DEALLOCATE  order_cursor
                       
set nocount off            

          
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_007]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_2trans_007]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.sp_c1_order    Script Date: 2002/7/6 上午 11:23:38 ******/

/****** Object:  Stored Procedure dbo.sp_c1_order    Script Date: 2002/5/2 AM 08:48:24 ******/
CREATE procedure sp_c1_order
as
declare	@syscd char(2),	@custno char(6),@otp1cd char(2),@otp1seq char(3)
declare @ptrval varbinary(16),@xml varchar(8000)

DECLARE Order_Cursor CURSOR FOR
 select o_syscd,o_custno,o_otp1cd,o_otp1seq
 from c1_order
 where o_syscd='C1'  and o_custno='000002'  and o_otp1cd='01'  

OPEN Order_Cursor

FETCH NEXT FROM Order_Cursor
    into @syscd,@custno,@otp1cd,@otp1seq

WHILE @@FETCH_STATUS = 0
BEGIN
    
	set @xml = '<?xml version="1.0" encoding="big5" ?><root>' 
	set @xml = @xml + dbo.fn_c1_order(@syscd,@custno,@otp1cd,@otp1seq) 
	set @xml = @xml + dbo.fn_c1_or(@syscd,@custno,@otp1cd,@otp1seq,'01','0') 
	set @xml = @xml + dbo.fn_c1_od(@syscd,@custno,@otp1cd,@otp1seq)
	set @xml = @xml + '</root>'	

	update c1_order set o_xmldata=@xml
 	where o_syscd=@syscd and o_custno=@custno and o_otp1cd=@otp1cd and o_otp1seq=@otp1seq

 	-- select @ptrval = TEXTPTR(o_xmldata) 
 	-- from c1_order
 	-- where o_syscd=@syscd and o_custno=@custno and o_otp1cd=@otp1cd and o_otp1seq=@otp1seq
 	
 	-- WRITETEXT c1_order.o_xmldata @ptrval  @xml

    FETCH NEXT FROM Order_Cursor
    into @syscd,@custno,@otp1cd,@otp1seq
END

CLOSE Order_Cursor
DEALLOCATE Order_Cursor


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_order]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_order]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_xml_call_fns    Script Date: 2002/7/6 上午 11:23:39 ******/

/****** Object:  Stored Procedure dbo.sp_c2_xml_call_fns    Script Date: 2002/5/2 AM 08:48:24 ******/
CREATE procedure sp_c2_xml_call_fns
as

declare @syscd char(2),@contno char(6)
declare @ptrval varbinary(16),@xml varchar(8000)

/* 若要執行測試單筆資料, where 條件請輸入 where cont_syscd='C2' and cont_contno='000004' 
   若要執行全部資料, where 條件請輸入 where cont_syscd='C2'
*/
DECLARE ContAll_Cursor CURSOR FOR
 select cont_syscd,cont_contno
 from c2_cont
 where cont_syscd='C2' 


OPEN ContAll_Cursor

FETCH NEXT FROM ContAll_Cursor
    into @syscd,@contno

WHILE @@FETCH_STATUS = 0
BEGIN
    
	set @xml = '<?xml version="1.0" encoding="big5" ?>'
	set @xml = @xml + dbo.fn_c2_contAll(@syscd,@contno) 

	update c2_cont set cont_xmldata=@xml
 	where cont_syscd=@syscd and cont_contno=@contno


    FETCH NEXT FROM ContAll_Cursor
    into @syscd,@contno
END

CLOSE ContAll_Cursor
DEALLOCATE ContAll_Cursor
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_001    Script Date: 2002/7/6 上午 11:23:39 ******/

/****** Object:  Stored Procedure dbo.sp_c2trans_001    Script Date: 2002/5/2 AM 08:48:27 ******/

CREATE proc dbo.sp_c2trans_001  
as
begin 
set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
DECLARE   @s_custno char(6), @custno int

select @custno = 0
 
/*產生c2_cust for 平廣*/

/*begin  distributed transaction  tran_1因為會有重複所以不用,也就是重複資料不必insert */
 
DECLARE  cust_cursor  CURSOR FOR            
 SELECT t2_cust.custno,   
         t2_cust.mfrno,   
         t2_cust.name,   
         t2_cust.jbti,   
         t2_cust.mfrnm,   
         t2_cust.iraddr,   
         t2_cust.tel,   
         t2_cust.movetel,   
         t2_cust.fax,   
         t2_cust.e_mail,   
         t2_cust.irzip,   
         t2_cust.itpcd,   
         t2_cust.btpcd,   
         t2_cust.createdate,   
         t2_cust.respnjbti  
    FROM t2_cust      
/* open the cursor */
open cust_cursor
/* Declare some variables to hold results.*/
Declare  
@oldcustno char(5), 
@mfrno char(10),   
         @name char(60),   
         @jbti char(12),   
         @mfrnm char(100),   
         @iraddr char(200),   
         @tel char(25),   
         @movetel char(20),   
         @fax char(25),   
         @e_mail char(25),   
         @irzip char(3),   
         @itpcd char(50),   
         @btpcd char(50),   
         @createdate char(8),   
         @respnjbti char(8)  

/* get the first row from the cursor */
FETCH  NEXT FROM  cust_cursor INTO
         @oldcustno, @mfrno,   
         @name,   
         @jbti,   
         @mfrnm,   
         @iraddr,   
         @tel,   
         @movetel,   
         @fax,   
         @e_mail,   
         @irzip,   
         @itpcd,   
         @btpcd,   
         @createdate,   
         @respnjbti
WHILE (@@FETCH_STATUS = 0)
BEGIN
select @custno = @custno + 1
select @s_custno =  convert(char(6), @custno) 
SELECT  @s_custno  = 
      CASE 
         WHEN @custno> 0 and @custno < 10 THEN '00000' + @s_custno
         WHEN  @custno > 9 and @custno < 100 THEN '0000' + @s_custno   
         WHEN  @custno >99 and @custno < 1000 THEN '000' + @s_custno
         WHEN  @custno > 999 and @custno < 10000 THEN '00' + @s_custno
         WHEN  @custno > 9999 and @custno < 100000 THEN '0' + @s_custno      
      END  


Insert  into  cust (   
         cust_custno,   
         cust_nm,   
         cust_jbti,   
         cust_mfrno,   
         cust_tel,   
         cust_fax,   
         cust_cell,   
         cust_email,   
         cust_regdate,   
         cust_moddate,   
         cust_itpcd,   
         cust_btpcd,   
         cust_rtpcd,   
         cust_oldcustno,
         cust_origsyscd  )  
values (@s_custno, @name, @jbti, @mfrno, @tel, @fax, @movetel,
@e_mail, @createdate, '99999999', '','', '', @oldcustno, 'C2')
/*values (@s_custno, @name, @jbti, @mfrno, @tel, @fax, @movetel,
@e_mail, @createdate, '99999999', @itpcd, @btpcd, '', @oldcustno, 'C2')--2002/02/25modify*/

Insert  into  mfr (   
         mfr_mfrno,   
         mfr_inm,   
         mfr_iaddr,   
         mfr_izip,   
         mfr_respnm,   
         mfr_respjbti,   
         mfr_tel,   
         mfr_fax,   
         mfr_regdate   )  
values (@mfrno, @mfrnm, @iraddr, @irzip, @respnjbti, '',
@tel, @fax, @createdate)


FETCH  NEXT FROM  cust_cursor INTO
         @oldcustno, @mfrno,   
         @name,   
         @jbti,   
         @mfrnm,   
         @iraddr,   
         @tel,   
         @movetel,   
         @fax,   
         @e_mail,   
         @irzip,   
         @itpcd,   
         @btpcd,   
         @createdate,   
         @respnjbti
END
/*SET IDENTITY_INSERT c1_cust off */
/*commit transaction  tran_1  因為會有重複所以不用,也就是重複資料不必insert */

CLOSE  cust_cursor                                                                                                                                     
DEALLOCATE  cust_cursor
                       
set nocount off           
       
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_001]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_001]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_002    Script Date: 2002/7/6 上午 11:23:39 ******/

/****** Object:  Stored Procedure dbo.sp_c2trans_002    Script Date: 2002/5/2 AM 08:48:27 ******/

/*產生 合約檔*/
CREATE proc dbo.sp_c2trans_002
as
begin 

set nocount on

/*SET IDENTITY_INSERT c1_cust ON */ 
/*FOR t_pb1-- Declare some variables to hold results.*/
DECLARE   @cont  char(5),     
         @signdate char(8), 
         @old_custno   char(5),   
         @custnm  char(60),   
         @aunm char(50),   
         @autel char(50),   
         @aufax char(25),   
         @aucell char(20),   
         @au_bdate char(6),   
         @au_edate char(6),   
         @bkcd char(2),   
         @disc int,   
         @freetm int,   
         @totjtm int,   
         @madejtm int,   
         @tottm int,   
         @pubtm int,   
         @totamt real,   
         @paidamt real,   
         @chgamt real,   
         @freemnt int,   
         @closerk char(1),   
         @clrtm int,   
         @getclrtm int,   
         @menotm int,   
         @moddate char(8),   
         @mfrno char(10),   
         @iraddr char(200),   
         @irnm char(60),   
         @new_custno char(6), 
         @empno char(6)
declare @seq int, @s_seq char(6)


/*產生c2_cont */
------------------------------------------------91/02/07

begin  distributed transaction  tran_1
 
DECLARE  cont_cursor  CURSOR FOR            
    SELECT a.cont,   
         a.signdate,   
a.custno, 
         a.custnm,   
         a.aunm,   
         a.autel,   
         a.aufax,   
         a.aucell,   
         a.au_bdate,   
         a.au_edate,   
         a.bkcd,   
         a.disc,   
         a.freetm,   
         a.totjtm,   
         a.madejtm,   
         a.tottm,   
         a.pubtm,   
         a.totamt,   
         a.paidamt,   
         a.chgamt,   
         a.freemnt,   
         a.closerk,   
         a.clrtm,   
         a.getclrtm,   
         a.menotm,   
         a.moddate,   
         b.mfrno,   
         b.iraddr,   
         b.irnm,   
         c.cust_custno, 
         d.empno  
    FROM  t2_cont   a,   
         t2_cust    b,   
         cust    c,
         t2_security d 
   WHERE ( a.custno = b.custno ) and  
         ( b.custno = c.cust_oldcustno ) and
         ( a.empno = d.s_code )         
open  cont_cursor

/* get the first row from the cursor */
FETCH  NEXT FROM  cont_cursor into
         @cont,     
         @signdate, 
         @old_custno,   
         @custnm,   
         @aunm,   
         @autel,   
         @aufax,   
         @aucell,   
         @au_bdate,   
         @au_edate,   
         @bkcd,   
         @disc,   
         @freetm,   
         @totjtm,   
         @madejtm,   
         @tottm,   
         @pubtm,   
         @totamt,   
         @paidamt,   
         @chgamt,   
         @freemnt,   
         @closerk,   
         @clrtm,   
         @getclrtm,   
         @menotm,   
         @moddate,   
         @mfrno,   
         @iraddr,   
         @irnm,
         @new_custno,   
         @empno
  
select @seq = 0  
WHILE (@@FETCH_STATUS = 0)
BEGIN
/* 合約號碼*/
select @seq = @seq + 1
select @s_seq =  convert(char(6), @seq) 
SELECT  @s_seq  = 
      CASE 
         WHEN @seq > 0 and @seq < 10 THEN '00000' + @s_seq
         WHEN  @seq > 9 and @seq < 100 THEN '0000' + @s_seq
WHEN  @seq > 99 and @seq < 1000 THEN '000' + @s_seq
WHEN  @seq > 999 and @seq < 10000 THEN '00' + @s_seq
WHEN  @seq > 9999 and @seq < 100000 THEN '0' + @s_seq             
      END  
----------------------------------------------------------------------------------------
select @bkcd = '0' + @bkcd
/*合約檔*/
Insert  into  c2_cont (
         cont_syscd,           
         cont_contno,  
            
         cont_conttp,   
         cont_bkcd,   
         cont_signdate,   
         cont_empno,   
         cont_mfrno,   
         cont_aunm,   
         cont_autel,   
         cont_aufax,   
         cont_aucell,   
         cont_auemail,   
         cont_sdate,   
         cont_edate,   
         cont_totjtm,   
         cont_madejtm,   
         cont_restjtm,   
         cont_disc,   
         cont_freetm,       
         cont_fgclosed,   
         cont_tottm,   
         cont_pubtm,   
         cont_resttm,
 
         cont_chgjtm, 
cont_custno,   
         cont_totamt,   
         cont_pubamt,   
         cont_chgamt,   
         cont_paidamt,   
         cont_restamt,   
         cont_clrtm,   
         cont_menotm,   
         cont_getclrtm,   
         cont_oldcontno,   
         cont_irnm,   
         cont_iraddr,   
         cont_irzip,   
         cont_irtel,   
         cont_irfax,   
         cont_ircell,   
         cont_iremail,   
         cont_moddate,   
         cont_invcd,   
         cont_taxtp,   
         cont_fgpayonce,   
         cont_fgitri,   
         cont_xmldata  )
    values ('C2', @s_seq, '01', @bkcd, @signdate, @empno, @mfrno, @aunm,    
           @autel,  @aufax,   @aucell, '', @au_bdate,   @au_edate, @totjtm,  
           @madejtm, 0, @disc, @freetm, @closerk, @tottm,   @pubtm, 0, 0,  
           @new_custno, @totamt, 0, @chgamt, @paidamt, 0, @clrtm,  
           @menotm, @getclrtm, @cont, @irnm, @iraddr, '', '', '', '', '', @moddate,             '9', '9', '9', '99', '')

FETCH  NEXT FROM  cont_cursor  into
         @cont,     
         @signdate, 
         @old_custno,   
         @custnm,   
         @aunm,   
         @autel,   
         @aufax,   
         @aucell,   
         @au_bdate,   
         @au_edate,   
         @bkcd,   
         @disc,   
         @freetm,   
         @totjtm,   
         @madejtm,   
         @tottm,   
         @pubtm,   
         @totamt,   
         @paidamt,   
         @chgamt,   
         @freemnt,   
         @closerk,   
         @clrtm,   
         @getclrtm,   
         @menotm,   
         @moddate,   
         @mfrno,   
         @iraddr,   
         @irnm,
         @new_custno,   
         @empno

END
/*SET IDENTITY_INSERT c1_cust off */
commit transaction  tran_1 
CLOSE  cont_cursor                                                                                                                                     
DEALLOCATE  cont_cursor
                       
set nocount off            

          
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_002]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_002]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_003    Script Date: 2002/7/6 上午 11:23:39 ******/

/****** Object:  Stored Procedure dbo.sp_c2trans_003    Script Date: 2002/5/2 AM 08:48:27 ******/

/*產生 合約檔*/
CREATE proc dbo.sp_c2trans_003
as
begin 

set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
/*FOR t_pb1-- Declare some variables to hold results.*/
DECLARE @syscd char(2),
         @contno char(6),   
         @name  char(30),   
         @addr char(100),   
         @zip char(5),
         @mtpcd char(1),   
         @datasrce char(1),  
         @buy_mnt int,   
         @free_mnt int,   
         @fgmosea char(1),    
         @ori_name char(60),   
         @ori_jbti char(12),   
         @ori_tel char(25),   
         @ori_movetel char(20),   
         @ori_fax char(25),   
         @ori_e_mail char(25),   
         @ori_irzip char(3),   
         @ori_fgmosea char(1),
         @mfrnm char(100)
declare @seq int, @s_seq char(2), @cont_temp char(6)
declare @inm  char(30),
       @jbti  char(12),   
       @tel char(12),   
       @movetel char(12),   
       @fax char(12),   
       @e_mail char(80)
 
/*產生c2_or 雜誌收件人檔 */
begin  distributed transaction  tran_1
 
DECLARE  or_cursor  CURSOR FOR            
        SELECT b.cont_syscd,   
         b.cont_contno,   
         a.name,   
         a.addr,   
         a.zip,   
         a.mtpcd,   
         a.datasrce,   
         a.buy_mnt,   
         a.free_mnt,   
         a.fgmosea,   
         c.name,   
         c.jbti,    
         c.tel,   
         c.movetel,   
         c.fax,   
         c.e_mail,   
         c.irzip,   
         c.fgmosea,
c.mfrnm  
    FROM c2_cont  b,   
         t2_or     a,   
         t2_cust    c,
         cust      d  
   WHERE ( b.cont_oldcontno = a.contno ) and  
         ( d.cust_oldcustno = c.custno )  and
         ( b.cont_custno = d.cust_custno)    

open  or_cursor

/* get the first row from the cursor */
FETCH  NEXT FROM  or_cursor into
         @syscd,   
         @contno,   
         @name,   
         @addr,   
         @zip, 
         @mtpcd,
         @datasrce,  
         @buy_mnt,   
         @free_mnt,     
         @fgmosea,   
         @ori_name,   
         @ori_jbti,   
         @ori_tel,   
         @ori_movetel,   
         @ori_fax,   
         @ori_e_mail,   
         @ori_irzip,   
         @ori_fgmosea,
         @mfrnm             
  
select @cont_temp = '99999' 
select @seq = 0  
WHILE (@@FETCH_STATUS = 0)
BEGIN
/*多個收件人處理(同一合約)*/
if @contno = @cont_temp
begin
    select @seq = @seq + 1
end 
else
begin
select @seq = 1
select @cont_temp = @contno
end
select @s_seq =  convert(char(2), @seq) 
SELECT  @s_seq  = 
      CASE 
         WHEN @seq > 0 and @seq < 10 THEN '0' + @s_seq
         WHEN  @seq > 9 and @seq < 100 THEN  @s_seq             
      END  
----------------------------------------------------------------------------------------
if @name = ''
  begin
      select @inm =  @mfrnm
      select @name = @ori_name
select @jbti =  @ori_jbti   
      select @tel = @ori_tel   
      select @movetel = @ori_movetel   
      select  @fax =   @ori_fax   
      select  @e_mail =   @ori_e_mail 
end 
else 
begin 
    select @inm =  ''
     
    select @jbti =  ''   
      select @tel = ''   
      select @movetel = ''   
      select  @fax =   ''   
      select  @e_mail =   ''
end     
     
/*收件人檔*/
Insert  into  c2_or (or_syscd,   
         or_contno,   
         or_oritem,   
         or_inm,   
         or_nm,   
         or_jbti,   
         or_addr,   
         or_zip,   
         or_tel,   
         or_fax,   
         or_cell,   
         or_email,   
         or_mtpcd,   
         or_pubcnt,   
         or_unpubcnt,   
         or_fgmosea  )
         
values ('C2', @contno, @s_seq, @inm, @name, @jbti, @addr, @zip, @tel, @fax, @movetel,  @e_mail, '',   @buy_mnt, @free_mnt,   @fgmosea )


FETCH  NEXT FROM  or_cursor into
         @syscd,   
         @contno,   
         @name,   
         @addr,   
         @zip, 
         @mtpcd,
         @datasrce,  
         @buy_mnt,   
         @free_mnt,     
         @fgmosea,   
@ori_name,   
         @ori_jbti,   
         @ori_tel,   
         @ori_movetel,   
         @ori_fax,   
         @ori_e_mail,   
         @ori_irzip,   
         @ori_fgmosea,
         @mfrnm  
END
/*SET IDENTITY_INSERT c1_cust off */
commit transaction  tran_1 
CLOSE  or_cursor                                                                                                                                     
DEALLOCATE  or_cursor                      
set nocount off                     
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_003]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_003]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2trans_004    Script Date: 2002/7/6 上午 11:23:40 ******/

/****** Object:  Stored Procedure dbo.sp_c2trans_004    Script Date: 2002/5/2 AM 08:48:28 ******/

CREATE proc dbo.sp_c2trans_004
as
begin 

set nocount on
/*SET IDENTITY_INSERT c1_cust ON */ 
/*FOR t_pb1-- Declare some variables to hold results.*/
DECLARE @contno char(6),   
         @yymm char(6),   
         @clr char(4),   
         @page char(10),   
         @pgs char(10),   
         @adamt real,   
         @chgamt real,   
         @origjno char(10),   
         @origjbkno char(20),   
         @chgjno char(4),   
         @remark char(50),   
         @pgs_mnt real,   
         @okflag char(1),   
         @moddate char(8),   
         @bkcd char(2),
         @remark2 char(50)
declare @seq int, @s_seq char(2)
declare @pno char(4), @ltpcd char(2), @pgscd char(2), @cont_temp char(6), @yymm_temp char(6), @seq_cnt int

/*產生c2_pub落版檔檔 */

 
DECLARE  pub_cursor  CURSOR FOR            
        SELECT b.cont_contno,   
         a.yymm,   
         a.clr,   
         a.page,   
         a.pgs,   
         a.adamt,   
         a.chgamt,   
         a.origjno,   
         a.origjbkno,   
         a.chgjno,   
         a.remark,   
         a.pgs_mnt,   
         a.okflag,   
         a.moddate,   
         c.bkp_pno,
         a.remark2,  
         a.bkcd
    FROM  v_t2_pub  a,   
         c2_cont    b,  
         bookp      c
   WHERE ( a.cont = b.cont_oldcontno )   and 
                    (a.bkcd = c.bkp_bkcd) and 
                   (a.yymm = c.bkp_date)

 
    

open  pub_cursor
select @seq = 0 
/* get the first row from the cursor */
FETCH  NEXT FROM  pub_cursor into
         @contno,   
         @yymm,   
         @clr,   
         @page,   
         @pgs,   
         @adamt,   
         @chgamt,   
         @origjno,   
         @origjbkno,   
         @chgjno,   
         @remark,   
         @pgs_mnt,   
         @okflag,   
         @moddate,   
         @pno,
         @remark2,  
          @bkcd  
select @cont_temp = @contno 
select @yymm_temp = @yymm  
WHILE (@@FETCH_STATUS = 0)
BEGIN
/*多個落版份數之處理(同一舊落版產生數個新落版)*/
/*select @contno, @yymm, @clr, @pgs_mnt */
if  NOT (@contno = @cont_temp and @yymm = @yymm_temp)
begin 
    select @seq = 0 
    select @cont_temp = @contno 
select @yymm_temp = @yymm
end
if @pgs = '內頁半頁'
  begin 
      select @ltpcd = '06'
      select @pgscd = '02'
  end
else if @pgs = '內頁全頁'
  begin 
      select @ltpcd = '06'
      select @pgscd = '01'
  end
  else if @pgs = '封底'
  begin 
      select @ltpcd = '03'
      select @pgscd = '01'
  end
  else if @pgs = '封底裡頁'
  begin 
      select @ltpcd = '04'
      select @pgscd = '01'
  end
else if @pgs = '封面'
  begin 
      select @ltpcd = '01'
      select @pgscd = '01'
  end
else if @pgs = '封面裡頁'
  begin 
      select @ltpcd = '02'
      select @pgscd = '01'
  end

else if @pgs = '首頁'
  begin 
      select @ltpcd = '05'
      select @pgscd = '01'
  end


if @clr = '彩色'
  begin 
      select @clr = '01'
  end
else if @clr = '套色'
  begin 
      select @clr = '02'
  end 
else if @clr = '黑白'
  begin 
      select @clr = '03'
  end 



select @seq_cnt = 0
WHILE(@seq_cnt < @pgs_mnt)
BEGIN
select @seq_cnt = @seq_cnt  +  1
select @seq = @seq + 1
select @s_seq =  convert(char(2), @seq) 
SELECT  @s_seq  = 
      CASE 
         WHEN @seq > 0 and @seq < 10 THEN '0' + @s_seq
         WHEN  @seq > 9 and @seq < 100 THEN  @s_seq             
      END  

begin  distributed transaction  tran_1
Insert  into  c2_pub (  
         pub_syscd,   
         pub_contno,   
         pub_yyyymm,   
         pub_pubseq,   
         pub_pgno,   
         pub_ltpcd,   
         pub_clrcd,   
         pub_pgscd,   
         pub_adamt,   
         pub_chgamt,   
         pub_drafttp,   
         pub_origbkcd,   
         pub_origjno,   
         pub_origjbkno,   
         pub_chgjbkcd,   
         pub_chgjno,   
         pub_chgjbkno,   
         pub_fgrechg,   
         pub_fggot,   
         pub_njtpcd,   
         pub_projno,   
         pub_costctr,   
         pub_fginved,   
         pub_fginvself,   
         pub_pno,   
         pub_remark,   
         pub_fgfixpg,   
         pub_moddate,   
         pub_modempno,   
         pub_bkcd   )
         
values ('C2', @contno, @yymm, @s_seq, '', @ltpcd, @clr, @pgscd, @adamt, '', '', '', '', '', '', '', '', '', @okflag, '', 'ZZZZZZZZZZ', 'ZZZZZZZ', '', '' , @pno, rtrim(@remark) + rtrim(@remark2), '', @moddate, '', @bkcd )

commit transaction  tran_1 
end 

FETCH  NEXT FROM  pub_cursor into
         @contno,   
         @yymm,   
         @clr,   
         @page,   
         @pgs,   
         @adamt,   
         @chgamt,   
         @origjno,   
         @origjbkno,   
         @chgjno,   
         @remark,   
         @pgs_mnt,   
         @okflag,   
         @moddate,   
         @pno,
         @remark2, 
         @bkcd   
END
/*SET IDENTITY_INSERT c1_cust off */

CLOSE  pub_cursor                                                                                                                                     
DEALLOCATE  pub_cursor                      
set nocount off
 
 
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_004]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c2trans_004]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  User Defined Function dbo.fn_c1_od    Script Date: 2002/7/6 上午 11:23:40 ******/

/****** Object:  User Defined Function dbo.fn_c1_od    Script Date: 2002/5/2 AM 08:48:28 ******/
CREATE FUNCTION dbo.fn_c1_od
(
	@syscd char(2),
	@custno char(6),
	@otp1cd char(2),
	@otp1seq char(3)
)
RETURNS varchar(4000)
AS
	BEGIN
declare @oditem char(2),@sdate char(8),@edate char(8),@oritem char(2)
declare @btpcd char(2),@projno  char(10),@costctr char(7),@amt varchar(10) ,@mnt varchar(4)

declare @xmldata varchar(4000)

select @oditem=od_oditem,@sdate=rtrim(od_sdate),@edate=rtrim(od_edate),@btpcd=od_btpcd,
 @projno=rtrim(od_projno),@costctr=rtrim(od_costctr),@amt=convert(varchar(10) ,od_amt)
 from c1_od
 where od_syscd=@syscd and od_custno=@custno and od_otp1cd=@otp1cd and od_otp1seq=@otp1seq

select @mnt=convert(varchar(4),sum(ra_mnt))
 from c1_ramt
 where ra_syscd=@syscd and ra_custno=@custno and ra_otp1cd=@otp1cd and ra_otp1seq=@otp1seq

 set @xmldata = '<訂單明細>'+
   '<明細表>'+ 
  '<項次>'+@oditem+'</項次>'+ 
  '<書籍類別>'+@btpcd+'</書籍類別>'+ 
  '<新舊訂戶>舊訂戶</新舊訂戶>'  

  if @projno = ''	
  	set @xmldata=@xmldata+'<計劃代號 />' 
  else
  	set @xmldata=@xmldata+'<計劃代號>'+@projno+'</計劃代號>' 

  if @costctr = ''
  	set @xmldata=@xmldata+'<成本中心 />' 
  else
  	set @xmldata=@xmldata+'<成本中心>'+@costctr+'</成本中心>' 

  if @sdate = ''
  	set @xmldata=@xmldata+'<訂閱起時 />' 
  else
  	set @xmldata=@xmldata+'<訂閱起時>'+SUBSTRING(@sdate,1,4)+'/'+SUBSTRING(@sdate,5,2)+'/'+SUBSTRING(@sdate,7,2)+'</訂閱起時>' 
   
  if @edate = ''
  	set @xmldata=@xmldata+'<訂閱訖時 />'  
  else
  	set @xmldata=@xmldata+'<訂閱訖時>'+SUBSTRING(@edate,1,4)+'/'+SUBSTRING(@edate,5,2)+'/'+SUBSTRING(@edate,7,2)+'</訂閱訖時>'  

  set @xmldata=@xmldata+'<金額>'+@amt+'</金額>'  

  set @xmldata=@xmldata+'<總數量>'+@mnt+'</總數量>'+ +'<備註 />' 

  set @xmldata=@xmldata+'<投遞資料>'  

	DECLARE Orderdetail_Cursor CURSOR FOR
	 select or_oritem
	 from c1_or
 	where or_syscd=@syscd and or_custno=@custno and or_otp1cd=@otp1cd and or_otp1seq=@otp1seq
	
	OPEN Orderdetail_Cursor
	
    FETCH NEXT FROM Orderdetail_Cursor
    into @oritem

	WHILE @@FETCH_STATUS = 0
	BEGIN
  		set @xmldata=@xmldata+dbo.fn_c1_or(@syscd ,@custno,@otp1cd,@otp1seq,@oritem,'1')
	    FETCH NEXT FROM Orderdetail_Cursor
	    into @oritem
	END
	
	CLOSE Orderdetail_Cursor
	DEALLOCATE Orderdetail_Cursor
  
   set @xmldata=@xmldata+'</投遞資料>'+
  '</明細表>'+ 
  '</訂單明細>' 

 	RETURN @xmldata
	END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c1_od]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  User Defined Function dbo.fn_c1_or    Script Date: 2002/7/6 上午 11:23:40 ******/

/****** Object:  User Defined Function dbo.fn_c1_or    Script Date: 2002/5/2 AM 08:48:28 ******/
CREATE FUNCTION dbo.fn_c1_or
(
	@syscd char(2),
	@custno char(6),
	@otp1cd char(2),
	@otp1seq char(3),
	@oritem  char(2),
	@stype char(1)
)
RETURNS varchar(4000)
AS
	BEGIN
declare @oditem char(2),@nm varchar(30),@inm varchar(30),@jbti varchar(12)
declare @addr varchar(1000),@zip char(5),@tel varchar(30),@fax varchar(30)
declare @cell varchar(30),@email varchar(80),@fgmosea char(1)
declare @mnt varchar(4), @mtpcd char(2)
declare @xmldata varchar(4000)

select @nm=rtrim(or_nm),@inm=rtrim(or_inm),@jbti=rtrim(or_jbti),@addr=rtrim(or_addr),@zip=rtrim(or_zip),
 @tel=rtrim(or_tel),@fax=rtrim(or_fax),@cell=rtrim(or_cell),@email=rtrim(or_email),@fgmosea=or_fgmosea
 from c1_or
 where or_syscd=@syscd and or_custno=@custno and or_otp1cd=@otp1cd and or_otp1seq=@otp1seq and or_oritem=@oritem

if @stype = '1'
select @mnt=convert(varchar(4),ra_mnt),@mtpcd=ra_mtpcd
 from c1_ramt
 where ra_syscd=@syscd and ra_custno=@custno and ra_otp1cd=@otp1cd and ra_otp1seq=@otp1seq and ra_oritem=@oritem


if @stype = '0'
 set @xmldata = '<收件人資料>'+'<收件人明細>'
if @stype = '1'
 set @xmldata = '<收件人明細>'
set @xmldata=@xmldata+ '<序號>'+@oritem+'</序號>'+ 
  '<姓名>'+@nm+'</姓名>'  
 /*set @xmldata = '<收件人資料>'+
   '<收件人明細>'+ 
  '<序號>'+@oritem+'</序號>'+ 
  '<姓名>'+@nm+'</姓名>'  */

  if @inm = ''	
  	set @xmldata=@xmldata+'<公司名稱 />'
  else
  	set @xmldata=@xmldata+'<公司名稱>'+@inm+'</公司名稱>' 
  if @jbti = ''	
  	set @xmldata=@xmldata+'<職稱 />'
  else
  	set @xmldata=@xmldata+'<職稱>'+@jbti+'</職稱>' 

  if @addr = ''
  	set @xmldata=@xmldata+'<地址 />'
  else
  	set @xmldata=@xmldata+'<地址>'+@addr+'</地址>' 

  if @zip = ''
  	set @xmldata=@xmldata+'<郵遞區號 />'
  else
  	set @xmldata=@xmldata+'<郵遞區號>'+@zip+'</郵遞區號>' 
   
  if @tel = ''
  	set @xmldata=@xmldata+'<電話 />'  
  else
  	set @xmldata=@xmldata+'<電話>'+@tel+'</電話>'  

  if @fax = ''
  	set @xmldata=@xmldata+'<傳真 />'  
  else
  	set @xmldata=@xmldata+'<傳真>'+@fax+'</傳真>'  

  if @cell = ''
  	set @xmldata=@xmldata+'<手機 />'  
  else
  	set @xmldata=@xmldata+'<手機>'+@cell+'</手機>'  

  if @email = ''
  	set @xmldata=@xmldata+'<Email />'  
  else
  	set @xmldata=@xmldata+'<Email>'+@email+'</Email>'  
  
  set @xmldata=@xmldata+'<海外郵寄>'+@fgmosea+'</海外郵寄>'  
  
  if @stype = '0'
  set @xmldata=@xmldata+'<郵寄數量>'+'0'+'</郵寄數量>'+ +'<郵寄類別>'+'11'+'</郵寄類別>' 

  if @stype = '1'
  set @xmldata=@xmldata+'<郵寄數量>'+@mnt+'</郵寄數量>'+ +'<郵寄類別>'+@mtpcd+'</郵寄類別>' 
  
  if @stype = '0'
  set @xmldata=@xmldata+'</收件人明細>'+ 
  '</收件人資料>' 
  if @stype = '1'
  set @xmldata=@xmldata+'</收件人明細>' 
 

 	RETURN @xmldata
	END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c1_or]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  User Defined Function dbo.fn_c1_order    Script Date: 2002/7/6 上午 11:23:40 ******/

/****** Object:  User Defined Function dbo.fn_c1_order    Script Date: 2002/5/2 AM 08:48:28 ******/
CREATE FUNCTION dbo.fn_c1_order
(
	@syscd char(2),
	@custno char(6),
	@otp1cd char(2),
	@otp1seq char(3)
)
RETURNS varchar(8000)
AS
	BEGIN
declare @otp2cd char(2),@mfrno char(10) ,@inm varchar(30),@ijbti varchar(12)
declare @iaddr varchar(1000),@izip char(5),@itel varchar(30),@ifax varchar(30)
declare @icell varchar(30),@iemail varchar(80),@pytpcd char(2),@fgpreinv char(1)
declare @date char(8),@empno char(6),@orescd char(2),@invcd char(1),@taxtp char(1)
declare @xmldata varchar(4000)

select @otp2cd=o_otp2cd,@mfrno=rtrim(o_mfrno),@inm=rtrim(o_inm),@ijbti=rtrim(o_ijbti),
 @iaddr=rtrim(o_iaddr),@izip=rtrim(o_izip),@itel=rtrim(o_itel),@ifax=rtrim(o_ifax),
 @icell=rtrim(o_icell),@iemail=rtrim(o_iemail),@pytpcd=o_pytpcd,@fgpreinv=o_fgpreinv,
 @date=o_date,@empno=o_empno,@orescd=o_orescd,@invcd=o_invcd,@taxtp=o_taxtp
 from c1_order
 where o_syscd=@syscd and o_custno=@custno and o_otp1cd=@otp1cd and o_otp1seq=@otp1seq

 set @xmldata = '<訂單>'+ 
  '<系統代碼>'+@syscd+'</系統代碼>'+ 
  '<訂戶編號>'+@custno+'</訂戶編號>'+ 
  '<訂單流水號>'+@syscd+@custno+@otp1cd+@otp1seq+'</訂單流水號>'+ 
  '<訂購類別一>'+@otp1cd+'</訂購類別一>'+ 
  '<訂購類別二>'+@otp2cd+'</訂購類別二>'+ 
  '<統一編號>'+@mfrno+'</統一編號>'+ 
  '<發票收件人姓名>'+@inm+'</發票收件人姓名>' 

  if @ijbti = ''	
  	set @xmldata=@xmldata+'<發票收件人職稱 />'
  else
  	set @xmldata=@xmldata+'<發票收件人職稱>'+@ijbti+'</發票收件人職稱>'

  if @iaddr = ''
  	set @xmldata=@xmldata+'<發票收件人地址 />' 
  else
  	set @xmldata=@xmldata+'<發票收件人地址>'+@iaddr+'</發票收件人地址>'

  if @izip = ''
  	set @xmldata=@xmldata+'<發票收件人郵遞區號 />' 
  else
  	set @xmldata=@xmldata+'<發票收件人郵遞區號>'+@izip+'</發票收件人郵遞區號>' 
   
  if @itel = ''
  	set @xmldata=@xmldata+'<發票收件人電話 />'  
  else
  	set @xmldata=@xmldata+'<發票收件人電話>'+@itel+'</發票收件人電話>'  

  if @ifax = ''
  	set @xmldata=@xmldata+'<發票收件人傳真 />'  
  else
  	set @xmldata=@xmldata+'<發票收件人傳真>'+@ifax+'</發票收件人傳真>' 

  if @icell = ''
  	set @xmldata=@xmldata+'<發票收件人手機 />'  
  else
  	set @xmldata=@xmldata+'<發票收件人手機>'+@icell+'</發票收件人手機>' 

  if @iemail = ''
  	set @xmldata=@xmldata+'<發票收件人Email />'  
  else
  	set @xmldata=@xmldata+'<發票收件人Email>'+@iemail+'</發票收件人Email>'
  
  set @xmldata=@xmldata+'<預開發票>0</預開發票>'+ 
  '<承辦人員>'+@empno+'</承辦人員>'+ 
  '<訂購日期>'+SUBSTRING(@date,1,4)+'/'+SUBSTRING(@date,5,2)+'/'+SUBSTRING(@date,7,2)+'</訂購日期>'+ 
  '<訂單來源>'+@orescd+'</訂單來源>'+ 
  '<發票類別>'+@invcd+'</發票類別>'+ 
  '<發票課稅別>'+@taxtp+'</發票課稅別>'+ 
  '<付款方式>'+@pytpcd+'</付款方式>'+ 
  '</訂單>'

 	RETURN @xmldata
	END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c1_order]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_cust    Script Date: 2002/7/6 上午 11:23:40 ******/
CREATE FUNCTION dbo.fn_c2_cust
(
	@custno varchar(6)
)
RETURNS varchar(200)
AS
	BEGIN
declare @nm varchar(30)
declare @xmldata varchar(200)

select @nm=rtrim(cust_nm)
 from cust
 where cust_custno=@custno


 set @xmldata = '<客戶資料>'

  if @nm = ''	
  	set @xmldata=@xmldata + '<客戶姓名 />'
  else
  	set @xmldata=@xmldata + '<客戶姓名>' + @nm + '</客戶姓名>' 

  if @custno = ''	
  	set @xmldata=@xmldata + '<客戶編號 />'
  else
  	set @xmldata=@xmldata + '<客戶編號>' + @custno + '</客戶編號>' 


  set @xmldata=@xmldata + '</客戶資料>'
   

 	RETURN @xmldata
	END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c2_cust]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_im    Script Date: 2002/7/6 上午 11:23:40 ******/
CREATE FUNCTION dbo.fn_c2_im
(
	@syscd varchar(2),
	@contno varchar(6),
	@imseq varchar(2)
)
RETURNS varchar(8000)
AS
	BEGIN
declare @mfrno varchar(10),@nm varchar(30),@jbti varchar(12)
declare @zip varchar(5),@addr varchar(120),@tel varchar(30),@fax varchar(30)
declare @cell varchar(30),@email varchar(80),@invcd varchar(1),@taxtp varchar(1)
declare @fgitri varchar(2)
declare @xmldata varchar(8000)

select @mfrno=rtrim(im_mfrno),@nm=rtrim(im_nm),@jbti=rtrim(im_jbti),
 @zip=rtrim(im_zip),@addr=rtrim(im_addr),@tel=rtrim(im_tel),@fax=rtrim(im_fax),
 @cell=rtrim(im_cell),@email=rtrim(im_email),@invcd=im_invcd,@taxtp=im_taxtp,
 @fgitri=im_fgitri
 from invmfr
 where im_syscd=@syscd and im_contno=@contno and im_imseq=@imseq


 set @xmldata = '<發票廠商資料>' + '<發票廠商收件人明細>' 

 set @xmldata=@xmldata +  '<系統代碼>' + @syscd + '</系統代碼>' +  
  '<合約書編號>' + @contno + '</合約書編號>' + 
  '<發票廠商序號>' + @imseq + '</發票廠商序號>'

  if @mfrno = ''	
  	set @xmldata=@xmldata + '<發票收件人廠商統編 />'
  else
  	set @xmldata=@xmldata + '<發票收件人廠商統編>' + @mfrno + '</發票收件人廠商統編>' 

  if @nm = ''	
  	set @xmldata=@xmldata + '<發票收件人姓名 />'
  else
  	set @xmldata=@xmldata + '<發票收件人姓名>' + @nm + '</發票收件人姓名>' 

  if @jbti = ''	
  	set @xmldata=@xmldata + '<發票收件人職稱 />'
  else
  	set @xmldata=@xmldata + '<發票收件人職稱>' + @jbti + '</發票收件人職稱>' 

  if @zip = ''
  	set @xmldata=@xmldata + '<發票收件人郵遞區號 />'
  else
  	set @xmldata=@xmldata + '<發票收件人郵遞區號>' + @zip + '</發票收件人郵遞區號>' 

  if @addr = ''
  	set @xmldata=@xmldata + '<發票收件人地址 />'
  else
  	set @xmldata=@xmldata + '<發票收件人地址>' + @addr + '</發票收件人地址>' 
   
  if @tel = ''
  	set @xmldata=@xmldata + '<發票收件人電話 />'  
  else
  	set @xmldata=@xmldata + '<發票收件人電話>' + @tel + '</發票收件人電話>'  

  if @fax = ''
  	set @xmldata=@xmldata + '<發票收件人傳真 />'  
  else
  	set @xmldata=@xmldata + '<發票收件人傳真>' + @fax + '</發票收件人傳真>'  

  if @cell = ''
  	set @xmldata=@xmldata + '<發票收件人手機 />'  
  else
  	set @xmldata=@xmldata + '<發票收件人手機>' + @cell + '</發票收件人手機>'  

  if @email = ''
  	set @xmldata=@xmldata + '<發票收件人Email />'  
  else
  	set @xmldata=@xmldata + '<發票收件人Email>' + @email + '</發票收件人Email>'  
  
  if @invcd = ''
  	set @xmldata=@xmldata + '<發票類別代碼 />'  
  else
  	set @xmldata=@xmldata + '<發票類別代碼>' + @invcd + '</發票類別代碼>'  

  if @taxtp = ''
  	set @xmldata=@xmldata + '<發票課稅別代碼 />'  
  else
  	set @xmldata=@xmldata + '<發票課稅別代碼>' + @taxtp + '</發票課稅別代碼>'  

  if @fgitri = ''
  	set @xmldata=@xmldata + '<院所內註記 />'  
  else
  	set @xmldata=@xmldata + '<院所內註記>' + @fgitri + '</院所內註記>'  


  set @xmldata=@xmldata + '</發票廠商收件人明細>' + '</發票廠商資料>'
 

 	RETURN @xmldata
	END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c2_im]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_mfr    Script Date: 2002/7/6 上午 11:23:41 ******/
CREATE FUNCTION dbo.fn_c2_mfr
(
	@mfrno varchar(10)
)
RETURNS varchar(1000)
AS
	BEGIN
declare @inm varchar(30),@respnm varchar(30),@respjbti varchar(12)
declare @tel varchar(30),@fax varchar(30)
declare @zip varchar(5),@addr varchar(120)
declare @xmldata varchar(1000)

select @inm=rtrim(mfr_inm),@respnm=rtrim(mfr_respnm),@respjbti=rtrim(mfr_respjbti),
 @tel=rtrim(mfr_tel),@fax=rtrim(mfr_fax),
 @zip=rtrim(mfr_izip),@addr=rtrim(mfr_iaddr)
 from mfr
 where mfr_mfrno=@mfrno


 set @xmldata = '<廠商資料>'

  if @inm = ''	
  	set @xmldata=@xmldata + '<公司發票抬頭 />'
  else
  	set @xmldata=@xmldata + '<公司發票抬頭>' + @inm + '</公司發票抬頭>' 

  if @mfrno = ''	
  	set @xmldata=@xmldata + '<廠商統編 />'
  else
  	set @xmldata=@xmldata + '<廠商統編>' + @mfrno + '</廠商統編>' 

  if @respnm = ''	
  	set @xmldata=@xmldata + '<廠商負責人姓名 />'
  else
  	set @xmldata=@xmldata + '<廠商負責人姓名>' + @respnm + '</廠商負責人姓名>' 

  if @respjbti = ''	
  	set @xmldata=@xmldata + '<廠商負責人職稱 />'
  else
  	set @xmldata=@xmldata + '<廠商負責人職稱>' + @respjbti + '</廠商負責人職稱>' 
  
  if @tel = ''
  	set @xmldata=@xmldata + '<廠商電話 />'  
  else
  	set @xmldata=@xmldata + '<廠商電話>' + @tel + '</廠商電話>'  

  if @fax = ''
  	set @xmldata=@xmldata + '<廠商傳真 />'  
  else
  	set @xmldata=@xmldata + '<廠商傳真>' + @fax + '</廠商傳真>'  

  if @zip = ''
  	set @xmldata=@xmldata + '<廠商郵遞區號 />'
  else
  	set @xmldata=@xmldata + '<廠商郵遞區號>' + @zip + '</廠商郵遞區號>' 

  if @addr = ''
  	set @xmldata=@xmldata + '<廠商地址 />'
  else
  	set @xmldata=@xmldata + '<廠商地址>' + @addr + '</廠商地址>' 


  set @xmldata=@xmldata + '</廠商資料>'
   

 	RETURN @xmldata
	END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c2_mfr]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_or    Script Date: 2002/7/6 上午 11:23:41 ******/
CREATE FUNCTION dbo.fn_c2_or
(
	@syscd varchar(2),
	@contno varchar(6),
	@oritem varchar(2)
)
RETURNS varchar(8000)
AS
	BEGIN
declare @nm varchar(30),@inm varchar(30),@jbti varchar(12)
declare @tel varchar(30),@fax varchar(30),@cell varchar(30),@email varchar(80)
declare @zip varchar(5),@addr varchar(120)
declare @pubcnt varchar(4),@unpubcnt varchar(4),@mtpcd varchar(2),@fgmosea varchar(1)
declare @xmldata varchar(8000)

select @inm=rtrim(or_inm),@nm=rtrim(or_nm),@jbti=rtrim(or_jbti),@addr=rtrim(or_addr),@zip=rtrim(or_zip),
 @tel=rtrim(or_tel),@fax=rtrim(or_fax),@cell=rtrim(or_cell),@email=rtrim(or_email),@fgmosea=or_fgmosea,
 @mtpcd=or_mtpcd, @pubcnt=convert(varchar(4),or_pubcnt), @unpubcnt=convert(varchar(4),or_unpubcnt)
 from c2_or
 where or_syscd=@syscd and or_contno=@contno and or_oritem=@oritem

 set @xmldata = '<雜誌收件人資料>' + '<雜誌收件人明細>' 

 set @xmldata=@xmldata +  '<系統代碼>' + @syscd + '</系統代碼>' +  
  '<合約書編號>' + @contno + '</合約書編號>' + 
  '<雜誌收件人序號>' + @oritem + '</雜誌收件人序號>'

  if @nm = ''	
  	set @xmldata=@xmldata + '<雜誌收件人姓名 />'
  else
  	set @xmldata=@xmldata + '<雜誌收件人姓名>' + @nm + '</雜誌收件人姓名>' 

  if @inm = ''	
  	set @xmldata=@xmldata + '<雜誌收件人公司名稱 />'
  else
  	set @xmldata=@xmldata + '<雜誌收件人公司名稱>' + @inm + '</雜誌收件人公司名稱>' 

  if @jbti = ''	
  	set @xmldata=@xmldata + '<雜誌收件人職稱 />'
  else
  	set @xmldata=@xmldata + '<雜誌收件人職稱>' + @jbti + '</雜誌收件人職稱>' 
   
  if @tel = ''
  	set @xmldata=@xmldata + '<雜誌收件人電話 />'  
  else
  	set @xmldata=@xmldata + '<雜誌收件人電話>' + @tel + '</雜誌收件人電話>'  

  if @fax = ''
  	set @xmldata=@xmldata + '<雜誌收件人傳真 />'  
  else
  	set @xmldata=@xmldata + '<雜誌收件人傳真>' + @fax + '</雜誌收件人傳真>'  

  if @cell = ''
  	set @xmldata=@xmldata + '<雜誌收件人手機 />'  
  else
  	set @xmldata=@xmldata + '<雜誌收件人手機>' + @cell + '</雜誌收件人手機>'  

  if @email = ''
  	set @xmldata=@xmldata + '<雜誌收件人Email />'  
  else
  	set @xmldata=@xmldata + '<雜誌收件人Email>' + @email + '</雜誌收件人Email>'  

  if @zip = ''
  	set @xmldata=@xmldata + '<雜誌收件人郵遞區號 />'
  else
  	set @xmldata=@xmldata + '<雜誌收件人郵遞區號>' + @zip + '</雜誌收件人郵遞區號>' 

  if @addr = ''
  	set @xmldata=@xmldata + '<雜誌收件人地址 />'
  else
  	set @xmldata=@xmldata + '<雜誌收件人地址>' + @addr + '</雜誌收件人地址>' 

  if @pubcnt = ''
  	set @xmldata=@xmldata + '<有登本數 />'  
  else
  	set @xmldata=@xmldata + '<有登本數>' + @pubcnt + '</有登本數>'  

  if @unpubcnt = ''
  	set @xmldata=@xmldata + '<未登本數 />'  
  else
  	set @xmldata=@xmldata + '<未登本數>' + @unpubcnt + '</未登本數>'  

  if @mtpcd = ''
  	set @xmldata=@xmldata + '<郵寄類別代碼 />'  
  else
  	set @xmldata=@xmldata + '<郵寄類別代碼>' + @mtpcd + '</郵寄類別代碼>'  

  if @fgmosea = ''
  	set @xmldata=@xmldata + '<海外郵寄註記 />'  
  else
  	set @xmldata=@xmldata + '<海外郵寄註記>' + @fgmosea + '</海外郵寄註記>'  


  set @xmldata=@xmldata + '</雜誌收件人明細>' + '</雜誌收件人資料>'
 

 	RETURN @xmldata
	END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c2_or]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_pub    Script Date: 2002/7/6 上午 11:23:41 ******/
CREATE FUNCTION dbo.fn_c2_pub
(
	@syscd char(2),
	@contno char(6),
	@yyyymm char(6),
	@pubseq char(2)
)
RETURNS varchar(8000)
AS
	BEGIN
declare @pubItem char(2),@conttp char(2)
declare @custno char(6),@projno char(10),@costctr char(7)
declare @bkcd char(2),@bkcdprojnocostctr char(19)
declare @pno varchar(4)
declare @pgno varchar(4),@fgfixpg char(1)
declare @ltpcd char(2),@clrcd char(2),@pgscd char(2)
declare @fggot char(1),@modempno char(8),@moddate char(8)
declare @fgupdated char(1)
declare @adamt varchar(10),@chgamt varchar(10),@fginved char(1)
declare @fginvself char(1),@remark varchar(50)
declare @drafttp char(1),@origbkcd char(2)
declare @origjno varchar(4),@origjbkno varchar(4)
declare @chgbkcd char(2),@chgjno varchar(4)
declare @chgjbkno varchar(4),@fgrechg char(1)
declare @njtpcd char(2),@imseq char(2)
declare @xmldata varchar(8000)

select @pubItem='01',@conttp='01',
 @custno='999999',@projno=rtrim(pub_projno),@costctr=rtrim(pub_costctr),
 @bkcd='01',@bkcdprojnocostctr=@bkcd+@projno+@costctr,
 @pubseq=rtrim(pub_pubseq),@yyyymm=rtrim(pub_yyyymm),
 @pno=convert(char(4),rtrim(pub_pno)),
 @pgno=convert(char(4),pub_pgno),@fgfixpg=rtrim(pub_fgfixpg),
 @ltpcd=rtrim(pub_ltpcd),@clrcd=rtrim(pub_clrcd),@pgscd=rtrim(pub_pgscd),
 @fggot=rtrim(pub_fggot),@modempno=rtrim(pub_modempno),@moddate=rtrim(pub_moddate),
 @fgupdated=rtrim(pub_fgupdated),
 @adamt=convert(varchar(10),pub_adamt),@chgamt=convert(varchar(10),pub_chgamt),@fginved=rtrim(pub_fginved),
 @fginvself=rtrim(pub_fginvself),@remark=rtrim(pub_remark),
 @drafttp=rtrim(pub_drafttp),@origbkcd=pub_origbkcd,
 @origjno=convert(varchar(10),rtrim(pub_origjno)),@origjbkno=convert(varchar(10),pub_origjbkno),
 @chgbkcd=pub_chgbkcd,@chgjno=convert(varchar(10),rtrim(pub_chgjno)),
 @chgjbkno=convert(varchar(10),pub_chgjbkno),@fgrechg=rtrim(pub_fgrechg),
 @njtpcd=pub_njtpcd,@imseq='01'
 from c2_pub
 where pub_syscd=@syscd and pub_contno=@contno and pub_yyyymm=@yyyymm and pub_pubseq=@pubseq

 set @xmldata = '<合約書落版刊登資料>'
 set @xmldata=@xmldata + '<落版明細表>'

  if @pubItem = ''	
  	set @xmldata=@xmldata + '<序號 />' 
  else
  	set @xmldata=@xmldata + '<序號>' + @pubItem + '</序號>' 

  set @xmldata=@xmldata + '<系統代碼>C2</系統代碼>' 

  if @contno = ''	
  	set @xmldata=@xmldata + '<合約書編號 />' 
  else
  	set @xmldata=@xmldata + '<合約書編號>' + @contno + '</合約書編號>' 

  if @conttp = ''	
  	set @xmldata=@xmldata + '<合約類別代碼 />' 
  else
  	set @xmldata=@xmldata + '<合約類別代碼>' + @conttp + '</合約類別代碼>' 

  if @custno = ''	
  	set @xmldata=@xmldata + '<客戶編號 />' 
  else
  	set @xmldata=@xmldata + '<客戶編號>' + @custno + '</客戶編號>' 

  if @projno = ''	
  	set @xmldata=@xmldata + '<計劃代號 />' 
  else
  	set @xmldata=@xmldata + '<計劃代號>' + @projno + '</計劃代號>' 

  if @costctr = ''
  	set @xmldata=@xmldata + '<成本中心 />' 
  else
  	set @xmldata=@xmldata + '<成本中心>' + @costctr + '</成本中心>' 

  if @bkcd = ''
  	set @xmldata=@xmldata + '<書籍類別代碼 />'  
  else
  	set @xmldata=@xmldata + '<書籍類別代碼>' + @bkcd + '</書籍類別代碼>'  

  if @bkcdprojnocostctr = ''
  	set @xmldata=@xmldata + '<書籍全碼 />'  
  else
  	set @xmldata=@xmldata + '<書籍全碼>' + @bkcdprojnocostctr + '</書籍全碼>'  

  if @yyyymm  = ''
  	set @xmldata=@xmldata + '<刊登年月 />'  
  else
  	set @xmldata=@xmldata + '<刊登年月>' + @yyyymm  + '</刊登年月>'  

  if @pubseq = ''
  	set @xmldata=@xmldata + '<落版序號 />'  
  else
  	set @xmldata=@xmldata + '<落版序號>' + @pubseq + '</落版序號>'  

  if @pno = ''
  	set @xmldata=@xmldata + '<書籍期別 />'  
  else
  	set @xmldata=@xmldata + '<書籍期別>' + @pno + '<書籍期別>'  

  if @pgno = ''
  	set @xmldata=@xmldata + '<刊登頁碼 />'  
  else
  	set @xmldata=@xmldata + '<刊登頁碼>' + @pgno + '</刊登頁碼>'  

  if @fgfixpg = ''
  	set @xmldata=@xmldata + '<固定頁次註記 />'  
  else
  	set @xmldata=@xmldata + '<固定頁次註記>' + @fgfixpg + '<固定頁次註記>'  

  if @clrcd = ''
  	set @xmldata=@xmldata + '<廣告色彩代碼 />'  
  else
  	set @xmldata=@xmldata + '<廣告色彩代碼>' + @clrcd + '</廣告色彩代碼>'  

  if @pgscd = ''
  	set @xmldata=@xmldata + '<廣告篇幅代碼 />'  
  else
  	set @xmldata=@xmldata + '<廣告篇幅代碼>' + @pgscd + '</廣告篇幅代碼>'  

  if @ltpcd = ''
  	set @xmldata=@xmldata + '<廣告版面代碼 />'  
  else
  	set @xmldata=@xmldata + '<廣告版面代碼>' + @ltpcd + '</廣告版面代碼>'  

  if @fggot = ''
  	set @xmldata=@xmldata + '<到稿註記 />'  
  else
  	set @xmldata=@xmldata + '<到稿註記>' + @fggot + '<到稿註記>'  

  if @adamt = ''
  	set @xmldata=@xmldata + '<落版後金額 />'  
  else
  	set @xmldata=@xmldata + '<落版後金額>' + @adamt + '</落版後金額>'  

  if @adamt = ''
  	set @xmldata=@xmldata + '<換稿費用 />'  
  else
  	set @xmldata=@xmldata + '<換稿費用>' + @adamt + '</換稿費用>'  

  if @moddate = ''
  	set @xmldata=@xmldata + '<落版最後修改日期 />'  
  else
  	set @xmldata=@xmldata + '<落版最後修改日期>' + @moddate + '<落版最後修改日期>'  

  if @modempno = ''
  	set @xmldata=@xmldata + '<落版修改業務員工號 />'  
  else
  	set @xmldata=@xmldata + '<落版修改業務員工號>' + @modempno + '<落版修改業務員工號>'  

  if @fgupdated = ''
  	set @xmldata=@xmldata + '<樣後修改註記 />'  
  else
  	set @xmldata=@xmldata + '<樣後修改註記>' + @fgupdated + '<樣後修改註記>'  


  set @xmldata =@xmldata + '<發票廠商收件人細節>' + 
  '<發票廠商收件人明細>'

	DECLARE ContIM_Cursor CURSOR FOR
	 select im_syscd, im_contno, im_imseq
	 from invmfr
	 where im_syscd=@syscd and im_contno=@contno and im_imseq=@imseq
	OPEN ContIM_Cursor
	
	FETCH NEXT FROM ContIM_Cursor
	 into @syscd, @contno, @imseq
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @xmldata=@xmldata + dbo.fn_c2_im(@syscd ,@contno,@imseq)
		FETCH NEXT FROM ContIM_Cursor
		 into @syscd, @contno, @imseq
	END
	
	CLOSE ContIM_Cursor
	DEALLOCATE ContIM_Cursor

  set @xmldata=@xmldata + '</發票廠商收件人明細>' +
  '</發票廠商收件人細節>'

  
  set @xmldata=@xmldata + '<落版細節>'

  if @adamt = ''
  	set @xmldata=@xmldata + '<落版廣告金額 />'  
  else
  	set @xmldata=@xmldata + '<落版廣告金額>' + @adamt + '</落版廣告金額>'  

  if @chgamt = ''
  	set @xmldata=@xmldata + '<換稿金額 />'  
  else
  	set @xmldata=@xmldata + '<換稿金額>' + @chgamt + '<換稿金額>'  

  if @fginved = ''
  	set @xmldata=@xmldata + '<已開立發票單註記 />'  
  else
  	set @xmldata=@xmldata + '<已開立發票單註記>' + @fginved + '<已開立發票單註記>'  

  if @fginvself = ''
  	set @xmldata=@xmldata + '<發票開立單人工處理註記 />'  
  else
  	set @xmldata=@xmldata + '<發票開立單人工處理註記>' + @fginvself + '<發票開立單人工處理註記>'

  if @remark = ''
  	set @xmldata=@xmldata + '<備註 />'  
  else
  	set @xmldata=@xmldata + '<備註>' + @remark + '<備註>'  

  if @drafttp = ''
  	set @xmldata=@xmldata + '<稿件類別代碼 />'  
  else
  	set @xmldata=@xmldata + '<稿件類別代碼>' + @drafttp + '</稿件類別代碼>'  

  if @origbkcd = ''
  	set @xmldata=@xmldata + '<舊稿書籍代碼 />'  
  else
  	set @xmldata=@xmldata + '<舊稿書籍代碼>' + @origbkcd + '</舊稿書籍代碼>'  

  if @origjno = ''
  	set @xmldata=@xmldata + '<舊稿期別 />'  
  else
  	set @xmldata=@xmldata + '<舊稿期別>' + @origjno + '</舊稿期別>'  

  if @origjbkno = ''
  	set @xmldata=@xmldata + '<舊稿頁碼 />'  
  else
  	set @xmldata=@xmldata + '<舊稿頁碼>' + @origjbkno + '</舊稿頁碼>'   

  if @chgbkcd = ''
  	set @xmldata=@xmldata + '<改稿書籍代碼 />'  
  else
  	set @xmldata=@xmldata + '<改稿書籍代碼>' + @chgbkcd + '</改稿書籍代碼>'  

  if @chgjno = ''
  	set @xmldata=@xmldata + '<改稿期別 />'  
  else
  	set @xmldata=@xmldata + '<改稿期別>' + @chgjno + '</改稿期別>'  

  if @chgjbkno = ''
  	set @xmldata=@xmldata + '<改稿頁碼 />'  
  else
  	set @xmldata=@xmldata + '<改稿頁碼>' + @chgjbkno + '<改稿頁碼>'  

  if @fgrechg = ''
  	set @xmldata=@xmldata + '<改稿重出片註記 />'  
  else
  	set @xmldata=@xmldata + '<改稿重出片註記>' + @fgrechg + '<改稿重出片註記>'  

  if @njtpcd = ''
  	set @xmldata=@xmldata + '<新稿製法代碼 />'  
  else
  	set @xmldata=@xmldata + '<新稿製法代碼>' + @njtpcd + '<新稿製法代碼>'  

  set @xmldata=@xmldata + '</落版細節>' 


  set @xmldata=@xmldata + '</落版明細表>'
  set @xmldata=@xmldata + '</合約書落版刊登資料>' 


 	RETURN @xmldata
	END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[fn_c2_pub]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_pubEmpty    Script Date: 2002/7/6 上午 11:23:41 ******/
CREATE FUNCTION dbo.fn_c2_pubEmpty
(
	@syscd varchar(2),
	@contno varchar(6)
)
RETURNS varchar(8000)
AS
	BEGIN
declare @custno varchar(6), @mfrno varchar(10)
declare @xmldata varchar(8000)

select @syscd=rtrim(cont_syscd),@contno=rtrim(cont_contno),@custno=rtrim(cont_custno),@mfrno=rtrim(cont_mfrno)
 from c2_cont
 where cont_syscd=@syscd and cont_contno=@contno

 set @xmldata = '<合約書落版刊登資料>'
 set @xmldata=@xmldata + '<落版明細表>'
 
 set @xmldata=@xmldata + '<序號>1</序號>'
 set @xmldata=@xmldata + '<系統代碼>C2</系統代碼>'
 set @xmldata=@xmldata + '<合約書編號>' + @contno + '</合約書編號>'
 set @xmldata=@xmldata + '<合約類別代碼>01</合約類別代碼>'
 set @xmldata=@xmldata + '<客戶編號>' + @custno + '</客戶編號>'
 set @xmldata=@xmldata + '<計劃代號>DF1559C330</計劃代號>'
 set @xmldata=@xmldata + '<成本中心>050C300</成本中心>'
 set @xmldata=@xmldata + '<書籍類別代碼>01</書籍類別代碼>' 
 set @xmldata=@xmldata + '<書籍全碼>01DF1559C330050C300</書籍全碼>' 
 set @xmldata=@xmldata + '<刊登年月 />'
 set @xmldata=@xmldata + '<落版序號>1</落版序號>'
 set @xmldata=@xmldata + '<書籍期別 />'
 set @xmldata=@xmldata + '<刊登頁碼 />'
 set @xmldata=@xmldata + '<固定頁次註記>0</固定頁次註記>'
 set @xmldata=@xmldata + '<廣告色彩代碼>00</廣告色彩代碼>'
 set @xmldata=@xmldata + '<廣告篇幅代碼>00</廣告篇幅代碼>'
 set @xmldata=@xmldata + '<廣告版面代碼>00</廣告版面代碼>'
 set @xmldata=@xmldata + '<到稿註記>0</到稿註記>'
 set @xmldata=@xmldata + '<落版後金額 />'
 set @xmldata=@xmldata + '<換稿費用 />'
 set @xmldata=@xmldata + '<落版最後修改日期 />'
 set @xmldata=@xmldata + '<落版修改業務員工號 />'
 set @xmldata=@xmldata + '<樣後修改註記>0</樣後修改註記>'

 set @xmldata=@xmldata + '<發票廠商收件人細節>'
 set @xmldata=@xmldata + '<發票廠商收件人明細>'
 set @xmldata=@xmldata + '<系統代碼>C2</系統代碼>' 
 set @xmldata=@xmldata + '<合約書編號>' + @contno + '</合約書編號>' 
 set @xmldata=@xmldata + '<發票廠商序號>1</發票廠商序號>'
 set @xmldata=@xmldata + '<發票收件人廠商統編>' + @mfrno + '</發票收件人廠商統編>' 
 set @xmldata=@xmldata + '<發票收件人姓名 />'
 set @xmldata=@xmldata + '<發票收件人職稱 />'
 set @xmldata=@xmldata + '<發票收件人郵遞區號 />'
 set @xmldata=@xmldata + '<發票收件人地址 />'
 set @xmldata=@xmldata + '<發票收件人電話 />'  
 set @xmldata=@xmldata + '<發票收件人傳真 />'  
 set @xmldata=@xmldata + '<發票收件人手機 />'  
 set @xmldata=@xmldata + '<發票收件人Email />'  
 set @xmldata=@xmldata + '<發票類別代碼>3</發票類別代碼>'
 set @xmldata=@xmldata + '<發票課稅別代碼>1</發票課稅別代碼>'
 set @xmldata=@xmldata + '<院所內註記></院所內註記>'
 set @xmldata=@xmldata + '</發票廠商收件人明細>'
 set @xmldata=@xmldata + '</發票廠商收件人細節>'
 
 set @xmldata=@xmldata + '<落版細節>'
 set @xmldata=@xmldata + '<落版廣告金額>0</落版廣告金額>'
 set @xmldata=@xmldata + '<換稿金額>0</換稿金額>'
 set @xmldata=@xmldata + '<已開立發票單註記>0</已開立發票單註記>'
 set @xmldata=@xmldata + '<發票開立單人工處理註記>0</發票開立單人工處理註記>'
 set @xmldata=@xmldata + '<備註 />'
 set @xmldata=@xmldata + '<稿件類別代碼>01</稿件類別代碼>'
 set @xmldata=@xmldata + '<舊稿書籍代碼 />'
 set @xmldata=@xmldata + '<舊稿期別 />'
 set @xmldata=@xmldata + '<舊稿頁碼 />'
 set @xmldata=@xmldata + '<改稿書籍代碼>01</改稿書籍代碼>'
 set @xmldata=@xmldata + '<改稿期別 />'
 set @xmldata=@xmldata + '<改稿頁碼 />'
 set @xmldata=@xmldata + '<改稿重出片註記></改稿重出片註記>'
 set @xmldata=@xmldata + '<新稿製法代碼>01</新稿製法代碼>'
 set @xmldata=@xmldata + '</落版細節>'

 set @xmldata=@xmldata + '</落版明細表>'
 set @xmldata=@xmldata + '</合約書落版刊登資料>' 


 	RETURN @xmldata
	END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_contBasic    Script Date: 2002/7/6 上午 11:23:42 ******/
CREATE FUNCTION dbo.fn_c2_contBasic
(
	@syscd char(2),
	@contno char(6)
)
RETURNS varchar(8000)
AS
	BEGIN
declare @mfrno char(10),@custno char(6),@conttp char(2)
declare @signdate varchar(8),@projno char(10),@costctr char(7)
declare @bkcd char(2),@bkcdprojnocostctr char(19)
declare @sdate char(6),@edate char(6),@empno varchar(7)
declare @fgpayonce char(1),@fgclosed char(1)
declare @moddate char(8),@modempno char(7),@oldcontno char(7)
declare @pubcnt varchar(4),@unpubcnt varchar(4)
declare @totjtm varchar(4),@madejtm varchar(4)
declare @restjtm varchar(4),@tottm varchar(4)
declare @pubtm varchar(4),@resttm varchar(4)
declare @totamt varchar(10),@paidamt varchar(10)
declare @restamt varchar(10),@chgjtm varchar(4)
declare @freetm varchar(4),@disc varchar(8)
declare @clrtm varchar(4),@menotm varchar(4),@getclrtm varchar(4)
declare @aunm varchar(30),@autel varchar(30),@aufax varchar(30)
declare @aucell varchar(30),@auemail varchar(80)
declare @xmldata varchar(8000)

select @mfrno=rtrim(cont_mfrno),@custno=rtrim(cont_custno),@conttp=cont_conttp,
 @signdate=rtrim(cont_signdate),@projno='DF1559C330',@costctr='050C300',
 @bkcd=cont_bkcd,@bkcdprojnocostctr=@bkcd+@projno+@costctr,
 @sdate=rtrim(cont_sdate),@edate=rtrim(cont_edate),@empno=rtrim(cont_empno),
 @fgpayonce=rtrim(cont_fgpayonce),@fgclosed=rtrim(cont_fgclosed),
 @moddate=rtrim(cont_moddate),@modempno=rtrim(cont_modempno),@oldcontno=cont_oldcontno,
 @pubcnt=1, @unpubcnt=0,
 @totjtm=convert(varchar(4),cont_totjtm),@madejtm=convert(varchar(4),cont_madejtm),
 @restjtm=convert(varchar(4),cont_restjtm),@tottm=convert(varchar(4),cont_tottm),
 @pubtm=convert(varchar(4),cont_pubtm),@resttm=convert(varchar(4),cont_resttm),
 @totamt=convert(varchar(10),cont_totamt),@paidamt=convert(varchar(10),cont_paidamt),
 @restamt=convert(varchar(10),cont_restamt),@chgjtm=convert(varchar(4),cont_chgjtm),
 @freetm=convert(varchar(4),cont_freetm),@disc=convert(varchar(4),cont_disc),
 @clrtm=cont_clrtm,@menotm=cont_menotm,@getclrtm=cont_getclrtm,
 @aunm=rtrim(cont_aunm),@autel=rtrim(cont_autel),@aufax=rtrim(cont_aufax),
 @aucell=rtrim(cont_aucell),@auemail=rtrim(cont_auemail)
 from c2_cont
 where cont_syscd=@syscd and cont_contno=@contno


 set @xmldata = '<合約書內容>'

 /* <廠商資料> */
	DECLARE ContMfr_Cursor CURSOR FOR
	 select mfr_mfrno
	 from mfr
 	where mfr_mfrno=@mfrno
	OPEN ContMfr_Cursor
	
    FETCH NEXT FROM ContMfr_Cursor
    into @mfrno

	WHILE @@FETCH_STATUS = 0
	BEGIN
  		set @xmldata=@xmldata + dbo.fn_c2_mfr(@mfrno)
	    FETCH NEXT FROM ContMfr_Cursor
	    into @mfrno
	END
	
	CLOSE ContMfr_Cursor
	DEALLOCATE ContMfr_Cursor


 /* <客戶資料> */
	DECLARE ContCust_Cursor CURSOR FOR
	 select cust_custno
	 from cust
 	where cust_custno=@custno
	OPEN ContCust_Cursor
	
    FETCH NEXT FROM ContCust_Cursor
    into @custno

	WHILE @@FETCH_STATUS = 0
	BEGIN
  		set @xmldata=@xmldata + dbo.fn_c2_cust(@custno)
	    FETCH NEXT FROM ContCust_Cursor
	    into @custno
	END
	
	CLOSE ContCust_Cursor
	DEALLOCATE ContCust_Cursor


 /* <合約書基本資料> */
  set @xmldata=@xmldata + '<合約書基本資料>' + 
  '<系統代碼>' + @syscd + '</系統代碼>' +  
  '<合約書編號>' + @contno + '</合約書編號>'

  if @conttp = ''	
  	set @xmldata=@xmldata + '<合約類別代碼 />'
  else
  	set @xmldata=@xmldata + '<合約類別代碼>' + @conttp + '</合約類別代碼>'

  if @signdate = ''	
  	set @xmldata=@xmldata + '<簽約日期 />'
  else
  	set @xmldata=@xmldata + '<簽約日期>' + @signdate + '</簽約日期>'

  if @projno = ''	
  	set @xmldata=@xmldata + '<計劃代號 />'
  else
  	set @xmldata=@xmldata + '<計劃代號>' + @projno + '</計劃代號>'

  if @costctr = ''	
  	set @xmldata=@xmldata + '<成本中心 />'
  else
  	set @xmldata=@xmldata + '<成本中心>' + @costctr + '</成本中心>'

  if @bkcdprojnocostctr = ''	
  	set @xmldata=@xmldata + '<書籍全碼 />'
  else
  	set @xmldata=@xmldata + '<書籍全碼>' + @bkcdprojnocostctr + '</書籍全碼>'

  if @bkcd = ''	
  	set @xmldata=@xmldata + '<書籍類別代碼 />'
  else
  	set @xmldata=@xmldata + '<書籍類別代碼>' + @bkcd + '</書籍類別代碼>'

  if @sdate = ''	
  	set @xmldata=@xmldata + '<合約起日 />'
  else
  	set @xmldata=@xmldata + '<合約起日>' + @sdate + '</合約起日>'

  if @edate = ''	
  	set @xmldata=@xmldata + '<合約迄日 />'
  else
  	set @xmldata=@xmldata + '<合約迄日>' + @edate + '</合約迄日>'

  if @empno = ''	
  	set @xmldata=@xmldata + '<承辦業務員工號 />'
  else
  	set @xmldata=@xmldata + '<承辦業務員工號>' + @empno + '</承辦業務員工號>'

  if @fgpayonce = ''	
  	set @xmldata=@xmldata + '<一次付清註記 />'
  else
  	set @xmldata=@xmldata + '<一次付清註記>' + @fgpayonce + '</一次付清註記>'

  if @fgclosed = ''	
  	set @xmldata=@xmldata + '<結案註記 />'
  else
  	set @xmldata=@xmldata + '<結案註記>' + @fgclosed + '</結案註記>'

  if @moddate = ''	
  	set @xmldata=@xmldata + '<最後修改日期 />'
  else
  	set @xmldata=@xmldata + '<最後修改日期>' + @moddate + '</最後修改日期>'

  if @modempno = ''	
  	set @xmldata=@xmldata + '<修改業務員工號 />'
  else
  	set @xmldata=@xmldata + '<修改業務員工號>' + @modempno + '</修改業務員工號>'

  if @oldcontno = ''	
  	set @xmldata=@xmldata + '<舊合約編號 />'
  else
  	set @xmldata=@xmldata + '<舊合約編號>' + @oldcontno + '</舊合約編號>'
 
  if @pubcnt = ''	
  	set @xmldata=@xmldata + '<總有登本數 />'
  else
  	set @xmldata=@xmldata + '<總有登本數>' + @pubcnt + '</總有登本數>'
 
  if @unpubcnt = ''	
  	set @xmldata=@xmldata + '<總未登本數 />'
  else
  	set @xmldata=@xmldata + '<總未登本數>' + @unpubcnt + '</總未登本數>'
   
  set @xmldata=@xmldata + '</合約書基本資料>'  


 /* <合約書細節> */
  set @xmldata=@xmldata + '<合約書細節>'  

  if @totjtm = ''
  	set @xmldata=@xmldata + '<總製稿次數 />'  
  else
  	set @xmldata=@xmldata + '<總製稿次數>' + @totjtm + '</總製稿次數>'

  if @madejtm = ''
  	set @xmldata=@xmldata + '<已製稿次數 />'  
  else
  	set @xmldata=@xmldata + '<已製稿次數>' + @madejtm + '</已製稿次數>'

  if @restjtm = ''
  	set @xmldata=@xmldata + '<剩餘製稿次數 />'  
  else
  	set @xmldata=@xmldata + '<剩餘製稿次數>' + @restjtm + '</剩餘製稿次數>'

  if @tottm = ''
  	set @xmldata=@xmldata + '<總刊登次數 />'  
  else
  	set @xmldata=@xmldata + '<總刊登次數>' + @tottm + '</總刊登次數>'

  if @pubtm = ''
  	set @xmldata=@xmldata + '<已刊登次數 />'  
  else
  	set @xmldata=@xmldata + '<已刊登次數>' + @pubtm + '</已刊登次數>'

  if @resttm = ''
  	set @xmldata=@xmldata + '<剩餘刊登次數 />'  
  else
  	set @xmldata=@xmldata + '<剩餘刊登次數>' + @resttm + '</剩餘刊登次數>'

  if @totamt = ''
  	set @xmldata=@xmldata + '<合約總金額 />'  
  else
  	set @xmldata=@xmldata + '<合約總金額>' + @totamt + '</合約總金額>'

  if @paidamt = ''
  	set @xmldata=@xmldata + '<已繳金額 />'  
  else
  	set @xmldata=@xmldata + '<已繳金額>' + @paidamt + '</已繳金額>'

  if @restamt = ''
  	set @xmldata=@xmldata + '<剩餘金額 />'  
  else
  	set @xmldata=@xmldata + '<剩餘金額>' + @restamt + '</剩餘金額>'

  if @chgjtm = ''
  	set @xmldata=@xmldata + '<換稿次數 />'  
  else
  	set @xmldata=@xmldata + '<換稿次數>' + @chgjtm + '</換稿次數>'

  if @freetm = ''
  	set @xmldata=@xmldata + '<贈送次數 />'  
  else
  	set @xmldata=@xmldata + '<贈送次數>' + @freetm + '</贈送次數>'

  if @disc = ''
  	set @xmldata=@xmldata + '<優惠折數 />'  
  else
  	set @xmldata=@xmldata + '<優惠折數>' + @disc + '</優惠折數>'

  if @clrtm = ''
  	set @xmldata=@xmldata + '<彩色次數 />'  
  else
  	set @xmldata=@xmldata + '<彩色次數>' + @clrtm + '</彩色次數>'

  if @menotm = ''
  	set @xmldata=@xmldata + '<黑白次數 />'  
  else
  	set @xmldata=@xmldata + '<黑白次數>' + @menotm + '</黑白次數>'

  if @getclrtm = ''
  	set @xmldata=@xmldata + '<套色次數 />'  
  else
  	set @xmldata=@xmldata + '<套色次數>' + @getclrtm + '</套色次數>'


  set @xmldata=@xmldata + '</合約書細節>'  


 /* <廣告聯絡人資料> */
  set @xmldata=@xmldata + '<廣告聯絡人資料>'  

  if @aunm = ''	
  	set @xmldata=@xmldata + '<廣告聯絡人姓名 />'
  else
  	set @xmldata=@xmldata + '<廣告聯絡人姓名>' + @aunm + '</廣告聯絡人姓名>'

  if @autel = ''
  	set @xmldata=@xmldata + '<廣告聯絡人電話 />' 
  else
  	set @xmldata=@xmldata + '<廣告聯絡人電話>' + @autel + '</廣告聯絡人電話>'

  if @aufax = ''
  	set @xmldata=@xmldata + '<廣告聯絡人傳真 />' 
  else
  	set @xmldata=@xmldata + '<廣告聯絡人傳真>' + @aufax + '</廣告聯絡人傳真>'

  if @aucell = ''
  	set @xmldata=@xmldata + '<廣告聯絡人手機 />' 
  else
  	set @xmldata=@xmldata + '<廣告聯絡人手機>' + @aucell + '</廣告聯絡人手機>' 
   
  if @auemail = ''
  	set @xmldata=@xmldata + '<廣告聯絡人Email />'  
  else
  	set @xmldata=@xmldata + '<廣告聯絡人Email>' + @auemail + '</廣告聯絡人Email>'  


  set @xmldata=@xmldata + '</廣告聯絡人資料>'  


  set @xmldata=@xmldata + '</合約書內容>'


 	RETURN @xmldata
	END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c2_contAll    Script Date: 2002/7/6 上午 11:23:42 ******/
CREATE FUNCTION dbo.fn_c2_contAll
(
	@syscd char(2),
	@contno char(6)
)
RETURNS varchar(8000)
AS
	BEGIN

declare @imseq char(2),@oritem char(2)
declare @yyyymm char(6),@pubseq char(2)
declare @xmldata varchar(8000)

select @syscd=rtrim(cont_syscd),@contno=rtrim(cont_contno)
 from c2_cont
 where cont_syscd=@syscd and cont_contno=@contno

select @oritem=or_oritem
 from c2_or
 where or_syscd=@syscd and or_contno=@contno

 
 /* <root> */
 
 set @xmldata = '<root>'
 
 
 /* <合約書內容> */

	DECLARE ContBasic_Cursor CURSOR FOR
	 select cont_syscd, cont_contno
	 from c2_cont
	 where cont_syscd=@syscd and cont_contno=@contno
	OPEN ContBasic_Cursor
	
	FETCH NEXT FROM ContBasic_Cursor
	 into @syscd, @contno
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @xmldata=@xmldata + dbo.fn_c2_contBasic(@syscd ,@contno)
		FETCH NEXT FROM ContBasic_Cursor
		 into @syscd, @contno
	END
	
	CLOSE ContBasic_Cursor
	DEALLOCATE ContBasic_Cursor


 /* <發票廠商資料> */
	set @imseq='01'
	
	DECLARE ContIM_Cursor CURSOR FOR
	 select im_syscd, im_contno, im_imseq
	 from invmfr
	 where im_syscd=@syscd and im_contno=@contno and im_imseq=@imseq
	OPEN ContIM_Cursor
	
	FETCH NEXT FROM ContIM_Cursor
	 into @syscd, @contno, @imseq
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @xmldata=@xmldata + dbo.fn_c2_im(@syscd ,@contno,@imseq)
		FETCH NEXT FROM ContIM_Cursor
		 into @syscd, @contno, @imseq
	END
	
	CLOSE ContIM_Cursor
	DEALLOCATE ContIM_Cursor


 /* <雜誌收件人資料> */

	DECLARE ContOR_Cursor CURSOR FOR
	 select or_syscd, or_contno, or_oritem
	 from c2_or
	 where or_syscd=@syscd and or_contno=@contno and or_oritem=@oritem
	OPEN ContOR_Cursor
	
	FETCH NEXT FROM ContOR_Cursor
	 into @syscd, @contno, @oritem
	WHILE @@FETCH_STATUS = 0
	BEGIN
		set @xmldata=@xmldata + dbo.fn_c2_or(@syscd ,@contno,@oritem)
		FETCH NEXT FROM ContOR_Cursor
		 into @syscd, @contno, @oritem
	END
	
	CLOSE ContOR_Cursor
	DEALLOCATE ContOR_Cursor

 /* </root> */

  set @xmldata=@xmldata + '</root>'

 	RETURN @xmldata
	END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

