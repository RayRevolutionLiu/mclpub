<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SAPListEdit.aspx.cs" Inherits="mclpub.SetAccount.SAPListEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function CreateTable(ia_syscd, ia_iasdate, ia_iasseq) {
            $.post("SAPListEdit.ashx", { ia_syscd: ia_syscd, ia_iasdate: ia_iasdate, ia_iasseq: ia_iasseq }, function (result) {
                if (result == "Empty") {
                    alert("沒有資料");
                    return;
                }
                else if (result == "Error") {
                    alert("參數錯誤");
                    return;
                }
                else {
                    $("#ShowTable tr").remove();
                    var header = "<tr>";
                    header += "<th>項次</th>";
                    header += "<th>發票開立單編號</th>";
                    header += "<th>廠商統一編號</th>";
                    header += "<th>廠商名稱</th>";
                    header += "<th>發票號碼</th>";
                    header += "<th>發票日期</th>";
                    header += "<th>往來種類</th>";
                    header += "<th>人工產生註記</th></tr>";
                    $("#ShowTable").append(header);

                    var content = "";
                    var MoneyCount = 0;
                    for (var i = 0; i < result.length; i++) {
                        content = "<tr>";
                        content += "<td>" + result[i].ia_iaitem + "</td>";
                        content += "<td>" + result[i].ia_refno + "</td>";
                        content += "<td>" + result[i].ia_mfrno + "</td>";
                        content += "<td>" + result[i].mfr_inm + "</td>";
                        content += "<td>" + result[i].ia_invno + "</td>";
                        content += "<td>" + result[i].ia_invdate + "</td>";
                        content += "<td>" + result[i].ia_fgitri + "</td>";
                        content += "<td>" + result[i].ia_fgnonauto + "</td>";
                        content += "</tr>";

                        $("#ShowTable").append(content);
                    }
                }
                //-----------------
                $("#dialogTable").dialog("open");
                return false;
            });
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 發票開立清單查詢</span>
    <span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="180" class="font_bold">系統代號：</td>
    <td>
        <asp:DropDownList ID="ddlBookType" runat="server">
        </asp:DropDownList>
    </td>
  </tr>
  <tr>

    <td align="right" width="180" class="font_bold">轉檔年月起訖：</td>
    <td>
        <asp:TextBox ID="tbxSDate" runat="server" Width="60px"></asp:TextBox>
        ~<asp:TextBox ID="tbxEDate" runat="server" Width="60px"></asp:TextBox>
        <asp:label id="lblSEDateMemo" runat="server" ForeColor="Maroon" >(如 2002/06  ～ 2002/12)</asp:label>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" OnClick="CheckBtn_Click"/>
    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>請先輸入要查詢之條件,點擊<span class="font_darkblue">選取</span>挑選要查詢之某一清單以顯示其詳細</li>
</ol>
</span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right"></td>
        </tr>
    </table>
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
            CssClass="font_blacklink font_size13" Width="100%" OnRowDataBound="GridView1_RowDataBound"
             PagerSettings-Visible="false" AllowSorting="true" OnSorting="GVEdit_Sorting">
            <Columns>
                <asp:BoundField DataField="ias_iasid" HeaderText="ID" />
                <asp:BoundField DataField="ias_syscd" HeaderText="系統代碼" />
                <asp:BoundField DataField="ias_iasdateNew" HeaderText="轉檔日期▲" SortExpression="ias_iasdateNew" HeaderStyle-ForeColor="White"/>
                <asp:BoundField DataField="ias_iasseq" HeaderText="批次" />
                <asp:BoundField DataField="ias_toitem" HeaderText="發票開立單數" />
                <asp:BoundField DataField="ias_createdate" HeaderText="產生日" />
                <asp:BoundField DataField="srspn_cname" HeaderText="產生員工" />
                <asp:BoundField DataField="ias_fgitri" HeaderText="往來種類" />
                <asp:BoundField DataField="ias_cancel" HeaderText="註銷" />
                <asp:BoundField DataField="ias_trans_sap" HeaderText="已轉SAP" />
                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                    <input id="DialogAddBtnTable" type="button" value="選取" ias_syscd='<%# Eval("ias_syscd") %>' ias_iasdate='<%# Eval("ias_iasdate") %>' ias_iasseq='<%# Eval("ias_iasseq") %>'
                        class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" onclick="CreateTable(this.getAttribute('ias_syscd'),this.getAttribute('ias_iasdate'),this.getAttribute('ias_iasseq'));" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
        </asp:GridView>
    </span>
    <div id="dialogTable" style="text-align: left; display: none;">
        <span class="stripeMe">
            <table id="ShowTable" border="0" width="100%" cellspacing="0" cellpadding="0">
            </table>
        </span>
    </div>
</asp:Content>
