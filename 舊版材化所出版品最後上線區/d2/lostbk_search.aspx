<%@ Page language="c#" Codebehind="lostbk_search.aspx.cs" Src="lostbk_search.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk_search" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>缺書處理 步驟一: 查詢</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							缺書處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							步驟一: 查詢</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form-->
			<form id="lostbk_search" method="post" runat="server">
				<TABLE style="WIDTH: 80%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">客戶資料</font>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							合約書編號：
						</TD>
						<td>
							<asp:textbox id="tbxContNo" runat="server" Width="80px"></asp:textbox>
						</td>
						<TD align="right">
							&nbsp;
						</TD>
						<TD>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							公司名稱：
						</TD>
						<TD>
							<asp:textbox id="tbxMfrIName" runat="server" Width="150px"></asp:textbox>
						</TD>
						<TD align="right">
							廠商統編：
						</TD>
						<TD>
							<asp:textbox id="tbxMfrNo" runat="server" Width="60px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							客戶編號：
						</TD>
						<TD>
							<asp:textbox id="tbxCustNo" runat="server" Width="45px" MaxLength="6"></asp:textbox>
							&nbsp;(須正確的值)
						</TD>
						<TD align="right">
							客戶姓名：
						</TD>
						<TD>
							<asp:textbox id="tbxCustName" runat="server" Width="80px"></asp:textbox>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">雜誌收件人資料</font>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							收件人姓名：
						</TD>
						<TD>
							<asp:textbox id="tbxORName" runat="server" Width="80px"></asp:textbox>
						</TD>
						<TD align="right">
							收件人電話：
						</TD>
						<TD>
							<asp:textbox id="tbxORTel" runat="server" Width="100px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							收件人地址：
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxORAddr" runat="server" Width="400px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							寄書狀態：
						</TD>
						<TD colSpan="3">
							<asp:radiobuttonlist id="rblSent" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="0" Selected="True">未寄出</asp:ListItem>
								<asp:ListItem Value="1">已寄出</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
				</TABLE>
				<asp:linkbutton id="lnbSearch" runat="server" ForeColor="#C000C0">查詢</asp:linkbutton>&nbsp;&nbsp;
				<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton>
				<asp:label id="lblMessage" runat="server" ForeColor="#C00000" Visible="False" Font-Size="X-Small"></asp:label>
				<br>
				<br>
				<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" AllowPaging="True">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgclosed" HeaderText="已結案"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="雜收人姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="收件地址"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgpubed" HeaderText="已落版"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgcancel" HeaderText="已註銷"></asp:BoundColumn>
						<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
				</asp:datagrid>
				<br>
				<br>
				<asp:datagrid id="DataGrid2" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:ButtonColumn Text="刪除" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
							<ItemStyle Wrap="False"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="lst_seq" HeaderText="缺書序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名">
							<ItemStyle Wrap="False"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="lst_oritem" HeaderText="雜收人序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_cont" HeaderText="缺書內容"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_date" HeaderText="缺書日期"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_fgsent" HeaderText="已寄出"></asp:BoundColumn>
						<asp:ButtonColumn Text="修改資料" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid></TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
