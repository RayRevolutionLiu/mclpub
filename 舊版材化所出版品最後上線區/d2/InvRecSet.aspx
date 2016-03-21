<%@ Page language="c#" Codebehind="InvRecSet.aspx.cs" Src="InvRecSet.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvRecSet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>挑選單一 發票廠商收件人</TITLE>
		<META content="Jean Chen" name="Programmer">
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
		<!-- Run at Server Form-->
		<form id="InvRecSet" method="post" runat="server">
			<!-- 發票收件人參考資料 --><label style="FONT-SIZE: x-small; COLOR: #ff0066">[發票收件人參考資料]</label>
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
						<TH width="40px">
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
							<div dataFld="發票收件人Email" noWrap>
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
			<FONT color="#c00000" size="2">註1：* 為必填欄位!</FONT>
			<br>
			<font color="#c00000" size="2">請按上方按鈕來選取指定的發票收件人, 然後選擇正確的 "郵寄類別 / 海外郵寄資料"!</font>
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
							<span dataFld="發票廠商序號" id="lblIMItem"></span>
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
							<input dataFld="發票收件人傳真" id="tbxIMFax" style="WIDTH: 65px" type="text" maxLength="30" size="1" name="tbxIMFax">
						</TD>
						<TD>
							<input dataFld="發票收件人手機" id="tbxIMCell" style="WIDTH: 50px" type="text" maxLength="30" size="1" name="tbxIMCell">
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
									院內</OPTION></SELECT>
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
		xmlDoc1.load("InvRec.xml");
		//alert(xmlDoc1.xml);
		
		//-------- 注意: 本網頁(與 InvRecForm.asp相比)因無新增之功能, 所以有關 xmlNewItems 本段的 coding 其實可以省略  ---------- //
		var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("發票廠商收件人明細");
		xmlNewItems.selectSingleNode("合約書編號").text=oMyObject.ContNo;
		//alert(xmlNewItems.xml);
		
		
		// 請參 新增雜誌收件人的 table (id=table1  dataSrc=#DSO3)
		// 抓出供挑選雜誌收件人的歷史資料 or 新增新的雜誌收件人 (若無歷史資料, 則直接新增)
		var xmlDoc3 = DSO3.XMLDocument;
		xmlDoc3.async = false;
		xmlDoc3.loadXML(oMyObject.prexmldata);
		//alert(oMyObject.prexmldata);
		
		var xmlItems3 = xmlDoc3.selectSingleNode("發票廠商資料");
		//alert("xmlItems3= " + xmlItems3.xml);
		
		
		// 請參 新增完畢回前頁的 table (id=table2  dataSrc=#DSO2)
		var xmlDoc2 = DSO2.XMLDocument;
		xmlDoc2.async = false;
		xmlDoc2.loadXML(oMyObject.xmldata);
		
		//var xmlItems = xmlDoc2.selectSingleNode("發票廠商資料");
		var xmlItems = xmlDoc2.selectSingleNode("發票廠商收件人細節");
		//alert("xmlItems= " + xmlItems.xml);
		
		
		function doDelete(obj){
			var idx = obj.recordNumber-1;
			var oldNode = xmlItems.childNodes.item(idx);
			if(xmlItems.childNodes.length <= 1)
				{
					var newNode = xmlNewItems.cloneNode(true);
					xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
				}
			oldNode.parentNode.removeChild(oldNode);
			
			// Disable 以下判斷式, 是因此處須正確的 pub_imseq (即原本的 im_seq, 而不須做重新sort序號的動作)
			// 每刪除一行, 重新顯示序號
			//for(i=0; i<xmlItems.childNodes.length;i++)
			//{
				//j1=String(i+1);
				//if(j1.length==1){
					//j1="0"+j1;
					//xmlItems.childNodes.item(i).selectSingleNode("發票廠商序號").text=j1;
				//}
				//else
					//xmlItems.childNodes.item(i).selectSingleNode("發票廠商序號").text=i+1;
			//}
		}
		
		
		function doCopy(obj){
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			//alert("xmlItems3= " + xmlItems3.xml);
			//alert("xmlItems3(" + idx + ")= " + xmlItems3.childNodes.item(idx).xml);
			
			var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
			//alert("newNode= " + newNode.xml);
			
			xmlItems = xmlDoc2.selectSingleNode("發票廠商收件人細節");
			//alert("xmlItems.firstChild= " + xmlItems.firstChild.xml);
			//alert("xmlItems.firstChild.childNodes.item(1).text= " + xmlItems.firstChild.childNodes.item(1).text);
			if(xmlItems.firstChild.childNodes.item(1).text=="")
				xmlItems.replaceChild(newNode, xmlItems.firstChild);
			else
				xmlItems.appendChild(newNode);
			xmlItems = xmlDoc2.selectSingleNode("發票廠商收件人細節");
			
			// Disable 以下判斷式, 是因此處須正確的 pub_imseq (即原本的 im_seq, 而不須做重新sort序號的動作)
			// 每新增一行, 重新顯示序號
			//for(i=0; i<xmlItems.childNodes.length;i++)
			//{
				//j1=String(i+1);
				//if(j1.length==1){
					//j1="0"+j1;
					//xmlItems.childNodes.item(i).selectSingleNode("發票廠商序號").text=j1;
				//}
				//else
				//{
					//xmlItems.childNodes.item(i).selectSingleNode("發票廠商序號").text=i+1;
				//}
				
			//}
			
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
			// 確認 挑選原則: 一筆落版資料只能有一筆發票廠商收件人資料
			//alert("idx= " + idx);
			if(idx<=1)
			{
				oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
				//alert("oMyObject.result= " + oMyObject.result.xml);
				window.returnValue = true;
				window.close();
			}
			else
			{
				alert("請挑選一筆發票廠商收件人資料!  多餘資料請按 '剪刀圖示(刪除)' 來刪除!");
				return;
			}
			
		}
		
		-->
		</SCRIPT>
	</body>
</HTML>
