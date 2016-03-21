<%@ Page language="c#" Codebehind="LostSearch.aspx.cs" src="LostSearch.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.LostSearch" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
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
		<form id="LostSearch" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 627px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
								缺書處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">查詢 </font>
						</td>
					</tr>
				</table>
				<TABLE style="WIDTH: 604px" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 550px" colSpan="4">
							<font color="white">訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 104px" align="right">
							訂單編號：
						</TD>
						<td colSpan="3">
							<asp:textbox id="tbxOrderNo" runat="server" Width="100px" MaxLength="13"></asp:textbox>
							(13碼例如：C100000101001)
						</td>
					</TR>
					<TR>
						<TD style="WIDTH: 104px" align="right">
							公司名稱：
						</TD>
						<td style="WIDTH: 232px">
							<asp:textbox id="tbxCompanyname" runat="server" Width="204px"></asp:textbox>
						</td>
						<TD style="WIDTH: 78px" align="right">
							統一編號：
						</TD>
						<td>
							<asp:textbox id="tbxMfrno" runat="server" Width="99px"></asp:textbox>
						</td>
					</TR>
					<TR>
						<TD style="WIDTH: 104px" align="right">
							訂戶編號：
						</TD>
						<td style="WIDTH: 232px">
							<asp:textbox id="tbxCustNo" runat="server" Width="52px" MaxLength="6"></asp:textbox>
						</td>
						<TD style="WIDTH: 78px" align="right">
							訂戶姓名：
						</TD>
						<td>
							<asp:textbox id="tbxCustName" runat="server" Width="99px"></asp:textbox>
						</td>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 550px" colSpan="4">
							<font color="white">收件人資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 104px" align="right">
							收件人姓名：
						</TD>
						<td style="WIDTH: 232px">
							<asp:textbox id="tbxRecName" runat="server" Width="99px"></asp:textbox>
						</td>
						<TD style="WIDTH: 78px" align="right">
							收件人電話：
						</TD>
						<td>
							<asp:textbox id="tbxRecTel" runat="server" Width="99px"></asp:textbox>
						</td>
					</TR>
					<TR>
						<TD style="WIDTH: 104px" align="right">
							收件人地址：
						</TD>
						<td colSpan="3">
							<asp:textbox id="tbxRecAddr" runat="server" Width="431px"></asp:textbox>
						</td>
					</TR>
					<TR>
						<TD style="WIDTH: 104px" align="right">
							寄書狀態：
						</TD>
						<td colSpan="3">
							<asp:RadioButtonList id="rblSent" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="0" Selected="True">未寄出</asp:ListItem>
								<asp:ListItem Value="1">已寄出</asp:ListItem>
							</asp:RadioButtonList>
						</td>
					</TR>
				</TABLE>
				<asp:linkbutton id="lnbSearch" runat="server" ForeColor="#C000C0">查詢</asp:linkbutton>
			</center>
			<CENTER>
				<asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn DataField="orderno" HeaderText="訂單編號">
							<ItemStyle Wrap="False"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp1nm" HeaderText="訂購類別">
							<HeaderStyle Width="28px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="o_date" HeaderText="訂購日期"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="書籍名稱">
							<ItemStyle Width="28px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="序號">
							<ItemStyle Width="10px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="收件人">
							<ItemStyle Width="40px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="od_sdate" HeaderText="訂閱起時"></asp:BoundColumn>
						<asp:BoundColumn DataField="od_edate" HeaderText="訂閱迄時"></asp:BoundColumn>
						<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid>
				<asp:datagrid id="DataGrid2" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:ButtonColumn Text="刪除" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="orderno" HeaderText="訂單編號" ItemStyle-Wrap="False"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_seq" HeaderText="缺書序號">
							<HeaderStyle Width="28px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp1nm" HeaderText="訂購類別一"></asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp2nm" HeaderText="訂購類別二"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="訂戶姓名" ItemStyle-Wrap="False"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_oritem" HeaderText="收件人序號">
							<HeaderStyle Width="40px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_cont" HeaderText="缺書內容"></asp:BoundColumn>
						<asp:ButtonColumn Text="修改資料" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid>
				<asp:label id="lblMessage" runat="server" ForeColor="#C00000" Visible="False"></asp:label>
			</CENTER>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
				event.returnValue=confirm("確認刪除此筆資料?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
