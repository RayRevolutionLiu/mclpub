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
face=新細明體>
<asp:Label id=lblCaption runat="server" ForeColor="Red"></asp:Label><BR>
<asp:DataGrid id=dgdAdr runat="server" AutoGenerateColumns="False" BackColor="#ECEBFF" Font-Size="X-Small">
<HeaderStyle ForeColor="SteelBlue" BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="adr_contno" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="廣告序號"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_imgurl" HeaderText="檔名"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_drafttp" HeaderText="圖稿類型"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="文字稿"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_urltp" HeaderText="文字稿類型"></asp:BoundColumn>
</Columns>
</asp:DataGrid></FONT></form>
	
  </body>
</HTML>
