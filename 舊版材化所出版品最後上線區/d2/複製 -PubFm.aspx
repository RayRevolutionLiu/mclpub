<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="PubFm.aspx.cs" Src="PubFm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���� - �s�W/���@/�R�� �������e</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header -->
		<CENTER><kw:header id="Header" runat="server"></kw:header></CENTER>
		<!-- �ثe�Ҧb��m -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						���� - �s�W/���@/�R������ �B�J�G: �s�W/���@/�R�� �������e</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="PubFm" method="post" runat="server">
			<!-- �w�s�W ������� �� --><FONT color="#ff0066" size="2">[�w�s�W ������� ��]</FONT>
			<asp:label id="lblPubCounts" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><asp:textbox id="tbxSysCode" runat="server" Font-Size="x-Small" DESIGNTIMEDRAGDROP="1502" Enabled="False" WIDTH="30px" MaxLength="2" Visible="False" BorderWidth="0px">C2</asp:textbox><asp:label id="lblContNo" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxContNo" runat="server" Font-Size="x-Small" Enabled="False" WIDTH="50px" MaxLength="6" BorderWidth="0px"></asp:textbox><asp:textbox id="tbxMfrNo" runat="server" Font-Size="X-Small" Enabled="False" MaxLength="10" BorderWidth="0px" Width="150px"></asp:textbox><asp:textbox id="tbxCustNo" runat="server" Font-Size="X-Small" Enabled="False" MaxLength="7" BorderWidth="0px" Width="100px"></asp:textbox><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="�R��" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pno" HeaderText="���y���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="���X"></asp:BoundColumn>
					<asp:BoundColumn DataField="ltp_nm" HeaderText="�s�i����"></asp:BoundColumn>
					<asp:BoundColumn DataField="clr_nm" HeaderText="�s�i��m"></asp:BoundColumn>
					<asp:BoundColumn DataField="pgs_nm" HeaderText="�s�i�g�T"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="�T�w����"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_drafttp" HeaderText="�Z��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fggot" HeaderText="��Z"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_origjno" HeaderText="�½Z���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgjno" HeaderText="��Z���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_adamt" HeaderText="�s�i���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgamt" HeaderText="���Z���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fginved" HeaderText="�w�}�o���}�߳�"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fginvself" HeaderText="�o���H�u�B�z"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="pub_fginved" HeaderText="�w�}�o���}�߳���O"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="pub_fginvself" HeaderText="�o���H�u�B�z���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_projno" HeaderText="�p���N��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_costctr" HeaderText="��������"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="im_fgitri" HeaderText="�|�Ҥ����O�N�X"></asp:BoundColumn>
					<asp:BoundColumn DataField="fgitri_name" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:label id="lblDraftCounts" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><FONT color="#ff0066" size="2">&nbsp;
				<asp:label id="lblAmtCounts" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><INPUT id="hiddenMfrNo" type="hidden" size="3" name="hiddenMfrNo" runat="server">&nbsp;
				<INPUT id="hiddenCustNo" type="hidden" size="3" name="hiddenCustNo" runat="server">
			</FONT>
			<br>
			<asp:label id="lblAddMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><br>
			<!-- ������� �s�W/�ק� �� --><font color="#ff0066" size="2">[������� �s�W/�ק� ��]</font>&nbsp;&nbsp;
			<asp:textbox id="tbxBookName" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="55px"></asp:textbox><asp:textbox id="tbxBkcd" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;
			<asp:label id="lblYYYMMMessage" runat="server" ForeColor="Gray" Font-Size="X-Small">�Z�n�~��X�z�d��G</asp:label><asp:textbox id="tbxStartDate" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="40px"></asp:textbox><font color="gray" size="2">��</font>
			<asp:textbox id="tbxEndDate" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="40px"></asp:textbox><br>
			<asp:label id="lblContMessage" runat="server" ForeColor="Blue" Font-Size="X-Small" Enabled="False" BorderWidth="0px"></asp:label><asp:label id="lblTotjtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxTotjtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;
			<asp:label id="lblTottm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxTottm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;
			<asp:label id="lblChgjtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxChgjtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;&nbsp;&nbsp;
			<asp:label id="lblFreetm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxFreetm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox><font color="gray" size="2">(<IMG class=ico id=imgContDetail onclick="javascript:window.open('ContFm_show.aspx?custno=<% Response.Write(hiddenCustNo.Value); %>&amp;old_contno=<% Response.Write(tbxContNo.Text); %>', '_new', 'Height=470, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt=��ܦX���Ѹ�� src="../images/edit.gif" width=18 border=0 >��ܦX���Ѹ��)</font>
			<br>
			<asp:label id="lblClrtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label>&nbsp;
			<asp:textbox id="tbxClrtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" MaxLength="3" BorderWidth="0px" Width="30px"></asp:textbox>&nbsp;
			<asp:label id="lblGetClrtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label>&nbsp;
			<asp:textbox id="tbxGetClrtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" MaxLength="3" BorderWidth="0px" Width="30px"></asp:textbox>&nbsp;
			<asp:label id="lblMenotm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxMenotm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" MaxLength="3" BorderWidth="0px" Width="30px"></asp:textbox><asp:label id="lblTotamt" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxTotamt" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="60px"></asp:textbox><asp:label id="lblContAdamt" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxContAdamt" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="60px"></asp:textbox>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" width="100%" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							�Ǹ�
						</TH>
						<TH>
							<FONT color="#c00000">*</FONT>�Z�n�~��
							<br>
							<font color="#c00000" size="2">(�ж�d��,
								<br>
								�p 200207)</font>
						</TH>
						<TH>
							<FONT color="#c00000">*</FONT>���y���O
						</TH>
						<TH>
							�Z�n���X
						</TH>
						<TH>
							�s�i���� <IMG class="ico" id="imgLPrior" title="��ܪ����u�����Ǹ��" onclick="doGetLPrior(this)" src="../images/edit.gif" border="0">
						</TH>
						<TH>
							�s�i��m
						</TH>
						<TH>
							�s�i�g�T
						</TH>
						<TH>
							<FONT color="#c00000">*</FONT> �T�w����
						</TH>
						<TH align="left" colSpan="3">
							�o���t�Ӧ���H �m�W
							<br>
							<font color="gray">(�ԲӸ�� <IMG class=ico title="�s�W/�ק�/�R�� �o���t�Ӧ���H" onclick="javascript:window.open('InvMfrForm.aspx?contno=<% Response.Write(tbxContNo.Text); %>&amp;custno=<% Response.Write(hiddenCustNo.Value); %>&amp;old_contno=0&amp;fgnew=1', '_new', 'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" height=18 src="../images/new.gif" border=0 >)</font>
						</TH>
					</TR>
				</THEAD>
				<TR bgColor="#e2eafc">
					<TD><asp:label id="lblPubSeq" runat="server"></asp:label></TD>
					<TD><INPUT id="tbxYYYYMM" onblur="Javascript:CheckYYYYMM(this);" type="text" maxLength="6" onchange="Javascript:CheckYYYYMM2(this);" size="6" name="tbxPubDate" runat="server">
					</TD>
					<TD><INPUT id="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);" type="text" maxLength="4" size="3" name="tbxBkpPno" runat="server">&nbsp;
						<IMG class="ico" id="imgBookpno" title="���y���O�ѦҸ��" onclick="Javascript:doGetBookp(this);" src="../images/edit.gif" border="0">
					</TD>
					<TD align="middle"><asp:textbox id="tbxPageNo" runat="server" MaxLength="3" Width="30px"></asp:textbox></TD>
					<TD><asp:dropdownlist id="ddlLTypeCode" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlColorCode" runat="server"></asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlPageSizeCode" runat="server"></asp:dropdownlist></TD>
					<TD><asp:radiobuttonlist id="rblfgfixpage" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">�O</asp:ListItem>
							<asp:ListItem Value="0">�_</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD colSpan="3"><asp:dropdownlist id="ddlIMSeq" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:imagebutton id="imbIMRefresh" runat="server" AlternateText="���s��z �o���t�Ӧ���H���" ImageUrl="../images/refresh.gif"></asp:imagebutton>&nbsp;
						<asp:label id="lblIMCount" runat="server" ForeColor="Maroon" Font-Size="XX-Small"></asp:label><INPUT id="hiddenIMfgitri" type="hidden" size="3" name="hiddenIMfgitri" runat="server">
					</TD>
				</TR>
				<!-- �ĤG�� -->
				<TR>
					<TH>
						&nbsp;
					</TH>
					<TH align="left" colSpan="2">
						�s�i���B
						<br>
						<font color="#c00000" size="2">(�w�]�P �s�i�O���)</font>
					</TH>
					<TH align="left" colSpan="2">
						���Z���B
					</TH>
					<TH align="left" colSpan="6">
						&nbsp;&nbsp;�Ƶ�
						<br>
						<FONT color="#c00000" size="2">(�̦h��J25�Ӥ���r)</FONT>
					</TH>
				</TR>
				<TR bgColor="#e2eafc">
					<TD>&nbsp;
					</TD>
					<TD colSpan="2"><FONT face="�s�ө���">$</FONT>
						<asp:textbox id="tbxAdAmt" runat="server" MaxLength="10" Width="50px"></asp:textbox></TD>
					<TD align="left" colSpan="2"><FONT face="�s�ө���">$</FONT>
						<asp:textbox id="tbxChgAmt" runat="server" MaxLength="10" Width="50px"></asp:textbox></TD>
					<TD colSpan="6"><asp:textbox id="tbxRemark" runat="server" MaxLength="25" Width="350px"></asp:textbox></TD>
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
						<FONT color="#c00000" size="2">*</FONT>��Z
					</TH>
					<TH>
						�s�Z�s�k
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
					<TD>&nbsp;
					</TD>
					<TD><asp:dropdownlist id="ddlDraftType" runat="server" AutoPostBack="True">
							<asp:ListItem Value="1">�½Z</asp:ListItem>
							<asp:ListItem Value="2">�s�Z</asp:ListItem>
							<asp:ListItem Value="3">��Z</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:radiobuttonlist id="rblfggot" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">�O</asp:ListItem>
							<asp:ListItem Value="0">�_</asp:ListItem>
						</asp:radiobuttonlist>&nbsp;
					</TD>
					<TD><asp:panel id="pnlNjtp" runat="server">
							<asp:DropDownList id="ddlNJTypeCode" runat="server"></asp:DropDownList>
						</asp:panel>&nbsp;
					</TD>
					<TD colSpan="3"><asp:panel id="pnlChg" runat="server">
							<asp:DropDownList id="ddlChgBookCode" runat="server" AutoPostBack="True"></asp:DropDownList>
							<asp:textbox id="tbxChgjno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
							<IMG class="ico" title="��Z���X�ѦҸ��" onclick="doGetPgNo2(this)" src="../images/edit.gif" border="0">
							<asp:textbox id="tbxChgbkno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
						</asp:panel>&nbsp;
					</TD>
					<TD style="BORDER-LEFT-WIDTH: 0px; BORDER-LEFT-COLOR: #e2eafc">&nbsp;
						<asp:radiobuttonlist id="rblfgrechg" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">�O</asp:ListItem>
							<asp:ListItem Value="0">�_</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD colSpan="3"><asp:panel id="pnlOrig" runat="server">
							<asp:DropDownList id="ddlOrigBookCode" runat="server" AutoPostBack="True"></asp:DropDownList>
							<asp:textbox id="tbxOrigjno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
							<IMG class="ico" title="�½Z���X�ѦҸ��" onclick="doGetPgNo1(this)" src="../images/edit.gif" border="0">
							<asp:textbox id="tbxOrigbkno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
						</asp:panel>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<FONT color="#c00000" size="2">* ���������!&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:label id="lblProjCostMessage" runat="server" ForeColor="Navy" Font-Size="X-Small"></asp:label><IMG class="ico" id="imgProjNoCostctr" onclick="javascript:window.open('../d5/proj.aspx', '_new', 'Height=470, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="��ܭp���N�����" src="../images/edit.gif" width="18" border="0"><asp:label id="lblProjNo" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:label>&nbsp;
				<asp:label id="lblCostCtr" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:label><asp:label id="lblfgITRI" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label></FONT><br>
			<asp:button id="btnSave" runat="server" Text="�x�s�s�W"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="�x�s�ק�"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="���J�w�]���"></asp:button>&nbsp;
			<asp:button id="btnGoChkList" runat="server" Text="�e�������ˮ֪�"></asp:button><asp:regularexpressionvalidator id="revPgNo" runat="server" Font-Size="X-Small" ControlToValidate="tbxPageNo" ValidationExpression="\d{0,3}" ErrorMessage="�Z�n���X�������Ʀr���A, �Ч�, �_�h��ƵL�k�s�W!"></asp:regularexpressionvalidator><asp:literal id="litWinOpen1" runat="server"></asp:literal><asp:literal id="litWinAlert1" runat="server"></asp:literal></form>
		<br>
		<!-- ���� Footer -->
		<CENTER><kw:footer id="Footer" runat="server"></kw:footer></CENTER>
		<SCRIPT language="javascript">
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
				var ContStartDate = window.document.all("tbxStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("tbxEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				if(yyyymm<ContStartDate || yyyymm>ContEndDate)
				{
					alert("'�Z�n�~��' �����b�X���_���d��, �Эץ�! \n�_�h�L�k�s�W�������~���!!!");
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
		</SCRIPT>
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
			if(BookPNo == null)
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
			var bkcd = document.all("tbxBkcd").value;
			var ym = document.all("tbxYYYYMM").value;
			myObject.bkcd = document.all("tbxBkcd").value;
			myObject.ym = document.all("tbxYYYYMM").value;
			//alert("myObject.bkcd= " + myObject.bkcd);
			//alert("myObject.ym= " + myObject.ym);
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ myObject
			var PageName = "bookp_get.aspx?bkcd=" + bkcd + "&ym=" + ym;
			//alert("PageName= " + PageName);
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:420px;dialogWidth:350px;dialogLeft:250px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result= " + myObject.result);
			
			if(vreturn)  {
				document.all("tbxBkpPno").value = myObject.result;
				// �ѨM�Y�S��J �Z�n�~���, ������ '���y���O', �ӥZ�n�~�묰�� �����p
				document.all("tbxYYYYMM").value = myObject.yyyymm;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="���y���O�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O
		function doGetLPrior(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// ���w�ǹL�h���ܼ� - ��X ���y���O�N�X & �Z�n�~��, �ӧ�X ���y���O
			var bkcd = document.all("tbxBkcd").value;
			myObject.bkcd = document.all("tbxBkcd").value;
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ myObject
			var PageName = "adlprior_get.aspx?bkcd=" + bkcd;
			vreturn=window.open(PageName,  '_new', 'Height=320, Width=280, Top=120, Left=490, toolbar=no, scrollbars=yes, status=no, resizable=no'); 
		}
		//-->
		</script>
		<!-- �������s��z �\�� (�� ����H����������, �|�I�s�� function) -->
		<script language="javascript">
		function RefreshMe()
		{
			window.PubFm.submit();
		}
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="�½Z���X�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O, �A��X��Z�n���X
		function doGetPgNo1(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// �ǤJ �t�Ӳνs & �½Z���O, �ӰѦҦC�X�Ӽt�� ���Z�n(�üg�^)���Ҧ��������
			// ������J �½Z���O / ��Z���O ��, �۰ʰʥX �½Z���X / ��Z���X �d�ߵ��G
			var mfrno = document.all("hiddenMfrNo").value;
			var bkpno = document.all("tbxOrigjno").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:170px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				document.all("tbxOrigbkno").value = myObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="��Z���X�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O, �A��X��Z�n���X
		// ���q�P�W�q�P, �u�O window.showModalDialog �̪���ܦ�m & vreturn ���P�Ӥw
		function doGetPgNo2(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// �ǤJ �t�Ӳνs & �½Z���O, �ӰѦҦC�X�Ӽt�� ���Z�n(�üg�^)���Ҧ��������
			// ������J �½Z���O / ��Z���O ��, �۰ʰʥX �½Z���X / ��Z���X �d�ߵ��G
			var mfrno = document.all("hiddenMfrNo").value;
			var bkpno = document.all("tbxChgjno").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:170px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				document.all("tbxChgbkno").value = myObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
	</body>
</HTML>
