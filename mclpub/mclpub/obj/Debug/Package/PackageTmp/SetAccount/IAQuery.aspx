<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IAQuery.aspx.cs" Inherits="mclpub.SetAccount.IAQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 網路廣告發票處理 / 大批月結發票開立產生：查詢條件</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        截止播出日：</td>
    <td align="left">
        <asp:TextBox ID="tbxDate" runat="server" Width="80px" CssClass="UniqueDate"></asp:TextBox>
        <asp:Label ID="lblyyyymmdd" runat="server" ForeColor="#C04000">(yyyy/mm/dd)</asp:Label>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxDate"></asp:requiredfieldvalidator>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxDate" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}/\d{2}" Display="Dynamic"></asp:RegularExpressionValidator>
      </td>
  </tr>
  </table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
            <asp:label id="lblMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:label>   
        </td>
    <td align="right">
        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />
    </td>
  </tr>
</table>
<asp:panel id="pnlSelect" Runat="server" Visible="False">
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />目前可開立之落版明細
            </td>
            <td align="right">
                <asp:Button ID="btnNextStep" runat="server" Text="勾選好了,下一步" 
                    onclick="btnNextStep_Click" />
            </td>        
        </tr>
</table>
<span class="stripeMe">
<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
                 Font-Size="11px" 
        onrowdatabound="DataGrid1_RowDataBound" AllowSorting="true" OnSorting="GVEdit_Sorting">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript:SelectAllCheckboxes(this);"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>
            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server" /> 
            </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號"  ItemStyle-ForeColor="Blue"/>
            <asp:BoundField DataField="cont_sdate"     HeaderText="合約起日"/>
            <asp:BoundField DataField="cont_edate"      HeaderText="合約迄日"/>
            <asp:BoundField DataField="cont_mfrno"      HeaderText="廠商統編" />
            <asp:BoundField DataField="cont_mfr_inm"  HeaderText="合約廠商名稱" />
            <asp:BoundField DataField="srspn_cname"     HeaderText="業務員"  ItemStyle-ForeColor="Blue"/>
            <asp:BoundField DataField="adr_seq"   HeaderText="落版序號" />
            <asp:BoundField DataField="adr_addate"      HeaderText="播出日期▼" SortExpression="adr_addate" HeaderStyle-ForeColor="White"/>
            <asp:BoundField DataField="im_mfrno"      HeaderText="發票廠商統編" ItemStyle-ForeColor="Peru" />
            <asp:BoundField DataField="im_mfr_inm"      HeaderText="發票廠商名稱" ItemStyle-ForeColor="Peru" />
            <asp:BoundField DataField="adr_adcate"      HeaderText="廣告頁面" />
            <asp:BoundField DataField="adr_keyword"      HeaderText="廣告位置" />
            <asp:BoundField DataField="adr_impr"      HeaderText="播放機率" />
            <asp:BoundField DataField="adr_adamt"      HeaderText="廣告價格" />
            <asp:BoundField DataField="adr_desamt"      HeaderText="設計價格" />
            <asp:BoundField DataField="adr_chgamt"      HeaderText="換稿費用" />
            <asp:BoundField DataField="adr_invamt"      HeaderText="發票金額" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="adr_remark"      HeaderText="備註"/>
            <asp:BoundField DataField="im_fgitri"      HeaderText="往來註記" />
            <asp:BoundField DataField="proj_projno"      HeaderText="計劃代號" ItemStyle-ForeColor="Peru"/>
            <asp:BoundField DataField="adr_imseq"      HeaderText="adr_imseq"/>
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</span>
</asp:panel>


<asp:panel id="pnlConfirm" Runat="server" Visible="False">
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="Table1">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />已挑選之落版明細
            </td>
            <td align="right">
				<asp:Button id="btnPreStep" runat="server" Text="重新挑選,回上一步" 
                    onclick="btnPreStep_Click"></asp:Button>
				<asp:Button id="btnPrint" runat="server" Text="列印預覽清單" Visible="false" 
                    onclick="btnPrint_Click"></asp:Button>
				<asp:Button id="btnOK" runat="server" ForeColor="Red" Text="確定產生發票開立單" 
                    onclick="btnOK_Click"></asp:Button>
            </td>        
        </tr>
</table>
<span class="stripeMe">
<asp:GridView ID="GridView1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
                  PagerSettings-Visible="false" Font-Size="11px" 
        onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號"  ItemStyle-ForeColor="Blue"/>
            <asp:BoundField DataField="cont_sdate"     HeaderText="合約起日"/>
            <asp:BoundField DataField="cont_edate"      HeaderText="合約迄日"/>
            <asp:BoundField DataField="cont_mfrno"      HeaderText="廠商統編" />
            <asp:BoundField DataField="cont_mfr_inm"  HeaderText="合約廠商名稱" />
            <asp:BoundField DataField="srspn_cname"     HeaderText="業務員"  ItemStyle-ForeColor="Blue"/>
            <asp:BoundField DataField="adr_seq"   HeaderText="落版序號" />
            <asp:BoundField DataField="adr_addate"      HeaderText="播出日期" />
            <asp:BoundField DataField="im_mfrno"      HeaderText="發票廠商統編" ItemStyle-ForeColor="Peru" />
            <asp:BoundField DataField="im_mfr_inm"      HeaderText="發票廠商名稱" ItemStyle-ForeColor="Peru" />
            <asp:BoundField DataField="adr_adcate"      HeaderText="廣告頁面" />
            <asp:BoundField DataField="adr_keyword"      HeaderText="廣告位置" />
            <asp:BoundField DataField="adr_impr"      HeaderText="播放機率" />
            <asp:BoundField DataField="adr_adamt"      HeaderText="廣告價格" />
            <asp:BoundField DataField="adr_desamt"      HeaderText="設計價格" />
            <asp:BoundField DataField="adr_chgamt"      HeaderText="換稿費用" />
            <asp:BoundField DataField="adr_invamt"      HeaderText="發票金額" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="adr_remark"      HeaderText="備註"/>
            <asp:BoundField DataField="im_fgitri"      HeaderText="往來註記"/>
            <asp:BoundField DataField="proj_projno"      HeaderText="計劃代號" ItemStyle-ForeColor="Peru"/>
            <asp:BoundField DataField="adr_imseq"      HeaderText="adr_imseq"/>
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</span>
</asp:panel>
</asp:Content>
