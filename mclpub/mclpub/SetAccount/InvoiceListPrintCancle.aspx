<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InvoiceListPrintCancle.aspx.cs" Inherits="mclpub.SetAccount.InvoiceListPrintCancle" %>

<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 發票清單列印與回復 / 查詢</span>
    <span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">

  <tr>
    <th colspan="2">發票資料</th>
  </tr>

  <tr>

    <td align="right" width="120" class="font_bold">系統代號:</td>

    <td>

        <asp:DropDownList ID="sysocDrpdown" runat="server">
        </asp:DropDownList>
    </td>

  </tr>

  <tr>

    <td align="right" width="120" class="font_bold">轉檔年月:</td>
    
    <td>
        <asp:TextBox ID="transform_time" runat="server" Width="66px"></asp:TextBox>
        <span class="font_lightgray">(例: 201207)</span>
    </td>

  </tr>

   <tr>

    <td align="right" width="120" class="font_bold">批次:</td>
    
    <td>
        <asp:TextBox ID="batch" runat="server"></asp:TextBox>
    </td>

  </tr>

  
</table>
</span>     
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">

        <asp:Button ID="CheckBtn" runat="server" Text="查詢" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn_Click"/>

    </td>
  </tr>
</table> 


<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
    <tr>
    	<td class="font_size18 font_bold">
            <img alt="搜尋" src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
        </td>
        
        <td align="right">
            &nbsp;
        </td>
    </tr>
</table>


 <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="select_item">
  <tr>

  
    <td align="left">

        <asp:Button ID="Button5" runat="server" Text="手動取回發票" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="Btn5_Click"/>

    </td>

  </tr>
</table> 

<span class="stripeMe">

    <asp:GridView ID="PsGV" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                OnRowDataBound="PsGVOnRowDataBound" 
                AllowPaging="True" 
                PagerSettings-Visible="false" 
                AllowSorting ="True" 
                EnableModelValidation="True">
    
        <Columns>

         <asp:TemplateField HeaderStyle-Width="10%">
             <ItemTemplate>
                 <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Detail">詳細資料</asp:LinkButton>
             </ItemTemplate>
         </asp:TemplateField>
            
            <asp:BoundField DataField="ias_syscd"       HeaderText="系統代號" />
            <asp:BoundField DataField="ias_iasdate"     HeaderText="轉檔日期" />
            <asp:BoundField DataField="ias_iasseq"      HeaderText="批次" />
            <asp:BoundField DataField="ias_toitem"      HeaderText="開立單數" />
            <asp:BoundField DataField="ias_createdate"  HeaderText="產生日期" />
            <asp:BoundField DataField="srspn_cname"     HeaderText="建立者" />
            <asp:BoundField DataField="ias_trans_sap"   HeaderText="是否轉SAP" />
            <asp:BoundField DataField="ias_cancel"      HeaderText="是否註銷" />

        </Columns>
    
        <EmptyDataRowStyle HorizontalAlign="Center" />
    
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    
        <PagerSettings Visible="False">
        </PagerSettings>
    
    </asp:GridView>

</span>

<!--{* 分頁start *}-->
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />    
</div>



<script type="text/javascript">

    function SelectSingleCheckboxes(spanChk) {

        elm = document.forms[0];

        x = 0;

        //檢查是否選取了兩項以上
        for (i = 0; i <= elm.length - 1; i++) {

            if (elm.elements[i].checked == true) {
                x++;
            }
        }

        //如果選取項超過兩個
        if (x > 1) {

            //清除所有勾選
            for (i = 0; i <= elm.length - 1; i++) {
                elm.elements[i].checked = false;
            }

            //重新選取最後勾選的選項
            spanChk.checked = true;
           
         }        
    }
</script> 

</asp:Content>
