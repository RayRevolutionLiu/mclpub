<%@ Page language="c#" Codebehind="SAPRecovery.aspx.cs" src="SAPRecovery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.SAPRecovery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="SAPRecovery" method="post" runat="server">
			<table id="AutoNumber1" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px" borderColor="#29498c" cellSpacing="0" cellPadding="0" width="100%" bgColor="#29284a" border="1">
				<tr>
					<td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none" width="100%">
						<IMG height="30" src="/mrlpub/images/header/Logo0.jpg" border="0">
					</td>
				</tr>
			</table>
			<table id="table1" width="100%">
				<tr>
					<td width="50%">
						<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							SAP轉檔 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							發票開立單轉SAP回復</FONT>
					</td>
					<td width="50%" align="right">
						<a href="SAP.aspx"><font color="blue">發票開立單轉SAP</font></a>
					</td>
				</tr>
			</table>
			<br>
			<FONT face="新細明體">
				<asp:label id="Label1" runat="server">轉檔年月：</asp:label>
				<asp:TextBox id="lblyyyymm" runat="server" Width="83px" MaxLength="6"></asp:TextBox>
				<asp:Label id="Label3" runat="server" ForeColor="#C00000">(yyyymm例如:200301)</asp:Label><br>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:label id="Label2" runat="server">批次：</asp:label>
				<asp:TextBox id="lblbatchseq" runat="server" Width="83px" MaxLength="6"></asp:TextBox>
				<br>
				<br>
				<asp:button id="btn_Recovery" runat="server" Text="發票開立單轉SAP回復"></asp:button>
				<asp:label id="lblMessage1" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
			</FONT>
		</form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="發票開立單轉SAP回復")
				event.returnValue=confirm("確定要執行發票開立單轉SAP回復?");
		}
		window.document.all("btn_Recovery").onclick=delete_confirm;
		</script>
	</body>
</HTML>
