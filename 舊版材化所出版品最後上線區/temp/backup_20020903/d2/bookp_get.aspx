<%@ Page language="c#" Codebehind="bookp_get.aspx.cs" Src="bookp_get.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.bookp_get" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>書籍期別之參考資料</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// <IMG class="ico" title="書籍期別參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		function doGetBookp(obj)
		{
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
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<!-- Run at Server Form -->
		<form id="bookp_get" method="post" target="_self" runat="server">
			<!-- 操作說明 --><font color="blue" size="2">操作說明：預設資料為 <font color="darkred">填入刊登年月之當年度</font>.</font>
			<br>
			<FONT color="blue" size="2">請按下 "<FONT color="darkred"><U>關閉視窗</U></FONT>" 按鈕, 
				來確認挑選"!</FONT>
			<br>
			<!-- DataGrid 開始 --><asp:datagrid id="DataGrid1" runat="server" ItemStyle-HorizontalAlign="Center" AllowPaging="False" PageSize="12" BackColor="White" BorderColor="Black" BorderStyle="None" AutoGenerateColumns="False">
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
				<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
				<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
				<ItemStyle BackColor="#BFCFF0"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="bkp_date" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="bkp_pno" HeaderText="書籍期別"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<!-- 備註說明 -->
			<font color="gray" size="2">註: 紅色字體為<font color="darkred">系統年月</font>的資料.</font>
			<br>
			<font color="gray" size="2">註: 藍色字體為<font color="darkred">搜尋結果</font>, 將帶回.</font>
			<br>
			<br>
			<!-- 關閉視窗按鈕 -->
			<INPUT id="btn_close" onclick="Javascript: doGetBookp();" type="button" value="關閉視窗" name="btn_close" Height="18px">
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
		<SCRIPT language="javascript">
		<!--
		// 自前一頁, 抓 MyObject
		var oMyObject = window.dialogArguments;
		
		// 自前一頁, 抓出其相關資料
		//alert("oMyObject.bkcd= " + oMyObject.bkcd);
		//alert("oMyObject.ym= " + oMyObject.ym);
		
		-->
		</SCRIPT>
	</body>
</HTML>
