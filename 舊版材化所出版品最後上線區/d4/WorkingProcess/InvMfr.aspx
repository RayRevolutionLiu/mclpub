<%@ Page language="c#" Codebehind="InvMfr.aspx.cs" src="InvMfr.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.InvMfr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdrInvoice</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="InvMfr" method="post" runat="server">
			<INPUT onclick="javascript:window.opener.document.forms(0).submit(); window.close();" type="button" value="����" name="btnClose1">
			<asp:panel id="pnlOldIm" runat="server" Width="100%">
				<asp:Label id="lblOldIm" runat="server" CssClass="NormalLabel">���v�X���o���t�Ӧ���H���</asp:Label>
				<BR>
				<asp:datagrid id="dgdOldInvMfr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="���J" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_addr" HeaderText="�a�}"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
						<asp:BoundColumn DataField="invcd" HeaderText="�o�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel>
			<TABLE class="TableColor" id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR class="TableColorHeader">
					<TD width="30">�Ǹ�</TD>
					<TD width="70">�t�Ӳνs</TD>
					<TD width="80">����H�m�W</TD>
					<TD width="60">¾��</TD>
					<TD width="160">�a�}</TD>
					<TD width="30">�l���ϸ�</TD>
					<TD width="80">�q��</TD>
					<TD width="80">�ǯu</TD>
					<TD width="80">���</TD>
					<TD width="160">EMAIL</TD>
					<TD>�o�����O</TD>
					<TD>�o���ҵ|�O</TD>
					<TD>�|�Ҥ����O</TD>
				</TR>
				<TR>
					<TD><asp:textbox id="tbxImSeq" runat="server" Width="100%" CssClass="ReadOnlyTextBox"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImMfrNo" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImNm" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImJbti" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImAddr" runat="server" Width="100%" Height="63px" TextMode="MultiLine"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImZip" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImTel" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImFax" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImCell" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:textbox id="tbxImEmail" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:dropdownlist id="ddlInvCd" Runat="server">
							<asp:ListItem Value="2" Selected="True">�G�p</asp:ListItem>
							<asp:ListItem Value="3">�T�p</asp:ListItem>
							<asp:ListItem Value="4">��L</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlTaxTp" Runat="server">
							<asp:ListItem Value="1" Selected="True">���|5%</asp:ListItem>
							<asp:ListItem Value="2">�s�|</asp:ListItem>
							<asp:ListItem Value="3">�K�|</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlFgItri" Runat="server">
							<asp:ListItem Value="" Selected="True">�@��</asp:ListItem>
							<asp:ListItem Value="06">�Ҥ�</asp:ListItem>
							<asp:ListItem Value="07">�|��</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="12"><asp:button id="btnAddIm" runat="server" Text="�s�W"></asp:button></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<asp:panel id="pnlNewIm" runat="server" Width="100%">
				<asp:Label id="lblNewIm" runat="server" CssClass="NormalLabel">���X���o���t�Ӧ���H���</asp:Label>
				<BR>
				<asp:datagrid id="dgdNewInvMfr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="im_imseq" ReadOnly="True" HeaderText="�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_addr" HeaderText="�a�}"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="�o�����O">
							<ItemTemplate>
								<asp:Label id=lblInvcd runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "invcd") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList id="DropDownList1" runat="server">
									<asp:ListItem Value="2">�G�p</asp:ListItem>
									<asp:ListItem Value="3">�T�p</asp:ListItem>
									<asp:ListItem Value="4">��L</asp:ListItem>
								</asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="�o���ҵ|�O">
							<ItemTemplate>
								<asp:Label id="lblTaxtp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "taxtp") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList id="ddlTaxtp" runat="server">
									<asp:ListItem Value="1">���|5%</asp:ListItem>
									<asp:ListItem Value="2">�s�|</asp:ListItem>
									<asp:ListItem Value="3">�K�|</asp:ListItem>
								</asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="�|�Ҥ����O">
							<ItemTemplate>
								<asp:Label id=lblItri runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "im_fgitri") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:dropdownlist id="ddlItri" Runat="server">
									<asp:ListItem Value="">�@��</asp:ListItem>
									<asp:ListItem Value="06">�Ҥ�</asp:ListItem>
									<asp:ListItem Value="07">�|��</asp:ListItem>
								</asp:dropdownlist>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="im_invcd" ReadOnly="True"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="im_taxtp" ReadOnly="True"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="im_fgitri" ReadOnly="True"></asp:BoundColumn>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="��s" CancelText="����" EditText="�ק�"></asp:EditCommandColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel><INPUT onclick="javascript:window.opener.document.forms(0).submit(); window.close();" type="button" value="����" name="btnClose">
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label></form>
	</body>
</HTML>
