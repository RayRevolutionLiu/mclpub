<%@ Page language="c#" Codebehind="MazRecForm.aspx.cs" src="MazRecForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.MazRecForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�Ҧ����x����H���</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO1, DSO2, DSO3 -->
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSO3" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<BODY>
		<form id="MazRecForm" method="post" runat="server">
			<!-- ���x����H�ѦҸ�� -->
			<label style="FONT-SIZE: x-small; COLOR: #ff0066">[���x����H�ѦҸ��]</label> 
			<!-- ��ܾ��v���-���x����H�� table (id=table1  dataSrc=#DSO3) -->
			<TABLE id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR borderColor="#bfcff0" bgColor="#bfcff0">
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small"></font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���q�W��</font>
						</TH>
						<TH width="65px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�m�W</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">¾��</font>
						</TH>
						<TH width="35px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�l��
								<br>
								�ϸ�</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�a�}</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�q��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�ǯu</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">Email</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�l�H���O</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���n
								<br>
								����</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���n
								<br>
								����</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���~
								<br>
								�l�H</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD>
							<IMG class="ico" title="�[�J���x����H" onclick="doCopy(this)" height="14" src="../images/copy.gif" border="0">
						</TD>
						<TD>
							<span dataFld="���x����H���q�W��" dataFormatAs="html"></span>
						</TD>
						<TD>
							<span dataFld="���x����H�m�W" dataFormatAs="html"></span>
						</TD>
						<TD>
							<div dataFld="���x����H¾��" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="���x����H�l���ϸ�" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="���x����H�a�}">
							</div>
						</TD>
						<TD>
							<div dataFld="���x����H�q��" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="���x����H�ǯu" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="���x����H���" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="���x����HEmail">
							</div>
						</TD>
						<TD>
							<div dataFld="�l�H���O�N�X">
							</div>
						</TD>
						<TD>
							<div dataFld="���n����">
							</div>
						</TD>
						<TD>
							<div dataFld="���n����">
							</div>
						</TD>
						<TD>
							<div dataFld="���~�l�H���O">
							</div>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="doAddNew()" type="button" value="�s�W���x����H">
			<br>
			<FONT color="#c00000" size="2">��1�G* ���������!</FONT>
			<br>
			<font size="2" color="#c00000">��2�G���q�W�٤Φa�}��ƹw�]�P�t�Ӧa�}���; �p�ݭק�, �Цۦ�W��!</font>
			<br>
			<font color="#c00000" size="2">�ж�J�������(�m�W), �ÿ�ܥ��T�� "�l�H���O (���~�l�H���O)"!</font>
			<br>
			<!-- �s�W���x����H�� table (id=table2  dataSrc=#DSO2) -->
			<TABLE id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0">
				<THEAD bgColor="#4a3c8c">
					<TR>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�R��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">��
								<br>
								��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* ���q�W��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* �m�W</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">¾��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�l��
								<br>
								�ϸ�</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�a�}</font>
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
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�l�H���O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���n
								<br>
								����</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���n
								<br>
								����</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���~
								<br>
								�l�H</font>
						</TH>
					</TR>
				</THEAD>
				<tbody bgColor="#e7e7ff">
					<TR>
						<TD>
							<IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
						</TD>
						<TD>
							<label dataFld="���x����H�Ǹ�" id="lblOrItem"></label>
						</TD>
						<TD>
							<input dataFld="���x����H���q�W��" id="tbxOrCompanyName" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrCompanyName">
						</TD>
						<TD>
							<input dataFld="���x����H�m�W" id="tbxOrName" style="WIDTH: 55px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrName">
						</TD>
						<TD>
							<input dataFld="���x����H¾��" id="tbxOrJobTitle" style="WIDTH: 40px; HEIGHT: 22px" type="text" maxLength="12" size="1" name="tbxOrJobTitle">
						</TD>
						<TD>
							<input dataFld="���x����H�l���ϸ�" id="tbxOrZipcode" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="5" size="1" name="tbxOrZipcode">
						</TD>
						<TD>
							<TEXTAREA dataFld="���x����H�a�}" id="tbxORAddr" name="tbxORAddr" rows="3" cols="20" style="WIDTH: 110px">
							</TEXTAREA>
						</TD>
						<TD>
							<input dataFld="���x����H�q��" id="tbxOrTel" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrTel">
						</TD>
						<TD>
							<input dataFld="���x����H�ǯu" id="tbxOrFax" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrFax">
						</TD>
						<TD>
							<input dataFld="���x����H���" id="tbxOrCellular" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="30" size="1" name="tbxOrCellular">
						</TD>
						<TD>
							<input dataFld="���x����HEmail" id="tbxOrEmail" style="WIDTH: 55px; HEIGHT: 22px" type="text" maxLength="80" size="1" name="tbxOrEmail">
						</TD>
						<TD>
							<SELECT dataFld="�l�H���O�N�X" id="ddlORMailTypeCode" onafterupdate="doSelectORMailType(this)" name="ddlORMailTypeCode" runat="server"></SELECT>
						</TD>
						<TD>
							<input dataFld="���n����" id="tbxOrPubCount" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="3" size="1" name="tbxOrPubCount">
						</TD>
						<TD>
							<input dataFld="���n����" id="tbxOrUnpubCount" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="3" size="1" name="tbxOrUnpubCount">
						</TD>
						<TD>
							<SELECT dataFld="���~�l�H���O" id="ddlfgMailOversea" name="ddlfgMailOversea" runat="server" disabled>
								<OPTION value="0" selected>
									�ꤺ</OPTION>
								<OPTION value="1">
									��~</OPTION></SELECT>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="SelectOK()" type="button" value="�s�W�����^�e��"> <INPUT id="hidden_xml" type="hidden" name="hidden_xml" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<br>
			<!-- �� TEXTAREA �O���ˬd XML ��X�ˬd�� -->
			<!--TEXTAREA id="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
			<br>
		</form>
		<SCRIPT language="javascript">
		<!--
		// �۫e�@��, �� MyObject
		var oMyObject = window.dialogArguments;
		//alert(oMyObject.xmldata);
		
		// �I�s MazRec.xml ��
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.async = false; 
		xmlDoc1.load("MazRec.xml");
		//alert(xmlDoc1.xml);
		
		var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("���x����H����");
		//alert(xmlNewItems.xml);
		
		// �w�]���w ���x����H�t�ө��Y = ���q�W��, ���x����H�a�} = ���q�a�}, ���x����H�l���ϸ� = ���q�l���ϸ�
		// �N�ǹL�Ӫ� MyObject.�ܼ� �w�]�� �Ҧ��s�W��(�t�Ĥ@��) ���۹������
		xmlNewItems.selectSingleNode("�t�ΥN�X").text=oMyObject.Syscd;
		xmlNewItems.selectSingleNode("�X���ѽs��").text=oMyObject.ContNo;
		xmlNewItems.selectSingleNode("���x����H���q�W��").text=oMyObject.MfrName;
		xmlNewItems.selectSingleNode("���x����H�a�}").text=oMyObject.MfrAddress;
		xmlNewItems.selectSingleNode("���x����H�l���ϸ�").text=oMyObject.MfrZipcode;
		xmlNewItems.selectSingleNode("���x����H�q��").text=oMyObject.MfrTel;
		xmlNewItems.selectSingleNode("���x����H�ǯu").text=oMyObject.MfrFax;
		xmlNewItems.selectSingleNode("���x����H¾��").text=oMyObject.CustJobTitle;
		//alert(oMyObject.MfrName);
		//alert(xmlNewItems.xml);
		
		
		// �а� �s�W���x����H�� table (id=table1  dataSrc=#DSO3)
		// ��X�ѬD�����x����H�����v��� or �s�W�s�����x����H (�Y�L���v���, �h�����s�W)
		var xmlDoc3 = DSO3.XMLDocument;
		xmlDoc3.async = false;
		if(oMyObject.flag)
			xmlDoc3.loadXML(oMyObject.prexmldata);
		else
		{
			document.all("table1").style.visibility="hidden";
		}
		//alert(oMyObject.prexmldata.xml);
		var xmlItems3 = xmlDoc3.selectSingleNode("���x����H���");
		
		
		// �а� �s�W�����^�e���� table (id=table2  dataSrc=#DSO2)
		var xmlDoc2 = DSO2.XMLDocument;
		xmlDoc2.async = false;
		xmlDoc2.loadXML(oMyObject.xmldata);
		
		var xmlItems = xmlDoc2.selectSingleNode("���x����H���");
		xmlItems.childNodes.item(0).selectSingleNode("�X���ѽs��").text=oMyObject.ContNo;
		//alert("xmlItems.xml= " + xmlItems.xml);
		
		// �Y�s�W���Ĥ@��L���, �h���w�]��
		xmlItems.childNodes.item(0).selectSingleNode("���x����H�Ǹ�").text="01";
		if(xmlItems.childNodes.item(0).selectSingleNode("���x����H�m�W").text=="")
		{
			xmlItems.childNodes.item(0).selectSingleNode("�t�ΥN�X").text=oMyObject.Syscd;
			xmlItems.childNodes.item(0).selectSingleNode("�X���ѽs��").text=oMyObject.ContNo;
			xmlItems.childNodes.item(0).selectSingleNode("���x����H���q�W��").text=oMyObject.MfrName;
			xmlItems.childNodes.item(0).selectSingleNode("���x����H�a�}").text=oMyObject.MfrAddress;
			xmlItems.childNodes.item(0).selectSingleNode("���x����H�l���ϸ�").text=oMyObject.MfrZipcode;
			xmlItems.childNodes.item(0).selectSingleNode("���x����H�q��").text=oMyObject.MfrTel;
			xmlItems.childNodes.item(0).selectSingleNode("���x����H�ǯu").text=oMyObject.MfrFax;
			xmlItems.childNodes.item(0).selectSingleNode("���x����H¾��").text=oMyObject.CustJobTitle;
		}
		

		function doAddNew(){
			var idx = xmlItems.childNodes.length;
			//alert("idx= " + idx);

			// cloneNode �s�W�@��ťզ�
			var newNode = xmlNewItems.cloneNode(true);
			//alert("newNode= " + newNode.xml);
			xmlItems.appendChild(newNode);
			
			// �C�s�W�@��ťզ��, ��ܸӷs�椧�Ǹ�
			var	j1=String(idx+1);
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(idx).selectSingleNode("���x����H�Ǹ�").text=j1;
			}
			else
				xmlItems.childNodes.item(idx).selectSingleNode("���x����H�Ǹ�").text=idx+1;
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
			
			// �C�R���@��, ���s��ܧǸ�
			for(i=0; i<xmlItems.childNodes.length;i++)
			{
				j1=String(i+1);
				if(j1.length==1){
					j1="0"+j1;
					xmlItems.childNodes.item(i).selectSingleNode("���x����H�Ǹ�").text=j1;
				}
				else
					xmlItems.childNodes.item(i).selectSingleNode("���x����H�Ǹ�").text=i+1;
			}

		}
		
		
		function doCopy(obj){
			var idx = obj.recordNumber-1;
			var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
			if(xmlItems.firstChild.childNodes.item(1).text=="")
				xmlItems.replaceChild(newNode, xmlItems.firstChild);
			else
				xmlItems.appendChild(newNode);
			
			// �C�ƻs�@��, ���s��ܧǸ�
			var idx1 = xmlItems.childNodes.length;
			var	j1=String(idx1);
			//alert("j1= " + j1);
			//alert("���x����H�Ǹ�= " + xmlItems.childNodes.item(0).selectSingleNode("���x����H�Ǹ�").text);
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(idx1-1).selectSingleNode("���x����H�Ǹ�").text=j1;
			}
			else
				xmlItems.childNodes.item(idx1-1).selectSingleNode("���x����H�Ǹ�").text=idx1;
		}
			
			
		function SelectOK(obj){
			// �U��O�����ˬd XML ���γ~
			//window.document.all("textarea1").value=xmlItems.xml;
			
			// �ˬd ������� �O�_����
			var idx = xmlItems.childNodes.length;
			for(i=0; i<idx;i++)
			{				
				// ���x����H���q�W��
				if(xmlItems.childNodes.item(i).selectSingleNode("���x����H���q�W��").text=="")  {
					var k=i+1;
					alert("��" + k + "�������q�W�٤��i�ť�");
					return;	}

				// ���x����H�m�W
				if(xmlItems.childNodes.item(i).selectSingleNode("���x����H�m�W").text=="")  {
					var m=i+1;
					alert("��" + m + "�������x����H�m�W���i�ť�");
					return;	}
			}
			
			
			// �Ǧ^ XML �Ȩ���������
			oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
			//alert("oMyObject.result= " + oMyObject.result.xml);
			window.returnValue = true;
			window.close();
		}
		
		
		function doSelectORMailType(obj)
		{
			// �Y �l�H���O�N�X���� > 20 ��ܬ��H����~, �h���~�l�H���O�������l�H���O�N�X���אּ 1 (�w�]�� 0)
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			strbuf = xmlItems.childNodes.item(idx).selectSingleNode("�l�H���O�N�X").text;
			//alert("strbuf= " + strbuf);
			
			//��ܮ��~�l�H���O����
			if(strbuf>20)
				xmlItems.childNodes.item(idx).selectSingleNode("���~�l�H���O").text = 1;
			else
				xmlItems.childNodes.item(idx).selectSingleNode("���~�l�H���O").text = 0;
			
			// �U��O�����ˬd XML ���γ~
			//window.document.all("textarea1").value=xmlItems.xml;
		}
		-->
		</SCRIPT>
	</BODY>
</HTML>
