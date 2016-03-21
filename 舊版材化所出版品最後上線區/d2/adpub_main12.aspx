<%@ Page language="c#" Codebehind="adpub_main12.aspx.cs" Src="adpub_main12.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main12" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告落版資料維護 - 由合約書進入 步驟二</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO0, DSO1, DSOX -->
		<OBJECT id="DSO0" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// 先定義 Object: DSO0, DSO1, DSOX; 設定 async = false
		DSO0.XMLDocument.async = false;
		DSO1.XMLDocument.async = false; 
		DSOX.XMLDocument.async = false;
		
		// 定義 xmlDoc0
		var xmlDoc0 = DSO0.XMLDocument;
		xmlDoc0.load("空白合約書.xml");
		//alert(xmlDoc0.xml);
		
		// 定義 xmlDoc0 裡的各 XML節點之名稱及其內容
		var xmlMain = xmlDoc0.selectSingleNode("/root");
		var xmlMfrCust = xmlDoc0.selectSingleNode("/root/廠商及客戶資料");
		var xmlContBasicData = xmlDoc0.selectSingleNode("/root/合約內容");
		var xmlInvRec = xmlDoc0.selectSingleNode("/root/寄發票收件人資料");
		var xmlPubData = xmlDoc0.selectSingleNode("/root/刊登細節");
		var xmlMazRec = xmlDoc0.selectSingleNode("/root/雜誌收件人資料");
		var xmlAdContactor = xmlDoc0.selectSingleNode("/root/廣告聯絡人資料");
		
		var xmlAdpubData = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料");
		var xmlAdpubItems = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料/落版明細表");
		var xmlAdpubItemDetails = xmlDoc0.selectSingleNode("/root/合約書落版刊登資料/落版明細表/落版更多細節");
		
		// 定義 xmlDoc1, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSO1.XMLDocument;
		xmlEmptyAdpubData.load("空白項目一.xml");

		// 定義 xmlDocX
		var xmlDocX = DSOX.XMLDocument;
		
		// 用 windows.alert 方式來顯示出 xmlAdpubItems 的內容, 做為檢查用
		//alert(xmlAdpubData.xml);
		
		//xmlHeader.selectSingleNode("訂戶編號").text=window.document.all("hiddenId").value;
		//xmlHeader.selectSingleNode("訂購日期").text=window.document.all("hiddenDate").value;
		-->
		</script>
		<script language="javascript">
		<!--
		// 合約書落版刊登資料的功能按鈕: AddNew, Delete, Copy
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
				
				
				// index 由 0 開始, 所以 item(0)
				var newNode = xmlAdpubData.childNodes.item(idx-1).cloneNode(true);
				//alert("newNode= " + newNode.xml)
				// 若使用下一行 (表示先在新增一行前, 先將序號加一), 則不用使用下面第二行; 此二行做的事是一樣的
				//newNode.selectSingleNode("序號").text = idx + 1;
				xmlAdpubData.appendChild(newNode);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text = idx + 1;
				// 檢查每一行的出現的序號值是否正確
				//alert("idx= " + idx);
				//alert("序號= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("序號").text);
			}

			function doDelete(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				var oldNode = xmlItems.childNodes.item(idx);
				
				if(xmlItems.childNodes.length <= 1)
				{
					var newNode = xmlEmptyItem.documentElement.cloneNode(true);
					xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
				}
				oldNode.parentNode.removeChild(oldNode);
				doSum();
			}
			
			function doCopy(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				var newNode = xmlAdpubItems.childNodes.item(idx).cloneNode(true);
				xmlAdpubItems.insertBefore(newNode, xmlAdpubItems.childNodes.item(idx).nextSibling);
				doSum();
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 雜誌收件人之詳細資料功能按鈕: AddMazRecData()
			function AddMazRecData()
			{
				// 使用 showModalDialog 來開細節之視窗
				strFeature = "";
				strFeature += "dialogHeight:400px;dialogWidth:580px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//	oParam.type = vType;
				//	oParam.keyword = vKeyword;
				//Disable next line temperly
				//var vReturn = window.showModalDialog("or_detail.aspx", oParam, strFeature); 
				
				// 改用 windows.open 來取代 showModalDialog 來開新視窗
				var vReturn = window.open("or_detail.aspx", "_new", "Width=580px, Height=340px");
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 抓出所有雜誌收件人之姓名的功能按鈕: doGetAllMazRec()
		function doGetAllMazRec()
		{
			var myObject = new Object();
				//    myObject.id=id;
				//    myObject.type1=type;
				//    myObject.seq=seq;
				//alert(document.all("hiddenRec").value);
			
			// 若 hiddenRec 無資料, 則顯示訊息 "沒有歷史資料~"
			// 否則, 先顯示 hiddenRec 裡的資料
			if(document.all("hiddenRec").value==""){
				myObject.flag=false;
				alert("沒有歷史資料, 請自行輸入資料");
			}
			else{
			    myObject.flag=true;
				myObject.prexmldata=document.all("hiddenRec").value;
			}
		 myObject.xmldata=xmlMazRec.xml;
		//alert(myObject.xmldata.xml);
		
		// 開啟視窗對話框
		vreturn=window.showModalDialog("MazRecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:780px;center:yes;scroll:yes;status:no;help:no;"); 
		
		//取代新的 xmlMazRec 資料
		xmlMazRec.parentNode.replaceChild(myObject.result, xmlMazRec);
		xmlMazRec = xmlDoc0.selectSingleNode("/root/雜誌收件人資料");
		//自前頁, 計抓出幾筆資料 xmlMazRec.childNodes.length
		//alert("xmlMazRec.childNodes.length = " + xmlMazRec.childNodes.length);

		// 抓出挑選出的所有雜誌收件人姓名, 並以 "," 符號隔開
		strbuf="";
		for(i=0; i<xmlMazRec.childNodes.length; i++){
			strbuf+=xmlMazRec.childNodes.item(i).selectSingleNode("雜誌收件人姓名").text+",";	//<姓名>為第二欄
		}
		document.all("lblRec").innerText=strbuf;
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 刊登落版之詳細資料功能按鈕: doPubDetail()
			function doPubDetail()
			{
				// 使用 showModalDialog 來開細節之視窗
				strFeature = "";
				strFeature += "dialogHeight:480px;dialogWidth:450px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//Disable next line temperly
				//var vReturn = window.showModalDialog("pubim_detail.aspx", oParam, strFeature); 
				
				// 改用 windows.open 來取代 showModalDialog 來開新視窗
				var vReturn = window.open("adpub_detail.aspx", "_blank", "Width=600px, Height=480px, top=20px, left=50px, Toolbar=no"); 
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// cal按鈕的 coding: 抓系統日期
		function pick_date(theField)
			{
			ret=window.open("cal.aspx?field_name="+ theField, "Poping", "toolbar=no,menubar=no,width=320,height=200", false);
			return true;
			}
		//-->
		</script>
		<script language="Javascript">
		<!--
		 // 連結廠商細節的按鈕
			function doSelectMfr(vType, vKeyword)
			{
				strFeature = "";
				strFeature += "dialogHeight:300px;dialogWidth:420px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//	oParam.type = vType;
				//	oParam.keyword = vKeyword;
				var vReturn = window.showModalDialog("Mfrim_detail.aspx", oParam, strFeature); 
				
				if(vReturn!=null)
				{
					//xmlDocX.loadXML(vReturn);
					//tbx_contno.value=xmlDocX.documentElement.selectSingleNode("姓名").text;
				}
			}
		//-->
		</script>
		<script language="Javascript">
		<!--
		 // 連結客戶細節的按鈕
			function doSelectCust(vType, vKeyword)
			{
				strFeature = "";
				strFeature += "dialogHeight:300px;dialogWidth:420px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//	oParam.type = vType;
				//	oParam.keyword = vKeyword;
				var vReturn = window.showModalDialog("訂戶查詢.htm", oParam, strFeature); 
				
				if(vReturn!=null)
				{
					//xmlDocX.loadXML(vReturn);
					//tbx_contno.value=xmlDocX.documentElement.selectSingleNode("姓名").text;
				}
			}
		//-->
		</script>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- 頁首 Header -->
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告落版資料維護 - 由合約書進入 步驟二</font>&nbsp;
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- 標題 -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">廣告落版資料的維護 - 由合約書進入</FONT></B> <STRONG><FONT color="red" size="2">
						(落版部份測試修改中...)</FONT></STRONG>
				<br>
				<FONT color="darkred" size="3">(步驟二: 修改本合約書所有的落版資料</FONT><FONT color="#8b0000">)</FONT>
			</DIV>
			<!-- Run at Server Form -->
			<form id="adpub_main12" method="post" runat="server">
				<!--Table 開始-->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<!-- 客戶資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(2) 廠商及客戶資料</font>
						</td>
					</TR>
					<!-- 廠商資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT color="#cc0099">(2)</FONT> 公司名稱/商號 (廠商統編)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCompanyName" runat="server" Height="18px"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblMfrNo" runat="server" Height="18px"></asp:label>
								) </FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<!--FONT face="新細明體"><IMG class="ico" title="廠商詳細資料" onclick="doSelectMfr('訂戶類別', lblMfrNo.value)" src="../images/edit.gif" width="18" border="0"></FONT-->
							<br>
							<FONT face="新細明體"><IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0"></FONT>
						</TD>
					</TR>
					<!-- 公司負責人資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							公司負責人姓名及職稱：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrRespName" runat="server" Height="18px"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblMfrRespJobTitle" runat="server" Height="18px"></asp:label>
								) </FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							公司電話：
							<br>
							公司傳真：
						</TD>
						<TD class="cssData">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblMfrTel" runat="server" Height="18px"></asp:label>
							<br>
							<asp:label id="lblMfrFax" runat="server" Height="18px"></asp:label>
						</TD>
					</TR>
					<!-- 客戶資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							客戶姓名 (客戶編號)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server" Height="18px"></asp:label>
							<FONT face="新細明體">&nbsp;</FONT> <FONT face="新細明體">(</FONT>
							<asp:label id="lblCustNo" runat="server" Height="18px"></asp:label>
							<FONT face="新細明體">)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<FONT face="新細明體"><IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0"></FONT>
						</TD>
					</TR>
					<!-- 合約書內容 -->
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">合約內容</font>
						</td>
					</tr>
					<TR>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<font color="#cc0099">(1)</font> 簽約日期：
						</TD>
						<TD class="cssData">
							<asp:label id="lblSignDate" runat="server" Height="18px"></asp:label>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							合約編號：
						</TD>
						<TD class="cssData">
							<asp:label id="lblContNo" runat="server" Height="18px"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" style="HEIGHT: 18px" noWrap align="right">
							合約類別：
						</TD>
						<TD class="cssData">
							<asp:dropdownlist id="ddlContType" runat="server" Height="18px" Enabled="False" AutoPostBack="True">
								<asp:ListItem Value="0" Selected="True">請選擇...</asp:ListItem>
								<asp:ListItem Value="1">一般合約</asp:ListItem>
								<asp:ListItem Value="2">推廣合約</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							書籍類別：
						</TD>
						<TD class="cssData" style="HEIGHT: 18px">
							<asp:dropdownlist id="ddlBookCode" runat="server" Height="18px" Enabled="False" AutoPostBack="True">
								<asp:ListItem Value="0" Selected="True">請選擇...</asp:ListItem>
								<asp:ListItem Value="工材">工材</asp:ListItem>
								<asp:ListItem Value="電材">電材</asp:ListItem>
								<asp:ListItem Value="工材叢書">工材叢書</asp:ListItem>
								<asp:ListItem Value="電材叢書">電材叢書</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							<font color="#cc0099">(7)</font> 合約起迄日：
						</TD>
						<TD class="cssData" noWrap>
							<asp:textbox id="tbxStartDate" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="65px"></asp:textbox>
							&nbsp; <font size="3">~ </font>
							<asp:textbox id="tbxEndDate" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="65px"></asp:textbox>
							&nbsp;,
							<br>
							<FONT size="2">共</FONT>
							<asp:label id="lblCountDateMonths" runat="server" Height="18px">12</asp:label>
							<FONT size="2">期&nbsp; </FONT><FONT color="red" size="1">(預設值為一年)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							承辦業務員：
						</TD>
						<TD class="cssData">
							<asp:label id="lblEmpNo" runat="server" Height="18px" ForeColor="red"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							一次付清註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="新細明體"><FONT face="新細明體"><FONT face="新細明體">院/所內註記</FONT>：</FONT></FONT>
						</TD>
						<TD class="cssData">
							<asp:radiobuttonlist id="rblfgITRI" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							指定頁次註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgFixPage" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="新細明體"><FONT face="新細明體">結案註記</FONT>：</FONT>
						</TD>
						<TD class="cssData">
							<asp:radiobuttonlist id="rblfgClosed" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
								<asp:ListItem Value="6">是: 所內</asp:ListItem>
								<asp:ListItem Value="7">是: 院內</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							<FONT face="新細明體">最後修改日</FONT>：
						</TD>
						<TD class="cssData" noWrap>
							<asp:label id="lblModDate" runat="server" Height="18px"></asp:label>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="新細明體"><FONT face="新細明體">舊合約編號</FONT>：</FONT>
						</TD>
						<TD class="cssData">
							<asp:label id="lblOldContNo" runat="server" Height="18px"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							發票類別：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblInvCode" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">二聯</asp:ListItem>
								<asp:ListItem Value="2" Selected="True">三聯</asp:ListItem>
								<asp:ListItem Value="3">其他</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="新細明體">發票課稅別：</FONT>
						</TD>
						<TD class="cssData">
							<asp:radiobuttonlist id="rblTaxType" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">應稅 5%</asp:ListItem>
								<asp:ListItem Value="2">零稅</asp:ListItem>
								<asp:ListItem Value="3">免稅</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
					<!-- 刊登細節 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(9) 刊登細節</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
							<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" border="0">
								<TBODY>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(9)</font> 總製稿次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxTotalJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											已製稿次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxMadeJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											剩餘製稿次數：&nbsp;
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxRestJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											總刊登次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxTotalTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											已刊登次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxPubTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											剩餘刊登次數：&nbsp;
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxRestTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(11)</font> 合約總金額：
										</TD>
										<TD class="cssData">
											<FONT face="新細明體">$</FONT>
											<asp:textbox id="tbxTotalAmt" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="55px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											已繳金額：
										</TD>
										<TD class="cssData">
											<FONT face="新細明體">$</FONT>
											<asp:textbox id="tbxPaidAmt" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="55px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											剩餘金額：
										</TD>
										<TD class="cssData">
											<FONT face="新細明體">$</FONT>
											<asp:textbox id="tbxRestAmt" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="55px"></asp:textbox>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(9)</font> 換稿次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxChangeJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											<FONT color="#cc0099">(9)</FONT> 贈送次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxFreeTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											<FONT color="#cc0099">(9)</FONT> 優惠折數：&nbsp;
										</TD>
										<TD class="cssData">
											<FONT face="新細明體">
												<asp:textbox id="tbxDiscount" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
												折</FONT>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											彩色次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxColorTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											黑白次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxMenoTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											套色次數：
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxGetColorTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
									</TR>
					</TR>
					<TR vAlign="center" align="left">
						<TD class="cssTitle" noWrap align="right">
							贈送本數：
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxFreeBookCount" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData">
							&nbsp;
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData">
							&nbsp;
						</TD>
					</TR>
				</TABLE>
				</TD></TR> 
				<!-- 廣告聯絡人資料 -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">(6) 廣告聯絡人資料</font>
					</td>
				</tr>
				<TR>
					<TD class="cssTitle" noWrap align="right">
						<FONT color="#cc0099">(6)</FONT> 廣告聯絡人姓名：
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuName" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="65px"></asp:textbox>
					</TD>
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						<FONT face="新細明體"></FONT>
					</TD>
					<TD class="cssData" noWrap>
						&nbsp;</FONT>
					</TD>
				</TR>
				<TR>
					<TD class="cssTitle" noWrap align="right">
						電話：
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuTel" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="85px"></asp:textbox>
					</TD>
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						傳真：
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuFax" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="85px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="cssTitle" noWrap align="right">
						手機：
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuCell" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="85px"></asp:textbox>
					</TD>
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						Email：
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuEmail" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="180px"></asp:textbox>
					</TD>
				</TR>
				</TBODY></TABLE> 
				<!-- 落版刊登資料 -->
				<TABLE dataFld="合約書落版刊登資料" id="Table1" style="WIDTH: 90%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="落版明細表" id="tbItems" style="WIDTH: 100%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 100%" colSpan="11">
											<FONT color="white">(10~12) 合約書落版刊登資料</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0" align="middle">
										<TD nowrap>
											功能
										</TD>
										<TD>
											序號
										</TD>
										<TD>
											刊登 年月
										</TD>
										<TD>
											刊登
											<br>
											頁碼
										</TD>
										<TD>
											廣告色彩
										</TD>
										<TD>
											廣告篇幅
										</TD>
										<TD>
											廣告版面
										</TD>
										<TD>
											份數
										</TD>
										<TD>
											到稿
											<br>
											註記
										</TD>
										<TD>
											業務員
											<br>
											工號
										</TD>
										<TD>
											修改
											<br>
											細節
										</TD>
									</TR>
								</THEAD>
								<TR borderColor="#bfcff0" bgColor="#e2eafc">
									<TD>
										<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="../images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" height="14" src="../images/cut.gif" width="9" border="0">
									</TD>
									<TD>
										<INPUT dataFld="序號" id="tbxPubSeq" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="2" size="2" value="1" name="tbxPubSeq">
									</TD>
									<TD>
										<INPUT dataFld="刊登年月" id="tbxPubDate" style="WIDTH: 50px; HEIGHT: 22px" type="text" maxLength="6" size="6" name="tbxPubDate">
									</TD>
									<TD>
										<INPUT dataFld="刊登頁碼" id="tbxPageNo" style="WIDTH: 22px; HEIGHT: 22px" type="text" maxLength="6" size="3" name="tbxPageNo">
									</TD>
									<TD>
										<SELECT dataFld="廣告色彩" id="ddlColorCode" name="ddlColorCode" runat="server" size="1">
											<OPTION value="00" selected>
												請選擇...</OPTION>
											<OPTION value="01">
												彩色</OPTION>
											<OPTION value="02">
												黑白</OPTION>
											<OPTION value="03">
												套色</OPTION>
										</SELECT>
									</TD>
									<TD>
										<SELECT dataFld="廣告篇幅" id="ddlPageSizeCode" name="ddlPageSizeCode" runat="server" size="1">
											<OPTION value="00" selected>
												請選擇...</OPTION>
											<OPTION value="01">
												全頁</OPTION>
											<OPTION value="02">
												半頁</OPTION>
										</SELECT>
									</TD>
									<TD>
										<SELECT dataFld="廣告版面" id="ddlLTypeCode" name="ddlLTypeCode" runat="server" size="1">
											<OPTION value="00" selected>
												請選擇...</OPTION>
											<OPTION value="01">
												特別-封面</OPTION>
											<OPTION value="02">
												特別-封面裡頁</OPTION>
											<OPTION value="03">
												特別-底面</OPTION>
											<OPTION value="04">
												特別-底面裡頁</OPTION>
											<OPTION value="05">
												首頁</OPTION>
											<OPTION value="06">
												內頁</OPTION>
										</SELECT>
									</TD>
									<TD>
										<INPUT dataFld="份數" id="tbxCnt" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="3" size="3" name="tbxCnt">
									</TD>
									<TD>
										<INPUT dataFld="到稿註記" id="cbxfgGot" type="checkbox" name="cbxfgGot">
									</TD>
									<TD>
										<INPUT dataFld="業務員工號" id="tbxEmpNo" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="5" size="5" name="tbxEmpNo">
									</TD>
									<TD>
										<IMG class="ico" title="落版更多細節" onclick="doPubDetail()" src="../images/edit.gif" border="0">
									</TD>
								</TR>
							</TABLE>
							<FONT face="新細明體">註:&nbsp;落版刊登資料的 新增</FONT> <FONT face="新細明體">及 刪除 功能尚未完成!</FONT>
							<br>
							<FONT face="新細明體">註: <font color="#cc0099">數字標示部份</font>表示對映到原書面稿之文字部份, 以方便輸入本電子表單.</FONT>
							<br>
							<FONT face="新細明體" color="red">註: 本網頁之合約書僅供瀏覽參考, 不允許修改; 若要修改, 請由 "合約書維護" 來做.</FONT>
							<br>
							<!-- Form按鈕 -->
							<div align="center">
								<INPUT id="btn_add" onclick="Javascript: AddToDB()" type="button" value="確定修改" name="btn_modify">&nbsp;&nbsp;
								<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="關閉視窗" name="btn_close">
								註: 確定修改的按鈕目前尚未完成!
							</div>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</BODY>
</HTML>
