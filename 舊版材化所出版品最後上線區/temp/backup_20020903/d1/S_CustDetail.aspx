<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="S_CustDetail.aspx.cs" src="S_CustDetail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.S_CustDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="CustDetail" method="post" runat="server">
			<center>
				<A id="test1" href="javascript:window.history.back()">�^�d�ߵe��</A>
				<asp:button id="btnNew" runat="server" Visible="False" Text="�s�W�ťխq��"></asp:button>
				<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
				<br>
				<asp:label id="lblCaption" runat="server" Visible="False" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:datagrid id="dgdOrder" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" AutoGenerateColumns="False" PageSize="8" AllowPaging="True">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn DataField="od_otp1seq" HeaderText="�q��y����"></asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp1nm" HeaderText="�q�����O�@"></asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp2nm" HeaderText="�q�����O�G"></asp:BoundColumn>
						<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="���y���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="begin_end" HeaderText="�q�\�_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
						<asp:ButtonColumn Text="�ԲӸ��" CommandName="Detail"></asp:ButtonColumn>
						<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid>
				<asp:datagrid id="DataGrid2" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" AutoGenerateColumns="False" PageSize="8" AllowPaging="True">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:ButtonColumn Text="���P�q��" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="od_otp1seq" HeaderText="�q��y����"></asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp1nm" HeaderText="�q�����O�@"></asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp2nm" HeaderText="�q�����O�G"></asp:BoundColumn>
						<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="���y���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="begin_end" HeaderText="�q�\�_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
						<asp:ButtonColumn Text="�ק�q��" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid>
				<asp:literal id="literal1" runat="server"></asp:literal>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		</CENTER>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="���P�q��")
				event.returnValue=confirm("�T�w�n�N�����q����P?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
