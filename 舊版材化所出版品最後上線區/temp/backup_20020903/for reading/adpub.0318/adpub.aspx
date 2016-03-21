<%@ Page Language="c#" CodeBehind="adpub.aspx.cs" Src="adpub.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub" %>
<HTML>
	<HEAD>
		<title>廣告落版</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<LINK href="../UserControl/adpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<!-- DataIsland -->
		<xml id="DSO1">
		</xml>
		<xml id="DSOT">
		</xml>
		<xml id="DSOEMPTY">
		</xml>
		<form id="form1" name="form1" runat="server">
			<center>
				<!-- 頁首 Header -->
				<!-- Hidden Value Filed -->
				<input id="hidData" type="hidden" runat="server"> 
				<!-- Initial Client Side Script -->
				<SCRIPT language="javascript">
				var xmlDoc1 = DSO1.XMLDocument;
				xmlDoc1.async = false; 
				xmlDoc1.load("adpubdata.xml");
				
				//插入頭尾空白node
				var xmlDocEmpty = DSOEMPTY.XMLDocument;
				xmlDocEmpty.async = false;
				xmlDocEmpty.load("adpubdata_empty_node.xml");
				
				var newHeadNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
				var newTailNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
				
				xmlDoc1.documentElement.insertBefore(newHeadNode, xmlDoc1.documentElement.childNodes.item(0));
				xmlDoc1.documentElement.appendChild(newTailNode);
				
				
				//這段可以work...只不過沒有資料，真糟糕... : 資料改由 DB 來, 非 .XML 而來
				var xmldoct = DSOT.XMLDocument;
				xmldoct.async = false;
				xmldoct.loadXML(document.form1("hidData").value);
				</SCRIPT>
				<!-- 目前所在位置 -->
				<table dataFld="items" id="tbItems" align="left">
					<tr>
						<td align="left">
							<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
								平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
								落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
								廣告落版</font>
						</td>
					</tr>
				</table>
				<br>
				<!-- 標題 -->
				<b><FONT color="darkblue" size="5">廣告落版 - 工材</FONT></b>
				<br>
				<!-- 抓當月刊登月份的系統年月 -->
				<DIV style="WIDTH: 520px" align="right">
					刊登月份：<b> <font color="red"></font></b>
				</DIV>
				<!-- 落版資料清單 -->
				<table id="tb1" dataSrc="#DSO1" align="center" border="1">
					<TBODY>
						<thead align="middle">
							<tr style="COLOR: white; Size: 4" bgColor="#214389">
								<td align="middle" colSpan="7">
									<font color="#ffffff" size="4">落版版面</font>
								</td>
							</tr>
							<tr bgColor="#bfcff0">
								<td noWrap>
									頁次
								</td>
								<td noWrap>
									描述
								</td>
								<td noWrap>
									色彩
								</td>
								<td noWrap>
									篇幅
								</td>
								<td noWrap>
									版面
								</td>
								<td noWrap>
									固定頁次
								</td>
								<td noWrap>
									版面２
								</td>
							</tr>
						</thead>
						<tbody onmousemove="doMouseMove()">
							<tr align="middle">
								<td class="cssOrder">
									<span dataFld="頁次" id="pageorder"></span>
								</td>
								<td class="cssDetail" align="left">
									<span dataFld="描述" id="idDescript" onclick="doClick(document.all.DSO1)"></span>
								</td>
								<td class="cssColor">
									<span dataFld="色彩"></span>
								</td>
								<td class="cssPagesize">
									<span dataFld="篇幅"></span>
								</td>
								<td class="cssPageLayout">
									<span dataFld="版面"></span>
								</td>
								<td class="cssFixPage">
									<span dataFld="固定頁次註記"></span>
								</td>
								<td class="cssPageLayout2">
									<input dataFld="版面2" id="pagelayout2" type="text" size="1">
								</td>
							</tr>
						</tbody>
						<tfoot>
							<tr>
								<td align="right" colSpan="7">
								</td>
							</tr>
						</tfoot>
				</table>
				<!-- 落版資料清單 -->
				<!-- Mouse click 後的資料開始 -->
				<DIV class="srcData" id="ico" style="DISPLAY: none; Z-INDEX: 100; POSITION: absolute">
				</DIV>
				<DIV id="fMenu">
					<DIV class="fixMenu" onclick="doReOrder()">
						重排頁次
					</DIV>
					<DIV class="fixMenu" onclick="doHelp1();">
						操作說明
					</DIV>
					<DIV class="fixMenu" onclick="window.location.href='/mrlpub/'">
						回首頁
					</DIV>
					<DIV class="fixMenu" id="tempMsg">
					</DIV>
				</DIV>
				<!-- 功能表結束 -->
				<script language="javascript">
				function doHelp1()
				{
					if(document.all.helpMsg.style.display.toLowerCase() == 'none')
					{
						document.all.helpMsg.style.display = "";
						event.srcElement.innerText = "隱藏操作說明"; 
					}
				else
				{
					document.all.helpMsg.style.display = "none";
					event.srcElement.innerText = "操作說明"; 
				}
				}
				//	window.onload = ggg();
				</script>
				<script language="javascript" src="UserControl/watermark.js"></script>
				<script language="javascript">
				// page layout maintain
				function doClick(theDSO)
				{
					if(btnPressed)
					{
						if(srcDSO == theDSO)
						{
							doPut();
							btnPressed = false;
							var gg = false;
							for(var i=0; i<document.getElementsByTagName("tb1").length; i++)
							{
								// if(event.srcElement.readyState=="complete")
							}
							doReOrder();
						}
					}
					else
					{
						srcDSO = theDSO;
						doPick();
						btnPressed = true;
					}
				}
				
				
				function doMouseMove()
				{
					// document.all("ico").value="Coords: (" + event.clientX + ", " + event.clientY + ")";
					document.all.ico.style.posLeft = event.clientX + document.body.scrollLeft;
					document.all.ico.style.posTop = event.clientY + document.body.scrollTop;
					// event.returnValue = false;
					// event.cancelBubble = true; 
					/*
					 */
				}
				
				
				function doPick()
				{
					srcObj = event.srcElement; srcObj.style.color="red"; 
					srcObj.style.cursor="hand";
					document.all.ico.style.display=""; 
					document.all.ico.innerText=srcObj.innerText;
					segOffset = srcObj.parentElement.parentElement.rowIndex-2;
					var xmlDoc = srcDSO.XMLDocument; 
					srcNode = xmlDoc.documentElement.childNodes.item(segOffset);
					return !btnPressed;
				}
				
				
				function doPut()
				{
					/*小賴的原始版
					var obj = event.srcElement;
					var idx = obj.parentElement.parentElement.rowIndex-2;
					var xmlDoc = srcDSO.XMLDocument; 
					xmlDoc.documentElement.insertBefore(srcNode, 
					xmlDoc.documentElement.childNodes.item(idx));
					srcObj.style.color=""; 
					srcObj.style.cursor="";
					srcObj = null;
					document.all.ico.style.display="none"; 
					return !btnPressed;
					*/
					
					//obj為抓出put下去時，發出事件的cell？
					var obj = event.srcElement; 
					
					//cell->row，然後找出該row的index，-2是去掉兩格的非資料binding區
					var idx = obj.parentElement.parentElement.rowIndex-2;
					
					//取出src的XmlDocument
					var xmlDoc = srcDSO.XMLDocument; 
					//alert(xmlDoc.documentElement.xml);
					
					if (idx==segOffset)		//segOffset是pick起來時，那個row的index
					{
						//alert("the same node"); 
						srcObj.style.color="";
						srcObj.style.cursor="";
						srcObj = null; 
						document.all.ico.style.display="none";
						return !btnPressed;
					} 
					
					//STEP2：如果挑選的點是不可移動的點，也不做
					if (srcNode.selectSingleNode("固定頁次").text == "1")
					{ 
						//alert("這個node不可以移動"+!btnPressed);
						alert("很抱歉, 這個位置被要求 '固定', 故它不可被移動!");
						srcObj.style.color=""; 
						srcObj.style.cursor="";
						srcObj = null;
						document.all.ico.style.display="none"; 
						return !btnPressed;
					}
					
					if (xmlDoc.documentElement.childNodes.item(idx).selectSingleNode("固定頁次").text =="1")
					{
						//alert("放下去的點是固定的");
						alert("很抱歉, 您想移到的位置被要求 '固定', 請重新安排新位置!");
						srcObj.style.color="";
						srcObj.style.cursor=""; 
						srcObj = null;
						document.all.ico.style.display="none";
						return !btnPressed
					}
					
					var xmlRefList = srcDSO.XMLDocument.documentElement.cloneNode(true); 
					
					xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);
					
					//開始重排
					
					//先移光
					var i; 
					for (i=0;i<xmlDoc.documentElement.childNodes.length;i++)
					{
						if (xmlDoc.documentElement.childNodes.item(i).selectSingleNode("固定頁次").text =="1")
						{ 
							xmlDoc.documentElement.removeChild(xmlDoc.documentElement.childNodes.item(i)); 
							i--;
						}
					}		
					i = null;
					
					var j;
					for (j=0;j<xmlRefList.childNodes.length&&j<xmlDoc.documentElement.childNodes.length;j++)
					{
						if ((xmlRefList.childNodes.item(j).selectSingleNode("固定頁次").text == "1") && (xmlRefList.childNodes.item(j).selectSingleNode("描述").text != xmlDoc.documentElement.childNodes.item(j).selectSingleNode("描述").text))
						{ 
							//挑喔～～
							var newNode = xmlRefList.childNodes.item(j).cloneNode(true); 
							//alert("insertBefore" + j + "th");
							xmlDoc.documentElement.insertBefore(newNode, xmlDoc.documentElement.childNodes.item(j));
							newNode = null;
						}
					}
					j = null; 
					
					//GC 
					xmlRefList = null;
					
					srcObj.style.color="";
					srcObj.style.cursor="";
					srcObj = null;
					document.all.ico.style.display="none";
					return !btnPressed;
				}
			
				function doReOrder()
				{
					var pp = 0;
					for(var i=0; i< document.all.pageorder.length; i++)
					{ 
						pp = pp + (document.all.pagelayout2[i].value/8); 
						document.all.pageorder[i].innerText = Math.ceil(pp);
					}
				}
				
				//重新排版，停用
				function doRePublish()
				{
				}
				
				var srcDSO = new Object();
				var btnPressed=false;
				var srcObj = new Object();
				var srcNode = new Object();
				var segIdx = 0;
				var segOffset = 0;
				</script>
				<!-- idDescript 之 OnMouseOver 色塊顏色 -->
				<script language="javascript" event="onmouseover" for="idDescript"> 
					style.backgroundColor='Gold';
					style.cursor="hand";
				</script>
				<!-- idDescript 之 OnMouseOut 色塊顏色 -->
				<script language="javascript" event="onmouseout" for="idDescript"> 
					style.backgroundColor='';
					style.cursor="default";
				</script>
				<!--  -->
				<!-- fMenu 之 OnMouseOver 色塊顏色  -->
				<script language="javascript" event="onmouseover" for="fMenu"> 
					event.srcElement.style.backgroundColor='Gold'; 
					event.srcElement.style.cursor="hand";
				</script>
				<!-- fMenu 之 OnMouseOut 色塊顏色  -->
				<script language="javascript" event="onmouseout" for="fMenu"> 
					event.srcElement.style.backgroundColor='';
					event.srcElement.style.cursor=""; 
				</script>
				<!-- fMenu 之 helpMsg 色塊顏色  -->
				<DIV class="help1" id="helpMsg" style="DISPLAY: none">
					<OL>
						<LI>
						請移動 Mouse 至要移動的描述欄位按一下 Mouse 右鍵, 這時會出現一個描述欄位的資料複製方塊.
						<LI>
						移動 Mouse 至要放置的描述欄位再按一下 Mouse 右鍵即可重新排列.
						<LI>
							不可調整不同類別的版面位置.
						</LI>
					</OL>
				</DIV>
				<P>
					註: <B>電材版面:</B> 特別版面, 彩色內頁(全), 套色內頁(全), 套色內頁(半)
					<BR>
					註: <B>工材版面:</B> 特別版面, 彩色內頁(全), 套色內頁(全), 黑白內頁(全), 黑白內頁(半)
				</P>
				<!-- 頁尾 Footer -->
			</center>
		</form>
	</BODY>
</HTML>
