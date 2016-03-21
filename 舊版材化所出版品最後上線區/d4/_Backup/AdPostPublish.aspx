<%@ Page language="c#" Codebehind="AdPostPublish.aspx.cs" Src="AdPostPublish.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdPostPublish" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    	<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body vLink=blue aLink=blue>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
	
    <form id="AdPostPublish" method="post" runat="server" enctype="multipart/form-data">
<FONT 
face=新細明體></FONT><FONT face=新細明體>
<asp:label id=lblStep0 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">挑選合約中要落版的廣告</asp:label><BR>
<asp:DataGrid id=dgdAdrIm runat="server" BackColor="#E7EBFF" Font-Size="X-Small" Font-Names="Times New Roman" AutoGenerateColumns="False" CellPadding="1">
<HeaderStyle ForeColor="Black" BackColor="#BFCFF0">
</HeaderStyle>

<SelectedItemStyle BackColor="DarkSeaGreen">
</SelectedItemStyle>

<Columns>
<asp:ButtonColumn Text="選取" CommandName="Select"></asp:ButtonColumn>
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
<asp:Label id=lblFgFixAdNm runat="server" Font-Size="X-Small" Text='<%# GetFgFixAdNm(DataBinder.Eval(Container.DataItem, "adr_fgfixad")) %>'></asp:Label></FONT>
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
<asp:BoundColumn Visible="False" DataField="adr_adamt" HeaderText="廣告價格"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_desamt" HeaderText="設計價格"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_chgamt" HeaderText="換稿費用"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_navurl" HeaderText="廣告連結"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_remark" HeaderText="備註"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_imseq" HeaderText="adr_imseq"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_fgfixad" HeaderText="adr_fgfixad"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_fggot" HeaderText="adr_fggot"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_drafttp" HeaderText="adr_drafttp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_urltp" HeaderText="adr_urltp"></asp:BoundColumn>
</Columns>
</asp:DataGrid><BR></FONT><asp:label id=lblStep1 runat="server" Font-Size="X-Small" BackColor="SteelBlue" Width="100%" ForeColor="White">參考基本資料</asp:label>
<TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 bgColor=lightcyan>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>合約編號</FONT> <asp:textbox id=tbxContNo runat="server" Font-Size="XX-Small" BackColor="Silver" size="6" ReadOnly="True"></asp:textbox></TD>
    <TD><FONT size=2>發票廠商 
<asp:dropdownlist id=ddlInvMfr runat="server" Enabled="False" Font-Size="X-Small"></asp:dropdownlist></FONT></TD>
    <TD colspan=2><FONT size=2>廣告連結</FONT> 
<asp:textbox id=tbxNavUrl runat="server" Font-Size="X-Small">http://</asp:textbox>
<asp:requiredfieldvalidator id=RequiredFieldValidator2 runat="server" Font-Size="XX-Small" ControlToValidate="tbxNavUrl" ErrorMessage="不可空白"></asp:requiredfieldvalidator></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>廣告價格 </FONT>
<asp:textbox id=tbxAdAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></TD>
    <TD><FONT size=2>發票金額<FONT size=3> 
      </FONT>
<asp:textbox id=tbxInvAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></FONT></TD>
    <TD colspan=2><FONT face=新細明體><FONT 
      size=2>廣告標語</FONT><FONT size=3> </FONT>
<asp:textbox id=tbxAltText runat="server" Font-Size="X-Small"></asp:textbox>
<asp:requiredfieldvalidator id=RequiredFieldValidator1 runat="server" Font-Size="XX-Small" ControlToValidate="tbxAltText" ErrorMessage="不可空白"></asp:requiredfieldvalidator></FONT></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>設計價格 </FONT>
<asp:textbox id=tbxDesAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></TD>
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
    <TD colspan=2 rowspan=5><FONT size=2><FONT face=新細明體>查詢客戶舊廣告資料</FONT><IMG onclick="doOpenCheck()" alt="" src="edit.gif" 
  name=imgCheckUrl></FONT></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>換稿費用 </FONT>
<asp:textbox id=tbxChgAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></TD>
    <TD><FONT face=新細明體 size=2>開始日期 
<asp:textbox id=tbxBeginDate runat="server" Width="70px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT 
      size=2>到稿註記</FONT><FONT size=3> </FONT>
<asp:dropdownlist id=ddlFgGot runat="server" Font-Size="X-Small" Enabled="False">
<asp:ListItem Value="1" Selected="True">是</asp:ListItem>
<asp:ListItem Value="0">否</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT face=新細明體><FONT 
      size=2>結束日期 </FONT>
<asp:textbox id=tbxEndDate runat="server" Width="70px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>廣告範圍 </FONT>
<asp:dropdownlist id=ddlAdCate runat="server" Font-Size="X-Small" AutoPostBack="True" Enabled="False">
<asp:ListItem Value="M">首頁</asp:ListItem>
<asp:ListItem Value="I">內頁</asp:ListItem>
<asp:ListItem Value="N">奈米</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT size=2>播放方式</FONT> 
<asp:dropdownlist id=ddlFgFixAd runat="server" Font-Size="X-Small" Enabled="False">
<asp:ListItem Value="0" Selected="True">輪播</asp:ListItem>
<asp:ListItem Value="1">定播</asp:ListItem>
</asp:dropdownlist><FONT size=2>機率</FONT> 
<asp:textbox id=tbxImpression runat="server" Font-Size="X-Small" size="1" ReadOnly="True" BackColor="Silver"></asp:textbox></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT face=新細明體 size=2>稿件類別</FONT></TD>
    <TD><FONT face=新細明體>
<asp:RadioButtonList id=rblDraftTp runat="server" Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow">
<asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
<asp:ListItem Value="2">新稿</asp:ListItem>
<asp:ListItem Value="3">改稿</asp:ListItem>
</asp:RadioButtonList></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT face=新細明體 size=2>URL類別</FONT></TD>
    <TD>
<asp:RadioButtonList id=rblUrlTp runat="server" Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow">
<asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
<asp:ListItem Value="2">新稿</asp:ListItem>
<asp:ListItem Value="3">改稿</asp:ListItem>
</asp:RadioButtonList></TD></TR>
  <TR>
    <TD colSpan=2><FONT face=新細明體 
      size=2>備註</FONT>
<asp:textbox id=tbxRemark runat="server" Font-Size="X-Small"></asp:textbox></TD>
    </TR></TABLE><FONT 
size=2><FONT 
color=red><FONT size=2></FONT></FONT></FONT><FONT 
size=2>
<asp:label id=lblStep2 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">上傳圖檔</asp:label><BR>
<input type=file runat=server id=fileAdImage NAME="fileAdImage"><BR></FONT><FONT 
size=2 color=#ff0000>請先確定每個資料都填寫無誤<BR></FONT> 
<asp:button id=btnSave runat="server" Text="儲存落版"></asp:button><input type=hidden id=hidOldContNo name=hidOldContNo runat=server>
<INPUT id=hidDateTarget type=hidden name=hidDataTarget 
      runat="server"> 
<INPUT id=hidCustNo type=hidden 
name=hidCustNo runat="server">
     </form>
	<!-- 頁尾 Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>
<script language=javascript>
function doOpenCheck()
{
	var custno = document.AdPostPublish.hidCustNo.value;
	
	if (custno == "" || custno == "undefined" || custno == "0")
	{
		alert("無該客戶舊合約資料可供參考");
	}
	else
	{
		window.open("AdQueryOldData.aspx?CustNo="+custno, "", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
	}
}
</script>
	
  </body>
</HTML>
