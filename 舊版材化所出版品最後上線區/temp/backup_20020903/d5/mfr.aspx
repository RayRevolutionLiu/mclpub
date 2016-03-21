<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Src="mfr.aspx.cs" Codebehind="mfr.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.mfr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廠商資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
		<form id="mfr" method="post" runat="server">
			<table id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
				<tr>
					<td align="left" width="100%" vAlign="top" height="22">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							共同檔案 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廠商資料維護 <FONT color="dimgray">(
								<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
								共有
								<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
								筆資料 )</FONT>
							<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
						</font>
					</td>
				</tr>
				<TR vAlign="top" height="224">
					<TD align="left" width="100%">
						<asp:DataGrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
							<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
							<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
							<ItemStyle BackColor="#BFCFF0"></ItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="mfr_mfrid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_mfrno" HeaderText="廠商統一編號"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="發票抬頭"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_iaddr" HeaderText="發票地址"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_izip" HeaderText="廠商郵遞區號"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_respnm" HeaderText="負責人姓名"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_respjbti" HeaderText="公司負責人職稱"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_tel" HeaderText="公司聯絡電話"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_fax" HeaderText="公司傳真號碼"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_regdate" HeaderText="註冊日期"></asp:BoundColumn>
								<asp:ButtonColumn Text="修改" ButtonType="PushButton" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
								<asp:ButtonColumn Text="刪除" ButtonType="PushButton" HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:DataGrid>
					</TD>
				</TR>
				<TR height="40">
					<TD align="left" width="100%">
						<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
						<asp:dropdownlist id="ddlQueryField" runat="server">
							<asp:ListItem Value="mfr_inm" Selected="True">發票抬頭</asp:ListItem>
							<asp:ListItem Value="mfr_mfrno">統一發票編號</asp:ListItem>
							<asp:ListItem Value="mfr_iaddr">發票地址</asp:ListItem>
							<asp:ListItem Value="mfr_tel">公司聯絡電話</asp:ListItem>
						</asp:dropdownlist>
						<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="開始搜尋"></asp:button>
						<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="全部顯示"></asp:button>
						<FONT face="新細明體">&nbsp;&nbsp;&nbsp;
							<asp:button id="btnAddNew" runat="server" Height="23px" Font-Size="9pt" Text="新增資料"></asp:button>
						</FONT>
					</TD>
				</TR>
			</table>
		</form>
		<!-- 頁尾 Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
