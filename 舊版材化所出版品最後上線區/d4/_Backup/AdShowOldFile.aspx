<%@ Page language="c#" Codebehind="AdShowOldFile.aspx.cs" Src="AdShowOldFile.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdShowOldFile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body bgColor=#bfcff0>
<form id=AdShowOldFile method=post runat="server"><FONT 
face=�s�ө���>
<asp:Label id=lblCaption runat="server" ForeColor="Red"></asp:Label><BR>
<asp:DataGrid id=dgdAdr runat="server" AutoGenerateColumns="False" BackColor="#ECEBFF" Font-Size="X-Small">
<HeaderStyle ForeColor="SteelBlue" BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="adr_contno" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="�s�i�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_imgurl" HeaderText="�ɦW"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_drafttp" HeaderText="�ϽZ����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="��r�Z"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_urltp" HeaderText="��r�Z����"></asp:BoundColumn>
</Columns>
</asp:DataGrid></FONT></form>
	
  </body>
</HTML>
