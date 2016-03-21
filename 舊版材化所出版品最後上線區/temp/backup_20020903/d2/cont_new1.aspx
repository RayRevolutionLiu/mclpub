<%@ Page language="c#" Codebehind="cont_new1.aspx.cs" Src="cont_new1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_new1" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增合約書 步驟一</TITLE>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
			function doDetail()
			{
			//	strFeature = "";
			//	strFeature += "dialogHeight:350px;dialogWidth:600px;center:yes;scroll:yes;status:no;help:no;";
			var vReturn = window.open("CustDetail.aspx?id="); 
			}
		</script>
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<!-- 目前所在位置 -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px; HEIGHT: 24px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							新增合約書 步驟一: 挑出客戶</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form -->
			<form id="cont_new1" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>&nbsp;&nbsp; <FONT color="#ffffff">&nbsp;&nbsp;
								<asp:Label id="lblContTypeCode" runat="server" ForeColor="Yellow"></asp:Label>
							</FONT>
						</td>
					</TR>
					<TR>
						<TD>
							公司名稱：
							<asp:textbox id="tbxCompanyName" runat="server" AutoPostBack="True" tabIndex="1" Width="150px"></asp:textbox>
						</TD>
						<TD rowSpan="3">
							<asp:label id="lblExplain" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
							2. 查出資料後, 按下 "修改客戶資料" 可修改該客戶的資料.<br>3. 查出資料後, 按下 "確定" 可繼續[新增合約書]步驟, 並帶入該客戶的相關資料.<br>
							<font color="gray">註: 避免重覆新增廠商資料 - 請先 '輸入<U>廠商統一編號</U>後, 按下<U>旁邊的按鈕</U>來查詢!
									<br>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如查無資料, 再按下方之 '<U>新增廠商資料</U>' 來新增廠商!</font></asp:label>
						</TD>
					</TR>
					<TR>
						<TD>
							統一編號：
							<asp:textbox id="tbxMfrNo" runat="server" AutoPostBack="True" tabIndex="2" Width="60px" MaxLength="10"></asp:textbox>
							&nbsp; <IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(tbxMfrNo.Text.ToString().Trim()); %>', '_new', 'Height=300, Width=400, Top=100, Left=200, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="查詢廠商" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							客戶編號：
							<asp:textbox id="tbxCustNo" runat="server" AutoPostBack="True" tabIndex="3" Width="45px" MaxLength="6"></asp:textbox>
							&nbsp;(須正確的值)
						</TD>
					</TR>
					<TR>
						<TD>
							客戶姓名：
							<asp:textbox id="tbxCustName" runat="server" AutoPostBack="True" tabIndex="4" Width="80px"></asp:textbox>
							<asp:linkbutton id="lnbShow" runat="server" tabIndex="5">查詢</asp:linkbutton>
						</TD>
						<TD>
							<asp:LinkButton id="lnbNewMfr" runat="server" ForeColor="Blue" ToolTip="新增廠商資料" tabIndex="6">新增廠商資料</asp:LinkButton>
							&nbsp;
							<asp:LinkButton id="lnbNewCust" runat="server" ForeColor="Blue" tabIndex="7">新增客戶資料</asp:LinkButton>
							<br>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:ButtonColumn Text="修改客戶資料" CommandName="Modify"></asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="cust_custid" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_custno" HeaderText="客戶編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_jbti" HeaderText="客戶職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="聯絡電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_regdate" HeaderText="註冊日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="舊客戶編號" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
									<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
