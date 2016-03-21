<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="mclpub.Class.SetAccount.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 發票清單列印與回復 / 發票開立單清單</span><span class="stripeMe"><table border="0" width="100%" cellspacing="0" cellpadding="0">
  
  <tr>
    <th colspan="3" align="left"> 發票開立清單</th>
  </tr>

  <tr>
    <td> 系統代號  :
        <asp:Label ID="LabelSyscd" runat="server" Text="Label"></asp:Label>
      </td>
    <td> 轉檔年月  :
        <asp:Label ID="LabelDate" runat="server" Text="Label"></asp:Label>
      </td>
    <td> 批    次  :
        <asp:Label ID="LabelSeq" runat="server" Text="Label"></asp:Label>
      </td>
  </tr>
</table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">

        &nbsp;</td>
    <td align="right">

        <asp:Button ID="Button1" runat="server" Text="列印發票開立清單" onclick="Btn1_Click"/>

        <asp:Button ID="Button2" runat="server" Text="列印發票申請單" onclick="Btn2_Click"/>

        <asp:Button ID="Button3" runat="server" Text="列印發票郵寄單" onclick="Btn3_Click"/>

        <asp:Button ID="Button4" runat="server" Text="發票開立清單回復" onclick="Btn4_Click"/>

    </td>
  </tr>
</table>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
    </td>
    <td align="right">
    </td>
</tr>
</table> 
<span class="stripeMe">

   <asp:GridView ID="PsGV" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True">
    
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
    
            <asp:BoundField DataField="ia_iaitem"   HeaderText="項次" />
            <asp:BoundField DataField="ia_invno"    HeaderText="發票開立編號" />
            <asp:BoundField DataField="ia_mfrno"    HeaderText="廠商統編" />
            <asp:BoundField DataField="mfr_inm"     HeaderText="廠商名稱" />
            <asp:BoundField DataField="ia_invno"    HeaderText="發票號碼" />
            <asp:BoundField DataField="ia_iabdate"  HeaderText="發票日期" />
            <asp:BoundField DataField="ia_fgitri"   HeaderText="往來種類" />
            <asp:BoundField DataField="ia_remark"   HeaderText="人工產生註記" />
            <asp:BoundField DataField="ia_syscd"    HeaderText="系統代號" />
            <asp:BoundField DataField="ia_iasdate"  HeaderText="轉檔年月" />
            <asp:BoundField DataField="ia_iasseq"   HeaderText="批次" />

        </Columns>
    
        <EmptyDataRowStyle HorizontalAlign="Center" />
    
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    
        <PagerSettings Visible="False">
        </PagerSettings>
    
    </asp:GridView>

</span>



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
