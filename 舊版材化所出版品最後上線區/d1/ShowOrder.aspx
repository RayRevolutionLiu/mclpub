<%@ Page language="c#" Codebehind="ShowOrder.aspx.cs" src="ShowOrder.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.ShowOrder" %>
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
	</HEAD>
	<body>
		<form id="ShowOrder" method="post" runat="server">
			<center>
				<input id="b1" onclick="javascript:window.close();" type="button" value="��������">&nbsp;
				<TABLE dataFld="�q��" id="MainTable" style="WIDTH: 655px" dataSrc="#DSO1" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">�q����</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 124px" align="right">
							�q��s���G
						</TD>
						<TD style="WIDTH: 192px" colSpan="3">
							<span dataFld="�q��s��" style="COLOR: maroon" runat="server"></span><input id="hiddenID" type="hidden" name="hiddenID" runat="server">&nbsp;&nbsp;
						</TD>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">�q��εo�����</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�q��y�����G
						</td>
						<td style="WIDTH: 235px">
							<span dataFld="�q��y����" style="COLOR: maroon" runat="server"></span><input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q��ӷ��G
						</td>
						<td style="WIDTH: 235px">
							<SELECT dataFld="�q��ӷ�" id="ddlOrderRes" runat="server" disabled></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�q�ʤ���G
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="�q�ʤ��" id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" name="tbxOrderDate" runat="server" readonly>&nbsp;&nbsp;
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q�����O�G
						</td>
						<td style="WIDTH: 257px">
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly Width="38px"></asp:textbox>
							<SELECT dataFld="�q�����O�G" id="ddlOrderType2" name="Select1" runat="server" disabled></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�o�����O�G
						</td>
						<td style="WIDTH: 235px">
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
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�I�ڤ覡�G
						</td>
						<td colSpan="3">
							<SELECT dataFld="�I�ڤ覡" id="ddlPayType" name="ddlPayType" runat="server" disabled></SELECT>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�Τ@�s���G
						</TD>
						<TD style="WIDTH: 192px">
							<input dataFld="�Τ@�s��" id="tbxMfrno" runat="server" readonly>
						</TD>
						<TD style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�q�ܡG
						</TD>
						<td style="WIDTH: 257px">
							<input dataFld="�o������H�q��" id="tbxTel" runat="server" readonly>
						</td>
					</TR>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�o������H�m�W�G
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="�o������H�m�W" id="tbxInvoiceName" runat="server" readonly>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							�ǯu�G
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="�o������H�ǯu" id="tbxFax" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�o������H¾�١G
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="�o������H¾��" id="tbxInvoiceJob" runat="server" readonly>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							����G
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="�o������H���" id="tbxCell" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�o������HEmail�G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="�o������HEmail" id="tbxEmail" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�l���ϸ��G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="�o������H�l���ϸ�" id="tbxPostCode" style="WIDTH: 39px; HEIGHT: 22px" size="1" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							�o���l�H�a�}�G
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="�o������H�a�}" id="tbxAddress" style="WIDTH: 421px; HEIGHT: 22px" size="64" runat="server" readonly>
						</td>
					</tr>
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">����H���</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 124px" align="right" bgColor="#bfcff0">
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
							<TABLE dataFld="���Ӫ�" id="tbItems" style="WIDTH: 655px" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 639px" colSpan="10">
											<FONT color="white">�q����Ӹ��</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0">
										<TD style="WIDTH: 37px">
											����
										</TD>
										<TD style="WIDTH: 98px" align="middle">
											���y���O
										</TD>
										<TD style="WIDTH: 70px" align="middle">
											�q��O
										</TD>
										<TD style="WIDTH: 96px" align="middle">
											�p���N��
										</TD>
										<TD style="WIDTH: 75px" align="middle">
											�q�\�_��
										</TD>
										<TD style="WIDTH: 72px" align="middle">
											�q�\�W��
										</TD>
										<TD style="WIDTH: 41px" align="middle">
											���B
										</TD>
										<TD style="WIDTH: 50px" align="middle">
											�`�ƶq
										</TD>
										<TD style="WIDTH: 49px" align="middle">
											����H
										</TD>
									</TR>
								</THEAD>
								<TR borderColor="#bfcff0" bgColor="#e2eafc">
									<TD style="WIDTH: 37px">
										<INPUT dataFld="����" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 98px">
										<SELECT dataFld="���y���O" id="ddlBookType" name="ddlBookType" runat="server" disabled>
											<OPTION selected>
											</OPTION>
										</SELECT>
									</TD>
									<TD style="WIDTH: 70px">
										<SPAN dataFld="�s�­q��" id="tbxCust"></SPAN>
									</TD>
									<TD style="WIDTH: 96px">
										<INPUT dataFld="�p���N��" id="tbxProj" style="WIDTH: 85px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="7" name="tt3">
									</TD>
									<TD style="WIDTH: 75px">
										<INPUT dataFld="�q�\�_��" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="6" name="tt4">
									</TD>
									<TD style="WIDTH: 72px">
										<INPUT dataFld="�q�\�W��" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="6" name="tt5">
									</TD>
									<TD style="WIDTH: 41px">
										<INPUT dataFld="���B" id="tbxAmt" style="WIDTH: 41px; HEIGHT: 22px" readOnly type="text" maxLength="6" size="1" name="tt6">
									</TD>
									<TD style="WIDTH: 50px">
										<INPUT dataFld="�`�ƶq" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</TD>
									<TD style="WIDTH: 49px">
										<IMG class="ico" title="����H�ԲӸ��" onclick="doSelectRec(this)" src="images/edit.gif" border="0">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">
			</center>
		</form>
		<script language="javascript">
DSO1.XMLDocument.async = false; 
DSO2.XMLDocument.async = false; 
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.loadXML(document.all("hiddenXML").value);
var xmlReceivers = xmlDoc1.selectSingleNode("/root/����H���");
var xmlRecItem = xmlDoc1.selectSingleNode("/root/�뻼���");
var xmlItems = xmlDoc1.selectSingleNode("/root/�q�����");
var xmlHeader = xmlDoc1.selectSingleNode("/root/�q��");
var xmlMain = xmlDoc1.selectSingleNode("/root");
//document.all("textarea1").value=xmlHeader.xml;

		</script>
		<script language="javascript">
function doGetRec()
{
    var myObject = new Object();
	    myObject.flag=true;
		myObject.prexmldata=xmlReceivers.xml;
    myObject.xmldata=xmlReceivers.xml;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
}
function doSelectRec(obj)
{
	var idx = obj.recordNumber-1;
    var myObject = new Object();
    var Items=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
    vreturn=window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:750px;"); 
//	Items.parentNode.replaceChild(myObject.result, Items);
//    Items=xmlItems.childNodes.item(idx).selectSingleNode("�뻼���");
//	var	amt=0;
//	for(i=0; i<Items.childNodes.length; i++){
//		amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("�l�H�ƶq").text);	//<�m�W>���ĤG��
//	}
//	xmlItems.childNodes.item(idx).selectSingleNode("�`�ƶq").text=String(amt);
//	document.all("textarea1").value=xmlItems.xml;
}
		</script>
	</body>
</HTML>
