<%@ Page language="c#" Codebehind="cust.aspx.cs" src="cust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.cust" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>客戶資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="JScript">
			function Delete_confirm(e) 
			{
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
					event.returnValue=confirm("是否確定刪除?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server"></kw:header>
		<CENTER>
			<FORM id="cust" method="post" runat="server">
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="90%" border="0">
						<TR>
							<TD vAlign="top" height="22">
								<FONT color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;共同檔案
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;客戶資料維護
									<FONT color="dimgray">(
										<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
										共有
										<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
										筆資料 )</FONT>
									<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
								</FONT>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" height="224">
								<P align="left">
									<asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
										<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
										<ItemStyle BackColor="#BFCFF0"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="cust_custid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_custno" HeaderText="客戶編號"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_jbti" HeaderText="客戶職稱"></asp:BoundColumn>
											<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商發票抬頭"></asp:BoundColumn>
											<asp:BoundColumn DataField="srspn_cname" HeaderText="業務人員"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_tel" HeaderText="聯絡電話"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_fax" HeaderText="傳真號碼"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_cell" HeaderText="手機號碼"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_email" HeaderText="Email 地址"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_oldcustno" HeaderText="舊客戶編號"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_regdate" HeaderText="註冊日期"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_moddate" HeaderText="修改日期"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_itpcd" HeaderText="客戶領域代碼"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_btpcd" HeaderText="客戶營業代碼"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_rtpcd" HeaderText="客戶閱讀代碼"></asp:BoundColumn>
											<asp:ButtonColumn Text="修改" ButtonType="PushButton" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
											<asp:ButtonColumn Text="刪除" ButtonType="PushButton" HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
									</asp:datagrid>
								</P>
							</TD>
						</TR>
						<TR>
							<TD height="40">
								<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
								<asp:dropdownlist id="ddlQueryField" runat="server">
									<asp:ListItem Value="cust_nm" Selected="True">客戶姓名</asp:ListItem>
									<asp:ListItem Value="cust_custno">客戶編號</asp:ListItem>
									<asp:ListItem Value="cust_oldcustno">舊客戶編號</asp:ListItem>
									<asp:ListItem Value="mfr_inm">廠商發票抬頭</asp:ListItem>
									<asp:ListItem Value="cust_mfrno">廠商統一編號</asp:ListItem>
									<asp:ListItem Value="cust_tel">聯絡電話</asp:ListItem>
									<asp:ListItem Value="cust_srspn_empno">業務人員</asp:ListItem>
								</asp:dropdownlist>
								<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="開始搜尋"></asp:button>
								<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="全部顯示"></asp:button>
								&nbsp; &nbsp;
								<asp:button id="btnAddNew" runat="server" Height="23px" Font-Size="9pt" Text="新增資料"></asp:button>
							</TD>
						</TR>
					</TABLE>
				</FONT>
			</FORM>
		</CENTER>
		<!-- 頁尾 Footer -->
		<kw:footer id="Footer" runat="server"></kw:footer>
	</body>
</HTML>
