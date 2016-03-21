<%@ Page language="c#" Codebehind="AtpMatp.aspx.cs" Src="AtpMatp.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AtpMatp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="AtpMatp" method="post" runat="server">
			<TABLE class="TableColor" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>選擇類別：
						<asp:dropdownlist id="ddlClass1" runat="server">
							<asp:ListItem Value="1">材料特性</asp:ListItem>
							<asp:ListItem Value="2">應用產業</asp:ListItem>
						</asp:dropdownlist>
						<asp:button id="btnSave1" runat="server" Text="儲存"></asp:button>&nbsp;&nbsp; <INPUT onclick="javascript:window.close();" type="button" value="關閉" name="btnClose1">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="4"><asp:datalist id="dlClass21" runat="server" Width="100%">
							<ItemTemplate>
								<TABLE class="TableColor" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR class="TableColorHeader">
										<TD>
											<asp:Label id=lblClass21 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cname") %>'>
											</asp:Label>
											<asp:TextBox id=tbxClass21 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cls2id") %>' Width="10px" Visible="False">
											</asp:TextBox>
											<asp:LinkButton id="lnkSelectAll21" runat="server" ForeColor="Yellow" CommandName="select">全選</asp:LinkButton></TD>
									</TR>
									<TR>
										<TD>
											<asp:checkboxlist id="cblClass321" runat="server" Width="100%" DataValueField="cls3_cls3id" DataTextField="cls3_cname" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="CheckBoxListStyle"></asp:checkboxlist></TD>
									</TR>
								</TABLE>
							</ItemTemplate>
						</asp:datalist></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="4"><asp:datalist id="dlClass22" runat="server" Width="100%">
							<ItemTemplate>
								<TABLE class="TableColor" id="Table22" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR class="TableColorHeader">
										<TD>
											<asp:Label id=lblClass22 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cname") %>'>
											</asp:Label>
											<asp:TextBox id=tbxClass22 runat="server" Width="10px" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cls2id") %>' Visible="False">
											</asp:TextBox>
											<asp:LinkButton id="lnkSelectAll22" runat="server" ForeColor="Yellow" CommandName="select">全選</asp:LinkButton>
										</TD>
									</TR>
									<TR>
										<TD>
											<asp:checkboxlist id="cblClass322" runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="4" DataTextField="cls3_cname" DataValueField="cls3_cls3id" CssClass="CheckBoxListStyle"></asp:checkboxlist></TD>
									</TR>
								</TABLE>
							</ItemTemplate>
						</asp:datalist></TD>
				</TR>
			</TABLE>
			<asp:button id="btnSave" runat="server" Text="儲存"></asp:button>&nbsp;&nbsp; <INPUT onclick="javascript:window.close();" type="button" value="關閉" name="btnClose"><INPUT id="hidSelected" type="hidden" name="hidSelected" runat="server">
		</form>
	</body>
</HTML>
