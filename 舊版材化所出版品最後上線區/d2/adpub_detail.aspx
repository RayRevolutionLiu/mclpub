<%@ Page language="c#" Codebehind="adpub_detail.aspx.cs" Src="adpub_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�i�����Z�n��Ƥ��Ӹ`��T</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO2 -->
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<body>
		<!-- ���� Header -->
		<!-- ���D -->
		<DIV align="left">
			<B><FONT color="darkblue" size="4">�����Ӹ`��T</FONT></B>&nbsp; <STRONG><FONT color="#00008b" size="4">
					�� <INPUT id="tbxContMessage" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: gray; BORDER-RIGHT-WIDTH: 0px" readOnly type="text" maxLength="100" size="50" name="tbxContMessage">&nbsp;<INPUT id="tbxPubMessage" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: gray; BORDER-RIGHT-WIDTH: 0px" readOnly type="text" maxLength="300" size="100" name="tbxPubMessage">&nbsp;
				</FONT></STRONG>
		</DIV>
		<br>
		<!-- Run at Server Form -->
		<form id="adpub_detail" method="post" runat="server">
			<!-- Table �}�l: �Ӹ`��T -->
			<!-- �s�W���x����H�� table (id=table2  dataSrc=#DSO2) -->
			<TABLE id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0">
				<THEAD bgColor="#4a3c8c">
					<TR>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">����
								<br>
								�s�i
								<br>
								���B</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���Z
								<br>
								���B</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�w�}��
								<br>
								�o��
								<br>
								���O</font>
							<br>
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: xx-small; COLOR: yellow">(0: �_, 1:�O)</FONT>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�o��
								<br>
								�}�߳�
								<br>
								�H�u
								<br>
								�B�z
								<br>
								���O</font>
							<br>
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: xx-small; COLOR: yellow">(0: �_, 1:�O)</FONT>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�Ƶ�</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�Z�����O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�½Z���y
								<br>
								���O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�½Z
								<br>
								���O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�½Z
								<br>
								���X</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">��Z���y
								<br>
								���O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">��Z
								<br>
								���O</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">��Z
								<br>
								���X</font>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">��Z
								<br>
								���X��
								<br>
								���O</font>
							<br>
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: xx-small; COLOR: yellow">(0: �_, 1:�O)</FONT>
						</TH>
						<TH>
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�s�Z
								<br>
								�s�k </font>
						</TH>
					</TR>
				</THEAD>
				<tbody bgColor="#e7e7ff">
					<TR>
						<TD>
							$ <input dataFld="�����s�i���B" id="tbxAdAmunt" style="WIDTH: 40px" type="text" maxLength="10" size="10" name="tbxAdAmunt">
						</TD>
						<TD>
							$ <input dataFld="���Z���B" id="tbxChangeAmunt" style="WIDTH: 40px" type="text" maxLength="10" size="10" name="tbxChangeAmunt">
						</TD>
						<TD>
							&nbsp; <input dataFld="�w�}�ߵo������O" id="tbxfgInvCode" onblur="Javascript:CheckValue2(this);" style="WIDTH: 30px; COLOR: gray" readOnly type="text" maxLength="1" size="1" name="tbxfgInvCode">
						</TD>
						<TD>
							&nbsp; <input dataFld="�o���}�߳�H�u�B�z���O" id="tbxfgInvSelf" onblur="Javascript:CheckValue3(this);" style="WIDTH: 30px; COLOR: gray" readOnly type="text" maxLength="1" size="1" name="tbxfgInvSelf">
						</TD>
						<TD>
							<input dataFld="�Ƶ�" id="tbxPubRemark" style="WIDTH: 65px" type="text" maxLength="255" size="10" name="tbxPubRemark">
						</TD>
						<TD>
							<SELECT dataFld="�Z�����O�N�X" id="ddlDraftTypeCode" onchange="Javascript:OnChangeddlDraftTypeCode(this);" name="ddlDraftTypeCode" runat="server">
								<OPTION value="1" selected>
									�½Z</OPTION>
								<OPTION value="2">
									�s�Z</OPTION>
								<OPTION value="3">
									��Z</OPTION></SELECT>
						</TD>
						<TD>
							<SELECT dataFld="�½Z���y�N�X" id="ddlOrigBookCode" name="ddlOrigBookCode" runat="server"></SELECT>
						</TD>
						<TD>
							<input dataFld="�½Z���O" id="tbxOrigJNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxOrigJNo">
						</TD>
						<TD>
							<input dataFld="�½Z���X" id="tbxOrigPageNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxOrigPageNo">&nbsp;<IMG class="ico" title="���X�ѦҸ��" src="../images/edit.gif" border="0" onclick="doGetPgNo1(this)">
						</TD>
						<TD>
							<SELECT dataFld="��Z���y�N�X" id="ddlChgBookCode" name="ddlChgBookCode" runat="server" disabled></SELECT>
						</TD>
						<TD>
							<input dataFld="��Z���O" id="tbxChangeJNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxChangeJNo" readonly>
						</TD>
						<TD>
							<input dataFld="��Z���X" id="tbxChgPageNo" style="WIDTH: 30px" type="text" maxLength="3" size="1" name="tbxChgPageNo">&nbsp;<IMG class="ico" title="���X�ѦҸ��" src="../images/edit.gif" border="0" onclick="doGetPgNo2(this)">
						</TD>
						<TD>
							&nbsp; <input dataFld="��Z���X�����O" id="tbxfgReChange" onblur="Javascript:CheckValue4(this);" style="WIDTH: 30px" type="text" maxLength="1" size="1" name="tbxfgReChange">
						</TD>
						<TD>
							<SELECT dataFld="�s�Z�s�k�N�X" id="ddlNJTypeCode" onchange="Javascript:CheckValue5(this);" name="ddlNJTypeCode" runat="server"></SELECT>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="EditPubOk()" type="button" value="�s�W�����^�e��"> <input type="reset" value="�M�����" name="ClearAll">
			&nbsp; <INPUT id="hidden_xml" style="WIDTH: 65px" type="hidden" size="5" name="hidden_xml" runat="server">
			<br>
			<asp:label id="Label1" runat="server" ForeColor="#C00000" Font-Size="X-Small">�����G���U "<SPAN style="COLOR: black; BACKGROUND-COLOR: #CDC9C9">
					�s�W�����^�e��</SPAN>" �ӽT�{�a�^�e���W�����; ���U "<SPAN style="COLOR: black; BACKGROUND-COLOR: #CDC9C9">�M�����</SPAN>" �ӲM���Ҧ����.</asp:label>
			<br>
			<asp:label id="Label2" runat="server" ForeColor="#C00000" Font-Size="X-Small">���G����J���O, �A���U '<U>
					�½Z���X/��Z���X </U>'�Ǫ��ϥܫ��s <IMG class="ico" title="���X�ѦҸ��" src="../images/edit.gif" border="0"> �i�a�^�w�]��! �p�ݭק�, �Цۦ�W�q!</asp:label>
			<br>
			<!-- �� TEXTAREA �O���ˬd XML ��X�ˬd�� -->
			<!--TEXTAREA id="textarea1" name="textarea1" rows="16" cols="80"--> <!--/TEXTAREA-->
		</form>
		<!-- ���� Footer -->
		<!-- Javascript -->
		<SCRIPT language="javascript">
		<!--
		// �۫e�@��, �� MyObject
		var oMyObject = window.dialogArguments;
		
		// �۫e�@��, ��X��������, ����ܦb���D�B tbxContMessage & tbxPubMessage ��
		//alert(oMyObject.xmldata);
		//alert("oMyObject.TotalPubSeq= " + oMyObject.TotalPubSeq);
		//alert("oMyObject.tottm= " + oMyObject.tottm);
		//alert("oMyObject.totjtm= " + oMyObject.totjtm);
		//alert("oMyObject.chgjtm= " + oMyObject.chgjtm);
		//alert("oMyObject.hiddenTotalJTime= " + oMyObject.hiddenTotalJTime);
		//alert("myObject.old_contno= " + myObject.old_contno);
		//alert("oMyObject.pubseq= " + oMyObject.pubseq);
		//alert("oMyObject.yyyymm= " + oMyObject.yyyymm);
		//alert("oMyObject.bkpno= " + oMyObject.bkpno);
		//alert("oMyObject.pgno= " + oMyObject.pgno);
		//alert("oMyObject.fgfixpage= " + oMyObject.fgfixpage);
		//alert("oMyObject.clrcd= " + oMyObject.clrcd);
		//alert("oMyObject.pgscd= " + oMyObject.pgscd);
		//alert("oMyObject.ltpcd= " + oMyObject.ltpcd);
		//alert("tbxPubMessage= " + window.document.all("tbxPubMessage").value);
		//alert("tbxContMessage= " + window.document.all("tbxContMessage").value);
		
		// �Ǹ�
		var tempPubMessage = "�����Ǹ�: " + oMyObject.pubseq;
		
		// �Z�n�~��
		if(oMyObject.yyyymm!="")
			tempPubMessage = tempPubMessage + ", �Z�n�~��: " + oMyObject.yyyymm;
		else
			tempPubMessage = tempPubMessage;
		
		// ���y���O
		if(oMyObject.bkpno!="")
			tempPubMessage = tempPubMessage + ", ���y���O: " + oMyObject.bkpno;
		else
			tempPubMessage = tempPubMessage;

		// �Z�n���X
		if(oMyObject.pgno!="")
				tempPubMessage = tempPubMessage + ", �Z�n���X: " + oMyObject.pgno;
		else
			tempPubMessage = tempPubMessage;
		
		// �T�w�������O
		if(oMyObject.fgfixpage!="")  {
			if(oMyObject.fgfixpage==0)
				tempPubMessage = tempPubMessage;
			else if(oMyObject.fgfixpage==1)
				tempPubMessage = tempPubMessage + " (���w�T�w����)";
		}
		else
			tempPubMessage = tempPubMessage;
		
		// �s�i��m�N�X
		if(oMyObject.clrcd!="")
		{
			var clrcd = parseInt(oMyObject.clrcd);
			var clrtext = "";
			
			// �N���ର��r
			switch(clrcd)
			{
				case 1:
						clrtext = "�m��";
						break;
				case 2:
						clrtext = "�¥�";
						break;
				case 3:
						clrtext = "�M��";
						break;
				default:
						clrtext = "�m��";
						break;
			}
			tempPubMessage = tempPubMessage + ", " + clrtext;
		}
		else
			tempPubMessage = tempPubMessage;
		
		// �s�i�g�T�N�X
		if(oMyObject.pgscd!="")
		{
			var pgscd = parseInt(oMyObject.pgscd);
			var pgstext = "";
			
			// �N���ର��r
			switch(pgscd)
			{
				case 1:
						pgstext = "����";
						break;
				case 2:
						pgstext = "�b��";
						break;
				default:
						pgstext = "����";
						break;
			}
			tempPubMessage = tempPubMessage + ", " + pgstext;
		}
		else
			tempPubMessage = tempPubMessage;
		
		// �s�i�����N�X
		if(oMyObject.ltpcd!="")
		{
			var ltpcd = parseInt(oMyObject.ltpcd);
			var ltptext = "";
			
			// �N���ର��r
			switch(ltpcd)
			{
				case 1:
						ltptext = "�ʭ�";
						break;
				case 2:
						ltptext = "�ʭ��̭�";
						break;
				case 3:
						ltptext = "�ʩ�";
						break;
				case 4:
						ltptext = "�ʩ��̭�";
						break;
				case 5:
						ltptext = "����";
						break;
				case 6:
						ltptext = "����";
						break;
				default:
						ltptext = "����";
						break;
			}
			tempPubMessage = tempPubMessage + ", " + ltptext;
		}
		else
			tempPubMessage = tempPubMessage;
		
		
		var tempContMessage = "";
		// �`�Z�n����
		if(oMyObject.tottm!="")
			tempContMessage = tempContMessage + "�X���� - �`�Z�n����: " + oMyObject.tottm;
		else
			tempContMessage = tempContMessage;
		
		// �`�s�Z����
		if(oMyObject.totjtm!="")
			tempContMessage = tempContMessage + ", �`�s�Z����: " + oMyObject.totjtm;
		else
			tempContMessage = tempContMessage;
		
		// ���Z����
		if(oMyObject.chgjtm!="")
			tempContMessage = tempContMessage + ", ���Z����: " + oMyObject.chgjtm;
		else
			tempContMessage = tempContMessage;
		
		// �N�j�M����T, ��X�� tbxPubMessage
		window.document.all("tbxContMessage").value = tempContMessage;
		window.document.all("tbxPubMessage").value = tempPubMessage;
		
		
		// �а� �s�W�����^�e���� table (id=table2  dataSrc=#DSO2)
		var xmlDoc2 = DSO2.XMLDocument;
		xmlDoc2.async = false;
		//alert(oMyObject.value.xml);
		xmlDoc2.loadXML(oMyObject.xmldata);
		
		var xmlPubDetails = xmlDoc2.selectSingleNode("�����Ӹ`");
		//alert(xmlPubDetails.xml);
		
			// ** �H�U coding �P OnChangeddlDraftTypeCode(obj) �p�P **
			// �`�N: �U�@��줧��, �O�� xml �Ө�, �ëD�� window.document.all("ddlDraftTypeCode").value �Ө�, �����P OnChangeddlDraftTypeCode(obj) ���P�B
			var ddlDraftTypeCodeResult = parseInt(xmlPubDetails.selectSingleNode("�Z�����O�N�X").text);
			//alert("ddlDraftTypeCodeResult= "  + ddlDraftTypeCodeResult);
			
			switch(ddlDraftTypeCodeResult)
			{
			// 1. ���½Z��, �M�� "��Z������� & �s�Z�������"
			case 1: {
					window.document.all("ddlDraftTypeCode").value = '1';
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// ������L�ݩ�
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("��Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("��Z���O").text='';
					xmlPubDetails.selectSingleNode("��Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���X�����O").text='';
					xmlPubDetails.selectSingleNode("�s�Z�s�k�N�X").text='';
					break;  }
			
			// 2. ���s�Z��, �M�� "��Z������� & �½Z�������"
			case 2: {
					window.document.all("ddlDraftTypeCode").value = '2';
					// ������L�ݩ�
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					window.document.all("ddlChgBookCode").value = '';
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlNJTypeCode").disabled = false;
					// �M����L�ݩʤ� xml ���
					xmlPubDetails.selectSingleNode("�½Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("�½Z���O").text='';
					xmlPubDetails.selectSingleNode("�½Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("��Z���O").text='';
					xmlPubDetails.selectSingleNode("��Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���X�����O").text='';
					break;  }
			
			// 3. ����Z��, �M�� "�s�Z������� & �½Z�������"
			case 3: {
					window.document.all("ddlDraftTypeCode").value = '3';
					// ������L�ݩ�
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlChgBookCode").disabled = false;
					window.document.all("tbxChangeJNo").readOnly = false;
					window.document.all("tbxChgPageNo").readOnly = false;
					window.document.all("tbxfgReChange").readOnly = false;
					window.document.all("tbxfgReChange").value = '0';
					// ������L�ݩ�
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					// �M����L�ݩʤ� xml ���
					xmlPubDetails.selectSingleNode("�½Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("�½Z���O").text='';
					xmlPubDetails.selectSingleNode("�½Z���X").text='';
					xmlPubDetails.selectSingleNode("�s�Z�s�k�N�X").text='';
					break;  }			
			
			}		
		// -->
		</SCRIPT>
		<SCRIPT language="javascript">
		<!-- 
		//�ˬd��J���U���O����, �O�_���� 0 �� 1
		
		//�ˬd��J�� "�w�}�ߵo������O" ���ȬO�_���T
		function CheckValue2(obj){ 
			if(window.document.all("tbxfgInvCode").value==0)
				window.document.all("tbxfgInvCode").value=0;
			else if(window.document.all("tbxfgInvCode").value==1)
				window.document.all("tbxfgInvCode").value=1;
			else {
				alert("�z��J �w�}�ߵo������O���� �O���~��, �Э��s��J");
				window.document.all("tbxfgInvCode").focus(); }

		}
		
		//�ˬd��J�� "�o���}�߳�H�u�B�z���O" ���ȬO�_���T
		function CheckValue3(obj){ 
			if(window.document.all("tbxfgInvSelf").value==0)
				window.document.all("tbxfgInvSelf").value=0;
			else if(window.document.all("tbxfgInvSelf").value==1)
				window.document.all("tbxfgInvSelf").value=1;
			else {
				alert("�z��J �o���}�߳�H�u�B�z���O���� �O���~��, �Э��s��J");
				window.document.all("tbxfgInvSelf").focus(); }

		}

		//�ˬd��J�� "��Z���X�����O" ���ȬO�_���T
		function CheckValue4(obj){ 
			if(window.document.all("tbxfgReChange").value==0)
				window.document.all("tbxfgReChange").value=0;
			else if(window.document.all("tbxfgReChange").value==1)
				window.document.all("tbxfgReChange").value=1;
			else {
				alert("�z��J ��Z���X�����O���� �O���~��, �Э��s��J");
				window.document.all("tbxfgReChange").focus(); }
		}
		
		//�� "�s�Z�s�k�N�X"��, �M�� "��Z���X�����O" ����
		function CheckValue5(obj){ 
				window.document.all("tbxfgReChange").value='';
		}
		//-->
		</SCRIPT>
		<SCRIPT language="javascript">
		<!-- 
			// �̤��P�Z�����O����, �h�M�����P�ﶵ�e���W���ȻP��XML��ڭ�
			// (�p�Y�D�s�Z, �h�@�w�n�M���s�Z�s�k�N�X���ȤΨ䥦������=>���ŭ�)
			// �D�n�O�B�z�e���W�Ȫ���ܤΨ�Ȫ����T��
		function OnChangeddlDraftTypeCode(obj){
			var ddlDraftTypeCodeResult = window.document.all("ddlDraftTypeCode").value;
			//alert("ddlDraftTypeCodeResult= "  + ddlDraftTypeCodeResult);
			
			// ��X �X���ѲӸ`�� '�`�s�Z����' & '���Z����', �Ѿl�`�s�Z���� Resttottm
			var totjtm = parseInt(oMyObject.totjtm);
			var chgjtm = parseInt(oMyObject.chgjtm);
			// ��X�ثe �Ѿl���`�s�Z���� oMyObject.hiddenTotalJTime
			var hiddenTotalJTime = parseInt(oMyObject.hiddenTotalJTime);
			
			// 1. ���½Z��, �M�� "��Z������� & �s�Z�������"
			if(ddlDraftTypeCodeResult==1) {
					window.document.all("ddlDraftTypeCode").value = '1';
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// ������L�ݩ�
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("��Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("��Z���O").text='';
					xmlPubDetails.selectSingleNode("��Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���X�����O").text='';
					xmlPubDetails.selectSingleNode("�s�Z�s�k�N�X").text='';
				}
			
			// 2. ���s�Z��, �M�� "��Z������� & �½Z�������"
			else if(ddlDraftTypeCodeResult==2) {
					var RestTime = hiddenTotalJTime -1;
					if(RestTime>=0)
						alert("�z��� �s�Z!\n\n '�`�s�Z����' �ٳ� " + RestTime + " ���i��, \n '���Z����' �ٳ� " + RestTime + " ���i��!");
					else  {
						alert("�s�Z���Ƥw�Χ�, �нT�{�O�_���Z!");
						window.document.all("ddlDraftTypeCode").value = '1';
						//return;
					}
					
					window.document.all("ddlDraftTypeCode").value = '2';
					// ������L�ݩ�
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					window.document.all("ddlChgBookCode").value = '';
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlNJTypeCode").disabled = false;
					// �M����L�ݩʤ� xml ���
					xmlPubDetails.selectSingleNode("�½Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("�½Z���O").text='';
					xmlPubDetails.selectSingleNode("�½Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("��Z���O").text='';
					xmlPubDetails.selectSingleNode("��Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���X�����O").text='';
				}
			
			// 3. ����Z��, �M�� "�s�Z������� & �½Z�������"
			else if (ddlDraftTypeCodeResult==3) {
					var RestTime = hiddenTotalJTime -1;
					if(RestTime>=0)
						alert("�z��� ��Z!\n\n '�`�s�Z����' �ٳ� " + RestTime + " ���i��, \n '���Z����' �ٳ� " + RestTime + " ���i��!");
					else  {
						alert("��Z���Ƥw�Χ�, �нT�{�O�_���Z!");
						window.document.all("ddlDraftTypeCode").value = '1';
						//return;
					}
					
					window.document.all("ddlDraftTypeCode").value = '3';
					// ������L�ݩ�
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlChgBookCode").disabled = false;
					window.document.all("tbxChangeJNo").readOnly = false;
					window.document.all("tbxChgPageNo").readOnly = false;
					window.document.all("tbxfgReChange").readOnly = false;
					window.document.all("tbxfgReChange").value = '0';
					// ������L�ݩ�
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					// �M����L�ݩʤ� xml ���
					xmlPubDetails.selectSingleNode("�½Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("�½Z���O").text='';
					xmlPubDetails.selectSingleNode("�½Z���X").text='';
					xmlPubDetails.selectSingleNode("�s�Z�s�k�N�X").text='';
				}
			
			// �N �Ѿl���`�s�Z���� �^�g�� oMyObject.hiddenTotalJTime, �H�Ǧ^�e�@��(���A���g�^�ܸӭ��� hiddenTotalJTime.Value)
			oMyObject.hiddenTotalJTime = RestTime;
						
		}
		//-->
		</SCRIPT>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="�½Z���X�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O, �A��X��Z�n���X
		// ���q�P�U�q�P, �u�O window.showModalDialog �̪���ܦ�m & vreturn �� xml ���P�Ӥw
		function doGetPgNo1(obj)
		{
			// �ǤJ �t�Ӳνs & �½Z���O, �ӰѦҦC�X�Ӽt�� ���Z�n(�üg�^)���Ҧ��������
			// ������J �½Z���O / ��Z���O ��, �۰ʰʥX �½Z���X / ��Z���X �d�ߵ��G
			var mfrno = oMyObject.mfrno;
			var bkpno = document.all("tbxOrigJNo").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, oMyObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:10px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				//document.all("tbxOrigJNo").value = oMyObject.bkpno;
				//xmlPubDetails.selectSingleNode("�½Z���O").text = oMyObject.bkpno;
				xmlPubDetails.selectSingleNode("�½Z���X").text = oMyObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="��Z���X�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O, �A��X��Z�n���X
		// ���q�P�W�q�P, �u�O window.showModalDialog �̪���ܦ�m & vreturn �� xml ���P�Ӥw
		function doGetPgNo2(obj)
		{
			// �ǤJ �t�Ӳνs & �½Z���O, �ӰѦҦC�X�Ӽt�� ���Z�n(�üg�^)���Ҧ��������
			// ������J �½Z���O / ��Z���O ��, �۰ʰʥX �½Z���X / ��Z���X �d�ߵ��G
			var mfrno = oMyObject.mfrno;
			var bkpno = document.all("tbxChangeJNo").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, oMyObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:170px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				//document.all("tbxChangeJNo").value = oMyObject.bkpno;
				//xmlPubDetails.selectSingleNode("��Z���O").text = oMyObject.bkpno;
				xmlPubDetails.selectSingleNode("��Z���X").text = oMyObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
		<SCRIPT language="javascript">
		<!-- 
		//�s�W�����^�e�������s
		function EditPubOk(obj)  {
			// �z�L textarea ���ˬd��X�� XML �O�_���T
			//window.document.all("textarea1").value=xmlPubDetails.xml;
			
			// �P�_ PageLoad ��, �Z�����O�������O, ����ܨ�L���O����� (�Y�M���D�������)
			// ** �H�U coding �P OnChangeddlDraftTypeCode(obj) �p�P **
			// �`�N: �U�@��줧��, �O�� xml �Ө�, �ëD�� window.document.all("ddlDraftTypeCode").value �Ө�, �����P OnChangeddlDraftTypeCode(obj) ���P�B
			var ddlDraftTypeCodeResult = parseInt(xmlPubDetails.selectSingleNode("�Z�����O�N�X").text);
			//alert("ddlDraftTypeCodeResult= "  + ddlDraftTypeCodeResult);
			
			switch(ddlDraftTypeCodeResult)
			{
			// 1. ���½Z��, �M�� "��Z������� & �s�Z�������"
			case 1: {
					window.document.all("ddlDraftTypeCode").value = '1';
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// ������L�ݩ�
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("��Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("��Z���O").text='';
					xmlPubDetails.selectSingleNode("��Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���X�����O").text='';
					xmlPubDetails.selectSingleNode("�s�Z�s�k�N�X").text='';
					break;  }

			// 2. ���s�Z��, �M�� "��Z������� & �½Z�������"
			case 2: {
					window.document.all("ddlDraftTypeCode").value = '2';
					// ������L�ݩ�
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					window.document.all("ddlChgBookCode").value = '';
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlNJTypeCode").disabled = false;
					// �M����L�ݩʤ� xml ���
					xmlPubDetails.selectSingleNode("�½Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("�½Z���O").text='';
					xmlPubDetails.selectSingleNode("�½Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("��Z���O").text='';
					xmlPubDetails.selectSingleNode("��Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���X�����O").text='';
					break;  }
						
			// 3. ����Z��, �M�� "�s�Z������� & �½Z�������"
			case 3: {
					window.document.all("ddlDraftTypeCode").value = '3';
					// ������L�ݩ�
					window.document.all("ddlOrigBookCode").disabled = true;
					window.document.all("tbxOrigJNo").value = '';
					window.document.all("tbxOrigJNo").readOnly = true;
					window.document.all("tbxOrigPageNo").value = '';
					window.document.all("tbxOrigPageNo").readOnly = true;
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlChgBookCode").disabled = false;
					window.document.all("tbxChangeJNo").readOnly = false;
					window.document.all("tbxChgPageNo").readOnly = false;
					window.document.all("tbxfgReChange").readOnly = false;
					window.document.all("tbxfgReChange").value = '0';
					// ������L�ݩ�
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					// �M����L�ݩʤ� xml ���
					xmlPubDetails.selectSingleNode("�½Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("�½Z���O").text='';
					xmlPubDetails.selectSingleNode("�½Z���X").text='';
					xmlPubDetails.selectSingleNode("�s�Z�s�k�N�X").text='';
					break;  }
			
			// �w�]��: �½Z
			default: {
					window.document.all("ddlDraftTypeCode").value = '1';
					// ���s�}�ҸӽZ���ݩ�
					window.document.all("ddlOrigBookCode").disabled = false;
					window.document.all("tbxOrigJNo").readOnly = false;
					window.document.all("tbxOrigPageNo").readOnly = false;
					// ������L�ݩ�
					window.document.all("ddlChgBookCode").disabled = true;
					window.document.all("tbxChangeJNo").value = '';
					window.document.all("tbxChangeJNo").readOnly = true;
					window.document.all("tbxChgPageNo").value = '';
					window.document.all("tbxChgPageNo").readOnly = true;
					window.document.all("tbxfgReChange").value = '';
					window.document.all("tbxfgReChange").readOnly = true;
					window.document.all("ddlNJTypeCode").value = '';
					window.document.all("ddlNJTypeCode").disabled = true;
					xmlPubDetails.selectSingleNode("��Z���y�N�X").text='';
					xmlPubDetails.selectSingleNode("��Z���O").text='';
					xmlPubDetails.selectSingleNode("��Z���X").text='';
					xmlPubDetails.selectSingleNode("��Z���X�����O").text='';
					xmlPubDetails.selectSingleNode("�s�Z�s�k�N�X").text='';
					break;  }
			}
			
			
			
			// �Ǧ^ XML �Ȩ���������
			oMyObject.result = xmlPubDetails;
			//alert("oMyObject.result= " + oMyObject.result.xml);
			window.returnValue = true; 
			window.close(); 
		}
		//-->
		</SCRIPT>
	</body>
</HTML>
