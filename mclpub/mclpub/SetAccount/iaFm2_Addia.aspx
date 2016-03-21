<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm2_Addia.aspx.cs" Inherits="mclpub.SetAccount.iaFm2_Addia" MaintainScrollPositionOnPostback="true" %>
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
<asp:Content  ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單產生 - 大批月結 - 步驟一: 挑選欲開立之落板資料</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="160" class="font_bold">
        書籍類別：</td>
    <td align="left">
        <asp:DropDownList ID="ddlBkcd" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" width="160" class="font_bold">刊登年月：
       </td>
    <td align="left">
        <asp:TextBox ID="tbxYYYYMM" runat="server" MaxLength="7" Width="90px"></asp:TextBox>
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
    <td align="right" width="160" class="font_bold">
        排序條件：</td>
    <td align="left">
        <asp:DropDownList ID="ddlOrderByFilter" runat="server">
            <asp:ListItem Selected="True" Value="1">合約編號+落版序號</asp:ListItem>
            <asp:ListItem Value="2">業務員</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  </table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
        
        <asp:Label ID="lblMessage" runat="server" Font-Size="Small" 
            ForeColor="Maroon"></asp:Label>
        <asp:textbox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:textbox>&nbsp;&nbsp; 

        <input id="hidIAStatus" type="hidden" maxLength="1" size="1" name="hidIAStatus" runat="server" />&nbsp; 
                
    </td>
    <td align="right">
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
    </td>
  </tr>
</table>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" /><asp:Label 
            ID="lblIA" runat="server" Font-Bold="True" ForeColor="Blue">目前可開立之落版明細：</asp:Label>
    </td>
    <td align="right">
    </td>
</tr>
</table>
<asp:panel id="pnlPub" runat="server">
<span class="stripeMe">
<asp:Label id="lblMemo1" runat="server" Font-Size="Small" ForeColor="#C04000">操作步驟一：請挑選欲開立的落版資料(不要馬上開立者, 請去除其勾選), 全部挑選完, 請按下 '挑畢, 確認挑選' 按鈕.</asp:Label>
<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
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
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="cont_conttp"  HeaderText="合約類別" />
            <asp:BoundField DataField="cont_sdate"  HeaderText="合約起日" />
            <asp:BoundField DataField="cont_edate"  HeaderText="合約迄日" />
            <asp:BoundField DataField="cont_mfrno"  HeaderText="廠商統編" />
            <asp:BoundField DataField="mfr_inm"  HeaderText="廠商名稱" ItemStyle-ForeColor="Maroon"/>
            <asp:BoundField DataField="cust_nm"  HeaderText="客戶姓名" />
            <asp:BoundField DataField="srspn_cname"  HeaderText="業務員" />
            <asp:BoundField DataField="cont_totamt"  HeaderText="合約總金額" />
            <asp:BoundField DataField="cont_paidamt"  HeaderText="已繳金額" />
            <asp:BoundField DataField="cont_restamt"  HeaderText="剩餘金額" />
            <asp:BoundField DataField="pub_yyyymm"  HeaderText="刊登年月" />
            <asp:BoundField DataField="pub_pubseq"  HeaderText="落版序號" />
            <asp:BoundField DataField="pub_imseq"  HeaderText="發廠序號" />
            <asp:BoundField DataField="im_nm"  HeaderText="發廠收件人" ItemStyle-ForeColor="Red"/>
            <asp:BoundField DataField="pub_pgno"  HeaderText="刊登頁碼" />
            <asp:BoundField DataField="ltp_nm"  HeaderText="版面" />
            <asp:BoundField DataField="clr_nm"  HeaderText="色彩" />
            <asp:BoundField DataField="pgs_nm"  HeaderText="篇幅" />
            <asp:BoundField DataField="pub_fgfixpg"  HeaderText="固定頁次" />
            <asp:BoundField DataField="pub_drafttp"  HeaderText="稿件類別" />
            <asp:BoundField DataField="njtp_nm"  HeaderText="新稿製法" />
            <asp:BoundField DataField="pub_fggot"  HeaderText="到稿" />
            <asp:BoundField DataField="pub_chgjno"  HeaderText="改稿期別" />
            <asp:BoundField DataField="pub_origjno"  HeaderText="舊稿期別" />
            <asp:BoundField DataField="pub_adamt"  HeaderText="廣告金額" />
            <asp:BoundField DataField="pub_chgamt"  HeaderText="換稿金額" />
            <asp:BoundField DataField="pub_remark"  HeaderText="備註" />
            <asp:BoundField DataField="cont_empno"  HeaderText="業務員工號" />
            <asp:BoundField DataField="pub_imseq"  HeaderText="發廠序號" />
            <asp:BoundField DataField="bk_nm"  HeaderText="書籍名稱" />
            <asp:BoundField DataField="pub_projno"  HeaderText="計劃代號" />
            <asp:BoundField DataField="pub_costctr"  HeaderText="成本中心" />

        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
</span>
<asp:Label id="lblMemo" runat="server" Font-Size="Small" ForeColor="#C04000">註：檢視 '預覽 發票開立清單' 時, 若發現資料誤挑, 請按下 '挑錯, 全部重挑' 按鈕來重新挑選; 或是落版資料有誤, 請維護之!</asp:Label><BR>
<asp:Button id="btnConfirmAmt" runat="server" Text="挑畢, 確認挑選" 
            onclick="btnConfirmAmt_Click"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnPickReset" runat="server" Text="挑錯, 全部重挑" 
            onclick="btnPickReset_Click"></asp:Button><BR><BR>
