<%@ Page language="c#" Codebehind="BulkOrder.aspx.cs" src="BulkOrder.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.BulkOrder" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
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
		<form id="BulkOrder" method="post" runat="server">
			<asp:label id="Label1" runat="server" Font-Size="X-Small">贈閱書籍：</asp:label>
			<asp:dropdownlist id="ddlBook" runat="server"></asp:dropdownlist>
			<br>
			<asp:label id="Label2" runat="server" Font-Size="X-Small">贈閱期間：</asp:label>
			<asp:textbox id="tbxStartDate" runat="server" Width="78px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxStartDate.name)" src="../images/calendar01.gif">
			<asp:label id="Label3" runat="server" Font-Size="X-Small">～</asp:label>
			<asp:textbox id="tbxEndDate" runat="server" Width="78px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxEndDate.name)" src="../images/calendar01.gif">
			<br>
			<asp:label id="Label4" runat="server" Font-Size="X-Small">公司名稱：</asp:label>
			<asp:textbox id="tbxCompanyname" runat="server" Width="267px"></asp:textbox>
			<asp:button id="btnSearch" runat="server" Text="開始搜尋"></asp:button>
			<BR>
			<asp:panel id="Panel1" runat="server" Visible="False">
				<asp:label id="Label5" runat="server" Font-Size="X-Small">續訂到期日：</asp:label>
				<asp:textbox id="tbxContinueDate" runat="server" Width="78px"></asp:textbox>
				<IMG class="ico" title="日曆" onclick="pick_date(tbxContinueDate.name)" src="../images/calendar01.gif">
				<asp:Button id="btnOK" runat="server" Text="確定續訂"></asp:Button>
				<asp:button id="btnCheckAll" runat="server" Text="全選"></asp:button>
			</asp:panel>
			<asp:datalist id="DataList1" runat="server" BorderWidth="1px" GridLines="Horizontal" CellPadding="3" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">流水號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">訂戶編號</FONT>
							</TD>
							<TD width="120">
								<FONT color="white">訂戶姓名</FONT>
							</TD>
							<TD width="200">
								<FONT color="white">公司名稱</FONT>
							</TD>
							<TD width="90">
								<FONT color="white">聯絡電話</FONT>
							</TD>
							<TD>
								<FONT color="white"></FONT>
							</TD>
						</TR>
					</TABLE>
				</HeaderTemplate>
				<EditItemStyle BackColor="Info"></EditItemStyle>
				<SelectedItemTemplate>
					<FONT face="新細明體"></FONT>
				</SelectedItemTemplate>
				<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
				<ItemStyle BorderWidth="1px" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
				<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
				<ItemTemplate>
					<TABLE>
						<TR>
							<TD>
								<asp:CheckBox id="cbx1" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblSeq" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "o_otp1seq")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblNo" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "o_custno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblName" Width="120" text='<%# DataBinder.Eval(Container.DataItem, "cust_nm")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCompanyname" Width="200" text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblTel" Width="90" text='<%# DataBinder.Eval(Container.DataItem, "cust_tel")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<input type="hidden" id="hiddenXml" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "o_xmldata")%>'>
								<asp:LinkButton id="lnbDetail" Runat="server" CommandName="Detail" ForeColor="Blue">詳細資料</asp:LinkButton>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<asp:literal id="literal1" runat="server"></asp:literal>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
		</script>
	</body>
</HTML>
