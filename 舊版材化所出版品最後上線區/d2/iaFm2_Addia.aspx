<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_Addia.aspx.cs" Src="iaFm2_Addia.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_Addia" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���}�߳沣�� - �j��뵲 �B�J�@</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header -->
		<center><kw:header id="Header" runat="server"></kw:header></center>
		<!-- �ثe�Ҧb��m -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�o���}�߳沣�� - �j��뵲 �B�J�@: �D����}�ߤ��������</font>&nbsp;
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_Addia" method="post" runat="server">
			<asp:panel id="pnlQuery" runat="server">
<asp:label id="lblBkcd" runat="server">���y���O�G</asp:label>
<asp:dropdownlist id="ddlBkcd" runat="server"></asp:dropdownlist><BR>
<asp:label id="lblYYYYMM" runat="server">�Z�n�~��G</asp:label>
<asp:textbox id="tbxYYYYMM" runat="server" MaxLength="7" Width="60px"></asp:textbox>&nbsp;<FONT color="darkred" size="2">
					(�w�]�ȡG���A�p2002/08)</FONT><BR>
<asp:label id="lblOrderByFilter" runat="server">�ƧǱ���G</asp:label>
<asp:dropdownlist id="ddlOrderByFilter" runat="server">
					<asp:ListItem Value="1" Selected="True">�X���s��+�����Ǹ�</asp:ListItem>
					<asp:ListItem Value="2">�~�ȭ�</asp:ListItem>
				</asp:dropdownlist><FONT color="#8b0000" size="2">&nbsp; </FONT>
<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>&nbsp; 
<asp:button id="btnClear" runat="server" Text="�M�����d"></asp:button><BR>
<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label>
<asp:textbox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:textbox>&nbsp;&nbsp; 
<INPUT id="hidIAStatus" type="hidden" maxLength="1" size="1" name="hidIAStatus" runat="server">&nbsp; 
<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox><BR>
<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxYYYYMM" ErrorMessage="'�Z�n�~��' �Ш̮榡��J(�аѮ����r����)!!!"></asp:RegularExpressionValidator></asp:panel><br>
			<asp:panel id="pnlPub" runat="server">
<asp:Label id="lblIA" runat="server" ForeColor="Blue" Font-Bold="True">�ثe�i�}�ߤ��������ӡG</asp:Label>
<asp:Button id="btnCheckedAll" runat="server" Text="����"></asp:Button>&nbsp; 
<asp:Button id="btnCheckedClear" runat="server" Text="�M��"></asp:Button><BR>
<asp:Label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J�@�G�ЬD����}�ߪ��������(���n���W�}�ߪ�, �Хh����Ŀ�), �����D�粒, �Ы��U '�D��, �T�{�D��' ���s.</asp:Label><BR>
<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="�D��">
							<ItemTemplate>
								<asp:CheckBox id="cbxChecked" runat="server" Checked="True"></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��">
							<ItemStyle ForeColor="Maroon" Width="60px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="srspn_cname" HeaderText="�~�ȭ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_totamt" HeaderText="�X���`���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_paidamt" HeaderText="�wú���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_restamt" HeaderText="�Ѿl���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="�o�t����H">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pgno" HeaderText="�Z�n���X"></asp:BoundColumn>
						<asp:BoundColumn DataField="ltp_nm" HeaderText="����"></asp:BoundColumn>
						<asp:BoundColumn DataField="clr_nm" HeaderText="��m"></asp:BoundColumn>
						<asp:BoundColumn DataField="pgs_nm" HeaderText="�g�T"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="�T�w����"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_drafttp" HeaderText="�Z�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="njtp_nm" HeaderText="�s�Z�s�k"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fggot" HeaderText="��Z"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgjno" HeaderText="��Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_origjno" HeaderText="�½Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_adamt" HeaderText="�s�i���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgamt" HeaderText="���Z���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_remark" HeaderText="�Ƶ�"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="�~�ȭ��u��"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="pub_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_projno" HeaderText="�p���N��"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_costctr" HeaderText="��������"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
<asp:Label id="lblMemo" runat="server" Font-Size="X-Small" ForeColor="#C04000">���G�˵� '�w�� �o���}�߲M��' ��, �Y�o�{��ƻ~�D, �Ы��U '�D��, �������D' ���s�ӭ��s�D��; �άO������Ʀ��~, �к��@��!</asp:Label><BR>
<asp:Button id="btnConfirmAmt" runat="server" Text="�D��, �T�{�D��"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnPickReset" runat="server" Text="�D��, �������D"></asp:Button><BR><BR>
<asp:label id="lblPickMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label><BR>
<asp:Label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J�G�G�A�˵��� '�w�� �o���}�߲M��' �ýT�{��ƵL�~����, �Ы��U '���� �o���}�߳�' ���s�ӧ����}�߰ʧ@!</asp:Label><BR>
<asp:Button id="btnCreateIA" runat="server" Text="���� �o���}�߳�"></asp:Button>
</asp:panel><br>
			<asp:Panel id="pnlPubProjError" runat="server">
				<asp:Label id="lblMemo3" runat="server" Font-Size="X-Small" ForeColor="#C04000">�H�U������<B>
						�p���N��</B>��<B>��������</B>��Ʀ��~, �Х��ץ��I<br>�ާ@�B�J�G���U '���@�������' �ӭӧO���ק���! �����ק粒��, �ЦA���U '�M�����d' ���s�ӭ��s�}�ߡI</asp:Label>
				<BR>
				<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="���@����" ButtonType="PushButton" HeaderText="���@�������" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��">
							<ItemStyle Width="60px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="srspn_cname" HeaderText="�~�ȭ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_totamt" HeaderText="�X���`���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_paidamt" HeaderText="�wú���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_restamt" HeaderText="�Ѿl���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="�o�t����H">
							<ItemStyle ForeColor="Maroon"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pgno" HeaderText="�Z�n���X"></asp:BoundColumn>
						<asp:BoundColumn DataField="ltp_nm" HeaderText="����"></asp:BoundColumn>
						<asp:BoundColumn DataField="clr_nm" HeaderText="��m"></asp:BoundColumn>
						<asp:BoundColumn DataField="pgs_nm" HeaderText="�g�T"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="�T�w����"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_drafttp" HeaderText="�Z�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="njtp_nm" HeaderText="�s�Z�s�k"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fggot" HeaderText="��Z"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgjno" HeaderText="��Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_origjno" HeaderText="�½Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_adamt" HeaderText="�s�i���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgamt" HeaderText="���Z���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_remark" HeaderText="�Ƶ�"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="�~�ȭ��u��"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="pub_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_bkcd" HeaderText="���y�N�X"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_projno" HeaderText="�p���N��"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_costctr" HeaderText="��������"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</asp:Panel><br>
			<asp:Literal id="Literal1" runat="server"></asp:Literal><br>
		</form>
		<br>
		<!-- ���� Footer -->
		<center><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
