<%@ Page language="c#" Codebehind="InvRecSet.aspx.cs" Src="InvRecSet.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvRecSet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�D���@ �o���t�Ӧ���H</TITLE>
		<META content="Jean Chen" name="Programmer">
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
	<body>
		<!-- Run at Server Form-->
		<form id="InvRecSet" method="post" runat="server">
			<!-- �o������H�ѦҸ�� --><label style="FONT-SIZE: x-small; COLOR: #ff0066">[�o������H�ѦҸ��]</label>
			<!-- ��ܾ��v���-�o������H�� table (id=table1  dataSrc=#DSO3) -->
			<TABLE id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR borderColor="#bfcff0" bgColor="#bfcff0">
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small"></font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�Ǹ�</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�t��
								<br>
								�νs</font>
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
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�o��
								<br>
								���O</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�o��
								<br>
								�ҵ|�O</font>
						</TH>
						<TH width="40px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�|�Ҥ�
								<br>
								���O</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD>
							<IMG class="ico" title="�[�J�o������H" onclick="doCopy(this)" height="14" src="../images/copy.gif" border="0">
						</TD>
						<TD>
							<span dataFld="�o���t�ӧǸ�" dataFormatAs="html"></span>
						</TD>
						<TD>
							<span dataFld="�o������H�t�Ӳνs"></span>
						</TD>
						<TD>
							<span dataFld="�o������H�m�W"></span>
						</TD>
						<TD>
							<div dataFld="�o������H¾��" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="�o������H�l���ϸ�" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="�o������H�a�}">
							</div>
						</TD>
						<TD>
							<div dataFld="�o������H�q��" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="�o������H�ǯu" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="�o������H���" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="�o������HEmail" noWrap>
							</div>
						</TD>
						<TD>
							<div dataFld="�o�����O�N�X">
							</div>
						</TD>
						<TD>
							<div dataFld="�o���ҵ|�O�N�X">
							</div>
						</TD>
						<TD>
							<div dataFld="�|�Ҥ����O">
							</div>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<FONT color="#c00000" size="2">��1�G* ���������!</FONT>
			<br>
			<font color="#c00000" size="2">�Ы��W����s�ӿ�����w���o������H, �M���ܥ��T�� "�l�H���O / ���~�l�H���"!</font>
			<br>
			<!-- �s�W���x����H�� table (id=table2  dataSrc=#DSO2) -->
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
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* �t��
								<br>
								&nbsp;&nbsp;�νs</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* �m�W</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">¾��</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* �l��
								<br>
								�ϸ�</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">* �a�}</font>
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
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�o��
								<br>
								���O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�o��
								<br>
								�ҵ|�O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�|�Ҥ�
								<br>
								���O</font>
						</TH>
					</TR>
				</THEAD>
				<tbody bgColor="#e7e7ff">
					<TR>
						<TD>
							<IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
						</TD>
						<TD>
							<span dataFld="�o���t�ӧǸ�" id="lblIMItem"></span>
						</TD>
						<TD>
							<input dataFld="�o������H�t�Ӳνs" id="tbxIMMfrNo" style="WIDTH: 65px" type="text" maxLength="10" size="1" name="tbxIMMfrNo">
						</TD>
						<TD>
							<input dataFld="�o������H�m�W" id="tbxIMName" style="WIDTH: 55px" type="text" maxLength="30" size="1" name="tbxIMName">
						</TD>
						<TD>
							<input dataFld="�o������H¾��" id="tbxIMJobTitle" style="WIDTH: 40px" type="text" maxLength="12" size="1" name="tbxIMJobTitle">
						</TD>
						<TD>
							<input dataFld="�o������H�l���ϸ�" id="tbxIMZipcode" style="WIDTH: 35px" type="text" maxLength="5" size="1" name="tbxIMZipcode">
						</TD>
						<TD>
							<TEXTAREA dataFld="�o������H�a�}" id="tbxIMAddr" name="tbxIMAddr" rows="3" cols="20" style="WIDTH: 110px">
							</TEXTAREA>
						</TD>
						<TD>
							<input dataFld="�o������H�q��" id="tbxIMTel" style="WIDTH: 65px" type="text" maxLength="30" size="1" name="tbxIMTel">
						</TD>
						<TD>
							<input dataFld="�o������H�ǯu" id="tbxIMFax" style="WIDTH: 65px" type="text" maxLength="30" size="1" name="tbxIMFax">
						</TD>
						<TD>
							<input dataFld="�o������H���" id="tbxIMCell" style="WIDTH: 50px" type="text" maxLength="30" size="1" name="tbxIMCell">
						</TD>
						<TD>
							<input dataFld="�o������HEmail" id="tbxIMEmail" style="WIDTH: 50px" type="text" maxLength="80" size="1" name="tbxIMEmail">
						</TD>
						<TD>
							<SELECT dataFld="�o�����O�N�X" id="SelIMInvCode" name="SelIMInvCode" runat="server">
								<OPTION value="2">
									�G�p</OPTION>
								<OPTION value="3" selected>
									�T�p</OPTION>
								<OPTION value="4">
									��L</OPTION></SELECT>
						</TD>
						<TD>
							<SELECT dataFld="�o���ҵ|�O�N�X" id="SelIMTaxType" name="SelIMTaxType" runat="server">
								<OPTION value="1" selected>
									���|5%</OPTION>
								<OPTION value="2">
									�s�|</OPTION>
								<OPTION value="3">
									�K�|</OPTION></SELECT>
						</TD>
						<TD>
							<SELECT dataFld="�|�Ҥ����O" id="SelIMfgItri" name="SelIMfgItri" runat="server">
								<OPTION value="" selected>
									�_</OPTION>
								<OPTION value="06">
									�Ҥ�</OPTION>
								<OPTION value="07">
									�|��</OPTION></SELECT>
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
		xmlDoc1.load("InvRec.xml");
		//alert(xmlDoc1.xml);
		
		//-------- �`�N: ������(�P InvRecForm.asp�ۤ�)�]�L�s�W���\��, �ҥH���� xmlNewItems ���q�� coding ���i�H�ٲ�  ---------- //
		var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("�o���t�Ӧ���H����");
		xmlNewItems.selectSingleNode("�X���ѽs��").text=oMyObject.ContNo;
		//alert(xmlNewItems.xml);
		
		
		// �а� �s�W���x����H�� table (id=table1  dataSrc=#DSO3)
		// ��X�ѬD�����x����H�����v��� or �s�W�s�����x����H (�Y�L���v���, �h�����s�W)
		var xmlDoc3 = DSO3.XMLDocument;
		xmlDoc3.async = false;
		xmlDoc3.loadXML(oMyObject.prexmldata);
		//alert(oMyObject.prexmldata);
		
		var xmlItems3 = xmlDoc3.selectSingleNode("�o���t�Ӹ��");
		//alert("xmlItems3= " + xmlItems3.xml);
		
		
		// �а� �s�W�����^�e���� table (id=table2  dataSrc=#DSO2)
		var xmlDoc2 = DSO2.XMLDocument;
		xmlDoc2.async = false;
		xmlDoc2.loadXML(oMyObject.xmldata);
		
		//var xmlItems = xmlDoc2.selectSingleNode("�o���t�Ӹ��");
		var xmlItems = xmlDoc2.selectSingleNode("�o���t�Ӧ���H�Ӹ`");
		//alert("xmlItems= " + xmlItems.xml);
		
		
		function doDelete(obj){
			var idx = obj.recordNumber-1;
			var oldNode = xmlItems.childNodes.item(idx);
			if(xmlItems.childNodes.length <= 1)
				{
					var newNode = xmlNewItems.cloneNode(true);
					xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
				}
			oldNode.parentNode.removeChild(oldNode);
			
			// Disable �H�U�P�_��, �O�]���B�����T�� pub_imseq (�Y�쥻�� im_seq, �Ӥ��������ssort�Ǹ����ʧ@)
			// �C�R���@��, ���s��ܧǸ�
			//for(i=0; i<xmlItems.childNodes.length;i++)
			//{
				//j1=String(i+1);
				//if(j1.length==1){
					//j1="0"+j1;
					//xmlItems.childNodes.item(i).selectSingleNode("�o���t�ӧǸ�").text=j1;
				//}
				//else
					//xmlItems.childNodes.item(i).selectSingleNode("�o���t�ӧǸ�").text=i+1;
			//}
		}
		
		
		function doCopy(obj){
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			//alert("xmlItems3= " + xmlItems3.xml);
			//alert("xmlItems3(" + idx + ")= " + xmlItems3.childNodes.item(idx).xml);
			
			var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
			//alert("newNode= " + newNode.xml);
			
			xmlItems = xmlDoc2.selectSingleNode("�o���t�Ӧ���H�Ӹ`");
			//alert("xmlItems.firstChild= " + xmlItems.firstChild.xml);
			//alert("xmlItems.firstChild.childNodes.item(1).text= " + xmlItems.firstChild.childNodes.item(1).text);
			if(xmlItems.firstChild.childNodes.item(1).text=="")
				xmlItems.replaceChild(newNode, xmlItems.firstChild);
			else
				xmlItems.appendChild(newNode);
			xmlItems = xmlDoc2.selectSingleNode("�o���t�Ӧ���H�Ӹ`");
			
			// Disable �H�U�P�_��, �O�]���B�����T�� pub_imseq (�Y�쥻�� im_seq, �Ӥ��������ssort�Ǹ����ʧ@)
			// �C�s�W�@��, ���s��ܧǸ�
			//for(i=0; i<xmlItems.childNodes.length;i++)
			//{
				//j1=String(i+1);
				//if(j1.length==1){
					//j1="0"+j1;
					//xmlItems.childNodes.item(i).selectSingleNode("�o���t�ӧǸ�").text=j1;
				//}
				//else
				//{
					//xmlItems.childNodes.item(i).selectSingleNode("�o���t�ӧǸ�").text=i+1;
				//}
				
			//}
			
		}
		
		
		function SelectOK(obj){
			// �U��O�����ˬd XML ���γ~
			//window.document.all("textarea1").value=xmlItems.xml;
			
			// �ˬd ������� �O�_����
			var idx = xmlItems.childNodes.length;
			for(i=0; i<idx;i++)
			{
				// �o������H�t�Ӳνs
				if(xmlItems.childNodes.item(i).selectSingleNode("�o������H�t�Ӳνs").text=="")  {
					var j=i+1;
					alert("��" + j + "�����t�Ӳνs���i�ť�");
					return;	}
				
				// �o������H�m�W
				if(xmlItems.childNodes.item(i).selectSingleNode("�o������H�m�W").text=="")  {
					var m=i+1;
					alert("��" + m + "�����o������H�m�W���i�ť�");
					return;	}
				
				// �o������H�l���ϸ�
				if(xmlItems.childNodes.item(i).selectSingleNode("�o������H�l���ϸ�").text=="")  {
					var n=i+1;
					alert("��" + n + "�����o������H�l���ϸ����i�ť�");
					return;	}
				
				// �o������H�a�}
				if(xmlItems.childNodes.item(i).selectSingleNode("�o������H�a�}").text=="")  {
					var p=i+1;
					alert("��" + p + "�����o������H�a�}���i�ť�");
					return;	}
			
				// �B�z �X���ѽs�� : �]�X���ѽs�������v��Ƭ� �ª��X���ѽs��, ���N���אּ�s���X���ѽs��, �_�h�s�ɮɦ��~(PK�|����)
				xmlItems.childNodes.item(i).selectSingleNode("�X���ѽs��").text = oMyObject.ContNo;
			}
			
			// �Ǧ^ XML �Ȩ���������
			// �T�{ �D���h: �@��������ƥu�঳�@���o���t�Ӧ���H���
			//alert("idx= " + idx);
			if(idx<=1)
			{
				oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
				//alert("oMyObject.result= " + oMyObject.result.xml);
				window.returnValue = true;
				window.close();
			}
			else
			{
				alert("�ЬD��@���o���t�Ӧ���H���!  �h�l��ƽЫ� '�ŤM�ϥ�(�R��)' �ӧR��!");
				return;
			}
			
		}
		
		-->
		</SCRIPT>
	</body>
</HTML>
