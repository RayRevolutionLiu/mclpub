<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SAP.aspx.cs" Inherits="mclpub.SetAccount.SAP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function CreateTable(ias_iasdate, ias_iasseq) {
            $.post("SAP.ashx", { ias_iasdate: ias_iasdate, ias_iasseq: ias_iasseq }, function (result) {
                if (result == "Empty") {
                    alert("沒有資料");
                    return;
                }
                else {
                    $("#ShowTable tr").remove();
                    var header = "<tr>";
                    header += "<th>發票開立單編號</th>";
                    header += "<th>統一編號</th>";
                    header += "<th>繳款編號</th>";
                    header += "<th>含稅金額</th>";
                    header += "<th>發票收件人</th>";
                    header += "<th>發票收件人地址</th></tr>";
                    $("#ShowTable").append(header);

                    var content = "";
                    var MoneyCount = 0;
                    for (var i = 0; i < result.length; i++) {
                        content = "<tr>";
                        content += "<td>" + result[i].ia_refno + "</td>";
                        content += "<td>" + result[i].ia_mfrno + "</td>";
                        content += "<td>" + result[i].ia_pyno + "</td>";
                        content += "<td>" + result[i].ia_pyat + "</td>";
                        content += "<td>" + result[i].ia_rnm + "</td>";
                        content += "<td>" + result[i].ia_raddr + "</td>";
                        content += "</tr>";
                        MoneyCount += parseInt(result[i].ia_pyat, 10);
                        $("#ShowTable").append(content);
                    }
                }
                $("#<% =btnPrint.ClientID%>").removeAttr("disabled");


                $("#lblMoney").text(MoneyCount);
                $("#<% =lblyyyymm.ClientID%>").val(ias_iasdate.replace(/(^\s*)|(\s*$)/g, ""));
                $("#<% =lblbatch.ClientID%>").val(ias_iasseq.replace(/(^\s*)|(\s*$)/g, ""));
                //-----------------
                $("#dialogTable").dialog("open");
                return false;
            });
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 發票開立單轉SAP</span>

<table width="100%">
    <tr>
        <td width="50%" align="right">
            <a href="SAPRecovery.aspx"><font color="red">發票開立單轉SAP回復(Recovery)</font></a> &nbsp;&nbsp;
            <a href="../Sys/refm.aspx">轉 SAP 發票摘要檔資料維護</a> &nbsp;&nbsp; <a href="../Sys/refd.aspx">
                轉 SAP 傳票摘要檔資料維護</a>
        </td>
    </tr>
</table>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />查詢結果
            </td>
            <td align="right">
            </td>        
        </tr>
</table>
<span class="stripeMe">
<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True" AllowSorting="true" OnSorting="GVEdit_Sorting">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <input id="DialogAddBtnTable" type="button" value="選取" ias_iasdate='<%# Eval("ias_iasdate") %>' ias_iasseq='<%# Eval("ias_iasseq") %>'
                        class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" onclick="CreateTable(this.getAttribute('ias_iasdate'),this.getAttribute('ias_iasseq'));" />
                </ItemTemplate> 
            </asp:TemplateField>
            <asp:BoundField DataField="ias_syscd"  HeaderText="系統代碼" />
            <asp:BoundField DataField="ias_iasdate"  HeaderText="轉檔年月▲" SortExpression="ias_iasdate" HeaderStyle-ForeColor="White" />
            <asp:BoundField DataField="ias_iasseq"  HeaderText="批次" />
            <asp:BoundField DataField="ias_createdate"  HeaderText="執行轉檔日期" />
            <asp:BoundField DataField="ias_createmen"  HeaderText="轉檔者工號" />
            <asp:BoundField DataField="ias_fgitri"  HeaderText="發票類型" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</span>

<div id="dialogTable" style="text-align: left; display:none;">
    <span class="stripeMe">
    轉檔年月：
    <input id="lblyyyymm" runat="server" type="text" style="background-color:#C0FFC0; border:0; border-style:none;" readonly="readonly" />
    &nbsp;
    批次：
    <input id="lblbatch" runat="server" type="text" style="background-color:#C0FFC0;border:0;border-style:none;" readonly="readonly" />
    &nbsp;
    <asp:Button ID="btnPrint" runat="server" Text="發票開立單轉SAP" disabled="disabled" OnClick="btnPrint_Click"/>
    <table id="ShowTable" border="0" width="100%" cellspacing="0" cellpadding="0">

    </table>
    含稅金額總計：<span id="lblMoney" style="color:Red">0</span>
    </span>
</div>
</asp:Content>
