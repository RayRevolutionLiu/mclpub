<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="OrderFM.aspx.cs" src="OrderFM.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.OrderFM" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
	</HEAD>
	<body>
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="OrderFM" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 706px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								訂單處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0"><asp:Label ID="lblTitle" Runat="server"></asp:Label><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								修改訂單</font>
						</td>
					</tr>
				</table>
				<TABLE dataFld="訂單" id="MainTable" style="WIDTH: 706px" dataSrc="#DSO1" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 125px" align="right">
							訂戶編號：
						</TD>
						<TD style="WIDTH: 192px">
							<span dataFld="訂戶編號" id="Span1" style="COLOR: maroon" runat="server"></span><input id="hiddenID" type="hidden" name="hiddenID" runat="server">
							<INPUT id="hiddenFgoi" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenFgoi" runat="server">
							<INPUT id="hiddenFgoe" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenFgoe" runat="server">
							<input id="hiddenBook" type="hidden" name="hiddenBook" runat="server">
						</TD>
						<TD style="WIDTH: 108px" align="right">
							訂戶姓名：
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<tr>
						<TD style="WIDTH: 125px" align="right">
							公司名稱：
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblCoName" ForeColor="Maroon" Runat="server"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoName" runat="server">
						</TD>
						<TD style="WIDTH: 108px" align="right">
							上次修改日期：
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblModifyDate" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</tr>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂單及發票資料</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							訂單流水號：
						</td>
						<td style="WIDTH: 235px">
							<span dataFld="訂單流水號" id="Span2" style="COLOR: maroon" runat="server"></span><input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂單來源：
						</td>
						<td style="WIDTH: 235px">
							<SELECT dataFld="訂單來源" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							訂購日期：
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="訂購日期" id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" name="tbxOrderDate" runat="server"><IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate.name)" src="../images/calendar01.gif">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂購類別：
						</td>
						<td style="WIDTH: 257px">
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly Width="38px"></asp:textbox>
							<SELECT dataFld="訂購類別二" id="ddlOrderType2" name="Select1" runat="server"></SELECT>
							<input id="hiddenType1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hiddenType1" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							發票類別：
						</td>
						<td style="WIDTH: 235px">
							<asp:Panel ID="panel1" Runat="server">
<INPUT dataFld="發票類別" id="rblInvcd1" type="radio" value="2" name="rblInvcd" runat="server">二聯 
<INPUT dataFld="發票類別" id="rblInvcd2" type="radio" value="3" name="rblInvcd" runat="server">三聯 
<INPUT dataFld="發票類別" id="rblInvcd3" type="radio" value="4" name="rblInvcd" runat="server">其他
						</asp:Panel>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							課稅別：
						</td>
						<td style="WIDTH: 257px">
							<asp:Panel ID="panel2" Runat="server">
