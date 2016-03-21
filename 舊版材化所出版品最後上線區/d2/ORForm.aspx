<%@ Page language="c#" Codebehind="ORForm.aspx.cs" Src="ORForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增/修改/刪除 雜誌收件人資料</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- JScript -->
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
					event.returnValue=confirm("是否確定刪除?")
			}
			document.onclick=Delete_confirm;
		</script>
		<!-- JavaScript -->
		<script language="JavaScript">
			function WindowClose()
			{ 
				// 重新整理 前一頁的動作
				window.opener.RefreshMe(); 
				
				// 關閉本視窗
				window.close();
			}
		</script>
	</HEAD>
	<body>
		<form id="ORForm" method="post" runat="server">
			<!-- 雜誌收件人 歷史資料 區 --><font color="#ff0066" size="2">[雜誌收件人 歷史資料 區]</font>
			<asp:label id="lblMfrInfo" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><FONT color="#ff0066" size="2">&nbsp;
			</FONT>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="載入資料" HeaderText="載入資料" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="郵寄地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_unpubcnt" HeaderText="未登本數"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_mtpcd" HeaderText="郵寄類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fgmosea" HeaderText="海外郵寄"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:label id="lblHistoryMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small" DESIGNTIMEDRAGDROP="424"></asp:label><br>
			<!-- 雜誌收件人 新增/修改資料 區 --><font color="#ff0066" size="2">[雜誌收件人 新增/修改資料 區]</font>
			<asp:textbox id="tbxORSysCode" runat="server" Font-Size="X-Small" MaxLength="2" WIDTH="30px" Enabled="False" Visible="False">C2</asp:textbox><FONT color="#ff0066" size="2">&nbsp;
				<asp:textbox id="tbxORContNo" runat="server" Font-Size="X-Small" MaxLength="6" WIDTH="50px" Enabled="False" Visible="False"></asp:textbox>&nbsp;&nbsp;
				<asp:label id="lblMfrNo" runat="server" Visible="False"></asp:label><asp:label id="lblCustNo" runat="server" Visible="False"></asp:label></FONT><FONT color="#c00000" size="2">欲修改為不同廠商/客戶資料, 
				請按下 <IMG class="ico" id="imgCustDetail" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">圖示來搜尋資料!</FONT>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							序號
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>公司名稱<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>姓名<IMG class="ico" id="Img1" onclick="javascript:window.open('../d5/Cust.aspx>', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">
						</TH>
						<TH>
							職稱
						</TH>
						<TH>
							電話
						</TH>
						<TH>
							有登
							<br>
							本數
						</TH>
						<TH>
							未登
							<br>
							本數
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>郵寄類別
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>海外
							<br>
							郵寄
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD><asp:label id="lblORItem" runat="server" Font-Size="X-Small"></asp:label></TD>
						<TD><asp:textbox id="tbxORMfrIName" runat="server" Font-Size="X-Small" MaxLength="50" Width="80px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORName" runat="server" Font-Size="X-Small" MaxLength="30" Width="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORJobTitle" runat="server" Font-Size="X-Small" MaxLength="12" Width="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORTel" runat="server" Font-Size="X-Small" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORPubCount" runat="server" Font-Size="X-Small" MaxLength="3" WIDTH="30px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORUnPubCount" runat="server" Font-Size="X-Small" MaxLength="3" WIDTH="30px"></asp:textbox></TD>
						<TD><asp:dropdownlist id="ddlORmtpcd" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlORfgmosea" runat="server">
								<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
								<asp:ListItem Value="1">國外</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<!-- 第二行 -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH colSpan="3">
							郵遞區號&nbsp;&amp;&nbsp;&nbsp;郵寄地址
						</TH>
						<TH>
							傳真
						</TH>
						<TH colSpan="2">
							手機
						</TH>
						<TH colSpan="2">
							Email
						</TH>
					</TR>
					<TR bgColor="#e2eafc">
						<TD>&nbsp;
						</TD>
						<TD colSpan="3"><asp:textbox id="tbxORZipcode" runat="server" Font-Size="X-Small" MaxLength="5" Width="40px"></asp:textbox>&nbsp;
							<asp:textbox id="tbxORAddr" runat="server" Font-Size="X-Small" MaxLength="120" WIDTH="230px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORFax" runat="server" Font-Size="X-Small" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD colSpan="2"><asp:textbox id="tbxORCell" runat="server" Font-Size="X-Small" MaxLength="30" WIDTH="80px"></asp:textbox></TD>
						<TD colSpan="2"><asp:textbox id="tbxOREmail" runat="server" Font-Size="X-Small" MaxLength="80" WIDTH="160px"></asp:textbox></TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* 為必填欄位!</FONT>
			<br>
			<asp:button id="btnSave" runat="server" Text="儲存新增"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="儲存修改"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="載入預設資料"></asp:button>&nbsp;
			<asp:button id="btnClearAll" runat="server" Text="清除資料"></asp:button>&nbsp;&nbsp;&nbsp;
			<INPUT id="btnClose" onclick="Javascript:WindowClose();" type="button" value="關閉視窗" name="btnClose">
			<br>
			<br>
			<font color="#ff0066" size="2">[已新增 雜誌收件人資料 區]</font>
			<br>
			<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="修改" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="郵寄地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_unpubcnt" HeaderText="未登本數"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_mtpcd" HeaderText="郵寄類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fgmosea" HeaderText="海外郵寄"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
		<br>
		<font color="darkred" size="2">操作說明：</font>
		<br>
		<font size="2">新增資料-於歷史區, 按 <U>載入資料</U>, 或按 "載入預設資料" 按鈕, 資料確認後, 按 "儲存新增" 按鈕.
			<br>
			修改資料-於已新增區的該資料行, 按下 <U>修改</U>, 資料確認後, 按 "儲存修改" 按鈕.
			<br>
			刪除資料-於已新增區的該資料行, 按下 "<U>刪除</U>" 即可.</font>
		<br>
		<font color="blue" size="2">全部操作完畢, 按 "關閉視窗" 來回到上一頁.</font>
	</body>
</HTML>
