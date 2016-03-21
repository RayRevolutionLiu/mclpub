<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateIa.aspx.cs" Inherits="mclpub.SetAccount.CreateIa" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 雜誌叢書發票處理 / 發票開立單產生</span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
                <asp:Button ID="btnCreateIa" runat="server" Text="產生發票資料" 
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
							<th width="20%">
								訂單編號
							</th>
							<th width="20%">
								訂購日期
							</th>
							<th width="15%">
								統一編號
							</th>
							<th width="20%">
								廠商名稱
							</th>
							<th width="25%">
								訂戶姓名
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
							<td width="20%">
								<asp:Label id="lblNo"  text='<%# DataBinder.Eval(Container.DataItem, "nostr")%>' runat="server"></asp:Label>
                                <input type="hidden" id="hiddenXML" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "o_xmldata")%>'>
							</td>
							<td width="20%">
								<asp:Label id="lblDate"  text='<%# DataBinder.Eval(Container.DataItem, "o_date")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblMfrno"  text='<%# DataBinder.Eval(Container.DataItem, "o_mfrno")%>' runat="server"></asp:Label>
							</td>
							<td width="20%">
								<asp:Label id="lblCompany"  text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' runat="server"></asp:Label>
							</td>
							<td width="25%">
								<asp:Label id="lblCustName"  text='<%# DataBinder.Eval(Container.DataItem, "cust_nm")%>' runat="server"></asp:Label>
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
