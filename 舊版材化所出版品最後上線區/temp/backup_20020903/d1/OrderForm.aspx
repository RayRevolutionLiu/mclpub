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
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<form id="OrderForm" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 706px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								�q��B�z <IMG height="10" src="images/header/right02.gif" width="10" border="0"> �@��/�s��q��</font>
						</td>
					</tr>
				</table>
				<TABLE dataFld="�q��" id="MainTable" style="WIDTH: 706px" dataSrc="#DSO0" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">�q����</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 114px" align="right">
							�q��s���G
						</TD>
						<TD style="WIDTH: 192px">
							<FONT color="#0000ff">&nbsp;&nbsp; </FONT>
							<asp:label id="lblInvoiceid" Runat="server" ForeColor="Maroon"></asp:label>
							<FONT color="#0000ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
								[</FONT><font color="red">*</font><font color="blue">���������]</font> <input id="hiddenID" type="hidden" runat="server">
							<INPUT id="hiddenFgoi" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
							<INPUT id="hiddenFgoe" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
							<input id="hiddenPreXml" type="hidden" runat="server"> <input id="hiddenBook" type="hidden" runat="server">
						</TD>
						<TD style="WIDTH: 108px" align="right">
							�q��m�W�G
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:label id="lblName" Runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<tr>
						<TD style="WIDTH: 114px" align="right">
							���q�W�١G
						</TD>
						<TD style="WIDTH: 192px" colSpan="3">
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:label id="lblCoName" Runat="server" ForeColor="Maroon"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server" NAME="hiddenCoName">
							<INPUT id="hiddenCoAddr" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
						</TD>
					</tr>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">�q��εo�����</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�q��y�����G
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp;
							<asp:label id="lblOrderNo" runat="server" ForeColor="Maroon"></asp:label>
							<input id="hiddenOrderNo" type="hidden" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q��ӷ��G
						</td>
						<td style="WIDTH: 235px">
							&nbsp;&nbsp; <SELECT dataFld="�q��ӷ�" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�q�ʤ���G
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp; <input id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" runat="server">
							<IMG class="ico" title="���" onclick="pick_date(tbxOrderDate.name)" src="../images/calendar01.gif">
							<INPUT id="hiddenDate" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenDate" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q�����O�G
						</td>
						<td style="WIDTH: 257px">
							&nbsp;&nbsp;
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly="True" Width="38px"></asp:textbox>
							<SELECT dataFld="�q�����O" id="ddlOrderType2" name="ddlOrderType2" runat="server"></SELECT>
							<input id="hiddenType1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�o�����O�G
						</td>
						<td style="WIDTH: 246px">
							<input dataFld="�o�����O" type="radio" value="2" name="rblInvcd">�G�p <input dataFld="�o�����O" type="radio" value="3" name="rblInvcd">�T�p
							<input dataFld="�o�����O" type="radio" value="4" name="rblInvcd">��L
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�ҵ|�O�G
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="�o���ҵ|�O" type="radio" value="1" name="rblTaxtp">���|5% <input dataFld="�o���ҵ|�O" type="radio" value="2" name="rblTaxtp">�s�|
							<input dataFld="�o���ҵ|�O" type="radio" value="3" name="rblTaxtp">�K�|
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�I�ڤ覡�G
						</td>
						<td>
							&nbsp;&nbsp; <SELECT dataFld="�I�ڤ覡" id="ddlPayType" name="ddlPayType" runat="server"></SELECT>
						</td>
						<td style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							�w�}�o���G
						</td>
						<td>
							<input dataFld="�w�}�o��" type="radio" value="0" name="rbl1">�_<input dataFld="�w�}�o��" type="radio" value="1" name="rbl1">
						�O
						<td>
						</td>
					<TR>
						<TD style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�Τ@�s���G
						</TD>
						<TD style="WIDTH: 246px">
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxMfrno" runat="server" ReadOnly Width="100px" MaxLength="10"></asp:textbox>
						</TD>
						<TD style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q�ܡG
						</TD>
						<td style="WIDTH: 257px">
							<font color="red">*</font>
							<asp:textbox id="tbxTel" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</TR>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�o������H�m�W�G
						</td>
						<td style="WIDTH: 246px">
							<font color="red">*</font>
							<asp:textbox id="tbxInvoiceName" runat="server" MaxLength="30"></asp:textbox>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�ǯu�G
						</td>
						<td style="WIDTH: 257px">
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxFax" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�o������H¾�١G
						</td>
						<td style="WIDTH: 246px">
							<input dataFld="�o������H¾��" onafterupdate="doChange()" type="radio" value="����" name="rblJob" runat="server">����
							<input dataFld="�o������H¾��" onafterupdate="doChange()" type="radio" value="�p�j" name="rblJob" runat="server">�p�j
							<input dataFld="�o������H¾��" onafterupdate="doChange()" type="radio" value="��L" name="rblJob" runat="server">��L
							<asp:textbox id="tbxInvoiceJob" runat="server" Width="82px" MaxLength="12" Height="26px"></asp:textbox>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							����G
						</td>
						<td style="WIDTH: 257px">
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxCell" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�o������HEmail�G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxEmail" runat="server" Width="450px" Height="24px"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�l���ϸ��G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxPostCode" runat="server" Width="39px" MaxLength="5" Height="24px"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�o���l�H�a�}�G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxAddress" runat="server" Width="450px" Height="24px"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�ӿ�~�ȭ��G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							&nbsp;&nbsp;<SELECT dataFld="�ӿ�H��" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">����H���</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							����H�G
						</TD>
						<TD style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="�s�W/�ק怜��H" onclick="doGetRec()" src="images/new.gif" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</TD>
					</TR>
				</TABLE>
				<TABLE dataFld="�q�����" id="Table1" dataSrc="#DSO0" cellSpacing="0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="���Ӫ�" id="tbItems" style="WIDTH: 758px" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 758px" colSpan="11">
											<FONT color="white">�q����Ӹ��</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0">
										<TD style="WIDTH: 39px; HEIGHT: 6px">
											�\��
										</TD>
										<TD style="WIDTH: 29px">
											����
										</TD>
										<TD style="WIDTH: 79px" align="middle">
											���y���O
										</TD>
										<TD style="WIDTH: 38px" align="middle">
											�q��O
										</TD>
										<TD style="WIDTH: 91px" align="middle">
											�q�\�_��
										</TD>
										<TD style="WIDTH: 93px" align="middle">
											�q�\�W��
										</TD>
										<TD style="WIDTH: 42px" align="middle">
											���B
										</TD>
										<TD style="WIDTH: 37px" align="middle">
											�`�ƶq
										</TD>
										<TD style="WIDTH: 149px" align="middle">
											����H
										</TD>
										<TD style="WIDTH: 49px" align="middle">
											�Ƶ�
										</TD>
									</TR>
								</THEAD>
								<TR borderColor="#bfcff0" bgColor="#e2eafc">
									<TD style="WIDTH: 39px">
										<IMG class="ico" title="�s�W���" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="�s�ө���">&nbsp;</FONT><IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
									</TD>
									<TD style="WIDTH: 29px">
										<INPUT dataFld="����" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 79px">
										<SELECT dataFld="���y���O" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT><input type="hidden" datafld="�p���N��" id="hiddenProj" runat="server" style="WIDTH: 27px; HEIGHT: 22px" size="1"><INPUT dataFld="��������" id="hiddenCostctr" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="7" name="hiddenCostctr" runat="server">
									</TD>
									<TD style="WIDTH: 38px">
										<SELECT dataFld="�s�­q��" id="ddlCust" name="ddlCust" runat="server">
											<OPTION value="�s�q��" selected>
												�s�q</OPTION>
											<OPTION value="��q��">
												��q</OPTION>
										</SELECT>
									</TD>
									<TD style="WIDTH: 91px">
										<INPUT dataFld="�q�\�_��" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt4">
										<IMG class="ico" title="���" onclick="pick_dateStart(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 93px">
										<INPUT dataFld="�q�\�W��" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<IMG class="ico" title="���" onclick="pick_dateEnd(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 42px">
										<INPUT dataFld="���B" id="tbxAmt" style="WIDTH: 41px; HEIGHT: 22px; TEXT-ALIGN: right" type="text" maxLength="6" size="1" name="tt6">
									</TD>
									<TD style="WIDTH: 37px">
										<INPUT dataFld="�`�ƶq" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px; TEXT-ALIGN: right" readOnly type="text" maxLength="4" size="1" name="tt7">
									</TD>
									<TD style="WIDTH: 149px">
										&nbsp; <IMG class="ico" title="����H�ԲӸ��" onclick="doSelectRec(this)" src="images/edit.gif" border="0">
										<LABEL id="lblRec1" style="COLOR: maroon"></LABEL>
									</TD>
									<TD style="WIDTH: 50px">
										<INPUT dataFld="�Ƶ�" id="tbxRemark" style="WIDTH: 50px; HEIGHT: 22px" type="text" maxLength="30" size="3" name="tt7">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<input id="btnSave" onclick="doSubmit()" type="button" value="�x�s�q��" name="btnSave"><input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="�����^����" name="btnCancel">
			</center>
		</form>
		<script language="javascript">
