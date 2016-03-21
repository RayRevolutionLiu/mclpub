<%@ Page language="c#" Codebehind="ORForm.aspx.cs" Src="ORForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增 雜誌收件人資料</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- JScript -->
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
					event.returnValue=confirm("是否確定刪除?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<form id="ORForm" method="post" runat="server">
			<!-- 雜誌收件人 歷史資料 區 -->
			<font color="#ff0066" size="2">[雜誌收件人 歷史資料 區]</font>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="修改" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_unpubcnt" HeaderText="未登本數"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_mtpcd" HeaderText="郵寄類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fgmosea" HeaderText="海外郵寄"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<br>
			<!-- 雜誌收件人 新增/修改資料 區 -->
			<font color="#ff0066" size="2">[雜誌收件人 新增/修改資料 區]</font>
			<asp:label id="lblORItem" runat="server" Font-Size="X-Small"></asp:label>
			<FONT color="#ff0066" size="2">&nbsp;
				<asp:label id="lblMfrInfo" runat="server" ForeColor="Blue"></asp:label>
				&nbsp;
				<asp:label id="lblMfrNo" runat="server" Visible="False"></asp:label>
				<asp:label id="lblCustNo" runat="server" Visible="False"></asp:label>
			</FONT>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							系統
							<br>
							代碼
						</TH>
						<TH>
							合約書
							<br>
							編號
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>公司名稱<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>姓名<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('../d5/Cust.aspx>', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">
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
						<TD>
							<asp:textbox id="tbxORSysCode" runat="server" MaxLength="2" WIDTH="30px" Font-Size="X-Small" Enabled="False">C2</asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORContNo" runat="server" MaxLength="6" WIDTH="50px" Font-Size="X-Small" Enabled="False"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORMfrIName" runat="server" MaxLength="50" Font-Size="X-Small" Width="80px"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORName" runat="server" MaxLength="30" Font-Size="X-Small" Width="70px"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORJobTitle" runat="server" MaxLength="12" Font-Size="X-Small" Width="70px"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORTel" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORPubCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORUnPubCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORmtpcd" runat="server"></asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORfgmosea" runat="server">
								<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
								<asp:ListItem Value="1">國外</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<!-- 第二行 -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH>
							郵遞
							<br>
							區號
						</TH>
						<TH colSpan="3">
							地址
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
						<TD>
							&nbsp;
						</TD>
						<TD>
							<asp:textbox id="tbxORZipcode" runat="server" MaxLength="5" Font-Size="X-Small" Width="40px"></asp:textbox>
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxORAddr" runat="server" MaxLength="120" WIDTH="230px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORFax" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxORCell" runat="server" MaxLength="30" WIDTH="80px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxOREmail" runat="server" MaxLength="80" WIDTH="160px" Font-Size="X-Small"></asp:textbox>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">註1：* 為必填欄位!</FONT>
			<br>
			<FONT color="#c00000" size="2">註2：預設顯示之廠商資料為該客戶之廠商資料;
				<br>
				欲修改為不同廠商/客戶資料, 請按下 <IMG class="ico" id="imgCustDetail" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">圖示來搜尋資料, 
				再將複製文字帶回本頁貼上!</FONT>
			<br>
			<br>
			<asp:button id="btnSave" runat="server" Text="儲存新增"></asp:button>
			&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="儲存修改"></asp:button>
			&nbsp;&nbsp; <INPUT id="btnClose" onclick="Javascript:window.close();" type="button" value="關閉視窗" name="btnClose">
		</form>
	</body>
</HTML>
