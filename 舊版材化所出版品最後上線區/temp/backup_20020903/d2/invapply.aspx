<%@ Page language="c#" Codebehind="invapply.aspx.cs" Src="invapply.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.invapply" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���}�ߥӽг�</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<center>
			<!-- ���� Header -->
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�o���}�ߥӽг�</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- ���D -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">�o���}�ߥӽг�</FONT></B>
			</DIV>
			<!-- Run at Server Form -->
			<form ID="invapply" name="invapply" method="post" runat="server">
				<TABLE style="WIDTH: 90%" border="0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<tr bgcolor="white" align="right">
						<td colspan="6">
							�����G 1 / 1
						</td>
					</tr>
					<TR bgcolor="#214389" style="COLOR: #ffffff">
						<TD nowrap>
							<FONT face="�s�ө���">�}�ߤ���G</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">90/11/29</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">&nbsp;</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">&nbsp;</FONT>
						</TD>
						<TD nowrap>
							<FONT face="�s�ө���"><B>�o���}�ߥӽг�s���G</B></FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_iano" runat="server" Height="18px">00000001</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="�s�ө���">���q�W�� (�Τ@�s��)�G</FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_imn" runat="server" Height="18px">�u��|</asp:Label>
							<FONT face="�s�ө���">&nbsp;&nbsp;(</FONT>
							<asp:Label id="lbl_mfrno" runat="server" Height="18px">02750963</asp:Label>
							<FONT face="�s�ө���">)</FONT>
						</TD>
						<TD nowrap>
							<FONT face="�s�ө���">�����N���G</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">
								<asp:Label id="lbl_deptnm" runat="server" Height="18px">��A��</asp:Label>
								&nbsp;(</FONT>
							<asp:Label id="lbl_deptcd" runat="server" Height="18px">SB100</asp:Label>
							<FONT face="�s�ө���">)</FONT>
						</TD>
						<TD nowrap>
							<FONT face="�s�ө���">�~�ȩӿ�H�m�W�G</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">
								<asp:Label id="lbl_cname" runat="server" Height="18px">��f��</asp:Label>
							</FONT>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="�s�ө���">�H�o���a�}�G</FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_rzip" runat="server" Height="18px">300</asp:Label>
							<FONT face="�s�ө���">&nbsp;
								<asp:Label id="lbl_raddr" runat="server" Height="18px">�s�˥�...</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="�s�ө���" color="#ff0000">��B�O�G</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">
								<asp:Label id="lbl_orgcd" runat="server" Height="18px">17</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="�s�ө���"><FONT face="�s�ө���">�~�ȩӿ�H�p���q�ܡG</FONT></FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">
								<asp:Label id="lbl_tel" runat="server" Height="18px">03-5916837</asp:Label>
							</FONT>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="�s�ө���">�o������H�m�W/�ٿסG</FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_rnm" runat="server" Height="18px">���W�R</asp:Label>
							&nbsp;&nbsp;
							<asp:Label id="lbl_rjbti" runat="server" Height="18px">�p�j</asp:Label>
						</TD>
						<TD nowrap>
							�X���s���G
						</TD>
						<TD>
							<asp:Label id="lbl_contno" runat="server" Height="18px">000001</asp:Label>
						</TD>
						<TD nowrap>
							&nbsp;�ӽФH�D�ީm�W / ñ���G
						</TD>
						<TD>
							<FONT face="�s�ө���">&nbsp;</FONT>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="�s�ө���">�o������H�q�ܡG</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">
								<asp:Label id="lbl_rtel" runat="server" Height="18px">03-5732073</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="�s�ө���" color="#ff0000">�p���N��(?)�G</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">
								<asp:Label id="lbl_projyr" runat="server" Height="18px">90</asp:Label>
								&nbsp;
								<asp:Label id="lbl_projno" runat="server" Height="18px">F59C740</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="�s�ө���">�|�p�m�W / ñ���G</FONT>
						</TD>
						<TD>
							<FONT face="�s�ө���">&nbsp;</FONT>
						</TD>
					</TR>
				</TABLE>
				<br>
				<TABLE dataFld="item" id="iad_detail" style="WIDTH: 90%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
					<thead>
						<tr bgColor="#214389">
							<td colSpan="7">
								<font color="white">�ӽг���Ӹ��</font>
							</td>
						</tr>
						<tr borderColor="#bfcff0" bgColor="#bfcff0" align="middle">
							<td nowrap>
								<span dataFld="item"></span>�\��
							</td>
							<td nowrap>
								����
							</td>
							<td nowrap>
								�p���N��
							</td>
							<td nowrap>
								�~�W
							</td>
							<td nowrap>
								�ƶq
							</td>
							<td nowrap>
								���
							</td>
							<td nowrap>
								�`��
							</td>
						</tr>
					</thead>
					<tbody>
						<tr borderColor="#bfcff0" bgColor="#e2eafc" align="middle">
							<td>
								<IMG class="ico" title="�s�W���" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="�s�ө���">&nbsp;</FONT><IMG class="ico" title="�R�����" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
							</td>
							<td>
								<asp:Label dataFld="����" id="lbl_item1" runat="server">1</asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_projno1" runat="server" Height="18px">90F59C730</asp:Label>
							</td>
							<td align="left">
								<asp:Label id="lbl_desc1" runat="server" Height="18px">�u��  �q�\ 2001/06~2002/05 </asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_unit1" runat="server" Height="18px">1</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_uprice1" runat="server" Height="18px">1800</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_amt1" runat="server" Height="18px">$ 2000</asp:Label>
							</td>
						</tr>
						<tr borderColor="#bfcff0" bgColor="#e2eafc" align="middle">
							<td>
								<IMG class="ico" title="�s�W���" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="�s�ө���">&nbsp;</FONT><IMG class="ico" title="�R�����" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
							</td>
							<td>
								<asp:Label dataFld="����" id="lbl_item2" runat="server">2</asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_projno2" runat="server" Height="18px">90F59C710</asp:Label>
							</td>
							<td align="left">
								<asp:Label id="lbl_desc2" runat="server" Height="18px">�u��  ��s�i�O</asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_unit2" runat="server" Height="18px">2</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_uprice2" runat="server" Height="18px">5000</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_amt2" runat="server" Height="18px">$ 1400</asp:Label>
							</td>
						</tr>
						<tr align="middle" valign="top">
							<td nowrap>
								�Ƶ��G
							</td>
							<td nowrap align="left" colspan="6">
								<asp:Label id="lbl_remark" runat="server">*�s�i�Ȥ�... </asp:Label>
							</td>
						<tr align="middle">
							<td nowrap>
								�o�����O�G
							</td>
							<td colspan="2" align="left" nowrap>
								<asp:RadioButtonList id="rab_invtpcd" runat="server" Height="18px" RepeatDirection="Horizontal">
									<asp:ListItem Value="1">�G�p</asp:ListItem>
									<asp:ListItem Value="2" Selected="True">�T�p</asp:ListItem>
									<asp:ListItem Value="3">��L</asp:ListItem>
								</asp:RadioButtonList>
							</td>
							<td nowrap>
								�p�p�G
							</td>
							<td colspan="2">
								&nbsp;
							</td>
							<td colspan="3" nowrap align="right">
								<FONT face="�s�ө���">$ </FONT>
								<asp:Label id="lbl_pyat" runat="server" Height="18px">3400</asp:Label>
							</td>
						</tr>
						<tr align="middle">
							<td nowrap>
								�o������G
							</td>
							<td colspan="2" align="left">
								<asp:Label id="lbl_iasdate" runat="server" Height="18px">90/12/25</asp:Label>
							</td>
							<td nowrap>
								�o���ҵ|�O�G
							</td>
							<td colspan="2" align="left" nowrap>
								<asp:RadioButtonList id="Radiobuttonlist1" runat="server" Height="18px">
									<asp:ListItem Value="1" Selected="True">���| 5%</asp:ListItem>
									<asp:ListItem Value="2">�s�|</asp:ListItem>
									<asp:ListItem Value="3">�K�|</asp:ListItem>
								</asp:RadioButtonList>
							</td>
							<td nowrap align="right">
								<FONT face="�s�ө���">$</FONT>
								<asp:Label id="lbl_txat" runat="server" Height="18px">170</asp:Label>
							</td>
						</tr>
						<tr align="middle">
							<td nowrap>
								�o�����X�G
							</td>
							<td colspan="2" align="left">
								<asp:Label id="lbl_invno" runat="server" Height="18px">FK18733396</asp:Label>
							</td>
							<td nowrap align="middle">
								�P���B (�`�p)�G
							</td>
							<td colspan="2">
								&nbsp;
							</td>
							<td nowrap align="right">
								<FONT face="�s�ө���">$</FONT>
								<asp:Label id="lbl_ivat" runat="server" Height="18px" Font-Bold="True">3570</asp:Label>
							</td>
						</tr>
					</tbody>
					<TFOOT>
						<TR align="left">
							<TD colSpan="8">
								<font color="blue">�z�n, ���F�K��R�ॻ���q�������b�ڪ��ڶ�, �нжQ���q�b<B>�l�H�b��</B>��, �H<B>�䲼</B>���W
									<br>
									<b>&nbsp; (1)</STRONG>&nbsp;�o���}�ߥӽг� (����^ ��
										<br>
										&nbsp; (2) �Q���q�ҭn�R�P���o�����X, ���</b>
									<br>
									<br>
									�䲼���Y�G �u�~���Ƭ�s��
									<br>
									�p���a�}�G �s�˿��˪F�������|�q������������ (�����]�^
									<br>
									�p���q�ܡG (03)591-8205&nbsp;&nbsp;&nbsp; �u�~�������x&nbsp;&nbsp; ����� �p�j ��
									<br>
								</font>
							</TD>
						</TR>
					</TFOOT>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
		</center>
	</BODY>
</HTML>
