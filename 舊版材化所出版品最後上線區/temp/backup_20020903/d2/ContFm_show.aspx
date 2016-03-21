<%@ Page language="c#" Codebehind="ContFm_show.aspx.cs" Src="ContFm_show.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_show" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>顯示合約書</TITLE>
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
			<!-- 關閉視窗按鈕 -->
			<INPUT id="btnCloseWin" onclick="javascript:window.close();" type="button" value="關閉視窗">
			<br>
			<!-- Run at Server Form -->
			<form id="ContFm_show" method="post" runat="server">
				<!--Table 開始-->
				<TABLE cellSpacing="0" cellPadding="4" width="92%" bgColor="#bfcff0" border="0">
					<!-- 廠商及客戶資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(2) 廠商及客戶資料</font>
						</td>
					</TR>
					<!-- 廠商資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" style="WIDTH: 174px" noWrap align="right" bgColor="#bfcff0">
							<FONT color="#cc0099">(2)</FONT> 公司名稱 (廠商統編)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrIName" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon"></asp:label>
							)
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- 公司負責人資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" style="WIDTH: 174px; HEIGHT: 24px" noWrap align="right" bgColor="#bfcff0">
							公司負責人 姓名(職稱)：
						</TD>
						<TD class="cssData" style="HEIGHT: 24px">
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
							&nbsp;<FONT face="新細明體">(
								<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" style="HEIGHT: 24px" noWrap align="right">
							公司電話 (傳真)：
						</TD>
						<TD class="cssData" style="HEIGHT: 24px">
							<asp:label id="lblMfrTel" runat="server"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblMfrFax" runat="server"></asp:label>
								)</FONT>
						</TD>
					</TR>
					<!-- 客戶資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" style="WIDTH: 174px" noWrap align="right" bgColor="#bfcff0">
							客戶姓名 (客戶編號)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server" ForeColor="Maroon"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblCustNo" runat="server" ForeColor="Maroon"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- 合約書基本資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="#ffffff">合約書基本資料&nbsp;&nbsp;</font>&nbsp;
							<asp:label id="lblfgClosedMessage" runat="server" ForeColor="Yellow"></asp:label>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" style="WIDTH: 174px" noWrap align="right" bgcolor="#bfcff0">
							<font color="#cc0099">(1)</font> 簽約日期：
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxSignDate" runat="server" MaxLength="10" Width="65px"></asp:textbox>
							<IMG id="img_signdate" onclick='javascript:pick_date("tbxSignDate");return false;' height="18" alt="查詢日期" src="../images/calendar01.gif" width="18">&nbsp;
							<FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">為必填欄位]</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							合約書編號：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:label id="lblContNo" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" style="WIDTH: 174px" noWrap align="right">
							合約類別：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlContType" runat="server">
								<asp:ListItem Value="01" Selected="True">一般合約</asp:ListItem>
								<asp:ListItem Value="09">推廣合約</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							書籍類別：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" style="WIDTH: 174px" noWrap align="right">
							<font color="#cc0099">(7)</font> 合約起迄日：
						</TD>
						<TD class="cssData" noWrap>
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxStartDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
							&nbsp; <font size="3">~</font> <FONT color="red">*</FONT>
							<asp:textbox id="tbxEndDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
							&nbsp;
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							建檔業務員：
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							一次付清註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							結案註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:RadioButtonList id="rblfgClosed" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							修改業務員：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:DropDownList id="ddlModEmpNo" runat="server"></asp:DropDownList>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							合約註銷註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:RadioButtonList id="rblfgCancel" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							參考合約書編號：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblOldContNo" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							建檔日期：
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;
							<asp:Label id="lblCreateDate" runat="server"></asp:Label>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							最後修改日期：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblModifyDate" runat="server"></asp:Label>
						</TD>
					</TR>
					<!-- 合約書細節 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(9)&nbsp;合約書細節</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
							<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" width="90%" border="0">
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="#cc0099">(9)</font> 總製稿次數：
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										總刊登次數：
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<FONT color="#cc0099">(11)</FONT> 合約總金額：
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT>$
										<asp:textbox id="tbxTotalAmt" runat="server" MaxLength="8" Width="60px"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right" style="HEIGHT: 26px">
										已製稿次數：
									</TD>
									<TD class="cssData" style="HEIGHT: 26px">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxMadeJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right" style="HEIGHT: 26px">
										已刊登次數：
									</TD>
									<TD class="cssData" style="HEIGHT: 26px">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxPubTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right" style="HEIGHT: 26px">
										已繳金額：
									</TD>
									<TD class="cssData" style="HEIGHT: 26px">
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:TextBox id="tbxPaidAmt" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										剩餘製稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										剩餘刊登次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										剩餘未繳金額：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:TextBox id="tbxRestAmt" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="#cc0099">(9)</font> 換稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<FONT color="#cc0099">(9)</FONT> 贈送次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;
									</TD>
									<TD class="cssTitle" align="right">
										<FONT color="#cc0099">(9)</FONT> 優惠折數：
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxDiscount" runat="server" MaxLength="6" Width="40px"></asp:textbox>
										<FONT face="新細明體">折</FONT>
									</TD>
									<TD class="cssTitle" align="right">
										<FONT color="#cc0099">(9)</FONT> 廣告費單價：&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;$
										<asp:TextBox id="tbxADAoumt" runat="server" MaxLength="8" Width="40px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										彩色次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxColorTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										套色次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxGetColorTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										黑白次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;
										<asp:textbox id="tbxMenoTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR> <!-- 廣告聯絡人 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(6) 廣告聯絡人資料</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							<FONT color="#cc0099">(6)</FONT> 廣告聯絡人姓名：
						</TD>
						<TD class="cssData">
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" MaxLength="30" Width="65px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							電話：
						</TD>
						<TD class="cssData">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxAuTel" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							傳真：
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuFax" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							手機：
						</TD>
						<TD class="cssData">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxAuCell" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							Email：
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuEmail" runat="server" MaxLength="80" Width="160px"></asp:textbox>
						</TD>
					</TR>
					<!-- 發票廠商收件人 資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="#ffffff">(3) 發票廠商收件人資料</font>&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Font-Size="XX-Small">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
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
						</TD>
					</TR>
					<!-- 雜誌收件人 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="#ffffff">(4) 雜誌收件人資料</font>&nbsp;&nbsp;
						</td>
					</TR>
					<TR>
						<TD colSpan="4">
							<FONT face="新細明體"></FONT>
							<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
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
							<div align="right">
								<font color="red">有登本數／未登本數 總計：
									<asp:Label id="lblORPunCnt" runat="server" ForeColor="Blue"></asp:Label>
									&nbsp;
									<asp:Label id="lblORUnPubCnt" runat="server" ForeColor="Blue"></asp:Label>
								</font>&nbsp;
							</div>
						</TD>
					</TR>
					<TR bgcolor="#ffffff">
						<TD colSpan="4" align="middle">
							<FONT face="新細明體"></FONT>
							<br>
							<INPUT id="btnCloseWin2" onclick="javascript:window.close();" type="button" value="關閉視窗" name="Button1">
						</TD>
					</TR>
				</TABLE>
			</form>
			<!-- 頁尾 Footer -->
		</center>
	</body>
</HTML>
