<%@ Page language="c#" Codebehind="IA1RecoveryQuery.aspx.cs" src="IA1RecoveryQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1RecoveryQuery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>單一廠商之發票開立單回復(Recovery):查詢條件</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IA1RecoveryQuery" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 90%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										單一廠商之發票開立單回復(Recovery):查詢條件</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">查詢條件</TD>
							</TR>
							<TR>
								<TD align="right" width="160">發票廠商名稱：</TD>
								<TD width="160"><asp:textbox id="tbxMfrNm" runat="server" Width="150px"></asp:textbox></TD>
								<TD class="ContAnnounce" rowSpan="3"><asp:label id="lblContHint" Runat="server" CssClass="ContAnnounce">
									1.請輸入任一關鍵詞來查詢，然後按下"查詢".<BR>
									2.查出資料後，選擇所需的發票開立單按下"確定"可進行發票開立單回復
									3.大批產生之發票開立單不會在此出現
									</asp:label></TD>
							</TR>
							<TR>
								<TD align="right">統一編號：</TD>
								<TD><asp:textbox id="tbxMfrNo" runat="server" Width="80px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 156px" align="right">發票收件人：</TD>
								<TD><asp:textbox id="tbxRecNm" runat="server" Width="100px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 156px" align="right">發票開立單編號：</TD>
								<TD><asp:textbox id="tbxIano" runat="server" Width="100px"></asp:textbox><asp:linkbutton id="lnbQuery" runat="server">查詢</asp:linkbutton></TD>
								<td><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
							</TR>
						</TABLE>
						<asp:datagrid id="dgdCont" runat="server" Width="90%" CssClass="DataGridStyle" AutoGenerateColumns="False" AllowPaging="True">
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="ia_iano" ReadOnly="True" HeaderText="發票開立單編號"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_contno" HeaderText="合約編號"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_mfrno" HeaderText="發票廠商統編"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="發票廠商名稱"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_pyat" HeaderText="發票金額"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_fgitri" HeaderText="往來註記"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_status" HeaderText="進行狀態"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_status" HeaderText="" Visible="False"></asp:BoundColumn>
								<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<!-- 頁首 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="確定")
				event.returnValue=confirm("確定要回復(Recovery)此筆發票資料?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