DSO0.XMLDocument.async = false;
DSO1.XMLDocument.async = false; 
DSOX.XMLDocument.async = false;

var xmlDoc0 = DSO0.XMLDocument;
xmlDoc0.load("�ťխq��@.xml");
//document.all("textarea1").value=xmlDoc0.xml;
//alert(xmlDoc0.xml);
//var xmlOwner = xmlDoc0.selectSingleNode("/root/�q��");
var xmlReceivers = xmlDoc0.selectSingleNode("/root/����H���");
//var xmlRecItem = xmlDoc0.selectSingleNode("/root/�뻼���");
xmlReceivers.childNodes.item(0).selectSingleNode("���q�W��").text=document.all("hiddenCoName").value;
xmlReceivers.childNodes.item(0).selectSingleNode("�a�}").text=document.all("tbxAddress").value;
xmlReceivers.childNodes.item(0).selectSingleNode("�m�W").text=document.all("tbxInvoiceName").value;
xmlReceivers.childNodes.item(0).selectSingleNode("¾��").text=document.all("tbxInvoiceJob").value;
xmlReceivers.childNodes.item(0).selectSingleNode("�l���ϸ�").text=document.all("tbxPostCode").value;
xmlReceivers.childNodes.item(0).selectSingleNode("�q��").text=document.all("tbxTel").value;
xmlReceivers.childNodes.item(0).selectSingleNode("�Ǹ�").text="01";

