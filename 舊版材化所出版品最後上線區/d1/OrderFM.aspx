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
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="OrderFM" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 706px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								�q��B�z <IMG height="10" src="images/header/right02.gif" width="10" border="0"><asp:Label ID="lblTitle" Runat="server"></asp:Label><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								�ק�q��</font>
						</td>
					</tr>
				</table>
				<TABLE dataFld="�q��" id="MainTable" style="WIDTH: 706px" dataSrc="#DSO1" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">�q����</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 125px" align="right">
							�q��s���G
						</TD>
						<TD style="WIDTH: 192px">
							<span dataFld="�q��s��" id="Span1" style="COLOR: maroon" runat="server"></span><input id="hiddenID" type="hidden" name="hiddenID" runat="server">
							<INPUT id="hiddenFgoi" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenFgoi" runat="server">
							<INPUT id="hiddenFgoe" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenFgoe" runat="server">
							<input id="hiddenBook" type="hidden" name="hiddenBook" runat="server">
						</TD>
						<TD style="WIDTH: 108px" align="right">
							�q��m�W�G
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="�s�ө���"></FONT>
							<asp:label id="lblName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<tr>
						<TD style="WIDTH: 125px" align="right">
							���q�W�١G
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="�s�ө���"></FONT>
							<asp:label id="lblCoName" ForeColor="Maroon" Runat="server"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoName" runat="server">
						</TD>
						<TD style="WIDTH: 108px" align="right">
							�W���ק����G
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="�s�ө���"></FONT>
							<asp:label id="lblModifyDate" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</tr>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">�q��εo�����</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�q��y�����G
						</td>
						<td style="WIDTH: 235px">
							<span dataFld="�q��y����" id="Span2" style="COLOR: maroon" runat="server"></span><input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q��ӷ��G
						</td>
						<td style="WIDTH: 235px">
							<SELECT dataFld="�q��ӷ�" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�q�ʤ���G
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="�q�ʤ��" id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" name="tbxOrderDate" runat="server"><IMG class="ico" title="���" onclick="pick_date(tbxOrderDate.name)" src="../images/calendar01.gif">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q�����O�G
						</td>
						<td style="WIDTH: 257px">
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly Width="38px"></asp:textbox>
							<SELECT dataFld="�q�����O�G" id="ddlOrderType2" name="Select1" runat="server"></SELECT>
							<input id="hiddenType1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hiddenType1" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�o�����O�G
						</td>
						<td style="WIDTH: 235px">
							<asp:Panel ID="panel1" Runat="server">
<INPUT dataFld="�o�����O" id="rblInvcd1" type="radio" value="2" name="rblInvcd" runat="server">�G�p 
<INPUT dataFld="�o�����O" id="rblInvcd2" type="radio" value="3" name="rblInvcd" runat="server">�T�p 
<INPUT dataFld="�o�����O" id="rblInvcd3" type="radio" value="4" name="rblInvcd" runat="server">��L
						</asp:Panel>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�ҵ|�O�G
						</td>
						<td style="WIDTH: 257px">
							<asp:Panel ID="panel2" Runat="server">
