<%@ Page language="c#" Src="mailer_edit.aspx.cs" Codebehind="mailer_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.mailer_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>寄件人資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="mailer_edit" method="post" runat="server">
			<P>
				<FONT title="" face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;共同檔案
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 寄件人資料維護
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 修改寄件人資料
								</FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">新增寄件人資料</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 87px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> 寄件人代碼:
						</P>
					</TD>
					<TD style="WIDTH: 135px">
						<asp:textbox id="ml_mlcd" runat="server" MaxLength="2" Width="25px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ControlToValidate="ml_mlcd" ErrorMessage="必填欄位!"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" Display="Dynamic" ControlToValidate="ml_mlcd" ErrorMessage="請輸入 2 位數字!" ValidationExpression="[0-9]{2}"></asp:regularexpressionvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD colSpan="3">
						<P align="right">
							<FONT color="#ff0000">*&nbsp;<FONT color="#8b4513">為必填欄位 &nbsp;</FONT></FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 87px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> 寄件人姓名:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="ml_nm" runat="server" MaxLength="10" Width="142px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ControlToValidate="ml_nm" ErrorMessage="必填欄位!"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 87px">
					</TD>
					<TD style="WIDTH: 135px">
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
						<P align="right">
							<asp:button id="btnUpdate" runat="server" Height="24px" Text="確定更新"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Height="24px" Text="放棄修改" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
