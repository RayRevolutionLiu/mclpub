<%@ Page language="c#" Codebehind="FreeForm.aspx.cs" src="FreeForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.FreeForm" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<OBJECT id="DSO0" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
	</HEAD>
	<body>
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="OrderForm" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 706px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								訂單處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0"><asp:Label ID="lblTitle" Runat="server"></asp:Label><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								新增訂單</font>
						</td>
					</tr>
				</table>
				<TABLE dataFld="訂單" id="MainTable" style="WIDTH: 615px; HEIGHT: 205px" dataSrc="#DSO0" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 108px" align="right">
							訂戶編號：
						</TD>
						<TD style="WIDTH: 192px">
							<FONT color="#0000ff">&nbsp;&nbsp; </FONT>
							<asp:label id="lblInvoiceid" Runat="server" ForeColor="Maroon"></asp:label>
							<FONT color="#0000ff"></FONT><input id="hiddenID" type="hidden" name="hiddenID" runat="server">
							<INPUT id="hiddenMfrno" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenFgoi" runat="server">
							<input id="hiddenPreXml" type="hidden" name="hiddenPreXml" runat="server"> <input id="hiddenBook" type="hidden" name="hiddenBook" runat="server">
						</TD>
						<TD style="WIDTH: 108px" align="right">
							訂戶姓名：
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:label id="lblName" Runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<tr>
						<TD style="WIDTH: 108px" align="right">
							公司名稱：
						</TD>
						<TD style="WIDTH: 192px" colSpan="3">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:label id="lblCoName" Runat="server" ForeColor="Maroon"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoName" runat="server">
							<INPUT id="hiddenCoAddress" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoAddress" runat="server">
						</TD>
					</tr>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂單資料</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							訂單流水號：
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp;
							<asp:label id="lblOrderNo" runat="server" ForeColor="Maroon"></asp:label>
							<input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂單來源：
						</td>
						<td style="WIDTH: 235px">
							&nbsp;&nbsp; <SELECT dataFld="訂單來源" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							訂購日期：
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp; <input id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" name="tbxOrderDate" runat="server">
							<IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate.name)" src="../images/calendar01.gif">
							<INPUT id="hiddenDate" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenDate" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂購類別：
						</td>
						<td style="WIDTH: 257px">
							&nbsp;&nbsp;
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly="True" Width="38px"></asp:textbox>
							<SELECT dataFld="訂購類別" id="ddlOrderType2" name="ddlOrderType2" runat="server"></SELECT>
							<input id="hiddenType1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hiddenType1" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							承辦業務員：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							&nbsp;&nbsp; <SELECT dataFld="承辦人員" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">收件人資料</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							收件人：
						</TD>
						<TD style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetRec()" src="images/new.gif" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</TD>
					</TR>
				</TABLE>
				<TABLE dataFld="訂單明細" id="Table1" dataSrc="#DSO0" cellSpacing="0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="明細表" id="tbItems" style="WIDTH: 615px" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 639px" colSpan="10">
											<FONT color="white">訂單明細資料</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0">
										<TD style="WIDTH: 45px; HEIGHT: 6px">
											功能
										</TD>
										<TD style="WIDTH: 37px">
											項次
										</TD>
										<TD style="WIDTH: 98px" align="middle">
											書籍類別
										</TD>
										<TD style="WIDTH: 96px" align="middle">
											計劃代號
										</TD>
										<TD style="WIDTH: 108px" align="middle">
											訂閱起時
										</TD>
										<TD style="WIDTH: 105px" align="middle">
											訂閱訖時
										</TD>
										<TD style="WIDTH: 50px" align="middle">
											總數量
										</TD>
										<TD style="WIDTH: 49px" align="middle">
											收件人
										</TD>
									</TR>
								</THEAD>
								<TR borderColor="#bfcff0" bgColor="#e2eafc">
									<TD style="WIDTH: 45px">
										<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
									</TD>
									<TD style="WIDTH: 37px">
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 98px">
										<SELECT dataFld="書籍類別" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT>
									</TD>
									<TD style="WIDTH: 96px">
										<INPUT dataFld="計劃代號" id="tbxProj" style="WIDTH: 85px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="7" name="tt3">
										<INPUT dataFld="成本中心" id="hiddenCostctr" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="7" name="hiddenCostctr" runat="server">
									</TD>
									<TD style="WIDTH: 108px">
										<INPUT dataFld="訂閱起時" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt4">
										<IMG class="ico" title="日曆" onclick="pick_dateStart(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 105px">
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<IMG class="ico" title="日曆" onclick="pick_dateEnd(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 50px">
										<INPUT dataFld="總數量" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</TD>
									<TD style="WIDTH: 49px">
										&nbsp; <IMG class="ico" title="收件人詳細資料" onclick="doSelectRec(this)" src="images/edit.gif" border="0">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<input id="btnSave" onclick="doSubmit()" type="button" value="儲存訂單"><input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="取消回首頁">
			</center>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
