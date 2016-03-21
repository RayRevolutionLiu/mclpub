<%@ Page language="c#" Codebehind="ContModify.aspx.cs" Src="ContModify.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.ContModify" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
    	<!-- CSS --><LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
<body>
		<!-- 頁首 Header --><kw:header id=Header runat="server">
		</kw:header>
<form id=ContModify method=post runat="server"><FONT 
face=新細明體>
<DIV align=center>
<TABLE cellSpacing=0 cellPadding=2 width="90%" align=center bgColor=#bfcff0 
border=0>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >廠商及客戶資料</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >公司名稱(統編)：</FONT></P></TD>
          <TD width="30%">
            <P align=left><asp:label id=lblMfrData runat="server" Font-Size="X-Small">公司名稱</asp:label><FONT 
            size=2>( <asp:label id=lblMfrNo runat="server">00000000</asp:label>)</FONT></P></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >詳細資料：</FONT></P></TD>
          <TD width="30%">
            <P align=left><IMG onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt=廠商詳細資料 src="edit.gif" name=imgMfrDetail ></P></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >公司負責人姓名(職稱)：</FONT></P></TD>
          <TD>
            <P align=left><asp:label id=lblRespData runat="server" Font-Size="X-Small">負責人(職稱)</asp:label></P></TD>
          <TD>
            <P align=right><FONT size=2 
            >公司電話(傳真)：</FONT></P></TD>
          <TD>
            <P align=left><asp:label id=lblMfrTel runat="server" Font-Size="X-Small">00-00000000(Fax: 00-00000000)</asp:label></P></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >客戶姓名(編號)：</FONT></P></TD>
          <TD><asp:label id=lblCustData runat="server" Font-Size="X-Small">客戶姓名</asp:label><FONT 
            size=2>( <asp:label id=lblCustNo runat="server">000000</asp:label>)</FONT></TD>
          <TD>
            <P align=right><FONT size=2 
            >詳細資料：</FONT></P></TD>
          <TD><IMG onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt=客戶詳細資料 src="edit.gif" name=imgCustDetail ></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >合約書基本資料</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >簽約日期：</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxSignDate runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><IMG onclick='javascript:pick_date("tbxSignDate", "tbxSDate", "tbxEDate");return false;' alt="" src="calendar01.gif" name=imgSignDate ></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >合約編號：</FONT></P></TD>
          <TD width="30%"><asp:label id=lblContNo runat="server" Font-Size="X-Small">000000</asp:label></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >合約類別：</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlContTp runat="server" Font-Size="XX-Small">
<asp:ListItem Value="01" Selected="True">一般合約</asp:ListItem>
<asp:ListItem Value="09">推廣合約</asp:ListItem>
</asp:dropdownlist></TD>
          <TD>
            <P align=right><FONT size=2 
            ></FONT>&nbsp;</P></TD>
          <TD></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >合約起迄日：</FONT></P></TD>
          <TD><asp:textbox id=tbxSDate runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox>～ 
<asp:textbox id=tbxEDate runat="server" Font-Size="XX-Small" Width="80px" AutoPostBack="True"></asp:textbox><asp:label id=lblDayCount runat="server" Font-Size="X-Small"></asp:label></TD>
          <TD>
            <P align=right><FONT size=2 
            >承辦業務員：</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlEmpData runat="server" Font-Size="XX-Small"></asp:dropdownlist></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >一次付清註記：</FONT></P></TD>
          <TD><asp:radiobuttonlist id=rblPayOnce runat="server" Font-Size="XX-Small" RepeatDirection="Horizontal">
