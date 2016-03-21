<%@ Page language="c#" Codebehind="AdPrePublish.aspx.cs" Src="AdPrePublish.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdPrePublish" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=AdPrePublish method=post runat="server"><FONT 
size=2><asp:panel id=pnlAllAdr 
BorderColor="green" BorderWidth="1px" Width="100%" Runat="server"><FONT 
face=新細明體><FONT color=red>基本合約資料<BR>
<TABLE borderColor=lightgrey cellSpacing=0 borderColorDark=white cellPadding=0 
width="100%" border=1>
  <TR align=middle bgColor=#bfcff0>
    <TD style="HEIGHT: 19px"><FONT size=2>合約編號</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>合約類別</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>簽約日期</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>合約起迄</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>刊登<BR>次數</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>贈送<BR>次數</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>優惠<BR>折數</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>總製圖檔稿<BR>次數</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>總至網頁稿<BR>次數</FONT></TD></TR>
  <TR>
    <TD><FONT 
    size=2>
<asp:Label id=lblContNo runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblContTp runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
      size=2>
<asp:Label id=lblSignDate runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblSEDate runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblPubTm runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblFreeTm runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblDisc runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblImgTm runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblUrlTm runat="server"></asp:Label></FONT></TD></TR></TABLE></FONT></FONT>
<asp:Label id=lblAdr runat="server" ForeColor="Red">現有廣告資料</asp:Label></asp:panel><asp:datagrid id=dgdAdr runat="server" AutoGenerateColumns="False" BackColor="#E7EBFF" Font-Size="X-Small">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="刪除" CommandName="Delete"></asp:ButtonColumn>
<asp:ButtonColumn Text="修改" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="序號"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="廣告標語"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" ReadOnly="True" HeaderText="播出起日"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" ReadOnly="True" HeaderText="播出迄日"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" ReadOnly="True" HeaderText="頁面"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" ReadOnly="True" HeaderText="位置"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="機率"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="廣告連結"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="播出方式">
<ItemTemplate>
<asp:Label id=lblFgFixAdNm runat="server" Text='<%# GetFgFixAdNm(DataBinder.Eval(Container.DataItem, "adr_fgfixad")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="adr_adamt" ReadOnly="True" HeaderText="廣告價格"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_desamt" ReadOnly="True" HeaderText="設計價格"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" ReadOnly="True" HeaderText="換稿費用"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" ReadOnly="True" HeaderText="發票金額"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_drafttp" HeaderText="drafttp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_urltp" HeaderText="urltp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_remark" HeaderText="remark"></asp:BoundColumn>
</Columns>
</asp:datagrid><br><asp:panel id=pnlInputArea runat="server" BorderColor="Green" BorderWidth="1px" 
Width="100%">
<asp:label id=lblStep1 runat="server" Width="100%" ForeColor="White" BackColor="SteelBlue" Font-Size="X-Small">填入基本資料</asp:label>
<TABLE cellSpacing=0 cellPadding=1 width="100%" bgColor=lightcyan border=0>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>合約編號</FONT> 
<asp:textbox id=tbxContNo runat="server" Width="60px" BackColor="Silver" Font-Size="X-Small" ReadOnly="True" size="6"></asp:textbox></TD>
    <TD><FONT size=2>發票廠商 
<asp:dropdownlist id=ddlInvMfr runat="server" Font-Size="X-Small"></asp:dropdownlist><IMG 
      alt="" src="edit.gif" name=imgAddInvMfr></FONT></TD>
    <TD colSpan=2><FONT size=2>廣告連結</FONT> 
<asp:textbox id=tbxNavUrl runat="server" Font-Size="X-Small"></asp:textbox>
<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" Font-Size="XX-Small" ErrorMessage="不可空白" ControlToValidate="tbxNavUrl" Display="Dynamic"></asp:RequiredFieldValidator></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>開始日期 </FONT>
<asp:textbox id=tbxBeginDate runat="server" Width="70px" Font-Size="X-Small"></asp:textbox>
<asp:ImageButton id=imbStartDate runat="server" ImageUrl="show-calendar.gif" CausesValidation="False"></asp:ImageButton>
<asp:RequiredFieldValidator id=RequiredFieldValidator3 runat="server" Font-Size="XX-Small" ErrorMessage="不可空白" ControlToValidate="tbxBeginDate" Display="Dynamic"></asp:RequiredFieldValidator></TD>
    <TD><FONT size=2>結束日期 
