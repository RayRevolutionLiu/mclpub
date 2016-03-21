<%@ Page language="c#" Src="mfr_addnew.aspx.cs" Codebehind="mfr_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.mfr_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廠商資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="mfr_addnew" method="post" runat="server">
			<P>
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;共同檔案
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 廠商資料維護
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 新增廠商資料
								</FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="90%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">新增廠商資料</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="red">* </FONT>資料類別:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:dropdownlist id="ddlmfr_type" runat="server" AutoPostBack="True">
							<asp:ListItem Value="A">廠商 - 統一編號</asp:ListItem>
							<asp:ListItem Value="B">姓名 - 身份證字號</asp:ListItem>
							<asp:ListItem Value="C">姓名 - 資料編號</asp:ListItem>
						</asp:dropdownlist>
					</TD>
					<TD colSpan="3">
						<P align="right">
							<FONT color="#ff0000">* </FONT><FONT color="#8b4513">為必填欄位&nbsp;</FONT><FONT color="#8b4513">&nbsp;</FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="red">* </FONT>
							<asp:label id="lblmfr_mfrno" runat="server">廠商統一編號</asp:label>
							:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_mfrno" runat="server" MaxLength="10" Width="75px"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="mfr_mfrno" ErrorMessage="必填欄位!" Display="Dynamic"></asp:requiredfieldvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD colSpan="3">
						<P align="right">
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="red">* </FONT>
							<asp:label id="lblmfr_inm" runat="server">發票抬頭</asp:label>
							:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="mfr_inm" runat="server" MaxLength="50" Width="270px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="mfr_inm" ErrorMessage="必填欄位!" Display="Dynamic"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							發票地址:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="mfr_iaddr" runat="server" MaxLength="60" Width="370px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							廠商郵遞區號:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="mfr_izip" runat="server" MaxLength="5" Width="42px"></asp:textbox>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" ControlToValidate="mfr_izip" ErrorMessage="只能填寫數字!" Display="Dynamic" ValidationExpression="[0-9]{1,5}"></asp:regularexpressionvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							公司負責人姓名:
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
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							公司負責人職稱:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_respjbti" runat="server" MaxLength="12" Width="100px"></asp:textbox>
					</TD>
					<TD style="WIDTH: 1px">
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							&nbsp;公司聯絡電話:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_tel" runat="server" MaxLength="30"></asp:textbox>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							公司傳真號碼:
						</P>
					</TD>
					<TD style="WIDTH: 345px">
						<asp:textbox id="mfr_fax" runat="server" MaxLength="30"></asp:textbox>
					</TD>
					<TD style="WIDTH: 1px">
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							註冊日期:
						</P>
					</TD>
					<TD style="WIDTH: 356px" colSpan="2">
						<asp:textbox id="mfr_regdate" runat="server" Width="60px"></asp:textbox>
						<FONT color="#696969">(範例:20020101)</FONT>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="mfr_regdate" ErrorMessage="請依範例格式輸入!" Display="Dynamic" ValidationExpression="[0-9]{8}"></asp:regularexpressionvalidator>
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
							<asp:button id="btnAddNew" runat="server" Text="確定新增" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="放棄新增" Height="24px" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
			</FONT><FONT size="2">
				<BR>
			</FONT>
		</form>
	</body>
</HTML>
