<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm1_Addia.aspx.cs" Inherits="mclpub.SetAccount.iaFm1_Addia" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
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
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單產生 - 一次付款 - 步驟二: 產生發票開立單</span>
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
    <li>操作步驟：請去除目前不要開立的資料 (被挑選者會被開立成同一張開立單), 先按<span class="font_darkblue">確認金額</span>, 再按下<span class="font_darkblue">產生發票開立單</span>按鈕來完成!</li>
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
                 AllowPaging="true" PagerSettings-Visible="false" 
        onrowdatabound="DataGrid1_RowDataBound" Font-Size="11px">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="3%"> 
                <headertemplate>  
                    <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)" ToolTip="按一次全選，再按一次取消全選" Checked="true" />  
                </headertemplate> 
                <itemtemplate>  
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked="true"/>  
                </itemtemplate> 
            </asp:TemplateField>
            <asp:BoundField DataField="pub_yyyymm"  HeaderText="刊登年月" />
            <asp:BoundField DataField="pub_pubseq"     HeaderText="落版序號" />
            <asp:BoundField DataField="pub_pgno"      HeaderText="刊登頁碼" />
            <asp:BoundField DataField="ltp_nm"      HeaderText="廣告版面" />
            <asp:BoundField DataField="clr_nm"  HeaderText="廣告色彩" />
            <asp:BoundField DataField="pgs_nm"     HeaderText="廣告篇幅" />
            <asp:BoundField DataField="pub_fgfixpg"   HeaderText="固定頁次" />
            <asp:BoundField DataField="pub_drafttp"      HeaderText="稿件類別" />
            <asp:BoundField DataField="pub_fggot"      HeaderText="到稿" />
            <asp:BoundField DataField="njtp_nm"      HeaderText="新稿製法" />
            <asp:BoundField DataField="pub_chgbkcd"      HeaderText="改稿書籍" />
            <asp:BoundField DataField="pub_chgjno"      HeaderText="改稿期別" />
            <asp:BoundField DataField="pub_chgjbkno"      HeaderText="改稿頁碼" />
            <asp:BoundField DataField="pub_fgrechg"      HeaderText="改稿重出片" />
            <asp:BoundField DataField="bk_nm"      HeaderText="舊稿書籍" />
            <asp:BoundField DataField="pub_origjno"      HeaderText="舊稿期別" />
            <asp:BoundField DataField="pub_origjbkno"      HeaderText="舊稿頁碼" />
            <asp:BoundField DataField="pub_adamt"      HeaderText="廣告金額" />
            <asp:BoundField DataField="pub_chgamt"      HeaderText="換稿金額"  />
            <asp:BoundField DataField="srspn_cname"      HeaderText="落版業務員" />
            <asp:BoundField DataField="pub_remark"      HeaderText="備註" />
            <asp:BoundField DataField="bk_nm"      HeaderText="書籍名稱" />
            <asp:BoundField DataField="pub_projno"      HeaderText="計劃代號" />
            <asp:BoundField DataField="pub_costctr"      HeaderText="成本中心" />
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

<asp:Button id="btnConfirmAmt" runat="server" Text="確認金額" 
        onclick="btnConfirmAmt_Click"></asp:Button>

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
<asp:Panel id="pnl2" runat="server" Font-Size="Small">
<asp:Label id="lblPickMessage" runat="server" Font-Size="Small" ForeColor="Blue" Font-Underline="True">已挑選金額 資料：</asp:Label><BR>總廣告金額：$ 
<asp:Label id="lblPickAdAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR><U>總換稿金額：</U>$ 
<asp:Label id="lblPickChgAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR>已挑選小計：$ 
<asp:Label id="lblPickTotalAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    </asp:Panel>
</td>
<td width="*">
<asp:Panel id="pnl3" runat="server" Font-Size="Small">
<asp:Label id="lblNewContMessage" runat="server" Font-Size="Small" ForeColor="Blue" Font-Underline="True">將更新之合約金額 資料：</asp:Label><BR>合約金額：$ 
<asp:Label id="lblNewContTotalAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR>已繳金額：$ 
<asp:Label id="lblNewContPaidAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><BR>剩餘金額：$ 
<asp:Label id="lblNewContRestAmt" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    </asp:Panel>
</td>
</tr>
</table>
<asp:Button id="btnAddia" runat="server" Text="產生發票開立單" onclick="btnAddia_Click"></asp:Button>
<asp:Button id="btnModifyCont" runat="server" Text="修改合約書"></asp:Button>
<asp:Button id="btnModifyPub" runat="server" Text="修改落版"></asp:Button>
<asp:TextBox id="tbxIANo" runat="server" Font-Size="Small" Width="100px" Visible="False"></asp:TextBox>		
</asp:Content>
