<%@ Page language="c#" Codebehind="InvMfrForm.aspx.cs" Src="InvMfrForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvMfrForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增/修改/刪除 發票廠商收件人資料</TITLE>
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
		<form id="InvMfrForm" method="post" runat="server">
			<!-- 發票廠商收件人 歷史資料 區 --><FONT color="#ff0066" size="2">[發票廠商收件人 歷史資料 區]&nbsp;&nbsp; </FONT>
			<asp:label id="lblMfrInfo" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:label><FONT color="#ff0066" size="2">&nbsp;
			</FONT>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="載入資料" HeaderText="載入資料" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_addr" HeaderText="發票地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:label id="lblHistoryMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon" DESIGNTIMEDRAGDROP="742"></asp:label><br>
			<!-- 發票廠商收件人 新增/修改資料 區 --><font color="#ff0066" size="2">[發票廠商收件人 新增/修改資料 區]</font>
			<asp:textbox id="tbxIMSysCode" runat="server" Visible="False" MaxLength="2" WIDTH="30px" Enabled="False">C2</asp:textbox><FONT color="#ff0066" size="2">&nbsp;
				<asp:textbox id="tbxIMContNo" runat="server" Visible="False" MaxLength="6" WIDTH="50px" Enabled="False"></asp:textbox>&nbsp;&nbsp;
				<asp:label id="lblMfrNo" runat="server" Visible="False"></asp:label>&nbsp;
				<asp:label id="lblCustNo" runat="server" Visible="False"></asp:label></FONT><FONT color="#c00000" size="2">欲修改為不同廠商/客戶資料, 
				請按下 <IMG class="ico" id="imgCustDetail" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">圖示來搜尋資料!</FONT>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							序號
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>廠商
							<br>
							統編<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">
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
						<TD><asp:label id="lblImSeq" runat="server" Font-Size="X-Small"></asp:label></TD>
						<TD><asp:textbox id="tbxIMMfrNo" runat="server" MaxLength="10" WIDTH="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMName" runat="server" MaxLength="30" WIDTH="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMJobTitle" runat="server" MaxLength="12" WIDTH="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMTel" runat="server" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD><asp:dropdownlist id="ddlIMInvtp" runat="server">
								<asp:ListItem Value="2">二聯</asp:ListItem>
								<asp:ListItem Value="3" Selected="True">三聯</asp:ListItem>
								<asp:ListItem Value="4">其他</asp:ListItem>
								<asp:ListItem Value="9">不清楚</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlIMTaxtp" runat="server">
								<asp:ListItem Value="1" Selected="True">應稅5%</asp:ListItem>
								<asp:ListItem Value="2">零稅</asp:ListItem>
								<asp:ListItem Value="3">免稅</asp:ListItem>
								<asp:ListItem Value="9">不清楚</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlIMfgITRI" runat="server"></asp:dropdownlist></TD>
					</TR>
					<!-- 第二行 -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH colSpan="3">
							郵遞區號&nbsp;&amp;&nbsp;&nbsp;發票地址
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
						<TD>&nbsp;
						</TD>
						<TD colSpan="3"><asp:textbox id="tbxIMZipcode" runat="server" MaxLength="5" WIDTH="40px"></asp:textbox>&nbsp;
							<asp:textbox id="tbxIMAddr" runat="server" MaxLength="120" WIDTH="230px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMFax" runat="server" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMCell" runat="server" MaxLength="30" WIDTH="80px"></asp:textbox></TD>
						<TD colSpan="2"><asp:textbox id="tbxIMEmail" runat="server" MaxLength="80" WIDTH="160px"></asp:textbox></TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* 為必填欄位!&nbsp;&nbsp;(院所內註記資料是依據 '計劃代號' 檔; 若無 '院內往來' 
				選項, 請先至 '共用檔案/計劃代號' 來新增其計劃代號.)<br>
				註：若發票廠商收件人為個人戶(英文字開頭), 則其發票類別將自動更正為 '二聯', 若原資料有誤將提示您已做此修正！</FONT>
			<br>
			<asp:button id="btnSave" runat="server" Text="儲存新增"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="儲存修改"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="載入預設資料"></asp:button>&nbsp;
			<asp:button id="btnClearAll" runat="server" Text="清除資料"></asp:button>&nbsp;&nbsp;
			<INPUT id="btnClose" onclick="Javascript:WindowClose();" type="button" value="關閉視窗" name="btnClose">
			<br>
			<br>
			<font color="#ff0066" size="2">[已新增 發票廠商收件人資料 區]</font>
			<br>
			<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="修改" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="刪除 " HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_addr" HeaderText="發票地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
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
