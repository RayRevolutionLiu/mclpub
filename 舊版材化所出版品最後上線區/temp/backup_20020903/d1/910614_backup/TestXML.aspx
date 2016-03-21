<%@ Page language="c#" Codebehind="TestXML.aspx.cs" src="TestXML.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.TestXML" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="TestXML" method="post" runat="server">
			<FONT face="新細明體">訂戶編號</FONT><asp:textbox id="TextBox1" runat="server" Width="73px" Height="24px"></asp:textbox><FONT face="新細明體">訂購類別</FONT>
			<asp:TextBox id="TextBox2" runat="server" Width="73px" Height="24px"></asp:TextBox>
			<FONT face="新細明體">訂單流水號</FONT>
			<asp:TextBox id="TextBox3" runat="server" Width="76px" Height="24px"></asp:TextBox>
			<BR>
			<asp:button id="Button2" runat="server" Text="Save"></asp:button>
			<asp:Button id="Button1" runat="server" Text="Show"></asp:Button>
			<TEXTAREA id="textarea1" name="textarea1" rows="20" cols="90" runat="server"></TEXTAREA>
		</form>
	</body>
</HTML>
