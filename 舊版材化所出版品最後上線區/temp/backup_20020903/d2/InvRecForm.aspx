<%@ Page language="c#" Codebehind="InvRecForm.aspx.cs" Src="InvRecForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvRecForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>所有發票收件人資料</TITLE>
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
	<body>
		<form id="InvRecForm" method="post" runat="server">
			<!-- 發票收件人參考資料 -->
			<label style="FONT-SIZE: x-small; COLOR: #ff0066">[發票收件人參考資料]</label> 
			<!-- 顯示歷史資料-發票收件人的 table (id=table1  dataSrc=#DSO3) -->
			<TABLE id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR borderColor="#bfcff0" bgColor="#bfcff0">
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small"></font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">序號</font>
						</TH>
						<TH width="30px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">系統
								<br>
								代碼</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">合約書
								<br>
								編號</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">廠商
								<br>
								統編</font>
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
						<TH width="30px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">發票
								<br>
								類別</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">發票
								<br>
								課稅別</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">院所內
								<br>
								註記</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD>
							<IMG class="ico" title="加入發票收件人" onclick="doCopy(this)" height="14" src="../images/copy.gif" border="0">
						</TD>
						<TD>
							<span dataFld="發票廠商序號" dataFormatAs="html"></span>
						</TD>
						<TD>
							<span dataFld="系統代碼"></span>
						</TD>
						<TD>
							<span dataFld="合約書編號"></span>
						</TD>
						<TD>
							<span dataFld="發票收件人廠商統編"></span>
						</TD>
						<TD>
							<span dataFld="發票收件人姓名"></span>
						</TD>
						<TD>
							<div dataFld="發票收件人職稱" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="發票收件人郵遞區號" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="發票收件人地址">
							</div>
						</TD>
						<TD>
							<div dataFld="發票收件人電話" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="發票收件人傳真" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="發票收件人手機" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="發票收件人Email">
							</div>
						</TD>
						<TD>
							<div dataFld="發票類別代碼">
							</div>
						</TD>
						<TD>
							<div dataFld="發票課稅別代碼">
							</div>
						</TD>
						<TD>
							<div dataFld="院所內註記">
							</div>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="doAddNew()" type="button" value="新增發票收件人">
			<br>
			<FONT color="#c00000" size="2">註1：* 為必填欄位!</FONT>
			<br>
			<FONT color="#c00000" size="2">註2：公司名稱及地址資料預設同廠商地址資料; 如需修改, 請自行增修!</FONT>
			<br>
			<font color="#c00000" size="2">請填入相關資料(姓名), 並選擇正確的 "發票類別 / 發票課稅別 / 院所內註記"!</font>
			<br>
			<!-- 新增雜誌收件人的 table (id=table2  dataSrc=#DSO2) -->
			<TABLE id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0">
				<THEAD bgColor="#4a3c8c">
					<TR>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">刪除</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">序號</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">系統
								<br>
								代碼</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">合約書
								<br>
								編號</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* 廠商
								<br>
								&nbsp;&nbsp;統編</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* 姓名</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">職稱</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* 郵遞
								<br>
								區號</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* 地址</font>
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
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">發票
								<br>
								類別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">發票
								<br>
								課稅別</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">院所內
								<br>
								註記</font>
						</TH>
					</TR>
				</THEAD>
				<tbody bgColor="#e7e7ff">
					<TR>
						<TD>
							<IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
						</TD>
						<TD>
							<label dataFld="發票廠商序號" id="lblIMItem"></label>
						</TD>
						<TD>
							<input dataFld="系統代碼" id="tbxIMSysCode" style="WIDTH: 30px" type="text" maxLength="2" size="1" name="tbxIMSysCode" disabled>
						</TD>
						<TD>
							<input dataFld="合約書編號" id="tbxIMContNo" style="WIDTH: 50px" type="text" maxLength="6" size="1" name="tbxIMContNo" disabled>
						</TD>
						<TD>
							<input dataFld="發票收件人廠商統編" id="tbxIMMfrNo" style="WIDTH: 65px" type="text" maxLength="10" size="1" name="tbxIMMfrNo">
						</TD>
						<TD>
							<input dataFld="發票收件人姓名" id="tbxIMName" style="WIDTH: 55px" type="text" maxLength="30" size="1" name="tbxIMName">
						</TD>
						<TD>
							<input dataFld="發票收件人職稱" id="tbxIMJobTitle" style="WIDTH: 40px" type="text" maxLength="12" size="1" name="tbxIMJobTitle">
						</TD>
						<TD>
							<input dataFld="發票收件人郵遞區號" id="tbxIMZipcode" style="WIDTH: 35px" type="text" maxLength="5" size="1" name="tbxIMZipcode">
						</TD>
						<TD>
							<TEXTAREA dataFld="發票收件人地址" id="tbxIMAddr" name="tbxIMAddr" rows="3" cols="20" style="WIDTH: 110px">
							</TEXTAREA>
						</TD>
						<TD>
							<input dataFld="發票收件人電話" id="tbxIMTel" style="WIDTH: 65px" type="text" maxLength="30" size="1" name="tbxIMTel">
						</TD>
						<TD>
							<input dataFld="發票收件人傳真" id="tbxIMFax" style="WIDTH: 50px" type="text" maxLength="30" size="1" name="tbxIMFax">
						</TD>
						<TD>
							<input dataFld="發票收件人手機" id="tbxIMCellular" style="WIDTH: 50px" type="text" maxLength="30" size="1" name="tbxIMCellular">
						</TD>
						<TD>
							<input dataFld="發票收件人Email" id="tbxIMEmail" style="WIDTH: 50px" type="text" maxLength="80" size="1" name="tbxIMEmail">
						</TD>
						<TD>
							<SELECT dataFld="發票類別代碼" id="SelIMInvCode" name="SelIMInvCode" runat="server">
								<OPTION value="2">
									二聯</OPTION>
								<OPTION value="3" selected>
									三聯</OPTION>
								<OPTION value="4">
									其他</OPTION></SELECT>
						</TD>
						<TD>
							<SELECT dataFld="發票課稅別代碼" id="SelIMTaxType" name="SelIMTaxType" runat="server">
								<OPTION value="1" selected>
									應稅5%</OPTION>
								<OPTION value="2">
									零稅</OPTION>
								<OPTION value="3">
									免稅</OPTION></SELECT>
						</TD>
						<TD>
							<SELECT dataFld="院所內註記" id="SelIMfgItri" name="SelIMfgItri" runat="server">
								<OPTION value="" selected>
									否</OPTION>
								<OPTION value="06">
									所內</OPTION>
								<OPTION value="07">
									院內</OPTION>
							</SELECT>
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
		
		// 呼叫 InvRec.xml 檔
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.async = false; 
		xmlDoc1.load("InvRec.xml");
		//alert(xmlDoc1.xml);
		
		var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("發票廠商收件人明細");
		//alert(xmlNewItems.xml);
		
		// 預設指定 發票收件人廠商抬頭 = 公司名稱, 發票收件人地址 = 公司地址, 發票收件人郵遞區號 = 公司郵遞區號
		// 將傳過來的 MyObject.變數 預設給 所有新增行(含第一行) 的相對應欄位
		xmlNewItems.selectSingleNode("系統代碼").text=oMyObject.Syscd;
		xmlNewItems.selectSingleNode("合約書編號").text=oMyObject.ContNo;
		// 以下幾個傳過來的值: 因在本網頁新增發票收件人時(每行資料須不同), 不須出現相同資料, 故暫 disable 起來
		xmlNewItems.selectSingleNode("發票收件人廠商統編").text=oMyObject.MfrNo;;
		//xmlNewItems.selectSingleNode("發票收件人廠商抬頭").text=oMyObject.MfrName;
		xmlNewItems.selectSingleNode("發票收件人地址").text=oMyObject.MfrAddress;
		xmlNewItems.selectSingleNode("發票收件人郵遞區號").text=oMyObject.MfrZipcode;
		xmlNewItems.selectSingleNode("發票收件人電話").text=oMyObject.MfrTel;
		xmlNewItems.selectSingleNode("發票收件人傳真").text=oMyObject.MfrFax;
		xmlNewItems.selectSingleNode("發票收件人職稱").text=oMyObject.CustJobTitle;	
		//alert(oMyObject.ContNo);
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
		var xmlItems3 = xmlDoc3.selectSingleNode("發票廠商資料");
		
		
		// 請參 新增完畢回前頁的 table (id=table2  dataSrc=#DSO2)
		var xmlDoc2 = DSO2.XMLDocument;
		xmlDoc2.async = false;
		xmlDoc2.loadXML(oMyObject.xmldata);
		
		var xmlItems = xmlDoc2.selectSingleNode("發票廠商資料");
		//alert("xmlItems.xml= " + xmlItems.xml);
		
		// 若新增的第一行無資料, 則給預設值
		xmlItems.childNodes.item(0).selectSingleNode("發票廠商序號").text="01";
		if(xmlItems.childNodes.item(0).selectSingleNode("發票收件人姓名").text=="")
		{
			xmlItems.childNodes.item(0).selectSingleNode("系統代碼").text=oMyObject.Syscd;
			xmlItems.childNodes.item(0).selectSingleNode("合約書編號").text=oMyObject.ContNo;
			xmlItems.childNodes.item(0).selectSingleNode("發票收件人廠商統編").text=oMyObject.MfrNo;
			//xmlItems.childNodes.item(0).selectSingleNode("發票收件人廠商抬頭").text=oMyObject.MfrName;
			xmlItems.childNodes.item(0).selectSingleNode("發票收件人地址").text=oMyObject.MfrAddress;
			xmlItems.childNodes.item(0).selectSingleNode("發票收件人郵遞區號").text=oMyObject.MfrZipcode;
			xmlItems.childNodes.item(0).selectSingleNode("發票收件人電話").text=oMyObject.MfrTel;
			xmlItems.childNodes.item(0).selectSingleNode("發票收件人傳真").text=oMyObject.MfrFax;
			xmlItems.childNodes.item(0).selectSingleNode("發票收件人職稱").text=oMyObject.CustJobTitle;
		}
		
		// 處理 合約書編號 : 因合約書編號的歷史資料為 舊的合約書編號, 須將之改為新的合約書編號, 否則存檔時有誤(PK會重覆)
		// 此處為 Load 歷史資料時, 就要改寫合約書編號; 此外, 在 doCopy() 及 SelectOK() 時也要再做一次 確認合約書編號(=為新的合約書編號) 之動作
		var idx = xmlItems.childNodes.length;
		for(i=0; i<idx;i++)
		{
			// 合約書編號
			xmlItems.childNodes.item(i).selectSingleNode("合約書編號").text = oMyObject.ContNo;
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
				xmlItems.childNodes.item(idx).selectSingleNode("發票廠商序號").text=j1;
			}
			else
				xmlItems.childNodes.item(idx).selectSingleNode("發票廠商序號").text=idx+1;
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
					xmlItems.childNodes.item(i).selectSingleNode("發票廠商序號").text=j1;
				}
				else
					xmlItems.childNodes.item(i).selectSingleNode("發票廠商序號").text=i+1;
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
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(idx1-1).selectSingleNode("發票廠商序號").text=j1;
				xmlItems.childNodes.item(idx1-1).selectSingleNode("合約書編號").text=oMyObject.ContNo;
			}
			else
				xmlItems.childNodes.item(idx1-1).selectSingleNode("發票廠商序號").text=j1;
				xmlItems.childNodes.item(idx1-1).selectSingleNode("合約書編號").text=oMyObject.ContNo;
		}
			
			
		function SelectOK(obj){
			// 下行是為做檢查 XML 之用途
			//window.document.all("textarea1").value=xmlItems.xml;
			
			// 檢查 必填欄位 是否有填
			var idx = xmlItems.childNodes.length;
			for(i=0; i<idx;i++)
			{
				// 發票收件人廠商統編
				if(xmlItems.childNodes.item(i).selectSingleNode("發票收件人廠商統編").text=="")  {
					var j=i+1;
					alert("第" + j + "筆的廠商統編不可空白");
					return;	}
				
				// 發票收件人姓名
				if(xmlItems.childNodes.item(i).selectSingleNode("發票收件人姓名").text=="")  {
					var m=i+1;
					alert("第" + m + "筆的發票收件人姓名不可空白");
					return;	}
				
				// 發票收件人郵遞區號
				if(xmlItems.childNodes.item(i).selectSingleNode("發票收件人郵遞區號").text=="")  {
					var n=i+1;
					alert("第" + n + "筆的發票收件人郵遞區號不可空白");
					return;	}
				
				// 發票收件人地址
				if(xmlItems.childNodes.item(i).selectSingleNode("發票收件人地址").text=="")  {
					var p=i+1;
					alert("第" + p + "筆的發票收件人地址不可空白");
					return;	}
			
				// 處理 合約書編號 : 因合約書編號的歷史資料為 舊的合約書編號, 須將之改為新的合約書編號, 否則存檔時有誤(PK會重覆)
				xmlItems.childNodes.item(i).selectSingleNode("合約書編號").text = oMyObject.ContNo;
			}
			
			// 傳回 XML 值並關閉視窗
			oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
			//alert("oMyObject.result= " + oMyObject.result.xml);
			window.returnValue = true;
			window.close();
		}
		
		-->
		</SCRIPT>
	</body>
</HTML>
