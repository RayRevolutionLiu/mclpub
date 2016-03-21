<%@ Page language="c#" Codebehind="AdrFreeSlots.aspx.cs" Src="AdrFreeSlots.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrFreeSlots" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="AdrFreeSlots" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
				<TR>
					<TD colspan="2">
						<asp:RadioButtonList id="rblAdCate" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
							<asp:ListItem Value="M">����</asp:ListItem>
							<asp:ListItem Value="I">����</asp:ListItem>
							<asp:ListItem Value="N">�`��</asp:ListItem>
						</asp:RadioButtonList>
						<asp:Label id="Label1" runat="server" CssClass="NormalLabel">�s�i�Ѿl�Ŷ���</asp:Label>
						<asp:TextBox id="tbxAdMonth" runat="server" Width="10px" Visible="False"></asp:TextBox>
						<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="��������" name="btn_close">
					</TD>
					<td>
						<asp:LinkButton id="lnbPrevMonth" runat="server">�W�Ӥ�</asp:LinkButton>
					</td>
					<td>
						<asp:LinkButton id="lnbNextMonth" runat="server">�U�Ӥ�</asp:LinkButton>
					</td>
				</TR>
				<TR>
					<TD colspan="4">
						<asp:DataGrid id="dgdFreeSlots" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False" CellPadding="1">
							<AlternatingItemStyle HorizontalAlign="Center" CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cnt_date" HeaderText="���"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_h0" HeaderText="����">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_h1" HeaderText="�k�@">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_h2" HeaderText="�k�G">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_h3" HeaderText="�k�T">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_h4" HeaderText="�k�|">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_w1" HeaderText="�k��@">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_w2" HeaderText="�k��G">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_w3" HeaderText="�k��T">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_w4" HeaderText="�k��|">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_w5" HeaderText="�k�夭">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cnt_w6" HeaderText="�k�夻">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