<INPUT dataFld="發票課稅別" type="radio" value="1" name="rblTaxtp">應稅5% 
<INPUT dataFld="發票課稅別" type="radio" value="2" name="rblTaxtp">零稅 
<INPUT dataFld="發票課稅別" type="radio" value="3" name="rblTaxtp">免稅
						</asp:Panel>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							付款方式：
						</td>
						<td colSpan="3">
							<SELECT dataFld="付款方式" id="ddlPayType" name="ddlPayType" runat="server"></SELECT>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							統一編號：
						</TD>
						<TD style="WIDTH: 192px">
							<input dataFld="統一編號" id="tbxMfrno" name="tbxMfrno" runat="server">
						</TD>
						<TD style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							電話：
						</TD>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人電話" id="tbxTel" name="tbxTel" runat="server">
						</td>
					</TR>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							發票收件人姓名：
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="發票收件人姓名" id="tbxInvoiceName" name="tbxInvoiceName" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							傳真：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人傳真" id="tbxFax" name="tbxFax" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							發票收件人職稱：
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="發票收件人職稱" id="tbxInvoiceJob" name="tbxInvoiceJob" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							手機：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人手機" id="tbxCell" name="tbxCell" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							發票收件人Email：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人Email" id="tbxEmail" name="tbxEmail" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							郵遞區號：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人郵遞區號" id="tbxPostCode" style="WIDTH: 39px; HEIGHT: 22px" size="1" name="tbxPostCode" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							發票郵寄地址：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人地址" id="tbxAddress" style="WIDTH: 421px; HEIGHT: 22px" size="64" name="tbxAddress" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							承辦業務員：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<SELECT dataFld="承辦人員" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">收件人資料</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							收件人：
						</TD>
						<TD style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetRec()" src="images/new.gif" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</TD>
					</TR>
				</TABLE>
				<TABLE dataFld="訂單明細" id="Table1" dataSrc="#DSO1" cellSpacing="0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="明細表" id="tbItems" style="WIDTH: 758px" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD id="1">
									<TR id="11" bgColor="#214389">
										<TD style="WIDTH: 758px" colSpan="11">
											<FONT color="white">訂單明細資料</FONT>
										</TD>
									</TR>
									<TR id="3" borderColor="#bfcff0" bgColor="#bfcff0">
										<TD id="33" style="WIDTH: 41px; HEIGHT: 6px">
											功能
										</TD>
										<TD style="WIDTH: 32px">
											項次
										</TD>
										<TD style="WIDTH: 91px" align="middle">
											書籍類別
										</TD>
										<TD style="WIDTH: 58px" align="middle">
											訂戶別
										</TD>
										<TD style="WIDTH: 105px" align="middle">
											訂閱起時
										</TD>
										<TD style="WIDTH: 110px" align="middle">
											訂閱訖時
										</TD>
										<TD style="WIDTH: 42px" align="middle">
											金額
										</TD>
										<TD style="WIDTH: 50px" align="middle">
											總數量
										</TD>
										<TD style="WIDTH: 213px" align="middle">
											收件人
										</TD>
										<TD style="WIDTH: 49px" align="middle">
											備註
										</TD>
									</TR>
								</THEAD>
								<TR id="tbItems1" borderColor="#bfcff0" bgColor="#e2eafc">
									<TD id="22" style="WIDTH: 41px">
										<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
									</TD>
									<TD style="WIDTH: 32px">
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 91px">
										<SELECT dataFld="書籍類別" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT><input dataFld="計劃代號" id="hiddenProj" style="WIDTH: 27px; HEIGHT: 22px" type="hidden" size="1" name="hiddenProj" runat="server">
									</TD>
									<TD style="WIDTH: 58px">
										<SELECT dataFld="新舊訂戶" id="ddlCust" name="ddlCust" runat="server">
											<OPTION value="新訂戶" selected>
												新訂</OPTION>
											<OPTION value="續訂戶">
												續訂</OPTION></SELECT>
									</TD>
									<TD style="WIDTH: 105px">
										<INPUT dataFld="訂閱起時" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt4">
										<IMG class="ico" title="日曆" onclick="pick_dateStart(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 110px">
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<IMG class="ico" title="日曆" onclick="pick_dateEnd(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 42px">
										<INPUT dataFld="金額" id="tbxAmt" style="WIDTH: 41px; HEIGHT: 22px" type="text" maxLength="6" size="1" name="tt6" runat="server">
									</TD>
									<TD style="WIDTH: 50px">
										<INPUT dataFld="總數量" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</TD>
									<TD id="test1" style="WIDTH: 213px">
										<IMG class="ico" title="收件人詳細資料" onclick="doSelectRec(this)" src="images/edit.gif" border="0">
										<LABEL id="lblRec1" style="COLOR: maroon"></LABEL>
									</TD>
									<TD style="WIDTH: 50px">
										<INPUT dataFld="備註" id="tbxRemark" style="WIDTH: 50px; HEIGHT: 22px" type="text" maxLength="30" size="3" name="tt7">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server"> <input id="btnSave" onclick="doSubmit()" type="button" value="儲存訂單"><input id="btnCancel" onclick='javascritp:window.location.href="../default.aspx"' type="button" value="取消回首頁">&nbsp;
			</center>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