<INPUT dataFld="�o���ҵ|�O" type="radio" value="1" name="rblTaxtp">���|5% 
<INPUT dataFld="�o���ҵ|�O" type="radio" value="2" name="rblTaxtp">�s�| 
<INPUT dataFld="�o���ҵ|�O" type="radio" value="3" name="rblTaxtp">�K�|
						</asp:Panel>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�I�ڤ覡�G
						</td>
						<td colSpan="3">
							<SELECT dataFld="�I�ڤ覡" id="ddlPayType" name="ddlPayType" runat="server"></SELECT>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�Τ@�s���G
						</TD>
						<TD style="WIDTH: 192px">
							<input dataFld="�Τ@�s��" id="tbxMfrno" name="tbxMfrno" runat="server">
						</TD>
						<TD style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q�ܡG
						</TD>
						<td style="WIDTH: 257px">
							<input dataFld="�o������H�q��" id="tbxTel" name="tbxTel" runat="server">
						</td>
					</TR>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�o������H�m�W�G
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="�o������H�m�W" id="tbxInvoiceName" name="tbxInvoiceName" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�ǯu�G
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="�o������H�ǯu" id="tbxFax" name="tbxFax" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�o������H¾�١G
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="�o������H¾��" id="tbxInvoiceJob" name="tbxInvoiceJob" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							����G
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="�o������H���" id="tbxCell" name="tbxCell" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�o������HEmail�G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="�o������HEmail" id="tbxEmail" name="tbxEmail" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�l���ϸ��G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="�o������H�l���ϸ�" id="tbxPostCode" style="WIDTH: 39px; HEIGHT: 22px" size="1" name="tbxPostCode" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							�o���l�H�a�}�G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="�o������H�a�}" id="tbxAddress" style="WIDTH: 421px; HEIGHT: 22px" size="64" name="tbxAddress" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							�ӿ�~�ȭ��G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<SELECT dataFld="�ӿ�H��" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">����H���</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 125px" align="right" bgColor="#bfcff0">
							����H�G
						</TD>
						<TD style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="�s�W/�ק怜��H" onclick="doGetRec()" src="images/new.gif" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</TD>
					</TR>
				</TABLE>
				<TABLE dataFld="�q�����" id="Table1" dataSrc="#DSO1" cellSpacing="0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="���Ӫ�" id="tbItems" style="WIDTH: 758px" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD id="1">
									<TR id="11" bgColor="#214389">
										<TD style="WIDTH: 758px" colSpan="11">
											<FONT color="white">�q����Ӹ��</FONT>
										</TD>
									</TR>
									<TR id="3" borderColor="#bfcff0" bgColor="#bfcff0">
										<TD id="33" style="WIDTH: 41px; HEIGHT: 6px">
											�\��
										</TD>
										<TD style="WIDTH: 32px">
											����
										</TD>
										<TD style="WIDTH: 91px" align="middle">
											���y���O
										</TD>
										<TD style="WIDTH: 58px" align="middle">
											�q��O
										</TD>
										<TD style="WIDTH: 105px" align="middle">
											�q�\�_��
										</TD>
										<TD style="WIDTH: 110px" align="middle">
											�q�\�W��
										</TD>
										<TD style="WIDTH: 42px" align="middle">
											���B
										</TD>
										<TD style="WIDTH: 50px" align="middle">
											�`�ƶq
										</TD>
										<TD style="WIDTH: 213px" align="middle">
											����H
										</TD>
										<TD style="WIDTH: 49px" align="middle">
											�Ƶ�
										</TD>
									</TR>
								</THEAD>
								<TR id="tbItems1" borderColor="#bfcff0" bgColor="#e2eafc">
									<TD id="22" style="WIDTH: 41px">
										<IMG class="ico" title="�s�W���" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="�s�ө���">&nbsp;</FONT><IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
									</TD>
									<TD style="WIDTH: 32px">
										<INPUT dataFld="����" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 91px">
										<SELECT dataFld="���y���O" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT><input dataFld="�p���N��" id="hiddenProj" style="WIDTH: 27px; HEIGHT: 22px" type="hidden" size="1" name="hiddenProj" runat="server">
									</TD>
									<TD style="WIDTH: 58px">
										<SELECT dataFld="�s�­q��" id="ddlCust" name="ddlCust" runat="server">
											<OPTION value="�s�q��" selected>
												�s�q</OPTION>
											<OPTION value="��q��">
												��q</OPTION></SELECT>
									</TD>
									<TD style="WIDTH: 105px">
										<INPUT dataFld="�q�\�_��" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt4">
										<IMG class="ico" title="���" onclick="pick_dateStart(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 110px">
										<INPUT dataFld="�q�\�W��" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<IMG class="ico" title="���" onclick="pick_dateEnd(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 42px">
										<INPUT dataFld="���B" id="tbxAmt" style="WIDTH: 41px; HEIGHT: 22px" type="text" maxLength="6" size="1" name="tt6" runat="server">
									</TD>
									<TD style="WIDTH: 50px">
										<INPUT dataFld="�`�ƶq" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</TD>
									<TD id="test1" style="WIDTH: 213px">
										<IMG class="ico" title="����H�ԲӸ��" onclick="doSelectRec(this)" src="images/edit.gif" border="0">
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
				<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server"> <input id="btnSave" onclick="doSubmit()" type="button" value="�x�s�q��"><input id="btnCancel" onclick='javascritp:window.location.href="../default.aspx"' type="button" value="�����^����">&nbsp;
			</center>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
