<%@ Page language="c#" Src="mfr_edit.aspx.cs" Codebehind="mfr_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.mfr_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�t�Ӹ�ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function pick_date(theField)
		{
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vReturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			if(vReturn)
				window.document.all(theField).value=vReturn;
				return true;
		}
		</script>
	</HEAD>
	<body>
		<form id="mfr_addnew" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�@�P�ɮ�
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �t�Ӹ�ƺ��@
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�ק�t�Ӹ��
								</FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			</FONT>
			<TABLE cellSpacing="1" cellPadding="3" width="90%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4" rowSpan="1">
						<FONT color="#ffffff"><FONT color="#ffffff"><FONT color="#ffffff">�ק�</FONT></FONT>�t�Ӹ��</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px; HEIGHT: 30px">
						<P align="right">
							<FONT color="red">* </FONT>�t�ӲΤ@�s��:
						</P>
					</TD>
					<TD style="WIDTH: 345px; HEIGHT: 30px">
						<asp:Label id="mfr_mfrno" runat="server" ForeColor="#C00000"></asp:Label>
					</TD>
					<TD colSpan="3" style="HEIGHT: 30px">
						<P align="right">
							&nbsp;<FONT color="#ff0000">*&nbsp;<FONT color="#8b4513">���������</FONT>&nbsp; </FONT>
							&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="red">* </FONT>�o�����Y:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="mfr_inm" runat="server" Width="270px" MaxLength="50"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="�������!" ControlToValidate="mfr_inm" Display="Dynamic"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							�o���a�}:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="mfr_iaddr" runat="server" Width="370px" MaxLength="120"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							�t�Ӷl���ϸ�:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="mfr_izip" runat="server" Width="42px" MaxLength="5"></asp:textbox>
						&nbsp;&nbsp;<A href="http://www.post.gov.tw/0-6-1.htm" target="_blank">�l���ϸ��d��</A>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ErrorMessage="�u���g�Ʀr!" ControlToValidate="mfr_izip" Display="Dynamic" ValidationExpression="[0-9]{1,5}"></asp:regularexpressionvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							���q�t�d�H�m�W:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_respnm" runat="server" MaxLength="30"></asp:textbox>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
						<FONT face="�s�ө���"></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							���q�t�d�H¾��:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_respjbti" runat="server" Width="100px" MaxLength="12"></asp:textbox>
						<FONT color="#696969">(��:�Y�L¾�ٮɽп�J"����"��"�p�j")</FONT>
					</TD>
					<TD style="WIDTH: 1px">
					</TD>
					<TD>
						<FONT face="�s�ө���"></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							&nbsp;���q�p���q��:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_tel" runat="server" MaxLength="30"></asp:textbox>
						<FONT color="#696969">(�d��:03-1234567#123)</FONT>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
						<FONT face="�s�ө���"></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							���q�ǯu���X:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_fax" runat="server" MaxLength="30"></asp:textbox>
						<FONT color="#696969">(�d��:03-1234567#123)</FONT>
					</TD>
					<TD style="WIDTH: 1px">
					</TD>
					<TD>
						<FONT face="�s�ө���"></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							���U���:
						</P>
					</TD>
					<TD style="WIDTH: 356px" colSpan="2">
						<asp:textbox id="mfr_regdate" runat="server" Width="60px"></asp:textbox>
						<IMG class="ico" title="���" onclick="pick_date(mfr_regdate.name)" src="../images/calendar01.gif">
						<FONT color="#696969">(�d��:20020101)</FONT>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ErrorMessage="�Ш̽d�Ү榡��J!" ControlToValidate="mfr_regdate" Display="Dynamic" ValidationExpression="[0-9]{8}"></asp:regularexpressionvalidator>
					</TD>
					<TD>
						<P align="right">
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<FONT size="2"></FONT>
					</TD>
					<TD style="WIDTH: 345px">
						<P align="right">
							<FONT size="2"></FONT>
						</P>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
						<P align="right">
							<asp:button id="btnUpdate" runat="server" Height="24px" Text="�T�w��s"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Height="24px" Text="���ק�" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
