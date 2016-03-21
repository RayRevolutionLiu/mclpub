<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proj.aspx.cs" Inherits="mclpub.Sys.proj" MasterPageFile="~/MasterPage.Master"  MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content ContentPlaceHolderID="head" runat="server" ID="Content2">
    <script>
//        function ValidateNumber(e, pnumber) {
//            if (!/^\d+$/.test(pnumber)) {
//                $(e).val(/^\d+/.exec($(e).val()));
//            }
//            return false;
//        }

        function submitBtn() {
            var sys_nm = $('#<% =ddlsys_nm.ClientID%> option:selected');
            var bk_nm = $('#<% =ddlbk_nm.ClientID%> option:selected');
            var fgitri_nm = $('#<% =ddlfgitri_nm.ClientID%> option:selected');
            var proj_projno = $('#<% =TextBoxproj_projno.ClientID%>');
            var proj_costctr = $('#<% =TextBoxproj_costctr.ClientID%>');
            var proj_cont = $('#<% =TextBoxproj_cont.ClientID%>');

            if (sys_nm.val() == "") {
                alert("系統代碼名稱為必填欄位!");
                return;
            }
            if (proj_projno.val() == "") {
                alert("計畫代號為必填欄位!");
                return;
            }

            $.post("projJudge.aspx", { sys_nm: sys_nm.val(), bk_nm: bk_nm.val(), fgitri_nm: fgitri_nm.val()
            , proj_projno: proj_projno.val(), proj_costctr: proj_costctr.val(), proj_cont: proj_cont.val()
            }, function (result) {
                if (result == "No!") {
                    alert('此筆資料已經存在!');
                }
                if (result == "Ok!") {
                    alert('新增成功!');
                    window.location.href = "proj.aspx";
                }
                if (result == "Error!") {
                    alert('資料錯誤!');
                }
            });
        }
    </script>

</asp:Content>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 計畫代號維護</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th>查詢條件</th>
  </tr>
  <tr>

    <td align="left" class="font_bold">
        <asp:TextBox ID="tbxQString" runat="server" Width="96px"></asp:TextBox>
        &nbsp;<asp:DropDownList ID="ddlQueryField" runat="server">
            <asp:ListItem Selected="True" Value="proj_projno">計劃代號</asp:ListItem>
            <asp:ListItem Value="proj_costctr">成本中心</asp:ListItem>
            <asp:ListItem Value="sys_nm">系統代碼名稱</asp:ListItem>
            <asp:ListItem Value="proj_bkcd">書籍代碼</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="Query" runat="server" Text="查詢"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="Query_Click"/>
        <input id="DialogAddBtn" type="button" value="新增資料" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
            onmouseout="this.className='btn_mouseout'" />
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
    <asp:GridView ID="ContGV" runat="server" Width="99%" AutoGenerateColumns="false" CssClass="font_blacklink font_size13" OnRowDataBound="ContGVOnRowDataBound" AllowPaging="true" PagerSettings-Visible="false">
    <Columns>
    <asp:BoundField DataField="proj_projid" HeaderText="ID" />
    <asp:TemplateField HeaderText="系統代碼名稱">
        <ItemTemplate>
            <asp:DropDownList ID="ddlsys_nm" runat="server" Visible="false">
            </asp:DropDownList>
            <asp:Label ID="Labelsys_nm" runat="server" Text='<%# Bind("sys_nm") %>'></asp:Label>
         </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="書籍名稱">
        <ItemTemplate>
            <asp:DropDownList ID="ddlbk_nm" runat="server" Visible="false">
            </asp:DropDownList>
            <asp:Label ID="Labelbk_nm" runat="server" Text='<%# Bind("bk_nm") %>'></asp:Label>
         </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="院所內往來註記">
        <ItemTemplate>
            <asp:DropDownList ID="ddlfgitri_nm" runat="server" Visible="false">
            </asp:DropDownList>
            <asp:Label ID="Labelfgitri_nm" runat="server" Text='<%# Bind("fgitri_nm") %>'></asp:Label>
         </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="計劃代號">
        <ItemTemplate>
            <asp:TextBox ID="TextBoxproj_projno" runat="server" MaxLength="10" Width="100px" Text='<%# Bind("proj_projno") %>' Visible="false"></asp:TextBox>
            <asp:Label ID="Labelproj_projno" runat="server" Text='<%# Bind("proj_projno") %>'></asp:Label>
         </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="成本中心">
        <ItemTemplate>
            <asp:TextBox ID="TextBoxproj_costctr" runat="server" MaxLength="7" Width="67px" Text='<%# Bind("proj_costctr") %>' Visible="false"></asp:TextBox>
            <asp:Label ID="Labelproj_costctr" runat="server" Text='<%# Bind("proj_costctr") %>'></asp:Label>
         </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="工作說明">
        <ItemTemplate>
            <asp:TextBox ID="TextBoxproj_cont" runat="server" MaxLength="12" Width="100px" Text='<%# Bind("proj_cont") %>' Visible="false"></asp:TextBox>
            <asp:Label ID="Labelproj_cont" runat="server" Text='<%# Bind("proj_cont") %>'></asp:Label>
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
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />  
 </div>

 <div id="dialog" style="text-align: left; display: none;" title="新增 新增計劃代號資料">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>系統代碼名稱:
                    </td>                
                    <td>
                        <asp:DropDownList ID="ddlsys_nm" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        書籍名稱:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlbk_nm" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        院所內往來註記:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlfgitri_nm" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font> 計劃代號:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxproj_projno" runat="server" MaxLength="10" Width="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                         成本中心:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxproj_costctr" runat="server" MaxLength="7" Width="67px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                         工作說明:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxproj_cont" runat="server" MaxLength="12" Width="100px"></asp:TextBox>
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
