<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecoveryIa.aspx.cs" Inherits="mclpub.SetAccount.RecoveryIa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 雜誌叢書發票處理 / 發票開立單回復(刪除)</span>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>此表列示之發票開立單是尚未產生發票開立清單且尚未繳款之資料, 
已產生發票開立清單或已繳款之發票資料不會在此列示</li>
    <li><span class="font_darkblue">發票類別</span>---2:二聯 3:三聯 4:其他
<span class="font_darkblue">課稅別</span>---1:應稅 2:零稅 3:免稅</li>
</ol>
</span>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
                <asp:Button ID="btnCreateIa" runat="server" Text="刪除發票開立單"  OnClientClick="javascript:return confirm('此動作將會刪除所選的發票開立單及明細, 確定要刪除此筆發票開立單?');"
                    onclick="btnCreateIa_Click" />
            </td>
            
        </tr>
    </table>
<span class="stripeMe">
<asp:datalist id="DataList1" runat="server" GridLines="Horizontal" Width="100%" 
        CssClass="font_blacklink font_size13" OnItemDataBound="DataList1_ItemDataBound">
				<HeaderTemplate>
                <table width="100%">
						<tr>
							<th width="3%" align="left">
								<asp:CheckBox id="cbx1" runat="server" onclick="javascript:SelectAllCheckboxes(this)" ToolTip="按一次全選，再按一次取消全選"></asp:CheckBox>
							</th>
							<th width="15%">
								發票開立單編號
							</th>
							<th width="10%">
								統一編號
							</th>
							<th width="13%">
								發票收件人
							</th>
							<th width="10%">
								職稱
							</th>
							<th width="10%">
								發票郵寄地址
							</th>
                            <th width="10%">
								郵遞區號
							</th>
                            <th width="9%">
								電話
							</th>
                            <th width="7%">
								發票類別
							</th>
                            <th width="7%">
								課稅別
							</th>
                            <th width="7%">
								狀態
							</th>
						</tr>
                </table>
				</HeaderTemplate>
				<ItemTemplate>
                <table width="100%">
						<tr>
							<td width="3%" align="left">
								<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
							</td>
							<td width="15%">
								<asp:Label id="lblNo"  text='<%# DataBinder.Eval(Container.DataItem, "ia_iano")%>' runat="server"></asp:Label>
							</td>
							<td width="10%">
								<asp:Label id="lblMfrno"  text='<%# DataBinder.Eval(Container.DataItem, "ia_mfrno")%>' runat="server"></asp:Label>
							</td>
							<td width="13%">
								<asp:Label id="lblName"  text='<%# DataBinder.Eval(Container.DataItem, "ia_rnm")%>' runat="server"></asp:Label>
							</td>
							<td width="10%">
								<asp:Label id="lblJob"  text='<%# DataBinder.Eval(Container.DataItem, "ia_rjbti")%>' runat="server"></asp:Label>
							</td>
							<td width="10%">
								<asp:Label id="lblAddr"  text='<%# DataBinder.Eval(Container.DataItem, "ia_raddr")%>' runat="server"></asp:Label>
							</td>
                            <td width="10%">
								<asp:Label id="lblZip"  text='<%# DataBinder.Eval(Container.DataItem, "ia_rzip")%>' runat="server"></asp:Label>
							</td>
                            <td width="9%">
								<asp:Label id="lblTel"  text='<%# DataBinder.Eval(Container.DataItem, "ia_rtel")%>' runat="server"></asp:Label>
							</td>
                            <td width="7%">
								<asp:Label id="lblInvcd"  text='<%# DataBinder.Eval(Container.DataItem, "ia_invcd")%>' runat="server"></asp:Label>
							</td>
                            <td width="7%">
								<asp:Label id="lblTaxtp"  text='<%# DataBinder.Eval(Container.DataItem, "ia_taxtp")%>' runat="server"></asp:Label>
							</td>
                            <td width="7%">
								<asp:Label id="lblStatus"  text='<%# DataBinder.Eval(Container.DataItem, "o_status")%>' runat="server"></asp:Label>
							</td>
						</tr>
                </table>
				</ItemTemplate>
				<FooterTemplate>
                    <asp:Panel ID="Panel_Noting" runat="server" Visible="false">
						<tr>
							<td width="100%" colspan="7" align="center">
								查詢無資料
							</td>
						</tr>
                    </asp:Panel>
				</FooterTemplate>
			</asp:datalist>
</span>
<script>
    function SelectAllCheckboxes(spanChk) {
        elm = document.forms[0];
        for (i = 0; i <= elm.length - 1; i++) {
            if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                if (elm.elements[i].checked != spanChk.checked)
                    elm.elements[i].click();
            }
        }
    } 
</script>

</asp:Content>
