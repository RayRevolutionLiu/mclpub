<%@ Page language="c#" Codebehind="adpub_detail.aspx.cs" Src="adpub_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廣告落版刊登資料之細節資訊</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO2 -->
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<!-- 標題 -->
		<DIV align="left">
			<B><FONT color="darkblue" size="4">落版細節資訊</FONT></B>&nbsp; <STRONG><FONT color="#00008b" size="4">
					－ <INPUT id="tbxContMessage" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: gray; BORDER-RIGHT-WIDTH: 0px" readOnly type="text" maxLength="100" size="50" name="tbxContMessage">&nbsp;<INPUT id="tbxPubMessage" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: gray; BORDER-RIGHT-WIDTH: 0px" readOnly type="text" maxLength="300" size="100" name="tbxPubMessage">&nbsp;
				</FONT></STRONG>
		</DIV>
		<br>
		<!-- Run at Server Form -->
		<form id="adpub_detail" method="post" runat="server">
			<!-- Table 開始: 細節資訊 -->
			<!-- 新增雜誌收件人的 table (id=table2  dataSrc=#DSO2) -->
			<TABLE id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0">
				<THEAD bgColor="#4a3c8c">
					<TR>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">落版
								<br>
								廣告
								<br>
								金額</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">換稿
								<br>
								金額</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">已開立
								<br>
								發票
								<br>
								註記</font>
							<br>
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: xx-small; COLOR: yellow">(0: 否, 1:是)</FONT>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">發票
								<br>
								開立單
								<br>
								人工
								<br>
								處理
								<br>
								註記</font>
							<br>
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: xx-small; COLOR: yellow">(0: 否, 1:是)</FONT>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">備註</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">稿件類別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">舊稿書籍
								<br>
								類別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">舊稿
								<br>
								期別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">舊稿
								<br>
								頁碼</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">改稿書籍
								<br>
								類別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">改稿
								<br>
								期別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">改稿
								<br>
								頁碼</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">改稿
								<br>
								重出片
								<br>
								註記</font>
							<br>
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: xx-small; COLOR: yellow">(0: 否, 1:是)</FONT>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">新稿
								<br>
								製法 </font>
						</TH>
					</TR>
				</THEAD>
				<tbody bgColor="#e7e7ff">
					<TR>
						<TD>
							$ <input dataFld="落版廣告金額" id="tbxAdAmunt" style="WIDTH: 40px" type="text" maxLength="10" size="10" name="tbxAdAmunt">
						</TD>
						<TD>
							$ <input dataFld="換稿金額" id="tbxChangeAmunt" style="WIDTH: 40px" type="text" maxLength="10" size="10" name="tbxChangeAmunt">
						</TD>
						<TD>
							&nbsp; <input dataFld="已開立發票單註記" id="tbxfgInvCode" onblur="Javascript:CheckValue2(this);" style="WIDTH: 30px; COLOR: gray" readOnly type="text" maxLength="1" size="1" name="tbxfgInvCode">
						</TD>
						<TD>
							&nbsp; <input dataFld="發票開立單人工處理註記" id="tbxfgInvSelf" onblur="Javascript:CheckValue3(this);" style="WIDTH: 30px; COLOR: gray" readOnly type="text" maxLength="1" size="1" name="tbxfgInvSelf">
						</TD>
						<TD>
							<input dataFld="備註" id="tbxPubRemark" style="WIDTH: 65px" type="text" maxLength="255" size="10" name="tbxPubRemark">
						</TD>
						<TD>
							<SELECT dataFld="稿件類別代碼" id="ddlDraftTypeCode" onchange="Javascript:OnChangeddlDraftTypeCode(this);" name="ddlDraftTypeCode" runat="server">
								<OPTION value="1" selected>
									舊稿</OPTION>
								<OPTION value="2">
									新稿</OPTION>
								<OPTION value="3">
									改稿</OPTION></SELECT>
						</TD>
						<TD>
							<SELECT dataFld="舊稿書籍代碼" id="ddlOrigBookCode" name="ddlOrigBookCode" runat="server"></SELECT>
						</TD>
						<TD>
							<input dataFld="舊稿期別" id="tbxOrigJNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxOrigJNo">
						</TD>
						<TD>
							<input dataFld="舊稿頁碼" id="tbxOrigPageNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxOrigPageNo">&nbsp;<IMG class="ico" title="頁碼參考資料" src="../images/edit.gif" border="0" onclick="doGetPgNo1(this)">
						</TD>
						<TD>
							<SELECT dataFld="改稿書籍代碼" id="ddlChgBookCode" name="ddlChgBookCode" runat="server" disabled></SELECT>
						</TD>
						<TD>
							<input dataFld="改稿期別" id="tbxChangeJNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxChangeJNo" readonly>
						</TD>
						<TD>
							<input dataFld="改稿頁碼" id="tbxChgPageNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxChgPageNo">&nbsp;<IMG class="ico" title="頁碼參考資料" src="../images/edit.gif" border="0" onclick="doGetPgNo2(this)">
						</TD>
						<TD>
							&nbsp; <input dataFld="改稿重出片註記" id="tbxfgReChange" onblur="Javascript:CheckValue4(this);" style="WIDTH: 30px" type="text" maxLength="1" size="1" name="tbxfgReChange">
						</TD>
						<TD>
							<SELECT dataFld="新稿製法代碼" id="ddlNJTypeCode" onchange="Javascript:CheckValue5(this);" name="ddlNJTypeCode" runat="server"></SELECT>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="EditPubOk()" type="button" value="新增完畢回前頁"> <input type="reset" value="清除資料" name="ClearAll">
			&nbsp; <INPUT id="hidden_xml" style="WIDTH: 65px" type="hidden" size="5" name="hidden_xml" runat="server">
			<br>
			<asp:label id="Label1" runat="server" ForeColor="#C00000" Font-Size="X-Small">說明：按下 "<SPAN style="COLOR: black; BACKGROUND-COLOR: #CDC9C9">
					新增完畢回前頁</SPAN>" 來確認帶回畫面上的資料; 按下 "<SPAN style="COLOR: black; BACKGROUND-COLOR: #CDC9C9">清除資料</SPAN>" 來清除所有資料.</asp:label>
			<br>
			<asp:label id="Label2" runat="server" ForeColor="#C00000" Font-Size="X-Small">註：先輸入期別, 再按下 '<U>
					舊稿頁碼/改稿頁碼 </U>'旁的圖示按鈕 <IMG class="ico" title="頁碼參考資料" src="../images/edit.gif" border="0"> 可帶回預設值! 如需修改, 請自行增訂!</asp:label>
			<br>
			<!-- 此 TEXTAREA 是供檢查 XML 輸出檢查用 -->
			<!--TEXTAREA id="textarea1" name="textarea1" rows="16" cols="80"--> <!--/TEXTAREA-->
		</form>
		<!-- 頁尾 Footer -->
		<!-- Javascript -->
		<SCRIPT language="javascript">
		<!--
		// 自前一頁, 抓 MyObject
		var oMyObject = window.dialogArguments;
		
		// 自前一頁, 抓出其相關資料, 並顯示在標題處 tbxContMessage & tbxPubMessage 裡
		//alert(oMyObject.xmldata);
		//alert("oMyObject.TotalPubSeq= " + oMyObject.TotalPubSeq);
		//alert("oMyObject.tottm= " + oMyObject.tottm);
		//alert("oMyObject.totjtm= " + oMyObject.totjtm);
		//alert("oMyObject.chgjtm= " + oMyObject.chgjtm);
		//alert("oMyObject.hiddenTotalJTime= " + oMyObject.hiddenTotalJTime);
		//alert("myObject.old_contno= " + myObject.old_contno);
		//alert("oMyObject.pubseq= " + oMyObject.pubseq);
		//alert("oMyObject.yyyymm= " + oMyObject.yyyymm);
		//alert("oMyObject.bkpno= " + oMyObject.bkpno);
		//alert("oMyObject.pgno= " + oMyObject.pgno);
		//alert("oMyObject.fgfixpage= " + oMyObject.fgfixpage);
		//alert("oMyObject.clrcd= " + oMyObject.clrcd);
		//alert("oMyObject.pgscd= " + oMyObject.pgscd);
		//alert("oMyObject.ltpcd= " + oMyObject.ltpcd);
		//alert("tbxPubMessage= " + window.document.all("tbxPubMessage").value);
		//alert("tbxContMessage= " + window.document.all("tbxContMessage").value);
		
		// 序號
		var tempPubMessage = "落版序號: " + oMyObject.pubseq;
		
		// 刊登年月
		if(oMyObject.yyyymm!="")
			tempPubMessage = tempPubMessage + ", 刊登年月: " + oMyObject.yyyymm;
		else
			tempPubMessage = tempPubMessage;
		
		// 書籍期別
		if(oMyObject.bkpno!="")
			tempPubMessage = tempPubMessage + ", 書籍期別: " + oMyObject.bkpno;
		else
			tempPubMessage = tempPubMessage;

		// 刊登頁碼
		if(oMyObject.pgno!="")
				tempPubMessage = tempPubMessage + ", 刊登頁碼: " + oMyObject.pgno;
		else
			tempPubMessage = tempPubMessage;
		
		// 固定頁次註記
		if(oMyObject.fgfixpage!="")  {
			if(oMyObject.fgfixpage==0)
				tempPubMessage = tempPubMessage;
			else if(oMyObject.fgfixpage==1)
				tempPubMessage = tempPubMessage + " (指定固定頁次)";
		}
		else
			tempPubMessage = tempPubMessage;
		
		// 廣告色彩代碼
		if(oMyObject.clrcd!="")
		{
			var clrcd = parseInt(oMyObject.clrcd);
			var clrtext = "";
			
			// 將值轉為文字
			switch(clrcd)
			{
				case 1:
						clrtext = "彩色";
						break;
				case 2:
						clrtext = "黑白";
						break;
				case 3:
						clrtext = "套色";
						break;
				default:
						clrtext = "彩色";
						break;
			}
			tempPubMessage = tempPubMessage + ", " + clrtext;
		}
		else
			tempPubMessage = tempPubMessage;
		
		// 廣告篇幅代碼
		if(oMyObject.pgscd!="")
		{
			var pgscd = parseInt(oMyObject.pgscd);
			var pgstext = "";
			
			// 將值轉為文字
			switch(pgscd)
			{
				case 1:
						pgstext = "全頁";
						break;
				case 2:
						pgstext = "半頁";
						break;
				default:
						pgstext = "全頁";
						break;
			}
			tempPubMessage = tempPubMessage + ", " + pgstext;
		}
		else
			tempPubMessage = tempPubMessage;
		
		// 廣告版面代碼
		if(oMyObject.ltpcd!="")
		{
			var ltpcd = parseInt(oMyObject.ltpcd);
			var ltptext = "";
			
			// 將值轉為文字
			switch(ltpcd)
			{
				case 1:
						ltptext = "封面";
						break;
				case 2:
						ltptext = "封面裡頁";
						break;
				case 3:
						ltptext = "封底";
						break;
				case 4:
						ltptext = "封底裡頁";
						break;
				case 5:
						ltptext = "首頁";
						break;
				case 6:
						ltptext = "內頁";
						break;
				default:
						ltptext = "內頁";
						break;
			}
			tempPubMessage = tempPubMessage + ", " + ltptext;
		}
		else
			tempPubMessage = tempPubMessage;
		
		
		var tempContMessage = "";
		// 總刊登次數
		if(oMyObject.tottm!="")
			tempContMessage = tempContMessage + "合約書 - 總刊登次數: " + oMyObject.tottm;
		else
			tempContMessage = tempContMessage;
		
		// 總製稿次數
		if(oMyObject.totjtm!="")
			tempContMessage = tempContMessage + ", 總製稿次數: " + oMyObject.totjtm;
		else
			tempContMessage = tempContMessage;
		
		// 換稿次數
		if(oMyObject.chgjtm!="")
			tempContMessage = tempContMessage + ", 換稿次數: " + oMyObject.chgjtm;
		else
			tempContMessage = tempContMessage;
		
		// 將搜尋之資訊, 輸出至 tbxPubMessage
		window.document.all("tbxContMessage").value = tempContMessage;
		window.document.all("tbxPubMessage").value = tempPubMessage;
		
		
		// 請參 新增完畢回前頁的 table (id=table2  dataSrc=#DSO2)
		var xmlDoc2 = DSO2.XMLDocument;
		xmlDoc2.async = false;
		//alert(oMyObject.value.xml);
		xmlDoc2.loadXML(oMyObject.xmldata);
		
		var xmlPubDetails = xmlDoc2.selectSingleNode("落版細節");
		//alert(xmlPubDetails.xml);
		
			// ** 以下 coding 與 OnChangeddlDraftTypeCode(obj) 雷同 **
			// 注意: 下一行抓之值, 是由 xml 而來, 並非由 window.document.all("ddlDraftTypeCode").value 而來, 此為與 OnChangeddlDraftTypeCode(obj) 不同處
			var ddlDraftTypeCodeResult = parseInt(xmlPubDetails.selectSingleNode("稿件類別代碼").text);
			//alert("ddlDraftTypeCodeResult= "  + ddlDraftTypeCodeResult);
			
			switch(ddlDraftTypeCodeResult)
			{
			// 1. 為舊稿時, 清除 "改稿相關資料 & 新稿相關資料"
			case 1: {
					window.document.all("ddlDraftTypeCode").value = '1';
					// 重新開啟該稿件之屬性
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// 關閉其他屬性
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("改稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("改稿期別").text='';
					xmlPubDetails.selectSingleNode("改稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿重出片註記").text='';
					xmlPubDetails.selectSingleNode("新稿製法代碼").text='';
					break;  }
			
			// 2. 為新稿時, 清除 "改稿相關資料 & 舊稿相關資料"
			case 2: {
					window.document.all("ddlDraftTypeCode").value = '2';
					// 關閉其他屬性
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					window.document.all("ddlChgBookCode").value = '';
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					// 重新開啟該稿件之屬性
					window.document.all("ddlNJTypeCode").disabled = false;
					// 清除其他屬性之 xml 資料
					xmlPubDetails.selectSingleNode("舊稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("舊稿期別").text='';
					xmlPubDetails.selectSingleNode("舊稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("改稿期別").text='';
					xmlPubDetails.selectSingleNode("改稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿重出片註記").text='';
					break;  }
			
			// 3. 為改稿時, 清除 "新稿相關資料 & 舊稿相關資料"
			case 3: {
					window.document.all("ddlDraftTypeCode").value = '3';
					// 關閉其他屬性
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					// 重新開啟該稿件之屬性
					window.document.all("ddlChgBookCode").disabled = false;
					window.document.all("tbxChangeJNo").readOnly = false;
					window.document.all("tbxChgPageNo").readOnly = false;
					window.document.all("tbxfgReChange").readOnly = false;
					window.document.all("tbxfgReChange").value = '0';
					// 關閉其他屬性
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					// 清除其他屬性之 xml 資料
					xmlPubDetails.selectSingleNode("舊稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("舊稿期別").text='';
					xmlPubDetails.selectSingleNode("舊稿頁碼").text='';
					xmlPubDetails.selectSingleNode("新稿製法代碼").text='';
					break;  }			
			
			}		
		// -->
		</SCRIPT>
		<SCRIPT language="javascript">
		<!-- 
		//檢查輸入之各註記的值, 是否等於 0 或 1
		
		//檢查輸入之 "已開立發票單註記" 的值是否正確
		function CheckValue2(obj){ 
			if(window.document.all("tbxfgInvCode").value==0)
				window.document.all("tbxfgInvCode").value=0;
			else if(window.document.all("tbxfgInvCode").value==1)
				window.document.all("tbxfgInvCode").value=1;
			else {
				alert("您輸入 已開立發票單註記的值 是錯誤的, 請重新輸入");
				window.document.all("tbxfgInvCode").focus(); }

		}
		
		//檢查輸入之 "發票開立單人工處理註記" 的值是否正確
		function CheckValue3(obj){ 
			if(window.document.all("tbxfgInvSelf").value==0)
				window.document.all("tbxfgInvSelf").value=0;
			else if(window.document.all("tbxfgInvSelf").value==1)
				window.document.all("tbxfgInvSelf").value=1;
			else {
				alert("您輸入 發票開立單人工處理註記的值 是錯誤的, 請重新輸入");
				window.document.all("tbxfgInvSelf").focus(); }

		}

		//檢查輸入之 "改稿重出片註記" 的值是否正確
		function CheckValue4(obj){ 
			if(window.document.all("tbxfgReChange").value==0)
				window.document.all("tbxfgReChange").value=0;
			else if(window.document.all("tbxfgReChange").value==1)
				window.document.all("tbxfgReChange").value=1;
			else {
				alert("您輸入 改稿重出片註記的值 是錯誤的, 請重新輸入");
				window.document.all("tbxfgReChange").focus(); }
		}
		
		//選 "新稿製法代碼"時, 清除 "改稿重出片註記" 的值
		function CheckValue5(obj){ 
				window.document.all("tbxfgReChange").value='';
		}
		//-->
		</SCRIPT>
		<SCRIPT language="javascript">
		<!-- 
			// 依不同稿件類別的值, 則清除不同選項畫面上的值與其XML實際值
			// (如若非新稿, 則一定要清除新稿製法代碼的值及其它相關值=>為空值)
			// 主要是處理畫面上值的顯示及其值的正確性
		function OnChangeddlDraftTypeCode(obj){
			var ddlDraftTypeCodeResult = window.document.all("ddlDraftTypeCode").value;
			//alert("ddlDraftTypeCodeResult= "  + ddlDraftTypeCodeResult);
			
			// 抓出 合約書細節之 '總製稿次數' & '換稿次數', 剩餘總製稿次數 Resttottm
			var totjtm = parseInt(oMyObject.totjtm);
			var chgjtm = parseInt(oMyObject.chgjtm);
			// 抓出目前 剩餘之總製稿次數 oMyObject.hiddenTotalJTime
			var hiddenTotalJTime = parseInt(oMyObject.hiddenTotalJTime);
			
			// 1. 為舊稿時, 清除 "改稿相關資料 & 新稿相關資料"
			if(ddlDraftTypeCodeResult==1) {
					window.document.all("ddlDraftTypeCode").value = '1';
					// 重新開啟該稿件之屬性
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// 關閉其他屬性
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("改稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("改稿期別").text='';
					xmlPubDetails.selectSingleNode("改稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿重出片註記").text='';
					xmlPubDetails.selectSingleNode("新稿製法代碼").text='';
				}
			
			// 2. 為新稿時, 清除 "改稿相關資料 & 舊稿相關資料"
			else if(ddlDraftTypeCodeResult==2) {
					var RestTime = hiddenTotalJTime -1;
					if(RestTime>=0)
						alert("您選擇 新稿!\n\n '總製稿次數' 還剩 " + RestTime + " 次可用, \n '換稿次數' 還剩 " + RestTime + " 次可用!");
					else  {
						alert("新稿次數已用完, 請確認是否換稿!");
						window.document.all("ddlDraftTypeCode").value = '1';
						//return;
					}
					
					window.document.all("ddlDraftTypeCode").value = '2';
					// 關閉其他屬性
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					window.document.all("ddlChgBookCode").value = '';
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					// 重新開啟該稿件之屬性
					window.document.all("ddlNJTypeCode").disabled = false;
					// 清除其他屬性之 xml 資料
					xmlPubDetails.selectSingleNode("舊稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("舊稿期別").text='';
					xmlPubDetails.selectSingleNode("舊稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("改稿期別").text='';
					xmlPubDetails.selectSingleNode("改稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿重出片註記").text='';
				}
			
			// 3. 為改稿時, 清除 "新稿相關資料 & 舊稿相關資料"
			else if (ddlDraftTypeCodeResult==3) {
					var RestTime = hiddenTotalJTime -1;
					if(RestTime>=0)
						alert("您選擇 改稿!\n\n '總製稿次數' 還剩 " + RestTime + " 次可用, \n '換稿次數' 還剩 " + RestTime + " 次可用!");
					else  {
						alert("改稿次數已用完, 請確認是否換稿!");
						window.document.all("ddlDraftTypeCode").value = '1';
						//return;
					}
					
					window.document.all("ddlDraftTypeCode").value = '3';
					// 關閉其他屬性
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					// 重新開啟該稿件之屬性
					window.document.all("ddlChgBookCode").disabled = false;
					window.document.all("tbxChangeJNo").readOnly = false;
					window.document.all("tbxChgPageNo").readOnly = false;
					window.document.all("tbxfgReChange").readOnly = false;
					window.document.all("tbxfgReChange").value = '0';
					// 關閉其他屬性
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					// 清除其他屬性之 xml 資料
					xmlPubDetails.selectSingleNode("舊稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("舊稿期別").text='';
					xmlPubDetails.selectSingleNode("舊稿頁碼").text='';
					xmlPubDetails.selectSingleNode("新稿製法代碼").text='';
				}
			
			// 將 剩餘之總製稿次數 回寫至 oMyObject.hiddenTotalJTime, 以傳回前一頁(須再次寫回至該頁之 hiddenTotalJTime.Value)
			oMyObject.hiddenTotalJTime = RestTime;
						
		}
		//-->
		</SCRIPT>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="舊稿頁碼參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別, 再抓出其刊登頁碼
		// 此段與下段同, 只是 window.showModalDialog 裡的顯示位置 & vreturn 之 xml 不同而已
		function doGetPgNo1(obj)
		{
			// 傳入 廠商統編 & 舊稿期別, 來參考列出該廠商 曾刊登(並寫回)之所有落版資料
			// 做為輸入 舊稿期別 / 改稿期別 時, 自動動出 舊稿頁碼 / 改稿頁碼 查詢結果
			var mfrno = oMyObject.mfrno;
			var bkpno = document.all("tbxOrigJNo").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// 開啟視窗對話框, 最後將值傳入 oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, oMyObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:10px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				//document.all("tbxOrigJNo").value = oMyObject.bkpno;
				//xmlPubDetails.selectSingleNode("舊稿期別").text = oMyObject.bkpno;
				xmlPubDetails.selectSingleNode("舊稿頁碼").text = oMyObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="改稿頁碼參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別, 再抓出其刊登頁碼
		// 此段與上段同, 只是 window.showModalDialog 裡的顯示位置 & vreturn 之 xml 不同而已
		function doGetPgNo2(obj)
		{
			// 傳入 廠商統編 & 舊稿期別, 來參考列出該廠商 曾刊登(並寫回)之所有落版資料
			// 做為輸入 舊稿期別 / 改稿期別 時, 自動動出 舊稿頁碼 / 改稿頁碼 查詢結果
			var mfrno = oMyObject.mfrno;
			var bkpno = document.all("tbxChangeJNo").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// 開啟視窗對話框, 最後將值傳入 oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, oMyObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:170px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				//document.all("tbxChangeJNo").value = oMyObject.bkpno;
				//xmlPubDetails.selectSingleNode("改稿期別").text = oMyObject.bkpno;
				xmlPubDetails.selectSingleNode("改稿頁碼").text = oMyObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
		<SCRIPT language="javascript">
		<!-- 
		//新增完畢回前頁的按鈕
		function EditPubOk(obj)  {
			// 透過 textarea 來檢查輸出的 XML 是否正確
			//window.document.all("textarea1").value=xmlPubDetails.xml;
			
			// 判斷 PageLoad 時, 稿件類別為何類別, 不顯示其他類別的資料 (即清除非相關資料)
			// ** 以下 coding 與 OnChangeddlDraftTypeCode(obj) 雷同 **
			// 注意: 下一行抓之值, 是由 xml 而來, 並非由 window.document.all("ddlDraftTypeCode").value 而來, 此為與 OnChangeddlDraftTypeCode(obj) 不同處
			var ddlDraftTypeCodeResult = parseInt(xmlPubDetails.selectSingleNode("稿件類別代碼").text);
			//alert("ddlDraftTypeCodeResult= "  + ddlDraftTypeCodeResult);
			
			switch(ddlDraftTypeCodeResult)
			{
			// 1. 為舊稿時, 清除 "改稿相關資料 & 新稿相關資料"
			case 1: {
					window.document.all("ddlDraftTypeCode").value = '1';
					// 重新開啟該稿件之屬性
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// 關閉其他屬性
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("改稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("改稿期別").text='';
					xmlPubDetails.selectSingleNode("改稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿重出片註記").text='';
					xmlPubDetails.selectSingleNode("新稿製法代碼").text='';
					break;  }

			// 2. 為新稿時, 清除 "改稿相關資料 & 舊稿相關資料"
			case 2: {
					window.document.all("ddlDraftTypeCode").value = '2';
					// 關閉其他屬性
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					window.document.all("ddlChgBookCode").value = '';
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					// 重新開啟該稿件之屬性
					window.document.all("ddlNJTypeCode").disabled = false;
					// 清除其他屬性之 xml 資料
					xmlPubDetails.selectSingleNode("舊稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("舊稿期別").text='';
					xmlPubDetails.selectSingleNode("舊稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("改稿期別").text='';
					xmlPubDetails.selectSingleNode("改稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿重出片註記").text='';
					break;  }
						
			// 3. 為改稿時, 清除 "新稿相關資料 & 舊稿相關資料"
			case 3: {
					window.document.all("ddlDraftTypeCode").value = '3';
					// 關閉其他屬性
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					// 重新開啟該稿件之屬性
					window.document.all("ddlChgBookCode").disabled = false;
					window.document.all("tbxChangeJNo").readOnly = false;
					window.document.all("tbxChgPageNo").readOnly = false;
					window.document.all("tbxfgReChange").readOnly = false;
					window.document.all("tbxfgReChange").value = '0';
					// 關閉其他屬性
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					// 清除其他屬性之 xml 資料
					xmlPubDetails.selectSingleNode("舊稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("舊稿期別").text='';
					xmlPubDetails.selectSingleNode("舊稿頁碼").text='';
					xmlPubDetails.selectSingleNode("新稿製法代碼").text='';
					break;  }
			
			// 預設為: 舊稿
			default: {
					window.document.all("ddlDraftTypeCode").value = '1';
					// 重新開啟該稿件之屬性
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// 關閉其他屬性
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("改稿書籍代碼").text='';
					xmlPubDetails.selectSingleNode("改稿期別").text='';
					xmlPubDetails.selectSingleNode("改稿頁碼").text='';
					xmlPubDetails.selectSingleNode("改稿重出片註記").text='';
					xmlPubDetails.selectSingleNode("新稿製法代碼").text='';
					break;  }
			}
			
			
			
			// 傳回 XML 值並關閉視窗
			oMyObject.result = xmlPubDetails;
			//alert("oMyObject.result= " + oMyObject.result.xml);
			window.returnValue = true; 
			window.close(); 
		}
		//-->
		</SCRIPT>
	</body>
</HTML>
