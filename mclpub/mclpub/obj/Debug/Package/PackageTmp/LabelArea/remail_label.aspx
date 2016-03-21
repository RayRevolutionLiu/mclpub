<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="remail_label.aspx.cs" Inherits="mclpub.LabelArea.remail_label"  StylesheetTheme=""%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Label" method="post" runat="server">
        <asp:Panel ID="Panel1" runat="server">

        </asp:Panel>




<%--				<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" RepeatDirection="Horizontal" BorderWidth="0px" CellSpacing="0" CellPadding="0">
					<ItemStyle Height="1pt" Width="52%"></ItemStyle>
					<ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblZip" runat="server" Font-Bold="True" Font-Size="14pt">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAddr" runat="server" Width="100%" Font-Bold="True" Font-Size="10pt">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                                <asp:Label ID="Label2" runat="server" Font-Names="新細明體" Font-Size="9pt">
							<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
                                </asp:Label><br />
                                <asp:Label ID="Label1" runat="server" Font-Names="新細明體"  Font-Size="9pt">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %></asp:Label>
                                <asp:Label ID="Label3" runat="server" Font-Names="新細明體" Font-Size="9pt"><br />
							訂閱起迄：
								<%# DataBinder.Eval(Container.DataItem, "od_sdate") %>
								~<%# DataBinder.Eval(Container.DataItem, "od_edate") %>&nbsp;&nbsp;&nbsp;&nbsp; 
								份數：<%# DataBinder.Eval(Container.DataItem, "ra_mnt") %></asp:Label>
                                <asp:Label ID="Label6" runat="server" Font-Names="新細明體" Font-Size="9pt"><br />
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "otp_otp2nm") %>)&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Font-Names="新細明體" Font-Size="9pt">
							<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>
                                </asp:Label>
                                &nbsp;&nbsp;
                                <asp:Label ID="lblBookNo1" runat="server" Font-Size="10pt"></asp:Label><br />
                        <asp:Label ID="pagevalue1" runat="server" Font-Size="6pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
                        <p style="page-break-after:always"></p>
                        <br />
                        <br />
					</ItemTemplate>
				</asp:datalist>
				<asp:datalist id="DataList2" runat="server" RepeatColumns="2" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="5" RepeatDirection="Horizontal">
					<ItemStyle Font-Size="X-Small" Height="130pt" Width="55%"></ItemStyle>
					<ItemTemplate>
						<asp:Label id="Label10" runat="server" Font-Names="新細明體" Font-Size="10pt">
							<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
						</asp:Label>
						<BR>
						<asp:Label id="Label9" runat="server" Font-Names="新細明體" Font-Size="10pt">
							<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
						</asp:Label>
						<BR>
						<asp:Label id="lbl_addr" runat="server" Font-Size="10pt" Font-Bold="True" Width="300">
							<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
						</asp:Label>
						<BR>
						<BR>
						&nbsp;&nbsp;
						<asp:Label id="Label11" runat="server" Font-Names="新細明體">
								訂閱起迄： <%# DataBinder.Eval(Container.DataItem, "od_sdate") %>~<%# DataBinder.Eval(Container.DataItem, "od_edate") %>&nbsp;&nbsp;&nbsp;&nbsp;
								份數：<%# DataBinder.Eval(Container.DataItem, "ra_mnt") %></asp:Label>
						<BR>
						&nbsp;&nbsp;
						<asp:Label id="Label12" runat="server" Font-Names="新細明體">
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "otp_otp2nm") %>)&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %></asp:Label>
						<BR>
						&nbsp;&nbsp;
						<asp:Label id="Label13" runat="server" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>
						</asp:Label>
						&nbsp;&nbsp;
						<asp:Label id="lblBookNo2" runat="server"></asp:Label>
						<BR>
						<asp:Label id="pagevalue2" runat="server" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>' Font-Size="5pt"></asp:Label>
					</ItemTemplate>
				</asp:datalist>--%>
		</form>
	</body>
</html>

<%--<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="remail_label" method="post" runat="server">
			<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="108pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="lblZip" runat="server" Font-Bold="True" Font-Size="11">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="lblAddr" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label2" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label1" runat="server" Font-Names="新細明體">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label6" runat="server" Font-Names="新細明體">
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "rm_syscd") %><%# DataBinder.Eval(Container.DataItem, "rm_custno") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1seq") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label4" runat="server" Font-Names="新細明體" Width="300">
						補書內容： <%# DataBinder.Eval(Container.DataItem, "rm_date") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "rm_cont") %>
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="pagevalue1" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
			<asp:datalist id="DataList2" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="144pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Size="11">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="Label5" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label7" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label8" runat="server" Font-Names="新細明體">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label9" runat="server" Font-Names="新細明體">
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "rm_syscd") %><%# DataBinder.Eval(Container.DataItem, "rm_custno") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1seq") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label10" runat="server" Font-Names="新細明體" Width="300">
						補書內容： <%# DataBinder.Eval(Container.DataItem, "rm_date") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "rm_cont") %>
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="Label11" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
		</form>
	</body>
</html>--%>
