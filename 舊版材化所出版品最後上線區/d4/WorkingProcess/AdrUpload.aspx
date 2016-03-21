<%@ Page language="c#" Codebehind="AdrUpload.aspx.cs" Src="AdrUpload.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrUpload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="AdrUpload" method="post" runat="server" enctype="multipart/form-data">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="500" border="0">
				<TR>
					<TD>
						<asp:Label id="lblFile" runat="server">上傳廣告圖檔：</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<INPUT id="fileUpload" type="file" name="fileUpload" runat="server"></TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="btnUpload" runat="server" Text="上傳"></asp:Button>&nbsp; <INPUT type="button" value="關閉" onclick='javascript:window.close()'></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
