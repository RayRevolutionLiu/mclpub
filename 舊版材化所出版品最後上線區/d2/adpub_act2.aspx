<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="adpub_act2.aspx.cs" Src="adpub_act2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_act2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告排版動作 步驟二</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<LINK href="../UserControl/adpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<CENTER>
			<!-- DataIsland -->
			<xml id="DSO1"></xml>
			<xml id="DSOS"></xml>
			<xml id="DSOT"></xml>
			<xml id="DSOEMPTY"></xml>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- Run at Server Form -->
			<form id="form1" name="form1" runat="server">
				<!-- Hidden Value Filed -->
				<input id="tbxStartPageNo" type="hidden" maxLength="3" size="3" name="tbxStartPageNo" runat="server">&nbsp;
				<input id="hidData_special" type="hidden" name="hidData_special" runat="server">&nbsp;
				<input id="hidData" type="hidden" name="hidData" runat="server">&nbsp; 
				<!-- Initial Client Side Script -->
				<SCRIPT language="javascript">
					// 資料由 資料庫 來的語法
					// 自資料庫中抓出資料, 並將值儲存至 hidData_special 再呼叫之 - for 特殊版面
					// document.form1("hidData_special").value 的資料由 .aspx.cs 裡取得
					//alert("hidData= " + document.form1("hidData_special").value);
					var xmldocts = DSOS.XMLDocument;
					xmldocts.async = false;
					xmldocts.loadXML(document.form1("hidData_special").value);
				</SCRIPT>
				<SCRIPT language="javascript">
					// 資料由 xml 來的語法
					//var xmlDoc1 = DSO1.XMLDocument;
					//xmlDoc1.async = false;
					//xmlDoc1.load("adpub_data.xml");
					
					// 資料由 資料庫 來的語法
					// 自資料庫中抓出資料, 並將值儲存至 hidData 再呼叫之 - for 一般版面
					// document.form1("hidData").value 的資料由 .aspx.cs 裡取得
					//alert("hidData= " + document.form1("hidData").value);
					var xmldoct = DSOT.XMLDocument;
					xmldoct.async = false;
					xmldoct.loadXML(document.form1("hidData").value);
					
					
					//插入頭尾空白node
					var xmlDocEmpty = DSOEMPTY.XMLDocument;
					xmlDocEmpty.async = false;
					xmlDocEmpty.load("adpub_data_empty.xml");
					
					var newHeadNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
					var newTailNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
					
					// 下幾行是 for - 自 xml檔案 載入時
					//xmlDoc1.documentElement.insertBefore(newHeadNode, xmlDoc1.documentElement.childNodes.item(0));
					//xmlDoc1.documentElement.appendChild(newTailNode);
					
					// 下幾行是 for - 自 資料庫 載入時
					xmldoct.documentElement.insertBefore(newHeadNode, xmldoct.documentElement.childNodes.item(0));
					xmldoct.documentElement.appendChild(newTailNode);
					
					// 下幾行是給 doReOrder() 裡用的 Global Variable
					var Arr = new Array();
				</SCRIPT>
				<!-- 目前所在位置 -->
				<table dataFld="items" id="tbItems" align="left">
					<tr>
						<td align="left">
							<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
								平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
								落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
								廣告排版動作&nbsp; 步驟二</FONT>
						</td>
					</tr>
				</table>
			&nbsp;
		</CENTER>
		<br>
		&nbsp; 
		<!-- 落版資料清單
			// 自 xml檔案 載入時, dataSrc 用 #DSO1
			// 自 資料庫 載入時, dataSrc 用 #DSOS (特殊版面) & #DSOT (一般版面)
		-->
		<table id="tblspecial" style="BORDER-RIGHT: #214389 1px solid; BORDER-TOP: #214389 1px solid; BORDER-LEFT: #214389 1px solid; BORDER-BOTTOM: #214389 1px solid" dataSrc="#DSOS" width="100%" align="center">
			<TBODY>
				<thead align="middle">
					<tr style="COLOR: white; Size: 4" bgColor="#214389">
						<td align="middle" colSpan="22">
							<STRONG><FONT size="4"><font color="#ffffff">廣告排版版面</font>&nbsp; -
									<asp:label id="lblSearchKeyword" runat="server" ForeColor="Gold" Font-Size="X-Small"></asp:label>
									&nbsp;
									<asp:label id="lblDBMessage" runat="server" ForeColor="Cyan" Font-Size="X-Small"></asp:label>
									<br>
									<asp:Label id="lblTotalCounts" runat="server" ForeColor="Orange" Font-Size="X-Small"></asp:Label>&nbsp;
									<asp:Label id="lblClrPgsGroupCount" runat="server" Font-Size="X-Small" ForeColor="Orange"></asp:Label>
								</FONT></STRONG>
						</td>
					</tr>
					<tr bgColor="#bfcff0">
						<td noWrap>
							新頁次
						</td>
						<td noWrap>
							合約書
							<br>
							編號
						</td>
						<td noWrap>
							落版
							<br>
							序號
						</td>
						<td noWrap>
							刊登
							<br>
							年月
						</td>
						<td noWrap>
							刊登
							<br>
							頁碼
						</td>
						<td noWrap width="8%">
							版面
						</td>
						<td noWrap>
							色彩
						</td>
						<td noWrap>
							篇幅
						</td>
						<td noWrap>
							固定
							<br>
							頁次
						</td>
						<td noWrap>
							<font color="red">公司名稱</font>
						</td>
						<td noWrap>
							到稿
						</td>
						<td noWrap>
							新稿
							<br>
							製法
						</td>
						<td noWrap>
							改稿
							<br>
							書籍
						</td>
						<td noWrap>
							改稿
							<br>
							期別
						</td>
						<td noWrap>
							改稿
							<br>
							頁碼
						</td>
						<td noWrap>
							改稿
							<br>
							重出片
						</td>
						<td noWrap>
							舊稿
							<br>
							書籍
						</td>
						<td noWrap>
							舊稿
							<br>
							期別
						</td>
						<td noWrap>
							舊稿
							<br>
							頁碼
						</td>
						<td noWrap>
							落版
							<br>
							業務員
						</td>
						<td noWrap>
							備註
						</td>
					</tr>
					<!-- 特殊版面 -->
					<tr>
						<td align="left" bgColor="gold" colSpan="22">
							<font color="green" size="2"><b>特殊版面</b></font>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr vAlign="bottom" align="middle">
						<td class="cssOrder">
							<span dataFld="頁次" id="OrderS"><FONT face="新細明體"></FONT></span>
						</td>
						<td class="cssColumn">
							<span dataFld="合約書編號" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="落版序號" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="刊登年月" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn" align="right">
							<span dataFld="刊登頁碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumnDiffColor" noWrap width="8%">
							<span dataFld="廣告版面" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="廣告色彩" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="廣告篇幅" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="固定頁次註記" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid" align="left">
							<!-- 當 load 自資料庫時: idCompanyName 的 onclick() 裡要變更為 DSOS --><span dataFld="公司名稱" id="idCompanyName1"></span>
						</td>
						<td class="cssColumn">
							<span dataFld="到稿註記" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="新稿製法" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="改稿書籍代碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="改稿期別" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="改稿頁碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="改稿重出片註記" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="舊稿書籍名稱" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="舊稿期別" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="舊稿頁碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn">
							<span dataFld="落版業務員姓名" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
						<td class="cssColumn" align="left">
							<span dataFld="備註" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
							</span>
						</td>
					</tr>
				</tbody>
		</table>
		<table id="tb1" style="BORDER-RIGHT: #214389 1px solid; BORDER-TOP: #214389 1px solid; BORDER-LEFT: #214389 1px solid; BORDER-BOTTOM: #214389 1px solid" dataSrc="#DSOT" width="100%" align="center">
			<thead>
				<!-- 一般版面 -->
				<tr>
					<td align="left" bgColor="gold" colSpan="22">
						<font color="green" size="2"><b>一般版面</b></font>
					</td>
				</tr>
				<tr bgColor="#bfcff0">
					<td noWrap>
						新頁次
					</td>
					<td noWrap>
						合約書
						<br>
						編號
					</td>
					<td noWrap>
						落版
						<br>
						序號
					</td>
					<td noWrap>
						刊登
						<br>
						年月
					</td>
					<td noWrap>
						刊登
						<br>
						頁碼
					</td>
					<td noWrap width="8%">
						版面
					</td>
					<td noWrap>
						色彩
					</td>
					<td noWrap>
						篇幅
					</td>
					<td noWrap>
						固定
						<br>
						頁次
					</td>
					<td noWrap>
						<font color="red">公司名稱</font>
					</td>
					<td noWrap>
						到稿
					</td>
					<td noWrap>
						新稿
						<br>
						製法
					</td>
					<td noWrap>
						改稿
						<br>
						書籍
					</td>
					<td noWrap>
						改稿
						<br>
						期別
					</td>
					<td noWrap>
						改稿
						<br>
						頁碼
					</td>
					<td noWrap>
						改稿
						<br>
						重出片
					</td>
					<td noWrap>
						舊稿
						<br>
						書籍
					</td>
					<td noWrap>
						舊稿
						<br>
						期別
					</td>
					<td noWrap>
						舊稿
						<br>
						頁碼
					</td>
					<td noWrap>
						落版
						<br>
						業務員
					</td>
					<td noWrap>
						備註
					</td>
				</tr>
			</thead>
			<tbody onmousemove="doMouseMove()">
				<tr vAlign="bottom" align="middle">
					<td class="cssOrder">
						<span dataFld="頁次" id="pageorder"><FONT face="新細明體"></FONT></span>
					</td>
					<td class="cssColumn">
						<span dataFld="合約書編號" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="落版序號" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="刊登年月" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn" align="right">
						<span dataFld="刊登頁碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumnDiffColor" noWrap width="8%">
						<span dataFld="廣告版面" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumnDiffColor">
						<span dataFld="廣告色彩" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumnDiffColor">
						<span dataFld="廣告篇幅" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumnDiffColor">
						<span dataFld="固定頁次註記" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssCompanyName" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid" align="left">
						<!-- 當 load 自資料庫時: idCompanyName 的 onclick() 裡要變更為 DSOT --><span dataFld="公司名稱" id="idCompanyName" onclick="doClick(document.all.DSOT)"></span>
					</td>
					<td class="cssColumn">
						<span dataFld="到稿註記" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="新稿製法" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="改稿書籍代碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="改稿期別" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="改稿頁碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="改稿重出片註記" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="舊稿書籍名稱" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="舊稿期別" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="舊稿頁碼" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn">
						<span dataFld="落版業務員姓名" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
					<td class="cssColumn" align="left">
						<span dataFld="備註" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
						</span>
					</td>
				</tr>
			</tbody>
			<tfoot>
				<tr>
					<td style="COLOR: #990033" align="left" bgColor="#bfcff0" colSpan="22">
						一般操作：請將滑鼠移到 "<font color="red">公司名稱</font>" 上, 按一次滑鼠左鍵, 再移滑鼠到您要移動的位置上再按一下左鍵, 
						來進行搬動落版資料.
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;移動完數筆, 
						請按 "<SPAN style="COLOR: black; BACKGROUND-COLOR: #cdc9c9">重排頁次</SPAN>", 
						來得到最新的排版順序, (若發現頁次有誤, 請再按一次);
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;最終的新頁次確認後, 
						請按 "<SPAN style="COLOR: black; BACKGROUND-COLOR: #cdc9c9">確認寫回</SPAN>" 
						來寫回新頁次資料至刊登頁碼處.
						<br>
						補充：固定頁次(=<font color="#336699">是</font>) 的欄位將不允許移動或被移動! 它表示該落版資料, 
						客戶有要求刊登在指定的頁碼!
						<br>
						補充：同月份同區塊(如彩色全頁)之落版資料, 若其篇幅為 "<font color="#336699">半頁</font>"), 請務必放於上下相鄰位置!
						<br>
						補充：公司名稱為 <font color="#336699">xxx</font> 者, 請確認其位置於頭及尾的位置!
						<br>
						<br>
						<font color="black">註: 欲修改落版資料, 請至 <A href="cont_main1.aspx" target="_self">合約處理/一般合約書/合約書維護</A>
							或 <A href="pub_new1.aspx" target="_self">合約處理/落版/新增/維護/顯示落版/由年月落版進入</A> 來修改!
							<br>
							列印說明: 如需列印本頁資料做為書面參考紙本, 列印時請選擇 "<font color="darkred">橫印</font>", 以得完整資料畫面!
							<br>
						</font>
					</td>
				</tr>
				<tr>
					<td align="middle" colSpan="22">
						<INPUT id="btnReOrder" onclick="Javascript: doReOrder();" type="button" value="重排頁次" name="btnReOrder">&nbsp;&nbsp;<INPUT id="btnWritetoDB" onclick="Javascript: doWriteToDB();" type="button" value="確認寫回" name="btnBack">
						<br>
					</td>
				</tr>
			</tfoot>
		</table>
		<br>
		<!-- Mouse click 後的資料開始 -->
		<CENTER>
			<DIV class="srcData" id="ico" style="DISPLAY: none; Z-INDEX: 100; POSITION: absolute">
			</DIV>
		</CENTER>
		<!-- 此 TEXTAREA 是供檢查 XML 輸出檢查用 -->
		<!--TEXTAREA id="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
		<!-- 頁尾 Footer -->
		<CENTER>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</CENTER>
		<!-- 抓出目前排版的新頁次, 寫入 hiddata 裡, 最後再將新頁次寫回資料庫 -->
		<script language="javascript">
				function doWriteToDB()
				{
					//下幾行是 for - 自 資料庫 載入時
					//先抓出目前畫面中的頁次
					var xmlDoc = DSOT.XMLDocument; 
					//alert(xmlDoc.documentElement.xml);
					//alert(xmlDoc.getElementsByTagName("頁次").length);
					
					//for(var i=0; i< document.all.pageorder.length; i++)
					for(var i=1; i< (xmlDoc.getElementsByTagName("頁次").length-1); i++)
					{
						//alert(document.all.pageorder[i].innerText);
						// 抓出非空白 node 之所有畫面上的新頁次
						//if(document.all.pageorder[i].innerText != "--")
						if(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text != "")
						{
							// 檢查輸出 畫面上的新頁次
							//alert(document.all.pageorder[i].innerText);
							
							// 改寫 DSOT.XMLDocument - 將畫面上的新頁次 存入 xmlDoc (注意: 未寫入前 xmlDoc的頁次為 0(初始值); 寫入後為 畫面上的新頁次)
							//alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text);
							
							// 若為固定頁次的資料, 其頁次不予以修改, 為原指定之頁次
							if (xmlDoc.documentElement.childNodes.item(i).selectSingleNode("固定頁次註記").text == "是")
							{
								//alert("第 " + i + " 筆為固定頁次");
								//alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text);
								//xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text;
								
								// 檢查該固定頁次之頁碼長度, 一律輸出轉為 2位數之數字! 
								var FixPgno = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text;
								if(FixPgno.length==1)
								{
									FixPgno = "0" + FixPgno;
								}
								else
								{
									FixPgno = FixPgno;
								}
								//alert("FixPgno= " + FixPgno);
								
								// 輸出結果於 "頁次" 處
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text = FixPgno;
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = FixPgno;
								
							}
							// 反之, 則給予新頁次
							else
							{
								//alert(document.all.pageorder[i].innerText);
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = document.all.pageorder[i].innerText;
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text = document.all.pageorder[i].innerText;
								//alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text);					
							}
						}
					}
					//檢查寫 新頁次 入 xmlDoc 是否成功
					//alert(xmlDoc.documentElement.xml);
					
					// 更新 hidData 值 - 將新的 xmlDoc 寫入 document.form1("hidData").value 值
					document.form1("hidData").value = "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlDoc.documentElement.xml;
					//alert("hidData= " + document.form1("hidData").value);
					
					// 執行 adpub_act3.aspx: 藉傳遞變數 ("hidData").value 值(即 xml資料) 抓出各行之新頁次, 再分別 update 寫入資料庫中				
					var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
					xmlHTTP.Open("post", "adpub_act3.aspx", false);
					xmlHTTP.Send(xmlDoc);
					
					// 檢查並輸出 xmlHTTP 狀態於本頁 textarea1 內
					//document.all("textarea1").value=xmlHTTP.responseText;
					
					if(xmlHTTP.statusText=="OK")
					{
						alert("新頁次更新成功!");
					}
					
					// 清除 xmlHTTP 資料為空
					var xmlHTTP = null;
					
					
					// 網頁 ReLoad
					location.reload(true);
				}
		</script>
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
							//var gg = false;
							//for(var i=0; i<document.getElementsByTagName("tb1").length; i++)
							//{
								// if(event.srcElement.readyState=="complete")
							//}
							//doReOrder();
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
				}
				
				
				function doPick()
				{
					srcObj = event.srcElement;
					srcObj.style.color="red"; 
					srcObj.style.cursor="hand";
					document.all.ico.style.display=""; 
					document.all.ico.innerText=srcObj.innerText;
					
					//下幾行是 for - 自 xml檔案 載入時				
					//segOffset = srcObj.parentElement.parentElement.rowIndex-2;
					////取出src的XmlDocument
					//var xmlDoc = srcDSO.XMLDocument; 
					//srcNode = xmlDoc.documentElement.childNodes.item(segOffset);
					//return !btnPressed;
					
					//下幾行是 for - 自 資料庫 載入時
					segOffset = srcObj.parentElement.parentElement.rowIndex-2;
					//var xmlDoc = xmldoct.XMLDocument; 
					srcNode = xmldoct.documentElement.childNodes.item(segOffset);
					return !btnPressed;
				}
				
				
				function doPut()
				{
					//obj為抓出put下去時，發出事件的cell？
					var obj = event.srcElement; 
					
					//cell->row，然後找出該row的index，-2是去掉兩格的非資料binding區
					var idx = obj.parentElement.parentElement.rowIndex-2;
					
					
					//取出src的XmlDocument
					//下一行是 for - 自 xml檔案 載入時
					//var xmlDoc = srcDSO.XMLDocument; 
					
					//下一行是 for - 自 資料庫 載入時
					var xmlDoc = DSOT.XMLDocument; 
					//alert(xmlDoc.documentElement.xml);
					
					if(idx==(xmlDoc.documentElement.childNodes.length-1))
					{
						alert("很抱歉, 禁止搬移到最後一個空位置上!");
						srcObj.style.color="";
						srcObj.style.cursor="";
						srcObj = null; 
						document.all.ico.style.display="none";
						return !btnPressed;
					}
					
					if(segOffset==(xmlDoc.documentElement.childNodes.length-1))
					{
						alert("很抱歉, 最後一個空位置禁止搬移!");
						srcObj.style.color="";
						srcObj.style.cursor="";
						srcObj = null; 
						document.all.ico.style.display="none";
						return !btnPressed;
					}
					
					if (idx==segOffset)		//segOffset是pick起來時，那個row的index
					{
						//alert("the same node"); 
						srcObj.style.color="";
						srcObj.style.cursor="";
						srcObj = null; 
						document.all.ico.style.display="none";
						return !btnPressed;
					} 
/*	
					if(idx==0)
					{
						if(parseInt(srcNode.selectSingleNode("廣告優先次序").text) != parseInt(xmldoct.documentElement.childNodes.item(1).selectSingleNode("廣告優先次序").text))
						{
							alert("很抱歉, 落版資料不可跨區(不同廣告色彩+廣告篇幅視為一區)!");
							srcObj.style.color=""; 
							srcObj.style.cursor="";
							srcObj = null;
							document.all.ico.style.display="none"; 
							return !btnPressed;
						}
					}
					else
					{
						if(parseInt(srcNode.selectSingleNode("廣告優先次序").text) != parseInt(xmldoct.documentElement.childNodes.item(idx).selectSingleNode("廣告優先次序").text))
						{
							alert("很抱歉, 落版資料不可跨區(不同廣告色彩+廣告篇幅視為一區)!");
							srcObj.style.color=""; 
							srcObj.style.cursor="";
							srcObj = null;
							document.all.ico.style.display="none"; 
							return !btnPressed;
						}
					}
*/					
					//STEP2：如果挑選的點是不可移動的點，也不做
					//if (srcNode.selectSingleNode("固定頁次註記").text == "1")
					if (srcNode.selectSingleNode("固定頁次註記").text == "是")
					{ 
						//alert("這個node不可以移動"+!btnPressed);
						alert("很抱歉, 這個位置被要求 '固定', 故它不可被移動!");
						srcObj.style.color=""; 
						srcObj.style.cursor="";
						srcObj = null;
						document.all.ico.style.display="none"; 
						return !btnPressed;
					}
					
					//下一行是 for - 自 xml檔案 載入時
					//if(xmlDoc.documentElement.childNodes.item(idx).selectSingleNode("固定頁次註記").text =="1")
					
					//下一行是 for - 自 資料庫 載入時
					//if (xmldoct.documentElement.childNodes.item(idx).selectSingleNode("固定頁次註記").text =="1")
					if (xmldoct.documentElement.childNodes.item(idx).selectSingleNode("固定頁次註記").text =="是")
					{
						//alert("放下去的點是固定的");
						alert("很抱歉, 您想移到的位置被要求 '固定', 請重新安排新位置!");
						srcObj.style.color="";
						srcObj.style.cursor=""; 
						srcObj = null;
						document.all.ico.style.display="none";
						return !btnPressed
					}

					//Owen Add
					if(segOffset > idx)
					{
						//Move Up
						for(var IndexItem=segOffset; IndexItem > (idx+1); IndexItem--)
						{
							var OrgNode= xmlDoc.documentElement.childNodes.item(IndexItem).cloneNode(true);
							var newNode = xmlDoc.documentElement.childNodes.item(IndexItem-1).cloneNode(true);
							xmlDoc.documentElement.replaceChild(newNode,xmlDoc.documentElement.childNodes.item(IndexItem));
							xmlDoc.documentElement.replaceChild(OrgNode,xmlDoc.documentElement.childNodes.item(IndexItem-1));
							OrgNode=null;
							newNode=null;
						}
					}
					else if(segOffset < idx)
					{
						//Move Down
						for(var IndexItem=segOffset; IndexItem < idx; IndexItem++)
						{
							var OrgNode= xmlDoc.documentElement.childNodes.item(IndexItem).cloneNode(true);
							var newNode = xmlDoc.documentElement.childNodes.item(IndexItem+1).cloneNode(true);
							xmlDoc.documentElement.replaceChild(newNode,xmlDoc.documentElement.childNodes.item(IndexItem));
							xmlDoc.documentElement.replaceChild(OrgNode,xmlDoc.documentElement.childNodes.item(IndexItem+1));
							OrgNode=null;
							newNode=null;
						}
					}
					
					/*
					//下一行是 for - 自 xml檔案 載入時
					//var xmlRefList = srcDSO.XMLDocument.documentElement.cloneNode(true); 
					//xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);
					
					//下一行是 for - 自 資料庫 載入時
					var xmlRefList = DSOT.XMLDocument.documentElement.cloneNode(true); 
					xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);

					//開始重排
					
					//先移光
					var i; 
					for (i=0;i<xmlDoc.documentElement.childNodes.length;i++)
					{
						if (xmlDoc.documentElement.childNodes.item(i).selectSingleNode("固定頁次註記").text =="是")
						{ 
							xmlDoc.documentElement.removeChild(xmlDoc.documentElement.childNodes.item(i)); 
							i--;
						}
					}		
					i = null;
					
					var j;
					//alert("xmlRefList.childNodes.length=" + xmlRefList.childNodes.length);
					for (j=0;j<xmlRefList.childNodes.length;j++)
					{						
						//做 safe control
						//alert("xmlDoc.documentElement.childNodes.length= " + xmlDoc.documentElement.childNodes.length);
						if (j<xmlDoc.documentElement.childNodes.length)
						{
							// 注意 if 條件裡的判斷式檢查 if(條件一!= 條件二)
							// 條件一-固定頁次註記(否): xmlRefList.固定頁次註記=1(是) && (xmlRefList.合約書編號+xmlRefList.落版序號+xmlRefList.刊登年月) ==> 才是唯一值; 不可只用 "公司名稱" 取代此唯一值), 否則搬移後, 會遺失多筆相同公司名稱值的資料
							// 條件二-固定頁次註記(是): xmlDoc合約書編號+xmlRefList.落版序號+xmlRefList.刊登年月
							//alert("xmlDoc.合約書編號= " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("合約書編號").text);
							//alert("xmlRefList.合約書編號= " + xmlRefList.childNodes.item(j).selectSingleNode("合約書編號").text);
							//alert("條件一-固定頁次註記(否): " + xmlRefList.childNodes.item(j).selectSingleNode("固定頁次註記").text == "是") && (xmlRefList.childNodes.item(j).selectSingleNode("合約書編號").text+xmlRefList.childNodes.item(j).selectSingleNode("落版序號").text+xmlRefList.childNodes.item(j).selectSingleNode("刊登年月").text);
							//alert("條件二-固定頁次註記(是): " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("合約書編號").text+xmlRefList.childNodes.item(j).selectSingleNode("落版序號").text+xmlRefList.childNodes.item(j).selectSingleNode("刊登年月").text);
							if ((xmlRefList.childNodes.item(j).selectSingleNode("固定頁次註記").text == "是") && (xmlRefList.childNodes.item(j).selectSingleNode("合約書編號").text+xmlRefList.childNodes.item(j).selectSingleNode("落版序號").text+xmlRefList.childNodes.item(j).selectSingleNode("刊登年月").text != xmlDoc.documentElement.childNodes.item(j).selectSingleNode("合約書編號").text+xmlRefList.childNodes.item(j).selectSingleNode("落版序號").text+xmlRefList.childNodes.item(j).selectSingleNode("刊登年月").text))
							{
								//挑喔～～
								var newNode = xmlRefList.childNodes.item(j).cloneNode(true);
								//alert("insertBefore" + j + "th");
								xmlDoc.documentElement.insertBefore(newNode, xmlDoc.documentElement.childNodes.item(j));
								newNode = null;
							}
						}
						else
						{
							var newNode = xmlRefList.childNodes.item(j).cloneNode(true);
							xmlDoc.documentElement.appendChild(newNode);
							newNode = null;
						}
					}
					j = null;
					
					//GC 
					xmlRefList = null;
					*/
					
					
					srcObj.style.color="";
					srcObj.style.cursor="";
					srcObj = null;
					document.all.ico.style.display="none";
					return !btnPressed;
				}
				
				function SortArr()
				{
					var Temp;
					
					for(var i=0; i<(Arr.length-1); i++)
						for(var j=i; j<Arr.length; j++)
							if(Arr[j]>Arr[i])
							{
								Temp=Arr[i];
								Arr[i]=Arr[j];
								Arr[j]=Temp;
							};
				}
				
				// 按下 重排頁次 的動作 function
				function doReOrder()
				{
					alert("重排頁次中...請稍後!");
					
					
					//取出src的XmlDocument
					//注意: 之前 function 有指定 srcDSO == theDSO (即DSO1); 所以下一行要變更直接load DSO1, 非 srcDSO; 否則若page一load時, 去按 "重排頁次" 會發生錯誤
					//var xmlDoc = srcDSO.XMLDocument; 
					
					//下一行是 for - 自 xml檔案 載入時
					//var xmlDoc = DSO1.XMLDocument; 
					//alert(xmlDoc.documentElement.xml); 
					
					//下一行是 for - 自 資料庫 載入時
					var xmlDoc = DSOT.XMLDocument; 
					//alert(xmlDoc.documentElement.xml); 
					//alert("xmlDoc.getElementsByTagName("頁次").length= " + xmlDoc.getElementsByTagName("頁次").length);
					
					
					// 測試 Arr 是否在此 function 可抓得到 (a Global Variable; 已定義在 Initial Client Side Script 裡, Line 61)
					//alert("Arr= " + Arr);
					
					// 指定 固定頁次=是, 則其 新頁次 = 刊登頁碼之DB值
					var FixPageNo = "";
					while(Arr.length!=0)
					  Arr.pop();
					for(var j=0; j< xmlDoc.getElementsByTagName("頁次").length; j++)
					{
						//alert("公司名稱= " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("公司名稱").text);
						if (xmlDoc.documentElement.childNodes.item(j).selectSingleNode("公司名稱").text != "xxx")
						{
							// 若 固定頁次=是, 則其 新頁次 = 刊登頁碼之DB值
							//alert("固定頁次註記(" + j + ")= " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("固定頁次註記").text);
							
							if(xmlDoc.documentElement.childNodes.item(j).selectSingleNode("固定頁次註記").text=="是")
							{
								// 抓出 其刊登頁碼之值
								FixPageNo = xmlDoc.documentElement.childNodes.item(j).selectSingleNode("刊登頁碼").text;
								//alert("FixPageNo= " + FixPageNo);
								if(xmlDoc.documentElement.childNodes.item(j).selectSingleNode("廣告篇幅").text=="半頁")
									FixPageNo = parseInt(FixPageNo) - 0.5;
								// 將 刊登頁碼值 塞入 Arr 裡, 以供 doIsInArray() & doNewPageNo() 使用
								Arr.push(FixPageNo);
								//alert("Arr= " + Arr);
								//alert("Arr.length=" + Arr.length);
								
								// 指定 固定頁次=是, 則其 新頁次 = 刊登頁碼之DB值
								//xmlDoc.documentElement.childNodes.item(j).selectSingleNode("刊登頁碼").text = xmlDoc.documentElement.childNodes.item(j).selectSingleNode("刊登頁碼").text;
								//xmlDoc.documentElement.childNodes.item(j).selectSingleNode("頁次").text = FixPageNo;
							}
						}
						// 若公司名稱的值為 "xxx" , 表示為空白的 nodes, 將不做計算頁次的處理, 做清除處理
						else
						{
							//alert("null");
							// 不做任何處理, 清除 頁次 & 刊登頁碼 為空
							xmlDoc.documentElement.childNodes.item(j).selectSingleNode("頁次").text = "";
							xmlDoc.documentElement.childNodes.item(j).selectSingleNode("刊登頁碼").text = "";
						}
					}
					Arr.reverse();
					SortArr();
					//alert("Arr= " + Arr);
					//alert("Arr.length=" + Arr.length);
					
					// pp 為新頁次, 長度由 0 ~ xmlDoc.getElementsByTagName("頁次").length
					//alert(xmlDoc.getElementsByTagName("頁次").length);
					//alert("pageorder.length=" + (document.all.pageorder.length-2) );
					var NewPageNo1 = "";
					var pp = parseInt(document.all("tbxStartPageNo").value)-1;
					var FixedPage = "";
					for(var i=1; i< (xmlDoc.getElementsByTagName("頁次").length-1); i++)
					{
						// 抓出所有落版資料
						// 抓出 行數及其刊登頁碼 之值
						//alert("刊登頁碼(" + i + ")= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text);
						//pp = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text;
							
						// 檢查 新頁次 NewPageNo  是否與 固定頁次註記="是"之刊登頁碼值 相衝突
						// 若 固定頁次註記 為 "否" 時, doIsInArray()
						if(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("固定頁次註記").text != "是")
						{
							// 計算出 新頁次 pp = 1 ~ document.all.pageorder.length-1
							if(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("廣告篇幅").text=="半頁")
							{
								if((i>2) && (xmlDoc.documentElement.childNodes.item(i-1).selectSingleNode("廣告篇幅").text=="全頁") && ((pp%1)!=0))
									pp=pp+0.5;
								pp=pp+0.5;
							}
							else if(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("廣告篇幅").text=="全頁")
								pp = pp + 1;
							else //Error
								pp = pp + 1;
							//alert("計算出 新頁次 " + pp);

							// 新頁次 pp  與 固定頁次之刊登頁碼 Arr[i] 有衝突時
							if(doIsInArray(pp)==1)
							{
								NewPageNo1 = doNewPageNo(pp);
								//alert("NewPageNo1: " +NewPageNo1);
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = Math.ceil(NewPageNo1);
								pp = NewPageNo1;
							}
							// 新頁次 pp  與 固定頁次之刊登頁碼 Arr[i] 無衝突時
							else
							{
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = Math.ceil(pp);
							}
								
						}
						// 若 固定頁次註記 為 "是" 時, 指定其 新頁次 = 刊登頁碼 )
						else
						{
							FixedPage = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text;
							//alert("刊登頁碼= " + FixedPage);	
							xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = FixedPage;
							//alert("頁次= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text);
								
						}
						
						// 6/24/2003 bug: 因修訂了 doSortingXML(), 故移除下段, 否則會發生新頁次由 8, 9, 6, 7 開始排
						// 檢查該固定頁次之頁碼長度, 一律輸出轉為 2位數之數字!
						// 若 新頁次 為個位數, 做前面補零的動作
						//if(document.all.pageorder[i].innerText < 10)
						//{
							//document.all.pageorder[i].innerText = "0" + document.all.pageorder[i].innerText;
							//xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = document.all.pageorder[i].innerText;
						//};
						//alert("document.all.pageorder[i].innerText= " + document.all.pageorder[i].innerText);
					}
					//Sorting
					doSortingXML();
					alert("重排頁次完成...請檢視!");
				}
				
				function doSortingXML()
				{
					var xmlDoc = DSOT.XMLDocument;
					var MinPageNo, SrcPageNo, DesPageNo, ItemtoMoved;
					
					for(var i=1; i< (xmlDoc.getElementsByTagName("頁次").length-2); i++)
					{
						// 6/24/2003 bug: 當新頁次超過100時, 並沒有排在 99之後, 卻排在9之後, 如 10, 100~109, 11, 11x...; 解決: SrcPageNo & DesPageNo 加 parseInt()
						SrcPageNo = parseInt(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text);
						//alert("Item to Compare " + i +" PageNo: " + SrcPageNo);
						MinPageNo = SrcPageNo;
						for(var j=(i+1); j< (xmlDoc.getElementsByTagName("頁次").length-1); j++)
						{
							DesPageNo = parseInt(xmlDoc.documentElement.childNodes.item(j).selectSingleNode("頁次").text);
							//alert("Item to be Compared " + j +" PageNo: " + DesPageNo);
							if(DesPageNo < MinPageNo)
							{
								//alert("Find Smaller Page in Item " +j + " PageNo: " + DesPageNo);
								MinPageNo = DesPageNo;
								ItemtoMoved= j;
							};
						};
						
						//Find Item to Move
						if(MinPageNo != SrcPageNo)
						{
							//alert("Src Item " + i +" Des Item " + ItemtoMoved);
							var OrgNode= xmlDoc.documentElement.childNodes.item(ItemtoMoved).cloneNode(true);
							var newNode = xmlDoc.documentElement.childNodes.item(i).cloneNode(true);
							xmlDoc.documentElement.replaceChild(newNode,xmlDoc.documentElement.childNodes.item(ItemtoMoved));
							xmlDoc.documentElement.replaceChild(OrgNode,xmlDoc.documentElement.childNodes.item(i));
							OrgNode=null;
							newNode=null;
						};
					};
				}
				
				// for doReOrder() 裡使用
				function doIsInArray(pp1)
				{
					// 抓出 固定頁次註記='是' 之刊登頁碼值
					for(var i=0; i< Arr.length; i++)
					{
						//alert("Arr[i]= " + Arr[i] + ", pp1=" + pp1);
						// 若 新頁次 = 固定頁次註記='是' 之刊登頁碼值 時
						if((pp1==Arr[i]) || (Math.ceil(pp1)==Arr[i]) || (pp1==Math.ceil(Arr[i])))
						{
							return 1;
						}
					}
					return 0;
				}
				
				
				// for doReOrder() 裡使用
				function doNewPageNo(pp2)
				{
					var Offset;
					
					while((Offset = doIsPageOccupied(pp2)) != 0)
					{
						pp2 = pp2 + Offset;
					}
					return pp2;
				}
				
				
				// for NewPageNo() 裡使用
				function doIsPageOccupied(pp1)
				{
					// 抓出 固定頁次註記='是' 之刊登頁碼值
					//alert("Arr= "+Arr);
					for(var i=0; i< Arr.length; i++)
					{
						//alert("Arr[i]= " + Arr[i] + ", pp1=" + pp1);
						// 若 新頁次 = 固定頁次註記='是' 之刊登頁碼值 時
						if((pp1==Arr[i]) || (Math.ceil(pp1)==Arr[i]) || (pp1==Math.ceil(Arr[i])))
						{
							//alert("Find");
							if(((pp1%1)!=0) && ((Arr[i]%1)!=0))
							{
								Arr.pop();
								return 0.5;
							}
							else
							{
								Arr.pop();
								return 1;
							};
						};
					}
					return 0;
				}
						
				// function doRePublish() 重新排版，已停用
				
				var srcDSO = new Object();
				var btnPressed=false;
				var srcObj = new Object();
				var srcNode = new Object();
				var segIdx = 0;
				var segOffset = 0;
		</script>
		<!-- idCompanyName 之 OnMouseOver 色塊顏色 -->
		<script language="javascript" event="onmouseover" for="idCompanyName">
					style.backgroundColor='Gold';
					style.cursor="hand";
		</script>
		<!-- idCompanyName 之 OnMouseOut 色塊顏色 -->
		<script language="javascript" event="onmouseout" for="idCompanyName">
					style.backgroundColor='';
					style.cursor="default";
		</script>
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
		</FORM>
	</BODY>
</HTML>
