<%@ Page language="c#" Codebehind="pubpgno_get.aspx.cs" Src="pubpgno_get.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.pubpgno_get" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>刊登頁碼之參考資料</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// <IMG class="ico" title="刊登頁碼參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		function doGetPgNo(obj)
		{
			//alert("hiddenPageNo.Value= " + document.all("hiddenPageNo").value);
			
			// 傳回值並關閉視窗
			oMyObject.bkpno = document.all("hiddenBookPNo").value;
			oMyObject.pgno = document.all("hiddenPageNo").value;
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			window.returnValue = true; 
			window.close();
		}
		//-->
		</script>
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<!-- Run at Server Form -->
		<form id="pubpgno_get" method="post" runat="server">
			<!-- 操作說明 -->
			<font color="blue" size="2">操作說明：預設資料為 <FONT color="#8b0000">該廠商 第一筆之已落版(寫回)之資料</FONT>.</font>
			<br>
			<FONT color="blue" size="2">按下 "<FONT color="darkred"><U>關閉視窗</U></FONT> " 將帶回預設值 
				(如需其他筆, 請自行記下修改)!</FONT>
			<br>
			<!-- DataGrid 開始 -->
			<asp:datagrid id="DataGrid1" runat="server" ItemStyle-HorizontalAlign="Center" PageSize="12" BackColor="White" BorderColor="Black" BorderStyle="None" AutoGenerateColumns="False">
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
				<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
				<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Center" BackColor="#BFCFF0"></ItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="pub_syscd" ReadOnly="True" HeaderText="系統代碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_contno" HeaderText="當期合約書編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pno" HeaderText="當期書籍期別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="當期刊登頁碼"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<!-- 備註說明 -->
			<font color="gray" size="2">註: 紅色字體為<font color="darkred">將帶回</font>之預設值資料.</font>
			<br>
			<br>
			<!-- 關閉視窗按鈕 -->
			<INPUT id="btn_close" onclick="Javascript: doGetPgNo();" type="button" value="關閉視窗" name="btn_close" Height="18px">
			&nbsp;
			<asp:label id="lblMessage" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<asp:label id="lblMfrNo" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<br>
			<asp:label id="lblGetPageNo" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label>
			<INPUT id="hiddenMfrNo" type="hidden" size="7" name="hiddenOldContNo" runat="server">
			<INPUT id="hiddenBookPNo" type="hidden" size="6" name="hiddenBookPNo" runat="server">
			<INPUT id="hiddenPageNo" type="hidden" size="4" name="hiddenPageNo" runat="server">
		</form>
		<!-- Javascript -->
		<SCRIPT language="javascript">
		<!--
		// 自前一頁, 抓 MyObject
		var oMyObject = window.dialogArguments;
		
		// 自前一頁, 抓出其相關資料
		//alert("oMyObject.mfrno= " + oMyObject.mfrno);	
		//alert("oMyObject.bkpno= " + oMyObject.bkpno);	
		-->
		</SCRIPT>
	</body>
</HTML>
