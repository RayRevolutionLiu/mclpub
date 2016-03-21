<%@ Page language="c#" Codebehind="PickRecievers.aspx.cs" Src="PickRecievers.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PickRecievers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<FORM id="Recievers" method="post" runat="server">
			<P>
				<FONT face="新細明體">尋找</FONT>
				<asp:textbox id="tbxSearchKey" runat="server"></asp:textbox>
				<asp:imagebutton id="btnSearch" runat="server"></asp:imagebutton>
				<asp:button id="btnModifyRecDB" runat="server" Text="修改收件人資料庫"></asp:button>
				<INPUT type="button" value="Button" onclick="doSubmit()">
			</P>
			<P>
				<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle BackColor="PaleTurquoise"></SelectedItemStyle>
					<Columns>
						<asp:BoundColumn DataField="or_orid" HeaderText="編號"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid>
			</P>
			<P>
				<asp:TextBox id="tbxXML" runat="server" TextMode="MultiLine" Rows="20" Width="500px"></asp:TextBox>
			</P>
		</FORM>
		<script LANGUAGE="javascript">
var oParam = window.dialogArguments;

function doSubmit()
{
	//oParam.result = xmlDocx.documentElement.cloneNode(true);
	window.returnValue = document.Recievers("tbxXML").value;
	window.close();
}
		</script>
	</body>
</HTML>
