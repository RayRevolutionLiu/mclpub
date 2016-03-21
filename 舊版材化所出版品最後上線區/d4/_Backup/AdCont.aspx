<%@ Page language="c#" Codebehind="AdCont.aspx.cs" Src="AdCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdCont" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=AdCont method=post runat="server"><FONT face=新細明體>
<TABLE style="WIDTH: 90%" cellSpacing=0 cellPadding=1 width="90%" 
bgColor=#bfcff0 border=0>
  <TR>
    <TD style="WIDTH: 558px" bgColor=#214389 colSpan=2 
      ><FONT size=2><FONT color=white 
      >廠商及客戶資料</FONT></FONT></TD></TR>
  <tr>
    <td>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >公司名稱：</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxMfrName runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >詳細資料：</FONT></P></TD>
          <TD width="35%"></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >客戶姓名：</FONT></P></TD>
          <TD><asp:textbox id=tbxCustName runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >聯絡電話：</FONT></P></TD>
          <TD><asp:textbox id=tbxCustTel runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >客戶職稱：</FONT></P></TD>
          <TD><asp:textbox id=tbxCustTitle runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >詳細資料：</FONT></P></TD>
          <TD></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >合約書基本資料</FONT></FONT></TD></TR>
  <tr>
    <td colSpan=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >合約編號：</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxContNo runat="server" Font-Size="XX-Small" BackColor="Silver" ReadOnly="True" Width="67px" Height="22px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >簽約日期：</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxContSignDate runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >合約類別：</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlContTp runat="server" Font-Size="XX-Small">
<asp:ListItem Value="00" Selected="True">材料世界網</asp:ListItem></asp:dropdownlist></TD>
          <TD>
            <P align=right><FONT size=2 
            >刊登起迄：</FONT></P></TD>
          <TD><asp:textbox id=tbxContSDate runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox><FONT 
            size=2>～ </FONT><asp:textbox id=tbxContEDate runat="server" Font-Size="XX-Small" Width="68px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >刊登類別：</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlPubCate runat="server" Font-Size="XX-Small">
<asp:ListItem Value="0">一般</asp:ListItem>
<asp:ListItem Value="1">推廣</asp:ListItem></asp:dropdownlist></TD>
          <TD>
            <P align=right><FONT size=2 
            >簽約業務：</FONT></P></TD>
          <TD><asp:textbox id=tbxContEmp runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD></TD>
          <TD></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >聯絡人：</FONT></P></TD>
          <TD><asp:textbox id=tbxAuName runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >聯絡電話：</FONT></P></TD>
          <TD><asp:textbox id=tbxAuTel runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox><FONT 
            size=2>&nbsp;&nbsp;&nbsp; 手機： </FONT><asp:textbox id=tbxAuCell runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >傳真號碼：</FONT></P></TD>
          <TD><asp:textbox id=tbxAuFax runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >email：</FONT> </P></TD>
          <TD><asp:textbox id=tbxAuEmail runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >合約詳細資料</FONT></FONT></TD></TR>
  <tr>
    <td colSpan=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >刊登次數：</FONT></P></TD>
          <TD width="18%"><asp:textbox id=tbxContPubTm runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >贈送次數：</FONT></P></TD>
          <TD width="17%"><FONT size=2 
            ><asp:textbox id=tbxContFreeTm runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></FONT></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >總制稿次數：</FONT></P></TD>
          <TD width="17%"><asp:textbox id=tbxContTotTm runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >合約金額：</FONT></P></TD>
          <TD><asp:textbox id=tbxContTotAmt runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >優惠折數：</FONT></P></TD>
          <TD><asp:textbox id=tbxContDisc runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >已繳金額：</FONT></P></TD>
          <TD><asp:textbox id=tbxContPaidAmt runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >發票收件人資料</FONT></FONT></TD></TR>
  <tr>
    <td colSpan=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >收件人：</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxIrName runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >電話：</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxIrTel runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox><FONT 
            size=2>&nbsp;&nbsp;&nbsp; 手機： <asp:textbox id=tbxIrCell runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></FONT></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >地址：</FONT></P></TD>
          <TD><asp:textbox id=tbxIrAddr runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >郵遞區號：</FONT></P></TD>
          <TD><asp:textbox id=tbxIrZip runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >傳真號碼：</FONT></P></TD>
          <TD><asp:textbox id=tbxIrFax runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >email：</FONT></P></TD>
          <TD><asp:textbox id=tbxIrEmail runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >其他資料</FONT></FONT></TD></TR>
  <tr>
    <td>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >推廣內文：</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxCCont runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >搜尋期限：</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxCsDate runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >廣告備註：</FONT></P></TD>
          <TD><asp:textbox id=tbxAdRemark runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >設備內文：</FONT></P></TD>
          <TD><asp:textbox id=tbxPdCont runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR></TABLE></td></tr></TABLE>[發票廠商資料] 
