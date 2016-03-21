<%@ Page language="c#" Codebehind="adprom_label2.aspx.cs" Src="adprom_label2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adprom_label2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告推廣戶標籤</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="adprom_label2" method="post" runat="server">
			<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="108pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="lblZip1" runat="server" Font-Bold="True" Font-Size="11">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="lblAddr1" runat="server" Width="300" Font-Bold="True" Font-Size="10">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblORName" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblORName1" runat="server" Font-Names="新細明體">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblContSEDate1" runat="server" Font-Names="新細明體">
							合約起迄：
								<%# DataBinder.Eval(Container.DataItem, "cont_sedate") %></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblPubCnt1" runat="server" Font-Names="新細明體">有登本數：<%# DataBinder.Eval(Container.DataItem, "or_pubcnt") %></asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblContNo1" runat="server" Font-Names="新細明體">
								合約編號： <%# DataBinder.Eval(Container.DataItem, "cont_contno") %>&nbsp;&nbsp;(
<asp:Label id="lblConttp1" runat="server" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "cont_conttpName") %>
						</asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %>
							</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblBookName1" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "bk_nm") %>
					</asp:Label>&nbsp;&nbsp;
					<BR>
					<asp:Label id=pagevalue1 runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'>
					</asp:Label><BR>
				</ItemTemplate>
			</asp:datalist>
		</form>
	</body>
</HTML>
