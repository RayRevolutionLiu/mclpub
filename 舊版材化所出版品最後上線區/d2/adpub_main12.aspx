<%@ Page language="c#" Codebehind="adpub_main12.aspx.cs" Src="adpub_main12.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main12" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i������ƺ��@ - �ѦX���Ѷi�J �B�J�G</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO0, DSO1, DSOX -->
		<OBJECT id="DSO0" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// ���w�q Object: DSO0, DSO1, DSOX; �]�w async = false
		DSO0.XMLDocument.async = false;
		DSO1.XMLDocument.async = false; 
		DSOX.XMLDocument.async = false;
		
		// �w�q xmlDoc0
		var xmlDoc0 = DSO0.XMLDocument;
		xmlDoc0.load("�ťզX����.xml");
		//alert(xmlDoc0.xml);
		
		// �w�q xmlDoc0 �̪��U XML�`�I���W�٤Ψ䤺�e
		var xmlMain = xmlDoc0.selectSingleNode("/root");
		var xmlMfrCust = xmlDoc0.selectSingleNode("/root/�t�ӤΫȤ���");
		var xmlContBasicData = xmlDoc0.selectSingleNode("/root/�X�����e");
		var xmlInvRec = xmlDoc0.selectSingleNode("/root/�H�o������H���");
		var xmlPubData = xmlDoc0.selectSingleNode("/root/�Z�n�Ӹ`");
		var xmlMazRec = xmlDoc0.selectSingleNode("/root/���x����H���");
		var xmlAdContactor = xmlDoc0.selectSingleNode("/root/�s�i�p���H���");
		
		var xmlAdpubData = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���");
		var xmlAdpubItems = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
		var xmlAdpubItemDetails = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/������h�Ӹ`");
		
		// �w�q xmlDoc1, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSO1.XMLDocument;
		xmlEmptyAdpubData.load("�ťն��ؤ@.xml");

		// �w�q xmlDocX
		var xmlDocX = DSOX.XMLDocument;
		
		// �� windows.alert �覡����ܥX xmlAdpubItems �����e, �����ˬd��
		//alert(xmlAdpubData.xml);
		
		//xmlHeader.selectSingleNode("�q��s��").text=window.document.all("hiddenId").value;
		//xmlHeader.selectSingleNode("�q�ʤ��").text=window.document.all("hiddenDate").value;
		-->
		</script>
		<script language="javascript">
		<!--
		// �X���Ѹ����Z�n��ƪ��\����s: AddNew, Delete, Copy
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
				
				
				// index �� 0 �}�l, �ҥH item(0)
				var newNode = xmlAdpubData.childNodes.item(idx-1).cloneNode(true);
				//alert("newNode= " + newNode.xml)
				// �Y�ϥΤU�@�� (��ܥ��b�s�W�@��e, ���N�Ǹ��[�@), �h���ΨϥΤU���ĤG��; ���G�氵���ƬO�@�˪�
				//newNode.selectSingleNode("�Ǹ�").text = idx + 1;
				xmlAdpubData.appendChild(newNode);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text = idx + 1;
				// �ˬd�C�@�檺�X�{���Ǹ��ȬO�_���T
				//alert("idx= " + idx);
				//alert("�Ǹ�= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text);
			}

			function doDelete(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				var oldNode = xmlItems.childNodes.item(idx);
				
				if(xmlItems.childNodes.length <= 1)
				{
					var newNode = xmlEmptyItem.documentElement.cloneNode(true);
					xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
				}
				oldNode.parentNode.removeChild(oldNode);
				doSum();
			}
			
			function doCopy(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				var newNode = xmlAdpubItems.childNodes.item(idx).cloneNode(true);
				xmlAdpubItems.insertBefore(newNode, xmlAdpubItems.childNodes.item(idx).nextSibling);
				doSum();
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ���x����H���ԲӸ�ƥ\����s: AddMazRecData()
			function AddMazRecData()
			{
				// �ϥ� showModalDialog �Ӷ}�Ӹ`������
				strFeature = "";
				strFeature += "dialogHeight:400px;dialogWidth:580px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//	oParam.type = vType;
				//	oParam.keyword = vKeyword;
				//Disable next line temperly
				//var vReturn = window.showModalDialog("or_detail.aspx", oParam, strFeature); 
				
				// ��� windows.open �Ө��N showModalDialog �Ӷ}�s����
				var vReturn = window.open("or_detail.aspx", "_new", "Width=580px, Height=340px");
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ��X�Ҧ����x����H���m�W���\����s: doGetAllMazRec()
		function doGetAllMazRec()
		{
			var myObject = new Object();
				//    myObject.id=id;
				//    myObject.type1=type;
				//    myObject.seq=seq;
				//alert(document.all("hiddenRec").value);
			
			// �Y hiddenRec �L���, �h��ܰT�� "�S�����v���~"
			// �_�h, ����� hiddenRec �̪����
			if(document.all("hiddenRec").value==""){
				myObject.flag=false;
				alert("�S�����v���, �Цۦ��J���");
			}
			else{
			    myObject.flag=true;
				myObject.prexmldata=document.all("hiddenRec").value;
			}
		 myObject.xmldata=xmlMazRec.xml;
		//alert(myObject.xmldata.xml);
		
		// �}�ҵ�����ܮ�
		vreturn=window.showModalDialog("MazRecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:780px;center:yes;scroll:yes;status:no;help:no;"); 
		
		//���N�s�� xmlMazRec ���
		xmlMazRec.parentNode.replaceChild(myObject.result, xmlMazRec);
		xmlMazRec = xmlDoc0.selectSingleNode("/root/���x����H���");
		//�۫e��, �p��X�X����� xmlMazRec.childNodes.length
		//alert("xmlMazRec.childNodes.length = " + xmlMazRec.childNodes.length);

		// ��X�D��X���Ҧ����x����H�m�W, �åH "," �Ÿ��j�}
		strbuf="";
		for(i=0; i<xmlMazRec.childNodes.length; i++){
			strbuf+=xmlMazRec.childNodes.item(i).selectSingleNode("���x����H�m�W").text+",";	//<�m�W>���ĤG��
		}
		document.all("lblRec").innerText=strbuf;
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �Z�n�������ԲӸ�ƥ\����s: doPubDetail()
			function doPubDetail()
			{
				// �ϥ� showModalDialog �Ӷ}�Ӹ`������
				strFeature = "";
				strFeature += "dialogHeight:480px;dialogWidth:450px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//Disable next line temperly
				//var vReturn = window.showModalDialog("pubim_detail.aspx", oParam, strFeature); 
				
				// ��� windows.open �Ө��N showModalDialog �Ӷ}�s����
				var vReturn = window.open("adpub_detail.aspx", "_blank", "Width=600px, Height=480px, top=20px, left=50px, Toolbar=no"); 
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// cal���s�� coding: ��t�Τ��
		function pick_date(theField)
			{
			ret=window.open("cal.aspx?field_name="+ theField, "Poping", "toolbar=no,menubar=no,width=320,height=200", false);
			return true;
			}
		//-->
		</script>
		<script language="Javascript">
		<!--
		 // �s���t�ӲӸ`�����s
			function doSelectMfr(vType, vKeyword)
			{
				strFeature = "";
				strFeature += "dialogHeight:300px;dialogWidth:420px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//	oParam.type = vType;
				//	oParam.keyword = vKeyword;
				var vReturn = window.showModalDialog("Mfrim_detail.aspx", oParam, strFeature); 
				
				if(vReturn!=null)
				{
					//xmlDocX.loadXML(vReturn);
					//tbx_contno.value=xmlDocX.documentElement.selectSingleNode("�m�W").text;
				}
			}
		//-->
		</script>
		<script language="Javascript">
		<!--
		 // �s���Ȥ�Ӹ`�����s
			function doSelectCust(vType, vKeyword)
			{
				strFeature = "";
				strFeature += "dialogHeight:300px;dialogWidth:420px;center:yes;scroll:yes;status:no;help:no;";
				var oParam = new Object();
				//	oParam.type = vType;
				//	oParam.keyword = vKeyword;
				var vReturn = window.showModalDialog("�q��d��.htm", oParam, strFeature); 
				
				if(vReturn!=null)
				{
					//xmlDocX.loadXML(vReturn);
					//tbx_contno.value=xmlDocX.documentElement.selectSingleNode("�m�W").text;
				}
			}
		//-->
		</script>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- ���� Header -->
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�i������ƺ��@ - �ѦX���Ѷi�J �B�J�G</font>&nbsp;
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- ���D -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">�s�i������ƪ����@ - �ѦX���Ѷi�J</FONT></B> <STRONG><FONT color="red" size="2">
						(�����������խק襤...)</FONT></STRONG>
				<br>
				<FONT color="darkred" size="3">(�B�J�G: �ק糧�X���ѩҦ����������</FONT><FONT color="#8b0000">)</FONT>
			</DIV>
			<!-- Run at Server Form -->
			<form id="adpub_main12" method="post" runat="server">
				<!--Table �}�l-->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<!-- �Ȥ��� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(2) �t�ӤΫȤ���</font>
						</td>
					</TR>
					<!-- �t�Ӹ�� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT color="#cc0099">(2)</FONT> ���q�W��/�Ӹ� (�t�Ӳνs)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblCompanyName" runat="server" Height="18px"></asp:label>
							<FONT face="�s�ө���">&nbsp;(
								<asp:label id="lblMfrNo" runat="server" Height="18px"></asp:label>
								) </FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�ԲӸ�ơG
						</TD>
						<TD class="cssData">
							<!--FONT face="�s�ө���"><IMG class="ico" title="�t�ӸԲӸ��" onclick="doSelectMfr('�q�����O', lblMfrNo.value)" src="../images/edit.gif" width="18" border="0"></FONT-->
							<br>
							<FONT face="�s�ө���"><IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new')" alt="�t�ӸԲӸ��" src="../images/edit.gif" width="18" border="0"></FONT>
						</TD>
					</TR>
					<!-- ���q�t�d�H��� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							���q�t�d�H�m�W��¾�١G
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrRespName" runat="server" Height="18px"></asp:label>
							<FONT face="�s�ө���">&nbsp;(
								<asp:label id="lblMfrRespJobTitle" runat="server" Height="18px"></asp:label>
								) </FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							���q�q�ܡG
							<br>
							���q�ǯu�G
						</TD>
						<TD class="cssData">
							<FONT face="�s�ө���"></FONT>
							<asp:label id="lblMfrTel" runat="server" Height="18px"></asp:label>
							<br>
							<asp:label id="lblMfrFax" runat="server" Height="18px"></asp:label>
						</TD>
					</TR>
					<!-- �Ȥ��� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�Ȥ�m�W (�Ȥ�s��)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server" Height="18px"></asp:label>
							<FONT face="�s�ө���">&nbsp;</FONT> <FONT face="�s�ө���">(</FONT>
							<asp:label id="lblCustNo" runat="server" Height="18px"></asp:label>
							<FONT face="�s�ө���">)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�ԲӸ�ơG
						</TD>
						<TD class="cssData">
							<FONT face="�s�ө���"><IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new')" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0"></FONT>
						</TD>
					</TR>
					<!-- �X���Ѥ��e -->
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">�X�����e</font>
						</td>
					</tr>
					<TR>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<font color="#cc0099">(1)</font> ñ������G
						</TD>
						<TD class="cssData">
							<asp:label id="lblSignDate" runat="server" Height="18px"></asp:label>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�X���s���G
						</TD>
						<TD class="cssData">
							<asp:label id="lblContNo" runat="server" Height="18px"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" style="HEIGHT: 18px" noWrap align="right">
							�X�����O�G
						</TD>
						<TD class="cssData">
							<asp:dropdownlist id="ddlContType" runat="server" Height="18px" Enabled="False" AutoPostBack="True">
								<asp:ListItem Value="0" Selected="True">�п��...</asp:ListItem>
								<asp:ListItem Value="1">�@��X��</asp:ListItem>
								<asp:ListItem Value="2">���s�X��</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							���y���O�G
						</TD>
						<TD class="cssData" style="HEIGHT: 18px">
							<asp:dropdownlist id="ddlBookCode" runat="server" Height="18px" Enabled="False" AutoPostBack="True">
								<asp:ListItem Value="0" Selected="True">�п��...</asp:ListItem>
								<asp:ListItem Value="�u��">�u��</asp:ListItem>
								<asp:ListItem Value="�q��">�q��</asp:ListItem>
								<asp:ListItem Value="�u���O��">�u���O��</asp:ListItem>
								<asp:ListItem Value="�q���O��">�q���O��</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							<font color="#cc0099">(7)</font> �X���_����G
						</TD>
						<TD class="cssData" noWrap>
							<asp:textbox id="tbxStartDate" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="65px"></asp:textbox>
							&nbsp; <font size="3">~ </font>
							<asp:textbox id="tbxEndDate" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="65px"></asp:textbox>
							&nbsp;,
							<br>
							<FONT size="2">�@</FONT>
							<asp:label id="lblCountDateMonths" runat="server" Height="18px">12</asp:label>
							<FONT size="2">��&nbsp; </FONT><FONT color="red" size="1">(�w�]�Ȭ��@�~)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ӿ�~�ȭ��G
						</TD>
						<TD class="cssData">
							<asp:label id="lblEmpNo" runat="server" Height="18px" ForeColor="red"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�@���I�M���O�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">�O</asp:ListItem>
								<asp:ListItem Value="0">�_</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="�s�ө���"><FONT face="�s�ө���"><FONT face="�s�ө���">�|/�Ҥ����O</FONT>�G</FONT></FONT>
						</TD>
						<TD class="cssData">
							<asp:radiobuttonlist id="rblfgITRI" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							���w�������O�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgFixPage" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="�s�ө���"><FONT face="�s�ө���">���׵��O</FONT>�G</FONT>
						</TD>
						<TD class="cssData">
							<asp:radiobuttonlist id="rblfgClosed" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
								<asp:ListItem Value="6">�O: �Ҥ�</asp:ListItem>
								<asp:ListItem Value="7">�O: �|��</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							<FONT face="�s�ө���">�̫�ק��</FONT>�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:label id="lblModDate" runat="server" Height="18px"></asp:label>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="�s�ө���"><FONT face="�s�ө���">�¦X���s��</FONT>�G</FONT>
						</TD>
						<TD class="cssData">
							<asp:label id="lblOldContNo" runat="server" Height="18px"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�o�����O�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblInvCode" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�G�p</asp:ListItem>
								<asp:ListItem Value="2" Selected="True">�T�p</asp:ListItem>
								<asp:ListItem Value="3">��L</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT face="�s�ө���">�o���ҵ|�O�G</FONT>
						</TD>
						<TD class="cssData">
							<asp:radiobuttonlist id="rblTaxType" runat="server" Height="18px" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">���| 5%</asp:ListItem>
								<asp:ListItem Value="2">�s�|</asp:ListItem>
								<asp:ListItem Value="3">�K�|</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
					<!-- �Z�n�Ӹ` -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(9) �Z�n�Ӹ`</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
							<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" border="0">
								<TBODY>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(9)</font> �`�s�Z���ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxTotalJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											�w�s�Z���ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxMadeJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											�Ѿl�s�Z���ơG&nbsp;
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxRestJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											�`�Z�n���ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxTotalTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											�w�Z�n���ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxPubTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											�Ѿl�Z�n���ơG&nbsp;
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxRestTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(11)</font> �X���`���B�G
										</TD>
										<TD class="cssData">
											<FONT face="�s�ө���">$</FONT>
											<asp:textbox id="tbxTotalAmt" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="55px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											�wú���B�G
										</TD>
										<TD class="cssData">
											<FONT face="�s�ө���">$</FONT>
											<asp:textbox id="tbxPaidAmt" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="55px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											�Ѿl���B�G
										</TD>
										<TD class="cssData">
											<FONT face="�s�ө���">$</FONT>
											<asp:textbox id="tbxRestAmt" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="55px"></asp:textbox>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(9)</font> ���Z���ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxChangeJTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											<FONT color="#cc0099">(9)</FONT> �ذe���ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxFreeTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											<FONT color="#cc0099">(9)</FONT> �u�f��ơG&nbsp;
										</TD>
										<TD class="cssData">
											<FONT face="�s�ө���">
												<asp:textbox id="tbxDiscount" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
												��</FONT>
										</TD>
									</TR>
									<TR vAlign="center" align="left">
										<TD class="cssTitle" noWrap align="right">
											�m�⦸�ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxColorTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" noWrap align="right">
											�¥զ��ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxMenoTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
										<TD class="cssTitle" align="right">
											�M�⦸�ơG
										</TD>
										<TD class="cssData">
											<asp:textbox id="tbxGetColorTime" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
										</TD>
									</TR>
					</TR>
					<TR vAlign="center" align="left">
						<TD class="cssTitle" noWrap align="right">
							�ذe���ơG
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxFreeBookCount" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="28px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData">
							&nbsp;
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData">
							&nbsp;
						</TD>
					</TR>
				</TABLE>
				</TD></TR> 
				<!-- �s�i�p���H��� -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">(6) �s�i�p���H���</font>
					</td>
				</tr>
				<TR>
					<TD class="cssTitle" noWrap align="right">
						<FONT color="#cc0099">(6)</FONT> �s�i�p���H�m�W�G
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuName" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="65px"></asp:textbox>
					</TD>
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						<FONT face="�s�ө���"></FONT>
					</TD>
					<TD class="cssData" noWrap>
						&nbsp;</FONT>
					</TD>
				</TR>
				<TR>
					<TD class="cssTitle" noWrap align="right">
						�q�ܡG
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuTel" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="85px"></asp:textbox>
					</TD>
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�ǯu�G
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuFax" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="85px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD class="cssTitle" noWrap align="right">
						����G
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuCell" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="85px"></asp:textbox>
					</TD>
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						Email�G
					</TD>
					<TD class="cssData">
						<asp:textbox id="tbxAuEmail" runat="server" Height="18px" AutoPostBack="True" ReadOnly="True" Width="180px"></asp:textbox>
					</TD>
				</TR>
				</TBODY></TABLE> 
				<!-- �����Z�n��� -->
				<TABLE dataFld="�X���Ѹ����Z�n���" id="Table1" style="WIDTH: 90%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="�������Ӫ�" id="tbItems" style="WIDTH: 100%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 100%" colSpan="11">
											<FONT color="white">(10~12) �X���Ѹ����Z�n���</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0" align="middle">
										<TD nowrap>
											�\��
										</TD>
										<TD>
											�Ǹ�
										</TD>
										<TD>
											�Z�n �~��
										</TD>
										<TD>
											�Z�n
											<br>
											���X
										</TD>
										<TD>
											�s�i��m
										</TD>
										<TD>
											�s�i�g�T
										</TD>
										<TD>
											�s�i����
										</TD>
										<TD>
											����
										</TD>
										<TD>
											��Z
											<br>
											���O
										</TD>
										<TD>
											�~�ȭ�
											<br>
											�u��
										</TD>
										<TD>
											�ק�
											<br>
											�Ӹ`
										</TD>
									</TR>
								</THEAD>
								<TR borderColor="#bfcff0" bgColor="#e2eafc">
									<TD>
										<IMG class="ico" title="�s�W���" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="../images/new.gif" width="16" border="0"><FONT face="�s�ө���">&nbsp;</FONT><IMG class="ico" title="�R�����" height="14" src="../images/cut.gif" width="9" border="0">
									</TD>
									<TD>
										<INPUT dataFld="�Ǹ�" id="tbxPubSeq" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="2" size="2" value="1" name="tbxPubSeq">
									</TD>
									<TD>
										<INPUT dataFld="�Z�n�~��" id="tbxPubDate" style="WIDTH: 50px; HEIGHT: 22px" type="text" maxLength="6" size="6" name="tbxPubDate">
									</TD>
									<TD>
										<INPUT dataFld="�Z�n���X" id="tbxPageNo" style="WIDTH: 22px; HEIGHT: 22px" type="text" maxLength="6" size="3" name="tbxPageNo">
									</TD>
									<TD>
										<SELECT dataFld="�s�i��m" id="ddlColorCode" name="ddlColorCode" runat="server" size="1">
											<OPTION value="00" selected>
												�п��...</OPTION>
											<OPTION value="01">
												�m��</OPTION>
											<OPTION value="02">
												�¥�</OPTION>
											<OPTION value="03">
												�M��</OPTION>
										</SELECT>
									</TD>
									<TD>
										<SELECT dataFld="�s�i�g�T" id="ddlPageSizeCode" name="ddlPageSizeCode" runat="server" size="1">
											<OPTION value="00" selected>
												�п��...</OPTION>
											<OPTION value="01">
												����</OPTION>
											<OPTION value="02">
												�b��</OPTION>
										</SELECT>
									</TD>
									<TD>
										<SELECT dataFld="�s�i����" id="ddlLTypeCode" name="ddlLTypeCode" runat="server" size="1">
											<OPTION value="00" selected>
												�п��...</OPTION>
											<OPTION value="01">
												�S�O-�ʭ�</OPTION>
											<OPTION value="02">
												�S�O-�ʭ��̭�</OPTION>
											<OPTION value="03">
												�S�O-����</OPTION>
											<OPTION value="04">
												�S�O-�����̭�</OPTION>
											<OPTION value="05">
												����</OPTION>
											<OPTION value="06">
												����</OPTION>
										</SELECT>
									</TD>
									<TD>
										<INPUT dataFld="����" id="tbxCnt" style="WIDTH: 30px; HEIGHT: 22px" type="text" maxLength="3" size="3" name="tbxCnt">
									</TD>
									<TD>
										<INPUT dataFld="��Z���O" id="cbxfgGot" type="checkbox" name="cbxfgGot">
									</TD>
									<TD>
										<INPUT dataFld="�~�ȭ��u��" id="tbxEmpNo" style="WIDTH: 65px; HEIGHT: 22px" type="text" maxLength="5" size="5" name="tbxEmpNo">
									</TD>
									<TD>
										<IMG class="ico" title="������h�Ӹ`" onclick="doPubDetail()" src="../images/edit.gif" border="0">
									</TD>
								</TR>
							</TABLE>
							<FONT face="�s�ө���">��:&nbsp;�����Z�n��ƪ� �s�W</FONT> <FONT face="�s�ө���">�� �R�� �\��|������!</FONT>
							<br>
							<FONT face="�s�ө���">��: <font color="#cc0099">�Ʀr�Хܳ���</font>��ܹ�M���ѭ��Z����r����, �H��K��J���q�l���.</FONT>
							<br>
							<FONT face="�s�ө���" color="red">��: ���������X���ѶȨ��s���Ѧ�, �����\�ק�; �Y�n�ק�, �Х� "�X���Ѻ��@" �Ӱ�.</FONT>
							<br>
							<!-- Form���s -->
							<div align="center">
								<INPUT id="btn_add" onclick="Javascript: AddToDB()" type="button" value="�T�w�ק�" name="btn_modify">&nbsp;&nbsp;
								<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="��������" name="btn_close">
								��: �T�w�ק諸���s�ثe�|������!
							</div>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
		</center>
	</BODY>
</HTML>
