<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkOrder.aspx.cs" Inherits="mclpub.Order.BulkOrder"  MasterPageFile="~/MasterPage.Master"%>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂單管理 / 雜誌叢書訂單處理 / 贈戶訂單整批作業</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="110" class="font_bold">贈閱書籍：</td>
    <td>
        <asp:DropDownList ID="ddlBook" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="110" class="font_bold"><span class="stripeMe">贈閱期間：</span></td>
    <td>
        <asp:TextBox ID="tbxStartdate" runat="server" Width="78px" CssClass="UniqueDate"></asp:TextBox>
        ~<asp:TextBox ID="tbxEndDate" runat="server" Width="78px" CssClass="UniqueDate"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="110" class="font_bold"> 
        <span class="stripeMe">
        公司名稱：</span></td>
    <td>
        <asp:TextBox ID="tbxCompanyname" runat="server" Width="267px"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="110" class="font_bold">續訂到期日：</td>
    <td>
        <asp:TextBox ID="tbxContinueDate" runat="server" Width="78px" CssClass="UniqueDate"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" onclick="CheckBtn_Click"/>
    </td>
  </tr>
</table>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Button ID="btnOK" runat="server" Text="確定續訂" onclick="btnOK_Click" />
    </td>
</tr>
</table>

<span class="stripeMe">
<asp:datalist id="DataList1" runat="server" GridLines="Horizontal" Width="100%" 
        CssClass="font_blacklink font_size13" 
        onitemdatabound="DataList1_ItemDataBound">
				<HeaderTemplate>
						<tr>
							<th width="3%" align="left">
								<asp:CheckBox id="cbx1" runat="server" onclick="javascript:SelectAllCheckboxes(this)" ToolTip="按一次全選，再按一次取消全選"></asp:CheckBox>
							</th>
							<th width="15%">
								流水號
							</th>
							<th width="15%">
								訂戶編號
							</th>
							<th width="15%">
								訂戶姓名
							</th>
							<th width="27%">
								公司名稱
							</th>
							<th width="15%">
								聯絡電話
							</th>
							<th width="10%">
							</th>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
						<tr>
							<td width="3%">
								<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
							</td>
							<td width="15%">
								<asp:Label id="lblSeq" text='<%# DataBinder.Eval(Container.DataItem, "o_otp1seq")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblNo" text='<%# DataBinder.Eval(Container.DataItem, "o_custno")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblName" text='<%# DataBinder.Eval(Container.DataItem, "cust_nm")%>' runat="server"></asp:Label>
							</td>
							<td width="27%">
								<asp:Label id="lblCompanyname" text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' runat="server"></asp:Label>
							</td>
							<td width="15%">
								<asp:Label id="lblTel" text='<%# DataBinder.Eval(Container.DataItem, "cust_tel")%>' runat="server"></asp:Label>
							</td>
							<td width="10%">
								<input type="hidden" id="hiddenXml" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "o_xmldata")%>'/>
								<asp:HyperLink ID="HyperLink1" runat="server">詳細資料</asp:HyperLink>
							</td>
						</tr>
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

$(function() {
$(".UniqueDate").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天"
});
        });

</script>  
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