<asp:label id="lblPickMessage" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:label><BR>
<asp:Label id="lblMemo2" runat="server" Font-Size="Small" ForeColor="#C04000">操作步驟二：再檢視完 '預覽 發票開立清單' 並確認資料無誤之後, 請按下 '產生 發票開立單' 按鈕來完成開立動作!</asp:Label><BR>
<asp:Button id="btnCreateIA" runat="server" Text="產生 發票開立單" onclick="btnCreateIA_Click"></asp:Button>
    </asp:panel>

    <asp:Panel id="pnlPubProjError" runat="server">
    <span class="stripeMe">
	<asp:Label id="lblMemo3" runat="server" Font-Size="Small" ForeColor="#C04000">以下落版之<B>
計劃代號</B>或<B>成本中心</B>資料有誤, 請先修正！<br>操作步驟：按下 '維護落版資料' 來個別完修改資料! 全部修改完畢, 請再按下 '清除重查' 按鈕來重新開立！</asp:Label>
	<br />
    <asp:GridView ID="DataGrid2" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
        onrowdatabound="DataGrid2_RowDataBound" Font-Size="11px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">確認挑選</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="cont_conttp"  HeaderText="合約類別" />
            <asp:BoundField DataField="cont_sdate"  HeaderText="合約起日" />
            <asp:BoundField DataField="cont_edate"  HeaderText="合約迄日" />
            <asp:BoundField DataField="cont_mfrno"  HeaderText="廠商統編" />
            <asp:BoundField DataField="mfr_inm"  HeaderText="廠商名稱" />
            <asp:BoundField DataField="cust_nm"  HeaderText="客戶姓名" />
            <asp:BoundField DataField="srspn_cname"  HeaderText="業務員" />
            <asp:BoundField DataField="cont_totamt"  HeaderText="合約總金額" />
            <asp:BoundField DataField="cont_paidamt"  HeaderText="已繳金額" />
            <asp:BoundField DataField="cont_restamt"  HeaderText="剩餘金額" />
            <asp:BoundField DataField="pub_yyyymm"  HeaderText="刊登年月"  ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="pub_pubseq"  HeaderText="落版序號" ItemStyle-ForeColor="Red" />
            <asp:BoundField DataField="pub_imseq"  HeaderText="發廠序號" />
            <asp:BoundField DataField="im_nm"  HeaderText="發廠收件人" ItemStyle-ForeColor="Maroon"/>
            <asp:BoundField DataField="pub_pgno"  HeaderText="刊登頁碼" />
            <asp:BoundField DataField="ltp_nm"  HeaderText="版面" />
            <asp:BoundField DataField="clr_nm"  HeaderText="色彩" />
            <asp:BoundField DataField="pgs_nm"  HeaderText="篇幅" />
            <asp:BoundField DataField="pub_fgfixpg"  HeaderText="固定頁次" />
            <asp:BoundField DataField="pub_drafttp"  HeaderText="稿件類別" />
            <asp:BoundField DataField="njtp_nm"  HeaderText="新稿製法" />
            <asp:BoundField DataField="pub_fggot"  HeaderText="到稿" />
            <asp:BoundField DataField="pub_chgjno"  HeaderText="改稿期別" />
            <asp:BoundField DataField="pub_origjno"  HeaderText="舊稿期別" />
            <asp:BoundField DataField="pub_adamt"  HeaderText="廣告金額" />
            <asp:BoundField DataField="pub_chgamt"  HeaderText="換稿金額" />
            <asp:BoundField DataField="pub_remark"  HeaderText="備註" />
            <asp:BoundField DataField="cont_empno"  HeaderText="業務員工號" />
            <asp:BoundField DataField="pub_imseq"  HeaderText="發廠序號" />
            <asp:BoundField DataField="cont_bkcd"  HeaderText="書籍代碼" />
            <asp:BoundField DataField="bk_nm"  HeaderText="書籍名稱" />
            <asp:BoundField DataField="pub_projno"  HeaderText="計劃代號" />
            <asp:BoundField DataField="pub_costctr"  HeaderText="成本中心" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
    </span>
  


   
    </asp:Panel>

      <div  id="regist_server_id_div">
    <input type="hidden" id="serverID" runat="server" />
    </div>
     <script type="text/javascript">

         (function test() {
             var ddddd = document.forms[0].getElementsByTagName('table');
             var i = 0;
             for (i = 0; i < ddddd.length; i++) {


                 var regist_server_id_div = document.getElementById('regist_server_id_div');
                 var input = regist_server_id_div.getElementsByTagName('input');
                 var value = input[0].value.split(',');

                 var TextBoxID = value[0];
                 var TableID = value[1];
                 if (ddddd[i].id != '' && ddddd[i].id != null) {
                     if (ddddd[i].id.toString().indexOf(TableID) >= 0) {
                         var virtualTbale = ddddd[i];

                         var tr = virtualTbale.getElementsByTagName('tr');

                         var i = 0;
                         var TextBox = document.getElementById(TextBoxID);
                         for (i = 0; i < tr.length; i++) {
                             var e = tr[i];
                             var TbaleDate = e.getAttribute("newDate");
                             if (TextBox.value.replace('/', '') != TbaleDate) {
                                 var td = e.getElementsByTagName('td');
                                 var j = 0;
                                 for (j = 0; j < td.length; j++) {
                                     td[j].style.background = 'Lavender';
                                 }
                             }
                         }
                     }
                 }
             }
         })();

</script>
</asp:Content>
