<%@ Page language="c#" Codebehind="FreeBook.aspx.cs" Src="FreeBook.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.FreeBook" %>
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
		<form id="FreeBook" method="post" runat="server">
			<asp:panel id="Panel1" runat="server">
				<asp:Label id="lblOldOr" runat="server" CssClass="ImportantLabel">[歷史合約雜誌收件人資料]</asp:Label>
				<BR>
				<asp:datagrid id="dgdOldOr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="載入" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_inm" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="國外">
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
						<TD width="30">序號</TD>
						<TD width="80">公司名稱</TD>
						<TD width="64">姓名</TD>
						<TD width="36">稱謂</TD>
						<TD width="30">郵遞<BR>
							區號</TD>
						<TD width="150">地址</TD>
						<TD width="54">電話</TD>
						<TD width="43">傳真</TD>
						<TD width="44">手機</TD>
						<TD width="86">Email</TD>
						<TD>國內外<BR>
							註記</TD>
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
								<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
								<asp:ListItem Value="1">國外</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
				</TABLE>
				<asp:button id="btnAddOr" runat="server" CausesValidation="False" Text="新增收件人資料"></asp:button>
				<asp:Button id="btnUpdateOr" runat="server" CausesValidation="False" Text="修改收件人資料"></asp:Button>
				<asp:Button id="btnCancelOr" runat="server" CausesValidation="False" Text="取消修改"></asp:Button>
				<BR>
				<asp:Label id="lblOrMsg" runat="server" CssClass="ImportantLabel"></asp:Label>
				<asp:datagrid id="dgdNewOr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="修改" CommandName="Select"></asp:ButtonColumn>
						<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_inm" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="國外">
							<ItemTemplate>
								<asp:Label id="Label1" runat="server" Font-Size="X-Small" Text='<%# GetYNCh(DataBinder.Eval(Container.DataItem, "or_fgmosea")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="or_fgmosea" HeaderText="國外"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel>
			<hr width="100%" color="orange" SIZE="1">
			<asp:panel id="Panel2" runat="server">
<asp:Label id="lblOldFreeBk" runat="server" CssClass="ImportantLabel">[歷史合約贈書資料]</asp:Label><BR>
<asp:datagrid id="dgdOldFreeBk" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="贈書項次"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_sdate" HeaderText="贈書起月"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_edate" HeaderText="贈書迄月"></asp:BoundColumn>
						<asp:BoundColumn DataField="fc_nm" HeaderText="書籍"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="郵寄類別">
							<ItemTemplate>
								<asp:Label id="lblOldMtpNm" runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid><BR>
<TABLE class="TableColor" id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR class="TableColorHeader">
						<TD width="73">贈書起月<BR>
							<asp:Label id="lblyymm" CssClass="ImportantLabel" Runat="server">(yyyy/MM)</asp:Label></TD>
						<TD width="73"><FONT color="#ffffff" size="2">贈書迄月<BR>
								<asp:Label id="lblyymm2" CssClass="ImportantLabel" Runat="server">(yyyy/MM)</asp:Label></FONT></TD>
						<TD width="71">書籍</TD>
						<TD width="108">郵寄類別</TD>
						<TD width="73">刊登當月<BR>
							份數</TD>
						<TD width="86">未刊登當月<BR>
							份數</TD>
						<TD>收件人</TD>
					</TR>
					<TR>
						<TD width="73">
							<asp:textbox id="tbxMaSDate" runat="server" Width="63px"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvSDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaSDate" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revSDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaSDate" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></TD>
						<TD width="73">
							<asp:textbox id="tbxMaEDate" runat="server" Width="63px"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvEDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaEDate" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revEDate" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxMaEDate" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></TD>
						<TD width="71">
							<asp:dropdownlist id="ddlFbkBkCd" runat="server">
								<asp:ListItem Value="01" Selected="True">工材</asp:ListItem>
								<asp:ListItem Value="02">電材</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD width="106">
							<asp:DropDownList id="ddlMtpCd" runat="server"></asp:DropDownList></TD>
						<TD width="73">
							<asp:TextBox id="tbxPubMnt" runat="server" Width="63px"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxPubMnt" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxPubMnt" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
						<TD style="WIDTH: 86px">
							<asp:TextBox id="tbxUnPubMnt" runat="server" Width="63px"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvUnPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxUnPubMnt" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revUnPubMnt" runat="server" CssClass="ValidatorStyle" ControlToValidate="tbxUnPubMnt" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
						<TD>
							<asp:DropDownList id="ddlOrSeq" runat="server"></asp:DropDownList></TD>
					</TR>
				</TABLE>
<asp:button id="btnAddFreeBk" runat="server" Text="新增贈書資料"></asp:button>
<asp:Button id="btnUpdateFreeBk" runat="server" CausesValidation="False" Text="修改贈書資料"></asp:Button>
<asp:Button id="btnCancelFreeBk" runat="server" CausesValidation="False" Text="取消修改"></asp:Button><BR>
<asp:Label id="lblFreeBkMsg" runat="server" CssClass="ImportantLabel"></asp:Label><BR>
<asp:DataGrid id="dgdNewFreeBk" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="修改" CommandName="Select"></asp:ButtonColumn>
						<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="贈書項次"></asp:BoundColumn>
						<asp:BoundColumn DataField="str_ma_sdate" HeaderText="贈書起月"></asp:BoundColumn>
						<asp:BoundColumn DataField="str_ma_edate" HeaderText="贈書迄月"></asp:BoundColumn>
						<asp:BoundColumn DataField="fbk_bkcd" HeaderText="書籍"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
						<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="郵寄類別">
							<ItemTemplate>
								<asp:Label id=lblMtpNm runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
					</Columns>
					<PagerStyle CssClass="PagerStyle"></PagerStyle>
				</asp:DataGrid></FONT></asp:panel><BR>
			<INPUT onclick="javascript:window.opener.document.forms(0).submit(); window.close();" type="button" value="關閉" name="btnClose">
			<asp:literal id="litAlert" runat="server"></asp:literal></FONT></form>
	</body>
</HTML>