DSO1.XMLDocument.async = false; 
DSO2.XMLDocument.async = false; 
DSOX.XMLDocument.async = false; 
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.loadXML(document.all("hiddenXML").value);
var xmlReceivers = xmlDoc1.selectSingleNode("/root/收件人資料");
//xmlReceivers.childNodes.item(0).selectSingleNode("公司名稱").text=document.all("hiddenCoName").value;
//xmlReceivers.childNodes.item(0).selectSingleNode("地址").text=document.all("tbxAddress").value;
//xmlReceivers.childNodes.item(0).selectSingleNode("序號").text="1";
var xmlRecItem = xmlDoc1.selectSingleNode("/root/訂單明細/明細表");
var xmlItems = xmlDoc1.selectSingleNode("/root/訂單明細");
var xmlHeader = xmlDoc1.selectSingleNode("/root/訂單");
var xmlMain = xmlDoc1.selectSingleNode("/root");
var xmlEmptyItem = DSO2.XMLDocument;
xmlEmptyItem.load("空白項目一.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.all("hiddenBook").value);
var ItemBook=xmlDocX.selectSingleNode("書籍資料");
//document.all("textarea1").value=ItemBook.xml;
strbuf="";
for(i=0; i<xmlReceivers.childNodes.length; i++){
	strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
}
document.all("lblRec").innerText=strbuf;
//alert(document.all("tbItems").children.item(1).children.item(0).children("test1").children("lblRec1").innerText);
/*for(i=0; i<xmlItems.childNodes.length; i++){
	strbuf="";
//	alert("length="+xmlItems.childNodes.item(i).selectSingleNode("投遞資料").xml);
	for(j=0; j<xmlItems.childNodes.item(i).selectSingleNode("投遞資料").childNodes.length; j++){
//		alert("j="+j);
//		alert(xmlItems.childNodes.item(i).selectSingleNode("投遞資料").childNodes.item(j).selectSingleNode("姓名").text);
		strbuf+=xmlItems.childNodes.item(i).selectSingleNode("投遞資料").childNodes.item(j).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
	}
	alert(strbuf);
	alert(document.all("tbItems").children.item(1).children.item(0).children.item(1).children("tbxId").innerText);
//	document.all("tbItems").children.item(1).children.item(i).children("test1").children("lblRec1").innerText=strbuf;
}*/
//alert(strbuf);
//alert(document.all("test1").id);

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
function doGetRec()
{
    var myObject = new Object();
	myObject.flag=true;
	myObject.prexmldata=document.all("hiddenRec").value;
//	myObject.prexmldata=xmlReceivers.xml;
    myObject.CoName=document.all("hiddenCoName").value;
    myObject.CoAddress=window.document.all("tbxAddress").value;
    myObject.xmldata=xmlReceivers.xml;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:800px;center:yes;scroll:yes;status:no;help:no;"); 
//    alert(myObject.result.xml);
	if(vreturn){
		xmlReceivers.parentNode.replaceChild(myObject.result, xmlReceivers);
		xmlReceivers = xmlDoc1.selectSingleNode("/root/收件人資料");
		strbuf="";
		for(i=0; i<xmlReceivers.childNodes.length; i++){
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
		strbuf="";
		for(i=0; i<Items.childNodes.length; i++){
			amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("郵寄數量").text);	//<姓名>為第二欄
			strbuf+=Items.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
		}
		xmlItems.childNodes.item(idx).selectSingleNode("總數量").text=String(amt);
		event.srcElement.parentElement.children("lblRec1").innerText=strbuf;
	}
//	document.all("textarea1").value=xmlItems.xml;
}
function doSelectBook(obj)
{
	var idx = obj.recordNumber-1;
	BookType=xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
	Type1=xmlHeader.selectSingleNode("付款方式").text
//	document.all("textarea1").value=xmlHeader.xml;
	if(xmlHeader.selectSingleNode("付款方式").text=="06")
		PayType="06";
	else
		PayType="";
	for(i=0; i<ItemBook.childNodes.length; i++){
		if((ItemBook.childNodes.item(i).selectSingleNode("obtp_otp1cd").text==document.all("hiddenType1").value)&&(ItemBook.childNodes.item(i).selectSingleNode("fgitri").text==PayType)
			&&(ItemBook.childNodes.item(i).selectSingleNode("obtp_obtpcd").text==BookType)){
			strbuf=ItemBook.childNodes.item(i).selectSingleNode("nostr").text;
			break;
		}
	}
//	strbuf = xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
//	xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text=strbuf.substr(0, 2);
	xmlItems.childNodes.item(idx).selectSingleNode("計劃代號").text=strbuf.substr(2, 10);
	xmlItems.childNodes.item(idx).selectSingleNode("成本中心").text=strbuf.substr(12, 7);
	if(BookType=="01"){
		if(window.document.all("hiddenFgoi").value=="0")
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="新訂戶";
		else
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="續訂戶";
	}
	else if(BookType=="02"){
		if(window.document.all("hiddenFgoe").value=="0")
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="新訂戶";
		else
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="續訂戶";
	}

}
function pick_dateStart(obj){
	var idx = obj.recordNumber-1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱起時").text=vreturn;
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
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
function doSubmit()
{
//	document.all("textarea1").value=xmlDoc1.xml;
	
	var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
	xmlHTTP.Open("post", "ModifyOrder.aspx", false);
	xmlHTTP.Send(xmlDoc1);
	if(xmlHTTP.statusText=="OK"){
//		alert("新增訂單成功");
			window.location.href="SaveMessage.aspx?str=modify";
	}
	else
		alert(xmlHTTP.responseText);
	var xmlHTTP = null;
}
		</script>
	</body>
</HTML>