<INPUT style="FONT-SIZE: xx-small" onclick=doOpenInvMfr() type=button value=新增 name=btnAddIM> 
<asp:button id=btnRefIM runat="server" Font-Size="XX-Small" Text="重新整理資料"></asp:button><BR><asp:datalist id=DataList1 runat="server" BackColor="#bfcff0" RepeatColumns="5" RepeatDirection="Horizontal">
<ItemTemplate>
<asp:Label id=lblMfrName runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container.DataItem, "im_nm") %>'></asp:Label>(
<asp:Label id=lblMfrNo runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container.DataItem, "im_mfrno") %>'></asp:Label>);　
</ItemTemplate></asp:datalist><BR>[現有網廣落版] <INPUT style="FONT-SIZE: xx-small" onclick=doOpenAdr() type=button value=新增 name=btnAddAdr> 
<asp:button id=btnRefAdr runat="server" Font-Size="XX-Small" Text="重新整理資料"></asp:button><BR><asp:datagrid id=DataGrid2 runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="Delete" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:BoundColumn DataField="adr_date" HeaderText="播出日期"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="廣告種類"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="廣告位置"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" HeaderText="費用"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="廣告標語"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_adrid" HeaderText="adr_adrid"></asp:BoundColumn>
</Columns></asp:datagrid><BR>[贈書資料] <INPUT style="FONT-SIZE: xx-small" onclick=doOpenFreeBk() type=button value=新增 name=btnAddBk Text="重新整理資料"> 
<asp:button id=btnRefFreeBk runat="server" Font-Size="XX-Small" Text="重新整理資料"></asp:button><BR><asp:datagrid id=DataGrid1 runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="刪除" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:ButtonColumn Text="ˇ" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="fbk_fbkid" HeaderText="id"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="贈書項次"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="贈書起日"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="贈書迄日"></asp:BoundColumn>
<asp:BoundColumn DataField="bk_nm" HeaderText="書籍"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
</Columns>
</asp:datagrid><BR></FONT><asp:button id=btnSave runat="server" Text="儲存"></asp:button><asp:button id=btnRefresh runat="server" Text="重新整理"></asp:button>
<INPUT 
id=hidInvMfrCount type=hidden runat="server"></form>
<SCRIPT language=javascript>
function doOpenInvMfr()
{
	//window.open("AddInvMfr.aspx", "Poping", "toolbar=no,menubar=no,width=320,height=200", false);
	window.open("AddInvMfr.aspx?ContNo=" + document.AdCont("tbxContNo").value , "Poping", "toolbar=no,menubar=no,width=800,height=600", false);
}

function doOpenAdr()
{
	if (document.AdCont("hidInvMfrCount").value > 0)
	{
		window.open("AdManagement.aspx?ContNo=" + document.AdCont("tbxContNo").value , "Adr", "toolbar=no,menubar=no,width=800,height=600", false);
	}
	else
	{
		alert("請先輸入發票廠商資料");
	}
}

function doOpenFreeBk()
{
	window.open("AddFreeBk.aspx?ContNo=" + document.AdCont("tbxContNo").value , "FreeBk", "toolbar=no,menubar=no,width=800,height=600", false);
}

</SCRIPT>


	
  </body>
</HTML>
