<%@ Page language="c#" Codebehind="PubFm_Add.aspx.cs" Src="PubFm_Add.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm_Add" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W�������e</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header -->
		<!-- �ثe�Ҧb��m -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left">
					<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�s�W���� �B�J�G: �s�W�������e</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="PubFm_Add" method="post" runat="server">
			<!--Table �}�l-->
			<TABLE id="tblPubMain" style="WIDTH: 98%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
				<!-- �t�ӤΫȤ��� -->
				<TR bgColor="#214389">
					<TD>
						<font color="white">�������</font>
					</TD>
				</TR>
			</TABLE>
			<!-- �w�s�W ������� �� --><font color="#ff0066" size="2">[�w�s�W ������� ��]</font>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="��s" HeaderText="�s��" CancelText="����" EditText="�s��"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="�R��" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pno" HeaderText="���y���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="�Z�n���X"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_clrcd" HeaderText="�s�i��m"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgscd" HeaderText="�s�i�g�T"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_ltpcd" HeaderText="�s�i����"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="�T�w�������O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fggot" HeaderText="��Z���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="�o������H�m�W"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:label id="lblAddMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<br>
			<!-- ������� �s�W/�ק� �� --><font color="#ff0066" size="2">[������� �s�W/�ק� ��]</font>
			<asp:textbox id="tbxSysCode" runat="server" Visible="False" MaxLength="2" WIDTH="30px" Enabled="False">C2</asp:textbox>
			<FONT color="#ff0066" size="2"></FONT>&nbsp;
			<asp:textbox id="tbxContNo" runat="server" Visible="False" MaxLength="6" WIDTH="50px" Enabled="False"></asp:textbox>
			&nbsp;
			<asp:label id="lblBkcd" runat="server" Visible="False" Font-Size="x-Small"></asp:label>
			&nbsp;
			<br>
			<font size="2">�Z�n�~��X�z�d��G</font>
			<asp:label id="lblStartDate" runat="server" Font-Size="x-Small"></asp:label>
			&nbsp;~&nbsp;
			<asp:label id="lblEndDate" runat="server" Font-Size="x-Small"></asp:label>
			&nbsp;
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							�Ǹ�
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�Z�n�~��
							<br>
							<font color="#c00000" size="2">(�ж�d��)</font>
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>���y���O
						</TH>
						<TH>
							�Z�n���X
						</TH>
						<TH>
							�s�i��m
						</TH>
						<TH>
							�s�i�g�T
						</TH>
						<TH>
							�s�i����
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�T�w����
							<BR>
							���O
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�o���t��
							<br>
							����H�Ǹ�
						</TH>
						<TH>
							�o���t��
							<br>
							����H�m�W
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
							<asp:label id="lblPubSeq" runat="server"></asp:label>
						</TD>
						<TD>
							&nbsp; <INPUT dataFld="�Z�n�~��" id="tbxYYYYMM" onblur="Javascript:CheckPubDate(this);" type="text" maxLength="6" onchange="Javascript:CheckPubDate2(this);" size="6" name="tbxPubDate">
						</TD>
						<TD>
							&nbsp; <INPUT dataFld="���y���O" id="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);" type="text" maxLength="4" size="3" name="tbxBkpPno">&nbsp;
							<IMG class="ico" title="���y���O�ѦҸ��" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
						</TD>
						<TD>
							&nbsp;
							<asp:textbox id="tbxPageNo" runat="server" MaxLength="3" Width="30px"></asp:textbox>
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
					<!-- �ĤG�� -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH>
							�s�i���B
						</TH>
						<TH>
							���Z���B
						</TH>
						<TH>
							�w�}��
							<br>
							�o������O
						</TH>
						<TH>
							�o���}�߳�
							<br>
							�H�u�B�z���O
						</TH>
						<TH colSpan="5">
							�Ƶ�
						</TH>
					</TR>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD colSpan="5">
							&nbsp;
						</TD>
					</TR>
					<!-- �ĤT�� -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�Z�����O
						</TH>
						<TH>
							�s�Z�s�k
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>��Z���O
						</TH>
						<TH>
							��Z����
						</TH>
						<TH>
							��Z���O
						</TH>
						<TH>
							��Z���X
						</TH>
						<TH>
							��Z���X��
							<br>
							���O
						</TH>
						<TH>
							�½Z����
						</TH>
						<TH>
							�½Z���O
						</TH>
						<TH>
							�½Z���X
						</TH>
					</TR>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* ���������!</FONT>
			<br>
			<asp:button id="btnSave" runat="server" Text="�x�s�s�W"></asp:button>
			&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="�x�s�ק�"></asp:button>
			&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="���J�w�]���"></asp:button>
			<br>
			<br>
		</form>
		<!-- Javascript -->
		<script language="javascript">
		<!--
		//�ˬd������J�� "�Z�n�~��" ���ȬO�_���T
		function CheckYYYYMM(obj)
		{	
			// �P�_�Z�n�~�몺���׬O�_�� 6�X
			var yyyymm = window.document.all("tbxYYYYMM").value;
			if(yyyymm.length!=6)
			{
				alert("'�Z�n�~��' �����ץ����� 6�X(�褸), �Эץ�!");
				return;
			}
			// �Y�Z�n�~�몺���׬� 6�X (�X�z)
			else
			{
				// �ˬd�O�_��J�� �Ʀr���A
				if(isNaN(yyyymm)==true)
					alert("'�Z�n�~��' ������J�Ʀr���A!");
				
				// �P�_�Z�n�~��O�_�b �X���_���� �d��
				var ContStartDate = window.document.all("lblStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("lblEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				//alert("ContStartDate= " + ContStartDate);
				//alert("ContEndDate= " + ContEndDate);
				if(yyyymm<ContStartDate || yyyymm>ContEndDate)
				{
					alert("'�Z�n�~��' �����b�X���_���d��, �Эץ�!");
					return;
				}
				
				// �çP�_�褸�Z�n�~��O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
				var yyyy = yyyymm.substring(0, 4);
				var mm = yyyymm.substring(4, 6);
				
				// �P�_�褸�Z�n�~�׬O�_�X�z��
				if(yyyy<=1990 || yyyy>=2200)
				{
					alert("�`�N: �Z�n�~�뤧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �Ч�!");
					return;
				}
				else
					yyyymm = yyyymm;
				
				// �P�_�褸�Z�n����O�_�X�z��
				if(mm>12 || mm<=0)
				{
					alert("�`�N: �Z�n�~�뤧��� '" + mm + "' ���X�z, �Ч�!");
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
		function CheckYYYYMM2(obj)
		{
			var yyyymm = window.document.all("tbxYYYYMM").value;
			if(yyyymm != "")
				alert("�z��s�F '�Z�n�~��' !\n �ЦA���@�U '���y���O' �Ǫ����s�ӧ�s���!!!");
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �ˬd "���y���O" �@��O�_����J
		function CheckBookPNo(obj)
		{	
			var BookPNo = window.document.all("tbxBkpPno").value;
			// �Y���y���O�S����J
			if(BookPNo.length==0)
			{
				//alert("'���y���O' ������!\n �Ы��U�k����s�ӬD��!");
				return;
			}
			else
			{
				// �ˬd�O�_��J�� �Ʀr���A
				if(isNaN(BookPNo)==true)
					alert("'���y���O' ������J�Ʀr���A!");
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="���y���O�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O
		function doGetBookp(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// ���w�ǹL�h���ܼ� - ��X ���y���O�N�X & �Z�n�~��, �ӧ�X ���y���O
			var bkcd = document.all("lblbkcd").value;
			var ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			//alert("ym= " + ym);
			myObject.bkcd = document.all("ddlBookCode").value.substring(0, 2);
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
	</body>
</HTML>
