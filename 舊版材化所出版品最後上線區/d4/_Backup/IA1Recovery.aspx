<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IA1Recovery.aspx.cs" Src="IA1Recovery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IA1Recovery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
         	<!-- CSS -->
         	<LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
  <body>
		<!-- 頁首 Header -->
		<kw:header id=Header runat="server">
		</kw:header>	
    <form id="IA1Recovery" method="post" runat="server"><FONT 
face=新細明體>請輸入合約編號：
<asp:TextBox id=tbxContNo runat="server" Width="90px" MaxLength="6"></asp:TextBox>
<asp:Button id=btnQueryCont runat="server" Text="查詢"></asp:Button><BR>
<asp:RequiredFieldValidator id=rfvContNo runat="server" ErrorMessage="合約編號不可空白" Display="Dynamic" Font-Size="X-Small" ControlToValidate="tbxContNo"></asp:RequiredFieldValidator>
<asp:Panel id=pnlCont runat="server" Width="100%">
<P align=center>
<TABLE borderColor=#000000 cellSpacing=1 cellPadding=1 width="95%" 
bgColor=#e7ebff border=0>
  <TR align=middle bgColor=#bfcff0>
    <TD style="WIDTH: 59px; HEIGHT: 43px" width=59><FONT face=新細明體 color=white 
      size=2>合約書編號</FONT></TD>
    <TD style="WIDTH: 150px; HEIGHT: 43px">
      <P><FONT size=2><FONT face=新細明體 
    color=white>廠商名稱<BR>(統編)</FONT></FONT></P></TD>
    <TD style="WIDTH: 80px; HEIGHT: 43px"><FONT size=2><FONT face=新細明體 
      color=white>客戶名稱<BR>(編號)</FONT></FONT></TD>
    <TD style="WIDTH: 73px; HEIGHT: 43px"><FONT size=2><FONT face=新細明體 
      color=white>簽約日期</FONT></FONT></TD>
    <TD style="WIDTH: 36px; HEIGHT: 43px"><FONT size=2><FONT color=white 
      size=2>合約<BR>類別</FONT></FONT></TD>
    <TD style="WIDTH: 102px; HEIGHT: 43px"><FONT color=white 
    size=2>合約起迄</FONT></TD>
    <TD style="WIDTH: 60px; HEIGHT: 43px"><FONT face=新細明體 color=white 
      size=2>承辦<BR>業務員/<BR>修改者</FONT></TD>
    <TD style="WIDTH: 38px; HEIGHT: 43px"><FONT size=2><FONT face=新細明體 
      color=white>一次<BR>付款</FONT></FONT></TD>
    <TD style="WIDTH: 39px; HEIGHT: 43px"><FONT face=新細明體 color=white 
      size=2>結案</FONT></TD>
    <TD style="WIDTH: 109px; HEIGHT: 43px"><FONT color=white 
      size=2>建檔日期/<BR>修改日期</FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 59px; HEIGHT: 74px"><FONT face=新細明體 size=2>
<asp:Label id=lblContNo runat="server"></asp:Label></FONT></TD>
    <TD style="WIDTH: 122px; HEIGHT: 74px"><FONT size=2><FONT face=新細明體>
<asp:Label id=lblMfrNm runat="server"></asp:Label>( 
<asp:Label id=lblMfrNo runat="server"></asp:Label>&nbsp;)</FONT></FONT></TD>
    <TD style="WIDTH: 75px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblCustNm runat="server"></asp:Label><FONT 
      face=新細明體><BR></FONT><FONT face=新細明體>( 
<asp:Label id=lblCustNo runat="server"></asp:Label>&nbsp;)</FONT></FONT></TD>
    <TD style="WIDTH: 73px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblSignDate runat="server"></asp:Label></FONT></TD>
    <TD style="WIDTH: 36px; HEIGHT: 74px"><FONT size=2><FONT size=2>
<asp:Label id=lblComtTp runat="server"></asp:Label></FONT></FONT></TD>
    <TD style="WIDTH: 102px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblSDate runat="server"></asp:Label><FONT face=新細明體>~ 
