<%@ Page language="c#" Codebehind="InvMfrForm.aspx.cs" Src="InvMfrForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvMfrForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增 發票廠商收件人資料</TITLE>
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
		<form id="InvMfrForm" method="post" runat="server">
			<!-- 發票廠商收件人 歷史資料 區 -->
			<font color="#ff0066" size="2">[發票廠商收件人 歷史資料 區]</font>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="修改" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="刪除 " HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<br>
			<!-- 發票廠商收件人 新增/修改資料 區 -->
			<font color="#ff0066" size="2">[發票廠商收件人 新增/修改資料 區]</font>
			<asp:Label id="lblImSeq" runat="server" Font-Size="X-Small"></asp:Label>
			<FONT color="#ff0066" size="2">&nbsp;
				<asp:Label id="lblMfrInfo" runat="server" ForeColor="Blue"></asp:Label>
				&nbsp;
				<asp:Label id="lblMfrNo" runat="server" Visible="False"></asp:Label>
				&nbsp;
				<asp:Label id="lblCustNo" runat="server" Visible="False"></asp:Label>
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
							<FONT color="#c00000" size="2">*</FONT>廠商
							<br>
							統編<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">
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
							<FONT color="#c00000" size="2">*</FONT>發票
							<br>
							類別
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>發票
							<br>
							課稅別
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>院所內
							<br>
							註記
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD>
							<asp:textbox id="tbxIMSysCode" runat="server" Enabled="False" WIDTH="30px" MaxLength="2">C2</asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMContNo" runat="server" Enabled="False" WIDTH="50px" MaxLength="6"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMMfrNo" runat="server" WIDTH="70px" MaxLength="10"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMName" runat="server" WIDTH="70px" MaxLength="30"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMJobTitle" runat="server" WIDTH="70px" MaxLength="12"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMTel" runat="server" WIDTH="90px" MaxLength="30"></asp:textbox>
						</TD>
						<TD align="middle">
							<asp:dropdownlist id="ddlIMInvtp" runat="server">
								<asp:ListItem Value="2">二聯</asp:ListItem>
								<asp:ListItem Value="3" Selected="True">三聯</asp:ListItem>
								<asp:ListItem Value="4">其他</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlIMTaxtp" runat="server">
								<asp:ListItem Value="1" Selected="True">應稅5%</asp:ListItem>
								<asp:ListItem Value="2">零稅</asp:ListItem>
								<asp:ListItem Value="3">免稅</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlIMfgITRI" runat="server">
								<asp:ListItem Value="" Selected="True">否</asp:ListItem>
								<asp:ListItem Value="06">所內</asp:ListItem>
								<asp:ListItem Value="07">院內</asp:ListItem>
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
							發票地址
						</TH>
						<TH>
							傳真
						</TH>
						<TH>
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
							<asp:textbox id="tbxIMZipcode" runat="server" WIDTH="40px" MaxLength="5"></asp:textbox>
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxIMAddr" runat="server" WIDTH="230px" MaxLength="120"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMFax" runat="server" WIDTH="90px" MaxLength="30"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMCell" runat="server" WIDTH="80px" MaxLength="30"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxIMEmail" runat="server" WIDTH="160px" MaxLength="80"></asp:textbox>
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
			<asp:Button id="btnModify" runat="server" Text="儲存修改"></asp:Button>
			&nbsp;&nbsp; <INPUT id="btnClose" type="button" value="關閉視窗" onclick="Javascript:window.close();">
			<br>
		</form>
	</body>
</HTML>
