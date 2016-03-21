<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="RecoveryIa.aspx.cs" src="RecoveryIa.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.RecoveryIa" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="RecoveryIa" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				發票處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">發票開立單回復(刪除)
			</FONT>
			<br>
			<asp:button id="btnDeleteIa" runat="server" Text="刪除發票開立單"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datalist id="DataList1" runat="server" BorderWidth="0px" GridLines="Horizontal" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="100">
								<FONT color="white">發票開立單編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">統一編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">發票收件人</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">職稱</FONT>
							</TD>
							<TD width="100">
								<FONT color="white">發票郵寄地址</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">郵遞區號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">電話</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">發票類別</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">課稅別</FONT>
							</TD>
						</TR>
					</TABLE>
				</HeaderTemplate>
				<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
				<ItemStyle BorderWidth="1px" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
				<ItemTemplate>
					<TABLE>
						<TR>
							<TD>
								<asp:CheckBox id="cbx1" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblNo" Width="100" text='<%# DataBinder.Eval(Container.DataItem, "ia_iano")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblMfrno" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_mfrno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblName" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_rnm")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblJob" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_rjbti")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblAddr" Width="100" text='<%# DataBinder.Eval(Container.DataItem, "ia_raddr")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblZip" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_rzip")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblTel" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_rtel")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblInvcd" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_invcd")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblTaxtp" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_taxtp")%>' Runat="server"></asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<br>
			<asp:label id="Label3" runat="server" ForeColor="Blue" Font-Size="X-Small">說明1：<br>此表列示之發票開立單是尚未產生發票開立清單且尚未繳款之資料, <br>已產生發票開立清單或已繳款之發票資料不會在此列示</asp:label>
			<br>
			<asp:label id="Label2" runat="server" ForeColor="Blue" Font-Size="X-Small">說明2：<br>發票類別---2:二聯  3:三聯  4:其他<br>課稅別---1:應稅  2:零稅  3:免稅</asp:label>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除發票開立單")
				event.returnValue=confirm("此動作將會刪除所選的發票開立單及明細, 確定要刪除此筆發票開立單?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
