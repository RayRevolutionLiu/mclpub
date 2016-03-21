<%@ Page language="c#" Codebehind="iaFm1_chklist.aspx.cs" Src="iaFm1_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_chklist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>發票開立單檢核表 - 一次付款</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						發票開立單檢核表 - 一次付款</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_chklist" method="post" runat="server">
			&nbsp;
			<asp:button id="btnBack" runat="server" Text="返回首頁"></asp:button>&nbsp;&nbsp;&nbsp;
			<INPUT id="btnPrint" onclick="Javascript:window.print();" type="button" value="列印本頁" name="btnPrint">&nbsp; 
			&nbsp; <INPUT id="btnClose" onclick="Javascript:window.close();" type="button" value="關閉視窗" name="btnClose">&nbsp;&nbsp;&nbsp;
			<asp:button id="btnAddIA" runat="server" Text="繼續開立"></asp:button><br>
			<br>
			<asp:label id="lblCont" runat="server" Font-Bold="True" ForeColor="Blue">合約資料：</asp:label>&nbsp;&nbsp;<asp:label id="lblContMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="發廠序號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="發廠收件人">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="書籍類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="cust_nm" HeaderText="客戶名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_totjtm" HeaderText="總製稿"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_tottm" HeaderText="總刊登"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_totamt" HeaderText="總金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_paidamt" HeaderText="已付金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_restamt" HeaderText="剩餘金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="承辦業務員"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cont_fgclosed" HeaderText="結案註記"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><br>
			<asp:label id="lblIA" runat="server" Font-Bold="True" ForeColor="Blue">已開立之發票資料：</asp:label>&nbsp;&nbsp;
			<asp:label id="lblIAMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><asp:textbox id="tbxIANo" runat="server" Font-Size="X-Small" Width="80px" MaxLength="8" Visible="False"></asp:textbox><asp:datagrid id="DataGrid2" runat="server" Font-Size="8pt" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="發票開立單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="稱謂"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="發票郵寄地址">
						<HeaderStyle Wrap="False"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_iaditem" HeaderText="發票開立單明細序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk1" HeaderText="合約編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk2" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk3" HeaderText="落版序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_desc" HeaderText="品名"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_projno" HeaderText="計劃代號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_costctr" HeaderText="成本中心"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_qty" HeaderText="數量"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_amt" HeaderText="金額"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><br>
		</form>
		<!-- 頁尾 Footer -->
	</body>
</HTML>
