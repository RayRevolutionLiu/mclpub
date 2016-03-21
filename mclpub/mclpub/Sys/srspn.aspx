<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="srspn.aspx.cs" Inherits="mclpub.Sys.srspn" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
                function ValidateNumber(e, pnumber) {
                    if (!/^\d+$/.test(pnumber)) {
                        $(e).val(/^\d+/.exec($(e).val()));
                    }
                    return false;
                }

        function submitBtn() {
            var srspn_empnoAdd = $('#<% =TextBoxsrspn_empnoAdd.ClientID%>');
            var srspn_cnameAdd = $('#<% =TextBoxsrspn_cnameAdd.ClientID%>');
            var srspn_telAdd = $('#<% =TextBoxsrspn_telAdd.ClientID%>');
            var srspn_atypeAdd = $('#<% =ddlsrspn_atypeAdd.ClientID%> option:selected');
            var OrgAbbNameAdd = $('#<% =ddlOrgAbbNameAdd.ClientID%> option:selected');
            var srspn_deptcdAdd = $('#<% =TextBoxsrspn_deptcdAdd.ClientID%>');
            var srspn_datedAdd = $('#<% =TextBoxsrspn_datedAdd.ClientID%>');

            if (srspn_empnoAdd.val() == "") {
                alert("業務人員工號為必填欄位!");
                return;
            }
            if (srspn_atypeAdd.val() == "") {
                alert("業務人員權限別為必填欄位!");
                return;
            }

            $.post("srspnJudge.aspx", { srspn_empnoAdd: srspn_empnoAdd.val(), srspn_cnameAdd: srspn_cnameAdd.val(), srspn_telAdd: srspn_telAdd.val()
            , srspn_atypeAdd: srspn_atypeAdd.val(), OrgAbbNameAdd: OrgAbbNameAdd.val(), srspn_deptcdAdd: srspn_deptcdAdd.val(), srspn_datedAdd: srspn_datedAdd.val()
            }, function (result) {
                if (result == "No!") {
                    alert('此筆資料已經存在!');
                }
                if (result == "Ok!") {
                    alert('新增成功!');
                    window.location.href = "srspn.aspx";
                }
                if (result == "Error!") {
                    alert('資料錯誤!');
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>
        $(function () {
            $(".ForSrspnDateTime").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yymmdd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天"
});
        });
</script>

    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 管理業務人員</span>
    <span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="90" class="font_bold">關鍵字:</td>
    <td>
        <asp:TextBox ID="TexTBoxKeyWord" runat="server"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="CheckBtn_Click"/>
    </td>
  </tr>
</table>  


<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
    <li>A-應用程式開發者，B-主要業務人員，C-次要業務人員，D–院外業務人員，E–訂戶人員，F-會計人員</li>

</ol>
</span>
<br />
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
        <input id="DialogAddBtn" type="button" value="新增資料" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
            onmouseout="this.className='btn_mouseout'" /></td>
        </tr>
    </table>
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="10"
            CssClass="font_blacklink font_size13" Width="100%" OnRowDataBound="GridView1_RowDataBound"
            AllowPaging="true" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField DataField="srspn_id" HeaderText="ID" />
                <asp:TemplateField HeaderText="業務人員工號">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxsrspn_empno" runat="server" MaxLength="6" Width="50px" Text='<%# Bind("srspn_empno") %>' Visible="false"></asp:TextBox>
                        <asp:Label ID="Labelsrspn_empno" runat="server" Text='<%# Bind("srspn_empno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="業務人員姓名">
                    <ItemTemplate>
                        <asp:Label ID="Labelsrspn_cname" runat="server" Text='<%# Bind("srspn_cname") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxsrspn_cname" runat="server" Width="60px" Visible="false"  Text='<%# Bind("srspn_cname") %>' MaxLength="10">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="業務人員電話">
                    <ItemTemplate>
                        <asp:Label ID="Labelsrspn_tel" runat="server" Text='<%# Bind("srspn_tel") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxsrspn_tel" runat="server" Width="80px" Visible="false"  Text='<%# Bind("srspn_tel") %>' MaxLength="12">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="業務人員權限別">
                    <ItemTemplate>
                        <asp:Label ID="Labelsrspn_atype" runat="server" Text='<%# Bind("srspn_atype") %>'></asp:Label>
                        <asp:DropDownList ID="ddlsrspn_atype" runat="server" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="業務人員單位別">
                    <ItemTemplate>
                        <asp:Label ID="LabelOrgAbbName" runat="server" Text='<%# Bind("OrgAbbName") %>'></asp:Label>
                        <asp:DropDownList ID="ddlOrgAbbName" runat="server" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="業務人員部門別">
                    <ItemTemplate>
                        <asp:Label ID="Labelsrspn_deptcd" runat="server" Text='<%# Bind("srspn_deptcd") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxsrspn_deptcd" runat="server" Width="50px" Visible="false"  Text='<%# Bind("srspn_deptcd") %>' MaxLength="5">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="業務人員註冊日">
                    <ItemTemplate>
                        <asp:Label ID="Labelsrspn_date" runat="server" Text='<%# Bind("srspn_date") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxsrspn_dated" runat="server" Width="70px" Visible="false"  Text='<%# Bind("srspn_date") %>' MaxLength="8" CssClass="ForSrspnDateTime">
                        </asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="(範例:20020101)" ForeColor="#696969" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CausesValidation="false" />
                        <asp:Button ID="SubBtn" runat="server" Text="確定" OnClick="SubBtn_Click" CausesValidation="false"
                            Visible="false" />
                        <asp:Button ID="CancelBtn" runat="server" Text="取消" OnClick="CancelBtn_Click" CausesValidation="false"
                            Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDel" runat="server" Text="刪除" OnClick="btnDel_Click" CausesValidation="false"
                            OnClientClick="javascript:return confirm('確定刪除?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
        </asp:GridView>
    </span>
    <div class="pager font_size13" style="width: 100%">
        <uc3:ucpager id="UCPager1" runat="server" />
    </div>
    <div id="dialog" style="text-align: left; display: none;" title="新增 系統代碼資料維護">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>業務人員工號:
                    </td>                
                    <td>
                        <asp:TextBox ID="TextBoxsrspn_empnoAdd" runat="server" MaxLength="6" Width="55px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        業務人員姓名:
                    </td>
                    <td>
                        <asp:textbox id="TextBoxsrspn_cnameAdd" runat="server" MaxLength="10"  Width="60px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        業務人員電話:
                    </td>
                    <td>
                        <asp:textbox id="TextBoxsrspn_telAdd" runat="server" MaxLength="12"  Width="65px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font> 業務人員權限別:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlsrspn_atypeAdd" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                         業務人員單位別:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOrgAbbNameAdd" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font> 業務人員部門別:
                    </td>
                    <td>
                        <asp:textbox id="TextBoxsrspn_deptcdAdd" runat="server" MaxLength="5"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                         業務人員註冊日:
                    </td>
                    <td>
                        <asp:textbox id="TextBoxsrspn_datedAdd" runat="server" MaxLength="8" onkeyup="return ValidateNumber($(this),value)"  Width="55px" CssClass="ForSrspnDateTime"></asp:textbox>
                    </td>
                </tr>
            </table>
        </span>
        <div style="text-align: right">
            <input id="Button1" type="button" value="新增資料" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
                onmouseout="this.className='btn_mouseout'" onclick="submitBtn()" />
        </div>
    </div>
</asp:Content>

