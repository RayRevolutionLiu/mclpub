<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IA1ConfirmChecked.aspx.cs" Inherits="mclpub.SetAccount.IA1ConfirmChecked" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        $<asp:Label ID="lblTotAmt" runat="server" CssClass="font_size12 font_red"></asp:Label>
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
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" /><asp:label id="lblAdrInfo" runat="server">發票開立單資料</asp:label>
            </td>
            <td align="right">
                &nbsp;</td>
            
        </tr>
</table>
<span class="stripeMe">
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th class="font_size12">廠商統編</th>
    <th class="font_size12">發票金額</th>
    <th class="font_size12">計畫代號</th>
    <th class="font_size12">發票收件人姓名</th>
    <th class="font_size12">職稱</th>
    <th class="font_size12">郵遞區號</th>
    <th class="font_size12">地址</th>
    <th class="font_size12">電話</th>
    <th class="font_size12">發票類別</th>
    <th class="font_size12">課稅別</th>
    <th class="font_size12">往來</th>
  </tr>
  <tr>
    <td>

        <asp:Label ID="lblMfrno" runat="server" CssClass="font_size12"></asp:Label>

    </td>
    <td>
        $<asp:Label ID="lblPyat" runat="server" CssClass="font_size12" ForeColor="Red"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblProjNo" runat="server" CssClass="font_size12" ForeColor="Red"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblNm" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblJbti" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblZip" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblAddr" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblTel" runat="server" CssClass="font_size12"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblInvcd" runat="server" CssClass="font_size12"></asp:Label>
        <asp:Label ID="lblInvcd1" runat="server" CssClass="font_size12" Visible="False"></asp:Label>
    </td>
    <td style="width:140px">
        <asp:Label ID="lblTaxtp" runat="server" CssClass="font_size12"></asp:Label>
        <asp:Label ID="lblTaxtp1" runat="server" CssClass="font_size12" Visible="False"></asp:Label>
    </td>
    <td style="width:140px">
        <asp:Label ID="lblFgitri" runat="server" CssClass="font_size12"></asp:Label>
        <asp:Label ID="lblFgitri1" runat="server" CssClass="font_size12" 
            Visible="False"></asp:Label>
    </td>
  </tr>
  </table>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="Table2">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" /><asp:label id="Label1" runat="server">發票開立單明細資料</asp:label>
                <asp:Label ID="lblCount" runat="server" ForeColor="DarkGoldenrod"></asp:Label>
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
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True"
                PagerSettings-Visible="false"
        onrowdatabound="DataGrid1_RowDataBound">
        <Columns>
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
            <asp:BoundField DataField="adr_remark"      HeaderText="備註" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</span>

<asp:panel id="pnlAdr" Width="100%" Runat="server">
<asp:Button id="btnBack" runat="server" Text="挑錯重新挑選" ToolTip="勾選的項目不對, 重新挑選" 
        onclick="btnBack_Click"></asp:Button>
<asp:Button id="btnModifyAdr" runat="server" Text="落版金額錯誤, 修改落版金額" 
        ToolTip="落版金額錯誤, 前往落版處理" onclick="btnModifyAdr_Click"></asp:Button>
<asp:Button id="btnCancel" runat="server" Text="取消, 回首頁" ToolTip="回首頁" 
        onclick="btnCancel_Click"></asp:Button>
<asp:Button id="btnPrint" runat="server" Text="列印預覽清單" onclick="btnPrint_Click" Visible="false"></asp:Button>
<asp:Button id="btnConfirm" runat="server" ForeColor="Red" Text="確定產生發票開立單" 
        ToolTip="確定產生發票開立單" onclick="btnConfirm_Click"></asp:Button>
</asp:panel>
<asp:panel id="pnlNext" Visible="False" Width="100%" Runat="server">
<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
<br />
<asp:Button id="btnContinue" runat="server" Text="繼續發票開立作業(同合約)" 
        onclick="btnContinue_Click"></asp:Button>
<asp:Button id="btnGoIA1" runat="server" Text="繼續發票開立作業(不同合約)" 
        onclick="btnGoIA1_Click"></asp:Button>
<asp:Button id="btnExit" runat="server" Text="結束, 回首頁" onclick="btnExit_Click"></asp:Button>
</asp:panel>
</asp:Content>
