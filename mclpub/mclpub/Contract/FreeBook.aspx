<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreeBook.aspx.cs" Inherits="mclpub.Contract.FreeBook" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>材料所出版品客戶管理系統</title>
</head>
<body>
    <form id="form1" runat="server">
    <span class="stripeMe">
    			<asp:panel id="Panel1" runat="server">
				<asp:Label id="lblOldOr" runat="server">[歷史合約雜誌收件人資料]</asp:Label>
				<br />
                    <asp:GridView ID="dgdOldOr" runat="server" AutoGenerateColumns="False" CssClass="font_blacklink font_size13" Width="99%">
                    <Columns>
                    <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="LKdel" CommandArgument='<%# Eval("or_oritem")%>' Text="載入"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="or_oritem" HeaderText="序號" />
                    <asp:BoundField DataField="or_inm" HeaderText="廠商名稱" />
                    <asp:BoundField DataField="or_nm" HeaderText="收件人姓名" />
                    <asp:BoundField DataField="or_jbti" HeaderText="職稱" />
                    <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
                    <asp:BoundField DataField="or_addr" HeaderText="地址" />
                    <asp:BoundField DataField="or_tel" HeaderText="電話" />
                    <asp:BoundField DataField="or_fax" HeaderText="傳真" />
                    <asp:BoundField DataField="or_cell" HeaderText="手機" />
                    <asp:BoundField DataField="or_email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="國外">
                    <ItemTemplate>
                        <asp:Label id="lblOldOrfgMoSea" runat="server" Text='<%# GetYNCh(DataBinder.Eval(Container.DataItem, "or_fgmosea")) %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
				<br />
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="99%" border="0" class="font_blacklink font_size13">
					<TR>
						<th width="30">序號</th>
						<th width="130">公司名稱</th>
						<th width="64">姓名</th>
						<th width="36">稱謂</th>
						<th width="30">郵遞<br />
							區號</th>
						<th width="100">地址</th>
						<th width="54">電話</th>
						<th width="43">傳真</th>
						<th width="44">手機</th>
						<th width="86">Email</th>
						<th>國內外<br />
							註記</th>
					</TR>
					<TR>
						<td>
							<asp:textbox id="tbxOrSeq" runat="server" Width="90%" ReadOnly="True" BackColor="#E0E0E0"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrInm" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrNm" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrJbti" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrZip" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrAddr" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrTel" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrFax" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrCell" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:textbox id="tbxOrEmail" runat="server" Width="90%"></asp:textbox></td>
						<td>
							<asp:dropdownlist id="ddlOrMoSea" runat="server">
								<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
								<asp:ListItem Value="1">國外</asp:ListItem>
							</asp:dropdownlist></td>
					</TR>
				</TABLE>
				<asp:button id="btnAddOr" runat="server" CausesValidation="False" Text="新增收件人資料" 
                        onclick="btnAddOr_Click"></asp:button>
				<asp:Button id="btnUpdateOr" runat="server" CausesValidation="False" Text="修改收件人資料" 
                        onclick="btnUpdateOr_Click"></asp:Button>
				<asp:Button id="btnCancelOr" runat="server" CausesValidation="False" Text="取消修改" onclick="btnCancelOr_Click"></asp:Button>
				<br />
				<asp:Label id="lblOrMsg" runat="server"></asp:Label>
                    <asp:GridView ID="dgdNewOr" runat="server" AutoGenerateColumns="False" 
                        CssClass="font_blacklink font_size13" Width="99%" 
                        onrowdatabound="dgdNewOr_RowDataBound">
                    <Columns>
                    <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="修改" OnClick="lkedit_Click" CausesValidation="False"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="刪除" OnClick="lkdel_Click"  OnClientClick="return confirm('是否刪除')" CausesValidation="False"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="or_oritem" HeaderText="序號" />
                    <asp:BoundField DataField="or_inm" HeaderText="廠商名稱" />
                    <asp:BoundField DataField="or_nm" HeaderText="收件人姓名" />
                    <asp:BoundField DataField="or_jbti" HeaderText="職稱" />
                    <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
                    <asp:BoundField DataField="or_addr" HeaderText="地址" />
                    <asp:BoundField DataField="or_tel" HeaderText="電話" />
                    <asp:BoundField DataField="or_fax" HeaderText="傳真" />
                    <asp:BoundField DataField="or_cell" HeaderText="手機" />
                    <asp:BoundField DataField="or_email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="國外">
                    <ItemTemplate>
                        <asp:Label id="lblOldOrfgMoSea" runat="server" Text='<%# GetYNCh(DataBinder.Eval(Container.DataItem, "or_fgmosea")) %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="or_fgmosea" HeaderText="國外" />
                    </Columns>
                    </asp:GridView>
			</asp:panel>
			<hr width="100%" color="orange" SIZE="1">
			<asp:panel id="Panel2" runat="server">
            <asp:Label id="lblOldFreeBk" runat="server">[歷史合約贈書資料]</asp:Label><br />
                <asp:GridView ID="dgdOldFreeBk" runat="server" AutoGenerateColumns="False" CssClass="font_blacklink font_size13" Width="99%">
                <Columns>
                <asp:BoundField DataField="ma_sdate" HeaderText="贈書起月" />
                <asp:BoundField DataField="ma_edate" HeaderText="贈書迄月" />
                <asp:BoundField DataField="fc_nm" HeaderText="書籍" />
                <asp:BoundField DataField="or_nm" HeaderText="收件人" />
                <asp:BoundField DataField="ma_pubmnt" HeaderText="當月刊登份數" />
                <asp:BoundField DataField="ma_unpubmnt" HeaderText="未刊登份數" />
                <asp:TemplateField HeaderText="郵寄類別">
                    <ItemTemplate>
                        <asp:Label id="lblOldMtpNm" runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>			
				<br />
                <TABLE id="Table2" cellSpacing="0" cellPadding="0" width="99%" border="0" class="font_blacklink font_size13">
					<TR>
						<th width="73">贈書起月<br />
							<asp:Label id="lblyymm" runat="server">(yyyy/MM)</asp:Label></th>
						<th width="73"><FONT color="#ffffff" size="2">贈書迄月<br />
								<asp:Label id="lblyymm2" Runat="server">(yyyy/MM)</asp:Label></FONT></th>
						<th width="71">書籍</th>
						<th width="108">郵寄類別</th>
						<th width="73">刊登當月<br />
							份數</th>
						<th width="86">未刊登當月<br />
							份數</th>
						<th>收件人</th>
					</TR>
					<TR>
						<td width="73">
							<asp:textbox id="tbxMaSDate" runat="server" Width="63px"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvSDate" runat="server" ControlToValidate="tbxMaSDate" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revSDate" runat="server" ControlToValidate="tbxMaSDate" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></td>
						<td width="73">
							<asp:textbox id="tbxMaEDate" runat="server" Width="63px"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvEDate" runat="server" ControlToValidate="tbxMaEDate" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revEDate" runat="server" ControlToValidate="tbxMaEDate" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></td>
						<td width="71">
							<asp:dropdownlist id="ddlFbkBkCd" runat="server">
								<asp:ListItem Value="01" Selected="True">工材</asp:ListItem>
								<asp:ListItem Value="02">電材</asp:ListItem>
							</asp:dropdownlist></td>
						<td width="106">
							<asp:DropDownList id="ddlMtpCd" runat="server"></asp:DropDownList></td>
						<td width="73">
							<asp:TextBox id="tbxPubMnt" runat="server" Width="63px"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvPubMnt" runat="server" ControlToValidate="tbxPubMnt" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revPubMnt" runat="server" ControlToValidate="tbxPubMnt" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d+"></asp:RegularExpressionValidator></td>
						<td style="WIDTH: 86px">
							<asp:TextBox id="tbxUnPubMnt" runat="server" Width="63px"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvUnPubMnt" runat="server" ControlToValidate="tbxUnPubMnt" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="revUnPubMnt" runat="server" ControlToValidate="tbxUnPubMnt" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="\d+"></asp:RegularExpressionValidator></td>
						<td>
							<asp:DropDownList id="ddlOrSeq" runat="server"></asp:DropDownList></td>
					</TR>
				</TABLE>
                <asp:button id="btnAddFreeBk" runat="server" Text="新增贈書資料" 
                    onclick="btnAddFreeBk_Click"></asp:button>
                <asp:Button id="btnUpdateFreeBk" runat="server" CausesValidation="False" 
                    Text="修改贈書資料" onclick="btnUpdateFreeBk_Click"></asp:Button>
                <asp:Button id="btnCancelFreeBk" runat="server" CausesValidation="False" 
                    Text="取消修改" onclick="btnCancelFreeBk_Click"></asp:Button><br />
                <asp:Label id="lblFreeBkMsg" runat="server"></asp:Label><br />
                
                <asp:GridView ID="dgdNewFreeBk" runat="server" AutoGenerateColumns="False" CssClass="font_blacklink font_size13" Width="99%" OnRowDataBound="dgdNewFreeBk_RowDataBound">
                <Columns>
                <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="修改" OnClick="lkdgdNewFreeBkedit_Click" CausesValidation="False"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="刪除" OnClick="lkdgdNewFreeBkdel_Click"  OnClientClick="return confirm('是否刪除')" CausesValidation="False"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="fbk_fbkitem" HeaderText="贈書項次" />
                <asp:BoundField DataField="str_ma_sdate" HeaderText="贈書起月" />
                <asp:BoundField DataField="str_ma_edate" HeaderText="贈書迄月" />
                <asp:BoundField DataField="fbk_bkcd" HeaderText="書籍" />
                <asp:BoundField DataField="or_nm" HeaderText="收件人" />
                <asp:BoundField DataField="ma_pubmnt" HeaderText="當月刊登份數" />
                <asp:BoundField DataField="ma_unpubmnt" HeaderText="未刊登份數" />
                <asp:TemplateField HeaderText="郵寄類別">
                    <ItemTemplate>
                        <asp:Label id="lblMtpNm" runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="or_oritem" HeaderText="收件人" />
                </Columns>
                </asp:GridView>
				</asp:panel>
				
				<br />
			<INPUT onclick="refresh();" type="button" value="關閉" name="btnClose" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
			<asp:literal id="litAlert" runat="server"></asp:literal>
    </span>
    </form>
</body>
<script>
    function refresh() {
        if (window.opener) {
            window.opener.PushBtn();
        }
        window.close();
    }
</script>
</html>
