/****** Object:  Database mrlpub    Script Date: 2002/11/19 上午 10:37:48 ******/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'mrlpub')
	DROP DATABASE [mrlpub]
GO

CREATE DATABASE [mrlpub]  ON (NAME = N'mrlpub_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\mrlpub_Data.MDF' , SIZE = 55, FILEGROWTH = 10%) LOG ON (NAME = N'mrlpub_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\mrlpub_Log.LDF' , SIZE = 4, FILEGROWTH = 10%)
 COLLATE Chinese_Taiwan_Stroke_BIN
GO

exec sp_dboption N'mrlpub', N'autoclose', N'false'
GO

exec sp_dboption N'mrlpub', N'bulkcopy', N'false'
GO

exec sp_dboption N'mrlpub', N'trunc. log', N'false'
GO

exec sp_dboption N'mrlpub', N'torn page detection', N'true'
GO

exec sp_dboption N'mrlpub', N'read only', N'false'
GO

exec sp_dboption N'mrlpub', N'dbo use', N'false'
GO

exec sp_dboption N'mrlpub', N'single', N'false'
GO

exec sp_dboption N'mrlpub', N'autoshrink', N'false'
GO

exec sp_dboption N'mrlpub', N'ANSI null default', N'false'
GO

exec sp_dboption N'mrlpub', N'recursive triggers', N'false'
GO

exec sp_dboption N'mrlpub', N'ANSI nulls', N'false'
GO

exec sp_dboption N'mrlpub', N'concat null yields null', N'false'
GO

exec sp_dboption N'mrlpub', N'cursor close on commit', N'false'
GO

exec sp_dboption N'mrlpub', N'default to local cursor', N'false'
GO

exec sp_dboption N'mrlpub', N'quoted identifier', N'false'
GO

exec sp_dboption N'mrlpub', N'ANSI warnings', N'false'
GO

exec sp_dboption N'mrlpub', N'auto create statistics', N'true'
GO

exec sp_dboption N'mrlpub', N'auto update statistics', N'true'
GO

use [mrlpub]
GO

/****** Object:  User Defined Function dbo.fn_c1_od    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c1_od]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c1_od]
GO

/****** Object:  User Defined Function dbo.fn_c1_or    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c1_or]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c1_or]
GO

/****** Object:  User Defined Function dbo.fn_c1_order    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_c1_order]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fn_c1_order]
GO

/****** Object:  Stored Procedure dbo.sp_c1_tmp_statistics    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_tmp_statistics]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_tmp_statistics]
GO

/****** Object:  Stored Procedure dbo.sp_c2_getad_1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_getad_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_getad_1]
GO

/****** Object:  Stored Procedure dbo.sp_tmp_003    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_tmp_003]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_tmp_003]
GO

/****** Object:  Stored Procedure dbo.sp_c1_cancel_order    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_cancel_order]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_cancel_order]
GO

/****** Object:  Stored Procedure dbo.sp_c1_delete_ia    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_delete_ia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_delete_ia]
GO

/****** Object:  Stored Procedure dbo.sp_c1_delete_py    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_delete_py]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_delete_py]
GO

/****** Object:  Stored Procedure dbo.sp_c1_delete_pyseq    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_delete_pyseq]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_delete_pyseq]
GO

/****** Object:  Stored Procedure dbo.sp_c1_tmp_income1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_tmp_income1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_tmp_income1]
GO

/****** Object:  Stored Procedure dbo.sp_c1_xml_to_detail    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c1_xml_to_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c1_xml_to_detail]
GO

/****** Object:  Stored Procedure dbo.sp_c2_ORCounts_stat2b    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_ORCounts_stat2b]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_ORCounts_stat2b]
GO

/****** Object:  Stored Procedure dbo.sp_c2_ORMtpCounts_stat2b    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_ORMtpCounts_stat2b]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_ORMtpCounts_stat2b]
GO

/****** Object:  Stored Procedure dbo.sp_c2_add_1_ia_1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_add_1_ia_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_add_1_ia_1]
GO

/****** Object:  Stored Procedure dbo.sp_c2_add_ia    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_add_ia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_add_ia]
GO

/****** Object:  Stored Procedure dbo.sp_c2_contlist2_1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_contlist2_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_contlist2_1]
GO

/****** Object:  Stored Procedure dbo.sp_c2_contlist2_2    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_contlist2_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_contlist2_2]
GO

/****** Object:  Stored Procedure dbo.sp_c2_delete_ia_1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_delete_ia_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_delete_ia_1]
GO

/****** Object:  Stored Procedure dbo.sp_c2_delete_ia_all    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_delete_ia_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_delete_ia_all]
GO

/****** Object:  Stored Procedure dbo.sp_c2_getad_2    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_getad_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_getad_2]
GO

/****** Object:  Stored Procedure dbo.sp_c2_pubfm_lbl_unpub    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_pubfm_lbl_unpub]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_pubfm_lbl_unpub]
GO

/****** Object:  Stored Procedure dbo.sp_c2_rp1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_rp1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_rp1]
GO

/****** Object:  Stored Procedure dbo.sp_c2_rp2    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_rp2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_rp2]
GO

/****** Object:  Stored Procedure dbo.sp_c3_add_ia    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c3_add_ia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c3_add_ia]
GO

/****** Object:  Stored Procedure dbo.sp_c3_delete_appf    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c3_delete_appf]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c3_delete_appf]
GO

/****** Object:  Stored Procedure dbo.sp_c3_delete_ia    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c3_delete_ia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c3_delete_ia]
GO

/****** Object:  Stored Procedure dbo.sp_c4_add_1_ia_1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_1_ia_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_1_ia_1]
GO

/****** Object:  Stored Procedure dbo.sp_c4_add_batch_ia    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_batch_ia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_batch_ia]
GO

/****** Object:  Stored Procedure dbo.sp_order_to_detail    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_order_to_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_order_to_detail]
GO

/****** Object:  Stored Procedure dbo.sp_tmp_001    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_tmp_001]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_tmp_001]
GO

/****** Object:  Stored Procedure dbo.sp_tmp_002    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_tmp_002]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_tmp_002]
GO

/****** Object:  Stored Procedure dbo.sp_to_sap_001_a    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_to_sap_001_a]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_to_sap_001_a]
GO

/****** Object:  Stored Procedure dbo.sp_to_sap_002    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_to_sap_002]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_to_sap_002]
GO

/****** Object:  Stored Procedure dbo.sp_c2_update_adpub    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c2_update_adpub]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c2_update_adpub]
GO

/****** Object:  Stored Procedure dbo.sp_sap_in_all    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_sap_in_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_sap_in_all]
GO

/****** Object:  Stored Procedure dbo.usp_return    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_return]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_return]
GO

/****** Object:  View dbo.c1_o_detail_v_old    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_o_detail_v_old]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[c1_o_detail_v_old]
GO

/****** Object:  View dbo.c1_otp1_v_old    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_otp1_v_old]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[c1_otp1_v_old]
GO

/****** Object:  View dbo.v_c1_tmp_001    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c1_tmp_001]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c1_tmp_001]
GO

/****** Object:  View dbo.v_c2_count_pubseq_of_cont    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c2_count_pubseq_of_cont]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c2_count_pubseq_of_cont]
GO

/****** Object:  View dbo.v_c2_iaFm2_prelist2    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c2_iaFm2_prelist2]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c2_iaFm2_prelist2]
GO

/****** Object:  View dbo.v_c2_iaFm2_prelist2a    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c2_iaFm2_prelist2a]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c2_iaFm2_prelist2a]
GO

/****** Object:  View dbo.v_c4_cont_cust_mfr    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_cont_cust_mfr]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_cont_cust_mfr]
GO

/****** Object:  View dbo.v_c4_contchecklist    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_contchecklist]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_contchecklist]
GO

/****** Object:  View dbo.v_c4_cust_mfr    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_cust_mfr]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_cust_mfr]
GO

/****** Object:  View dbo.v_c4_invbatch    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_invbatch]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_invbatch]
GO

/****** Object:  View dbo.v_label1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_label1]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_label1]
GO

/****** Object:  View dbo.v_label_c1    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_label_c1]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_label_c1]
GO

/****** Object:  View dbo.v_maxseq    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_maxseq]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_maxseq]
GO

/****** Object:  Table [dbo].[Results]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Results]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Results]
GO

/****** Object:  Table [dbo].[Table1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Table1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Table1]
GO

/****** Object:  Table [dbo].[WebMember]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WebMember]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[WebMember]
GO

/****** Object:  Table [dbo].[WebMember_copy]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WebMember_copy]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[WebMember_copy]
GO

/****** Object:  Table [dbo].[book]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[book]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[book]
GO

/****** Object:  Table [dbo].[bookp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bookp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bookp]
GO

/****** Object:  Table [dbo].[btp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[btp]
GO

/****** Object:  Table [dbo].[c1_cust]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_cust]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_cust]
GO

/****** Object:  Table [dbo].[c1_lost]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_lost]
GO

/****** Object:  Table [dbo].[c1_obtp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_obtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_obtp]
GO

/****** Object:  Table [dbo].[c1_od]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_od]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_od]
GO

/****** Object:  Table [dbo].[c1_or]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_or]
GO

/****** Object:  Table [dbo].[c1_order]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_order]
GO

/****** Object:  Table [dbo].[c1_ores]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_ores]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_ores]
GO

/****** Object:  Table [dbo].[c1_otp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_otp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_otp]
GO

/****** Object:  Table [dbo].[c1_ramt]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_ramt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_ramt]
GO

/****** Object:  Table [dbo].[c1_remail]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c1_remail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c1_remail]
GO

/****** Object:  Table [dbo].[c2_clr]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_clr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_clr]
GO

/****** Object:  Table [dbo].[c2_cont]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_cont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_cont]
GO

/****** Object:  Table [dbo].[c2_cont_full]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_cont_full]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_cont_full]
GO

/****** Object:  Table [dbo].[c2_contlist2]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_contlist2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_contlist2]
GO

/****** Object:  Table [dbo].[c2_getad]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_getad]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_getad]
GO

/****** Object:  Table [dbo].[c2_lost]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_lost]
GO

/****** Object:  Table [dbo].[c2_lprior]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_lprior]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_lprior]
GO

/****** Object:  Table [dbo].[c2_ltp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_ltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_ltp]
GO

/****** Object:  Table [dbo].[c2_njtp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_njtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_njtp]
GO

/****** Object:  Table [dbo].[c2_or]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_or]
GO

/****** Object:  Table [dbo].[c2_pgno]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pgno]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pgno]
GO

/****** Object:  Table [dbo].[c2_pgsize]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pgsize]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pgsize]
GO

/****** Object:  Table [dbo].[c2_pub]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pub]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pub]
GO

/****** Object:  Table [dbo].[c2_pub_full]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c2_pub_full]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c2_pub_full]
GO

/****** Object:  Table [dbo].[c3_appf]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_appf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_appf]
GO

/****** Object:  Table [dbo].[c3_custcat1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_custcat1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_custcat1]
GO

/****** Object:  Table [dbo].[c3_custcat2]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_custcat2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_custcat2]
GO

/****** Object:  Table [dbo].[c3_freebk]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_freebk]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_freebk]
GO

/****** Object:  Table [dbo].[c3_invmfr]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_invmfr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_invmfr]
GO

/****** Object:  Table [dbo].[c3_lost]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_lost]
GO

/****** Object:  Table [dbo].[c3_or]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_or]
GO

/****** Object:  Table [dbo].[c3_remail]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c3_remail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c3_remail]
GO

/****** Object:  Table [dbo].[c4_adcnt]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_adcnt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_adcnt]
GO

/****** Object:  Table [dbo].[c4_adr]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_adr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_adr]
GO

/****** Object:  Table [dbo].[c4_adrd]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_adrd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_adrd]
GO

/****** Object:  Table [dbo].[c4_cont]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_cont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_cont]
GO

/****** Object:  Table [dbo].[c4_freebk]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_freebk]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_freebk]
GO

/****** Object:  Table [dbo].[c4_lost]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_lost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_lost]
GO

/****** Object:  Table [dbo].[c4_or]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_or]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_or]
GO

/****** Object:  Table [dbo].[c4_ramt]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_ramt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_ramt]
GO

/****** Object:  Table [dbo].[c4_remail]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_remail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_remail]
GO

/****** Object:  Table [dbo].[cust]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cust]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cust]
GO

/****** Object:  Table [dbo].[freecat]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[freecat]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[freecat]
GO

/****** Object:  Table [dbo].[hicard]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[hicard]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[hicard]
GO

/****** Object:  Table [dbo].[ia]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ia]
GO

/****** Object:  Table [dbo].[iab]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iab]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[iab]
GO

/****** Object:  Table [dbo].[iad]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iad]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[iad]
GO

/****** Object:  Table [dbo].[ias]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ias]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ias]
GO

/****** Object:  Table [dbo].[inftmp20]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[inftmp20]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[inftmp20]
GO

/****** Object:  Table [dbo].[inv10]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[inv10]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[inv10]
GO

/****** Object:  Table [dbo].[inv20]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[inv20]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[inv20]
GO

/****** Object:  Table [dbo].[invmfr]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[invmfr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[invmfr]
GO

/****** Object:  Table [dbo].[itp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[itp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[itp]
GO

/****** Object:  Table [dbo].[itriorg]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[itriorg]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[itriorg]
GO

/****** Object:  Table [dbo].[log_mb]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[log_mb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[log_mb]
GO

/****** Object:  Table [dbo].[mailer]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mailer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mailer]
GO

/****** Object:  Table [dbo].[mb]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mb]
GO

/****** Object:  Table [dbo].[mfr]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mfr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mfr]
GO

/****** Object:  Table [dbo].[mltp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mltp]
GO

/****** Object:  Table [dbo].[mtp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[mtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[mtp]
GO

/****** Object:  Table [dbo].[pbcatcol]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatcol]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatcol]
GO

/****** Object:  Table [dbo].[pbcatedt]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatedt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatedt]
GO

/****** Object:  Table [dbo].[pbcatfmt]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatfmt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatfmt]
GO

/****** Object:  Table [dbo].[pbcattbl]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcattbl]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcattbl]
GO

/****** Object:  Table [dbo].[pbcatvld]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pbcatvld]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pbcatvld]
GO

/****** Object:  Table [dbo].[proj]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proj]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[proj]
GO

/****** Object:  Table [dbo].[py]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[py]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[py]
GO

/****** Object:  Table [dbo].[pyd]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pyd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pyd]
GO

/****** Object:  Table [dbo].[pyseq]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pyseq]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pyseq]
GO

/****** Object:  Table [dbo].[pytp]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pytp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[pytp]
GO

/****** Object:  Table [dbo].[refd]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[refd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[refd]
GO

/****** Object:  Table [dbo].[refm]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[refm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[refm]
GO

/****** Object:  Table [dbo].[sapiv]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapiv]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapiv]
GO

/****** Object:  Table [dbo].[sapivd]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapivd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapivd]
GO

/****** Object:  Table [dbo].[saplog]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[saplog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[saplog]
GO

/****** Object:  Table [dbo].[sapvou]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sapvou]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sapvou]
GO

/****** Object:  Table [dbo].[srspn]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[srspn]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[srspn]
GO

/****** Object:  Table [dbo].[syscd]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[syscd]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[syscd]
GO

/****** Object:  Table [dbo].[test]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[test]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[test]
GO

/****** Object:  Table [dbo].[tmp_cust1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_cust1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tmp_cust1]
GO

/****** Object:  Table [dbo].[tmp_income1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_income1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tmp_income1]
GO

/****** Object:  Table [dbo].[tmp_label1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_label1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tmp_label1]
GO

/****** Object:  Table [dbo].[tmp_label2]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_label2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tmp_label2]
GO

/****** Object:  Table [dbo].[tmp_list1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_list1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tmp_list1]
GO

/****** Object:  Table [dbo].[tmp_statistics]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_statistics]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tmp_statistics]
GO

/****** Object:  Table [dbo].[wk_c2_rp1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp1]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_1]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp1_1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp1_1]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_2]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp1_2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp1_2]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_3]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp1_3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp1_3]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_4]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp1_4]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp1_4]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_5]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp1_5]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp1_5]
GO

/****** Object:  Table [dbo].[wk_c2_rp2]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp2]
GO

/****** Object:  Table [dbo].[wk_c2_rp3]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c2_rp3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c2_rp3]
GO

/****** Object:  Table [dbo].[wkflag]    Script Date: 2002/11/19 上午 10:38:17 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wkflag]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wkflag]
GO

/****** Object:  Login ADuser    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ADuser')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'ADuser', null, @logindb, @loginlang
END
GO

/****** Object:  Login ITRI\520035    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\520035')
	exec sp_grantlogin N'ITRI\520035'
	exec sp_defaultdb N'ITRI\520035', N'master'
	exec sp_defaultlanguage N'ITRI\520035', N'us_english'
GO

/****** Object:  Login ITRI\520155    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\520155')
	exec sp_grantlogin N'ITRI\520155'
	exec sp_defaultdb N'ITRI\520155', N'master'
	exec sp_defaultlanguage N'ITRI\520155', N'us_english'
GO

/****** Object:  Login ITRI\520183    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\520183')
	exec sp_grantlogin N'ITRI\520183'
	exec sp_defaultdb N'ITRI\520183', N'master'
	exec sp_defaultlanguage N'ITRI\520183', N'us_english'
GO

/****** Object:  Login ITRI\521427    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\521427')
	exec sp_grantlogin N'ITRI\521427'
	exec sp_defaultdb N'ITRI\521427', N'master'
	exec sp_defaultlanguage N'ITRI\521427', N'us_english'
GO

/****** Object:  Login ITRI\521449    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\521449')
	exec sp_grantlogin N'ITRI\521449'
	exec sp_defaultdb N'ITRI\521449', N'master'
	exec sp_defaultlanguage N'ITRI\521449', N'us_english'
GO

/****** Object:  Login ITRI\521812    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\521812')
	exec sp_grantlogin N'ITRI\521812'
	exec sp_defaultdb N'ITRI\521812', N'master'
	exec sp_defaultlanguage N'ITRI\521812', N'us_english'
GO

/****** Object:  Login ITRI\521931    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\521931')
	exec sp_grantlogin N'ITRI\521931'
	exec sp_defaultdb N'ITRI\521931', N'master'
	exec sp_defaultlanguage N'ITRI\521931', N'us_english'
GO

/****** Object:  Login ITRI\521955    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\521955')
	exec sp_grantlogin N'ITRI\521955'
	exec sp_defaultdb N'ITRI\521955', N'master'
	exec sp_defaultlanguage N'ITRI\521955', N'us_english'
GO

/****** Object:  Login ITRI\521965    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\521965')
	exec sp_grantlogin N'ITRI\521965'
	exec sp_defaultdb N'ITRI\521965', N'master'
	exec sp_defaultlanguage N'ITRI\521965', N'us_english'
GO

/****** Object:  Login ITRI\521986    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\521986')
	exec sp_grantlogin N'ITRI\521986'
	exec sp_defaultdb N'ITRI\521986', N'master'
	exec sp_defaultlanguage N'ITRI\521986', N'us_english'
GO

/****** Object:  Login ITRI\522251    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\522251')
	exec sp_grantlogin N'ITRI\522251'
	exec sp_defaultdb N'ITRI\522251', N'master'
	exec sp_defaultlanguage N'ITRI\522251', N'us_english'
GO

/****** Object:  Login ITRI\522255    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\522255')
	exec sp_grantlogin N'ITRI\522255'
	exec sp_defaultdb N'ITRI\522255', N'master'
	exec sp_defaultlanguage N'ITRI\522255', N'us_english'
GO

/****** Object:  Login ITRI\522274    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\522274')
	exec sp_grantlogin N'ITRI\522274'
	exec sp_defaultdb N'ITRI\522274', N'master'
	exec sp_defaultlanguage N'ITRI\522274', N'us_english'
GO

/****** Object:  Login ITRI\522305    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\522305')
	exec sp_grantlogin N'ITRI\522305'
	exec sp_defaultdb N'ITRI\522305', N'master'
	exec sp_defaultlanguage N'ITRI\522305', N'us_english'
GO

/****** Object:  Login ITRI\522330    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\522330')
	exec sp_grantlogin N'ITRI\522330'
	exec sp_defaultdb N'ITRI\522330', N'master'
	exec sp_defaultlanguage N'ITRI\522330', N'us_english'
GO

/****** Object:  Login ITRI\522340    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\522340')
	exec sp_grantlogin N'ITRI\522340'
	exec sp_defaultdb N'ITRI\522340', N'master'
	exec sp_defaultlanguage N'ITRI\522340', N'us_english'
GO

/****** Object:  Login ITRI\522397    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\522397')
	exec sp_grantlogin N'ITRI\522397'
	exec sp_defaultdb N'ITRI\522397', N'master'
	exec sp_defaultlanguage N'ITRI\522397', N'us_english'
GO

/****** Object:  Login ITRI\620133    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\620133')
	exec sp_grantlogin N'ITRI\620133'
	exec sp_defaultdb N'ITRI\620133', N'master'
	exec sp_defaultlanguage N'ITRI\620133', N'us_english'
GO

/****** Object:  Login ITRI\620267    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\620267')
	exec sp_grantlogin N'ITRI\620267'
	exec sp_defaultdb N'ITRI\620267', N'master'
	exec sp_defaultlanguage N'ITRI\620267', N'us_english'
GO

/****** Object:  Login ITRI\640095    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\640095')
	exec sp_grantlogin N'ITRI\640095'
	exec sp_defaultdb N'ITRI\640095', N'master'
	exec sp_defaultlanguage N'ITRI\640095', N'us_english'
GO

/****** Object:  Login ITRI\640138    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\640138')
	exec sp_grantlogin N'ITRI\640138'
	exec sp_defaultdb N'ITRI\640138', N'master'
	exec sp_defaultlanguage N'ITRI\640138', N'us_english'
GO

/****** Object:  Login ITRI\650141    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\650141')
	exec sp_grantlogin N'ITRI\650141'
	exec sp_defaultdb N'ITRI\650141', N'master'
	exec sp_defaultlanguage N'ITRI\650141', N'us_english'
GO

/****** Object:  Login ITRI\660016    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\660016')
	exec sp_grantlogin N'ITRI\660016'
	exec sp_defaultdb N'ITRI\660016', N'master'
	exec sp_defaultlanguage N'ITRI\660016', N'us_english'
GO

/****** Object:  Login ITRI\660250    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\660250')
	exec sp_grantlogin N'ITRI\660250'
	exec sp_defaultdb N'ITRI\660250', N'master'
	exec sp_defaultlanguage N'ITRI\660250', N'us_english'
GO

/****** Object:  Login ITRI\670001    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\670001')
	exec sp_grantlogin N'ITRI\670001'
	exec sp_defaultdb N'ITRI\670001', N'master'
	exec sp_defaultlanguage N'ITRI\670001', N'us_english'
GO

/****** Object:  Login ITRI\680197    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\680197')
	exec sp_grantlogin N'ITRI\680197'
	exec sp_defaultdb N'ITRI\680197', N'master'
	exec sp_defaultlanguage N'ITRI\680197', N'us_english'
GO

/****** Object:  Login ITRI\680201    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\680201')
	exec sp_grantlogin N'ITRI\680201'
	exec sp_defaultdb N'ITRI\680201', N'master'
	exec sp_defaultlanguage N'ITRI\680201', N'us_english'
GO

/****** Object:  Login ITRI\690113    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\690113')
	exec sp_grantlogin N'ITRI\690113'
	exec sp_defaultdb N'ITRI\690113', N'master'
	exec sp_defaultlanguage N'ITRI\690113', N'us_english'
GO

/****** Object:  Login ITRI\690269    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\690269')
	exec sp_grantlogin N'ITRI\690269'
	exec sp_defaultdb N'ITRI\690269', N'master'
	exec sp_defaultlanguage N'ITRI\690269', N'us_english'
GO

/****** Object:  Login ITRI\700337    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\700337')
	exec sp_grantlogin N'ITRI\700337'
	exec sp_defaultdb N'ITRI\700337', N'master'
	exec sp_defaultlanguage N'ITRI\700337', N'us_english'
GO

/****** Object:  Login ITRI\700378    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\700378')
	exec sp_grantlogin N'ITRI\700378'
	exec sp_defaultdb N'ITRI\700378', N'master'
	exec sp_defaultlanguage N'ITRI\700378', N'us_english'
GO

/****** Object:  Login ITRI\710155    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\710155')
	exec sp_grantlogin N'ITRI\710155'
	exec sp_defaultdb N'ITRI\710155', N'master'
	exec sp_defaultlanguage N'ITRI\710155', N'us_english'
GO

/****** Object:  Login ITRI\710165    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\710165')
	exec sp_grantlogin N'ITRI\710165'
	exec sp_defaultdb N'ITRI\710165', N'master'
	exec sp_defaultlanguage N'ITRI\710165', N'us_english'
GO

/****** Object:  Login ITRI\710544    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\710544')
	exec sp_grantlogin N'ITRI\710544'
	exec sp_defaultdb N'ITRI\710544', N'master'
	exec sp_defaultlanguage N'ITRI\710544', N'us_english'
GO

/****** Object:  Login ITRI\710637    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\710637')
	exec sp_grantlogin N'ITRI\710637'
	exec sp_defaultdb N'ITRI\710637', N'master'
	exec sp_defaultlanguage N'ITRI\710637', N'us_english'
GO

/****** Object:  Login ITRI\730125    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\730125')
	exec sp_grantlogin N'ITRI\730125'
	exec sp_defaultdb N'ITRI\730125', N'master'
	exec sp_defaultlanguage N'ITRI\730125', N'us_english'
GO

/****** Object:  Login ITRI\730308    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\730308')
	exec sp_grantlogin N'ITRI\730308'
	exec sp_defaultdb N'ITRI\730308', N'master'
	exec sp_defaultlanguage N'ITRI\730308', N'us_english'
GO

/****** Object:  Login ITRI\740017    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\740017')
	exec sp_grantlogin N'ITRI\740017'
	exec sp_defaultdb N'ITRI\740017', N'master'
	exec sp_defaultlanguage N'ITRI\740017', N'us_english'
GO

/****** Object:  Login ITRI\740036    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\740036')
	exec sp_grantlogin N'ITRI\740036'
	exec sp_defaultdb N'ITRI\740036', N'master'
	exec sp_defaultlanguage N'ITRI\740036', N'us_english'
GO

/****** Object:  Login ITRI\740048    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\740048')
	exec sp_grantlogin N'ITRI\740048'
	exec sp_defaultdb N'ITRI\740048', N'master'
	exec sp_defaultlanguage N'ITRI\740048', N'us_english'
GO

/****** Object:  Login ITRI\740057    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\740057')
	exec sp_grantlogin N'ITRI\740057'
	exec sp_defaultdb N'ITRI\740057', N'master'
	exec sp_defaultlanguage N'ITRI\740057', N'us_english'
GO

/****** Object:  Login ITRI\740160    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\740160')
	exec sp_grantlogin N'ITRI\740160'
	exec sp_defaultdb N'ITRI\740160', N'master'
	exec sp_defaultlanguage N'ITRI\740160', N'us_english'
GO

/****** Object:  Login ITRI\740320    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\740320')
	exec sp_grantlogin N'ITRI\740320'
	exec sp_defaultdb N'ITRI\740320', N'mrlpub'
	exec sp_defaultlanguage N'ITRI\740320', N'us_english'
GO

/****** Object:  Login ITRI\740444    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\740444')
	exec sp_grantlogin N'ITRI\740444'
	exec sp_defaultdb N'ITRI\740444', N'master'
	exec sp_defaultlanguage N'ITRI\740444', N'us_english'
GO

/****** Object:  Login ITRI\750171    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\750171')
	exec sp_grantlogin N'ITRI\750171'
	exec sp_defaultdb N'ITRI\750171', N'master'
	exec sp_defaultlanguage N'ITRI\750171', N'us_english'
GO

/****** Object:  Login ITRI\750207    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\750207')
	exec sp_grantlogin N'ITRI\750207'
	exec sp_defaultdb N'ITRI\750207', N'master'
	exec sp_defaultlanguage N'ITRI\750207', N'us_english'
GO

/****** Object:  Login ITRI\750326    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\750326')
	exec sp_grantlogin N'ITRI\750326'
	exec sp_defaultdb N'ITRI\750326', N'master'
	exec sp_defaultlanguage N'ITRI\750326', N'us_english'
GO

/****** Object:  Login ITRI\750344    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\750344')
	exec sp_grantlogin N'ITRI\750344'
	exec sp_defaultdb N'ITRI\750344', N'master'
	exec sp_defaultlanguage N'ITRI\750344', N'us_english'
GO

/****** Object:  Login ITRI\750576    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\750576')
	exec sp_grantlogin N'ITRI\750576'
	exec sp_defaultdb N'ITRI\750576', N'master'
	exec sp_defaultlanguage N'ITRI\750576', N'us_english'
GO

/****** Object:  Login ITRI\750641    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\750641')
	exec sp_grantlogin N'ITRI\750641'
	exec sp_defaultdb N'ITRI\750641', N'master'
	exec sp_defaultlanguage N'ITRI\750641', N'us_english'
GO

/****** Object:  Login ITRI\760966    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\760966')
	exec sp_grantlogin N'ITRI\760966'
	exec sp_defaultdb N'ITRI\760966', N'master'
	exec sp_defaultlanguage N'ITRI\760966', N'us_english'
GO

/****** Object:  Login ITRI\761077    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\761077')
	exec sp_grantlogin N'ITRI\761077'
	exec sp_defaultdb N'ITRI\761077', N'master'
	exec sp_defaultlanguage N'ITRI\761077', N'us_english'
GO

/****** Object:  Login ITRI\770381    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\770381')
	exec sp_grantlogin N'ITRI\770381'
	exec sp_defaultdb N'ITRI\770381', N'master'
	exec sp_defaultlanguage N'ITRI\770381', N'us_english'
GO

/****** Object:  Login ITRI\770382    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\770382')
	exec sp_grantlogin N'ITRI\770382'
	exec sp_defaultdb N'ITRI\770382', N'master'
	exec sp_defaultlanguage N'ITRI\770382', N'us_english'
GO

/****** Object:  Login ITRI\770916    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\770916')
	exec sp_grantlogin N'ITRI\770916'
	exec sp_defaultdb N'ITRI\770916', N'master'
	exec sp_defaultlanguage N'ITRI\770916', N'us_english'
GO

/****** Object:  Login ITRI\780139    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780139')
	exec sp_grantlogin N'ITRI\780139'
	exec sp_defaultdb N'ITRI\780139', N'master'
	exec sp_defaultlanguage N'ITRI\780139', N'us_english'
GO

/****** Object:  Login ITRI\780217    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780217')
	exec sp_grantlogin N'ITRI\780217'
	exec sp_defaultdb N'ITRI\780217', N'master'
	exec sp_defaultlanguage N'ITRI\780217', N'us_english'
GO

/****** Object:  Login ITRI\780355    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780355')
	exec sp_grantlogin N'ITRI\780355'
	exec sp_defaultdb N'ITRI\780355', N'master'
	exec sp_defaultlanguage N'ITRI\780355', N'us_english'
GO

/****** Object:  Login ITRI\780356    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780356')
	exec sp_grantlogin N'ITRI\780356'
	exec sp_defaultdb N'ITRI\780356', N'master'
	exec sp_defaultlanguage N'ITRI\780356', N'us_english'
GO

/****** Object:  Login ITRI\780451    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780451')
	exec sp_grantlogin N'ITRI\780451'
	exec sp_defaultdb N'ITRI\780451', N'master'
	exec sp_defaultlanguage N'ITRI\780451', N'us_english'
GO

/****** Object:  Login ITRI\780526    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780526')
	exec sp_grantlogin N'ITRI\780526'
	exec sp_defaultdb N'ITRI\780526', N'master'
	exec sp_defaultlanguage N'ITRI\780526', N'us_english'
GO

/****** Object:  Login ITRI\780670    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780670')
	exec sp_grantlogin N'ITRI\780670'
	exec sp_defaultdb N'ITRI\780670', N'master'
	exec sp_defaultlanguage N'ITRI\780670', N'us_english'
GO

/****** Object:  Login ITRI\780913    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\780913')
	exec sp_grantlogin N'ITRI\780913'
	exec sp_defaultdb N'ITRI\780913', N'master'
	exec sp_defaultlanguage N'ITRI\780913', N'us_english'
GO

/****** Object:  Login ITRI\790098    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\790098')
	exec sp_grantlogin N'ITRI\790098'
	exec sp_defaultdb N'ITRI\790098', N'master'
	exec sp_defaultlanguage N'ITRI\790098', N'us_english'
GO

/****** Object:  Login ITRI\790149    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\790149')
	exec sp_grantlogin N'ITRI\790149'
	exec sp_defaultdb N'ITRI\790149', N'master'
	exec sp_defaultlanguage N'ITRI\790149', N'us_english'
GO

/****** Object:  Login ITRI\790565    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\790565')
	exec sp_grantlogin N'ITRI\790565'
	exec sp_defaultdb N'ITRI\790565', N'master'
	exec sp_defaultlanguage N'ITRI\790565', N'us_english'
GO

/****** Object:  Login ITRI\790650    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\790650')
	exec sp_grantlogin N'ITRI\790650'
	exec sp_defaultdb N'ITRI\790650', N'master'
	exec sp_defaultlanguage N'ITRI\790650', N'us_english'
GO

/****** Object:  Login ITRI\790660    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\790660')
	exec sp_grantlogin N'ITRI\790660'
	exec sp_defaultdb N'ITRI\790660', N'master'
	exec sp_defaultlanguage N'ITRI\790660', N'us_english'
GO

/****** Object:  Login ITRI\790815    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\790815')
	exec sp_grantlogin N'ITRI\790815'
	exec sp_defaultdb N'ITRI\790815', N'master'
	exec sp_defaultlanguage N'ITRI\790815', N'us_english'
GO

/****** Object:  Login ITRI\800108    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\800108')
	exec sp_grantlogin N'ITRI\800108'
	exec sp_defaultdb N'ITRI\800108', N'master'
	exec sp_defaultlanguage N'ITRI\800108', N'us_english'
GO

/****** Object:  Login ITRI\800117    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\800117')
	exec sp_grantlogin N'ITRI\800117'
	exec sp_defaultdb N'ITRI\800117', N'master'
	exec sp_defaultlanguage N'ITRI\800117', N'us_english'
GO

/****** Object:  Login ITRI\800209    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\800209')
	exec sp_grantlogin N'ITRI\800209'
	exec sp_defaultdb N'ITRI\800209', N'master'
	exec sp_defaultlanguage N'ITRI\800209', N'us_english'
GO

/****** Object:  Login ITRI\800586    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\800586')
	exec sp_grantlogin N'ITRI\800586'
	exec sp_defaultdb N'ITRI\800586', N'master'
	exec sp_defaultlanguage N'ITRI\800586', N'us_english'
GO

/****** Object:  Login ITRI\800650    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\800650')
	exec sp_grantlogin N'ITRI\800650'
	exec sp_defaultdb N'ITRI\800650', N'master'
	exec sp_defaultlanguage N'ITRI\800650', N'us_english'
GO

/****** Object:  Login ITRI\800907    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\800907')
	exec sp_grantlogin N'ITRI\800907'
	exec sp_defaultdb N'ITRI\800907', N'master'
	exec sp_defaultlanguage N'ITRI\800907', N'us_english'
GO

/****** Object:  Login ITRI\800917    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\800917')
	exec sp_grantlogin N'ITRI\800917'
	exec sp_defaultdb N'ITRI\800917', N'master'
	exec sp_defaultlanguage N'ITRI\800917', N'us_english'
GO

/****** Object:  Login ITRI\810010    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810010')
	exec sp_grantlogin N'ITRI\810010'
	exec sp_defaultdb N'ITRI\810010', N'master'
	exec sp_defaultlanguage N'ITRI\810010', N'us_english'
GO

/****** Object:  Login ITRI\810087    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810087')
	exec sp_grantlogin N'ITRI\810087'
	exec sp_defaultdb N'ITRI\810087', N'master'
	exec sp_defaultlanguage N'ITRI\810087', N'us_english'
GO

/****** Object:  Login ITRI\810218    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810218')
	exec sp_grantlogin N'ITRI\810218'
	exec sp_defaultdb N'ITRI\810218', N'master'
	exec sp_defaultlanguage N'ITRI\810218', N'us_english'
GO

/****** Object:  Login ITRI\810254    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810254')
	exec sp_grantlogin N'ITRI\810254'
	exec sp_defaultdb N'ITRI\810254', N'master'
	exec sp_defaultlanguage N'ITRI\810254', N'us_english'
GO

/****** Object:  Login ITRI\810261    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810261')
	exec sp_grantlogin N'ITRI\810261'
	exec sp_defaultdb N'ITRI\810261', N'master'
	exec sp_defaultlanguage N'ITRI\810261', N'us_english'
GO

/****** Object:  Login ITRI\810483    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810483')
	exec sp_grantlogin N'ITRI\810483'
	exec sp_defaultdb N'ITRI\810483', N'master'
	exec sp_defaultlanguage N'ITRI\810483', N'us_english'
GO

/****** Object:  Login ITRI\810490    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810490')
	exec sp_grantlogin N'ITRI\810490'
	exec sp_defaultdb N'ITRI\810490', N'master'
	exec sp_defaultlanguage N'ITRI\810490', N'us_english'
GO

/****** Object:  Login ITRI\810522    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810522')
	exec sp_grantlogin N'ITRI\810522'
	exec sp_defaultdb N'ITRI\810522', N'master'
	exec sp_defaultlanguage N'ITRI\810522', N'us_english'
GO

/****** Object:  Login ITRI\810556    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810556')
	exec sp_grantlogin N'ITRI\810556'
	exec sp_defaultdb N'ITRI\810556', N'uclplan'
	exec sp_defaultlanguage N'ITRI\810556', N'us_english'
GO

/****** Object:  Login ITRI\810657    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810657')
	exec sp_grantlogin N'ITRI\810657'
	exec sp_defaultdb N'ITRI\810657', N'master'
	exec sp_defaultlanguage N'ITRI\810657', N'us_english'
GO

/****** Object:  Login ITRI\810844    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810844')
	exec sp_grantlogin N'ITRI\810844'
	exec sp_defaultdb N'ITRI\810844', N'master'
	exec sp_defaultlanguage N'ITRI\810844', N'us_english'
GO

/****** Object:  Login ITRI\810898    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\810898')
	exec sp_grantlogin N'ITRI\810898'
	exec sp_defaultdb N'ITRI\810898', N'master'
	exec sp_defaultlanguage N'ITRI\810898', N'us_english'
GO

/****** Object:  Login ITRI\820111    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\820111')
	exec sp_grantlogin N'ITRI\820111'
	exec sp_defaultdb N'ITRI\820111', N'master'
	exec sp_defaultlanguage N'ITRI\820111', N'us_english'
GO

/****** Object:  Login ITRI\820128    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\820128')
	exec sp_grantlogin N'ITRI\820128'
	exec sp_defaultdb N'ITRI\820128', N'master'
	exec sp_defaultlanguage N'ITRI\820128', N'us_english'
GO

/****** Object:  Login ITRI\820246    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\820246')
	exec sp_grantlogin N'ITRI\820246'
	exec sp_defaultdb N'ITRI\820246', N'master'
	exec sp_defaultlanguage N'ITRI\820246', N'us_english'
GO

/****** Object:  Login ITRI\820301    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\820301')
	exec sp_grantlogin N'ITRI\820301'
	exec sp_defaultdb N'ITRI\820301', N'master'
	exec sp_defaultlanguage N'ITRI\820301', N'us_english'
GO

/****** Object:  Login ITRI\830018    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\830018')
	exec sp_grantlogin N'ITRI\830018'
	exec sp_defaultdb N'ITRI\830018', N'master'
	exec sp_defaultlanguage N'ITRI\830018', N'us_english'
GO

/****** Object:  Login ITRI\830397    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\830397')
	exec sp_grantlogin N'ITRI\830397'
	exec sp_defaultdb N'ITRI\830397', N'master'
	exec sp_defaultlanguage N'ITRI\830397', N'us_english'
GO

/****** Object:  Login ITRI\840204    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\840204')
	exec sp_grantlogin N'ITRI\840204'
	exec sp_defaultdb N'ITRI\840204', N'master'
	exec sp_defaultlanguage N'ITRI\840204', N'us_english'
GO

/****** Object:  Login ITRI\840580    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\840580')
	exec sp_grantlogin N'ITRI\840580'
	exec sp_defaultdb N'ITRI\840580', N'master'
	exec sp_defaultlanguage N'ITRI\840580', N'us_english'
GO

/****** Object:  Login ITRI\840695    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\840695')
	exec sp_grantlogin N'ITRI\840695'
	exec sp_defaultdb N'ITRI\840695', N'uclplan'
	exec sp_defaultlanguage N'ITRI\840695', N'us_english'
GO

/****** Object:  Login ITRI\840706    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\840706')
	exec sp_grantlogin N'ITRI\840706'
	exec sp_defaultdb N'ITRI\840706', N'master'
	exec sp_defaultlanguage N'ITRI\840706', N'us_english'
GO

/****** Object:  Login ITRI\840901    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\840901')
	exec sp_grantlogin N'ITRI\840901'
	exec sp_defaultdb N'ITRI\840901', N'master'
	exec sp_defaultlanguage N'ITRI\840901', N'us_english'
GO

/****** Object:  Login ITRI\850153    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\850153')
	exec sp_grantlogin N'ITRI\850153'
	exec sp_defaultdb N'ITRI\850153', N'master'
	exec sp_defaultlanguage N'ITRI\850153', N'us_english'
GO

/****** Object:  Login ITRI\850159    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\850159')
	exec sp_grantlogin N'ITRI\850159'
	exec sp_defaultdb N'ITRI\850159', N'master'
	exec sp_defaultlanguage N'ITRI\850159', N'us_english'
GO

/****** Object:  Login ITRI\850232    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\850232')
	exec sp_grantlogin N'ITRI\850232'
	exec sp_defaultdb N'ITRI\850232', N'master'
	exec sp_defaultlanguage N'ITRI\850232', N'us_english'
GO

/****** Object:  Login ITRI\850394    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\850394')
	exec sp_grantlogin N'ITRI\850394'
	exec sp_defaultdb N'ITRI\850394', N'master'
	exec sp_defaultlanguage N'ITRI\850394', N'us_english'
GO

/****** Object:  Login ITRI\860018    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860018')
	exec sp_grantlogin N'ITRI\860018'
	exec sp_defaultdb N'ITRI\860018', N'master'
	exec sp_defaultlanguage N'ITRI\860018', N'us_english'
GO

/****** Object:  Login ITRI\860029    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860029')
	exec sp_grantlogin N'ITRI\860029'
	exec sp_defaultdb N'ITRI\860029', N'master'
	exec sp_defaultlanguage N'ITRI\860029', N'us_english'
GO

/****** Object:  Login ITRI\860107    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860107')
	exec sp_grantlogin N'ITRI\860107'
	exec sp_defaultdb N'ITRI\860107', N'master'
	exec sp_defaultlanguage N'ITRI\860107', N'us_english'
GO

/****** Object:  Login ITRI\860118    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860118')
	exec sp_grantlogin N'ITRI\860118'
	exec sp_defaultdb N'ITRI\860118', N'master'
	exec sp_defaultlanguage N'ITRI\860118', N'us_english'
GO

/****** Object:  Login ITRI\860282    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860282')
	exec sp_grantlogin N'ITRI\860282'
	exec sp_defaultdb N'ITRI\860282', N'master'
	exec sp_defaultlanguage N'ITRI\860282', N'us_english'
GO

/****** Object:  Login ITRI\860401    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860401')
	exec sp_grantlogin N'ITRI\860401'
	exec sp_defaultdb N'ITRI\860401', N'master'
	exec sp_defaultlanguage N'ITRI\860401', N'us_english'
GO

/****** Object:  Login ITRI\860478    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860478')
	exec sp_grantlogin N'ITRI\860478'
	exec sp_defaultdb N'ITRI\860478', N'master'
	exec sp_defaultlanguage N'ITRI\860478', N'us_english'
GO

/****** Object:  Login ITRI\860637    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860637')
	exec sp_grantlogin N'ITRI\860637'
	exec sp_defaultdb N'ITRI\860637', N'master'
	exec sp_defaultlanguage N'ITRI\860637', N'us_english'
GO

/****** Object:  Login ITRI\860645    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860645')
	exec sp_grantlogin N'ITRI\860645'
	exec sp_defaultdb N'ITRI\860645', N'master'
	exec sp_defaultlanguage N'ITRI\860645', N'us_english'
GO

/****** Object:  Login ITRI\860859    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\860859')
	exec sp_grantlogin N'ITRI\860859'
	exec sp_defaultdb N'ITRI\860859', N'master'
	exec sp_defaultlanguage N'ITRI\860859', N'us_english'
GO

/****** Object:  Login ITRI\870360    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\870360')
	exec sp_grantlogin N'ITRI\870360'
	exec sp_defaultdb N'ITRI\870360', N'master'
	exec sp_defaultlanguage N'ITRI\870360', N'us_english'
GO

/****** Object:  Login ITRI\870657    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\870657')
	exec sp_grantlogin N'ITRI\870657'
	exec sp_defaultdb N'ITRI\870657', N'master'
	exec sp_defaultlanguage N'ITRI\870657', N'us_english'
GO

/****** Object:  Login ITRI\870723    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\870723')
	exec sp_grantlogin N'ITRI\870723'
	exec sp_defaultdb N'ITRI\870723', N'master'
	exec sp_defaultlanguage N'ITRI\870723', N'us_english'
GO

/****** Object:  Login ITRI\880537    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\880537')
	exec sp_grantlogin N'ITRI\880537'
	exec sp_defaultdb N'ITRI\880537', N'master'
	exec sp_defaultlanguage N'ITRI\880537', N'us_english'
GO

/****** Object:  Login ITRI\880573    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\880573')
	exec sp_grantlogin N'ITRI\880573'
	exec sp_defaultdb N'ITRI\880573', N'master'
	exec sp_defaultlanguage N'ITRI\880573', N'us_english'
GO

/****** Object:  Login ITRI\880581    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\880581')
	exec sp_grantlogin N'ITRI\880581'
	exec sp_defaultdb N'ITRI\880581', N'master'
	exec sp_defaultlanguage N'ITRI\880581', N'us_english'
GO

/****** Object:  Login ITRI\880591    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\880591')
	exec sp_grantlogin N'ITRI\880591'
	exec sp_defaultdb N'ITRI\880591', N'master'
	exec sp_defaultlanguage N'ITRI\880591', N'us_english'
GO

/****** Object:  Login ITRI\880819    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\880819')
	exec sp_grantlogin N'ITRI\880819'
	exec sp_defaultdb N'ITRI\880819', N'master'
	exec sp_defaultlanguage N'ITRI\880819', N'us_english'
GO

/****** Object:  Login ITRI\890363    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\890363')
	exec sp_grantlogin N'ITRI\890363'
	exec sp_defaultdb N'ITRI\890363', N'master'
	exec sp_defaultlanguage N'ITRI\890363', N'us_english'
GO

/****** Object:  Login ITRI\900078    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\900078')
	exec sp_grantlogin N'ITRI\900078'
	exec sp_defaultdb N'ITRI\900078', N'master'
	exec sp_defaultlanguage N'ITRI\900078', N'us_english'
GO

/****** Object:  Login ITRI\900080    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\900080')
	exec sp_grantlogin N'ITRI\900080'
	exec sp_defaultdb N'ITRI\900080', N'master'
	exec sp_defaultlanguage N'ITRI\900080', N'us_english'
GO

/****** Object:  Login ITRI\900087    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\900087')
	exec sp_grantlogin N'ITRI\900087'
	exec sp_defaultdb N'ITRI\900087', N'master'
	exec sp_defaultlanguage N'ITRI\900087', N'us_english'
GO

/****** Object:  Login ITRI\900103    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\900103')
	exec sp_grantlogin N'ITRI\900103'
	exec sp_defaultdb N'ITRI\900103', N'uclcacdb'
	exec sp_defaultlanguage N'ITRI\900103', N'us_english'
GO

/****** Object:  Login ITRI\900833    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\900833')
	exec sp_grantlogin N'ITRI\900833'
	exec sp_defaultdb N'ITRI\900833', N'master'
	exec sp_defaultlanguage N'ITRI\900833', N'us_english'
GO

/****** Object:  Login ITRI\910142    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\910142')
	exec sp_grantlogin N'ITRI\910142'
	exec sp_defaultdb N'ITRI\910142', N'master'
	exec sp_defaultlanguage N'ITRI\910142', N'us_english'
GO

/****** Object:  Login ITRI\910521    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\910521')
	exec sp_grantlogin N'ITRI\910521'
	exec sp_defaultdb N'ITRI\910521', N'master'
	exec sp_defaultlanguage N'ITRI\910521', N'us_english'
GO

/****** Object:  Login ITRI\910637    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\910637')
	exec sp_grantlogin N'ITRI\910637'
	exec sp_defaultdb N'ITRI\910637', N'master'
	exec sp_defaultlanguage N'ITRI\910637', N'us_english'
GO

/****** Object:  Login ITRI\SrvAccount    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\SrvAccount')
	exec sp_grantlogin N'ITRI\SrvAccount'
	exec sp_defaultdb N'ITRI\SrvAccount', N'master'
	exec sp_defaultlanguage N'ITRI\SrvAccount', N'us_english'
GO

/****** Object:  Login WebLogin    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'WebLogin')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'sales', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'WebLogin', null, @logindb, @loginlang
END
GO

/****** Object:  Login comusr    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'comusr')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'common', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'comusr', null, @logindb, @loginlang
END
GO

/****** Object:  Login ibaone    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ibaone')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'ibaone', null, @logindb, @loginlang
END
GO

/****** Object:  Login ibasmgr    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ibasmgr')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'ibasmgr', null, @logindb, @loginlang
END
GO

/****** Object:  Login mailadm    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'mailadm')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'mailadm', null, @logindb, @loginlang
END
GO

/****** Object:  Login mrlmis    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'mrlmis')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'mrlmis', null, @logindb, @loginlang
END
GO

/****** Object:  Login mrlpub    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'mrlpub')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'繁體中文'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'mrlpub', null, @logindb, @loginlang
END
GO

/****** Object:  Login nspcom    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'nspcom')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'common', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'nspcom', null, @logindb, @loginlang
END
GO

/****** Object:  Login oedppub    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'oedppub')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'oedpmsdb', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'oedppub', null, @logindb, @loginlang
END
GO

/****** Object:  Login petshop    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'petshop')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'MSPetShop', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'petshop', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubchem    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubchem')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubchem', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubcms    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubcms')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'common', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubcms', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubcom    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubcom')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'common', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubcom', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubcompart    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubcompart')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubcompart', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubezfl    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubezfl')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubezfl', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubfa10    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubfa10')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubfa10', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubfdpj    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubfdpj')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubfdpj', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubiba    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubiba')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubiba', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubibapur    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubibapur')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubibapur', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubmirl    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubmirl')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubmirl', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubmrlpub    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubmrlpub')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'mrlpub', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubmrlpub', null, @logindb, @loginlang
END
GO

/****** Object:  Login puboa    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'puboa')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'puboa', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubof    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubof')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubof', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubread    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubread')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubread', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubsap    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubsap')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubsap', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubsb000    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubsb000')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'uclplan', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubsb000', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubse100    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubse100')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubse100', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubsectl    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubsectl')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubsectl', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubsel    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubsel')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubsel', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubspf    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubspf')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubspf', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubtel    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubtel')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubtel', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubtmc    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubtmc')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubtmc', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubuclcac    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubuclcac')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'uclcacdb', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubuclcac', null, @logindb, @loginlang
END
GO

/****** Object:  Login pubvd    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'pubvd')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'pubvd', null, @logindb, @loginlang
END
GO

/****** Object:  Login test    Script Date: 2002/11/19 上午 10:37:48 ******/
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

