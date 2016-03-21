﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RmLabelFilter.aspx.cs" Inherits="mclpub.LabelArea.RmLabelFilter" MasterPageFile="~/MasterPage.Master" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;標籤處理 / 雜誌叢書標籤處理 / 補書標籤列印</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">郵寄地區：</td>
    <td>
        <asp:DropDownList ID="ddlMosea" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlMosea_SelectedIndexChanged">
            <asp:ListItem Value="0">國內</asp:ListItem>
            <asp:ListItem Value="1">國外</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  </table>
</span> 
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="btnLabelPrint1" runat="server" Text="標籤列印" 
            onclick="btnLabelPrint1_Click" />
        <asp:Button ID="btnPrintOK" runat="server" Enabled="false" Text="列印正確" 
            onclick="btnPrintOK_Click" />
    </td>
  </tr>
</table>
<span class="stripeMe">
<asp:datalist id="DataList1" runat="server" GridLines="Horizontal" Width="100%" 
        CssClass="font_blacklink font_size13" 
        onitemdatabound="DataList1_ItemDataBound">
				<HeaderTemplate>
                <table width="100%">
						<tr>
							<th width="3%" align="left">
								<asp:CheckBox id="cbx1" runat="server" onclick="javascript:SelectAllCheckboxes(this)" ToolTip="按一次全選，再按一次取消全選"></asp:CheckBox>
							</th>
							<th width="15%">
								訂單編號
							</th>
							<th width="15%">
								序號
							</th>
							<th width="15%">
								收件人
							</th>
							<th width="27%">
								補書內容
							</th>
							<th width="15%">
								寄書狀態
							</th>
						</tr>
                </table>
				</HeaderTemplate>
				<ItemTemplate>
                <table width="100%">
						<tr>
							<td width="3%">
								<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
							</td>
							<td width="15%">
								<asp:Label id="lblNo" text='<%# DataBinder.Eval(Container.DataItem, "nostr")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblSeq" text='<%# DataBinder.Eval(Container.DataItem, "rm_seq")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblRecName" text='<%# DataBinder.Eval(Container.DataItem, "or_nm")%>' runat="server"></asp:Label>
							</td>
							<td width="27%">
								<asp:Label id="lblCont" text='<%# DataBinder.Eval(Container.DataItem, "rm_cont")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblFlagSent" text='<%# DataBinder.Eval(Container.DataItem, "rm_fgsent")%>' runat="server"></asp:Label>
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
