<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SetSAPManage.aspx.cs" Inherits="mclpub.SetAccount.SetSAPManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 發票轉檔 / 建立發票開立清單 </span>  
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
    <td align="right" width="120" class="font_bold">往來種類:</td>   
    <td>
        <asp:DropDownList ID="fgitriDropdown" runat="server" >
        </asp:DropDownList>
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
 

<ol class="font_size13 font_bold font_gray">
	<li>請輸入任一關鍵詞然後按下查詢</li>
    
</ol>

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

<span class="stripeMe">

    <asp:GridView ID="PsGV" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                OnRowDataBound="PsGVOnRowDataBound" 
                AllowSorting ="True" 
                OnSorting="gv_data_Sorting" EnableModelValidation="True" 
        DataKeyNames="ia_iaid">
    
        <Columns>

        
        <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript: SelectAllCheckboxes(this);"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>

            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server"/> 
            </itemtemplate>

        </asp:TemplateField> 
        
            <asp:BoundField DataField="ia_iaid"    HeaderText="ID" FooterText="123" />
            <asp:BoundField DataField="ia_mfrno"    HeaderText="廠商統編" FooterText="123" />
            <asp:BoundField DataField="ia_rnm"      HeaderText="廠商名稱" />
            <asp:BoundField DataField="mfr_inm"      HeaderText="公司名稱" />
            <asp:BoundField DataField="ia_refno"    HeaderText="發票開立編號" />
            <asp:BoundField DataField="ia_pyat"     HeaderText="發票金額" />
            <asp:BoundField DataField="ia_invcdN"    HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtpN"    HeaderText="課稅別" />
            <asp:BoundField DataField="ia_fgitriN"   HeaderText="往來註記" />

        </Columns>
    
        <EmptyDataRowStyle HorizontalAlign="Center" />
    
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>   
<PagerSettings Visible="False"></PagerSettings>
    </asp:GridView>
</span>

<div align="right">
    <asp:Button ID="Button1"  runat="server" Text="建立發票開立清單" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="Button1_Click"/>
</div>

<script type="text/javascript">
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