/****** Object:  Login u521393    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'u521393')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'u521393', null, @logindb, @loginlang
END
GO

/****** Object:  Login u761192    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'u761192')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'u761192', null, @logindb, @loginlang
END
GO

/****** Object:  Login u840606    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'u840606')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'u840606', null, @logindb, @loginlang
END
GO

/****** Object:  Login webuser    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'webuser')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'common', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'webuser', null, @logindb, @loginlang
END
GO

/****** Object:  Login ITRI\UCL-0F    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from master.dbo.syslogins where loginname = N'ITRI\UCL-0F')
	exec sp_grantlogin N'ITRI\UCL-0F'
	exec sp_defaultdb N'ITRI\UCL-0F', N'uclplan'
	exec sp_defaultlanguage N'ITRI\UCL-0F', N'us_english'
GO

/****** Object:  Login ITRI\SrvAccount    Script Date: 2002/11/19 上午 10:37:48 ******/
exec sp_addsrvrolemember N'ITRI\SrvAccount', sysadmin
GO

/****** Object:  User dbo    Script Date: 2002/11/19 上午 10:37:48 ******/
/****** Object:  User mrlpub    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from dbo.sysusers where name = N'mrlpub' and uid < 16382)
	EXEC sp_grantdbaccess N'mrlpub', N'mrlpub'
GO

/****** Object:  User webuser    Script Date: 2002/11/19 上午 10:37:48 ******/
if not exists (select * from dbo.sysusers where name = N'webuser' and uid < 16382)
	EXEC sp_grantdbaccess N'webuser', N'webuser'
GO

GRANT  CREATE VIEW ,  CREATE PROCEDURE  TO [webuser]
GO

/****** Object:  User mrlpub    Script Date: 2002/11/19 上午 10:37:48 ******/
exec sp_addrolemember N'db_owner', N'mrlpub'
GO

/****** Object:  User webuser    Script Date: 2002/11/19 上午 10:37:48 ******/
exec sp_addrolemember N'db_owner', N'webuser'
GO

/****** Object:  Table [dbo].[Results]    Script Date: 2002/11/19 上午 10:38:43 ******/
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

/****** Object:  Table [dbo].[Table1]    Script Date: 2002/11/19 上午 10:38:45 ******/
CREATE TABLE [dbo].[Table1] (
	[syscode] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iano] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[remark] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[WebMember]    Script Date: 2002/11/19 上午 10:38:46 ******/
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

/****** Object:  Table [dbo].[WebMember_copy]    Script Date: 2002/11/19 上午 10:38:47 ******/
CREATE TABLE [dbo].[WebMember_copy] (
	[userid] [char] (15) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[password] [char] (9) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ssn] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[company] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[address] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[job_title] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[department] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[email] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[tel] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[fax_no] [char] (25) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_head] [char] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_addr] [char] (60) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_no] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[job_class] [char] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[register_date] [datetime] NULL ,
	[terminate_date] [datetime] NULL ,
	[start_date] [datetime] NULL ,
	[basic_fee] [int] NULL ,
	[pre_pay] [int] NULL ,
	[spend] [int] NULL ,
	[remark] [char] (128) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[news] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[invoice_date] [datetime] NULL ,
	[mem_from] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[ipcontrol] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[web_id] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[book]    Script Date: 2002/11/19 上午 10:38:47 ******/
CREATE TABLE [dbo].[book] (
	[bk_bkid] [int] IDENTITY (1, 1) NOT NULL ,
	[bk_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bk_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[bookp]    Script Date: 2002/11/19 上午 10:38:48 ******/
CREATE TABLE [dbo].[bookp] (
	[bkp_bkpid] [int] IDENTITY (1, 1) NOT NULL ,
	[bkp_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkp_date] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[bkp_pno] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[btp]    Script Date: 2002/11/19 上午 10:38:48 ******/
CREATE TABLE [dbo].[btp] (
	[btp_btpid] [int] IDENTITY (1, 1) NOT NULL ,
	[btp_btpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[btp_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_cust]    Script Date: 2002/11/19 上午 10:38:49 ******/
CREATE TABLE [dbo].[c1_cust] (
	[cust_custid] [int] IDENTITY (1, 1) NOT NULL ,
	[cust_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cust_nm] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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

/****** Object:  Table [dbo].[c1_lost]    Script Date: 2002/11/19 上午 10:38:50 ******/
CREATE TABLE [dbo].[c1_lost] (
	[lst_lstid] [int] IDENTITY (1, 1) NOT NULL ,
	[lst_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_rea] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_sdate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_edate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_obtp]    Script Date: 2002/11/19 上午 10:38:51 ******/
CREATE TABLE [dbo].[c1_obtp] (
	[obtp_obtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[obtp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpnm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_od]    Script Date: 2002/11/19 上午 10:38:51 ******/
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
	[od_amt] [real] NOT NULL ,
	[od_custtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_or]    Script Date: 2002/11/19 上午 10:38:52 ******/
CREATE TABLE [dbo].[c1_or] (
	[or_orid] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_order]    Script Date: 2002/11/19 上午 10:38:53 ******/
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
	[o_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_xmldata] [ntext] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_orescd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_cancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_indate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_iano] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_special] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_status] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_moduid] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_modstatus] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_ores]    Script Date: 2002/11/19 上午 10:38:53 ******/
CREATE TABLE [dbo].[c1_ores] (
	[ores_oresid] [int] IDENTITY (1, 1) NOT NULL ,
	[ores_orescd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ores_oresnm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_otp]    Script Date: 2002/11/19 上午 10:38:54 ******/
CREATE TABLE [dbo].[c1_otp] (
	[otp_otpid] [int] IDENTITY (1, 1) NOT NULL ,
	[otp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp1nm] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp2cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp2nm] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c1_ramt]    Script Date: 2002/11/19 上午 10:38:54 ******/
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

/****** Object:  Table [dbo].[c1_remail]    Script Date: 2002/11/19 上午 10:38:55 ******/
CREATE TABLE [dbo].[c1_remail] (
	[rm_rmid] [int] IDENTITY (1, 1) NOT NULL ,
	[rm_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_sdate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_edate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_clr]    Script Date: 2002/11/19 上午 10:38:56 ******/
CREATE TABLE [dbo].[c2_clr] (
	[clr_clrid] [int] IDENTITY (1, 1) NOT NULL ,
	[clr_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clr_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_cont]    Script Date: 2002/11/19 上午 10:38:56 ******/
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
	[cont_modempno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgcancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_credate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_adamt] [real] NOT NULL ,
	[cont_freebkcnt] [int] NOT NULL ,
	[cont_remark] [ntext] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgtemp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgpubed] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_restclrtm] [int] NOT NULL ,
	[cont_restmenotm] [int] NOT NULL ,
	[cont_restgetclrtm] [int] NOT NULL ,
	[cont_njtpcnt] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_cont_full]    Script Date: 2002/11/19 上午 10:38:58 ******/
CREATE TABLE [dbo].[c2_cont_full] (
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_aunm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_restjtm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_adamt] [real] NOT NULL ,
	[cont_restclrtm] [int] NOT NULL ,
	[cont_restmenotm] [int] NOT NULL ,
	[cont_restgetclrtm] [int] NOT NULL ,
	[pubmmstr] [char] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_contlist2]    Script Date: 2002/11/19 上午 10:38:58 ******/
CREATE TABLE [dbo].[c2_contlist2] (
	[syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ornamestr] [varchar] (300) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[orfullnamestr] [varchar] (350) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_getad]    Script Date: 2002/11/19 上午 10:38:59 ******/
CREATE TABLE [dbo].[c2_getad] (
	[syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pubmmstr] [varchar] (300) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_lost]    Script Date: 2002/11/19 上午 10:38:59 ******/
CREATE TABLE [dbo].[c2_lost] (
	[lst_lstid] [int] IDENTITY (1, 1) NOT NULL ,
	[lst_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_rea] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgprepnt] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[lst_fgpntlbl] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_lprior]    Script Date: 2002/11/19 上午 10:39:00 ******/
CREATE TABLE [dbo].[c2_lprior] (
	[lp_lpid] [int] IDENTITY (1, 1) NOT NULL ,
	[lp_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_priorseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_ltp]    Script Date: 2002/11/19 上午 10:39:01 ******/
CREATE TABLE [dbo].[c2_ltp] (
	[ltp_ltpid] [int] IDENTITY (1, 1) NOT NULL ,
	[ltp_ltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ltp_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_njtp]    Script Date: 2002/11/19 上午 10:39:01 ******/
CREATE TABLE [dbo].[c2_njtp] (
	[njtp_njtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[njtp_njtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[njtp_nm] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_or]    Script Date: 2002/11/19 上午 10:39:02 ******/
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

/****** Object:  Table [dbo].[c2_pgno]    Script Date: 2002/11/19 上午 10:39:03 ******/
CREATE TABLE [dbo].[c2_pgno] (
	[pg_pgid] [int] IDENTITY (1, 1) NOT NULL ,
	[pg_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pg_startpgno] [int] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_pgsize]    Script Date: 2002/11/19 上午 10:39:03 ******/
CREATE TABLE [dbo].[c2_pgsize] (
	[pgs_pgsid] [int] IDENTITY (1, 1) NOT NULL ,
	[pgs_pgscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs_nm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_pub]    Script Date: 2002/11/19 上午 10:39:04 ******/
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
	[pub_fgupdated] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fgact] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c2_pub_full]    Script Date: 2002/11/19 上午 10:39:05 ******/
CREATE TABLE [dbo].[c2_pub_full] (
	[pub_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pubseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ltp_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pgs_nm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[clr_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pub_fggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_origjno] [int] NOT NULL ,
	[pub_chgjno] [int] NOT NULL ,
	[pub_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_appf]    Script Date: 2002/11/19 上午 10:39:06 ******/
CREATE TABLE [dbo].[c3_appf] (
	[app_id] [int] IDENTITY (1, 1) NOT NULL ,
	[app_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_appno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_userid] [char] (15) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_custcat1] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_custcat2] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_appdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_fgreapp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_sumamt] [real] NOT NULL ,
	[app_btpcd] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_itpcd] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_rtpcd] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_indate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_moduid] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[app_status] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_custcat1]    Script Date: 2002/11/19 上午 10:39:07 ******/
CREATE TABLE [dbo].[c3_custcat1] (
	[cat1_id] [int] IDENTITY (1, 1) NOT NULL ,
	[cat1_cat1cd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cat1_cat1nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_custcat2]    Script Date: 2002/11/19 上午 10:39:07 ******/
CREATE TABLE [dbo].[c3_custcat2] (
	[cat2_id] [int] IDENTITY (1, 1) NOT NULL ,
	[cat2_cat1cd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cat2_cat2cd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cat2_cat2nm] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_freebk]    Script Date: 2002/11/19 上午 10:39:07 ******/
CREATE TABLE [dbo].[c3_freebk] (
	[fb_id] [int] IDENTITY (1, 1) NOT NULL ,
	[fb_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fb_appno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fb_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fb_fbseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fb_fccd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fb_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fb_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fb_mnt] [int] NOT NULL ,
	[fb_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_invmfr]    Script Date: 2002/11/19 上午 10:39:08 ******/
CREATE TABLE [dbo].[c3_invmfr] (
	[im_imid] [int] IDENTITY (1, 1) NOT NULL ,
	[im_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_appno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_imseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_inm] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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
	[im_fgitri] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_amt] [real] NOT NULL ,
	[im_fgia] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_modstatus] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_moduid] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_pytpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_lost]    Script Date: 2002/11/19 上午 10:39:09 ******/
CREATE TABLE [dbo].[c3_lost] (
	[lst_lstid] [int] IDENTITY (1, 1) NOT NULL ,
	[lst_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_appno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_cont] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_rea] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_sdate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_edate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_or]    Script Date: 2002/11/19 上午 10:39:10 ******/
CREATE TABLE [dbo].[c3_or] (
	[or_id] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_appno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_inm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_addr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_zip] [varchar] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_cell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_email] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c3_remail]    Script Date: 2002/11/19 上午 10:39:10 ******/
CREATE TABLE [dbo].[c3_remail] (
	[rm_rmid] [int] IDENTITY (1, 1) NOT NULL ,
	[rm_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_appno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_sdate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_edate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c4_adcnt]    Script Date: 2002/11/19 上午 10:39:11 ******/
CREATE TABLE [dbo].[c4_adcnt] (
	[cnt_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cnt_adcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cnt_h0] [int] NOT NULL ,
	[cnt_h1] [int] NOT NULL ,
	[cnt_h2] [int] NOT NULL ,
	[cnt_h3] [int] NOT NULL ,
	[cnt_h4] [int] NOT NULL ,
	[cnt_w1] [int] NOT NULL ,
	[cnt_w2] [int] NOT NULL ,
	[cnt_w3] [int] NOT NULL ,
	[cnt_w4] [int] NOT NULL ,
	[cnt_w5] [int] NOT NULL ,
	[cnt_w6] [int] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c4_adr]    Script Date: 2002/11/19 上午 10:39:11 ******/
CREATE TABLE [dbo].[c4_adr] (
	[adr_adrid] [int] IDENTITY (1, 1) NOT NULL ,
	[adr_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_imseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_invamt] [real] NOT NULL ,
	[adr_adcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_keyword] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_alttext] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_imgurl] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_navurl] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_urltp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_impr] [int] NOT NULL ,
	[adr_adamt] [real] NOT NULL ,
	[adr_desamt] [real] NOT NULL ,
	[adr_chgamt] [real] NOT NULL ,
	[adr_remark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgfixad] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fginvself] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgact] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c4_adrd]    Script Date: 2002/11/19 上午 10:39:12 ******/
CREATE TABLE [dbo].[c4_adrd] (
	[adrd_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adrd_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adrd_adrseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adrd_addate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adrd_fginved] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adrd_adramt] [real] NOT NULL ,
	[adrd_chgamt] [real] NOT NULL ,
	[adrd_desamt] [real] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c4_cont]    Script Date: 2002/11/19 上午 10:39:13 ******/
CREATE TABLE [dbo].[c4_cont] (
	[cont_contid] [int] IDENTITY (1, 1) NOT NULL ,
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_conttp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_signdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_pubcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aunm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_auemail] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_disc] [real] NOT NULL ,
	[cont_freetm] [int] NOT NULL ,
	[cont_totimgtm] [int] NOT NULL ,
	[cont_toturltm] [int] NOT NULL ,
	[cont_pubtm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_totamt] [real] NOT NULL ,
	[cont_paidamt] [real] NOT NULL ,
	[cont_restamt] [real] NOT NULL ,
	[cont_ccont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_csdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_atp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_matp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgclosed] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_adremark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_adsprem] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_pdcont] [varchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgpayonce] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgtemp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgpubed] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgcancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_modempno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_credate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c4_freebk]    Script Date: 2002/11/19 上午 10:39:14 ******/
CREATE TABLE [dbo].[c4_freebk] (
	[fbk_fbkid] [int] IDENTITY (1, 1) NOT NULL ,
	[fbk_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_fbkitem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c4_lost]    Script Date: 2002/11/19 上午 10:39:14 ******/
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

/****** Object:  Table [dbo].[c4_or]    Script Date: 2002/11/19 上午 10:39:15 ******/
CREATE TABLE [dbo].[c4_or] (
	[or_orid] [int] IDENTITY (1, 1) NOT NULL ,
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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

/****** Object:  Table [dbo].[c4_ramt]    Script Date: 2002/11/19 上午 10:39:15 ******/
CREATE TABLE [dbo].[c4_ramt] (
	[ma_raid] [int] IDENTITY (1, 1) NOT NULL ,
	[ma_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_fbkitem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_pubmnt] [int] NOT NULL ,
	[ma_unpubmnt] [int] NOT NULL ,
	[ma_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[c4_remail]    Script Date: 2002/11/19 上午 10:39:16 ******/
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

/****** Object:  Table [dbo].[cust]    Script Date: 2002/11/19 上午 10:39:16 ******/
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
	[cust_orgisyscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[freecat]    Script Date: 2002/11/19 上午 10:39:17 ******/
CREATE TABLE [dbo].[freecat] (
	[fc_id] [int] IDENTITY (1, 1) NOT NULL ,
	[fc_fccd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fc_nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[hicard]    Script Date: 2002/11/19 上午 10:39:18 ******/
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

/****** Object:  Table [dbo].[ia]    Script Date: 2002/11/19 上午 10:39:18 ******/
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
	[ia_rnm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_raddr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rzip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rjbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_rtel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_fgnonauto] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_status] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_cname] [varchar] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_tel] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_contno] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iabdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ia_iabseq] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[iab]    Script Date: 2002/11/19 上午 10:39:19 ******/
CREATE TABLE [dbo].[iab] (
	[iab_iabid] [int] IDENTITY (1, 1) NOT NULL ,
	[iab_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iab_iabdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iab_iabseq] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iab_createdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[iab_createmen] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[iad]    Script Date: 2002/11/19 上午 10:39:19 ******/
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

/****** Object:  Table [dbo].[ias]    Script Date: 2002/11/19 上午 10:39:20 ******/
CREATE TABLE [dbo].[ias] (
	[ias_iasid] [int] IDENTITY (1, 1) NOT NULL ,
	[ias_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_iasdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_iasseq] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_toitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_cancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_trans_sap] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_createdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_createmen] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ias_fgitri] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[inftmp20]    Script Date: 2002/11/19 上午 10:39:21 ******/
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

/****** Object:  Table [dbo].[inv10]    Script Date: 2002/11/19 上午 10:39:21 ******/
CREATE TABLE [dbo].[inv10] (
	[inv10_cusno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_contno] [char] (13) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_period] [char] (12) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_invno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_invoamt] [float] NOT NULL ,
	[inv10_docno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_postdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_umark] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_paydate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[inv10_payamt] [float] NOT NULL ,
	[inv10_retamt] [float] NOT NULL ,
	[inv10_aramt] [float] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[inv20]    Script Date: 2002/11/19 上午 10:39:22 ******/
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

/****** Object:  Table [dbo].[invmfr]    Script Date: 2002/11/19 上午 10:39:23 ******/
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

