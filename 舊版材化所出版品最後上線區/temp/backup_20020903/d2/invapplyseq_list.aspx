<%@ Page language="c#" Codebehind="invapplyseq_list.aspx.cs" Src="invapplyseq_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.invapplyseq_list" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立清單編號</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<center>
			<!-- 頁首 Header -->
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							發票開立清單編號</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- 標題 -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">發票開立清單編號</FONT></B>
			</DIV>
			<!-- Run at Server Form -->
			<form ID="invapplyseq_list" name="invapplyseq_list" method="post" runat="server">
				<asp:DataGrid id="DataGrid1" runat="server" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False">
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
						<asp:BoundColumn DataField="ias_iasid" HeaderText="ID"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_syscd" HeaderText="系統代碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_iasdate" HeaderText="發票開立清單轉檔日期"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_iasseq" HeaderText="發票開立清單批次"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_toitem" HeaderText="發票開立清單總項次"></asp:BoundColumn>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
				</asp:DataGrid>
				<br>
				<!-- 暫時連結 Excel 檔 -->
				<br>
				<a href="invapplyseq_list.xls" class="external">參考樣章</a>
				<br>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</BODY>
</HTML>