DSO1.XMLDocument.async = false; 
DSO2.XMLDocument.async = false; 
DSOX.XMLDocument.async = false; 
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.loadXML(document.all("hiddenXML").value);
var xmlReceivers = xmlDoc1.selectSingleNode("/root/����H���");
//xmlReceivers.childNodes.item(0).selectSingleNode("���q�W��").text=document.all("hiddenCoName").value;
//xmlReceivers.childNodes.item(0).selectSingleNode("�a�}").text=document.all("tbxAddress").value;
//xmlReceivers.childNodes.item(0).selectSingleNode("�Ǹ�").text="1";
var xmlRecItem = xmlDoc1.selectSingleNode("/root/�q�����/���Ӫ�");
var xmlItems = xmlDoc1.selectSingleNode("/root/�q�����");
var xmlHeader = xmlDoc1.selectSingleNode("/root/�q��");
var xmlMain = xmlDoc1.selectSingleNode("/root");
var xmlEmptyItem = DSO2.XMLDocument;
xmlEmptyItem.load("�ťն��ؤ@.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.all("hiddenBook").value);
var ItemBook=xmlDocX.selectSingleNode("���y���");
//document.all("textarea1").value=ItemBook.xml;
strbuf="";
for(i=0; i<xmlReceivers.childNodes.length; i++){
	strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("�m�W").text+",";	//<�m�W>���ĤG��
}
document.all("lblRec").innerText=strbuf;
//alert(document.all("tbItems").children.item(1).children.item(0).children("test1").children("lblRec1").innerText);
/*for(i=0; i<xmlItems.childNodes.length; i++){
	strbuf="";
//	alert("length="+xmlItems.childNodes.item(i).selectSingleNode("�뻼���").xml);
	for(j=0; j<xmlItems.childNodes.item(i).selectSingleNode("�뻼���").childNodes.length; j++){
//		alert("j="+j);
//		alert(xmlItems.childNodes.item(i).selectSingleNode("�뻼���").childNodes.item(j).selectSingleNode("�m�W").text);
		strbuf+=xmlItems.childNodes.item(i).selectSingleNode("�뻼���").childNodes.item(j).selectSingleNode("�m�W").text+",";	//<�m�W>���ĤG��
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
		xmlReceivers = xmlDoc1.selectSingleNode("/root/����H���");
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
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
    vreturn=window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:750px;"); 
	if(vreturn){
		Items.parentNode.replaceChild(myObject.result, Items);
		Items=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
		var	amt=0;
		strbuf="";
		for(i=0; i<Items.childNodes.length; i++){
			amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("�l�H�ƶq").text);	//<�m�W>���ĤG��
			strbuf+=Items.childNodes.item(i).selectSingleNode("�m�W").text+",";	//<�m�W>���ĤG��
		}
		xmlItems.childNodes.item(idx).selectSingleNode("�`�ƶq").text=String(amt);
		event.srcElement.parentElement.children("lblRec1").innerText=strbuf;
	}
//	document.all("textarea1").value=xmlItems.xml;
}
function doSelectBook(obj)
{
	var idx = obj.recordNumber-1;
	BookType=xmlItems.childNodes.item(idx).selectSingleNode("���y���O").text;
	Type1=xmlHeader.selectSingleNode("�I�ڤ覡").text
//	document.all("textarea1").value=xmlHeader.xml;
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
//		alert("�s�W�q�榨�\");
			window.location.href="SaveMessage.aspx?str=modify";
	}
	else
		alert(xmlHTTP.responseText);
	var xmlHTTP = null;
}
		</script>
	</body>
</HTML>