/****** Object:  Table [dbo].[itp]    Script Date: 2002/11/19 上午 10:39:23 ******/
CREATE TABLE [dbo].[itp] (
	[itp_itpid] [int] IDENTITY (1, 1) NOT NULL ,
	[itp_itpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[itp_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[itriorg]    Script Date: 2002/11/19 上午 10:39:24 ******/
CREATE TABLE [dbo].[itriorg] (
	[io_id] [int] NOT NULL ,
	[io_orgcd] [nvarchar] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[io_orgcname] [nvarchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[log_mb]    Script Date: 2002/11/19 上午 10:39:24 ******/
CREATE TABLE [dbo].[log_mb] (
	[lg_uid] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[lg_mnt] [int] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mailer]    Script Date: 2002/11/19 上午 10:39:25 ******/
CREATE TABLE [dbo].[mailer] (
	[ml_mlid] [int] IDENTITY (1, 1) NOT NULL ,
	[ml_mlcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ml_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mb]    Script Date: 2002/11/19 上午 10:39:25 ******/
CREATE TABLE [dbo].[mb] (
	[uid] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[mnt] [int] NOT NULL ,
	[ip_addr] [char] (15) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[pwd] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mfr]    Script Date: 2002/11/19 上午 10:39:26 ******/
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

/****** Object:  Table [dbo].[mltp]    Script Date: 2002/11/19 上午 10:39:26 ******/
CREATE TABLE [dbo].[mltp] (
	[mltp_mltpid] [int] IDENTITY (1, 1) NOT NULL ,
	[mltp_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mltp_mlcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mltp_mltpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[mtp]    Script Date: 2002/11/19 上午 10:39:27 ******/
CREATE TABLE [dbo].[mtp] (
	[mtp_mtpid] [int] IDENTITY (1, 1) NOT NULL ,
	[mtp_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mtp_nm] [char] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pbcatcol]    Script Date: 2002/11/19 上午 10:39:27 ******/
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

/****** Object:  Table [dbo].[pbcatedt]    Script Date: 2002/11/19 上午 10:39:28 ******/
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

/****** Object:  Table [dbo].[pbcatfmt]    Script Date: 2002/11/19 上午 10:39:28 ******/
CREATE TABLE [dbo].[pbcatfmt] (
	[pbf_name] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbf_frmt] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbf_type] [smallint] NOT NULL ,
	[pbf_cntr] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pbcattbl]    Script Date: 2002/11/19 上午 10:39:29 ******/
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

/****** Object:  Table [dbo].[pbcatvld]    Script Date: 2002/11/19 上午 10:39:30 ******/
CREATE TABLE [dbo].[pbcatvld] (
	[pbv_name] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbv_vald] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pbv_type] [smallint] NOT NULL ,
	[pbv_cntr] [int] NULL ,
	[pbv_msg] [varchar] (254) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[proj]    Script Date: 2002/11/19 上午 10:39:30 ******/
CREATE TABLE [dbo].[proj] (
	[proj_projid] [int] IDENTITY (1, 1) NOT NULL ,
	[proj_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[proj_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[proj_fgitri] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[proj_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[proj_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[proj_cont] [char] (12) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[py]    Script Date: 2002/11/19 上午 10:39:31 ******/
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
	[py_ccdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_fgprinted] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pysdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pysseq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[py_pysitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pyd]    Script Date: 2002/11/19 上午 10:39:32 ******/
CREATE TABLE [dbo].[pyd] (
	[pyd_pydid] [int] IDENTITY (1, 1) NOT NULL ,
	[pyd_pyno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_pyditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_iano] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pyd_cancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pyseq]    Script Date: 2002/11/19 上午 10:39:32 ******/
CREATE TABLE [dbo].[pyseq] (
	[pys_pysid] [int] IDENTITY (1, 1) NOT NULL ,
	[pys_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_pysdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_pysseq] [char] (4) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_toitem] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_pytpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_fgprinted] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_createdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pys_createmen] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[pytp]    Script Date: 2002/11/19 上午 10:39:33 ******/
CREATE TABLE [dbo].[pytp] (
	[pytp_pytpid] [int] IDENTITY (1, 1) NOT NULL ,
	[pytp_pytpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pytp_nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[refd]    Script Date: 2002/11/19 上午 10:39:33 ******/
CREATE TABLE [dbo].[refd] (
	[rd_rdid] [int] IDENTITY (1, 1) NOT NULL ,
	[rd_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_accdcr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rd_descr] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[refm]    Script Date: 2002/11/19 上午 10:39:34 ******/
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

/****** Object:  Table [dbo].[sapiv]    Script Date: 2002/11/19 上午 10:39:34 ******/
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

/****** Object:  Table [dbo].[sapivd]    Script Date: 2002/11/19 上午 10:39:35 ******/
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

/****** Object:  Table [dbo].[saplog]    Script Date: 2002/11/19 上午 10:39:35 ******/
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

/****** Object:  Table [dbo].[sapvou]    Script Date: 2002/11/19 上午 10:39:36 ******/
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

/****** Object:  Table [dbo].[srspn]    Script Date: 2002/11/19 上午 10:39:36 ******/
CREATE TABLE [dbo].[srspn] (
	[srspn_id] [int] IDENTITY (1, 1) NOT NULL ,
	[srspn_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_cname] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_tel] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_atype] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_orgcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_deptcd] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[srspn_pwd] [char] (14) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[syscd]    Script Date: 2002/11/19 上午 10:39:37 ******/
CREATE TABLE [dbo].[syscd] (
	[sys_sysid] [int] IDENTITY (1, 1) NOT NULL ,
	[sys_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[sys_nm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[sys_deptcd] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[test]    Script Date: 2002/11/19 上午 10:39:37 ******/
CREATE TABLE [dbo].[test] (
	[aa] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tmp_cust1]    Script Date: 2002/11/19 上午 10:39:38 ******/
CREATE TABLE [dbo].[tmp_cust1] (
	[od_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[begin_end] [char] (18) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp1nm] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[otp_otp2nm] [char] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpnm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_oditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[o_status] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tmp_income1]    Script Date: 2002/11/19 上午 10:39:38 ******/
CREATE TABLE [dbo].[tmp_income1] (
	[tmp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_otp2cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_btpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_param1] [int] NOT NULL ,
	[tmp_param2] [int] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tmp_label1]    Script Date: 2002/11/19 上午 10:39:39 ******/
CREATE TABLE [dbo].[tmp_label1] (
	[od_odid] [int] NOT NULL ,
	[od_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_oditem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_sdate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[od_edate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_mnt] [int] NOT NULL ,
	[ra_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mtp_nm] [char] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[obtp_obtpnm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ra_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tmp_label2]    Script Date: 2002/11/19 上午 10:39:39 ******/
CREATE TABLE [dbo].[tmp_label2] (
	[tmp_id] [int] IDENTITY (1, 1) NOT NULL ,
	[tmp_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_otp1seq] [char] (3) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tmp_list1]    Script Date: 2002/11/19 上午 10:39:40 ******/
CREATE TABLE [dbo].[tmp_list1] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[tmp_no] [char] (13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_pytpnm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_fgpreinv] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_obtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_obtpnm] [char] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_datestr] [char] (21) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_amt] [int] NOT NULL ,
	[tmp_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_inm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_addr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_tel] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_mnt] [int] NOT NULL ,
	[tmp_rmcont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_rmdate] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_cname] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_pyno] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_custtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tmp_statistics]    Script Date: 2002/11/19 上午 10:39:40 ******/
CREATE TABLE [dbo].[tmp_statistics] (
	[tmp_otp1cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_otp2cd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_btpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tmp_param1] [int] NOT NULL ,
	[tmp_param2] [int] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp1]    Script Date: 2002/11/19 上午 10:39:41 ******/
CREATE TABLE [dbo].[wk_c2_rp1] (
	[tid] [int] IDENTITY (1, 1) NOT NULL ,
	[mark] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_aunm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_restjtm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_adamt] [real] NOT NULL ,
	[cont_pubclrtm] [int] NOT NULL ,
	[cont_pubmenotm] [int] NOT NULL ,
	[cont_pubgetclrtm] [int] NOT NULL ,
	[pubmmstr] [char] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pubcnt] [int] NULL ,
	[prior_per_cont] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pub_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pub_pubseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[ltp_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pgs_nm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[clr_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pub_fggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pub_origjno] [int] NULL ,
	[pub_chgjno] [int] NULL ,
	[pub_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[lp_priorseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pub_totamt] [real] NULL ,
	[cont_fgcancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_1]    Script Date: 2002/11/19 上午 10:39:42 ******/
CREATE TABLE [dbo].[wk_c2_rp1_1] (
	[mark] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_aunm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_restjtm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_adamt] [real] NOT NULL ,
	[cont_pubclrtm] [int] NOT NULL ,
	[cont_pubmenotm] [int] NOT NULL ,
	[cont_pubgetclrtm] [int] NOT NULL ,
	[pubmmstr] [char] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_fgcancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_2]    Script Date: 2002/11/19 上午 10:39:42 ******/
CREATE TABLE [dbo].[wk_c2_rp1_2] (
	[pub_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_pubseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ltp_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pgs_nm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[clr_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_fggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_origjno] [int] NOT NULL ,
	[pub_chgjno] [int] NOT NULL ,
	[pub_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lp_priorseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_totamt] [real] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_3]    Script Date: 2002/11/19 上午 10:39:43 ******/
CREATE TABLE [dbo].[wk_c2_rp1_3] (
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pub_yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pubcnt] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_4]    Script Date: 2002/11/19 上午 10:39:43 ******/
CREATE TABLE [dbo].[wk_c2_rp1_4] (
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[prior_per_cont] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp1_5]    Script Date: 2002/11/19 上午 10:39:43 ******/
CREATE TABLE [dbo].[wk_c2_rp1_5] (
	[mark] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_aunm] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [char] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_restjtm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_adamt] [real] NOT NULL ,
	[cont_pubclrtm] [int] NOT NULL ,
	[cont_pubmenotm] [int] NOT NULL ,
	[cont_pubgetclrtm] [int] NOT NULL ,
	[pubmmstr] [char] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[pubcnt] [int] NULL ,
	[prior_per_cont] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[cont_fgcancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp2]    Script Date: 2002/11/19 上午 10:39:44 ******/
CREATE TABLE [dbo].[wk_c2_rp2] (
	[contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[pubseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[pgno] [int] NOT NULL ,
	[clr_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[ltp_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[pgs_nm] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[fggot] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[srspn_cname] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[fgrechg] [int] NOT NULL ,
	[unfgrechg] [int] NOT NULL ,
	[chgbk_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[chgjno] [int] NOT NULL ,
	[chgjbkno] [int] NOT NULL ,
	[origbk_nm] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[origjno] [int] NOT NULL ,
	[origjbkno] [int] NOT NULL ,
	[njtpcd01] [int] NOT NULL ,
	[njtpcd02] [int] NOT NULL ,
	[njtpcd03] [int] NOT NULL ,
	[njtpcd04] [int] NOT NULL ,
	[njtpcd05] [int] NOT NULL ,
	[fgupdated] [int] NOT NULL ,
	[clrcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[lp_priorseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[fgfixpg] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wk_c2_rp3]    Script Date: 2002/11/19 上午 10:39:45 ******/
CREATE TABLE [dbo].[wk_c2_rp3] (
	[contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[Unpubcnt] [int] NOT NULL ,
	[fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[mtpnm] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[bknm] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[conttpnm] [varchar] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[wkflag]    Script Date: 2002/11/19 上午 10:39:45 ******/
CREATE TABLE [dbo].[wkflag] (
	[wk_flgcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[wk_name] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Table1] WITH NOCHECK ADD 
	CONSTRAINT [PK_Table1] PRIMARY KEY  CLUSTERED 
	(
		[syscode],
		[iano]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[WebMember] WITH NOCHECK ADD 
	CONSTRAINT [PK_WebMember] PRIMARY KEY  CLUSTERED 
	(
		[userid],
		[web_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[book] WITH NOCHECK ADD 
	CONSTRAINT [PK_book] PRIMARY KEY  CLUSTERED 
	(
		[bk_bkcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[bookp] WITH NOCHECK ADD 
	CONSTRAINT [PK_bookp] PRIMARY KEY  CLUSTERED 
	(
		[bkp_bkcd],
		[bkp_date]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[btp] WITH NOCHECK ADD 
	CONSTRAINT [PK_BusinessType] PRIMARY KEY  CLUSTERED 
	(
		[btp_btpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_cust] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_cust] PRIMARY KEY  CLUSTERED 
	(
		[cust_custno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_lost] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_lost] PRIMARY KEY  CLUSTERED 
	(
		[lst_syscd],
		[lst_custno],
		[lst_otp1cd],
		[lst_otp1seq],
		[lst_oritem],
		[lst_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_obtp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_OrderBookType] PRIMARY KEY  CLUSTERED 
	(
		[obtp_otp1cd],
		[obtp_obtpcd]
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
		[or_syscd],
		[or_custno],
		[or_otp1cd],
		[or_otp1seq],
		[or_oritem]
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

ALTER TABLE [dbo].[c1_ores] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_ores] PRIMARY KEY  CLUSTERED 
	(
		[ores_orescd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_otp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_otp] PRIMARY KEY  CLUSTERED 
	(
		[otp_otp1cd],
		[otp_otp2cd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_ramt] WITH NOCHECK ADD 
	CONSTRAINT [PK_MailAmount] PRIMARY KEY  CLUSTERED 
	(
		[ra_syscd],
		[ra_custno],
		[ra_otp1cd],
		[ra_otp1seq],
		[ra_oditem],
		[ra_oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c1_remail] WITH NOCHECK ADD 
	CONSTRAINT [PK_c1_remail] PRIMARY KEY  CLUSTERED 
	(
		[rm_syscd],
		[rm_custno],
		[rm_otp1cd],
		[rm_otp1seq],
		[rm_oritem],
		[rm_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_clr] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_ADColor] PRIMARY KEY  CLUSTERED 
	(
		[clr_clrcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_cont] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_Contract] PRIMARY KEY  CLUSTERED 
	(
		[cont_syscd],
		[cont_contno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_contlist2] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_contlist2] PRIMARY KEY  CLUSTERED 
	(
		[syscd],
		[contno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_getad] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_getad] PRIMARY KEY  CLUSTERED 
	(
		[syscd],
		[contno]
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
		[lp_priorseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_ltp] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_LayoutType] PRIMARY KEY  CLUSTERED 
	(
		[ltp_ltpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_njtp] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_NewJourType] PRIMARY KEY  CLUSTERED 
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

ALTER TABLE [dbo].[c2_pgno] WITH NOCHECK ADD 
	CONSTRAINT [PK_c2_pgno] PRIMARY KEY  CLUSTERED 
	(
		[pg_bkcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c2_pgsize] WITH NOCHECK ADD 
	CONSTRAINT [PK_2_pgsize] PRIMARY KEY  CLUSTERED 
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

ALTER TABLE [dbo].[c3_appf] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_appf] PRIMARY KEY  CLUSTERED 
	(
		[app_syscd],
		[app_appno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c3_custcat1] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_custcat1] PRIMARY KEY  CLUSTERED 
	(
		[cat1_cat1cd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c3_custcat2] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_custcat2] PRIMARY KEY  CLUSTERED 
	(
		[cat2_cat1cd],
		[cat2_cat2cd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c3_freebk] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_freebk] PRIMARY KEY  CLUSTERED 
	(
		[fb_syscd],
		[fb_appno],
		[fb_oritem],
		[fb_fbseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c3_invmfr] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_invmfr] PRIMARY KEY  CLUSTERED 
	(
		[im_syscd],
		[im_appno],
		[im_imseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c3_lost] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_lost] PRIMARY KEY  CLUSTERED 
	(
		[lst_syscd],
		[lst_appno],
		[lst_oritem],
		[lst_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c3_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_or] PRIMARY KEY  CLUSTERED 
	(
		[or_syscd],
		[or_appno],
		[or_oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c3_remail] WITH NOCHECK ADD 
	CONSTRAINT [PK_c3_remail] PRIMARY KEY  CLUSTERED 
	(
		[rm_syscd],
		[rm_appno],
		[rm_oritem],
		[rm_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_adcnt] WITH NOCHECK ADD 
	CONSTRAINT [PK_c4_adcnt] PRIMARY KEY  CLUSTERED 
	(
		[cnt_date],
		[cnt_adcate]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_adr] WITH NOCHECK ADD 
	CONSTRAINT [PK_c4_adr] PRIMARY KEY  CLUSTERED 
	(
		[adr_syscd],
		[adr_contno],
		[adr_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_adrd] WITH NOCHECK ADD 
	CONSTRAINT [PK_c4_adinv] PRIMARY KEY  CLUSTERED 
	(
		[adrd_syscd],
		[adrd_contno],
		[adrd_adrseq],
		[adrd_addate]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_cont] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_cont_1] PRIMARY KEY  CLUSTERED 
	(
		[cont_syscd],
		[cont_contno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_freebk] WITH NOCHECK ADD 
	CONSTRAINT [PK_c4_freebk] PRIMARY KEY  CLUSTERED 
	(
		[fbk_syscd],
		[fbk_contno],
		[fbk_fbkitem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_lost] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_lost] PRIMARY KEY  CLUSTERED 
	(
		[lst_syscd],
		[lst_contno],
		[lst_fbkitem],
		[lst_oritem],
		[lst_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_or] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_or] PRIMARY KEY  CLUSTERED 
	(
		[or_syscd],
		[or_contno],
		[or_oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_ramt] WITH NOCHECK ADD 
	CONSTRAINT [PK_c4_ramt] PRIMARY KEY  CLUSTERED 
	(
		[ma_syscd],
		[ma_contno],
		[ma_fbkitem],
		[ma_oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[c4_remail] WITH NOCHECK ADD 
	CONSTRAINT [PK_4_remail] PRIMARY KEY  CLUSTERED 
	(
		[rm_syscd],
		[rm_contno],
		[rm_mseq],
		[rm_seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cust] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_Customer] PRIMARY KEY  CLUSTERED 
	(
		[cust_custno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[freecat] WITH NOCHECK ADD 
	CONSTRAINT [PK_freecat] PRIMARY KEY  CLUSTERED 
	(
		[fc_fccd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ia] WITH NOCHECK ADD 
	CONSTRAINT [PK_ia] PRIMARY KEY  CLUSTERED 
	(
		[ia_syscd],
		[ia_iano]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[iab] WITH NOCHECK ADD 
	CONSTRAINT [PK_iab] PRIMARY KEY  CLUSTERED 
	(
		[iab_syscd],
		[iab_iabdate],
		[iab_iabseq]
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

ALTER TABLE [dbo].[inftmp20] WITH NOCHECK ADD 
	CONSTRAINT [pkinftmp20] PRIMARY KEY  CLUSTERED 
	(
		[inf20_orgcd],
		[inf20_infno],
		[inf20_date],
		[inf20_vseq],
		[inf20_iseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[inv10] WITH NOCHECK ADD 
	CONSTRAINT [PK_inv10] PRIMARY KEY  CLUSTERED 
	(
		[inv10_cusno],
		[inv10_projno],
		[inv10_contno],
		[inv10_period],
		[inv10_invno]
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
	CONSTRAINT [PK_InvMfr] PRIMARY KEY  CLUSTERED 
	(
		[im_syscd],
		[im_contno],
		[im_imseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[itp] WITH NOCHECK ADD 
	CONSTRAINT [PK_IndCode] PRIMARY KEY  CLUSTERED 
	(
		[itp_itpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[log_mb] WITH NOCHECK ADD 
	CONSTRAINT [PK_log_mb] PRIMARY KEY  CLUSTERED 
	(
		[lg_uid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mailer] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_Mailer] PRIMARY KEY  CLUSTERED 
	(
		[ml_mlcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mb] WITH NOCHECK ADD 
	CONSTRAINT [PK_mb] PRIMARY KEY  CLUSTERED 
	(
		[uid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mfr] WITH NOCHECK ADD 
	CONSTRAINT [PK_Mfr] PRIMARY KEY  CLUSTERED 
	(
		[mfr_mfrno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mltp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_MLTp] PRIMARY KEY  CLUSTERED 
	(
		[mltp_syscd],
		[mltp_mlcd],
		[mltp_mltpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[mtp] WITH NOCHECK ADD 
	CONSTRAINT [PK_1_MailType] PRIMARY KEY  CLUSTERED 
	(
		[mtp_mtpcd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[proj] WITH NOCHECK ADD 
	CONSTRAINT [PK_proj] PRIMARY KEY  CLUSTERED 
	(
		[proj_syscd],
		[proj_bkcd],
		[proj_fgitri]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[py] WITH NOCHECK ADD 
	CONSTRAINT [PK_py] PRIMARY KEY  CLUSTERED 
	(
		[py_pyno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[pyd] WITH NOCHECK ADD 
	CONSTRAINT [PK_pyd] PRIMARY KEY  CLUSTERED 
	(
		[pyd_pyno],
		[pyd_pyditem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[pyseq] WITH NOCHECK ADD 
	CONSTRAINT [PK_pyseq] PRIMARY KEY  CLUSTERED 
	(
		[pys_pysdate],
		[pys_pysseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[pytp] WITH NOCHECK ADD 
	CONSTRAINT [PK_PaymentMethod] PRIMARY KEY  CLUSTERED 
	(
		[pytp_pytpcd]
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

ALTER TABLE [dbo].[saplog] WITH NOCHECK ADD 
	CONSTRAINT [pksaplog] PRIMARY KEY  CLUSTERED 
	(
		[sap_type],
		[sap_yyyymm],
		[sap_seq],
		[sap_orgcd]
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
		[srspn_empno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[syscd] WITH NOCHECK ADD 
	CONSTRAINT [PK_syscd] PRIMARY KEY  CLUSTERED 
	(
		[sys_syscd]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tmp_label2] WITH NOCHECK ADD 
	CONSTRAINT [PK_tmp_label2] PRIMARY KEY  CLUSTERED 
	(
		[tmp_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tmp_list1] WITH NOCHECK ADD 
	CONSTRAINT [PK_tmp_list1] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[wk_c2_rp1_1] WITH NOCHECK ADD 
	CONSTRAINT [PK_wk_c2_rp1_1] PRIMARY KEY  CLUSTERED 
	(
		[cont_syscd],
		[cont_contno]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[wk_c2_rp2] WITH NOCHECK ADD 
	CONSTRAINT [PK_wk_c2_rp2] PRIMARY KEY  CLUSTERED 
	(
		[contno],
		[yyyymm],
		[pubseq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[wk_c2_rp3] WITH NOCHECK ADD 
	CONSTRAINT [PK_wp_c2_rp3] PRIMARY KEY  CLUSTERED 
	(
		[contno],
		[oritem]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[wkflag] WITH NOCHECK ADD 
	CONSTRAINT [PK_tmpflag] PRIMARY KEY  CLUSTERED 
	(
		[wk_flgcd]
	)  ON [PRIMARY] 
GO

 CREATE  UNIQUE  CLUSTERED  INDEX [pbcatedt_idx] ON [dbo].[pbcatedt]([pbe_name], [pbe_seqn]) ON [PRIMARY]
GO

 CREATE  UNIQUE  CLUSTERED  INDEX [pbcatfmt_idx] ON [dbo].[pbcatfmt]([pbf_name]) ON [PRIMARY]
GO

 CREATE  UNIQUE  CLUSTERED  INDEX [pbcatvld_idx] ON [dbo].[pbcatvld]([pbv_name]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Results] WITH NOCHECK ADD 
	CONSTRAINT [DF_Results_o_syscd] DEFAULT ('C') FOR [o_syscd],
	CONSTRAINT [DF_Results_o_custno] DEFAULT ('') FOR [o_custno],
	CONSTRAINT [DF_Results_o_otp1seq] DEFAULT ('') FOR [o_otp1seq],
	CONSTRAINT [DF_Results_o_otp2cd] DEFAULT ('') FOR [o_otp2cd],
	CONSTRAINT [DF_Results_o_mfrno] DEFAULT ('') FOR [o_mfrno],
	CONSTRAINT [DF_Results_o_inm] DEFAULT ('') FOR [o_inm],
	CONSTRAINT [DF_Results_o_ijbti] DEFAULT ('') FOR [o_ijbti],
	CONSTRAINT [DF_Results_o_idddr] DEFAULT ('') FOR [o_idddr],
	CONSTRAINT [DF_Results_o_izip] DEFAULT ('') FOR [o_izip],
	CONSTRAINT [DF_Results_o_itel] DEFAULT ('') FOR [o_itel],
	CONSTRAINT [DF_Results_o_ifax] DEFAULT ('') FOR [o_ifax],
	CONSTRAINT [DF_Results_o_icell] DEFAULT ('') FOR [o_icell],
	CONSTRAINT [DF_Results_o_iemail] DEFAULT ('') FOR [o_iemail],
	CONSTRAINT [DF_Results_o_pytpcd] DEFAULT ('') FOR [o_pytpcd],
	CONSTRAINT [DF_Results_o_fgpreinv] DEFAULT ('') FOR [o_fgpreinv],
	CONSTRAINT [DF_Results_o_date] DEFAULT ('') FOR [o_date],
	CONSTRAINT [DF_Results_o_moddate] DEFAULT ('') FOR [o_moddate],
	CONSTRAINT [DF_Results_o_oldvdate] DEFAULT ('') FOR [o_oldvdate],
	CONSTRAINT [DF_Results_o_empno] DEFAULT ('') FOR [o_empno],
	CONSTRAINT [DF_Results_o_xmldata] DEFAULT ('') FOR [o_xmldata],
	CONSTRAINT [DF_Results_o_orescd] DEFAULT ('') FOR [o_orescd],
	CONSTRAINT [DF_Results_o_invcd] DEFAULT ('') FOR [o_invcd],
	CONSTRAINT [DF_Results_o_taxtp] DEFAULT ('') FOR [o_taxtp]
GO

ALTER TABLE [dbo].[Table1] WITH NOCHECK ADD 
	CONSTRAINT [DF_Table1_remark] DEFAULT ('') FOR [remark]
GO

ALTER TABLE [dbo].[book] WITH NOCHECK ADD 
	CONSTRAINT [DF_book_bk_bkcd_1] DEFAULT ('') FOR [bk_bkcd],
	CONSTRAINT [DF_book_bk_nm_1] DEFAULT ('') FOR [bk_nm]
GO

ALTER TABLE [dbo].[bookp] WITH NOCHECK ADD 
	CONSTRAINT [DF_bookp_bkp_bkcd] DEFAULT ('') FOR [bkp_bkcd],
	CONSTRAINT [DF_bookp_bkp_date] DEFAULT ('') FOR [bkp_date],
	CONSTRAINT [DF_bookp_bkp_pno] DEFAULT ('') FOR [bkp_pno]
GO

ALTER TABLE [dbo].[btp] WITH NOCHECK ADD 
	CONSTRAINT [DF_btp_btp_btpcd] DEFAULT ('') FOR [btp_btpcd],
	CONSTRAINT [DF_btp_btp_nm] DEFAULT ('') FOR [btp_nm]
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
	CONSTRAINT [DF_1_cust_cust_btpcd] DEFAULT ('') FOR [cust_btpcd],
	CONSTRAINT [DF_c1_cust_cust_oldcustno] DEFAULT ('') FOR [cust_oldcustno1],
	CONSTRAINT [DF_c1_cust_cust_bkcd] DEFAULT ('') FOR [cust_oldcustno2]
GO

ALTER TABLE [dbo].[c1_lost] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_lost_lst_syscd] DEFAULT ('C1') FOR [lst_syscd],
	CONSTRAINT [DF_c1_lost_lst_custno] DEFAULT ('') FOR [lst_custno],
	CONSTRAINT [DF_c1_lost_lst_otp1cd] DEFAULT ('') FOR [lst_otp1cd],
	CONSTRAINT [DF_c1_lost_lst_otp1seq] DEFAULT ('') FOR [lst_otp1seq],
	CONSTRAINT [DF_c1_lost_lst_oritem] DEFAULT ('') FOR [lst_oritem],
	CONSTRAINT [DF_c1_lost_lst_seq] DEFAULT ('') FOR [lst_seq],
	CONSTRAINT [DF_c1_lost_lst_cont] DEFAULT ('') FOR [lst_cont],
	CONSTRAINT [DF_c1_lost_lst_date] DEFAULT ('') FOR [lst_date],
	CONSTRAINT [DF_c1_lost_lst_rea] DEFAULT ('') FOR [lst_rea],
	CONSTRAINT [DF_c1_lost_lst_fgsent] DEFAULT ('0') FOR [lst_fgsent],
	CONSTRAINT [DF_c1_lost_lst_sdate] DEFAULT ('') FOR [lst_sdate],
	CONSTRAINT [DF_c1_lost_lst_edate] DEFAULT ('') FOR [lst_edate]
GO

ALTER TABLE [dbo].[c1_obtp] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_obtp_obtp_otp1cd] DEFAULT ('') FOR [obtp_otp1cd],
	CONSTRAINT [DF_c1_obtp_obtp_obtpcd] DEFAULT ('') FOR [obtp_obtpcd],
	CONSTRAINT [DF_c1_obtp_obtp_obtpnm] DEFAULT ('') FOR [obtp_obtpnm]
GO

ALTER TABLE [dbo].[c1_od] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_od_od_syscd] DEFAULT ('C1') FOR [od_syscd],
	CONSTRAINT [DF_c1_od_od_custno] DEFAULT ('') FOR [od_custno],
	CONSTRAINT [DF_c1_od_od_otp1cd] DEFAULT ('') FOR [od_otp1cd],
	CONSTRAINT [DF_c1_od_od_otp1seq] DEFAULT ('') FOR [od_otp1seq],
	CONSTRAINT [DF_c1_od_od_oditem] DEFAULT ('') FOR [od_oditem],
	CONSTRAINT [DF_c1_od_od_sdate] DEFAULT ('') FOR [od_sdate],
	CONSTRAINT [DF_c1_od_od_edate] DEFAULT ('') FOR [od_edate],
	CONSTRAINT [DF_c1_od_od_btpcd] DEFAULT ('') FOR [od_btpcd],
	CONSTRAINT [DF_c1_od_od_projno] DEFAULT ('') FOR [od_projno],
	CONSTRAINT [DF_c1_od_od_costctr] DEFAULT ('') FOR [od_costctr],
	CONSTRAINT [DF_1_od_od_remark] DEFAULT ('') FOR [od_remark],
	CONSTRAINT [DF_c1_od_od_amt] DEFAULT ('') FOR [od_amt],
	CONSTRAINT [DF_c1_od_od_custtp] DEFAULT ('') FOR [od_custtp]
GO

ALTER TABLE [dbo].[c1_or] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_or_or_syscd] DEFAULT ('C1') FOR [or_syscd],
	CONSTRAINT [DF_c1_or_or_custno] DEFAULT ('') FOR [or_custno],
	CONSTRAINT [DF_c1_or_or_otp1cd] DEFAULT ('') FOR [or_otp1cd],
	CONSTRAINT [DF_c1_or_or_otp1seq] DEFAULT ('') FOR [or_otp1seq],
	CONSTRAINT [DF_c1_or_or_oritem] DEFAULT ('') FOR [or_oritem],
	CONSTRAINT [DF_c1_or_or_inm] DEFAULT ('') FOR [or_inm],
	CONSTRAINT [DF_c1_or_or_nm] DEFAULT ('') FOR [or_nm],
	CONSTRAINT [DF_c1_or_or_jbti] DEFAULT ('') FOR [or_jbti],
	CONSTRAINT [DF_c1_or_or_addr] DEFAULT ('') FOR [or_addr],
	CONSTRAINT [DF_c1_or_or_zip] DEFAULT ('') FOR [or_zip],
	CONSTRAINT [DF_c1_or_or_tel] DEFAULT ('') FOR [or_tel],
	CONSTRAINT [DF_c1_or_or_fax] DEFAULT ('') FOR [or_fax],
	CONSTRAINT [DF_c1_or_or_cell] DEFAULT ('') FOR [or_cell],
	CONSTRAINT [DF_c1_or_or_email] DEFAULT ('') FOR [or_email],
	CONSTRAINT [DF_c1_or_or_fgmosea] DEFAULT ('0') FOR [or_fgmosea]
GO

ALTER TABLE [dbo].[c1_order] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_order_o_syscd] DEFAULT ('C1') FOR [o_syscd],
	CONSTRAINT [DF_c1_order_o_custno] DEFAULT ('') FOR [o_custno],
	CONSTRAINT [DF_c1_order_o_otp1cd] DEFAULT ('') FOR [o_otp1cd],
	CONSTRAINT [DF_c1_order_o_otp1seq] DEFAULT ('') FOR [o_otp1seq],
	CONSTRAINT [DF_c1_order_o_otp2cd] DEFAULT ('') FOR [o_otp2cd],
	CONSTRAINT [DF_c1_order_o_mfrno] DEFAULT ('') FOR [o_mfrno],
	CONSTRAINT [DF_c1_order_o_inm] DEFAULT ('') FOR [o_inm],
	CONSTRAINT [DF_c1_order_o_ijbti] DEFAULT ('') FOR [o_ijbti],
	CONSTRAINT [DF_c1_order_o_idddr] DEFAULT ('') FOR [o_iaddr],
	CONSTRAINT [DF_c1_order_o_izip] DEFAULT ('') FOR [o_izip],
	CONSTRAINT [DF_c1_order_o_itel] DEFAULT ('') FOR [o_itel],
	CONSTRAINT [DF_c1_order_o_ifax] DEFAULT ('') FOR [o_ifax],
	CONSTRAINT [DF_c1_order_o_icell] DEFAULT ('') FOR [o_icell],
	CONSTRAINT [DF_c1_order_o_iemail] DEFAULT ('') FOR [o_iemail],
	CONSTRAINT [DF_c1_order_o_pytpcd] DEFAULT ('') FOR [o_pytpcd],
	CONSTRAINT [DF_c1_order_o_fgpreinv] DEFAULT ('0') FOR [o_fgpreinv],
	CONSTRAINT [DF_c1_order_o_date] DEFAULT ('') FOR [o_date],
	CONSTRAINT [DF_c1_order_o_moddate] DEFAULT ('') FOR [o_moddate],
	CONSTRAINT [DF_c1_order_o_oldvdate] DEFAULT ('') FOR [o_oldvdate],
	CONSTRAINT [DF_c1_order_o_empno] DEFAULT ('') FOR [o_empno],
	CONSTRAINT [DF_c1_order_o_xmldata] DEFAULT ('') FOR [o_xmldata],
	CONSTRAINT [DF_c1_order_o_orescd] DEFAULT ('') FOR [o_orescd],
	CONSTRAINT [DF_c1_order_o_invcd] DEFAULT ('') FOR [o_invcd],
	CONSTRAINT [DF_c1_order_o_taxtp] DEFAULT ('') FOR [o_taxtp],
	CONSTRAINT [DF_c1_order_o_fgctm] DEFAULT ('0') FOR [o_cancel],
	CONSTRAINT [DF_c1_order_o_indate] DEFAULT ('') FOR [o_indate],
	CONSTRAINT [DF_c1_order_o_iano] DEFAULT ('') FOR [o_iano],
	CONSTRAINT [DF_c1_order_o_special] DEFAULT ('') FOR [o_special],
	CONSTRAINT [DF_c1_order_o_status] DEFAULT ('') FOR [o_status],
	CONSTRAINT [DF_c1_order_o_moduid] DEFAULT ('') FOR [o_moduid],
	CONSTRAINT [DF_c1_order_o_modstatus] DEFAULT ('') FOR [o_modstatus]
GO

ALTER TABLE [dbo].[c1_ores] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_ores_ores_orescd] DEFAULT ('') FOR [ores_orescd],
	CONSTRAINT [DF_c1_ores_ores_oresnm] DEFAULT ('') FOR [ores_oresnm]
GO

ALTER TABLE [dbo].[c1_otp] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_otp_otp_otp1cd] DEFAULT ('') FOR [otp_otp1cd],
	CONSTRAINT [DF_c1_otp_otp_otp1nm] DEFAULT ('') FOR [otp_otp1nm],
	CONSTRAINT [DF_c1_otp_otp_otp2cd] DEFAULT ('') FOR [otp_otp2cd],
	CONSTRAINT [DF_c1_otp_otp_otp2nm] DEFAULT ('') FOR [otp_otp2nm]
GO

ALTER TABLE [dbo].[c1_ramt] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_ramt_ra_syscd] DEFAULT ('C1') FOR [ra_syscd],
	CONSTRAINT [DF_c1_ramt_ra_custno] DEFAULT ('') FOR [ra_custno],
	CONSTRAINT [DF_c1_ramt_ra_otp1cd] DEFAULT ('') FOR [ra_otp1cd],
	CONSTRAINT [DF_c1_ramt_ra_otp1seq] DEFAULT ('') FOR [ra_otp1seq],
	CONSTRAINT [DF_c1_ramt_ra_oditem] DEFAULT ('') FOR [ra_oditem],
	CONSTRAINT [DF_c1_ramt_ra_oritem] DEFAULT ('') FOR [ra_oritem],
	CONSTRAINT [DF_c1_ramt_ra_mnt] DEFAULT ('') FOR [ra_mnt],
	CONSTRAINT [DF_c1_ramt_ra_mtpcd] DEFAULT ('') FOR [ra_mtpcd]
GO

ALTER TABLE [dbo].[c1_remail] WITH NOCHECK ADD 
	CONSTRAINT [DF_c1_remail_rm_syscd] DEFAULT ('C1') FOR [rm_syscd],
	CONSTRAINT [DF_c1_remail_rm_custno] DEFAULT ('') FOR [rm_custno],
	CONSTRAINT [DF_c1_remail_rm_otp1cd] DEFAULT ('') FOR [rm_otp1cd],
	CONSTRAINT [DF_c1_remail_rm_otp1seq] DEFAULT ('') FOR [rm_otp1seq],
	CONSTRAINT [DF_c1_remail_rm_oritem] DEFAULT ('') FOR [rm_oritem],
	CONSTRAINT [DF_c1_remail_rm_seq] DEFAULT ('') FOR [rm_seq],
	CONSTRAINT [DF_c1_remail_rm_cont] DEFAULT ('') FOR [rm_cont],
	CONSTRAINT [DF_c1_remail_rm_date] DEFAULT ('') FOR [rm_date],
	CONSTRAINT [DF_c1_remail_rm_fgsent] DEFAULT ('0') FOR [rm_fgsent],
	CONSTRAINT [DF_c1_remail_rm_sdate] DEFAULT ('') FOR [rm_sdate],
	CONSTRAINT [DF_c1_remail_rm_edate] DEFAULT ('') FOR [rm_edate]
GO

ALTER TABLE [dbo].[c2_clr] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_clr_clr_clrcd] DEFAULT ('') FOR [clr_clrcd],
	CONSTRAINT [DF_c2_clr_clr_nm] DEFAULT ('') FOR [clr_nm]
GO

ALTER TABLE [dbo].[c2_cont] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_cont_cont_syscd] DEFAULT ('C2') FOR [cont_syscd],
	CONSTRAINT [DF_c2_cont_cont_contno] DEFAULT ('') FOR [cont_contno],
	CONSTRAINT [DF_c2_cont_cont_conttp_1] DEFAULT ('') FOR [cont_conttp],
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
	CONSTRAINT [DF_c2_cont_cont_custno_1] DEFAULT ('') FOR [cont_custno],
	CONSTRAINT [DF_c2_cont_cont_totamt] DEFAULT ('') FOR [cont_totamt],
	CONSTRAINT [DF_c2_cont_cont_pubamt_1] DEFAULT ('') FOR [cont_pubamt],
	CONSTRAINT [DF_c2_cont_cont_chgamt_1] DEFAULT ('') FOR [cont_chgamt],
	CONSTRAINT [DF_c2_cont_cont_paidamt] DEFAULT ('') FOR [cont_paidamt],
	CONSTRAINT [DF_c2_cont_cont_restamt] DEFAULT ('') FOR [cont_restamt],
	CONSTRAINT [DF_c2_cont_cont_clrtm] DEFAULT ('') FOR [cont_clrtm],
	CONSTRAINT [DF_c2_cont_cont_menotm] DEFAULT ('') FOR [cont_menotm],
	CONSTRAINT [DF_c2_cont_cont_getclrtm] DEFAULT ('') FOR [cont_getclrtm],
	CONSTRAINT [DF_c2_cont_cont_oldcontno] DEFAULT ('') FOR [cont_oldcontno],
	CONSTRAINT [DF_c2_cont_cont_moddate] DEFAULT ('') FOR [cont_moddate],
	CONSTRAINT [DF_c2_cont_cont_fgpayonce] DEFAULT ('0') FOR [cont_fgpayonce],
	CONSTRAINT [DF_c2_cont_cont_modempno] DEFAULT ('') FOR [cont_modempno],
	CONSTRAINT [DF_c2_cont_cont_fgcancel] DEFAULT ('0') FOR [cont_fgcancel],
	CONSTRAINT [DF_c2_cont_cont_credate] DEFAULT ('') FOR [cont_credate],
	CONSTRAINT [DF_c2_cont_cont_adamt] DEFAULT ('') FOR [cont_adamt],
	CONSTRAINT [DF_c2_cont_cont_freebkcnt] DEFAULT ('') FOR [cont_freebkcnt],
	CONSTRAINT [DF_c2_cont_cont_remark] DEFAULT ('') FOR [cont_remark],
	CONSTRAINT [DF_c2_cont_cont_fgtemp] DEFAULT ('1') FOR [cont_fgtemp],
	CONSTRAINT [DF_c2_cont_cont_fgpubed] DEFAULT ('0') FOR [cont_fgpubed],
	CONSTRAINT [DF_c2_cont_cont_restclrtm] DEFAULT ('') FOR [cont_restclrtm],
	CONSTRAINT [DF_c2_cont_cont_restmenotm] DEFAULT ('') FOR [cont_restmenotm],
	CONSTRAINT [DF_c2_cont_cont_restgetclrtm] DEFAULT ('') FOR [cont_restgetclrtm],
	CONSTRAINT [DF_c2_cont_cont_njtpcnt] DEFAULT ('0') FOR [cont_njtpcnt]
GO

ALTER TABLE [dbo].[c2_contlist2] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_contlist2_syscd] DEFAULT ('') FOR [syscd],
	CONSTRAINT [DF_c2_contlist2_contno] DEFAULT ('') FOR [contno],
	CONSTRAINT [DF_c2_contlist2_ornamestr] DEFAULT ('') FOR [ornamestr],
	CONSTRAINT [DF_c2_contlist2_orfullnamestr] DEFAULT ('') FOR [orfullnamestr]
GO

ALTER TABLE [dbo].[c2_getad] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_getad_syscd] DEFAULT ('') FOR [syscd],
	CONSTRAINT [DF_c2_getad_contno] DEFAULT ('') FOR [contno],
	CONSTRAINT [DF_c2_getad_pubmmstr] DEFAULT ('') FOR [pubmmstr]
GO

ALTER TABLE [dbo].[c2_lost] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_lost_lst_syscd] DEFAULT ('C2') FOR [lst_syscd],
	CONSTRAINT [DF_c2_lost_lst_contno] DEFAULT ('') FOR [lst_contno],
	CONSTRAINT [DF_c2_lost_lst_oritem] DEFAULT ('') FOR [lst_oritem],
	CONSTRAINT [DF_c2_lost_lst_seq] DEFAULT ('') FOR [lst_seq],
	CONSTRAINT [DF_c2_lost_lst_cont] DEFAULT ('') FOR [lst_cont],
	CONSTRAINT [DF_c2_lost_lst_date] DEFAULT ('') FOR [lst_date],
	CONSTRAINT [DF_c2_lost_lst_rea] DEFAULT ('') FOR [lst_rea],
	CONSTRAINT [DF_c2_lost_lst_fgsent] DEFAULT ('0') FOR [lst_fgsent],
	CONSTRAINT [DF_c2_lost_lst_sdate] DEFAULT ('') FOR [lst_sdate],
	CONSTRAINT [DF_c2_lost_lst_edate] DEFAULT ('') FOR [lst_edate],
	CONSTRAINT [DF_c2_lost_lst_fgprepnt] DEFAULT ('') FOR [lst_fgprepnt],
	CONSTRAINT [DF_c2_lost_lst_fgpntlbl] DEFAULT ('0') FOR [lst_fgpntlbl]
GO

ALTER TABLE [dbo].[c2_lprior] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_lprior_lp_bkcd] DEFAULT ('') FOR [lp_bkcd],
	CONSTRAINT [DF_c2_lprior_lp_priorseq] DEFAULT ('') FOR [lp_priorseq],
	CONSTRAINT [DF_c2_lprior_lp_ltpcd] DEFAULT ('') FOR [lp_ltpcd],
	CONSTRAINT [DF_c2_lprior_lp_clrcd] DEFAULT ('') FOR [lp_clrcd],
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
	CONSTRAINT [DF_c2_or_or_syscd] DEFAULT ('C2') FOR [or_syscd],
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
	CONSTRAINT [DF_c2_or_or_pubmnt] DEFAULT ('') FOR [or_pubcnt],
	CONSTRAINT [DF_c2_or_or_unpubmnt] DEFAULT ('') FOR [or_unpubcnt],
	CONSTRAINT [DF_c2_or_or_fgmosea] DEFAULT ('0') FOR [or_fgmosea]
GO

ALTER TABLE [dbo].[c2_pgno] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_pgno_pg_bkcd] DEFAULT ('') FOR [pg_bkcd],
	CONSTRAINT [DF_c2_pgno_pg_startpgno] DEFAULT ('7') FOR [pg_startpgno]
GO

ALTER TABLE [dbo].[c2_pgsize] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_pgsize_pgs_pgscd] DEFAULT ('') FOR [pgs_pgscd],
	CONSTRAINT [DF_c2_pgsize_pgs_nm] DEFAULT ('') FOR [pgs_nm]
GO

ALTER TABLE [dbo].[c2_pub] WITH NOCHECK ADD 
	CONSTRAINT [DF_c2_pub_pub_syscd] DEFAULT ('C2') FOR [pub_syscd],
	CONSTRAINT [DF_c2_pub_pub_contno] DEFAULT ('') FOR [pub_contno],
	CONSTRAINT [DF_c2_pub_pub_date] DEFAULT ('') FOR [pub_yyyymm],
	CONSTRAINT [DF_c2_pub_pub_pubseq] DEFAULT ('') FOR [pub_pubseq],
	CONSTRAINT [DF_c2_pub_pub_pgno] DEFAULT ('') FOR [pub_pgno],
	CONSTRAINT [DF_c2_pub_pub_ltpcd] DEFAULT ('') FOR [pub_ltpcd],
	CONSTRAINT [DF_c2_pub_pub_clrcd] DEFAULT ('') FOR [pub_clrcd],
	CONSTRAINT [DF_c2_pub_pub_pgscd] DEFAULT ('') FOR [pub_pgscd],
	CONSTRAINT [DF_c2_pub_pub_adamt] DEFAULT ('') FOR [pub_adamt],
	CONSTRAINT [DF_c2_pub_pub_chgamt] DEFAULT ('') FOR [pub_chgamt],
	CONSTRAINT [DF_c2_pub_pub_drafttp] DEFAULT ('') FOR [pub_drafttp],
	CONSTRAINT [DF_c2_pub_pub_bkcd] DEFAULT ('') FOR [pub_origbkcd],
	CONSTRAINT [DF_c2_pub_pub_origjno] DEFAULT ('') FOR [pub_origjno],
	CONSTRAINT [DF_c2_pub_pub_origjbkno] DEFAULT ('') FOR [pub_origjbkno],
	CONSTRAINT [DF_c2_pub_pub_chgjbkcd] DEFAULT ('') FOR [pub_chgbkcd],
	CONSTRAINT [DF_c2_pub_pub_chgjno] DEFAULT ('') FOR [pub_chgjno],
	CONSTRAINT [DF_c2_pub_pub_chgjbkno] DEFAULT ('') FOR [pub_chgjbkno],
	CONSTRAINT [DF_c2_pub_pub_fgrechg] DEFAULT ('') FOR [pub_fgrechg],
	CONSTRAINT [DF_c2_pub_pub_fggot] DEFAULT (' ') FOR [pub_fggot],
	CONSTRAINT [DF_c2_pub_pub_njtpcd] DEFAULT ('') FOR [pub_njtpcd],
	CONSTRAINT [DF_c2_pub_pub_projno] DEFAULT ('') FOR [pub_projno],
	CONSTRAINT [DF_c2_pub_pub_costctr] DEFAULT ('') FOR [pub_costctr],
	CONSTRAINT [DF_c2_pub_pub_fginved] DEFAULT (' ') FOR [pub_fginved],
	CONSTRAINT [DF_c2_pub_pub_fginvself] DEFAULT ('0') FOR [pub_fginvself],
	CONSTRAINT [DF_c2_pub_pub_pno] DEFAULT ('') FOR [pub_pno],
	CONSTRAINT [DF_c2_pub_pub_remark] DEFAULT ('') FOR [pub_remark],
	CONSTRAINT [DF_c2_pub_pub_fgfixpg] DEFAULT ('0') FOR [pub_fgfixpg],
	CONSTRAINT [DF_c2_pub_pub_moddate] DEFAULT ('') FOR [pub_moddate],
	CONSTRAINT [DF_c2_pub_pub_modman] DEFAULT ('') FOR [pub_modempno],
	CONSTRAINT [DF_c2_pub_pub_bkcd_1] DEFAULT ('01') FOR [pub_bkcd],
	CONSTRAINT [DF_c2_pub_pub_imseq] DEFAULT ('') FOR [pub_imseq],
	CONSTRAINT [DF_c2_pub_pub_fgupdated] DEFAULT ('0') FOR [pub_fgupdated],
	CONSTRAINT [DF_c2_pub_pub_fgact] DEFAULT ('0') FOR [pub_fgact]
GO

ALTER TABLE [dbo].[c3_appf] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_appf_app_syscd] DEFAULT ('') FOR [app_syscd],
	CONSTRAINT [DF_c3_appf_app_appno] DEFAULT ('') FOR [app_appno],
	CONSTRAINT [DF_c3_appf_app_userid] DEFAULT ('') FOR [app_userid],
	CONSTRAINT [DF_c3_appf_app_custcat1] DEFAULT ('') FOR [app_custcat1],
	CONSTRAINT [DF_c3_appf_app_custcat2] DEFAULT ('') FOR [app_custcat2],
	CONSTRAINT [DF_c3_appf_app_sdate] DEFAULT ('') FOR [app_sdate],
	CONSTRAINT [DF_c3_appf_app_edate] DEFAULT ('') FOR [app_edate],
	CONSTRAINT [DF_c3_appf_app_fgnew] DEFAULT ('') FOR [app_fgreapp],
	CONSTRAINT [DF_c3_appf_app_amt] DEFAULT (0) FOR [app_sumamt],
	CONSTRAINT [DF_c3_appf_app_btpcd] DEFAULT ('') FOR [app_btpcd],
	CONSTRAINT [DF_c3_appf_app_itpcd] DEFAULT ('') FOR [app_itpcd],
	CONSTRAINT [DF_c3_appf_app_rtpcd] DEFAULT ('') FOR [app_rtpcd],
	CONSTRAINT [DF_c3_appf_app_projno] DEFAULT ('') FOR [app_projno],
	CONSTRAINT [DF_c3_appf_app_costctr] DEFAULT ('') FOR [app_costctr],
	CONSTRAINT [DF_c3_appf_app_indate] DEFAULT ('') FOR [app_indate],
	CONSTRAINT [DF_c3_appf_app_empno] DEFAULT ('') FOR [app_empno],
	CONSTRAINT [DF_c3_appf_app_moddate] DEFAULT ('') FOR [app_moddate],
	CONSTRAINT [DF_c3_appf_app_moduid] DEFAULT ('') FOR [app_moduid],
	CONSTRAINT [DF_c3_appf_app_status] DEFAULT ('') FOR [app_status]
GO

ALTER TABLE [dbo].[c3_custcat1] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_custcat1_cat1_cat1cd] DEFAULT ('') FOR [cat1_cat1cd],
	CONSTRAINT [DF_c3_custcat1_cat1_cat1nm] DEFAULT ('') FOR [cat1_cat1nm]
GO

ALTER TABLE [dbo].[c3_custcat2] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_custcat2_cat2_cat1cd] DEFAULT ('') FOR [cat2_cat1cd],
	CONSTRAINT [DF_c3_custcat2_cat2_cat2cd] DEFAULT ('') FOR [cat2_cat2cd],
	CONSTRAINT [DF_c3_custcat2_cat2_cat2nm] DEFAULT ('') FOR [cat2_cat2nm]
GO

ALTER TABLE [dbo].[c3_freebk] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_freebk_fb_syscd] DEFAULT ('C1') FOR [fb_syscd],
	CONSTRAINT [DF_c3_freebk_fb_appno] DEFAULT ('') FOR [fb_appno],
	CONSTRAINT [DF_c3_freebk_fb_oritem] DEFAULT ('') FOR [fb_oritem],
	CONSTRAINT [DF_c3_freebk_fb_fbseq] DEFAULT ('') FOR [fb_fbseq],
	CONSTRAINT [DF_c3_freebk_fb_obtpcd] DEFAULT ('') FOR [fb_fccd],
	CONSTRAINT [DF_c3_freebk_fb_sdate] DEFAULT ('') FOR [fb_sdate],
	CONSTRAINT [DF_c3_freebk_fb_edate] DEFAULT ('') FOR [fb_edate],
	CONSTRAINT [DF_c3_freebk_fb_mnt] DEFAULT (0) FOR [fb_mnt],
	CONSTRAINT [DF_c3_freebk_fb_mtpcd] DEFAULT ('') FOR [fb_mtpcd]
GO

ALTER TABLE [dbo].[c3_invmfr] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_invmfr_im_syscd] DEFAULT ('') FOR [im_syscd],
	CONSTRAINT [DF_c3_invmfr_im_appno] DEFAULT ('') FOR [im_appno],
	CONSTRAINT [DF_c3_invmfr_im_imseq] DEFAULT ('') FOR [im_imseq],
	CONSTRAINT [DF_c3_invmfr_im_mfrno] DEFAULT ('') FOR [im_mfrno],
	CONSTRAINT [DF_c3_invmfr_im_inm] DEFAULT ('') FOR [im_inm],
	CONSTRAINT [DF_c3_invmfr_im_nm] DEFAULT ('') FOR [im_nm],
	CONSTRAINT [DF_c3_invmfr_im_jbti] DEFAULT ('') FOR [im_jbti],
	CONSTRAINT [DF_c3_invmfr_im_zip] DEFAULT ('') FOR [im_zip],
	CONSTRAINT [DF_c3_invmfr_im_addr] DEFAULT ('') FOR [im_addr],
	CONSTRAINT [DF_c3_invmfr_im_tel] DEFAULT ('') FOR [im_tel],
	CONSTRAINT [DF_c3_invmfr_im_fax] DEFAULT ('') FOR [im_fax],
	CONSTRAINT [DF_c3_invmfr_im_cell] DEFAULT ('') FOR [im_cell],
	CONSTRAINT [DF_c3_invmfr_im_email] DEFAULT ('') FOR [im_email],
	CONSTRAINT [DF_c3_invmfr_im_invcd] DEFAULT ('') FOR [im_invcd],
	CONSTRAINT [DF_c3_invmfr_im_taxtp] DEFAULT ('') FOR [im_taxtp],
	CONSTRAINT [DF_c3_invmfr_im_fgitri] DEFAULT ('') FOR [im_fgitri],
	CONSTRAINT [DF_c3_invmfr_im_amt] DEFAULT (0) FOR [im_amt],
	CONSTRAINT [DF_c3_invmfr_im_fgia] DEFAULT ('') FOR [im_fgia],
	CONSTRAINT [DF_c3_invmfr_im_modstatus] DEFAULT ('') FOR [im_modstatus],
	CONSTRAINT [DF_c3_invmfr_im_moduid] DEFAULT ('') FOR [im_moduid],
	CONSTRAINT [DF_c3_invmfr_im_pytpcd] DEFAULT ('') FOR [im_pytpcd]
GO

ALTER TABLE [dbo].[c3_lost] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_lost_lst_syscd] DEFAULT ('C1') FOR [lst_syscd],
	CONSTRAINT [DF_c3_lost_lst_appno] DEFAULT ('') FOR [lst_appno],
	CONSTRAINT [DF_c3_lost_lst_oritem] DEFAULT ('') FOR [lst_oritem],
	CONSTRAINT [DF_c3_lost_lst_seq] DEFAULT ('') FOR [lst_seq],
	CONSTRAINT [DF_c3_lost_lst_cont] DEFAULT ('') FOR [lst_cont],
	CONSTRAINT [DF_c3_lost_lst_date] DEFAULT ('') FOR [lst_date],
	CONSTRAINT [DF_c3_lost_lst_rea] DEFAULT ('') FOR [lst_rea],
	CONSTRAINT [DF_c3_lost_lst_fgsent] DEFAULT ('') FOR [lst_fgsent],
	CONSTRAINT [DF_c3_lost_lst_sdate] DEFAULT ('') FOR [lst_sdate],
	CONSTRAINT [DF_c3_lost_lst_edate] DEFAULT ('') FOR [lst_edate]
GO

ALTER TABLE [dbo].[c3_or] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_or_or_syscd] DEFAULT ('') FOR [or_syscd],
	CONSTRAINT [DF_c3_or_or_appno] DEFAULT ('') FOR [or_appno],
	CONSTRAINT [DF_c3_or_or_otitem] DEFAULT ('') FOR [or_oritem],
	CONSTRAINT [DF_c3_or_or_inm] DEFAULT ('') FOR [or_inm],
	CONSTRAINT [DF_c3_or_or_nm] DEFAULT ('') FOR [or_nm],
	CONSTRAINT [DF_c3_or_or_jbti] DEFAULT ('') FOR [or_jbti],
	CONSTRAINT [DF_c3_or_or_addr] DEFAULT ('') FOR [or_addr],
	CONSTRAINT [DF_c3_or_or_zip] DEFAULT ('') FOR [or_zip],
	CONSTRAINT [DF_c3_or_or_tel] DEFAULT ('') FOR [or_tel],
	CONSTRAINT [DF_c3_or_or_fax] DEFAULT ('') FOR [or_fax],
	CONSTRAINT [DF_c3_or_or_cell] DEFAULT ('') FOR [or_cell],
	CONSTRAINT [DF_c3_or_or_email] DEFAULT ('') FOR [or_email],
	CONSTRAINT [DF_c3_or_or_fgmosea] DEFAULT ('') FOR [or_fgmosea]
GO

ALTER TABLE [dbo].[c3_remail] WITH NOCHECK ADD 
	CONSTRAINT [DF_c3_remail_rm_syscd] DEFAULT ('C1') FOR [rm_syscd],
	CONSTRAINT [DF_c3_remail_rm_appno] DEFAULT ('') FOR [rm_appno],
	CONSTRAINT [DF_c3_remail_rm_oritem] DEFAULT ('') FOR [rm_oritem],
	CONSTRAINT [DF_c3_remail_rm_seq] DEFAULT ('') FOR [rm_seq],
	CONSTRAINT [DF_c3_remail_rm_cont] DEFAULT ('') FOR [rm_cont],
	CONSTRAINT [DF_c3_remail_rm_date] DEFAULT ('') FOR [rm_date],
	CONSTRAINT [DF_c3_remail_rm_fgsent] DEFAULT ('') FOR [rm_fgsent],
	CONSTRAINT [DF_c3_remail_rm_sdate] DEFAULT ('') FOR [rm_sdate],
	CONSTRAINT [DF_c3_remail_rm_edate] DEFAULT ('') FOR [rm_edate]
GO

ALTER TABLE [dbo].[c4_adcnt] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_adcnt_cnt_date] DEFAULT ('') FOR [cnt_date],
	CONSTRAINT [DF_c4_adcnt_cnt_keyword_1] DEFAULT ('') FOR [cnt_adcate],
	CONSTRAINT [DF_c4_adcnt_cnt_keyword] DEFAULT (0) FOR [cnt_h0],
	CONSTRAINT [DF_c4_adcnt_cnt_count] DEFAULT (0) FOR [cnt_h1],
	CONSTRAINT [DF_c4_adcnt_cnt_h3] DEFAULT (0) FOR [cnt_h2],
	CONSTRAINT [DF_c4_adcnt_cnt_h4] DEFAULT (0) FOR [cnt_h3],
	CONSTRAINT [DF_c4_adcnt_cnt_h5] DEFAULT (0) FOR [cnt_h4],
	CONSTRAINT [DF_c4_adcnt_cnt_h6] DEFAULT (0) FOR [cnt_w1],
	CONSTRAINT [DF_c4_adcnt_cnt_h7] DEFAULT (0) FOR [cnt_w2],
	CONSTRAINT [DF_c4_adcnt_cnt_h8] DEFAULT (0) FOR [cnt_w3],
	CONSTRAINT [DF_c4_adcnt_cnt_h9] DEFAULT (0) FOR [cnt_w4],
	CONSTRAINT [DF_c4_adcnt_cnt_h10] DEFAULT (0) FOR [cnt_w5],
	CONSTRAINT [DF_c4_adcnt_cnt_h11] DEFAULT (0) FOR [cnt_w6]
GO

ALTER TABLE [dbo].[c4_adr] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_adr_adr_syscd] DEFAULT ('C4') FOR [adr_syscd],
	CONSTRAINT [DF_c4_adr_adr_contno] DEFAULT ('') FOR [adr_contno],
	CONSTRAINT [DF_c4_adr_adr_seq] DEFAULT ('') FOR [adr_seq],
	CONSTRAINT [DF_c4_adr_adr_imseq] DEFAULT ('') FOR [adr_imseq],
	CONSTRAINT [DF_c4_adr_adr_date] DEFAULT ('') FOR [adr_sdate],
	CONSTRAINT [DF_c4_adr_adr_edate] DEFAULT ('') FOR [adr_edate],
	CONSTRAINT [DF_c4_adr_adr_invamt] DEFAULT ('') FOR [adr_invamt],
	CONSTRAINT [DF_c4_adr_adr_adcate] DEFAULT ('') FOR [adr_adcate],
	CONSTRAINT [DF_c4_adr_adr_keyword] DEFAULT ('') FOR [adr_keyword],
	CONSTRAINT [DF_c4_adr_adr_alttext] DEFAULT ('') FOR [adr_alttext],
	CONSTRAINT [DF_c4_adr_adr_imgurl] DEFAULT ('') FOR [adr_imgurl],
	CONSTRAINT [DF_c4_adr_adr_drafttp] DEFAULT ('') FOR [adr_drafttp],
	CONSTRAINT [DF_c4_adr_adr_navurl] DEFAULT ('') FOR [adr_navurl],
	CONSTRAINT [DF_c4_adr_adr_urlcate] DEFAULT ('') FOR [adr_urltp],
	CONSTRAINT [DF_c4_adr_adr_impr] DEFAULT ('') FOR [adr_impr],
	CONSTRAINT [DF_c4_adr_adr_adamt] DEFAULT ('') FOR [adr_adamt],
	CONSTRAINT [DF_c4_adr_adr_desamt] DEFAULT ('') FOR [adr_desamt],
	CONSTRAINT [DF_c4_adr_adr_chgamt] DEFAULT ('') FOR [adr_chgamt],
	CONSTRAINT [DF_c4_adr_adr_remark] DEFAULT ('') FOR [adr_remark],
	CONSTRAINT [DF_c4_adr_adr_projno] DEFAULT ('') FOR [adr_projno],
	CONSTRAINT [DF_c4_adr_adr_costctr] DEFAULT ('') FOR [adr_costctr],
	CONSTRAINT [DF_c4_adr_adr_fgfixad] DEFAULT ('0') FOR [adr_fgfixad],
	CONSTRAINT [DF_c4_adr_adr_fggot] DEFAULT ('0') FOR [adr_fggot],
	CONSTRAINT [DF_c4_adr_adr_fginvself] DEFAULT ('') FOR [adr_fginvself],
	CONSTRAINT [DF_c4_adr_adr_fgact] DEFAULT ('0') FOR [adr_fgact]
GO

ALTER TABLE [dbo].[c4_adrd] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_adinv_adinv_syscd] DEFAULT ('') FOR [adrd_syscd],
	CONSTRAINT [DF_c4_adinv_adinv_contno] DEFAULT ('') FOR [adrd_contno],
	CONSTRAINT [DF_c4_adinv_adinv_imseq] DEFAULT ('') FOR [adrd_adrseq],
	CONSTRAINT [DF_c4_adinv_adinv_addate] DEFAULT ('') FOR [adrd_addate],
	CONSTRAINT [DF_c4_adinv_adinv_inved] DEFAULT ('') FOR [adrd_fginved],
	CONSTRAINT [DF_c4_adrd_adrd_adramt] DEFAULT (0) FOR [adrd_adramt],
	CONSTRAINT [DF_c4_adrd_adrd_chgamt] DEFAULT (0) FOR [adrd_chgamt],
	CONSTRAINT [DF_c4_adrd_adrd_desamt] DEFAULT (0) FOR [adrd_desamt]
GO

ALTER TABLE [dbo].[c4_cont] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_cont_cont_syscd] DEFAULT ('C4') FOR [cont_syscd],
	CONSTRAINT [DF_c4_cont_cont_contno] DEFAULT ('') FOR [cont_contno],
	CONSTRAINT [DF_c4_cont_cont_custno] DEFAULT ('') FOR [cont_custno],
	CONSTRAINT [DF_c4_cont_cont_conttp] DEFAULT ('') FOR [cont_conttp],
	CONSTRAINT [DF_c4_cont_cont_signdate] DEFAULT ('') FOR [cont_signdate],
	CONSTRAINT [DF_c4_cont_cont_sdate] DEFAULT ('') FOR [cont_sdate],
	CONSTRAINT [DF_c4_cont_cont_edate] DEFAULT ('') FOR [cont_edate],
	CONSTRAINT [DF_c4_cont_cont_empno] DEFAULT ('') FOR [cont_empno],
	CONSTRAINT [DF_c4_cont_cont_mfrno] DEFAULT ('') FOR [cont_mfrno],
	CONSTRAINT [DF_c4_cont_cont_pubcate] DEFAULT ('') FOR [cont_pubcate],
	CONSTRAINT [DF_c4_cont_cont_aunm] DEFAULT ('') FOR [cont_aunm],
	CONSTRAINT [DF_c4_cont_cont_autel] DEFAULT ('') FOR [cont_autel],
	CONSTRAINT [DF_c4_cont_cont_aufax] DEFAULT ('') FOR [cont_aufax],
	CONSTRAINT [DF_c4_cont_cont_aucell] DEFAULT ('') FOR [cont_aucell],
	CONSTRAINT [DF_c4_cont_cont_auemail] DEFAULT ('') FOR [cont_auemail],
	CONSTRAINT [DF_c4_cont_cont_disc] DEFAULT ('') FOR [cont_disc],
	CONSTRAINT [DF_c4_cont_cont_freetm] DEFAULT (0) FOR [cont_freetm],
	CONSTRAINT [DF_c4_cont_cont_tottm] DEFAULT (0) FOR [cont_totimgtm],
	CONSTRAINT [DF_c4_cont_cont_toturltm] DEFAULT (0) FOR [cont_toturltm],
	CONSTRAINT [DF_c4_cont_cont_pubtm] DEFAULT (0) FOR [cont_pubtm],
	CONSTRAINT [DF_c4_cont_cont_resttm] DEFAULT (0) FOR [cont_resttm],
	CONSTRAINT [DF_c4_cont_cont_totamt] DEFAULT (0) FOR [cont_totamt],
	CONSTRAINT [DF_c4_cont_cont_paidamt] DEFAULT (0) FOR [cont_paidamt],
	CONSTRAINT [DF_c4_cont_cont_restamt] DEFAULT (0) FOR [cont_restamt],
	CONSTRAINT [DF_c4_cont_cont_ccont] DEFAULT ('') FOR [cont_ccont],
	CONSTRAINT [DF_c4_cont_cont_csdate] DEFAULT ('') FOR [cont_csdate],
	CONSTRAINT [DF_c4_cont_cont_atp] DEFAULT ('') FOR [cont_atp],
	CONSTRAINT [DF_c4_cont_cont_matp] DEFAULT ('') FOR [cont_matp],
	CONSTRAINT [DF_c4_cont_cont_fgclosed] DEFAULT ('0') FOR [cont_fgclosed],
	CONSTRAINT [DF_c4_cont_cont_adremark] DEFAULT ('') FOR [cont_adremark],
	CONSTRAINT [DF_c4_cont_cont_adsprem] DEFAULT ('') FOR [cont_adsprem],
	CONSTRAINT [DF_c4_cont_cont_pdcont] DEFAULT ('') FOR [cont_pdcont],
	CONSTRAINT [DF_c4_cont_cont_moddate] DEFAULT ('') FOR [cont_moddate],
	CONSTRAINT [DF_c4_cont_cont_fgpayonce] DEFAULT ('0') FOR [cont_fgpayonce],
	CONSTRAINT [DF_c4_cont_cont_fgtemp] DEFAULT ('1') FOR [cont_fgtemp],
	CONSTRAINT [DF_c4_cont_cont_fgpubed] DEFAULT ('0') FOR [cont_fgpubed],
	CONSTRAINT [DF_c4_cont_cont_fgcancel] DEFAULT ('0') FOR [cont_fgcancel],
	CONSTRAINT [DF_c4_cont_cont_modempno] DEFAULT ('') FOR [cont_modempno],
	CONSTRAINT [DF_c4_cont_cont_credate] DEFAULT ('') FOR [cont_credate]
GO

ALTER TABLE [dbo].[c4_freebk] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_freebk_fbk_syscd] DEFAULT ('C4') FOR [fbk_syscd],
	CONSTRAINT [DF_c4_freebk_fbk_contno] DEFAULT ('') FOR [fbk_contno],
	CONSTRAINT [DF_c4_freebk_fbk_fbkitem] DEFAULT ('') FOR [fbk_fbkitem],
	CONSTRAINT [DF_c4_freebk_fbk_sdate] DEFAULT ('') FOR [fbk_sdate],
	CONSTRAINT [DF_c4_freebk_fbk_edate] DEFAULT ('') FOR [fbk_edate],
	CONSTRAINT [DF_c4_freebk_fbk_bkcd] DEFAULT ('') FOR [fbk_bkcd]
GO

ALTER TABLE [dbo].[c4_lost] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_lost_lst_syscd] DEFAULT ('C4') FOR [lst_syscd],
	CONSTRAINT [DF_c4_lost_lst_contno] DEFAULT ('') FOR [lst_contno],
	CONSTRAINT [DF_c4_lost_lst_fbkitem] DEFAULT ('') FOR [lst_fbkitem],
	CONSTRAINT [DF_c4_lost_lst_oritem] DEFAULT ('') FOR [lst_oritem],
	CONSTRAINT [DF_c4_lost_lst_seq] DEFAULT ('') FOR [lst_seq],
	CONSTRAINT [DF_c4_lost_lst_cont] DEFAULT ('') FOR [lst_cont],
	CONSTRAINT [DF_c4_lost_lst_date] DEFAULT ('') FOR [lst_date],
	CONSTRAINT [DF_c4_lost_lst_rea] DEFAULT ('') FOR [lst_rea],
	CONSTRAINT [DF_c4_lost_lst_fgsent] DEFAULT ('0') FOR [lst_fgsent]
GO

ALTER TABLE [dbo].[c4_or] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_or_or_syscd] DEFAULT ('C4') FOR [or_syscd],
	CONSTRAINT [DF_c4_or_or_contno] DEFAULT ('') FOR [or_contno],
	CONSTRAINT [DF_c4_or_or_oritem] DEFAULT ('') FOR [or_oritem],
	CONSTRAINT [DF_c4_or_or_inm] DEFAULT ('') FOR [or_inm],
	CONSTRAINT [DF_c4_or_or_nm] DEFAULT ('') FOR [or_nm],
	CONSTRAINT [DF_c4_or_or_jbti] DEFAULT ('') FOR [or_jbti],
	CONSTRAINT [DF_c4_or_or_addr] DEFAULT ('') FOR [or_addr],
	CONSTRAINT [DF_c4_or_or_zip] DEFAULT ('') FOR [or_zip],
	CONSTRAINT [DF_c4_or_or_tel] DEFAULT ('') FOR [or_tel],
	CONSTRAINT [DF_c4_or_or_fax] DEFAULT ('') FOR [or_fax],
	CONSTRAINT [DF_c4_or_or_cell] DEFAULT ('') FOR [or_cell],
	CONSTRAINT [DF_c4_or_or_email] DEFAULT ('') FOR [or_email],
	CONSTRAINT [DF_c4_or_or_fgmosea] DEFAULT ('0') FOR [or_fgmosea]
GO

ALTER TABLE [dbo].[c4_remail] WITH NOCHECK ADD 
	CONSTRAINT [DF_c4_remail_rm_syscd] DEFAULT ('C4') FOR [rm_syscd],
	CONSTRAINT [DF_c4_remail_rm_contno] DEFAULT ('') FOR [rm_contno],
	CONSTRAINT [DF_c4_remail_rm_mseq] DEFAULT ('') FOR [rm_mseq],
	CONSTRAINT [DF_c4_remail_rm_seq] DEFAULT ('') FOR [rm_seq],
	CONSTRAINT [DF_c4_remail_rm_cont] DEFAULT ('') FOR [rm_cont],
	CONSTRAINT [DF_c4_remail_rm_date] DEFAULT ('') FOR [rm_date],
	CONSTRAINT [DF_c4_remail_rm_fgsent] DEFAULT ('') FOR [rm_fgsent]
GO

ALTER TABLE [dbo].[cust] WITH NOCHECK ADD 
	CONSTRAINT [DF_cust_cust_custno] DEFAULT ('') FOR [cust_custno],
	CONSTRAINT [DF_cust_cust_nm] DEFAULT ('') FOR [cust_nm],
	CONSTRAINT [DF_cust_cust_jbti] DEFAULT ('') FOR [cust_jbti],
	CONSTRAINT [DF_cust_cust_mfrno] DEFAULT ('') FOR [cust_mfrno],
	CONSTRAINT [DF_cust_cust_tel] DEFAULT ('') FOR [cust_tel],
	CONSTRAINT [DF_cust_cust_fax] DEFAULT ('') FOR [cust_fax],
	CONSTRAINT [DF_cust_cust_cell] DEFAULT ('') FOR [cust_cell],
	CONSTRAINT [DF_cust_cust_email] DEFAULT ('') FOR [cust_email],
	CONSTRAINT [DF_cust_cust_regdate] DEFAULT ('') FOR [cust_regdate],
	CONSTRAINT [DF_cust_cust_moddate] DEFAULT ('') FOR [cust_moddate],
	CONSTRAINT [DF_cust_cust_itpcd] DEFAULT ('') FOR [cust_itpcd],
	CONSTRAINT [DF_cust_cust_btpcd] DEFAULT ('') FOR [cust_btpcd],
	CONSTRAINT [DF_cust_cust_rtpcd] DEFAULT ('') FOR [cust_rtpcd],
	CONSTRAINT [DF_cust_cust_oldcustno] DEFAULT ('') FOR [cust_oldcustno],
	CONSTRAINT [DF_cust_cust_orgisyscd] DEFAULT ('') FOR [cust_orgisyscd]
GO

ALTER TABLE [dbo].[freecat] WITH NOCHECK ADD 
	CONSTRAINT [DF_freecat_fc_fccd] DEFAULT ('') FOR [fc_fccd],
	CONSTRAINT [DF_freecat_fc_fcnm] DEFAULT ('') FOR [fc_nm]
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
	CONSTRAINT [DF_ia_ia_contno] DEFAULT ('') FOR [ia_contno],
	CONSTRAINT [DF_ia_ia_iabdate] DEFAULT ('') FOR [ia_iabdate],
	CONSTRAINT [DF_ia_ia_iabseq] DEFAULT ('') FOR [ia_iabseq]
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
	CONSTRAINT [DF_ias_ias_cancel] DEFAULT ('0') FOR [ias_cancel],
	CONSTRAINT [DF_ias_ias_trans_sap] DEFAULT ('0') FOR [ias_trans_sap],
	CONSTRAINT [DF_ias_ias_createdate] DEFAULT ('') FOR [ias_createdate],
	CONSTRAINT [DF_ias_ias_createmen] DEFAULT ('') FOR [ias_createmen],
	CONSTRAINT [DF_ias_ias_fgitri] DEFAULT ('') FOR [ias_fgitri]
GO

ALTER TABLE [dbo].[invmfr] WITH NOCHECK ADD 
	CONSTRAINT [DF_InvMfr_im_syscd] DEFAULT ('') FOR [im_syscd],
	CONSTRAINT [DF_InvMfr_im_contno] DEFAULT ('') FOR [im_contno],
	CONSTRAINT [DF_InvMfr_im_imseq] DEFAULT ('') FOR [im_imseq],
	CONSTRAINT [DF_InvMfr_im_mfrno] DEFAULT ('') FOR [im_mfrno],
	CONSTRAINT [DF_InvMfr_im_nm] DEFAULT ('') FOR [im_nm],
	CONSTRAINT [DF_InvMfr_im_jbti] DEFAULT ('') FOR [im_jbti],
	CONSTRAINT [DF_InvMfr_im_zipcode] DEFAULT ('') FOR [im_zip],
	CONSTRAINT [DF_InvMfr_im_addr] DEFAULT ('') FOR [im_addr],
	CONSTRAINT [DF_InvMfr_im_tel] DEFAULT ('') FOR [im_tel],
	CONSTRAINT [DF_InvMfr_im_fax] DEFAULT ('') FOR [im_fax],
	CONSTRAINT [DF_InvMfr_im_cell] DEFAULT ('') FOR [im_cell],
	CONSTRAINT [DF_InvMfr_im_email] DEFAULT ('') FOR [im_email],
	CONSTRAINT [DF_InvMfr_im_invcd] DEFAULT ('3') FOR [im_invcd],
	CONSTRAINT [DF_InvMfr_im_taxtp] DEFAULT ('1') FOR [im_taxtp],
	CONSTRAINT [DF_InvMfr_im_fgitri] DEFAULT ('') FOR [im_fgitri]
GO

ALTER TABLE [dbo].[itp] WITH NOCHECK ADD 
	CONSTRAINT [DF_itp_itp_itpcd] DEFAULT ('') FOR [itp_itpcd],
	CONSTRAINT [DF_itp_itp_nm] DEFAULT ('') FOR [itp_nm]
GO

ALTER TABLE [dbo].[log_mb] WITH NOCHECK ADD 
	CONSTRAINT [DF_log_mb_lg_mnt] DEFAULT (0) FOR [lg_mnt]
GO

ALTER TABLE [dbo].[mailer] WITH NOCHECK ADD 
	CONSTRAINT [DF_mailer_ml_mlcd] DEFAULT ('') FOR [ml_mlcd],
	CONSTRAINT [DF_mailer_ml_nm] DEFAULT ('') FOR [ml_nm]
GO

ALTER TABLE [dbo].[mb] WITH NOCHECK ADD 
	CONSTRAINT [DF_mb_mnt] DEFAULT (0) FOR [mnt],
	CONSTRAINT [DF_mb_ip_addr] DEFAULT ('') FOR [ip_addr],
	CONSTRAINT [DF_mb_pwd] DEFAULT ('') FOR [pwd]
GO

ALTER TABLE [dbo].[mfr] WITH NOCHECK ADD 
	CONSTRAINT [DF_mfr_mfr_mfrno] DEFAULT ('') FOR [mfr_mfrno],
	CONSTRAINT [DF_mfr_mfr_inm] DEFAULT ('') FOR [mfr_inm],
	CONSTRAINT [DF_mfr_mfr_iaddr] DEFAULT ('') FOR [mfr_iaddr],
	CONSTRAINT [DF_mfr_mfr_izip] DEFAULT ('') FOR [mfr_izip],
	CONSTRAINT [DF_mfr_mfr_respnm] DEFAULT ('') FOR [mfr_respnm],
	CONSTRAINT [DF_mfr_mfr_respjbti] DEFAULT ('') FOR [mfr_respjbti],
	CONSTRAINT [DF_mfr_mfr_tel] DEFAULT ('') FOR [mfr_tel],
	CONSTRAINT [DF_mfr_mfr_fax] DEFAULT ('') FOR [mfr_fax],
	CONSTRAINT [DF_mfr_mfr_regdate] DEFAULT ('') FOR [mfr_regdate]
GO

ALTER TABLE [dbo].[mltp] WITH NOCHECK ADD 
	CONSTRAINT [DF_mltp_mltp_syscd] DEFAULT ('C') FOR [mltp_syscd],
	CONSTRAINT [DF_mltp_mltp_mlcd] DEFAULT ('') FOR [mltp_mlcd],
	CONSTRAINT [DF_mltp_mltp_mltpcd] DEFAULT ('') FOR [mltp_mltpcd]
GO

ALTER TABLE [dbo].[mtp] WITH NOCHECK ADD 
	CONSTRAINT [DF_mtp_mtp_mtpcd] DEFAULT ('') FOR [mtp_mtpcd],
	CONSTRAINT [DF_mtp_mtp_nm] DEFAULT ('') FOR [mtp_nm]
GO

ALTER TABLE [dbo].[proj] WITH NOCHECK ADD 
	CONSTRAINT [DF_proj_proj_syscd] DEFAULT ('') FOR [proj_syscd],
	CONSTRAINT [DF_proj_proj_bkcd] DEFAULT ('') FOR [proj_bkcd],
	CONSTRAINT [DF_proj_proj_fgitri] DEFAULT ('') FOR [proj_fgitri],
	CONSTRAINT [DF_proj_proj_projno] DEFAULT ('') FOR [proj_projno],
	CONSTRAINT [DF_proj_proj_costctr] DEFAULT ('') FOR [proj_costctr],
	CONSTRAINT [DF_proj_proj_cont] DEFAULT ('') FOR [proj_cont]
GO

ALTER TABLE [dbo].[py] WITH NOCHECK ADD 
	CONSTRAINT [DF_py_py_pyno] DEFAULT ('') FOR [py_pyno],
	CONSTRAINT [DF_py_py_amt] DEFAULT ('') FOR [py_amt],
	CONSTRAINT [DF_py_py_pytpcd] DEFAULT ('') FOR [py_pytpcd],
	CONSTRAINT [DF_py_py_date] DEFAULT ('') FOR [py_date],
	CONSTRAINT [DF_py_py_moseq] DEFAULT ('') FOR [py_moseq],
	CONSTRAINT [DF_py_py_moitem] DEFAULT ('') FOR [py_moitem],
	CONSTRAINT [DF_py_py_chkno] DEFAULT ('') FOR [py_chkno],
	CONSTRAINT [DF_py_py_chkbnm] DEFAULT ('') FOR [py_chkbnm],
	CONSTRAINT [DF_py_py_chkdate] DEFAULT ('') FOR [py_chkdate],
	CONSTRAINT [DF_py_py_waccno] DEFAULT ('') FOR [py_waccno],
	CONSTRAINT [DF_py_py_wdate] DEFAULT ('') FOR [py_wdate],
	CONSTRAINT [DF_py_py_wbcd] DEFAULT ('') FOR [py_wbcd],
	CONSTRAINT [DF_py_py_ccno] DEFAULT ('') FOR [py_ccno],
	CONSTRAINT [DF_py_py_cctp] DEFAULT ('') FOR [py_cctp],
	CONSTRAINT [DF_py_py_ccauthcd] DEFAULT ('') FOR [py_ccauthcd],
	CONSTRAINT [DF_py_py_ccvdate] DEFAULT ('') FOR [py_ccvdate],
	CONSTRAINT [DF_py_py_ccdate] DEFAULT ('') FOR [py_ccdate],
	CONSTRAINT [DF_py_py_fgprinted] DEFAULT ('0') FOR [py_fgprinted],
	CONSTRAINT [DF_py_py_syscd] DEFAULT ('C') FOR [py_syscd],
	CONSTRAINT [DF_py_py_pysdate] DEFAULT ('') FOR [py_pysdate],
	CONSTRAINT [DF_py_py_pysseq] DEFAULT ('') FOR [py_pysseq],
	CONSTRAINT [DF_py_py_pyditem] DEFAULT ('') FOR [py_pysitem]
GO

ALTER TABLE [dbo].[pyd] WITH NOCHECK ADD 
	CONSTRAINT [DF_pyd_pyd_pyno] DEFAULT ('') FOR [pyd_pyno],
	CONSTRAINT [DF_pyd_pyd_pyditem] DEFAULT ('') FOR [pyd_pyditem],
	CONSTRAINT [DF_pyd_pyd_syscd_1] DEFAULT ('') FOR [pyd_syscd],
	CONSTRAINT [DF_pyd_pyd_invno] DEFAULT ('') FOR [pyd_iano],
	CONSTRAINT [DF_pyd_pyd_cancel] DEFAULT ('') FOR [pyd_cancel]
GO

ALTER TABLE [dbo].[pyseq] WITH NOCHECK ADD 
	CONSTRAINT [DF_pyseq_pys_syscd] DEFAULT ('') FOR [pys_syscd],
	CONSTRAINT [DF_pyseq_pys_pysdate] DEFAULT ('') FOR [pys_pysdate],
	CONSTRAINT [DF_pyseq_pys_pysseq] DEFAULT ('') FOR [pys_pysseq],
	CONSTRAINT [DF_pyseq_pys_toitem] DEFAULT ('') FOR [pys_toitem],
	CONSTRAINT [DF_pyseq_pys_pytpcd] DEFAULT ('') FOR [pys_pytpcd],
	CONSTRAINT [DF_pyseq_pys_ccseq] DEFAULT ('') FOR [pys_fgprinted],
	CONSTRAINT [DF_pyseq_pys_modate] DEFAULT ('') FOR [pys_createdate],
	CONSTRAINT [DF_pyseq_pys_moname] DEFAULT ('') FOR [pys_createmen]
GO

ALTER TABLE [dbo].[pytp] WITH NOCHECK ADD 
	CONSTRAINT [DF_pytp_pytp_pytpcd] DEFAULT ('') FOR [pytp_pytpcd],
	CONSTRAINT [DF_pytp_pytp_nm] DEFAULT ('') FOR [pytp_nm]
GO

ALTER TABLE [dbo].[refd] WITH NOCHECK ADD 
	CONSTRAINT [DF_refd_rd_syscd] DEFAULT ('C') FOR [rd_syscd],
	CONSTRAINT [DF_refd_rd_projno] DEFAULT ('') FOR [rd_projno],
	CONSTRAINT [DF_refd_rd_costctr] DEFAULT ('') FOR [rd_costctr],
	CONSTRAINT [DF_refd_rd_accdcr] DEFAULT ('') FOR [rd_accdcr],
	CONSTRAINT [DF_refd_rd_descr] DEFAULT ('') FOR [rd_descr]
GO

ALTER TABLE [dbo].[refm] WITH NOCHECK ADD 
	CONSTRAINT [DF_refm_rm_syscd] DEFAULT ('C') FOR [rm_syscd],
	CONSTRAINT [DF_refm_rm_remark] DEFAULT ('') FOR [rm_remark],
	CONSTRAINT [DF_refm_rm_deptcd] DEFAULT ('') FOR [rm_deptcd],
	CONSTRAINT [DF_refm_rm_accddr] DEFAULT ('') FOR [rm_accddr],
	CONSTRAINT [DF_refm_rm_idescr] DEFAULT ('') FOR [rm_idescr],
	CONSTRAINT [DF_refm_rm_iunit] DEFAULT ('') FOR [rm_iunit],
	CONSTRAINT [DF_refm_rm_iremark] DEFAULT ('') FOR [rm_iremark]
GO

ALTER TABLE [dbo].[sapiv] WITH NOCHECK ADD 
	CONSTRAINT [DF_sapiv_iv_orgcd] DEFAULT ('') FOR [iv_orgcd],
	CONSTRAINT [DF_sapiv_iv_type] DEFAULT ('') FOR [iv_type],
	CONSTRAINT [DF_sapiv_iv_yyyymm] DEFAULT ('') FOR [iv_yyyymm],
	CONSTRAINT [DF_sapiv_iv_seq] DEFAULT ('') FOR [iv_seq],
	CONSTRAINT [DF_sapiv_iv_infno] DEFAULT ('') FOR [iv_infno],
	CONSTRAINT [DF_sapiv_iv_ref] DEFAULT ('') FOR [iv_ref],
	CONSTRAINT [DF_sapiv_iv_date] DEFAULT ('') FOR [iv_date],
	CONSTRAINT [DF_sapiv_iv_invtp] DEFAULT ('') FOR [iv_invtp],
	CONSTRAINT [DF_sapiv_iv_invcd] DEFAULT ('') FOR [iv_invcd],
	CONSTRAINT [DF_sapiv_iv_taxtp] DEFAULT ('') FOR [iv_taxtp],
	CONSTRAINT [DF_sapiv_iv_remark] DEFAULT ('') FOR [iv_remark],
	CONSTRAINT [DF_sapiv_iv_cusno] DEFAULT ('') FOR [iv_cusno],
	CONSTRAINT [DF_sapiv_iv_title] DEFAULT ('') FOR [iv_title],
	CONSTRAINT [DF_sapiv_iv_address] DEFAULT ('') FOR [iv_address],
	CONSTRAINT [DF_sapiv_iv_saleamt] DEFAULT ('') FOR [iv_saleamt],
	CONSTRAINT [DF_sapiv_iv_taxamt] DEFAULT ('') FOR [iv_taxamt],
	CONSTRAINT [DF_sapiv_iv_invoamt] DEFAULT ('') FOR [iv_invoamt],
	CONSTRAINT [DF_sapiv_iv_curr] DEFAULT ('') FOR [iv_curr],
	CONSTRAINT [DF_sapiv_iv_rate] DEFAULT ('') FOR [iv_rate],
	CONSTRAINT [DF_sapiv_iv_prtctl] DEFAULT ('') FOR [iv_prtctl],
	CONSTRAINT [DF_sapiv_iv_postdate] DEFAULT ('') FOR [iv_postdate],
	CONSTRAINT [DF_sapiv_iv_accddr] DEFAULT ('') FOR [iv_accddr],
	CONSTRAINT [DF_sapiv_iv_attach] DEFAULT ('') FOR [iv_attach],
	CONSTRAINT [DF_sapiv_iv_exptype] DEFAULT ('') FOR [iv_exptype],
	CONSTRAINT [DF_sapiv_iv_expremark] DEFAULT ('') FOR [iv_expremark]
GO

ALTER TABLE [dbo].[sapivd] WITH NOCHECK ADD 
	CONSTRAINT [DF_sapivd_ivd_infno] DEFAULT ('') FOR [ivd_infno],
	CONSTRAINT [DF_sapivd_ivd_iseq] DEFAULT ('') FOR [ivd_iseq],
	CONSTRAINT [DF_sapivd_ivd_idescr] DEFAULT ('') FOR [ivd_idescr],
	CONSTRAINT [DF_sapivd_ivd_iunit] DEFAULT ('') FOR [ivd_iunit],
	CONSTRAINT [DF_sapivd_ivd_iqty] DEFAULT ('') FOR [ivd_iqty],
	CONSTRAINT [DF_sapivd_ivd_iuniprice] DEFAULT ('') FOR [ivd_iuniprice],
	CONSTRAINT [DF_sapivd_ivd_iremark] DEFAULT ('') FOR [ivd_iremark]
GO

ALTER TABLE [dbo].[sapvou] WITH NOCHECK ADD 
	CONSTRAINT [DF_sapvou_vou_infno] DEFAULT ('') FOR [vou_infno],
	CONSTRAINT [DF_sapvou_vou_vseq] DEFAULT ('') FOR [vou_vseq],
	CONSTRAINT [DF_sapvou_vou_accdcr] DEFAULT ('') FOR [vou_accdcr],
	CONSTRAINT [DF_sapvou_vou_projno] DEFAULT ('') FOR [vou_projno],
	CONSTRAINT [DF_sapvou_vou_costctr] DEFAULT ('') FOR [vou_costctr],
	CONSTRAINT [DF_sapvou_vou_contno] DEFAULT ('') FOR [vou_contno],
	CONSTRAINT [DF_sapvou_vou_period] DEFAULT ('') FOR [vou_period],
	CONSTRAINT [DF_sapvou_vou_amt] DEFAULT ('') FOR [vou_amt],
	CONSTRAINT [DF_sapvou_vou_descr] DEFAULT ('') FOR [vou_descr],
	CONSTRAINT [DF_sapvou_vou_alloc] DEFAULT ('') FOR [vou_alloc]
GO

ALTER TABLE [dbo].[srspn] WITH NOCHECK ADD 
	CONSTRAINT [DF_srspn_srspn_empno] DEFAULT ('') FOR [srspn_empno],
	CONSTRAINT [DF_srspn_srspn_cname] DEFAULT ('') FOR [srspn_cname],
	CONSTRAINT [DF_srspn_srspn_tel] DEFAULT ('') FOR [srspn_tel],
	CONSTRAINT [DF_srspn_srspn_atype] DEFAULT ('') FOR [srspn_atype],
	CONSTRAINT [DF_srspn_srspn_orgcd] DEFAULT ('') FOR [srspn_orgcd],
	CONSTRAINT [DF_srspn_srspn_deptcd] DEFAULT ('') FOR [srspn_deptcd],
	CONSTRAINT [DF_srspn_srspn_date] DEFAULT ('') FOR [srspn_date],
	CONSTRAINT [DF_srspn_srspn_pwd] DEFAULT ('') FOR [srspn_pwd]
GO

ALTER TABLE [dbo].[syscd] WITH NOCHECK ADD 
	CONSTRAINT [DF_syscd_sys_syscd] DEFAULT ('') FOR [sys_syscd],
	CONSTRAINT [DF_syscd_sys_nm] DEFAULT ('') FOR [sys_nm],
	CONSTRAINT [DF_syscd_sys_deptcd] DEFAULT ('') FOR [sys_deptcd]
GO

ALTER TABLE [dbo].[test] WITH NOCHECK ADD 
	CONSTRAINT [DF_test_aa] DEFAULT ('') FOR [aa]
GO

ALTER TABLE [dbo].[tmp_cust1] WITH NOCHECK ADD 
	CONSTRAINT [DF_tmp_cust1_o_cancel] DEFAULT ('0') FOR [o_status]
GO

ALTER TABLE [dbo].[tmp_income1] WITH NOCHECK ADD 
	CONSTRAINT [DF_tmp_c1_order_tmp_otp1cd] DEFAULT ('') FOR [tmp_otp1cd],
	CONSTRAINT [DF_tmp_c1_order_tmp_otp2cd] DEFAULT ('') FOR [tmp_otp2cd],
	CONSTRAINT [DF_tmp_c1_order_tmp_btpcd] DEFAULT ('') FOR [tmp_btpcd],
	CONSTRAINT [DF_tmp_c1_order_tmp_projno] DEFAULT ('') FOR [tmp_projno],
	CONSTRAINT [DF_tmp_c1_order_tmp_amt] DEFAULT (0) FOR [tmp_param1],
	CONSTRAINT [DF_tmp_c1_order_tmp_mnt] DEFAULT (0) FOR [tmp_param2]
GO

ALTER TABLE [dbo].[tmp_label1] WITH NOCHECK ADD 
	CONSTRAINT [DF_tmp_label1_od_syscd] DEFAULT ('') FOR [od_syscd],
	CONSTRAINT [DF_tmp_label1_od_custno] DEFAULT ('') FOR [od_custno],
	CONSTRAINT [DF_tmp_label1_od_otp1cd] DEFAULT ('') FOR [od_otp1cd],
	CONSTRAINT [DF_tmp_label1_od_otp1seq] DEFAULT ('') FOR [od_otp1seq],
	CONSTRAINT [DF_tmp_label1_od_oditem] DEFAULT ('') FOR [od_oditem],
	CONSTRAINT [DF_tmp_label1_od_sdate] DEFAULT ('') FOR [od_sdate],
	CONSTRAINT [DF_tmp_label1_od_edate] DEFAULT ('') FOR [od_edate],
	CONSTRAINT [DF_tmp_label1_ra_mnt] DEFAULT (0) FOR [ra_mnt],
	CONSTRAINT [DF_tmp_label1_ra_mtpcd] DEFAULT ('') FOR [ra_mtpcd],
	CONSTRAINT [DF_tmp_label1_mtp_nm] DEFAULT ('') FOR [mtp_nm],
	CONSTRAINT [DF_tmp_label1_obtp_obtpnm] DEFAULT ('') FOR [obtp_obtpnm],
	CONSTRAINT [DF_tmp_label1_ra_oritem] DEFAULT ('') FOR [ra_oritem]
GO

ALTER TABLE [dbo].[tmp_list1] WITH NOCHECK ADD 
	CONSTRAINT [DF_tmp_list1_tmp_obtpcd] DEFAULT ('') FOR [tmp_obtpcd],
	CONSTRAINT [DF_tmp_list1_tmp_cname] DEFAULT ('') FOR [tmp_cname],
	CONSTRAINT [DF_tmp_list1_tmp_pyno] DEFAULT ('') FOR [tmp_pyno],
	CONSTRAINT [DF_tmp_list1_tmp_susttp] DEFAULT ('') FOR [tmp_custtp]
GO

ALTER TABLE [dbo].[tmp_statistics] WITH NOCHECK ADD 
	CONSTRAINT [DF_tmp_statistics_tmp_otp1cd] DEFAULT ('') FOR [tmp_otp1cd],
	CONSTRAINT [DF_tmp_statistics_tmp_otp2cd] DEFAULT ('') FOR [tmp_otp2cd],
	CONSTRAINT [DF_tmp_statistics_tmp_btpcd] DEFAULT ('') FOR [tmp_btpcd],
	CONSTRAINT [DF_tmp_statistics_tmp_parm1] DEFAULT (0) FOR [tmp_param1],
	CONSTRAINT [DF_tmp_statistics_tmp_parm2] DEFAULT (0) FOR [tmp_param2]
GO

ALTER TABLE [dbo].[wk_c2_rp1] WITH NOCHECK ADD 
	CONSTRAINT [DF_wk_c2_rp1_cont_fgcancel] DEFAULT ('') FOR [cont_fgcancel]
GO

ALTER TABLE [dbo].[wk_c2_rp1_1] WITH NOCHECK ADD 
	CONSTRAINT [DF_wk_c2_rp1_1_cont_fgcancel] DEFAULT ('') FOR [cont_fgcancel]
GO

ALTER TABLE [dbo].[wk_c2_rp1_5] WITH NOCHECK ADD 
	CONSTRAINT [DF_wk_c2_rp1_5_cont_fgcancek] DEFAULT ('') FOR [cont_fgcancel]
GO

ALTER TABLE [dbo].[wkflag] WITH NOCHECK ADD 
	CONSTRAINT [DF_tmpflag_wk_flgcd] DEFAULT ('') FOR [wk_flgcd],
	CONSTRAINT [DF_tmpflag_wk_name] DEFAULT ('') FOR [wk_name]
GO

 CREATE  UNIQUE  INDEX [c2_cont_full_x] ON [dbo].[c2_cont_full]([cont_syscd], [cont_contno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [c2_pub_full_x] ON [dbo].[c2_pub_full]([pub_syscd], [pub_contno], [pub_yyyymm], [pub_pubseq]) ON [PRIMARY]
GO

 CREATE  INDEX [idinftmp201] ON [dbo].[inftmp20]([inf20_orgcd], [inf20_type], [inf20_yyyymm], [inf20_seq]) ON [PRIMARY]
GO

 CREATE  INDEX [IX_inv10] ON [dbo].[inv10]([inv10_invno]) ON [PRIMARY]
GO

 CREATE  INDEX [IX_inv10_1] ON [dbo].[inv10]([inv10_projno]) ON [PRIMARY]
GO

 CREATE  INDEX [idinvno] ON [dbo].[inv20]([inv20_invno]) ON [PRIMARY]
GO

 CREATE  INDEX [idprojno] ON [dbo].[inv20]([inv20_projno]) ON [PRIMARY]
GO

 CREATE  INDEX [idcontno] ON [dbo].[inv20]([inv20_contno], [inv20_period]) ON [PRIMARY]
GO

 CREATE  INDEX [idchkno] ON [dbo].[inv20]([inv20_chkno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pbcatcol_idx] ON [dbo].[pbcatcol]([pbc_tnam], [pbc_ownr], [pbc_cnam]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [pbcattbl_idx] ON [dbo].[pbcattbl]([pbt_tnam], [pbt_ownr]) ON [PRIMARY]
GO

 CREATE  INDEX [idsapiv1] ON [dbo].[sapiv]([iv_orgcd], [iv_type], [iv_yyyymm], [iv_seq]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [wk_c2_rp1_1] ON [dbo].[wk_c2_rp1_1]([cont_syscd], [cont_contno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [c2_pub_x] ON [dbo].[wk_c2_rp1_2]([pub_syscd], [pub_contno], [pub_yyyymm], [pub_pubseq]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [c2_cont_temp_x] ON [dbo].[wk_c2_rp1_3]([cont_syscd], [cont_contno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [prior_per_cont_pk] ON [dbo].[wk_c2_rp1_4]([cont_contno]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [wk_c2_rp1_1_x_1] ON [dbo].[wk_c2_rp1_5]([cont_syscd], [cont_contno]) ON [PRIMARY]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Results]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Results]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Table1]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[Table1]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[WebMember]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[WebMember]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[book]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[book]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[bookp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[bookp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[btp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[btp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_cust]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_cust]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_lost]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_lost]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_obtp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_obtp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_od]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_od]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_or]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_order]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_order]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ores]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ores]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_otp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_otp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ramt]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_ramt]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_remail]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_remail]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_clr]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_clr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_cont]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_cont]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_getad]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_getad]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lost]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lost]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lprior]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_lprior]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_ltp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_ltp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_njtp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_njtp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_or]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pgsize]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pgsize]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pub]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c2_pub]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_adcnt]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_adcnt]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_adr]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_adr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_cont]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_cont]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_freebk]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_freebk]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_lost]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_lost]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_or]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_ramt]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_ramt]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_remail]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c4_remail]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[cust]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[cust]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[hicard]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[hicard]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ia]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ia]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[iad]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[iad]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ias]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[ias]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inftmp20]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inftmp20]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inv10]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inv10]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inv20]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[inv20]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[invmfr]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[invmfr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[itp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[itp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[itriorg]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[itriorg]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mailer]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mailer]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mfr]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mfr]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mltp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mltp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mtp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[mtp]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatcol]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatcol]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatcol]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatedt]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatedt]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatedt]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatfmt]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatfmt]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatfmt]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcattbl]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcattbl]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcattbl]  TO [webuser]
