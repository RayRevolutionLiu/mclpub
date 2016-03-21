<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_Addia.aspx.cs" Src="iaFm2_Addia.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_Addia" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單產生 - 大批月結 步驟一</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<center><kw:header id="Header" runat="server"></kw:header></center>
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						發票開立單產生 - 大批月結 步驟一: 挑選欲開立之落版資料</font>&nbsp;
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_Addia" method="post" runat="server">
			<asp:panel id="pnlQuery" runat="server">
<asp:label id="lblBkcd" runat="server">書籍類別：</asp:label>
<asp:dropdownlist id="ddlBkcd" runat="server"></asp:dropdownlist><BR>
<asp:label id="lblYYYYMM" runat="server">刊登年月：</asp:label>
<asp:textbox id="tbxYYYYMM" runat="server" MaxLength="7" Width="60px"></asp:textbox>&nbsp;<FONT color="darkred" size="2">
					(預設值：當月，如2002/08)</FONT><BR>
<asp:label id="lblOrderByFilter" runat="server">排序條件：</asp:label>
<asp:dropdownlist id="ddlOrderByFilter" runat="server">
					<asp:ListItem Value="1" Selected="True">合約編號+落版序號</asp:ListItem>
					<asp:ListItem Value="2">業務員</asp:ListItem>
				</asp:dropdownlist><FONT color="#8b0000" size="2">&nbsp; </FONT>
<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button>&nbsp; 
<asp:button id="btnClear" runat="server" Text="清除重查"></asp:button><BR>
<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label>
<asp:textbox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:textbox>&nbsp;&nbsp; 
<INPUT id="hidIAStatus" type="hidden" maxLength="1" size="1" name="hidIAStatus" runat="server">&nbsp; 
<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox><BR>
<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxYYYYMM" ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!"></asp:RegularExpressionValidator></asp:panel><br>
			<asp:panel id="pnlPub" runat="server">
<asp:Label id="lblIA" runat="server" ForeColor="Blue" Font-Bold="True">目前可開立之落版明細：</asp:Label>
<asp:Button id="btnCheckedAll" runat="server" Text="全選"></asp:Button>&nbsp; 
<asp:Button id="btnCheckedClear" runat="server" Text="清選"></asp:Button><BR>
<asp:Label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟一：請挑選欲開立的落版資料(不要馬上開立者, 請去除其勾選), 全部挑選完, 請按下 '挑畢, 確認挑選' 按鈕.</asp:Label><BR>
<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="挑選">
							<ItemTemplate>
								<asp:CheckBox id="cbxChecked" runat="server" Checked="True"></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱">
							<ItemStyle ForeColor="Maroon" Width="60px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="srspn_cname" HeaderText="業務員"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_totamt" HeaderText="合約總金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_paidamt" HeaderText="已繳金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_restamt" HeaderText="剩餘金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_imseq" HeaderText="發廠序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="發廠收件人">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pgno" HeaderText="刊登頁碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="ltp_nm" HeaderText="版面"></asp:BoundColumn>
						<asp:BoundColumn DataField="clr_nm" HeaderText="色彩"></asp:BoundColumn>
						<asp:BoundColumn DataField="pgs_nm" HeaderText="篇幅"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="固定頁次"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_drafttp" HeaderText="稿件類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="njtp_nm" HeaderText="新稿製法"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fggot" HeaderText="到稿"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgjno" HeaderText="改稿期別"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_origjno" HeaderText="舊稿期別"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_adamt" HeaderText="廣告金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgamt" HeaderText="換稿金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_remark" HeaderText="備註"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="業務員工號"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="pub_imseq" HeaderText="發廠序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_projno" HeaderText="計劃代號"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_costctr" HeaderText="成本中心"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
<asp:Label id="lblMemo" runat="server" Font-Size="X-Small" ForeColor="#C04000">註：檢視 '預覽 發票開立清單' 時, 若發現資料誤挑, 請按下 '挑錯, 全部重挑' 按鈕來重新挑選; 或是落版資料有誤, 請維護之!</asp:Label><BR>
<asp:Button id="btnConfirmAmt" runat="server" Text="挑畢, 確認挑選"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnPickReset" runat="server" Text="挑錯, 全部重挑"></asp:Button><BR><BR>
<asp:label id="lblPickMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label><BR>
<asp:Label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟二：再檢視完 '預覽 發票開立清單' 並確認資料無誤之後, 請按下 '產生 發票開立單' 按鈕來完成開立動作!</asp:Label><BR>
<asp:Button id="btnCreateIA" runat="server" Text="產生 發票開立單"></asp:Button>
</asp:panel><br>
			<asp:Panel id="pnlPubProjError" runat="server">
				<asp:Label id="lblMemo3" runat="server" Font-Size="X-Small" ForeColor="#C04000">以下落版之<B>
						計劃代號</B>或<B>成本中心</B>資料有誤, 請先修正！<br>操作步驟：按下 '維護落版資料' 來個別完修改資料! 全部修改完畢, 請再按下 '清除重查' 按鈕來重新開立！</asp:Label>
				<BR>
				<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="維護落版" ButtonType="PushButton" HeaderText="維護落版資料" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱">
							<ItemStyle Width="60px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="srspn_cname" HeaderText="業務員"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_totamt" HeaderText="合約總金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_paidamt" HeaderText="已繳金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_restamt" HeaderText="剩餘金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_imseq" HeaderText="發廠序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="發廠收件人">
							<ItemStyle ForeColor="Maroon"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pgno" HeaderText="刊登頁碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="ltp_nm" HeaderText="版面"></asp:BoundColumn>
						<asp:BoundColumn DataField="clr_nm" HeaderText="色彩"></asp:BoundColumn>
						<asp:BoundColumn DataField="pgs_nm" HeaderText="篇幅"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="固定頁次"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_drafttp" HeaderText="稿件類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="njtp_nm" HeaderText="新稿製法"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_fggot" HeaderText="到稿"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgjno" HeaderText="改稿期別"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_origjno" HeaderText="舊稿期別"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_adamt" HeaderText="廣告金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_chgamt" HeaderText="換稿金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_remark" HeaderText="備註"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="業務員工號"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="pub_imseq" HeaderText="發廠序號"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_bkcd" HeaderText="書籍代碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_projno" HeaderText="計劃代號"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_costctr" HeaderText="成本中心"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</asp:Panel><br>
			<asp:Literal id="Literal1" runat="server"></asp:Literal><br>
		</form>
		<br>
		<!-- 頁尾 Footer -->
		<center><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
