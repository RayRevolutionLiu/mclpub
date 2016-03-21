<%@ Page language="c#" Codebehind="adpub_main22.aspx.cs" Src="adpub_main22.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main22" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廣告落版資料維護 - 由年月落版進入 步驟二</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO0, DSO1, DSOX -->
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<!-- 目前所在位置 -->
		<CENTER>
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告落版資料的維護: 由年月落版進入&nbsp;步驟二</font>
					</td>
				</tr>
			</table>
			&nbsp;
			<DIV align="center">
			</DIV>
			<DIV align="center">
				&nbsp;
			</DIV>
			<DIV align="center">
				<asp:Label id="lblContMessage" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:Label>
			</DIV>
			<br>
			<!-- Run at Server Form -->
			<form id="adpub_main22" method="post" runat="server">
				<TABLE dataFld="合約書落版刊登資料" id="xmlAdpubData" style="WIDTH: 98%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="落版明細表" id="Table2" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 100%" colSpan="11">
											<FONT color="#ffffff">(10~12) 合約書落版刊登資料</FONT>&nbsp; <FONT color="yellow" size="2">(若落版第一筆的 
												'刊登年月' 未填, 將不做新增落版檔的處理, 您可稍後新增/維護之.)</FONT>
										</TD>
									</TR>
									<TR align="middle" borderColor="#bfcff0" bgColor="#bfcff0">
										<TD noWrap align="middle">
											功能
										</TD>
										<TD>
											序號
										</TD>
										<TD>
											<FONT color="red">* </FONT>刊登年月
											<br>
											(西元6碼, <FONT face="新細明體" color="#c00000">如 200203</FONT>)
											<br>
											/ <FONT color="red">* </FONT>書籍期別 <IMG class="ico" title="書籍期別參考資料" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
										</TD>
										<TD>
											刊登
											<br>
											頁碼
										</TD>
										<TD>
											固定
											<br>
											頁次
											<br>
											註記
											<br>
											<FONT face="新細明體" color="#c00000">(0: 否, 1:是)</FONT>
										</TD>
										<TD>
											廣告色彩
										</TD>
										<TD>
											廣告篇幅
											<br>
											<FONT face="新細明體" color="#c00000">(同月份
												<br>
												=>半頁)</FONT>
										</TD>
										<TD>
											廣告版面
										</TD>
										<TD>
											到稿
											<br>
											註記
											<br>
											<FONT face="新細明體" color="#c00000">(0: 否, 1:是)</FONT>
										</TD>
										<TD>
											發票
											<br>
											收件人
										</TD>
										<TD>
											落版
											<br>
											細節
										</TD>
									</TR>
								</THEAD>
								<TR align="middle" borderColor="#bfcff0" bgColor="#e2eafc">
									<TD>
										<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" src="../images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
									</TD>
									<TD>
										<INPUT dataFld="序號" id="tbxPubSeq" readOnly type="text" maxLength="2" size="2" value="1" name="tbxPubSeq">
									</TD>
									<TD>
										<FONT color="red">* </FONT><INPUT dataFld="刊登年月" id="tbxPubDate" onblur="Javascript:CheckPubDate(this);" type="text" maxLength="6" onchange="Javascript:CheckPubDate2(this);" size="6" name="tbxPubDate">
										/ <FONT color="red">* </FONT><INPUT dataFld="書籍期別" id="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);" type="text" maxLength="4" size="3" name="tbxBkpPno">
										<IMG class="ico" title="書籍期別參考資料" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
									</TD>
									<TD>
										<INPUT dataFld="刊登頁碼" id="tbxPageNo" type="text" maxLength="3" size="3" name="tbxPageNo">
									</TD>
									<TD>
										<INPUT dataFld="固定頁次註記" id="tbxfgFixPage" onblur="Javascript:CheckfgFixPage(this);" type="text" maxLength="1" size="3" name="tbxfgFixPage">
									</TD>
									<TD>
										&nbsp;<SELECT dataFld="廣告色彩代碼" id="ddlColorCode" name="ddlColorCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="廣告篇幅代碼" id="ddlPageSizeCode" name="ddlPageSizeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="廣告版面代碼" id="ddlLTypeCode" name="ddlLTypeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<INPUT dataFld="到稿註記" id="" onblur="Javascript:CheckfgGot(this);" type="text" maxLength="1" size="1" value="0" name="tbxfgGot">
									</TD>
									<TD>
										<IMG class="ico" title="發票廠商收件人詳細資料" onclick="doSelectIMRec(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenIMDetail" type="hidden" size="1" name="hiddenIMDetail" runat="server">
										<LABEL id="lblSingleIMRec" style="COLOR: maroon"></LABEL>
									</TD>
									<TD>
										<IMG class="ico" title="落版細節" onclick="doEditPub(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenPubDetail" type="hidden" size="1" name="hiddenPubDetail" runat="server">
									</TD>
								</TR>
							</TABLE>
							<FONT face="新細明體">註: <font color="#cc0099">數字標示部份</font>表示對映到原書面稿之文字部份, 以方便輸入本電子表單.</FONT>&nbsp;
							<br>
							<FONT face="新細明體">註: 若某欄位前面有 <FONT color="red">* </FONT>符號, 表示該欄是必填資料, 不可空白!</FONT>
							<br>
							<!-- hiddenXML 欄 -->
							<INPUT dataFld="廠商統編" id="hiddenMfrNo" type="hidden" size="10" name="hiddenMfrNo" runat="server">&nbsp;
							<INPUT dataFld="客戶編號" id="hiddenCustNo" type="hidden" size="6" name="hiddenCustNo" runat="server">&nbsp;
							<INPUT dataFld="最後修改日期" id="hiddenModDate" type="hidden" size="8" name="hiddenModDate" runat="server">&nbsp;
							<INPUT dataFld="合約書編號" id="hiddenContNo" type="hidden" size="6" name="hiddenContNo" runat="server">&nbsp;
							<INPUT dataFld="舊合約編號" id="hiddenOldContNo" type="hidden" size="6" name="hiddenOldContNo" runat="server">&nbsp;
							<INPUT dataFld="合約類別代碼" id="hiddenContType" type="hidden" size="2" name="hiddenContType" runat="server">&nbsp;
							<INPUT dataFld="書籍類別代碼" id="hiddenBkcd" type="hidden" size="2" name="hiddenBkcd" runat="server">&nbsp;
							<INPUT dataFld="承辦業務員工號" id="hiddenEmpNo" type="hidden" size="7" name="hiddenEmpNo" runat="server">&nbsp;
							<INPUT id="hiddenLoginEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenLoginEmpNo" runat="server">&nbsp;
							<INPUT id="hiddenModEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenModEmpNo" runat="server">&nbsp;
							<INPUT dataFld="總製稿次數" id="hiddenTotalJTime" type="hidden" maxLength="3" size="3" name="hiddenTotalJTime" runat="server">&nbsp;
							<INPUT dataFld="已製稿次數" id="hiddenMadeJTime" type="hidden" maxLength="3" size="3" name="hiddenMadeJTime" runat="server">&nbsp;
							<INPUT dataFld="總刊登次數" id="hiddenTotalTime" type="hidden" maxLength="3" size="3" name="hiddenTotalTime" runat="server">&nbsp;
							<INPUT dataFld="已刊登次數" id="hiddenPubTime" type="hidden" maxLength="3" size="3" name="hiddenPubTime" runat="server">&nbsp;
							<INPUT dataFld="換稿次數" id="hiddenChangeTime" type="hidden" maxLength="3" size="3" name="hiddenChangeTime" runat="server">&nbsp;
							<INPUT dataFld="發票收件人姓名" id="hiddenInvRec" type="hidden" size="6" name="hiddenInvRec" runat="server">&nbsp;
							<INPUT dataFld="雜誌收件人姓名" id="hiddenMazRec" type="hidden" size="6" name="hiddenMazRec" runat="server">&nbsp;
							<INPUT dataFld="落版明細表" id="hiddenAdPub" type="hidden" size="6" name="hiddenAdPub" runat="server">&nbsp;
							<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">&nbsp;
						</TD>
					</TR>
				</TABLE>
				<!-- Form按鈕 -->
				<DIV align="center">
					<input id="btnSave" onclick="doSubmit()" type="button" value="儲存修改" name="btnSave">&nbsp;&nbsp;
					<input id="btnCancel" onclick='javascritp:window.location.href="adpub_main21.aspx"' type="button" value="取消回上頁" name="btnCancel">
				</DIV>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</CENTER>
		<!-- 此 TEXTAREA 是供檢查 XML 輸出檢查用 -->
		<!--TEXTAREA id="textarea1" name="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// 本段使用 xmlDoc1 取代 xmlDoc0 (不同於 cont_new3.aspx)
		
		
		// 先定義 Object: DSO1, 設定 async = false
		DSO1.XMLDocument.async = false; 
		
		// 定義 xmlDoc1: 歷史的 XML 資料
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.loadXML(document.all("hiddenXML").value);
		//alert(xmlDoc1.xml);
		
		
		// 定義 xmlDoc1 裡的各 XML節點之名稱及其內容
		var xmlMain = xmlDoc1.selectSingleNode("/root");
		var xmlHeader = xmlDoc1.selectSingleNode("/root/合約書內容");
		
		var xmlMfrData = xmlDoc1.selectSingleNode("/root/合約書內容/廠商資料");
		var xmlCustData = xmlDoc1.selectSingleNode("/root/合約書內容/客戶資料");
		var xmlContBasicData = xmlDoc1.selectSingleNode("/root/合約書內容/合約書基本資料");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/合約書內容/寄發票收件人資料");
		var xmlContDetail = xmlDoc1.selectSingleNode("/root/合約書內容/合約書細節");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/發票廠商資料");
		var xmlMazRec = xmlDoc1.selectSingleNode("/root/雜誌收件人資料");
		//alert(xmlMazRec.xml);
		var xmlAdContactor = xmlDoc1.selectSingleNode("/root/合約書內容/廣告聯絡人資料");
		var xmlAdpubData = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料");
		var xmlAdpubItems = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表");
		var xmlAdpubItemInvRec = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
		var xmlAdpubItemDetails = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
		// 用 windows.alert 方式來顯示出 xmlAdpubItems 的內容 (或可改為其他變數名稱), 做為檢查用
		//alert("合約書內容= " + xmlHeader.xml);
		//alert("xmlAdpubData= " + xmlAdpubData.xml);
		//document.all("textarea1").value=xmlMain.xml;
		
		
		// 定義 xmlDocX, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSOX.XMLDocument;
		xmlEmptyAdpubData.load("空白落版刊登資料.xml");
		
		
		// 抓出落版之單一發票收件人姓名
		var idx=xmlAdpubData.childNodes.length;
		var Items = xmlAdpubData.xml;
		strbuf="";
		for(i=0; i<idx; i++){
			Items=xmlAdpubData.childNodes.item(i).selectSingleNode("發票廠商收件人細節");
			//alert("Items(" + i + ")= " + Items.xml);
			//alert("Items.發票收件人姓名(" + i + ")= " + Items.childNodes.item(0).selectSingleNode("發票收件人姓名").text);
			//alert("strbuf= " + strbuf);
			strbuf=Items.childNodes.item(0).selectSingleNode("發票收件人姓名").text;	//<發票收件人姓名>為第二欄
			// 把得出之結果寫回到新增畫面裡 
			document.all("lblSingleIMRec").innerText = strbuf;
		}
		//event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
		
		-->
		</script>
		<script language="javascript">
		<!--
		// 合約書落版刊登資料的功能按鈕: doAddNew, doDelete
			// 新增落版資料項
			function doAddNew(obj)
			{
				var idx = xmlAdpubData.childNodes.length;
				//alert("idx= " + idx);
				
				// 顯示 NodeList 其內容: 二選一方式
				//alert(xmlAdpubData.childNodes.item(0).xml);

				//var xx = "";
				//for(var i=0; i<idx; i++)
				//{
					 //xx+= xmlAdpubData.childNodes.item(i).xml;
				//}
				//alert("xmlAdpubData ="+xx);
				
				
				// index 由 0 開始, 所以 item(0); 並顯示出其序號及刊登日期
				//var newNode = xmlAdpubData.childNodes.item(idx-1).cloneNode(true);
				var newNode = xmlEmptyAdpubData.documentElement.cloneNode(true);
				//alert("newNode= " + newNode.xml)
				
				// 若使用下一行 (表示先在新增一行前, 先將序號加一); 則不用使用下面第二行; 此二行做的事是一樣的, 請二選一
				//newNode.selectSingleNode("序號").text = idx + 1;
				xmlAdpubData.appendChild(newNode);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text = idx + 1;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("落版序號").text = idx + 1;
				
				// 此處為填入第二筆落版資料的預設值, 第一筆的預設值寫在 Submit() 裡
				// 指定 cloneNode 裡的預設值
				xmlAdpubData.childNodes.item(idx).selectSingleNode("客戶編號").text=window.document.all("hiddenCustNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("合約書編號").text=window.document.all("hiddenContNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("合約類別代碼").text=window.document.all("hiddenContType").value;
				
				// -- 本處與 cont_new3.aspx & cont_main3.aspx 不同 --
				// 先自書籍類別代碼抓出 "計劃代號, 成本中心"
				var BookCode = window.document.all("hiddenBkcd").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍類別代碼").text=BookCode;
				
				// 將 落版最後修改日期 Reformat 去除 "/", 以免新增入 c2_pub 時 (因使用 sp_c2_cont_newSave_pub 受限, 必須在新增前先確認資料正確) , 無法去除其 "/", 而造成資料有誤
				var ModDate = window.document.all("hiddenModDate").value;
				ModDate = ModDate.substring(0, 4) + ModDate.substring(5, 7) + ModDate.substring(8, 10);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("落版最後修改日期").text=ModDate;
				// 下一行 coding 與 cont_show.aspx 不同 (同 cont_new3.aspx)
				xmlAdpubData.childNodes.item(idx).selectSingleNode("落版修改業務員工號").text=window.document.all("hiddenEmpNo").value;
				
				//xmlAdpubData.childNodes.item(idx).selectSingleNode("落版細節").text=xmlAdpubData.childNodes.item(idx-1).selectSingleNode("落版細節").text;
				
				// 檢查每一行的出現的序號值是否正確
				//alert("idx= " + idx);
				//alert("序號= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text);
				//alert("落版序號= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("落版序號").text);
				
				//alert(xmlAdpubData.xml);
				
			}

			// 刪除落版資料項
			function doDelete(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				//alert("idx= " + idx);
				var oldNode = xmlAdpubData.childNodes.item(idx);
				//alert("oldNode= " + oldNode);
								
				if(xmlAdpubData.childNodes.length > 1)
				{
					oldNode.parentNode.removeChild(oldNode);
					// 刪除 序號
					for(i=0; i<xmlAdpubData.childNodes.length;i++)
					{
						xmlAdpubData.childNodes.item(i).selectSingleNode("序號").text=i+1;
						xmlAdpubData.childNodes.item(i).selectSingleNode("落版序號").text=i+1;
					}
				}
				
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// cal按鈕的 coding: 抓系統日期
		function pick_date(theField)
		{
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			window.document.all(theField).value=vreturn;
			return true;
			
			// 下段不用 run, 因 doSubmit() 已寫入 xmlContBasicData.selectSingleNode("簽約日期").text 資料
			//if(vreturn)
				//xmlContBasicData.selectSingleNode("簽約日期").text=vreturn;
			//return true;
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//檢查落版輸入之 "刊登年月" 的值是否正確
		function CheckPubDate(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// 判斷刊登年月的長度是否為 6碼
			var yyyymm = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			if(yyyymm.length!=6)
			{
				alert("落版第 " + (idx+1) + " 筆 '刊登年月' 的長度必須為 6碼(西元), 請修正!");
				return;
			}
			// 若刊登年月的長度為 6碼 (合理)
			else
			{
				// 檢查是否輸入為 數字型態
				if(isNaN(yyyymm)==true)
					alert("落版第 " + (idx+1) + " 筆的 '刊登年月' 必須輸入數字型態!");
				
				// 判斷刊登年月是否在 合約起迄日 範圍內
				var ContStartDate = window.document.all("tbxStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("tbxEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				//alert("ContStartDate= " + ContStartDate);
				//alert("ContEndDate= " + ContEndDate);
				if(xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text<ContStartDate || xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text>ContEndDate)
				{
					alert("落版第 " + (idx+1) + " 筆 '刊登年月' 必須在合約起迄範圍內, 請修正!");
					return;
				}
				
				// 並判斷西元刊登年月是否合理化 : 年(4碼, 1990~2200), 月(01~12)
				var yyyy = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text.substring(0, 4);
				var mm = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text.substring(4, 6);

				// 判斷西元刊登年度是否合理化
				if(yyyy<=1990 || yyyy>=2200)
				{
					alert("注意: 落版第 " + (idx+1) + " 筆的刊登年月之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請更正!");
					return;
				}
				else
					yyyymm = yyyymm;
				
				// 判斷西元刊登月份是否合理化
				if(mm>12 || mm<=0)
				{
					alert("注意: 落版第 " + (idx+1) + " 筆的刊登年月之月份 '" + mm + "' 不合理, 請更正!");
					return;
				}
				else
					yyyymm = yyyymm;			
			// 結束 - 若刊登年月的長度為 6碼 (合理)
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 提示因 '刊登年月' 變更, 必須更新 '書籍期別' 的值 (再按一下)
		function CheckPubDate2(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			if(xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text != "")
				alert("您更新了 落版第 " + (idx+1) + " 筆之 '刊登年月' !\n 請再按一下落版第 " + (idx+1) + " 筆之 '書籍期別' 旁的按鈕來更新資料!!!");
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 檢查 "書籍期別" 一欄是否有輸入
		function CheckBookPNo(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);

			var BookPNo = xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍期別").text;
			// 若書籍期別沒有輸入
			if(BookPNo.length==0)
			{
				//alert("落版第 " + (idx+1) + " 筆的 '書籍期別' 為必填!\n 請按下右方按鈕來挑選!");
				return;
			}
			else
			{
				// 檢查是否輸入為 數字型態
				if(isNaN(BookPNo)==true)
					alert("落版第 " + (idx+1) + " 筆的 '書籍期別' 必須輸入數字型態!");
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="書籍期別參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		function doGetBookp(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			myObject.flag=true;
			
			//alert("xmlAdpubItems.xml= " + xmlAdpubItems.xml);
			myObject.xmldata = xmlAdpubItems.xml;
			//myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// 指定傳過去的變數 - 抓出 書籍類別代碼 & 刊登年月, 來找出 書籍期別
			var bkcd = document.all("hiddenBkcd").value.substring(0, 2);
			var ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			//alert("ym= " + ym);
			myObject.bkcd = document.all("hiddenBkcd").value.substring(0, 2);
			myObject.ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			var PageName = "bookp_get.aspx?bkcd=" + bkcd + "&ym=" + ym;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:420px;dialogWidth:350px;dialogLeft:250px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result= " + myObject.result);
			
			if(vreturn)  {
				xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍期別").text = myObject.result;
				// 解決若沒輸入 刊登年月時, 直接按 '書籍期別', 而刊登年月為空 的情況
				xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text = myObject.yyyymm;
				
				// 同上之方法二 - 解決若沒輸入 刊登年月時, 直接按 '書籍期別', 而刊登年月為空 的情況
				//if(xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text=="")  {
					//var CurrentDate = new Date();
					//var Currentyyyy = CurrentDate.getFullYear();
					//var Currentmm = CurrentDate.getMonth()+1;
					//if(Currentmm.length!=2)
						//Currentmm = "0" + Currentmm;
					//var Currentym = Currentyyyy + Currentmm;
					//xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text=Currentym;
				//}
				return true;
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//檢查落版輸入之 "固定頁次註記" 的值是否正確
		function CheckfgFixPage(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgFixPage = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("固定頁次註記").text);
			if(fgFixPage!=1 && fgFixPage!=0)
			{
				alert("落版第 " + (idx+1) + " 筆的固定頁次註記的值錯誤, 請重新輸入!");
				return;
				//window.document.all("tbxfgFixPage").focus();
			}
			
		}
		
		//-->
		</script>
		<script language="javascript">
		<!--
		//檢查落版輸入之 "到稿註記" 的值是否正確
		function CheckfgGot(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgGot = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("到稿註記").text);
			//alert((idx+1) + ", fgFixPage= " + fgFixPage);
			if(fgGot!=1 && fgGot!=0)
			{
				alert("落版第 " + (idx+1) + " 筆的到稿註記的值錯誤, 請重新輸入!");
				return;
				//window.document.all("tbxfgGot").focus();
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 於落版資料處挑出單一發票廠商收件人之功能按鈕: doSelectIMRec()	
		function doSelectIMRec(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			//alert("hiddenInvRec= " + document.all("hiddenInvRec").value);
			
			var Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("發票廠商收件人細節");
			
			// myObject.prexmldata 是給 InvRecSet.aspx 裡 #DSO3 呼叫歷史資料用;
			// 注意: 若沒有先按下 "挑選發票廠商收件人" 按鈕, 則此處 myObject.prexmldata 的資料會是空白的 xmlInvRec
			if(document.all("hiddenInvRec").value=="")
				myObject.prexmldata=xmlInvRec;
			else
				myObject.prexmldata=document.all("hiddenInvRec").value;
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			
			// myObject.xmldata 是給 InvRecSet.aspx 裡 #DSO2 空白xmlInvRec用;
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("發票廠商收件人細節").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// 抓出 系統代碼, 合約書編號; 傳給發票廠商收件人資料之系統代碼, 合約書編號 myObject.Syscd, myObject.ContNo
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			
			// 開啟視窗對話框
			vreturn=window.showModalDialog("InvRecSet.aspx", myObject, "dialogHeight:450px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			if(vreturn)
			{
				Items.parentNode.replaceChild(myObject.result, Items);
				Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("發票廠商收件人細節");
				//alert("Items= " + Items.xml);
				//document.all("textarea1").value=xmlInvRec.xml;
				
				strbuf="";
				for(i=0; i<Items.childNodes.length; i++){
					strbuf+=Items.childNodes.item(i).selectSingleNode("發票收件人姓名").text;	//<姓名>為第二欄
				}
				//alert("strbuf= " + strbuf);
				
				// 把得出之結果寫回到新增畫面裡 
				event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
				//document.all("textarea1").value=Items.xml;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 刊登落版之詳細資料功能按鈕: doEditPub()
		function doEditPub(obj)
		{	
			//alert("xmlAdpubItemDetails= " + xmlAdpubItemDetails.xml);		
			
			// 抓行號
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// 定義 myObject 為視窗回傳值
			var myObject = new Object();
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("落版細節").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			
			// 指定傳過去的變數
			// 此為該筆落版(序號)之 xml 資料
			//alert(xmlAdpubData.childNodes.item(idx).xml);
			
			// 總落版次數, 方便抓出 改稿+新稿之總次數 之 for loop
			myObject.TotalPubSeq=xmlAdpubData.childNodes.length;
			//alert("myObject.TotalPubSeq= " + myObject.TotalPubSeq);
			//alert(xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text);
			
			// 傳入合約書細節之資料 - 總刊登次數, 總製稿次數, 換稿次數
			myObject.tottm=window.document.all("hiddenTotalTime").value;
			myObject.totjtm=window.document.all("hiddenTotalJTime").value;
			//alert("myObject.tottm= " + myObject.tottm);
			myObject.chgjtm=window.document.all("hiddenChangeTime").value;
			// 剩餘之總製稿次數, 方便計算 總製稿次數之剩餘次數
			myObject.hiddenTotalJTime= document.all("hiddenTotalJTime").value;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// 傳入 廠商編號 & 廠商統編, 來參考列出該廠商 曾刊登(並寫回)之所有落版資料
			// 做為輸入 舊稿期別 / 改稿期別 時, 自動動出 舊稿頁碼 / 改稿頁碼 查詢結果
			myObject.contno= document.all("hiddenContNo").value;
			myObject.mfrno = document.all("hiddenMfrNo").value;
			
			// 傳入其他資料, 以在 "落版細節資訊" 下方顯示其相關資料 (解決因 showModalDialog 必須關閉, 才能看前頁資料)
			myObject.pubseq=xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text;
			myObject.yyyymm=xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			myObject.bkpno=xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍期別").text;
			myObject.pgno=xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登頁碼").text;
			myObject.fgfixpage=xmlAdpubData.childNodes.item(idx).selectSingleNode("固定頁次註記").text;
			myObject.clrcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("廣告色彩代碼").text;
			myObject.pgscd=xmlAdpubData.childNodes.item(idx).selectSingleNode("廣告篇幅代碼").text;
			myObject.ltpcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("廣告版面代碼").text;
			
			//定義 AdpubItemDetails 為傳過去的值 落版細節
			var AdpubItemDetails = xmlAdpubData.childNodes.item(idx).selectSingleNode("落版細節");
			//alert("AdpubItemDetails.xml= " + AdpubItemDetails.xml);
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			vreturn=window.showModalDialog("adpub_detail.aspx", myObject, "dialogHeight:300px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result.xml= " + myObject.result.xml);
			
			//取代新的 AdpubItemDetails 資料
			AdpubItemDetails.parentNode.replaceChild(myObject.result, AdpubItemDetails);
			AdpubItemDetails = xmlDoc1.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
			
			// 取代 '剩餘之總製稿次數' hiddenTotalJTime
			document.all("hiddenTotalJTime").value = myObject.hiddenTotalJTime;
			xmlContDetail.selectSingleNode("剩餘製稿次數").text=myObject.hiddenTotalJTime;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// 透過 textarea 做為檢查輸出的 XML 是否正確
			//document.all("textarea1").value=xmlAdpubItemDetails.xml;
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 本表單之 "儲存修改" 按鈕: doSubmit()
		function doSubmit()
		{
			// 本段使用 xmlDoc1 取代 xmlDoc0 (不同於 cont_new3.aspx)
			
			
			// 下段是與 cont_new3.aspx & cont_show.aspx 不同處
			// 更新 最後修改日期
			var ModDate = window.document.all("hiddenModDate").value;
			ModDate = ModDate.substring(0, 4) + ModDate.substring(5, 7) + ModDate.substring(8, 10);
			xmlContBasicData.selectSingleNode("最後修改日期").text=ModDate;
			xmlAdpubItems.selectSingleNode("落版最後修改日期").text=ModDate;
			
			// 落版修改業務員工號
			//xmlAdpubItems.selectSingleNode("落版業務員工號").text=window.document.all("hiddenEmpNo").value;
			xmlAdpubItems.selectSingleNode("落版修改業務員工號").text=window.document.all("hiddenEmpNo").value;
			
			// 更新 已刊登次數 (根據 =落版的總筆數) => 方法一
			//xmlContDetail.selectSingleNode("已刊登次數").text = parseInt(idx);
			//var RestPubTime = parseInt(document.all("tbxTotalTime").value) - parseInt(idx);
			
			// 更新 已刊登次數 & 剩餘刊登次數
			xmlContDetail.selectSingleNode("已刊登次數").text = document.all("hiddenPubTime").value;
			var RestPubTime = parseInt(document.all("hiddenTotalTime").value) - parseInt(document.all("hiddenPubTime").value);
			xmlContDetail.selectSingleNode("剩餘刊登次數").text = RestPubTime;
			//document.all("tbxPubTime").value = parseInt(idx);
			//document.all("tbxRestTime").value = parseInt(document.all("tbxPubTime").value) - parseInt(idx);
			
			
			// 更新 落版最後修改日期, 落版業務員工號, 落版修改業務員工號, 已製稿次數
			var idx = xmlAdpubData.childNodes.length;
			//alert("idx= " + idx);
			//alert("xmlAdpubData= " + xmlAdpubData.xml);
			var i;
			var MadeJTime = 0;
			for(i=0; i<idx; i++) 
			{
				xmlAdpubData.childNodes.item(i).selectSingleNode("落版最後修改日期").text=ModDate;
				xmlAdpubData.childNodes.item(i).selectSingleNode("落版業務員工號").text=window.document.all("hiddenEmpNo").value;
				xmlAdpubData.childNodes.item(i).selectSingleNode("落版修改業務員工號").text=window.document.all("hiddenEmpNo").value;
				//if(xmlAdpubData.childNodes.item(i).selectSingleNode("樣後修改註記").text == "")
					//xmlAdpubData.childNodes.item(i).selectSingleNode("樣後修改註記").text=0;
				//else
					//xmlAdpubData.childNodes.item(i).selectSingleNode("樣後修改註記").text = xmlAdpubData.childNodes.item(i).selectSingleNode("樣後修改註記").text;
				
				//alert("稿件類別代碼= " + xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").xml);
				var drafttp = xmlAdpubData.childNodes.item(i).selectSingleNode("落版細節/稿件類別代碼").text;
				drafttp = parseInt(drafttp);
				//alert("稿件類別代碼= " + drafttp);
				switch(drafttp)
				{
					case 1:
						MadeJTime = parseInt(MadeJTime);
						break;
					case 2:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
					case 3:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
				}
				//alert("MadeJTime=" + MadeJTime);
			}
			//alert("hiddenTotalJTime=" + document.all("hiddenTotalJTime").value);
			//alert("MadeJTime=" + MadeJTime);
			//alert("剩餘製稿次數=" + (parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime)));
			xmlContDetail.selectSingleNode("已製稿次數").text = parseInt(MadeJTime);
			
			// 若 剩餘製稿次數 < 0, 則其值指定為 0
			if((parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime)) > 0)
				xmlContDetail.selectSingleNode("剩餘製稿次數").text = parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime);
			else
				xmlContDetail.selectSingleNode("剩餘製稿次數").text = 0;
			
			
			// 透過 textarea 做為檢查輸出的 XML 是否正確 
			//document.all("textarea1").value=xmlMain.xml;
			//alert(xmlDoc1.xml);
			
			
			//// 測試, 先傳字串給存檔程式 (cont_mainSave.aspx) 看看是否有問題
			//// 若無, 再進行傳 xml 資料
			////  在這邊把 xmlDoc1.xml 的資料傳給存檔程式
			////var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			////xmlHTTP.Open("post", "cont_mainSave.aspx", false);
			// 單傳字串到 cont_newSave.aspx 看看是否抓得到; 若抓得到, 再抓 xmlDoc1
			////xmlHTTP.Send("test");
			////document.all("textarea1").value=xmlHTTP.responseText;
			////var xmlHTTP = null;

			// 開始傳送 xml 資料至資料庫中儲存 ------------------
			// 在這邊把 xmlDoc1.xml 的資料傳給存檔程式
			var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			xmlHTTP.Open("post", "adpub_mainSave.aspx", false);
			xmlHTTP.Send(xmlDoc1);
			
			// 檢查並輸出 xmlHTTP 狀態於本頁 textarea1 內
			////alert(xmlHTTP.responseText);
			//document.all("textarea1").value=xmlHTTP.responseText;
			
			// 若儲存成功, 以警告視窗顯示
			if(xmlHTTP.statusText=="OK")
			{
				alert("修改落版成功");
				window.location.href="/mrlpub/d2/cont_SaveMessage.aspx?str=adpub_mainSave";
				//if(window.confirm("修改成功,要繼續修改其他落版?"))
				//{
					//if(window.document.all("hiddenContType").value=="01")
						//window.location.href="cont_main1.aspx?function1=mod&conttp=01";
					//else if(window.document.all("hiddenContType").value=="09")
						//window.location.href="cont_main1.aspx?function1=mod&conttp=09";
				//}
				//else
					//window.location.href="http://140.96.18.18/mrlpub/";
			}
			
			// 清除 xmlHTTP 資料為空
			var xmlHTTP = null;
		}
		//-->
		</script>
		</FONT>
	</BODY>
</HTML>