GO

GRANT  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatvld]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatvld]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pbcatvld]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[py]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[py]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyd]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyd]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyseq]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pyseq]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pytp]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[pytp]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refd]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refd]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refm]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[refm]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapiv]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapiv]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapivd]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapivd]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[saplog]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[saplog]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapvou]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[sapvou]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[srspn]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[srspn]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[syscd]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[syscd]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_cust1]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_cust1]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_income1]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_income1]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_income1]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_label1]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_label1]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_label2]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_label2]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_list1]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[tmp_list1]  TO [webuser]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[wkflag]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[wkflag]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.c1_otp1_v_old    Script Date: 2002/11/19 上午 10:39:46 ******/
/****** Object:  View dbo.c1_otp1_v    Script Date: 2002/1/3 下午 04:29:54 ******/
CREATE VIEW dbo.c1_otp1_v_old
AS
SELECT DISTINCT otp_otp1cd, otp_otp1nm
FROM             dbo.c1_otp

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  SELECT  ON [dbo].[c1_otp1_v_old]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_otp1_v_old]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_otp1_v_old]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c1_tmp_001    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c1_tmp_001
AS
SELECT         dbo.c1_od.*, dbo.c1_order.o_otp2cd, dbo.c1_ramt.ra_mnt, 
                          dbo.c1_ramt.ra_mtpcd
