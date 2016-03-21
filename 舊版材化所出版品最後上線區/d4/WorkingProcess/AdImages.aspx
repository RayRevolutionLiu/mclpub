<%@ Page language="c#" Codebehind="AdImages.aspx.cs" Src="AdImages.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdImages" %>
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
		<form id="AdImages" method="post" runat="server">
			<asp:Panel id="pnlImages" runat="server">
<asp:Label id="lblImageInfo" runat="server" CssClass="NormalLabel">現有廣告圖檔Label</asp:Label>&nbsp;&nbsp;&nbsp; 
<A href="x.aspx">上傳廣告圖檔</A><BR>
<asp:DataList id="dlImageList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
					<ItemTemplate>
						<TABLE id="Table1" cellSpacing="2" cellPadding="1" border="0">
							<TR>
								<TD>
									<asp:Image id=imgAdrImage runat="server" BorderWidth="0px" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "filename") %>'>
									</asp:Image></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id=lblFileName runat="server" CssClass="NormalLabel" Text='<%# DataBinder.Eval(Container.DataItem, "filename") %>'>
									</asp:Label></TD>
							</TR>
						</TABLE>
					</ItemTemplate>
				</asp:DataList>
			</asp:Panel></form>
	</body>
</HTML>
