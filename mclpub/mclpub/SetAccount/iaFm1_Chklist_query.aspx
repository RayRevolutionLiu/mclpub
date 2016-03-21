<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm1_Chklist_query.aspx.cs" Inherits="mclpub.SetAccount.iaFm1_Chklist_query" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單檢核表  - 一次付款 - 步驟一: 查詢畫面</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold"><span class="font_red">*</span>
        廠商名稱：</td>
    <td align="left">
        <asp:TextBox ID="tbxMfrIName" runat="server"  MaxLength="50" 
            Width="120px"></asp:TextBox>
                    <asp:Label ID="lblMfrNo" runat="server" Font-Size="Small" 
            ForeColor="#C00000"></asp:Label>
                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxMfrIName"></asp:requiredfieldvalidator>
        <asp:TextBox ID="tbxMfrNo" runat="server"  Visible="False" 
            Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">發票廠商收件人姓名：
       </td>
    <td align="left">

        <asp:TextBox ID="tbxIMName" runat="server" MaxLength="30" Width="60px"></asp:TextBox>

        </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        發票開立單號碼：</td>
    <td align="left">
        <asp:TextBox ID="tbxIANo" runat="server" MaxLength="8" Width="80px"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
        
        &nbsp;&nbsp; 

        <input id="hidIAStatus" type="hidden" maxLength="1" size="1" name="hidIAStatus" runat="server" />&nbsp; 
                
        <asp:TextBox ID="tbxContNo" runat="server" Font-Size="X-Small" MaxLength="6" 
            Visible="False" Width="60px"></asp:TextBox>
        <asp:TextBox ID="tbxIMSeq" runat="server" Font-Size="X-Small" Visible="False" 
            Width="30px"></asp:TextBox>
        <asp:TextBox ID="tbxIMName2" runat="server" Font-Size="X-Small" Visible="False" 
            Width="80px"></asp:TextBox>
                
    </td>
    <td align="right">
        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />
    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
    <ol>
       <li>請挑選要檢核的合約書編號及發票廠商收件人, 再按下<span class="font_darkblue">確認挑選</span>按鈕</li>
       <li>請挑選要檢核的發票開立單編號, 再按下<span class="font_darkblue">確認挑選</span>按鈕!</li>
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
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">確認挑選</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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
<div class="pager font_size13">
<uc3:ucpager id="UCPager1" runat="server" />
</div>
<span class="stripeMe">
<asp:GridView ID="DataGrid2" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
                 Font-Size="11px" onrowdatabound="DataGrid2_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="35px">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">確認挑選</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ia_iano"      HeaderText="發票開立單編號" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="ia_mfrno"      HeaderText="廠商統編" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="mfr_inm"      HeaderText="廠商名稱" />
            <asp:BoundField DataField="ia_rnm"      HeaderText="發票收件人" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="ia_rjbti"      HeaderText="稱謂" />
            <asp:BoundField DataField="ia_rzip"      HeaderText="郵遞區號" />
            <asp:BoundField DataField="ia_raddr"      HeaderText="發票郵寄地址" />
            <asp:BoundField DataField="ia_rtel"      HeaderText="電話" />
            <asp:BoundField DataField="ia_invcd"      HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"      HeaderText="課稅別" />
            <asp:BoundField DataField="ia_status"      HeaderText="目前狀態" />
            <asp:BoundField DataField="ia_invno"      HeaderText="發票號碼" />
            <asp:BoundField DataField="ia_pyat"      HeaderText="含稅(實付)金額" />
            <asp:BoundField DataField="ia_contno"      HeaderText="合約編號" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
</span>
</asp:Content>