FROM             dbo.c1_od INNER JOIN
                          dbo.c1_order ON dbo.c1_od.od_syscd = dbo.c1_order.o_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_order.o_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_order.o_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_order.o_otp1seq INNER JOIN
                          dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND 
                          dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem
WHERE         (dbo.c1_ramt.ra_mtpcd <> '11')

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c2_count_pubseq_of_cont    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c2_count_pubseq_of_cont
AS
SELECT TOP 100 PERCENT COUNT(dbo.c2_pub.pub_pubseq) AS pubseq_cnt, 
                  dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno
FROM     dbo.c2_cont INNER JOIN
                  dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND 
                  dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno
WHERE  (dbo.c2_cont.cont_fgclosed = '0')
GROUP BY dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno
ORDER BY dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c2_iaFm2_prelist2    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c2_iaFm2_prelist2
AS
SELECT         dbo.v_c2_iaFm2_prelist2a.*, dbo.mfr.mfr_inm AS im_mfrinm
FROM             dbo.v_c2_iaFm2_prelist2a INNER JOIN
                          dbo.mfr ON dbo.v_c2_iaFm2_prelist2a.im_mfrno = dbo.mfr.mfr_mfrno

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c2_iaFm2_prelist2a    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c2_iaFm2_prelist2a
AS
SELECT         TOP 100 PERCENT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, 
                          dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_sdate, 
                          dbo.c2_cont.cont_edate, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) 
                          + '/' + SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6) 
                          + ' ~ ' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) 
                          + '/' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate, 
                          RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mfr.mfr_inm) 
                          AS mfr_inm, RTRIM(dbo.cust.cust_nm) AS cust_nm, dbo.c2_cont.cont_empno, 
                          RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.c2_cont.cont_totamt, 
                          dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_pub.pub_imseq, 
                          dbo.invmfr.im_nm, dbo.invmfr.im_jbti, dbo.invmfr.im_zip, dbo.invmfr.im_addr, 
                          dbo.invmfr.im_tel, dbo.invmfr.im_invcd, dbo.invmfr.im_taxtp, 
                          RTRIM(dbo.invmfr.im_fgitri) AS im_fgitri, SUBSTRING(dbo.c2_pub.pub_yyyymm,
                           1, 4) + '/' + SUBSTRING(dbo.c2_pub.pub_yyyymm, 5, 6) AS pub_yyyymm, 
                          dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_clrcd, RTRIM(dbo.c2_clr.clr_nm) 
                          AS clr_nm, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_ltpcd, 
                          dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_adamt, 
                          dbo.c2_pub.pub_chgamt, 
                          dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt AS pub_totamt, 
                          RTRIM(dbo.invmfr.im_mfrno) AS im_mfrno
FROM             dbo.c2_pub INNER JOIN
                          dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND 
                          dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno INNER JOIN
                          dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN
                          dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN
                          dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN
                          dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN
                          dbo.invmfr ON dbo.c2_pub.pub_syscd = dbo.invmfr.im_syscd AND 
                          dbo.c2_pub.pub_contno = dbo.invmfr.im_contno AND 
                          dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq
WHERE         (dbo.c2_pub.pub_fginved = 't') AND (dbo.c2_cont.cont_fgpubed = '1') AND 
                          (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND 
                          (dbo.c2_cont.cont_fgtemp = '0')
ORDER BY  dbo.c2_pub.pub_contno, dbo.invmfr.im_imseq, dbo.c2_pub.pub_pubseq

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c4_cont_cust_mfr    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c4_cont_cust_mfr
AS
SELECT dbo.c4_cont.*, dbo.cust.*, dbo.mfr.*
FROM     dbo.c4_cont INNER JOIN
                  dbo.cust ON dbo.c4_cont.cont_custno = dbo.cust.cust_custno INNER JOIN
                  dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c4_contchecklist    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c4_contchecklist
AS
SELECT dbo.c4_cont.cont_contid, dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, 
                  dbo.c4_cont.cont_custno, dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_signdate, 
                  dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_empno, 
                  dbo.c4_cont.cont_mfrno, dbo.c4_cont.cont_pubcate, dbo.c4_cont.cont_aunm, 
                  dbo.c4_cont.cont_autel, dbo.c4_cont.cont_aufax, dbo.c4_cont.cont_aucell, 
                  dbo.c4_cont.cont_auemail, dbo.c4_cont.cont_disc, dbo.c4_cont.cont_freetm, 
                  dbo.c4_cont.cont_pubtm, dbo.c4_cont.cont_resttm, dbo.c4_cont.cont_totamt, 
                  dbo.c4_cont.cont_paidamt, dbo.c4_cont.cont_restamt, dbo.c4_cont.cont_ccont, 
                  dbo.c4_cont.cont_csdate, dbo.c4_cont.cont_atp, dbo.c4_cont.cont_matp, 
                  dbo.c4_cont.cont_fgclosed, dbo.c4_cont.cont_adremark, dbo.c4_cont.cont_pdcont, 
                  dbo.c4_cont.cont_moddate, dbo.c4_cont.cont_fgpayonce, dbo.c4_cont.cont_fgtemp, 
                  dbo.c4_cont.cont_fgpubed, dbo.c4_cont.cont_modempno, dbo.c4_cont.cont_credate, 
                  dbo.c4_cont.cont_totimgtm, dbo.c4_cont.cont_toturltm, dbo.c4_cont.cont_adsprem, 
                  dbo.c4_cont.cont_fgcancel AS mfr_mfrnm, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrno
FROM     dbo.c4_cont LEFT OUTER JOIN
                  dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno LEFT OUTER JOIN
                      (SELECT DISTINCT adrd_syscd, adrd_contno
                       FROM      c4_adrd
                       WHERE   adrd_fginved = '0') DRIVERTBL ON 
                  dbo.c4_cont.cont_syscd = DRIVERTBL.adrd_syscd AND 
                  dbo.c4_cont.cont_contno = DRIVERTBL.adrd_contno
WHERE  (dbo.c4_cont.cont_fgtemp <> '1') AND (dbo.c4_cont.cont_fgcancel <> '1') AND 
                  (dbo.c4_cont.cont_fgclosed <> '1')

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c4_cust_mfr    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c4_cust_mfr
AS
SELECT dbo.cust.*, dbo.mfr.*
FROM     dbo.cust INNER JOIN
                  dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_c4_invbatch    Script Date: 2002/11/19 上午 10:39:46 ******/
CREATE VIEW dbo.v_c4_invbatch
AS
SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, 
                  dbo.c4_cont.cont_mfrno, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, 
                  dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_impr, 
                  DRIVERTBL.suminvamt, dbo.mfr.mfr_inm, dbo.invmfr.im_nm, dbo.invmfr.im_jbti, 
                  dbo.invmfr.im_invcd, dbo.invmfr.im_taxtp, dbo.invmfr.im_fgitri, 
                  dbo.c4_cont.cont_empno, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_imseq, 
                  dbo.c4_adr.adr_alttext
FROM     dbo.c4_adr INNER JOIN
                      (SELECT DISTINCT 
                                         adrd_syscd, adrd_contno, adrd_adrseq, suminvamt = SUM(adrd_adramt) 
                                         + SUM(adrd_chgamt) + SUM(adrd_desamt)
                       FROM      c4_adrd
                       WHERE   substring(adrd_addate, 1, 6) <= '200208' AND adrd_fginved = '0'
                       GROUP BY adrd_syscd, adrd_contno, adrd_adrseq) DRIVERTBL ON 
                  DRIVERTBL.adrd_syscd = dbo.c4_adr.adr_syscd AND 
                  DRIVERTBL.adrd_contno = dbo.c4_adr.adr_contno AND 
                  DRIVERTBL.adrd_adrseq = dbo.c4_adr.adr_seq INNER JOIN
                  dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND 
                  dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno INNER JOIN
                  dbo.invmfr ON dbo.c4_adr.adr_syscd = dbo.invmfr.im_syscd AND 
                  dbo.c4_adr.adr_contno = dbo.invmfr.im_contno AND 
                  dbo.c4_adr.adr_imseq = dbo.invmfr.im_imseq INNER JOIN
                  dbo.mfr ON dbo.invmfr.im_mfrno = dbo.mfr.mfr_mfrno

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_label1    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE VIEW dbo.v_label1
AS
SELECT         dbo.c1_od.od_syscd, dbo.c1_od.od_custno, dbo.c1_od.od_otp1cd, 
                          dbo.c1_od.od_otp1seq, dbo.c1_od.od_oditem, dbo.c1_od.od_sdate, 
                          dbo.c1_od.od_edate, dbo.c1_od.od_btpcd, dbo.c1_od.od_projno, 
                          dbo.c1_od.od_costctr, dbo.c1_od.od_remark, dbo.c1_od.od_amt, 
                          dbo.c1_ramt.ra_oritem, dbo.c1_ramt.ra_mnt, dbo.mtp.mtp_nm, 
                          dbo.c1_obtp.obtp_obtpnm, dbo.c1_otp.otp_otp1nm, 
                          dbo.c1_otp.otp_otp2nm
FROM             dbo.c1_od INNER JOIN
                          dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND 
                          dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN
                          dbo.mtp ON dbo.c1_ramt.ra_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd INNER JOIN
                          dbo.c1_order ON dbo.c1_od.od_syscd = dbo.c1_order.o_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_order.o_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_order.o_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_order.o_otp1seq INNER JOIN
                          dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND 
                          dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  SELECT  ON [dbo].[v_label1]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[v_label1]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[v_label1]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_label_c1    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE VIEW dbo.v_label_c1
AS
SELECT         dbo.c1_od.od_odid, dbo.c1_od.od_syscd, dbo.c1_od.od_custno, 
                          dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_oditem, 
                          dbo.c1_od.od_sdate, dbo.c1_od.od_edate, dbo.c1_ramt.ra_mnt, 
                          dbo.mtp.mtp_nm, dbo.c1_obtp.obtp_obtpnm, 
                          dbo.c1_od.od_syscd + dbo.c1_od.od_custno + dbo.c1_od.od_otp1cd + dbo.c1_od.od_otp1seq
                           AS nostr, dbo.c1_ramt.ra_oritem
FROM             dbo.c1_od INNER JOIN
                          dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND 
                          dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN
                          dbo.mtp ON dbo.c1_ramt.ra_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  SELECT  ON [dbo].[v_label_c1]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[v_label_c1]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[v_label_c1]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.v_maxseq    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE VIEW dbo.v_maxseq
AS
SELECT         TOP 100 PERCENT dbo.c1_order.o_syscd, dbo.c1_order.o_custno, 
                          dbo.c1_order.o_otp1cd, MAX(dbo.c1_order.o_otp1seq) AS seq, 
                          dbo.c1_od.od_edate
FROM             dbo.c1_order INNER JOIN
                          dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND 
                          dbo.c1_order.o_custno = dbo.c1_od.od_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq
GROUP BY  dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, 
                          dbo.c1_od.od_edate
HAVING          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) >= '200204') AND 
                          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) <= '200205')
ORDER BY  dbo.c1_order.o_custno

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  SELECT  ON [dbo].[v_maxseq]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[v_maxseq]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[v_maxseq]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  View dbo.c1_o_detail_v_old    Script Date: 2002/11/19 上午 10:39:47 ******/
/****** Object:  View dbo.c1_o_detail_v    Script Date: 2002/1/3 下午 04:29:54 ******/
CREATE VIEW dbo.c1_o_detail_v_old
AS
SELECT         dbo.c1_order.o_custno, dbo.c1_order.o_mfrno, dbo.c1_order.o_inm, 
                          dbo.c1_order.o_ijbti, dbo.pytp.pytp_nm, dbo.c1_order.o_otp1seq, 
                          dbo.c1_od.od_oditem, dbo.c1_od.od_sdate, dbo.c1_od.od_edate, 
                          dbo.c1_obtp.obtp_obtpnm, dbo.c1_od.od_projno, dbo.c1_od.od_amt, 
                          dbo.c1_otp1_v_old.otp_otp1nm, dbo.c1_otp.otp_otp2nm
FROM             dbo.c1_order INNER JOIN
                          dbo.c1_od ON dbo.c1_order.o_custno = dbo.c1_od.od_custno AND 
                          dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN
                          dbo.pytp ON dbo.c1_order.o_pytpcd = dbo.pytp.pytp_pytpcd INNER JOIN
                          dbo.c1_otp1_v_old ON 
                          dbo.c1_order.o_otp1cd = dbo.c1_otp1_v_old.otp_otp1cd INNER JOIN
                          dbo.c1_otp ON dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd AND 
                          dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  SELECT  ON [dbo].[c1_o_detail_v_old]  TO [public]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_o_detail_v_old]  TO [mrlpub]
GO

GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON [dbo].[c1_o_detail_v_old]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_update_adpub    Script Date: 2002/11/19 上午 10:39:47 ******/

CREATE PROCEDURE dbo.sp_c2_update_adpub 
(@syscd char(2), 
@contno char(6), 
@yyyymm char(6), 
@pubseq char(2),
@pgno int)
AS
UPDATE        c2_pub
SET                  pub_pgno = @pgno
WHERE         (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_sap_in_all    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE proc dbo.sp_sap_in_all (@yyyymm  char(6), @batch_seq char(6), @rtn char(1) output )
As
set  xact_abort on 
exec sp_sap_recovery_001 '200201','10001',0
exec sp_sap_recovery_002 '200201','10001',0
exec sp_to_sap_001 '200201','10001', '740320', '0'
exec sp_to_sap_002 '200201', '10001'
exec sp_to_sap_003 '200201', '10001', '',0

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_sap_in_all]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_sap_in_all]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.usp_return    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE Procedure usp_return
as 
Declare @ret_val int
return

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_cancel_order    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE PROCEDURE dbo.sp_c1_cancel_order
	@syscd varchar(2), @custno varchar(6), @otp1cd  varchar(2), @otp1seq  varchar(3)
	
AS
declare @iano varchar(8)
set nocount on
------在c1_order中取得iano
select @iano=o_iano from c1_order
  where o_syscd=@syscd and o_custno=@custno and o_otp1cd=@otp1cd and o_otp1seq=@otp1seq
------刪除c1_remail
delete c1_remail
  where rm_syscd=@syscd and rm_custno=@custno and rm_otp1cd=@otp1cd and rm_otp1seq=@otp1seq
------刪除c1_ramt
delete c1_ramt
  where ra_syscd=@syscd and ra_custno=@custno and ra_otp1cd=@otp1cd and ra_otp1seq=@otp1seq
------刪除c1_or
delete c1_or
  where or_syscd=@syscd and or_custno=@custno and or_otp1cd=@otp1cd and or_otp1seq=@otp1seq
------刪除c1_od
delete c1_od
  where od_syscd=@syscd and od_custno=@custno and od_otp1cd=@otp1cd and od_otp1seq=@otp1seq
------刪除iad
delete iad where iad_syscd=@syscd and iad_iano= @iano
------刪除ia
delete ia where ia_syscd=@syscd and ia_iano= @iano
------刪除c1_order
delete c1_order 
  where o_syscd=@syscd and o_custno=@custno and o_otp1cd=@otp1cd and o_otp1seq=@otp1seq
------pyd作註銷的註記
update pyd set pyd_cancel='1' where pyd_syscd=@syscd and pyd_iano=@iano

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_cancel_order]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_delete_ia    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE PROCEDURE dbo.sp_c1_delete_ia
	@syscd varchar(2), @iano varchar(8), @type varchar(1), @empno varchar(7)
	
AS
set nocount on
------刪除iad
delete iad where iad_syscd=@syscd and iad_iano= @iano
------刪除ia
delete ia where ia_syscd=@syscd and ia_iano= @iano
if @type='0' -----發票開立單Recovery
------c1_order 中 set o_iano='' , o_status='1'
	update c1_order set o_iano='', o_status='1', o_moduid=@empno where o_syscd=@syscd and o_iano=@iano
if @type='1'	-----預開發票未繳款之註銷發票
------c1_order 中 set o_iano='' , o_status='1', o_modstatus='1'
	update c1_order set o_iano='', o_status='1', o_modstatus='1', o_moduid=@empno where o_syscd=@syscd and o_iano=@iano

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_delete_ia]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_delete_py    Script Date: 2002/11/19 上午 10:39:47 ******/
CREATE PROCEDURE dbo.sp_c1_delete_py	@pyno varchar(8)
	
AS
declare @syscd varchar(2), @iano varchar(8)
set nocount on
------ia 中 ia_pyno='' and  ia_pyseq=''
DECLARE Ia_Cursor CURSOR FOR
 select pyd_syscd, pyd_iano
 from pyd
 where pyd_pyno=@pyno
OPEN Ia_Cursor
FETCH NEXT FROM Ia_Cursor
    into @syscd, @iano
WHILE @@FETCH_STATUS = 0
BEGIN
  update ia set ia_pyno='' , ia_pyseq='' 
	where ia_syscd=@syscd and ia_iano=@iano
FETCH NEXT FROM Ia_Cursor
    into @syscd, @iano
END
CLOSE Ia_Cursor
DEALLOCATE Ia_Cursor
------刪除pyd
delete pyd where  pyd_pyno= @pyno
------刪除py
delete py where py_pyno= @pyno

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_delete_py]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_delete_pyseq    Script Date: 2002/11/19 上午 10:39:48 ******/
CREATE PROCEDURE dbo.sp_c1_delete_pyseq	@pysdate varchar(6), @pysseq varchar(4)
	