<asp:textbox id=tbxEndDate runat="server" Width="70px" Font-Size="X-Small"></asp:textbox>
<asp:ImageButton id=imbEndDate runat="server" ImageUrl="show-calendar.gif" CausesValidation="False"></asp:ImageButton>
<asp:Label id=lblTotDays runat="server"></asp:Label>
<asp:RequiredFieldValidator id=RequiredFieldValidator4 runat="server" Font-Size="XX-Small" ErrorMessage="不可空白" ControlToValidate="tbxEndDate" Display="Dynamic"></asp:RequiredFieldValidator></FONT></TD>
    <TD colSpan=2><FONT face=新細明體><FONT size=2>廣告標語</FONT><FONT size=3> 
</FONT>
<asp:textbox id=tbxAltText runat="server" Font-Size="X-Small"></asp:textbox>
<asp:RequiredFieldValidator id=RequiredFieldValidator2 runat="server" Font-Size="XX-Small" ErrorMessage="不可空白" ControlToValidate="tbxAltText" Display="Dynamic"></asp:RequiredFieldValidator></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>廣告範圍 </FONT>
<asp:dropdownlist id=ddlAdCate runat="server" Font-Size="X-Small" AutoPostBack="True">
<asp:ListItem Value="M">首頁</asp:ListItem>
<asp:ListItem Value="I">內頁</asp:ListItem>
<asp:ListItem Value="N">奈米</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT size=2>廣告位置 
<asp:dropdownlist id=ddlKey runat="server" Font-Size="X-Small">
<asp:ListItem Value="h0">正中</asp:ListItem>
<asp:ListItem Value="h1">右1</asp:ListItem>
<asp:ListItem Value="h2">右2</asp:ListItem>
<asp:ListItem Value="h3">右3</asp:ListItem>
<asp:ListItem Value="h4">右4</asp:ListItem>
<asp:ListItem Value="w1">右文1</asp:ListItem>
<asp:ListItem Value="w2">右文2</asp:ListItem>
<asp:ListItem Value="w3">右文3</asp:ListItem>
<asp:ListItem Value="w4">右文4</asp:ListItem>
<asp:ListItem Value="w5">右文5</asp:ListItem>
<asp:ListItem Value="w6">右文6</asp:ListItem>
</asp:dropdownlist></FONT></TD>
    <TD colSpan=2 rowSpan=5><FONT size=2>
<asp:calendar id=calSelectAdDate runat="server" BorderColor="White" BorderWidth="1px" ForeColor="Black" BackColor="LemonChiffon" Font-Size="9pt" Font-Names="Verdana" NextPrevFormat="FullMonth" CellPadding="0">
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
</asp:calendar>
<INPUT id=hidDateTarget type=hidden name=hidDataTarget 
      runat="server"></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>到稿註記</FONT><FONT size=3> </FONT>
<asp:dropdownlist id=ddlFgGot runat="server" Font-Size="X-Small">
<asp:ListItem Value="1" Selected="True">是</asp:ListItem>
<asp:ListItem Value="0">否</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT face=新細明體 size=2>播放方式<FONT size=3> 
<asp:dropdownlist id=ddlFgFixAd runat="server" Font-Size="X-Small" AutoPostBack="True">
<asp:ListItem Value="0" Selected="True">輪播</asp:ListItem>
<asp:ListItem Value="1">定播</asp:ListItem>
</asp:dropdownlist></FONT><FONT size=2>機率</FONT><FONT size=3> </FONT>
<asp:textbox id=tbxImpression runat="server" Width="25px" Font-Size="X-Small" size="1" MaxLength="2">1</asp:textbox>
<asp:RequiredFieldValidator id=RequiredFieldValidator5 runat="server" Font-Size="XX-Small" ErrorMessage="不可空白" ControlToValidate="tbxImpression">*</asp:RequiredFieldValidator></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>稿件類別</FONT></TD>
    <TD><FONT face=新細明體>
<asp:RadioButtonList id=rblDraftTp runat="server" Font-Size="X-Small" RepeatLayout="Flow" RepeatDirection="Horizontal">
<asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
<asp:ListItem Value="2">新稿</asp:ListItem>
<asp:ListItem Value="3">改稿</asp:ListItem>
</asp:RadioButtonList><IMG onclick=doOpenCheck() alt="" src="edit.gif" 
      name=imgCheckImg></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>URL類別</FONT></TD>
    <TD>
<asp:RadioButtonList id=rblUrlTp runat="server" Font-Size="X-Small" RepeatLayout="Flow" RepeatDirection="Horizontal">
<asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
<asp:ListItem Value="2">新稿</asp:ListItem>
<asp:ListItem Value="3">改稿</asp:ListItem>
</asp:RadioButtonList><IMG onclick=doOpenCheck() alt="" src="edit.gif" 
      name=imgCheckUrl></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT face=新細明體 size=2>廣告價格 
