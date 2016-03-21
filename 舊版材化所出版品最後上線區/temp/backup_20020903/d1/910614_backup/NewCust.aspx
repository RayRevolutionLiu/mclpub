<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="NewCust.aspx.cs" src="NewCust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.NewCust" %>
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
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<form id="CustForm" method="post" runat="server">
			<CENTER>
				<table id="tbItems">
					<tr>
						<td style="WIDTH: 600px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								訂戶資料 <IMG height="10" src="images/header/right02.gif" width="10" border="0"> 新增訂戶資料
							</font>
						</td>
					</tr>
				</table>
			</CENTER>
			<CENTER>
				<TABLE style="WIDTH: 600px" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 647px" colSpan="4">
							<font color="white">廠商資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							公司名稱：
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							&nbsp;&nbsp;
							<asp:textbox id="tbxCompanyname" runat="server" Width="200px"></asp:textbox>
							<IMG class="ico" title="查詢" onclick="doSelectMfr( tbxMfrno.name,tbxMfrno.value,tbxCompanyname.name, tbxCompanyname.value)" height="20" src="images/search.gif" width="18" border="0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<font color="blue">[</font><font color="red">*</font><font color="blue">為必填欄位]</font>
							<br>
							<asp:label id="Label1" runat="server" ForeColor="DarkRed">[請輸入關鍵值然後按"查詢"以取得統一編號] </asp:label>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							統一編號：
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxMfrno" runat="server" Width="107px"></asp:textbox>
							<IMG class="ico" title="查詢" onclick="doSelectMfr( tbxMfrno.name,tbxMfrno.value,tbxCompanyname.name, tbxCompanyname.value)" height="20" src="images/search.gif" width="18" border="0">
							<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="tbxMfrno" ErrorMessage="RequiredFieldValidator">不能為空白</asp:requiredfieldvalidator>
							<asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label>
							<br>
							<asp:label id="Label2" runat="server" ForeColor="DarkRed">[如確定輸入正確之統一編號,即可跳過查詢功能繼續輸入以下資料] </asp:label>
						</TD>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 647px" colSpan="4">
							<font color="white">新訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							訂戶編號：
						</TD>
						<TD style="WIDTH: 185px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:Label id="lblInvoiceid" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
						<TD style="WIDTH: 69px" align="right">
							登錄日期：
						</TD>
						<TD style="WIDTH: 259px">
							<asp:textbox id="tbxRegDate" runat="server" Width="107px"></asp:textbox>
							<IMG class="ico" title="日曆" onclick="pick_date(tbxRegDate.name)" src="../images/calendar01.gif">
							<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="tbxRegDate" ErrorMessage="日期格式 2001/01/01" Font-Size="X-Small" ValidationExpression="[0-9]{4}/[0-9]{2}/[0-9]{2}"></asp:regularexpressionvalidator>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							姓名：
						</TD>
						<TD style="WIDTH: 185px">
							<font color="red">*</font>
							<asp:textbox id="tbxCustname" runat="server" Width="107px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCustname" ErrorMessage="不能為空白" Font-Size="X-Small"></asp:requiredfieldvalidator>
						</TD>
						<TD style="WIDTH: 69px" align="right">
							手機號碼：
						</TD>
						<TD style="WIDTH: 259px">
							<asp:textbox id="tbxCell" runat="server" Width="107px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							聯絡電話：
						</TD>
						<TD style="WIDTH: 185px">
							<font color="red">*</font>
							<asp:textbox id="tbxTel" runat="server" Width="107px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTel" ErrorMessage="不能為空白" Font-Size="X-Small"></asp:requiredfieldvalidator>
						</TD>
						<TD style="WIDTH: 69px" align="right">
							傳真號碼：
						</TD>
						<TD style="WIDTH: 259px">
							<asp:textbox id="tbxFax" runat="server" Width="107px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							職稱：
						</TD>
						<TD style="WIDTH: 185px">
							<asp:radiobuttonlist id="rblJob" runat="server" Width="176px" RepeatDirection="Horizontal" AutoPostBack="true">
								<asp:ListItem Value="先生" Selected="True">先生</asp:ListItem>
								<asp:ListItem Value="小姐">小姐</asp:ListItem>
								<asp:ListItem Value="自訂">自訂</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD style="WIDTH: 341px" colSpan="2">
							<asp:textbox id="tbxJob" runat="server" Enabled="False" Height="26px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							Email：
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<asp:textbox id="tbxEmail" runat="server" Width="322px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							營業項目：
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<asp:checkboxlist id="cblbtp" runat="server" Width="506px" RepeatDirection="Horizontal" BorderStyle="Inset" BorderWidth="1px" RepeatColumns="4" BackColor="#E2EAFC"></asp:checkboxlist>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							專業領域：
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<asp:checkboxlist id="cblitp" runat="server" Width="506px" RepeatDirection="Horizontal" BorderStyle="Inset" BorderWidth="1px" RepeatColumns="4" BackColor="#E2EAFC"></asp:checkboxlist>
						</TD>
					</TR>
				</TABLE>
				<asp:button id="btnNew" runat="server" Text="新增資料"></asp:button>
				<input onclick="javascript:window.history.back();" type="button" value="放棄新增">
				<br>
			</CENTER>
		</form>
		<!-- 頁尾 Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
function doSelectMfr(theField1, value1, theField2, value2)
{
	strFeature = "";
	strFeature += "dialogHeight:350px;dialogWidth:600px;center:yes;scroll:yes;status:no;help:no;";
	var vReturn = window.open("MfrSearch.aspx?Field1="+theField1+"&mfrno="+value1+"&Field2="+theField2+"&company="+value2); 
}
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vReturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vReturn)
		window.document.all(theField).value=vReturn;
	return true;
}
	</script>
	</body>
</HTML>
