<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="cont_main3.aspx.cs" Src="cont_main3.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_main3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>維護合約書 步驟三</TITLE>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO0, DSO1, DSOX -->
		<OBJECT id="DSO0" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<BODY>
		<!-- 頁首 Header -->
		<kw:header id="Header1" runat="server">
		</kw:header>
		<!-- 目前所在位置 -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px; HEIGHT: 24px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							維護合約書 步驟三: 修改合約書內容</font>
					</td>
				</tr>
			</table>
			<!-- 注意:
			     1. 各 table 裡的 dataFld & dataSrc="#DSO0"  要由 DSO0 改為 DSO1; 
			     2. 且各 server control 元件要改為 input 元件, 且 input 要加 dataFld 屬性
			     3. 各區域 (如廠商及客戶資料...區) 要內加一層 table, 好抓對各區的 dataFld -->
			<!-- Run at Server Form -->
			<form id="cont_main3" method="post" runat="server">
				<!--Table 開始-->
				<TABLE dataFld="合約書內容" id="Header" style="WIDTH: 95%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TBODY>
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="廠商資料" id="MfrData" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<!-- 廠商及客戶資料 -->
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="white">(2) 廠商及客戶資料</font>
										</td>
									</TR>
									<!-- 廠商資料 -->
									<TR vAlign="center">
										<TD class="cssTitle" noWrap align="right" width="30%" bgColor="#bfcff0">
											<FONT color="#cc0099">(2)</FONT> 公司名稱/商號 (廠商統編)：
										</TD>
										<TD class="cssData" width="33%">
											<asp:label dataFld="公司發票抬頭" id="lblCompanyName" runat="server"></asp:label>
											&nbsp;(
											<asp:label dataFld="廠商統編" id="lblMfrNo" runat="server"></asp:label>
											) <INPUT dataFld="廠商統編" id="hiddenMfrNo" type="hidden" size="1" name="hiddenMfrNo" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" width="10%">
											詳細資料：
										</TD>
										<TD class="cssData" width="*">
											<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">&nbsp;
											<INPUT dataFld="廠商地址" id="hiddenMfrName" type="hidden" size="1" name="hiddenMfrName" runat="server">
											<INPUT dataFld="廠商郵遞區號" id="hiddenMfrZipcode" type="hidden" size="1" name="hiddenMfrZipcode" runat="server">
											<INPUT dataFld="廠商地址" id="hiddenMfrAddress" type="hidden" size="1" name="hiddenMfrAddress" runat="server">
										</TD>
									</TR>
									<!-- 公司負責人資料 -->
									<TR vAlign="center">
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											公司負責人姓名及職稱：
										</TD>
										<TD class="cssData">
											<asp:label dataFld="廠商負責人姓名" id="lblMfrRespName" runat="server"></asp:label>
											&nbsp;(
											<asp:label dataFld="廠商負責人職稱" id="lblMfrRespJobTitle" runat="server"></asp:label>
											) <INPUT dataFld="廠商負責人姓名" id="hiddenMfrRespName" type="hidden" size="1" name="hiddenMfrRespName" runat="server">
											<INPUT dataFld="廠商負責人職稱" id="hiddenMfrRespJobTitle" type="hidden" size="1" name="hiddenMfrRespJobTitle" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right">
											公司電話/傳真：
										</TD>
										<TD class="cssData">
											<asp:label dataFld="廠商電話" id="lblMfrTel" runat="server"></asp:label>
											&nbsp;(Fax:
											<asp:label dataFld="廠商傳真" id="lblMfrFax" runat="server"></asp:label>
											) <INPUT dataFld="廠商電話" id="hiddenMfrTel" type="hidden" size="1" name="hiddenMfrTel" runat="server">
											<INPUT dataFld="廠商傳真" id="hiddenMfrFax" type="hidden" size="1" name="hiddenMfrFax" runat="server">
										</TD>
									</TR>
									<!-- 客戶資料 -->
									<TR>
										<TD colSpan="4">
											<TABLE dataFld="客戶資料" id="CustData" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
												<TR vAlign="center">
													<TD class="cssTitle" noWrap align="right" width="28%" bgColor="#bfcff0">
														客戶姓名 (客戶編號)：
													</TD>
													<TD class="cssData" width="32%">
														<asp:label dataFld="客戶姓名" id="lblCustName" runat="server"></asp:label>
														&nbsp;&nbsp;(<asp:label dataFld="客戶編號" id="lblCustNo" Runat="server" ForeColor="Maroon"></asp:label>
														)&nbsp; <INPUT dataFld="客戶編號" id="hiddenCustNo" type="hidden" size="1" name="hiddenCustNo" runat="server">
														<INPUT id="hiddenPreXml" type="hidden" size="6" name="hiddenPreXml" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right" width="15%">
														詳細資料：
													</TD>
													<TD class="cssData" width="*">
														<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=430, Width=550, Top=60, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">&nbsp;
														<INPUT id="hiddenCustName" type="hidden" size="1" name="hiddenCustName" runat="server">
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- 合約書基本資料 -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="合約書基本資料" id="ContBasicData" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="#ffffff">合約書基本資料&nbsp;&nbsp;</font>&nbsp;
											<asp:label id="lblfgClosedMessage" runat="server"></asp:label>
										</td>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											<font color="#cc0099">(1)</font> 簽約日期：
										</TD>
										<TD class="cssData">
											<FONT color="red">*</FONT> <INPUT dataFld="簽約日期" id="tbxSignDate" type="text" maxLength="10" size="9" name="tbxSignDate" runat="server">&nbsp;
											<IMG id="img_signdate" onclick='javascript:pick_date("tbxSignDate");return false;' height="18" alt="查詢日期" src="../images/calendar01.gif" width="18">&nbsp;
											<FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">為必填欄位]</FONT>
											<INPUT dataFld="簽約日期" id="hiddenSignDate" type="hidden" size="2" name="hiddenSignDate" runat="server">
											<INPUT id="hiddenModDate" type="hidden" size="2" name="hiddenModDate" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right">
											合約編號：
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp;
											<asp:label id="lblContNo" runat="server" ForeColor="Red"></asp:label>
											<INPUT id="hiddenContNo" type="hidden" size="6" name="hiddenContNo" runat="server">&nbsp;
											<INPUT id="hiddenOldContNo" style="WIDTH: 30px" type="hidden" size="6" name="hiddenOldContNo" runat="server">
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											合約類別：
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp;
											<asp:dropdownlist id="ddlContType" runat="server" Enabled="False">
												<asp:ListItem Value="01" Selected="True">一般合約</asp:ListItem>
												<asp:ListItem Value="09">推廣合約</asp:ListItem>
											</asp:dropdownlist>
											<INPUT id="hiddenContType" type="hidden" size="2" name="hiddenContType" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											書籍類別：
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <SELECT dataFld="書籍類別代碼" id="ddlBookCode" name="ddlBookCode" runat="server"></SELECT>&nbsp;
											<INPUT dataFld="書籍全碼" id="hiddenBkcdProjCost" type="hidden" size="1" name="hiddenBkcdProjCost" runat="server">&nbsp;
											<INPUT dataFld="計劃代號" id="hiddenProjNo" type="hidden" size="1" name="hiddenProjNo" runat="server">&nbsp;
											<INPUT dataFld="成本中心" id="hiddenCostCtr" type="hidden" size="1" name="hiddenCostCtr" runat="server">
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(7)</font> 合約起迄日：
										</TD>
										<TD class="cssData" noWrap>
											<FONT color="red">*</FONT> <INPUT dataFld="合約起日" id="tbxStartDate" style="WIDTH: 45px" type="text" maxLength="7" size="7" name="tbxStartDate" runat="server">&nbsp;
											<font size="3">~</font> <FONT color="red">*</FONT> <INPUT dataFld="合約迄日" id="tbxEndDate" style="WIDTH: 45px" type="text" maxLength="7" size="7" name="tbxEndDate" runat="server">
											<FONT face="新細明體" color="#c00000">(預設值: 一年)</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											承辦業務員：
										</TD>
										<TD class="cssData">
											<FONT color="red">* </FONT><SELECT id="ddlEmpNo" name="ddlEmpNo" runat="server"></SELECT>
											<INPUT dataFld="承辦業務員工號" id="hiddenEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenEmpNo" runat="server">
											<INPUT dataFld="承辦業務員工號" id="hiddenLoginEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenLoginEmpNo" runat="server">&nbsp; 
											<!--FONT face="新細明體" color="#c00000">(預設值: 登入者)</FONT-->
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											一次付清註記：
										</TD>
										<TD class="cssData" noWrap>
											&nbsp;&nbsp; <SELECT dataFld="一次付清註記" id="ddlfgPayOnce" name="ddlfgPayOnce" runat="server">
												<OPTION value="1">
													是</OPTION>
												<OPTION value="0" selected>
													否</OPTION></SELECT>&nbsp;
											<asp:textbox dataFld="一次付清註記" id="hiddenfgClosed" runat="server" MaxLength="1" Width="20px" ReadOnly="True" Visible="False"></asp:textbox>
											</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											&nbsp;
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											結案註記：
										</TD>
										<TD class="cssData" noWrap>
											&nbsp;&nbsp; <SELECT dataFld="結案註記" id="ddlfgClosed" name="ddlfgClosed" runat="server">
												<OPTION value="1">
													是</OPTION>
												<OPTION value="0" selected>
													否</OPTION></SELECT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											舊合約編號：
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;&nbsp;&nbsp; <INPUT dataFld="舊合約編號" id="tbxOldContNo" type="text" maxLength="7" size="7" name="tbxOldContNo" runat="server" disabled>
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											最後修改日：
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;&nbsp;&nbsp; <INPUT dataFld="最後修改日期" id="tbxModDate" style="COLOR: gray" readOnly type="text" maxLength="10" size="10" name="tbxModDate" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											修改業務員工號：
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;&nbsp;&nbsp; <SELECT id="ddlModEmpNo" name="ddlModEmpNo" runat="server"></SELECT>&nbsp;
											<INPUT dataFld="修改業務員工號" id="hiddenModEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenModEmpNo" runat="server">&nbsp;
											<FONT face="新細明體" color="#c00000">(預設值: 登入者)</FONT>
										</TD>
									</TR>
								</TABLE>
							</TD>
						<!-- 合約書細節 -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="合約書細節" id="ContDetail" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="white">(9)&nbsp;合約書細節</font>
										</td>
									</TR>
									<TR>
										<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
											<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" width="90%" border="0">
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														<font color="#cc0099">(9)</font> 總製稿次數：
													</TD>
													<TD class="cssData">
														<FONT color="red">*</FONT> <INPUT dataFld="總製稿次數" id="tbxTotalJTime" maxLength="3" size="2" name="tbxTotalJTime" runat="server" onblur="Javascript: checkTotalJTime(this)">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														總刊登次數：
													</TD>
													<TD class="cssData">
														<FONT color="red">*</FONT> <INPUT dataFld="總刊登次數" id="tbxTotalTime" maxLength="3" size="2" name="tbxTotalTime" runat="server" onblur="Javascript: checkTotalTime(this)">
													</TD>
													<TD class="cssTitle" align="right">
														<FONT color="#cc0099">(11)</FONT> 合約總金額：
													</TD>
													<TD class="cssData">
														<FONT color="red">* </FONT>$ <INPUT dataFld="合約總金額" id="tbxTotalAmt" maxLength="8" size="5" name="tbxTotalAmt" runat="server" onblur="Javascript: checkTotalAmt(this)">&nbsp;
														<INPUT dataFld="總製稿次數" id="hiddenTotalJTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalJTime" runat="server">&nbsp;
														<INPUT dataFld="總刊登次數" id="hiddenTotalTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalTime" runat="server">
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														已製稿次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="已製稿次數" id="tbxMadeJTime" maxLength="3" size="2" name="tbxMadeJTime" runat="server" onblur="Javascript: checkRestJTime(this)">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														已刊登次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="已刊登次數" id="tbxPubTime" maxLength="3" size="2" name="tbxPubTime" runat="server" onblur="Javascript: checkRestTime(this)">
													</TD>
													<TD class="cssTitle" align="right">
														已繳金額：
													</TD>
													<TD class="cssData">
														&nbsp; &nbsp; $ <INPUT dataFld="已繳金額" id="tbxPaidAmt" maxLength="8" size="5" name="tbxPaidAmt" runat="server" onblur="Javascript: checkRestAmt(this)">
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														剩餘製稿次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="剩餘製稿次數" id="tbxRestJTime" maxLength="3" size="2" name="tbxRestJTime" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														剩餘刊登次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="剩餘刊登次數" id="tbxRestTime" maxLength="3" size="2" name="tbxRestTime" runat="server">
													</TD>
													<TD class="cssTitle" align="right">
														剩餘金額：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; $ <INPUT dataFld="剩餘金額" id="tbxRestAmt" maxLength="8" size="5" name="tbxRestAmt" runat="server">
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														<font color="#cc0099">(9)</font> 換稿次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="換稿次數" id="tbxChangeJTime" maxLength="3" size="2" name="tbxChangeJTime" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														<FONT color="#cc0099">(9)</FONT> 贈送次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="贈送次數" id="tbxFreeTime" maxLength="3" size="2" name="tbxFreeTime" runat="server">
													</TD>
													<TD class="cssTitle" align="right">
														<FONT color="#cc0099">(9)</FONT> 優惠折數：
													</TD>
													<TD class="cssData">
														<FONT color="red">*&nbsp;&nbsp;&nbsp; </FONT><INPUT dataFld="優惠折數" id="tbxDiscount" maxLength="6" size="4" name="tbxDiscount" runat="server" onblur="Javascript: checkDiscount(this)">
														<FONT face="新細明體">折</FONT><FONT face="新細明體" color="#c00000">(填實數, 如 0.xxx)</FONT>
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														彩色次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="彩色次數" id="tbxColorTime" maxLength="3" size="2" name="tbxColorTime" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														黑白次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="黑白次數" id="tbxMenoTime" maxLength="3" size="2" name="tbxMenoTime" runat="server">
													</TD>
													<TD class="cssTitle" align="right">
														套色次數：
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <INPUT dataFld="套色次數" id="tbxGetColorTime" maxLength="3" size="2" name="tbxGetColorTime" runat="server">
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- 發票廠商資料 -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="發票廠商資料" id="InvRec" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<TD colSpan="4">
											<FONT color="white">(4) 發票廠商收件人資料</FONT>
										</TD>
									</TR>
									<TR vAlign="center">
										<TD noWrap align="right" width="28%" bgColor="#bfcff0">
											<font color="#cc0099">(4)</font> 發票收件人姓名：
										</TD>
										<TD noWrap width="*" colSpan="3">
											<IMG class="ico" title="新增/修改發票收件人" onclick="doGetAllInvRec()" height="18" src="../images/new.gif" border="0">&nbsp;
											<INPUT dataFld="發票收件人姓名" id="hiddenInvRec" type="hidden" size="1" name="hiddenInvRec" runat="server">
											<DIV id="lblInvRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
											</DIV>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- 雜誌收件人資料 -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="雜誌收件人資料" id="MazRec" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<TD colSpan="4">
											<FONT color="white">(4) 雜誌收件人資料</FONT>
										</TD>
									</TR>
									<TR vAlign="center">
										<TD noWrap align="right" width="28%" bgColor="#bfcff0">
											<font color="#cc0099">(4)</font> 雜誌收件人姓名：
										</TD>
										<TD noWrap width="*" colSpan="3">
											<IMG class="ico" title="新增/修改收件人" onclick="doGetAllMazRec()" height="18" src="../images/new.gif" border="0">&nbsp;
											<INPUT dataFld="雜誌收件人姓名" id="hiddenMazRec" type="hidden" size="6" name="hiddenMazRec" runat="server">
											<DIV id="lblMazRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
											</DIV>
											&nbsp;&nbsp;&nbsp;
											<asp:label id="lblTotalPubCount" runat="server" ForeColor="Maroon"></asp:label>
											&nbsp; <INPUT dataFld="總有登本數" id="hiddenTotalPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalPubCount" runat="server">&nbsp;
											<INPUT dataFld="總未登本數" id="hiddenTotalUnPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalUnPubCount" runat="server">
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- 廣告聯絡人資料 -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="廣告聯絡人資料" id="AdContactor" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="white">(6) 廣告聯絡人資料</font>
										</td>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											<FONT color="#cc0099">(6)</FONT> 廣告聯絡人姓名：
										</TD>
										<TD class="cssData">
											<FONT color="red">* </FONT><INPUT dataFld="廣告聯絡人姓名" id="tbxAuName" maxLength="30" size="10" name="tbxAUName" runat="server">
											&nbsp; <FONT face="新細明體" color="#c00000">(預設同客戶資料!)</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											&nbsp;
										</TD>
										<TD class="cssData" noWrap>
											&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											電話：
										</TD>
										<TD class="cssData">
											<FONT color="red">* </FONT><INPUT dataFld="廣告聯絡人電話" id="tbxAUTel" maxLength="30" size="10" name="tbxAUTel" runat="server">
											&nbsp; <FONT face="新細明體" color="#c00000">(預設同客戶資料!)</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											傳真：
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <INPUT dataFld="廣告聯絡人傳真" id="tbxAUFax" maxLength="30" size="10" name="tbxAUFax" runat="server">
											&nbsp; <FONT face="新細明體" color="#c00000">(預設同客戶資料!)</FONT>
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											手機：
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <INPUT dataFld="廣告聯絡人手機" id="tbxAUCell" maxLength="30" size="10" name="tbxAUCell" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											Email：
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <INPUT dataFld="廣告聯絡人Email" id="tbxAUEmail" maxLength="80" size="20" name="tbxAUEmail" runat="server">
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
				<!-- 落版刊登資料 -->
				<TABLE dataFld="合約書落版刊登資料" id="xmlAdpubData" style="WIDTH: 98%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="落版明細表" id="Table2" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 100%" colSpan="11">
											<FONT color="#ffffff">(10~12) 合約書落版刊登資料</FONT>&nbsp; <FONT color="yellow" size="2">(若落版第一筆的 
												'刊登年月' 未填, 將不做新增落版檔的處理, 您可稍後新增/維護之.)</FONT>
										</TD>
									</TR>
									<TR align="middle" borderColor="#bfcff0" bgColor="#bfcff0">
										<TD noWrap align="middle">
											功能
										</TD>
										<TD>
											序號
										</TD>
										<TD>
											<FONT color="red">* </FONT>刊登年月
											<br>
											(西元6碼, <FONT face="新細明體" color="#c00000">如 200203</FONT>)
											<br>
											/ <FONT color="red">* </FONT>書籍期別 <IMG class="ico" title="書籍期別參考資料" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
										</TD>
										<TD>
											刊登
											<br>
											頁碼
										</TD>
										<TD>
											固定
											<br>
											頁次
											<br>
											註記
											<br>
											<FONT face="新細明體" color="#c00000">(0: 否, 1:是)</FONT>
										</TD>
										<TD>
											廣告色彩
										</TD>
										<TD>
											廣告篇幅
											<br>
											<FONT face="新細明體" color="#c00000">(同月份
												<br>
												= &gt;半頁)</FONT>
										</TD>
										<TD>
											廣告版面
										</TD>
										<TD>
											到稿
											<br>
											註記
											<br>
											<FONT face="新細明體" color="#c00000">(0: 否, 1:是)</FONT>
										</TD>
										<TD>
											發票
											<br>
											收件人
										</TD>
										<TD>
											落版
											<br>
											細節
										</TD>
									</TR>
								</THEAD>
								<TR align="middle" borderColor="#bfcff0" bgColor="#e2eafc">
									<TD>
										<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" src="../images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
									</TD>
									<TD>
										<INPUT dataFld="序號" id="tbxPubSeq" readOnly type="text" maxLength="2" size="2" value="1" name="tbxPubSeq">
									</TD>
									<TD>
										<FONT color="red">* </FONT><INPUT dataFld="刊登年月" id="tbxPubDate" type="text" maxLength="6" size="6" name="tbxPubDate" onblur="Javascript:CheckPubDate(this);" onchange="Javascript:CheckPubDate2(this);">
										/ <FONT color="red">* </FONT><INPUT dataFld="書籍期別" id="tbxBkpPno" type="text" maxLength="4" size="3" name="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);">
										<IMG class="ico" title="書籍期別參考資料" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
									</TD>
									<TD>
										<INPUT dataFld="刊登頁碼" id="tbxPageNo" type="text" maxLength="3" size="3" name="tbxPageNo">
									</TD>
									<TD>
										<INPUT dataFld="固定頁次註記" id="tbxfgFixPage" type="text" maxLength="1" size="3" name="tbxfgFixPage" onblur="Javascript:CheckfgFixPage(this);">
									</TD>
									<TD>
										<SELECT dataFld="廣告色彩代碼" id="ddlColorCode" name="ddlColorCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="廣告篇幅代碼" id="ddlPageSizeCode" name="ddlPageSizeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="廣告版面代碼" id="ddlLTypeCode" name="ddlLTypeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<INPUT dataFld="到稿註記" id="" type="text" maxLength="1" size="1" value="0" name="tbxfgGot" onblur="Javascript:CheckfgGot(this);">
									</TD>
									<TD>
										<IMG class="ico" title="發票廠商收件人詳細資料" onclick="doSelectIMRec(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenIMDetail" type="hidden" size="1" name="hiddenIMDetail" runat="server">
										<LABEL id="lblSingleIMRec" style="COLOR: maroon"></LABEL>
									</TD>
									<TD>
										<IMG class="ico" title="落版細節" onclick="doEditPub(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenPubDetail" type="hidden" size="1" name="hiddenPubDetail" runat="server">
									</TD>
								</TR>
							</TABLE>
							<FONT face="新細明體">註: <font color="#cc0099">數字標示部份</font>表示對映到原書面稿之文字部份, 以方便輸入本電子表單.</FONT>&nbsp;
							<br>
							<FONT face="新細明體">註: 若某欄位前面有 <FONT color="red">* </FONT>符號, 表示該欄是必填資料, 不可空白!</FONT>
							<br>
							<!-- hiddenXML 欄 -->
							<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">
						</TD>
					</TR>
				</TABLE>
				<!-- Form按鈕 -->
				<DIV align="center">
					<input id="btnSave" onclick="doSubmit()" type="button" value="儲存修改" name="btnSave">&nbsp;&nbsp;
					<input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="取消回首頁" name="btnCancel">
				</DIV>
			</form>
			<br>
			<!-- 此 TEXTAREA 是供檢查 XML 輸出檢查用 -->
			<!--TEXTAREA id="textarea1" name="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// 本段使用 xmlDoc1 取代 xmlDoc0 (不同於 cont_new3.aspx)
		
		
		// 先定義 Object: DSO1, 設定 async = false
		DSO1.XMLDocument.async = false; 
		
		// 定義 xmlDoc1: 歷史的 XML 資料
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.loadXML(document.all("hiddenXML").value);
		//alert(xmlDoc1.xml);
		
		// 定義 xmlDoc1: 歷史的 XML 資料
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.loadXML(document.all("hiddenXML").value);
		//alert(xmlDoc1.xml);
		
		// 定義 xmlDoc1 裡的各 XML節點之名稱及其內容
		var xmlMain = xmlDoc1.selectSingleNode("/root");
		var xmlHeader = xmlDoc1.selectSingleNode("/root/合約書內容");
		
		var xmlMfrData = xmlDoc1.selectSingleNode("/root/合約書內容/廠商資料");
		var xmlCustData = xmlDoc1.selectSingleNode("/root/合約書內容/客戶資料");
		var xmlContBasicData = xmlDoc1.selectSingleNode("/root/合約書內容/合約書基本資料");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/合約書內容/寄發票收件人資料");
		var xmlContDetail = xmlDoc1.selectSingleNode("/root/合約書內容/合約書細節");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/發票廠商資料");
		var xmlMazRec = xmlDoc1.selectSingleNode("/root/雜誌收件人資料");
		//alert(xmlMazRec.xml);
					// 預設指定 雜誌收件人公司名稱, 雜誌收件人地址 = 公司名稱, 公司地址(發票收件人地址)
			// 注意: Javascript 最好放於 BODY 之後, 以免類似 下面 alert 會出現 error
			// PS. 下二行的結果是一樣的
			//alert(document.cont_new3("hiddenMfrName").value);
			//alert(document.all("hiddenMfrNo").value);
			//alert(document.all("hiddenMfrName").value);
			//alert(document.all("hiddenMfrAddress").value);
			//alert(document.all("hiddenMfrZipcode").value);
			//xmlInvRec.childNodes.item(0).selectSingleNode("發票廠商序號").text="1";
			//xmlInvRec.childNodes.item(0).selectSingleNode("系統代碼").text="C2";
			//xmlInvRec.childNodes.item(0).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人廠商統編").text=document.all("hiddenMfrNo").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人地址").text=document.all("hiddenMfrAddress").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人郵遞區號").text=document.all("hiddenMfrZipcode").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人電話").text=document.all("hiddenMfrTel").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人傳真").text=document.all("hiddenMfrFax").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人職稱").text=document.all("hiddenMfrRespJobTitle").value;
			
			//xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人序號").text="1";
			//xmlMazRec.childNodes.item(0).selectSingleNode("系統代碼").text="C2";
			//xmlMazRec.childNodes.item(0).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人公司名稱").text=document.all("hiddenMfrName").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人地址").text=document.all("hiddenMfrAddress").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人郵遞區號").text=document.all("hiddenMfrZipcode").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人電話").text=document.all("hiddenMfrTel").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人傳真").text=document.all("hiddenMfrFax").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人職稱").text=document.all("hiddenMfrRespJobTitle").value;
		
		var xmlAdContactor = xmlDoc1.selectSingleNode("/root/合約書內容/廣告聯絡人資料");
			
		var xmlAdpubData = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料");
		var xmlAdpubItems = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表");
		var xmlAdpubItemInvRec = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
		var xmlAdpubItemDetails = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
		// 用 windows.alert 方式來顯示出 xmlAdpubItems 的內容 (或可改為其他變數名稱), 做為檢查用
		//alert("合約書內容= " + xmlHeader.xml);
		
		// 定義 xmlDocX, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSOX.XMLDocument;
		xmlEmptyAdpubData.load("空白落版刊登資料.xml");

		
		// --- 以下為新的 coding (與 cont_new3.aspx 不同處)
		// 先檢查是否有抓到 xmlDoc1 的資料 (即 hiddenXML 的資料)
		//alert("xmlInvRec= " + xmlInvRec.xml);
		//alert("xmlInvRec2= " + xmlHeader.selectSingleNode("寄發票收件人資料").xml);
		//alert("xmlHeader寄發票收件人電話= " + xmlHeader.selectSingleNode("寄發票收件人資料/寄發票收件人電話").xml);
		//alert("xmlInvRec寄發票收件人電話= " + xmlInvRec.selectSingleNode("寄發票收件人電話").xml);
		//alert("xmlContBasicData一次付清註記= " + xmlContBasicData.selectSingleNode("一次付清註記").xml);
		
		// 先自書籍類別代碼抓出 "計劃代號, 成本中心"	
		//var BkcdProjCost = window.document.all("hiddenBkcdProjCost").value;
		//alert("BkcdProjCost= " + BkcdProjCost);
		//var BookCode = window.document.all("ddlBookCode").value;
		//var BookCode = BkcdProjCost.substr(0, 2);
		//alert("BookCode= " + BookCode);
		//var ProjNo = BkcdProjCost.substr(2, 10);
		//alert("ProjNo= " + ProjNo);
		//alert("ProjNo= " + window.document.all("hiddenProjNo").value);
		//var CostCtr = BkcdProjCost.substr(12, 7);
		//alert("CostCtr= " + CostCtr);
		
		
		// 抓出挑選出的所有發票廠商收件人姓名, 並以 "," 符號隔開;
		strbuf1 = "";
		for(i=0; i<xmlInvRec.childNodes.length; i++)
		{
			// 確認合約書編號為 新增的編號, 以免新增入 table 時有誤
			xmlInvRec.childNodes.item(i).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
			//strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("發票收件人廠商抬頭").text + "-" + xmlInvRec.childNodes.item(i).selectSingleNode("發票收件人姓名").text + ", ";	//發票收件人廠商抬頭+發票收件人姓名 欄
			strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("發票收件人姓名").text + ", ";	//發票收件人姓名 欄
		}
		//alert("strbuf=" + strbuf);	
		// 把得出之結果寫回到畫面裡 
		document.all("lblInvRec").innerText = strbuf1;
		
		
		// 抓出落版之單一發票收件人姓名
		var idx=xmlAdpubData.childNodes.length;
		var Items = xmlAdpubData.xml;
		strbuf="";
		for(i=0; i<idx; i++){
			Items=xmlAdpubData.childNodes.item(i).selectSingleNode("發票廠商收件人細節");
			//alert("Items(" + i + ")= " + Items.xml);
			//alert("Items.發票收件人姓名(" + i + ")= " + Items.childNodes.item(0).selectSingleNode("發票收件人姓名").text);
			//alert("strbuf= " + strbuf);
			strbuf=Items.childNodes.item(0).selectSingleNode("發票收件人姓名").text;	//<發票收件人姓名>為第二欄
			// 把得出之結果寫回到畫面裡 
			document.all("lblSingleIMRec").innerText = strbuf;
		}
		//event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
		
		
		// 抓出挑選出的所有雜誌收件人姓名, 並以 "," 符號隔開; 並抓出 有登本數 & 未登本數的加總
		strbuf2 = "";
		var TotalPubCount = 0;
		var TotalUnPubCount = 0;
		for(i=0; i<xmlMazRec.childNodes.length; i++)
		{
			// 確認合約書編號為 新增的編號, 以免新增入 table 時有誤
			xmlMazRec.childNodes.item(i).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
			strbuf2 += xmlMazRec.childNodes.item(i).selectSingleNode("雜誌收件人姓名").text + ", ";	//雜誌收件人姓名 欄
			TotalPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("有登本數").text);	//有登本數 欄
			TotalUnPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("未登本數").text);	//未登本數 欄
		}
		//alert("strbuf2=" + strbuf2);
		// 把得出之結果寫回到新增畫面裡 
		// 目前 總有登本數 & 總未登本數 只有寫到畫面上顯示, 而尚未寫回入 xml 或 DB 喔!
		document.all("lblTotalPubCount").innerText = "(總有登本數: " + TotalPubCount + " / 總未登本數: " + TotalUnPubCount + ")";
		//xmlContBasicData.selectSingleNode("總有登本數").text = String(TotalPubCount);
		//xmlContBasicData.selectSingleNode("總未登本數").text = String(TotalUnPubCount);
		document.all("lblMazRec").innerText = strbuf2;
		-->
		</script>
		<script language="javascript">
		<!--
		// 合約書落版刊登資料的功能按鈕: doAddNew, doDelete
			// 新增落版資料項
			function doAddNew(obj)
			{
				var idx = xmlAdpubData.childNodes.length;
				//alert("idx= " + idx);
				
				// 顯示 NodeList 其內容: 二選一方式
				//alert(xmlAdpubData.childNodes.item(0).xml);

				//var xx = "";
				//for(var i=0; i<idx; i++)
				//{
					 //xx+= xmlAdpubData.childNodes.item(i).xml;
				//}
				//alert("xmlAdpubData ="+xx);
				
				
				// index 由 0 開始, 所以 item(0); 並顯示出其序號及刊登日期
				//var newNode = xmlAdpubData.childNodes.item(idx-1).cloneNode(true);
				var newNode = xmlEmptyAdpubData.documentElement.cloneNode(true);
				//alert("newNode= " + newNode.xml)
				
				// 若使用下一行 (表示先在新增一行前, 先將序號加一); 則不用使用下面第二行; 此二行做的事是一樣的, 請二選一
				//newNode.selectSingleNode("序號").text = idx + 1;
				xmlAdpubData.appendChild(newNode);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text = idx + 1;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("落版序號").text = idx + 1;
				
				// 此處為填入第二筆落版資料的預設值, 第一筆的預設值寫在 Submit() 裡
				// 指定 cloneNode 裡的預設值
				xmlAdpubData.childNodes.item(idx).selectSingleNode("客戶編號").text=window.document.all("hiddenCustNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("合約書編號").text=window.document.all("hiddenContNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("合約類別代碼").text=window.document.all("hiddenContType").value;
				
				// 先自書籍類別代碼抓出 "計劃代號, 成本中心"
				var BkcdProjCost = window.document.all("ddlBookCode").value;
				window.document.all("hiddenBkcdProjCost").value = BkcdProjCost;
				//alert("BkcdProjCost= " + BkcdProjCost);
				var BookCode = BkcdProjCost.substr(0, 2)
				var ProjNo = BkcdProjCost.substr(2, 10);
				var CostCtr = BkcdProjCost.substr(12, 7);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍全碼").text=BkcdProjCost;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍類別代碼").text=BookCode;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("計劃代號").text=ProjNo;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("成本中心").text=CostCtr;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("樣後修改註記").text=0;
				// 將 落版最後修改日期 Reformat 去除 "/", 以免新增入 c2_pub 時 (因使用 sp_c2_cont_newSave_pub 受限, 必須在新增前先確認資料正確) , 無法去除其 "/", 而造成資料有誤
				var PubModDate = window.document.all("hiddenModDate").value;
				PubModDate = PubModDate.substring(0, 4) + PubModDate.substring(5, 7) + PubModDate.substring(8, 10);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("落版最後修改日期").text=PubModDate;
				// 下一行 coding 與 cont_show.aspx 不同 (同 cont_new3.aspx)
				xmlAdpubData.childNodes.item(idx).selectSingleNode("落版修改業務員工號").text=window.document.all("ddlEmpNo").value;
				
				//xmlAdpubData.childNodes.item(idx).selectSingleNode("落版細節").text=xmlAdpubData.childNodes.item(idx-1).selectSingleNode("落版細節").text;
				
				// 檢查每一行的出現的序號值是否正確
				//alert("idx= " + idx);
				//alert("序號= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text);
				//alert("落版序號= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("落版序號").text);
				
				//alert(xmlAdpubData.xml);
				
			}

			// 刪除落版資料項
			function doDelete(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				//alert("idx= " + idx);
				var oldNode = xmlAdpubData.childNodes.item(idx);
				//alert("oldNode= " + oldNode);
								
				if(xmlAdpubData.childNodes.length > 1)
				{
					oldNode.parentNode.removeChild(oldNode);
					// 刪除 序號
					for(i=0; i<xmlAdpubData.childNodes.length;i++)
					{
						xmlAdpubData.childNodes.item(i).selectSingleNode("序號").text=i+1;
						xmlAdpubData.childNodes.item(i).selectSingleNode("落版序號").text=i+1;
					}
				}
				
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// cal按鈕的 coding: 抓系統日期
		function pick_date(theField)
		{
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			window.document.all(theField).value=vreturn;
			return true;
			
			// 下段不用 run, 因 doSubmit() 已寫入 xmlContBasicData.selectSingleNode("簽約日期").text 資料
			//if(vreturn)
				//xmlContBasicData.selectSingleNode("簽約日期").text=vreturn;
			//return true;
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 檢查 合約起日 的值是否合理
		function checkContSDate(obj)
		{
			var StartDate = document.all("tbxStartDate").value;
			//alert("StartDate= " + StartDate);
			
			// 若輸入型態為 6碼年月(無 "/" 符號), 則自動轉換其格式為 'xxxx(4碼年)/xx(2碼月)', 如 '2002/05'
			if(StartDate.length==6)  {
				var StartDate = document.all("tbxStartDate").value;
				document.all("tbxStartDate").value=StartDate.substring(0, 4) + "/" + StartDate.substring(4, 6);
				//alert(document.all("tbxStartDate").value);
				
				// 檢查 合約起日之年月是否合理化 : 年(4碼, 1990~2200), 月(01~12)
				var yyyy = StartDate.substring(0, 4);
				var mm = StartDate.substring(4, 6);
				
				// 判斷年度是否合理化
				if(yyyy<=1990 || yyyy>=2200)  {
					alert("注意: 合約起日之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請馬上更正!");
					document.all("tbxStartDate").focus();
					return;
				}
				
				// 判斷月份是否合理化
				if(mm>12 || mm<=0)  {
					alert("注意: 合約起日之月份 '" + mm + "' 不合理, 請馬上更正!");
					document.all("tbxStartDate").focus();
					return;
				}
				
				// 判斷合約起日之年月是否為 數值型態
				if(isNaN(yyyy)==true)  {
					alert("合約書細節之 '合約起日之年份' 必須輸入數字型態!");
					document.all("tbxStartDate").focus();
					return;
				}
				if(isNaN(mm)==true)  {
					alert("合約書細節之 '合約起日之月份' 必須輸入數字型態!");
					document.all("tbxStartDate").focus();
					return;
				}
				
			}
			// 若輸入型態不為 6碼
			else
			{
				// 檢查 合約起日 之長度合理性: 若不滿 7, 則予以警告
				if(StartDate.length!=7)  {
					alert("很抱歉, 合約起日的值須符合 'xxxx(4碼年)/xx(2碼月)', 如 '2002/05'\n 請修正!");
					document.all("tbxStartDate").focus();
					return;
				}
				// 若輸入型態為 標準 7碼
				else
				{
					// 檢查 合約起日之年月 是否合理化 : 年(4碼, 1990~2200), 月(01~12)
					var yyyy = StartDate.substring(0, 4);
					var mm = StartDate.substring(5, 7);
					
					// 判斷年度是否合理化
					if(yyyy<=1990 || yyyy>=2200)
					{
						alert("注意: 合約起日之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請馬上更正!");
						document.all("tbxStartDate").focus();
						return;
					}
					
					// 判斷月份是否合理化
					if(mm>12 || mm<=0)
					{
						alert("注意: 合約起日之月份 '" + mm + "' 不合理, 請馬上更正!");
						document.all("tbxStartDate").focus();
						return;
					}
					
					// 判斷合約起日之年月是否為 數值型態
					if(isNaN(yyyy)==true)  {
						alert("合約書細節之 '合約起日之年份' 必須輸入數字型態!");
						document.all("tbxStartDate").focus();
						return;
					}
					if(isNaN(mm)==true)  {
						alert("合約書細節之 '合約起日之月份' 必須輸入數字型態!");
						document.all("tbxStartDate").focus();
						return;
					}
					
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 檢查 合約迄日 的值是否合理
		function checkContEDate(obj)
		{
			var EndDate = document.all("tbxEndDate").value;
			//alert("EndDate= " + EndDate);

			// 若輸入型態為 6碼年月(無 "/" 符號), 則自動轉換其格式為 'xxxx(4碼年)/xx(2碼月)', 如 '2002/05'
			if(EndDate.length==6)  {
				var EndDate = document.all("tbxEndDate").value;
				document.all("tbxEndDate").value=EndDate.substring(0, 4) + "/" + EndDate.substring(4, 6);
				//alert(document.all("tbxEndDate").value);
				
				// 檢查 合約迄日之年月是否合理化 : 年(4碼, 1990~2200), 月(01~12)
				var yyyy = EndDate.substring(0, 4);
				var mm = EndDate.substring(4, 6);
				
				// 判斷年度是否合理化
				if(yyyy<=1990 || yyyy>=2200)  {
					alert("注意: 合約起日之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請馬上更正!");
					document.all("tbxEndDate").focus();
					return;
				}
				
				// 判斷月份是否合理化
				if(mm>12 || mm<=0)  {
					alert("注意: 合約迄日之月份 '" + mm + "' 不合理, 請馬上更正!");
					document.all("tbxEndDate").focus();
					return;
				}
				
				// 判斷合約起日之年月是否為 數值型態
				if(isNaN(yyyy)==true)  {
					alert("合約書細節之 '合約迄日之年份' 必須輸入4碼數字型態!");
					document.all("tbxEndDate").focus();
					return;
				}
				if(isNaN(mm)==true)  {
					alert("合約書細節之 '合約迄日之月份' 必須輸入2碼數字型態!");
					document.all("tbxEndDate").focus();
					return;
				}
				
			}
			// 若輸入型態不為 6碼
			else
			{		
				// 檢查 合約起日 之長度合理性: 若不滿 7, 則予以警告
				if(EndDate.length!=7)  {
					alert("很抱歉, 合約起日的值須符合 'xxxx(4碼年)/xx(2碼月)', 如 '2002/05'\n 請修正!");
					document.all("tbxEndDate").focus();
					return;
				}
				// 若輸入型態為 標準 7碼
				else
				{	
					// 檢查 合約起日之年月 是否合理化 : 年(4碼, 1990~2200), 月(01~12)
					var yyyy = EndDate.substring(0, 4);
					var mm = EndDate.substring(5, 7);
					
					// 判斷合約起日之年度是否合理化
					if(yyyy<=1990 || yyyy>=2200)
					{
						alert("注意: 合約迄日之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請馬上更正!");
						document.all("tbxEndDate").focus();
						return;
					}
					
					// 判斷合約起日之月份是否合理化
					if(mm>12 || mm<=0)
					{
						alert("注意: 合約迄日之月份 '" + mm + "' 不合理, 請馬上更正!");
						document.all("tbxEndDate").focus();
						return;
					}
					
					// 判斷合約起日之年月是否為 數值型態
					if(isNaN(yyyy)==true)  {
						alert("合約書細節之 '合約迄日之年份' 必須輸入4碼數字型態!");
						document.all("tbxEndDate").focus();
						return;
					}
					if(isNaN(mm)==true)  {
						alert("合約書細節之 '合約迄日之月份' 必須輸入2碼數字型態!");
						document.all("tbxEndDate").focus();
						return;
					}
					
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 預設 總製稿次數 = 換稿次數
		function checkTotalJTime(obj)
		{
			var TotalJTime = document.all("tbxTotalJTime").value;
			//alert("TotalJTime= " + TotalJTime);
			
			// 檢查 總製稿次數 是否輸入為 數字型態
			if(isNaN(TotalJTime)==true)  {
				alert("合約書細節之 '總製稿次數' 必須輸入數字型態!");
				document.all("tbxTotalJTime").focus();
				return;
			}
			// 若是, 則檢查輸出型態是否正確
			else  {
				document.all("tbxTotalJTime").value = TotalJTime;
				document.all("tbxChangeJTime").value = TotalJTime;
				document.all("hiddenTotalJTime").value = TotalJTime;
			}
			
			
			// 與 cont_new3.aspx 不同處 : 若更改總製稿次數, 不但要變更 換稿次數, "剩餘製稿次數" 也要變更.
			var RestJTime = document.all("tbxRestJTime").value;
			//alert("RestJTime= " + RestJTime);
			
			// 檢查 剩餘製稿次數 是否輸入為 數字型態
			if(isNaN(RestJTime)==true)  {
				alert("合約書細節之 '剩餘製稿次數' 必須輸入數字型態!");
				document.all("tbxRestJTime").focus();
				return;
			}
			// 若是, 則檢查輸出型態是否正確
			else  {
				// 剩餘製稿次數 = 總製稿次數 - 已製稿次數
				document.all("tbxRestJTime").value = parseInt(TotalJTime) - parseInt(document.all("tbxMadeJTime").value);
				xmlContDetail.selectSingleNode("剩餘製稿次數").text = document.all("tbxRestJTime").value
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 依 已製稿次數 計算 剩餘製稿次數
		function checkRestJTime(obj)
		{
			var TotalJTime = document.all("tbxTotalJTime").value;
			var MadeJTime = document.all("tbxMadeJTime").value;
			//alert("PaidAmt= " + PaidAmt);
			
			// 檢查 已繳金額 是否輸入為 數字型態
			if(isNaN(MadeJTime)==true)  {
				alert("合約書細節之 '已製稿次數' 必須輸入數字型態!");
				document.all("tbxMadeJTime").focus();
				return;
			}
			// 若是, 則檢查輸出型態是否正確
			else  {
				document.all("tbxMadeJTime").value = MadeJTime;
				
				// 檢查 已製稿次數 是否超過 總製稿次數
				if(parseInt(MadeJTime)>parseInt(TotalJTime))  {
					alert("已製稿次數 超過 總製稿次數!  請修正");
					document.all("tbxMadeJTime").focus();
					return;
				}
				else
				{
					// 剩餘製稿次數 = 總製稿次數 - 已製稿次數
					document.all("tbxRestJTime").value = parseInt(TotalJTime) - parseInt(MadeJTime);
					xmlContDetail.selectSingleNode("已製稿次數").text = document.all("tbxMadeJTime").value;
					document.all("hiddenTotalJTime").value = parseInt(TotalJTime);
					xmlContDetail.selectSingleNode("剩餘製稿次數").text = document.all("tbxRestJTime").value;
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 判別 總刊登次數 <= 合約起迄次數內 (若每個月一次), 如合約起迄為 12個月, 則其總刊登次數不應超過 12次
		function checkTotalTime(obj)
		{
			var TotalTime = document.all("tbxTotalTime").value;
			//alert("TotalTime= " + TotalTime);
			
			// 檢查是否輸入為 數字型態
			if(isNaN(TotalTime)==true)  {
				alert("合約書細節之 '總刊登次數' 必須輸入數字型態!");
				document.all("tbxTotalTime").focus();
				return;
			}
			// 若是數字型態, 則檢查輸出格式是否正確
			else
			{
				//document.all("hiddenTotalTime").value = TotalTime;
				
				// 抓出 合約起日~合約迄日的月份數目, 即 總刊登次數 的 Max
				var StartDate = document.all("tbxStartDate").value;
				var EndDate = document.all("tbxEndDate").value;
				//alert("StartDate= " + StartDate);
				//alert("EndDate= " + EndDate);
				// 先抓出 各別之 年份 & 月份
				StartDate = StartDate.substring(0, 4) + StartDate.substring(5, 7);
				var StartDateyyyy = StartDate.substring(0, 4);
				var StartDatemm = StartDate.substring(4, 6);
				EndDate = EndDate.substring(0, 4) + EndDate.substring(5, 7);
				var EndDateyyyy = EndDate.substring(0, 4);
				var EndDatemm = EndDate.substring(4, 6);
				var Diffyyyy = parseInt(EndDateyyyy) - parseInt(StartDateyyyy);
				//alert("Diffyyyy= " + Diffyyyy);

				var DiffMonths = 0;			
				// 檢查是否為同年份
				// 若 起迄日 相同年份, 月份直接相減, 如 200201~200211  => 10 個月
				if(Diffyyyy==0)
				{
					DiffMonths = parseInt(EndDatemm) - parseInt(StartDatemm);
				}
				// 若 起迄日 不同年份, 則 [迄日年份別(*12) +迄日月份]
				// 如 200205~200312 => ( [(2003-2002)*12 + 04] -05 ) + 01 = 20 個月
				else
				{
					//DiffMonths = ((Diffyyyy*12) + parseInt(EndDatemm) ) - parseInt(StartDatemm) + 1
					DiffMonths = ((Diffyyyy*12) + parseInt(EndDatemm) ) - parseInt(StartDatemm) + 1
				}
				//alert("DiffMonths= " + DiffMonths);
				
				// 檢查 總刊登次數 是否超過 Max (合約起迄日的月份差)
				if(document.all("tbxTotalTime").value>DiffMonths)
				{
					var DiffTime = parseInt(TotalTime) - DiffMonths;
					alert("合約書細節之 '總刊登次數' 超過合約起迄(月份) " + DiffTime + " 次");
					return;
				}
				
				// 剩餘刊登次數 = 總刊登次數 - 已刊登次數
				document.all("tbxRestTime").value = parseInt(TotalTime) - parseInt(document.all("tbxPubTime").value);
				xmlContDetail.selectSingleNode("剩餘刊登次數").text = document.all("tbxRestTime").value
				
				
				// 與 cont_new3.aspx 不同處 : 若更改總刊登次數, "剩餘刊登次數" 也要變更.
				var RestTime = document.all("tbxRestTime").value;
				//alert("RestTime= " + RestTime);
				
				// 檢查 剩餘刊登次數 是否輸入為 數字型態
				if(isNaN(RestTime)==true)  {
					alert("合約書細節之 '剩餘刊登次數' 必須輸入數字型態!");
					document.all("tbxRestTime").focus();
					return;
				}
				// 若是, 則檢查輸出型態是否正確
				else  {
					document.all("tbxTotalTime").value = TotalTime;
					document.all("hiddenTotalTime").value = TotalTime;
					
					// 剩餘刊登次數 = 總刊登次數 - 已刊登次數
					document.all("tbxRestTime").value = parseInt(TotalTime) - parseInt(document.all("tbxPubTime").value);
					xmlContDetail.selectSingleNode("剩餘刊登次數").text = document.all("tbxRestTime").value
				}
				
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 依 已刊登次數 計算 剩餘刊登次數
		function checkRestTime(obj)
		{
			var TotalTime = document.all("tbxTotalTime").value;
			var PubTime = document.all("tbxPubTime").value;
			//alert("PubTime= " + PubTime);
			
			// 檢查 已繳金額 是否輸入為 數字型態
			if(isNaN(PubTime)==true)  {
				alert("合約書細節之 '已刊登次數' 必須輸入數字型態!");
				document.all("tbxPubTime").focus();
				return;
			}
			// 若是, 則檢查輸出型態是否正確
			else  {
				document.all("tbxPubTime").value = PubTime;
				
				// 檢查 已繳金額 是否超過 合約總金額
				if(parseInt(PubTime)>parseInt(TotalTime))  {
					alert("已刊登次數 超過 總刊登次數!  請修正");
					document.all("tbxPubTime").focus();
					return;
				}
				else
				{
					// 剩餘刊登次數 = 總刊登次數 - 已刊登次數
					document.all("tbxRestTime").value = parseInt(TotalTime) - parseInt(PubTime);
					xmlContDetail.selectSingleNode("已刊登次數").text = document.all("tbxPubTime").value
					xmlContDetail.selectSingleNode("剩餘刊登次數").text = document.all("tbxRestTime").value
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 依 合約總金額 計算 已繳金額, 剩餘金額
		function checkTotalAmt(obj)
		{
			var TotalAmt = document.all("tbxTotalAmt").value;
			//alert("TotalAmt= " + TotalAmt);
			
			// 檢查 合約總金額 是否輸入為 數字型態
			if(isNaN(TotalAmt)==true)  {
				alert("合約書細節之 '合約總金額' 必須輸入數字型態!");
				document.all("tbxTotalAmt").focus();
				return;
			}
			// 若是, 則檢查輸出型態是否正確
			else  {
				document.all("tbxTotalAmt").value = TotalAmt;
				
				// 剩餘金額 = 合約總金額 - 已繳金額
				document.all("tbxRestAmt").value = parseInt(TotalAmt) - parseInt(document.all("tbxPaidAmt").value);
				xmlContDetail.selectSingleNode("剩餘金額").text = document.all("tbxRestAmt").value
				
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 依 已繳金額 計算 剩餘金額
		function checkRestAmt(obj)
		{
			var TotalAmt = document.all("tbxTotalAmt").value;
			var PaidAmt = document.all("tbxPaidAmt").value;
			//alert("PaidAmt= " + PaidAmt);
			
			// 檢查 已繳金額 是否輸入為 數字型態
			if(isNaN(PaidAmt)==true)  {
				alert("合約書細節之 '已繳金額' 必須輸入數字型態!");
				document.all("tbxPaidAmt").focus();
				return;
			}
			// 若是, 則檢查輸出型態是否正確
			else  {
				document.all("tbxPaidAmt").value = PaidAmt;
				
				// 檢查 已繳金額 是否超過 合約總金額
				if(parseInt(PaidAmt)>parseInt(TotalAmt))  {
					alert("已繳金額 超過 合約總金額!  請修正");
					document.all("tbxPaidAmt").focus();
					return;
				}
				else
				{
					// 剩餘金額 = 合約總金額 - 已繳金額
					document.all("tbxRestAmt").value = parseInt(TotalAmt) - parseInt(PaidAmt);
					xmlContDetail.selectSingleNode("已繳金額").text = document.all("tbxPaidAmt").value
					xmlContDetail.selectSingleNode("剩餘金額").text = document.all("tbxRestAmt").value
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 若優惠折數不為實數, 而為整數型態, 將之更正
		function checkDiscount(obj)
		{
			var Discount = document.all("tbxDiscount").value;
			//alert("Discount= " + Discount);
			
			// 檢查是否輸入為 數字型態
			if(isNaN(Discount)==true)  {
				alert("合約書細節之 '優惠折數' 必須輸入數字型態!");
				document.all("tbxDiscount").focus();
				return;
			}
			// 若是, 則檢查輸出型態是否正確
			else  {
				//alert("Discount.substring(0, 2)= " + Discount.substring(0, 2));
				if(Discount.substring(0, 2) == "0.")  {
					Discount = Discount;
				}
				else  {
					Discount = "0." + Discount;
				}
				//alert("Discount= " + Discount);
				document.all("tbxDiscount").value = Discount;
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//檢查落版輸入之 "刊登年月" 的值是否正確
		function CheckPubDate(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// 判斷刊登年月的長度是否為 6碼
			var yyyymm = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			if(yyyymm.length!=6)
			{
				alert("落版第 " + (idx+1) + " 筆 '刊登年月' 的長度必須為 6碼(西元), 請修正!");
				return;
			}
			// 若刊登年月的長度為 6碼 (合理)
			else
			{
				// 檢查是否輸入為 數字型態
				if(isNaN(yyyymm)==true)
					alert("落版第 " + (idx+1) + " 筆的 '刊登年月' 必須輸入數字型態!");
				
				// 判斷刊登年月是否在 合約起迄日 範圍內
				var ContStartDate = window.document.all("tbxStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("tbxEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				//alert("ContStartDate= " + ContStartDate);
				//alert("ContEndDate= " + ContEndDate);
				if(xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text<ContStartDate || xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text>ContEndDate)
				{
					alert("落版第 " + (idx+1) + " 筆 '刊登年月' 必須在合約起迄範圍內, 請修正!");
					return;
				}
				
				// 並判斷西元刊登年月是否合理化 : 年(4碼, 1990~2200), 月(01~12)
				var yyyy = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text.substring(0, 4);
				var mm = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text.substring(4, 6);

				// 判斷西元刊登年度是否合理化
				if(yyyy<=1990 || yyyy>=2200)
				{
					alert("注意: 落版第 " + (idx+1) + " 筆的刊登年月之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請更正!");
					return;
				}
				else
					yyyymm = yyyymm;
				
				// 判斷西元刊登月份是否合理化
				if(mm>12 || mm<=0)
				{
					alert("注意: 落版第 " + (idx+1) + " 筆的刊登年月之月份 '" + mm + "' 不合理, 請更正!");
					return;
				}
				else
					yyyymm = yyyymm;			
			// 結束 - 若刊登年月的長度為 6碼 (合理)
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 提示因 '刊登年月' 變更, 必須更新 '書籍期別' 的值 (再按一下)
		function CheckPubDate2(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			if(xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text != "")
				alert("您更新了 落版第 " + (idx+1) + " 筆之 '刊登年月' !\n 請再按一下落版第 " + (idx+1) + " 筆之 '書籍期別' 旁的按鈕來更新資料!!!");
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 檢查 "書籍期別" 一欄是否有輸入
		function CheckBookPNo(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);

			var BookPNo = xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍期別").text;
			// 若書籍期別沒有輸入
			if(BookPNo.length==0)
			{
				//alert("落版第 " + (idx+1) + " 筆的 '書籍期別' 為必填!\n 請按下右方按鈕來挑選!");
				return;
			}
			else
			{
				// 檢查是否輸入為 數字型態
				if(isNaN(BookPNo)==true)
					alert("落版第 " + (idx+1) + " 筆的 '書籍期別' 必須輸入數字型態!");
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="書籍期別參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		function doGetBookp(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			myObject.flag=true;
			
			//alert("xmlAdpubItems.xml= " + xmlAdpubItems.xml);
			myObject.xmldata = xmlAdpubItems.xml;
			//myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// 指定傳過去的變數 - 抓出 書籍類別代碼 & 刊登年月, 來找出 書籍期別
			var bkcd = document.all("ddlBookCode").value.substring(0, 2);
			var ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			//alert("ym= " + ym);
			myObject.bkcd = document.all("ddlBookCode").value.substring(0, 2);
			myObject.ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			var PageName = "bookp_get.aspx?bkcd=" + bkcd + "&ym=" + ym;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:420px;dialogWidth:350px;dialogLeft:250px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result= " + myObject.result);
			
			if(vreturn)  {
				xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍期別").text = myObject.result;
				// 解決若沒輸入 刊登年月時, 直接按 '書籍期別', 而刊登年月為空 的情況
				xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text = myObject.yyyymm;
				
				// 同上之方法二 - 解決若沒輸入 刊登年月時, 直接按 '書籍期別', 而刊登年月為空 的情況
				//if(xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text=="")  {
					//var CurrentDate = new Date();
					//var Currentyyyy = CurrentDate.getFullYear();
					//var Currentmm = CurrentDate.getMonth()+1;
					//if(Currentmm.length!=2)
						//Currentmm = "0" + Currentmm;
					//var Currentym = Currentyyyy + Currentmm;
					//xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text=Currentym;
				//}
				return true;
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//檢查落版輸入之 "固定頁次註記" 的值是否正確
		function CheckfgFixPage(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgFixPage = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("固定頁次註記").text);
			if(fgFixPage!=1 && fgFixPage!=0)
			{
				alert("落版第 " + (idx+1) + " 筆的固定頁次註記的值錯誤, 請重新輸入!");
				return;
				//window.document.all("tbxfgFixPage").focus();
			}
			
		}
		
		//-->
		</script>
		<script language="javascript">
		<!--
		//檢查落版輸入之 "到稿註記" 的值是否正確
		function CheckfgGot(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgGot = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("到稿註記").text);
			//alert((idx+1) + ", fgFixPage= " + fgFixPage);
			if(fgGot!=1 && fgGot!=0)
			{
				alert("落版第 " + (idx+1) + " 筆的到稿註記的值錯誤, 請重新輸入!");
				return;
				//window.document.all("tbxfgGot").focus();
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 抓出所有發票廠商收件人之姓名的功能按鈕: doGetAllMazRec()
		function doGetAllInvRec() 
		{
			var myObject = new Object();
			//alert("hiddenInvRec= " + document.all("hiddenInvRec").value);
			
			// 若 hiddenInvRec 無資料: 則顯示訊息 "沒有歷史資料..."
			// 若 hiddenInvRec 有資料: 抓出 hiddenInvRec 裡的歷史資料
			if(document.all("hiddenInvRec").value=="")
			{
				myObject.flag=false;
				alert("沒有歷史資料, 請自行輸入資料");
				
				// 將 prexmldata 歷史資料 填入 MazRecForm.aspx 下方空白處
				myObject.xmldata = xmlInvRec.xml;
			}
			else
			{
			    myObject.flag=true;
				myObject.prexmldata = document.all("hiddenInvRec").value;
				
				// 將 prexmldata 歷史資料 填入 InvRecForm.aspx 下方空白處 + 以下指定資料 myObject.xxx
				myObject.xmldata = myObject.prexmldata;
			}
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// 抓出 公司名稱, 寄發票地址, 寄發票郵遞區號; 傳給雜誌收件人資料之公司名稱, 地址, 郵遞區號 myObject.MfrName, myObject.MfrAddress, myObject.MfrZipcode
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			myObject.MfrNo=document.all("hiddenMfrNo").value;
			//alert(myObject.MfrNo);
			myObject.MfrName=document.all("hiddenMfrName").value;
			//alert(myObject.MfrName);
			myObject.MfrAddress=window.document.all("hiddenMfrAddress").value;
			myObject.MfrZipcode=window.document.all("hiddenMfrZipcode").value;
			myObject.MfrTel=window.document.all("hiddenMfrTel").value;
			myObject.MfrFax=window.document.all("hiddenMfrFax").value;
			myObject.CustJobTitle=window.document.all("hiddenMfrRespJobTitle").value;
			
			// 開啟視窗對話框
			vreturn=window.showModalDialog("InvRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:830px;center:yes;scroll:yes;status:no;help:no;"); 
			if(vreturn)
			{
				//取代新的 xmlInvRec 資料
				xmlInvRec.parentNode.replaceChild(myObject.result, xmlInvRec);
				xmlInvRec = xmlDoc1.selectSingleNode("/root/發票廠商資料");
				//alert(myObject.result.xml);
				//alert("xmlInvRec= " + xmlInvRec.xml);
				//alert("發票收件人姓名0= " + xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人姓名").text);
				
				//自前頁, 計抓出幾筆資料 xmlInvRec.childNodes.length
				//alert("xmlInvRec.childNodes.length = " + xmlInvRec.childNodes.length);
				
				// 抓出挑選出的所有發票收件人姓名, 並以 "," 符號隔開;
				strbuf1 = "";
				for(i=0; i<xmlInvRec.childNodes.length; i++)
				{
					// 確認合約書編號為 新增的編號, 以免新增入 table 時有誤
					xmlInvRec.childNodes.item(i).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
					//strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("發票收件人廠商抬頭").text + "-" + xmlInvRec.childNodes.item(i).selectSingleNode("發票收件人姓名").text + ", ";	//發票收件人姓名 欄
					strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("發票收件人姓名").text + ", ";	//發票收件人姓名 欄
				}
				//alert("strbuf=" + strbuf);
				
				// 把得出之結果寫回到新增畫面裡 
				document.all("lblInvRec").innerText = strbuf1;
				
				// 把得出之結果寫回到 hiddenInvRec 值, 以免當此合約書為新的(old_contno=0)時, doSelectIMRec() 會抓不到歷史資料
				document.all("hiddenInvRec").value = xmlInvRec.xml;
				//document.all("textarea1").value=xmlInvRec.xml;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 於落版資料處挑出單一發票廠商收件人之功能按鈕: doSelectIMRec()	
		function doSelectIMRec(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			//alert("hiddenInvRec= " + document.all("hiddenInvRec").value);
			
			var Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("發票廠商收件人細節");
			
			// myObject.prexmldata 是給 InvRecSet.aspx 裡 #DSO3 呼叫歷史資料用;
			// 注意: 若沒有先按下 "挑選發票廠商收件人" 按鈕, 則此處 myObject.prexmldata 的資料會是空白的 xmlInvRec
			if(document.all("hiddenInvRec").value=="")
				myObject.prexmldata=xmlInvRec;
			else
				myObject.prexmldata=document.all("hiddenInvRec").value;
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			
			// myObject.xmldata 是給 InvRecSet.aspx 裡 #DSO2 空白xmlInvRec用;
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("發票廠商收件人細節").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// 抓出 系統代碼, 合約書編號; 傳給發票廠商收件人資料之系統代碼, 合約書編號 myObject.Syscd, myObject.ContNo
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			
			// 開啟視窗對話框
			vreturn=window.showModalDialog("InvRecSet.aspx", myObject, "dialogHeight:450px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			if(vreturn)
			{
				Items.parentNode.replaceChild(myObject.result, Items);
				Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("發票廠商收件人細節");
				//alert("Items= " + Items.xml);
				//document.all("textarea1").value=xmlInvRec.xml;
				
				strbuf="";
				for(i=0; i<Items.childNodes.length; i++){
					strbuf+=Items.childNodes.item(i).selectSingleNode("發票收件人姓名").text;	//<姓名>為第二欄
				}
				//alert("strbuf= " + strbuf);
				
				// 把得出之結果寫回到新增畫面裡 
				event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
				//document.all("textarea1").value=Items.xml;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 抓出所有雜誌收件人之姓名的功能按鈕: doGetAllMazRec()
		function doGetAllMazRec() 
		{
			var myObject = new Object();
			//alert("hiddenMazRec= " + document.all("hiddenMazRec").value);
			
			// 若 hiddenMazRec 無資料: 則顯示訊息 "沒有歷史資料..."
			// 若 hiddenMazRec 有資料: 抓出 hiddenMazRec 裡的歷史資料
			if(document.all("hiddenMazRec").value=="")
			{
				myObject.flag=false;
				alert("沒有歷史資料, 請自行輸入資料");
				
				// 將 prexmldata 歷史資料 填入 MazRecForm.aspx 下方空白處
				myObject.xmldata = xmlMazRec.xml;
			}
			else
			{
			    myObject.flag=true;
				myObject.prexmldata = document.all("hiddenMazRec").value;
				
				// 將 prexmldata 歷史資料 填入 MazRecForm.aspx 下方空白處
				myObject.xmldata = myObject.prexmldata;
			}
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// 抓出 公司名稱, 寄發票地址, 寄發票郵遞區號; 傳給雜誌收件人資料之公司名稱, 地址, 郵遞區號 myObject.MfrName, myObject.MfrAddress, myObject.MfrZipcode
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			myObject.MfrName=document.all("hiddenMfrName").value;
			//alert(myObject.MfrName);
			myObject.MfrAddress=window.document.all("hiddenMfrAddress").value;
			myObject.MfrZipcode=window.document.all("hiddenMfrZipcode").value;
			myObject.MfrTel=window.document.all("hiddenMfrTel").value;
			myObject.MfrFax=window.document.all("hiddenMfrFax").value;
			myObject.CustJobTitle=window.document.all("hiddenMfrRespJobTitle").value;
			
			
			vreturn=window.showModalDialog("MazRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:830px;center:yes;scroll:yes;status:no;help:no;");
			if(vreturn)
			{
				//取代新的 xmlMazRec 資料
				xmlMazRec.parentNode.replaceChild(myObject.result, xmlMazRec);
				xmlMazRec = xmlDoc1.selectSingleNode("/root/雜誌收件人資料");
				//alert(myObject.result.xml);
				//alert("xmlMazRec= " + xmlMazRec.xml);
				//alert("雜誌收件人姓名0= " + xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人姓名").text);
				
				//自前頁, 計抓出幾筆資料 xmlMazRec.childNodes.length
				//alert("xmlMazRec.childNodes.length = " + xmlMazRec.childNodes.length);
				
				// 抓出挑選出的所有雜誌收件人姓名, 並以 "," 符號隔開; 並抓出 有登本數 & 未登本數的加總
				strbuf2 = "";
				var TotalPubCount = 0;
				var TotalUnPubCount = 0;
				for(i=0; i<xmlMazRec.childNodes.length; i++)
				{
					// 確認合約書編號為 新增的編號, 以免新增入 table 時有誤
					xmlMazRec.childNodes.item(i).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
					strbuf2 += xmlMazRec.childNodes.item(i).selectSingleNode("雜誌收件人姓名").text + ", ";	//雜誌收件人姓名 欄
					TotalPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("有登本數").text);	//有登本數 欄
					TotalUnPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("未登本數").text);	//未登本數 欄
				}
				// 將 總有登本數/總未登本數 值寫入相關 hidden 值裡, 好方便之後的其 xml 值抓到
				document.all("hiddenTotalPubCount").Value = TotalPubCount;
				document.all("hiddenTotalUnPubCount").Value = TotalUnPubCount;
				//alert("strbuf2=" + strbuf2);
				//alert("總有登本數 TotalPubCount=" + TotalPubCount);
				//alert("總未登本數 TotalUnPubCount=" + TotalUnPubCount);
				
				// 把得出之結果寫回到新增畫面裡 
				// 目前 總有登本數 & 總未登本數 只有寫到畫面上顯示, 而尚未寫回入 xml 或 DB 喔!
				document.all("lblTotalPubCount").innerText = "(總有登本數: " + TotalPubCount + " / 總未登本數: " + TotalUnPubCount + ")";
				xmlContBasicData.selectSingleNode("總有登本數").text = parseInt(TotalPubCount);
				xmlContBasicData.selectSingleNode("總未登本數").text = parseInt(TotalUnPubCount);
				document.all("lblMazRec").innerText = strbuf2;
				
				// 把得出之結果寫回到 hiddenInvRec 值, 以免當此合約書為新的(old_contno=0)時, doSelectIMRec() 會抓不到歷史資料
				document.all("hiddenMazRec").value = xmlMazRec.xml;
				//document.all("textarea1").value=xmlInvRec.xml;
			}
		
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 刊登落版之詳細資料功能按鈕: doEditPub()
		function doEditPub(obj)
		{	
			//alert("xmlAdpubItemDetails= " + xmlAdpubItemDetails.xml);		
			
			// 抓行號
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// 定義 myObject 為視窗回傳值
			var myObject = new Object();
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("落版細節").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			
			// 指定傳過去的變數
			// 此為該筆落版(序號)之 xml 資料
			//alert(xmlAdpubData.childNodes.item(idx).xml);
			
			// 總落版次數, 方便抓出 改稿+新稿之總次數 之 for loop
			myObject.TotalPubSeq=xmlAdpubData.childNodes.length;
			//alert("myObject.TotalPubSeq= " + myObject.TotalPubSeq);
			//alert(xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text);
			
			// 傳入合約書細節之資料 - 總刊登次數, 總製稿次數, 換稿次數
			myObject.tottm=window.document.all("tbxTotalTime").value;
			myObject.totjtm=window.document.all("tbxTotalJTime").value;
			//alert("myObject.tottm= " + myObject.tottm);
			myObject.chgjtm=window.document.all("tbxChangeJTime").value;
			// 剩餘之總製稿次數, 方便計算 總製稿次數之剩餘次數
			myObject.hiddenTotalJTime= document.all("hiddenTotalJTime").value;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// 傳入 廠商編號 & 廠商統編, 來參考列出該廠商 曾刊登(並寫回)之所有落版資料
			// 做為輸入 舊稿期別 / 改稿期別 時, 自動動出 舊稿頁碼 / 改稿頁碼 查詢結果
			myObject.contno= document.all("hiddenContNo").value;
			myObject.mfrno = document.all("hiddenMfrNo").value;
			
			// 傳入其他資料, 以在 "落版細節資訊" 下方顯示其相關資料 (解決因 showModalDialog 必須關閉, 才能看前頁資料)
			myObject.pubseq=xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text;
			myObject.yyyymm=xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			myObject.bkpno=xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍期別").text;
			myObject.pgno=xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登頁碼").text;
			myObject.fgfixpage=xmlAdpubData.childNodes.item(idx).selectSingleNode("固定頁次註記").text;
			myObject.clrcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("廣告色彩代碼").text;
			myObject.pgscd=xmlAdpubData.childNodes.item(idx).selectSingleNode("廣告篇幅代碼").text;
			myObject.ltpcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("廣告版面代碼").text;
			
			//定義 AdpubItemDetails 為傳過去的值 落版細節
			var AdpubItemDetails = xmlAdpubData.childNodes.item(idx).selectSingleNode("落版細節");
			//alert("AdpubItemDetails.xml= " + AdpubItemDetails.xml);
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			vreturn=window.showModalDialog("adpub_detail.aspx", myObject, "dialogHeight:300px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result.xml= " + myObject.result.xml);
			
			//取代新的 AdpubItemDetails 資料
			AdpubItemDetails.parentNode.replaceChild(myObject.result, AdpubItemDetails);
			AdpubItemDetails = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
			
			// 取代 '剩餘之總製稿次數' hiddenTotalJTime
			document.all("hiddenTotalJTime").value = myObject.hiddenTotalJTime;
			xmlContDetail.selectSingleNode("剩餘製稿次數").text=myObject.hiddenTotalJTime;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// 透過 textarea 做為檢查輸出的 XML 是否正確
			//document.all("textarea1").value=xmlAdpubItemDetails.xml;
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 本表單之 "儲存修改" 按鈕: doSubmit()
		function doSubmit()
		{
			// 本段使用 xmlDoc1 取代 xmlDoc0 (不同於 cont_new3.aspx)
			
			
			// 下段是與 cont_new3.aspx & cont_show.aspx 不同處
			// 更新 最後修改日期
			xmlContBasicData.selectSingleNode("最後修改日期").text=window.document.all("hiddenModDate").value;
			
			// 將 落版最後修改日期 PubModDate 之值去除 "/", 以免新增入 c2_pub 時 (因使用 sp_c2_cont_newSave_pub 受限, 必須在新增前先確認資料正確) , 無法去除其 "/", 而造成資料有誤
			var PubModDate = window.document.all("hiddenModDate").value;
			PubModDate = PubModDate.substring(0, 4) + PubModDate.substring(5, 7) + PubModDate.substring(8, 10);
			xmlAdpubItems.selectSingleNode("落版最後修改日期").text=PubModDate;
			xmlAdpubItems.selectSingleNode("落版業務員工號").text=window.document.all("ddlEmpNo").value;
			xmlAdpubItems.selectSingleNode("落版修改業務員工號").text=window.document.all("ddlEmpNo").value;
			
			// 更新 已刊登次數 (根據 =落版的總筆數) => 方法一
			//xmlContDetail.selectSingleNode("已刊登次數").text = parseInt(idx);
			//var RestPubTime = parseInt(document.all("tbxTotalTime").value) - parseInt(idx);
			
			// 更新 已刊登次數 & 剩餘刊登次數
			xmlContDetail.selectSingleNode("已刊登次數").text = document.all("tbxPubTime").value;
			var RestPubTime = parseInt(document.all("tbxTotalTime").value) - parseInt(document.all("tbxPubTime").value);
			xmlContDetail.selectSingleNode("剩餘刊登次數").text = RestPubTime;
			//document.all("tbxPubTime").value = parseInt(idx);
			//document.all("tbxRestTime").value = parseInt(document.all("tbxPubTime").value) - parseInt(idx);
			
			
			// 更新 落版最後修改日期, 落版業務員工號, 落版修改業務員工號, 已製稿次數
			var idx = xmlAdpubData.childNodes.length;
			//alert("idx= " + idx);
			//alert("xmlAdpubData= " + xmlAdpubData.xml);
			var i;
			var MadeJTime = 0;
			for(i=0; i<idx; i++) 
			{
				//var xmlAdpubData = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料");
				//var xmlAdpubItems = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表");
				//var xmlAdpubItemInvRec = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
				//var xmlAdpubItemDetails = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
				
				xmlAdpubData.childNodes.item(i).selectSingleNode("落版最後修改日期").text=PubModDate;
				xmlAdpubData.childNodes.item(i).selectSingleNode("落版業務員工號").text=window.document.all("ddlEmpNo").value;
				xmlAdpubData.childNodes.item(i).selectSingleNode("落版修改業務員工號").text=window.document.all("ddlEmpNo").value;
				
				//alert("稿件類別代碼= " + xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").xml);
				var drafttp = xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text;
				drafttp = parseInt(drafttp);
				//alert("稿件類別代碼= " + drafttp);
				switch(drafttp)
				{
					case 1:
						MadeJTime = parseInt(MadeJTime);
						break;
					case 2:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
					case 3:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
				}
			}
			//alert("hiddenTotalJTime=" + document.all("hiddenTotalJTime").value);
			//alert("MadeJTime=" + MadeJTime);
			//alert("剩餘製稿次數=" + (parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime)));
			xmlContDetail.selectSingleNode("已製稿次數").text = parseInt(MadeJTime);
			
			// 若落版之總製稿次數 MadeJTime 與合約書細節之總製稿次數不符合時, 給予警告訊息
			if(parseInt(MadeJTime) != parseInt(document.all("tbxMadeJTime").value))
			{
				alert("落版之總製稿次數:" + parseInt(MadeJTime) + " 與 合約書細節之總製稿次數:" + parseInt(document.all("tbxMadeJTime").value) + " 不符合!");
			}
			xmlContDetail.selectSingleNode("已製稿次數").text = parseInt(MadeJTime);
			document.all("tbxMadeJTime").value = parseInt(MadeJTime);
			
			xmlContDetail.selectSingleNode("剩餘製稿次數").text = parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime);
			// 若 剩餘製稿次數 < 0, 則其值指定為 0
			if((parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime)) > 0)
				xmlContDetail.selectSingleNode("剩餘製稿次數").text = parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime);
			else
				xmlContDetail.selectSingleNode("剩餘製稿次數").text = 0;	
			document.all("tbxRestJTime").value = parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime);
			
			
			// 透過 textarea 做為檢查輸出的 XML 是否正確 
			//document.all("textarea1").value=xmlMain.xml;
			//alert(xmlDoc1.xml);
			
			
			//// 測試, 先傳字串給存檔程式 (cont_mainSave.aspx) 看看是否有問題
			//// 若無, 再進行傳 xml 資料
			////  在這邊把 xmlDoc1.xml 的資料傳給存檔程式
			////var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			////xmlHTTP.Open("post", "cont_mainSave.aspx", false);
			// 單傳字串到 cont_newSave.aspx 看看是否抓得到; 若抓得到, 再抓 xmlDoc1
			////xmlHTTP.Send("test");
			////document.all("textarea1").value=xmlHTTP.responseText;
			////var xmlHTTP = null;

			// 開始傳送 xml 資料至資料庫中儲存 ------------------
			// 在這邊把 xmlDoc1.xml 的資料傳給存檔程式
			var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			xmlHTTP.Open("post", "cont_mainSave.aspx", false);
			xmlHTTP.Send(xmlDoc1);
			
			// 檢查並輸出 xmlHTTP 狀態於本頁 textarea1 內
			////alert(xmlHTTP.responseText);
			//document.all("textarea1").value=xmlHTTP.responseText;
			
			// 若儲存成功, 以警告視窗顯示
			if(xmlHTTP.statusText=="OK")
			{
				alert("修改合約書成功");
				window.location.href="/mrlpub/d2/cont_SaveMessage.aspx?str=modify";
				if(window.confirm("修改合約書成功,要繼續修改合約書?"))
				{
					if(window.document.all("hiddenContType").value=="01")
						window.location.href="cont_main1.aspx?function1=mod&conttp=01";
					else if(window.document.all("hiddenContType").value=="09")
						window.location.href="cont_main1.aspx?function1=mod&conttp=09";
				}
				else
					window.location.href="http://140.96.18.18/mrlpub/";
			}
			
			// 清除 xmlHTTP 資料為空
			var xmlHTTP = null;
		}
		//-->
		</script>
	</BODY>
</HTML>
