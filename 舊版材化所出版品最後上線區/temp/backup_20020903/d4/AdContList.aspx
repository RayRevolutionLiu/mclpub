<%@ Page language="c#" Codebehind="AdContList.aspx.cs" Src="AdContList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdContList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body >
	
    <form id="AdContList" method="post" runat="server">
<asp:DataGrid id=DataGrid1 runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="#FFFFFF" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_empno" HeaderText="�~�ȭ�"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_totamt" HeaderText="�X���`���B"></asp:BoundColumn>
</Columns>
</asp:DataGrid>

     </form>
	
  </body>
</HTML>
