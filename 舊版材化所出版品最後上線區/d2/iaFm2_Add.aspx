<%@ Page language="c#" Codebehind="iaFm2_Add.aspx.cs" Src="iaFm2_Add.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_Add" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���}�߳沣�� - �j��뵲 �B�J�@</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header -->
		<center>
			<kw:header id="Header" runat="server"></kw:header></center>
		<!-- �ثe�Ҧb��m -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�o���}�߳沣�� - �j��뵲 �B�J�@</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_Add" method="post" runat="server">
			<asp:label id="lblBkcd" runat="server">���y���O�G</asp:label><asp:dropdownlist id="ddlBkcd" runat="server"></asp:dropdownlist><br>
			<asp:label id="lblYYYYMM" runat="server">�Z�n�~��G</asp:label><asp:textbox id="tbxYYYYMM" runat="server" Width="60px" MaxLength="6"></asp:textbox>&nbsp;<font color="darkred" size="2">(�w�]�ȡG���A�p200208)</font><br>
			<asp:label id="lblOrderByFilter" runat="server">�ƧǱ���G</asp:label><asp:dropdownlist id="ddlOrderByFilter" runat="server">
				<asp:ListItem Value="1" Selected="True">�X���s��+�����Ǹ�</asp:ListItem>
				<asp:ListItem Value="2">�~�ȭ�</asp:ListItem>
			</asp:dropdownlist><FONT color="#8b0000" size="2">&nbsp; </FONT>
			<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>&nbsp;
			<asp:button id="btnClear" runat="server" Text="�M�����d"></asp:button><br>
			<asp:label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><asp:textbox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:textbox>&nbsp;&nbsp;
			<INPUT id="hidIAStatus" type="hidden" maxLength="1" size="1" name="hidIAStatus" runat="server"><br>
			<br>
			<asp:panel id="pnlPub" runat="server">
<asp:Label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J�@�G�ЬD��n�}�ߪ��������, �D�����U '�T�{���B'.</asp:Label><BR>
<asp:Label id="lblIA" runat="server" ForeColor="Blue" Font-Bold="True">��븨���}�ߩ��ӡG</asp:Label>
<asp:Button id="btnCheckedAll" runat="server" Text="����"></asp:Button>&nbsp; 
<asp:Button id="btnCheckedClear" runat="server" Text="�M��"></asp:Button><BR>
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
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
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
					</Columns>
				</asp:DataGrid>
<asp:Button id="btnConfirmAmt" runat="server" Text="�T�{���B"></asp:Button><BR></asp:panel><br>
			<asp:panel id="pnlContAmtCount" runat="server">
<asp:Label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J�G�G�нT�{���B��ƥ��T, �A���U '�w�� �o���}�߳�' �~��.</asp:Label><BR>
<asp:Label id="lblContAmtCount" runat="server" ForeColor="Blue" Font-Bold="True">���}�ߪ��B�T�{�ϡG</asp:Label><FONT face="�s�ө���">
					&nbsp;
					<asp:Label id="lblContAmtMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></FONT></FONT>
<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="�o�t����H">
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
						<asp:BoundColumn HeaderText="���s�i�`�B">
							<ItemStyle ForeColor="Teal"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn HeaderText="��봫�Z�`�B">
							<ItemStyle ForeColor="Teal"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn HeaderText="���}���`�B">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="�~�ȭ��u��"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid><BR>
<DIV align="right">
					<asp:Label id="lblSubTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
					<asp:TextBox id="tbxSubTotalAmt" runat="server" Width="80px" Visible="False"></asp:TextBox></DIV>
<asp:Button id="btnGoChklist" runat="server" Text="�w�� �o���}�߳�"></asp:Button><FONT face="�s�ө���">&nbsp;
					<asp:Button id="btnBackPick" runat="server" Text="�^�W�@�B�J ���D"></asp:Button></FONT><BR></asp:panel></form>
		<br>
		<!-- ���� Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer></center>
		<!-- Javascript -->
		<script language="javascript">
			// ��X�P�_��
			var IAStatus = document.all("hidIAStatus").value;
			//alert("IAStatus= " + IAStatus);
			//if(IAStatus == "1")
			//{
				//window.confirm("�Ӥ�w���o���}�߳�D��ζ}�߰ʧ@, �O�_�n�����w�����ˮ֪���!");
			//}
		</script>
		<script language="JScript">
			function confirm_OK(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�T�w")
				{
					var bkcd = document.all("ddlBkcd").value;
					var yyyymm = document.all("tbxYYYYMM").value;
					var iastatus = document.all("hidIAStatus").value;
					var sort = document.all("ddlOrderByFilter").value;
					//alert("bkcd=" + bkcd);
					//alert("yyyymm=" + yyyymm);
					//alert("iastatus=" + iastatus);
					//alert("sort=" + sort);
					if(IAStatus == "1")
					{
						//event.returnValue=confirm("�O�_�T�w�R��?")
						event.returnValue=confirm.confirm("�Ӥ�w���o���}�߳�D��ζ}�߰ʧ@, �O�_�n�����w�����ˮ֪���!");
					}
					
					var strbuf = "iaFm2_chklist.aspx?bkcd=" + bkcd + "&yyyymm=" + yyyymm + "&iastatus=" + iastatus + "&sort=" + sort;
					//alert("strbuf=" + strbuf);
					location.href = strbuf;
				}
			}
			document.onclick=confirm_OK;
		</script>
	</body>
</HTML>