AS
set nocount on
------將py 中 py_pysdate='' ,  py_pysseq='' , py_pysitem=''
update py set py_pysdate='' ,  py_pysseq='' , py_pysitem=''
	where py_pysdate=@pysdate and py_pysseq=@pysseq
------刪除pyseq
delete pyseq where  pys_pysdate=@pysdate and pys_pysseq=@pysseq

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_delete_pyseq]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_tmp_income1    Script Date: 2002/11/19 上午 10:39:48 ******/
CREATE PROCEDURE dbo.sp_c1_tmp_income1
	@date1 varchar(8), @date2 varchar(8), @projno varchar(10), @otp1cd varchar(2)
	
AS
declare	@otp2cd char(2), @mnt	int, @amt int, @btpcd char(2)
set nocount on
DECLARE @idoc	int
------收入統計表暫存檔
delete tmp_statistics
if @projno<>''
begin
DECLARE otp_Cursor CURSOR FOR
SELECT         c1_otp.otp_otp2cd, c1_obtp.obtp_obtpcd
FROM             c1_otp INNER JOIN
                          c1_obtp ON c1_otp.otp_otp1cd = c1_obtp.obtp_otp1cd
WHERE         (c1_otp.otp_otp1cd = @otp1cd)
ORDER BY  c1_otp.otp_otp2cd, c1_obtp.obtp_obtpcd
OPEN otp_Cursor
FETCH NEXT FROM otp_Cursor
    into @otp2cd, @btpcd
WHILE @@FETCH_STATUS = 0
BEGIN
set @amt=0
set @mnt=0
SELECT         @amt=SUM(c1_od.od_amt)
FROM             c1_order INNER JOIN
                          c1_od ON c1_order.o_syscd = c1_od.od_syscd AND 
                          c1_order.o_custno = c1_od.od_custno AND 
                          c1_order.o_otp1cd = c1_od.od_otp1cd AND 
                          c1_order.o_otp1seq = c1_od.od_otp1seq
WHERE         (c1_order.o_otp1cd =@otp1cd) AND (c1_order.o_otp2cd = @otp2cd) AND 
                          (c1_order.o_date>=@date1) and (c1_order.o_date<=@date2)  AND
		(c1_od.od_btpcd=@btpcd) AND (c1_od.od_projno=@projno)
SELECT         @mnt=SUM(c1_ramt.ra_mnt)
FROM             c1_order INNER JOIN
                          c1_od ON c1_order.o_syscd = c1_od.od_syscd AND 
                          c1_order.o_custno = c1_od.od_custno AND 
                          c1_order.o_otp1cd = c1_od.od_otp1cd AND 
                          c1_order.o_otp1seq = c1_od.od_otp1seq INNER JOIN
                          c1_ramt ON c1_od.od_syscd = c1_ramt.ra_syscd AND 
                          c1_od.od_custno = c1_ramt.ra_custno AND 
                          c1_od.od_otp1cd = c1_ramt.ra_otp1cd AND 
                          c1_od.od_otp1seq = c1_ramt.ra_otp1seq AND 
                          c1_od.od_oditem = c1_ramt.ra_oditem
WHERE         (c1_order.o_otp1cd = @otp1cd) AND (c1_order.o_otp2cd = @otp2cd) AND 
                          (c1_order.o_date>=@date1) and (c1_order.o_date<=@date2) AND
		(c1_od.od_btpcd=@btpcd) AND (c1_od.od_projno=@projno)
if @mnt=NULL
 set @mnt=0
if @amt=NULL
 set @amt=0
INSERT INTO tmp_statistics
                          (tmp_otp1cd, tmp_otp2cd, tmp_btpcd, tmp_param1, tmp_param2)
VALUES         (@otp1cd, @otp2cd, @btpcd, @amt,  @mnt)
FETCH NEXT FROM otp_Cursor
    into @otp2cd, @btpcd
END
CLOSE otp_Cursor
DEALLOCATE otp_Cursor
end
if @projno=''
begin
DECLARE otp_Cursor CURSOR FOR
SELECT         c1_otp.otp_otp2cd, c1_obtp.obtp_obtpcd
FROM             c1_otp INNER JOIN
                          c1_obtp ON c1_otp.otp_otp1cd = c1_obtp.obtp_otp1cd
WHERE         (c1_otp.otp_otp1cd = @otp1cd)
ORDER BY  c1_otp.otp_otp2cd, c1_obtp.obtp_obtpcd
OPEN otp_Cursor
FETCH NEXT FROM otp_Cursor
    into @otp2cd, @btpcd
WHILE @@FETCH_STATUS = 0
BEGIN
set @amt=0
set @mnt=0
SELECT         @amt=SUM(c1_od.od_amt)
FROM             c1_order INNER JOIN
                          c1_od ON c1_order.o_syscd = c1_od.od_syscd AND 
                          c1_order.o_custno = c1_od.od_custno AND 
                          c1_order.o_otp1cd = c1_od.od_otp1cd AND 
                          c1_order.o_otp1seq = c1_od.od_otp1seq
WHERE         (c1_order.o_otp1cd =@otp1cd) AND (c1_order.o_otp2cd = @otp2cd) AND 
                          (c1_order.o_date>=@date1) and (c1_order.o_date<=@date2) AND (c1_od.od_btpcd=@btpcd)
SELECT         @mnt=SUM(c1_ramt.ra_mnt)
FROM             c1_order INNER JOIN
                          c1_od ON c1_order.o_syscd = c1_od.od_syscd AND 
                          c1_order.o_custno = c1_od.od_custno AND 
                          c1_order.o_otp1cd = c1_od.od_otp1cd AND 
                          c1_order.o_otp1seq = c1_od.od_otp1seq INNER JOIN
                          c1_ramt ON c1_od.od_syscd = c1_ramt.ra_syscd AND 
                          c1_od.od_custno = c1_ramt.ra_custno AND 
                          c1_od.od_otp1cd = c1_ramt.ra_otp1cd AND 
                          c1_od.od_otp1seq = c1_ramt.ra_otp1seq AND 
                          c1_od.od_oditem = c1_ramt.ra_oditem
WHERE         (c1_order.o_otp1cd = @otp1cd) AND (c1_order.o_otp2cd = @otp2cd) AND 
                          (c1_order.o_date>=@date1) and (c1_order.o_date<=@date2) AND (c1_od.od_btpcd=@btpcd)
if @mnt=NULL
 set @mnt=0
if @amt=NULL
 set @amt=0
INSERT INTO tmp_statistics
                          (tmp_otp1cd, tmp_otp2cd, tmp_btpcd, tmp_param1, tmp_param2)
VALUES         (@otp1cd, @otp2cd, @btpcd, @amt,  @mnt)
FETCH NEXT FROM otp_Cursor
    into @otp2cd, @btpcd
END
CLOSE otp_Cursor
DEALLOCATE otp_Cursor
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_xml_to_detail    Script Date: 2002/11/19 上午 10:39:48 ******/
/****** Object:  Stored Procedure dbo.sp_c1_xml_to_detail    Script Date: 2002/5/2 AM 08:48:24 ******/
CREATE procedure sp_c1_xml_to_detail
as
declare	@syscd char(2),@custno char(6),@otp1cd char(2),@otp1seq char(3)
declare @ptrval varbinary(16),@xml varchar(8000), @xml_1 varchar(8000)
DECLARE OrderXML_Cursor CURSOR FOR
 select o_syscd,o_custno,o_otp1cd,o_otp1seq, CONVERT(varchar(8000),o_xmldata)
 from c1_order
 where o_syscd='C1' and o_custno='000003' and @otp1cd='01' and @otp1seq='002'
OPEN OrderXML_Cursor
FETCH NEXT FROM OrderXML_Cursor
    into @syscd,@custno,@otp1cd,@otp1seq, @xml_1
WHILE @@FETCH_STATUS = 0
BEGIN
	set @xml = '<?xml version="1.0" encoding="big5" ?>'+@xml_1
	exec sp_order_to_detail @xml ,@syscd,@custno,@otp1cd,@otp1seq
FETCH NEXT FROM OrderXML_Cursor
    into @syscd,@custno,@otp1cd,@otp1seq, @xml_1
END
CLOSE OrderXML_Cursor
DEALLOCATE OrderXML_Cursor

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_xml_to_detail]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c1_xml_to_detail]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_ORCounts_stat2b    Script Date: 2002/11/19 上午 10:39:48 ******/
CREATE PROCEDURE dbo.sp_c2_ORCounts_stat2b  ( @bkcd char(2), @yyyymm char(6) )  
as
begin 
set nocount on

SELECT         TOP 100 PERCENT c2_cont.cont_contno, c2_cont.cont_mfrno,
                          RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd,
                          RTRIM(mtp.mtp_nm) AS mtp_nm, COUNT(c2_or.or_unpubcnt)
                          AS UnPubCounts, c2_cont.cont_sdate, c2_cont.cont_edate,
                          SUBSTRING(c2_cont.cont_sdate, 1, 4)
                          + '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6)
                          + ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4)
                          + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate,
		c2_cont.cont_conttp, c2_or.or_fgmosea
FROM             c2_cont INNER JOIN
                          c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND
                          c2_cont.cont_contno = c2_or.or_contno INNER JOIN
                          mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN
                          mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno
WHERE         (c2_cont.cont_fgclosed = '0') AND (c2_cont.cont_contno NOT IN
                              (SELECT DISTINCT c2_pub.pub_contno
                                FROM              c2_pub
                                WHERE          c2_pub.pub_yyyymm = @yyyymm)) AND
                          (c2_or.or_unpubcnt > 0) AND (c2_cont.cont_fgcancel = '0') AND
                          (c2_cont.cont_fgtemp = '0')
                           AND (c2_cont.cont_bkcd = @bkcd) 
GROUP BY  c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm,
                          c2_or.or_mtpcd, mtp.mtp_nm, c2_cont.cont_sdate,
                          c2_cont.cont_edate, c2_cont.cont_conttp, c2_or.or_fgmosea
ORDER BY  c2_or.or_mtpcd, c2_cont.cont_contno

set nocount off
end
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_ORMtpCounts_stat2b    Script Date: 2002/11/19 上午 10:39:48 ******/
/* 11/18/2002 modify, 新增平廣標籤(當月未刊登)資料至 wk_c2_rp3 */
CREATE PROCEDURE dbo.sp_c2_ORMtpCounts_stat2b  ( @bkcd char(2), @conttp char(2), @fgmosea char(1), @yyyymm char(6) )
as
begin
set nocount on


/* 測試資料用
declare @bkcd char(2), @conttp char(2), @fgmosea char(1), @yyyymm char(6)
select @bkcd = '02'
select @conttp = '01'
select @fgmosea = '0'
select @yyyymm = '200211'
*/

------Transaction
begin  distributed transaction  tran_1


/* 刪除 tmp_statMachRate */
delete wk_c2_rp3


DECLARE  MtpUnPubCounts_cursor  CURSOR FOR
	SELECT         DISTINCT dbo.c2_cont.cont_contno, dbo.c2_or.or_oritem, dbo.c2_or.or_unpubcnt,
		 dbo.c2_or.or_fgmosea, dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm,
		RTRIM(dbo.book.bk_nm) AS bk_nm,
                          CASE WHEN dbo.c2_cont.cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName
	FROM             dbo.c2_cont INNER JOIN
                          dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND
                          dbo.c2_cont.cont_contno = dbo.c2_or.or_contno INNER JOIN
                          dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd  INNER JOIN
                          dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd
	WHERE         (dbo.c2_cont.cont_fgclosed = '0')  AND (dbo.c2_cont.cont_fgcancel = '0') AND
                          (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_or.or_unpubcnt > 0) AND
                          (dbo.c2_cont.cont_contno NOT IN
                              (SELECT DISTINCT c2_pub.pub_contno
                                FROM              c2_pub
                                WHERE          c2_pub.pub_yyyymm = @yyyymm))
                          AND (c2_cont.cont_bkcd = @bkcd) AND (c2_cont.cont_conttp = @conttp)
                          AND (c2_or.or_fgmosea = @fgmosea)
	ORDER BY  dbo.c2_or.or_unpubcnt, dbo.c2_cont.cont_contno


/* open the cursor */
open MtpUnPubCounts_cursor


/* Declare some variables to hold results.*/
declare @iContno char(6), @iOrItem char(2), @iUnpubCnt int, @ifgmosea char(1)
declare @iMtpcd char(2), @iMtpName varchar(20)
declare @iBkName varchar(12), @iContptName varchar(12)



FETCH  NEXT FROM MtpUnPubCounts_cursor
 INTO @iContno,@iOrItem, @iUnpubCnt, @ifgmosea, @iMtpcd, @iMtpName, @iBkName, @iContptName


/* 若有 sc_cursor 資料, 則做以下之處理 */
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
	select @iContno, @iOrItem, @iUnpubCnt, @ifgmosea, @iMtpcd, @iMtpName, @iBkName, @iContptName

	/* 產生 tmp_statMachRate */
	INSERT wk_c2_rp3(contno, oritem, Unpubcnt, fgmosea, mtpcd, mtpnm, bknm, conttpnm )
	VALUES (@iContno, @iOrItem, @iUnpubCnt, @ifgmosea, @iMtpcd, @iMtpName, @iBkName, @iContptName )


	/* 讀下一筆 stat_cursor */
	FETCH  NEXT FROM MtpUnPubCounts_cursor
	INTO @iContno, @iOrItem, @iUnpubCnt, @ifgmosea, @iMtpcd, @iMtpName, @iBkName, @iContptName
END


CLOSE  MtpUnPubCounts_cursor
DEALLOCATE  MtpUnPubCounts_cursor


------Transaction
commit transaction  tran_1


set nocount off
end
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_add_1_ia_1    Script Date: 2002/11/19 上午 10:39:48 ******/
/* 發票開立單產生 一次付款: 找出某一合約之當月要開落版資料的發票開立單*/
/* pub_fginved 已開發票開立單註記default---' '  已挑選---'v'  已產生ia ---'1' */
CREATE proc dbo.sp_c2_add_1_ia_1 (@syscd char(02), @contno char(6), @imseq char(2))  
as
begin 
set nocount on
/*declare @syscd    char(02), @contno char(6), @imseq char(2)
SELECT @syscd = 'C2'
select @contno = '000027'
select @imseq = '01'*/
DECLARE   @cname char(10), @tel char(12), @edate char(8), @yy char(02)
select @edate = convert(char(8),getdate(),112)
select @yy = substring(@edate,3,2)
/*讀出c2_cont*/
declare @cnt int
SELECT @cnt = count(
          c2_pub.pub_pubseq)  
          
    FROM c2_pub  
   WHERE c2_pub.pub_fginved = 'v' and
           c2_pub.pub_contno = @contno and 
           c2_pub.pub_imseq = @imseq   
select @cnt
if @cnt = 0 
begin
   return
end 
 SELECT @cname = srspn_cname,   
                @tel = srspn_tel 
    FROM c2_cont,   
                 srspn  
   WHERE ( c2_cont.cont_empno = srspn.srspn_empno ) and      
          ( c2_cont.cont_syscd  =  @syscd ) AND  
         ( c2_cont.cont_contno  =  @contno )    
DECLARE  pub_cursor  CURSOR FOR  
  SELECT c2_pub.pub_yyyymm, 
          c2_pub.pub_pubseq,  
         c2_pub.pub_imseq,   
         c2_pub.pub_adamt,   
         c2_pub.pub_chgamt,   
         c2_pub.pub_projno,   
         c2_pub.pub_costctr,     
         c2_pub.pub_bkcd  
    FROM c2_pub  
   WHERE c2_pub.pub_fginved = 'v' and
           c2_pub.pub_contno = @contno and 
           c2_pub.pub_imseq = @imseq   
/* open the cursor */
open pub_cursor
/* Declare some variables to hold results.*/
DECLARE @yyyymm char(6),  @pubseq char(02),     
          @adamt real,   
          @chgamt real,   
          @projno char(10),   
          @costctr char(7),    
          @bkcd  char(2),
          @tmp_imseq char(02)
declare  @im_fgitri char(2),   
        @im_nm   char(30),   
        @im_jbti   char(12),   
        @im_zip    char(5),   
        @im_addr   char(120),   
        @im_tel    char(30),   
        @im_invcd  char(1),   
        @im_taxtp  char(1),   
        @im_mfrno char(10)
declare @amt real, @amtnet real
declare @desc char(100), @uprice real, @iaditem int, @s_iaditem char(3)
declare @first_rec int, @iaseq int, @s_iaseq char(6)
declare @iano char(8), @refno char(10)
/* get the first row from the cursor */
FETCH  NEXT FROM  pub_cursor
 INTO @yyyymm, @pubseq, @imseq, @adamt, @chgamt, @projno, @costctr,    
          @bkcd
/* select @tmp_imseq = @imseq   */
begin  distributed transaction  tran_1
/*求發票主檔之銷售額、稅額、發票金額*/
select @iaseq = 0 
SELECT @iaseq =  convert(int, max(substring(ia.ia_iano,3,6))) 
  FROM ia  
where (substring(ia.ia_iano,1,2) = @yy) and 
(ia.ia_syscd = @syscd)
select @iaseq
if @iaseq <> null
begin
select @iaseq = @iaseq + 1
end 
else
  begin 
    select @iaseq = 1
  end  
select @s_iaseq =  convert(char(6), @iaseq) 
SELECT  @s_iaseq  = 
      CASE 
         WHEN @iaseq > 0 and @iaseq < 10 THEN '00000' + @s_iaseq
         WHEN @iaseq > 9 and @iaseq < 100 THEN '0000' + @s_iaseq   
         WHEN @iaseq >99 and @iaseq < 1000 THEN '000' + @s_iaseq
         WHEN @iaseq > 999 and @iaseq < 10000 THEN '00' + @s_iaseq
         WHEN @iaseq > 9999 and @iaseq < 100000 THEN '0' + @s_iaseq     
      END  
select @iano = @yy + @s_iaseq
select @refno = @syscd + @iano 
select @yy, @s_iaseq, @iano
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno  )
VALUES (@syscd, '', '', '', @iano, @refno, '', '', '', 0, 0, '', '', '', '', '', '', '', '', '0',  '', '', '', @cname, @tel, @syscd + @contno)
SELECT @iaditem =0
select @amt = 0
 
 
WHILE (@@FETCH_STATUS = 0)
BEGIN
                                    
SELECT @iaditem = @iaditem + 1
select @s_iaditem =  convert(char(3), @iaditem)
SELECT  @s_iaditem  = 
      CASE 
         WHEN @iaditem > 0 and @iaditem < 10 THEN '00' + @s_iaditem
         WHEN @iaditem > 9 and @iaditem < 100 THEN '0' + @s_iaditem   
      END  
SELECT @desc = 
CASE 
   WHEN @bkcd = '01' then '工材雜誌'
   WHEN @bkcd = '02' then '電材雜誌'
END
SELECT  @desc =  rtrim(ltrim(@desc)) + ' ' + substring( rtrim(ltrim(@yyyymm)),1,4) + '/' +  substring( rtrim(ltrim(@yyyymm)),5,2) + ' ' + '廣告費'
select @uprice = @adamt + @chgamt
select @amt = @amt + @uprice
SELECT @syscd, @iano, @s_iaditem, @contno, @yyyymm, @pubseq,  @projno, @costctr, @desc,  @uprice, @uprice
 
INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
VALUES (@syscd, @iano, @s_iaditem, @contno, @yyyymm, @pubseq, '',  @projno, @costctr, @desc,  1,  '' , @uprice, @uprice)   
FETCH  NEXT FROM  pub_cursor INTO
                                  @yyyymm, @pubseq, @imseq, @adamt, @chgamt, @projno, @costctr, @bkcd
END
SELECT  @im_fgitri =  im_fgitri, @im_nm =  im_nm, @im_jbti =  im_jbti, @im_zip = im_zip,
               @im_addr = im_addr, @im_tel =  im_tel, @im_invcd =  im_invcd, @im_taxtp = im_taxtp, 
               @im_mfrno = im_mfrno 
    FROM invmfr
    WHERE ( invmfr.im_syscd = @syscd ) AND  
         ( invmfr.im_contno = @contno ) AND  
         ( invmfr.im_imseq = @imseq )  
UPDATE ia  
     SET ia_mfrno =  @im_mfrno,
             ia_pyat = @amt,       
             ia_fgitri = @im_fgitri,
             ia_rnm = @im_nm,
             ia_raddr = @im_addr,
             ia_rzip = @im_zip,
             ia_rjbti = @im_jbti,
             ia_rtel = @im_tel,
             ia_invcd = @im_invcd,
             ia_taxtp = @im_taxtp 
WHERE ( ia.ia_syscd = @syscd ) AND
              ( ia.ia_iano = @iano ) 
update c2_pub
  set  pub_fginved = '1'
  WHERE c2_pub.pub_fginved = 'v' and
               c2_pub.pub_contno = @contno and
               c2_pub.pub_imseq = @imseq     
commit transaction  tran_1 
CLOSE  pub_cursor   
                                                                                                                                 
DEALLOCATE  pub_cursor
                       
                       
set nocount off            
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_add_ia    Script Date: 2002/11/19 上午 10:39:48 ******/
/* 本 sp 同 sp_c2_add_1_ia_1 */
/* 發票開立單產生 大批月結: 找出當月要開之落版資料的整批發票開立單*/
/* pub_fginved 已開發票開立單註記default---' '  已挑選---'v'  已產生ia ---'1' */
CREATE proc dbo.sp_c2_add_ia (@syscd char(02), @contno char(6), @imseq char(2), @iabdate char(6), @iabseq char(6))  
as
begin 
set nocount on
/*declare @syscd    char(02), @contno char(6), @imseq char(2)
SELECT @syscd = 'C2'
select @contno = '000027'
select @imseq = '01'
select @iabdate = '200207'
select @iabseq = '000001'
select @lempno = '800443'*/
DECLARE   @cname char(10), @tel char(12), @edate char(8), @yy char(02)
select @edate = convert(char(8),getdate(),112)
select @yy = substring(@edate,3,2)
/* 讀出 c2_cont */
declare @cnt int
SELECT @cnt = count(
          c2_pub.pub_pubseq)  
          
    FROM c2_pub  
   WHERE c2_pub.pub_fginved = 'v' and
           c2_pub.pub_contno = @contno and 
           c2_pub.pub_imseq = @imseq   
select @cnt
if @cnt = 0 
begin
   return
end 
 SELECT @cname = srspn_cname,   
                @tel = srspn_tel 
    FROM c2_cont,   
                 srspn  
   WHERE ( c2_cont.cont_empno = srspn.srspn_empno ) and      
          ( c2_cont.cont_syscd  =  @syscd ) AND  
         ( c2_cont.cont_contno  =  @contno )    
DECLARE  pub_cursor  CURSOR FOR  
  SELECT c2_pub.pub_yyyymm, 
          c2_pub.pub_pubseq,  
         c2_pub.pub_imseq,   
         c2_pub.pub_adamt,   
         c2_pub.pub_chgamt,   
         c2_pub.pub_projno,   
         c2_pub.pub_costctr,     
         c2_pub.pub_bkcd  
    FROM c2_pub  
   WHERE c2_pub.pub_fginved = 'v' and
           c2_pub.pub_contno = @contno and 
           c2_pub.pub_imseq = @imseq   
/* open the cursor */
open pub_cursor
/* Declare some variables to hold results.*/
DECLARE @yyyymm char(6),  @pubseq char(02),     
          @adamt real,   
          @chgamt real,   
          @projno char(10),   
          @costctr char(7),    
          @bkcd  char(2),
          @tmp_imseq char(02)
declare  @im_fgitri char(2),   
        @im_nm   char(30),   
        @im_jbti   char(12),   
        @im_zip    char(5),   
        @im_addr   char(120),   
        @im_tel    char(30),   
        @im_invcd  char(1),   
        @im_taxtp  char(1),   
        @im_mfrno char(10)
declare @amt real, @amtnet real
declare @desc char(100), @uprice real, @iaditem int, @s_iaditem char(3)
declare @first_rec int, @iaseq int, @s_iaseq char(6)
declare @iano char(8), @refno char(10)
/* get the first row from the cursor */
FETCH  NEXT FROM  pub_cursor
 INTO @yyyymm, @pubseq, @imseq, @adamt, @chgamt, @projno, @costctr,    
          @bkcd
/* select @tmp_imseq = @imseq   */
begin  distributed transaction  tran_1
/*求發票主檔之銷售額、稅額、發票金額*/
select @iaseq = 0 
SELECT @iaseq =  convert(int, max(substring(ia.ia_iano,3,6))) 
  FROM ia  
where (substring(ia.ia_iano,1,2) = @yy) and 
(ia.ia_syscd = @syscd)
select  @iaseq
if @iaseq <> null
begin
select @iaseq = @iaseq + 1
end 
else
  begin 
    select @iaseq = 1
  end  
select @s_iaseq =  convert(char(6), @iaseq) 
SELECT  @s_iaseq  = 
      CASE 
         WHEN @iaseq > 0 and @iaseq < 10 THEN '00000' + @s_iaseq
         WHEN @iaseq > 9 and @iaseq < 100 THEN '0000' + @s_iaseq   
         WHEN @iaseq >99 and @iaseq < 1000 THEN '000' + @s_iaseq
         WHEN @iaseq > 999 and @iaseq < 10000 THEN '00' + @s_iaseq
         WHEN @iaseq > 9999 and @iaseq < 100000 THEN '0' + @s_iaseq     
      END  
select @iano = @yy + @s_iaseq
select @refno = @syscd + @iano 
select @yy, @s_iaseq, @iano
/* 產生 ia */
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno, ia_iabdate, ia_iabseq  )
VALUES (@syscd, '', '', '', @iano, @refno, '', '', '', 0, 0, '', '', '', '', '', '', '', '', '0',  '', '', '', @cname, @tel, @syscd + @contno, @iabdate, @iabseq)
SELECT @iaditem =0
select @amt = 0
 
 
WHILE (@@FETCH_STATUS = 0)
BEGIN
                                    
SELECT @iaditem = @iaditem + 1
select @s_iaditem =  convert(char(3), @iaditem)
SELECT  @s_iaditem  = 
      CASE 
         WHEN @iaditem > 0 and @iaditem < 10 THEN '00' + @s_iaditem
         WHEN @iaditem > 9 and @iaditem < 100 THEN '0' + @s_iaditem   
      END  
SELECT @desc = 
CASE 
   WHEN @bkcd = '01' then '工材雜誌'
   WHEN @bkcd = '02' then '電材雜誌'
END
/*SELECT @desc = @desc + @yyyymm  + '廣告費' */
SELECT  @desc =  rtrim(ltrim(@desc)) + ' ' + substring( rtrim(ltrim(@yyyymm)),1,4) + '/' +  substring( rtrim(ltrim(@yyyymm)),5,2) + ' ' + '廣告費'
select @uprice = @adamt + @chgamt
select @amt = @amt + @uprice
SELECT @syscd, @iano, @s_iaditem, @contno, @yyyymm, @pubseq,  @projno, @costctr, @desc,  @uprice, @uprice
 
/* 產生 iad */
INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
VALUES (@syscd, @iano, @s_iaditem, @contno, @yyyymm, @pubseq, '',  @projno, @costctr, @desc,  1,  '' , @uprice, @uprice)   
FETCH  NEXT FROM  pub_cursor INTO
                                  @yyyymm, @pubseq, @imseq, @adamt, @chgamt, @projno, @costctr, @bkcd
END
SELECT  @im_fgitri =  im_fgitri, @im_nm =  im_nm, @im_jbti =  im_jbti, @im_zip = im_zip,
               @im_addr = im_addr, @im_tel =  im_tel, @im_invcd =  im_invcd, @im_taxtp = im_taxtp, 
               @im_mfrno = im_mfrno 
    FROM invmfr
    WHERE ( invmfr.im_syscd = @syscd ) AND  
         ( invmfr.im_contno = @contno ) AND  
         ( invmfr.im_imseq = @imseq )  
UPDATE ia  
     SET ia_mfrno =  @im_mfrno,
             ia_pyat = @amt,       
             ia_fgitri = @im_fgitri,
             ia_rnm = @im_nm,
             ia_raddr = @im_addr,
             ia_rzip = @im_zip,
             ia_rjbti = @im_jbti,
             ia_rtel = @im_tel,
             ia_invcd = @im_invcd,
             ia_taxtp = @im_taxtp 
WHERE ( ia.ia_syscd = @syscd ) AND
              ( ia.ia_iano = @iano ) 
/* 更新 c2_pub 之 pub_fginved 值 */
update c2_pub
  set  pub_fginved = '1'
  WHERE c2_pub.pub_fginved = 'v' and
               c2_pub.pub_contno = @contno and
               c2_pub.pub_imseq = @imseq     
/* 更新 c2_cont 之 cont_paidamt, cont_restamt 值 
    先抓出合約相關金額, 再做計算 */
declare @totamt real, @paidamt real, @restamt real
SELECT @totamt = cont_totamt,   
               @paidamt = cont_paidamt,
               @restamt = cont_restamt
    FROM c2_cont
   WHERE ( c2_cont.cont_syscd  =  @syscd ) AND  
         ( c2_cont.cont_contno  =  @contno ) 
select @totamt
select @paidamt
select @restamt
declare @NewPaidAmt real, @NewRestAmt real
select @NewPaidAmt = @paidamt+@amt
select @NewRestAmt = @totamt - @NewPaidAmt
select @NewPaidAmt
select @NewRestAmt
update c2_cont
  set  cont_paidamt = @NewPaidAmt, 
        cont_restamt =@NewRestAmt
  WHERE  c2_cont.cont_syscd = @syscd and
               c2_cont.cont_contno = @contno     
commit transaction  tran_1 
CLOSE  pub_cursor   
                                                                                                                                 
DEALLOCATE  pub_cursor
                       
                       
set nocount off            
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_contlist2_1    Script Date: 2002/11/19 上午 10:39:48 ******/
CREATE proc dbo.sp_c2_contlist2_1 (@bkcd char(2))
as
begin
set nocount on
declare @contno char(6)
/* 將 table 資料清空 */
delete from c2_contlist2
/* 讀出 c2_cont, c2_or 資料: 抓 @contno */
DECLARE  contor_cursor  CURSOR FOR
	SELECT DISTINCT c2_cont.cont_contno
	FROM             c2_cont INNER JOIN
	                          c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND
	                          c2_cont.cont_contno = c2_or.or_contno
	WHERE         (c2_cont.cont_bkcd = @bkcd)
	ORDER BY  c2_cont.cont_contno
/* open the cursor */
open contor_cursor
------Transaction
begin  distributed transaction  tran_1
FETCH  NEXT FROM  contor_cursor
  INTO @contno
/* 若有 contor_cursor 資料, 則做以下之處理 */
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE (@@FETCH_STATUS = 0)
BEGIN
	select @contno
	exec sp_c2_contlist2_2  @contno
	FETCH  NEXT FROM  contor_cursor
	  INTO @contno
END
commit transaction  tran_1
CLOSE  contor_cursor
DEALLOCATE  contor_cursor
set nocount off
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_contlist2_2    Script Date: 2002/11/19 上午 10:39:48 ******/
CREATE proc dbo.sp_c2_contlist2_2 ( @contno char(6) )
as
begin
set nocount on
/*
declare @contno char(6)
select  @contno = '000028'
*/
/* 讀出 c2_cont, c2_or 資料: 抓 or_nm, FullName */
DECLARE  contor_cursor_2  CURSOR FOR
	SELECT DISTINCT
                          c2_or.or_inm, CASE WHEN RTRIM(or_nm) <> '' THEN RTRIM(or_nm) ELSE  '(無指定)' END AS or_nm,
                          RTRIM(SUBSTRING(c2_or.or_inm, 1, 4)) + '-' + CASE WHEN RTRIM(or_nm) <> '' THEN RTRIM(or_nm) ELSE  '(無指定)' END AS FullName
	FROM             c2_or INNER JOIN
                          c2_cont ON c2_or.or_syscd = c2_cont.cont_syscd AND
                          c2_or.or_contno = c2_cont.cont_contno
	WHERE         (c2_or.or_syscd = 'C2') AND (c2_or.or_contno = @contno)
/* open the cursor */
open contor_cursor_2
/* Declare some variables to hold results.*/
declare @mfr_inm varchar(30), @orname varchar(30), @orfullname varchar(35), @ornamestr varchar(300), @orfullnamestr varchar(350)
select @ornamestr = ''
select @orfullnamestr = ''
FETCH  NEXT FROM  contor_cursor_2
  INTO @mfr_inm, @orname, @orfullname
/* 若有 contor_cursor_2 資料, 則做以下之處理 */
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE (@@FETCH_STATUS = 0)
BEGIN
	select @ornamestr = @ornamestr + @orname + ', '
	select @orfullnamestr = @orfullnamestr + @orfullname + ', '
	FETCH  NEXT FROM  contor_cursor_2
	  INTO @mfr_inm, @orname, @orfullname
END
/* 檢查資料 */
--select @mfr_inm
--select @orname
--select @orfullname
--select @ornamestr
--select @orfullnamestr
/* 去除 @ornamestr, @orfullnamestr 最末個 ',' 符號 */
declare @orfulname_len int, @orname_len int
 select @orname_len =  LEN(@ornamestr) - 1
 select @orfulname_len =  LEN(@orfullnamestr) - 1
 select @ornamestr = substring(@ornamestr, 1, @orname_len)
 select @orfullnamestr = substring(@orfullnamestr, 1, @orfulname_len)
select @ornamestr
select @orfullnamestr
/* 將值插入 table */
insert c2_contlist2(syscd, contno, ornamestr, orfullnamestr)
values ('C2', @contno, @ornamestr, @orfullnamestr)
CLOSE  contor_cursor_2
DEALLOCATE  contor_cursor_2
set nocount off
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_delete_ia_1    Script Date: 2002/11/19 上午 10:39:48 ******/
/* 發票開立單回復 一次付款:  */
CREATE PROCEDURE dbo.sp_c2_delete_ia_1
	@iano varchar(8), @syscd varchar(2), @contno varchar(6), @yyyymm char(6), @pubseq char(2)
	
AS
set nocount on
------刪除iad
delete iad where iad_syscd=@syscd and iad_iano= @iano
------刪除ia
delete ia where ia_syscd=@syscd and ia_iano= @iano
----- 發票開立單/預開發票未繳款之註銷發票 Recovery
----- c2_pub 中 set pub_fginved=' '
update c2_pub set pub_fginved=' ' where pub_syscd=@syscd and pub_contno=@contno and pub_yyyymm=@yyyymm and pub_pubseq=@pubseq

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_delete_ia_all    Script Date: 2002/11/19 上午 10:39:48 ******/
/* 發票開立單回復 大批月結: 找出某一批發票開立單 */
CREATE PROCEDURE dbo.sp_c2_delete_ia_all
	@iabdate char(6), @iabseq char(6)
as
begin
set nocount on
/*
declare @iabdate char(6), @iabseq char(6)
select @iabdate = '200208'
select @iabseq = '000001'
*/
/* 讀出 c2_cont, invmfr 資料: 抓 @syscd, @iano, @pyat, @contno */
DECLARE ia_cursor CURSOR FOR
	SELECT         ia_syscd, RTRIM(ia_iano) AS ia_iano, ia_pyat,  RTRIM(ia_contno) AS ia_contno
	FROM             ia
	WHERE         (ia.ia_status = ' ') AND (ia.ia_syscd = 'C2') AND
                          (ia.ia_iabdate = @iabdate) AND (ia.ia_iabseq = @iabseq)
/* open the cursor */
open ia_cursor
------Transaction
begin  distributed transaction  tran_1
/* Declare some variables to hold results.*/
declare	@syscd char(2), @iano char(8), @pyat real, @contno char(13)
FETCH  NEXT FROM  ia_cursor
 INTO @syscd, @iano, @pyat, @contno
--select @contno = substring(@contno, 3, 6)
/* 若有 ia_cursor 資料, 則做以下之處理 */
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
	/* 檢查 ia_cursor 資料 */
	select @syscd
	select @iano
	select @pyat
	select @contno
	/* for loop 刪除&更新 detail */
	DECLARE iad_cursor CURSOR FOR
		SELECT          RTRIM(iad_fk1) AS iad_fk1,
				  RTRIM(iad_fk2) AS iad_fk2,
	                          RTRIM(iad_fk3) AS iad_fk3
		FROM             iad
		WHERE         (iad_syscd = 'C2') AND (iad_iano = @iano)
	open iad_cursor
	/* Declare some variables to hold results.*/
	declare	@fk1 char(10), @fk2 char(10), @fk3 char(10)
	FETCH  NEXT FROM  iad_cursor
	 INTO @fk1, @fk2, @fk3
	/* 若有 iad_cursor 資料, 則做以下之處理 */
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		/* 檢查 iad_cursor 資料 */
		--select @iano
		select @fk1
		select @fk2
		select @fk3
		------ 更新 c2_pub 之 pub_fginved= 值為 ' '
		UPDATE        c2_pub
		SET                  pub_fginved = ' '
		WHERE         (pub_syscd = @syscd)
			        AND (pub_contno = RTRIM(@fk1))
			        AND (pub_yyyymm = RTRIM(@fk2))
		                AND (pub_pubseq = RTRIM(@fk3))
		FETCH  NEXT FROM  iad_cursor
			 INTO @fk1, @fk2, @fk3
	END
	CLOSE  iad_cursor
	DEALLOCATE  iad_cursor
	------ 刪除iad
	delete iad where iad_syscd=@syscd
			 and iad_iano= RTRIM(@iano)
	------ 更新 c2_cont 之 合約相關金額: cont_paidamt, cont_restamt 值
	update c2_cont set cont_paidamt=cont_paidamt-@pyat, cont_restamt=cont_restamt+@pyat
		where cont_syscd=@syscd and cont_contno=RTRIM(substring(@contno, 3, 6))
	select cont_paidamt, cont_restamt from c2_cont
		where cont_syscd=@syscd and cont_contno=RTRIM(substring(@contno, 3, 6))
	------ 刪除ia
	delete ia where ia_syscd=@syscd and ia_status= ' '
			and ia_iano=RTRIM(@iano)
	------ 讀下一筆 ia
	------ This is executed as long as the previous fetch succeeds.
	FETCH  NEXT FROM  ia_cursor
		 INTO @syscd, @iano, @pyat, @contno
