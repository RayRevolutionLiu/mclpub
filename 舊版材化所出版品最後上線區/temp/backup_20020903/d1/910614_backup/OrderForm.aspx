<%@ Page language="c#" Codebehind="OrderForm.aspx.cs" src="OrderForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.OrderForm" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
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
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<form id="OrderForm" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 706px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								訂單處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0"> 一般/零售訂單</font>
						</td>
					</tr>
				</table>
				<TABLE dataFld="訂單" id="MainTable" style="WIDTH: 706px" dataSrc="#DSO0" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 114px" align="right">
							訂戶編號：
						</TD>
						<TD style="WIDTH: 192px">
							<FONT color="#0000ff">&nbsp;&nbsp; </FONT>
							<asp:label id="lblInvoiceid" Runat="server" ForeColor="Maroon"></asp:label>
							<FONT color="#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
								[</FONT><font color="red">*</font><font color="blue">為必填欄位]</font> <input id="hiddenID" type="hidden" runat="server">
							<INPUT id="hiddenFgoi" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
							<INPUT id="hiddenFgoe" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
							<input id="hiddenPreXml" type="hidden" runat="server"> <input id="hiddenBook" type="hidden" runat="server">
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
						<TD style="WIDTH: 114px" align="right">
							公司名稱：
						</TD>
						<TD style="WIDTH: 192px" colSpan="3">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:label id="lblCoName" Runat="server" ForeColor="Maroon"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server" NAME="hiddenCoName">
							<INPUT id="hiddenCoAddr" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
						</TD>
					</tr>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂單及發票資料</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							訂單流水號：
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp;
							<asp:label id="lblOrderNo" runat="server" ForeColor="Maroon"></asp:label>
							<input id="hiddenOrderNo" type="hidden" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂單來源：
						</td>
						<td style="WIDTH: 235px">
							&nbsp;&nbsp; <SELECT dataFld="訂單來源" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							訂購日期：
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp; <input id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" runat="server">
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
							<input id="hiddenType1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							發票類別：
						</td>
						<td style="WIDTH: 246px">
							<input dataFld="發票類別" type="radio" value="2" name="rblInvcd">二聯 <input dataFld="發票類別" type="radio" value="3" name="rblInvcd">三聯
							<input dataFld="發票類別" type="radio" value="4" name="rblInvcd">其他
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							課稅別：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票課稅別" type="radio" value="1" name="rblTaxtp">應稅5% <input dataFld="發票課稅別" type="radio" value="2" name="rblTaxtp">零稅
							<input dataFld="發票課稅別" type="radio" value="3" name="rblTaxtp">免稅
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							付款方式：
						</td>
						<td>
							&nbsp;&nbsp; <SELECT dataFld="付款方式" id="ddlPayType" name="ddlPayType" runat="server"></SELECT>
						</td>
						<td style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							預開發票：
						</td>
						<td>
							<input dataFld="預開發票" type="radio" value="0" name="rbl1">否<input dataFld="預開發票" type="radio" value="1" name="rbl1">
						是
						<td>
						</td>
					<TR>
						<TD style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							統一編號：
						</TD>
						<TD style="WIDTH: 246px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxMfrno" runat="server" ReadOnly Width="100px" MaxLength="10"></asp:textbox>
						</TD>
						<TD style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							電話：
						</TD>
						<td style="WIDTH: 257px">
							<font color="red">*</font>
							<asp:textbox id="tbxTel" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</TR>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							發票收件人姓名：
						</td>
						<td style="WIDTH: 246px">
							<font color="red">*</font>
							<asp:textbox id="tbxInvoiceName" runat="server" MaxLength="30"></asp:textbox>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							傳真：
						</td>
						<td style="WIDTH: 257px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxFax" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							發票收件人職稱：
						</td>
						<td style="WIDTH: 246px">
							<input dataFld="發票收件人職稱" onafterupdate="doChange()" type="radio" value="先生" name="rblJob" runat="server">先生
							<input dataFld="發票收件人職稱" onafterupdate="doChange()" type="radio" value="小姐" name="rblJob" runat="server">小姐
							<input dataFld="發票收件人職稱" onafterupdate="doChange()" type="radio" value="其他" name="rblJob" runat="server">其他
							<asp:textbox id="tbxInvoiceJob" runat="server" Width="82px" MaxLength="12" Height="26px"></asp:textbox>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							手機：
						</td>
						<td style="WIDTH: 257px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxCell" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							發票收件人Email：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxEmail" runat="server" Width="450px" Height="24px"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							郵遞區號：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxPostCode" runat="server" Width="39px" MaxLength="5" Height="24px"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							發票郵寄地址：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxAddress" runat="server" Width="450px" Height="24px"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							承辦業務員：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							&nbsp;&nbsp;<SELECT dataFld="承辦人員" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">收件人資料</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 114px" align="right" bgColor="#bfcff0">
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
							<TABLE dataFld="明細表" id="tbItems" style="WIDTH: 758px" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 758px" colSpan="11">
											<FONT color="white">訂單明細資料</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0">
										<TD style="WIDTH: 39px; HEIGHT: 6px">
											功能
										</TD>
										<TD style="WIDTH: 29px">
											項次
										</TD>
										<TD style="WIDTH: 79px" align="middle">
											書籍類別
										</TD>
										<TD style="WIDTH: 38px" align="middle">
											訂戶別
										</TD>
										<TD style="WIDTH: 91px" align="middle">
											訂閱起時
										</TD>
										<TD style="WIDTH: 93px" align="middle">
											訂閱訖時
										</TD>
										<TD style="WIDTH: 42px" align="middle">
											金額
										</TD>
										<TD style="WIDTH: 37px" align="middle">
											總數量
										</TD>
										<TD style="WIDTH: 149px" align="middle">
											收件人
										</TD>
										<TD style="WIDTH: 49px" align="middle">
											備註
										</TD>
									</TR>
								</THEAD>
								<TR borderColor="#bfcff0" bgColor="#e2eafc">
									<TD style="WIDTH: 39px">
										<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
									</TD>
									<TD style="WIDTH: 29px">
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 79px">
										<SELECT dataFld="書籍類別" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT><input type="hidden" datafld="計劃代號" id="hiddenProj" runat="server" style="WIDTH: 27px; HEIGHT: 22px" size="1"><INPUT dataFld="成本中心" id="hiddenCostctr" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="7" name="hiddenCostctr" runat="server">
									</TD>
									<TD style="WIDTH: 38px">
										<SELECT dataFld="新舊訂戶" id="ddlCust" name="ddlCust" runat="server">
											<OPTION value="新訂戶" selected>
												新訂</OPTION>
											<OPTION value="續訂戶">
												續訂</OPTION>
										</SELECT>
									</TD>
									<TD style="WIDTH: 91px">
										<INPUT dataFld="訂閱起時" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt4">
										<IMG class="ico" title="日曆" onclick="pick_dateStart(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 93px">
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<IMG class="ico" title="日曆" onclick="pick_dateEnd(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 42px">
										<INPUT dataFld="金額" id="tbxAmt" style="WIDTH: 41px; HEIGHT: 22px; TEXT-ALIGN: right" type="text" maxLength="6" size="1" name="tt6">
									</TD>
									<TD style="WIDTH: 37px">
										<INPUT dataFld="總數量" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px; TEXT-ALIGN: right" readOnly type="text" maxLength="4" size="1" name="tt7">
									</TD>
									<TD style="WIDTH: 149px">
										&nbsp; <IMG class="ico" title="收件人詳細資料" onclick="doSelectRec(this)" src="images/edit.gif" border="0">
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
				<input id="btnSave" onclick="doSubmit()" type="button" value="儲存訂單" name="btnSave"><input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="取消回首頁" name="btnCancel">
			</center>
		</form>
		<script language="javascript">
