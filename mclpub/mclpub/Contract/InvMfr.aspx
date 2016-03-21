<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvMfr.aspx.cs" Inherits="mclpub.Contract.InvMfr" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AdrInvoice</title>
</head>
<body>
    <form id="form1" runat="server">
    <span class="stripeMe">
    			&nbsp;<asp:panel id="pnlOldIm" runat="server" Width="100%">
				<asp:Label id="lblOldIm" runat="server">歷史合約發票廠商收件人資料</asp:Label>
				<br />
                <asp:GridView ID="dgdOldInvMfr" runat="server" AutoGenerateColumns="False" 
                    Width="99%" CssClass="font_blacklink font_size13" 
                    onrowdatabound="dgdOldInvMfr_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="載入" OnClick="onLoad_click"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="im_imseq" HeaderText="序號" />
                <asp:BoundField DataField="im_mfrno" HeaderText="廠商統編" />
                <asp:BoundField DataField="im_nm" HeaderText="收件人姓名" />
                <asp:BoundField DataField="im_jbti" HeaderText="稱謂" />
                <asp:BoundField DataField="im_addr" HeaderText="地址" />
                <asp:BoundField DataField="im_zip" HeaderText="郵遞區號" />
                <asp:BoundField DataField="im_tel" HeaderText="電話" />
                <asp:BoundField DataField="im_fax" HeaderText="傳真" />
                <asp:BoundField DataField="im_cell" HeaderText="手機" />
                <asp:BoundField DataField="im_email" HeaderText="Email" />
                <asp:BoundField DataField="invcd" HeaderText="發票類別" />
                <asp:BoundField DataField="taxtp" HeaderText="發票課稅別" />
                <asp:BoundField DataField="im_fgitri" HeaderText="院所內註記" />
                </Columns>
                </asp:GridView>
				<br />
			</asp:panel>
			<table id="table2" cellSpacing="0" cellPadding="0" width="99%" border="0" class="font_blacklink font_size13">
				<tr>
					<th width="30">序號</th>
					<th width="70">廠商統編</th>
					<th width="80">收件人姓名</th>
					<th width="60">職稱</th>
					<th width="160">地址</th>
					<th width="30">郵遞區號</th>
					<th width="80">電話</th>
					<th width="80">傳真</th>
					<th width="80">手機</th>
					<th width="160">EMAIL</th>
					<th>發票類別</th>
					<th>發票課稅別</th>
					<th>院所內註記</th>
				</tr>
				<tr>
					<td><asp:textbox id="tbxImSeq" runat="server" Width="90%" Enabled="false"></asp:textbox></td>
					<td><asp:textbox id="tbxImMfrNo" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:textbox id="tbxImNm" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:textbox id="tbxImJbti" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:textbox id="tbxImAddr" runat="server" Width="90%" Height="63px" TextMode="MultiLine"></asp:textbox></td>
					<td><asp:textbox id="tbxImZip" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:textbox id="tbxImTel" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:textbox id="tbxImFax" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:textbox id="tbxImCell" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:textbox id="tbxImEmail" runat="server" Width="90%"></asp:textbox></td>
					<td><asp:dropdownlist id="ddlInvCd" Runat="server">
							<asp:ListItem Value="2" Selected="true">二聯</asp:ListItem>
							<asp:ListItem Value="3">三聯</asp:ListItem>
							<asp:ListItem Value="4">其他</asp:ListItem>
						</asp:dropdownlist></td>
					<td><asp:dropdownlist id="ddlTaxTp" Runat="server">
							<asp:ListItem Value="1" Selected="true">應稅5%</asp:ListItem>
							<asp:ListItem Value="2">零稅</asp:ListItem>
							<asp:ListItem Value="3">免稅</asp:ListItem>
						</asp:dropdownlist></td>
					<td><asp:dropdownlist id="ddlFgItri" Runat="server">
							<asp:ListItem Value="" Selected="true">一般</asp:ListItem>
							<asp:ListItem Value="06">所內</asp:ListItem>
							<asp:ListItem Value="07">院內</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
			</table>
			<asp:button id="btnAddIm" runat="server" Text="新增" 
                    onclick="btnAddIm_Click"></asp:button>
            <asp:Button id="btnUpdateFreeBk" runat="server" CausesValidation="False" 
                    Text="修改收件人資料" onclick="btnUpdateFreeBk_Click"></asp:Button>
            <asp:Button id="btnCancelFreeBk" runat="server" CausesValidation="False" 
                    Text="取消修改" onclick="btnCancelFreeBk_Click"></asp:Button><br />
			<asp:panel id="pnlNewIm" runat="server" Width="100%">
				<asp:Label id="lblNewIm" runat="server" >本合約發票廠商收件人資料</asp:Label>
				<br />
                <asp:GridView ID="dgdNewInvMfr" runat="server" AutoGenerateColumns="False" Width="99%" CssClass="font_blacklink font_size13">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server"  Text="刪除" OnClick="Del_click" OnClientClick="return confirm('是否刪除')"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="im_imseq" HeaderText="序號" />
                <asp:BoundField DataField="im_mfrno" HeaderText="廠商統編" />
                <asp:BoundField DataField="im_nm" HeaderText="收件人姓名" />
                <asp:BoundField DataField="im_jbti" HeaderText="稱謂" />
                <asp:BoundField DataField="im_addr" HeaderText="地址" />
                <asp:BoundField DataField="im_zip" HeaderText="郵遞區號" />
                <asp:BoundField DataField="im_tel" HeaderText="電話" />
                <asp:BoundField DataField="im_fax" HeaderText="傳真" />
                <asp:BoundField DataField="im_cell" HeaderText="手機" />
                <asp:BoundField DataField="im_email" HeaderText="Email" />
                <asp:BoundField DataField="invcd" HeaderText="發票類別" />
                <asp:BoundField DataField="taxtp" HeaderText="發票課稅別" />
                <asp:BoundField DataField="imfgitri" HeaderText="院所內註記" />
                    <asp:TemplateField HeaderStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" Text="修改" OnClick="edit_Click"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
			</asp:panel>
			<INPUT onclick="refresh();" type="button" value="關閉" name="btnClose" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
	</span>
	</form>
	
<script>
    function refresh() {
        if (window.opener) {
            window.opener.PushBtn();
        }
        window.close();
    }
</script>
</html>
