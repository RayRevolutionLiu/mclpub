<%@ Page language="c#" Codebehind="RecForm.aspx.cs" src="RecForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.RecForm" %>
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
		<OBJECT id="DSO3" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
	</HEAD>
	<body>
		<form id="RecForm" method="post" runat="server">
			<label style="FONT-SIZE: x-small; COLOR: #ff0066">[����H�ѦҸ��]</label>
			<TABLE id="table1" style="WIDTH: 744px" dataSrc="#DSO3" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR borderColor="#bfcff0" bgColor="#bfcff0">
						<TH style="WIDTH: 11px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���</font>
						</TH>
						<TH style="WIDTH: 52px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�m�W</font>
						</TH>
						<TH style="WIDTH: 51px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���q�W��</font>
						</TH>
						<TH style="WIDTH: 51px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">¾��</font>
						</TH>
						<TH style="WIDTH: 105px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�a�}</font>
						</TH>
						<TH style="WIDTH: 32px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�l���ϸ�</font>
						</TH>
						<TH style="WIDTH: 64px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�q��</font>
						</TH>
						<TH style="WIDTH: 66px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�ǯu</font>
						</TH>
						<TH style="WIDTH: 67px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���</font>
						</TH>
						<TH style="WIDTH: 83px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">Email</font>
						</TH>
						<TH style="WIDTH: 32px; HEIGHT: 29px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���~�l�H</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD style="WIDTH: 11px">
							<IMG class="ico" title="�[�J����H" onclick="doCopy(this)" height="14" src="images/copy.gif" border="0">
						</TD>
						<TD style="WIDTH: 52px">
							<span dataFld="�m�W" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 51px">
							<span dataFld="���q�W��" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 51px">
							<div dataFld="¾��" noWrap>
							</div>
						</TD>
						<TD style="WIDTH: 105px">
							<div dataFld="�a�}">
							</div>
						</TD>
						<TD style="WIDTH: 32px">
							<div dataFld="�l���ϸ�" noWrap>
							</div>
						</TD>
						<TD style="WIDTH: 64px">
							<div dataFld="�q��" noWrap>
								<FONT face="�s�ө���"></FONT>
							</div>
						</TD>
						<TD style="WIDTH: 66px">
							<div dataFld="�ǯu" noWrap>
							</div>
						</TD>
						<TD style="WIDTH: 67px">
							<div dataFld="���" noWrap>
							</div>
						</TD>
						<TD style="WIDTH: 83px">
							<div dataFld="Email">
							</div>
						</TD>
						<TD style="WIDTH: 32px">
							<div dataFld="���~�l�H">
							</div>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="doAddNew()" type="button" value="�s�W����H">
			<TABLE id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0">
				<THEAD bgColor="#4a3c8c">
					<TR>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�R��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�Ǹ�</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�m�W</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���q�W��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">¾��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�a�}</font>
						</TH>
						<TH style="WIDTH: 43px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�l���ϸ�</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�q��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�ǯu</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">Email</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�l�H�a��</font>
						</TH>
					</TR>
				</THEAD>
				<tbody bgColor="#e7e7ff">
					<TR>
						<TD>
							<IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">
						</TD>
						<TD>
							<label dataFld="�Ǹ�" id="tt0"></label>
						</TD>
						<TD>
							<input dataFld="�m�W" id="tt1" style="WIDTH: 60px; HEIGHT: 22px" type="text" maxLength="30" size="5" name="tt1">
						</TD>
						<TD>
							<input dataFld="���q�W��" id="tt" style="WIDTH: 60px; HEIGHT: 22px" type="text" maxLength="20" size="7" name="tt">
						</TD>
						<TD>
							<input dataFld="¾��" id="tt2" style="WIDTH: 60px; HEIGHT: 22px" type="text" maxLength="6" size="7" name="tt2">
						</TD>
						<TD>
							<textarea dataFld="�a�}" id="tta" rows="3" cols="15"></textarea>
						</TD>
						<TD style="WIDTH: 43px">
							<input dataFld="�l���ϸ�" id="tt4" style="WIDTH: 40px; HEIGHT: 22px" type="text" maxLength="5" size="1" name="tt4">
						</TD>
						<TD>
							<input dataFld="�q��" id="tt6" style="WIDTH: 66px; HEIGHT: 22px" type="text" size="5" name="tt6" maxLength="30">
						</TD>
						<TD>
							<input dataFld="�ǯu" id="tt7" style="WIDTH: 55px; HEIGHT: 22px" type="text" size="3" name="tt7">
						</TD>
						<TD>
							<input dataFld="���" id="tt8" style="WIDTH: 69px; HEIGHT: 22px" type="text" size="6" name="tt8">
						</TD>
						<TD>
							<input dataFld="Email" id="tt9" style="WIDTH: 90px; HEIGHT: 22px" type="text" size="9" name="tt9">
						</TD>
						<TD>
							<SELECT dataFld="���~�l�H" id="ddl1" name="ddl1" runat="server">
								<OPTION value="0" selected>
									�ꤺ</OPTION>
								<OPTION value="1">
									��~</OPTION></SELECT>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="SelectOK()" type="button" value="�s�W�����^�e��"> <INPUT id="hidden_xml" type="hidden" name="hidden_xml" runat="server">&nbsp;&nbsp;&nbsp;
			<br>
			&nbsp;
		</form>
		<SCRIPT language="javascript">
