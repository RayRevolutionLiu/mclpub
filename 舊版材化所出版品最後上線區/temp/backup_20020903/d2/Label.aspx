<%@ Page language="c#" Codebehind="Label.aspx.cs" src="Label.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.Labeltest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Label" method="post" runat="server">
			<FONT face="�s�ө���">
				<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" BorderWidth="1px" ShowHeader="False" ShowFooter="False" GridLines="Both" Width="100%" CellPadding="5" RepeatDirection="Horizontal">
					<FooterTemplate>
						<asp:Label id="Label1" runat="server">Label</asp:Label>
					</FooterTemplate>
					<ItemStyle Font-Size="X-Small" Height="144pt" Width="50%"></ItemStyle>
					<ItemTemplate>
						<asp:Label id="Label5" runat="server">
							<%# DataBinder.Eval(Container.DataItem, "�l���ϸ�") %>
							&nbsp;&nbsp;
							<%# DataBinder.Eval(Container.DataItem, "�a�}") %>
						</asp:Label>
						<P>
							&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="Label2" runat="server" Font-Names="�s�ө���">
								<%# DataBinder.Eval(Container.DataItem, "���q�W��") %>
							</asp:Label>
							<BR>
							&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="Label1" runat="server" Font-Names="�s�ө���">
								<%# DataBinder.Eval(Container.DataItem, "�m�W") %>
							</asp:Label>
							<BR>
							&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="Label3" runat="server" Font-Names="�s�ө���">
								�q�\�_���G <%# DataBinder.Eval(Container.DataItem, "�q�\�_��") %>
								���ơG5
							</asp:Label>
							<BR>
							&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="Label6" runat="server" Font-Names="�s�ө���">
								�q��s���G <%# DataBinder.Eval(Container.DataItem, "�q��s��") %>
								�@��q��@�@�h��
							</asp:Label>
							<BR>
							&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="Label4" runat="server" Font-Names="�s�ө���">
								<%# DataBinder.Eval(Container.DataItem, "�ɮѤ��e") %>
							</asp:Label>
							<asp:Label id="pagevalue" runat="server">page</asp:Label>
						</P>
					</ItemTemplate>
				</asp:datalist>
			</FONT>
		</form>
	</body>
</HTML>
