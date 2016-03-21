<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="QueryCont.aspx.cs" Src="QueryCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.QueryCont" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body >
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
	
    <form id="QueryCont" method="post" runat="server"><FONT 
face=�s�ө���>
<TABLE dataFld=items id=tbItems>
  <TR>
    <TD style="WIDTH: 100%" align=left><FONT color=#333333 size=2><IMG 
      height=10 src="../images/header/right02.gif" width=10 border=0> &nbsp;�����s�i���t�� 
      <IMG height=10 src="../images/header/right02.gif" width=10 border=0> �X���B�z 
      <IMG height=10 src="../images/header/right02.gif" width=10 border=0> �s�W�X���� 
      �B�J�@: �D�X�Ȥ�</FONT> </TD></TR></TABLE>
<P>
<TABLE cellSpacing=0 cellPadding=2 
bgColor=#bfcff0>
  <TR bgColor=#214389>
    <TD colSpan=2><FONT color=white>�d�߱���</FONT>&nbsp;&nbsp; <FONT 
      color=#ffffff>&nbsp;&nbsp; 
<asp:Label id=lblContTypeCode runat="server" ForeColor="Yellow"></asp:Label></FONT></TD></TR>
  <TR>
    <TD>���q�W�١G 
<asp:textbox id=tbxCompanyName tabIndex=1 runat="server" AutoPostBack="True" Width="150px"></asp:textbox></TD>
    <TD rowSpan=3>
<asp:label id=lblExplain runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
							2. �d�X��ƫ�, ���U "�ק�Ȥ���" �i�ק�ӫȤ᪺���.<br>3. �d�X��ƫ�, ���U "�T�w" �i�~��[�s�W�X����]�B�J, �ña�J�ӫȤ᪺�������.<br>
							<font color="gray">��: �קK���зs�W�t�Ӹ�� - �Х� '��J<U>�t�ӲΤ@�s��</U>��, ���U<U>���䪺���s</U>�Ӭd��!
									<br>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�p�d�L���, �A���U�褧 '<U>�s�W�t�Ӹ��</U>' �ӷs�W�t��!</font></asp:label></TD></TR>
  <TR>
    <TD>�Τ@�s���G 
<asp:textbox id=tbxMfrNo tabIndex=2 runat="server" AutoPostBack="True" Width="60px" MaxLength="10"></asp:textbox>&nbsp; 
      <IMG class=ico id=imgMfrDetail 
      onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(tbxMfrNo.Text.ToString().Trim()); %>', '_new', 'Height=300, Width=400, Top=100, Left=200, toolbar=no, scrollbar=yes, status=no, resizable=no')" 
      alt=�d�߼t�� src="../images/edit.gif" width=18 border=0> </TD></TR>
  <TR>
    <TD noWrap>�Ȥ�s���G 
<asp:textbox id=tbxCustNo tabIndex=3 runat="server" AutoPostBack="True" Width="45px" MaxLength="6"></asp:textbox>&nbsp;(�����T����) 
    </TD></TR>
  <TR>
    <TD>�Ȥ�m�W�G 
<asp:textbox id=tbxCustName tabIndex=4 runat="server" AutoPostBack="True" Width="80px"></asp:textbox>
<asp:linkbutton id=lnbShow runat="server" CausesValidation="False">�d��</asp:linkbutton></TD>
    <TD>
<asp:LinkButton id=lnbNewMfr tabIndex=6 runat="server" ForeColor="Blue" ToolTip="�s�W�t�Ӹ��">�s�W�t�Ӹ��</asp:LinkButton>&nbsp; 
<asp:LinkButton id=lnbNewCust tabIndex=7 runat="server" ForeColor="Blue">�s�W�Ȥ���</asp:LinkButton><BR>
<asp:label id=lblMessage runat="server" ForeColor="Red"></asp:label></TD></TR>
  <TR>
    <TD colSpan=2>
<asp:datagrid id=DataGrid1 Font-Size="XX-Small" AutoGenerateColumns="False" CellPadding="2" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" Runat="server" AllowPaging="True">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:ButtonColumn Text="�ק�Ȥ���" CommandName="Modify"></asp:ButtonColumn>
<asp:BoundColumn Visible="False" DataField="cust_custid" HeaderText="ID"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
<asp:BoundColumn DataField="cust_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="cust_jbti" HeaderText="�Ȥ�¾��"></asp:BoundColumn>
<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
<asp:BoundColumn DataField="cust_regdate" HeaderText="���U���"></asp:BoundColumn>
<asp:BoundColumn DataField="cust_oldcustno" HeaderText="�«Ȥ�s��">
<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
</Columns>
</asp:datagrid></TD></TR></TABLE><!-- Run at Server Form --></P>

     </form></FONT>
	<!-- ���� Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>
	
  </body>
</HTML>
