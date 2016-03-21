<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm1_chklist.aspx.cs" Inherits="mclpub.SetAccount.iaFm1_chklist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單檢核表 - 一次付款</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
    <tr>
    	<td class="font_size18 font_bold">
            <img alt="搜尋" src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />
            <asp:Label ID="lblCont" runat="server" Font-Bold="True" ForeColor="Blue">合約資料：</asp:Label>
            <asp:Label ID="lblContMessage" runat="server" Font-Size="Small" 
                ForeColor="Maroon"></asp:Label>
        </td>       
        <td align="right">
            &nbsp;</td>
    </tr>
</table>
<span class="stripeMe">
<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
                 AllowPaging="true" PagerSettings-Visible="false" Font-Size="11px" 
        onrowdatabound="DataGrid1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號"  ItemStyle-ForeColor="Red"/>
            <asp:BoundField DataField="im_imseq"     HeaderText="發廠序號" ItemStyle-ForeColor="Red"/>
            <asp:BoundField DataField="im_nm"      HeaderText="發廠收件人" ItemStyle-ForeColor="Red"/>
            <asp:BoundField DataField="mfr_inm"      HeaderText="廠商名稱" />
            <asp:BoundField DataField="bk_nm"  HeaderText="書籍類別" />
            <asp:BoundField DataField="cont_conttp"     HeaderText="合約類別" />
            <asp:BoundField DataField="cont_signdate"   HeaderText="簽約日期" />
            <asp:BoundField DataField="cont_sdate"      HeaderText="合約起日" />
            <asp:BoundField DataField="cont_edate"      HeaderText="合約迄日" />
            <asp:BoundField DataField="cont_custno"      HeaderText="客戶編號" />
            <asp:BoundField DataField="cust_nm"      HeaderText="客戶名稱" />
            <asp:BoundField DataField="cont_totjtm"      HeaderText="總製稿" />
            <asp:BoundField DataField="cont_tottm"      HeaderText="總刊登" />
            <asp:BoundField DataField="cont_totamt"      HeaderText="總金額" />
            <asp:BoundField DataField="cont_paidamt"      HeaderText="已付金額" />
            <asp:BoundField DataField="cont_restamt"      HeaderText="剩餘金額" />
            <asp:BoundField DataField="cont_fgclosed"      HeaderText="結案" />
            <asp:BoundField DataField="srspn_cname"      HeaderText="承辦業務員" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="Table1">
    <tr>
    	<td class="font_size18 font_bold">
            <img alt="搜尋" src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />
            <asp:Label ID="lblIA" runat="server" Font-Bold="True" ForeColor="Blue">已開立之發票資料：</asp:Label>
            <asp:Label ID="lblIAMessage" runat="server" Font-Size="Small" 
                ForeColor="Maroon"></asp:Label>
        </td>       
        <td align="right">
            <asp:TextBox ID="tbxIANo" runat="server" Font-Size="X-Small" MaxLength="8" 
                Visible="False" Width="80px"></asp:TextBox>
        </td>
    </tr>
</table>
<span class="stripeMe">
<asp:GridView ID="DataGrid2" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
                 AllowPaging="true" PagerSettings-Visible="false" Font-Size="11px" 
        onrowdatabound="DataGrid2_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ia_iano"      HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_mfrno"      HeaderText="廠商統編" />
            <asp:BoundField DataField="mfr_inm"      HeaderText="廠商名稱" />
            <asp:BoundField DataField="ia_rnm"      HeaderText="發票收件人" />
            <asp:BoundField DataField="ia_rjbti"      HeaderText="稱謂" />
            <asp:BoundField DataField="ia_raddr"      HeaderText="發票郵寄地址" />
            <asp:BoundField DataField="ia_rzip"      HeaderText="郵遞區號" />
            <asp:BoundField DataField="ia_rtel"      HeaderText="電話" />
            <asp:BoundField DataField="ia_invcd"      HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"      HeaderText="課稅別" />
            <asp:BoundField DataField="iad_iaditem"      HeaderText="發票開立單明細序號" />
            <asp:BoundField DataField="iad_fk1"      HeaderText="合約編號" />
            <asp:BoundField DataField="iad_fk2"      HeaderText="刊登年月" />
            <asp:BoundField DataField="iad_fk3"      HeaderText="落版序號" />
            <asp:BoundField DataField="iad_desc"      HeaderText="品名" />
            <asp:BoundField DataField="iad_projno"      HeaderText="計劃代號" />
            <asp:BoundField DataField="iad_costctr"      HeaderText="成本中心" />
            <asp:BoundField DataField="iad_qty"      HeaderText="數量" />
            <asp:BoundField DataField="iad_amt"      HeaderText="金額" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="Table2">
    <tr>
    	<td class="font_size18 font_bold" align="right">
            <asp:button id="btnBack" runat="server" Text="返回首頁" onclick="btnBack_Click"></asp:button>
            <INPUT id="btnPrint" onclick="Javascript:window.print();" type="button" value="列印本頁"
             name="btnPrint" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
            onmouseout="this.className='btn_mouseout'">
            <asp:button id="btnAddIA" runat="server" Text="繼續開立" onclick="btnAddIA_Click"></asp:button>
        </td>
   </tr>
</table> 

</asp:Content>
