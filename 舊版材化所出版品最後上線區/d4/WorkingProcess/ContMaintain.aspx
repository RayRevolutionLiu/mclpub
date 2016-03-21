<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="ContMaintain.aspx.cs" Src="ContMaintain.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContMaintain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="ContMaintain" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										合約處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										維護合約書 步驟三: 維護合約</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD><asp:panel id="pnlContBody" Runat="server" Width="100%">
							<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="TableColorHeader">廠商及客戶資料</TD>
								</TR>
								<TR>
									<TD><!--廠商及客戶資料 -->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">公司名稱(統編)：</TD>
												<TD width="30%">
													<asp:label id="lblMfrNm" runat="server" ForeColor="Maroon">公司名稱</asp:label>(
													<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon">00000000</asp:label>&nbsp; 
													)</TD>
												<TD align="right" width="15%">詳細資料：</TD>
												<TD width="35%"><IMG 
                  onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" 
                  alt=廠商詳細資料 src="../../images/edit.gif" 
name=imgMfrDetail></TD>
											</TR>
											<TR>
												<TD align="right">公司負責人姓名(職稱)：</TD>
												<TD>
													<asp:label id="lblRespData" runat="server" ForeColor="Maroon">負責人(職稱)</asp:label></TD>
												<TD align="right">公司電話(傳真)：</TD>
												<TD>
													<asp:label id="lblMfrTelFax" runat="server" ForeColor="Maroon">00-00000000(Fax: 00-00000000)</asp:label></TD>
											<TR>
												<TD align="right">客戶姓名(編號)：</TD>
												<TD>
													<asp:label id="lblCustNm" runat="server" ForeColor="Maroon">客戶姓名</asp:label>(
													<asp:label id="lblCustNo" runat="server" ForeColor="Maroon">000000</asp:label>&nbsp; 
													)</TD>
												<TD align="right">詳細資料：</TD>
												<TD><IMG 
                  onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" 
                  alt=客戶詳細資料 src="../../images/edit.gif" 
              name=imgCustDetail></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">合約書基本資料</TD>
								</TR>
								<TR>
									<TD><!--合約書基本資料-->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">合約編號：</TD>
												<TD width="30%">
													<asp:label id="lblContNo" runat="server" ForeColor="Maroon">000000</asp:label></TD>
												<TD align="right" width="15%">簽約日期：</TD>
												<TD width="35%">
													<asp:textbox id="tbxSignDate" runat="server" Width="80px" MaxLength="10"></asp:textbox><IMG onclick='javascript:pick_date("tbxSignDate", "tbxSDate", "tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate"></TD>
											</TR>
											<TR>
												<TD align="right">合約類別：</TD>
												<TD>
													<asp:dropdownlist id="ddlContTp" runat="server">
														<asp:ListItem Value="01" Selected="True">一般合約</asp:ListItem>
														<asp:ListItem Value="09">推廣合約</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD align="right">合約起迄日：</TD>
												<TD>
													<asp:textbox id="tbxSDate" runat="server" Width="80px" MaxLength="10"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">&nbsp;～
													<asp:textbox id="tbxEDate" runat="server" Width="80px" MaxLength="10" AutoPostBack="True"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
													<asp:label id="lblDayCount" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="right">已開過發票：</TD>
												<TD>
													<asp:radiobuttonlist id="rblPayOnce" runat="server" RepeatDirection="Horizontal" Enabled="False">
														<asp:ListItem Value="1">是</asp:ListItem>
														<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD align="right">承辦業務員：</TD>
												<TD>
													<asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD align="right">合約備註：</TD>
												<TD colSpan="3">
													<asp:textbox id="tbxRemark" runat="server" Width="273px" MaxLength="50"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">合約書細節</TD>
								</TR>
								<TR>
									<TD><!--合約書細節-->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">刊登次數：</TD>
												<TD width="30%">
													<asp:textbox id="tbxPubTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnPubTm" runat="server"></asp:label>
													<asp:Button id="btnCount" runat="server" Text="計算次數"></asp:Button></TD>
												<TD align="right" width="15%">合約總金額：</TD>
												<TD width="35%">
													<asp:textbox id="tbxTotAmt" runat="server" Width="80px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">贈送次數：</TD>
												<TD>
													<asp:textbox id="tbxFreeTm" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">優惠折數：</TD>
												<TD>
													<asp:textbox id="tbxDisc" runat="server" Width="80px"></asp:textbox>(例: 
													0.8表示八折)</TD>
											</TR>
											<TR>
												<TD align="right">總製圖檔稿次數：</TD>
												<TD>
													<asp:textbox id="tbxTotImgTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnImgTm" runat="server"></asp:label></TD>
												<TD align="right">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD align="right">總製網頁稿次數：</TD>
												<TD>
													<asp:textbox id="tbxTotUrlTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnUrlTm" runat="server"></asp:label></TD>
												<TD align="right">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">廣告聯絡人資料</TD>
								</TR>
								<TR>
									<TD><!--廣告聯絡人資料-->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">廣告聯絡人姓名：</TD>
												<TD width="30%">
													<asp:textbox id="tbxAuNm" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right" width="15%">&nbsp;</TD>
												<TD width="35%">&nbsp;</TD>
											</TR>
											<TR>
												<TD align="right">電話：</TD>
												<TD>
													<asp:textbox id="tbxAuTel" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">傳真：</TD>
												<TD>
													<asp:textbox id="tbxAuFax" runat="server" Width="80px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">手機：</TD>
												<TD>
													<asp:textbox id="tbxAuCell" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">Email：</TD>
												<TD>
													<asp:textbox id="tbxAuEmail" runat="server" Width="150px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">廣告推廣內文、期限、產品設備內文</TD>
								</TR>
								<TR>
									<TD>
										<TABLE class="TableColor" cellSpacing="0" cellPadding="1" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">廣告推廣內文：</TD>
												<TD>
													<asp:textbox id="tbxCCont" runat="server" Width="407px" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">搜尋期限：</TD>
												<TD>
													<asp:textbox id="tbxCsDate" runat="server" Width="80px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxCsDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
													<asp:regularexpressionvalidator id="revCsDate" runat="server" ErrorMessage="格式錯誤，請輸入正確格式" Display="Dynamic" ControlToValidate="tbxCsDate" CssClass="ValidatorStyle" ValidationExpression="[1-2]\d{3}\/[0-2]\d\/[0-3]\d"></asp:regularexpressionvalidator>(如：2002/12/31)</TD>
											</TR>
											<TR>
												<TD align="right">產品設備內文：
												</TD>
												<TD>
													<asp:textbox id="tbxPdCont" runat="server" Width="500px" MaxLength="250" TextMode="MultiLine" Rows="3" Height="94px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">材料特性及應用產業相關資料</TD>
								</TR>
								<TR>
									<TD>
										<TABLE class="TableColor" cellSpacing="0" cellPadding="1" width="100%" border="0">
											<TR>
												<TD vAlign="top" width="50%">材料特性：<IMG 
                  onclick='doOpenMisc(<% Response.Write("\""+lblContNo.Text+"\""); %>, "1")' 
                  alt=ATP_MATP src="../../images/edit.gif" name=imgAtpMatp>
													<asp:datagrid id="dgdAtpMatp1" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2">
														<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
														<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemStyle"></ItemStyle>
														<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="cls2_cname" ReadOnly="True">
																<ItemStyle Wrap="False"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="cls3_cname" ReadOnly="True"></asp:BoundColumn>
														</Columns>
													</asp:datagrid></TD>
												<TD vAlign="top">應用產業：<IMG 
                  onclick='doOpenMisc(<% Response.Write("\""+lblContNo.Text+"\""); %>, "2")' 
                  alt=ATP_MATP src="../../images/edit.gif" name=imgAtpMatp>
													<asp:datagrid id="dgdAtpMatp2" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2">
														<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
														<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemStyle"></ItemStyle>
														<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="cls2_cname" ReadOnly="True">
																<ItemStyle Wrap="False"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="cls3_cname" ReadOnly="True"></asp:BoundColumn>
														</Columns>
													</asp:datagrid></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">雜誌收件人及贈書資料<IMG 
            onclick='doOpenFreeBk(<% Response.Write("\""+ lblCustNo.Text +"\""); %>, <% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\"" + tbxOldContNo.Text + "\""); %>)' 
            alt=詳細 src="..\..\images\new.gif" name=imgAddFreeBk></TD>
								</TR>
								<TR>
									<TD>
										<asp:datagrid id="dgdNewOr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
											<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle" Wrap="False"></HeaderStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-Width="25" DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_inm" HeaderText="公司名稱"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_nm" HeaderText="雜誌收件人姓名"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="or_fgmosea" HeaderText="國外"></asp:BoundColumn>
											</Columns>
										</asp:datagrid>
										<asp:DataGrid id="dgdNewFreeBk" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
											<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-Width="25" DataField="fbk_fbkitem" HeaderText="項次"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-Width="60" DataField="str_ma_sdate" HeaderText="贈書起月"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-Width="60" DataField="str_ma_edate" HeaderText="贈書迄月"></asp:BoundColumn>
												<asp:BoundColumn DataField="fc_nm" HeaderText="書籍"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-Width="60" DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
												<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
												<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerStyle"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">發票廠商基本資料<IMG 
            onclick='doOpenInvMfr(<% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\"" + tbxOldContNo.Text + "\""); %>, <% Response.Write("\"" + lblMfrNo.Text + "\""); %>)' 
            alt=詳細 src="..\..\images\new.gif" name=imgAddInvMfr></TD>
								</TR>
								<TR>
									<TD>
										<asp:datagrid id="dgdNewInvMfr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
											<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-Width="25" DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-Width="60" DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-Width="60" DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_jbti" HeaderText="稱謂"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
												<asp:BoundColumn DataField="invcd" HeaderText="發票類別"></asp:BoundColumn>
												<asp:BoundColumn DataField="taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
												<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD>
										<TABLE borderColor="red" border="1">
											<TR>
												<TD>
													<asp:Label id="Label1" runat="server">合約現況</asp:Label></TD>
												<TD>
													<asp:RadioButtonList id="rblClosed" runat="server" Width="158px" RepeatDirection="Horizontal" Height="14px">
														<asp:ListItem Value="0">進行中</asp:ListItem>
														<asp:ListItem Value="1">已結案</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:Button id="btnSave" runat="server" Text="儲存合約"></asp:Button>
										<asp:Button id="btnNoSave" runat="server" Text="取消儲存"></asp:Button>
										<asp:Button id="btnFgCancel" runat="server" Text="註銷合約" CssClass="AlertButtonStyle"></asp:Button></TD>
								</TR>
								<TR>
									<TD>
										<asp:textbox id="tbxHidMfrNo" runat="server" Width="10px" Visible="False"></asp:textbox>
										<asp:textbox id="tbxHidCustNo" runat="server" Width="10px" Visible="False"></asp:textbox>
										<asp:TextBox id="tbxOldContNo" runat="server" Width="10px" Visible="False"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</asp:panel><asp:panel id="pnlBack" Runat="server" Width="100%">
							<P align="center">
								<asp:Button id="btnHome" Runat="server" Text="回主選單"></asp:Button></P>
						</asp:panel></TD>
				</TR>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="註銷合約")
				event.returnValue=confirm("確定要註銷此合約?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
