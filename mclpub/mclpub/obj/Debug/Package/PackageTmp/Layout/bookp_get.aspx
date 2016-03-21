<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookp_get.aspx.cs" Inherits="mclpub.Layout.bookp_get" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>書籍期別之參考資料</title>
</head>
<body>
		<!-- 頁首 Header -->
		<!-- Run at Server Form -->
		<form id="bookp_get" method="post" target="_self" runat="server">
			<!-- 操作說明 -->
			<font color="blue" size="2">操作說明：預設資料為 <font color="darkred">填入刊登年月之當年度</font>.</font>
			<br>
			<FONT color="blue" size="2">請按下<span class="font_darkblue">關閉視窗</span>按鈕, 
				來確認挑選"!</FONT>
			<br />
            <span class="stripeMe">
			<!-- DataGrid 開始 -->
			<asp:datagrid id="DataGrid1" runat="server" PageSize="12"  BorderStyle="None" AutoGenerateColumns="False" UseAccessibleHeader="true"
            CssClass="font_blacklink font_size13" Font-Size="X-Small">
				<Columns>
					<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="bkp_date" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="bkp_pno" HeaderText="書籍期別"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
            </span>
			<!-- 備註說明 -->
			<font color="gray" size="2">註: 藍色字體為<font color="darkred">搜尋結果</font>, 將帶回.</font>
			<br>
			<br>
			<!-- 關閉視窗按鈕 -->
			<INPUT id="btn_close" onclick="Javascript:doGetBookp();" type="button" value="關閉視窗" name="btn_close"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
			&nbsp;
			<asp:label id="lblMessage" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<asp:label id="lblYYYYMM" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<asp:label id="lblGetBookPNo" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<INPUT id="hiddenBookPNo" type="hidden" size="3" name="hiddenBookPNo" runat="server">
			<INPUT id="hiddenYYYYMM" type="hidden" size="6" name="hiddenYYYYMM" runat="server">
			<br>
		</form>
		<!-- 頁尾 Footer -->
		<!-- Javascript -->
	</body>

		<script language="javascript">
		<!--
		    // <IMG class="ico" title="書籍期別參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		    function doGetBookp(obj) {
		        //alert("hiddenBookPNo.Value= " + document.all("hiddenBookPNo").value);

		        // 傳回值並關閉視窗
		        oMyObject.result = document.all("hiddenBookPNo").value;
		        oMyObject.yyyymm = document.all("hiddenYYYYMM").value;
		        //alert("oMyObject.result= " + oMyObject.result);
		        //alert("oMyObject.yyyymm= " + oMyObject.yyyymm);

		        window.returnValue = true;
		        window.close();
		    }
		//-->
		</script>
        		<SCRIPT language="javascript">
		<!--
        		    // 自前一頁, 抓 MyObject
        		    var oMyObject = window.dialogArguments;

        		    // 自前一頁, 抓出其相關資料
        		    //alert("oMyObject.bkcd= " + oMyObject.bkcd);
        		    //alert("oMyObject.ym= " + oMyObject.ym);
		
		-->
		</SCRIPT>
</html>
