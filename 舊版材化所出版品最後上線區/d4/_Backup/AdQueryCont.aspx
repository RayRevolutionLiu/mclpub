<%@ Page language="c#" Codebehind="AdQueryCont.aspx.cs" Src="AdQueryCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdQueryCont" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<META content="Microsoft Visual Studio 7.0" name=GENERATOR>
<META content=C# name=CODE_LANGUAGE>
<META content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<META content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
     	<!-- CSS --><LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
<BODY>
		<!-- 頁首 Header --><kw:header id=Header runat="server">
		</kw:header>
<FORM id=AdQueryCont method=post runat="server"><FONT 
face=新細明體><asp:panel id=pnlQArea 
runat="server" Width="100%">
<TABLE cellSpacing=1 cellPadding=1 width="100%" bgColor=#e7ebff border=0>
  <TR bgColor=#bfcff0>
    <TD>
<asp:RadioButtonList id=rblQueryType runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Font-Size="X-Small">
<asp:ListItem Value="0" Selected="True">由合約書編號</asp:ListItem>
<asp:ListItem Value="1">由簽約日期</asp:ListItem>
<asp:ListItem Value="2">由廠商名稱</asp:ListItem>
</asp:RadioButtonList></TD></TR>
  <TR>
    <TD><FONT size=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TR>
          <TD width=300>
            <TABLE id=tblByContNo cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=120><FONT size=2>合約編號</FONT></TD>
                <TD><FONT size=2>
<asp:TextBox id=tbxQContNo runat="server" Width="80px" MaxLength="6"></asp:TextBox></FONT></TD></TR></TABLE>
            <TABLE id=tblBySignDate cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=120><FONT size=2>簽約日期區間</FONT></TD>
                <TD><FONT size=2>
<asp:TextBox id=tbxMinDate runat="server" Width="80px" MaxLength="10"></asp:TextBox>
<asp:ImageButton id=imbMinDate runat="server" CausesValidation="False" ImageUrl="show-calendar.gif"></asp:ImageButton>～</FONT></TD></TR>
              <TR>
                <TD><FONT size=2>　　</FONT></TD>
                <TD><FONT size=2>
<asp:TextBox id=tbxMaxDate runat="server" Width="80px" MaxLength="10"></asp:TextBox>
<asp:ImageButton id=imbMaxDate runat="server" CausesValidation="False" ImageUrl="show-calendar.gif"></asp:ImageButton></FONT></TD></TR></TABLE>
            <TABLE id=tblByMfrNm cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=120><FONT size=2>廠商名稱</FONT></TD>
                <TD><FONT size=2>
<asp:TextBox id=tbxMfrNm runat="server" Width="100px" MaxLength="6"></asp:TextBox></FONT></TD></TR></TABLE></TD>
          <TD>
<asp:calendar id=calSelectAdDate runat="server" Font-Size="9pt" CellPadding="0" NextPrevFormat="FullMonth" Font-Names="Verdana" BackColor="LemonChiffon" ForeColor="Black" BorderWidth="1px" BorderColor="White">
<TodayDayStyle BackColor="PaleGoldenrod">
</TodayDayStyle>

<DayStyle Font-Size="XX-Small">
</DayStyle>

<NextPrevStyle Font-Size="6pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom">
</NextPrevStyle>

<DayHeaderStyle Font-Size="5pt">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="8pt" Font-Bold="True" BorderWidth="3px" ForeColor="#333399" BorderColor="Black" BackColor="Gold">
</TitleStyle>

<WeekendDayStyle Font-Size="XX-Small">
</WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle>
</asp:calendar></TD></TR></TABLE></FONT></TD></TR>
  <TR>
    <TD>
<asp:Button id=btnGo runat="server" Text="查詢"></asp:Button>
<INPUT 
      id=hidDateTarget type=hidden name=hidDataTarget 
  runat="server"></TD></TR></TABLE></asp:panel><FONT size=2><asp:panel id=pnlAdr runat="server" 
Width="100%">
<asp:Label id=lblAdrDesc ForeColor="Red" Runat="server"></asp:Label>
<asp:DataGrid id=dgdAdr runat="server" Font-Size="XX-Small" CellPadding="2" BackColor="#E7EBFF" AutoGenerateColumns="False">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="選取" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="adr_contno" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="序號"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="廣告標語"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="播出起日"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="播出迄日"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" HeaderText="版面"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="位置"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="播出機率"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="播出方式">
<ItemTemplate>
<FONT face=新細明體>
<asp:Label id=lblFgFixAdNm runat="server" Text='<%# GetFgFixAdNm(DataBinder.Eval(Container.DataItem, "adr_fgfixad")) %>'></asp:Label></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="發票廠商"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" HeaderText="發票金額"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="已落版">
<ItemTemplate>
<FONT face=新細明體>
<asp:Label id=lblFgGotNm runat="server" Text='<%# GetFgGotNm(DataBinder.Eval(Container.DataItem, "adr_fggot")) %>'></asp:Label></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="adr_adamt" HeaderText="廣告價格"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_desamt" HeaderText="設計價格"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" HeaderText="換稿費用"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="廣告連結"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="檔案名稱">
<ItemTemplate>
<asp:Label id=lblImgUrl runat="server" Text='<%# GetImgUrlFile(DataBinder.Eval(Container.DataItem, "adr_imgurl")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="adr_remark" HeaderText="備註"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="cont_custno" HeaderText="cont_custno"></asp:BoundColumn>
</Columns>
</asp:DataGrid></asp:panel></FONT></FONT></FORM>
	<!-- 頁尾 Footer --><kw:footer id=Footer runat="server">
	</kw:footer>
	
  </BODY>
</HTML>
