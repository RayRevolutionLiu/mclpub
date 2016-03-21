<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="cont_new3.aspx.cs" Src="cont_new3.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_new3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增合約書 步驟三</TITLE>
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
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							新增合約書 步驟三: 新增合約書內容</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form-->
			<FORM id="cont_new3" name="cont_new3" method="post" runat="server">
				<!--Table 開始-->
				<!-- 請注意各 table 裡的 dataFld & dataSrc="#DSO0" -->
				<TABLE dataFld="合約書內容" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<!-- 廠商及客戶資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(2) 廠商及客戶資料</font>
						</td>
					</TR>
					<!-- 廠商資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT color="#cc0099">(2)</FONT> 公司名稱/商號 (廠商統編)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCompanyName" runat="server"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrNo" runat="server"></asp:label>
							) <INPUT id="hiddenMfrNo" type="hidden" size="1" name="hiddenMfrNo" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">&nbsp;
							<INPUT id="hiddenMfrName" type="hidden" size="1" name="hiddenMfrName" runat="server">
							<INPUT id="hiddenMfrZipcode" type="hidden" size="1" name="hiddenMfrZipcode" runat="server">
							<INPUT id="hiddenMfrAddress" type="hidden" size="1" name="hiddenMfrAddress" runat="server">
						</TD>
					</TR>
					<!-- 公司負責人資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							公司負責人姓名及職稱：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
							) <INPUT id="hiddenMfrRespName" type="hidden" size="1" name="hiddenMfrRespName" runat="server">
							<INPUT id="hiddenMfrRespJobTitle" type="hidden" size="1" name="hiddenMfrRespJobTitle" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							公司電話/傳真：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrTel" runat="server"></asp:label>
							&nbsp;(Fax:
							<asp:label id="lblMfrFax" runat="server"></asp:label>
							) <INPUT id="hiddenMfrTel" type="hidden" size="1" name="hiddenMfrTel" runat="server">
							<INPUT id="hiddenMfrFax" type="hidden" size="1" name="hiddenMfrFax" runat="server">
						</TD>
					</TR>
					<!-- 客戶資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							客戶姓名 (客戶編號)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server"></asp:label>
							&nbsp;&nbsp;(
							<asp:label id="lblCustNo" Runat="server" ForeColor="Maroon"></asp:label>
							)&nbsp; <INPUT id="hiddenCustNo" type="hidden" size="1" name="hiddenCustNo" runat="server">
							<INPUT id="hiddenPreXml" type="hidden" size="6" name="hiddenPreXml" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">&nbsp;
							<INPUT id="hiddenCustName" type="hidden" size="1" name="hiddenCustName" runat="server">
						</TD>
					</TR>
					<!-- 合約書基本資料 -->
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
							<INPUT id="hiddenModDate" type="hidden" size="2" name="hiddenModDate" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							合約編號：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:label id="lblContNo" runat="server" ForeColor="Red"></asp:label>
							<INPUT id="hiddenContNo" style="WIDTH: 30px" type="hidden" size="6" name="hiddenContNo" runat="server">&nbsp;
							<INPUT id="hiddenOldContNo" style="WIDTH: 30px" type="hidden" size="6" name="hiddenOldContNo" runat="server">
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							合約類別：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlContType" runat="server">
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
							<FONT color="red">*</FONT> <INPUT id="tbxStartDate" style="WIDTH: 45px" type="text" maxLength="7" size="6" name="tbxStartDate" runat="server" onblur="Javascript: checkContSDate(this)">&nbsp;
							<font size="3">~</font> <FONT color="red">*</FONT> <INPUT id="tbxEndDate" style="WIDTH: 45px" type="text" maxLength="7" size="6" name="tbxEndDate" runat="server" onblur="Javascript: checkContEDate(this)">
							<FONT face="新細明體" color="#c00000">(預設值: 一年)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							承辦業務員：
						</TD>
						<TD class="cssData">
							<FONT color="red">* </FONT><SELECT dataFld="承辦業務員工號" id="ddlEmpNo" name="ddlEmpNo" runat="server"></SELECT>
							<INPUT dataFld="承辦業務員工號" id="hiddenEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenEmpNo" runat="server">&nbsp;&nbsp;
							<INPUT dataFld="登入業務員工號" id="hiddenLoginEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenLoginEmpNo" runat="server">&nbsp;
							<FONT face="新細明體" color="#c00000">(預設值: 登入者)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							一次付清註記：
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlfgPayOnce" runat="server">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
							</asp:dropdownlist>
							&nbsp;
							<asp:textbox id="hiddenfgClosed" runat="server" MaxLength="1" Width="20px" ReadOnly="True" Visible="False"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							&nbsp;
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;
						</TD>
					</TR>
					<!-- 合約書細節 -->
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
										<FONT color="red">* </FONT><INPUT dataFld="總製稿次數" id="tbxTotalJTime" style="WIDTH: 28px" maxLength="3" size="3" name="tbxTotalJTime" runat="server" onblur="Javascript: checkTotalJTime(this)">
									</TD>
									<TD class="cssTitle" noWrap align="right">
										總刊登次數：&nbsp;
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT><INPUT dataFld="總刊登次數" id="tbxTotalTime" style="WIDTH: 28px" maxLength="3" size="3" name="tbxTotalTime" runat="server" onblur="Javascript: checkTotalTime(this)">
									</TD>
									<TD class="cssTitle" align="right">
										<FONT color="#cc0099">(11)</FONT> 合約總金額：&nbsp;
									</TD>
									<TD class="cssData">
										<FONT face="新細明體"><FONT color="red">* </FONT>$</FONT>
										<asp:textbox id="tbxTotalAmt" runat="server" MaxLength="8" Width="55px"></asp:textbox>
										&nbsp; <INPUT dataFld="總製稿次數" id="hiddenTotalJTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalJTime" runat="server">&nbsp;
										<INPUT dataFld="總刊登次數" id="hiddenTotalTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalTime" runat="server">
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="#cc0099">(9)</font> 換稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
										<FONT face="新細明體" color="#c00000">&nbsp;</FONT>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<FONT color="#cc0099">(9)</FONT> 贈送次數：&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										<FONT color="#cc0099">(9)</FONT> 優惠折數：&nbsp;
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT>&nbsp;&nbsp; <INPUT dataFld="優惠折數" id="tbxDiscount" style="WIDTH: 40px" maxLength="6" size="4" name="tbxDiscount" runat="server" onblur="Javascript: checkDiscount(this)">
										<FONT face="新細明體">折</FONT><FONT face="新細明體" color="#c00000">(填實數, 如 0.xxx)</FONT>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										彩色次數：
									</TD>
									<TD class="cssData">
										<FONT face="新細明體">&nbsp;&nbsp; </FONT>
										<asp:textbox id="tbxColorTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										黑白次數：
									</TD>
									<TD class="cssData">
										<FONT face="新細明體">&nbsp;&nbsp; </FONT>
										<asp:textbox id="tbxMenoTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										套色次數：
									</TD>
									<TD class="cssData">
										<FONT face="新細明體">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:textbox id="tbxGetColorTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
										</FONT>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<!-- 發票廠商資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<FONT color="#ffffff">(3) 發票廠商收件人資料&nbsp;&nbsp; </FONT>
							<asp:label id="lblInvRecMessage" runat="server"></asp:label>
						</td>
					</TR>
					<TR vAlign="center">
						<TD noWrap align="right" bgColor="#bfcff0">
							<font color="#cc0099">(3)</font> 發票收件人姓名：
						</TD>
						<TD noWrap colSpan="3">
							<IMG class="ico" title="新增/修改發票收件人" onclick="doGetAllInvRec()" height="18" src="../images/new.gif" border="0">&nbsp;
							<INPUT id="hiddenInvRec" type="hidden" size="1" name="hiddenInvRec" runat="server">
							<DIV id="lblInvRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
							</DIV>
						</TD>
					</TR>
					<!-- 雜誌收件人資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">(4) 雜誌收件人資料&nbsp;&nbsp; </FONT>
							<asp:label id="lblMazRecMessage" runat="server"></asp:label>
						</TD>
					</TR>
					<TR vAlign="center">
						<TD noWrap align="right" bgColor="#bfcff0">
							<font color="#cc0099">(4)</font> 雜誌收件人姓名：
						</TD>
						<TD noWrap colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetAllMazRec()" height="18" src="../images/new.gif" border="0">&nbsp;
							<INPUT id="hiddenMazRec" type="hidden" size="1" name="hiddenMazRec" runat="server">
							<DIV id="lblMazRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
							</DIV>
							&nbsp;&nbsp;&nbsp;
							<asp:label id="lblTotalPubCount" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp; <INPUT dataFld="總有登本數" id="hiddenTotalPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalPubCount" runat="server">&nbsp;
							<INPUT dataFld="總未登本數" id="hiddenTotalUnPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalUnPubCount" runat="server">
						</TD>
					</TR>
					<!-- 廣告聯絡人資料 -->
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
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" MaxLength="30" Width="65px"></asp:textbox>
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
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuTel" runat="server" MaxLength="30" Width="85px"></asp:textbox>
							&nbsp; <FONT face="新細明體" color="#c00000">(預設同客戶資料!)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							傳真：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuFax" runat="server" MaxLength="30" Width="85px"></asp:textbox>
							&nbsp; <FONT face="新細明體" color="#c00000">(預設同客戶資料!)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							手機：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuCell" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							Email：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuEmail" runat="server" MaxLength="80" Width="160px"></asp:textbox>
						</TD>
					</TR>
				</TABLE>
				<!-- 落版刊登資料 -->
				<TABLE dataFld="合約書落版刊登資料" id="Table1" style="WIDTH: 98%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="落版明細表" id="Table2" style="WIDTH: 100%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
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
							<!-- Form按鈕 -->
							<DIV align="center">
								<input id="btnSave" onclick="doSubmit()" type="button" value="儲存新增" name="btnSave">&nbsp;&nbsp;
								<input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="取消回首頁" name="btnCancel">
							</DIV>
						</TD>
					</TR>
				</TABLE>
			</FORM>
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
		// 本段使用 xmlDoc0 (空白 XML 資料; 不同於 cont_main3.aspx)
		
		// 先定義 Object: DSO0, DSO1, DSOX; 設定 async = false
		DSO0.XMLDocument.async = false;
		DSO1.XMLDocument.async = false; 
		DSOX.XMLDocument.async = false;
		
		// 定義 xmlDoc0
		var xmlDoc0 = DSO0.XMLDocument;
		xmlDoc0.load("空白合約書.xml");
		//alert(xmlDoc0.xml);
		
		// 定義 xmlDoc0 裡的各 XML節點之名稱及其內容
		var xmlMain = xmlDoc0.selectSingleNode("/root");
		var xmlHeader = xmlDoc0.selectSingleNode("/root/合約書內容");
		
		var xmlMfrData = xmlDoc0.selectSingleNode("/root/合約書內容/廠商資料");
		var xmlCustData = xmlDoc0.selectSingleNode("/root/合約書內容/客戶資料");
		var xmlContBasicData = xmlDoc0.selectSingleNode("/root/合約書內容/合約書基本資料");
		var xmlContDetail = xmlDoc0.selectSingleNode("/root/合約書內容/合約書細節");
		var xmlInvRec = xmlDoc0.selectSingleNode("/root/發票廠商資料");
		var xmlMazRec = xmlDoc0.selectSingleNode("/root/雜誌收件人資料");
		//alert(xmlMazRec.xml);
			// 預設指定 雜誌收件人公司名稱, 雜誌收件人地址 = 公司名稱, 公司地址(發票收件人地址)
			// 注意: Javascript 最好放於 BODY 之後, 以免類似 下面 alert 會出現 error
			// PS. 下二行的結果是一樣的
			//alert(document.cont_new3("hiddenMfrName").value);
			//alert(document.all("hiddenMfrNo").value);
			//alert(document.all("hiddenMfrName").value);
			//alert(document.all("hiddenMfrAddress").value);
			//alert(document.all("hiddenMfrZipcode").value);
			xmlInvRec.childNodes.item(0).selectSingleNode("發票廠商序號").text="1";
			xmlInvRec.childNodes.item(0).selectSingleNode("系統代碼").text="C2";
			xmlInvRec.childNodes.item(0).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人廠商統編").text=document.all("hiddenMfrNo").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人地址").text=document.all("hiddenMfrAddress").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人郵遞區號").text=document.all("hiddenMfrZipcode").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人電話").text=document.all("hiddenMfrTel").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人傳真").text=document.all("hiddenMfrFax").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("發票收件人職稱").text=document.all("hiddenMfrRespJobTitle").value;
			
			xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人序號").text="1";
			xmlMazRec.childNodes.item(0).selectSingleNode("系統代碼").text="C2";
			xmlMazRec.childNodes.item(0).selectSingleNode("合約書編號").text=document.all("hiddenContNo").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人公司名稱").text=document.all("hiddenMfrName").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人地址").text=document.all("hiddenMfrAddress").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人郵遞區號").text=document.all("hiddenMfrZipcode").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人電話").text=document.all("hiddenMfrTel").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人傳真").text=document.all("hiddenMfrFax").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("雜誌收件人職稱").text=document.all("hiddenMfrRespJobTitle").value;
		
		var xmlAdContactor = xmlDoc0.selectSingleNode("/root/合約書內容/廣告聯絡人資料");
		
		var xmlAdpubData = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料");
		var xmlAdpubItems = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料/落版明細表");
		var xmlAdpubItemInvRec = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
		var xmlAdpubItemDetails = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
		// 用 windows.alert 方式來顯示出 xmlAdpubItems 的內容 (或可改為其他變數名稱), 做為檢查用
		//alert(xmlHeader.xml);
	
		// 定義 xmlDoc1, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSO1.XMLDocument;
		xmlEmptyAdpubData.load("空白落版刊登資料.xml");

		// 定義 xmlDocX
		var xmlDocX = DSOX.XMLDocument;
		
		// (不同於 cont_main3.aspx)
		
		
		// 若空白合約書, 合約細節處不為必填的欄位給預設值
		if(window.document.all("tbxChangeJTime").value=="")  {
			window.document.all("tbxChangeJTime").value="0";  }
		if(window.document.all("tbxFreeTime").value=="")  {
			window.document.all("tbxFreeTime").value="0";  }
		if(window.document.all("tbxColorTime").value=="")  {
			window.document.all("tbxColorTime").value="0";  }
		if(window.document.all("tbxMenoTime").value=="")  {
			window.document.all("tbxMenoTime").value="0";  }
		if(window.document.all("tbxGetColorTime").value=="")  {
			window.document.all("tbxGetColorTime").value="0";  }
		
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
				xmlAdpubData.childNodes.item(idx).selectSingleNode("落版業務員工號").text=window.document.all("ddlEmpNo").value;
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
			
			// 檢查是否輸入為 數字型態
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
			
			// 檢查 總製稿次數 是否輸入為 數字型態
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
				xmlInvRec = xmlDoc0.selectSingleNode("/root/發票廠商資料");
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
				
				// 若發票廠商收件人只有一位, 則指定落版處的發票收件人為該人
				//alert("xmlInvRec.xml= " + xmlInvRec.xml)
				//xmlAdpubItemInvRec = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
				//if(xmlInvRec.childNodes.length==1)  {
					//alert("發票廠商收件人只有一位!");
					// 下一行不 work => 因兩處 xml架構不同, 無法直接取代
					//xmlAdpubItemInvRec.xml = xmlInvRec.xml;
				//}
				//alert("xmlInvRec=" + xmlInvRec.xml);
				
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
			
			
			// 開啟視窗對話框
			vreturn=window.showModalDialog("MazRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:830px;center:yes;scroll:yes;status:no;help:no;");
			if(vreturn)
			{
				//取代新的 xmlMazRec 資料
				xmlMazRec.parentNode.replaceChild(myObject.result, xmlMazRec);
				xmlMazRec = xmlDoc0.selectSingleNode("/root/雜誌收件人資料");
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
				//document.all("textarea1").value=xmlMazRec.xml;
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
			AdpubItemDetails = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
			
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
		// 本表單之 "儲存新增" 按鈕: doSubmit()
		function doSubmit()
		{
			// 檢查必填欄位是否空白
			if(window.document.all("tbxSignDate").value=="")  {
					alert("簽約日期不可空白");
					document.all("tbxSignDate").focus();
					return;	}

			if(window.document.all("tbxStartDate").value=="")  {
				alert("合約起日不可空白");
				document.all("tbxStartDate").focus();
				return;	}

			if(window.document.all("tbxEndDate").value=="")  {
				alert("合約迄日不可空白");
				document.all("tbxEndDate").focus();
				return;	}

			if(window.document.all("ddlEmpNo").value=="")  {
				alert("承辦業務員工號不可空白");
				document.all("ddlEmpNo").focus();
				return;	}
					
			if(window.document.all("tbxTotalJTime").value=="")  {
				alert("總製稿次數不可空白");
				document.all("tbxTotalJTime").focus();
				return;	}
			
			if(window.document.all("tbxTotalAmt").value=="")  {
				alert("合約總金額不可空白");
				document.all("tbxTotalAmt").focus();
				return;	}

			if(window.document.all("tbxDiscount").value=="0.")  {
				alert("優惠折數不可空白");
				document.all("tbxDiscount").focus();
				return;	}

			if(window.document.all("tbxAuName").value=="")  {
				alert("廣告聯絡人姓名不可空白");
				document.all("tbxAuName").focus();
				return;	}

			if(window.document.all("tbxAuTel").value=="")  {
				alert("廣告聯絡人電話不可空白");
				document.all("tbxAuTel").focus();
				return;	}
			
			
			// 本段使用 xmlDoc0 (空白 XML 資料; 不同於 cont_main3.aspx)
			
			
			// xmlMfrData等各 XML節點之名稱及其內容, 可參前面的 coding (Line 33~46)
			// 比如 var xmlMfrData = xmlDoc0.selectSingleNode("/root/合約書內容/廠商資料"); (Line 36)
			// xmlMfrData裡的節點名稱與 window.document 裡的物件名稱要對應正確, 否則會有 errror

			// 廠商及客戶資料區
			xmlMfrData.selectSingleNode("廠商統編").text=window.document.all("hiddenMfrNo").value;
			xmlMfrData.selectSingleNode("公司發票抬頭").text=window.document.all("hiddenMfrName").value;
			xmlMfrData.selectSingleNode("廠商負責人姓名").text=window.document.all("hiddenMfrRespName").value;
			xmlMfrData.selectSingleNode("廠商負責人職稱").text=window.document.all("hiddenMfrRespJobTitle").value;
			xmlMfrData.selectSingleNode("廠商電話").text=window.document.all("hiddenMfrTel").value;
			xmlMfrData.selectSingleNode("廠商傳真").text=window.document.all("hiddenMfrFax").value;
			xmlMfrData.selectSingleNode("廠商郵遞區號").text=window.document.all("hiddenMfrZipcode").value;
			xmlMfrData.selectSingleNode("廠商地址").text=window.document.all("hiddenMfrAddress").value;
			//alert("hiddenMfrName= " + window.document.all("hiddenMfrName").value);

			xmlCustData.selectSingleNode("客戶編號").text=window.document.all("hiddenCustNo").value;
			xmlCustData.selectSingleNode("客戶姓名").text=window.document.all("hiddenCustName").value;
			//alert("hiddenCustName= " + window.document.all("hiddenCustName").value);
			
			
			// 合約書基本資料區
			xmlContBasicData.selectSingleNode("合約書編號").text=window.document.all("hiddenContNo").value;		
			xmlContBasicData.selectSingleNode("合約類別代碼").text=window.document.all("hiddenContType").value;		
				// 藉 下拉式選單 書籍類別的 DB 值(19碼 nostr, 請參 .cs sqlDataAdapter3), 抓出其計劃代號及成本中心
				// 將 nostr 存入 hiddenBook 裡, 以方便維護畫面抓出資料
				var BkcdProjCost = window.document.all("ddlBookCode").value;
				window.document.all("hiddenBkcdProjCost").value = BkcdProjCost;
				//alert("BkcdProjCost= " + BkcdProjCost);
				var BookCode = BkcdProjCost.substr(0, 2);
				var ProjNo = BkcdProjCost.substr(2, 10);
				var CostCtr = BkcdProjCost.substr(12, 7);
			xmlContBasicData.selectSingleNode("書籍全碼").text=BkcdProjCost;
			xmlContBasicData.selectSingleNode("書籍類別代碼").text=BookCode;
			xmlContBasicData.selectSingleNode("計劃代號").text=ProjNo;
			xmlContBasicData.selectSingleNode("成本中心").text=CostCtr;
			xmlContBasicData.selectSingleNode("承辦業務員工號").text=window.document.all("ddlEmpNo").value;
			xmlContBasicData.selectSingleNode("修改業務員工號").text=window.document.all("ddlEmpNo").value;
			
			// 一次付清註記, 若使用 rab 方式, 不知為何抓不到其值 ==> 所以目前以 ddl 方式顯示
			//alert("rabfgPayOnce.value= " + window.document.all("rabfgITRI").value);
			xmlContBasicData.selectSingleNode("一次付清註記").text=window.document.all("ddlfgPayOnce").value;
			
			// 院所內註記, 若使用 rab 方式, 不知為何抓不到其值 ==> 所以目前以 ddl 方式顯示
			//alert("rabfgITRI.value= " + window.document.all("rabfgITRI").value);
			//xmlContBasicData.selectSingleNode("院所內註記").text=window.document.all("ddlfgITRI").value;
			
			// 日期原本是抓含有 / 符號, 再將去除/的值(NewstrSignDate) 存入 xml & DB
			// 現日期格式改為直接儲存含 / 符號的日期, 以方便維護畫面; 但注意儲存入 DB 時仍要去除 / 符號
			//strSignDate=window.document.all("tbxSignDate").value;
				//var NewstrModDate="";
				//NewstrSignDate = strSignDate.substring(0, 4) + strSignDate.substring(5, 7) + strSignDate.substring(8, 10);
				////alert("NewstrSignDate= " + NewstrSignDate);
			////xmlContBasicData.selectSingleNode("簽約日期").text=strSignDate.split("/");  // 此方法只是把 "/" 改為 ","
			//xmlContBasicData.selectSingleNode("簽約日期").text=NewstrSignDate;
			xmlContBasicData.selectSingleNode("簽約日期").text=window.document.all("tbxSignDate").value;
			xmlContBasicData.selectSingleNode("合約起日").text=window.document.all("tbxStartDate").value;
			xmlContBasicData.selectSingleNode("合約迄日").text=window.document.all("tbxEndDate").value;
			
			
			// 沒有出現在畫面裡的欄位, 先給預設值
			xmlContBasicData.selectSingleNode("系統代碼").text="C2";
			xmlContBasicData.selectSingleNode("最後修改日期").text=window.document.all("hiddenModDate").value;
			xmlContBasicData.selectSingleNode("舊合約編號").text= window.document.all("hiddenOldContNo").value;
			xmlContBasicData.selectSingleNode("總有登本數").text=document.all("hiddenTotalPubCount").Value;
			xmlContBasicData.selectSingleNode("總未登本數").text= document.all("hiddenTotalUnPubCount").Value;
			
			// 合約書細節區
			xmlContDetail.selectSingleNode("總製稿次數").text=window.document.all("tbxTotalJTime").value;
			xmlContDetail.selectSingleNode("總刊登次數").text=window.document.all("tbxTotalTime").value;
			xmlContDetail.selectSingleNode("合約總金額").text=window.document.all("tbxTotalAmt").value;
			xmlContDetail.selectSingleNode("換稿次數").text=window.document.all("tbxChangeJTime").value;
			xmlContDetail.selectSingleNode("贈送次數").text=window.document.all("tbxFreeTime").value;
			xmlContDetail.selectSingleNode("優惠折數").text=window.document.all("tbxDiscount").value;
			xmlContDetail.selectSingleNode("彩色次數").text=window.document.all("tbxColorTime").value;
			xmlContDetail.selectSingleNode("黑白次數").text=window.document.all("tbxMenoTime").value;
			xmlContDetail.selectSingleNode("套色次數").text=window.document.all("tbxGetColorTime").value;
			// 沒有出現在畫面裡的欄位, 先給預設值
			// 注意: 已製稿次數 的值寫在下面 (因須特別處理)
			xmlContDetail.selectSingleNode("剩餘製稿次數").text=document.all("hiddenTotalJTime").value;
			var TotalTime = window.document.all("tbxTotalTime").value;
			var PubTime = xmlAdpubData.childNodes.length;
			var RestTime = parseInt(TotalTime) - parseInt(PubTime);
			xmlContDetail.selectSingleNode("已刊登次數").text = parseInt(PubTime);
			xmlContDetail.selectSingleNode("剩餘刊登次數").text = parseInt(RestTime);
			xmlContDetail.selectSingleNode("已繳金額").text= "0";
			xmlContDetail.selectSingleNode("剩餘金額").text = window.document.all("tbxTotalAmt").value;
			
			// 廣告聯絡人資料區
			xmlAdContactor.selectSingleNode("廣告聯絡人姓名").text=window.document.all("tbxAuName").value;
			xmlAdContactor.selectSingleNode("廣告聯絡人電話").text=window.document.all("tbxAuTel").value;
			xmlAdContactor.selectSingleNode("廣告聯絡人傳真").text=window.document.all("tbxAuFax").value;
			xmlAdContactor.selectSingleNode("廣告聯絡人手機").text=window.document.all("tbxAuCell").value;
			xmlAdContactor.selectSingleNode("廣告聯絡人Email").text=window.document.all("tbxAuEmail").value;
			
			// 合約書落版刊登資料區 (第一筆的)
			// 註: 第 idx 筆的 xml 資料值(即第二筆以後的落版資料的預設值), 寫在 doAddNew() 裡 
			xmlAdpubItems.selectSingleNode("客戶編號").text=window.document.all("hiddenCustNo").value;
			xmlAdpubItems.selectSingleNode("合約書編號").text=window.document.all("hiddenContNo").value;
			xmlAdpubItems.selectSingleNode("合約類別代碼").text=window.document.all("hiddenContType").value;
			xmlAdpubItems.selectSingleNode("書籍全碼").text=BkcdProjCost;
			xmlAdpubItems.selectSingleNode("書籍類別代碼").text=BookCode;
			xmlAdpubItems.selectSingleNode("計劃代號").text=ProjNo;
			xmlAdpubItems.selectSingleNode("成本中心").text=CostCtr;
			xmlAdpubItems.selectSingleNode("樣後修改註記").text=0;
			// 將 落版最後修改日期 Reformat 去除 "/", 以免新增入 c2_pub 時 (因使用 sp_c2_cont_newSave_pub 受限, 必須在新增前先確認資料正確) , 無法去除其 "/", 而造成資料有誤
			var PubModDate = window.document.all("hiddenModDate").value;
			PubModDate = PubModDate.substring(0, 4) + PubModDate.substring(5, 7) + PubModDate.substring(8, 10);
			xmlAdpubItems.selectSingleNode("落版最後修改日期").text=PubModDate;
			xmlAdpubItems.selectSingleNode("落版業務員工號").text=window.document.all("ddlEmpNo").value;
			xmlAdpubItems.selectSingleNode("落版修改業務員工號").text=window.document.all("ddlEmpNo").value;
			
			
			// ------------- 以下是做判斷, 檢查資料是否合理, 否則予以警告 --------------------
			// 抓到目前落版資料有幾筆 idx
			var idx = xmlAdpubData.childNodes.length;
			//alert("idx= " + idx);
			
			// --------  以下抓各筆落版資料(靠 for loop)裡的某項, 來做加總等計算 ------------------
			// A段: 計算 合約書細節與落版之廣告色彩次數是否符合. 落版的廣告色彩代碼之所有加總次數 與 合約書的總彩色次數, 總黑白次數, 總套色次數 做比對.
			var clrtm = 0;
			var memotm = 0;
			var getclrtm = 0;
			var noncolor = 0;
			
			// B段: 計算出 換稿次數 = 落版/改稿次數 + 落版/新稿次數
			var Chgjtm = 0;
			
			// C段: 計算出 已製稿次數 = 改稿重出片註記=1(是) + 新稿製法=01~04 之所有落版筆數的加總
			var Madejtm = 0;
			
			// D段: 計算出 "落版後金額" = 每筆 "落版廣告金額" 的加總
			var pubamt=0;
			
			// E段: 計算出 "換稿費用" = 每筆 "換稿金額" 的加總
			var chgamt=0;
			
			// F段: 檢查 "刊登年月" 是否有輸入
			var yyyymm="";
			//alert("總筆數= " + parseInt(xmlAdpubData.childNodes.length));
			
			// G段: 檢查 "書籍期別" 是否有輸入
			var bkp="";
			
			var i;
			for(i=0; i<idx; i++) 
			{
				// A段: 計算 合約書細節與落版之廣告色彩次數是否符合. 
				// 先抓出落版的 廣告色彩代碼 之所有加總次數: 落版彩色次數, 落版黑白次數, 落版套色次數
					//alert("廣告色彩代碼= " + xmlAdpubData.childNodes.item(k).selectSingleNode("廣告色彩代碼").text);
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("廣告色彩代碼").text=="01")  {
						//alert("第 " + (i+1) + "行: 您選擇彩色");
						clrtm = clrtm + 1;	}
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("廣告色彩代碼").text=="02")  {
						//alert("第 " + (i+1) + "行: 您選擇黑白");
						memotm = memotm + 1;	}
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("廣告色彩代碼").text=="03")  {
						//alert("第 " + (i+1) + "行: 您選擇套色");
						getclrtm = getclrtm + 1;	}
				
				// B段: 計算出 換稿次數 = 落版/改稿次數 + 落版/新稿次數
				// 先抓出 稿件類別代碼為 改稿 或新稿 的次數(筆數, 份數; 每筆為一份)
					// 若為改稿
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text == "3")
						Chgjtm = Chgjtm + 1;
					else
						Chgjtm = Chgjtm;
					
					// 若為新稿
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text == "2")
						Chgjtm = Chgjtm + 1;
					else
						Chgjtm = Chgjtm;
				
				// C段: 計算出 已製稿次數 = 改稿重出片註記=1(是) + 新稿製法=01~04 之所有落版筆數的加總
				// 先抓出 改稿重出片註記=1 或 新稿製法代碼=1~4 的次數(筆數, 份數; 每筆為一份)
					//alert("第 " + i + "行的稿件類別代碼: " + xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text);
					//alert("第 " + i + "行的改稿重出片註記: " + xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/改稿重出片註記").text);
					// 若為改稿重出片
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text == "3" && xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/改稿重出片註記").text == "1")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// 若 新稿製法 為 內製
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/新稿製法代碼").text == "01")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// 若 新稿製法 為 外製
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/新稿製法代碼").text == "02")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// 若 新稿製法 為 委製
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/新稿製法代碼").text == "03")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// 若 新稿製法 為 外購
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/新稿製法代碼").text == "04")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
				
				// D段: 計算出 "落版後金額" = 每筆 "落版廣告金額" 的加總 
					pubamt = pubamt + parseInt(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/落版廣告金額").text);
				
				// E段: 計算出 "換稿費用" = 每筆 "換稿金額" 的加總
					chgamt = chgamt + parseInt(xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/換稿金額").text);
				
				// F段: 檢查 "刊登年月" 是否有輸入
					yyyymm = xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text;
					
					//若落版刊登資料有多筆時 - 若其刊登年月為空值, 不做新增至 c2_pub 處理
					if(parseInt(xmlAdpubData.childNodes.length) >=2)
					{
						// 檢查 刊登年月 是否為空值
						// 若為空值, 則警告之 並不允許繼續的動作(return), 直到所有的刊登年月填入為止
						if(xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text == "")  {
							yyyymm = "";
							alert("落版第 " + (i+1) + " 筆的刊登年月(西元6碼)為必填, 請先修正!");
							return;
						}
						// 若 刊登年月 不為空值 - 則先檢查其格式, 正確則填入 xml
						else
						{
							
							// 判斷刊登年月的長度是否為 6碼
							var yyyymm = xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text;
							if(yyyymm.length!=6)  {
								alert("落版第 " + (i+1) + " 筆 '刊登年月' 的長度必須為 6碼(西元), 請修正!");
								return;
								//window.document.all("tbxfgFixPage").focus();
							}
							// 若刊登年月的長度為 6碼 (合理)
							else
							{
								//** 以下同 checkPubDate() function **
								
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
								if(xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text<ContStartDate || xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text>ContEndDate)
								{
									alert("落版第 " + (i+1) + " 筆 '刊登年月' 必須在合約起迄範圍內, 請修正!");
									return;
								}
								
								// 並判斷西元刊登年月是否合理化 : 年(4碼, 1990~2200), 月(01~12)
								var yyyy = xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text.substring(0, 4);
								var mm = xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text.substring(4, 6);
								
								// 判斷西元刊登年度是否合理化
								if(yyyy<=1990 || yyyy>=2200)  {
									alert("注意: 落版第 " + (i+1) + " 筆的刊登年月之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請更正!");
									return;
								}
								else
									yyyymm = yyyymm;
								
								// 判斷西元刊登月份是否合理化
								if(mm>12 || mm<=0)  {
									alert("注意: 落版第 " + (i+1) + " 筆的刊登年月之月份 '" + mm + "' 不合理, 請更正!");
									return;
								}
								else
									yyyymm = yyyymm;			
							// 結束 - 若刊登年月的長度為 6碼 (合理)
							}

						// 結束 落版刊登資料有多筆時 的判斷式 else
						}
						
						// G段: 檢查 "書籍期別" 是否有輸入
						var BookPNo = xmlAdpubData.childNodes.item(i).selectSingleNode("書籍期別").text;
						// 若書籍期別沒有輸入
						if(BookPNo.length==0)  {
							alert("落版第 " + (i+1) + " 筆的 '書籍期別' 為必填, 請修正!");
							return;
						}
						else  {
							// 檢查是否輸入為 數字型態
							if(isNaN(BookPNo)==true)
								alert("落版第 " + (i+1) + " 筆的 '書籍期別' 必須輸入數字型態!");
						}
						
						// H 段: 檢查是否有按下該筆之 '發票收件人'
						if(document.all("lblSingleIMRec").innerText == "")  {
							alert("您沒有按下 落版之第 " + (i+1) + " 筆之 '發票收件人姓名'旁的按鈕, 請按一下做確認!");
							return;
						}
						
					}
					
					
					//若落版刊登資料只有一筆時 - 若其刊登年月為空值, 不做新增至 c2_pub 處理
					else
					{
						// 檢查 刊登年月 是否為空值
						// 一筆之刊登年月的若為空值, 給予警告訊息: 不做新增落版資料的處理
						if(xmlAdpubData.childNodes.item(i).selectSingleNode("刊登年月").text == "")  {
							yyyymm = "";
							alert("落版第 " + (i+1) + " 筆的 '刊登年月' 未填, 將不做新增落版檔的處理!\n 您可稍後新增/維護之.\n\n 合約書檔等其他資料新增中...請稍後!");
						}
						// 若 刊登年月 不為空值 - 則先檢查其格式, 正確則填入 xml
						else
						{						
							// G段: 檢查 "書籍期別" 是否有輸入
							var BookPNo = xmlAdpubData.childNodes.item(i).selectSingleNode("書籍期別").text;
							// 若書籍期別沒有輸入
							if(BookPNo.length==0)  {
								alert("落版第 " + (i+1) + " 筆的 '書籍期別' 為必填, 請修正!");
								return;
							}
							else  {
								// 檢查是否輸入為 數字型態
								if(isNaN(BookPNo)==true)
									alert("落版第 " + (i+1) + " 筆的 '書籍期別' 必須輸入數字型態!");
							}
							
							// H 段: 檢查是否有按下該筆之 '發票收件人'
							if(document.all("lblSingleIMRec").innerText == "")  {
								alert("您沒有按下 落版之第 " + (i+1) + " 筆之 '發票收件人姓名' 旁的按鈕, 請按一下做挑選!");
								return;
							}
							
						}

					// 結束 落版刊登資料只有一筆時 的判斷式 else
					}
					
					// H 段: 檢查是否有按下該筆之 '發票收件人'
					//if(document.all("lblSingleIMRec").innerText == "")  {
						//alert("您沒有挑選 落版之第 筆之 '發票收件人姓名'旁的按鈕, 請按一下做確認!");
						//return;
					//}
			
			// 結束 for loop
			}
			// 抓出總結果, 寫入 xml 及畫面上
			//alert("clrtm= " + clrtm);
			//alert("memotm= " + memotm);
			//alert("getclrtm= " + getclrtm);
			//alert("Chgjtm= " + Chgjtm);
			//alert("Madejtm= " + parseInt(Madejtm));
			//alert("pubamt= " + pubamt);
			//alert("chgamt= " + chgamt);
			//alert("yyyymm= " + yyyymm);
			
			// 注意: 因合約書細節的資料都是由業務員自行輸入, 所以不必把以下的結果回寫至合約書細節處;
			//       但若落版的相關欄位 與 合約書細節的相關欄位 不符(如超過次數), 則要予以警告!
			//xmlContDetail.selectSingleNode("換稿次數").text = parseInt(Chgjtm);
			//window.document.all("tbxChangeJTime").value = Chgjtm;
			
			// A 段:
			// 若落版之 總彩色次數/ 總黑白次數 / 總套色次數 > 合約書之 彩色次數/ 黑白次數 / 套色次數, 則予以警告
			var ContClrtm = window.document.all("tbxColorTime").value;
			var DiffClrtm = clrtm - ContClrtm;
			var ContMemotm = window.document.all("tbxMenoTime").value;
			var DiffMemotm = memotm - ContMemotm;
			var ContGetClrtm = window.document.all("tbxGetColorTime").value;
			var DiffGetClrtm = getclrtm - ContGetClrtm;
			if(parseInt(clrtm) > ContClrtm)  {
				alert("注意: 落版處已超過合約書之彩色次數：" + DiffClrtm + " 次, 請先修正!");	
				return;
				}
			if(parseInt(memotm) > ContMemotm)  {
				alert("注意: 落版處已超過合約書之黑白次數：" + DiffMemotm + " 次, 請先修正!");	
				return;
				}
			if(parseInt(getclrtm) > ContGetClrtm)  {
				alert("注意: 落版處已超過合約書之套色次數：" + DiffGetClrtm + " 次, 請先修正!");	
				return;
				}
			
			// 若 合約書 之 彩色次數+黑白次數+套色次數 > 總刊登次數, 則予以警告
			var ContTotalTime = window.document.all("tbxTotalTime").value; 
			var ContFreeTime = window.document.all("tbxFreeTime").value;
			ContTotalTime = parseInt(ContTotalTime) + parseInt(ContFreeTime);
			//alert("ContTotalTime= " + ContTotalTime);
			var ContTotalColorTime = parseInt(ContClrtm) + parseInt(ContMemotm) + parseInt(ContGetClrtm);
			//alert("ContTotalColorTime= " + ContTotalColorTime);
			var DiffContTime1 = parseInt(ContTotalColorTime) - parseInt(ContTotalTime);
			if(ContTotalColorTime>ContTotalTime)  {
				alert("注意: 合約書細節之 彩色+黑白+套色次數 超過 總刊登次數 " + DiffContTime1 + " 次!");
				return;
			}
			
			
			// 若落版之總廣告色彩次數(彩色次數+黑白次數+套色次數) 超過合約書細節之 總刊登次數 or 總廣告色彩次數 時 予以警告		
			var PubColorTime = clrtm + memotm + getclrtm;
			//alert("PubColorTime= " + PubColorTime);
			var DiffPubNonColor1 = noncolor - ContTotalTime;
			var DiffPubNonColor2 = noncolor - ContTotalColorTime;
			if(noncolor > ContTotalTime)  {
				alert("注意: 落版之 '總廣告色彩次數' 超過合約書細節之 '總刊登次數' " + DiffPubNonColor1 + " 次!");
				return;
			}
			if(noncolor > ContTotalColorTime)  {
				alert("注意: 落版之 '總廣告色彩次數' 超過合約書細節之 '總廣告色彩次數' " + DiffPubNonColor2 + " 次!");
				return;
			}
			
			//// 若 落版 之 總彩色次數+總黑白次數+總套色次數 > 總刊登次數, 則予以警告
			//var PubTotalColorTime = parseInt(clrtm) + parseInt(memotm) + parseInt(getclrtm);
			////alert("PubTotalColorTime= " + PubTotalColorTime);
			//var DiffContTime2 = parseInt(PubTotalColorTime) - parseInt(ContTotalTime);
			//if(PubTotalColorTime>ContTotalTime)  {
				//alert("注意: 落版處 彩色+黑白+套色次數 超過 總刊登次數 " + DiffContTime2 + " 次!");
				//return;
			//}
			
			
			// B 段:	
			// 若 改稿+新稿的份數(每筆落版為一份) > 換稿次數, 則予以警告訊息
			var ContChgjtm = window.document.all("tbxChangeJTime").value;
			var DiffChgjtm = Chgjtm - ContChgjtm;
			if(parseInt(Chgjtm) > ContChgjtm)  {
				alert("注意: 落版處 已超過合約細節之換稿次數：" + DiffChgjtm + " 次, 請確認是否要收換稿費用!");  
				return; }
			
			// C 段:
			// 若總製稿次數 > 已製稿次數, 則予以警告訊息
			var ContTotjtm = window.document.all("tbxTotalJTime").value;
			var Diffjtm = Madejtm - ContTotjtm;
			if(parseInt(Madejtm) > ContTotjtm)  {
				alert("注意: 落版處 已超過合約細節之總製稿次數：" + Diffjtm + " 次, 請確認是否要收換稿費用!");  
				return; }
			// 合約書細節的 已製稿次數 在本畫面中沒有顯示, 是隱藏欄位, 要輸出其值, 以供在維護畫面中顯示.
			xmlContDetail.selectSingleNode("已製稿次數").text = parseInt(Madejtm);
			
			// D 段:
			// 指定第一筆落筆資料之換稿費用 (idx=1, item(0)) 的 XML 資料為 chgamt
			xmlAdpubItems.selectSingleNode("落版後金額").text=parseInt(pubamt);
			// 指定第 N 筆落筆資料之換稿費用 (idx=2..., item(idx-1)) 的 XML 資料為 chgamt
			for(m=1; m<=idx-1; m++) {
				xmlAdpubData.childNodes.item(m).selectSingleNode("落版後金額").text=parseInt(pubamt);
			}		
			
			// E 段:
			// 指定第一筆落筆資料之換稿費用 (idx=1, item(0)) 的 XML 資料為 chgamt
			xmlAdpubItems.selectSingleNode("換稿費用").text=parseInt(chgamt);
			// 指定第 N 筆落筆資料之換稿費用 (idx=2..., item(idx-1)) 的 XML 資料為 chgamt
			for(n=1; n<=idx-1; n++) {
				xmlAdpubData.childNodes.item(n).selectSingleNode("換稿費用").text=parseInt(chgamt);
			}
			// 即指定 idx = 1, 2, 3, ...N 時, item(0), item(1), item(2), ..., item(idx-1) 的值都要一樣相同.
			//xmlAdpubData.childNodes.item(idx-1).selectSingleNode("換稿費用").text=parseInt(chgamt);
			//alert(xmlAdpubData.xml);
			
			//----
			// 若 "落版之總費用 (pubamt+chgamt)" 超過合約書細節之 "合約總金額", 則予以警告
			var ContTotalAmt = window.document.all("tbxTotalAmt").value;
			var PubTotalAmt = parseInt(pubamt) + parseInt(chgamt);
			var DiffAmt = parseInt(PubTotalAmt) - parseInt(ContTotalAmt);
			if(PubTotalAmt>ContTotalAmt)  {
				alert("落版之總金額 (落版廣告金額+換稿金額) 超過合約書細節之 '合約總金額' $ " + DiffAmt + ",\n 請修正!");
				return;
			}
			
			// 判斷是否有按下 '發票廠商收件人姓名'旁的按鈕, 否則予以警告
			if(document.all("lblInvRec").innerText == "")  {
				alert("您沒有按下 '發票廠商收件人姓名' 旁的按鈕, 請按一下做確認!");
				return;
			}
			
			// 判斷是否有按下 '雜誌收件人姓名'旁的按鈕, 否則予以警告
			if(document.all("lblTotalPubCount").innerText == "")  {
				alert("您沒有按下 '雜誌收件人姓名' 旁的按鈕, 請按一下做確認!");
				return;
			}
			
			// 判斷是否有按下 '雜誌收件人姓名'旁的按鈕, 否則予以警告
			// 寫在上方 for loop -  H 段裡 
			
			
			// 若落版的總次數 > 總刊登次數, 則給予警告訊息, 且不予以繼續新增
			//alert("idx= " + idx);
			var tottm = window.document.all("tbxTotalTime").value;
			var freetm = window.document.all("tbxFreeTime").value;
			var TotalContPubTime = tottm + freetm;
			//alert(TotalContPubTime);
			if (idx > tottm)  {
				alert("注意: 此張合約書總刊登次數已滿, 請考慮再簽訂合約.  (或請確認總刊登次數!)");
				alert("資料尚未新增!!!!!!");
				return; }
			else
			{
				// 透過 textarea 做為檢查輸出的 XML 是否正確 
				//document.all("textarea1").value=xmlMain.xml;
				////alert(xmlDoc0.xml);
				
				
				//// 測試, 先傳字串給存檔程式 (cont_newSave.aspx) 看看是否有問題
				//// 若無, 再進行傳 xml 資料
				////  在這邊把 xmlDoc1.xml 的資料傳給存檔程式
				////var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
				////xmlHTTP.Open("post", "cont_mainSave.aspx", false);
				//// 單傳字串到 cont_newSave.aspx 看看是否抓得到; 若抓得到, 再抓 xmlDoc1
				////xmlHTTP.Send("test");
				////document.all("textarea1").value=xmlHTTP.responseText;
				////var xmlHTTP = null;
				
				
				// 開始傳送 xml 資料至資料庫中儲存 ------------------
				// 在這邊把 xmlDoc1.xml 的資料傳給存檔程式
				var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
				xmlHTTP.Open("post", "cont_newSave.aspx", false);
				xmlHTTP.Send(xmlDoc0);
				
				// 檢查並輸出 xmlHTTP 狀態於本頁 textarea1 內
				//document.all("textarea1").value=xmlHTTP.responseText;
				
				// 若儲存成功, 以警告視窗顯示
				if(xmlHTTP.statusText=="OK")
				{
					alert("新增合約書成功");
					
					// 新增成功, 轉址到訊息頁:
					// 轉址到訊息頁: 非一次付款
					if(xmlContBasicData.selectSingleNode("一次付清註記").text==0)  {
						window.location.href="cont_SaveMessage.aspx?str=cont_newSave&cno=" + window.document.all("hiddenContNo").value;
					}
					// 轉址到訊息頁: 一次付款
					else  {
						window.location.href="cont_SaveMessage.aspx?str=cont_newSavefg&cno=" + window.document.all("hiddenContNo").value;
					}
					
				}
				
				// 清除 xmlHTTP 資料為空
				var xmlHTTP = null;
			}
			
		}
		//-->
		</script>
	</BODY>
</HTML>
