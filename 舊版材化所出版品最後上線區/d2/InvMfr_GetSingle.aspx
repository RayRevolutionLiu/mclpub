<%@ Page language="c#" Codebehind="InvMfr_GetSingle.aspx.cs" Src="InvMfr_GetSingle.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvMfr_GetSingle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>顯示所有 發票廠商收件人 資料</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- JavaScript -->
		<script language="JavaScript">
		function WindowClose() 
		{ 
			// 傳回值並關閉視窗
			//oMyObject.IMSeq = document.all("tbxIMseq").value;
			//oMyObject.IMName = document.all("tbxIMName").value;
			//alert("oMyObject.IMSeq= " + oMyObject.IMSeq);
			//alert("oMyObject.IMName= " + oMyObject.IMName);
			
			//window.returnValue = true; 
			window.close();
		}
		
		function NewWindow() 
		{ 
			// 傳回值並關閉視窗
			var contno = document.all("hiddenContNo").value;
			var custno = document.all("hiddenCustNo").value;
			var old_contno = document.all("hiddenOldContNo").value;
			var fgnew = document.all("hiddenfgnew").value;
			var winName = "InvMfrForm.aspx?contno=" + contno + "&custno=" + custno + "&old_contno=" + old_contno + "&fgnew=" + fgnew + "&fmnm=ContFm_modify";
			
			var winfeatures = "'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no'";
			window.open(winName, '_new', winfeatures);
		}
		</script>
	</HEAD>
	<body>
		<form id="InvMfr_GetSingle" method="post" runat="server">
			<!-- 已新增 發票廠商收件人資料 區 -->
			<FONT color="#ff0066" size="2">[已新增 發票廠商收件人資料 區]&nbsp;&nbsp;
				<asp:label id="lblCountMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label>
			</FONT>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_addr" HeaderText="發票地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<!-- 修改資料之連結 -->
			<FONT color="#c00000" size="2">註一：如果您要增修資料, 請按</FONT> <INPUT id="btnGoLink" style="COLOR: blue; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; TEXT-DECORATION: underline; BORDER-BOTTOM-STYLE: none" onclick="Javascript:NewWindow();" type="button" value="此處" name="btnGoLink">.&nbsp;
			<br>
			<FONT color="#c00000" size="2">註二：如果您修改了收件人姓名, 或新增/刪除了收件人資料, 回到落版畫面時, 請按下收件人旁的 '<U>重新整理<img src="../images/refresh.gif" border="0"></U>' 
				來抓取最新資料.</FONT>
			<br>
			<INPUT id="hiddenContNo" type="hidden" name="hiddenContNo" runat="server" style="WIDTH: 50px">
			<INPUT id="hiddenCustNo" style="WIDTH: 50px" type="hidden" name="hiddenCustNo" runat="server">
			<INPUT id="hiddenOldContNo" style="WIDTH: 50px" type="hidden" name="hiddenOldContNo" runat="server">
			<INPUT id="hiddenfgnew" style="WIDTH: 30px" type="hidden" name="hiddenfgnew" runat="server">
			<br>
			<INPUT id="btnClose" onclick="Javascript:WindowClose();" type="button" value="關閉視窗" name="btnClose">
			<br>
			<!-- 操作說明 --><FONT color="blue" size="2">按下 "<FONT color="darkred"><U>關閉視窗</U></FONT>" 
				按鈕, 來結束!</FONT>
			<br>
		</form>
		<!-- Javascript -->
		<SCRIPT language="javascript">
		<!--
		// 自前一頁, 抓 MyObject
		//var oMyObject = window.dialogArguments;
		
		// 自前一頁, 抓出其相關資料
		//alert("oMyObject.syscd= " + oMyObject.syscd);
		//alert("oMyObject.contno= " + oMyObject.contno);
		-->
		</SCRIPT>
	</body>
</HTML>