<asp:ListItem Value="1">是</asp:ListItem>
<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
</asp:radiobuttonlist></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >合約備註：</FONT></P></TD>
          <TD><asp:textbox id=tbxAdRemark runat="server" Font-Size="XX-Small" Width="250px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >特別註記：</FONT></P></TD>
          <TD><asp:textbox id=tbxAdSpRemark runat="server" Font-Size="XX-Small" Width="250px"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >合約書細節</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >刊登次數：</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxPubTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            size=2>剩餘： </FONT><asp:label id=lblUnPubTm runat="server" Font-Size="X-Small"></asp:label></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >合約總金額：</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxTotAmt runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD></TR>
        <TR>
          <TD><FONT size=2>
            <P align=right><FONT size=2 
            >贈送次數：</FONT></P></FONT></TD>
          <TD><asp:textbox id=tbxFreeTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >優惠折數：</FONT></P></TD>
          <TD><asp:textbox id=tbxDisc runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            color=red size=2>(例: 0.8表示八折)</FONT></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >總圖檔製稿次數：</FONT></P></TD>
          <TD><asp:textbox id=tbxTotImgTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            size=2>剩餘： <asp:label id=lblUnImgTm runat="server"></asp:label></FONT></TD>
          <TD>
            <P align=right><FONT size=2 
            >已開立發票金額：</FONT></P></TD>
          <TD><FONT size=2><asp:label id=lblInvedAmt runat="server"></asp:label>&nbsp; 
            剩餘： <asp:label id=lblUnInvedAmt runat="server"></asp:label></FONT></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >總製網頁稿次數：</FONT></P></TD>
          <TD><asp:textbox id=tbxTotUrlTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            size=2>剩餘： <asp:label id=lblUnUrlTm runat="server"></asp:label></FONT></TD>
          <TD>
            <P align=right><FONT size=2 
            >以繳款金額：</FONT></P></TD>
          <TD><FONT size=2><asp:label id=lblPaidAmt runat="server"></asp:label></FONT></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >廣告聯絡人資料</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >廣告聯絡人姓名：</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxAuNm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            ></FONT>&nbsp;</P></TD>
          <TD width="30%"></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >電話：</FONT></P></TD>
          <TD><asp:textbox id=tbxAuTel runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >傳真：</FONT></P></TD>
          <TD><asp:textbox id=tbxAuFax runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >手機：</FONT></P></TD>
          <TD><asp:textbox id=tbxAuCell runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >Email：</FONT></P></TD>
          <TD><asp:textbox id=tbxAuEmail runat="server" Font-Size="XX-Small" Width="150px"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD style="HEIGHT: 24px" bgColor=#214389><table><tr><td><FONT 
      color=white size=2>其他資料</FONT></td><td>
<asp:Panel id=pnlMisc runat="server"><IMG id=imgMisc onclick='doOpenMisc(<% Response.Write("\""+lblContNo.Text+"\""); %>)' alt=新增 src="new.gif" name=imgMisc> <asp:imagebutton id=imgRefMisc runat="server" ImageUrl="refresh.gif" CausesValidation="False"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%" colSpan=4><FONT color=red 
            size=2 
            >由此填入廣告推廣內文、期限、產品設備內文、材料特性、應用產業等相關資料</FONT></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><table><tr><td><FONT color=white size=2 
      >發票廠商收件人資料</FONT></td><td>
<asp:Panel id=pnlIM runat="server"><IMG id=imgAddIM  alt="" src="new.gif" name=imgAddIM onclick='doOpenInvMfr(<% Response.Write("\""+hidCustNo.Value+"\""); %> , <% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\""+hidOldContNo.Value+"\""); %>)'><asp:imagebutton id=imbRefIM runat="server" ImageUrl="refresh.gif" CausesValidation="False"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD><asp:datagrid id=DataGridIM runat="server" Font-Size="X-Small" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="SlateBlue">
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
<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
</Columns>
</asp:datagrid></TD></TR>
  <TR>
    <TD bgColor=#214389><table><tr><td><FONT color=white size=2 
      >雜誌收件人及贈書資料</FONT></td><td>
<asp:Panel id=pnlFreebk runat="server"><IMG id=imgAddFreeBk alt="" src="new.gif" name=imgAddFreeBk onclick='doOpenFreeBk(<% Response.Write("\""+hidCustNo.Value+"\""); %>, <% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\""+hidOldContNo.Value+"\""); %>)'><asp:imagebutton id=imbRefFreeBk runat="server" ImageUrl="refresh.gif" CausesValidation="False"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD><asp:datagrid id=DataGridFreeBk runat="server" Font-Size="X-Small" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="SlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="贈書項次"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="贈書起月"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="贈書迄月"></asp:BoundColumn>
<asp:BoundColumn DataField="fc_nm" HeaderText="書籍"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="郵寄類別">
<ItemTemplate>
<asp:Label id=lblMtpNm runat="server" Font-Size="X-Small" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
</Columns>
</asp:datagrid></TD></TR>
  <TR>
    <TD bgColor=#214389><table><tr><td><FONT color=white size=2 
      >網路廣告資料</FONT></td><td>
