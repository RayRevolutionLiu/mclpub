<%@ Page language="c#" Src="srspn.aspx.cs" Codebehind="srspn.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.srspn" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>管理業務人員資料維護</TITLE>
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
		<form id="srspn" method="post" runat="server">
			<P>
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
						<TR>
							<TD align="left" width="100%" vAlign="top" height="22">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									共同檔案 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									管理業務人員資料維護 <FONT color="dimgray">(
										<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
										共有
										<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
										筆資料 )</FONT>
									<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
								</FONT>
							</TD>
						</TR>
						<TR vAlign="top" height="224">
							<TD align="left" width="100%">
								<asp:DataGrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
									<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
									<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
									<ItemStyle BackColor="#BFCFF0"></ItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="srspn_id" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_empno" HeaderText="業務人員工號"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_cname" HeaderText="業務人員姓名"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_tel" HeaderText="業務人員電話"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_atype" HeaderText="業務人員權限別"></asp:BoundColumn>
										<asp:BoundColumn DataField="OrgAbbName" HeaderText="業務人員單位別"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_deptcd" HeaderText="業務人員部門別"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_date" HeaderText="業務人員註冊日"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_pwd" HeaderText="業務人員密碼" Visible="False"></asp:BoundColumn>
										<asp:ButtonColumn Text="修改" ButtonType="PushButton" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
										<asp:ButtonColumn Text="刪除" ButtonType="PushButton" HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
									</Columns>
								</asp:DataGrid>
							</TD>
						</TR>
						<TR height="40">
							<TD align="left" width="100%">
								<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
								<asp:DropDownList id="ddlQueryField" runat="server">
									<asp:ListItem Value="srspn_cname" Selected="True">業務人員姓名</asp:ListItem>
									<asp:ListItem Value="srspn_empno">業務人員工號</asp:ListItem>
									<asp:ListItem Value="srspn_tel">業務人員電話</asp:ListItem>
								</asp:DropDownList>
								<asp:button id="Query" runat="server" Text="開始搜尋" Font-Size="9pt" Height="23px"></asp:button>
								<asp:button id="btnShowAll" runat="server" Text="全部顯示" Font-Size="9pt" Height="23px"></asp:button>
								&nbsp;&nbsp;&nbsp;
								<asp:button id="btnAddNew" runat="server" Text="新增資料" Font-Size="9pt" Height="23px"></asp:button>
							</TD>
						</TR>
						<TR height="40">
							<TD align="left" width="100%">
							<FONT size="2" color="#555555">備註： A-應用程式開發者，B-主要業務人員，C-次要業務人員，D–院外業務人員，E–訂戶人員，F-會計人員<br><font color=red>變更自己的權限後，關閉視窗重新登入系統。</font></FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			</FONT>
		</form>
		<!-- 頁尾 Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