<asp:Label id=lblEDate runat="server"></asp:Label></FONT></FONT></TD>
    <TD style="WIDTH: 60px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblEmpNm runat="server"></asp:Label><FONT 
      face=新細明體>/<BR>
<asp:Label id=lblEmpNo runat="server"></asp:Label></FONT></FONT></TD>
    <TD style="WIDTH: 38px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblFgPayOnce runat="server"></asp:Label></FONT></TD>
    <TD style="WIDTH: 39px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblFgClosed runat="server"></asp:Label></FONT></TD>
    <TD style="WIDTH: 109px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblCreDate runat="server"></asp:Label><FONT 
      face=新細明體>/<BR>
<asp:Label id=lblModDate runat="server"></asp:Label></FONT></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 59px"><FONT size=2><FONT face=新細明體></FONT></FONT></TD>
    <TD style="WIDTH: 677px" colSpan=9>
      <TABLE borderColor=#000000 cellSpacing=1 cellPadding=1 width=680 
      bgColor=#e7ebff border=0>
        <TR align=middle bgColor=#bfcff0>
          <TD style="WIDTH: 70px"><FONT size=2><FONT face=新細明體 
            color=white>刊登次數</FONT></FONT></TD>
          <TD style="WIDTH: 73px"><FONT color=white size=2>贈送次數</FONT></TD>
          <TD style="WIDTH: 110px"><FONT color=white size=2>總製稿數</FONT></TD>
          <TD style="WIDTH: 87px"><FONT color=white size=2>聯絡人姓名</FONT></TD>
          <TD style="WIDTH: 73px"><FONT color=white size=2>電話</FONT></TD>
          <TD style="WIDTH: 76px"><FONT color=white size=2>傳真</FONT></TD>
          <TD style="WIDTH: 63px"><FONT color=white size=2>手機</FONT></TD>
          <TD><FONT size=2><FONT color=white size=2>Email</FONT></FONT></TD></TR>
        <TR>
          <TD style="WIDTH: 70px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblPubTm runat="server"></asp:Label></FONT></TD>
          <TD style="WIDTH: 73px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblFreeTm runat="server"></asp:Label></FONT></TD>
          <TD style="WIDTH: 110px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblTotTm runat="server"></asp:Label></FONT></TD>
          <TD style="WIDTH: 87px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuNm runat="server"></asp:Label></FONT></TD>
          <TD style="WIDTH: 73px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuTel runat="server"></asp:Label></FONT></TD>
          <TD style="WIDTH: 76px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuFax runat="server"></asp:Label></FONT></TD>
          <TD style="WIDTH: 63px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuCell runat="server"></asp:Label></FONT></TD>
          <TD style="HEIGHT: 22px"><FONT size=2><FONT size=2><FONT face=新細明體>
<asp:Label id=lblAuEmail runat="server"></asp:Label></FONT></FONT></FONT></TD></TR>
        <TR align=middle bgColor=#bfcff0>
          <TD style="WIDTH: 70px"><FONT face=新細明體 color=white 
            size=2>合約金額</FONT></TD>
          <TD style="WIDTH: 73px"><FONT color=white size=2>已繳金額</FONT></TD>
          <TD style="WIDTH: 69px"><FONT color=white size=2>剩餘金額</FONT></TD>
          <TD style="WIDTH: 87px"><FONT color=#000000 size=2></FONT></TD>
          <TD style="WIDTH: 73px"><FONT color=#000000 size=2></FONT></TD>
          <TD style="WIDTH: 76px"><FONT color=#000000 size=2></FONT></TD>
          <TD style="WIDTH: 63px"><FONT color=#000000 size=2></FONT></TD>
          <TD><FONT size=2><FONT color=white size=2>備註</FONT></FONT></TD></TR>
        <TR>
          <TD style="WIDTH: 70px"><FONT size=2><FONT size=2><FONT face=新細明體>
<asp:Label id=lblTotAmt runat="server"></asp:Label></FONT></FONT></FONT></TD>
          <TD style="WIDTH: 73px"><FONT size=2><FONT size=2>
<asp:Label id=lblPaidAmt runat="server"></asp:Label></FONT></FONT></TD>
          <TD style="WIDTH: 69px"><FONT size=2><FONT size=2>
