<%@ Page language="c#" Codebehind="PayListFilter.aspx.cs" src="PayListFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayListFilter" %>
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
		<form id="PayListFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				繳款處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">產生繳款清單
			</FONT>
			<br>
			產生年月：
			<asp:label id="lblyyyymm" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:label>
			批次：
			<asp:label id="lblbatch" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:label>
			總項次：
			<asp:label id="lbltoitem" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:label>
			<asp:button id="btnListPrint" runat="server" Text="列印繳款清單" Enabled="False"></asp:button>
			<br>
			<asp:label id="Label1" runat="server">付款方式：</asp:label>
			<asp:dropdownlist id="ddlPayType" runat="server" AutoPostBack="True"></asp:dropdownlist>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:button id="btnList" runat="server" Text="產生繳款清單" Enabled="False"></asp:button>
			<br>
			<asp:datalist id="DataList1" runat="server" Visible="False" BorderWidth="0px" GridLines="Horizontal" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款日期</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">金額</FONT>
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
								<asp:Label id="lblNo1" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_pyno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblDate" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_date")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblAmt" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "py_amt")%>' Runat="server"></asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<asp:datalist id="DataList2" runat="server" Visible="False" BorderWidth="0px" GridLines="Horizontal" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款日期</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">金額</FONT>
							</TD>
							<TD width="120">
								<FONT color="white">票據號碼</FONT>
							</TD>
							<TD width="100">
								<FONT color="white">付款行</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">到期日</FONT>
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
								<asp:CheckBox id="cbx2" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblNo2" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_pyno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label17" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_date")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label18" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "py_amt")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblChkno" Width="120" text='<%# DataBinder.Eval(Container.DataItem, "py_chkno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblChkbnm" Width="100" text='<%# DataBinder.Eval(Container.DataItem, "py_chkbnm")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblChkdate" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_chkdate")%>' Runat="server"></asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<asp:datalist id="DataList3" runat="server" Visible="False" BorderWidth="0px" GridLines="Horizontal" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款日期</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">金額</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">劃撥單批號</FONT>
							</TD>
							<TD width="30">
								<FONT color="white">劃撥單項次</FONT>
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
								<asp:CheckBox id="cbx3" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblNo3" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_pyno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label3" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_date")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label4" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "py_amt")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblMoseq" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "py_moseq")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblMoitem" Width="30" text='<%# DataBinder.Eval(Container.DataItem, "py_moitem")%>' Runat="server"></asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<asp:datalist id="DataList4" runat="server" Visible="False" BorderWidth="0px" GridLines="Horizontal" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款日期</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">金額</FONT>
							</TD>
							<TD width="120">
								<FONT color="white">電匯帳號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">匯入日期</FONT>
							</TD>
							<TD width="30">
								<FONT color="white">金融代碼</FONT>
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
								<asp:CheckBox id="cbx4" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblNo4" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_pyno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label31" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_date")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label32" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "py_amt")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblWaccno" Width="120" text='<%# DataBinder.Eval(Container.DataItem, "py_waccno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblWdate" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_wdate")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblWbcd" Width="30" text='<%# DataBinder.Eval(Container.DataItem, "py_wbcd")%>' Runat="server"></asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<asp:datalist id="DataList5" runat="server" Visible="False" BorderWidth="0px" GridLines="Horizontal" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">繳款日期</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">金額</FONT>
							</TD>
							<TD width="120">
								<FONT color="white">信用卡卡號</FONT>
							</TD>
							<TD width="50">
								<FONT color="white">授權碼</FONT>
							</TD>
							<TD width="50">
								<FONT color="white">有效年月</FONT>
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
								<asp:CheckBox id="cbx5" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblNo5" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_pyno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label8" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "py_date")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="Label9" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "py_amt")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCcno" Width="120" text='<%# DataBinder.Eval(Container.DataItem, "py_ccno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCcauthcd" Width="50" text='<%# DataBinder.Eval(Container.DataItem, "py_ccauthcd")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCcvdate" Width="50" text='<%# DataBinder.Eval(Container.DataItem, "py_ccvdate")%>' Runat="server"></asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<br>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" Visible="False" BorderWidth="1px" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="py_pyno" HeaderText="繳款編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="繳款日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysdate" HeaderText="繳款清單產生年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysseq" HeaderText="繳款清單批次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysitem" HeaderText="繳款清單項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moseq" HeaderText="劃撥單批號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moitem" HeaderText="項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkno" HeaderText="票據號碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkbnm" HeaderText="付款行"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkdate" HeaderText="到期日"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_waccno" HeaderText="電匯帳號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wdate" HeaderText="匯入日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wbcd" HeaderText="金融代碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccno" HeaderText="信用卡卡號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccauthcd" HeaderText="授權碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccvdate" HeaderText="有效年月"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:literal id="Literal1" runat="server"></asp:literal>
		</form>
	</body>
</HTML>
