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
<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_empno" HeaderText="業務員"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_totamt" HeaderText="合約總金額"></asp:BoundColumn>
</Columns>
</asp:DataGrid>

     </form>
	
  </body>
</HTML>