END
------ 刪除iab
delete iab where iab_syscd=@syscd
		and iab_iabdate=@iabdate
		and iab_iabseq=@iabseq
commit transaction  tran_1
CLOSE  ia_cursor
DEALLOCATE  ia_cursor
set nocount off
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_getad_2    Script Date: 2002/11/19 上午 10:39:48 ******/
CREATE proc dbo.sp_c2_getad_2 ( @contno char(6) )
as
begin
set nocount on
/* 讀出 c2_cont, c2_pub 資料: 抓 pub_yyyymm */
DECLARE  getad_cursor_2  CURSOR FOR
  SELECT c2_pub.pub_yyyymm
    FROM c2_cont,
         c2_pub
   WHERE ( c2_cont.cont_contno = c2_pub.pub_contno ) and
         ( c2_cont.cont_syscd = c2_pub.pub_syscd ) and
         ( ( c2_cont.cont_contno = @contno )  )
/* open the cursor */
open getad_cursor_2
/* Declare some variables to hold results.*/
declare @pubmm varchar(6), @pubmmstr varchar(216)
select @pubmmstr = ''
FETCH  NEXT FROM  getad_cursor_2 INTO
         @pubmm
/* 若有 getad_cursor_2 資料, 則做以下之處理 */
WHILE (@@FETCH_STATUS = 0)
BEGIN
	select @pubmmstr = @pubmmstr + substring(@pubmm,1,4) + '/' +  substring(@pubmm,5,2)  + ','
	FETCH  NEXT FROM  getad_cursor_2 INTO
         @pubmm
END
/* 去除 @pubmmstr 最末個 ',' 符號 */
declare @i_len int
 select @i_len =  LEN(@pubmmstr) - 1
 select @pubmmstr = substring(@pubmmstr, 1, @i_len)
/* 將值插入 table */
insert c2_getad(syscd, contno,pubmmstr)
values ('C2', @contno, @pubmmstr)
CLOSE  getad_cursor_2
DEALLOCATE  getad_cursor_2
set nocount off
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c2_getad_2]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c2_getad_2]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_pubfm_lbl_unpub    Script Date: 2002/11/19 上午 10:39:48 ******/
CREATE PROCEDURE dbo.sp_c2_pubfm_lbl_unpub  ( @bkcd char(2), @conttp char(2), @fgmosea char(1), @yyyymm char(6) )  
as
begin 
set nocount on
SELECT         DISTINCT dbo.c2_cont.cont_contno, dbo.c2_cont.cont_sdate, 
                          dbo.c2_cont.cont_edate, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) 
                          + '/' + SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6) 
                          + ' ~ ' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) 
                          + '/' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate, 
                          RTRIM(dbo.c2_or.or_inm) AS or_inm, RTRIM(dbo.c2_or.or_nm) AS or_nm, 
                          RTRIM(dbo.c2_or.or_jbti) AS or_jbti, RTRIM(dbo.c2_or.or_zip) AS or_zip, 
                          RTRIM(dbo.c2_or.or_addr) AS or_addr, dbo.c2_or.or_unpubcnt, 
                          dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm,
		RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, dbo.c2_or.or_oritem, 
		RTRIM(dbo.book.bk_nm) AS bk_nm, 
                          CASE WHEN dbo.c2_cont.cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName
FROM             dbo.c2_cont INNER JOIN
                          dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND 
                          dbo.c2_cont.cont_contno = dbo.c2_or.or_contno INNER JOIN
                          dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd  INNER JOIN
                          dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd
WHERE         (dbo.c2_cont.cont_fgclosed = '0')  AND (dbo.c2_cont.cont_fgcancel = '0') AND 
                          (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_or.or_unpubcnt > 0) AND 
                          (dbo.c2_cont.cont_contno NOT IN
                              (SELECT DISTINCT c2_pub.pub_contno
                                FROM              c2_pub
                                WHERE          c2_pub.pub_yyyymm = @yyyymm))
                          AND (c2_cont.cont_bkcd = @bkcd) AND (c2_cont.cont_conttp = @conttp)
                          AND (c2_or.or_fgmosea = @fgmosea)  
ORDER BY  dbo.c2_or.or_unpubcnt, dbo.c2_cont.cont_contno
set nocount off
end
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_rp1    Script Date: 2002/11/19 上午 10:39:48 ******/
/* 2002/10/22 修正 wk_c2_rp1_1 & wk_c2_rp1_5 & wk_c2_rp1 新增 'cont_fgcancel' (註銷註記), 輸出結果不包含已註銷之資料 */
/* 2002/8/9 修正 wk_c2_rp1_2 & wk_c2_rp1 由 'cont_adamt' (已落版總廣告金額) 改為 'pub_totamt' (當月落版金額) */
CREATE proc dbo.sp_c2_rp1(@yyyymm  char(6), @bkcd char(2) )
As

begin 
set nocount on

begin distributed transaction create_trans

   
/* declare  @yyyymm char(06), @bkcd char(02)
select @yyyymm = '200207'
select @bkcd = '01'  */


delete from wk_c2_rp1_1

insert into wk_c2_rp1_1( mark,   
          cont_syscd,   
          cont_contno,   
          mfr_inm,   
          cont_aunm,   
          cont_autel,   
          cont_aufax,   
          cont_aucell,   
          cont_sdate,   
          cont_edate,   
          cont_restjtm,   
          cont_resttm,   
          cont_adamt,   
          cont_pubclrtm,   
          cont_pubmenotm,   
          cont_pubgetclrtm,   
          pubmmstr, 
          cont_empno,
          cont_fgcancel  )

SELECT mark1  = 
          case
              when a.cont_edate =  @yyyymm then '*'
              else ''
          end ,   
          a.cont_syscd,   
          a.cont_contno,   
          b.mfr_inm,   
          a.cont_aunm,   
          a.cont_autel,   
          a.cont_aufax,   
          a.cont_aucell,   
          a.cont_sdate,   
          a.cont_edate,   
          a.cont_restjtm,   
          a.cont_resttm,   
          a.cont_adamt,   
          a.cont_clrtm - a.cont_restclrtm as clrtm,   
          a.cont_menotm - a.cont_restmenotm as menotm,   
          a.cont_getclrtm - a.cont_restgetclrtm as getclrtm,   
          c.pubmmstr,
          a.cont_empno,
          a.cont_fgcancel
    FROM c2_cont  a,   
         c2_getad   c,   
         mfr   b  
   WHERE (  a.cont_syscd *= c.syscd) and  
         (  a.cont_contno *= c.contno) and  
         (  a.cont_mfrno *=   b.mfr_mfrno) and  
         ( (  a.cont_fgclosed = '0' ) AND  
         (  a.cont_bkcd = @bkcd ) )    

delete  from wk_c2_rp1_2
insert into wk_c2_rp1_2( pub_syscd,   
          pub_contno,   
          pub_yyyymm,   
          pub_pubseq,   
          ltp_nm,   
          pgs_nm,   
          clr_nm,   
          pub_fggot,   
          pub_origjno,   
          pub_chgjno,   
          pub_drafttp,   
          lp_priorseq,
          pub_totamt  )

SELECT a.pub_syscd,   
         a.pub_contno,   
         a.pub_yyyymm,   
         a.pub_pubseq,   
         b.ltp_nm,   
         d.pgs_nm,   
         c.clr_nm,   
         a.pub_fggot,   
         a.pub_origjno,   
         a.pub_chgjno,  
         pub_drafttp = 
          case 
             when a.pub_drafttp = '2'  then 'v'
             else ''
          end ,   
         f.lp_priorseq,
         a.pub_adamt+a.pub_chgamt AS pub_totamt
    FROM c2_pub  a,   
         c2_ltp  b,   
         c2_clr c,   
         c2_pgsize d,   
         c2_cont  e,   
         c2_lprior  f  
   WHERE ( a.pub_ltpcd = b.ltp_ltpcd ) and  
         ( a.pub_clrcd = c.clr_clrcd ) and  
         ( a.pub_pgscd = d.pgs_pgscd ) and  
         ( e.cont_syscd = a.pub_syscd ) and  
         ( e.cont_contno = a.pub_contno ) and  
         ( e.cont_bkcd = f.lp_bkcd ) and  
         ( c.clr_clrcd = f.lp_clrcd ) and  
         ( b.ltp_ltpcd = f.lp_ltpcd ) and  
         ( d.pgs_pgscd = f.lp_pgscd ) and  
         ( ( e.cont_fgclosed = '0' ) AND  
         ( e.cont_bkcd = @bkcd) and
       ( a.pub_yyyymm = @yyyymm) )
    
  delete from wk_c2_rp1_3
  insert into wk_c2_rp1_3(cont_syscd,   
         cont_contno,   
         pub_yyyymm,   
         pubcnt)  
    SELECT a.cont_syscd,   
         a.cont_contno,   
         b.pub_yyyymm,   
         count(b.pub_pubseq)  
    FROM c2_cont  a,   
         c2_pub  b  
   WHERE ( a.cont_syscd = b.pub_syscd ) and  
         ( a.cont_contno = b.pub_contno ) and  
         ( ( a.cont_fgclosed = '0' ) AND  
         ( b.pub_yyyymm = @yyyymm) )   
GROUP BY a.cont_syscd,   
         a.cont_contno,   
         b.pub_yyyymm  
ORDER BY a.cont_syscd ASC,   
         a.cont_contno ASC,   
         b.pub_yyyymm ASC  

delete  from wk_c2_rp1_4 
insert into wk_c2_rp1_4(cont_contno, prior_per_cont) 
 SELECT b.cont_contno,   
         min(c.lp_priorseq ) as prior_per_cont  
    FROM c2_pub  a,   
         c2_cont       b,   
         c2_lprior      c  
   WHERE ( a.pub_syscd = b.cont_syscd ) and  
         ( a.pub_ltpcd = c.lp_ltpcd ) and  
         ( a.pub_clrcd = c.lp_clrcd ) and  
         ( a.pub_pgscd = c.lp_pgscd ) and  
         ( a.pub_contno = b.cont_contno ) and  
         ( ( a.pub_yyyymm = @yyyymm) AND  
         ( b.cont_bkcd = @bkcd ) )   
GROUP BY b.cont_contno  
ORDER BY b.cont_contno ASC 

delete from wk_c2_rp1_5
insert into wk_c2_rp1_5( mark,   
          cont_syscd,   
          cont_contno,   
          mfr_inm,   
          cont_aunm,   
          cont_autel,   
          cont_aufax,   
          cont_aucell,   
          cont_sdate,   
          cont_edate,   
          cont_restjtm,   
          cont_resttm,   
          cont_adamt,   
          cont_pubclrtm,   
          cont_pubmenotm,   
          cont_pubgetclrtm,   
          pubmmstr,   
          pubcnt,   
          prior_per_cont, 
          cont_empno,
         cont_fgcancel  )
 SELECT a.mark,   
         a.cont_syscd,   
         a.cont_contno,   
         a.mfr_inm,   
         a.cont_aunm,   
         a.cont_autel,   
         a.cont_aufax,   
         a.cont_aucell,   
         a.cont_sdate,   
         a.cont_edate,   
         a.cont_restjtm,   
         a.cont_resttm,   
         a.cont_adamt,   
         a.cont_pubclrtm,   
         a.cont_pubmenotm,   
         a.cont_pubgetclrtm,   
         a.pubmmstr,   
         b.pubcnt,   
         c.prior_per_cont,
         a.cont_empno,
         a.cont_fgcancel
    FROM wk_c2_rp1_1 a,   
         wk_c2_rp1_3 b,   
         wk_c2_rp1_4 c  
   WHERE ( a.cont_syscd *= b.cont_syscd) and  
         ( a.cont_contno *= b.cont_contno) and  
         ( a.cont_contno *= c.cont_contno) and  
         ( ( a.cont_sdate <= @yyyymm) AND  
         ( a.cont_edate >= @yyyymm) )   
ORDER BY c.prior_per_cont ASC,   
         a.cont_contno ASC      

delete from wk_c2_rp1
insert into wk_c2_rp1(  mark,   
           cont_syscd,   
           cont_contno,   
           mfr_inm,   
           cont_aunm,   
           cont_autel,   
           cont_aufax,   
           cont_aucell,   
           cont_sdate,   
           cont_edate,   
           cont_restjtm,   
           cont_resttm,   
           cont_adamt,   
           cont_pubclrtm,   
           cont_pubmenotm,   
           cont_pubgetclrtm,   
           pubmmstr,   
           pubcnt,   
           prior_per_cont,   
           pub_yyyymm,   
           pub_pubseq,   
           ltp_nm,   
           pgs_nm,   
           clr_nm,   
           pub_fggot,   
           pub_origjno,   
           pub_chgjno,   
           pub_drafttp,   
           lp_priorseq, 
           cont_empno,
           pub_totamt,
           cont_fgcancel  )

 SELECT a.mark,   
         a.cont_syscd,   
         a.cont_contno,   
         a.mfr_inm,   
         a.cont_aunm,   
         a.cont_autel,   
         a.cont_aufax,   
         a.cont_aucell,   
         a.cont_sdate,   
         a.cont_edate,   
         a.cont_restjtm,   
         a.cont_resttm,   
         a.cont_adamt,   
         a.cont_pubclrtm,   
         a.cont_pubmenotm,   
         a.cont_pubgetclrtm,   
         a.pubmmstr,   
         c.pubcnt,   
         '' as a,   
         b.pub_yyyymm,   
         b.pub_pubseq,   
         b.ltp_nm,   
         b.pgs_nm,   
         b.clr_nm,   
         b.pub_fggot,   
         b.pub_origjno,   
         b.pub_chgjno,   
         b.pub_drafttp,   
         b.lp_priorseq,
         a.cont_empno,
         b.pub_totamt,
         a.cont_fgcancel
    FROM wk_c2_rp1_1 a,   
         wk_c2_rp1_2 b,   
         wk_c2_rp1_3 c 
   WHERE ( a.cont_syscd *= b.pub_syscd) and  
         ( a.cont_contno *= b.pub_contno) and  
         ( a.cont_syscd *= c.cont_syscd) and  
         ( a.cont_contno *= c.cont_contno) and  
         ( ( a.cont_sdate > @yyyymm) OR  
         ( a.cont_edate < @yyyymm) ) 
ORDER BY a.cont_contno ASC    

insert into wk_c2_rp1(  mark,   
           cont_syscd,   
           cont_contno,   
           mfr_inm,   
           cont_aunm,   
           cont_autel,   
           cont_aufax,   
           cont_aucell,   
           cont_sdate,   
           cont_edate,   
           cont_restjtm,   
           cont_resttm,   
           cont_adamt,   
           cont_pubclrtm,   
           cont_pubmenotm,   
           cont_pubgetclrtm,   
           pubmmstr,   
           pubcnt,   
           prior_per_cont,   
           pub_yyyymm,   
           pub_pubseq,   
           ltp_nm,   
           pgs_nm,   
           clr_nm,   
           pub_fggot,   
           pub_origjno,   
           pub_chgjno,   
           pub_drafttp,   
           lp_priorseq,
           cont_empno,
           pub_totamt,
           cont_fgcancel )
 
 SELECT a.mark, 
         a.cont_syscd,   
         a.cont_contno,   
         a.mfr_inm,   
         a.cont_aunm,   
         a.cont_autel,   
         a.cont_aufax,   
         a.cont_aucell,   
         a.cont_sdate,   
         a.cont_edate,   
         a.cont_restjtm,   
         a.cont_resttm,   
         a.cont_adamt,   
         a.cont_pubclrtm,   
         a.cont_pubmenotm,   
         a.cont_pubgetclrtm,   
         a.pubmmstr,   
         a.pubcnt,   
         a.prior_per_cont,   
         b.pub_yyyymm,   
         b.pub_pubseq,   
         b.ltp_nm,   
         b.pgs_nm,   
         b.clr_nm,   
         b.pub_fggot,   
         b.pub_origjno,   
         b.pub_chgjno,   
         b.pub_drafttp,   
         b.lp_priorseq,
         a.cont_empno,
         b.pub_totamt,
         a.cont_fgcancel
    FROM wk_c2_rp1_5 a,   
         wk_c2_rp1_2 b  
   WHERE ( a.cont_syscd *=  b.pub_syscd) and  
         ( a.cont_contno *=  b.pub_contno)   
ORDER BY a.prior_per_cont ASC,   
         a.cont_contno ASC

commit transaction create_trans

set nocount off
end
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_rp2    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE proc dbo.sp_c2_rp2(@bkcd char(2), @yyyymm  char(6))
as
delete wk_c2_rp2
insert into  wk_c2_rp2(
         contno,
         yyyymm,
         pubseq,
         pgno,
         clr_nm,
         ltp_nm,
         pgs_nm,
         mfr_inm,
         fggot,
         srspn_cname,
         drafttp,
         fgrechg,
         unfgrechg,
         chgbk_nm,
         chgjno,
         chgjbkno,
         origbk_nm,
         origjno,
         origjbkno,
         njtpcd01,
         njtpcd02,
         njtpcd03,
         njtpcd04,
         njtpcd05,
         fgupdated,
         clrcd,
         empno,
         fgfixpg,
         lp_priorseq  )
 SELECT   a.cont_contno,
         b.pub_yyyymm,
         b.pub_pubseq,
         b.pub_pgno,
         d.clr_nm,
         e.ltp_nm,
         f.pgs_nm,
         c.mfr_inm,
         fggot =
          case
                  when  b.pub_fggot =  '0' then '否'
                  when   b.pub_fggot = '1' then '是'
                  else ''
          end,
         g.srspn_cname,
         b.pub_drafttp,
         fgrechg =
          case
                  when  b.pub_fgrechg =  '1' then 1
                  else 0
          end,
          unfgrechg =
          case
                  when  b.pub_fgrechg =  '0' then 1
                  else 0
           end,
          chgbk_nm =
          case  b.pub_chgbkcd
                  when     '01' then '工材雜誌'
                  when     '02' then '電材雜誌'
                  else ''
          end,
         b.pub_chgjno,
         b.pub_chgjbkno,
         origbk_nm =
          case  b.pub_origbkcd
                  when     '01' then '工材雜誌'
                  when     '02' then '電材雜誌'
                  else ''
          end,
         b.pub_origjno,
         b.pub_origjbkno,
        njtpcd01 =
          case
                  when  b.pub_njtpcd =  '01' then 1
                  else 0
          end,
        njtpcd02 =
          case
                  when  b.pub_njtpcd =  '02' then 1
                  else 0
          end,
        njtpcd03 =
          case
                  when  b.pub_njtpcd =  '03' then 1
                  else 0
          end,
        njtpcd04 =
          case
                  when  b.pub_njtpcd =  '04' then 1
                  else 0
          end,
        njtpcd05 =
          case
                  when  b.pub_njtpcd =  '05' then 1
                  else 0
          end,
          b.pub_fgupdated,
          b.pub_clrcd,
          a.cont_empno,
          fgfixpg =
          case  
                  when  b.pub_fgfixpg =  '0' then '否'
                  when   b.pub_fgfixpg = '1' then '是'
                  else ''
          end,
          h.lp_priorseq
    FROM c2_cont      a,
                c2_pub       b,
                mfr            c,
                c2_clr        d,
                c2_ltp        e,
                c2_pgsize   f,
                srspn         g,
	   c2_lprior    h
   WHERE ( a.cont_syscd = b.pub_syscd ) and
         ( a.cont_contno = b.pub_contno ) and
         ( a.cont_mfrno = c.mfr_mfrno ) and
         ( b.pub_ltpcd = e.ltp_ltpcd ) and
         ( b.pub_clrcd = d.clr_clrcd ) and
         ( b.pub_pgscd = f.pgs_pgscd ) and
         ( a.cont_empno = g.srspn_empno ) and
         ( b.pub_bkcd = h.lp_bkcd ) and
         ( b.pub_ltpcd = h.lp_ltpcd ) and
         ( b.pub_clrcd = h.lp_clrcd ) and
         ( b.pub_pgscd = h.lp_pgscd ) and
         ( (a.cont_bkcd = @bkcd) and
 ( b.pub_yyyymm =@yyyymm )  )
ORDER BY d.clr_clrcd ASC,
                      a.cont_contno ASC,
                      b.pub_pubseq ASC
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c3_add_ia    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE PROCEDURE dbo.sp_c3_add_ia
	@syscd char(2), @appno char(6), @imseq char(2), @iano char(8)
	
AS
begin
set nocount on
begin distributed transaction create_trans
declare  @im_fgitri char(2),   
        @im_nm   char(30),   
        @im_jbti   char(12),   
        @im_zip    char(5),   
        @im_addr   char(120),   
        @im_tel    char(30),   
        @im_invcd  char(1),   
        @im_taxtp  char(1),   
        @im_mfrno char(10),
		@im_amt real
declare @app_projno	char(10),
		@app_costctr char(7),
		@app_sdate	char(10),
		@app_edate	char(10)
declare @desc char(100), @uprice real, @iaditem int, @s_iaditem char(3)
declare @first_rec int, @iaseq int, @s_iaseq char(6)
SELECT  @im_fgitri =  im_fgitri, @im_nm =  im_nm, @im_jbti =  im_jbti, @im_zip = im_zip,
               @im_addr = im_addr, @im_tel =  im_tel, @im_invcd =  im_invcd, @im_taxtp = im_taxtp, 
               @im_mfrno = im_mfrno, @im_amt = im_amt 
    FROM c3_invmfr
    WHERE ( c3_invmfr.im_syscd = @syscd ) AND  
         ( c3_invmfr.im_appno = @appno ) AND  
         ( c3_invmfr.im_imseq = @imseq )
         
SELECT  @app_projno =  app_projno, @app_costctr =  app_costctr, 
		@app_sdate = SUBSTRING(app_sdate,1,4)+'/'+SUBSTRING(app_sdate,5,2)+'/'+SUBSTRING(app_sdate,7,2),
		@app_edate = SUBSTRING(app_edate,1,4)+'/'+SUBSTRING(app_edate,5,2)+'/'+SUBSTRING(app_edate,7,2)
    FROM c3_appf
    WHERE ( c3_appf.app_syscd = @syscd ) AND  
         ( c3_appf.app_appno = @appno )
select @desc='材料世界網訂閱'+@app_sdate+'~'+@app_edate
------insert ia
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno  )
VALUES (@syscd, '', '', '', @iano, @syscd + @iano, @im_mfrno, '', '', @im_amt, 0, '', '', @im_fgitri, @im_nm, @im_addr, @im_zip, @im_jbti, @im_tel, '0',  @im_invcd, @im_taxtp, '', '', '', @syscd + @appno)
------insert iad
INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
VALUES (@syscd, @iano, '001', @appno, @imseq, '', '',  @app_projno, @app_costctr, @desc,  1,  '' , 0, @im_amt)   
------將 c3_invmfr中之im_fgia='3'表示此筆資料已產生ia
update c3_invmfr
  set  im_fgia = '3'
    WHERE ( c3_invmfr.im_syscd = @syscd ) AND  
         ( c3_invmfr.im_appno = @appno ) AND  
         ( c3_invmfr.im_imseq = @imseq )
commit transaction create_trans
set nocount off
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c3_delete_appf    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE PROCEDURE dbo.sp_c3_delete_appf
	@syscd varchar(2), @appno varchar(6)
	
AS
begin
set nocount on
begin distributed transaction create_trans
------刪除c3_remail
delete c3_remail
  where rm_syscd=@syscd and rm_appno=@appno
------刪除c3_lost
delete c3_lost
  where lst_syscd=@syscd and lst_appno=@appno
------刪除c3_freebk
delete c3_freebk
  where fb_syscd=@syscd and fb_appno=@appno
------刪除c3_or
delete c3_or
  where or_syscd=@syscd and or_appno=@appno
------刪除c3_invmfr
delete c3_invmfr
  where im_syscd=@syscd and im_appno=@appno
------刪除c3_appf
delete c3_appf
  where app_syscd=@syscd and app_appno=@appno
commit transaction create_trans
set nocount off
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c3_delete_ia    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE PROCEDURE dbo.sp_c3_delete_ia
	@syscd varchar(2), @iano varchar(8), @appno varchar(6), @imseq varchar(2), @type varchar(1), @empno varchar(7)
	
AS
begin
set nocount on
begin distributed transaction create_trans
------刪除iad
delete iad where iad_syscd=@syscd and iad_iano= @iano
------刪除ia
delete ia where ia_syscd=@syscd and ia_iano= @iano
if @type='0' -----發票開立單Recovery
------c3_invmfr 中 set im_fgia='1' 
	update c3_invmfr set im_fgia='1', im_moduid=@empno where im_syscd=@syscd and im_appno=@appno and im_imseq=@imseq
if @type='1'	-----預開發票未繳款之註銷發票
------c3_invmfr 中 set im_fgia='1', im_modstatus='1'
	update c3_invmfr set im_fgia='1', im_modstatus='1', im_moduid=@empno where im_syscd=@syscd and im_appno=@appno and im_imseq=@imseq
commit transaction create_trans
set nocount off
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.sp_c4_add_1_ia_1    Script Date: 2002/11/19 上午 10:39:49 ******/
/*找出某一合約之為開發票之落版的發票開立單*/
/* pub_fginved 已開發票開立單註記default---' '  已挑選---'v'  已產生ia ---'1' */
CREATE proc dbo.sp_c4_add_1_ia_1 (@syscd char(02), @contno char(6), @imseq char(2))  
as
begin 
set nocount on
/*declare @syscd    char(02), @contno char(6), @imseq char(2)
SELECT @syscd = 'C4'
select @contno = '910009'
select @imseq = '02'  */
DECLARE   @cname char(10), @tel char(12), @edate0 char(8), @yy char(02)
select @edate0 = convert(char(8),getdate(),112)
select @yy = substring(@edate0,3,2)
/*讀出c2_cont*/
declare @cnt int
SELECT @cnt = count(c4_adrd.adrd_addate)  
    FROM c4_adr,   
         c4_adrd  
   WHERE ( c4_adr.adr_syscd = c4_adrd.adrd_syscd ) and  
         ( c4_adr.adr_contno = c4_adrd.adrd_contno ) and  
         ( c4_adr.adr_seq = c4_adrd.adrd_adrseq ) and  
         ( ( c4_adr.adr_syscd = 'C4' ) AND  
         ( c4_adr.adr_contno = '910009' ) AND  
         ( c4_adr.adr_imseq = '02' ) AND  
         ( c4_adrd.adrd_fginved = 'v' ) )    
   
select @cnt
if @cnt = 0 
begin
   return
end 
 SELECT @cname = srspn_cname,   
                @tel = srspn_tel 
    FROM c4_cont,   
                 srspn  
   WHERE ( c4_cont.cont_empno = srspn.srspn_empno ) and      
          ( c4_cont.cont_syscd  =  @syscd ) AND  
         ( c4_cont.cont_contno  =  @contno )    
DECLARE  adr_cursor  CURSOR FOR  
  SELECT b.adrd_addate,
          a.adr_seq,  
          a.adr_imseq,   
          b.adrd_adramt,   
          b.adrd_chgamt,
          b.adrd_desamt,   
        a.adr_projno,   
        a.adr_costctr   
    FROM c4_adr   a, 
          c4_adrd  b  
   WHERE ( a.adr_syscd = b.adrd_syscd ) and  
         ( a.adr_contno = b.adrd_contno ) and  
         ( a.adr_seq = b.adrd_adrseq ) and
          (  b.adrd_fginved = 'v' and
            a.adr_contno = @contno and 
            a.adr_imseq = @imseq   )
/* open the cursor */
open adr_cursor
/* Declare some variables to hold results.*/
DECLARE @date char(8), @adrseq char(02),     
          @adramt real,   
          @chgamt real, @desamt real,   
          @projno char(10),   
          @costctr char(7),    
          @tmp_imseq char(02)
declare  @im_fgitri char(2),   
        @im_nm   char(30),   
        @im_jbti   char(12),   
        @im_zip    char(5),   
        @im_addr   char(120),   
        @im_tel    char(30),   
        @im_invcd  char(1),   
        @im_taxtp  char(1),   
        @im_mfrno char(10)
declare @amt real, @amtnet real
declare @desc char(100), @uprice real, @iaditem int, @s_iaditem char(3)
declare @first_rec int, @iaseq int, @s_iaseq char(6)
declare @iano char(8), @refno char(10)
/* get the first row from the cursor */
FETCH  NEXT FROM  adr_cursor
 INTO @date, @adrseq, @imseq, @adramt, @chgamt, @desamt, @projno, @costctr
/* select @tmp_imseq = @imseq   */
begin  distributed transaction  tran_1
/*求發票主檔之銷售額、稅額、發票金額*/
select @iaseq = 0 
SELECT @iaseq =  convert(int, max(substring(ia.ia_iano,3,6))) 
  FROM ia  
where (substring(ia.ia_iano,1,2) = @yy) and 
(ia.ia_syscd = @syscd)
select @iaseq
if @iaseq <> null
begin
select @iaseq = @iaseq + 1
end 
else
  begin 
    select @iaseq = 1
  end  
select @s_iaseq =  convert(char(6), @iaseq) 
SELECT  @s_iaseq  = 
      CASE 
         WHEN @iaseq > 0 and @iaseq < 10 THEN '00000' + @s_iaseq
         WHEN @iaseq > 9 and @iaseq < 100 THEN '0000' + @s_iaseq   
         WHEN @iaseq >99 and @iaseq < 1000 THEN '000' + @s_iaseq
         WHEN @iaseq > 999 and @iaseq < 10000 THEN '00' + @s_iaseq
         WHEN @iaseq > 9999 and @iaseq < 100000 THEN '0' + @s_iaseq     
      END  
select @iano = @yy + @s_iaseq
select @refno = @syscd + @iano 
select @yy, @s_iaseq, @iano
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno  )
VALUES (@syscd, '', '', '', @iano, @refno, '', '', '', 0, 0, '', '', '', '', '', '', '', '', '0',  '', '', '', @cname, @tel, @syscd + @contno)
SELECT @iaditem =0
select @amt = 0
 
 
WHILE (@@FETCH_STATUS = 0)
BEGIN
                                    
SELECT @iaditem = @iaditem + 1
select @s_iaditem =  convert(char(3), @iaditem)
SELECT  @s_iaditem  = 
      CASE 
         WHEN @iaditem > 0 and @iaditem < 10 THEN '00' + @s_iaditem
         WHEN @iaditem > 9 and @iaditem < 100 THEN '0' + @s_iaditem   
      END  
SELECT @desc =  '材網廣告費' + @date 
select @uprice = @adramt + @chgamt + @desamt
select @amt = @amt + @uprice
SELECT @syscd, @iano, @s_iaditem, @contno, @date, @adrseq,  @projno, @costctr, @desc,  @uprice, @uprice
 
INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
VALUES (@syscd, @iano, @s_iaditem, @syscd, @contno, @adrseq, @date,  @projno, @costctr, @desc,  1,  '' , @uprice, @uprice)  
update c4_adrd
  set  adrd_fginved = '1'
  WHERE adrd_fginved = 'v' and
               adrd_contno = @contno and
              adrd_adrseq = @adrseq and
              adrd_addate = @date 
FETCH  NEXT FROM  adr_cursor
 INTO @date, @adrseq, @imseq, @adramt, @chgamt, @desamt, @projno, @costctr
END
SELECT  @im_fgitri =  im_fgitri, @im_nm =  im_nm, @im_jbti =  im_jbti, @im_zip = im_zip,
               @im_addr = im_addr, @im_tel =  im_tel, @im_invcd =  im_invcd, @im_taxtp = im_taxtp, 
               @im_mfrno = im_mfrno 
    FROM invmfr
    WHERE ( invmfr.im_syscd = @syscd ) AND  
         ( invmfr.im_contno = @contno ) AND  
         ( invmfr.im_imseq = @imseq )  
UPDATE ia  
     SET ia_mfrno =  @im_mfrno,
             ia_pyat = @amt,       
             ia_fgitri = @im_fgitri,
             ia_rnm = @im_nm,
             ia_raddr = @im_addr,
             ia_rzip = @im_zip,
             ia_rjbti = @im_jbti,
             ia_rtel = @im_tel,
             ia_invcd = @im_invcd,
             ia_taxtp = @im_taxtp 
WHERE ( ia.ia_syscd = @syscd ) AND
              ( ia.ia_iano = @iano ) 
    
commit transaction  tran_1 
CLOSE adr_cursor   
                                                                                                                                 
DEALLOCATE adr_cursor
                       
set nocount off            
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.sp_c4_add_batch_ia    Script Date: 2002/11/19 上午 10:39:49 ******/
/*找出某一合約之為開發票之落版的發票開立單*/
/* pub_fginved 已開發票開立單註記default---' '  已挑選---'v'  已產生ia ---'1' */
CREATE proc dbo.sp_c4_add_batch_ia(@syscd char(02), @contno char(6), @imseq char(2), @month char(6))  
as
begin 
set nocount on
/*declare @syscd    char(02), @contno char(6), @imseq char(2)
SELECT @syscd = 'C4'
select @contno = '999999'
select @imseq = '01'  */
DECLARE   @cname char(10), @tel char(12), @edate0 char(8), @yy char(02)
select @edate0 = convert(char(8),getdate(),112)
select @yy = substring(@edate0,3,2)
/*讀出廣告明細檔中該開的個數*/
declare @cnt int
SELECT @cnt = count(c4_adrd.adrd_addate)  
    FROM c4_adr,   
         c4_adrd  
   WHERE ( c4_adr.adr_syscd = c4_adrd.adrd_syscd ) and  
         ( c4_adr.adr_contno = c4_adrd.adrd_contno ) and  
         ( c4_adr.adr_seq = c4_adrd.adrd_adrseq ) and  
         ( c4_adr.adr_syscd = @syscd ) AND  
         ( c4_adr.adr_contno = @contno ) AND  
         ( c4_adr.adr_imseq = @imseq ) AND  
         ( c4_adrd.adrd_fginved = 'v' ) AND
         ( substring(c4_adrd.adrd_addate,1,6)<=@month)
/*秀出來*/   
select @cnt
/*沒資料就不做了*/
if @cnt = 0 
begin
   return
end
 /*找出業務*/
 SELECT @cname = srspn_cname,   
                @tel = srspn_tel 
    FROM c4_cont,   
                 srspn  
   WHERE ( c4_cont.cont_empno = srspn.srspn_empno ) and      
          ( c4_cont.cont_syscd  =  @syscd ) AND  
         ( c4_cont.cont_contno  =  @contno )    
/*開始做明細*/
DECLARE  adr_cursor  CURSOR FOR  
  SELECT b.adrd_addate,
          a.adr_seq,  
          a.adr_imseq,   
          b.adrd_adramt,   
          b.adrd_chgamt,
          b.adrd_desamt,   
        a.adr_projno,   
        a.adr_costctr   
    FROM c4_adr   a, 
          c4_adrd  b  
   WHERE ( a.adr_syscd = b.adrd_syscd ) and  
         ( a.adr_contno = b.adrd_contno ) and  
         ( a.adr_seq = b.adrd_adrseq ) and
          (  b.adrd_fginved = 'v' and
             substring(b.adrd_addate,1,6)<=@month and
            a.adr_contno = @contno and 
            a.adr_imseq = @imseq   )
/* open the cursor */
open adr_cursor
/* Declare some variables to hold results.*/
DECLARE @date char(8), @adrseq char(02),     
          @adramt real,   
          @chgamt real, @desamt real,   
          @projno char(10),   
          @costctr char(7),    
          @tmp_imseq char(02)
declare  @im_fgitri char(2),   
        @im_nm   char(30),   
        @im_jbti   char(12),   
        @im_zip    char(5),   
        @im_addr   char(120),   
        @im_tel    char(30),   
        @im_invcd  char(1),   
        @im_taxtp  char(1),   
        @im_mfrno char(10)
declare @amt real, @amtnet real
declare @desc char(100), @uprice real, @iaditem int, @s_iaditem char(3)
declare @first_rec int, @iaseq int, @s_iaseq char(6)
declare @iano char(8), @refno char(10)
/* get the first row from the cursor */
FETCH  NEXT FROM  adr_cursor
 INTO @date, @adrseq, @imseq, @adramt, @chgamt, @desamt, @projno, @costctr
/* select @tmp_imseq = @imseq   */
begin  distributed transaction  tran_1
/*求發票主檔之銷售額、稅額、發票金額*/
select @iaseq = 0 
SELECT @iaseq =  convert(int, max(substring(ia.ia_iano,3,6))) 
  FROM ia  
where (substring(ia.ia_iano,1,2) = @yy) and 
(ia.ia_syscd = @syscd)
select @iaseq
if @iaseq <> null
begin
select @iaseq = @iaseq + 1
end 
else
  begin 
    select @iaseq = 1
  end  
select @s_iaseq =  convert(char(6), @iaseq) 
SELECT  @s_iaseq  = 
      CASE 
         WHEN @iaseq > 0 and @iaseq < 10 THEN '00000' + @s_iaseq
         WHEN @iaseq > 9 and @iaseq < 100 THEN '0000' + @s_iaseq   
         WHEN @iaseq >99 and @iaseq < 1000 THEN '000' + @s_iaseq
         WHEN @iaseq > 999 and @iaseq < 10000 THEN '00' + @s_iaseq
         WHEN @iaseq > 9999 and @iaseq < 100000 THEN '0' + @s_iaseq     
      END  
select @iano = @yy + @s_iaseq
select @refno = @syscd + @iano 
select @yy, @s_iaseq, @iano
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno  )
VALUES (@syscd, '', '', '', @iano, @refno, '', '', '', 0, 0, '', '', '', '', '', '', '', '', '0',  '', '', '', @cname, @tel, @syscd + @contno)
SELECT @iaditem =0
select @amt = 0
 
 
WHILE (@@FETCH_STATUS = 0)
BEGIN
                                    
SELECT @iaditem = @iaditem + 1
select @s_iaditem =  convert(char(3), @iaditem)
SELECT  @s_iaditem  = 
      CASE 
         WHEN @iaditem > 0 and @iaditem < 10 THEN '00' + @s_iaditem
         WHEN @iaditem > 9 and @iaditem < 100 THEN '0' + @s_iaditem   
      END  
SELECT @desc =  '材網廣告費' + @date 
select @uprice = @adramt + @chgamt + @desamt
select @amt = @amt + @uprice
SELECT @syscd, @iano, @s_iaditem, @contno, @date, @adrseq,  @projno, @costctr, @desc,  @uprice, @uprice
 
INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
VALUES (@syscd, @iano, @s_iaditem, @syscd, @contno, @adrseq, @date,  @projno, @costctr, @desc,  1,  '' , @uprice, @uprice)  
update c4_adrd
  set  adrd_fginved = '1'
  WHERE adrd_fginved = 'v' and
               adrd_contno = @contno and
              adrd_adrseq = @adrseq and
              adrd_addate = @date
FETCH  NEXT FROM  adr_cursor
 INTO @date, @adrseq, @imseq, @adramt, @chgamt, @desamt, @projno, @costctr
END
SELECT  @im_fgitri =  im_fgitri, @im_nm =  im_nm, @im_jbti =  im_jbti, @im_zip = im_zip,
               @im_addr = im_addr, @im_tel =  im_tel, @im_invcd =  im_invcd, @im_taxtp = im_taxtp, 
               @im_mfrno = im_mfrno 
    FROM invmfr
    WHERE ( invmfr.im_syscd = @syscd ) AND  
         ( invmfr.im_contno = @contno ) AND  
         ( invmfr.im_imseq = @imseq )  
UPDATE ia  
     SET ia_mfrno =  @im_mfrno,
             ia_pyat = @amt,       
             ia_fgitri = @im_fgitri,
             ia_rnm = @im_nm,
             ia_raddr = @im_addr,
             ia_rzip = @im_zip,
             ia_rjbti = @im_jbti,
             ia_rtel = @im_tel,
             ia_invcd = @im_invcd,
             ia_taxtp = @im_taxtp 
WHERE ( ia.ia_syscd = @syscd ) AND
              ( ia.ia_iano = @iano ) 
    
commit transaction  tran_1 
CLOSE adr_cursor   
                                                                                                                                 
DEALLOCATE adr_cursor
                       
set nocount off            
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_order_to_detail    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE PROCEDURE dbo.sp_order_to_detail 
	@XML varchar(7000), @syscd varchar(2),
	@custno varchar(6), @otp1cd varchar(2),
	@otp1seq varchar(3)
AS
set nocount on
DECLARE @idoc	int
exec sp_xml_preparedocument @idoc OUTPUT, @XML
------訂單明細檔  c1_od
delete c1_od where od_syscd=@syscd and od_custno=@custno and od_otp1cd=@otp1cd
			and od_otp1seq=@otp1seq
insert c1_od 
select  系統代碼, 訂戶編號, 訂購類別一,訂單流水號=substring( 訂單流水號, 11,3),項次,
	訂閱起時=substring(訂閱起時,1,4)+substring(訂閱起時,6,2)+substring(訂閱起時,9,2),
	訂閱訖時=substring(訂閱訖時,1,4)+substring(訂閱訖時,6,2)+substring(訂閱訖時,9,2),
	書籍類別, 計劃代號, 成本中心, 備註, 金額, 
	新舊訂戶=CASE 新舊訂戶
			WHEN '新訂戶' THEN '0'
			WHEN '續訂戶' THEN '1'
			WHEN '舊訂戶' THEN '1'
			ELSE ''
		END
from openxml(@idoc, '/root/訂單明細/明細表', 2)
	with (系統代碼 varchar(2) '//訂單/系統代碼',
	訂戶編號	varchar(6) '//訂戶編號',
	訂購類別一	varchar(2) '//訂單/訂購類別一',
	訂單流水號	varchar(13) '//訂單流水號',
	項次		varchar(2),
	訂閱起時	varchar(10),
	訂閱訖時	varchar(10),
	書籍類別	varchar(2),
	計劃代號	varchar(10),
	成本中心	varchar(7),
	備註		varchar(30),
	金額		char(6),
	新舊訂戶	char(6)
	)
------收件人檔  c1_or
delete c1_or where or_syscd=@syscd and or_custno=@custno and or_otp1cd=@otp1cd
			and or_otp1seq=@otp1seq
insert c1_or 
select  系統代碼, 訂戶編號, 訂購類別一,訂單流水號=substring( 訂單流水號, 11,3),序號,
	公司名稱, 姓名,  職稱, 地址, 郵遞區號, 電話, 傳真, 手機, Email, 海外郵寄
from openxml(@idoc, '/root/收件人資料/收件人明細', 2)
	with (系統代碼 varchar(2) '//訂單/系統代碼',
	訂戶編號	varchar(6) '//訂戶編號',
	訂購類別一	varchar(2) '//訂單/訂購類別一',
	訂單流水號	varchar(13) '//訂單流水號',
	序號		varchar(2),
	公司名稱	varchar(30),
	姓名		varchar(30),
	職稱		varchar(12),
	地址		varchar(80),
	郵遞區號	char(5),
	電話		varchar(30),
	傳真		varchar(30),
	手機		varchar(30),
	Email		varchar(80),
	海外郵寄	char(1)
	)
------收件人數量檔  c1_ramt
delete c1_ramt where ra_syscd=@syscd and ra_custno=@custno and ra_otp1cd=@otp1cd
			and ra_otp1seq=@otp1seq
insert c1_ramt 
select  系統代碼, 訂戶編號, 訂購類別一,訂單流水號=substring( 訂單流水號, 11,3), 
	項次,序號,郵寄數量, 郵寄類別
from openxml(@idoc, '/root/訂單明細/明細表/投遞資料/收件人明細', 2)
	with (系統代碼 varchar(2) '//訂單/系統代碼',
	訂戶編號	varchar(6) '//訂戶編號',
	訂購類別一	varchar(2) '//訂單/訂購類別一',
	訂單流水號	varchar(13) '//訂單流水號',
	項次		varchar(2) '../../項次',
	序號		varchar(2),
	郵寄數量	varchar(4),
	郵寄類別	varchar(2)
	)
-----發票開立單檔
-----發票開立明細檔
-----繳款單檔
-----繳款單明細檔
exec sp_xml_removedocument @idoc

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_order_to_detail]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_order_to_detail]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_tmp_001    Script Date: 2002/11/19 上午 10:39:49 ******/
/****** Object:  Stored Procedure dbo.sp_tmp_001    Script Date: 2002/3/27 PM 01:45:54 ******/

CREATE PROCEDURE dbo.sp_tmp_001
	@syscd varchar(2), @otp1cd varchar(2), @mtpcd varchar(2), @btpcd varchar(2), @maildate varchar(6)
	
AS
begin
set nocount on
begin distributed transaction create_trans

if @syscd='C1'
  begin
------大宗標籤暫存檔
--truncate table tmp_label1
  delete tmp_label1
  if @btpcd='01' or @btpcd='02'
    begin
      insert tmp_label1 
      SELECT         dbo.c1_od.od_odid, dbo.c1_od.od_syscd, dbo.c1_od.od_custno, 
                          dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_oditem, 
		substring(dbo.c1_od.od_sdate,1,4)+'/'+substring(dbo.c1_od.od_sdate,5,2)+'/'+substring(dbo.c1_od.od_sdate,7,2),
		substring(dbo.c1_od.od_edate,1,4)+'/'+substring(dbo.c1_od.od_edate,5,2)+'/'+substring(dbo.c1_od.od_edate,7,2), 
		dbo.c1_ramt.ra_mnt, dbo.c1_ramt.ra_mtpcd,
                          dbo.mtp.mtp_nm, dbo.c1_obtp.obtp_obtpnm, 
                          dbo.c1_ramt.ra_oritem
      FROM             dbo.c1_od INNER JOIN
                          dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND 
                          dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN
                          dbo.mtp ON dbo.c1_ramt.ra_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd
      where od_syscd=@syscd 
	and od_otp1cd=@otp1cd 
	and ra_mtpcd=@mtpcd
	and od_btpcd=@btpcd
	and ((substring(od_sdate,1,6) <= @maildate) and (substring(od_edate,1,6) >= @maildate))
    end
  else
    begin
      insert tmp_label1 
      SELECT         dbo.c1_od.od_odid, dbo.c1_od.od_syscd, dbo.c1_od.od_custno, 
                          dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_oditem, 
                          dbo.c1_od.od_sdate, dbo.c1_od.od_edate, dbo.c1_ramt.ra_mnt, dbo.c1_ramt.ra_mtpcd,
                          dbo.mtp.mtp_nm, dbo.c1_obtp.obtp_obtpnm, 
                          dbo.c1_ramt.ra_oritem
      FROM             dbo.c1_od INNER JOIN
                          dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND 
                          dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN
                          dbo.mtp ON dbo.c1_ramt.ra_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd
      where od_syscd=@syscd 
	and od_otp1cd=@otp1cd 
	and ra_mtpcd=@mtpcd
	and od_btpcd=@btpcd
    end
  end

if @syscd='C3'
  begin
------大宗標籤暫存檔
--truncate table tmp_label1
  delete tmp_label1
    begin
      insert tmp_label1 
      SELECT         c3_freebk.fb_id, c3_freebk.fb_syscd, c3_freebk.fb_appno, '', '', c3_freebk.fb_fbseq,
		substring(c3_freebk.fb_sdate,1,4)+'/'+substring(c3_freebk.fb_sdate,5,2)+'/'+substring(c3_freebk.fb_sdate,7,2),
		substring(c3_freebk.fb_edate,1,4)+'/'+substring(c3_freebk.fb_edate,5,2)+'/'+substring(c3_freebk.fb_edate,7,2), 
                          c3_freebk.fb_mnt, c3_freebk.fb_mtpcd, mtp.mtp_nm, freecat.fc_nm, c3_freebk.fb_oritem
	  FROM             c3_freebk INNER JOIN
                          mtp ON c3_freebk.fb_mtpcd = mtp.mtp_mtpcd INNER JOIN
                          freecat ON c3_freebk.fb_fccd = freecat.fc_fccd
      where fb_syscd=@syscd 
		and fb_mtpcd=@mtpcd
		and fb_fccd=@btpcd
		and ((substring(fb_sdate,1,6) <= @maildate) and (substring(fb_edate,1,6) >= @maildate))
    end
  end

commit transaction create_trans
set nocount off
end
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_tmp_001]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_tmp_001]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_tmp_002    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE PROCEDURE dbo.sp_tmp_002
	@syscd varchar(2), @custno varchar(6)
	
AS
set nocount on
DECLARE @idoc	int
------訂戶歷史訂單暫存檔
--truncate table tmp_label1
delete tmp_cust1
insert tmp_cust1
SELECT            dbo.c1_od.od_syscd, dbo.c1_od.od_custno, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, 
                          dbo.c1_od.od_sdate + '~' + dbo.c1_od.od_edate AS begin_end, 
                          dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, 
                          dbo.c1_obtp.obtp_obtpnm, dbo.c1_ramt.ra_oditem, dbo.c1_ramt.ra_oritem,dbo.c1_order.o_status
FROM             dbo.c1_order INNER JOIN
                          dbo.c1_obtp INNER JOIN
                          dbo.c1_od ON dbo.c1_obtp.obtp_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_obtp.obtp_obtpcd = dbo.c1_od.od_btpcd INNER JOIN
                          dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND 
                          dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem ON 
                          dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND 
                          dbo.c1_order.o_custno = dbo.c1_od.od_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN
                          dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND 
                          dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd
where (dbo.c1_od.od_syscd=@syscd) and (dbo.c1_od.od_custno=@custno)
ORDER BY  dbo.c1_od.od_otp1seq DESC

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_tmp_002]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_tmp_002]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_to_sap_001_a    Script Date: 2002/11/19 上午 10:39:49 ******/
/****** Object:  Stored Procedure dbo.sp_to_sap_001_a    Script Date: 2002/3/27 PM 01:45:55 ******/
/*被sp_find_for_inftmp20呼叫
   產生出@syscd+@iano 這一張發票開立單的數筆傳票明細(以計畫代號彙總到一筆傳票明細)並存到table:sap_vou*/
 
CREATE proc dbo.sp_to_sap_001_a (@syscd  char(2), @iano char(8), @taxtp char(1), @saleamt real, @rtn_codev char(1)
 output )  
as 
declare @vouseq int, @vou_totamt real, @first_vou_totamt real
declare @difamt real, @s_vouseq char(3), @s_first_vou_totamt char(13)
declare @tot_invamt real, @pj char(10)
declare @accdcr char(7) ,@costctr char(7) , @descr varchar(50), @notifyno char(10), @vou_amt real
select @rtn_codev = '0'
DECLARE vou_cursor  CURSOR FOR
SELECT  iad.iad_projno,   sum(iad.iad_amt )  
    FROM mrlpub..ia     ,   
                mrlpub.. iad  
   WHERE ( ia.ia_syscd = iad.iad_syscd ) and  
         ( ia.ia_iano = iad.iad_iano ) and  
         ( ( ia.ia_syscd = @syscd ) and   
         ( ia.ia_iano = @iano ) )   
    GROUP BY ia.ia_syscd,   
         ia.ia_iano,   
         iad.iad_projno
   
OPEN vou_cursor
/* get the first row from the cursor */
FETCH NEXT FROM  vou_cursor INTO 
                 @pj,  @tot_invamt 
 
select @vouseq = 0
select @vou_totamt = 0
WHILE (@@FETCH_STATUS  =  0)
 BEGIN
  select @vouseq = @vouseq + 1
  if @taxtp = "1"
    begin 
       select @vou_amt = round(@tot_invamt/1.05,0)
    end 
  else
    begin
      select @vou_amt  =  @tot_invamt
    end 
  if @vouseq = 1 
    begin
      select @first_vou_totamt = @vou_amt
    end 
  select @vou_totamt  =  @vou_totamt  + @vou_amt
  select @s_vouseq =  convert(char(3), @vouseq)
 
 SELECT @accdcr = rd_accdcr, @costctr =  refd.rd_costctr, @descr =rd_descr
             FROM mrlpub.. refd  
             WHERE     ( rd_syscd =  @syscd ) AND  
                               ( rd_projno =  @pj )
 
 select @notifyno = @syscd + @iano
 INSERT sapvou
 VALUES (@notifyno, @s_vouseq, @accdcr, @pj, @costctr, @syscd, @iano, @vou_amt, @descr, "")     
 FETCH vou_cursor into  @pj,  @tot_invamt   
     
 END
CLOSE  vou_cursor
if @vou_totamt <>  @saleamt
  
begin
select @difamt  = @saleamt  - @vou_totamt
select  @first_vou_totamt, @difamt
select @first_vou_totamt  =  @first_vou_totamt  +  @difamt 
select  @first_vou_totamt
select @s_first_vou_totamt  =  convert(char(13),  @first_vou_totamt)
/*要轉換值*/
/*select @notifyno,'1'      */
UPDATE mrlpub..sapvou 
SET vou_amt  =  @s_first_vou_totamt
	WHERE vou_infno  =  @notifyno  and 
                               vou_vseq = '1'
end 
DEALLOCATE  vou_cursor

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_to_sap_001_a]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_to_sap_001_a]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_to_sap_002    Script Date: 2002/11/19 上午 10:39:49 ******/
/*sap轉檔先呼叫sp_to_sap_001,再呼叫本程式
  功能：將某一(轉檔年月+批次)由sp_to_sap_001產生之sap_iv,sap_ivd,sap_vou產生出應付介面inftmp20*/
CREATE proc dbo.sp_to_sap_002 (@yyyymm  char(6), @batch_seq char(6)  output  )
as
insert into  inftmp20( inftmp20.inf20_orgcd,   
         inftmp20.inf20_type,   
         inftmp20.inf20_yyyymm,   
         inftmp20.inf20_seq,   
         inftmp20.inf20_infno,   
         inftmp20.inf20_ref,   
         inftmp20.inf20_date,   
         inftmp20.inf20_invtp,   
         inftmp20.inf20_invcd,   
         inftmp20.inf20_taxtp,   
         inftmp20.inf20_remark,   
         inftmp20.inf20_cusno,   
         inftmp20.inf20_title,   
         inftmp20.inf20_address,   
         inftmp20.inf20_saleamt,   
         inftmp20.inf20_taxamt,   
         inftmp20.inf20_invoamt,   
         inftmp20.inf20_curr,   
         inftmp20.inf20_rate,   
         inftmp20.inf20_prtctl,   
         inftmp20.inf20_postdate,   
         inftmp20.inf20_accddr,   
         inftmp20.inf20_attach,   
         inftmp20.inf20_exptype,   
         inftmp20.inf20_expremark,   
         inftmp20.inf20_vseq,   
         inftmp20.inf20_accdcr,   
         inftmp20.inf20_projno,   
         inftmp20.inf20_costctr,   
         inftmp20.inf20_contno,   
         inftmp20.inf20_period,   
         inftmp20.inf20_amt,   
         inftmp20.inf20_descr,   
         inftmp20.inf20_alloc,   
         inftmp20.inf20_iseq,   
         inftmp20.inf20_idescr,   
         inftmp20.inf20_iunit,   
         inftmp20.inf20_iqty,   
         inftmp20.inf20_iuniprice,   
         inftmp20.inf20_iremark )
SELECT f.iv_orgcd,   
         f.iv_type,   
         f.iv_yyyymm,   
         f.iv_seq,   
         f.iv_infno,   
         f.iv_ref,   
         f.iv_date,   
         f.iv_invtp,   
         f.iv_invcd,   
         f.iv_taxtp,   
         f.iv_remark,   
         f.iv_cusno,   
         f.iv_title,   
         f.iv_address,   
         f.iv_saleamt,   
         f.iv_taxamt,   
         f.iv_invoamt,   
         f.iv_curr,   
         f.iv_rate,   
         f.iv_prtctl,   
         f.iv_postdate,   
         f.iv_accddr,   
         f.iv_attach,   
         f.iv_exptype,   
         f.iv_expremark,
/*vou 8個欄位*/
         '', '', '', '', '', '', '', '', '',
         g.ivd_iseq,   
         g.ivd_idescr,   
         g.ivd_iunit,   
         g.ivd_iqty,   
         g.ivd_iuniprice,   
         g.ivd_iremark  
    FROM sapiv    f,   
         sapivd    g  
   WHERE ( f.iv_infno = g.ivd_infno ) and  
         ( (f.iv_yyyymm = @yyyymm ) AND  
         (f.iv_seq = @batch_seq ) )       ;   
  
insert into  inftmp20( inftmp20.inf20_orgcd,   
         inftmp20.inf20_type,   
         inftmp20.inf20_yyyymm,   
         inftmp20.inf20_seq,   
         inftmp20.inf20_infno,   
         inftmp20.inf20_ref,   
         inftmp20.inf20_date,   
         inftmp20.inf20_invtp,   
         inftmp20.inf20_invcd,   
         inftmp20.inf20_taxtp,   
         inftmp20.inf20_remark,   
         inftmp20.inf20_cusno,   
         inftmp20.inf20_title,   
         inftmp20.inf20_address,   
         inftmp20.inf20_saleamt,   
         inftmp20.inf20_taxamt,   
         inftmp20.inf20_invoamt,   
         inftmp20.inf20_curr,   
         inftmp20.inf20_rate,   
         inftmp20.inf20_prtctl,   
         inftmp20.inf20_postdate,   
         inftmp20.inf20_accddr,   
         inftmp20.inf20_attach,   
         inftmp20.inf20_exptype,   
         inftmp20.inf20_expremark,   
         inftmp20.inf20_vseq,   
         inftmp20.inf20_accdcr,   
         inftmp20.inf20_projno,   
         inftmp20.inf20_costctr,   
         inftmp20.inf20_contno,   
         inftmp20.inf20_period,   
         inftmp20.inf20_amt,   
         inftmp20.inf20_descr,   
         inftmp20.inf20_alloc,   
         inftmp20.inf20_iseq,   
         inftmp20.inf20_idescr,   
         inftmp20.inf20_iunit,   
         inftmp20.inf20_iqty,   
         inftmp20.inf20_iuniprice,   
         inftmp20.inf20_iremark )  
SELECT h.iv_orgcd,   
         h.iv_type,   
         h.iv_yyyymm,   
         h.iv_seq,   
         h.iv_infno,   
         h.iv_ref,   
         h.iv_date,   
         h.iv_invtp,   
         h.iv_invcd,   
         h.iv_taxtp,   
         h.iv_remark,   
         h.iv_cusno,   
         h.iv_title,   
         h.iv_address,   
         h.iv_saleamt,   
         h.iv_taxamt,   
         h.iv_invoamt,   
         h.iv_curr,   
         h.iv_rate,   
         h.iv_prtctl,   
         h.iv_postdate,   
         h.iv_accddr,   
         h.iv_attach,   
         h.iv_exptype,   
         h.iv_expremark,   
         i.vou_vseq,   
         i.vou_accdcr,   
         i.vou_projno,   
         i.vou_costctr,   
         i.vou_contno,   
         i.vou_period,   
         i.vou_amt,   
         i.vou_descr,   
         i.vou_alloc,
         '', '', '', '', '', ''  
    FROM sapiv  h,   
         sapvou  i  
   WHERE (h.iv_infno = i.vou_infno ) and
( (h.iv_yyyymm = @yyyymm ) AND  
           (h.iv_seq = @batch_seq ) )
update ias
 set ias_trans_sap ='1'
 where
          ias_iasdate = @yyyymm  and
          ias_iasseq = @batch_seq

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_to_sap_002]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_to_sap_002]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c1_tmp_statistics    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE PROCEDURE dbo.sp_c1_tmp_statistics
	(@type varchar(1), @btpcd varchar(2), @yyyymm varchar(6))
------@date1 varchar(8), @date2 varchar(8), @projno varchar(6), 	
AS
declare	@otp1cd char(2),@otp2cd char(2), @mnt	int, @cust_count int, @book_count int, @mtpcd 
char(2)
set nocount on
if @type='0'	-----印製份數統計表(大宗郵寄)
begin
delete tmp_statistics
set @mtpcd='11'
DECLARE otp_Cursor CURSOR FOR
SELECT         c1_otp.otp_otp1cd, c1_otp.otp_otp2cd
FROM             c1_otp
where otp_otp1cd='01' or otp_otp1cd='02' or otp_otp1cd='03'
 ORDER BY  otp_otp1cd, otp_otp2cd
OPEN otp_Cursor
FETCH NEXT FROM otp_Cursor
    into @otp1cd,@otp2cd
WHILE @@FETCH_STATUS = 0
BEGIN
  set @mnt=1
  WHILE (@mnt<6)
  BEGIN
    set @book_count=0
    SELECT         @book_count=COUNT(*)
    FROM             dbo.c1_od INNER JOIN
                          dbo.c1_order ON dbo.c1_od.od_syscd = dbo.c1_order.o_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_order.o_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_order.o_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_order.o_otp1seq INNER JOIN
                          dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND 
                          dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND 
                          dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND 
                          dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND 
                          dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem
    WHERE         (dbo.c1_od.od_otp1cd = @otp1cd) AND (dbo.c1_order.o_otp2cd = @otp2cd) AND 
                          (SUBSTRING(c1_od.od_sdate, 1, 6) <= @yyyymm) AND 				
		(SUBSTRING(c1_od.od_edate,1,6) >= @yyyymm) AND 
		(c1_od.od_btpcd = @btpcd)  AND 
                          (dbo.c1_ramt.ra_mtpcd = @mtpcd) AND (dbo.c1_ramt.ra_mnt = @mnt)
  
    INSERT INTO tmp_statistics
                          (tmp_otp1cd, tmp_otp2cd, tmp_btpcd, tmp_param1, tmp_param2)
    			VALUES         (@otp1cd, @otp2cd, @mtpcd, @book_count,  @mnt)
  set @mnt=@mnt+1
  END
FETCH NEXT FROM otp_Cursor
    into @otp1cd,@otp2cd
END
CLOSE otp_Cursor
DEALLOCATE otp_Cursor
end
if @type='1'	-----印製份數統計表(收發室經辦)
begin
  delete tmp_statistics
----院內傳遞(mtpcd='19') & 掛號(mtpcd='12')
  DECLARE otp_Cursor CURSOR FOR
  SELECT         c1_otp.otp_otp1cd, c1_otp.otp_otp2cd, dbo.mtp.mtp_mtpcd
  FROM             c1_otp CROSS JOIN dbo.mtp
  where (otp_otp1cd='01' or otp_otp1cd='02' or otp_otp1cd='03') and (mtp_mtpcd='12' or mtp_mtpcd='19')
	ORDER BY  mtp_mtpcd DESC,otp_otp1cd, otp_otp2cd
  OPEN otp_Cursor
  FETCH NEXT FROM otp_Cursor
    into @otp1cd,@otp2cd,@mtpcd
  WHILE @@FETCH_STATUS = 0
  BEGIN
    set @mnt=1
    WHILE (@mnt<6)
    BEGIN
      set @book_count=0
      SELECT         @book_count=COUNT(*)
      FROM             v_c1_tmp_001
      WHERE         (od_otp1cd = @otp1cd) AND (o_otp2cd = @otp2cd) AND 
                          (SUBSTRING(od_sdate, 1, 6) <= @yyyymm) AND 				
		(SUBSTRING(od_edate,1,6) >= @yyyymm) AND 
		(od_btpcd = @btpcd)  AND 
                          (ra_mtpcd = @mtpcd) AND (ra_mnt = @mnt)
  
      INSERT INTO tmp_statistics
                          (tmp_otp1cd, tmp_otp2cd, tmp_btpcd, tmp_param1, tmp_param2)
    			VALUES         (@otp1cd, @otp2cd, @mtpcd, @book_count,  @mnt)
      set @mnt=@mnt+1
    END
    FETCH NEXT FROM otp_Cursor
      into @otp1cd,@otp2cd,@mtpcd
  END
  CLOSE otp_Cursor
  DEALLOCATE otp_Cursor
----國外郵寄
  DECLARE mtp_Cursor CURSOR FOR
  SELECT         dbo.mtp.mtp_mtpcd
  FROM           dbo.mtp
  where (SUBSTRING(mtp_mtpcd, 1, 1)='2')
  OPEN mtp_Cursor
  FETCH NEXT FROM mtp_Cursor
    into @mtpcd
  WHILE @@FETCH_STATUS = 0
  BEGIN
    set @mnt=1
    WHILE (@mnt<6)
    BEGIN
      set @book_count=0
      SELECT         @book_count=COUNT(*)
      FROM             v_c1_tmp_001
      WHERE         (od_otp1cd = @otp1cd) AND (o_otp2cd = @otp2cd) AND 
                          (SUBSTRING(od_sdate, 1, 6) <= @yyyymm) AND 				
		(SUBSTRING(od_edate,1,6) >= @yyyymm) AND 
		(od_btpcd = @btpcd)  AND 
                          (ra_mtpcd = @mtpcd) AND (ra_mnt = @mnt)
  
      INSERT INTO tmp_statistics
                          (tmp_otp1cd, tmp_otp2cd, tmp_btpcd, tmp_param1, tmp_param2)
    			VALUES         ('', '', @mtpcd, @book_count,  @mnt)
      set @mnt=@mnt+1
    END
    FETCH NEXT FROM mtp_Cursor
      into @mtpcd
  END
  CLOSE mtp_Cursor
  DEALLOCATE mtp_Cursor
end
if @type='2'	-----客戶份數表
begin
delete tmp_statistics
DECLARE otp_Cursor CURSOR FOR
 select otp_otp1cd,otp_otp2cd
 from c1_otp
 where otp_otp1cd='01' or otp_otp1cd='02'
 ORDER BY  otp_otp1cd, otp_otp2cd
OPEN otp_Cursor
FETCH NEXT FROM otp_Cursor
    into @otp1cd,@otp2cd
WHILE @@FETCH_STATUS = 0
BEGIN
set @cust_count=0
set @mnt=0
SELECT         @cust_count=COUNT(*)
FROM             c1_order INNER JOIN
                          c1_od ON c1_order.o_syscd = c1_od.od_syscd AND 
                          c1_order.o_custno = c1_od.od_custno AND 
                          c1_order.o_otp1cd = c1_od.od_otp1cd AND 
                          c1_order.o_otp1seq = c1_od.od_otp1seq
WHERE         (c1_order.o_otp1cd =@otp1cd) AND (c1_order.o_otp2cd = @otp2cd) AND 
                          (SUBSTRING(c1_od.od_sdate, 1, 6) <= @yyyymm) AND 
(SUBSTRING(c1_od.od_edate,1,6) >= @yyyymm) AND 
                          (c1_od.od_btpcd = @btpcd)
SELECT         @mnt=SUM(c1_ramt.ra_mnt)
FROM             c1_order INNER JOIN
                          c1_od ON c1_order.o_syscd = c1_od.od_syscd AND 
                          c1_order.o_custno = c1_od.od_custno AND 
                          c1_order.o_otp1cd = c1_od.od_otp1cd AND 
                          c1_order.o_otp1seq = c1_od.od_otp1seq INNER JOIN
                          c1_ramt ON c1_od.od_syscd = c1_ramt.ra_syscd AND 
                          c1_od.od_custno = c1_ramt.ra_custno AND 
                          c1_od.od_otp1cd = c1_ramt.ra_otp1cd AND 
                          c1_od.od_otp1seq = c1_ramt.ra_otp1seq AND 
                          c1_od.od_oditem = c1_ramt.ra_oditem
WHERE         (c1_order.o_otp1cd = @otp1cd) AND (c1_order.o_otp2cd = @otp2cd) AND 
                          (c1_od.od_btpcd = @btpcd) AND (SUBSTRING(c1_od.od_sdate, 1, 
6)<=@yyyymm) AND 
                          (SUBSTRING(c1_od.od_edate,1,6) >= @yyyymm)
if @mnt=NULL
 set @mnt=0
INSERT INTO tmp_statistics
                          (tmp_otp1cd, tmp_otp2cd, tmp_btpcd, tmp_param1, tmp_param2)
VALUES         (@otp1cd, @otp2cd, @btpcd, @cust_count,  @mnt)
FETCH NEXT FROM otp_Cursor
    into @otp1cd,@otp2cd
END
CLOSE otp_Cursor
DEALLOCATE otp_Cursor
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_c2_getad_1    Script Date: 2002/11/19 上午 10:39:49 ******/
CREATE proc dbo.sp_c2_getad_1 ( @fgclosed  char(1), @bkcd char(2))  
as
begin 
set nocount on
declare @contno char(6)


delete from c2_getad
DECLARE  getad_cursor  CURSOR FOR 
SELECT c2_cont.cont_contno  
FROM c2_cont      
   WHERE  
          ( c2_cont.cont_fgclosed = @fgclosed ) and
            (c2_cont.cont_bkcd = @bkcd)
      
open getad_cursor

FETCH  NEXT FROM  getad_cursor INTO
         @contno

WHILE (@@FETCH_STATUS = 0)
BEGIN
select @contno
exec sp_c2_getad_2  @contno

FETCH  NEXT FROM  getad_cursor INTO
         @contno


END
CLOSE  getad_cursor                                                                                                                                     
DEALLOCATE  getad_cursor
                       
set nocount off            
end
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_c2_getad_1]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_c2_getad_1]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  Stored Procedure dbo.sp_tmp_003    Script Date: 2002/11/19 上午 10:39:50 ******/
CREATE PROCEDURE dbo.sp_tmp_003
	@syscd varchar(2), @otp1cd varchar(2), @btpcd varchar(2), @sdate varchar(6), @edate varchar(6)
	
AS
set nocount on
DECLARE @idoc	int
------續訂標籤暫存檔
--truncate table tmp_label1
delete tmp_label1
if @btpcd='01' or  @btpcd='02'	---工材或電材
insert tmp_label1 
SELECT          dbo.c1_od.od_odid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, 
                          dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_od.od_oditem,
		substring(dbo.c1_od.od_sdate,1,4)+'/'+substring(dbo.c1_od.od_sdate,5,2)+'/'+substring(dbo.c1_od.od_sdate,7,2),
		substring(dbo.c1_od.od_edate,1,4)+'/'+substring(dbo.c1_od.od_edate,5,2)+'/'+substring(dbo.c1_od.od_edate,7,2), 
		'','','', dbo.c1_obtp.obtp_obtpnm,''
FROM             dbo.c1_order INNER JOIN
                          dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND 
                          dbo.c1_order.o_custno = dbo.c1_od.od_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd AND 
                          dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd INNER JOIN
                          dbo.v_maxseq ON dbo.c1_order.o_syscd = dbo.v_maxseq.o_syscd AND 
                          dbo.c1_order.o_custno = dbo.v_maxseq.o_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.v_maxseq.o_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.v_maxseq.seq
where          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) >= @sdate) AND 
                          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) <= @edate) AND
		(dbo.c1_order.o_otp1cd=@otp1cd) AND (dbo.c1_order.o_syscd=@syscd) AND (dbo.c1_od.od_btpcd=@btpcd)
/*SELECT          dbo.c1_od.od_odid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, 
                          dbo.c1_order.o_otp1cd, MAX(dbo.c1_order.o_otp1seq) AS seq, dbo.c1_od.od_oditem,
		substring(dbo.c1_od.od_sdate,1,4)+'/'+substring(dbo.c1_od.od_sdate,5,2)+'/'+substring(dbo.c1_od.od_sdate,7,2),
		substring(dbo.c1_od.od_edate,1,4)+'/'+substring(dbo.c1_od.od_edate,5,2)+'/'+substring(dbo.c1_od.od_edate,7,2), 
		'','','', dbo.c1_obtp.obtp_obtpnm,''
FROM             dbo.c1_order INNER JOIN
                          dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND 
                          dbo.c1_order.o_custno = dbo.c1_od.od_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd AND 
                          dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd INNER JOIN
                          dbo.v_maxseq ON dbo.c1_order.o_syscd = dbo.v_maxseq.o_syscd AND 
                          dbo.c1_order.o_custno = dbo.v_maxseq.o_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.v_maxseq.o_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.v_maxseq.seq
GROUP BY  dbo.c1_od.od_odid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_od.od_oditem,  dbo.c1_od.od_sdate, 
                          dbo.c1_od.od_edate, dbo.c1_obtp.obtp_obtpnm, dbo.c1_od.od_btpcd
HAVING          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) >= @sdate) AND 
                          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) <= @edate) AND
		(dbo.c1_order.o_otp1cd=@otp1cd) AND (dbo.c1_order.o_syscd=@syscd) AND (dbo.c1_od.od_btpcd=@btpcd)*/
else	----全部
insert tmp_label1 
SELECT          dbo.c1_od.od_odid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, 
                          dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_od.od_oditem,
		substring(dbo.c1_od.od_sdate,1,4)+'/'+substring(dbo.c1_od.od_sdate,5,2)+'/'+substring(dbo.c1_od.od_sdate,7,2),
		substring(dbo.c1_od.od_edate,1,4)+'/'+substring(dbo.c1_od.od_edate,5,2)+'/'+substring(dbo.c1_od.od_edate,7,2), 
		'','','', dbo.c1_obtp.obtp_obtpnm,''
FROM             dbo.c1_order INNER JOIN
                          dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND 
                          dbo.c1_order.o_custno = dbo.c1_od.od_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd AND 
                          dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd INNER JOIN
                          dbo.v_maxseq ON dbo.c1_order.o_syscd = dbo.v_maxseq.o_syscd AND 
                          dbo.c1_order.o_custno = dbo.v_maxseq.o_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.v_maxseq.o_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.v_maxseq.seq
where          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) >= @sdate) AND 
                          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) <= @edate) AND
		(dbo.c1_order.o_otp1cd=@otp1cd) AND (dbo.c1_order.o_syscd=@syscd)
/*SELECT          dbo.c1_od.od_odid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, 
                          dbo.c1_order.o_otp1cd, MAX(dbo.c1_order.o_otp1seq) AS seq, dbo.c1_od.od_oditem, 
		substring(dbo.c1_od.od_sdate,1,4)+'/'+substring(dbo.c1_od.od_sdate,5,2)+'/'+substring(dbo.c1_od.od_sdate,7,2),
		substring(dbo.c1_od.od_edate,1,4)+'/'+substring(dbo.c1_od.od_edate,5,2)+'/'+substring(dbo.c1_od.od_edate,7,2), 
		'','','', dbo.c1_obtp.obtp_obtpnm,''
FROM             dbo.c1_order INNER JOIN
                          dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND 
                          dbo.c1_order.o_custno = dbo.c1_od.od_custno AND 
                          dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND 
                          dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN
                          dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd AND 
                          dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd
GROUP BY  dbo.c1_od.od_odid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_od.od_oditem,  dbo.c1_od.od_sdate, 
                          dbo.c1_od.od_edate, dbo.c1_obtp.obtp_obtpnm
HAVING          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) >= @sdate) AND 
                          (SUBSTRING(dbo.c1_od.od_edate, 1, 6) <= @edate) AND
		(dbo.c1_order.o_otp1cd=@otp1cd) AND (dbo.c1_order.o_syscd=@syscd)*/

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

GRANT  EXECUTE  ON [dbo].[sp_tmp_003]  TO [mrlpub]
GO

GRANT  EXECUTE  ON [dbo].[sp_tmp_003]  TO [webuser]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c1_or    Script Date: 2002/11/19 上午 10:39:50 ******/
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

GRANT  REFERENCES ,  EXECUTE  ON [dbo].[fn_c1_or]  TO [mrlpub]
GO

GRANT  REFERENCES ,  EXECUTE  ON [dbo].[fn_c1_or]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c1_order    Script Date: 2002/11/19 上午 10:39:50 ******/
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

GRANT  REFERENCES ,  EXECUTE  ON [dbo].[fn_c1_order]  TO [mrlpub]
GO

GRANT  REFERENCES ,  EXECUTE  ON [dbo].[fn_c1_order]  TO [webuser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** Object:  User Defined Function dbo.fn_c1_od    Script Date: 2002/11/19 上午 10:39:50 ******/
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
  '<新舊訂戶>續訂戶</新舊訂戶>'  
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

GRANT  REFERENCES ,  EXECUTE  ON [dbo].[fn_c1_od]  TO [mrlpub]
GO

GRANT  REFERENCES ,  EXECUTE  ON [dbo].[fn_c1_od]  TO [webuser]
GO


exec sp_addextendedproperty N'MS_Description', N'('''')', N'user', N'dbo', N'table', N'Results', N'column', N'o_otp1cd'


GO


exec sp_addextendedproperty N'MS_Description', null, N'user', N'dbo', N'table', N'c4_or', N'column', N'or_addr'


GO


exec sp_addextendedproperty N'MS_Description', null, N'user', N'dbo', N'table', N'itp', N'column', N'itp_itpcd'


GO

