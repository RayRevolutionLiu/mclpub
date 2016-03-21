<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayFilter.aspx.cs" Inherits="mclpub.Pay.PayFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 繳款處理 / 新增繳款單</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">關鍵字查詢：</td>
    <td>
        <asp:TextBox ID="tbxKeyWord" runat="server"></asp:TextBox>
      </td>
      
  </tr>
  </table>
</span> 

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="Button1" runat="server" Text="查詢" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="下一步" onclick="Button2_Click" />
    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>請選擇欲付款之發票並點選下一步</li>
</ol>
</span>
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
								發票開立單編號
							</th>
							<th width="20%">
								統一編號
							</th>
							<th width="30%">
								公司名稱
							</th>
							<th width="15%">
								發票收件人
							</th>
							<th width="20%">
								含稅金額
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
								<asp:Label id="lblNo"  text='<%# DataBinder.Eval(Container.DataItem, "ia_refno")%>' runat="server"></asp:Label>
							</td>
							<td width="20%">
								<asp:Label id="lblMfrno"  text='<%# DataBinder.Eval(Container.DataItem, "ia_mfrno")%>' runat="server"></asp:Label>
							</td>
							<td width="30%">
								<asp:Label id="lblCompanyname"  text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblName"  text='<%# DataBinder.Eval(Container.DataItem, "ia_rnm")%>' runat="server"></asp:Label>
							</td>
							<td width="20%">
								<asp:Label id="lblAmt"  text='<%# DataBinder.Eval(Container.DataItem, "ia_pyat")%>' runat="server"></asp:Label>
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
