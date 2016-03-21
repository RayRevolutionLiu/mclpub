<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="AdCheckList.aspx.cs" Src="AdCheckList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdCheckList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
    		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
<form id=AdCheckList method=post runat="server"><FONT 
face=新細明體><asp:panel id=pnlQArea 
runat="server" Width="100%">
<TABLE cellSpacing=1 cellPadding=1 width="100%" bgColor=#e7ebff border=0>
  <TR bgColor=#bfcff0>
    <TD></TD></TR>
  <TR>
    <TD><FONT size=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TR>
          <TD style="WIDTH: 418px" width=418>
            <TABLE id=tblByContNo cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=150><FONT size=2>
<asp:CheckBox id=cbxContNo runat="server"></asp:CheckBox>合約編號</FONT></TD>
                <TD><FONT size=2>
<asp:TextBox id=tbxQContNo runat="server" Width="80px" MaxLength="6"></asp:TextBox></FONT></TD></TR></TABLE>
            <TABLE id=tblBySignDate cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=150><FONT size=2>
<asp:CheckBox id=cbxSignDate runat="server"></asp:CheckBox>簽約日期區間</FONT></TD>
                <TD><FONT size=2>
<asp:TextBox id=tbxMinDate runat="server" Width="80px" MaxLength="10"></asp:TextBox>
<asp:ImageButton id=imbMinDate runat="server" CausesValidation="False" ImageUrl="show-calendar.gif"></asp:ImageButton>～ 
<asp:TextBox id=tbxMaxDate runat="server" Width="80px" MaxLength="10"></asp:TextBox>
<asp:ImageButton id=imbMaxDate runat="server" CausesValidation="False" ImageUrl="show-calendar.gif"></asp:ImageButton></FONT></TD></TR></TABLE>
            <TABLE id=tblByEmpNo cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=150><FONT size=2>
<asp:CheckBox id=cbxEmpNo runat="server"></asp:CheckBox>簽約業務員</FONT></TD>
                <TD>
<asp:DropDownList id=ddlEmpNo runat="server"></asp:DropDownList></TD></TR></TABLE>
            <TABLE id=tblByMfrNm cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=150><FONT size=2>
<asp:CheckBox id=cbxMfrNm runat="server"></asp:CheckBox>公司名稱</FONT></TD>
                <TD>
<asp:TextBox id=tbxMfrNm runat="server" Width="80px"></asp:TextBox></TD></TR></TABLE>
            <TABLE id=tblByAdrInterval cellSpacing=0 cellPadding=1 width="100%" 
            border=0 runat="server">
              <TR>
                <TD width=150><FONT size=2>
<asp:CheckBox id=cbxAdDate runat="server"></asp:CheckBox>廣告區間</FONT></TD>
                <TD>
<asp:TextBox id=tbxAdMinDate runat="server" Width="80px" MaxLength="10"></asp:TextBox>～ 
<asp:TextBox id=tbxAdMaxDate runat="server" Width="80px" MaxLength="10"></asp:TextBox></TD></TR></TABLE></TD>
          <TD>
<asp:calendar id=calSelectAdDate runat="server" CellPadding="0" NextPrevFormat="FullMonth" Font-Names="Verdana" BackColor="LemonChiffon" ForeColor="Black" BorderWidth="1px" BorderColor="White" Font-Size="9pt">
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
<asp:DataGrid id=dgdAdr runat="server" CellPadding="2" BackColor="#E7EBFF" Font-Size="XX-Small" AutoGenerateColumns="False">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
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
<asp:TemplateColumn HeaderText="已到稿">
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
</Columns>
</asp:DataGrid></asp:panel></FONT></FONT></form>
				<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>		
  </body>
</HTML>
