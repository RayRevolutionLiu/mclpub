<%@ Page language="c#" Codebehind="adpub_act2.aspx.cs" Src="adpub_act2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_act2" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�����ʧ@ �B�J�G</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<LINK href="../UserControl/adpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<CENTER>
			<!-- DataIsland -->
			<xml id="DSO1">
			</xml>
			<xml id="DSOT">
			</xml>
			<xml id="DSOEMPTY">
			</xml>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- Run at Server Form -->
			<form id="form1" name="form1" runat="server">
				<!-- Hidden Value Filed -->
				<input id="hidData" type="hidden" name="hidData" runat="server"> 
				<!-- Initial Client Side Script -->
				<SCRIPT language="javascript">
					//var xmlDoc1 = DSO1.XMLDocument;
					//xmlDoc1.async = false;
					//xmlDoc1.load("adpub_data.xml");
					
					//�o�q�i�Hwork...�u���L�S����ơA�u�V�|...
					//�o�q�O�۸�Ʈw����X���, ���N�W�q�� xml�ɮ� �Ө�
					// document.form1("hidData").value ����ƥ� .cs �̨��o
					//alert("hidData= " + document.form1("hidData").value);
					var xmldoct = DSOT.XMLDocument;
					xmldoct.async = false;
					xmldoct.loadXML(document.form1("hidData").value);
					
					
					//���J�Y���ť�node
					var xmlDocEmpty = DSOEMPTY.XMLDocument;
					xmlDocEmpty.async = false;
					xmlDocEmpty.load("adpub_data_empty.xml");
					
					var newHeadNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
					var newTailNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
					
					// �U�X��O for - �� xml�ɮ� ���J��
					//xmlDoc1.documentElement.insertBefore(newHeadNode, xmlDoc1.documentElement.childNodes.item(0));
					//xmlDoc1.documentElement.appendChild(newTailNode);
					
					// �U�X��O for - �� ��Ʈw ���J��
					xmldoct.documentElement.insertBefore(newHeadNode, xmldoct.documentElement.childNodes.item(0));
					xmldoct.documentElement.appendChild(newTailNode);
					
					// �U�X��O�� doReOrder() �̥Ϊ� Global Variable
					var Arr = new Array();
					
				</SCRIPT>
				<!-- �ثe�Ҧb��m -->
				<table dataFld="items" id="tbItems" align="left">
					<tr>
						<td align="left">
							<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
								�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
								�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
								�s�i�����ʧ@&nbsp; �B�J�G</FONT>
						</td>
					</tr>
				</table>
			&nbsp;
		</CENTER>
		<CENTER>
			<FONT face="�s�ө���"></FONT>
			<br>
		</CENTER>
		<!-- ������ƲM��
			// �� xml�ɮ� ���J��, dataSrc �� #DSO1
			// �� ��Ʈw ���J��, dataSrc �� #DSOT
		-->
		<CENTER>
			<table id="tb1" dataSrc="#DSOT" align="center" style="BORDER-RIGHT: #214389 1px solid; BORDER-TOP: #214389 1px solid; BORDER-LEFT: #214389 1px solid; BORDER-BOTTOM: #214389 1px solid">
				<TBODY>
					<thead align="middle">
						<tr style="COLOR: white; Size: 4" bgColor="#214389">
							<td align="middle" colSpan="22">
								<STRONG><FONT size="4"><font color="#ffffff">�s�i��������</font>&nbsp; -
										<asp:label id="lblSearchKeyword" runat="server" Font-Size="X-Small" ForeColor="Gold"></asp:label>
										&nbsp;
										<asp:label id="lblDBMessage" runat="server" ForeColor="Cyan" Font-Size="X-Small"></asp:label>
									</FONT></STRONG>
							</td>
						</tr>
						<tr bgColor="#bfcff0">
							<td noWrap>
								����
							</td>
							<td noWrap>
								�X����
								<br>
								�s��
							</td>
							<td noWrap>
								����
								<br>
								�Ǹ�
							</td>
							<td noWrap>
								�Z�n
								<br>
								�~��
							</td>
							<td noWrap>
								�Z�n
								<br>
								���X
							</td>
							<td noWrap>
								��m
							</td>
							<td noWrap>
								�g�T
							</td>
							<td noWrap>
								����
							</td>
							<td noWrap>
								�T�w
								<br>
								����
							</td>
							<td noWrap>
								<font color="red">���q�W��</font>
							</td>
							<td noWrap>
								�s�Z
								<br>
								�s�k
							</td>
							<td noWrap>
								��Z
							</td>
							<td noWrap>
								��Z
								<br>
								���y
							</td>
							<td noWrap>
								��Z
								<br>
								���O
							</td>
							<td noWrap>
								��Z
								<br>
								���X
							</td>
							<td noWrap>
								��Z
								<br>
								���X��
							</td>
							<td noWrap>
								�½Z
								<br>
								���y
							</td>
							<td noWrap>
								�½Z
								<br>
								���O
							</td>
							<td noWrap>
								�½Z
								<br>
								���X
							</td>
							<td noWrap>
								����
								<br>
								�~�ȭ�
							</td>
							<td noWrap>
								�Ƶ�
							</td>
							<td noWrap>
								(�Ѧ�)
							</td>
						</tr>
					</thead>
					<tbody onmousemove="doMouseMove()">
						<tr align="middle" valign="bottom">
							<td class="cssOrder">
								<span dataFld="����" id="pageorder"><FONT face="�s�ө���"></FONT></span>
							</td>
							<td class="cssColumn">
								<span dataFld="�X���ѽs��" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="�����Ǹ�" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="�Z�n�~��" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn" align="right">
								<span dataFld="�Z�n���X" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="�s�i��m" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumnDiffColor">
								<span dataFld="�s�i�g�T" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn" nowrap>
								<span dataFld="�s�i����" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumnDiffColor">
								<span dataFld="�T�w�������O" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssCompanyName" align="left" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								<!-- �� load �۸�Ʈw��: idCompanyName �� onclick() �̭n�ܧ� DSOT --><span dataFld="���q�W��" id="idCompanyName" onclick="doClick(document.all.DSOT)"></span>
							</td>
							<td class="cssColumn">
								<span dataFld="�s�Z�s�k" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="��Z���O" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="��Z���y�N�X" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="��Z���O" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="��Z���X" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="��Z���X�����O" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="�½Z���y�W��" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="�½Z���O" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="�½Z���X" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<span dataFld="�����~�ȭ��m�W" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn" align="left">
								<span dataFld="�Ƶ�" style="BORDER-RIGHT: #595959 0px solid; BORDER-TOP: #595959 0px solid; BORDER-LEFT: #595959 0px solid; BORDER-BOTTOM: #595959 1px solid">
								</span>
							</td>
							<td class="cssColumn">
								<input dataFld="����2" id="pagelayout2" type="text" size="1" disabled style="BORDER-RIGHT: #595959 0px; BORDER-TOP: #595959 0px; BORDER-LEFT: #595959 0px; BORDER-BOTTOM: #595959 0px">
							</td>
						</tr>
					</tbody>
					<tfoot>
						<tr>
							<td align="left" bgColor="#bfcff0" colSpan="22" style="COLOR: #990033">
								�@��ާ@�G�бN�ƹ����� "<font color="red">���q�W��</font>" �W, ���@���ƹ�����, �A���ƹ���z�n���ʪ���m�W�A���@�U����, 
								�Ӷi��h�ʸ������.
								<br>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�������ʧ�, 
								�Ы�����椧 "<font color="green">���ƭ���</font>" ���s; �����T�{��, �̫�Ы� "<SPAN style="COLOR: black; BACKGROUND-COLOR: #cdc9c9">�T�{�g�^</SPAN>" 
								�ӧ���.
								<br>
								�ާ@�ɥR�G�T�w����(=<font color="#336699">�O</font>) �����N�����\����! ��ܸӸ������, �Ȥᦳ�n�D�Z�n�b���w�����X!
								<br>
								�ާ@�ɥR�G�P�@�X���ѽs���B�P������h���������(��g�T�� "<font color="#336699">�b��</font>"), �аȥ����W�U�۾F��m!
								<br>
								�ާ@�ɥR�G���q�W�٬� <font color="#336699">xxx</font> ��, �нT�{���m���Y�Χ�����m!
								<br>
								<br>
								<font color="black">��: ���ק︨�����, �Ц� <A href="cont_main1.aspx" target="_self">�X���B�z/�@��X����/�X���Ѻ��@</A>
									�� <A href="adpub_main21.aspx" target="_self">�����B�z/�s�i������ƺ��@-�Ѧ~�븨���i�J</A> �ӭק�!
									<br>
									��: �p�ݦC�L������ư����ѭ��Ѧү�, �C�L�ɽп�� "<font color="darkred">��L</font>", �H�o�����Ƶe��!
									<br>
								</font>
							</td>
						</tr>
						<tr>
							<td align="middle" colSpan="22">
								<FONT face="�s�ө���">(�Х����U�� "���ƭ���" ���s, �A���k�����) =&gt; </FONT><INPUT id="btnWritetoDB" onclick="Javascript: doWriteToDB();" type="button" value="�T�{�g�^" name="btnBack">
								<br>
							</td>
						</tr>
					</tfoot>
			</table>
		</CENTER>
		<!-- ������ƲM�� -->
		<!-- Mouse click �᪺��ƶ}�l -->
		<CENTER>
			<DIV class="srcData" id="ico" style="DISPLAY: none; Z-INDEX: 100; POSITION: absolute">
			</DIV>
		</CENTER>
		<CENTER>
			<DIV id="fMenu">
				<DIV class="fixMenu" onclick="doReOrder()">
					���ƭ���
				</DIV>
				<DIV class="fixMenu" onclick="doHelp1();">
					�ާ@����
				</DIV>
				<DIV class="fixMenu" onclick="window.location.href='/mrlpub/'">
					��^����
				</DIV>
				<DIV class="fixMenu" id="tempMsg">
				</DIV>
			</DIV>
		</CENTER>
		<CENTER>
			<br>
			<!-- �� TEXTAREA �O���ˬd XML ��X�ˬd�� -->
			<!--TEXTAREA id="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</CENTER>
		<!-- ��X�ثe�ƪ����s����, �g�J hiddata ��, �̫�A�N�s�����g�^��Ʈw -->
		<script language="javascript">
				function doWriteToDB()
				{
					//�U�X��O for - �� ��Ʈw ���J��
					//����X�ثe�e����������
					var xmlDoc = DSOT.XMLDocument; 
					//alert(xmlDoc.documentElement.xml); 
					
					//alert(document.all.pageorder[3].innerText);
					for(var i=0; i< document.all.pageorder.length; i++)
					{
						// ��X�D�ť� node ���Ҧ��e���W���s����
						if(document.all.pageorder[i].innerText != "--")
						{
							// �ˬd��X �e���W���s����
							//alert(document.all.pageorder[i].innerText);
							
							// ��g DSOT.XMLDocument - �N�e���W���s���� �s�J xmlDoc (�`�N: ���g�J�e xmlDoc�������� 0(��l��); �g�J�ᬰ �e���W���s����)
							//alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text);
							
							// �Y���T�w���������, �䭶�������H�ק�, ������w������
							if (xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�T�w�������O").text == "�O")
							{
								//alert("�� " + i + " �����T�w����");
								//alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text);
								//xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text;
								
								// �ˬd�өT�w���������X����, �@�߿�X�ର 2��Ƥ��Ʀr! 
								var FixPgno = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text;
								if(FixPgno.length==1)
								{
									FixPgno = "0" + FixPgno;
								}
								else
								{
									FixPgno = FixPgno;
								}
								//alert("FixPgno= " + FixPgno);
								
								// ��X���G�� "����" �B
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text = FixPgno;
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = FixPgno;
								
							}
							// �Ϥ�, �h�����s����
							else
							{
								//alert(document.all.pageorder[i].innerText);
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = document.all.pageorder[i].innerText;
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text = document.all.pageorder[i].innerText;
								//alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text);					
							}
						}
					}
					//�ˬd�g �s���� �J xmlDoc �O�_���\
					//alert(xmlDoc.documentElement.xml);
					
					// ��s hidData �� - �N�s�� xmlDoc �g�J document.form1("hidData").value ��
					document.form1("hidData").value = "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlDoc.documentElement.xml;
					//alert("hidData= " + document.form1("hidData").value);
					
					// ���� adpub_act3.aspx: �Ƕǻ��ܼ� ("hidData").value ��(�Y xml���) ��X�U�椧�s����, �A���O update �g�J��Ʈw��				
					var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
					xmlHTTP.Open("post", "adpub_act3.aspx", false);
					xmlHTTP.Send(xmlDoc);
					
					// �ˬd�ÿ�X xmlHTTP ���A�󥻭� textarea1 ��
					//document.all("textarea1").value=xmlHTTP.responseText;
					
					if(xmlHTTP.statusText=="OK")
					{
						alert("�s������s���\!");
					}
					
					// �M�� xmlHTTP ��Ƭ���
					var xmlHTTP = null;
					
					
					// ���� ReLoad
					location.reload(true);
				}
				</script>
		<!-- �\����� -->
		<script language="javascript">
				function doHelp1()
				{
					if(document.all.helpMsg.style.display.toLowerCase() == 'none')
					{
						document.all.helpMsg.style.display = "";
						event.srcElement.innerText = "���þާ@����"; 
					}
					else
					{
						document.all.helpMsg.style.display = "none";
						event.srcElement.innerText = "�ާ@����"; 
					}
				}
				//	window.onload = ggg();
				</script>
		<script language="javascript" src="UserControl/watermark.js"></script>
		<script language="javascript">
				// page layout maintain
				function doClick(theDSO)
				{
					if(btnPressed)
					{
						if(srcDSO == theDSO)
						{
							doPut();
							btnPressed = false;
							var gg = false;
							for(var i=0; i<document.getElementsByTagName("tb1").length; i++)
							{
								// if(event.srcElement.readyState=="complete")
							}
							doReOrder();
						}
					}
					else
					{
						srcDSO = theDSO;
						doPick();
						btnPressed = true;
					}
				}
				
				
				function doMouseMove()
				{
					// document.all("ico").value="Coords: (" + event.clientX + ", " + event.clientY + ")";
					document.all.ico.style.posLeft = event.clientX + document.body.scrollLeft;
					document.all.ico.style.posTop = event.clientY + document.body.scrollTop;
					// event.returnValue = false;
					// event.cancelBubble = true; 
					/*
					 */
				}
				
				
				function doPick()
				{
					srcObj = event.srcElement;
					srcObj.style.color="red"; 
					srcObj.style.cursor="hand";
					document.all.ico.style.display=""; 
					document.all.ico.innerText=srcObj.innerText;
					
					//�U�X��O for - �� xml�ɮ� ���J��				
					//segOffset = srcObj.parentElement.parentElement.rowIndex-2;
					////���Xsrc��XmlDocument
					//var xmlDoc = srcDSO.XMLDocument; 
					//srcNode = xmlDoc.documentElement.childNodes.item(segOffset);
					//return !btnPressed;
					
					//�U�X��O for - �� ��Ʈw ���J��
					segOffset = srcObj.parentElement.parentElement.rowIndex-2;
					var xmlDoc = xmldoct.XMLDocument; 
					srcNode = xmldoct.documentElement.childNodes.item(segOffset);
					return !btnPressed;
				}
				
				
				function doPut()
				{
					/*�p�઺��l��
					var obj = event.srcElement;
					var idx = obj.parentElement.parentElement.rowIndex-2;
					var xmlDoc = srcDSO.XMLDocument; 
					xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx));
					srcObj.style.color=""; 
					srcObj.style.cursor="";
					srcObj = null;
					document.all.ico.style.display="none"; 
					return !btnPressed;
					*/
					
					//obj����Xput�U�h�ɡA�o�X�ƥ�cell�H
					var obj = event.srcElement; 
					
					//cell->row�A�M���X��row��index�A-2�O�h����檺�D���binding��
					var idx = obj.parentElement.parentElement.rowIndex-2;
					
					
					//���Xsrc��XmlDocument
					//�U�@��O for - �� xml�ɮ� ���J��
					//var xmlDoc = srcDSO.XMLDocument; 
					
					//�U�@��O for - �� ��Ʈw ���J��
					var xmlDoc = DSOT.XMLDocument; 
					//alert(xmlDoc.documentElement.xml);
					
					
					if (idx==segOffset)		//segOffset�Opick�_�ӮɡA����row��index
					{
						//alert("the same node"); 
						srcObj.style.color="";
						srcObj.style.cursor="";
						srcObj = null; 
						document.all.ico.style.display="none";
						return !btnPressed;
					} 
					
					//STEP2�G�p�G�D�諸�I�O���i���ʪ��I�A�]����
					//if (srcNode.selectSingleNode("�T�w�������O").text == "1")
					if (srcNode.selectSingleNode("�T�w�������O").text == "�O")
					{ 
						//alert("�o��node���i�H����"+!btnPressed);
						alert("�ܩ�p, �o�Ӧ�m�Q�n�D '�T�w', �G�����i�Q����!");
						srcObj.style.color=""; 
						srcObj.style.cursor="";
						srcObj = null;
						document.all.ico.style.display="none"; 
						return !btnPressed;
					}
					
					//�U�@��O for - �� xml�ɮ� ���J��
					//if(xmlDoc.documentElement.childNodes.item(idx).selectSingleNode("�T�w�������O").text =="1")
					
					//�U�@��O for - �� ��Ʈw ���J��
					//if (xmldoct.documentElement.childNodes.item(idx).selectSingleNode("�T�w�������O").text =="1")
					if (xmldoct.documentElement.childNodes.item(idx).selectSingleNode("�T�w�������O").text =="�O")
					{
						//alert("��U�h���I�O�T�w��");
						alert("�ܩ�p, �z�Q���쪺��m�Q�n�D '�T�w', �Э��s�w�Ʒs��m!");
						srcObj.style.color="";
						srcObj.style.cursor=""; 
						srcObj = null;
						document.all.ico.style.display="none";
						return !btnPressed
					}
					
					//�U�@��O for - �� xml�ɮ� ���J��
					//var xmlRefList = srcDSO.XMLDocument.documentElement.cloneNode(true); 
					//xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);
					
					//�U�@��O for - �� ��Ʈw ���J��
					var xmlRefList = DSOT.XMLDocument.documentElement.cloneNode(true); 
					xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);
					
					//�}�l����
					
					//������
					var i; 
					for (i=0;i<xmlDoc.documentElement.childNodes.length;i++)
					{
						if (xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�T�w�������O").text =="�O")
						{ 
							xmlDoc.documentElement.removeChild(xmlDoc.documentElement.childNodes.item(i)); 
							i--;
						}
					}		
					i = null;
					
					var j;
					//alert("xmlRefList.childNodes.length=" + xmlRefList.childNodes.length);
					for (j=0;j<xmlRefList.childNodes.length;j++)
					{						
						//�� safe control
						//alert("xmlDoc.documentElement.childNodes.length= " + xmlDoc.documentElement.childNodes.length);
						if (j<xmlDoc.documentElement.childNodes.length)
						{
							// �`�N if ����̪��P�_���ˬd if(����@!= ����G)
							// ����@-�T�w�������O(�_): xmlRefList.�T�w�������O=1(�O) && (xmlRefList.�X���ѽs��+xmlRefList.�����Ǹ�+xmlRefList.�Z�n�~��) ==> �~�O�ߤ@��; ���i�u�� "���q�W��" ���N���ߤ@��), �_�h�h����, �|�򥢦h���ۦP���q�W�٭Ȫ����
							// ����G-�T�w�������O(�O): xmlDoc�X���ѽs��+xmlRefList.�����Ǹ�+xmlRefList.�Z�n�~��
							//alert("xmlDoc.�X���ѽs��= " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�X���ѽs��").text);
							//alert("xmlRefList.�X���ѽs��= " + xmlRefList.childNodes.item(j).selectSingleNode("�X���ѽs��").text);
							//alert("����@-�T�w�������O(�_): " + xmlRefList.childNodes.item(j).selectSingleNode("�T�w�������O").text == "�O") && (xmlRefList.childNodes.item(j).selectSingleNode("�X���ѽs��").text+xmlRefList.childNodes.item(j).selectSingleNode("�����Ǹ�").text+xmlRefList.childNodes.item(j).selectSingleNode("�Z�n�~��").text);
							//alert("����G-�T�w�������O(�O): " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�X���ѽs��").text+xmlRefList.childNodes.item(j).selectSingleNode("�����Ǹ�").text+xmlRefList.childNodes.item(j).selectSingleNode("�Z�n�~��").text);
							if ((xmlRefList.childNodes.item(j).selectSingleNode("�T�w�������O").text == "�O") && (xmlRefList.childNodes.item(j).selectSingleNode("�X���ѽs��").text+xmlRefList.childNodes.item(j).selectSingleNode("�����Ǹ�").text+xmlRefList.childNodes.item(j).selectSingleNode("�Z�n�~��").text != xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�X���ѽs��").text+xmlRefList.childNodes.item(j).selectSingleNode("�����Ǹ�").text+xmlRefList.childNodes.item(j).selectSingleNode("�Z�n�~��").text))
							{
								//�D����
								var newNode = xmlRefList.childNodes.item(j).cloneNode(true);
								//alert("insertBefore" + j + "th");
								xmlDoc.documentElement.insertBefore(newNode, xmlDoc.documentElement.childNodes.item(j));
								newNode = null;
							}
						}
						else
						{
							var newNode = xmlRefList.childNodes.item(j).cloneNode(true);
							xmlDoc.documentElement.appendChild(newNode);
							newNode = null;
						}
					}
					j = null; 
					
					//GC 
					xmlRefList = null;
					
					srcObj.style.color="";
					srcObj.style.cursor="";
					srcObj = null;
					document.all.ico.style.display="none";
					return !btnPressed;
				}
				
				
				// ���U ���ƭ��� ���ʧ@ function
				function doReOrder()
				{
					//���Xsrc��XmlDocument
					//�`�N: ���e function �����w srcDSO == theDSO (�YDSO1); �ҥH�U�@��n�ܧ󪽱�load DSO1, �D srcDSO; �_�h�Ypage�@load��, �h�� "���ƭ���" �|�o�Ϳ��~
					//var xmlDoc = srcDSO.XMLDocument; 
					
					//�U�@��O for - �� xml�ɮ� ���J��
					//var xmlDoc = DSO1.XMLDocument; 
					//alert(xmlDoc.documentElement.xml); 
					
					//�U�@��O for - �� ��Ʈw ���J��
					var xmlDoc = DSOT.XMLDocument; 
					//alert(xmlDoc.documentElement.xml); 
					//alert("document.all.pageorder.length= " + document.all.pageorder.length);
					
					
					// ���� Arr �O�_�b�� function �i��o�� (a Global Variable; �w�w�q�b Initial Client Side Script ��, Line 61)
					//alert("Arr= " + Arr);
					
					
					// ���w �T�w����=�O, �h�� �s���� = �Z�n���X��DB��
					var FixPageNo = "";
					for(var j=0; j< document.all.pageorder.length; j++)
					{
						//alert("���q�W��= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("���q�W��").text);
						if (xmlDoc.documentElement.childNodes.item(j).selectSingleNode("���q�W��").text != "xxx")
						{
							// �Y �T�w����=�O, �h�� �s���� = �Z�n���X��DB��
							//alert("�T�w�������O(" + j + ")= " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�T�w�������O").text);
							
							if(xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�T�w�������O").text=="�O")
							{
								// ��X ��Z�n���X����
								FixPageNo = xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�Z�n���X").text;
								//alert("FixPageNo= " + FixPageNo);
								
								// �N �Z�n���X�� ��J Arr ��, �H�� doIsInArray() & doNewPageNo() �ϥ�
								Arr.push(FixPageNo);
								//alert("Arr= " + Arr);
								//alert("Arr.length=" + Arr.length);
								
								// ���w �T�w����=�O, �h�� �s���� = �Z�n���X��DB��
								//xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�Z�n���X").text = xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�Z�n���X").text;
								xmlDoc.documentElement.childNodes.item(j).selectSingleNode("����").text = FixPageNo;
							}
						}
						// �Y���q�W�٪��Ȭ� "xxx" , ��ܬ��ťժ� nodes, �N�����p�⭶�����B�z, ���M���B�z
						else
						{
							//alert("null");
							// ��������B�z, �M�� ���� & �Z�n���X ����
							xmlDoc.documentElement.childNodes.item(j).selectSingleNode("����").text = "";
							xmlDoc.documentElement.childNodes.item(j).selectSingleNode("�Z�n���X").text = "";
						}
					}
					//alert("Arr= " + Arr);
					//alert("Arr.length=" + Arr.length);
					
					
					// pp ���s����, ���ץ� 0 ~ document.all.pageorder.length-2 (�� 2���]�O�h�Y���ť� Nodes)
					//alert("pageorder.length=" + (document.all.pageorder.length-2) );
					var NewPageNo1 = "";
					var pp = 0;
					var FixedPage = "";
					for(var i=0; i< document.all.pageorder.length; i++)
					{
						//alert("���q�W��= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("���q�W��").text);
						// �h���ť� Nodes - �Y���q�W�٪��Ȭ� "xxx" , ��ܬ��ťժ� nodes, �N�����p�⭶�����B�z
						if (xmlDoc.documentElement.childNodes.item(i).selectSingleNode("���q�W��").text == "xxx")
						{
							//alert("null");
							// ��������B�z, �M�� ���� & �Z�n���X ����
							xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = "";
							xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text = "";
						}
						// ��X�Ҧ��������
						else
						{
							// ��X ��ƤΨ�Z�n���X ����
							//alert("�Z�n���X(" + i + ")= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text);
							//pp = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text;
							
							// �p��X �s���� pp = 1 ~ document.all.pageorder.length-1
							pp = pp + (document.all.pagelayout2[i].value/8);
							//alert("pp= " + pp);
							
							
							// �ˬd �s���� NewPageNo  �O�_�P �T�w�������O="�O"���Z�n���X�� �۽Ĭ�
							// �Y �T�w�������O �� "�_" ��, doIsInArray()
							if(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�T�w�������O").text != "�O")
							{
								// �s���� pp  �P �T�w�������Z�n���X Arr[i] ���Ĭ��
								if(doIsInArray(pp)==1)
								{
									// �Y�� �b��, ��s���� = pp
									if(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�s�i�g�T").text=="�b��")
									{
										xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = pp;
									}
									// �Y�� ����, ��X �S���Ĭ𪺷s���� (= skip �T�w�������Z�n���X Arr[i])
									else
									{
										NewPageNo1 = doNewPageNo(pp);
										xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = NewPageNo1;
										pp = NewPageNo1;
										//alert("NewPageNo1= " + NewPageNo1);
									}
								}
								// �s���� pp  �P �T�w�������Z�n���X Arr[i] �L�Ĭ��
								else
								{
									xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = pp;
								}
								
								// Math.cell �O�|�ˤ��J: �Ǧ^�̤j����� (�Y�L����i��)
								document.all.pageorder[i].innerText = Math.ceil(pp);
							}
							// �Y �T�w�������O �� "�O" ��, ���w�� �s���� = �Z�n���X )
							else
							{
								FixedPage = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("�Z�n���X").text;
								//alert("�Z�n���X= " + FixedPage);	
								xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text = FixedPage;
								//alert("����= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("����").text);
								
								// Math.cell �O�|�ˤ��J: �Ǧ^�̤j����� (�Y�L����i��)
								document.all.pageorder[i].innerText = Math.ceil(FixedPage);	
							}
							
							
							// �ˬd�өT�w���������X����, �@�߿�X�ର 2��Ƥ��Ʀr!
							// �Y �s���� ���Ӧ��, ���e���ɹs���ʧ@
							if(document.all.pageorder[i].innerText < 10)
								document.all.pageorder[i].innerText = "0" + document.all.pageorder[i].innerText;
							else
								document.all.pageorder[i].innerText = document.all.pageorder[i].innerText;
							//alert("document.all.pageorder[i].innerText= " + document.all.pageorder[i].innerText);
							
						}
						
					}
				}
				
				
				// for doReOrder() �̨ϥ�
				function doIsInArray(pp1)
				{
					// ��X �T�w�������O='�O' ���Z�n���X��
					for(var i=0; i< Arr.length; i++)
					{
						//alert("Arr[i]= " + Arr[i] + ", pp1=" + pp1);
						// �Y �s���� = �T�w�������O='�O' ���Z�n���X�� ��
						if(pp1==Arr[i])
						{
							return 1;
						}
					}
					return 0;
				}
				
				
				// for doReOrder() �̨ϥ�
				function doNewPageNo(pp2)
				{
					do
					{
						pp2++;
					}
					while(doIsPageOccupied(pp2) != 0)
					return pp2;
				}
				
				
				// for NewPageNo() �̨ϥ�
				function doIsPageOccupied(pp3)
				{
					// ��X �T�w�������O='�O' ���Z�n���X��
					for(var i=0; i< Arr.length; i++)
					{
						//alert("Arr[i]= " + Arr[i] + ", pp3=" + pp3);
						// �Y �s���� = �T�w�������O='�O' ���Z�n���X�� ��
						if(pp3==Arr[i])
							return 1;
					}
					return 0;
				}
				
				
				// ���s�ƪ��A�w����
				function doRePublish()
				{
				}
				
				var srcDSO = new Object();
				var btnPressed=false;
				var srcObj = new Object();
				var srcNode = new Object();
				var segIdx = 0;
				var segOffset = 0;
				</script>
		<!-- idCompanyName �� OnMouseOver ����C�� -->
		<script language="javascript" event="onmouseover" for="idCompanyName">
					style.backgroundColor='Gold';
					style.cursor="hand";
				</script>
		<!-- idCompanyName �� OnMouseOut ����C�� -->
		<script language="javascript" event="onmouseout" for="idCompanyName">
					style.backgroundColor='';
					style.cursor="default";
				</script>
		<!-- fMenu �� OnMouseOver ����C��  -->
		<script language="javascript" event="onmouseover" for="fMenu">
					event.srcElement.style.backgroundColor='Gold';
					event.srcElement.style.cursor="hand";
				</script>
		<!-- fMenu �� OnMouseOut ����C��  -->
		<script language="javascript" event="onmouseout" for="fMenu">
					event.srcElement.style.backgroundColor='';
					event.srcElement.style.cursor="";
				</script>
		<!-- fMenu �� helpMsg ����C��  -->
		<CENTER>
			<DIV class="help1" id="helpMsg" style="DISPLAY: none; WIDTH: 580px; HEIGHT: 110px" align="left">
				<OL>
					<LI>
						�бN�ƹ������l�檺(��p�Ĥ���) "<font color="red"> ���q�W��</font>" �W, ���@���ƹ�����, 
					�o�ɷ|�X�{�@�ӦP�˪����q�W��, ���Q�ƻs���(�����).
					<LI>
						�A���ƹ���ئa�檺(��p�ĤG��) "<font color="red"> ���q�W��</font>�W, �A���@�U����, �Ӷi��h�ʸ������, 
					�ӭ�l��N�|�Q�w�m��ئa�檺�U�@���m.
					<LI>
						�������ʧ�, �Ы�����椧 "<font color="green">���ƭ���</font>" ���s.
					<LI>
						�̲ת������T�{��, �̫�Ы� "<SPAN style="BACKGROUND-COLOR: gray">�T�{�g�^</SPAN>" �ӧ����g�^��Ʈw.
					</LI>
				</OL>
			</DIV>
		</CENTER>
		</FORM>
	</BODY>
</HTML>
