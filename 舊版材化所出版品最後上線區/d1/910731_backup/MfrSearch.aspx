<%@ Page language="c#" Codebehind="MfrSearch.aspx.cs" src="MfrSearch.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.MfrSearch" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="MfrSearch" method="post" runat="server">
			<P>
				<INPUT onclick="doClose()" type="button" value="����"> <input id="Hidden1" type="hidden" runat="server" NAME="Hidden1">
				<asp:label id="Label1" runat="server" ForeColor="DarkRed" Font-Size="X-Small">�Ы�[���],�����|�۰�����</asp:label>
				<asp:datagrid id="MfrDataGrid" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#CC9966" BackColor="White" CellPadding="4" Font-Size="X-Small" AllowPaging="True">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="Navy"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#330099" BackColor="#FFFFCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<Columns>
						<asp:ButtonColumn Text="���" CommandName="Select">
							<ItemStyle Wrap="False" ForeColor="Red">
							</ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="mfr_mfrid" HeaderText="�Ǹ�">
							<ItemStyle Width="20px">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�Τ@�s��">
							<ItemStyle Wrap="False">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_iaddr" HeaderText="�o���a�}"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_izip" HeaderText="�l���ϸ�">
							<ItemStyle Width="40px">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_respnm" HeaderText="�t�d�H">
							<ItemStyle Width="60px">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_respjbti" HeaderText="¾��"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_tel" HeaderText="�p���q��">
							<ItemStyle Wrap="False">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_fax" HeaderText="�ǯu���X">
							<ItemStyle Wrap="False">
							</ItemStyle>
						</asp:BoundColumn>
					</Columns>
				</asp:datagrid>
				<input id="Hidden2" type="hidden" runat="server" NAME="Hidden2"> <input id="Hidden3" type="hidden" runat="server" NAME="Hidden3">
				<input id="Hidden4" type="hidden" runat="server" NAME="Hidden4">
			</P>
			<P>
				<asp:Literal id="Literal1" runat="server"></asp:Literal>
				<asp:Literal id="Literal2" runat="server"></asp:Literal>
				<asp:Literal id="Literal3" runat="server"></asp:Literal>
			</P>
		</form>
		<script language="javascript">

function doClose()
{
//	window.opener.document.all(window.document.all("Hidden1").value).value="" + window.document.all("Hidden2").value;
//	window.opener.document.all(window.document.all("Hidden3").value).value="" + window.document.all("Hidden4").value;
	window.close();
}
		</script>
	</body>
</HTML>