var xmlItems = xmlDoc0.selectSingleNode("/root/�q�����");
var xmlHeader = xmlDoc0.selectSingleNode("/root/�q��");
var xmlMain = xmlDoc0.selectSingleNode("/root");
//document.all("textarea1").value=xmlMain.xml;
var xmlEmptyItem = DSO1.XMLDocument;
xmlEmptyItem.load("�ťն��ؤ@.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.all("hiddenBook").value);
var ItemBook=xmlDocX.selectSingleNode("���y���");
//alert(xmlItems.xml);
if((document.all("tbxInvoiceJob").value=="�p�j")||(document.all("tbxInvoiceJob").value=="����"))
	xmlHeader.selectSingleNode("�o������H¾��").text=window.document.all("tbxInvoiceJob").value;
else
	xmlHeader.selectSingleNode("�o������H¾��").text="��L";
//xmlHeader.selectSingleNode("�q�ʤ��").text=window.document.all("hiddenDate").value;
		</script>
		<script language="javascript">
function doChange(){
	if(xmlHeader.selectSingleNode("�o������H¾��").text=="��L")
		document.all("tbxInvoiceJob").value="";
	else
		document.all("tbxInvoiceJob").value=xmlHeader.selectSingleNode("�o������H¾��").text;
}

function doAddNew(obj)
{
//	var idx=obj.parentElement.parentElement.rowIndex-1;
//	var idx = obj.recordNumber-1;
	var idx = xmlItems.childNodes.length;
//	xmlEmptyItem.documentElement.childNodes.item(0).text=idx;
	var newNode = xmlEmptyItem.documentElement.cloneNode(true);
//	alert(newNode.xml);
//	newNode.selectSingleNode("����").text=idx;
//	xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
	xmlItems.appendChild(newNode);
	var	j1=String(idx+1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx).selectSingleNode("����").text=j1;
	}
	else
		xmlItems.childNodes.item(idx).selectSingleNode("����").text=idx+1;
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
				xmlItems.childNodes.item(i).selectSingleNode("����").text=j1;
			}
			else
				xmlItems.childNodes.item(i).selectSingleNode("����").text=i+1;
		}
	}
}

