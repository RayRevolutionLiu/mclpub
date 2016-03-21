<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayListPrint.aspx.cs" Inherits="mclpub.Pay.PayListPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function CreateTable(pys_pysdate, pys_pysseq, pytp_nm) {
        $.post("PayListPrintGen.ashx", { pys_pysdate: pys_pysdate, pys_pysseq: pys_pysseq }, function (result) {
            if (result == "Empty") {
                alert("沒有資料");
                return;
            }
            else {
                $("#ShowTable tr").remove();
                var header = "<tr>";
                header += "<th>繳款編號</th>";
                header += "<th>繳款日期</th>";
                header += "<th>金額</th>";
                header += "<th>繳款清單產生年月</th>";
                header += "<th>繳款清單批次</th>";
                header += "<th>繳款清單項次</th>";
                header += "<th>劃撥單批號</th>";
                header += "<th>項次</th>";
                header += "<th>票據號碼</th>";
                header += "<th>付款行</th>";
                header += "<th>到期日</th>";
                header += "<th>電匯帳號</th>";
                header += "<th>匯入日期</th>";
                header += "<th>金融代碼</th>";
                header += "<th>信用卡卡號</th>";
                header += "<th>授權碼</th>";
                header += "<th>有效年月</th></tr>";
                $("#ShowTable").append(header);

                var content = "";
                for (var i = 0; i < result.length; i++) {
                    content = "<tr>";
                    content += "<td>" + result[i].py_pyno + "</td>";
                    content += "<td>" + result[i].py_date + "</td>";
                    content += "<td>" + result[i].py_amt + "</td>";
                    content += "<td>" + result[i].py_pysdate + "</td>";
                    content += "<td>" + result[i].py_pysseq + "</td>";
                    content += "<td>" + result[i].py_pysitem + "</td>";
                    content += "<td>" + result[i].py_moseq + "</td>";
                    content += "<td>" + result[i].py_moitem + "</td>";
                    content += "<td>" + result[i].py_chkno + "</td>";
                    content += "<td>" + result[i].py_chkbnm + "</td>";
                    content += "<td>" + result[i].py_chkdate + "</td>";
                    content += "<td>" + result[i].py_waccno + "</td>";
                    content += "<td>" + result[i].py_wdate + "</td>";
                    content += "<td>" + result[i].py_wbcd + "</td>";
                    content += "<td>" + result[i].py_ccno + "</td>";
                    content += "<td>" + result[i].py_ccauthcd + "</td>";
                    content += "<td>" + result[i].py_ccvdate + "</td>";
                    content += "</tr>";
                    $("#ShowTable").append(content);
                }
            }
            $("#btnPrint").removeAttr("disabled");
            //ajax匯出Excel參數
            $("#hdpytp_nm").val(pytp_nm.replace(/(^\s*)|(\s*$)/g, ""));
            $("#lblyyyymm").val(pys_pysdate.replace(/(^\s*)|(\s*$)/g, ""));
            $("#lblbatch").val(pys_pysseq.replace(/(^\s*)|(\s*$)/g, ""));
            //-----------------
            $("#dialogTable").dialog("open");
            return false;
        });
    }
</script>
<script>
    function ExportExcel() {
        var pytp_nm = $("#hdpytp_nm").val();
        var lblyyyymm = $("#lblyyyymm").val();
        var lblbatch = $("#lblbatch").val();
        window.location.href = "PayListPrintExcel.aspx?pytp_nm=" + pytp_nm + "&lblyyyymm=" + lblyyyymm + "&lblbatch=" + lblbatch + "";
//        $.post("PayListPrintExcel.aspx", { pytp_nm: pytp_nm, lblyyyymm: lblyyyymm, lblbatch: lblbatch }, function (result) {

//        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 繳款處理 / 列印繳款清單</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="left" class="font_bold" style="width:120px">清單產生年月：
      </td>
      <td>

          <asp:DropDownList ID="ddlYear" runat="server">
          </asp:DropDownList>
          年<asp:DropDownList ID="ddlMonth" runat="server">
              <asp:ListItem Value="01">1</asp:ListItem>
              <asp:ListItem Value="02">2</asp:ListItem>
              <asp:ListItem Value="03">3</asp:ListItem>
              <asp:ListItem Value="04">4</asp:ListItem>
              <asp:ListItem Value="05">5</asp:ListItem>
              <asp:ListItem Value="06">6</asp:ListItem>
              <asp:ListItem Value="07">7</asp:ListItem>
              <asp:ListItem Value="08">8</asp:ListItem>
              <asp:ListItem Value="09">9</asp:ListItem>
              <asp:ListItem Value="10">10</asp:ListItem>
              <asp:ListItem Value="11">11</asp:ListItem>
              <asp:ListItem Value="12">12</asp:ListItem>
          </asp:DropDownList>
          月</td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
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
    <asp:GridView ID="DataGrid1" runat="server" Width="99%" 
        AutoGenerateColumns="false" CssClass="font_blacklink font_size13">
    <Columns>
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>    
        <input id="DialogAddBtnTable" type="button" value="選取" pys_pysdate='<%# Eval("pys_pysdate") %>' pys_pysseq='<%# Eval("pys_pysseq") %>' pytp_nm='<%# Eval("pytp_nm") %>'
        class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" onclick="CreateTable(this.getAttribute('pys_pysdate'),this.getAttribute('pys_pysseq'),this.getAttribute('pytp_nm'));" />
    </ItemTemplate>
    </asp:TemplateField>    
    <asp:BoundField DataField="pys_pysdate" HeaderText="產生年月" />
    <asp:BoundField DataField="pys_pysseq" HeaderText="批次" />
    <asp:BoundField DataField="pys_toitem" HeaderText="總項次" />
    <asp:BoundField DataField="pytp_nm" HeaderText="付款方式" />
    <asp:BoundField DataField="pys_createdate" HeaderText="建立日期" />
    <asp:BoundField DataField="pys_createmen" HeaderText="建立者" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
    <div id="dialogTable" style="text-align: left; display:none;">
        <span class="stripeMe">
        產生年月：
         <input id="lblyyyymm" type="text" value="0" style="color:Purple; background-color:#C0FFC0; border:0" readonly="readonly" />
        &nbsp;
        批次：
        <input id="lblbatch" type="text" value="0" style="color:Purple; background-color:#C0FFC0;border:0" readonly="readonly" />
        &nbsp;

        <input id="btnPrint" type="button" value="列印繳款清單" class="btn_mouseout"
         onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" 
         onclick="ExportExcel();" disabled="disabled" />
        <input id="hdpytp_nm" type="hidden"  /><!--ajax 用來下載EXCEL傳送過去的付款方式種類-->
        <table id="ShowTable" border="0" width="100%" cellspacing="0" cellpadding="0">

        </table>
        </span>
    </div>

</asp:Content>