DSO0.XMLDocument.async = false;
DSO1.XMLDocument.async = false; 
DSOX.XMLDocument.async = false;

var xmlDoc0 = DSO0.XMLDocument;
xmlDoc0.load("空白訂單一.xml");
//document.all("textarea1").value=xmlDoc0.xml;
//alert(xmlDoc0.xml);
//var xmlOwner = xmlDoc0.selectSingleNode("/root/訂戶");
var xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
//var xmlRecItem = xmlDoc0.selectSingleNode("/root/投遞資料");
xmlReceivers.childNodes.item(0).selectSingleNode("公司名稱").text=document.all("hiddenCoName").value;
xmlReceivers.childNodes.item(0).selectSingleNode("地址").text=document.all("tbxAddress").value;
xmlReceivers.childNodes.item(0).selectSingleNode("姓名").text=document.all("tbxInvoiceName").value;
xmlReceivers.childNodes.item(0).selectSingleNode("職稱").text=document.all("tbxInvoiceJob").value;
xmlReceivers.childNodes.item(0).selectSingleNode("郵遞區號").text=document.all("tbxPostCode").value;
xmlReceivers.childNodes.item(0).selectSingleNode("電話").text=document.all("tbxTel").value;
xmlReceivers.childNodes.item(0).selectSingleNode("序號").text="01";