<asp:textbox id=tbxAdAmt runat="server" Width="60px" Font-Size="X-Small" AutoPostBack="True">0</asp:textbox></FONT></TD>
    <TD><FONT face=新細明體><FONT size=2>設計價格 </FONT>
<asp:textbox id=tbxDesAmt runat="server" Width="60px" Font-Size="X-Small" AutoPostBack="True">0</asp:textbox></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT face=新細明體 size=2>換稿費用 
<asp:textbox id=tbxChgAmt runat="server" Width="60px" Font-Size="X-Small" AutoPostBack="True">0</asp:textbox></FONT></TD>
    <TD><FONT size=2>發票金額</FONT><FONT size=3> </FONT>
<asp:textbox id=tbxInvAmt runat="server" Width="60px" BackColor="#E0E0E0" Font-Size="X-Small" ReadOnly="True">0</asp:textbox></TD></TR>
  <TR>
    <TD colSpan=2><FONT face=新細明體 size=2>備註</FONT> 
<asp:textbox id=tbxRemark runat="server" Font-Size="X-Small"></asp:textbox></TD></TR></TABLE></asp:panel><asp:label id=lblTitle runat="server" ForeColor="Red">00xx的廣告剩餘空間表</asp:label>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR vAlign=top>
    <TD><asp:datagrid id=DataGrid1 runat="server" BorderColor="Green" AutoGenerateColumns="False" BackColor="LightCyan" Font-Size="XX-Small" Font-Names="Verdana" CellPadding="2" AllowPaging="True" PageSize="15">
<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="SteelBlue">
</HeaderStyle>

<PagerStyle HorizontalAlign="Right" Mode="NumericPages">
</PagerStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="cnt_date" HeaderText="日期"></asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h0" HeaderText="正中">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h1" HeaderText="右1">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h2" HeaderText="右2">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h3" HeaderText="右3">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h4" HeaderText="右4">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w1" HeaderText="右文1">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w2" HeaderText="右文2">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w3" HeaderText="右文3">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w4" HeaderText="右文4">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w5" HeaderText="右文5">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w6" HeaderText="右文6">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid></TD>
    <TD width=10><FONT face=新細明體 
      ></FONT></TD>
    <TD><FONT face=新細明體>最早參考資料日期 <asp:calendar id=calCntView runat="server" BorderColor="White" BorderWidth="1px" ForeColor="Black" BackColor="LemonChiffon" Font-Size="9pt" Font-Names="Verdana" NextPrevFormat="FullMonth" CellPadding="0">
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
</asp:calendar></FONT></TD></TR></TABLE><BR></FONT><asp:button id=btnSave runat="server" Text="儲存"></asp:button><asp:button id=btnDoModify runat="server" Text="儲存修改"></asp:button><FONT 
face=新細明體>&nbsp;&nbsp;&nbsp; <INPUT id=btnClose onclick='doClose(<% Response.Write("\""+Request.QueryString["Act"]+"\""); %>)' type=button value=關閉或取消 name=btnClose> 
</FONT><FONT size=2></FONT><INPUT id=hidOldContNo 
type=hidden name=hidOldContNo runat="server"> 
<asp:Literal id=litAlert runat="server"></asp:Literal></FORM>
<SCRIPT language=javascript>
function doOpenAddIM(custno, new_contno, old_contno)
{

	/* 原來在img裡面的event onclick='doOpenAddIM(<% Response.Write(Request.QueryString["CustNo"]); %>, <% Response.Write(Request.QueryString["NewContNo"]); %>, <% Response.Write(Request.QueryString["OldContNo"]); %>)' */
	window.open("AddInvMfr.aspx?CustNo=" + custno + "&NewContNo=" + new_contno + "&OldContNo=" + old_contno , "Poping", "toolbar=no,menubar=no,width=800,height=600", false);
}

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

function doOpenCheck()
{
	var contno = document.AdPrePublish.hidOldContNo.value;
	
	if (contno == "" || contno == "undefined" || contno=="0")
	{
		alert("無舊合約資料可供參考");
	}
	else
	{
		window.showModalDialog("AdShowOldFile.aspx?ContNo="+contno, "", "dialogHeight:400px;dialogWidth:400px;center:yes;scroll:yes;status:no;help:no;resizable=yes");
	}
}
</SCRIPT>



	
  </body>
</HTML>
