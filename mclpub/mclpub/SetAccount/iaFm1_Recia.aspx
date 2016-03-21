<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm1_Recia.aspx.cs" Inherits="mclpub.SetAccount.iaFm1_Recia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單回復 - 一次付款 - 步驟二: 回復發票開立單</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">

  <tr>
    <th colspan="3">廠商資料</th>
  </tr>

  <tr>

    <td align="left" width="200" class="font_bold">
        <asp:Label ID="lblContNo" runat="server" Font-Size="Small"></asp:Label>
      </td>

    <td align="left" width="200" class="font_bold">
        <asp:Label ID="lblIMSeq" runat="server" Font-Size="Small"></asp:Label>
      </td>

    <td>
        <asp:Label ID="lblMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
      </td>
  </tr>

  <tr>

    <td align="left" class="font_bold" colspan="3">
        <asp:Label ID="lblMfrCust" runat="server" Font-Size="Small" 
            ForeColor="Maroon"></asp:Label>
        <asp:Button ID="btnShowFullCont" runat="server" Text="顯示合約落版資料"/>
        <asp:TextBox ID="tbxCustNo" runat="server" Font-Size="Small" Visible="False" 
            Width="60px"></asp:TextBox>
        <asp:TextBox ID="tbxbkcd" runat="server" Font-Size="Small" Visible="False" 
            Width="30px"></asp:TextBox>
        <asp:TextBox ID="tbxfgpubed" runat="server" Font-Size="Small" Visible="False" 
            Width="20px"></asp:TextBox>
      </td>

  </tr>
</table>
</span>
<span class="font_size13 font_bold font_gray">
<ol>
    <li>操作步驟：整張發票開立單並被回復, 請先按<span class="font_darkblue">確認金額</span>, 再按下<span class="font_darkblue">回復發票開立單</span>按鈕來完成!</li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
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
                 AllowPaging="true" PagerSettings-Visible="false" Font-Size="11px" 
        onrowdatabound="DataGrid1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號"  ItemStyle-ForeColor="Red"/>
            <asp:BoundField DataField="im_imseq"     HeaderText="發廠序號" ItemStyle-ForeColor="Red"/>
            <asp:BoundField DataField="im_nm"      HeaderText="發廠收件人" ItemStyle-ForeColor="Red"/>
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
<br />
<asp:label id="lblIAMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:label>
<span class="stripeMe">
<asp:GridView ID="DataGrid2" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
                 Font-Size="11px" onrowdatabound="DataGrid2_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ia_iano"      HeaderText="發票開立單編號"  />
            <asp:BoundField DataField="ia_mfrno"      HeaderText="廠商統編"  />
            <asp:BoundField DataField="mfr_inm"      HeaderText="廠商名稱" />
            <asp:BoundField DataField="ia_rnm"      HeaderText="發票收件人" />
            <asp:BoundField DataField="ia_rjbti"      HeaderText="稱謂" />
            <asp:BoundField DataField="ia_rzip"      HeaderText="郵遞區號" />
            <asp:BoundField DataField="ia_raddr"      HeaderText="發票郵寄地址" />
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
<br />
<br />
<table width="100%" border="1" bordercolor="#336699" cellpadding="4" cellspacing="2">
<tr>
<td width="33%">
<asp:Panel id="pnl1" runat="server" Font-Size="Small">
<asp:Label id="lblContMessage" runat="server" Font-Size="Small" ForeColor="Blue" Font-Underline="True">合約金額 資料：</asp:Label><BR>合約金額：$ 
<asp:Label id="lblContTotalAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR>已繳金額：$ 
<asp:Label id="lblContPaidAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR>剩餘金額：$ 
<asp:Label id="lblContRestAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    </asp:Panel>
</td>
<td width="33%">
<asp:panel id="pnl2" runat="server" Font-Size="Small">
<asp:Label id="lblPickMessage" runat="server" Font-Size="Small" ForeColor="Blue" Font-Underline="True">本開立單總金額 資料：</asp:Label><BR>$ 
<asp:Label id="lblPickTotalAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label></asp:panel>
</td>
<td width="33%">
<asp:Panel id="pnl3" runat="server" Font-Size="Small">
<asp:Label id="lblNewContMessage" runat="server" Font-Size="Small" ForeColor="Blue" Font-Underline="True">將更新之合約金額 資料：</asp:Label><BR>合約金額：$ 
<asp:Label id="lblNewContTotalAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR>已繳金額：$ 
<asp:Label id="lblNewContPaidAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR>剩餘金額：$ 
<asp:Label id="lblNewContRestAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    </asp:Panel>
</td>
</tr>
</table>
	<asp:button id="btnRecia" runat="server" Text="回復發票開立單" 
        onclick="btnRecia_Click"></asp:button>
	<asp:button id="btnModifyCont" runat="server" Text="修改合約書" 
        onclick="btnModifyCont_Click"></asp:button>
	<asp:button id="btnModifyPub" runat="server" Text="修改落版" 
        onclick="btnModifyPub_Click"></asp:button>
</asp:Content>