var xmlItems = xmlDoc0.selectSingleNode("/root/訂單明細");
var xmlHeader = xmlDoc0.selectSingleNode("/root/訂單");
var xmlMain = xmlDoc0.selectSingleNode("/root");
//document.all("textarea1").value=xmlMain.xml;
var xmlEmptyItem = DSO1.XMLDocument;
xmlEmptyItem.load("空白項目一.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.all("hiddenBook").value);
var ItemBook=xmlDocX.selectSingleNode("書籍資料");
//alert(xmlItems.xml);
if((document.all("tbxInvoiceJob").value=="小姐")||(document.all("tbxInvoiceJob").value=="先生"))
	xmlHeader.selectSingleNode("發票收件人職稱").text=window.document.all("tbxInvoiceJob").value;
else
	xmlHeader.selectSingleNode("發票收件人職稱").text="其他";
//xmlHeader.selectSingleNode("訂購日期").text=window.document.all("hiddenDate").value;
		</script>
		<script language="javascript">
function doChange(){
	if(xmlHeader.selectSingleNode("發票收件人職稱").text=="其他")
		document.all("tbxInvoiceJob").value="";
	else
		document.all("tbxInvoiceJob").value=xmlHeader.selectSingleNode("發票收件人職稱").text;
}

function doAddNew(obj)
{
//	var idx=obj.parentElement.parentElement.rowIndex-1;
//	var idx = obj.recordNumber-1;
	var idx = xmlItems.childNodes.length;
//	xmlEmptyItem.documentElement.childNodes.item(0).text=idx;
	var newNode = xmlEmptyItem.documentElement.cloneNode(true);
//	alert(newNode.xml);
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
//	window.document.all("textarea1").value=xmlItems.xml;

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
    myObject.xmldata=xmlReceivers.xml;
//    alert(document.all("hiddenCoAddr").value);
//    myObject.CoAddress=document.all("hiddenCoAddr").value;
//    alert(xmlReceivers.xml);
    myObject.CoName=document.all("hiddenCoName").value;
    myObject.Name=document.all("tbxInvoiceName").value;
    myObject.Address=document.all("tbxAddress").value;
    myObject.PostCode=document.all("tbxPostCode").value;
    myObject.Job=document.all("tbxInvoiceJob").value;
    myObject.Tel=document.all("tbxTel").value;
//    alert(myObject.xmldata.xml);
//	strbuf="RecForm.aspx?id="+id+"&type1="+type+"&seq="+seq;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:800px;center:yes;scroll:yes;status:no;help:no;"); 
//    alert(myObject.result.xml);
	if(vreturn){
		xmlReceivers.parentNode.replaceChild(myObject.result, xmlReceivers);
		xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
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
//    alert(Items.xml);
//    myObject.CoName=document.all("hiddenCoName").value;
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
    vreturn=window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:530px;"); 
    if(vreturn){
		Items.parentNode.replaceChild(myObject.result, Items);
		Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
//    alert(Items.xml);
//	document.all("textarea1").value=Items.xml;
		var	amt=0;
		strbuf="";
		for(i=0; i<Items.childNodes.length; i++){
			amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("郵寄數量").text);	//<姓名>為第二欄
			strbuf+=Items.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
		}
		xmlItems.childNodes.item(idx).selectSingleNode("總數量").text=String(amt);
		event.srcElement.parentElement.children("lblRec1").innerText=strbuf;
//		event.srcElement.innerText=strbuf;
//		alert(event.srcElement.parentElement.children("lblRec1").innerText);
//		alert(document.getElementsByTagName.item(Table1));
//		document.all.Table1.rows(0).cells(8).innerText=strbuf;
	}
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
function doSubmit()
{
	xmlHeader.selectSingleNode("系統代碼").text="C1";
	xmlHeader.selectSingleNode("訂戶編號").text=window.document.all("hiddenID").value;
	xmlHeader.selectSingleNode("訂單流水號").text=window.document.all("hiddenOrderNo").value;
	xmlHeader.selectSingleNode("訂購類別一").text=window.document.all("hiddenType1").value;
	if(window.document.all("hiddenType1").value=="09")
		xmlHeader.selectSingleNode("訂購類別二").text="00";
	else
		xmlHeader.selectSingleNode("訂購類別二").text=window.document.all("ddlOrderType2").value;
	xmlHeader.selectSingleNode("統一編號").text=window.document.all("tbxMfrno").value;
	if(window.document.all("tbxInvoiceName").value==""){
		alert("發票收件人姓名不可空白");
		document.all("tbxInvoiceName").focus();
		return;
	}
	if(window.document.all("tbxTel").value==""){
		alert("發票收件人電話不可空白");
		document.all("tbxTel").focus();
		return;
	}
	if(window.document.all("tbxAddress").value==""){
		alert("發票收件人地址不可空白");
		document.all("tbxAddress").focus();
		return;
	}
	if(window.document.all("tbxPostCode").value==""){
		alert("發票收件人郵遞區號不可空白");
		document.all("tbxPostCode").focus();
		return;
	}
	xmlHeader.selectSingleNode("發票收件人姓名").text=window.document.all("tbxInvoiceName").value;
	if(xmlHeader.selectSingleNode("發票收件人職稱").text=="其他")
		xmlHeader.selectSingleNode("發票收件人職稱").text=window.document.all("tbxInvoiceJob").value;
	xmlHeader.selectSingleNode("發票收件人地址").text=window.document.all("tbxAddress").value;
	xmlHeader.selectSingleNode("發票收件人郵遞區號").text=window.document.all("tbxPostCode").value;
	xmlHeader.selectSingleNode("發票收件人電話").text=window.document.all("tbxTel").value;
	xmlHeader.selectSingleNode("發票收件人傳真").text=window.document.all("tbxFax").value;
	xmlHeader.selectSingleNode("發票收件人手機").text=window.document.all("tbxCell").value;
	xmlHeader.selectSingleNode("發票收件人Email").text=window.document.all("tbxEmail").value;
//	xmlHeader.selectSingleNode("付款方式").text=window.document.all("ddlPayType").value;
//	xmlHeader.selectSingleNode("預開發票").text="0";
//	xmlHeader.selectSingleNode("承辦人員").text="840695";
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
//	xmlHeader.selectSingleNode("訂單來源").text=window.document.all("ddlOrderRes").value;
//	xmlHeader.selectSingleNode("發票類別").text=window.document.all("rblInvcd").value;
//	xmlHeader.selectSingleNode("發票課稅別").text=window.document.all("rblTaxtp").value;
//  在這邊把xmlDoc0.xml的資料傳給存檔程式
	
	var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
	xmlHTTP.Open("post", "SaveOrder.aspx", false);
	xmlHTTP.Send(xmlDoc0);
//	document.all("textarea1").value=xmlHTTP.responseText;
//	alert(xmlHTTP.responseText);
    var myObject = new Object();
   	strbuf="C1"+document.all("hiddenID").value+document.all("hiddenType1").value+document.all("hiddenOrderNo").value;
	xmlHeader.selectSingleNode("訂戶編號").text=window.document.all("hiddenID").value;
	xmlHeader.selectSingleNode("訂單流水號").text=window.document.all("hiddenOrderNo").value;
	xmlHeader.selectSingleNode("訂購類別一").text=window.document.all("hiddenType1").value;

	if(xmlHTTP.statusText=="OK"){
//		alert("新增訂單成功");
		if(window.confirm("新增訂單成功,要進行繳款處理?"))
			window.location.href="http://140.96.18.18/mrlpub/d1/PayFilter.aspx?caller=order";
//			window.location.href="http://140.96.18.18/mrlpub/d1/PayTypeForm.aspx?caller=order&id="+window.document.all("hiddenOrderNo").value;
		else{
			if(window.confirm("要繼續新增訂單?")){
				if(window.document.all("hiddenType1").value=="01")
					window.location.href="http://140.96.18.18/mrlpub/d1/SearchCust1.aspx?type1=01&function1=new";
				else if(window.document.all("hiddenType1").value=="09")
					window.location.href="http://140.96.18.18/mrlpub/d1/SearchCust1.aspx?type1=09&function1=new";
			}
			else
				window.location.href="http://140.96.18.18/mrlpub/";
		}
	}
	else if(xmlHTTP.statusText=="Error1")
		alert("新增發票開立單檔失敗!!"+xmlHTTP.responseText);
	else if(xmlHTTP.statusText=="Error2")
		alert("新增訂單失敗!!"+xmlHTTP.responseText);
	else
		alert(xmlHTTP.responseText);
	var xmlHTTP = null;
}
	</script>
	</body>
</HTML>