var oMyObject = window.dialogArguments;
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.async = false; 
xmlDoc1.load("RecAddr.xml");
var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("����H����");
//alert(xmlNewItems.xml);
xmlNewItems.selectSingleNode("���q�W��").text=oMyObject.CoName;
xmlNewItems.selectSingleNode("�a�}").text=oMyObject.Address;
//alert(oMyObject.CoName);
var xmlDoc3 = DSO3.XMLDocument;
xmlDoc3.async = false;
if(oMyObject.flag)
	xmlDoc3.loadXML(oMyObject.prexmldata);
else{
	document.all("table1").style.visibility="hidden";
}
var xmlItems3 = xmlDoc3.selectSingleNode("����H���");
var xmlDoc2 = DSO2.XMLDocument;
xmlDoc2.async = false;
//alert(oMyObject.xmldata);
xmlDoc2.loadXML(oMyObject.xmldata);
var xmlItems = xmlDoc2.selectSingleNode("����H���");
//alert(xmlItems.xml);
if((xmlItems.childNodes.item(0).selectSingleNode("�m�W").text=="")&&(xmlItems.childNodes.item(0).selectSingleNode("���q�W��").text=="")){
	xmlItems.childNodes.item(0).selectSingleNode("�m�W").text=oMyObject.Name;
	xmlItems.childNodes.item(0).selectSingleNode("�a�}").text=oMyObject.Address;
	xmlItems.childNodes.item(0).selectSingleNode("¾��").text=oMyObject.Job;
	xmlItems.childNodes.item(0).selectSingleNode("�l���ϸ�").text=oMyObject.PostCode;
	xmlItems.childNodes.item(0).selectSingleNode("�q��").text=oMyObject.Tel;
}


function doAddNew(){
	var idx = xmlItems.childNodes.length;
	var newNode = xmlNewItems.cloneNode(true);
	xmlItems.appendChild(newNode);
	var	j1=String(idx+1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx).selectSingleNode("�Ǹ�").text=j1;
	}
	else
		xmlItems.childNodes.item(idx).selectSingleNode("�Ǹ�").text=idx+1;
}
function doDelete(obj){
	var idx = obj.recordNumber-1;
	var oldNode = xmlItems.childNodes.item(idx);
	if(xmlItems.childNodes.length <= 1)
	{
		var newNode = xmlNewItems.cloneNode(true);
		xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
	}
	oldNode.parentNode.removeChild(oldNode);
	for(i=0; i<xmlItems.childNodes.length;i++){
		j1=String(i+1);
		if(j1.length==1){
			j1="0"+j1;
			xmlItems.childNodes.item(i).selectSingleNode("�Ǹ�").text=j1;
		}
		else
			xmlItems.childNodes.item(i).selectSingleNode("�Ǹ�").text=i+1;
	}
}
function doCopy(obj){
	var idx = obj.recordNumber-1;
	var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
	if(xmlItems.firstChild.childNodes.item(1).text=="")
		xmlItems.replaceChild(newNode, xmlItems.firstChild);
	else
		xmlItems.appendChild(newNode);
	var idx1 = xmlItems.childNodes.length;
//	alert(idx1);
//	alert(xmlItems.childNodes.item(0).selectSingleNode("�Ǹ�").text);
	var	j1=String(idx1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx1-1).selectSingleNode("�Ǹ�").text=j1;
	}
	else
		xmlItems.childNodes.item(idx1-1).selectSingleNode("�Ǹ�").text=idx1;
}
function SelectOK(obj){
	oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
	window.returnValue = true;
	window.close();
}
		</SCRIPT>
	</body>
</HTML>
