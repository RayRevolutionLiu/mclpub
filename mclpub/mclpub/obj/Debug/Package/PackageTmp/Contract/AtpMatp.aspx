<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtpMatp.aspx.cs" Inherits="mclpub.Contract.AtpMatp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>材料所出版品客戶管理系統</title>	
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <span class="stripeMe">
    <span>
        <asp:dropdownlist id="ddlClass1" runat="server">
        <asp:ListItem Value="1">材料特性</asp:ListItem>
        <asp:ListItem Value="2">應用產業</asp:ListItem>
        </asp:dropdownlist>
        <asp:button id="btnSave1" runat="server" Text="儲存" onclick="btnSave1_Click"></asp:button>&nbsp;&nbsp; <INPUT onclick="javascript:window.close();" type="button" value="關閉" name="btnClose1" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
    </span>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    			<TABLE  cellSpacing="0" cellPadding="0" width="100%" border="0" class="font_blacklink font_size13">
				<TR>
					<TD vAlign="top">
					<asp:datalist id="dlClass21" runat="server" Width="100%" 
                            onitemcommand="dlClass21_ItemCommand">
							<ItemTemplate>
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<th align="left">
											<asp:Label id="lblClass21" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cname") %>'>
											</asp:Label>
											<asp:TextBox id="tbxClass21" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cls2id") %>' Width="10px" Visible="False">
											</asp:TextBox>
											<asp:LinkButton id="lnkSelectAll21" runat="server" ForeColor="Yellow" CommandName="Command1">全選</asp:LinkButton>
											<asp:LinkButton id="lnkSelectAll21Cancel" runat="server" ForeColor="Aquamarine" CommandName="Command2">清除</asp:LinkButton>
											
									</th>
									<TR>
										<TD>
											<asp:checkboxlist id="cblClass321" runat="server" Width="100%" DataValueField="cls3_cls3id" DataTextField="cls3_cname" RepeatColumns="4" RepeatDirection="Horizontal"></asp:checkboxlist></TD>
									</TR>
								</TABLE>
								<br />
							</ItemTemplate>
						</asp:datalist>
						</TD>
				</TR>
				<TR>
					<TD vAlign="top">
					<asp:datalist id="dlClass22" runat="server" Width="100%" 
                            onitemcommand="dlClass22_ItemCommand">
							<ItemTemplate>
								<TABLE id="Table22" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<th align="left">
											<asp:Label id="lblClass22" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cname") %>'>
											</asp:Label>
											<asp:TextBox id="tbxClass22" runat="server" Width="10px" Text='<%# DataBinder.Eval(Container.DataItem, "cls2_cls2id") %>' Visible="False">
											</asp:TextBox>
											<asp:LinkButton id="lnkSelectAll22" runat="server" ForeColor="Yellow" CommandName="Command1">全選</asp:LinkButton>
											<asp:LinkButton id="lnkSelectAll22Cancel" runat="server" ForeColor="Aquamarine" CommandName="Command2">清除</asp:LinkButton>
										</th>
									</TR>
									<TR>
										<TD>
											<asp:checkboxlist id="cblClass322" runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="4" DataTextField="cls3_cname" DataValueField="cls3_cls3id"></asp:checkboxlist></TD>
									</TR>
								</TABLE>
								<br />
							</ItemTemplate>
						</asp:datalist>
						</TD>
				</TR>
			</TABLE>
			</ContentTemplate>
			</asp:UpdatePanel>
			<asp:button id="btnSave" runat="server" Text="儲存" onclick="btnSave1_Click"></asp:button>&nbsp;&nbsp; <INPUT onclick="javascript:window.close();" type="button" value="關閉" name="btnClose" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"><INPUT id="hidSelected" type="hidden" name="hidSelected" runat="server">

    </span>
    </form>
</body>
</html>
