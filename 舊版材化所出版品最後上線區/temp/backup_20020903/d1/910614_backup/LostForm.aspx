<%@ Page language="c#" Codebehind="LostForm.aspx.cs" src="LostForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.LostForm" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="LostForm" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 627px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
								缺書處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">缺書登錄</font>
						</td>
					</tr>
				</table>
				<TABLE style="WIDTH: 596px; HEIGHT: 68px" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">訂單資料</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 5px" align="right">
							訂單編號：
						</td>
						<td style="WIDTH: 148px; HEIGHT: 5px">
							<asp:label id="lblNo" Runat="server" ForeColor="Maroon"></asp:label>
						</td>
						<td style="WIDTH: 120px; HEIGHT: 5px" align="right">
							訂購類別：
						</td>
						<td style="WIDTH: 192px; HEIGHT: 5px">
							<asp:label id="lblType1" Runat="server" ForeColor="Maroon"></asp:label>
						</td>
					</tr>
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 132px" align="right">
							訂戶編號：
						</TD>
						<TD style="WIDTH: 148px">
							<asp:label id="lblCustNo" Runat="server" ForeColor="Maroon"></asp:label>
						</TD>
						<TD style="WIDTH: 120px" align="right">
							姓名：
						</TD>
						<TD style="WIDTH: 192px">
							<asp:label id="lblCustName" Runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 132px; HEIGHT: 1px" align="right">
							公司名稱：
						</TD>
						<TD style="WIDTH: 192px; HEIGHT: 1px" colSpan="3">
							<asp:label id="lblCoName" Runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">收件人資料</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 1px" align="right">
							收件人：
						</td>
						<td style="WIDTH: 148px; HEIGHT: 1px" colSpan="3">
							<asp:label id="lblRecName" Runat="server" ForeColor="Maroon"></asp:label>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 1px" align="right">
							地址：
						</td>
						<td style="WIDTH: 192px; HEIGHT: 1px" colSpan="3">
							<asp:label id="lblRecAddr" Runat="server" ForeColor="Maroon"></asp:label>
						</td>
					</tr>
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">缺書資料</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 31px" align="right">
							缺書序號：
						</td>
						<td style="WIDTH: 148px; HEIGHT: 31px">
							<asp:label id="lblLostSeq" runat="server" ForeColor="Maroon"></asp:label>
						</td>
						<td style="WIDTH: 132px; HEIGHT: 31px" align="right">
							訂購起迄：
						</td>
						<td style="WIDTH: 148px; HEIGHT: 31px">
							<asp:label id="lblsdate" runat="server" ForeColor="Maroon"></asp:label>
							~<asp:label id="lbledate" runat="server" ForeColor="Maroon"></asp:label>
						</td>
					</tr>
					<tr>
						<td class="cssTitle" style="WIDTH: 132px; HEIGHT: 75px" align="right">
							缺書內容：
						</td>
						<td class="cssData" style="HEIGHT: 75px" colSpan="3">
							<TEXTAREA id="textarea1" style="WIDTH: 445px; HEIGHT: 77px" rows="4" cols="53" runat="server"></TEXTAREA>
						</td>
					</tr>
					<tr>
						<td class="cssTitle" style="WIDTH: 132px; HEIGHT: 42px" align="right">
							缺書原因：
						</td>
						<td class="cssData" colSpan="3">
							<TEXTAREA id="textarea2" style="WIDTH: 445px; HEIGHT: 75px" rows="4" cols="53" runat="server"></TEXTAREA>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 1px" align="right">
							寄書狀態：
						</td>
						<td style="WIDTH: 192px; HEIGHT: 1px" colSpan="3">
							<asp:DropDownList id="ddlSendFlag" runat="server">
								<asp:ListItem Value="Y" Selected="True">可寄出</asp:ListItem>
								<asp:ListItem Value="N">目前暫時無法寄出</asp:ListItem>
								<asp:ListItem Value="D">不處理</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
				</TABLE>
				<asp:button id="btnModify" runat="server" Width="163px" Text="資料錯誤,修改訂單" Height="28px"></asp:button>
				<asp:button id="btnOK" runat="server" Width="157px" Text="確定新增缺書資料" Height="28px"></asp:button>
				<asp:button id="btnCancel" runat="server" Width="82px" Text="取消回首頁" Height="28px"></asp:button>
			</center>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<SCRIPT language="javascript">
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vReturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vReturn)
		window.document.all(theField).value=vReturn;
	return true;
}
		</SCRIPT>
	</body>
</HTML>
