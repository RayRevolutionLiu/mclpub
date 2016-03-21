<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IA1QueryCont.aspx.cs" Inherits="mclpub.SetAccount.IA1QueryCont" %>
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
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 網路廣告發票處理 / 單一合約發票開立：挑選開立發票項目</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" /><asp:label id="lblContInfo" runat="server" >合約基本資料</asp:label>
            </td>
            <td align="right">
                &nbsp;</td>
            
        </tr>
</table>
<span class="stripeMe">
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th class="font_size12">合約編號</th>
    <th class="font_size12">合約類別</th>
    <th class="font_size12">簽約日期</th>
    <th class="font_size12">合約起迄</th>
    <th class="font_size12">刊登次數</th>
    <th class="font_size12">贈送次數</th>
    <th class="font_size12">合約金額</th>
    <th class="font_size12">優惠折數</th>
    <th class="font_size12">總製圖檔稿次數</th>
    <th class="font_size12">總製網頁稿次數</th>
  </tr>
  <tr>
    <td>

        <asp:Label ID="lblContNo" runat="server" CssClass="font_size12" ></asp:Label>

    </td>
    <td>
        <asp:Label ID="lblContTp" runat="server" CssClass="font_size12" ></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblSignDate" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td style="width:190px">
        <asp:Label ID="lblSDate" runat="server" CssClass="font_size12" ></asp:Label>～
        <asp:Label ID="lblEDate" runat="server" CssClass="font_size12" ></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblPubTm" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblFreeTm" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblTotAmt" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblDisc" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblTotImgTm" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblTotUrlTm" runat="server" CssClass="font_size12"></asp:Label>
    </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="Table1">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" /><asp:label id="lblAdrInfo" runat="server">本合約廣告資料</asp:label>
            </td>
            <td align="right">
                &nbsp;</td>
            
        </tr>
</table>
<span class="stripeMe">
<asp:panel id="pnlAdr" Width="100%" Runat="server">
											<asp:Panel id="pnlOptions" Runat="server" Width="100%">
												<asp:Label id="lblSelectInvMfr" Runat="server" ForeColor="Red">發票廠商：</asp:Label>
												<asp:DropDownList id="ddlInvMfr" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="ddlInvMfr_SelectedIndexChanged"></asp:DropDownList>
												<asp:Button ID="btnConfirmSelected" runat="server" Text="確認已勾選的廣告項目" 
                                                    onclick="btnConfirmSelected_Click" />
											</asp:Panel>
<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True"
                  PagerSettings-Visible="false"
        onrowdatabound="DataGrid1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript:SelectAllCheckboxes(this);"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>
            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server" Enabled="false"/> 
            </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="adr_seq"  HeaderText="序號"/>
            <asp:BoundField DataField="adr_addate"     HeaderText="播出日期"/>
            <asp:BoundField DataField="adr_alttext"      HeaderText="廣告標語" />
            <asp:BoundField DataField="adr_adcate"      HeaderText="廣告頁面" Visible="false" />
            <asp:BoundField DataField="adr_keyword"  HeaderText="廣告位置" Visible="false" />
            <asp:BoundField DataField="adr_navurl"     HeaderText="廣告連結" />
            <asp:BoundField DataField="adr_impr"   HeaderText="播放機率" />
            <asp:BoundField DataField="adr_adamt"      HeaderText="廣告價格" />
            <asp:BoundField DataField="adr_desamt"      HeaderText="設計價格" />
            <asp:BoundField DataField="adr_chgamt"      HeaderText="換稿費用" />
            <asp:BoundField DataField="adr_invamt"      HeaderText="發票金額" />
            <asp:BoundField DataField="adr_imseq"      HeaderText="發票廠商" />
            <asp:BoundField DataField="adr_remark"      HeaderText="備註" />
            <asp:BoundField DataField="adr_fginved"      HeaderText="adr_fginved" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</asp:panel>
</span>
</asp:Content>
