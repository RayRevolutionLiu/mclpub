<%@ Page language="c#" Codebehind="SetRecForm.aspx.cs" src="SetRecForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.SetRecForm" %>
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
		<form id="SetRecForm" method="post" runat="server">
			<asp:Label id="Label1" runat="server" ForeColor="#0000C0" Font-Size="X-Small">����H���</asp:Label>
			<TABLE id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR borderColor="#bfcff0" bgColor="#bfcff0">
						<TH style="WIDTH: 2px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���</font>
						</TH>
						<TH style="WIDTH: 12px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�Ǹ�</font>
						</TH>
						<TH style="WIDTH: 51px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�m�W</font>
						</TH>
						<TH style="WIDTH: 163px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���q�W��</font>
						</TH>
						<TH style="WIDTH: 44px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">¾��</font>
						</TH>
						<TH style="WIDTH: 98px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�a�}</font>
						</TH>
						<TH style="WIDTH: 32px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�l���ϸ�</font>
						</TH>
						<TH style="WIDTH: 73px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�q��</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD style="WIDTH: 2px">
							<IMG class="ico" title="�[�J����H" onclick="doCopy(this)" height="14" src="images/copy.gif" border="0">
						</TD>
						<TD style="WIDTH: 12px">
							<span dataFld="�Ǹ�"></span>
						</TD>
						<TD style="WIDTH: 51px">
							<span dataFld="�m�W" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 163px">
							<span dataFld="���q�W��" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 44px">
							<div dataFld="¾��" noWrap>
								<FONT face="�s�ө���"></FONT>
							</div>
						</TD>
						<TD style="WIDTH: 98px">
							<div dataFld="�a�}">
								<FONT face="�s�ө���"></FONT>
							</div>
						</TD>
						<TD style="WIDTH: 32px">
							<div dataFld="�l���ϸ�" noWrap>
							</div>
						</TD>
						<TD style="WIDTH: 73px">
							<div dataFld="�q��" noWrap>
								<FONT face="�s�ө���"></FONT>
							</div>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<asp:Label id="Label2" runat="server" ForeColor="#C00000" Font-Size="X-Small">�п���ݭn������H,�M���W�ƶq�ζl�H���O</asp:Label>
			<TABLE id="table2" style="WIDTH: 499px" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="1">
				<THEAD>
					<TR borderColor="#4a3c8c" bgColor="#4a3c8c">
						<TH style="WIDTH: 15px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�R��</font>
						</TH>
						<TH style="WIDTH: 16px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�Ǹ�</font>
						</TH>
						<TH style="WIDTH: 89px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�m�W</font>
						</TH>
						<TH style="WIDTH: 163px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���q�W��</font>
						</TH>
						<TH style="WIDTH: 37px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�l�H�ƶq</font>
						</TH>
						<TH style="HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�l�H�a��</font>
						</TH>
						<TH style="HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�l�H���O</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD style="WIDTH: 15px">
							<IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">
						</TD>
						<TD style="WIDTH: 16px">
							<span dataFld="�Ǹ�"></span>
						</TD>
						<TD style="WIDTH: 89px">
							<span dataFld="�m�W" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 163px">
							<span dataFld="���q�W��" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 37px">
							<input dataFld="�l�H�ƶq" id="tt1" style="WIDTH: 35px; HEIGHT: 22px" type="text" size="1" name="tt5">
						</TD>
						<TD>
							<select datafld="���~�l�H" name="ddl1" disabled>
								<option value="0" selected>
									�ꤺ</option><option value="1">��~</option>
							</select>
						</TD>
						<TD>
							<SELECT dataFld="�l�H���O" id="ddlSendType" name="ddlSendType" runat="server">
								<OPTION selected>
								</OPTION>
							</SELECT>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="SelectOK()" type="button" value="�s�W�����^�e��"> <INPUT id="hidden_xml" type="hidden" name="hidden_xml" runat="server">&nbsp;&nbsp;&nbsp;
		</form>
		<SCRIPT language="javascript">
var oMyObject = window.dialogArguments;
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.async = false; 
xmlDoc1.load("RecAddr.xml");
var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("����H����");
//xmlNewItems.selectSingleNode("���q�W��").text=oMyObject.CoName;
var xmlDoc3 = DSO3.XMLDocument;
xmlDoc3.async = false;
xmlDoc3.loadXML(oMyObject.prexmldata.xml);
//alert(oMyObject.prexmldata.xml);
var xmlItems3 = xmlDoc3.selectSingleNode("����H���");
var xmlDoc2 = DSO2.XMLDocument;
xmlDoc2.async = false;
xmlDoc2.loadXML(oMyObject.xmldata.xml);
var xmlItems = xmlDoc2.selectSingleNode("�뻼���");
//	alert("xmlItems.xml"+xmlItems.xml);

function doDelete(obj){
	var idx = obj.recordNumber-1;
	var oldNode = xmlItems.childNodes.item(idx);
	if(xmlItems.childNodes.length <= 1)
	{
		var newNode = xmlNewItems.cloneNode(true);
		xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
	}
	oldNode.parentNode.removeChild(oldNode);
}
function doCopy(obj){
	var idx = obj.recordNumber-1;
//	alert("xmlItems3"+xmlItems3.childNodes.item(idx).xml);
	if(xmlItems3.childNodes.item(idx).selectSingleNode("���~�l�H")!=null){
		if(xmlItems3.childNodes.item(idx).selectSingleNode("���~�l�H").text=="0")
			xmlItems3.childNodes.item(idx).selectSingleNode("�l�H���O").text="11";
		else
			xmlItems3.childNodes.item(idx).selectSingleNode("�l�H���O").text="21";
	}
	var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
	if(xmlItems.firstChild.childNodes.item(1).text=="")
		xmlItems.replaceChild(newNode, xmlItems.firstChild);
	else
		xmlItems.appendChild(newNode);
	xmlItems = xmlDoc2.selectSingleNode("�뻼���");
}
function SelectOK(obj){
		oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
		window.returnValue = true;
		window.close();
}
function doSendType(obj)
{
	var idx = obj.recordNumber-1;
}
		</SCRIPT>
	</body>
</HTML>
