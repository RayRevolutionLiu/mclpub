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
			<INPUT onclick="javascript:window.opener.document.forms(0).submit(); window.close();" type="button" value="關閉" name="btnClose1">
			<asp:panel id="pnlOldIm" runat="server" Width="100%">
				<asp:Label id="lblOldIm" runat="server" CssClass="NormalLabel">歷史合約發票廠商收件人資料</asp:Label>
				<BR>
				<asp:datagrid id="dgdOldInvMfr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="載入" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_jbti" HeaderText="稱謂"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
						<asp:BoundColumn DataField="invcd" HeaderText="發票類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel>
			<TABLE class="TableColor" id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR class="TableColorHeader">
					<TD width="30">序號</TD>
					<TD width="70">廠商統編</TD>
					<TD width="80">收件人姓名</TD>
					<TD width="60">職稱</TD>
					<TD width="160">地址</TD>
					<TD width="30">郵遞區號</TD>
					<TD width="80">電話</TD>
					<TD width="80">傳真</TD>
					<TD width="80">手機</TD>
					<TD width="160">EMAIL</TD>
					<TD>發票類別</TD>
					<TD>發票課稅別</TD>
					<TD>院所內註記</TD>
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
							<asp:ListItem Value="2" Selected="True">二聯</asp:ListItem>
							<asp:ListItem Value="3">三聯</asp:ListItem>
							<asp:ListItem Value="4">其他</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlTaxTp" Runat="server">
							<asp:ListItem Value="1" Selected="True">應稅5%</asp:ListItem>
							<asp:ListItem Value="2">零稅</asp:ListItem>
							<asp:ListItem Value="3">免稅</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlFgItri" Runat="server">
							<asp:ListItem Value="" Selected="True">一般</asp:ListItem>
							<asp:ListItem Value="06">所內</asp:ListItem>
							<asp:ListItem Value="07">院內</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="12"><asp:button id="btnAddIm" runat="server" Text="新增"></asp:button></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<asp:panel id="pnlNewIm" runat="server" Width="100%">
				<asp:Label id="lblNewIm" runat="server" CssClass="NormalLabel">本合約發票廠商收件人資料</asp:Label>
				<BR>
				<asp:datagrid id="dgdNewInvMfr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="im_imseq" ReadOnly="True" HeaderText="序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_jbti" HeaderText="稱謂"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="發票類別">
							<ItemTemplate>
								<asp:Label id=lblInvcd runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "invcd") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList id="DropDownList1" runat="server">
									<asp:ListItem Value="2">二聯</asp:ListItem>
									<asp:ListItem Value="3">三聯</asp:ListItem>
									<asp:ListItem Value="4">其他</asp:ListItem>
								</asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="發票課稅別">
							<ItemTemplate>
								<asp:Label id="lblTaxtp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "taxtp") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList id="ddlTaxtp" runat="server">
									<asp:ListItem Value="1">應稅5%</asp:ListItem>
									<asp:ListItem Value="2">零稅</asp:ListItem>
									<asp:ListItem Value="3">免稅</asp:ListItem>
								</asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="院所內註記">
							<ItemTemplate>
								<asp:Label id=lblItri runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "im_fgitri") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:dropdownlist id="ddlItri" Runat="server">
									<asp:ListItem Value="">一般</asp:ListItem>
									<asp:ListItem Value="06">所內</asp:ListItem>
									<asp:ListItem Value="07">院內</asp:ListItem>
								</asp:dropdownlist>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="im_invcd" ReadOnly="True"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="im_taxtp" ReadOnly="True"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="im_fgitri" ReadOnly="True"></asp:BoundColumn>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel><INPUT onclick="javascript:window.opener.document.forms(0).submit(); window.close();" type="button" value="關閉" name="btnClose">
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label></form>
	</body>
</HTML>
