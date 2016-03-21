<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="ContFm_modify.aspx.cs" Src="ContFm_modify.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_modify" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>維護合約書 步驟三</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// cal按鈕的 coding: 抓系統日期
		function pick_date(theField, theField1, theField2)
		{
			// 簽約日期
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			//alert("vreturn= " + vreturn);
			
			// 合約起日: 簽約日期的下一個月份
			var vreturn1YYYY = vreturn.substring(0, 4);
			var vreturn1MM = vreturn.substring(5, 7);
			vreturn1MM = parseInt(vreturn1MM) + 1;
			if(vreturn1MM < 10)
				vreturn1MM = "0" + vreturn1MM;
			else
				vreturn1MM = vreturn1MM;
			var vreturn1 = vreturn1YYYY + "/" + vreturn1MM;
			//alert("vreturn1= " + vreturn1);
			
			// 合約迄日: 合約起日一年內 (+ 11個月)
			var vreturn2YYYY = vreturn1YYYY;
			var vreturn2MM = vreturn1MM;
			//alert(parseInt(vreturn2MM));
			// 若合約起日月份為 1月, 則其合約迄日= 年份=合約起日月份 & 月份=12
			if(parseInt(vreturn2MM) == 1)
			{
				vreturn2YYYY = vreturn2YYYY;
				vreturn2MM = 12;
			}
			// 否則, 合約迄日= 年份=合約起日年份+1 & 月份=合約起日月份-1
			else
			{
				// 若月份為 11~12, 則其輸出格式 前方不必加 0 來顯示
				if(parseInt(vreturn2MM) >= 11)
				{
					vreturn2YYYY = parseInt(vreturn1YYYY) + 1;
					vreturn2MM = parseInt(vreturn1MM) - 1;
					vreturn2MM = vreturn2MM;
				}
				// 若月份小於 11, 則其輸出格式 前方加 0 來顯示
				else
				{
					vreturn2YYYY = parseInt(vreturn1YYYY) + 1;
					//alert(parseInt(vreturn1MM));
					vreturn2MM = parseInt(vreturn1MM) - 1;
					vreturn2MM = "0" + vreturn2MM;
					
					// 特別針對簽約日期之月份=8, 9 的 bug 解決
					if(parseInt(vreturn1MM) == 0)
					{
						vreturn2MM = parseInt(vreturn.substring(6, 7)) - 1;
						vreturn2MM = "0" + vreturn2MM;
					}
				}
			}
			var vreturn2 = vreturn2YYYY + "/" + vreturn2MM;
			//alert("vreturn2= " + vreturn2);
			
			window.document.all(theField).value=vreturn;
			window.document.all(theField1).value=vreturn1;
			window.document.all(theField2).value=vreturn2;
			return true;
		}
		//-->
		</script>
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
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
			<!-- Run at Server Form-->
			<form id="ContFm_modify" method="post" runat="server">
				<!--Table 開始-->
				<TABLE cellSpacing="0" cellPadding="4" width="92%" bgColor="#bfcff0" border="0">
					<!-- 廠商及客戶資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">廠商及客戶資料</font>
						</td>
					</TR>
					<!-- 廠商資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							公司名稱 (廠商統編)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrIName" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon"></asp:label>
							)
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=450, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- 公司負責人資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							公司負責人 姓名(職稱)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
							&nbsp;<FONT face="新細明體">(
								<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							公司電話 (傳真)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrTel" runat="server"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblMfrFax" runat="server"></asp:label>
								)</FONT>
						</TD>
					</TR>
					<!-- 客戶資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							客戶姓名 (客戶編號)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server" ForeColor="Maroon"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblCustNo" runat="server" ForeColor="Maroon"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- 合約書基本資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="#ffffff">合約書基本資料&nbsp;&nbsp;</font>&nbsp;
							<asp:label id="lblfgClosedMessage" runat="server" ForeColor="Yellow"></asp:label>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right" bgcolor="#bfcff0">
							簽約日期：
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxSignDate" runat="server" MaxLength="10" Width="65px"></asp:textbox>
							<IMG id="img_signdate" onclick='javascript:pick_date("tbxSignDate", "tbxStartDate", "tbxEndDate");return false;' height="18" alt="查詢日期" src="../images/calendar01.gif" width="18">&nbsp;
							<FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">為必填欄位]</FONT>
							<br>
							<FONT face="新細明體" color="#c00000">(預設值: 一年, 如 2002/06 ~ 2003/05)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							合約書編號：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:label id="lblContNo" runat="server" ForeColor="Maroon"></asp:label>
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
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							書籍類別：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							合約起迄日：
						</TD>
						<TD class="cssData" noWrap>
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxStartDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
							&nbsp; <font size="3">~</font> <FONT color="red">*</FONT>
							<asp:textbox id="tbxEndDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
							&nbsp;
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							建檔業務員：
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							一次付清註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
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
							<asp:RadioButtonList id="rblfgClosed" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							修改業務員：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:DropDownList id="ddlModEmpNo" runat="server"></asp:DropDownList>
							<br>
							<FONT face="新細明體" color="#c00000">(預設值: 登入者)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							合約註銷註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:RadioButtonList id="rblfgCancel" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							參考合約書編號：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblOldContNo" runat="server" ForeColor="Maroon"></asp:Label>
							&nbsp;&nbsp;
							<asp:Label id="lblOldContMessage" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							建檔日期：
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;
							<asp:Label id="lblCreateDate" runat="server"></asp:Label>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							最後修改日期：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblModifyDate" runat="server"></asp:Label>
						</TD>
					</TR>
					<!-- 合約書細節 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">合約書細節</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
							<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" width="90%" border="0">
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										總製稿次數：
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										總刊登次數：
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										合約總金額：
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT>$
										<asp:textbox id="tbxTotalAmt" runat="server" MaxLength="8" Width="60px"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										已製稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxMadeJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										已刊登次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxPubTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										已繳金額：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:TextBox id="tbxPaidAmt" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										剩餘製稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										剩餘刊登次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										剩餘金額：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:TextBox id="tbxRestAmt" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										換稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										贈送次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										廣告費單價：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:TextBox id="tbxADAmt" runat="server" MaxLength="8" Width="40px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										優惠折數：
										<BR>
										<FONT face="新細明體" color="#c00000">(請填實數!)</FONT>
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxDiscount" runat="server" MaxLength="6" Width="40px"></asp:textbox>
										<FONT face="新細明體">折</FONT>&nbsp;
										<br>
										<FONT color="#c00000">七五折, 請填 0.75</FONT>
									</TD>
									<TD class="cssTitle" align="right">
										贈送本數：
									</TD>
									<TD class="cssData">
										$
										<asp:textbox id="tbxFreeBookCount" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										彩色次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxColorTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										套色次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxGetColorTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										黑白次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="tbxMenoTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 總廣告金額：</font>
									</TD>
									<TD class="cssData">
										$
										<asp:textbox id="tbxPubAdAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray" Enabled="False"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 總換稿金額：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:textbox id="tbxPubChangeAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray" Enabled="False"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 剩餘彩色次：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestClrtm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 剩餘套色次：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestGetClrtm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 剩餘黑白次：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:TextBox id="tbxRestMenotm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR> <!-- 廣告聯絡人 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">廣告聯絡人資料</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							廣告聯絡人姓名：
						</TD>
						<TD class="cssData">
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" MaxLength="30" Width="65px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData" noWrap>
							<FONT face="新細明體" color="#c00000">(本區資料 預設同客戶資料!)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							電話：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuTel" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							傳真：
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuFax" runat="server" MaxLength="30" Width="85px"></asp:textbox>
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
							<asp:textbox id="tbxAuEmail" runat="server" MaxLength="80" Width="160px"></asp:textbox>
						</TD>
					</TR>
					<!-- 備註　資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">備註</font>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" align="right">
							額外備註：
						</TD>
						<TD class="cssData" colSpan="3">
							&nbsp;&nbsp;&nbsp;<TEXTAREA id="tarContRemark" name="tarContRemark" rows="5" cols="60" runat="server"></TEXTAREA>
						</TD>
					</TR>
					<!-- 發票廠商收件人 資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="#ffffff">發票廠商收件人資料</font>&nbsp;&nbsp;&nbsp;
							<asp:Label id="lblIMMessage" runat="server" ForeColor="Yellow"></asp:Label>
							&nbsp;&nbsp; <IMG class="ico" title="新增/修改/刪除 發票廠商收件人" height="18" src="../images/new.gif" border="0" onclick="javascript:window.open('InvMfrForm.aspx?contno=<% Response.Write(lblContNo.Text); %>&amp;custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblOldContNo.Text); %>&amp;fgnew=<% Response.Write(lblfgNew.Text); %>', '_new', 'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')">&nbsp;&nbsp;&nbsp;
							<asp:ImageButton id="imbIMRefresh" runat="server" ImageUrl="../images/refresh.gif" AlternateText="重新整理 發票廠商收件人資料"></asp:ImageButton>
							<asp:Label id="lblfgNew" runat="server" ForeColor="Yellow" Visible="False"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD colspan="4">
							<font color="darkred">操作說明：</font>按 <img src="../images/new.gif" border="0" alt="新增/修改/刪除 雜誌收件人">
							來 新增 / 修改 / 刪除 收件人資料; &nbsp;按 <img src="../images/refresh.gif" border="0" alt="重新整理 雜誌收件人資料">
							來取得及確認最新資料!
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Font-Size="XX-Small">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_addr" HeaderText="發票地址"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
							<br>
						</TD>
					</TR>
					<!-- 雜誌收件人 資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="#ffffff">雜誌收件人資料</font>&nbsp;&nbsp;
							<asp:Label id="lblORMessage" runat="server" ForeColor="Yellow"></asp:Label>
							&nbsp;&nbsp;&nbsp; <IMG class="ico" title="新增/修改/刪除 雜誌收件人" height="18" src="../images/new.gif" border="0" onclick="javascript:window.open('ORForm.aspx?contno=<% Response.Write(lblContNo.Text); %>&amp;custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblOldContNo.Text); %>&amp;fgnew=<% Response.Write(lblfgNew.Text); %>', '_new', 'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')">&nbsp;&nbsp;&nbsp;
							<asp:ImageButton id="imbORRefresh" runat="server" AlternateText="重新整理 雜誌收件人資料" ImageUrl="../images/refresh.gif"></asp:ImageButton>
							<font color="yellow">(資料取回後, 請按一下左方按鈕)</font>
						</TD>
					</TR>
					<TR>
						<TD colspan="4">
							<font color="darkred">操作說明：</font>按 <img src="../images/new.gif" border="0" alt="新增/修改/刪除 雜誌收件人">
							來 新增 / 修改 / 刪除 收件人資料; &nbsp;按 <img src="../images/refresh.gif" border="0" alt="重新整理 雜誌收件人資料">
							來取得及確認最新資料!
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_inm" HeaderText="廠商名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_jbti" HeaderText="職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_addr" HeaderText="郵寄地址"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_unpubcnt" HeaderText="未登本數"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_mtpcd" HeaderText="郵寄類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_fgmosea" HeaderText="海外郵寄"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
							<br>
							<div align="right">
								<font color="red">有登本數／未登本數 總計：
									<asp:Label id="lblORPunCnt" runat="server" ForeColor="Blue"></asp:Label>
									&nbsp;
									<asp:Label id="lblORUnPubCnt" runat="server" ForeColor="Blue"></asp:Label>
								</font>&nbsp;
							</div>
						</TD>
					</TR>
					<TR bgColor="#ffffff">
						<TD align="middle" colSpan="4">
							<br>
							<asp:button id="btnSave" runat="server" Text="儲存修改"></asp:button>
							&nbsp;&nbsp;
							<asp:button id="btnCancel" runat="server" Text="取消回首頁"></asp:button>
							&nbsp;
							<asp:Button id="btnGoPub" runat="server" Text="維護落版資料"></asp:Button>
							&nbsp;
							<asp:Label id="lblfgPubed" runat="server"></asp:Label>
							<asp:Label id="lblpubfgnew" runat="server"></asp:Label>
						</TD>
					</TR>
				</TABLE>
			</form>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
		<!-- 網頁重新整理 功能 (當 收件人視窗關閉時, 會呼叫此 function) -->
		<script language="javascript">
			function RefreshMe()
			{
				window.ContFm_modify.submit();
			}
		</script>
	</body>
</HTML>
