<%@ Page language="c#" Codebehind="adpub_main1.aspx.cs" Src="adpub_main1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告落版資料維護</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<center>
			<!-- 頁首 Header -->
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告落版資料的新增與維護 步驟一</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- 標題 -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">廣告落版資料的新增與維護</FONT></B><FONT color="darkred" size="3">&nbsp;(步驟一: 
					搜尋落版資料;&nbsp;</FONT></B></FONT><FONT color="darkred" size="3"> 目前只提供搜尋及選擇)</FONT></B>&nbsp;
			</DIV>
			<!-- Run at Server Form -->
			<form id="adpub_main" name="adpub_main" method="post" runat="server">
				<!-- 搜尋廠商及客戶的 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">廠商資料</font>
						</td>
					</tr>
					<TR>
						<TD>
							公司名稱：
							<asp:textbox id="tbxMfrName" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
						<td rowSpan="5">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵值來查詢, 然後按下 "查詢".<br><br>
							2. 查出資料後, 按下 "修改資料" 可修改該客戶的資料.<br>3. 查出資料後, 按下 "詳細資料" 可看到該客戶的歷史資料.<br>4. 查出資料後, 按下 "確定" 可進行資料維護工作.</asp:label>
						</td>
					</TR>
					<TR>
						<TD>
							統一編號：
							<asp:textbox id="tbxMfrNo" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							客戶編號：
							<asp:textbox id="tbxCustNo" runat="server" Height="18px" Width="99px"></asp:textbox>
							&nbsp;(須正確的值)
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							客戶姓名：
							<asp:textbox id="tbxCustName" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							合約編號：
							<asp:textbox id="tbxContNo" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							刊登年月：
							<asp:textbox id="tbxPubDate" runat="server" Height="18px" Width="99px"></asp:textbox>
							&nbsp;
							<br>
							(請輸入 2~6碼數字, 如九一年一月, 請輸入&nbsp;9101)
						</TD>
						<!-- 查詢按鈕 -->
						<td>
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>
							&nbsp;
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</td>
					</TR>
					<TR>
						<TD>
							過濾條件：
							<asp:DropDownList id="ddlDataFilter" runat="server" Height="18px">
								<asp:ListItem Value="0" Selected="True">所有資料</asp:ListItem>
								<asp:ListItem Value="1">當月刊登</asp:ListItem>
							</asp:DropDownList>
						</TD>
					</TR>
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" BorderColor="#3366CC" Runat="server" AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:ButtonColumn Text="修改資料" CommandName="Modify"></asp:ButtonColumn>
									<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_date" HeaderText="刊登年月"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_custno" HeaderText="訂戶編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="訂戶姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="聯絡電話"></asp:BoundColumn>
									<asp:ButtonColumn Text="詳細資料" CommandName="Detail"></asp:ButtonColumn>
									<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</BODY>
</HTML>
