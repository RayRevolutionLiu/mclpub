<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm2_chklist_ia.aspx.cs" Inherits="mclpub.SetAccount.iaFm2_chklist_ia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單檢核表 - 大批月結</span>
<asp:panel id="pnlQuery" runat="server">
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="160" class="font_bold"><asp:label id="lblBkcd" runat="server">書籍類別：</asp:label></td>
    <td align="left">
        <asp:DropDownList ID="ddlBkcd" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" width="160" class="font_bold"><asp:label id="lblYYYYMM" runat="server">刊登年月：</asp:label>
       </td>
    <td align="left">
        <asp:TextBox ID="tbxYYYYMM" runat="server" MaxLength="7" Width="60px"></asp:TextBox>
        <FONT color="darkred" size="2">
					(預設值：當月，如2002/08)</FONT>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxYYYYMM" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxYYYYMM"></asp:requiredfieldvalidator>
      </td>
  </tr>
  <tr>
    <td align="right" width="160" class="font_bold"><asp:label id="lblOrderByFilter" runat="server">排序條件：</asp:label></td>
    <td align="left">
        <asp:DropDownList ID="ddlOrderByFilter" runat="server">
            <asp:ListItem Selected="True" Value="1">合約編號+落版序號</asp:ListItem>
            <asp:ListItem Value="2">業務員</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" width="160" class="font_bold"><asp:Label id="lblIabSeq" runat="server">＊發票開立單批號：</asp:Label></td>
    <td align="left">
        <asp:TextBox ID="tbxIabseq" runat="server" MaxLength="6" Width="60px">000001</asp:TextBox>
        <FONT color="darkred" size="2">(請輸入正確值，如 000001)</FONT>
      </td>
  </tr>
  </table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">

        <asp:Label ID="lblMessage" runat="server" Font-Size="X-Small" 
            ForeColor="Maroon"></asp:Label>
        <asp:TextBox ID="tbxIAStatus" runat="server" Visible="False" Width="30px"></asp:TextBox>
        <asp:Label ID="lblMemo" runat="server" Font-Size="Small" ForeColor="Red">註：已於會計系統中處理的資料, 無法再做檢視或列印!</asp:Label>

    </td>
    <td align="right">
       <asp:button id="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click"></asp:button>
    </td>
  </tr>
</table>
</asp:panel>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
    </td>
    <td align="right">
        <asp:Label ID="lblMessage2" runat="server" Font-Size="Small" 
            ForeColor="Maroon"></asp:Label>
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
        onrowdatabound="DataGrid1_RowDataBound" Font-Size="11px">
        <Columns>
            <asp:BoundField DataField="ia_iano"  HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_mfrno"  HeaderText="廠商統編" />
            <asp:BoundField DataField="mfr_inm"  HeaderText="廠商名稱" />
            <asp:BoundField DataField="ia_rnm"  HeaderText="發票收件人" />
            <asp:BoundField DataField="ia_rjbti"  HeaderText="稱謂" />
            <asp:BoundField DataField="ia_raddr"  HeaderText="發票郵寄地址" />
            <asp:BoundField DataField="ia_rzip"  HeaderText="郵遞區號" />
            <asp:BoundField DataField="ia_rtel"  HeaderText="電話" />
            <asp:BoundField DataField="ia_invcd"  HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"  HeaderText="課稅別" />
            <asp:BoundField DataField="iad_iaditem"  HeaderText="發票開立單明細序號" />
            <asp:BoundField DataField="iad_fk1"  HeaderText="合約編號" />
            <asp:BoundField DataField="iad_fk2"  HeaderText="刊登年月" />
            <asp:BoundField DataField="iad_fk3"  HeaderText="落版序號" />
            <asp:BoundField DataField="iad_desc"  HeaderText="品名" />
            <asp:BoundField DataField="iad_projno"  HeaderText="計劃代號" />
            <asp:BoundField DataField="iad_costctr"  HeaderText="成本中心" />
            <asp:BoundField DataField="iad_qty"  HeaderText="數量" />
            <asp:BoundField DataField="iad_amt"  HeaderText="金額" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
    <div style="text-align:right">
        <asp:Button ID="btnPrintList" runat="server" onclick="btnPrintList_Click" 
            Text="列印檢核表" />
    </div>
</span>
</asp:Content>
