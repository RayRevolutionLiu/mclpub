<%@ Page language="c#" Codebehind="AddInvMfr.aspx.cs" Src="AddInvMfr.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AddInvMfr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>新增/修改/刪除 發票廠商收件人資料</TITLE>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
		<!-- JScript -->
<script language=JScript>
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
					event.returnValue=confirm("是否確定刪除?")
			}
			document.onclick=Delete_confirm;
		</script>
</HEAD>
<body>
<form id=AddInvMfr method=post runat="server">
			<!-- 發票廠商收件人 歷史資料 區 --><FONT 
color=#ff0066 size=2>[發票廠商收件人 歷史資料 區]&nbsp;&nbsp; </FONT><asp:label id=lblMfrInfo runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><br><asp:datagrid id=DataGrid1 runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="載入新增" HeaderText="載入新增" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:label id=lblHistoryMessage runat="server" ForeColor="Maroon" Font-Size="X-Small" DESIGNTIMEDRAGDROP="742"></asp:label><FONT 
color=#ff0066 size=2>以上為歷史資料參考區，要帶入該資料請按「載入新增」</FONT>
<HR width="100%" color=orange SIZE=1><font 
color=#ff0066 size=2>[發票廠商收件人 新增/修改資料 區]</font> <asp:textbox id=tbxIMSysCode runat="server" Enabled="False" WIDTH="30px" MaxLength="2" Visible="False">C4</asp:textbox><FONT 
color=#ff0066 size=2>&nbsp; <asp:textbox id=tbxIMContNo runat="server" Enabled="False" WIDTH="50px" MaxLength="6" Visible="False"></asp:textbox>&nbsp;&nbsp; 
<asp:label id=lblMfrNo runat="server" Visible="False"></asp:label>&nbsp; 
<asp:label id=lblCustNo runat="server" Visible="False"></asp:label></FONT><FONT 
color=#c00000 size=2>欲修改為不同廠商/客戶資料, 請按下 <IMG class=ico id=imgCustDetail alt=客戶詳細資料 src="edit.gif" width=18 border=0 >圖示來搜尋資料!</FONT> <br>
<TABLE id=tblAdd style="FONT-SIZE: x-small" borderColor=#bfcff0 cellSpacing=0 
cellPadding=0 bgColor=#bfcff0 border=1>
  <THEAD>
  <TR>
    <TH><FONT face=新細明體 
      >序號</FONT>&nbsp; </TH>
    <TH><FONT color=#c00000 size=2 
      >*</FONT>廠商 <br>統編<IMG class=ico id=imgMfrDetail onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbars=yes, status=no, resizable=yes')" alt=廠商詳細資料 src="edit.gif" width=18 border=0 > </TH>
    <TH><FONT color=#c00000 size=2 
      >*</FONT>姓名<IMG class=ico id=Img1 onclick="javascript:window.open('../d5/Cust.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbars=yes, status=no, resizable=yes')" alt=客戶詳細資料 src="edit.gif" width=18 border=0 > </TH>
    <TH>職稱 </TH>
    <TH>電話 </TH>
    <TH><FONT color=#c00000 size=2 
      >*</FONT>發票 <br>類別 </TH>
    <TH><FONT color=#c00000 size=2 
      >*</FONT>發票 <br>課稅別 </TH>
    <TH><FONT color=#c00000 size=2 
      >*</FONT>院所內 <br>註記 
</TH></TR></THEAD>
  <TBODY>
  <TR bgColor=#e2eafc>
    <TD><asp:label id=lblImSeq runat="server" Font-Size="X-Small"></asp:label></TD>
    <TD><asp:textbox id=tbxIMMfrNo runat="server" WIDTH="70px" MaxLength="10"></asp:textbox></TD>
    <TD><asp:textbox id=tbxIMName runat="server" WIDTH="70px" MaxLength="30"></asp:textbox></TD>
    <TD><asp:textbox id=tbxIMJobTitle runat="server" WIDTH="70px" MaxLength="12"></asp:textbox></TD>
    <TD><asp:textbox id=tbxIMTel runat="server" WIDTH="90px" MaxLength="30"></asp:textbox></TD>
    <TD align=middle><asp:dropdownlist id=ddlIMInvtp runat="server">
								<asp:ListItem Value="2">二聯</asp:ListItem>
								<asp:ListItem Value="3" Selected="True">三聯</asp:ListItem>
								<asp:ListItem Value="4">其他</asp:ListItem>
							</asp:dropdownlist></TD>
    <TD><asp:dropdownlist id=ddlIMTaxtp runat="server">
								<asp:ListItem Value="1" Selected="True">應稅5%</asp:ListItem>
								<asp:ListItem Value="2">零稅</asp:ListItem>
								<asp:ListItem Value="3">免稅</asp:ListItem>
							</asp:dropdownlist></TD>
    <TD><asp:dropdownlist id=ddlIMfgITRI runat="server">
								<asp:ListItem Value="" Selected="True">否</asp:ListItem>
								<asp:ListItem Value="06">所內</asp:ListItem>
								<asp:ListItem Value="07">院內</asp:ListItem>
							</asp:dropdownlist></TD></TR>
					<!-- 第二行 -->
  <TR>
    <TH>&nbsp; </TH>
    <TH colSpan=3>郵遞區號&nbsp;&amp;&nbsp;&nbsp;發票地址 </TH>
    <TH>傳真 </TH>
    <TH>手機 </TH>
    <TH colSpan=2>Email </TH></TR>
  <TR bgColor=#e2eafc>
    <TD>&nbsp; </TD>
    <TD colSpan=3><asp:textbox id=tbxIMZipcode runat="server" WIDTH="40px" MaxLength="5"></asp:textbox>&nbsp; 
<asp:textbox id=tbxIMAddr runat="server" WIDTH="230px" MaxLength="120"></asp:textbox></TD>
    <TD><asp:textbox id=tbxIMFax runat="server" WIDTH="90px" MaxLength="30"></asp:textbox></TD>
    <TD><asp:textbox id=tbxIMCell runat="server" WIDTH="80px" MaxLength="30"></asp:textbox></TD>
    <TD colSpan=2><asp:textbox id=tbxIMEmail runat="server" WIDTH="160px" MaxLength="80"></asp:textbox></TD></TR></TBODY></TABLE><FONT 
color=#c00000 size=2>* 為必填欄位!</FONT> <br><asp:button id=btnSave runat="server" Text="儲存新增"></asp:button>&nbsp;&nbsp; 
<asp:button id=btnModify runat="server" Text="儲存修改"></asp:button>&nbsp;&nbsp; 
<asp:button id=btnLoadData runat="server" Text="載入預設資料"></asp:button>&nbsp; 
&nbsp; <INPUT id=btnClose onclick='doClose(<% Response.Write("\""+Request.QueryString["Act"]+"\""); %>)' type=button value=關閉視窗 name=btnClose> 
<br><br><font color=#ff0066 size=2>[已新增 發票廠商收件人資料 區]</font> <br><asp:datagrid id=DataGrid2 runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
<HeaderStyle Font-Bold="True" BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="修改" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
<asp:ButtonColumn Text="刪除 " HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
</Columns>
</asp:datagrid></form>
<script language=javascript>
function doClose(myaction)
{
	if (myaction == "Mod")
	{
		window.opener.ContModify.submit();
	}
	else
	{
		window.opener.NewCont.submit();
	}
	window.close();
}
</script>

	</body>
</HTML>
