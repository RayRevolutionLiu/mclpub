<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayListFilter.aspx.cs" Inherits="mclpub.Pay.PayListFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function SelectAllCheckboxes(spanChk,GVid) {
        elm = document.forms[0];
        for (i = 0; i <= elm.length - 1; i++) {
            if (elm[i].type == "checkbox" && elm[i].id != spanChk.id && elm[i].id.indexOf(GVid) != -1) {
                if (elm.elements[i].checked != spanChk.checked)
                    elm.elements[i].click();
            }
        }
    } 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 繳款處理 / 產生繳款清單</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="left" class="font_bold" colspan="2">產生年月：
        <asp:Label ID="lblyyyymm" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:Label>
        &nbsp;
        批次：
        <asp:Label ID="lblbatch" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:Label>
        &nbsp;
        總項次：
	    <asp:label id="lbltoitem" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:label>

      </td>
  </tr>
  <tr>

    <td align="right" width="90" class="font_bold"><span class="stripeMe">付款方式：</span></td>
    <td>
        <asp:DropDownList ID="ddlPayType" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlPayType_SelectedIndexChanged">
        </asp:DropDownList>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
    <asp:button id="btnList" runat="server" Text="產生繳款清單" Enabled="False" 
            onclick="btnList_Click"></asp:button>			
    <asp:button id="btnListPrint" runat="server" Text="列印繳款清單" Enabled="False" 
            onclick="btnListPrint_Click"></asp:button>
    </td>    
    <td align="right">
        <asp:Button ID="btnSearch" runat="server" Text="查詢" onclick="btnSearch_Click" />
    </td>
  </tr>
</table>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        &nbsp;</td>
</tr>
</table>
<span class="stripeMe">
<asp:GridView ID="DataList1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13"  EnableModelValidation="True" >
        <Columns>       
        <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript:SelectAllCheckboxes(this,'DataList1');"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>
            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server"/> 
            </itemtemplate>
        </asp:TemplateField> 
        
            <asp:BoundField DataField="py_pyno" HeaderText="繳款編號" />
            <asp:BoundField DataField="py_date" HeaderText="繳款日期"/>
            <asp:BoundField DataField="py_amt"  HeaderText="金額" />
        </Columns>   
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    </asp:GridView>
<asp:GridView ID="DataList2" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" EnableModelValidation="True" >
        <Columns>       
        <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript:SelectAllCheckboxes(this,'DataList2');"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>
            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server"/> 
            </itemtemplate>
        </asp:TemplateField> 
        
            <asp:BoundField DataField="py_pyno" HeaderText="繳款編號" />
            <asp:BoundField DataField="py_date" HeaderText="繳款日期"/>
            <asp:BoundField DataField="py_amt"  HeaderText="金額" />
            <asp:BoundField DataField="py_chkno" HeaderText="票據號碼" />
            <asp:BoundField DataField="py_chkbnm" HeaderText="付款行"/>
            <asp:BoundField DataField="py_chkdate"  HeaderText="到期日" />
        </Columns>   
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    </asp:GridView>
<asp:GridView ID="DataList3" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" EnableModelValidation="True" >
        <Columns>       
        <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript:SelectAllCheckboxes(this,'DataList3');"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>
            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server"/> 
            </itemtemplate>
        </asp:TemplateField> 
        
            <asp:BoundField DataField="py_pyno" HeaderText="繳款編號" />
            <asp:BoundField DataField="py_date" HeaderText="繳款日期"/>
            <asp:BoundField DataField="py_amt"  HeaderText="金額" />
            <asp:BoundField DataField="py_moseq" HeaderText="劃撥單批號" />
            <asp:BoundField DataField="py_moitem" HeaderText="劃撥單項次"/>
        </Columns>   
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    </asp:GridView>
<asp:GridView ID="DataList4" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" EnableModelValidation="True" >
        <Columns>       
        <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript:SelectAllCheckboxes(this,'DataList4');"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>
            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server"/> 
            </itemtemplate>
        </asp:TemplateField>       
            <asp:BoundField DataField="py_pyno" HeaderText="繳款編號" />
            <asp:BoundField DataField="py_date" HeaderText="繳款日期"/>
            <asp:BoundField DataField="py_amt"  HeaderText="金額" />
            <asp:BoundField DataField="py_waccno" HeaderText="電匯帳號" />
            <asp:BoundField DataField="py_wdate" HeaderText="匯入日期"/>
            <asp:BoundField DataField="py_wbcd" HeaderText="金融代碼"/>
        </Columns>
</asp:GridView>
<asp:GridView ID="DataList5" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" EnableModelValidation="True" >
        <Columns>       
        <asp:TemplateField HeaderStyle-Width="3%">
            <headertemplate> 
                <asp:CheckBox ID="CheckAll" 
                              runat="server" 
                              onclick="javascript:SelectAllCheckboxes(this,'DataList5');"                          
                              ToolTip="按一次全選，再按一次取消全選" /> 
             </headertemplate>
            <itemtemplate> 
                <asp:CheckBox ID="CheckBox2" runat="server"/> 
            </itemtemplate>
        </asp:TemplateField>       
            <asp:BoundField DataField="py_pyno" HeaderText="繳款編號" />
            <asp:BoundField DataField="py_date" HeaderText="繳款日期"/>
            <asp:BoundField DataField="py_amt"  HeaderText="金額" />
            <asp:BoundField DataField="py_ccno" HeaderText="信用卡卡號" />
            <asp:BoundField DataField="py_ccauthcd" HeaderText="授權碼"/>
            <asp:BoundField DataField="py_ccvdate" HeaderText="有效年月"/>
        </Columns>
</asp:GridView>

<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" >
        <Columns>       
            <asp:BoundField DataField="py_pyno" HeaderText="繳款編號" />
            <asp:BoundField DataField="py_date" HeaderText="繳款日期"/>
            <asp:BoundField DataField="py_amt" HeaderText="金額" />
            <asp:BoundField DataField="py_pysdate" HeaderText="繳款清單產生年月"/>
            <asp:BoundField DataField="py_pysseq" HeaderText="繳款清單批次" />
            <asp:BoundField DataField="py_pysitem" HeaderText="繳款清單項次"/>
            <asp:BoundField DataField="py_moseq" HeaderText="劃撥單批號" />
            <asp:BoundField DataField="py_moitem" HeaderText="項次"/>
            <asp:BoundField DataField="py_chkno" HeaderText="票據號碼" />
            <asp:BoundField DataField="py_chkbnm" HeaderText="付款行"/>
            <asp:BoundField DataField="py_chkdate" HeaderText="到期日" />
            <asp:BoundField DataField="py_waccno" HeaderText="電匯帳號"/>
            <asp:BoundField DataField="py_wdate" HeaderText="匯入日期" />
            <asp:BoundField DataField="py_wbcd" HeaderText="金融代碼"/>
            <asp:BoundField DataField="py_ccno" HeaderText="信用卡卡號" />
            <asp:BoundField DataField="py_ccauthcd" HeaderText="授權碼"/>
            <asp:BoundField DataField="py_ccvdate" HeaderText="有效年月" />
        </Columns>   
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    </asp:GridView>
</span>
</asp:Content>