DSO0.XMLDocument.async = false;
DSO1.XMLDocument.async = false; 
DSOX.XMLDocument.async = false;

var xmlDoc0 = DSO0.XMLDocument;
xmlDoc0.load("空白訂單一.xml");
//alert(xmlDoc0.xml);
//var xmlOwner = xmlDoc0.selectSingleNode("/root/訂戶");
var xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
xmlReceivers.childNodes.item(0).selectSingleNode("公司名稱").text=document.all("hiddenCoName").value;
xmlReceivers.childNodes.item(0).selectSingleNode("地址").text=document.all("hiddenCoAddress").value;
xmlReceivers.childNodes.item(0).selectSingleNode("序號").text="01";
var xmlRecItem = xmlDoc0.selectSingleNode("/root/投遞資料");
var xmlItems = xmlDoc0.selectSingleNode("/root/訂單明細");
var xmlHeader = xmlDoc0.selectSingleNode("/root/訂單");
var xmlMain = xmlDoc0.selectSingleNode("/root");
var xmlEmptyItem = DSO1.XMLDocument;
xmlEmptyItem.load("空白項目一.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.all("hiddenBook").value);
var ItemBook=xmlDocX.selectSingleNode("書籍資料");
//xmlHeader.selectSingleNode("訂戶編號").text=window.document.all("hiddenId").value;
//xmlHeader.selectSingleNode("訂購日期").text=window.document.all("hiddenDate").value;
		</script>
		<script language="javascript">
function doAddNew(obj)
{
//	var idx=obj.parentElement.parentElement.rowIndex-1;
//	var idx = obj.recordNumber-1;
	var idx = xmlItems.childNodes.length;
//	xmlEmptyItem.documentElement.childNodes.item(0).text=idx;
	var newNode = xmlEmptyItem.documentElement.cloneNode(true);
//	newNode.selectSingleNode("項次").text=idx;
//	xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
	xmlItems.appendChild(newNode);
	var	j1=String(idx+1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx).selectSingleNode("項次").text=j1;
	}
	else
		xmlItems.childNodes.item(idx).selectSingleNode("項次").text=idx+1;
}
function doDelete(obj){
	var idx = obj.recordNumber-1;
	var oldNode = xmlItems.childNodes.item(idx);
	if(xmlItems.childNodes.length > 1){
		oldNode.parentNode.removeChild(oldNode);
		for(i=0; i<xmlItems.childNodes.length;i++){
			j1=String(i+1);
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(i).selectSingleNode("項次").text=j1;
			}
			else
				xmlItems.childNodes.item(i).selectSingleNode("項次").text=i+1;
		}
	}
}

function doSelectBook(obj)
{
	var idx = obj.recordNumber-1;
	BookType=xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
	for(i=0; i<ItemBook.childNodes.length; i++){
		if((ItemBook.childNodes.item(i).selectSingleNode("obtp_otp1cd").text==document.all("hiddenType1").value)&&(ItemBook.childNodes.item(i).selectSingleNode("fgitri").text=="")
			&&(ItemBook.childNodes.item(i).selectSingleNode("obtp_obtpcd").text==BookType)){
			strbuf=ItemBook.childNodes.item(i).selectSingleNode("nostr").text;
			break;
		}
	}
//	strbuf = xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
//	xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text=strbuf.substr(0, 2);
	xmlItems.childNodes.item(idx).selectSingleNode("計劃代號").text=strbuf.substr(2, 10);
	xmlItems.childNodes.item(idx).selectSingleNode("成本中心").text=strbuf.substr(12, 7);

}

