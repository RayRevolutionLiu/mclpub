<%@ Page language="c#" Src="refd2.aspx.cs" Codebehind="refd2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.refd2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>轉SAP傳票明細摘要檔資料維護</TITLE>
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
		<form id="refd" method="post" runat="server">
			<P>
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
						<TR>
							<TD align="left" width="100%" vAlign="top" height="22">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									共同檔案 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									轉 SAP 傳票摘要檔資料維護 <FONT color="dimgray">(
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
										<asp:BoundColumn Visible="False" DataField="rd_rdid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="sys_nm" HeaderText="系統代碼名稱"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_projno" HeaderText="計劃代號"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_costctr" HeaderText="成本中心"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_accdcr" HeaderText="傳票貸方總帳科目"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_descr" HeaderText="傳票摘要"></asp:BoundColumn>
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
									<asp:ListItem Value="rd_descr" Selected="True">傳票摘要</asp:ListItem>
									<asp:ListItem Value="sys_nm">系統代碼名稱</asp:ListItem>
									<asp:ListItem Value="rd_projno">計劃代號</asp:ListItem>
								</asp:DropDownList>
								<asp:button id="Query" runat="server" Text="開始搜尋" Font-Size="9pt" Height="23px"></asp:button>
								<asp:button id="btnShowAll" runat="server" Text="全部顯示" Font-Size="9pt" Height="23px"></asp:button>
								&nbsp;&nbsp;&nbsp;
								<asp:button id="btnAddNew" runat="server" Text="新增資料" Font-Size="9pt" Height="23px"></asp:button>
							</TD>
						</TR>
					</TABLE>
			</P>
			</FONT>
		</form>
	</body>
</HTML>
