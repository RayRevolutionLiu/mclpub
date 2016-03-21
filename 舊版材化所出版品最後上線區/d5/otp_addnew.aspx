<%@ Page language="c#" Src="otp_addnew.aspx.cs" Codebehind="otp_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.otp_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>訂購類別檔資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="btp_addnew" method="post" runat="server">
			<P>
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									共同檔案 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									訂購類別檔資料維護 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									新增訂購類別檔資料 </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="60%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">新增訂購類別檔資料</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> 訂購類別1名稱:
						</P>
					</TD>
					<TD style="WIDTH: 140px">
						<asp:DropDownList id="ddlotp_otp1cd" runat="server" AutoPostBack="True">
							<asp:ListItem Value="01" Selected="True">訂閱</asp:ListItem>
							<asp:ListItem Value="02">贈閱</asp:ListItem>
							<asp:ListItem Value="03">推廣</asp:ListItem>
							<asp:ListItem Value="09">零售</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD colSpan="3">
						<P align="right">
							<FONT color="#ff0000">*&nbsp;<FONT color="#8b4513">為必填欄位 &nbsp;</FONT></FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> 訂購類別2代碼:
						</P>
					</TD>
					<TD style="WIDTH: 140px">
						<asp:textbox id="otp_otp2cd" runat="server" Width="28px" MaxLength="2"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="必填欄位!" ControlToValidate="otp_otp2cd" Display="Dynamic"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="請輸入 2 位數字!" ControlToValidate="otp_otp2cd" Display="Dynamic" ValidationExpression="[0-9]{2}"></asp:regularexpressionvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD colSpan="3">
						<P align="right">
							
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> 訂購類別2名稱:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="otp_otp2nm" runat="server" Width="268px" MaxLength="20"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="必填欄位!" ControlToValidate="otp_otp2nm" Display="Dynamic"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				
				<TR>
					<TD style="WIDTH: 94px">
					</TD>
					<TD style="WIDTH: 140px">
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
						<P align="right">
							<asp:button id="btnAddNew" runat="server" Text="確定新增" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="放棄新增" Height="24px" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
