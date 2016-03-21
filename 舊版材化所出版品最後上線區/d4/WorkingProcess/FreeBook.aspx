<%@ Page language="c#" Codebehind="FreeBook.aspx.cs" Src="FreeBook.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.FreeBook" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="FreeBook" method="post" runat="server">
			<asp:panel id="Panel1" runat="server">
				<asp:Label id="lblOldOr" runat="server" CssClass="ImportantLabel">[���v�X�����x����H���]</asp:Label>
				<BR>
				<asp:datagrid id="dgdOldOr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="���J" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_inm" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="��~">
							<ItemTemplate>
								<asp:Label id=lblOldOrfgMoSea runat="server" Text='<%# GetYNCh(DataBinder.Eval(Container.DataItem, "or_fgmosea")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid>
				<BR>
				<TABLE class="TableColor" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR class="TableColorHeader">
						<TD width="30">�Ǹ�</TD>
						<TD width="80">���q�W��</TD>
						<TD width="64">�m�W</TD>
						<TD width="36">�ٿ�</TD>
						<TD width="30">�l��<BR>
							�ϸ�</TD>
						<TD width="150">�a�}</TD>
						<TD width="54">�q��</TD>
						<TD width="43">�ǯu</TD>
						<TD width="44">���</TD>
						<TD width="86">Email</TD>
						<TD>�ꤺ�~<BR>
							���O</TD>
					</TR>
					<TR>
						<TD>
							<asp:textbox id="tbxOrSeq" runat="server" Width="30px" ReadOnly="True" BackColor="#E0E0E0"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrInm" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrNm" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrJbti" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrZip" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrAddr" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrTel" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrFax" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrCell" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:textbox id="tbxOrEmail" runat="server" Width="100%"></asp:textbox></TD>
						<TD>
							<asp:dropdownlist id="ddlOrMoSea" runat="server">
								<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
								<asp:ListItem Value="1">��~</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
				</TABLE>
				<asp:button id="btnAddOr" runat="server" CausesValidation="False" Text="�s�W����H���"></asp:button>
				<asp:Button id="btnUpdateOr" runat="server" CausesValidation="False" Text="�ק怜��H���"></asp:Button>
				<asp:Button id="btnCancelOr" runat="server" CausesValidation="False" Text="�����ק�"></asp:Button>
				<BR>
				<asp:Label id="lblOrMsg" runat="server" CssClass="ImportantLabel"></asp:Label>
				<asp:datagrid id="dgdNewOr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
						<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_inm" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="��~">
							<ItemTemplate>
								<asp:Label id="Label1" runat="server" Font-Size="X-Small" Text='<%# GetYNCh(DataBinder.Eval(Container.DataItem, "or_fgmosea")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="or_fgmosea" HeaderText="��~"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel>
			<hr width="100%" color="orange" SIZE="1">
			<asp:panel id="Panel2" runat="server">
<asp:Label id="lblOldFreeBk" runat="server" CssClass="ImportantLabel">[���v�X���خѸ��]</asp:Label><BR>
<asp:datagrid id="dgdOldFreeBk" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_edate" HeaderText="�خѨ���"></asp:BoundColumn>
						<asp:BoundColumn DataField="fc_nm" HeaderText="���y"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="�l�H���O">
							<ItemTemplate>
								<asp:Label id="lblOldMtpNm" runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid><BR>
<TABLE class="TableColor" id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR class="TableColorHeader">
						<TD width="73">�خѰ_��<BR>
							<asp:Label id="lblyymm" CssClass="ImportantLabel" Runat="server">(yyyy/MM)</asp:Label></TD>
						<TD width="73"><FONT color="#ffffff" size="2">�خѨ���<BR>
								<asp:Label id="lblyymm2" CssClass="ImportantLabel" Runat="server">(yyyy/MM)</asp:Label></FONT></TD>
						<TD width="71">���y</TD>
						<TD width="108">�l�H���O</TD>
						<TD width="73">�Z�n���<BR>
							����</TD>
						<TD width="86">���Z�n���<BR>
							����</TD>
						<TD>����H</TD>
					</TR>
					<TR>
						<TD width="73">
							<asp:textbox id="tbxMaSDate" runat="server" Width="63px"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvSDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaSDate" Display="Dynamic" ErrorMessage="���i�ť�"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revSDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaSDate" Display="Dynamic" ErrorMessage="�榡���~" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></TD>
						<TD width="73">
							<asp:textbox id="tbxMaEDate" runat="server" Width="63px"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvEDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaEDate" Display="Dynamic" ErrorMessage="���i�ť�"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revEDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaEDate" Display="Dynamic" ErrorMessage="�榡���~" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></TD>
						<TD width="71">
							<asp:dropdownlist id="ddlFbkBkCd" runat="server">
								<asp:ListItem Value="01" Selected="True">�u��</asp:ListItem>
								<asp:ListItem Value="02">�q��</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD width="106">
							<asp:DropDownList id="ddlMtpCd" runat="server"></asp:DropDownList></TD>
						<TD width="73">
							<asp:TextBox id="tbxPubMnt" runat="server" Width="63px"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxPubMnt" Display="Dynamic" ErrorMessage="���i�ť�"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxPubMnt" Display="Dynamic" ErrorMessage="�榡���~" ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
						<TD style="WIDTH: 86px">
							<asp:TextBox id="tbxUnPubMnt" runat="server" Width="63px"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvUnPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxUnPubMnt" Display="Dynamic" ErrorMessage="���i�ť�"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revUnPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxUnPubMnt" Display="Dynamic" ErrorMessage="�榡���~" ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
						<TD>
							<asp:DropDownList id="ddlOrSeq" runat="server"></asp:DropDownList></TD>
					</TR>
				</TABLE>
<asp:button id="btnAddFreeBk" runat="server" Text="�s�W�خѸ��"></asp:button>
<asp:Button id="btnUpdateFreeBk" runat="server" CausesValidation="False" Text="�ק��خѸ��"></asp:Button>
<asp:Button id="btnCancelFreeBk" runat="server" CausesValidation="False" Text="�����ק�"></asp:Button><BR>
<asp:Label id="lblFreeBkMsg" runat="server" CssClass="ImportantLabel"></asp:Label><BR>
<asp:DataGrid id="dgdNewFreeBk" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
						<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
						<asp:BoundColumn DataField="str_ma_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="str_ma_edate" HeaderText="�خѨ���"></asp:BoundColumn>
						<asp:BoundColumn DataField="fbk_bkcd" HeaderText="���y"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="�l�H���O">
							<ItemTemplate>
								<asp:Label id=lblMtpNm runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
					</Columns>
					<PagerStyle CssClass="PagerStyle"></PagerStyle>
				</asp:DataGrid></FONT></asp:panel><BR>
			<INPUT onclick="javascript:window.opener.document.forms(0).submit(); window.close();" type="button" value="����" name="btnClose">
			<asp:literal id="litAlert" runat="server"></asp:literal></FONT></form>
	</body>
</HTML>
