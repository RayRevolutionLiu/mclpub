<%@ Page language="c#" Codebehind="S_FixCostCenter.aspx.cs" src="S_FixCostCenter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.S_FixCostCenter" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
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
		<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
		<form id="SearchCust1" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 627px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								成本中心異動修正</font>
						</td>
					</tr>
				</table>
				<TABLE style="WIDTH: 640px" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 550px" colSpan="2">
							<font color="white">請確認新成本中心代號後，再進行異動修正!!</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 380px">
							新成本中心代號：
							<asp:textbox id="tbxCostCenterNo" runat="server" Width="180px"></asp:textbox><asp:Button id="Button1" runat="server" Text="確定異動"></asp:Button>
						</TD>
						<td rowSpan="2">
							<asp:label id="Label6" runat="server" ForeColor="DarkRed">請輸入新成本代號，然後按下"確定異動"。<br></asp:label>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入新成本中心代號，不能空白!!" ControlToValidate="tbxCostCenterNo"></asp:RequiredFieldValidator>
						</td>
					</TR>
					<!--<TR>
						<TD style="WIDTH: 347px">
							統一編號：
							<asp:textbox id="tbxMfrno" runat="server" Width="80px"></asp:textbox>
							<asp:Label id="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							訂戶編號：
							<asp:textbox id="tbxCustNo" runat="server" Width="80px"></asp:textbox>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							訂戶姓名：
							<asp:textbox id="tbxCustName" runat="server" Width="99px"></asp:textbox>
							<asp:linkbutton id="lnbShow" runat="server" ForeColor="#C000C0">查詢</asp:linkbutton>
							<asp:LinkButton id="lnbNewMfr" runat="server" ForeColor="Blue" ToolTip="新增廠商資料">新增廠商資料</asp:LinkButton>
							<asp:LinkButton id="lnbNewCust" runat="server" ForeColor="Blue">新增訂戶資料</asp:LinkButton>
						</TD>
					</TR>-->
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px"
								BorderColor="#3366CC" AutoGenerateColumns="False" Runat="server" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399"
									Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:ButtonColumn Text="修改資料" CommandName="Modify"></asp:ButtonColumn>
									<asp:BoundColumn DataField="mfrnm" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_custno" HeaderText="訂戶編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno1" HeaderText="舊工材編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno2" HeaderText="舊電材編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="訂戶姓名">
										<ItemStyle Width="80px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cust_jbti" HeaderText="訂戶職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="聯絡電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_regdate" HeaderText="註冊日期"></asp:BoundColumn>
									<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
			</center>
		</form>
		<!-- 頁尾 Footer -->
		<kw:footer id="Footer" runat="server"></kw:footer>
		<script language="javascript">
		</script>
	</body>
</HTML>
