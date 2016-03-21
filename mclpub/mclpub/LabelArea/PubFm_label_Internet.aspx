<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PubFm_label_Internet.aspx.cs" Inherits="mclpub.LabelArea.PubFm_label_Internet" StylesheetTheme="" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>平面廣告標籤 當月刊登</title>
</head>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Label" method="post" runat="server">
        <asp:Panel ID="Panel1" runat="server">

        </asp:Panel>
		</form>
	</body>
<%--<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="PubFm_label" method="post" runat="server">
			<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="95pt" Width="55%"></ItemStyle>
				<ItemTemplate>
                <table>
                    <tr>
                        <td>
					<asp:Label id="lblZip1" runat="server" Font-Bold="True" Font-Size="11">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
						</asp:Label></td>
				        <td><asp:Label id="lblAddr1" runat="server" Width="300" Font-Bold="True" Font-Size="10">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label></td>
                    </tr>
                </table>
                    <BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblORName" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblORName1" runat="server" Font-Names="新細明體">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblContSEDate1" runat="server" Font-Names="新細明體">
							贈閱起迄：
								<%# DataBinder.Eval(Container.DataItem, "ma_sdate") %>~<%# DataBinder.Eval(Container.DataItem, "ma_edate") %></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblPubCnt1" runat="server" Font-Names="新細明體">有登本數：<%# DataBinder.Eval(Container.DataItem, "ma_mnt") %></asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblContNo1" runat="server" Font-Names="新細明體">
								合約編號： <%# DataBinder.Eval(Container.DataItem, "cont_contno") %>&nbsp;&nbsp;(
<asp:Label id="lblConttp1" runat="server" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "cont_conttpName") %>
						</asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %>
							</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblBookName1" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "fc_nm") %>
					</asp:Label>&nbsp;&nbsp;
					<asp:Label id="lblBkpNo1" runat="server"></asp:Label>&nbsp;期
					<BR>
					<asp:Label id=pagevalue1 runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'>
					</asp:Label><BR>
				</ItemTemplate>
			</asp:datalist>
			<asp:datalist id="DataList2" runat="server" RepeatColumns="2" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="5" RepeatDirection="Horizontal">
				<ItemStyle Font-Size="X-Small" Height="130pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="lblORName2" runat="server" Font-Size="10pt" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
						</asp:Label><BR>
					<asp:Label id="lblMfrIName2" runat="server" Font-Size="10pt" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label><BR>
					<asp:Label id="lblORAddr2" runat="server" Width="300" Font-Bold="True" Font-Size="10pt">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label><BR>
					<BR>
					&nbsp;&nbsp;
					<asp:Label id="lblContSEDate2" runat="server" Font-Names="新細明體">
								贈閱起迄： <%# DataBinder.Eval(Container.DataItem, "ma_sdate") %>~<%# DataBinder.Eval(Container.DataItem, "ma_edate") %>&nbsp;&nbsp;&nbsp;&nbsp;
								
							</asp:Label>
					<asp:Label id="lblPubCnt2" runat="server" Font-Names="新細明體">有登本數：<%# DataBinder.Eval(Container.DataItem, "ma_mnt") %></asp:Label><BR>
					&nbsp;&nbsp;
					<asp:Label id="lblContNo2" runat="server" Font-Names="新細明體">
								合約編號： <%# DataBinder.Eval(Container.DataItem, "cont_contno") %></asp:Label>&nbsp;&nbsp; 
					(
					<asp:Label id="lblConttp2" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "cont_conttpName") %>
					</asp:Label>)&nbsp;&nbsp;
					<asp:Label id="lblmtpName2" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %>
					</asp:Label><BR>
					&nbsp;&nbsp;
					<asp:Label id="lblBookName2" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "fc_nm") %>
					</asp:Label>&nbsp;&nbsp;
					<asp:Label id="lblBkpNo2" runat="server"></asp:Label>&nbsp;期<BR>
					<asp:Label id=pagevalue2 runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'>
					</asp:Label>
				</ItemTemplate>
			</asp:datalist>
		</form>
	</body>--%>
</html>
