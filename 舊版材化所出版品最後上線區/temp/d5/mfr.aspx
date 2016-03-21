<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Src="mfr.aspx.cs" Codebehind="mfr.aspx.cs" AutoEventWireup="false" Inherits="d5.mfr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
					event.returnValue=confirm("是否確定刪除?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<table id="tbItems" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td width="100%" align="left">
					<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						&nbsp;共同檔案222 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						廠商資料 </font>
				</td>
			</tr>
		</table>
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<form id="mfr" method="post" runat="server">
				<TR>
					<TD style="WIDTH: 64px" height="36">
						<P align="right">
							<FONT style="FONT-SIZE: 9pt" face="新細明體">發票抬頭：</FONT>
						</P>
					</TD>
					<TD style="WIDTH: 159px" height="36">
						<asp:TextBox id="QString" runat="server" Width="96px" Height="21px"></asp:TextBox>
						<FONT face="新細明體"></FONT>
						<asp:Button id="Query" runat="server" Text="搜尋" Width="50px" Height="22px" Font-Size="9pt"></asp:Button>
					</TD>
					<TD height="36">
						<FONT face="新細明體">
							<asp:Button id="Addnew" runat="server" Text="新增一筆資料" Width="118px" Height="22px" Font-Size="9pt"></asp:Button>
						</FONT>
					</TD>
				</TR>
		</table>
		<asp:DataGrid id="DataGrid1" style="FONT-SIZE: 9pt" runat="server" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" CellPadding="2" BackColor="White" AllowPaging="True">
			<HeaderStyle ForeColor="White" BackColor="#214389"></HeaderStyle>
			<PagerStyle Mode="NumericPages"></PagerStyle>
			<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
			<ItemStyle BackColor="#BFCFF0"></ItemStyle>
			<Columns>
				<asp:BoundColumn DataField="mfr_mfrid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_mfrno" HeaderText="廠商統一編號"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_inm" HeaderText="發票抬頭(公司名稱)"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_iaddr" HeaderText="廠商(發票郵寄)地址"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_izip" HeaderText="廠商郵遞區號"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_respnm" HeaderText="公司負責人姓名"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_respnjbti" HeaderText="公司負責人職稱"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_tel" HeaderText="公司聯絡電話"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_fax" HeaderText="公司傳真號碼"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_regdate" HeaderText="註冊日期"></asp:BoundColumn>
				<asp:EditCommandColumn ButtonType="PushButton" UpdateText="更新" HeaderText="修改" CancelText="取消" EditText="修改">
					<HeaderStyle BackColor="ControlDarkDark">
					</HeaderStyle>
				</asp:EditCommandColumn>
				<asp:ButtonColumn Text="刪除" ButtonType="PushButton" HeaderText="刪除" CommandName="Delete">
					<HeaderStyle BackColor="ControlDarkDark">
					</HeaderStyle>
				</asp:ButtonColumn>
			</Columns>
		</asp:DataGrid>
		<P>
		</P>
		</FORM> 
		<!-- 頁尾 Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
