<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelAndColseShow.aspx.cs" Inherits="mclpub.Contract.CancelAndColseShow" MasterPageFile="~/MasterPage.Master"  MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script language="javascript">
    function cleanAll() {
        window.document.getElementById("<% =tbxCompanyName.ClientID%>").value = "";
        window.document.getElementById("<% =tbxMfrNo.ClientID%>").value = "";
        window.document.getElementById("<% =tbxCustNo.ClientID%>").value = "";
        window.document.getElementById("<% =tbxCustName.ClientID%>").value = "";
        window.document.getElementById("<% =tbxContNo.ClientID%>").value = "";
        window.document.getElementById("<% =DpSelectType.ClientID%>").value = "99";
    }

    function doSelectMfr(win_width, win_height) {
        var mfrnoV = window.document.getElementById("<% =tbxMfrNo.ClientID%>").value;
        var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",location=no,status=no";
        var vReturn = window.open("mfr_detail.aspx?mfrno=" + mfrnoV, "Poping", features);
    }


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


<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 平面廣告合約書 / (註銷/結案)合約書清單</span>  
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">(註銷/結案)合約書清單</th>
  </tr>
  <tr>

    <td align="right" width="200" class="font_bold">公司名稱:</td>
    <td>
        <asp:TextBox ID="tbxCompanyName" runat="server" Width="150px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">廠商統編:</td>
    <td>
        <asp:TextBox ID="tbxMfrNo" runat="server" Width="60px" MaxLength="10"></asp:TextBox>
        <IMG class="ico" title="查詢" onclick="doSelectMfr(350,300)" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0" alt="查詢廠商">
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">客戶編號:</td>
    <td>
        <asp:TextBox ID="tbxCustNo" runat="server" Width="45px" MaxLength="6"></asp:TextBox>
        (須正確的值)</td>
  </tr>
  <tr>
    <td align="right" class="font_bold">客戶姓名:</td>
    <td>
        <asp:TextBox ID="tbxCustName" runat="server" Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">合約編號:</td>
    <td>
        <asp:TextBox ID="tbxContNo" runat="server" MaxLength="6" 
            tabIndex="5" Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">查詢類別:</td>
    <td>
        <asp:DropDownList ID="DpSelectType" runat="server">
        <asp:ListItem Value="99" Selected="True">請選擇</asp:ListItem>
        <asp:ListItem Value="01">顯示已結案合約書</asp:ListItem>
        <asp:ListItem Value="02">註銷合約書</asp:ListItem>
        <asp:ListItem Value="03">顯示已註銷合約書</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
</table>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
  <td align="left">
     <asp:Button ID="btnCancel" runat="server" Text="確認註銷" onclick="btnCancel_Click" />
  </td>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn_Click"/>
        <input id="btnClear" name="btnClear" onclick="cleanAll();" type="button" value="清除重查" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"/>
    </td>
  </tr>
</table>


<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
    </td>
</tr>
</table>
<asp:Panel ID="Panel1" runat="server">
<span class="stripeMe">
    <asp:GridView ID="GridView01" runat="server" Width="99%" AutoGenerateColumns="false" CssClass="font_blacklink font_size13" AllowPaging="true" PagerSettings-Visible="false" OnRowDataBound="GridView01OnRowDataBound">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
    <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" />
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" />
    <asp:BoundField DataField="cont_mfrno" HeaderText="廠商統編" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cont_custno" HeaderText="客戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cont_fgcancel" HeaderText="已註銷" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:TemplateField HeaderStyle-Width="8%">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server">顯示合約書</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>   
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span> 
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />  
 </div> 
</asp:Panel>

<asp:Panel ID="Panel2" runat="server">
    <span class="stripeMe">
    <asp:GridView ID="GridView02" runat="server" Width="99%" 
        AutoGenerateColumns="false" CssClass="font_blacklink font_size13" 
        AllowPaging="true" PagerSettings-Visible="false" 
        onrowdatabound="GridView02_RowDataBound" DataKeyNames="cont_contno">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
    <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" />
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" />
    <asp:BoundField DataField="cont_mfrno" HeaderText="廠商統編" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cont_custno" HeaderText="客戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cont_fgclosed" HeaderText="已結案" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:TemplateField> 
        <headertemplate>  
            <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)" ToolTip="按一次全選，再按一次取消全選" />  
        </headertemplate> 
        <itemtemplate>  
            <asp:CheckBox ID="CheckBox2" runat="server"/>  
        </itemtemplate> 
    </asp:TemplateField> 
    <asp:TemplateField HeaderStyle-Width="8%">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server">顯示合約書</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-Width="8%">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink2" runat="server">維護合約書</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>      
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
<div class="pager font_size13">
 <uc3:ucpager id="UCPager2" runat="server" />  
 </div>
</asp:Panel>
 
<asp:Panel ID="Panel3" runat="server">
<span class="stripeMe">
    <asp:GridView ID="GridView03" runat="server" Width="99%" 
        AutoGenerateColumns="false" CssClass="font_blacklink font_size13" 
        AllowPaging="true" PagerSettings-Visible="false" 
        onrowdatabound="GridView03_RowDataBound">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
    <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" />
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" />
    <asp:BoundField DataField="cont_mfrno" HeaderText="廠商統編" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cont_custno" HeaderText="客戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cont_fgclosed" HeaderText="已結案" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:TemplateField HeaderStyle-Width="8%">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server">顯示合約書</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>     
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
<div class="pager font_size13">
 <uc3:ucpager id="UCPager3" runat="server" />  
 </div>
 </asp:Panel>
 
 </asp:Content>