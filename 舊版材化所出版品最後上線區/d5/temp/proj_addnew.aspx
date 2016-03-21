<%@ Page language="c#" Src="proj_addnew.aspx.cs" Codebehind="proj_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.proj_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>計劃代號資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="proj_addnew" method="post" runat="server">
			<P>
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									共同檔案 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									計劃代號資料維護 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									新增計劃代號資料 </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="65%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">新增計劃代號資料</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> 系統代碼名稱:
						</P>
					</TD>
					<TD style="WIDTH: 212px">
						<asp:dropdownlist id="ddlproj_syscd" runat="server"></asp:dropdownlist>
						&nbsp;<A href="syscd_addnew.aspx" target="">新增系統代碼資料</A></FONT>
					</TD>
					<TD>
						<P align="right">
							<FONT color="#ff0033">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位 &nbsp;</FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							書籍名稱:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:dropdownlist id="ddlproj_bkcd" runat="server"></asp:dropdownlist>
						&nbsp;<A href="book_addnew.aspx" target="">新增書籍資料</A></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							院所內往來註記:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:textbox id="proj_fgitri" runat="server" MaxLength="2" Width="25px"></asp:textbox>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ValidationExpression="[1-9]{2}" ErrorMessage="請輸入 2 位數字!" ControlToValidate="proj_fgitri" Display="Dynamic"></asp:regularexpressionvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> 計劃代號:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:textbox id="proj_projno" runat="server" MaxLength="10" Width="90px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="必填欄位!" ControlToValidate="proj_projno" Display="Dynamic"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							成本中心:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:textbox id="proj_costctr" runat="server" MaxLength="7" Width="67px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							工作說明:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:textbox id="proj_cont" runat="server" MaxLength="12" Width="168px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
					</TD>
					<TD style="WIDTH: 212px">
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD>
						<P align="right">
							<asp:button id="btnAddNew" runat="server" Height="24px" Text="確定新增"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Height="24px" Text="放棄新增" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
