if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_xmlfilelog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_xmlfilelog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_adrlist]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_adrlist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_adrlist_adr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_adrlist_adr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_atpstring]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_atpstring]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_fbkstring]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_fbkstring]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_getad]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_getad]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_getad_adr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_getad_adr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_getad_drafttp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_getad_drafttp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_getad_urltp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_getad_urltp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_ia_prelist]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_ia_prelist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_label_list]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_label_list]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_mail_mnt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_mail_mnt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wk_c4_matpstring]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[wk_c4_matpstring]
GO

CREATE TABLE [dbo].[c4_xmlfilelog] (
	[xml_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[xml_fgexist] [int] NOT NULL ,
	[xml_createdate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_adrlist] (
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tot_adr_addays] [int] NOT NULL ,
	[adr_adcate_M] [int] NOT NULL ,
	[adr_adcate_I] [int] NOT NULL ,
	[adr_adcate_N] [int] NOT NULL ,
	[adr_fgfixad] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_pubtm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_freetm] [int] NOT NULL ,
	[cont_totimgtm] [int] NOT NULL ,
	[res_drafttp] [int] NOT NULL ,
	[cont_toturltm] [int] NOT NULL ,
	[res_urltp] [int] NOT NULL ,
	[sum_adamt] [int] NOT NULL ,
	[sum_desamt] [int] NOT NULL ,
	[sum_chgamt] [int] NOT NULL ,
	[cont_totamt] [int] NOT NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_remark] [char] (50) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_adrlist_adr] (
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tot_adr_addays] [int] NOT NULL ,
	[adr_adcate_M] [int] NOT NULL ,
	[adr_adcate_I] [int] NOT NULL ,
	[adr_adcate_N] [int] NOT NULL ,
	[adr_fgfixad] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[sum_adamt] [int] NOT NULL ,
	[sum_desamt] [int] NOT NULL ,
	[sum_chgamt] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_atpstring] (
	[wkatp_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[wkatp_atpstr] [varchar] (1000) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_fbkstring] (
	[wkfbk_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[wkfbk_fbkstr] [varchar] (1000) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_getad] (
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aunm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_addate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[tot_adr_addays] [int] NOT NULL ,
	[adr_adcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_keyword] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgfixad] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_impr] [int] NOT NULL ,
	[adr_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_imgurl] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgimggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_urltp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgurlgot] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[adr_navurl] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_pubtm] [int] NOT NULL ,
	[cont_freetm] [int] NOT NULL ,
	[cont_totimgtm] [int] NOT NULL ,
	[res_drafttp] [int] NULL ,
	[cont_toturltm] [int] NOT NULL ,
	[res_urltp] [int] NULL ,
	[cont_totamt] [real] NOT NULL ,
	[ia_amt] [real] NULL ,
	[cont_paidamt] [real] NOT NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_fgout] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_getad_adr] (
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[tot_adr_addays] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_getad_drafttp] (
	[contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[drafttp_cnt] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_getad_urltp] (
	[contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[urltp_cnt] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_ia_prelist] (
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cust_nm] [char] (30) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[srspn_cname] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_totamt] [real] NOT NULL ,
	[im_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[im_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[im_mfr_inm] [char] (50) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[im_zip] [varchar] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_addr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_invcd] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_taxtp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[im_fgitri] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_addate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[adr_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[adr_invamt] [int] NOT NULL ,
	[adr_adamt] [int] NOT NULL ,
	[adr_desamt] [int] NOT NULL ,
	[adr_chgamt] [int] NOT NULL ,
	[adr_imseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_label_list] (
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_conttp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[ma_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[or_inm] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_nm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_jbti] [varchar] (12) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_addr] [varchar] (120) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_zip] [char] (5) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_tel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_mnt] [int] NOT NULL ,
	[fbk_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fgpub] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_mail_mnt] (
	[contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[yyyymm] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[conttp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fgmosea] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[pubmnt] [int] NOT NULL ,
	[unpubmnt] [int] NOT NULL ,
	[bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[wk_c4_matpstring] (
	[wkmatp_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[wkmatp_matpstr] [varchar] (1000) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

