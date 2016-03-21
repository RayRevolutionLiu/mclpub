<%@ Page language="c#" Src="refd2_edit.aspx.cs" Codebehind="refd2_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.refd2_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>轉SAP傳票明細摘要檔資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="refd_edit" method="post" runat="server">
			<P>
				<FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									共同檔案 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									轉 SAP 傳票摘要檔資料維護 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									修改轉 SAP 傳票摘要檔資料 </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="77%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">修改轉 SAP 傳票摘要檔資料</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> 系統代碼名稱:
						</P>
					</TD>
					<TD style="WIDTH: 249px">
						<asp:dropdownlist id="ddlrd_syscd" runat="server"></asp:dropdownlist>
					</TD>
					<TD>
						<P align="right">
							<FONT color="#ff0033">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位&nbsp;&nbsp;</FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> 計劃代號:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlrd_projno" runat="server"></asp:dropdownlist>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							成本中心:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="rd_costctr" runat="server" Width="67px" MaxLength="7"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							傳票貸方總帳科目:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="rd_accdcr" runat="server" MaxLength="7" Width="54px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							傳票摘要:
						</P>
					</TD>
					<TD style="WIDTH: 285px" colSpan="2">
						<asp:textbox id="rd_descr" runat="server" MaxLength="50" Width="270px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
					<TD style="WIDTH: 249px">
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
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
