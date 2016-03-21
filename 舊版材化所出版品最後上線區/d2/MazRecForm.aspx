<%@ Page language="c#" Codebehind="MazRecForm.aspx.cs" src="MazRecForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.MazRecForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>所有雜誌收件人資料</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO1, DSO2, DSO3 -->
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSO3" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<BODY>
		<form id="MazRecForm" method="post" runat="server">
			<!-- 雜誌收件人參考資料 -->
			<label style="FONT-SIZE: x-small; COLOR: #ff0066">[雜誌收件人參考資料]</label> 
			<!-- 顯示歷史資料-雜誌收件人的 table (id=table1  dataSrc=#DSO3) -->
			<TABLE id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR borderColor="#bfcff0" bgColor="#bfcff0">
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small"></font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">公司名稱</font>
						</TH>
						<TH width="65px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">姓名</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">職稱</font>
						</TH>
						<TH width="35px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">郵遞
								<br>
								區號</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">地址</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">電話</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">傳真</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">手機</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">Email</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">郵寄類別</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">有登
								<br>
								本數</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">未登
								<br>
								本數</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">海外
								<br>
								郵寄</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD>
							<IMG class="ico" title="加入雜誌收件人" onclick="doCopy(this)" height="14" src="../images/copy.gif" border="0">
						</TD>
						<TD>
							<span dataFld="雜誌收件人公司名稱" dataFormatAs="html"></span>
						</TD>
						<TD>
							<span dataFld="雜誌收件人姓名" dataFormatAs="html"></span>
						</TD>
						<TD>
							<div dataFld="雜誌收件人職稱" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="雜誌收件人郵遞區號" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="雜誌收件人地址">
							</div>
						</TD>
						<TD>
							<div dataFld="雜誌收件人電話" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="雜誌收件人傳真" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="雜誌收件人手機" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="雜誌收件人Email">
							</div>
						</TD>
						<TD>
							<div dataFld="郵寄類別代碼">
							</div>
						</TD>
						<TD>
							<div dataFld="有登本數">
							</div>
						</TD>
						<TD>
							<div dataFld="未登本數">
							</div>
						</TD>
						<TD>
							<div dataFld="海外郵寄註記">
							</div>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="doAddNew()" type="button" value="新增雜誌收件人">
			<br>
			<FONT color="#c00000" size="2">註1：* 為必填欄位!</FONT>
			<br>
			<font size="2" color="#c00000">註2：公司名稱及地址資料預設同廠商地址資料; 如需修改, 請自行增修!</font>
			<br>
			<font color="#c00000" size="2">請填入相關資料(姓名), 並選擇正確的 "郵寄類別 (海外郵寄註記)"!</font>
			<br>
			<!-- 新增雜誌收件人的 table (id=table2  dataSrc=#DSO2) -->
			<TABLE id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0">
				<THEAD bgColor="#4a3c8c">
					<TR>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">刪除</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">序
								<br>
								號</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* 公司名稱</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* 姓名</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">職稱</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">郵遞
								<br>
								區號</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">地址</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">電話</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">傳真</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">手機</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">Email</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">郵寄類別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">有登
								<br>
								本數</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">未登
								<br>
								本數</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">海外
								<br>
								郵寄</font>
						</TH>
					</TR>
				</THEAD>
				<tbody bgColor="#e7e7ff">
					<TR>
						<TD>
							<IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
						</TD>
						<TD>
							<label dataFld="雜誌收件人序號" id="lblOrItem"></label>
						</TD>
						<TD>
							<input dataFld="雜誌收件人公司名稱" id="tbxOrCompanyName" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrCompanyName">
						</TD>
						<TD>
							<input dataFld="雜誌收件人姓名" id="tbxOrName" style="WIDTH: 55px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrName">
						</TD>
						<TD>
							<input dataFld="雜誌收件人職稱" id="tbxOrJobTitle" style="WIDTH: 40px; HEIGHT: 22px" type="text" maxLength="12" size="1" name="tbxOrJobTitle">
						</TD>
						<TD>
							<input dataFld="雜誌收件人郵遞區號" id="tbxOrZipcode" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="5" size="1" name="tbxOrZipcode">
						</TD>
						<TD>
							<TEXTAREA dataFld="雜誌收件人地址" id="tbxORAddr" name="tbxORAddr" rows="3" cols="20" style="WIDTH: 110px">
							</TEXTAREA>
						</TD>
						<TD>
							<input dataFld="雜誌收件人電話" id="tbxOrTel" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrTel">
						</TD>
						<TD>
							<input dataFld="雜誌收件人傳真" id="tbxOrFax" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrFax">
						</TD>
						<TD>
							<input dataFld="雜誌收件人手機" id="tbxOrCellular" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrCellular">
						</TD>
						<TD>
							<input dataFld="雜誌收件人Email" id="tbxOrEmail" style="WIDTH: 55px; HEIGHT: 22px" type="text" maxLength="80" size="1" name="tbxOrEmail">
						</TD>
						<TD>
							<SELECT dataFld="郵寄類別代碼" id="ddlORMailTypeCode" onafterupdate="doSelectORMailType(this)" name="ddlORMailTypeCode" runat="server"></SELECT>
						</TD>
						<TD>
							<input dataFld="有登本數" id="tbxOrPubCount" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="3" size="1" name="tbxOrPubCount">
						</TD>
						<TD>
							<input dataFld="未登本數" id="tbxOrUnpubCount" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="3" size="1" name="tbxOrUnpubCount">
						</TD>
						<TD>
							<SELECT dataFld="海外郵寄註記" id="ddlfgMailOversea" name="ddlfgMailOversea" runat="server" disabled>
								<OPTION value="0" selected>
									國內</OPTION>
								<OPTION value="1">
									國外</OPTION></SELECT>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="SelectOK()" type="button" value="新增完畢回前頁"> <INPUT id="hidden_xml" type="hidden" name="hidden_xml" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<br>
			<!-- 此 TEXTAREA 是供檢查 XML 輸出檢查用 -->
			<!--TEXTAREA id="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
			<br>
		</form>
		<SCRIPT language="javascript">
		<!--
		// 自前一頁, 抓 MyObject
		var oMyObject = window.dialogArguments;
		//alert(oMyObject.xmldata);
		
		// 呼叫 MazRec.xml 檔
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.async = false; 
		xmlDoc1.load("MazRec.xml");
		//alert(xmlDoc1.xml);
		
		var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("雜誌收件人明細");
		//alert(xmlNewItems.xml);
		
		// 預設指定 雜誌收件人廠商抬頭 = 公司名稱, 雜誌收件人地址 = 公司地址, 雜誌收件人郵遞區號 = 公司郵遞區號
		// 將傳過來的 MyObject.變數 預設給 所有新增行(含第一行) 的相對應欄位
		xmlNewItems.selectSingleNode("系統代碼").text=oMyObject.Syscd;
		xmlNewItems.selectSingleNode("合約書編號").text=oMyObject.ContNo;
		xmlNewItems.selectSingleNode("雜誌收件人公司名稱").text=oMyObject.MfrName;
		xmlNewItems.selectSingleNode("雜誌收件人地址").text=oMyObject.MfrAddress;
		xmlNewItems.selectSingleNode("雜誌收件人郵遞區號").text=oMyObject.MfrZipcode;
		xmlNewItems.selectSingleNode("雜誌收件人電話").text=oMyObject.MfrTel;
		xmlNewItems.selectSingleNode("雜誌收件人傳真").text=oMyObject.MfrFax;
		xmlNewItems.selectSingleNode("雜誌收件人職稱").text=oMyObject.CustJobTitle;
		//alert(oMyObject.MfrName);
		//alert(xmlNewItems.xml);
		
		
		// 請參 新增雜誌收件人的 table (id=table1  dataSrc=#DSO3)
		// 抓出供挑選雜誌收件人的歷史資料 or 新增新的雜誌收件人 (若無歷史資料, 則直接新增)
		var xmlDoc3 = DSO3.XMLDocument;
		xmlDoc3.async = false;
		if(oMyObject.flag)
			xmlDoc3.loadXML(oMyObject.prexmldata);
		else
		{
			document.all("table1").style.visibility="hidden";
		}
		//alert(oMyObject.prexmldata.xml);
		var xmlItems3 = xmlDoc3.selectSingleNode("雜誌收件人資料");
		
		
		// 請參 新增完畢回前頁的 table (id=table2  dataSrc=#DSO2)
		var xmlDoc2 = DSO2.XMLDocument;
		xmlDoc2.async = false;
		xmlDoc2.loadXML(oMyObject.xmldata);
		
		var xmlItems = xmlDoc2.selectSingleNode("雜誌收件人資料");
		xmlItems.childNodes.item(0).selectSingleNode("合約書編號").text=oMyObject.ContNo;
		//alert("xmlItems.xml= " + xmlItems.xml);
		
		// 若新增的第一行無資料, 則給預設值
		xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人序號").text="01";
		if(xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人姓名").text=="")
		{
			xmlItems.childNodes.item(0).selectSingleNode("系統代碼").text=oMyObject.Syscd;
			xmlItems.childNodes.item(0).selectSingleNode("合約書編號").text=oMyObject.ContNo;
			xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人公司名稱").text=oMyObject.MfrName;
			xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人地址").text=oMyObject.MfrAddress;
			xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人郵遞區號").text=oMyObject.MfrZipcode;
			xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人電話").text=oMyObject.MfrTel;
			xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人傳真").text=oMyObject.MfrFax;
			xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人職稱").text=oMyObject.CustJobTitle;
		}
		

		function doAddNew(){
			var idx = xmlItems.childNodes.length;
			//alert("idx= " + idx);

			// cloneNode 新增一行空白行
			var newNode = xmlNewItems.cloneNode(true);
			//alert("newNode= " + newNode.xml);
			xmlItems.appendChild(newNode);
			
			// 每新增一行空白行時, 顯示該新行之序號
			var	j1=String(idx+1);
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(idx).selectSingleNode("雜誌收件人序號").text=j1;
			}
			else
				xmlItems.childNodes.item(idx).selectSingleNode("雜誌收件人序號").text=idx+1;
		}
		
		
		function doDelete(obj){
			var idx = obj.recordNumber-1;
			var oldNode = xmlItems.childNodes.item(idx);
			if(xmlItems.childNodes.length <= 1)
				{
					var newNode = xmlNewItems.cloneNode(true);
					xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
				}
			oldNode.parentNode.removeChild(oldNode);
			
			// 每刪除一行, 重新顯示序號
			for(i=0; i<xmlItems.childNodes.length;i++)
			{
				j1=String(i+1);
				if(j1.length==1){
					j1="0"+j1;
					xmlItems.childNodes.item(i).selectSingleNode("雜誌收件人序號").text=j1;
				}
				else
					xmlItems.childNodes.item(i).selectSingleNode("雜誌收件人序號").text=i+1;
			}

		}
		
		
		function doCopy(obj){
			var idx = obj.recordNumber-1;
			var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
			if(xmlItems.firstChild.childNodes.item(1).text=="")
				xmlItems.replaceChild(newNode, xmlItems.firstChild);
			else
				xmlItems.appendChild(newNode);
			
			// 每複製一行, 重新顯示序號
			var idx1 = xmlItems.childNodes.length;
			var	j1=String(idx1);
			//alert("j1= " + j1);
			//alert("雜誌收件人序號= " + xmlItems.childNodes.item(0).selectSingleNode("雜誌收件人序號").text);
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(idx1-1).selectSingleNode("雜誌收件人序號").text=j1;
			}
			else
				xmlItems.childNodes.item(idx1-1).selectSingleNode("雜誌收件人序號").text=idx1;
		}
			
			
		function SelectOK(obj){
			// 下行是為做檢查 XML 之用途
			//window.document.all("textarea1").value=xmlItems.xml;
			
			// 檢查 必填欄位 是否有填
			var idx = xmlItems.childNodes.length;
			for(i=0; i<idx;i++)
			{				
				// 雜誌收件人公司名稱
				if(xmlItems.childNodes.item(i).selectSingleNode("雜誌收件人公司名稱").text=="")  {
					var k=i+1;
					alert("第" + k + "筆的公司名稱不可空白");
					return;	}

				// 雜誌收件人姓名
				if(xmlItems.childNodes.item(i).selectSingleNode("雜誌收件人姓名").text=="")  {
					var m=i+1;
					alert("第" + m + "筆的雜誌收件人姓名不可空白");
					return;	}
			}
			
			
			// 傳回 XML 值並關閉視窗
			oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
			//alert("oMyObject.result= " + oMyObject.result.xml);
			window.returnValue = true;
			window.close();
		}
		
		
		function doSelectORMailType(obj)
		{
			// 若 郵寄類別代碼的值 > 20 表示為寄到海外, 則海外郵寄註記之值應郵寄類別代碼應改為 1 (預設為 0)
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			strbuf = xmlItems.childNodes.item(idx).selectSingleNode("郵寄類別代碼").text;
			//alert("strbuf= " + strbuf);
			
			//顯示海外郵寄註記之值
			if(strbuf>20)
				xmlItems.childNodes.item(idx).selectSingleNode("海外郵寄註記").text = 1;
			else
				xmlItems.childNodes.item(idx).selectSingleNode("海外郵寄註記").text = 0;
			
			// 下行是為做檢查 XML 之用途
			//window.document.all("textarea1").value=xmlItems.xml;
		}
		-->
		</SCRIPT>
	</BODY>
</HTML>
