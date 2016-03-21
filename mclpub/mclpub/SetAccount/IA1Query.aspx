<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IA1Query.aspx.cs" Inherits="mclpub.SetAccount.IA1Query" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 網路廣告發票處理 / 單一廠商發票開立產生</span>
<span class="stripeMe">
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        公司名稱：</td>
    <td align="left">
        <asp:TextBox ID="tbxMfrNm" runat="server" Width="150px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">統一編號：
       </td>
    <td align="left">
        <asp:TextBox ID="tbxMfrNo" runat="server" Width="80px"></asp:TextBox>
        </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        客戶編號：</td>
    <td align="left">
        <asp:TextBox ID="tbxCustNo" runat="server" MaxLength="6" Width="60px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
       客戶姓名：</td>
    <td align="left">
        <asp:TextBox ID="tbxCustNm" runat="server" Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        合約書編號：</td>
    <td align="left">
        <asp:TextBox ID="tbxContNo" runat="server" Width="80px"></asp:TextBox>
        <asp:LinkButton ID="lngGoThis" runat="server" onclick="lngGoThis_Click">GO</asp:LinkButton>
      </td>
  </tr>
  </table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
        
        &nbsp;&nbsp; 

        <input id="hidIAStatus" type="hidden" maxLength="1" size="1" name="hidIAStatus" runat="server" />&nbsp; 
                
        </td>
    <td align="right">
        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />
    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
    <ol>
       <li>請輸入任一關鍵詞來查詢，然後按下<span class="font_darkblue">查詢</span></li>
       <li>查出資料後，選擇所需的合約按下<span class="font_darkblue">確定</span>可進行下一步驟</li>
       <li>如輸入確定的合約編號, 按下<span class="font_darkblue">GO</span>可進行下一步驟</li>
    </ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
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
             <asp:TemplateField HeaderStyle-Width="35px">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="確認" OnClick="Button1_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號"/>
            <asp:BoundField DataField="cont_signdate"     HeaderText="簽約日期"/>
            <asp:BoundField DataField="mfr_inm"      HeaderText="公司名稱" />
            <asp:BoundField DataField="cust_custno"      HeaderText="客戶編號" />
            <asp:BoundField DataField="cust_nm"  HeaderText="客戶姓名" />
            <asp:BoundField DataField="cont_aunm"     HeaderText="廣告聯絡人姓名" />
            <asp:BoundField DataField="cont_autel"   HeaderText="廣告聯絡人電話" />
            <asp:BoundField DataField="cont_fgpayonce"      HeaderText="一次付清註記" />
            <asp:BoundField DataField="cont_fgclosed"      HeaderText="已結案" />
            <asp:BoundField DataField="cont_conttp"      HeaderText="合約類別" />
            <asp:BoundField DataField="cont_disc"      HeaderText="優惠折數" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</span>
<div class="pager font_size13">
<uc3:ucpager id="UCPager1" runat="server" />
</div>
</asp:Content>
