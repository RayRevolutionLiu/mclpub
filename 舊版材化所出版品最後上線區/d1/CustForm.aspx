<%@ Page language="c#" Codebehind="CustForm.aspx.cs" src="CustForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CustForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="CustForm" method="post" runat="server">
			<FONT face="新細明體"></FONT>
		</form>
		<center>
			<table dataFld="items" id="tbItems">
				<tr>
					<td style="WIDTH: 627px" align="left">
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
							訂戶資料 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
							<% Response.Write(Context.Request.QueryString["type"]);%>
						</font>
					</td>
				</tr>
			</table>
			<TABLE style="WIDTH: 596px; HEIGHT: 68px" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">訂戶資料</font>
					</td>
				</tr>
				<TR>
					<TD class="cssTitle" style="WIDTH: 189px" align="right">
						訂戶編號：
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						<INPUT dataFld="訂戶類別" id="invoiceid" type="text" name="invoiceid" style="WIDTH: 109px; HEIGHT: 22px" size="12">
						<IMG class="ico" onclick="doSelectCust('訂戶類別', custname.value)" height="20" src="images/search.gif" width="18" border="0" title="查詢">
					</TD>
					<TD class="cssTitle" style="WIDTH: 109px" align="right">
						公司名稱：
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						<INPUT dataFld="公司名稱" id="companyname" type="text" name="companyname" style="WIDTH: 159px; HEIGHT: 22px" size="21">
						<IMG class="ico" onclick="doSelectCust('公司名稱', companyname.value)" height="20" src="images/search.gif" width="18" border="0" title="查詢">
					</TD>
				</TR>
				<TR>
					<TD class="cssTitle" style="WIDTH: 189px" align="right">
						姓名：
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						<INPUT dataFld="姓名" id="custname" type="text" name="custname" style="WIDTH: 108px; HEIGHT: 22px" size="12">
						<IMG class="ico" onclick="doSelectCust('姓名', custname.value)" height="20" src="images/search.gif" width="18" border="0" title="查詢">
					</TD>
					<TD class="cssTitle" style="WIDTH: 109px" align="right">
						詳細資料：
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						&nbsp;<IMG class="ico" title="訂戶詳細資料" height="14" src="images/edit.gif" width="16" border="0">
					</TD>
				</TR>
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">訂單及發票資料</font>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 22px" align="right">
						訂單流水號：
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 22px">
						&nbsp;
						<asp:dropdownlist id="DropDownList3" runat="server">
							<asp:ListItem Value="1">001</asp:ListItem>
							<asp:ListItem Value="2">002</asp:ListItem>
							<asp:ListItem Value="3">003</asp:ListItem>
						</asp:dropdownlist>
					</td>
					<td class="cssTitle" style="WIDTH: 109px; HEIGHT: 22px" align="right">
						收件人：
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 22px">
						&nbsp;
						<asp:dropdownlist id="DropDownList4" runat="server">
							<asp:ListItem Value="001">葉玉莉</asp:ListItem>
							<asp:ListItem Value="002">陳俐靜</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 22px" align="right">
						訂購書籍：
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 22px">
						&nbsp;
						<asp:dropdownlist id="Dropdownlist2" runat="server">
							<asp:ListItem Value="1">工材訂購</asp:ListItem>
							<asp:ListItem Value="2">電材訂購</asp:ListItem>
						</asp:dropdownlist>
					</td>
					<td class="cssTitle" style="WIDTH: 109px; HEIGHT: 33px" align="right">
						訂購類別：
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 33px">
						<FONT face="新細明體">訂閱</FONT>
					</td>
				</tr>
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">缺書資料</font>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 31px" align="right">
						缺書序號：
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 31px">
						<input dataFld="缺書序號" id="Text3" style="WIDTH: 98px; HEIGHT: 22px" type="text" size="11" name="Text3">
					</td>
					<td class="cssTitle" style="WIDTH: 109px; HEIGHT: 31px" align="right">
						缺書日期：
					</td>
					<td class="cssData" style="WIDTH: 192px;HEIGHT: 31px">
						<input dataFld="缺書日期" id="hh" style="WIDTH: 98px" type="text" size="11" name="hh">
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 75px" align="right">
						缺書內容：
					</td>
					<td class="cssData" colSpan="3" style="HEIGHT: 75px">
						&nbsp;<TEXTAREA style="WIDTH: 445px; HEIGHT: 77px" rows="4" cols="53">							</TEXTAREA>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 42px" align="right">
						缺書原因：
					</td>
					<td class="cssData" colSpan="3">
						&nbsp;<TEXTAREA style="WIDTH: 445px; HEIGHT: 75px" rows="4" cols="53">							</TEXTAREA>
					</td>
				</tr>
			</TABLE>
			<!-- 頁尾 Footer -->
		</center>
		<asp:Button id="Button1" runat="server" Text="新增資料"></asp:Button>
		<asp:Button id="Button2" runat="server" Text="修改資料"></asp:Button>
		<asp:Button id="Button3" runat="server" Text="取消輸入"></asp:Button>
	</body>
</HTML>