<asp:Label id=lblResAmt runat="server"></asp:Label></FONT></FONT></TD>
          <TD style="WIDTH: 87px"><FONT size=2><FONT size=2></FONT></FONT></TD>
          <TD style="WIDTH: 73px"><FONT size=2></FONT></TD>
          <TD style="WIDTH: 76px"><FONT size=2></FONT></TD>
          <TD style="WIDTH: 63px"><FONT size=2></FONT></TD>
          <TD><FONT size=2><FONT size=2><FONT size=2>
<asp:Label id=lblAdRemark runat="server"></asp:Label></FONT></FONT></FONT></TD></TR></TABLE><FONT 
      size=2></FONT><FONT size=2><FONT face=新細明體></FONT></FONT><FONT 
      size=2></FONT><FONT size=2><FONT size=2></FONT></FONT><FONT 
      size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT 
      size=2></FONT><FONT size=2></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 59px"><FONT size=2></FONT></TD>
    <TD style="WIDTH: 122px" colSpan=9><FONT size=2></FONT><FONT 
      size=2></FONT><FONT size=2></FONT><FONT size=2><FONT 
      size=2></FONT></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT 
      size=2></FONT><FONT size=2></FONT><FONT size=2><FONT 
      face=新細明體>發票廠商收件人</FONT> 
<asp:DataGrid id=dgdInvMfr runat="server" Width="720px" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#E7EBFF">
<HeaderStyle ForeColor="Black" BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
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
<asp:TemplateColumn HeaderText="發票類別">
<ItemTemplate>
<asp:Label id="lblInvNm" runat="server" Font-Size="X-Small" Text='<%# GetInvNm(DataBinder.Eval(Container.DataItem, "im_invcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="發票課稅別">
<ItemTemplate>
<asp:Label id="lblTaxNm" runat="server" Font-Size="X-Small" Text='<%# GetTaxNm(DataBinder.Eval(Container.DataItem, "im_taxtp")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
</Columns>
</asp:DataGrid></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 59px"><FONT size=2></FONT></TD>
    <TD style="WIDTH: 122px" colSpan=9><FONT size=2></FONT><FONT 
      size=2></FONT><FONT size=2></FONT><FONT size=2><FONT size=2><FONT 
      face=新細明體></FONT></FONT></FONT><FONT size=2><FONT 
      face=新細明體></FONT></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT 
      size=2></FONT><FONT size=2><FONT face=新細明體>贈書資料</FONT> 
<asp:DataGrid id=dgdFreeBk runat="server" Width="720px" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#e7ebff">
<HeaderStyle ForeColor="Black" BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="贈書項次"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="贈書起月"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="贈書迄月"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="書籍類別">
<ItemTemplate>
<asp:Label id="lblBkNm" runat="server" Font-Size="X-Small" Text='<%# GetBkNm(DataBinder.Eval(Container.DataItem, "fbk_bkcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="郵寄類別">
<ItemTemplate>
<asp:Label id=lblMtpNm runat="server" Font-Size="X-Small" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
</asp:DataGrid></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 59px"></TD>
    <TD style="WIDTH: 122px" colSpan=9><FONT face=新細明體 size=2>網路廣告資料<BR>
<asp:DataGrid id=dgdAdr runat="server" Width="720px" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="LightCyan">
<HeaderStyle ForeColor="White" BackColor="CornflowerBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="adr_seq" HeaderText="序號"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="廣告標語"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="播出起日"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="播出迄日"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" HeaderText="種類"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="位置"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="機率"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="廣告連結"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_fgfixad" HeaderText="播出方式"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adamt" HeaderText="廣告價格"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_desamt" HeaderText="設計價格"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" HeaderText="換稿費用"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" HeaderText="發票金額"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_drafttp" HeaderText="圖稿製法"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_urltp" HeaderText="網頁稿製法"></asp:BoundColumn>
</Columns>
</asp:DataGrid></FONT></TD></TR></TABLE>
<asp:Button id=btnRecovery runat="server" Text="確定回復" CausesValidation="False"></asp:Button></P>
</asp:Panel></FONT>
     </form>
		<!-- 頁尾 Footer -->
		<kw:footer id=Footer runat="server">
		</kw:footer>	
  </body>
</HTML>