function doSelectBook(obj)
{
	var idx = obj.recordNumber-1;
	BookType=xmlItems.childNodes.item(idx).selectSingleNode("���y���O").text;
	if(xmlHeader.selectSingleNode("�I�ڤ覡").text=="06")
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
//	strbuf = xmlItems.childNodes.item(idx).selectSingleNode("���y���O").text;
//	xmlItems.childNodes.item(idx).selectSingleNode("���y���O").text=strbuf.substr(0, 2);
	xmlItems.childNodes.item(idx).selectSingleNode("�p���N��").text=strbuf.substr(2, 10);
	xmlItems.childNodes.item(idx).selectSingleNode("��������").text=strbuf.substr(12, 7);
	if(BookType=="01"){
		if(window.document.all("hiddenFgoi").value=="0")
			xmlItems.childNodes.item(idx).selectSingleNode("�s�­q��").text="�s�q��";
		else
			xmlItems.childNodes.item(idx).selectSingleNode("�s�­q��").text="��q��";
	}
	else if(BookType=="02"){
		if(window.document.all("hiddenFgoe").value=="0")
			xmlItems.childNodes.item(idx).selectSingleNode("�s�­q��").text="�s�q��";
		else
			xmlItems.childNodes.item(idx).selectSingleNode("�s�­q��").text="��q��";
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
		alert("�S�����v���, �Цۦ��J���");
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
		xmlReceivers = xmlDoc0.selectSingleNode("/root/����H���");
		strbuf="";
		for(i=0; i<xmlReceivers.childNodes.length; i++){
			strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("�m�W").text+",";	//<�m�W>���ĤG��
		}
		document.all("lblRec").innerText=strbuf;
	}
}
function doSelectRec(obj)
{
	var idx = obj.recordNumber-1;
    var myObject = new Object();
    var Items=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
//    alert(Items.xml);
//    myObject.CoName=document.all("hiddenCoName").value;
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
    vreturn=window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:530px;"); 
    if(vreturn){
		Items.parentNode.replaceChild(myObject.result, Items);
		Items=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
//    alert(Items.xml);
//	document.all("textarea1").value=Items.xml;
		var	amt=0;
		strbuf="";
		for(i=0; i<Items.childNodes.length; i++){
			amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("�l�H�ƶq").text);	//<�m�W>���ĤG��
			strbuf+=Items.childNodes.item(i).selectSingleNode("�m�W").text+",";	//<�m�W>���ĤG��
		}
		xmlItems.childNodes.item(idx).selectSingleNode("�`�ƶq").text=String(amt);
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
		xmlItems.childNodes.item(idx).selectSingleNode("�q�\�_��").text=vreturn;
	return true;
}
function pick_dateEnd(obj){
	var idx = obj.recordNumber-1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("�q�\�W��").text=vreturn;
	return true;
}
function doSubmit()
{
	xmlHeader.selectSingleNode("�t�ΥN�X").text="C1";
	xmlHeader.selectSingleNode("�q��s��").text=window.document.all("hiddenID").value;
	xmlHeader.selectSingleNode("�q��y����").text=window.document.all("hiddenOrderNo").value;
	xmlHeader.selectSingleNode("�q�����O�@").text=window.document.all("hiddenType1").value;
	if(window.document.all("hiddenType1").value=="09")
		xmlHeader.selectSingleNode("�q�����O�G").text="00";
	else
		xmlHeader.selectSingleNode("�q�����O�G").text=window.document.all("ddlOrderType2").value;
	xmlHeader.selectSingleNode("�Τ@�s��").text=window.document.all("tbxMfrno").value;
	if(window.document.all("tbxInvoiceName").value==""){
		alert("�o������H�m�W���i�ť�");
		document.all("tbxInvoiceName").focus();
		return;
	}
	if(window.document.all("tbxTel").value==""){
		alert("�o������H�q�ܤ��i�ť�");
		document.all("tbxTel").focus();
		return;
	}
	if(window.document.all("tbxAddress").value==""){
		alert("�o������H�a�}���i�ť�");
		document.all("tbxAddress").focus();
		return;
	}
	if(window.document.all("tbxPostCode").value==""){
		alert("�o������H�l���ϸ����i�ť�");
		document.all("tbxPostCode").focus();
		return;
	}
	xmlHeader.selectSingleNode("�o������H�m�W").text=window.document.all("tbxInvoiceName").value;
	if(xmlHeader.selectSingleNode("�o������H¾��").text=="��L")
		xmlHeader.selectSingleNode("�o������H¾��").text=window.document.all("tbxInvoiceJob").value;
	xmlHeader.selectSingleNode("�o������H�a�}").text=window.document.all("tbxAddress").value;
	xmlHeader.selectSingleNode("�o������H�l���ϸ�").text=window.document.all("tbxPostCode").value;
	xmlHeader.selectSingleNode("�o������H�q��").text=window.document.all("tbxTel").value;
	xmlHeader.selectSingleNode("�o������H�ǯu").text=window.document.all("tbxFax").value;
	xmlHeader.selectSingleNode("�o������H���").text=window.document.all("tbxCell").value;
	xmlHeader.selectSingleNode("�o������HEmail").text=window.document.all("tbxEmail").value;
//	xmlHeader.selectSingleNode("�I�ڤ覡").text=window.document.all("ddlPayType").value;
//	xmlHeader.selectSingleNode("�w�}�o��").text="0";
//	xmlHeader.selectSingleNode("�ӿ�H��").text="840695";
	xmlHeader.selectSingleNode("�q�ʤ��").text=window.document.all("tbxOrderDate").value;
/*	document.all("tbxOrderDate").value=document.all("tbxOrderDate").value.replace("/", "");
	document.all("tbxOrderDate").value=document.all("tbxOrderDate").value.replace("/", "");
	xmlHeader.selectSingleNode("�q�ʤ��").text=window.document.all("tbxOrderDate").value;
	document.all("tbxStartDate").value=document.all("tbxStartDate").value.replace("/", "");
	document.all("tbxStartDate").value=document.all("tbxStartDate").value.replace("/", "");
	xmlItems.selectSingleNode("�q�\�_��").text=window.document.all("tbxStartDate").value;
	document.all("tbxEndDate").value=document.all("tbxEndDate").value.replace("/", "");
	document.all("tbxEndDate").value=document.all("tbxEndDate").value.replace("/", "");
	xmlItems.selectSingleNode("�q�\�W��").text=window.document.all("tbxEndDate").value;*/
//	xmlHeader.selectSingleNode("�q��ӷ�").text=window.document.all("ddlOrderRes").value;
//	xmlHeader.selectSingleNode("�o�����O").text=window.document.all("rblInvcd").value;
//	xmlHeader.selectSingleNode("�o���ҵ|�O").text=window.document.all("rblTaxtp").value;
//  �b�o���xmlDoc0.xml����ƶǵ��s�ɵ{��
	
	var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
	xmlHTTP.Open("post", "SaveOrder.aspx", false);
	xmlHTTP.Send(xmlDoc0);
//	document.all("textarea1").value=xmlHTTP.responseText;
//	alert(xmlHTTP.responseText);
    var myObject = new Object();
   	strbuf="C1"+document.all("hiddenID").value+document.all("hiddenType1").value+document.all("hiddenOrderNo").value;
	xmlHeader.selectSingleNode("�q��s��").text=window.document.all("hiddenID").value;
	xmlHeader.selectSingleNode("�q��y����").text=window.document.all("hiddenOrderNo").value;
	xmlHeader.selectSingleNode("�q�����O�@").text=window.document.all("hiddenType1").value;

	if(xmlHTTP.statusText=="OK"){
//		alert("�s�W�q�榨�\");
		if(window.confirm("�s�W�q�榨�\,�n�i��ú�ڳB�z?"))
			window.location.href="http://140.96.18.18/mrlpub/d1/PayFilter.aspx?caller=order";
//			window.location.href="http://140.96.18.18/mrlpub/d1/PayTypeForm.aspx?caller=order&id="+window.document.all("hiddenOrderNo").value;
		else{
			if(window.confirm("�n�~��s�W�q��?")){
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
		alert("�s�W�o���}�߳��ɥ���!!"+xmlHTTP.responseText);
	else if(xmlHTTP.statusText=="Error2")
		alert("�s�W�q�楢��!!"+xmlHTTP.responseText);
	else
		alert(xmlHTTP.responseText);
	var xmlHTTP = null;
}
	</script>
	</body>
</HTML>