<asp:Panel id=pblAdr runat="server"><IMG id=imgAddAdr onclick='doOpenAdr(<% Response.Write("\""+lblContNo.Text+"\""); %>)' alt="" src="new.gif" name=imgAddAdr> <asp:imagebutton id=imbRefAdr runat="server" ImageUrl="refresh.gif"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD><asp:datagrid id=dgdAdr runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#BFCFF0">
<HeaderStyle ForeColor="White" BackColor="SlateBlue">
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
<asp:BoundColumn Visible="False" DataField="adr_drafttp" HeaderText="drafttp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_urltp" HeaderText="urltp"></asp:BoundColumn>
</Columns>
</asp:datagrid></TD></TR></TABLE></DIV></FONT>
<P align=center><asp:button id=btnSaveCont runat="server" Text="儲存修改"></asp:button><asp:button id=btnDiscardCont runat="server" BackColor="Red" Text="註銷合約" ForeColor="White" Font-Bold="True"></asp:button><asp:button id=btnCloseCont runat="server" BackColor="Blue" Text="合約結案" ForeColor="White" Font-Bold="True"></asp:button><asp:button id=btnBack runat="server" Text="取消回首頁"></asp:button><INPUT 
id=hidOldContNo type=hidden name=hidOldContNo 
runat="server"> <INPUT id=hidCustNo type=hidden name=hidCustNo runat="server"> <input id=hidIMCount type=hidden 
name=hidIMCount runat="server"></P></form>
<script language=javascript>
		<!--
		// cal按鈕的 coding: 抓系統日期
		function pick_date(theField, theField1, theField2)
		{
			// 簽約日期
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			//alert("vreturn= " + vreturn);
			
			// 合約起日
			
			var vreturn1 = vreturn;
			//alert("vreturn1= " + vreturn1);
			
			// 合約迄日

			//var vreturn2 = vreturn;
			//alert("vreturn2= " + vreturn2);
			
			window.document.all(theField).value=vreturn;
			window.document.all(theField1).value=vreturn1;
			//window.document.all(theField2).value=vreturn2;
			//return true;
		}
		//-->
		</script>

<SCRIPT language=javascript>
function doOpenInvMfr(custno, new_contno, old_contno)
{
	//window.open("AddInvMfr.aspx", "Poping", "toolbar=no,menubar=no,width=320,height=200", false);
	window.open("AddInvMfr.aspx?Act=Mod&CustNo=" + custno + "&NewContNo=" + new_contno + "&OldContNo=" + old_contno , "Poping", "toolbar=no,menubar=no,width=800,scrollbars=yes,resizable=yes,height=600", false);
}

function doOpenAdr(new_contno)
{
	var strQS = "Act=Mod&NewContNo=" + new_contno+ "&OldContNo=" + document.all("hidOldContNo").value;
	strQS += "&ContTp=" + document.all("ddlContTp").value;
	strQS += "&SignDate=" + document.all("tbxSignDate").value;
	strQS += "&SDate=" + document.all("tbxSDate").value;
	strQS += "&EDate=" + document.all("tbxEDate").value;
	strQS += "&PubTm=" + document.all("tbxPubTm").value;
	strQS += "&FreeTm=" + document.all("tbxFreeTm").value;
	strQS += "&Disc=" + document.all("tbxDisc").value;
	strQS += "&ImgTm=" + document.all("tbxTotImgTm").value;
	strQS += "&UrlTm=" + document.all("tbxTotUrlTm").value;
	//alert(strQS);
	//alert(document.all("hidIMCount").value);		
	if (document.all("hidIMCount").value > "0")
	{
		window.open("AdPrePublish.aspx?" + strQS, "Adr", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
		//window.showModalDialog("AdPrePublish.aspx?" + strQS, "", "dialogHeight:640px;dialogWidth:480px;center:yes;scroll:yes;status:no;help:no;resizable=yes");		
	}
	else if (document.all("ddlContTp").options(document.all("ddlContTp").selectedIndex).value=="09")
	{
		//推廣合約
		window.open("AdPrePublish.aspx?" + strQS, "Adr", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
	}	
	else
	{
		alert("請先輸入發票廠商資料");
	}
}

function doOpenFreeBk(custno, new_contno, old_contno)
{
	window.open("AddFreeBk.aspx?Act=Mod&CustNo=" + custno + "&NewContNo=" + new_contno + "&OldContNo=" + old_contno , "Poping", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
}

function doOpenMisc(new_contno)
{
	//window.showModalDialog("ContMisc.aspx", "", "dialogHeight:480px;dialogWidth:640px;center:yes;scroll:yes;status:no;help:no;resizable=yes");
	window.open("ContMisc.aspx?ContNo="+new_contno, "Poping", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
}

</SCRIPT>


	<!-- 頁尾 Footer --><kw:footer id=Footer runat="server">
	</kw:footer>

  </body>
</HTML>