function doGetRec()
{
    var myObject = new Object();
//    myObject.id=id;
//    myObject.type1=type;
//    myObject.seq=seq;
//alert(document.all("hiddenRec").value);
	if(document.all("hiddenRec").value==""){
		myObject.flag=false;
		alert("沒有歷史資料, 請自行輸入資料");
	}
	else{
	    myObject.flag=true;
		myObject.prexmldata=document.all("hiddenRec").value;
	}
    myObject.CoName=document.all("hiddenCoName").value;
    myObject.CoAddress=document.all("hiddenCoAddress").value;
    myObject.xmldata=xmlReceivers.xml;
//    alert(myObject.xmldata.xml);
//	strbuf="RecForm.aspx?id="+id+"&type1="+type+"&seq="+seq;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
//    alert(myObject.result.xml);
	if(vreturn){
		xmlReceivers.parentNode.replaceChild(myObject.result, xmlReceivers);
		xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
		strbuf="";
		for(i=0; i<xmlReceivers.childNodes.length; i++){
//			strbuf+=xmlReceivers.childNodes.item(i).childNodes.item(1).text+",";	//<姓名>為第二欄
			strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
		}
		document.all("lblRec").innerText=strbuf;
	}
}
function doSelectRec(obj)
{
	var idx = obj.recordNumber-1;
    var myObject = new Object();
    var Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
    vreturn=window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:750px;"); 
	if(vreturn){
		Items.parentNode.replaceChild(myObject.result, Items);
		Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
		var	amt=0;
		for(i=0; i<Items.childNodes.length; i++){
			amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("郵寄數量").text);	//<姓名>為第二欄
		}
		xmlItems.childNodes.item(idx).selectSingleNode("總數量").text=String(amt);
	}
//	document.all("textarea1").value=xmlItems.xml;
}

function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
function pick_dateStart(obj){
	var idx = obj.recordNumber-1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn){
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱起時").text=vreturn;
		if(window.document.all("hiddenType1").value=="02"){
			year=(parseInt(vreturn.substr(0, 4))+1).toString();
			day=(parseInt(vreturn.substr(8, 2))-1).toString();
			if(day="0")
				day="01";
			if(day.length==1)
				day="0"+day;
			month=vreturn.substr(5, 2);
			
//		LastDate = new Date(year+1, month, day-1);
			if(month=="01")
				xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text=parseInt(year-1).toString()+"/"+"12/31";
			else{
				xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text=year+"/"+month+"/"+day;
			}	
		}
		else if(window.document.all("hiddenType1").value=="03")
			xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text="9999/01/01";
	}
	return true;
}
function pick_dateEnd(obj){
	var idx = obj.recordNumber-1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature);
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text=vreturn;
	return true;
}
function doSubmit()
{
	xmlHeader.selectSingleNode("系統代碼").text="C1";
	xmlHeader.selectSingleNode("訂戶編號").text=window.document.all("hiddenID").value;
	xmlHeader.selectSingleNode("訂單流水號").text=window.document.all("hiddenOrderNo").value;
	xmlHeader.selectSingleNode("訂購類別一").text=window.document.all("hiddenType1").value;
	xmlHeader.selectSingleNode("訂購類別二").text=window.document.all("ddlOrderType2").value;
	xmlHeader.selectSingleNode("預開發票").text="0";
//	xmlHeader.selectSingleNode("承辦人員").text="840695";
	xmlHeader.selectSingleNode("統一編號").text=window.document.all("hiddenMfrno").value;
	xmlHeader.selectSingleNode("訂購日期").text=window.document.all("tbxOrderDate").value;
/*	document.all("tbxOrderDate").value=document.all("tbxOrderDate").value.replace("/", "");
	document.all("tbxOrderDate").value=document.all("tbxOrderDate").value.replace("/", "");
	xmlHeader.selectSingleNode("訂購日期").text=window.document.all("tbxOrderDate").value;
	document.all("tbxStartDate").value=document.all("tbxStartDate").value.replace("/", "");
	document.all("tbxStartDate").value=document.all("tbxStartDate").value.replace("/", "");
	xmlItems.selectSingleNode("訂閱起時").text=window.document.all("tbxStartDate").value;
	document.all("tbxEndDate").value=document.all("tbxEndDate").value.replace("/", "");
	document.all("tbxEndDate").value=document.all("tbxEndDate").value.replace("/", "");
	xmlItems.selectSingleNode("訂閱訖時").text=window.document.all("tbxEndDate").value;*/

//  在這邊把xmlDoc0.xml的資料傳給存檔程式
//	document.all("textarea1").value=xmlMain.xml;
	var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
	xmlHTTP.Open("post", "SaveOrder.aspx", false);
//	xmlHTTP.Open("post", "訂單.aspx", false);
	xmlHTTP.Send(xmlDoc0);
	if(xmlHTTP.statusText=="OK"){
//		alert("新增訂單成功");
		if(window.confirm("新增訂單成功,要繼續新增訂單?")){
			if(window.document.all("hiddenType1").value=="02")
				window.location.href="http://140.96.18.18/mrlpub/d1/SearchCust1.aspx?type1=02";
			else if(window.document.all("hiddenType1").value=="03")
				window.location.href="http://140.96.18.18/mrlpub/d1/SearchCust1.aspx?type1=03";
		}
		else
			window.location.href="http://140.96.18.18/mrlpub/";
	}
	else
		alert(xmlHTTP.responseText);	
	var xmlHTTP = null;
}
	</script>
	</body>
</HTML>
