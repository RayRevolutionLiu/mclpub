<%@ Page language="c#" Src="srspn_edit.aspx.cs" Codebehind="srspn_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.srspn_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>管理業務人員資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="srspn_edit" method="post" runat="server">
			<P>
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									共同檔案 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									管理業務人員資料維護 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									修改管理業務人員資料 </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="77%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">修改管理業務人員資料</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> 業務人員工號:
						</P>
					</TD>
					<TD style="WIDTH: 285px">
						<asp:textbox id="srspn_empno" runat="server" Width="46px" MaxLength="6"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="srspn_empno" ErrorMessage="必填欄位!" Display="Dynamic"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="srspn_empno" ErrorMessage="請輸入 6 位數字!" Display="Dynamic" ValidationExpression="[0-9]{6}"></asp:regularexpressionvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD colSpan="3">
						<P align="right">
							<FONT color="#ff0033">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位&nbsp;&nbsp;</FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							業務人員姓名:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="srspn_cname" runat="server" Width="142px" MaxLength="10"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							業務人員電話:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="srspn_tel" runat="server" Width="100px" MaxLength="12"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> 業務人員權限別:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlsrspn_atype" runat="server">
							<asp:ListItem Value="A">A - 應用程式開發者</asp:ListItem>
							<asp:ListItem Value="B">B - 主要業務負責人</asp:ListItem>
							<asp:ListItem Value="C">C - 次要業務負責人</asp:ListItem>
							<asp:ListItem Value="D">D - 會計人員</asp:ListItem>
						</asp:dropdownlist>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							業務人員單位別:
						</P>
					</TD>
					<TD style="WIDTH: 285px">
						<asp:dropdownlist id="ddlsrspn_orgcd" runat="server"></asp:dropdownlist>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							業務人員部門別:
						</P>
					</TD>
					<TD style="WIDTH: 285px">
						<asp:textbox id="srspn_deptcd" runat="server" Width="50px" MaxLength="5"></asp:textbox>
					</TD>
					<TD style="WIDTH: 1px">
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							業務人員註冊日:
						</P>
					</TD>
					<TD style="WIDTH: 282px" colSpan="2">
						<asp:textbox id="srspn_date" runat="server" Width="60px" MaxLength="8"></asp:textbox>
						<FONT color="#696969">(範例:20020101)</FONT>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="srspn_date" ErrorMessage="請依範例格式輸入!" Display="Dynamic" ValidationExpression="[0-9]{8}"></asp:regularexpressionvalidator>
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> 業務人員密碼:
						</P>
					</TD>
					<TD style="WIDTH: 282px" colSpan="2">
						<asp:textbox id="srspn_pwd" runat="server" MaxLength="14" Width="120px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="srspn_pwd"></asp:requiredfieldvalidator>
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
						</P>
					</TD>
					<TD style="WIDTH: 285px">
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
