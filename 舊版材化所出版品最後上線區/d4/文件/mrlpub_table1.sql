if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_adcnt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_adcnt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_adr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_adr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_class1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_class1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_class2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_class2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_class3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_class3]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_classes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_classes]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[c4_xmlfilelog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[c4_xmlfilelog]
GO

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

CREATE TABLE [dbo].[c4_adr] (
	[adr_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_addate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_adcate] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_keyword] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_alttext] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_imgurl] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_impr] [int] NOT NULL ,
	[adr_navurl] [varchar] (255) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_drafttp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_urltp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_imseq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_invamt] [int] NOT NULL ,
	[adr_adamt] [int] NOT NULL ,
	[adr_desamt] [int] NOT NULL ,
	[adr_chgamt] [int] NOT NULL ,
	[adr_remark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_projno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_costctr] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fginved] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[adr_fgfixad] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgimggot] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgurlgot] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[adr_fginvself] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[adr_fgact] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_class1] (
	[cls1_cls1id] [int] NOT NULL ,
	[cls1_name] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_class2] (
	[cls2_cls2id] [int] NOT NULL ,
	[cls2_cls1id] [int] NOT NULL ,
	[cls2_cname] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_class3] (
	[cls3_cls3id] [int] NOT NULL ,
	[cls3_cls2id] [int] NOT NULL ,
	[cls3_cls1id] [int] NOT NULL ,
	[cls3_cname] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_classes] (
	[cls_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cls_cls1id] [int] NOT NULL ,
	[cls_cls2id] [int] NOT NULL ,
	[cls_cls3id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_cont] (
	[cont_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_conttp] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_signdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_sdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_edate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_empno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_mfrno] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_custno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aunm] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_autel] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aufax] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_aucell] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_auemail] [varchar] (80) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_freetm] [int] NOT NULL ,
	[cont_resttm] [int] NOT NULL ,
	[cont_pubtm] [int] NOT NULL ,
	[cont_totimgtm] [int] NOT NULL ,
	[cont_toturltm] [int] NOT NULL ,
	[cont_disc] [real] NOT NULL ,
	[cont_totamt] [real] NOT NULL ,
	[cont_paidamt] [real] NOT NULL ,
	[cont_restamt] [real] NOT NULL ,
	[cont_ccont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_csdate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_pdcont] [varchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_remark] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_credate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_moddate] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_modempno] [char] (7) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_oldcontno] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[cont_fgpayonce] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgtemp] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgpubed] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgclosed] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[cont_fgcancel] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_freebk] (
	[fbk_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_fbkitem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[fbk_bkcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
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
	[lst_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[lst_fgprint] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_or] (
	[or_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[or_inm] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
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

CREATE TABLE [dbo].[c4_ramt] (
	[ma_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_fbkitem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ma_sdate] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[ma_edate] [char] (6) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[ma_pubmnt] [int] NOT NULL ,
	[ma_unpubmnt] [int] NOT NULL ,
	[ma_mtpcd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_remail] (
	[rm_syscd] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_contno] [char] (6) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_oritem] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_seq] [char] (2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_cont] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_fgsent] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[rm_fgprint] [char] (1) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[c4_xmlfilelog] (
	[xml_date] [char] (8) COLLATE Chinese_Taiwan_Stroke_BIN NOT NULL ,
	[xml_fgexist] [int] NOT NULL ,
	[xml_createdate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

