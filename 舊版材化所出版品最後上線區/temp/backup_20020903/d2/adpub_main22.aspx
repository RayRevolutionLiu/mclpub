<%@ Page language="c#" Codebehind="adpub_main22.aspx.cs" Src="adpub_main22.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main22" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�i������ƺ��@ - �Ѧ~�븨���i�J �B�J�G</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO0, DSO1, DSOX -->
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<!-- �ثe�Ҧb��m -->
		<CENTER>
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�i������ƪ����@: �Ѧ~�븨���i�J&nbsp;�B�J�G</font>
					</td>
				</tr>
			</table>
			&nbsp;
			<DIV align="center">
			</DIV>
			<DIV align="center">
				&nbsp;
			</DIV>
			<DIV align="center">
				<asp:Label id="lblContMessage" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:Label>
			</DIV>
			<br>
			<!-- Run at Server Form -->
			<form id="adpub_main22" method="post" runat="server">
				<TABLE dataFld="�X���Ѹ����Z�n���" id="xmlAdpubData" style="WIDTH: 98%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="�������Ӫ�" id="Table2" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 100%" colSpan="11">
											<FONT color="#ffffff">(10~12) �X���Ѹ����Z�n���</FONT>&nbsp; <FONT color="yellow" size="2">(�Y�����Ĥ@���� 
												'�Z�n�~��' ����, �N�����s�W�����ɪ��B�z, �z�i�y��s�W/���@��.)</FONT>
										</TD>
									</TR>
									<TR align="middle" borderColor="#bfcff0" bgColor="#bfcff0">
										<TD noWrap align="middle">
											�\��
										</TD>
										<TD>
											�Ǹ�
										</TD>
										<TD>
											<FONT color="red">* </FONT>�Z�n�~��
											<br>
											(�褸6�X, <FONT face="�s�ө���" color="#c00000">�p 200203</FONT>)
											<br>
											/ <FONT color="red">* </FONT>���y���O <IMG class="ico" title="���y���O�ѦҸ��" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
										</TD>
										<TD>
											�Z�n
											<br>
											���X
										</TD>
										<TD>
											�T�w
											<br>
											����
											<br>
											���O
											<br>
											<FONT face="�s�ө���" color="#c00000">(0: �_, 1:�O)</FONT>
										</TD>
										<TD>
											�s�i��m
										</TD>
										<TD>
											�s�i�g�T
											<br>
											<FONT face="�s�ө���" color="#c00000">(�P���
												<br>
												=>�b��)</FONT>
										</TD>
										<TD>
											�s�i����
										</TD>
										<TD>
											��Z
											<br>
											���O
											<br>
											<FONT face="�s�ө���" color="#c00000">(0: �_, 1:�O)</FONT>
										</TD>
										<TD>
											�o��
											<br>
											����H
										</TD>
										<TD>
											����
											<br>
											�Ӹ`
										</TD>
									</TR>
								</THEAD>
								<TR align="middle" borderColor="#bfcff0" bgColor="#e2eafc">
									<TD>
										<IMG class="ico" title="�s�W���" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" src="../images/new.gif" width="16" border="0"><FONT face="�s�ө���">&nbsp;</FONT><IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
									</TD>
									<TD>
										<INPUT dataFld="�Ǹ�" id="tbxPubSeq" readOnly type="text" maxLength="2" size="2" value="1" name="tbxPubSeq">
									</TD>
									<TD>
										<FONT color="red">* </FONT><INPUT dataFld="�Z�n�~��" id="tbxPubDate" onblur="Javascript:CheckPubDate(this);" type="text" maxLength="6" onchange="Javascript:CheckPubDate2(this);" size="6" name="tbxPubDate">
										/ <FONT color="red">* </FONT><INPUT dataFld="���y���O" id="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);" type="text" maxLength="4" size="3" name="tbxBkpPno">
										<IMG class="ico" title="���y���O�ѦҸ��" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
									</TD>
									<TD>
										<INPUT dataFld="�Z�n���X" id="tbxPageNo" type="text" maxLength="3" size="3" name="tbxPageNo">
									</TD>
									<TD>
										<INPUT dataFld="�T�w�������O" id="tbxfgFixPage" onblur="Javascript:CheckfgFixPage(this);" type="text" maxLength="1" size="3" name="tbxfgFixPage">
									</TD>
									<TD>
										&nbsp;<SELECT dataFld="�s�i��m�N�X" id="ddlColorCode" name="ddlColorCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="�s�i�g�T�N�X" id="ddlPageSizeCode" name="ddlPageSizeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="�s�i�����N�X" id="ddlLTypeCode" name="ddlLTypeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<INPUT dataFld="��Z���O" id="" onblur="Javascript:CheckfgGot(this);" type="text" maxLength="1" size="1" value="0" name="tbxfgGot">
									</TD>
									<TD>
										<IMG class="ico" title="�o���t�Ӧ���H�ԲӸ��" onclick="doSelectIMRec(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenIMDetail" type="hidden" size="1" name="hiddenIMDetail" runat="server">
										<LABEL id="lblSingleIMRec" style="COLOR: maroon"></LABEL>
									</TD>
									<TD>
										<IMG class="ico" title="�����Ӹ`" onclick="doEditPub(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenPubDetail" type="hidden" size="1" name="hiddenPubDetail" runat="server">
									</TD>
								</TR>
							</TABLE>
							<FONT face="�s�ө���">��: <font color="#cc0099">�Ʀr�Хܳ���</font>��ܹ�M���ѭ��Z����r����, �H��K��J���q�l���.</FONT>&nbsp;
							<br>
							<FONT face="�s�ө���">��: �Y�Y���e���� <FONT color="red">* </FONT>�Ÿ�, ��ܸ���O������, ���i�ť�!</FONT>
							<br>
							<!-- hiddenXML �� -->
							<INPUT dataFld="�t�Ӳνs" id="hiddenMfrNo" type="hidden" size="10" name="hiddenMfrNo" runat="server">&nbsp;
							<INPUT dataFld="�Ȥ�s��" id="hiddenCustNo" type="hidden" size="6" name="hiddenCustNo" runat="server">&nbsp;
							<INPUT dataFld="�̫�ק���" id="hiddenModDate" type="hidden" size="8" name="hiddenModDate" runat="server">&nbsp;
							<INPUT dataFld="�X���ѽs��" id="hiddenContNo" type="hidden" size="6" name="hiddenContNo" runat="server">&nbsp;
							<INPUT dataFld="�¦X���s��" id="hiddenOldContNo" type="hidden" size="6" name="hiddenOldContNo" runat="server">&nbsp;
							<INPUT dataFld="�X�����O�N�X" id="hiddenContType" type="hidden" size="2" name="hiddenContType" runat="server">&nbsp;
							<INPUT dataFld="���y���O�N�X" id="hiddenBkcd" type="hidden" size="2" name="hiddenBkcd" runat="server">&nbsp;
							<INPUT dataFld="�ӿ�~�ȭ��u��" id="hiddenEmpNo" type="hidden" size="7" name="hiddenEmpNo" runat="server">&nbsp;
							<INPUT id="hiddenLoginEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenLoginEmpNo" runat="server">&nbsp;
							<INPUT id="hiddenModEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenModEmpNo" runat="server">&nbsp;
							<INPUT dataFld="�`�s�Z����" id="hiddenTotalJTime" type="hidden" maxLength="3" size="3" name="hiddenTotalJTime" runat="server">&nbsp;
							<INPUT dataFld="�w�s�Z����" id="hiddenMadeJTime" type="hidden" maxLength="3" size="3" name="hiddenMadeJTime" runat="server">&nbsp;
							<INPUT dataFld="�`�Z�n����" id="hiddenTotalTime" type="hidden" maxLength="3" size="3" name="hiddenTotalTime" runat="server">&nbsp;
							<INPUT dataFld="�w�Z�n����" id="hiddenPubTime" type="hidden" maxLength="3" size="3" name="hiddenPubTime" runat="server">&nbsp;
							<INPUT dataFld="���Z����" id="hiddenChangeTime" type="hidden" maxLength="3" size="3" name="hiddenChangeTime" runat="server">&nbsp;
							<INPUT dataFld="�o������H�m�W" id="hiddenInvRec" type="hidden" size="6" name="hiddenInvRec" runat="server">&nbsp;
							<INPUT dataFld="���x����H�m�W" id="hiddenMazRec" type="hidden" size="6" name="hiddenMazRec" runat="server">&nbsp;
							<INPUT dataFld="�������Ӫ�" id="hiddenAdPub" type="hidden" size="6" name="hiddenAdPub" runat="server">&nbsp;
							<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">&nbsp;
						</TD>
					</TR>
				</TABLE>
				<!-- Form���s -->
				<DIV align="center">
					<input id="btnSave" onclick="doSubmit()" type="button" value="�x�s�ק�" name="btnSave">&nbsp;&nbsp;
					<input id="btnCancel" onclick='javascritp:window.location.href="adpub_main21.aspx"' type="button" value="�����^�W��" name="btnCancel">
				</DIV>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</CENTER>
		<!-- �� TEXTAREA �O���ˬd XML ��X�ˬd�� -->
		<!--TEXTAREA id="textarea1" name="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// ���q�ϥ� xmlDoc1 ���N xmlDoc0 (���P�� cont_new3.aspx)
		
		
		// ���w�q Object: DSO1, �]�w async = false
		DSO1.XMLDocument.async = false; 
		
		// �w�q xmlDoc1: ���v�� XML ���
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.loadXML(document.all("hiddenXML").value);
		//alert(xmlDoc1.xml);
		
		
		// �w�q xmlDoc1 �̪��U XML�`�I���W�٤Ψ䤺�e
		var xmlMain = xmlDoc1.selectSingleNode("/root");
		var xmlHeader = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e");
		
		var xmlMfrData = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�t�Ӹ��");
		var xmlCustData = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�Ȥ���");
		var xmlContBasicData = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�X���Ѱ򥻸��");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�H�o������H���");
		var xmlContDetail = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�X���ѲӸ`");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/�o���t�Ӹ��");
		var xmlMazRec = xmlDoc1.selectSingleNode("/root/���x����H���");
		//alert(xmlMazRec.xml);
		var xmlAdContactor = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�s�i�p���H���");
		var xmlAdpubData = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���");
		var xmlAdpubItems = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
		var xmlAdpubItemInvRec = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
		var xmlAdpubItemDetails = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
		// �� windows.alert �覡����ܥX xmlAdpubItems �����e (�Υi�אּ��L�ܼƦW��), �����ˬd��
		//alert("�X���Ѥ��e= " + xmlHeader.xml);
		//alert("xmlAdpubData= " + xmlAdpubData.xml);
		//document.all("textarea1").value=xmlMain.xml;
		
		
		// �w�q xmlDocX, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSOX.XMLDocument;
		xmlEmptyAdpubData.load("�ťո����Z�n���.xml");
		
		
		// ��X��������@�o������H�m�W
		var idx=xmlAdpubData.childNodes.length;
		var Items = xmlAdpubData.xml;
		strbuf="";
		for(i=0; i<idx; i++){
			Items=xmlAdpubData.childNodes.item(i).selectSingleNode("�o���t�Ӧ���H�Ӹ`");
			//alert("Items(" + i + ")= " + Items.xml);
			//alert("Items.�o������H�m�W(" + i + ")= " + Items.childNodes.item(0).selectSingleNode("�o������H�m�W").text);
			//alert("strbuf= " + strbuf);
			strbuf=Items.childNodes.item(0).selectSingleNode("�o������H�m�W").text;	//<�o������H�m�W>���ĤG��
			// ��o�X�����G�g�^��s�W�e���� 
			document.all("lblSingleIMRec").innerText = strbuf;
		}
		//event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
		
		-->
		</script>
		<script language="javascript">
		<!--
		// �X���Ѹ����Z�n��ƪ��\����s: doAddNew, doDelete
			// �s�W������ƶ�
			function doAddNew(obj)
			{
				var idx = xmlAdpubData.childNodes.length;
				//alert("idx= " + idx);
				
				// ��� NodeList �䤺�e: �G��@�覡
				//alert(xmlAdpubData.childNodes.item(0).xml);

				//var xx = "";
				//for(var i=0; i<idx; i++)
				//{
					 //xx+= xmlAdpubData.childNodes.item(i).xml;
				//}
				//alert("xmlAdpubData ="+xx);
				
				
				// index �� 0 �}�l, �ҥH item(0); ����ܥX��Ǹ��ΥZ�n���
				//var newNode = xmlAdpubData.childNodes.item(idx-1).cloneNode(true);
				var newNode = xmlEmptyAdpubData.documentElement.cloneNode(true);
				//alert("newNode= " + newNode.xml)
				
				// �Y�ϥΤU�@�� (��ܥ��b�s�W�@��e, ���N�Ǹ��[�@); �h���ΨϥΤU���ĤG��; ���G�氵���ƬO�@�˪�, �ФG��@
				//newNode.selectSingleNode("�Ǹ�").text = idx + 1;
				xmlAdpubData.appendChild(newNode);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text = idx + 1;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ǹ�").text = idx + 1;
				
				// ���B����J�ĤG��������ƪ��w�]��, �Ĥ@�����w�]�ȼg�b Submit() ��
				// ���w cloneNode �̪��w�]��
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ȥ�s��").text=window.document.all("hiddenCustNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�X���ѽs��").text=window.document.all("hiddenContNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�X�����O�N�X").text=window.document.all("hiddenContType").value;
				
				// -- ���B�P cont_new3.aspx & cont_main3.aspx ���P --
				// ���ۮ��y���O�N�X��X "�p���N��, ��������"
				var BookCode = window.document.all("hiddenBkcd").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O�N�X").text=BookCode;
				
				// �N �����̫�ק��� Reformat �h�� "/", �H�K�s�W�J c2_pub �� (�]�ϥ� sp_c2_cont_newSave_pub ����, �����b�s�W�e���T�{��ƥ��T) , �L�k�h���� "/", �ӳy����Ʀ��~
				var ModDate = window.document.all("hiddenModDate").value;
				ModDate = ModDate.substring(0, 4) + ModDate.substring(5, 7) + ModDate.substring(8, 10);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�����̫�ק���").text=ModDate;
				// �U�@�� coding �P cont_show.aspx ���P (�P cont_new3.aspx)
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�����ק�~�ȭ��u��").text=window.document.all("hiddenEmpNo").value;
				
				//xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ӹ`").text=xmlAdpubData.childNodes.item(idx-1).selectSingleNode("�����Ӹ`").text;
				
				// �ˬd�C�@�檺�X�{���Ǹ��ȬO�_���T
				//alert("idx= " + idx);
				//alert("�Ǹ�= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text);
				//alert("�����Ǹ�= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ǹ�").text);
				
				//alert(xmlAdpubData.xml);
				
			}

			// �R��������ƶ�
			function doDelete(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				//alert("idx= " + idx);
				var oldNode = xmlAdpubData.childNodes.item(idx);
				//alert("oldNode= " + oldNode);
								
				if(xmlAdpubData.childNodes.length > 1)
				{
					oldNode.parentNode.removeChild(oldNode);
					// �R�� �Ǹ�
					for(i=0; i<xmlAdpubData.childNodes.length;i++)
					{
						xmlAdpubData.childNodes.item(i).selectSingleNode("�Ǹ�").text=i+1;
						xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ǹ�").text=i+1;
					}
				}
				
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// cal���s�� coding: ��t�Τ��
		function pick_date(theField)
		{
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			window.document.all(theField).value=vreturn;
			return true;
			
			// �U�q���� run, �] doSubmit() �w�g�J xmlContBasicData.selectSingleNode("ñ�����").text ���
			//if(vreturn)
				//xmlContBasicData.selectSingleNode("ñ�����").text=vreturn;
			//return true;
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//�ˬd������J�� "�Z�n�~��" ���ȬO�_���T
		function CheckPubDate(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// �P�_�Z�n�~�몺���׬O�_�� 6�X
			var yyyymm = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			if(yyyymm.length!=6)
			{
				alert("������ " + (idx+1) + " �� '�Z�n�~��' �����ץ����� 6�X(�褸), �Эץ�!");
				return;
			}
			// �Y�Z�n�~�몺���׬� 6�X (�X�z)
			else
			{
				// �ˬd�O�_��J�� �Ʀr���A
				if(isNaN(yyyymm)==true)
					alert("������ " + (idx+1) + " ���� '�Z�n�~��' ������J�Ʀr���A!");
				
				// �P�_�Z�n�~��O�_�b �X���_���� �d��
				var ContStartDate = window.document.all("tbxStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("tbxEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				//alert("ContStartDate= " + ContStartDate);
				//alert("ContEndDate= " + ContEndDate);
				if(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text<ContStartDate || xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text>ContEndDate)
				{
					alert("������ " + (idx+1) + " �� '�Z�n�~��' �����b�X���_���d��, �Эץ�!");
					return;
				}
				
				// �çP�_�褸�Z�n�~��O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
				var yyyy = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text.substring(0, 4);
				var mm = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text.substring(4, 6);

				// �P�_�褸�Z�n�~�׬O�_�X�z��
				if(yyyy<=1990 || yyyy>=2200)
				{
					alert("�`�N: ������ " + (idx+1) + " �����Z�n�~�뤧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �Ч�!");
					return;
				}
				else
					yyyymm = yyyymm;
				
				// �P�_�褸�Z�n����O�_�X�z��
				if(mm>12 || mm<=0)
				{
					alert("�`�N: ������ " + (idx+1) + " �����Z�n�~�뤧��� '" + mm + "' ���X�z, �Ч�!");
					return;
				}
				else
					yyyymm = yyyymm;			
			// ���� - �Y�Z�n�~�몺���׬� 6�X (�X�z)
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ���ܦ] '�Z�n�~��' �ܧ�, ������s '���y���O' ���� (�A���@�U)
		function CheckPubDate2(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			if(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text != "")
				alert("�z��s�F ������ " + (idx+1) + " ���� '�Z�n�~��' !\n �ЦA���@�U������ " + (idx+1) + " ���� '���y���O' �Ǫ����s�ӧ�s���!!!");
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �ˬd "���y���O" �@��O�_����J
		function CheckBookPNo(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);

			var BookPNo = xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O").text;
			// �Y���y���O�S����J
			if(BookPNo.length==0)
			{
				//alert("������ " + (idx+1) + " ���� '���y���O' ������!\n �Ы��U�k����s�ӬD��!");
				return;
			}
			else
			{
				// �ˬd�O�_��J�� �Ʀr���A
				if(isNaN(BookPNo)==true)
					alert("������ " + (idx+1) + " ���� '���y���O' ������J�Ʀr���A!");
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="���y���O�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O
		function doGetBookp(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			myObject.flag=true;
			
			//alert("xmlAdpubItems.xml= " + xmlAdpubItems.xml);
			myObject.xmldata = xmlAdpubItems.xml;
			//myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// ���w�ǹL�h���ܼ� - ��X ���y���O�N�X & �Z�n�~��, �ӧ�X ���y���O
			var bkcd = document.all("hiddenBkcd").value.substring(0, 2);
			var ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			//alert("ym= " + ym);
			myObject.bkcd = document.all("hiddenBkcd").value.substring(0, 2);
			myObject.ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ myObject
			var PageName = "bookp_get.aspx?bkcd=" + bkcd + "&ym=" + ym;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:420px;dialogWidth:350px;dialogLeft:250px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result= " + myObject.result);
			
			if(vreturn)  {
				xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O").text = myObject.result;
				// �ѨM�Y�S��J �Z�n�~���, ������ '���y���O', �ӥZ�n�~�묰�� �����p
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text = myObject.yyyymm;
				
				// �P�W����k�G - �ѨM�Y�S��J �Z�n�~���, ������ '���y���O', �ӥZ�n�~�묰�� �����p
				//if(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text=="")  {
					//var CurrentDate = new Date();
					//var Currentyyyy = CurrentDate.getFullYear();
					//var Currentmm = CurrentDate.getMonth()+1;
					//if(Currentmm.length!=2)
						//Currentmm = "0" + Currentmm;
					//var Currentym = Currentyyyy + Currentmm;
					//xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text=Currentym;
				//}
				return true;
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//�ˬd������J�� "�T�w�������O" ���ȬO�_���T
		function CheckfgFixPage(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgFixPage = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("�T�w�������O").text);
			if(fgFixPage!=1 && fgFixPage!=0)
			{
				alert("������ " + (idx+1) + " �����T�w�������O���ȿ��~, �Э��s��J!");
				return;
				//window.document.all("tbxfgFixPage").focus();
			}
			
		}
		
		//-->
		</script>
		<script language="javascript">
		<!--
		//�ˬd������J�� "��Z���O" ���ȬO�_���T
		function CheckfgGot(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgGot = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("��Z���O").text);
			//alert((idx+1) + ", fgFixPage= " + fgFixPage);
			if(fgGot!=1 && fgGot!=0)
			{
				alert("������ " + (idx+1) + " ������Z���O���ȿ��~, �Э��s��J!");
				return;
				//window.document.all("tbxfgGot").focus();
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �󸨪���ƳB�D�X��@�o���t�Ӧ���H���\����s: doSelectIMRec()	
		function doSelectIMRec(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			//alert("hiddenInvRec= " + document.all("hiddenInvRec").value);
			
			var Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("�o���t�Ӧ���H�Ӹ`");
			
			// myObject.prexmldata �O�� InvRecSet.aspx �� #DSO3 �I�s���v��ƥ�;
			// �`�N: �Y�S�������U "�D��o���t�Ӧ���H" ���s, �h���B myObject.prexmldata ����Ʒ|�O�ťժ� xmlInvRec
			if(document.all("hiddenInvRec").value=="")
				myObject.prexmldata=xmlInvRec;
			else
				myObject.prexmldata=document.all("hiddenInvRec").value;
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			
			// myObject.xmldata �O�� InvRecSet.aspx �� #DSO2 �ť�xmlInvRec��;
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("�o���t�Ӧ���H�Ӹ`").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// ��X �t�ΥN�X, �X���ѽs��; �ǵ��o���t�Ӧ���H��Ƥ��t�ΥN�X, �X���ѽs�� myObject.Syscd, myObject.ContNo
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			
			// �}�ҵ�����ܮ�
			vreturn=window.showModalDialog("InvRecSet.aspx", myObject, "dialogHeight:450px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			if(vreturn)
			{
				Items.parentNode.replaceChild(myObject.result, Items);
				Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("�o���t�Ӧ���H�Ӹ`");
				//alert("Items= " + Items.xml);
				//document.all("textarea1").value=xmlInvRec.xml;
				
				strbuf="";
				for(i=0; i<Items.childNodes.length; i++){
					strbuf+=Items.childNodes.item(i).selectSingleNode("�o������H�m�W").text;	//<�m�W>���ĤG��
				}
				//alert("strbuf= " + strbuf);
				
				// ��o�X�����G�g�^��s�W�e���� 
				event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
				//document.all("textarea1").value=Items.xml;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �Z�n�������ԲӸ�ƥ\����s: doEditPub()
		function doEditPub(obj)
		{	
			//alert("xmlAdpubItemDetails= " + xmlAdpubItemDetails.xml);		
			
			// ��渹
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// �w�q myObject �������^�ǭ�
			var myObject = new Object();
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ӹ`").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			
			// ���w�ǹL�h���ܼ�
			// �����ӵ�����(�Ǹ�)�� xml ���
			//alert(xmlAdpubData.childNodes.item(idx).xml);
			
			// �`��������, ��K��X ��Z+�s�Z���`���� �� for loop
			myObject.TotalPubSeq=xmlAdpubData.childNodes.length;
			//alert("myObject.TotalPubSeq= " + myObject.TotalPubSeq);
			//alert(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text);
			
			// �ǤJ�X���ѲӸ`����� - �`�Z�n����, �`�s�Z����, ���Z����
			myObject.tottm=window.document.all("hiddenTotalTime").value;
			myObject.totjtm=window.document.all("hiddenTotalJTime").value;
			//alert("myObject.tottm= " + myObject.tottm);
			myObject.chgjtm=window.document.all("hiddenChangeTime").value;
			// �Ѿl���`�s�Z����, ��K�p�� �`�s�Z���Ƥ��Ѿl����
			myObject.hiddenTotalJTime= document.all("hiddenTotalJTime").value;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// �ǤJ �t�ӽs�� & �t�Ӳνs, �ӰѦҦC�X�Ӽt�� ���Z�n(�üg�^)���Ҧ��������
			// ������J �½Z���O / ��Z���O ��, �۰ʰʥX �½Z���X / ��Z���X �d�ߵ��G
			myObject.contno= document.all("hiddenContNo").value;
			myObject.mfrno = document.all("hiddenMfrNo").value;
			
			// �ǤJ��L���, �H�b "�����Ӹ`��T" �U����ܨ������� (�ѨM�] showModalDialog ��������, �~��ݫe�����)
			myObject.pubseq=xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text;
			myObject.yyyymm=xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			myObject.bkpno=xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O").text;
			myObject.pgno=xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n���X").text;
			myObject.fgfixpage=xmlAdpubData.childNodes.item(idx).selectSingleNode("�T�w�������O").text;
			myObject.clrcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("�s�i��m�N�X").text;
			myObject.pgscd=xmlAdpubData.childNodes.item(idx).selectSingleNode("�s�i�g�T�N�X").text;
			myObject.ltpcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("�s�i�����N�X").text;
			
			//�w�q AdpubItemDetails ���ǹL�h���� �����Ӹ`
			var AdpubItemDetails = xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ӹ`");
			//alert("AdpubItemDetails.xml= " + AdpubItemDetails.xml);
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ myObject
			vreturn=window.showModalDialog("adpub_detail.aspx", myObject, "dialogHeight:300px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result.xml= " + myObject.result.xml);
			
			//���N�s�� AdpubItemDetails ���
			AdpubItemDetails.parentNode.replaceChild(myObject.result, AdpubItemDetails);
			AdpubItemDetails = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
			
			// ���N '�Ѿl���`�s�Z����' hiddenTotalJTime
			document.all("hiddenTotalJTime").value = myObject.hiddenTotalJTime;
			xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text=myObject.hiddenTotalJTime;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// �z�L textarea �����ˬd��X�� XML �O�_���T
			//document.all("textarea1").value=xmlAdpubItemDetails.xml;
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ����椧 "�x�s�ק�" ���s: doSubmit()
		function doSubmit()
		{
			// ���q�ϥ� xmlDoc1 ���N xmlDoc0 (���P�� cont_new3.aspx)
			
			
			// �U�q�O�P cont_new3.aspx & cont_show.aspx ���P�B
			// ��s �̫�ק���
			var ModDate = window.document.all("hiddenModDate").value;
			ModDate = ModDate.substring(0, 4) + ModDate.substring(5, 7) + ModDate.substring(8, 10);
			xmlContBasicData.selectSingleNode("�̫�ק���").text=ModDate;
			xmlAdpubItems.selectSingleNode("�����̫�ק���").text=ModDate;
			
			// �����ק�~�ȭ��u��
			//xmlAdpubItems.selectSingleNode("�����~�ȭ��u��").text=window.document.all("hiddenEmpNo").value;
			xmlAdpubItems.selectSingleNode("�����ק�~�ȭ��u��").text=window.document.all("hiddenEmpNo").value;
			
			// ��s �w�Z�n���� (�ھ� =�������`����) => ��k�@
			//xmlContDetail.selectSingleNode("�w�Z�n����").text = parseInt(idx);
			//var RestPubTime = parseInt(document.all("tbxTotalTime").value) - parseInt(idx);
			
			// ��s �w�Z�n���� & �Ѿl�Z�n����
			xmlContDetail.selectSingleNode("�w�Z�n����").text = document.all("hiddenPubTime").value;
			var RestPubTime = parseInt(document.all("hiddenTotalTime").value) - parseInt(document.all("hiddenPubTime").value);
			xmlContDetail.selectSingleNode("�Ѿl�Z�n����").text = RestPubTime;
			//document.all("tbxPubTime").value = parseInt(idx);
			//document.all("tbxRestTime").value = parseInt(document.all("tbxPubTime").value) - parseInt(idx);
			
			
			// ��s �����̫�ק���, �����~�ȭ��u��, �����ק�~�ȭ��u��, �w�s�Z����
			var idx = xmlAdpubData.childNodes.length;
			//alert("idx= " + idx);
			//alert("xmlAdpubData= " + xmlAdpubData.xml);
			var i;
			var MadeJTime = 0;
			for(i=0; i<idx; i++) 
			{
				xmlAdpubData.childNodes.item(i).selectSingleNode("�����̫�ק���").text=ModDate;
				xmlAdpubData.childNodes.item(i).selectSingleNode("�����~�ȭ��u��").text=window.document.all("hiddenEmpNo").value;
				xmlAdpubData.childNodes.item(i).selectSingleNode("�����ק�~�ȭ��u��").text=window.document.all("hiddenEmpNo").value;
				//if(xmlAdpubData.childNodes.item(i).selectSingleNode("�˫�ק���O").text == "")
					//xmlAdpubData.childNodes.item(i).selectSingleNode("�˫�ק���O").text=0;
				//else
					//xmlAdpubData.childNodes.item(i).selectSingleNode("�˫�ק���O").text = xmlAdpubData.childNodes.item(i).selectSingleNode("�˫�ק���O").text;
				
				//alert("�Z�����O�N�X= " + xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").xml);
				var drafttp = xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text;
				drafttp = parseInt(drafttp);
				//alert("�Z�����O�N�X= " + drafttp);
				switch(drafttp)
				{
					case 1:
						MadeJTime = parseInt(MadeJTime);
						break;
					case 2:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
					case 3:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
				}
				//alert("MadeJTime=" + MadeJTime);
			}
			//alert("hiddenTotalJTime=" + document.all("hiddenTotalJTime").value);
			//alert("MadeJTime=" + MadeJTime);
			//alert("�Ѿl�s�Z����=" + (parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime)));
			xmlContDetail.selectSingleNode("�w�s�Z����").text = parseInt(MadeJTime);
			
			// �Y �Ѿl�s�Z���� < 0, �h��ȫ��w�� 0
			if((parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime)) > 0)
				xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text = parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime);
			else
				xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text = 0;
			
			
			// �z�L textarea �����ˬd��X�� XML �O�_���T 
			//document.all("textarea1").value=xmlMain.xml;
			//alert(xmlDoc1.xml);
			
			
			//// ����, ���Ǧr�굹�s�ɵ{�� (cont_mainSave.aspx) �ݬݬO�_�����D
			//// �Y�L, �A�i��� xml ���
			////  �b�o��� xmlDoc1.xml ����ƶǵ��s�ɵ{��
			////var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			////xmlHTTP.Open("post", "cont_mainSave.aspx", false);
			// ��Ǧr��� cont_newSave.aspx �ݬݬO�_��o��; �Y��o��, �A�� xmlDoc1
			////xmlHTTP.Send("test");
			////document.all("textarea1").value=xmlHTTP.responseText;
			////var xmlHTTP = null;

			// �}�l�ǰe xml ��Ʀܸ�Ʈw���x�s ------------------
			// �b�o��� xmlDoc1.xml ����ƶǵ��s�ɵ{��
			var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			xmlHTTP.Open("post", "adpub_mainSave.aspx", false);
			xmlHTTP.Send(xmlDoc1);
			
			// �ˬd�ÿ�X xmlHTTP ���A�󥻭� textarea1 ��
			////alert(xmlHTTP.responseText);
			//document.all("textarea1").value=xmlHTTP.responseText;
			
			// �Y�x�s���\, �Hĵ�i�������
			if(xmlHTTP.statusText=="OK")
			{
				alert("�ק︨�����\");
				window.location.href="/mrlpub/d2/cont_SaveMessage.aspx?str=adpub_mainSave";
				//if(window.confirm("�ק令�\,�n�~��ק��L����?"))
				//{
					//if(window.document.all("hiddenContType").value=="01")
						//window.location.href="cont_main1.aspx?function1=mod&conttp=01";
					//else if(window.document.all("hiddenContType").value=="09")
						//window.location.href="cont_main1.aspx?function1=mod&conttp=09";
				//}
				//else
					//window.location.href="http://140.96.18.18/mrlpub/";
			}
			
			// �M�� xmlHTTP ��Ƭ���
			var xmlHTTP = null;
		}
		//-->
		</script>
		</FONT>
	</BODY>
</HTML>
