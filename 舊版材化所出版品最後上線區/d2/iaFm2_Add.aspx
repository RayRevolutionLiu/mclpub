<%@ Page language="c#" Codebehind="iaFm2_Add.aspx.cs" Src="iaFm2_Add.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_Add" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單產生 - 大批月結 步驟一</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<center>
			<kw:header id="Header" runat="server"></kw:header></center>
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						發票開立單產生 - 大批月結 步驟一</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_Add" method="post" runat="server">
			<asp:label id="lblBkcd" runat="server">書籍類別：</asp:label><asp:dropdownlist id="ddlBkcd" runat="server"></asp:dropdownlist><br>
			<asp:label id="lblYYYYMM" runat="server">刊登年月：</asp:label><asp:textbox id="tbxYYYYMM" runat="server" Width="60px" MaxLength="6"></asp:textbox>&nbsp;<font color="darkred" size="2">(預設值：當月，如200208)</font><br>
			<asp:label id="lblOrderByFilter" runat="server">排序條件：</asp:label><asp:dropdownlist id="ddlOrderByFilter" runat="server">
				<asp:ListItem Value="1" Selected="True">合約編號+落版序號</asp:ListItem>
				<asp:ListItem Value="2">業務員</asp:ListItem>
			</asp:dropdownlist><FONT color="#8b0000" size="2">&nbsp; </FONT>
			<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button>&nbsp;
			<asp:button id="btnClear" runat="server" Text="清除重查"></asp:button><br>
			<asp:label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><asp:textbox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:textbox>&nbsp;&nbsp;
			<INPUT id="hidIAStatus" type="hidden" maxLength="1" size="1" name="hidIAStatus" runat="server"><br>
			<br>
			<asp:panel id="pnlPub" runat="server">
<asp:Label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟一：請挑選要開立的落版資料, 挑完按下 '確認金額'.</asp:Label><BR>
<asp:Label id="lblIA" runat="server" ForeColor="Blue" Font-Bold="True">當月落版開立明細：</asp:Label>
<asp:Button id="btnCheckedAll" runat="server" Text="全選"></asp:Button>&nbsp; 
<asp:Button id="btnCheckedClear" runat="server" Text="清選"></asp:Button><BR>
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
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
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
					</Columns>
				</asp:DataGrid>
<asp:Button id="btnConfirmAmt" runat="server" Text="確認金額"></asp:Button><BR></asp:panel><br>
			<asp:panel id="pnlContAmtCount" runat="server">
<asp:Label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟二：請確認此處資料正確, 再按下 '預覽 發票開立單' 繼續.</asp:Label><BR>
<asp:Label id="lblContAmtCount" runat="server" ForeColor="Blue" Font-Bold="True">欲開立金額確認區：</asp:Label><FONT face="新細明體">
					&nbsp;
					<asp:Label id="lblContAmtMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></FONT></FONT>
<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="發廠序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="發廠收件人">
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
						<asp:BoundColumn HeaderText="當月廣告總額">
							<ItemStyle ForeColor="Teal"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn HeaderText="當月換稿總額">
							<ItemStyle ForeColor="Teal"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn HeaderText="當月開立總額">
							<ItemStyle ForeColor="Red"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="業務員工號"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid><BR>
<DIV align="right">
					<asp:Label id="lblSubTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
					<asp:TextBox id="tbxSubTotalAmt" runat="server" Width="80px" Visible="False"></asp:TextBox></DIV>
<asp:Button id="btnGoChklist" runat="server" Text="預覽 發票開立單"></asp:Button><FONT face="新細明體">&nbsp;
					<asp:Button id="btnBackPick" runat="server" Text="回上一步驟 重挑"></asp:Button></FONT><BR></asp:panel></form>
		<br>
		<!-- 頁尾 Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer></center>
		<!-- Javascript -->
		<script language="javascript">
			// 抓出判斷值
			var IAStatus = document.all("hidIAStatus").value;
			//alert("IAStatus= " + IAStatus);
			//if(IAStatus == "1")
			//{
				//window.confirm("該月已做發票開立單挑選或開立動作, 是否要直接預覽其檢核表資料!");
			//}
		</script>
		<script language="JScript">
			function confirm_OK(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="確定")
				{
					var bkcd = document.all("ddlBkcd").value;
					var yyyymm = document.all("tbxYYYYMM").value;
					var iastatus = document.all("hidIAStatus").value;
					var sort = document.all("ddlOrderByFilter").value;
					//alert("bkcd=" + bkcd);
					//alert("yyyymm=" + yyyymm);
					//alert("iastatus=" + iastatus);
					//alert("sort=" + sort);
					if(IAStatus == "1")
					{
						//event.returnValue=confirm("是否確定刪除?")
						event.returnValue=confirm.confirm("該月已做發票開立單挑選或開立動作, 是否要直接預覽其檢核表資料!");
					}
					
					var strbuf = "iaFm2_chklist.aspx?bkcd=" + bkcd + "&yyyymm=" + yyyymm + "&iastatus=" + iastatus + "&sort=" + sort;
					//alert("strbuf=" + strbuf);
					location.href = strbuf;
				}
			}
			document.onclick=confirm_OK;
		</script>
	</body>
</HTML>
